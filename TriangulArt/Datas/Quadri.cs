using System.Windows.Forms.VisualStyles;

namespace TriangulArt {
	public class Quadri {
		public int x1, y1, x2, y2, x3, y3, x4, y4;
		public byte color;

		public Quadri() {

		}

		public Quadri(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, byte color) {
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
			this.x3 = x3;
			this.y3 = y3;
			this.x4 = x4;
			this.y4 = y4;
			this.color = color;
			CheckCoord();
		}

		private void CheckCoord() {
			if (y1 > y3) {
				int tmp = y1;
				y1 = y3;
				y3 = tmp;
				tmp = x1;
				x1 = x3;
				x3 = tmp;
			}
			if (y2 > y4) {
				int tmp = y2;
				y2 = y4;
				y4 = tmp;
				tmp = x2;
				x2 = x4;
				x4 = tmp;
			}
			if (x1 > x2) {
				int tmp = x1;
				x1 = x2;
				x2 = tmp;
				tmp = y1;
				y1 = y2;
				y2 = tmp;
			}
			if ( x3>x4) {
				int tmp = x3;
				x3 = x4;
				x4 = tmp;
				tmp = y3;
				y3 = y4;
				y4 = tmp;
			}
		}
	}
}
