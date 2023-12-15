using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace TriangulArt {
	[Serializable]
	public class Datas {
		public int modeRendu = 0;
		public List<Triangle> lstTriangle = new List<Triangle>();
		public int[] palette = new int[16];
		public int tpsAttente = 16;
		public string nomImage;
		private int selLigne = -1;

		public Datas() {
			for (int i = 0; i < 16; i++)
				palette[i] = PaletteCpc.Palette[i];
		}

		private void FillTriangle(DirectBitmap bmpLock, int x1, int y1, int x2, int y2, int x3, int y3, int c, bool selected = false) {
			int dx1 = x3 - x1;
			int dy1 = y3 - y1;
			int sgn1 = dx1 > 0 ? 1 : -1;
			dx1 = Math.Abs(dx1);
			int err1 = 0;
			int dx2 = x2 - x1;
			int dy2 = y2 - y1;
			int sgn2 = dx2 > 0 ? 1 : -1;
			dx2 = Math.Abs(dx2);
			int err2 = 0;
			int xl = x1;
			int xr = x1;
			if (y1 == y2)
				xr = x2;

			for (int y = y1; y < y3; y++) {
				int color = selected ? (y << 13) + (y << 4) + (y << 22) : c;
				if (xr > xl)
					bmpLock.SetHorLine(xl, y, (xr - xl), color, selected);
				else
					bmpLock.SetHorLine(xr, y, (xl - xr), color, selected);

				err1 += dx1;
				while (err1 >= dy1) {
					xl += sgn1;
					err1 -= dy1;
				}
				if (y == y2) { // On passe au tracé du second "demi-triangle"
					dx2 = x3 - x2;
					dy2 = y3 - y2;
					sgn2 = dx2 > 0 ? 1 : -1;
					dx2 = Math.Abs(dx2);
					err2 = 0;
				}
				err2 += dx2;
				while (err2 >= dy2) {
					xr += sgn2;
					err2 -= dy2;
				}
			}
		}

		private int CountPctFillTriangle(DirectBitmap bmpLock, int x1, int y1, int x2, int y2, int x3, int y3, int c) {
			int dx1 = x3 - x1;
			int dy1 = y3 - y1;
			int sgn1 = dx1 > 0 ? 1 : -1;
			dx1 = Math.Abs(dx1);
			int err1 = 0;
			int dx2 = x2 - x1;
			int dy2 = y2 - y1;
			int sgn2 = dx2 > 0 ? 1 : -1;
			dx2 = Math.Abs(dx2);
			int err2 = 0;
			int xl = x1;
			int xr = x1;
			if (y1 == y2)
				xr = x2;

			int nbFound = 0, nbPt = 0;
			for (int y = y1; y < y3; y++) {
				if (xr > xl) {
					for (int x = 0; x <= xr - xl; x++) {
						nbPt++;
						if (bmpLock.GetPixel(xl + x, y) == c)
							nbFound++;
					}
				}
				else {
					for (int x = 0; x <= xl - xr; x++) {
						nbPt++;
						if (bmpLock.GetPixel(xr + x, y) == c)
							nbFound++;
					}
				}
				err1 += dx1;
				while (err1 >= dy1) {
					xl += sgn1;
					err1 -= dy1;
				}
				if (y == y2) { // On passe au tracé du second "demi-triangle"
					dx2 = x3 - x2;
					dy2 = y3 - y2;
					sgn2 = dx2 > 0 ? 1 : -1;
					dx2 = Math.Abs(dx2);
					err2 = 0;
				}
				err2 += dx2;
				while (err2 >= dy2) {
					xr += sgn2;
					err2 -= dy2;
				}
			}
			return nbPt > 0 ? nbFound * 100 / nbPt : -1;
		}

		public void FillTriangle(DirectBitmap bmpLock, Triangle t, int maxWidth, bool modeLines, bool selected = false, int trueCol = 0) {
			int x1 = t.x1;
			int y1 = t.y1;
			int x2 = t.x2;
			int y2 = t.y2;
			int x3 = t.x3;
			int y3 = t.y3;
			int c = t.color;
			if (modeLines) {
				bmpLock.DrawLine(x1, y1, x2, y2, trueCol != 0 ? trueCol : PaletteCpc.GetColorPal(c).GetColorArgb, selected);
				bmpLock.DrawLine(x2, y2, x3, y3, trueCol != 0 ? trueCol : PaletteCpc.GetColorPal(c).GetColorArgb, selected);
				bmpLock.DrawLine(x3, y3, x1, y1, trueCol != 0 ? trueCol : PaletteCpc.GetColorPal(c).GetColorArgb, selected);
			}
			else {
				FillTriangle(bmpLock, x1, y1, x2, y2, x3, y3, trueCol != 0 ? trueCol : PaletteCpc.GetColorPal(c).GetColorArgb, selected);
				if (modeRendu == 1)
					FillTriangle(bmpLock, maxWidth - 1 - x1, y1, maxWidth - 1 - x2, y2, maxWidth - 1 - x3, y3, trueCol != 0 ? trueCol : PaletteCpc.GetColorPal(c).GetColorArgb, false);
				else
					if (modeRendu == 2)
					FillTriangle(bmpLock, x3, 255 - y3, x2, 255 - y2, x1, 255 - y1, trueCol != 0 ? trueCol : PaletteCpc.GetColorPal(c).GetColorArgb, false);
			}
		}

		public void FillTriangles(DirectBitmap bmpLock, int maxWidth, bool modeLines) {
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				if ( t.enabled)
					FillTriangle(bmpLock, t, maxWidth, modeLines, i == selLigne);
			}
		}

		public Triangle SelectTriangle(int s) {
			selLigne = s;
			if (s != -1)
				return lstTriangle[selLigne];

			return null;
		}

		public int SelTriangle(int xReel, int yReel) {
			for (int i = lstTriangle.Count; i-- > 0;) {
				Triangle t = lstTriangle[i];
				if (IsInTriancle(t, xReel, yReel)) {
					return i;
				}
			}
			return -1;
		}

		public int GetSelTriangle() {
			return selLigne;
		}

		private int IsLeft(int x1, int y1, int x2, int y2, int x3, int y3) {
			return (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
		}

		private bool IsInTriancle(Triangle t, int posx, int posy) {
			return IsLeft(t.x3, t.y3, t.x1, t.y1, posx, posy) * IsLeft(t.x3, t.y3, t.x1, t.y1, t.x2, t.y2) > 0 && IsLeft(t.x1, t.y1, t.x2, t.y2, posx, posy) * IsLeft(t.x1, t.y1, t.x2, t.y2, t.x3, t.y3) > 0 && IsLeft(t.x3, t.y3, t.x2, t.y2, posx, posy) * IsLeft(t.x3, t.y3, t.x2, t.y2, t.x1, t.y1) > 0;
		}

		public void EditSelTriangle(Triangle t, byte c, int newIndex) {
			if (newIndex != selLigne && newIndex >= 0 && newIndex < lstTriangle.Count) {
				lstTriangle[selLigne].x1 = lstTriangle[newIndex].x1;
				lstTriangle[selLigne].y1 = lstTriangle[newIndex].y1;
				lstTriangle[selLigne].x2 = lstTriangle[newIndex].x2;
				lstTriangle[selLigne].y2 = lstTriangle[newIndex].y2;
				lstTriangle[selLigne].x3 = lstTriangle[newIndex].x3;
				lstTriangle[selLigne].y3 = lstTriangle[newIndex].y3;
				lstTriangle[selLigne].color = lstTriangle[newIndex].color;
				lstTriangle[newIndex].x1 = t.x1;
				lstTriangle[newIndex].y1 = t.y1;
				lstTriangle[newIndex].x2 = t.x2;
				lstTriangle[newIndex].y2 = t.y2;
				lstTriangle[newIndex].x3 = t.x3;
				lstTriangle[newIndex].y3 = t.y3;
				lstTriangle[newIndex].color = c;
				selLigne = newIndex;
			}
			else {
				lstTriangle[selLigne].x1 = t.x1;
				lstTriangle[selLigne].y1 = t.y1;
				lstTriangle[selLigne].x2 = t.x2;
				lstTriangle[selLigne].y2 = t.y2;
				lstTriangle[selLigne].x3 = t.x3;
				lstTriangle[selLigne].y3 = t.y3;
				lstTriangle[selLigne].color = c;
			}
		}

		public void DeleteSelTriangle() {
			lstTriangle.RemoveAt(selLigne);
		}

		public void UpTriangle() {
			Triangle t = lstTriangle[selLigne];
			lstTriangle[selLigne] = lstTriangle[selLigne - 1];
			lstTriangle[selLigne - 1] = t;
		}

		public void DownTriangle() {
			Triangle t = lstTriangle[selLigne];
			lstTriangle[selLigne] = lstTriangle[selLigne + 1];
			lstTriangle[selLigne + 1] = t;
		}

		public void SetFirstTriangle() {
			for (int i = selLigne; i > 0; i--) {
				Triangle t = lstTriangle[i];
				lstTriangle[i] = lstTriangle[i - 1];
				lstTriangle[i - 1] = t;
			}
		}

		public void SetLastTriangle(int nb) {
			for (int i = selLigne; i < nb; i++) {
				Triangle t = lstTriangle[i];
				lstTriangle[i] = lstTriangle[i + 1];
				lstTriangle[i + 1] = t;
			}
		}

		private void MoveTriangle(Triangle t, int deplX, int deplY, int maxWidth) {
			t.x1 = Math.Max(Math.Min(t.x1 + deplX, maxWidth - 1), 0);
			t.y1 = Math.Max(Math.Min(t.y1 + deplY, 255), 0);
			t.x2 = Math.Max(Math.Min(t.x2 + deplX, maxWidth - 1), 0);
			t.y2 = Math.Max(Math.Min(t.y2 + deplY, 255), 0);
			t.x3 = Math.Max(Math.Min(t.x3 + deplX, maxWidth - 1), 0);
			t.y3 = Math.Max(Math.Min(t.y3 + deplY, 255), 0);
		}

		public void DeplaceTriangle(int deplX, int deplY, int maxWidth) {
			MoveTriangle(lstTriangle[selLigne], deplX, deplY, maxWidth);
		}

		public void DeplaceImage(int deplX, int deplY, int maxWidth) {
			foreach (Triangle t in lstTriangle)
				MoveTriangle(t, deplX, deplY, maxWidth);
		}

		public void CleanUp(int maxWidth, bool onlyCalc = false) {
			int nbTri = lstTriangle.Count;
			DirectBitmap bmpLock = new DirectBitmap(maxWidth, 256); // Bitmap temporaire pour tracé des triangles
			for (int i = 0; i < nbTri; i++)
				FillTriangle(bmpLock, lstTriangle[i], maxWidth, false, false, i + 1); // tracé triangle dans la couleur i+1

			if (!onlyCalc) {
				// Premiere passe : supprimer triangle complètement recouvert
				for (int i = 0; i < nbTri; i++) {
					bool found = false;
					for (int x = 0; x < maxWidth; x++)
						for (int y = 0; y < 256; y++)
							if (bmpLock.GetPixel(x, y) == i + 1) { // Vérifier image contient au moins un pixel de la couleur i+1
								found = true;
								break;
							}
					if (!found)
						lstTriangle[i].x1 = lstTriangle[i].y1 = lstTriangle[i].x2 = lstTriangle[i].y2 = 0;
				}

				// Seconde passe : supprimer les triangles ayant des coordonnées identiques
				for (int i = 0; i < nbTri; i++) {
					Triangle t = lstTriangle[i];
					if ((t.x1 == t.x2 && t.y1 == t.y2)
						|| (t.x1 == t.x3 && t.y1 == t.y3)
						|| (t.x2 == t.x3 && t.y2 == t.y3)) {
						lstTriangle.RemoveAt(i);
						i--;
						nbTri--;
					}
				}
			}

			// Troisième passe: calcule le pourcentage de visibilité de chaque triangle
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				lstTriangle[i].SetPctFill(CountPctFillTriangle(bmpLock, t.x1, t.y1, t.x2, t.y2, t.x3, t.y3, i + 1));
			}
			bmpLock.Dispose();
		}

		public void ToQuadri() {
			List<Triangle> copyList = new List<Triangle>();
			foreach (Triangle t in lstTriangle)
				copyList.Add(t);

			List<Quadri> lstQuadri = new List<Quadri>();
			for (int i = 0; i < copyList.Count; i++) {
				for (int j = 0; j < copyList.Count; j++) {
					if (i != j) {
						Triangle t1 = copyList[i];
						Triangle t2 = copyList[j];
						// Cas 1
						if (t1.x2 == t2.x1 && t1.y2 == t2.y1 && t1.x3 == t2.x2 && t1.y3 == t2.y2 && t1.color == t2.color) {
							lstQuadri.Add(new Quadri(t1.x1, t1.y1, t1.x2, t1.y2, t2.x2, t2.y2, t2.x3, t2.y3, t1.color));
							copyList.Remove(t1);
							copyList.Remove(t2);
							i = j = 0;
						}
						// Cas 2
						if (t1.x1 == t2.x1 && t1.y1 == t2.y1 && t1.x3 == t2.x3 && t1.y3 == t2.y3 && t1.color == t2.color) {
							lstQuadri.Add(new Quadri(t1.x1, t1.y1, t1.x2, t1.y2, t2.x2, t2.y2, t2.x3, t2.y3, t1.color));
							copyList.Remove(t1);
							copyList.Remove(t2);
							i = j = 0;
						}
					}
				}
			}
			bool trouve;
			do {
				List<Quadri> copyQuadri = new List<Quadri>();
				foreach (Quadri q in lstQuadri)
					copyQuadri.Add(q);

				trouve = false;
				lstQuadri.Clear();
				for (int i = 0; i < copyQuadri.Count; i++) {
					for (int j = 0; j < copyQuadri.Count; j++) {
						if (i != j) {
							Quadri q1 = copyQuadri[i];
							Quadri q2 = copyQuadri[j];
							// Cas 1
							if (q1.x2 == q2.x1 && q1.y2 == q2.y1 && q1.x4 == q2.x3 && q1.y4 == q2.y3 && q1.color == q2.color) {
								lstQuadri.Add(new Quadri(q1.x1, q1.y1, q2.x2, q2.y2, q1.x3, q1.y3, q2.x4, q2.y4, q1.color));
								copyQuadri.Remove(q1);
								copyQuadri.Remove(q2);
								i = j = 0;
								trouve = true;
								break;
							}
							// Cas 2
							if (q1.x3 == q2.x1 && q1.y3 == q2.y1 && q1.x4 == q2.x2 && q1.y4 == q2.y2 && q1.color == q2.color) {
								lstQuadri.Add(new Quadri(q1.x1, q1.y1, q1.x2, q1.y2, q2.x3, q2.y3, q2.x4, q2.y4, q1.color));
								copyQuadri.Remove(q1);
								copyQuadri.Remove(q2);
								i = j = 0;
								trouve = true;
							}
						}
					}
				}

				foreach (Quadri q in copyQuadri)
					lstQuadri.Add(q);
			}
			while (trouve);

			// Reformer les triangles à partir des quadri
			lstTriangle.Clear();
			foreach (Quadri q in lstQuadri) {
				lstTriangle.Add(new Triangle(q.x1, q.y1, q.x3, q.y3, q.x4, q.y4, q.color));
				lstTriangle.Add(new Triangle(q.x1, q.y1, q.x2, q.y2, q.x4, q.y4, q.color));
			}
		}

		public void Rapproche(int distMin) {
			int deltax = 0, deltay = 0;
			for (int i = 0; i < lstTriangle.Count - 1; i++)
				for (int j = i + 1; j < lstTriangle.Count; j++) {
					Triangle tFirst = lstTriangle[i];
					Triangle tSecond = lstTriangle[j];
					deltax = tFirst.x1 - tSecond.x1;
					deltay = tFirst.y1 - tSecond.y1;
					double d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x1 -= (deltax + 1) / 2;
						tSecond.x1 += (deltax + 1) / 2;
						tFirst.y1 -= (deltay + 1) / 2;
						tSecond.y1 += (deltay + 1) / 2;
					}
					deltax = tFirst.x1 - tSecond.x2;
					deltay = tFirst.y1 - tSecond.y2;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x1 -= (deltax + 1) / 2;
						tSecond.x2 += (deltax + 1) / 2;
						tFirst.y1 -= (deltay + 1) / 2;
						tSecond.y2 += (deltay + 1) / 2;
					}
					deltax = tFirst.x1 - tSecond.x3;
					deltay = tFirst.y1 - tSecond.y3;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x1 -= (deltax + 1) / 2;
						tSecond.x3 += (deltax + 1) / 2;
						tFirst.y1 -= (deltay + 1) / 2;
						tSecond.y3 += (deltay + 1) / 2;
					}
					deltax = tFirst.x2 - tSecond.x1;
					deltay = tFirst.y2 - tSecond.y1;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x2 -= (deltax + 1) / 2;
						tSecond.x1 += (deltax + 1) / 2;
						tFirst.y2 -= (deltay + 1) / 2;
						tSecond.y1 += (deltay + 1) / 2;
					}
					deltax = tFirst.x2 - tSecond.x2;
					deltay = tFirst.y2 - tSecond.y2;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x2 -= (deltax + 1) / 2;
						tSecond.x2 += (deltax + 1) / 2;
						tFirst.y2 -= (deltay + 1) / 2;
						tSecond.y2 += (deltay + 1) / 2;
					}
					deltax = tFirst.x2 - tSecond.x3;
					deltay = tFirst.y2 - tSecond.y3;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x2 -= (deltax + 1) / 2;
						tSecond.x3 += (deltax + 1) / 2;
						tFirst.y2 -= (deltay + 1) / 2;
						tSecond.y3 += (deltay + 1) / 2;
					}
					deltax = tFirst.x3 - tSecond.x1;
					deltay = tFirst.y3 - tSecond.y1;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x3 -= (deltax + 1) / 2;
						tSecond.x1 += (deltax + 1) / 2;
						tFirst.y3 -= (deltay + 1) / 2;
						tSecond.y1 += (deltay + 1) / 2;
					}
					deltax = tFirst.x3 - tSecond.x2;
					deltay = tFirst.y3 - tSecond.y2;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x3 -= (deltax + 1) / 2;
						tSecond.x2 += (deltax + 1) / 2;
						tFirst.y3 -= (deltay + 1) / 2;
						tSecond.y2 += (deltay + 1) / 2;
					}
					deltax = tFirst.x3 - tSecond.x3;
					deltay = tFirst.y3 - tSecond.y3;
					d = Math.Sqrt(deltax * deltax + deltay * deltay);
					if (d > 0 && d <= distMin) {
						tFirst.x3 -= (deltax + 1) / 2;
						tSecond.x3 += (deltax + 1) / 2;
						tFirst.y3 -= (deltay + 1) / 2;
						tSecond.y3 += (deltay + 1) / 2;
					}
					tFirst.TriSommets();
					tFirst.TriSommets3();
					tSecond.TriSommets();
					tSecond.TriSommets3();
				}
		}

		public void CoefZoom(Triangle t, double coefX, double coefY, bool center, int maxWidth) {
			int addCenter = center ? 127 : 0;
			double x1 = addCenter + (t.x1 - addCenter) * coefX;
			double y1 = addCenter + (t.y1 - addCenter) * coefY;
			double x2 = addCenter + (t.x2 - addCenter) * coefX;
			double y2 = addCenter + (t.y2 - addCenter) * coefY;
			double x3 = addCenter + (t.x3 - addCenter) * coefX;
			double y3 = addCenter + (t.y3 - addCenter) * coefY;
			t.x1 = (int)Math.Max(Math.Min(x1, maxWidth - 1), 0);
			t.y1 = (int)Math.Max(Math.Min(y1, 255), 0);
			t.x2 = (int)Math.Max(Math.Min(x2, maxWidth - 1), 0);
			t.y2 = (int)Math.Max(Math.Min(y2, 255), 0);
			t.x3 = (int)Math.Max(Math.Min(x3, maxWidth - 1), 0);
			t.y3 = (int)Math.Max(Math.Min(y3, 255), 0);
		}

		public void CoefZoom(double coefX, double coefY, bool center, int maxWidth) {
			foreach (Triangle t in lstTriangle)
				CoefZoom(t, coefX, coefY, center, maxWidth);
		}

		public void Clear() {
			lstTriangle.Clear();
		}

		public void Import(string fileName, bool clearAll) {
			if (clearAll)
				lstTriangle.Clear();

			StreamReader rw = new StreamReader(fileName);
			string l;
			do {
				l = rw.ReadLine();
				if (l != null)
					AnalyseLigne(l);
			}
			while (l != null);
			rw.Close();
		}

		public bool AnalyseLigne(string line) {
			string ltrait = line.Trim();
			if (ltrait.Length >= 6) {
				if (ltrait.Substring(0, 2) == "DB") {
					ltrait = ltrait.Substring(3).Trim();
					char[] delimiters = new char[] { ',', '#' };
					string[] param = ltrait.Split(delimiters);
					if (param.Length == 14) {
						int x1 = int.Parse(param[1], NumberStyles.HexNumber);
						int y1 = int.Parse(param[3], NumberStyles.HexNumber);
						int x2 = int.Parse(param[5], NumberStyles.HexNumber);
						int y2 = int.Parse(param[7], NumberStyles.HexNumber);
						int x3 = int.Parse(param[9], NumberStyles.HexNumber);
						int y3 = int.Parse(param[11], NumberStyles.HexNumber);
						int c = int.Parse(param[13], NumberStyles.HexNumber);
						if (x1 >= 0 && y1 >= 0 && x2 >= 0 && y2 >= 0 && x3 >= 0 && y3 >= 0) {
							lstTriangle.Add(new Triangle(x1, y1, x2, y2, x3, y3, (byte)(c & 0x0F)));
							return (c & 0x80) != 0;
						}
					}
					else
						if (param.Length == 2) {
						if (int.Parse(param[1], NumberStyles.HexNumber) == 255)
							return true;
					}
				}
			}
			return false;
		}

		public void GenereSourceAsm(string fileName, int mode, bool cpcPlus, bool withCode, bool modePolice, bool mode3D) {
			bool polyMode = false;
			//
			// Rapprocher les triangles ayant des coordonnées comparables
			//
			if (polyMode) {
				for (int i = 0; i < lstTriangle.Count - 1; i++) {
					Triangle t1 = lstTriangle[i];
					for (int j = i + 1; j < lstTriangle.Count; j++) {
						Triangle t2 = lstTriangle[j];
						if (t1.EquPoly(t2)) {
							if (j != i + 1) {
								lstTriangle[j] = lstTriangle[i + 1];
								lstTriangle[i + 1] = t2;
							}
							i++;
							break;
						}
					}
				}
			}
			StreamWriter sw = GenereAsm.OpenAsm(fileName);
			if (string.IsNullOrEmpty(nomImage))
				nomImage = Path.GetFileName(fileName);

			string nom = nomImage;
			int p = nom.IndexOf('.');
			if (p > 0)
				nom = nom.Substring(0, p);

			if (withCode)
				GenereAsm.GenereDrawTriangleCode(sw, nom, mode, cpcPlus);

			GenereAsm.GenereDatas(sw, this, nom, mode, cpcPlus, modePolice, mode3D);
			if (withCode)
				GenereAsm.GenereDrawTriangleData(sw, mode, cpcPlus);

			GenereAsm.CloseAsm(sw);
		}

		public void ChangeMode(int newMode) {
			if (palette.Length == 4) {
				int[] tmp = new int[4];
				for (int i = 0; i < 4; i++)
					tmp[i] = palette[i];

				palette = new int[16];
				for (int j = 0; j < 16; j++)
					palette[j] = j < 4 ? tmp[j] : PaletteCpc.Palette[j];
			}
			for (int i = 0; i < lstTriangle.Count; i++) {
				if (newMode == 0) {
					lstTriangle[i].x1 >>= 1;
					lstTriangle[i].x2 >>= 1;
					lstTriangle[i].x3 >>= 1;
				}
				else {
					lstTriangle[i].x1 <<= 1;
					lstTriangle[i].x2 <<= 1;
					lstTriangle[i].x3 <<= 1;
				}
			}
		}
	}
}
