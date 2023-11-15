using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TriangulArt {
	class Objet {
		const int CONST_Z = 50000;                   // Constante d'affichage 3D->2D

		public List<Vertex> lstVertex = new List<Vertex>();
		public List<Face> lstFace = new List<Face>();

		//
		// Calcule les paramètres (centre, taille) d'un objet
		//
		private void CalcParamObjet(Vertex centre, Vertex taille) {
			Vertex MinPt = new Vertex(1000000.0, 1000000.0, 1000000.0);
			Vertex MaxPt = new Vertex(-1000000.0, -1000000.0, -1000000.0);
			foreach (Vertex v in lstVertex) {
				if (MinPt.X > v.X)
					MinPt.X = v.X;

				if (MinPt.Y > v.Y)
					MinPt.Y = v.Y;

				if (MinPt.Z > v.Z)
					MinPt.Z = v.Z;

				if (MaxPt.X < v.X)
					MaxPt.X = v.X;

				if (MaxPt.Y < v.Y)
					MaxPt.Y = v.Y;

				if (MaxPt.Z < v.Z)
					MaxPt.Z = v.Z;
			}
			taille.X = MaxPt.X - MinPt.X;
			taille.Y = MaxPt.Y - MinPt.Y;
			taille.Z = MaxPt.Z - MinPt.Z;
			centre.X = MinPt.X + taille.X / 2.0;
			centre.Y = MinPt.Y + taille.Y / 2.0;
			centre.Z = MinPt.Z + taille.Z / 2.0;
		}

		//
		// Modifie les paramètres (centre, taille) d'un objet
		//
		private void SetParamObjet(Vertex centre, Vertex taille) {
			foreach (Vertex v in lstVertex) {
				v.X = (v.X + centre.X) * taille.X;
				v.Y = (v.Y + centre.Y) * taille.Y;
				v.Z = (v.Z + centre.Z) * taille.Z;
			}
		}

		//
		// Recentre un objet
		//
		private void RecentrePoints() {
			Vertex Taille = new Vertex(0, 0, 0), Centre = new Vertex(0, 0, 0);
			CalcParamObjet(Centre, Taille);
			foreach (Vertex v in lstVertex) {
				v.X -= Centre.X;
				v.Y -= Centre.Y;
				v.Z -= Centre.Z;
			}
		}

		//
		// Calcule les coordonnées de chaque points composant l'objet pour l'affichage
		// à l'écran, en fonction des paramètres de position, angle, zoom
		// Affichage de l'objet complêt en fonction des paramètres choisis
		//
		public void DrawObj(DirectBitmap bm, int posx, int posy, int zoomx, int zoomy, int angx, int angy, int angz, int numFace, int numPoint, List<Triangle> lstTri = null, DirectBitmap bmCalc = null) {
			double xSin = Math.Sin(angx * Math.PI / 180.0);
			double xCos = Math.Cos(angx * Math.PI / 180.0);
			double ySin = Math.Sin(angy * Math.PI / 180.0);
			double yCos = Math.Cos(angy * Math.PI / 180.0);
			double zSin = Math.Sin(angz * Math.PI / 180.0);
			double zCos = Math.Cos(angz * Math.PI / 180.0);
			foreach (Vertex v in lstVertex) {
				double yt = (v.Y * xCos - v.Z * xSin);
				double zt = (v.Y * xSin + v.Z * xCos);
				double xt = (v.X * yCos - zt * ySin);
				double z = CONST_Z + (v.X * ySin + zt * yCos);
				v.SetPoint(posx + (int)(((xt * zCos - yt * zSin) * zoomx) / z), posy + (int)(((xt * zSin + yt * zCos) * zoomy) / z), (int)z);
			}

			// Tri des faces par ordre des Z
			List<Face> lstDraw = new List<Face>();
			for (int i = 0; i < lstFace.Count; i++)
				lstDraw.Add(lstFace[i]);

			lstDraw.Sort(delegate (Face p1, Face p2) {
				int cmp = (p1.GetA.Pz + p1.GetB.Pz + p1.GetC.Pz) - (p2.GetA.Pz + p2.GetB.Pz + p2.GetC.Pz);
				return cmp != 0 ? cmp : p1.Num - p2.Num;
			});

			// Affiche les triangles
			for (int i = 0; i < lstDraw.Count; i++) {
				Face f = lstDraw[i];
				Triangle t = new Triangle(f.GetA.Px, f.GetA.Py, f.GetB.Px, f.GetB.Py, f.GetC.Px, f.GetC.Py, f.Color.GetColorArgb, bm);
				t.FillTriangle(bm, false, bmCalc, i);
				if (lstTri != null)
					lstTri.Add(t);      // Ajoute dans la liste des triangles si passée en paramètre
			}

			// Affiche la face sélectionnée
			if (numFace != -1) {
				Face f = lstFace[numFace];
				Triangle t = new Triangle(f.GetA.Px, f.GetA.Py, f.GetB.Px, f.GetB.Py, f.GetC.Px, f.GetC.Py, 0, bm);
				t.FillTriangle(bm, true);
			}

			// Affiche le point sélectionné
			if (numPoint > -1)
				for (int x = -1; x < 2; x++)
					for (int y = -1; y < 2; y++)
						bm.SetPixel(x + lstVertex[numPoint].Px, y + lstVertex[numPoint].Py, new RvbColor(0, 0, 0));
		}

		//
		// Lecture et construction objet
		//
		public void ReadObject(string fileName) {
			try {
				StreamReader rd = new StreamReader(fileName);
				lstFace.Clear();
				lstVertex.Clear();
				string l;
				int numFace = 0;
				do {
					l = rd.ReadLine();
					if (l != null) {
						l = l.ToUpper();
						if (l.Contains("MATERIAL:") && lstFace.Count > 0) {
							// Lecture couleurs R,V,B de la face
							int pr = l.LastIndexOf('R');
							int pg = l.LastIndexOf('G');
							int pb = l.LastIndexOf('B');
							if (pr > 0 && pg > 0 && pb > 0) {
								int end = l.Substring(pr + 1).Trim().IndexOf(' ');
								if (end > -1) {
									int r = Utils.ConvertToInt(l.Substring(pr + 1, end + 1));
									end = l.Substring(pg + 2).Trim().IndexOf(' ');
									int v = Utils.ConvertToInt(l.Substring(pg + 1, end + 1));
									int b = Utils.ConvertToInt(l.Substring(pb + 1));
									lstFace[lstFace.Count - 1].Color = new RvbColor((byte)r, (byte)v, (byte)b);
								}
								else
									lstFace[lstFace.Count - 1].Color = new RvbColor(0);
							}
						}

						if (l.Contains("VERTEX ")) {
							// Ajout Vertex
							int px = l.IndexOf("X:");
							int py = l.IndexOf("Y:");
							int pz = l.IndexOf("Z:");
							if (px > 0 && py > 0 && pz > 0) {
								string newl = l.Substring(px + 2).Trim();
								int end = newl.IndexOf(' ');
								double x = Convert.ToDouble(newl.Substring(0, end).Replace('.', ','));
								newl = l.Substring(py + 2).Trim();
								end = newl.IndexOf(' ');
								double y = Convert.ToDouble(newl.Substring(0, end).Replace('.', ','));
								newl = l.Substring(pz + 2).Trim();
								end = newl.IndexOf(' ');
								double z = Convert.ToDouble(newl.Substring(0, end > -1 ? end + 1 : newl.Length).Replace('.', ','));
								lstVertex.Add(new Vertex(x, y, z));
							}
						}
						if (l.Contains("FACE ")) {
							// Ajout Face
							int pa = l.IndexOf("A:");
							int pb = l.IndexOf("B:");
							int pc = l.IndexOf("C:");
							if (pa > 0 && pb > 0 && pc > 0) {
								string newl = l.Substring(pa + 2).Trim();
								int end = newl.IndexOf(' ');
								int a = Utils.ConvertToInt(newl.Substring(0, end + 1));
								newl = l.Substring(pb + 2).Trim();
								end = newl.IndexOf(' ');
								int b = Utils.ConvertToInt(newl.Substring(0, end + 1));
								newl = l.Substring(pc + 2).Trim();
								end = newl.IndexOf(' ');
								int c = Utils.ConvertToInt(newl.Substring(0, end > -1 ? end + 1 : newl.Length));
								if (a < lstVertex.Count && b < lstVertex.Count && c < lstVertex.Count) {
									Face f = new Face(numFace++, lstVertex[a], lstVertex[b], lstVertex[c]);
									lstFace.Add(f);
								}
							}
						}
					}
				}
				while (l != null);
				rd.Close();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, "Erreur lecture objet.");
			}
		}
	}
}
