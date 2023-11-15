using System.Collections.Generic;
using System.IO;

namespace TriangulArt {
	public class Image {
		public List<Triangle> lstTriangle = new List<Triangle>();

		public Image() {
		}

		public void Optimize(DirectBitmap bmpCalc) {
			for (int i = 0; i < lstTriangle.Count; i++) {
				for (int y = 0; y < bmpCalc.Height; y++)
					for (int x = 0; x < bmpCalc.Width; x++) {
						if (bmpCalc.GetPixel(x, y) == i) {
							lstTriangle[i].SetPctFill(1);
							break;
						}
					}
			}
		}

		public void GenereDatas(Datas d, int numImage, bool mode0) {
			d.nomImage = "Frame_" + numImage.ToString();
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				if (t.GetPctFill() == 1) {
					int c = PaletteCpc.GetNumPen(t.color);
					int x1 = t.x1 >> (mode0 ? 1 : 0);
					int x2 = t.x2 >> (mode0 ? 1 : 0);
					int x3 = t.x3 >> (mode0 ? 1 : 0);
					d.lstTriangle.Add(new Triangle(t.x1, t.y1, t.x2, t.y2, t.x3, t.y3, c));
				}
			}
		}
	}
}
