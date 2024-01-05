using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TriangulArt {
	public class ImageFond {
		private List<Bitmap> tabImage = new List<Bitmap>();
		public Bitmap GetImage { get { return tabImage[imageSel < tabImage.Count ? imageSel : tabImage.Count - 1]; } }
		public int NbImg { get { return tabImage.Count; } }
		private int imageSel = 0;

		public ImageFond() {
			ClearAll();
		}

		public void ClearAll() {
			foreach (Bitmap b in tabImage)
				b.Dispose();

			tabImage.Clear();
		}

		public void InitBitmap(MemoryStream imageStream) {
			ClearAll();
			Image selImage = new Bitmap(imageStream);
			FrameDimension dimension = new FrameDimension(selImage.FrameDimensionsList[0]);
			int nbImg = selImage.GetFrameCount(dimension);
			for (int n = 0; n < nbImg; n++) {
				selImage.SelectActiveFrame(dimension, n);
				tabImage.Add(new Bitmap(selImage));
			}
		}

		public void SelectBitmap(int num) {
			imageSel = num;
		}
	}
}
