using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
		private int selLigne = -1;

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

		private void Render(bool forceDrawZoom = false) {
			UpdatePalette();
			pictureBox.Image = bmpLock.Bitmap;
			pictureBox.Refresh();
		}

		private Triangle CheckDatas() {
			int x1, y1, x2, y2, x3, y3;
			if (int.TryParse(txbX1.Text, out x1)
				&& int.TryParse(txbY1.Text, out y1)
				&& int.TryParse(txbX2.Text, out x2)
				&& int.TryParse(txbY2.Text, out y2)
				&& int.TryParse(txbX3.Text, out x3)
				&& int.TryParse(txbY3.Text, out y3)) {
				if (x1 >= 0 && x1 < 256 && y1 >= 0 && y1 < 256 && x2 >= 0 && x2 < 256 && y2 >= 0 && y2 < 256 && x3 >= 0 && x3 < 256 && y3 >= 0 && y3 < 256) {
					Triangle t = new Triangle(x1, y1, x2, y2, x3, y3);
					t.color = selColor;
					t.Normalise2();
					t.Normalise3();
					return t;
				}
				else
					MessageBox.Show("Les coordonnées doivent être comprises entre 0 et 255");
			}
			else
				MessageBox.Show("Les coordonnées sont invalides");
			return null;
		}

		private void DisplayList() {
			listTriangles.Items.Clear();
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				listTriangles.Items.Add("Triangle " + i.ToString("000") + " : (" + t.x1 + "," + t.y1 + "),(" + t.x2 + "," + t.y2 + "),(" + t.x3 + "," + t.y3 + ")");
			}
			txbX1.Text = txbX2.Text = txbX3.Text = txbY1.Text = txbY2.Text = txbY3.Text = "";
			selLigne = -1;
			bpEdit.Enabled = bpDelete.Enabled = false;
		}

		private void AddTriangle(Triangle t) {
			lstTriangle.Add(t);
			FillTriangle(t);
			DisplayList();
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
						tri.Normalise3();
						SetInfo("Triangle enregistré : (" + tri.x1 + "," + tri.y1 + "),(" + tri.x2 + "," + tri.y2 + "),(" + tri.x3 + "," + tri.y3 + ")");
						AddTriangle(tri);
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

		private void FillTriangle(Triangle t, bool selected = false) {
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
				int color = selected ? (y << 13) + (y << 3) + (y << 22) : GetPalCPC(BitmapCpc.Palette[t.color]);
				if (xr > xl)
					bmpLock.SetHorLineDouble(xl << 1, y << 1, (xr - xl) << 1, color);
				else
					bmpLock.SetHorLineDouble((xl + xr - xl) << 1, y << 1, (xl - xr) << 1, color);

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
		}

		private void FillTriangles() {
			Reset();
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				FillTriangle(t, i == selLigne);
			}
			Render();
		}

		private void GenereDatas(string fileName) {
			StreamWriter sw = File.CreateText(fileName);
			int nbOctets = 0;
			for (int i = 0; i < lstTriangle.Count; i++) {
				Triangle t = lstTriangle[i];
				int color = i < lstTriangle.Count - 1 ? t.color : t.color + 0x80;
				sw.WriteLine("\tDB\t#" + t.x1.ToString("X2") + ",#" + t.y1.ToString("X2") + ",#" + t.x2.ToString("X2") + ",#" + t.y2.ToString("X2") + ",#" + t.x3.ToString("X2") + ",#" + t.y3.ToString("X2") + ",#" + color.ToString("X2"));
				nbOctets += 7;
			}
			sw.WriteLine("; Taille " + nbOctets.ToString() + " octets");
			sw.Close();
		}

		private void bpLoad_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				try {
					lstTriangle = (List<Triangle>)new XmlSerializer(typeof(List<Triangle>)).Deserialize(fileParam);
					SetInfo("Lecture triangles ok");
					FillTriangles();
					DisplayList();
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

		private void SetNewColor(int pen) {
			EditColor ed = new EditColor( pen, BitmapCpc.Palette[pen], bitmapCpc.GetColorPal(pen).GetColorArgb, BitmapCpc.cpcPlus);
			ed.ShowDialog(this);
			if (ed.isValide) {
				BitmapCpc.Palette[pen] = ed.ValColor;
				UpdatePalette();
				FillTriangles();
			}
		}

		private void Color0_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				selColor = 0;
				UpdatePalette();
			}
			else
				SetNewColor(0);
		}

		private void Color1_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				selColor = 1;
				UpdatePalette();
			}
			else
				SetNewColor(1);
		}

		private void Color2_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				selColor = 2;
				UpdatePalette();
			}
			else
				SetNewColor(2);
		}

		private void Color3_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				selColor = 3;
				UpdatePalette();
			}
			else
				SetNewColor(3);
		}

		private void bpGenereAsm_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				GenereDatas(dlg.FileName);
			}
		}

		private void SetSelect() {
			if (selLigne != -1) {
				txbX1.Text = lstTriangle[selLigne].x1.ToString();
				txbY1.Text = lstTriangle[selLigne].y1.ToString();
				txbX2.Text = lstTriangle[selLigne].x2.ToString();
				txbY2.Text = lstTriangle[selLigne].y2.ToString();
				txbX3.Text = lstTriangle[selLigne].x3.ToString();
				txbY3.Text = lstTriangle[selLigne].y3.ToString();
				FillTriangles();
				bpEdit.Enabled = bpDelete.Enabled = true;
			}
			else
				DisplayList();
		}

		private void listTriangles_SelectedIndexChanged(object sender, EventArgs e) {
			selLigne = listTriangles.SelectedIndex;
			SetSelect();
		}

		private void bpRedraw_Click(object sender, EventArgs e) {
			FillTriangles();
			DisplayList();
		}

		private void bpDelete_Click(object sender, EventArgs e) {
			lstTriangle.RemoveAt(selLigne);
			DisplayList();
			FillTriangles();
		}

		private void bpEdit_Click(object sender, EventArgs e) {
			Triangle t = CheckDatas();
			if (t != null) {
				lstTriangle[selLigne].x1 = t.x1;
				lstTriangle[selLigne].y1 = t.y1;
				lstTriangle[selLigne].x2 = t.x2;
				lstTriangle[selLigne].y2 = t.y2;
				lstTriangle[selLigne].x3 = t.x3;
				lstTriangle[selLigne].y3 = t.y3;
				int memoSel = selLigne;
				DisplayList();
				listTriangles.SelectedIndex = memoSel;
			}
		}

		private void bpAddCoord_Click(object sender, EventArgs e) {
			Triangle t = CheckDatas();
			if (t != null) {
				SetInfo("Triangle enregistré : (" + t.x1 + "," + t.y1 + "),(" + t.x2 + "," + t.y2 + "),(" + t.x3 + "," + t.y3 + ")");
				AddTriangle(t);
			}
		}
	}
}
