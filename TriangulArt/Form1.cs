using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class Form1 : Form {
		private BitmapCpc bitmapCpc = new BitmapCpc();
		private DirectBitmap bmpLock;
		private List<Triangle> lstTriangle = new List<Triangle>();
		private bool modeAddTriangle = false;
		private int numPt;
		Triangle tri = new Triangle();

		public Form1() {
			InitializeComponent();
			bmpLock = new DirectBitmap(pictureBox.Width, pictureBox.Height);
			Reset();
		}


		public void Reset(bool force = false) {
			for (int y = 0; y < bmpLock.Height; y += 2)
				bmpLock.SetHorLineDouble(0, y, BitmapCpc.TailleX, GetPalCPC(BitmapCpc.Palette[0]));

			//for (int i = 0; i < 16; i++)
			//	colors[i].Visible = lockColors[i].Visible = i < maxPen;

			Render();
		}

		private int GetPalCPC(int c) {
			return BitmapCpc.cpcPlus ? (((c & 0xF0) >> 4) * 17) + ((((c & 0xF00) >> 8) * 17) << 8) + (((c & 0x0F) * 17) << 16) : BitmapCpc.RgbCPC[c < 27 ? c : 0].GetColor;
		}

		private void UpdatePalette() {
			//for (int i = 0; i < 16; i++) {
			//	colors[i].BackColor = Color.FromArgb(bitmapCpc.GetColorPal(i).GetColorArgb);
			//	colors[i].Refresh();
			//}
		}

		public void Render(bool forceDrawZoom = false) {
			UpdatePalette();
			pictureBox.Image = bmpLock.Bitmap;
			pictureBox.Refresh();
		}

		private void TrtMouseMove(object sender, MouseEventArgs e) {
			int incY = 2;
			int yReel = (e.Y & -incY) >> 1;
			int xReel = e.X >> 1;
			lblInfoPos.Text = "x:" + xReel.ToString("000") + " y:" + yReel.ToString("000");
			if (e.Button == MouseButtons.Left && modeAddTriangle) {
				switch (numPt) {
					case 1:
						tri.x1 = (byte)xReel;
						tri.y1 = (byte)yReel;
						numPt = 2;
						SetInfos("Attente positionnement second point triangle");
						break;

					case 2:
						tri.x2 = (byte)xReel;
						tri.y2 = (byte)yReel;
						numPt = 3;
						SetInfos("Attente positionnement troisième point triangle");
						break;

					case 3:
						tri.x3 = (byte)xReel;
						tri.y3 = (byte)yReel;
						numPt = 1;
						modeAddTriangle = false;
						bpAddTriangle.Enabled = true;
						SetInfos("Triangle enregistré.");
						tri.Normalise();
						SetInfos("(" + tri.x1 + "," + tri.y1 + "),(" + tri.x2 + "," + tri.y2 + "),(" + tri.x3 + "," + tri.y3 + ")");
						lstTriangle.Add(tri);
						FillTriangle(tri);
						break;
				}
			}
		}

		private void pictureBox_MouseLeave(object sender, EventArgs e) {
			lblInfoPos.Text = "";
		}

		private void bpAddTriangle_Click(object sender, EventArgs e) {
			numPt = 1;
			modeAddTriangle = true;
			bpAddTriangle.Enabled = false;
			SetInfos("Attente positionnement premier point triangle");
		}

		public void SetInfos(string txt) {
			listInfo.Items.Add(DateTime.Now.ToString() + " - " + txt);
			listInfo.SelectedIndex = listInfo.Items.Count - 1;
		}

		private void FillTriangle(Triangle t) {
			int dx1 = t.x3 - t.x1;
			int dy1 = t.y3 - t.y1;
			int sgn1 = dx1 > 0 ? 1 : -1;
			dx1 = Math.Abs(dx1);
			int err1 = 0;
			int dx2 = t.x2 - t.x1;
			int dy2 = t.y2 - t.y1;
			int sgn2 = dx2 > 0 ? 1 : -1;
			dx2 = Math.Abs(dx2);
			int err2 = 0;
			int xl = t.x1;
			int xr = t.x1;
			if (t.y1 == t.y2)
				xr = t.x2;

			for (int y = t.y1; y < t.y3; y++) {
				bmpLock.SetHorLineDouble(xl << 1, y << 1, Math.Abs(xr - xl) << 1, GetPalCPC(BitmapCpc.Palette[1]));
				err1 += dx1;
				while (err1 > dy1) {
					xl += sgn1;
					err1 -= dy1;
				}
				if (y == t.y2) { // On passe au tracé du second "demi-triangle"
					dx2 = t.x3 - t.x2;
					dy2 = t.y3 - t.y2;
					sgn2 = dx2 > 0 ? 1 : -1;
					dx2 = Math.Abs(dx2);
					err2 = 0;
				}
				err2 += dx2;
				while (err2 > dy2) {
					xr += sgn2;
					err2 -= dy2;
				}
			}
			Render();
		}
	}
}
