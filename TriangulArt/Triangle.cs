namespace TriangulArt {
	class Triangle {
		public int x1, y1, x2, y2, x3, y3;

		public void Normalise() {
			if (y1 > y3) {
				int tmp = y1;
				y1 = y3;
				y3 = tmp;
				tmp = x1;
				x1 = x3;
				x3 = tmp;
			}
			if (y1 > y2) {
				int  tmp = y1;
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
	}
}
