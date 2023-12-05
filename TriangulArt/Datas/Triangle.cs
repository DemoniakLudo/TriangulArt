using System;

namespace TriangulArt {
	public partial class Triangle {
		public int x1, y1, x2, y2, x3, y3;
		public byte color;
		private int pctFill = -1;

		public Triangle() {
		}

		public Triangle(int x1, int y1, int x2, int y2, int x3, int y3, byte color) {
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.x3 = x3;
			this.y3 = y3;
			Normalise();
			TriSommets();
			TriSommets3();
			this.color = color;
		}

		public void Normalise() {
			x1 = Math.Max(Math.Min(x1, 383), 0);
			y1 = Math.Max(Math.Min(y1, 383), 0);
			x2 = Math.Max(Math.Min(x2, 383), 0);
			y2 = Math.Max(Math.Min(y2, 383), 0);
			x3 = Math.Max(Math.Min(x3, 383), 0);
			y3 = Math.Max(Math.Min(y3, 383), 0);
		}

		public bool EquPoly(Triangle t) {
			return color == t.color && ((x2 == t.x1 && y2 == t.x1 && x3 == t.x2 && y3 == t.y2)
									|| (x1 == t.x1 && y1 == t.y1 && x3 == t.x2 && y3 == t.y2)
									|| (x1 == t.x1 && y1 == t.y1 && x3 == t.x3 && y3 == t.y3)
									|| (x1 == t.x2 && y1 == t.y2 && x2 == t.x3 && y2 == t.y3)
									);
		}

		public int GetPctFill() {
			return pctFill;
		}

		public void SetPctFill(int pct) {
			pctFill = pct;
		}

		public Triangle(int x1, int y1, int x2, int y2, int x3, int y3, byte color, DirectBitmap bm) {
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.x3 = x3;
			this.y3 = y3;
			Normalise(bm.Width, bm.Height);
			TriSommets();
			TriSommets3();
			this.color = color;
		}

		public void Normalise(int maxX, int maxY) {
			x1 = Math.Max(Math.Min(x1, maxX - 1), 0);
			y1 = Math.Max(Math.Min(y1, maxY - 1), 0);
			x2 = Math.Max(Math.Min(x2, maxX - 1), 0);
			y2 = Math.Max(Math.Min(y2, maxY - 1), 0);
			x3 = Math.Max(Math.Min(x3, maxX - 1), 0);
			y3 = Math.Max(Math.Min(y3, maxY - 1), 0);
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

		public void FillTriangle(DirectBitmap bmpLock, bool selected = false, DirectBitmap bmCalc = null, int indice = 0) {
			if (y1 > y2) {
				int tmp = y1;
				y1 = y2;
				y2 = tmp;
				tmp = x1;
				x1 = x2;
				x2 = tmp;
			}
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
					bmCalc?.SetHorLine(xl, y, (xr - xl), indice);
				}
				else {
					bmpLock.SetHorLine(xr, y, (xl - xr), color, selected);
					bmCalc?.SetHorLine(xr, y, (xl - xr), indice);
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
		}
	}
}
