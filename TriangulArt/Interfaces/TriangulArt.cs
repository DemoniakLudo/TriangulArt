using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class TriangulArt : Form {
		private PaletteCpc bitmapCpc = new PaletteCpc();
		private DirectBitmap bmpLock;
		private enum DrawMd { NONE = 0, MOVETRIANGLE, ADDTRIANGLE, ADDQUADRI, ADDRECTANGLE, ADDCERCLE, ADDLINE };
		private DrawMd mouseOpt = DrawMd.NONE;
		private int numPt, nbr;
		private Triangle triSel;
		private int oldx1, oldy1;
		private int selColor = 1;
		private Bitmap bmpFond = null;
		private Projet projet = new Projet();
		private Version version = Assembly.GetExecutingAssembly().GetName().Version;
		private const int MAX_RAYONS = 32;
		private int maxWidth;
		private int coefX;
		private Label[] colors = new Label[16];

		public TriangulArt() {
			InitializeComponent();
			for (int i = 0; i < 16; i++) {
				// Générer les contrôles de "couleurs"
				colors[i] = new Label();
				colors[i].BorderStyle = BorderStyle.FixedSingle;
				colors[i].Location = new Point(966, 4 + i * 48);
				colors[i].Size = new Size(40, 32);
				colors[i].Tag = i;
				colors[i].MouseClick += ClickColor;
				Controls.Add(colors[i]);
			}
			lblInfoVersion.Text = "V " + version.ToString() + " - " + new DateTime(2000, 1, 1).AddDays(version.Build).ToShortDateString();
			projet.AddData();
			SetNewMode(true);
			Reset();
			SetImageProjet();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			switch (keyData) {
				case Keys.Left:
					if (projet.selData > 0)
						bpImagePrec_Click(null, null);

					return true;

				case Keys.Right:
					if (projet.selData < projet.lstData.Count - 1)
						bpImageSuiv_Click(null, null);

					return true;

				case Keys.Delete:
					DeleteSelTriangle();
					return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		public void Reset(bool force = false) {
			if (bmpFond != null) {
				for (int y = 0; y < 256; y++)
					for (int x = 0; x < maxWidth; x++)
						bmpLock.SetPixel(x, y, bmpFond.GetPixel(x, y).ToArgb());
			}
			else
				for (int y = 0; y < bmpLock.Height; y++)
					bmpLock.SetHorLine(0, y, maxWidth, projet.SelImage().GetPalCPC(PaletteCpc.Palette[0]));

			Render();
		}

		public void ResetNoRender(bool force = false) {
			if (bmpFond != null) {
				for (int y = 0; y < 256; y++)
					for (int x = 0; x < maxWidth; x++)
						bmpLock.SetPixel(x, y, bmpFond.GetPixel(x, y).ToArgb());
			}
			else
				for (int y = 0; y < bmpLock.Height; y++)
					bmpLock.SetHorLine(0, y, maxWidth, projet.SelImage().GetPalCPC(PaletteCpc.Palette[0]));
		}

		// Changement de la palette
		private void ClickColor(object sender, MouseEventArgs e) {
			Label colorClick = sender as Label;
			int pen = colorClick.Tag != null ? (int)colorClick.Tag : 0;
			if (e.Button == MouseButtons.Left) {
				selColor = pen;
				UpdatePalette();
			}
			else
				SetNewColor(pen);
		}

		private void UpdatePalette() {
			for (int i = 0; i < 16; i++)
				colors[i].BackColor = Color.FromArgb(PaletteCpc.GetColorPal(i).GetColorArgb);

			ColorSel.BackColor = Color.FromArgb(PaletteCpc.GetColorPal(selColor).GetColorArgb);
		}

		private void pictureBox_Paint(object sender, PaintEventArgs e) {
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(bmpLock.Bitmap, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height), 0, 0, bmpLock.Bitmap.Width, bmpLock.Bitmap.Height, GraphicsUnit.Pixel);
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
				if (x1 >= 0 && x1 < maxWidth && y1 >= 0 && y1 < 256 && x2 >= 0 && x2 < maxWidth && y2 >= 0 && y2 < 256 && x3 >= 0 && x3 < maxWidth && y3 >= 0 && y3 < 256)
					return new Triangle(x1, y1, x2, y2, x3, y3, selColor);
				else
					MessageBox.Show("Les coordonnées doivent être comprises entre 0 et 255");
			}
			else
				MessageBox.Show("Les coordonnées sont invalides");
			return null;
		}

		private void FillTriangles() {
			ResetNoRender();
			projet.SelImage().FillTriangles(bmpLock, maxWidth, chkLine.Checked);
			Render();
			bpAjoutLigne.Enabled=			bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = true;
			mouseOpt = DrawMd.NONE;
		}

		private void DisplayList() {
			listTriangles.Items.Clear();
			for (int i = 0; i < projet.SelImage().lstTriangle.Count; i++) {
				Triangle t = projet.SelImage().lstTriangle[i];
				string inf = "Tr." + i.ToString("000") + "\t\t(" + t.x1 + "," + t.y1 + ")\t\t(" + t.x2 + "," + t.y2 + ")\t\t(" + t.x3 + "," + t.y3 + ")\t\tcouleur:" + t.color;
				if (t.GetPctFill() != -1) {
					int f = t.GetPctFill();
					inf += "\t\t" + f + "%";
					if (f < 10)
						inf += "====";

					if (f < 25)
						inf += "===";

					if (f < 40)
						inf += "==";

					if (f < 50)
						inf += "=";
				}
				listTriangles.Items.Add(inf);
			}
			txbX1.Text = txbX2.Text = txbX3.Text = txbY1.Text = txbY2.Text = txbY3.Text = txbX4.Text = txbY4.Text = txbPos.Text = "";
			bpUp.Enabled = bpDown.Enabled = bpFirst.Enabled = bpLast.Enabled = false;
			triSel = projet.SelImage().SelectTriangle(-1);
			bpEdit.Enabled = bpDelete.Enabled = false;
		}

		private void AddTriangle(Triangle t) {
			projet.SelImage().lstTriangle.Add(t);
			projet.SelImage().FillTriangle(bmpLock, t, maxWidth, chkLine.Checked);
			DisplayList();
		}

		private void DrawMoveTriangle(Graphics g) {
			XorDrawing.DrawXorTriangle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2, triSel.x3, triSel.y3);
		}

		private void TrtMouseMove(object sender, MouseEventArgs e) {
			int yReel = (e.Y + 2) / 3;
			int xReel = (e.X + 2) / coefX;
			lblInfoPos.Text = "x:" + xReel.ToString("000") + " y:" + yReel.ToString("000");
			if ((mouseOpt == DrawMd.ADDTRIANGLE || mouseOpt == DrawMd.ADDQUADRI || mouseOpt==DrawMd.ADDLINE) && triSel != null) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				if (numPt == 2) {
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
				}
				if (numPt == 3) {
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2, triSel.y2, oldx1, oldy1);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2, triSel.y2, oldx1, oldy1);
				}
				if (numPt == 4) {
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x3, triSel.y3, oldx1, oldy1);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x3, triSel.y3, oldx1, oldy1);
				}
				pictureBox.Refresh();
			}
			if (mouseOpt == DrawMd.ADDRECTANGLE && triSel != null) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				if (numPt == 2) {
					XorDrawing.DrawXorRectangle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorRectangle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
				}
				pictureBox.Refresh();
			}
			if (mouseOpt == DrawMd.ADDCERCLE && triSel != null) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				if (numPt == 2) {
					XorDrawing.DrawXorCercle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1, nbr);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorCercle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1, nbr);
				}
				pictureBox.Refresh();
			}
			if (e.Button == MouseButtons.Left && mouseOpt == DrawMd.MOVETRIANGLE && triSel != null) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				DrawMoveTriangle(g);
				int dx = xReel - oldx1;
				int dy = yReel - oldy1;
				projet.SelImage().DeplaceTriangle(dx, dy, maxWidth);
				oldx1 = xReel;
				oldy1 = yReel;
				DrawMoveTriangle(g);
				pictureBox.Refresh();
			}
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
			int yReel = (e.Y + 2) / 3;
			int xReel = (e.X + 2) / coefX;
			if (e.Button == MouseButtons.Right)
				if (mouseOpt == DrawMd.NONE)
					listTriangles.SelectedIndex = projet.SelImage().SelTriangle(xReel, yReel);
				else
					FillTriangles();


			if (e.Button == MouseButtons.Left && triSel != null && mouseOpt == DrawMd.NONE) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				DrawMoveTriangle(g);
				oldx1 = xReel;
				oldy1 = yReel;
				SetInfo("Déplacement triangle à la souris, pos départ = " + oldx1 + "," + oldy1);
				mouseOpt = DrawMd.MOVETRIANGLE;
			}
		}

		// Mémorisation des points pour tracé triangle
		private void MemoPtTriangle(Graphics g, int xReel, int yReel) {
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
					if (triSel != null) {
						triSel.x2 = xReel;
						triSel.y2 = yReel;
						triSel.TriSommets();
						numPt = 3;
						SetInfo("Attente positionnement troisième point triangle");
						oldx1 = xReel;
						oldy1 = yReel;
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2);
					}
					break;

				case 3:
					if (triSel != null) {
						XorDrawing.DrawXorTriangle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2, oldx1, oldy1);
						triSel.x3 = xReel;
						triSel.y3 = yReel;
						numPt = 1;
						triSel.TriSommets3();
						SetInfo("Triangle enregistré : (" + triSel.x1 + "," + triSel.y1 + "),(" + triSel.x2 + "," + triSel.y2 + "),(" + triSel.x3 + "," + triSel.y3 + ")");
						AddTriangle(triSel);
						Render();
					}
					break;
			}
		}

		// Mémorisation des points pour tracé quadrilatère
		private void MemoPtQuadri(Graphics g, int xReel, int yReel) {
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
					if (triSel != null) {
						triSel.x2 = xReel;
						triSel.y2 = yReel;
						numPt = 3;
						SetInfo("Attente positionnement troisième point quadrilatère");
						oldx1 = xReel;
						oldy1 = yReel;
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2);
					}
					break;

				case 3:
					if (triSel != null) {
						triSel.x3 = xReel;
						triSel.y3 = yReel;
						numPt = 4;
						SetInfo("Attente positionnement quatrième point quadrilatère");
					}
					break;

				case 4:
					if (triSel != null) {
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2);
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x2, triSel.y2, triSel.x3, triSel.y3);
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
						XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x3, triSel.y3, oldx1, oldy1);
						Triangle nt = new Triangle(triSel.x1, triSel.y1, triSel.x3, triSel.y3, oldx1, oldy1, selColor);
						triSel.TriSommets();
						triSel.TriSommets3();
						SetInfo("Triangle enregistré : (" + triSel.x1 + "," + triSel.y1 + "),(" + triSel.x2 + "," + triSel.y2 + "),(" + triSel.x3 + "," + triSel.y3 + ")");
						AddTriangle(triSel);
						SetInfo("Triangle enregistré : (" + nt.x1 + "," + nt.y1 + "),(" + nt.x2 + "," + nt.y2 + "),(" + nt.x3 + "," + nt.y3 + ")");
						AddTriangle(nt);
						numPt = 1;
						Render();
					}
					break;
			}
		}

		// Mémorisation des points pour tracé rectangle
		private void MemoPtRectangle(Graphics g, int xReel, int yReel) {
			switch (numPt) {
				case 1:
					triSel = new Triangle();
					triSel.x1 = xReel;
					triSel.y1 = yReel;
					triSel.color = selColor;
					numPt = 2;
					SetInfo("Attente positionnement second point rectangle");
					oldx1 = xReel;
					oldy1 = yReel;
					break;

				case 2:
					XorDrawing.DrawXorRectangle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1);
					triSel.x3 = oldx1;
					triSel.y3 = oldy1;
					triSel.x2 = triSel.x3;
					triSel.y2 = triSel.y1;
					Triangle nt = new Triangle(triSel.x1, triSel.y1, triSel.x1, triSel.y3, triSel.x3, triSel.y3, selColor);
					triSel.TriSommets();
					triSel.TriSommets3();
					SetInfo("Triangle enregistré : (" + triSel.x1 + "," + triSel.y1 + "),(" + triSel.x2 + "," + triSel.y2 + "),(" + triSel.x3 + "," + triSel.y3 + ")");
					AddTriangle(triSel);
					SetInfo("Triangle enregistré : (" + nt.x1 + "," + nt.y1 + "),(" + nt.x2 + "," + nt.y2 + "),(" + nt.x3 + "," + nt.y3 + ")");
					AddTriangle(nt);
					numPt = 1;
					Render();
					break;
			}
		}

		// Mémorisation des points pour tracé cercle
		private void MemoPtCercle(Graphics g, int xReel, int yReel) {
			switch (numPt) {
				case 1:
					triSel = new Triangle();
					triSel.x1 = xReel;
					triSel.y1 = yReel;
					triSel.color = selColor;
					numPt = 2;
					SetInfo("Attente définition rayon cercle");
					oldx1 = xReel;
					oldy1 = yReel;
					break;

				case 2:
					XorDrawing.DrawXorCercle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, oldx1, oldy1, nbr);
					double r = Math.Sqrt((oldx1 - triSel.x1) * (oldx1 - triSel.x1) + (oldy1 - triSel.y1) * (oldy1 - triSel.y1));
					int x1 = triSel.x1;
					int y1 = triSel.y1;
					int ang = (360 / nbr);
					for (int a = 0; a < 360; a += ang) {
						int x2 = x1 + (int)(r * Math.Cos(a / 180.0 * Math.PI));
						int y2 = y1 + (int)(r * Math.Sin(a / 180.0 * Math.PI));
						int x3 = x1 + (int)(r * Math.Cos((a - ang) / 180.0 * Math.PI));
						int y3 = y1 + (int)(r * Math.Sin((a - ang) / 180.0 * Math.PI));
						Triangle t = new Triangle(x1, y1, x2, y2, x3, y3, selColor);
						AddTriangle(t);
						SetInfo("Triangle enregistré : (" + t.x1 + "," + t.y1 + "),(" + t.x2 + "," + t.y2 + "),(" + t.x3 + "," + t.y3 + ")");
					}
					numPt = 1;
					Render();
					break;
			}
		}

		// Mémorisation des points pour tracé ligne
		private void MemoPtLine(Graphics g, int xReel, int yReel) {
			switch (numPt) {
				case 1:
					triSel = new Triangle();
					triSel.x1 = xReel;
					triSel.y1 = yReel;
					triSel.color = selColor;
					numPt = 2;
					triSel.x2 = xReel;
					triSel.y2 = yReel<255?yReel+1:yReel-1;
					triSel.TriSommets();
					numPt = 2;
					SetInfo("Attente positionnement second point ligne");
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorLine(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2);
					break;

				case 2:
					if (triSel != null) {
						XorDrawing.DrawXorTriangle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2, oldx1, oldy1);
						triSel.x3 = xReel;
						triSel.y3 = yReel;
						numPt = 1;
						triSel.TriSommets3();
						SetInfo("Triangle enregistré : (" + triSel.x1 + "," + triSel.y1 + "),(" + triSel.x2 + "," + triSel.y2 + "),(" + triSel.x3 + "," + triSel.y3 + ")");
						AddTriangle(triSel);
						Render();
					}
					break;
			}
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
			int yReel = (e.Y + 2) / 3;
			int xReel = (e.X + 2) / coefX;
			if (e.Button == MouseButtons.Left) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				switch (mouseOpt) {
					case DrawMd.MOVETRIANGLE:
						DrawMoveTriangle(g);
						DisplayList();
						FillTriangles();
						break;

					case DrawMd.ADDTRIANGLE:
						MemoPtTriangle(g, xReel, yReel);
						break;

					case DrawMd.ADDQUADRI:
						MemoPtQuadri(g, xReel, yReel);
						break;

					case DrawMd.ADDRECTANGLE:
						MemoPtRectangle(g, xReel, yReel);
						break;

					case DrawMd.ADDCERCLE:
						MemoPtCercle(g, xReel, yReel);
						break;

					case DrawMd.ADDLINE:
						MemoPtLine(g, xReel, yReel);
						break;
				}
			}
		}

		private void pictureBox_MouseLeave(object sender, EventArgs e) {
			lblInfoPos.Text = "";
		}

		public void SetInfo(string txt) {
			listInfo.Items.Add(DateTime.Now.ToString() + " - " + txt);
			listInfo.SelectedIndex = listInfo.Items.Count - 1;
		}

		private void DisplayMemory() {
			int nbTri = projet.SelImage().lstTriangle.Count;
			int mem = chkModePolice.Checked ? (nbTri * 6) + 2 : (nbTri * 7) + 6;
			SetInfo("Nbre de triangles:" + nbTri.ToString() + " - Mémoire utilisée:" + mem + " octets");
		}

		private void DisplayMemoryProjet() {
			int nbTri = 0, nbImg = projet.lstData.Count;
			foreach (Datas d in projet.lstData) {
				nbTri += d.lstTriangle.Count;
			}
			int mem = chkModePolice.Checked ? (nbTri * 6) + (nbImg * 2) : (nbTri * 7) + (nbImg * 6);
			SetInfo("Nbre de triangles du projet:" + nbTri.ToString() + " - Mémoire utilisée:" + mem.ToString() + " octets");
		}

		private void InitImage() {
			for (int i = 0; i < 16; i++)
				PaletteCpc.Palette[i] = projet.SelImage().palette[i];

			PaletteCpc.cpcPlus = chkPlus.Checked = projet.cpcPlus;
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
			if (chkAnim3D.Checked)
				DisplayMemoryProjet();
			else
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
				try {
					Datas d = (Datas)new XmlSerializer(typeof(Datas)).Deserialize(fileParam);
					projet.SetImage(d);
					SetInfo("Lecture image ok");
					for (int i = 0; i < projet.SelImage().lstTriangle.Count; i++)
						projet.SelImage().lstTriangle[i].Normalise();

					InitImage();
				}
				catch {
					MessageBox.Show("Erreur lecture image ...");
				}
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
				projet.SelImage().GenereSourceAsm(dlg.FileName, projet.mode, projet.cpcPlus, chkCodeAsm.Checked, chkModePolice.Checked, chkAnim3D.Checked);
				SetInfo("Génération assembleur ok.");
			}
		}

		private void SetNewColor(int pen) {
			EditColor ed = new EditColor(pen, PaletteCpc.Palette[pen], PaletteCpc.GetColorPal(pen).GetColorArgb, PaletteCpc.cpcPlus);
			ed.ShowDialog(this);
			if (ed.isValide) {
				if (chkAnim3D.Checked) {
					foreach (Datas d in projet.lstData)
						PaletteCpc.Palette[pen] = d.palette[pen] = ed.ValColor;

					DisplayList();
					FillTriangles();
					DisplayMemory();
				}
				else {
					PaletteCpc.Palette[pen] = projet.SelImage().palette[pen] = ed.ValColor;
					UpdatePalette();
					FillTriangles();
				}
			}
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
				bpFirst.Enabled = bpUp.Enabled = listTriangles.SelectedIndex > 0;
				bpLast.Enabled = bpDown.Enabled = listTriangles.SelectedIndex < projet.SelImage().lstTriangle.Count - 1;
			}
			else
				DisplayList();
		}

		private void bpRedraw_Click(object sender, EventArgs e) {
			projet.SelImage().CleanUp(maxWidth, true);
			DisplayList();
			FillTriangles();
		}

		private void DeleteSelTriangle() {
			if (triSel != null && MessageBox.Show("Etes vous sur(e) de vouloir supprimer ce triangle ?", "Confirmation suppression", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
				projet.SelImage().DeleteSelTriangle();
				DisplayList();
				FillTriangles();
			}
		}

		private void bpDelete_Click(object sender, EventArgs e) {
			DeleteSelTriangle();
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
						if (x4 >= 0 && x4 < maxWidth && y4 >= 0 && y4 < 256)
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
			projet.cpcPlus = PaletteCpc.cpcPlus = chkPlus.Checked;
			FillTriangles();
		}

		private void bpImportImage_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Fichier image (*.bmp, *.gif, *.png, *.jpg,*.jpeg)|*.bmp;*.gif;*.png;*.jpg;*.jpeg;";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				using (Bitmap b = new Bitmap(dlg.FileName)) {
					if (b.Width == maxWidth && b.Height == 256) {
						bmpFond = new Bitmap(b);
						Reset();
						SetInfo("Lecture image de fond ok.");
					}
					else
						MessageBox.Show("L'image n'a pas le bon format (" + maxWidth.ToString() + "x256 pixels)");
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

		private void bpFirst_Click(object sender, EventArgs e) {
			projet.SelImage().SetFirstTriangle();
			DisplayList();
			listTriangles.SelectedIndex = 0;
		}

		private void bpLast_Click(object sender, EventArgs e) {
			int nbTriangles = projet.SelImage().lstTriangle.Count - 1;
			projet.SelImage().SetLastTriangle(nbTriangles);
			DisplayList();
			listTriangles.SelectedIndex = nbTriangles;
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
					if (chkAnim3D.Checked) {
						foreach (Datas d in projet.lstData) {
							d.DeplaceImage(deplX, deplY, maxWidth);
						}
						DisplayList();
						FillTriangles();
						DisplayMemory();
					}
					else {
						projet.SelImage().DeplaceImage(deplX, deplY, maxWidth);
						DisplayList();
						FillTriangles();
					}
				}
				else
					if (triSel != null) {
						int memoSel = projet.SelImage().GetSelTriangle();
						projet.SelImage().DeplaceTriangle(deplX, deplY, maxWidth);
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
					if (chkAnim3D.Checked) {
						foreach (Datas d in projet.lstData) {
							d.CoefZoom(zoomX, zoomY, chkCenterZoom.Checked, maxWidth);
						}
						DisplayList();
						FillTriangles();
						DisplayMemory();
					}
					else {
						projet.SelImage().CoefZoom(zoomX, zoomY, chkCenterZoom.Checked, maxWidth);
						DisplayList();
						FillTriangles();
					}
				}
				else
					if (triSel != null) {
						int memoSel = projet.SelImage().GetSelTriangle();
						projet.SelImage().CoefZoom(triSel, zoomX, zoomY, chkCenterZoom.Checked, maxWidth);
						DisplayList();
						listTriangles.SelectedIndex = memoSel;
					}
					else
						MessageBox.Show("Pas de triangle sélectionné");
			}
			else
				MessageBox.Show("Veuillez sélectionner des données de zoom valide");
		}

		private void bpRapproche_Click(object sender, EventArgs e) {
			projet.SelImage().Rapproche(4);
			projet.SelImage().CleanUp(maxWidth);
			DisplayList();
			FillTriangles();
		}

		private void bpAjoutLigne_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDLINE;
			SetInfo("Attente positionnement premier point ligne");
			bpAjoutLigne.Enabled=bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void bpAddTriangle_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDTRIANGLE;
			SetInfo("Attente positionnement premier point triangle");
			bpAjoutLigne.Enabled=bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void bpAjoutQuadri_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDQUADRI;
			SetInfo("Attente positionnement premier point quadrilatère");
			bpAjoutLigne.Enabled=bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void bpAjoutRect_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDRECTANGLE;
			SetInfo("Attente positionnement premier point rectangle");
			bpAjoutLigne.Enabled=bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void bpAjoutCercle_Click(object sender, EventArgs e) {
			nbr = 0;
			int.TryParse(txbNbRayons.Text, out nbr);
			if (nbr > 3 && nbr <= MAX_RAYONS) {
				numPt = 1;
				mouseOpt = DrawMd.ADDCERCLE;
				SetInfo("Attente positionnement centre cercle");
				bpAjoutLigne.Enabled = bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
			}
			else
				MessageBox.Show("Le nombre de rayons doit être compris entre 4 et " + MAX_RAYONS.ToString());
		}

		private void bpClean_Click(object sender, EventArgs e) {
			int nbAvant = projet.SelImage().lstTriangle.Count;
			projet.SelImage().CleanUp(maxWidth);
			int nbApres = projet.SelImage().lstTriangle.Count;
			if (nbApres != nbAvant)
				SetInfo("Nbre de triangles optimisés : " + (nbAvant - nbApres).ToString());
			else
				SetInfo("Pas d'optimisation possible.");

			DisplayList();
			FillTriangles();
			DisplayMemory();
		}

		#region Gestion projet
		private void SetImageProjet() {
			bpImagePrec.Enabled = projet.selData > 0;
			bpImageSuiv.Enabled = projet.selData < projet.lstData.Count - 1;
			bpSupImage.Enabled = projet.lstData.Count > 1;
			lblInfoImage.Text = (projet.selData + 1).ToString() + "/" + projet.lstData.Count.ToString();
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
					if (projet.mode == 0)
						rbMode0.Checked = true;
					else
						rbMode1.Checked = true;

					SetNewMode(false);
					projet.SelectImage(0);
					SetImageProjet();
					this.Text = Path.GetFileName(dlg.FileName);
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
					DisplayMemoryProjet();
				}
				catch {
					MessageBox.Show("Erreur sauvegarde projet...");
				}
				file.Close();
			}
		}

		private void bpFusion_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Fichiers xml (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				try {
					Projet projetTmp = (Projet)new XmlSerializer(typeof(Projet)).Deserialize(fileParam);
					if (projetTmp.lstData.Count == projet.lstData.Count) {
						for (int i = 0; i <projet.lstData.Count; i++) {
							Datas d1 =projet.lstData[i];
							Datas d2 = projetTmp.lstData[i];
							for (int j = 0; j < d2.lstTriangle.Count; j++)
								d1.lstTriangle.Add(d2.lstTriangle[j]);
						}
						SetInfo("Lecture projet ok");
						SetNewMode(false);
						projet.SelectImage(0);
						SetImageProjet();
					}
					else
						MessageBox.Show("Les projets n'ont pas le même nombre d'images...");
				}
				catch {
					MessageBox.Show("Erreur lecture projet...");
				}
				fileParam.Close();
			}
		}

		private void bpNewImage_Click(object sender, EventArgs e) {
			projet.AddData();
			SetImageProjet();
		}

		private void bpSupImage_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes vous sur(e) de vouloir supprimer cette image ?", "Confirmation suppression", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
				projet.RemoveImage();
				SetImageProjet();
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
				projet.GenereSourceAsm(dlg.FileName, chkModePolice.Checked, chkAnim3D.Checked, chkZX0.Checked);
				SetInfo("Génération assembleur ok.");
			}
		}

		private void bpNewProjet_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes vous sur(e) de vouloir créer un nouveau projet ? Ceci effacera le projet en cours.", "Confirmation création nouveau projet", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
				projet.Clear();
				SetImageProjet();
			}
		}
		#endregion

		private void SetNewMode(bool withResize) {
			if (bmpLock != null)
				bmpLock.Dispose();

			int nbCols = 1 << (4 >> projet.mode);
			for (int i = 0; i < 16; i++)
				colors[i].Visible = i < nbCols;

			switch (projet.mode) {
				case 0:
					maxWidth = chkOverscan.Checked ? 192 : 160;
					coefX = 6;
					bmpLock = new DirectBitmap(maxWidth, 256);
					break;

				case 1:
					maxWidth = chkOverscan.Checked ? 384 : 320;
					coefX = 3;
					bmpLock = new DirectBitmap(maxWidth, 256);
					break;
			}
			if (withResize)
				foreach (Datas d in projet.lstData)
					d.ChangeMode(projet.mode);

			DisplayList();
			FillTriangles();
		}

		private void rbMode0_CheckedChanged(object sender, EventArgs e) {
			if (rbMode0.Checked && projet.mode != 0) {
				projet.mode = 0;
				SetNewMode(true);
			}
		}

		private void rbMode1_CheckedChanged(object sender, EventArgs e) {
			if (rbMode1.Checked && projet.mode != 1) {
				projet.mode = 1;
				SetNewMode(true);
			}
		}

		private void bpCleanProj_Click(object sender, EventArgs e) {
			Enabled = false;
			int nbAvant = 0, nbApres = 0;
			foreach (Datas d in projet.lstData) {
				nbAvant += d.lstTriangle.Count;
				d.CleanUp(maxWidth);
				nbApres += d.lstTriangle.Count;
			}
			if (nbApres != nbAvant)
				SetInfo("Nbre de triangles optimisés : " + (nbAvant - nbApres).ToString());
			else
				SetInfo("Pas d'optimisation possible.");

			DisplayList();
			FillTriangles();
			DisplayMemory();
			Enabled = true;
		}

		private void chkAnim3D_CheckedChanged(object sender, EventArgs e) {
			bpMakeAnim3D.Visible = chkZX0.Visible = chkAnim3D.Checked;
		}

		private void chkLine_CheckedChanged(object sender, EventArgs e) {
			bpRedraw_Click(null, null);
		}

		private void bpMakeAnim3D_Click(object sender, EventArgs e) {
			Enabled = false;
			new MakeAnim(projet).ShowDialog();
			projet.SelectImage(0);
			SetImageProjet();
			Enabled = true;
		}

		private void chkOverscan_CheckedChanged(object sender, EventArgs e) {
			if (chkOverscan.Checked) {
				pictureBox.Width = 1152;
				panel1.Left = 1202;
				this.Width = 1876;
				for (int i = 0; i < 16; i++)
					colors[i].Left = 1158;
			}
			else {
				pictureBox.Width = 960;
				panel1.Left = 1010;
				this.Width = 1684;
				for (int i = 0; i < 16; i++)
					colors[i].Left = 966;
			}
			SetNewMode(true);
		}
	}
}
