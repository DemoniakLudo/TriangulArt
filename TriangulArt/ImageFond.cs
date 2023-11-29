﻿using System.Collections.Generic;
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

		public ImageFond(int width, int height) {
			tabImage.Add(new Bitmap(width, height));
		}

		public void ClearAll() {
			foreach (Bitmap b in tabImage)
				b.Dispose();

			tabImage.Clear();
		}

		public void InitBitmap(Bitmap b) {
			ClearAll();
			tabImage.Add(new Bitmap(b));
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

		public void InitBitmap(int nbImg, int width, int height) {
			ClearAll();
			for (int n = 0; n < nbImg; n++)
				tabImage.Add(new Bitmap(width, height));
		}

		public void ImportBitmap(Bitmap bmp, int numImage) {
			tabImage[numImage] = new Bitmap(bmp);
		}

		public Bitmap GetBitmap(int numImage) {
			return tabImage[numImage < tabImage.Count ? numImage : tabImage.Count - 1];
		}

		public void DeleteImage(int numImage) {
			tabImage.RemoveAt(numImage);
		}

		public void SelectBitmap(int num) {
			imageSel = num;
		}
	}
}
