using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class Form1 : Form {
		private BitmapCpc bitmapCpc = new BitmapCpc();
		private DirectBitmap bmpLock;
		private List<Triangle> lstTriangle = new List<Triangle>();
		private bool modeAddTriangle = false;
		private int numPt;
		Triangle tri;
		private int oldx1, oldy1;
		private int selColor = 1;

		public Form1() {
			InitializeComponent();
			bmpLock = new DirectBitmap(pictureBox.Width, pictureBox.Height);
			Reset();
		}


		public void Reset(bool force = false) {
			for (int y = 0; y < bmpLock.Height; y += 2)
				bmpLock.SetHorLineDouble(0, y, BitmapCpc.TailleX, GetPalCPC(BitmapCpc.Palette[0]));


			Render();
		}

		private int GetPalCPC(int c) {
			return BitmapCpc.cpcPlus ? (((c & 0xF0) >> 4) * 17) + ((((c & 0xF00) >> 8) * 17) << 8) + (((c & 0x0F) * 17) << 16) : BitmapCpc.RgbCPC[c < 27 ? c : 0].GetColor;
		}

		private void UpdatePalette() {
			Color0.BackColor = Color.FromArgb(bitmapCpc.GetColorPal(0).GetColorArgb);
			Color1.BackColor = Color.FromArgb(bitmapCpc.GetColorPal(1).GetColorArgb);
			Color2.BackColor = Color.FromArgb(bitmapCpc.GetColorPal(2).GetColorArgb);
			Color3.BackColor = Color.FromArgb(bitmapCpc.GetColorPal(3).GetColorArgb);
			ColorSel.BackColor = Color.FromArgb(bitmapCpc.GetColorPal(selColor).GetColorArgb);
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
			Graphics g = Graphics.FromImage(pictureBox.Image);
			if (numPt == 2) {
				XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, oldx1 << 1, oldy1 << 1);
				oldx1 = xReel;
				oldy1 = yReel;
				XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, oldx1 << 1, oldy1 << 1);
			}
			if (numPt == 3) {
				XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, oldx1 << 1, oldy1 << 1);
				XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x2 << 1, tri.y2 << 1, oldx1 << 1, oldy1 << 1);
				oldx1 = xReel;
				oldy1 = yReel;
				XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, oldx1 << 1, oldy1 << 1);
				XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x2 << 1, tri.y2 << 1, oldx1 << 1, oldy1 << 1);
			}

			if (e.Button == MouseButtons.Left && modeAddTriangle) {
				switch (numPt) {
					case 1:
						tri = new Triangle();
						tri.x1 = xReel;
						tri.y1 = yReel;
						tri.color = selColor;
						numPt = 2;
						SetInfo("Attente positionnement second point triangle");
						oldx1 = xReel;
						oldy1 = yReel;
						break;

					case 2:
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, oldx1 << 1, oldy1 << 1);
						tri.x2 = xReel;
						tri.y2 = yReel;
						tri.Normalise2();
						numPt = 3;
						SetInfo("Attente positionnement troisième point triangle");
						oldx1 = xReel;
						oldy1 = yReel;
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, tri.x2 << 1, tri.y2 << 1);
						break;

					case 3:
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, tri.x2 << 1, tri.y2 << 1);
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x1 << 1, tri.y1 << 1, oldx1 << 1, oldy1 << 1);
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, tri.x2 << 1, tri.y2 << 1, oldx1 << 1, oldy1 << 1);
						tri.x3 = xReel;
						tri.y3 = yReel;
						numPt = 1;
						modeAddTriangle = false;
						bpAddTriangle.Enabled = true;
						SetInfo("Triangle enregistré.");
						tri.Normalise3();
						SetInfo("(" + tri.x1 + "," + tri.y1 + "),(" + tri.x2 + "," + tri.y2 + "),(" + tri.x3 + "," + tri.y3 + ")");
						lstTriangle.Add(tri);
						FillTriangle(tri);
						break;
				}
			}
			pictureBox.Refresh();
		}

		private void pictureBox_MouseLeave(object sender, EventArgs e) {
			lblInfoPos.Text = "";
		}

		private void bpAddTriangle_Click(object sender, EventArgs e) {
			numPt = 1;
			modeAddTriangle = true;
			bpAddTriangle.Enabled = false;
			SetInfo("Attente positionnement premier point triangle");
		}

		public void SetInfo(string txt) {
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
				if (xr >= xl)
					bmpLock.SetHorLineDouble(xl << 1, y << 1, (xr - xl) << 1, GetPalCPC(BitmapCpc.Palette[t.color]));
				else
					bmpLock.SetHorLineDouble((xl + xr - xl) << 1, y << 1, (xl - xr) << 1, GetPalCPC(BitmapCpc.Palette[t.color]));

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

		private void bpLoad_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				try {
					lstTriangle = (List<Triangle>)new XmlSerializer(typeof(List<Triangle>)).Deserialize(fileParam);
					SetInfo("Lecture triangles ok");
					foreach (Triangle t in lstTriangle) {
						FillTriangle(t);
					}
				}
				catch {
					MessageBox.Show("Erreur lecture fichier...");
				}
				fileParam.Close();
			}
		}

		private void bpSave_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(List<Triangle>)).Serialize(file, lstTriangle);
					SetInfo("Sauvegarde triangles ok");
				}
				catch {
					MessageBox.Show("Erreur sauvegarde triangles...");
				}
				file.Close();
			}
		}

		private void Color0_Click(object sender, EventArgs e) {
			selColor = 0;
			UpdatePalette();
		}

		private void Color1_Click(object sender, EventArgs e) {
			selColor = 1;
			UpdatePalette();
		}

		private void Color2_Click(object sender, EventArgs e) {
			selColor = 2;
			UpdatePalette();

		}

		private void Color3_Click(object sender, EventArgs e) {
			selColor = 3;
			UpdatePalette();
		}
	}
}
