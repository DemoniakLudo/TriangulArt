using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TriangulArt {
	[System.Serializable]
	public class Datas {
		public int modeRendu = 0;
		public List<Triangle> lstTriangle = new List<Triangle>();
		public int[] palette = new int[4];
		public bool cpcPlus = false;
		public int tpsAttente = 8192;

		private int selLigne = -1;

		public int GetPalCPC(int c) {
			return BitmapCpc.cpcPlus ? (((c & 0xF0) >> 4) * 17) + ((((c & 0xF00) >> 8) * 17) << 8) + (((c & 0x0F) * 17) << 16) : BitmapCpc.RgbCPC[c < 27 ? c : 0].GetColor;
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
					bmpLock.SetHorLineDouble(xl << 1, y << 1, (xr - xl) << 1, color, selected);
				else
					bmpLock.SetHorLineDouble((xl + xr - xl) << 1, y << 1, (xl - xr) << 1, color, selected);

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

		public void FillTriangle(DirectBitmap bmpLock, Triangle t, bool selected = false) {
			int x1 = t.x1;
			int y1 = t.y1;
			int x2 = t.x2;
			int y2 = t.y2;
			int x3 = t.x3;
			int y3 = t.y3;
			int c = t.color;
			FillTriangle(bmpLock, x1, y1, x2, y2, x3, y3, GetPalCPC(BitmapCpc.Palette[c]), selected);
			if (modeRendu == 1)
				FillTriangle(bmpLock, 255 - x1, y1, 255 - x2, y2, 255 - x3, y3, GetPalCPC(BitmapCpc.Palette[c]), false);
			else
				if (modeRendu == 2)
					FillTriangle(bmpLock, x3, 255 - y3, x2, 255 - y2, x1, 255 - y1, GetPalCPC(BitmapCpc.Palette[c]), false);
		}

		public void FillTriangles(DirectBitmap bmpLock) {
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				FillTriangle(bmpLock, t, i == selLigne);
			}
		}

		public Triangle SelectTriangle(int s) {
			selLigne = s;
			if (s != -1)
				return lstTriangle[selLigne];

			return null;
		}

		public int SelTriangle(int xReel, int yReel) {
			for (int i = lstTriangle.Count; i-- > 0; ) {
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

		public void EditSelTriangle(Triangle t, int c, int newIndex) {
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

		private void MoveTriangle(Triangle t, int deplX, int deplY) {
			t.x1 += deplX;
			t.y1 += deplY;
			t.x2 += deplX;
			t.y2 += deplY;
			t.x3 += deplX;
			t.y3 += deplY;
		}

		public void DeplaceTriangle(int deplX, int deplY) {
			MoveTriangle(lstTriangle[selLigne], deplX, deplY);
		}

		public void DeplaceImage(int deplX, int deplY) {
			foreach (Triangle t in lstTriangle)
				MoveTriangle(t, deplX, deplY);
		}

		public void CleanUp(DirectBitmap bmpLock) {
			// vérifier triangle non complètement recouvert
			FillTriangles(bmpLock);
			int nbTri = lstTriangle.Count;
			for (int i = 0; i < nbTri; i++) {
				bool found = false;
				for (int x = 0; x < 512; x++)
					for (int y = 0; y < 512; y++)
						if (bmpLock.GetPixel(x, y) == GetPalCPC(BitmapCpc.Palette[lstTriangle[i].color])) {
							found = true;
							x = 512;
							y = 512;
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

		public void CoefZoom(Triangle t, double coefX, double coefY) {
			double x1 = 127 + (t.x1 - 127) * coefX;
			double y1 = 127 + (t.y1 - 127) * coefY;
			double x2 = 127 + (t.x2 - 127) * coefX;
			double y2 = 127 + (t.y2 - 127) * coefY;
			double x3 = 127 + (t.x3 - 127) * coefX;
			double y3 = 127 + (t.y3 - 127) * coefY;
			t.x1 = (int)x1;
			t.y1 = (int)y1;
			t.x2 = (int)x2;
			t.y2 = (int)y2;
			t.x3 = (int)x3;
			t.y3 = (int)y3;
		}

		public void CoefZoom(double coefX, double coefY) {
			foreach (Triangle t in lstTriangle)
				CoefZoom(t, coefX, coefY);
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

		private void AnalyseLigne(string line) {
			string ltrait = line.Trim();
			if (ltrait.Length > 6) {
				if (ltrait.Substring(0, 2) == "DB") {
					ltrait = ltrait.Substring(3).Trim();
					char[] delimiters = new char[] { ',', '#' };
					string[] param = ltrait.Split(delimiters);
					if (param.Length == 14) {
						int x1 = int.Parse(param[1], System.Globalization.NumberStyles.HexNumber);
						int y1 = int.Parse(param[3], System.Globalization.NumberStyles.HexNumber);
						int x2 = int.Parse(param[5], System.Globalization.NumberStyles.HexNumber);
						int y2 = int.Parse(param[7], System.Globalization.NumberStyles.HexNumber);
						int x3 = int.Parse(param[9], System.Globalization.NumberStyles.HexNumber);
						int y3 = int.Parse(param[11], System.Globalization.NumberStyles.HexNumber);
						int c = int.Parse(param[13], System.Globalization.NumberStyles.HexNumber);
						if (x1 >= 0 && y1 >= 0 && x2 >= 0 && y2 >= 0 && x3 >= 0 && y3 >= 0)
							lstTriangle.Add(new Triangle(x1, y1, x2, y2, x3, y3, c & 0x0F));
					}
				}
			}
		}

		public void GenereSourceAsm(string fileName, bool withCode, bool cpcPlus) {
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
			string file = Path.GetFileName(fileName);
			int p = file.IndexOf('.');
			if (p > 0)
				file = file.Substring(0, p);

			if (withCode)
				GenereAsm.GenereDrawTriangleCode(sw, file, cpcPlus);

			GenereAsm.GenereDatas(sw, this, file, cpcPlus);
			if (withCode)
				GenereAsm.GenereDrawTriangleData(sw, cpcPlus);

			GenereAsm.CloseAsm(sw);
		}
	}
}
