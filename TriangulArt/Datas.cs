using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TriangulArt {
	[System.Serializable]
	public class Datas {
		public List<Triangle> lstTriangle = new List<Triangle>();
		public int[] palette = new int[4];
		private int selLigne = -1;

		public int GetPalCPC(int c) {
			return BitmapCpc.cpcPlus ? (((c & 0xF0) >> 4) * 17) + ((((c & 0xF00) >> 8) * 17) << 8) + (((c & 0x0F) * 17) << 16) : BitmapCpc.RgbCPC[c < 27 ? c : 0].GetColor;
		}

		public void FillTriangle(DirectBitmap bmpLock, Triangle t, bool selected = false) {
			int dx1 = t.x3 - t.x1;
			int dy1 = t.y3 - t.y1;
			int sgn1 = dx1 > 0 ? 1 : -1;
			dx1 = Math.Abs(dx1);
			int err1 = 0;
			int dx2 = t.x2 - t.x1;
			int dy2 = t.y2 - t.y1;
			int sgn2 = dx2 > 0 ? 1 : -1;
			dx2 = Math.Abs(dx2);
			int err2 = 0;
			int xl = t.x1;
			int xr = t.x1;
			if (t.y1 == t.y2)
				xr = t.x2;

			for (int y = t.y1; y < t.y3; y++) {
				int color = selected ? (y << 13) + (y << 3) + (y << 22) : GetPalCPC(BitmapCpc.Palette[t.color]);
				if (xr > xl)
					bmpLock.SetHorLineDouble(xl << 1, y << 1, (xr - xl) << 1, color);
				else
					bmpLock.SetHorLineDouble((xl + xr - xl) << 1, y << 1, (xl - xr) << 1, color);

				err1 += dx1;
				while (err1 >= dy1) {
					xl += sgn1;
					err1 -= dy1;
				}
				if (y == t.y2) { // On passe au tracé du second "demi-triangle"
					dx2 = t.x3 - t.x2;
					dy2 = t.y3 - t.y2;
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

		public void EditSelTriangle(Triangle t, int c) {
			lstTriangle[selLigne].x1 = t.x1;
			lstTriangle[selLigne].y1 = t.y1;
			lstTriangle[selLigne].x2 = t.x2;
			lstTriangle[selLigne].y2 = t.y2;
			lstTriangle[selLigne].x3 = t.x3;
			lstTriangle[selLigne].y3 = t.y3;
			lstTriangle[selLigne].color = c;
		}

		public void DeleteSelTriangle() {
			lstTriangle.RemoveAt(selLigne);
		}

		public void Clear() {
			lstTriangle.Clear();
		}

		public bool Import(string fileName) {
			bool ret = false;
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
			return ret;
		}

		private void AnalyseLigne(string line) {
			string ltrait = line.Trim();
			if (ltrait.Length > 6) {
				if (ltrait.Substring(0, 3) == "DB ") {
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
						if (x1 >= 0 && y1 >= 0 && x2 >= 0 && y2 >= 0 && x3 >= 0 && y3 >= 0) {
							Triangle t = new Triangle(x1, y1, x2, y2, x3, y3, c);
							lstTriangle.Add(t);
						}
					}
				}
			}
		}

		public void GenereSourceAsm(string fileName, bool withCode) {
			StreamWriter sw = GenereAsm.OpenAsm(fileName);
			if (withCode)
				GenereAsm.GenereDrawTriangleCode(sw);

			GenereAsm.GenereDatas(sw, lstTriangle);
			if (withCode)
				GenereAsm.GenereDrawTriangleData(sw);

			GenereAsm.CloseAsm(sw);
		}
	}
}
