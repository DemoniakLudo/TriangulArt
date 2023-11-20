using System.Collections.Generic;

namespace TriangulArt {
	public class Image {
		public List<Triangle> lstTriangle = new List<Triangle>();

		public Image() {
		}

		public void Optimize(DirectBitmap bmpCalc) {
			for (int i = 0; i < lstTriangle.Count; i++)
				for (int y = 0; y < bmpCalc.Height; y++)
					for (int x = 0; x < bmpCalc.Width; x++)
						if (bmpCalc.GetPixel(x, y) == i) {
							lstTriangle[i].SetPctFill(1);
							break;
						}
		}

		public void GenereDatas(Datas d, int numImage, bool mode0) {
			d.nomImage = "Frame_" + numImage.ToString();
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				if (t.GetPctFill() == 1) {
					int x1 = mode0 ? t.x1 >> 1 : t.x1;
					int x2 = mode0 ? t.x2 >> 1 : t.x2;
					int x3 = mode0 ? t.x3 >> 1 : t.x3;
					d.lstTriangle.Add(new Triangle(x1, t.y1, x2, t.y2, x3, t.y3, t.color));
				}
			}
		}
	}
}
