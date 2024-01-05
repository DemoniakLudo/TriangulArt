using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TriangulArt {
	[Serializable]
	public class Objet {
		const int CONST_Z = 100000;      // Constante d'affichage 3D->2D
		const double CONV = Math.PI / 180;
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
		public void CalcParamObjet(ref Vertex centre, ref Vertex taille) {
			Vertex MinPt = new Vertex(1000000.0, 1000000.0, 1000000.0);
			Vertex MaxPt = new Vertex(-1000000.0, -1000000.0, -1000000.0);
			foreach (Vertex v in lstVertex) {
				MinPt.x = Math.Min(MinPt.x, v.x);
				MinPt.y = Math.Min(MinPt.y, v.y);
				MinPt.z = Math.Min(MinPt.z, v.z);
				MaxPt.x = Math.Max(MaxPt.x, v.x);
				MaxPt.y = Math.Max(MaxPt.y, v.y);
				MaxPt.z = Math.Max(MaxPt.z, v.z);
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
		public void SetParamObjet(Vertex centre, Vertex taille) {
			foreach (Vertex v in lstVertex) {
				v.x = (v.x + centre.x) * taille.x;
				v.y = (v.y + centre.y) * taille.y;
				v.z = (v.z + centre.z) * taille.z;
			}
		}

		public void ModifObject(double posx, double posy) {
			foreach (Vertex v in lstVertex) {
				v.x = v.px - posx;
				v.y = posy - v.py;
				v.z = v.pz - CONST_Z;
			}
		}

		//
		// Recentre un objet
		//
		public void RecentrePoints() {
			Vertex Taille = new Vertex(0, 0, 0), Centre = new Vertex(0, 0, 0);
			CalcParamObjet(ref Centre, ref Taille);
			foreach (Vertex v in lstVertex) {
				v.x -= Centre.x;
				v.y -= Centre.y;
				v.z -= Centre.z;
			}
		}

		public void AddRotateVertex(double x, double y, double ay) {
			lstVertex.Add(new Vertex(x * Math.Cos(ay * CONV), y, x * Math.Sin(ay * CONV)));
		}

		//
		// Calcule les coordonnées de chaque points composant l'objet pour l'affichage
		// à l'écran, en fonction des paramètres de position, angle, zoom
		// Affichage de l'objet complêt en fonction des paramètres choisis
		//
		public void DrawObj(DirectBitmap bm, double posx, double posy, double zoomx, double zoomy, double ax, double ay, double az, int numFace, int numPoint, List<Triangle> lstTri = null, DirectBitmap bmCalc = null) {
			double xxp = Math.Cos(ax * CONV) * Math.Cos(ay * CONV);
			double xyp = Math.Sin(ax * CONV) * Math.Cos(ay * CONV);
			double xzp = Math.Sin(ay * CONV);
			double yxp = Math.Sin(ax * CONV) * Math.Cos(az * CONV) + Math.Cos(ax * CONV) * Math.Sin(ay * CONV) * Math.Sin(az * CONV);
			double yyp = -Math.Cos(ax * CONV) * Math.Cos(az * CONV) + Math.Sin(ax * CONV) * Math.Sin(ay * CONV) * Math.Sin(az * CONV);
			double yzp = -Math.Cos(ay * CONV) * Math.Sin(az * CONV);
			double zxp = Math.Sin(ax * CONV) * Math.Sin(az * CONV) - Math.Cos(ax * CONV) * Math.Sin(ay * CONV) * Math.Cos(az * CONV);
			double zyp = -Math.Cos(ax * CONV) * Math.Sin(az * CONV) - Math.Sin(ax * CONV) * Math.Sin(ay * CONV) * Math.Cos(az * CONV);
			double zzp = Math.Cos(ay * CONV) * Math.Cos(az * CONV);


			double xSin = Math.Sin(ax * CONV);
			double xCos = Math.Cos(ax * CONV);
			double ySin = Math.Sin(ay * CONV);
			double yCos = Math.Cos(ay * CONV);
			double zSin = Math.Sin(az * CONV);
			double zCos = Math.Cos(az * CONV);
			foreach (Vertex v in lstVertex) {
				double xx = v.x * xxp + v.y * xyp + v.z * xzp;
				double yy = v.x * yxp + v.y * yyp + v.z * yzp;
				double zz = v.x * zxp + v.y * zyp + v.z * zzp;

				double yt = (v.y * xCos - v.z * xSin);
				double zt = (v.y * xSin + v.z * xCos);
				double xt = (v.x * yCos - zt * ySin);
				double z = CONST_Z + (v.x * ySin + zt * yCos);
				v.SetPoint(posx + (((xt * zCos - yt * zSin) * zoomx) / z), posy - (((xt * zSin + yt * zCos) * zoomy) / z), z);

				v.SetPoint(posx + xx * zoomx, posy - yy * zoomy, zz);
			}

			// Tri des faces par ordre des Z
			List<Face> lstDraw = new List<Face>();
			for (int i = 0; i < lstFace.Count; i++)
				lstDraw.Add(lstFace[i]);

			lstDraw.Sort(delegate (Face p1, Face p2) {
				double cmp = p1.GetZFace(lstVertex) - p2.GetZFace(lstVertex);
				return cmp != 0 ? (int)cmp : p1.num - p2.num;
			});

			// Affiche les triangles
			for (int i = 0; i < lstDraw.Count; i++) {
				Triangle t = lstDraw[i].GetTriangleCalc(lstVertex, lstDraw[i].pen, bm);
				t.FillTriangle(bm, false, bmCalc, i);
				if (lstTri != null)
					lstTri.Add(t);      // Ajoute dans la liste des triangles si passée en paramètre
			}

			// Affiche la face sélectionnée
			if (numFace != -1)
				lstFace[numFace].GetTriangleCalc(lstVertex, 0, bm).FillTriangle(bm, true);

			// Affiche le point sélectionné
			if (numPoint > -1)
				for (int x = -2; x < 3; x++)
					for (int y = -2; y < 3; y++)
						bm.SetPixel(x + (int)lstVertex[numPoint].px, y + (int)lstVertex[numPoint].py, new RvbColor((byte)(64 - x * 63), (byte)(64 + y * 63), (byte)((x + y) * 63)));
		}

		#region Lecture/Sauvegarde objet
		private double DecodeValue(string l, int startPos) {
			int p;
			l = l.Substring(startPos).Trim();
			for (p = 0; p < l.Length; p++) {
				if (!Char.IsDigit(l[p]) && l[p] != ' ' && l[p] != '\t' && l[p] != '.' && l[p] != '-')
					break;
			}
			return Utils.ToDouble(l.Substring(0, p));
		}

		private void AddVertex(string l) {
			// Ajout Vertex
			int px = l.IndexOf("X:") + 2;
			int py = l.IndexOf("Y:") + 2;
			int pz = l.IndexOf("Z:") + 2;
			if (px > 2 && py > 2 && pz > 2)
				lstVertex.Add(new Vertex(DecodeValue(l, px), DecodeValue(l, py), DecodeValue(l, pz)));
		}

		private void AddFace(string l, int offsetVertex, ref int numFace) {
			// Ajout Face
			int pa = l.IndexOf("A:") + 2;
			int pb = l.IndexOf("B:") + 2;
			int pc = l.IndexOf("C:") + 2;
			if (pa > 2 && pb > 2 && pc > 2) {
				int a = (int)DecodeValue(l, pa);
				int b = (int)DecodeValue(l, pb);
				int c = (int)DecodeValue(l, pc);
				if (a < lstVertex.Count && b < lstVertex.Count && c < lstVertex.Count)
					lstFace.Add(new Face(numFace++, a + offsetVertex, b + offsetVertex, c + offsetVertex, 1));
			}
		}

		private void SetFaceColor(string l, ref int numPen) {
			// Lecture couleurs R,V,B de la face
			int pr = l.LastIndexOf('R') + 1;
			int pg = l.LastIndexOf('G') + 1;
			int pb = l.LastIndexOf('B') + 1;
			if (pr > 1 && pg > 1 && pb > 1) {
				RvbColor faceColor = new RvbColor((byte)DecodeValue(l, pr), (byte)DecodeValue(l, pg), (byte)DecodeValue(l, pb));
				if (numPen != 0 && PaletteCpc.SetPaletteFromColor(faceColor, numPen))
					numPen--;

				lstFace[lstFace.Count - 1].pen = PaletteCpc.GetNumPen(faceColor);
			}
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
		#endregion
	}
}
