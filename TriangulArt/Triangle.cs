﻿namespace TriangulArt {
	[System.Serializable]
	public class Triangle {
		public int x1, y1, x2, y2, x3, y3;
		public int color;

		public Triangle() {
		}

		public Triangle(int x1, int y1, int x2, int y2, int x3, int y3) {
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.x3 = x3;
			this.y3 = y3;
		}

		public void Normalise2() {
			if (y1 > y2) {
				int tmp = y1;
				y1 = y2;
				y2 = tmp;
				tmp = x1;
				x1 = x2;
				x2 = tmp;
			}
		}

		public void Normalise3() {
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

		public void DoubleCoord() {
			x1 <<= 1;
			y1 <<= 1;
			x2 <<= 1;
			y2 <<= 1;
			x3 <<= 1;
			y3 <<= 1;
		}

		public void Move(int inc) {
			x1 += inc;
			y1 += inc;
			x2 += inc;
			y2 += inc;
			x3 += inc;
			y3 += inc;
		}
	}
}
