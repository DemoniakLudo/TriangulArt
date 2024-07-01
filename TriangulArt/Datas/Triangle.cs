using System;

namespace TriangulArt {
	public partial class Triangle {
		public int x1, y1, x2, y2, x3, y3;
		public byte color;
		public int pctFill = -1;
		public bool enabled = true;

		public Triangle() {
		}

		public Triangle(int x1, int y1, int x2, int y2, int x3, int y3, byte color, DirectBitmap bm = null, bool enabled = true) {
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.x3 = x3;
			this.y3 = y3;
			this.color = color;
			this.enabled = enabled;
			if (bm == null)
				Normalise();
			else
				Normalise(bm.Width, bm.Height);

			TriSommets();
			TriSommets3();
		}

		public void Normalise() {
			Normalise(383, 255);
		}

		public void Normalise(int maxX, int maxY) {
			x1 = Math.Max(Math.Min(x1, maxX - 1), -maxX);
			y1 = Math.Max(Math.Min(y1, maxY - 1), -maxY);
			x2 = Math.Max(Math.Min(x2, maxX - 1), -maxX);
			y2 = Math.Max(Math.Min(y2, maxY - 1), -maxY);
			x3 = Math.Max(Math.Min(x3, maxX - 1), -maxX);
			y3 = Math.Max(Math.Min(y3, maxY - 1), -maxY);
		}

		public bool EquPoly(Triangle t) {
			return color == t.color && ((x2 == t.x1 && y2 == t.x1 && x3 == t.x2 && y3 == t.y2)
									|| (x1 == t.x1 && y1 == t.y1 && x3 == t.x2 && y3 == t.y2)
									|| (x1 == t.x1 && y1 == t.y1 && x3 == t.x3 && y3 == t.y3)
									|| (x1 == t.x2 && y1 == t.y2 && x2 == t.x3 && y2 == t.y3)
									);
		}

		public void TriSommets() {
			if (y1 > y2) {
				int tmp = y1;
				y1 = y2;
				y2 = tmp;
				tmp = x1;
				x1 = x2;
				x2 = tmp;
			}
		}

		public void TriSommets3() {
			if (y1 > y3) {
				int tmp = y1;
				y1 = y3;
				y3 = tmp;
				tmp = x1;
				x1 = x3;
				x3 = tmp;
			}
			if (y1 > y2) {
				int tmp = y1;
				y1 = y2;
				y2 = tmp;
				tmp = x1;
				x1 = x2;
				x2 = tmp;
			}
			if (y2 > y3) {
				int tmp = y2;
				y2 = y3;
				y3 = tmp;
				tmp = x2;
				x2 = x3;
				x3 = tmp;
			}
		}

		private double IsLeft(double x1, double y1, double x2, double y2, double x3, double y3) {
			return (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
		}

		public bool IsInTriancle(int posx, int posy) {
			return IsLeft(x3, y3, x1, y1, posx, posy) * IsLeft(x3, y3, x1, y1, x2, y2) > 0 && IsLeft(x1, y1, x2, y2, posx, posy) * IsLeft(x1, y1, x2, y2, x3, y3) > 0 && IsLeft(x3, y3, x2, y2, posx, posy) * IsLeft(x3, y3, x2, y2, x1, y1) > 0;
		}

		public void FillTriangle(DirectBitmap bmpLock, bool selected = false, DirectBitmap bmCalc = null, int indice = 0) {
			if (bmpLock != null) {
				TriSommets();
				TriSommets3();
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
					int color = selected ? (y << 13) + (y << 4) + (y << 22) : PaletteCpc.GetColorPal(this.color).GetColorArgb;
					if (xr > xl) {
						bmpLock.SetHorLine(xl, y, (xr - xl), color, selected);
						if (bmCalc != null)
							bmCalc.SetHorLine(xl, y, (xr - xl), indice);
					}
					else {
						bmpLock.SetHorLine(xr, y, (xl - xr), color, selected);
						if (bmCalc != null)
							bmCalc.SetHorLine(xr, y, (xl - xr), indice);
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
				// Dessine les lignes de délimitation du triangle
				if (bmCalc == null) {
					RvbColor cFill = PaletteCpc.GetColorPal(color);
					int lineCol = (255 - cFill.b) + ((255 - cFill.v) << 8) + ((255 - cFill.r) << 16) + (255 << 24);
					bmpLock.DrawLine(x1, y1, x2, y2, lineCol, false);
					bmpLock.DrawLine(x2, y2, x3, y3, lineCol, false);
					bmpLock.DrawLine(x3, y3, x1, y1, lineCol, false);
				}
			}
		}

		public void CountPctFillTriangle(DirectBitmap bmpLock, int c) {
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
			pctFill = nbPt > 0 ? nbFound * 100 / nbPt : -1;
		}
	}
}
