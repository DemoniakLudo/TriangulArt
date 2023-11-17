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
				if (t.GetPctFill() == 1)
					d.lstTriangle.Add(new Triangle(t.x1, t.y1, t.x2, t.y2, t.x3, t.y3, t.color));
			}
		}
	}
}
