﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TriangulArt {
	[Serializable]
	public class Objet {
		const int CONST_Z = 50000;		// Constante d'affichage 3D->2D

		public List<Vertex> lstVertex = new List<Vertex>();
		public List<Face> lstFace = new List<Face>();
		public string nom = "";
		public Objet() {
		}

		// Raz objet
		public void Clear() {
			lstFace.Clear();
			lstVertex.Clear();
		}

		//
		// Calcule les paramètres (centre, taille) d'un objet
		//
		private void CalcParamObjet(Vertex centre, Vertex taille) {
			Vertex MinPt = new Vertex(1000000.0, 1000000.0, 1000000.0);
			Vertex MaxPt = new Vertex(-1000000.0, -1000000.0, -1000000.0);
			foreach (Vertex v in lstVertex) {
				if (MinPt.x > v.x)
					MinPt.x = v.x;

				if (MinPt.y > v.y)
					MinPt.y = v.y;

				if (MinPt.z > v.z)
					MinPt.z = v.z;

				if (MaxPt.x < v.x)
					MaxPt.x = v.x;

				if (MaxPt.y < v.y)
					MaxPt.y = v.y;

				if (MaxPt.z < v.z)
					MaxPt.z = v.z;
			}
			taille.x = MaxPt.x - MinPt.x;
			taille.y = MaxPt.y - MinPt.y;
			taille.z = MaxPt.z - MinPt.z;
			centre.x = MinPt.x + taille.x / 2.0;
			centre.y = MinPt.y + taille.y / 2.0;
			centre.z = MinPt.z + taille.z / 2.0;
		}

		//
		// Modifie les paramètres (centre, taille) d'un objet
		//
		private void SetParamObjet(Vertex centre, Vertex taille) {
			foreach (Vertex v in lstVertex) {
				v.x = (v.x + centre.x) * taille.x;
				v.y = (v.y + centre.y) * taille.y;
				v.z = (v.z + centre.z) * taille.z;
			}
		}

		//
		// Recentre un objet
		//
		private void RecentrePoints() {
			Vertex Taille = new Vertex(0, 0, 0), Centre = new Vertex(0, 0, 0);
			CalcParamObjet(Centre, Taille);
			foreach (Vertex v in lstVertex) {
				v.x -= Centre.x;
				v.y -= Centre.y;
				v.z -= Centre.z;
			}
		}

		//
		// Calcule les coordonnées de chaque points composant l'objet pour l'affichage
		// à l'écran, en fonction des paramètres de position, angle, zoom
		// Affichage de l'objet complêt en fonction des paramètres choisis
		//
		public void DrawObj(DirectBitmap bm, double posx, double posy, double zoomx, double zoomy, double angx, double angy, double angz, int numFace, int numPoint, List<Triangle> lstTri = null, DirectBitmap bmCalc = null) {
			double xSin = Math.Sin(angx * Math.PI / 180.0);
			double xCos = Math.Cos(angx * Math.PI / 180.0);
			double ySin = Math.Sin(angy * Math.PI / 180.0);
			double yCos = Math.Cos(angy * Math.PI / 180.0);
			double zSin = Math.Sin(angz * Math.PI / 180.0);
			double zCos = Math.Cos(angz * Math.PI / 180.0);
			foreach (Vertex v in lstVertex) {
				double yt = (v.y * xCos - v.z * xSin);
				double zt = (v.y * xSin + v.z * xCos);
				double xt = (v.x * yCos - zt * ySin);
				double z = CONST_Z + (v.x * ySin + zt * yCos);
				v.SetPoint(posx + (((xt * zCos - yt * zSin) * zoomx) / z), posy - (((xt * zSin + yt * zCos) * zoomy) / z), z);
			}

			// Tri des faces par ordre des Z
			List<Face> lstDraw = new List<Face>();
			for (int i = 0; i < lstFace.Count; i++)
				lstDraw.Add(lstFace[i]);

			lstDraw.Sort(delegate (Face p1, Face p2) {
				double cmp = (lstVertex[p1.a].pz + lstVertex[p1.b].pz + lstVertex[p1.c].pz) - (lstVertex[p2.a].pz + lstVertex[p2.b].pz + lstVertex[p2.c].pz);
				return cmp != 0 ? (int)cmp : p1.num - p2.num;
			});

			// Affiche les triangles
			for (int i = 0; i < lstDraw.Count; i++) {
				Face f = lstDraw[i];
				Triangle t = new Triangle((int)lstVertex[f.a].px, (int)lstVertex[f.a].py, (int)lstVertex[f.b].px, (int)lstVertex[f.b].py, (int)lstVertex[f.c].px, (int)lstVertex[f.c].py, f.pen, bm);
				t.FillTriangle(bm, false, bmCalc, i);
				if (lstTri != null)
					lstTri.Add(t);      // Ajoute dans la liste des triangles si passée en paramètre
			}

			// Affiche la face sélectionnée
			if (numFace != -1) {
				Face f = lstFace[numFace];
				Triangle t = new Triangle((int)lstVertex[f.a].px, (int)lstVertex[f.a].py, (int)lstVertex[f.b].px, (int)lstVertex[f.b].py, (int)lstVertex[f.c].px, (int)lstVertex[f.c].py, 0, bm);
				t.FillTriangle(bm, true);
			}

			// Affiche le point sélectionné
			if (numPoint > -1)
				for (int x = -2; x < 3; x++)
					for (int y = -2; y < 3; y++)
						bm.SetPixel(x + (int)lstVertex[numPoint].px, y + (int)lstVertex[numPoint].py, new RvbColor((byte)(64 - x * 63), (byte)(64 + y * 63), (byte)((x + y) * 63)));
		}

		private double DecodeValue(string l) {
			int p;
			l = l.Trim();
			for (p = 0; p < l.Length; p++) {
				if (!Char.IsDigit(l[p]) && l[p] != ' ' && l[p] != '\t' && l[p] != '.' && l[p] != '-')
					break;
			}
			return Utils.ToDouble(l.Substring(0, p));
		}

		private void AddVertex(string l) {
			// Ajout Vertex
			int px = l.IndexOf("X:");
			int py = l.IndexOf("Y:");
			int pz = l.IndexOf("Z:");
			if (px > 0 && py > 0 && pz > 0) {
				double x = DecodeValue(l.Substring(px + 2));
				double y = DecodeValue(l.Substring(py + 2));
				double z = DecodeValue(l.Substring(pz + 2));
				lstVertex.Add(new Vertex(x, y, z));
			}
		}

		private void AddFace(string l, int offsetVertex, ref int numFace) {
			// Ajout Face
			int pa = l.IndexOf("A:");
			int pb = l.IndexOf("B:");
			int pc = l.IndexOf("C:");
			if (pa > 0 && pb > 0 && pc > 0) {
				string newl = l.Substring(pa + 2).Trim();
				int end = newl.IndexOfAny(new char[] { ' ', '\t' });
				int a = (int)DecodeValue(l.Substring(pa + 2));
				int b = (int)DecodeValue(l.Substring(pb + 2));
				int c = (int)DecodeValue(l.Substring(pc + 2));
				if (a < lstVertex.Count && b < lstVertex.Count && c < lstVertex.Count) {
					Face f = new Face(numFace++, a + offsetVertex, b + offsetVertex, c + offsetVertex);
					lstFace.Add(f);
				}
			}
		}

		private void SetFaceColor(string l, ref int numPen) {
			// Lecture couleurs R,V,B de la face
			int pr = l.LastIndexOf('R');
			int pg = l.LastIndexOf('G');
			int pb = l.LastIndexOf('B');
			if (pr > 0 && pg > 0 && pb > 0) {
				byte r = (byte)DecodeValue(l.Substring(pr + 1));
				byte v = (byte)DecodeValue(l.Substring(pg + 1));
				byte b = (byte)DecodeValue(l.Substring(pb + 1));
				RvbColor faceColor = new RvbColor(r, v, b);
				if (numPen != 0 && PaletteCpc.SetPaletteFromColor(faceColor, numPen))
					numPen--;

				lstFace[lstFace.Count - 1].pen = PaletteCpc.GetNumPen(faceColor);
			}
			else
				lstFace[lstFace.Count - 1].pen = 1;
		}

		//
		// Lecture et construction objet
		//
		public void ReadObject(string fileName, ref int numPen, bool fusion = false) {
			StreamReader rd = null;
			try {
				rd = new StreamReader(fileName);
				if (!fusion) {
					lstFace.Clear();
					lstVertex.Clear();
				}
				string l;
				int offsetVertex = lstVertex.Count;
				int numFace = 0;
				do {
					l = rd.ReadLine();
					if (l != null) {
						l = l.ToUpper();
						if (l.Contains("VERTEX "))
							AddVertex(l);

						if (l.Contains("FACE "))
							AddFace(l, offsetVertex, ref numFace);

						if (l.Contains("MATERIAL:") && lstFace.Count > 0)
							SetFaceColor(l, ref numPen);
					}
				}
				while (l != null);
				nom = Path.GetFileName(fileName);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, "Erreur lecture objet.");
			}
			if (rd != null)
				rd.Close();
		}

		public void SaveObject(string fileName) {
			StreamWriter wr = null;
			try {
				wr = new StreamWriter(fileName);
				wr.WriteLine("Named object : \"Objet généré avec TriangulArt\"");
				wr.WriteLine("Tri - mesh, Vertices: {0}	Faces: {1}", lstVertex.Count, lstFace.Count);
				wr.WriteLine("");
				wr.WriteLine("Vertex list:");
				for (int i = 0; i < lstVertex.Count; i++)
					wr.WriteLine("Vertex {0}:	X:{1}	Y:{2}	Z:{3}", i, lstVertex[i].x, lstVertex[i].y, lstVertex[i].z);

				wr.WriteLine("");
				wr.WriteLine("Face list:");
				for (int i = 0; i < lstFace.Count; i++) {
					Face f = lstFace[i];
					wr.WriteLine("Face {0}:	A:{1}	B:{2}	C:{3}", i, f.a, f.b, f.c);
					RvbColor color = PaletteCpc.GetColorPal(f.pen);
					wr.WriteLine("Material:	r {0}	g {1}	b {2}", color.r, color.v, color.b);
				}
				nom = Path.GetFileName(fileName);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, "Erreur sauvegarde objet.");
			}
			if (wr != null)
				wr.Close();
		}
	}
}
