﻿using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class Form1 : Form {
		private BitmapCpc bitmapCpc = new BitmapCpc();
		private DirectBitmap bmpLock;
		private bool modeAddTriangle = false, modeMoveTriangle = false, modeAddQuadri = false;
		private int numPt;
		private Triangle triSel;
		private int oldx1, oldy1;
		private int selColor = 1;
		private Bitmap bmpFond = null;
		private Projet projet = new Projet();
		private Version version = Assembly.GetExecutingAssembly().GetName().Version;

		public Form1() {
			InitializeComponent();
			lblInfoVersion.Text = "V " + version.ToString() + " - " + new DateTime(2000, 1, 1).AddDays(version.Build).ToShortDateString();
			projet.AddData();
			bmpLock = new DirectBitmap(512, 512);
			Reset();
			SetImageProjet();
		}

		public void Reset(bool force = false) {
			if (bmpFond != null) {
				for (int y = 0; y < 256; y++)
					for (int x = 0; x < 256; x++)
						bmpLock.SetHorLineDouble(x << 1, y << 1, 2, bmpFond.GetPixel(x, y).ToArgb());

			}
			else
				for (int y = 0; y < bmpLock.Height; y += 2)
					bmpLock.SetHorLineDouble(0, y, BitmapCpc.TailleX, projet.SelImage().GetPalCPC(BitmapCpc.Palette[0]));

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
			projet.SelImage().FillTriangles(bmpLock);
			Render();
		}


		private void DisplayList() {
			listTriangles.Items.Clear();
			for (int i = 0; i < projet.SelImage().lstTriangle.Count; i++) {
				Triangle t = projet.SelImage().lstTriangle[i];
				listTriangles.Items.Add("Tr." + i.ToString("000") + "\t\t(" + t.x1 + "," + t.y1 + ")\t\t(" + t.x2 + "," + t.y2 + ")\t\t(" + t.x3 + "," + t.y3 + ")\t\tcouleur:" + t.color);
			}
			txbX1.Text = txbX2.Text = txbX3.Text = txbY1.Text = txbY2.Text = txbY3.Text = txbX4.Text = txbY4.Text = txbPos.Text = "";
			bpUp.Visible = bpDown.Visible = false;
			triSel = projet.SelImage().SelectTriangle(-1);
			bpEdit.Enabled = bpDelete.Enabled = false;
		}

		private void AddTriangle(Triangle t) {
			projet.SelImage().lstTriangle.Add(t);
			projet.SelImage().FillTriangle(bmpLock, t);
			DisplayList();
		}

		private void DrawMoveTriangle(Graphics g) {
			XorDrawing.DrawXorTriangle(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x2 << 1, triSel.y2 << 1, triSel.x3 << 1, triSel.y3 << 1);
		}

		private void TrtMouseMove(object sender, MouseEventArgs e) {
			int yReel = (e.Y + 2) / 3;
			int xReel = (e.X + 2) / 3;
			lblInfoPos.Text = "x:" + xReel.ToString("000") + " y:" + yReel.ToString("000");
			if ((modeAddTriangle || modeAddQuadri) && triSel != null) {
				if (numPt == 2) {
					Graphics g = Graphics.FromImage(pictureBox.Image);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
				}
				if (numPt == 3) {
					Graphics g = Graphics.FromImage(pictureBox.Image);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2 << 1, triSel.y2 << 1, oldx1 << 1, oldy1 << 1);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2 << 1, triSel.y2 << 1, oldx1 << 1, oldy1 << 1);
				}
				if (numPt == 4) {
					Graphics g = Graphics.FromImage(pictureBox.Image);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x3 << 1, triSel.y3 << 1, oldx1 << 1, oldy1 << 1);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x3 << 1, triSel.y3 << 1, oldx1 << 1, oldy1 << 1);
				}
				pictureBox.Refresh();
			}
			if (e.Button == MouseButtons.Left && modeMoveTriangle && triSel != null) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				DrawMoveTriangle(g);
				int dx = xReel - oldx1;
				int dy = yReel - oldy1;
				projet.SelImage().DeplaceTriangle(dx, dy);
				oldx1 = xReel;
				oldy1 = yReel;
				DrawMoveTriangle(g);
				pictureBox.Refresh();
			}
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
			int yReel = (e.Y + 2) / 3;
			int xReel = (e.X + 2) / 3;
			if (e.Button == MouseButtons.Right)
				if (!modeAddTriangle && !modeAddQuadri)
					listTriangles.SelectedIndex = projet.SelImage().SelTriangle(xReel, yReel);
				else {
					modeAddTriangle = modeAddQuadri = false;
					bpAddTriangle.Enabled = bpAjoutQuadri.Enabled = true;
					FillTriangles();
				}

			if (e.Button == MouseButtons.Left && triSel != null && !modeMoveTriangle && !modeAddTriangle && !modeAddQuadri) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				DrawMoveTriangle(g);
				oldx1 = xReel;
				oldy1 = yReel;
				SetInfo("Déplacement triangle à la souris, pos départ = " + oldx1 + "," + oldy1);
				modeMoveTriangle = true;
			}
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
			int yReel = (e.Y + 2) / 3;
			int xReel = (e.X + 2) / 3;
			if (e.Button == MouseButtons.Left) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				if (modeAddTriangle && triSel != null) {
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
							XorDrawing.DrawXorTriangle(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x2 << 1, triSel.y2 << 1, oldx1 << 1, oldy1 << 1);
							triSel.x3 = xReel;
							triSel.y3 = yReel;
							numPt = 1;
							triSel.TriSommets3();
							SetInfo("Triangle enregistré : (" + triSel.x1 + "," + triSel.y1 + "),(" + triSel.x2 + "," + triSel.y2 + "),(" + triSel.x3 + "," + triSel.y3 + ")");
							AddTriangle(triSel);
							Render();
							break;
					}
				}
				if (modeAddQuadri && triSel != null) {
					switch (numPt) {
						case 1:
							triSel = new Triangle();
							triSel.x1 = xReel;
							triSel.y1 = yReel;
							triSel.color = selColor;
							numPt = 2;
							SetInfo("Attente positionnement second point quadrilatère");
							oldx1 = xReel;
							oldy1 = yReel;
							break;

						case 2:
							triSel.x2 = xReel;
							triSel.y2 = yReel;
							numPt = 3;
							SetInfo("Attente positionnement troisième point quadrilatère");
							oldx1 = xReel;
							oldy1 = yReel;
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x2 << 1, triSel.y2 << 1);
							break;

						case 3:
							triSel.x3 = xReel;
							triSel.y3 = yReel;
							numPt = 4;
							SetInfo("Attente positionnement quatrième point quadrilatère");
							break;

						case 4:
							// Effacer quadri
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, triSel.x2 << 1, triSel.y2 << 1);
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2 << 1, triSel.y2 << 1, triSel.x3 << 1, triSel.y3 << 1);
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1 << 1, triSel.y1 << 1, oldx1 << 1, oldy1 << 1);
							XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x3 << 1, triSel.y3 << 1, oldx1 << 1, oldy1 << 1);
							Triangle nt = new Triangle(triSel.x1, triSel.y1, triSel.x3, triSel.y3, oldx1, oldy1, selColor);
							triSel.TriSommets();
							triSel.TriSommets3();
							nt.TriSommets();
							nt.TriSommets3();
							SetInfo("Triangle enregistré : (" + triSel.x1 + "," + triSel.y1 + "),(" + triSel.x2 + "," + triSel.y2 + "),(" + triSel.x3 + "," + triSel.y3 + ")");
							AddTriangle(triSel);
							SetInfo("Triangle enregistré : (" + nt.x1 + "," + nt.y1 + "),(" + nt.x2 + "," + nt.y2 + "),(" + nt.x3 + "," + nt.y3 + ")");
							AddTriangle(nt);
							numPt = 1;
							Render();
							break;
					}
				}
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
			bpAddTriangle.Enabled = bpAjoutQuadri.Enabled = false;
		}

		public void SetInfo(string txt) {
			listInfo.Items.Add(DateTime.Now.ToString() + " - " + txt);
			listInfo.SelectedIndex = listInfo.Items.Count - 1;
		}

		private void DisplayMemory() {
			int nb = projet.SelImage().lstTriangle.Count;
			SetInfo("Nbre de triangles:" + nb.ToString() + " - Mémoire utilisée:" + (nb * 7).ToString() + " octets");
		}

		private void InitImage() {
			for (int i = 0; i < 4; i++)
				BitmapCpc.Palette[i] = projet.SelImage().palette[i];

			BitmapCpc.cpcPlus = chkPlus.Checked = projet.SelImage().cpcPlus;
			txbNomImage.Text = projet.SelImage().nomImage;
			txbTpsAttente.Text = projet.SelImage().tpsAttente.ToString();
			UpdatePalette();
			FillTriangles();
			DisplayList();
			//Text = "TriangulArt - " + dlg.FileName;
			switch (projet.SelImage().modeRendu) {
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
			DisplayMemory();
		}

		private void MemImage() {
			int.TryParse(txbTpsAttente.Text, out projet.SelImage().tpsAttente);
			projet.SelImage().tpsAttente = Math.Min(850, Math.Max(1, projet.SelImage().tpsAttente));
			projet.SelImage().nomImage = txbNomImage.Text;
		}

		private void bpLoad_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Fichiers xml (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				//try {
				Datas d = (Datas)new XmlSerializer(typeof(Datas)).Deserialize(fileParam);
				projet.SetImage(d);
				SetInfo("Lecture image ok");
				for (int i = 0; i < projet.SelImage().lstTriangle.Count; i++)
					projet.SelImage().lstTriangle[i].Normalise();

				InitImage();
				//}
				//catch {
				//	MessageBox.Show("Erreur lecture image ...");
				//}
				fileParam.Close();
			}
		}

		private void bpSave_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Fichiers xml (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				MemImage();
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Datas)).Serialize(file, projet.SelImage());
					DisplayMemory();
					SetInfo("Sauvegarde image ok");
				}
				catch {
					MessageBox.Show("Erreur sauvegarde image...");
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
					projet.SelImage().Import(dlg.FileName, chkClearData.Checked);
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
				int.TryParse(txbTpsAttente.Text, out projet.SelImage().tpsAttente);
				projet.SelImage().tpsAttente = Math.Min(850, Math.Max(1, projet.SelImage().tpsAttente));
				projet.SelImage().GenereSourceAsm(dlg.FileName, chkCodeAsm.Checked);
				SetInfo("Génération assembleur ok.");
			}
		}

		private void SetNewColor(int pen) {
			EditColor ed = new EditColor(pen, BitmapCpc.Palette[pen], bitmapCpc.GetColorPal(pen).GetColorArgb, BitmapCpc.cpcPlus);
			ed.ShowDialog(this);
			if (ed.isValide) {
				BitmapCpc.Palette[pen] = projet.SelImage().palette[pen] = ed.ValColor;
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
			triSel = projet.SelImage().SelectTriangle(listTriangles.SelectedIndex);
			if (triSel != null) {
				txbPos.Text = listTriangles.SelectedIndex.ToString();
				txbX1.Text = triSel.x1.ToString();
				txbY1.Text = triSel.y1.ToString();
				txbX2.Text = triSel.x2.ToString();
				txbY2.Text = triSel.y2.ToString();
				txbX3.Text = triSel.x3.ToString();
				txbY3.Text = triSel.y3.ToString();
				txbX4.Text = txbY4.Text = "";
				selColor = triSel.color;
				FillTriangles();
				UpdatePalette();
				bpEdit.Enabled = bpDelete.Enabled = true;
				bpUp.Visible = listTriangles.SelectedIndex > 0;
				bpDown.Visible = listTriangles.SelectedIndex < projet.SelImage().lstTriangle.Count - 1;
			}
			else
				DisplayList();
		}

		private void bpRedraw_Click(object sender, EventArgs e) {
			modeAddQuadri = modeAddTriangle = modeMoveTriangle = false;
			DisplayList();
			FillTriangles();
		}

		private void bpDelete_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes vous sur(e) de vouloir supprimer ce triangle ?", "Confirmation suppression", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
				projet.SelImage().DeleteSelTriangle();
				DisplayList();
				FillTriangles();
			}
		}

		private void bpEdit_Click(object sender, EventArgs e) {
			Triangle t = CheckDatas();
			if (t != null) {
				int newIndex = -1;
				int.TryParse(txbPos.Text, out newIndex);
				projet.SelImage().EditSelTriangle(t, selColor, newIndex);
				int memoSel = projet.SelImage().GetSelTriangle();
				DisplayList();
				listTriangles.SelectedIndex = memoSel;
			}
		}

		private void bpAddCoord_Click(object sender, EventArgs e) {
			Triangle t = CheckDatas();
			if (t != null) {
				Triangle tnew = null;
				if (txbX4.Text != "" && txbY4.Text != "") {
					int x1 = Convert.ToInt32(txbX1.Text);
					int y1 = Convert.ToInt32(txbY1.Text);
					int x3 = Convert.ToInt32(txbX3.Text);
					int y3 = Convert.ToInt32(txbY3.Text);
					int x4 = 0, y4 = 0;
					if (int.TryParse(txbX4.Text, out x4) && int.TryParse(txbY4.Text, out y4)) {
						if (x4 >= 0 && x4 < 256 && y4 >= 0 && y4 < 256)
							tnew = new Triangle(x1, y1, x3, y3, x4, y4, selColor);
					}
				}
				AddTriangle(t);
				SetInfo("Triangle enregistré : (" + t.x1 + "," + t.y1 + "),(" + t.x2 + "," + t.y2 + "),(" + t.x3 + "," + t.y3 + ")");
				if (tnew != null) {
					SetInfo("Triangle enregistré : (" + tnew.x1 + "," + tnew.y1 + "),(" + tnew.x2 + "," + tnew.y2 + "),(" + tnew.x3 + "," + tnew.y3 + ")");
					AddTriangle(tnew);
				}
				txbX4.Text = txbY4.Text = "";
				FillTriangles();
			}
		}

		private void chkPlus_CheckedChanged(object sender, EventArgs e) {
			projet.SelImage().cpcPlus = BitmapCpc.cpcPlus = chkPlus.Checked;
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
				projet.SelImage().Clear();
				DisplayList();
				Reset();
			}
		}

		private void bpUp_Click(object sender, EventArgs e) {
			int memoSel = listTriangles.SelectedIndex;
			projet.SelImage().UpTriangle();
			listTriangles.SelectedIndex = memoSel - 1;

		}

		private void bpDown_Click(object sender, EventArgs e) {
			int memoSel = listTriangles.SelectedIndex;
			projet.SelImage().DownTriangle();
			listTriangles.SelectedIndex = memoSel + 1;
		}

		private void rbStandard_CheckedChanged(object sender, EventArgs e) {
			projet.SelImage().modeRendu = 0;
			DisplayList();
			FillTriangles();
		}

		private void rbHorizontal_CheckedChanged(object sender, EventArgs e) {
			projet.SelImage().modeRendu = 1;
			DisplayList();
			FillTriangles();
		}

		private void rbVertical_CheckedChanged(object sender, EventArgs e) {
			projet.SelImage().modeRendu = 2;
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
					projet.SelImage().DeplaceImage(deplX, deplY);
					DisplayList();
					FillTriangles();
				}
				else
					if (triSel != null) {
						int memoSel = projet.SelImage().GetSelTriangle();
						projet.SelImage().DeplaceTriangle(deplX, deplY);
						DisplayList();
						listTriangles.SelectedIndex = memoSel;
					}
					else
						MessageBox.Show("Pas de triangle sélectionné");
			}
			else
				MessageBox.Show("Veuillez sélectionner des données de déplacement valide");
		}

		private void bpRapproche_Click(object sender, EventArgs e) {
			projet.SelImage().Rapproche(4);
			projet.SelImage().CleanUp(bmpLock);
			DisplayList();
			FillTriangles();
		}

		private void bpAjoutQuadri_Click(object sender, EventArgs e) {
			numPt = 1;
			modeAddQuadri = true;
			SetInfo("Attente positionnement premier point quadrilatère");
			bpAjoutQuadri.Enabled = bpAddTriangle.Enabled = false;
		}

		private void bpZoom_Click(object sender, EventArgs e) {
			double zoomX = 0, zoomY = 0;
			if (double.TryParse(txbTrX.Text.Replace('.', ','), out zoomX) && double.TryParse(txbTrY.Text.Replace('.', ','), out zoomY)) {
				if (rbDepImage.Checked) {
					projet.SelImage().CoefZoom(zoomX, zoomY, chkCenterZoom.Checked);
					DisplayList();
					FillTriangles();
				}
				else
					if (triSel != null) {
						int memoSel = projet.SelImage().GetSelTriangle();
						projet.SelImage().CoefZoom(triSel, zoomX, zoomY, chkCenterZoom.Checked);
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
			int nbAvant = projet.SelImage().lstTriangle.Count;
			projet.SelImage().CleanUp(bmpLock);
			int nbApres = projet.SelImage().lstTriangle.Count;
			if (nbApres != nbAvant)
				SetInfo("Nbre de triangles optimisés : " + (nbAvant - nbApres).ToString());
			else
				SetInfo("Pas d'optimisation possible.");

			DisplayList();
			FillTriangles();
			DisplayMemory();
		}

		private void SetImageProjet() {
			bpImagePrec.Visible = projet.selData > 0;
			bpImageSuiv.Visible = projet.selData < projet.nbData - 1;
			lblInfoImage.Text = (projet.selData + 1).ToString() + "/" + projet.nbData.ToString();
			InitImage();
		}

		private void bpReadProj_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Fichiers xml (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				try {
					projet = (Projet)new XmlSerializer(typeof(Projet)).Deserialize(fileParam);
					SetInfo("Lecture projet ok");
					projet.SelectImage(0);
					SetImageProjet();
				}
				catch {
					MessageBox.Show("Erreur lecture projet...");
				}
				fileParam.Close();
			}
		}

		private void bpSaveProj_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Fichiers xml (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				MemImage();
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Projet)).Serialize(file, projet);
					SetInfo("Sauvegarde projet ok");
				}
				catch {
					MessageBox.Show("Erreur sauvegarde projet...");
				}
				file.Close();
			}
		}

		private void bpNewImage_Click(object sender, EventArgs e) {
			projet.AddData();
			SetImageProjet();
		}

		private void bpSupImage_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes vous sur(e) de vouloir supprimer cette image ?", "Confirmation suppression", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
			}
		}

		private void bpImagePrec_Click(object sender, EventArgs e) {
			MemImage();
			projet.SelectImage(projet.selData - 1);
			SetImageProjet();
		}

		private void bpImageSuiv_Click(object sender, EventArgs e) {
			MemImage();
			projet.SelectImage(projet.selData + 1);
			SetImageProjet();
		}

		private void bpGenereProjetAsm_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Fichiers assembleur (*.asm)|*.asm";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				projet.GenereSourceAsm(dlg.FileName);
				SetInfo("Génération assembleur ok.");
			}
		}
	}
}
