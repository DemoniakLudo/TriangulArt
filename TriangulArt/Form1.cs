using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class Form1 : Form {
		private BitmapCpc bitmapCpc = new BitmapCpc();
		private DirectBitmap bmpLock;
		private bool modeAddTriangle = false, modeMoveTriangle = false;
		private int numPt;
		private Triangle triSel;
		private int oldx1, oldy1;
		private int selColor = 1;
		private Bitmap bmpFond = null;
		private Datas datas = new Datas();
		private Version version = Assembly.GetExecutingAssembly().GetName().Version;

		public Form1() {
			InitializeComponent();
			bmpLock = new DirectBitmap(512, 512);
			Reset();
			for (int i = 0; i < 4; i++)
				datas.palette[i] = BitmapCpc.Palette[i];

			lblInfoVersion.Text = "V " + version.ToString() + " - " + new DateTime(2000, 1, 1).AddDays(version.Build).ToShortDateString();
		}

		public void Reset(bool force = false) {
			if (bmpFond != null) {
				for (int y = 0; y < 256; y++)
					for (int x = 0; x < 256; x++)
						bmpLock.SetHorLineDouble(x << 1, y << 1, 2, bmpFond.GetPixel(x, y).ToArgb());

			}
			else
				for (int y = 0; y < bmpLock.Height; y += 2)
					bmpLock.SetHorLineDouble(0, y, BitmapCpc.TailleX, datas.GetPalCPC(BitmapCpc.Palette[0]));

			Render();
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
				if (x1 >= 0 && x1 < 256 && y1 >= 0 && y1 < 256 && x2 >= 0 && x2 < 256 && y2 >= 0 && y2 < 256 && x3 >= 0 && x3 < 256 && y3 >= 0 && y3 < 256)
					return new Triangle(x1, y1, x2, y2, x3, y3, selColor);
				else
					MessageBox.Show("Les coordonnées doivent être comprises entre 0 et 255");
			}
			else
				MessageBox.Show("Les coordonnées sont invalides");
			return null;
		}

		private void FillTriangles() {
			Reset();
			datas.FillTriangles(bmpLock);
			Render();
		}


		private void DisplayList() {
			listTriangles.Items.Clear();
			for (int i = 0; i < datas.lstTriangle.Count; i++) {
				Triangle t = datas.lstTriangle[i];
				listTriangles.Items.Add("Tr." + i.ToString("000") + "\t\t(" + t.x1 + "," + t.y1 + ")\t\t(" + t.x2 + "," + t.y2 + ")\t\t(" + t.x3 + "," + t.y3 + ")\t\tcouleur:" + t.color);
			}
			txbX1.Text = txbX2.Text = txbX3.Text = txbY1.Text = txbY2.Text = txbY3.Text = "";
			bpUp.Visible = bpDown.Visible = false;
			triSel = datas.SelectTriangle(-1);
			bpEdit.Enabled = bpDelete.Enabled = false;
		}

		private void AddTriangle(Triangle t) {
			datas.lstTriangle.Add(t);
			datas.FillTriangle(bmpLock, t);
			DisplayList();
		}

		private void DrawMoveTriangle(Graphics g) {
			XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x2 << 1, triSel.y2 << 1);
			XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x3 << 1, triSel.y3 << 1);
			XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2 << 1, triSel.y2 << 1, triSel.x3 << 1, triSel.y3 << 1);
		}

		private void TrtMouseMove(object sender, MouseEventArgs e) {
			try {
				int yReel = (e.Y & 0xFFE) >> 2;
				int xReel = e.X >> 2;
				lblInfoPos.Text = "x:" + xReel.ToString("000") + " y:" + yReel.ToString("000");
				Graphics g = Graphics.FromImage(pictureBox.Image);
				if (modeAddTriangle) {
					if (numPt == 2) {
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
						oldx1 = xReel;
						oldy1 = yReel;
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
					}
					if (numPt == 3) {
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2 << 1, triSel.y2 << 1, oldx1 << 1, oldy1 << 1);
						oldx1 = xReel;
						oldy1 = yReel;
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2 << 1, triSel.y2 << 1, oldx1 << 1, oldy1 << 1);
					}
				}
				if (e.Button == MouseButtons.Left && modeMoveTriangle) {
					DrawMoveTriangle(g);
					int dx = xReel - oldx1;
					int dy = yReel - oldy1;
					datas.DeplaceTriangle(dx, dy);
					oldx1 = xReel;
					oldy1 = yReel;
					DrawMoveTriangle(g);
				}
				pictureBox.Refresh();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.StackTrace, ex.Message);
			}
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
			int yReel = (e.Y & 0xFFE) >> 2;
			int xReel = e.X >> 2;
			if (e.Button == MouseButtons.Right)
				if (!modeAddTriangle)
					listTriangles.SelectedIndex = datas.SelTriangle(xReel, yReel);
				else {
					modeAddTriangle = false;
					bpAddTriangle.Enabled = true;
					FillTriangles();
				}

			if (e.Button == MouseButtons.Left && triSel != null && !modeMoveTriangle && !modeAddTriangle) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				DrawMoveTriangle(g);
				oldx1 = xReel;
				oldy1 = yReel;
				SetInfo("Déplacement triangle à la souris, pos départ = " + oldx1 + "," + oldy1);
				modeMoveTriangle = true;
			}
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
			int yReel = (e.Y & 0xFFE) >> 2;
			int xReel = e.X >> 2;
			if (e.Button == MouseButtons.Left) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				if (modeAddTriangle) {
					switch (numPt) {
						case 1:
							triSel = new Triangle();
							triSel.x1 = xReel;
							triSel.y1 = yReel;
							triSel.color = selColor;
							numPt = 2;
							SetInfo("Attente positionnement second point triangle");
							oldx1 = xReel;
							oldy1 = yReel;
							break;

						case 2:
							triSel.x2 = xReel;
							triSel.y2 = yReel;
							triSel.TriSommets();
							numPt = 3;
							SetInfo("Attente positionnement troisième point triangle");
							oldx1 = xReel;
							oldy1 = yReel;
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x2 << 1, triSel.y2 << 1);
							break;

						case 3:
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x2 << 1, triSel.y2 << 1);
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2 << 1, triSel.y2 << 1, oldx1 << 1, oldy1 << 1);
							triSel.x3 = xReel;
							triSel.y3 = yReel;
							numPt = 1;
							triSel.TriSommets3();
							SetInfo("Triangle enregistré : (" + triSel.x1 + "," + triSel.y1 + "),(" + triSel.x2 + "," + triSel.y2 + "),(" + triSel.x3 + "," + triSel.y3 + ")");
							AddTriangle(triSel);
							break;
					}
				}
				else
					if (modeMoveTriangle) {
						DrawMoveTriangle(g);
						modeMoveTriangle = false;
						DisplayList();
						FillTriangles();
					}
			}
		}

		private void pictureBox_MouseLeave(object sender, EventArgs e) {
			lblInfoPos.Text = "";
		}

		private void bpAddTriangle_Click(object sender, EventArgs e) {
			numPt = 1;
			modeAddTriangle = true;
			SetInfo("Attente positionnement premier point triangle");
			bpAddTriangle.Enabled = false;
		}

		public void SetInfo(string txt) {
			listInfo.Items.Add(DateTime.Now.ToString() + " - " + txt);
			listInfo.SelectedIndex = listInfo.Items.Count - 1;
		}

		private void bpLoad_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Fichiers xml (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				try {
					datas = (Datas)new XmlSerializer(typeof(Datas)).Deserialize(fileParam);
					SetInfo("Lecture triangles ok");
					for (int i = 0; i < datas.lstTriangle.Count; i++)
						datas.lstTriangle[i].Normalise();

					switch (datas.modeRendu) {
						case 0:
							rbStandard.Checked = true;
							break;

						case 1:
							rbHorizontal.Checked = true;
							break;

						case 2:
							rbVertical.Checked = true;
							break;
					}

					for (int i = 0; i < 4; i++)
						BitmapCpc.Palette[i] = datas.palette[i];

					UpdatePalette();
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
			dlg.Filter = "Fichiers xml (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Datas)).Serialize(file, datas);
					SetInfo("Sauvegarde triangles ok");
				}
				catch {
					MessageBox.Show("Erreur sauvegarde triangles...");
				}
				file.Close();
			}
		}

		private void bpImport_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Fichiers assembleur (*.asm)|*.asm";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				try {
					datas.Import(dlg.FileName, chkClearData.Checked);
					SetInfo("Import triangles ok");
					FillTriangles();
					DisplayList();
				}
				catch {
					MessageBox.Show("Erreur lors de l'importation des données...");
				}
			}
		}

		private void bpGenereAsm_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Fichiers assembleur (*.asm)|*.asm";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				datas.GenereSourceAsm(dlg.FileName, chkCodeAsm.Checked, chkPlus.Checked);
				SetInfo("Génération assembleur ok.");
			}
		}

		private void SetNewColor(int pen) {
			EditColor ed = new EditColor(pen, BitmapCpc.Palette[pen], bitmapCpc.GetColorPal(pen).GetColorArgb, BitmapCpc.cpcPlus);
			ed.ShowDialog(this);
			if (ed.isValide) {
				BitmapCpc.Palette[pen] = datas.palette[pen] = ed.ValColor;
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

		private void listTriangles_SelectedIndexChanged(object sender, EventArgs e) {
			triSel = datas.SelectTriangle(listTriangles.SelectedIndex);
			if (triSel != null) {
				txbX1.Text = triSel.x1.ToString();
				txbY1.Text = triSel.y1.ToString();
				txbX2.Text = triSel.x2.ToString();
				txbY2.Text = triSel.y2.ToString();
				txbX3.Text = triSel.x3.ToString();
				txbY3.Text = triSel.y3.ToString();
				selColor = triSel.color;
				FillTriangles();
				UpdatePalette();
				bpEdit.Enabled = bpDelete.Enabled = true;
				bpUp.Visible = listTriangles.SelectedIndex > 0;
				bpDown.Visible = listTriangles.SelectedIndex < datas.lstTriangle.Count - 1;
			}
			else
				DisplayList();
		}

		private void bpRedraw_Click(object sender, EventArgs e) {
			DisplayList();
			FillTriangles();
		}

		private void bpDelete_Click(object sender, EventArgs e) {
			datas.DeleteSelTriangle();
			DisplayList();
			FillTriangles();
		}

		private void bpEdit_Click(object sender, EventArgs e) {
			Triangle t = CheckDatas();
			if (t != null) {
				datas.EditSelTriangle(t, selColor);
				int memoSel = datas.GetSelTriangle();
				DisplayList();
				listTriangles.SelectedIndex = memoSel;
			}
		}

		private void bpAddCoord_Click(object sender, EventArgs e) {
			Triangle t = CheckDatas();
			if (t != null) {
				SetInfo("Triangle enregistré : (" + t.x1 + "," + t.y1 + "),(" + t.x2 + "," + t.y2 + "),(" + t.x3 + "," + t.y3 + ")");
				AddTriangle(t);
				FillTriangles();
			}
		}

		private void chkPlus_CheckedChanged(object sender, EventArgs e) {
			BitmapCpc.cpcPlus = chkPlus.Checked;
			FillTriangles();
		}

		private void bpImportImage_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Fichier image (*.bmp, *.gif, *.png, *.jpg,*.jpeg)|*.bmp;*.gif;*.png;*.jpg;*.jpeg;";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				using (Bitmap b = new Bitmap(dlg.FileName)) {
					if (b.Width == 256 && b.Height == 256) {
						bmpFond = new Bitmap(b);
						Reset();
						SetInfo("Lecture image de fond ok.");
					}
					else
						MessageBox.Show("L'image n'a pas le bon format (256x256 pixels)");
				}
			}
		}

		private void bpClear_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes vous certain de vouloir tout effacer ?", "Confirmation d'effacement", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				if (bmpFond != null) {
					bmpFond.Dispose();
					bmpFond = null;
				}
				datas.Clear();
				DisplayList();
				Reset();
			}
		}

		private void bpUp_Click(object sender, EventArgs e) {
			int memoSel = listTriangles.SelectedIndex;
			datas.UpTriangle();
			listTriangles.SelectedIndex = memoSel - 1;

		}

		private void bpDown_Click(object sender, EventArgs e) {
			int memoSel = listTriangles.SelectedIndex;
			datas.DownTriangle();
			listTriangles.SelectedIndex = memoSel + 1;
		}

		private void rbStandard_CheckedChanged(object sender, EventArgs e) {
			datas.modeRendu = 0;
			DisplayList();
			FillTriangles();
		}

		private void rbHorizontal_CheckedChanged(object sender, EventArgs e) {
			datas.modeRendu = 1;
			DisplayList();
			FillTriangles();
		}

		private void rbVertical_CheckedChanged(object sender, EventArgs e) {
			datas.modeRendu = 2;
			DisplayList();
			FillTriangles();
		}

		private void bpClearList_Click(object sender, EventArgs e) {
			listInfo.Items.Clear();
		}

		private void bpDeplace_Click(object sender, EventArgs e) {
			int deplX = 0, deplY = 0;
			if (int.TryParse(txbTrX.Text, out deplX) && int.TryParse(txbTrY.Text, out deplY)) {
				if (rbDepImage.Checked) {
					datas.DeplaceImage(deplX, deplY);
					DisplayList();
					FillTriangles();
				}
				else
					if (triSel != null) {
						int memoSel = datas.GetSelTriangle();
						datas.DeplaceTriangle(deplX, deplY);
						DisplayList();
						listTriangles.SelectedIndex = memoSel;
					}
					else
						MessageBox.Show("Pas de triangle sélectionné");
			}
			else
				MessageBox.Show("Veuillez sélectionner des données de déplacement valide");
		}

		private void bpZoom_Click(object sender, EventArgs e) {
			double zoomX = 0, zoomY = 0;
			if (double.TryParse(txbTrX.Text.Replace('.', ','), out zoomX) && double.TryParse(txbTrY.Text.Replace('.', ','), out zoomY)) {
				if (rbDepImage.Checked) {
					datas.CoefZoom(zoomX, zoomY);
					DisplayList();
					FillTriangles();
				}
				else
					if (triSel != null) {
						int memoSel = datas.GetSelTriangle();
						datas.CoefZoom(triSel, zoomX, zoomY);
						DisplayList();
						listTriangles.SelectedIndex = memoSel;
					}
					else
						MessageBox.Show("Pas de triangle sélectionné");
			}
			else
				MessageBox.Show("Veuillez sélectionner des données de zoom valide");

		}

		private void bpClean_Click(object sender, EventArgs e) {
			datas.CleanUp();
			DisplayList();
			FillTriangles();
		}
	}
}
