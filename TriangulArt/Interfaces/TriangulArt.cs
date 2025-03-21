﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class TriangulArt : Form {
		private DirectBitmap bmpLock;
		private enum DrawMd { NONE = 0, MOVETRIANGLE, ADDTRIANGLE, ADDQUADRI, ADDRECTANGLE, ADDCERCLE, ADDLINE };
		private DrawMd mouseOpt = DrawMd.NONE;
		private int numPt, nbr;
		private Triangle triSel;
		private int oldx1, oldy1;
		private byte selColor = 1;
		private ImageFond bmpFond = new ImageFond();
		private Projet projet = new Projet();
		private const int MAX_RAYONS = 32;
		private int coefX;
		private Label[] colors = new Label[16];
		private CpcEmul cpc = new CpcEmul();

		public TriangulArt() {
			InitializeComponent();
			for (int i = 0; i < 16; i++) {
				// Générer les contrôles de "couleurs"
				colors[i] = new Label {
					BorderStyle = BorderStyle.FixedSingle,
					Location = new Point(966, 4 + i * 48),
					Size = new Size(40, 32),
					Tag = i,
					TextAlign = ContentAlignment.MiddleCenter,
					Text = i.ToString()
				};
				colors[i].MouseClick += ClickColor;
				Controls.Add(colors[i]);
			}
			Version version = Assembly.GetExecutingAssembly().GetName().Version;
			lblInfoVersion.Text = "V " + version.ToString() + " - " + new DateTime(2000, 1, 1).AddDays(version.Build).ToShortDateString();
			projet.Init();
			comboNbColonnes.SelectedIndex = 1;
			SetNewMode(true);
			Reset();
			SetImageProjet();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			switch (keyData) {
				case Keys.Left:
					if (projet.selData > 0)
						BpImagePrec_Click(null, null);

					return true;

				case Keys.Right:
					if (projet.selData < projet.lstData.Count - 1)
						BpImageSuiv_Click(null, null);

					return true;

				case Keys.Delete:
					DeleteSelTriangle();
					return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		public void Reset() {
			ResetNoRender();
			Render();
		}

		public void ResetNoRender() {
			if (bmpFond.NbImg > 0)
				bmpLock.Copy(bmpFond.GetImage);
			else
				bmpLock.Fill(PaletteCpc.GetColorPal(0).GetColorArgb);
		}

		// Changement de la palette
		private void ClickColor(object sender, MouseEventArgs e) {
			Label colorClick = sender as Label;
			int pen = colorClick.Tag != null ? (int)colorClick.Tag : 0;
			if (e.Button == MouseButtons.Left) {
				selColor = (byte)pen;
				if (triSel != null)
					triSel.color = selColor;

				UpdatePalette();
			}
			else
				SetNewColor(pen);
		}

		private void UpdatePalette() {
			for (int i = 0; i < 16; i++) {
				RvbColor col = PaletteCpc.GetColorPal(i);
				colors[i].BackColor = Color.FromArgb(col.GetColorArgb);
				colors[i].ForeColor = (col.r * 9798 + col.v * 19235 + col.b * 3735) > 0x400000 ? Color.Black : Color.White;
			}
			ColorSel.BackColor = Color.FromArgb(PaletteCpc.GetColorPal(selColor).GetColorArgb);
		}

		private void PictureBox_Paint(object sender, PaintEventArgs e) {
			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			e.Graphics.DrawImage(bmpLock.Bitmap, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height), 0, 0, bmpLock.Bitmap.Width, bmpLock.Bitmap.Height, GraphicsUnit.Pixel);
		}

		private void Render() {
			UpdatePalette();
			int endLigne = 256;
			switch (projet.tailleColonnes) {
				case 1:
					endLigne = 200;
					break;
				case 2:
					endLigne = 168;
					break;
			}
			for (int y = endLigne; y < 256; y++)
				bmpLock.DrawLine(0, y, bmpLock.Width, y, y == endLigne ? 0xFF0000 : 0, false);

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
			ResetNoRender();
			projet.SelImage().FillTriangles(bmpLock, bmpLock.Width, chkLine.Checked);
			Render();
			bpAjoutLigne.Enabled = bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = true;
			mouseOpt = DrawMd.NONE;
		}

		private void DisplayList(bool withCheck = false) {
			int maxHeight = comboNbColonnes.SelectedIndex == 0 ? 255 : comboNbColonnes.SelectedIndex == 1 ? 200 : 168;
			listTriangles.Items.Clear();
			for (int i = 0; i < projet.SelImage().lstTriangle.Count; i++) {
				Triangle t = projet.SelImage().lstTriangle[i];
				string inf = (t.enabled ? " " : "*") + i.ToString("000") + "  ("
							+ t.x1.ToString("000") + "," + t.y1.ToString("000") + ")  ("
							+ t.x2.ToString("000") + "," + t.y2.ToString("000") + ")  ("
							+ t.x3.ToString("000") + "," + t.y3.ToString("000") + ")  c:"
							+ t.color.ToString("00");
				int f = t.pctFill;
				if (f != -1) {
					inf += "\t" + f + "%";
					if (f < 50)
						inf += "=";

					if (f < 40)
						inf += "=";

					if (f < 25)
						inf += "=";

					if (f < 10)
						inf += "=";
				}
				if (t.y1 > maxHeight || t.y2 > maxHeight || t.y3 > maxHeight) {
					inf = (t.enabled ? "" : "*") + i.ToString("000") + "\tERREUR :TAILLE Y>TAILLE Y MAX";
					if (withCheck)
						SetInfo("!!! Le triangle " + i + " descend trop bas pour la résolution choisie...");
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
			projet.SelImage().FillTriangle(bmpLock, t, bmpLock.Width, chkLine.Checked);
			DisplayList();
		}

		private void DrawMoveTriangle(Graphics g) {
			XorDrawing.DrawXorTriangle(g, (Bitmap)pictureBox.Image, triSel.x1, triSel.y1, triSel.x2, triSel.y2, triSel.x3, triSel.y3);
		}

		private void TrtMouseMove(object sender, MouseEventArgs e) {
			int yReel = (e.Y + 2) / 3;
			int xReel = (e.X + 2) / coefX;
			lblInfoPos.Text = "x:" + xReel.ToString("000") + " y:" + yReel.ToString("000");
			if ((mouseOpt == DrawMd.ADDTRIANGLE || mouseOpt == DrawMd.ADDQUADRI || mouseOpt == DrawMd.ADDLINE) && triSel != null) {
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
					XorDrawing.DrawXorCercle(g, (Bitmap)pictureBox.Image, projet.mode, triSel.x1, triSel.y1, oldx1, oldy1, nbr);
					oldx1 = xReel;
					oldy1 = yReel;
					XorDrawing.DrawXorCercle(g, (Bitmap)pictureBox.Image, projet.mode, triSel.x1, triSel.y1, oldx1, oldy1, nbr);
				}
				pictureBox.Refresh();
			}
			if (e.Button == MouseButtons.Left && mouseOpt == DrawMd.MOVETRIANGLE && triSel != null) {
				Graphics g = Graphics.FromImage(pictureBox.Image);
				DrawMoveTriangle(g);
				int dx = xReel - oldx1;
				int dy = yReel - oldy1;
				projet.SelImage().DeplaceTriangle(dx, dy, bmpLock.Width);
				oldx1 = xReel;
				oldy1 = yReel;
				DrawMoveTriangle(g);
				pictureBox.Refresh();
			}
		}

		private void PictureBox_MouseDown(object sender, MouseEventArgs e) {
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
					triSel = new Triangle {
						x1 = xReel,
						y1 = yReel,
						color = selColor
					};
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
					triSel = new Triangle {
						x1 = xReel,
						y1 = yReel,
						color = selColor
					};
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
					triSel = new Triangle {
						x1 = xReel,
						y1 = yReel,
						color = selColor
					};
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
					triSel = new Triangle {
						x1 = xReel,
						y1 = yReel,
						color = selColor
					};
					numPt = 2;
					SetInfo("Centre en " + xReel + "," + yReel + ", attente définition rayon cercle");
					oldx1 = xReel;
					oldy1 = yReel;
					break;

				case 2:
					XorDrawing.DrawXorCercle(g, (Bitmap)pictureBox.Image, projet.mode, triSel.x1, triSel.y1, oldx1, oldy1, nbr);
					double r = Math.Sqrt((oldx1 - triSel.x1) * (oldx1 - triSel.x1) + (oldy1 - triSel.y1) * (oldy1 - triSel.y1));
					int x1 = triSel.x1;
					int y1 = triSel.y1;
					int ang = (360 / nbr);
					for (int a = 0; a < 360; a += ang) {
						int x2 = x1 + (int)(r * Math.Cos(a / 180.0 * Math.PI));
						int y2 = y1 + ((int)(r * Math.Sin(a / 180.0 * Math.PI)));
						int x3 = x1 + (int)(r * Math.Cos((a - ang) / 180.0 * Math.PI));
						int y3 = y1 + ((int)(r * Math.Sin((a - ang) / 180.0 * Math.PI)));
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
					triSel = new Triangle {
						x1 = xReel,
						y1 = yReel,
						color = selColor
					};
					numPt = 2;
					triSel.x2 = xReel;
					triSel.y2 = yReel < 255 ? yReel + 1 : yReel - 1;
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

		private void PictureBox_MouseUp(object sender, MouseEventArgs e) {
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

		private void PictureBox_MouseLeave(object sender, EventArgs e) {
			lblInfoPos.Text = "";
		}

		public void SetInfo(string txt) {
			listInfo.Items.Add(DateTime.Now.ToString() + " - " + txt);
			listInfo.SelectedIndex = listInfo.Items.Count - 1;
		}

		private void DisplayMemory() {
			if (chkAnim3D.Checked) {
				int nbTri = 0, nbImg = projet.lstData.Count;
				foreach (Datas d in projet.lstData)
					nbTri += d.GetTriangleActif();

				int mem = chkModePolice.Checked ? (nbTri * 6) + (nbImg * 2) : (nbTri * 7) + (nbImg * 6);
				SetInfo("Nbre de triangles du projet:" + nbTri.ToString() + " - Mémoire utilisée:" + mem.ToString() + " octets");
			}
			else {
				int nbTri = projet.SelImage().GetTriangleActif();
				int mem = chkModePolice.Checked ? (nbTri * 6) + 2 : (nbTri * 7) + 6;
				SetInfo("Nbre de triangles:" + nbTri.ToString() + " - Mémoire utilisée:" + mem + " octets");
			}
		}

		private void InitImage() {
			PaletteCpc.cpcPlus = chkPlus.Checked = projet.cpcPlus;
			for (int i = 0; i < projet.SelImage().palette.Length; i++)
				PaletteCpc.Palette[i] = projet.SelImage().palette[i];

			txbNomImage.Text = projet.SelImage().nomImage;
			txbTpsAttente.Text = projet.SelImage().tpsAttente.ToString();
			UpdatePalette();
			FillTriangles();
			DisplayList();
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

		private void BpLoad_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog { Filter = "Fichiers xml (*.xml)|*.xml" };
			if (dlg.ShowDialog() == DialogResult.OK) {
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

		private void BpSave_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers xml (*.xml)|*.xml" };
			if (dlg.ShowDialog() == DialogResult.OK) {
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

		private void BpImport_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog { Filter = "Fichiers assembleur (*.asm)|*.asm" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				try {
					if (chkAnim3D.Checked)
						projet.Import(dlg.FileName, chkClearData.Checked);
					else
						projet.SelImage().Import(dlg.FileName, chkClearData.Checked);
					SetInfo("Import triangles ok");
					FillTriangles();
					DisplayList(true);
				}
				catch {
					MessageBox.Show("Erreur lors de l'importation des données...");
				}
			}
		}

		private void BpGenereAsm_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers assembleur (*.asm)|*.asm" };
			if (dlg.ShowDialog() == DialogResult.OK) {
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
					DisplayMemory();
				}
				else {
					PaletteCpc.Palette[pen] = projet.SelImage().palette[pen] = ed.ValColor;
					UpdatePalette();
				}
				FillTriangles();
			}
			FillTriangles();
		}

		private void ListTriangles_SelectedIndexChanged(object sender, EventArgs e) {
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

		private void BpRedraw_Click(object sender, EventArgs e) {
			projet.SelImage().CleanUp(bmpLock.Width, projet.tailleColonnes == 64 ? 256 : projet.tailleColonnes == 80 ? 200 : 168, true);
			DisplayList(true);
			FillTriangles();
		}

		private void DeleteSelTriangle() {
			if (triSel != null && MessageBox.Show("Etes vous sur(e) de vouloir supprimer ce triangle ?", "Confirmation suppression", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				projet.SelImage().DeleteSelTriangle();
				InitImage();
			}
		}

		private void BpDelete_Click(object sender, EventArgs e) {
			DeleteSelTriangle();
		}

		private void BpEdit_Click(object sender, EventArgs e) {
			Triangle t = CheckDatas();
			if (t != null) {
				int newIndex;
				int.TryParse(txbPos.Text, out newIndex);
				projet.SelImage().EditSelTriangle(t, selColor, newIndex);
				int memoSel = projet.SelImage().GetSelTriangle();
				DisplayList();
				listTriangles.SelectedIndex = memoSel;
			}
		}

		private void BpAddCoord_Click(object sender, EventArgs e) {
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

		private void ChkPlus_CheckedChanged(object sender, EventArgs e) {
			if (Enabled) {
				bpGenPal.Visible = projet.cpcPlus = PaletteCpc.cpcPlus = chkPlus.Checked;
				if (!PaletteCpc.cpcPlus) {
					for (int i = 0; i < 16; i++) {
						int rvb = PaletteCpc.Palette[i];
						RvbColor col = new RvbColor((byte)((rvb & 0x0F) * 17), (byte)((rvb >> 8) * 17), (byte)(((rvb >> 4) & 0x0F) * 17));
						int maxDelta = 0x7FFFFFF, penSel = 0;
						for (int p = 0; p < 27; p++) {
							int delta = Math.Abs(col.r - PaletteCpc.RgbCPC[p].r) + Math.Abs(col.v - PaletteCpc.RgbCPC[p].v) + Math.Abs(col.b - PaletteCpc.RgbCPC[p].b);
							if (delta < maxDelta) {
								maxDelta = delta;
								penSel = p;
							}
						}
						PaletteCpc.Palette[i] = penSel;
					}
				}
				else {
					for (int i = 0; i < 16; i++) {
						if (PaletteCpc.Palette[i] < 27) {
							RvbColor col = PaletteCpc.RgbCPC[PaletteCpc.Palette[i]];
							PaletteCpc.Palette[i] = ((col.b >> 4) << 4) + ((col.v >> 4) << 8) + (col.r >> 4);
						}
						else
							PaletteCpc.Palette[i] = 0;
					}
				}
				for (int pen = 0; pen < 16; pen++) {
					if (chkAnim3D.Checked) {
						foreach (Datas d in projet.lstData)
							d.palette[pen] = PaletteCpc.Palette[pen];
					}
					else
						projet.SelImage().palette[pen] = PaletteCpc.Palette[pen];
				}
				FillTriangles();
			}
		}

		private void BpImportImage_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog { Filter = "Fichier image (*.bmp, *.gif, *.png, *.jpg,*.jpeg)|*.bmp;*.gif;*.png;*.jpg;*.jpeg;" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				using (Bitmap b = new Bitmap(dlg.FileName)) {
					if ((b.Width <= bmpLock.Width || b.Width >> 1 <= bmpLock.Width) && b.Height <= bmpLock.Height) {
						FileStream fileScr = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
						byte[] tabBytes = new byte[fileScr.Length];
						fileScr.Read(tabBytes, 0, tabBytes.Length);
						fileScr.Close();
						MemoryStream imageStream = new MemoryStream(tabBytes) { Position = 0 };
						bmpFond.InitBitmap(imageStream);
						Reset();
						SetInfo("Lecture image de fond ok.");
						while (bmpFond.NbImg > projet.lstData.Count)
							projet.lstData.Add(new Datas());
					}
					else
						MessageBox.Show("L'image n'a pas le bon format (" + bmpLock.Width.ToString() + "x" + bmpLock.Height.ToString() + " pixels)");
				}
			}
		}

		private void BpClear_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes vous certain de vouloir effaccer cette image ?", "Confirmation d'effacement", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				bmpFond.ClearAll();
				projet.SelImage().Clear();
				DisplayList();
				Reset();
			}
		}

		private void BpUp_Click(object sender, EventArgs e) {
			int memoSel = listTriangles.SelectedIndex;
			projet.SelImage().UpTriangle();
			listTriangles.SelectedIndex = memoSel - 1;
		}

		private void BpDown_Click(object sender, EventArgs e) {
			int memoSel = listTriangles.SelectedIndex;
			projet.SelImage().DownTriangle();
			listTriangles.SelectedIndex = memoSel + 1;
		}

		private void BpFirst_Click(object sender, EventArgs e) {
			projet.SelImage().SetFirstTriangle();
			DisplayList();
			listTriangles.SelectedIndex = 0;
		}

		private void BpLast_Click(object sender, EventArgs e) {
			int nbTriangles = projet.SelImage().lstTriangle.Count - 1;
			projet.SelImage().SetLastTriangle(nbTriangles);
			DisplayList();
			listTriangles.SelectedIndex = nbTriangles;
		}

		private void RbStandard_CheckedChanged(object sender, EventArgs e) {
			projet.SelImage().modeRendu = 0;
			DisplayList();
			FillTriangles();
		}

		private void RbHorizontal_CheckedChanged(object sender, EventArgs e) {
			projet.SelImage().modeRendu = 1;
			DisplayList();
			FillTriangles();
		}

		private void RbVertical_CheckedChanged(object sender, EventArgs e) {
			projet.SelImage().modeRendu = 2;
			DisplayList();
			FillTriangles();
		}

		private void BpClearList_Click(object sender, EventArgs e) {
			listInfo.Items.Clear();
		}

		private void BpDeplace_Click(object sender, EventArgs e) {
			int deplX = 0, deplY = 0;
			if (int.TryParse(txbTrX.Text, out deplX) && int.TryParse(txbTrY.Text, out deplY)) {
				if (rbDepImage.Checked) {
					if (chkAnim3D.Checked) {
						for (int i = projet.selData; i < projet.lstData.Count; i++)
							projet.lstData[i].DeplaceImage(deplX, deplY, bmpLock.Width);

						DisplayList();
						FillTriangles();
						DisplayMemory();
					}
					else {
						projet.SelImage().DeplaceImage(deplX, deplY, bmpLock.Width);
						DisplayList();
						FillTriangles();
					}
				}
				else
					if (triSel != null) {
					int memoSel = projet.SelImage().GetSelTriangle();
					projet.SelImage().DeplaceTriangle(deplX, deplY, bmpLock.Width);
					DisplayList();
					listTriangles.SelectedIndex = memoSel;
				}
				else
					MessageBox.Show("Pas de triangle sélectionné");
			}
			else
				MessageBox.Show("Veuillez sélectionner des données de déplacement valide");
		}

		private void BpZoom_Click(object sender, EventArgs e) {
			double zoomX = 0, zoomY = 0;
			if (double.TryParse(txbTrX.Text.Replace('.', ','), out zoomX) && double.TryParse(txbTrY.Text.Replace('.', ','), out zoomY)) {
				if (rbDepImage.Checked) {
					if (chkAnim3D.Checked) {
						foreach (Datas d in projet.lstData) {
							d.CoefZoom(zoomX, zoomY, chkCenterZoom.Checked, bmpLock.Width);
						}
						DisplayList();
						FillTriangles();
						DisplayMemory();
					}
					else {
						projet.SelImage().CoefZoom(zoomX, zoomY, chkCenterZoom.Checked, bmpLock.Width);
						DisplayList();
						FillTriangles();
					}
				}
				else
					if (triSel != null) {
					int memoSel = projet.SelImage().GetSelTriangle();
					projet.SelImage().CoefZoom(triSel, zoomX, zoomY, chkCenterZoom.Checked, bmpLock.Width);
					DisplayList();
					listTriangles.SelectedIndex = memoSel;
				}
				else
					MessageBox.Show("Pas de triangle sélectionné");
			}
			else
				MessageBox.Show("Veuillez sélectionner des données de zoom valide");
		}

		private void BpRapproche_Click(object sender, EventArgs e) {
			projet.SelImage().Rapproche(4);
			projet.SelImage().ToQuadri();
			projet.SelImage().CleanUp(bmpLock.Width, projet.tailleColonnes == 64 ? 256 : projet.tailleColonnes == 80 ? 200 : 168);
			DisplayList();
			FillTriangles();
		}

		private void BpAjoutLigne_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDLINE;
			SetInfo("Attente positionnement premier point ligne");
			bpAjoutLigne.Enabled = bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void BpAddTriangle_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDTRIANGLE;
			SetInfo("Attente positionnement premier point triangle");
			bpAjoutLigne.Enabled = bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void BpAjoutQuadri_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDQUADRI;
			SetInfo("Attente positionnement premier point quadrilatère");
			bpAjoutLigne.Enabled = bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void BpAjoutRect_Click(object sender, EventArgs e) {
			numPt = 1;
			mouseOpt = DrawMd.ADDRECTANGLE;
			SetInfo("Attente positionnement premier point rectangle");
			bpAjoutLigne.Enabled = bpAjoutTriangle.Enabled = bpAjoutQuadri.Enabled = bpAjoutRect.Enabled = bpAjoutCercle.Enabled = txbNbRayons.Enabled = false;
		}

		private void BpAjoutCercle_Click(object sender, EventArgs e) {
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

		private void BpClean_Click(object sender, EventArgs e) {
			int nbAvant = projet.SelImage().GetTriangleActif();
			projet.SelImage().CleanUp(bmpLock.Width, projet.tailleColonnes == 64 ? 256 : projet.tailleColonnes == 80 ? 200 : 168);
			int nbApres = projet.SelImage().GetTriangleActif();
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

		private void BpReadProj_Click(object sender, EventArgs e) {
			Enabled = false;
			OpenFileDialog dlg = new OpenFileDialog { Filter = "Fichiers xml (*.xml)|*.xml" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				try {
					projet = (Projet)new XmlSerializer(typeof(Projet)).Deserialize(fileParam);
					SetInfo("Lecture projet ok");

					if (projet.lstAnim.Count > 0 && projet.lstAnim[0].nbImages > 0)
						chkAnim3D.Checked = true;

					if (projet.mode == 0)
						rbMode0.Checked = true;
					else
						rbMode1.Checked = true;

					SetNewMode(false);
					bmpFond.ClearAll();
					projet.SelectImage(0);
					SetImageProjet();
					Text = Path.GetFileName(dlg.FileName);
					bpGenPal.Visible = projet.cpcPlus;
					comboNbColonnes.SelectedIndex = projet.tailleColonnes;
					if (projet.lstAnim.Count == 0)
						projet.lstAnim.Add(new Animation());
				}
				catch {
					MessageBox.Show("Erreur lecture projet...");
				}
				fileParam.Close();
			}
			Enabled = true;
		}

		private void BpSaveProj_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers xml (*.xml)|*.xml" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				MemImage();
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Projet)).Serialize(file, projet);
					SetInfo("Sauvegarde projet ok");
					DisplayMemory();
				}
				catch {
					MessageBox.Show("Erreur sauvegarde projet...");
				}
				file.Close();
			}
		}

		private void BpFusion_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog { Filter = "Fichiers xml (*.xml)|*.xml" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				FileStream fileParam = File.Open(dlg.FileName, FileMode.Open);
				try {
					Projet projetTmp = (Projet)new XmlSerializer(typeof(Projet)).Deserialize(fileParam);
					if (projetTmp.lstData.Count == projet.lstData.Count) {
						for (int i = 0; i < projet.lstData.Count; i++) {
							Datas d1 = projet.lstData[i];
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

		private void BpNewImage_Click(object sender, EventArgs e) {
			projet.AddData();
			SetImageProjet();
		}

		private void BpSupImage_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes vous sur(e) de vouloir supprimer cette image ?", "Confirmation suppression", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
				projet.RemoveImage();
				SetImageProjet();
			}
		}

		private void BpImagePrec_Click(object sender, EventArgs e) {
			MemImage();
			projet.SelectImage(projet.selData - 1);
			if (bmpFond.NbImg > projet.selData)
				bmpFond.SelectBitmap(projet.selData);

			SetImageProjet();
		}

		private void BpImageSuiv_Click(object sender, EventArgs e) {
			MemImage();
			projet.SelectImage(projet.selData + 1);
			if (bmpFond.NbImg > projet.selData)
				bmpFond.SelectBitmap(projet.selData);

			SetImageProjet();
		}

		private void BpGenereProjetAsm_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers assembleur (*.asm)|*.asm" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				SaveMedia dlgSave = new SaveMedia("Animation", Path.GetFileNameWithoutExtension(dlg.FileName));
				dlgSave.ShowDialog();
				if (dlgSave.saveMediaOk) {
					string labelMedia = string.IsNullOrEmpty(dlgSave.LabelMedia) ? null : dlgSave.LabelMedia;
					projet.GenereSourceAsm(dlg.FileName, labelMedia, chkModePolice.Checked, chkAnim3D.Checked, chkZX0.Checked);
					SetInfo("Génération assembleur ok.");
				}
			}
		}

		private void BpNewProjet_Click(object sender, EventArgs e) {
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
					coefX = 6;
					bmpLock = new DirectBitmap(comboNbColonnes.SelectedIndex == 2 ? 192 : comboNbColonnes.SelectedIndex == 1 ? 160 : 128, 256);
					break;

				case 1:
					coefX = 3;
					bmpLock = new DirectBitmap(comboNbColonnes.SelectedIndex == 2 ? 384 : comboNbColonnes.SelectedIndex == 1 ? 320 : 256, 256);
					break;
			}
			if (withResize)
				foreach (Datas d in projet.lstData)
					d.ChangeMode(projet.mode);

			DisplayList(true);
			FillTriangles();
		}

		private void RbMode0_CheckedChanged(object sender, EventArgs e) {
			if (rbMode0.Checked && projet.mode != 0) {
				projet.mode = 0;
				SetNewMode(true);
			}
		}

		private void RbMode1_CheckedChanged(object sender, EventArgs e) {
			if (rbMode1.Checked && projet.mode != 1) {
				projet.mode = 1;
				SetNewMode(true);
			}
		}

		private void BpCleanProj_Click(object sender, EventArgs e) {
			Enabled = false;
			if (MessageBox.Show("Confirmez l'optimsation globale et la suppression des triangles inactif ?", "Confirmation suppression", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				int nbAvant = 0, nbApres = 0;
				projet.Clean(bmpLock.Width, projet.tailleColonnes == 64 ? 256 : projet.tailleColonnes == 80 ? 200 : 168, ref nbAvant, ref nbApres);
				for (int k = 0; k < projet.lstData.Count; k++)
					for (int i = projet.lstData[k].lstTriangle.Count - 1; i >= 0; i--)
						if (!projet.lstData[k].lstTriangle[i].enabled)
							projet.lstData[k].lstTriangle.RemoveAt(i);


				int oldAvant = 0;
				projet.Clean(bmpLock.Width, projet.tailleColonnes == 64 ? 256 : projet.tailleColonnes == 80 ? 200 : 168, ref oldAvant, ref nbApres);
				if (nbApres != nbAvant)
					SetInfo("Nbre de triangles optimisés : " + (nbAvant - nbApres).ToString());
				else
					SetInfo("Pas d'optimisation possible.");

				InitImage();
				DisplayList();
				FillTriangles();
				SetImageProjet();
			}
			Enabled = true;
		}

		private void ChkLine_CheckedChanged(object sender, EventArgs e) {
			BpRedraw_Click(null, null);
		}

		private void BpReadPal_Click(object sender, EventArgs e) {
			Enabled = false;
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers palette (*.pal)|*.pal|Fichiers palette (*.kit)|*.kit|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == DialogResult.OK) {
				PaletteCpc.LirePalette(of.FileName);
				if (chkAnim3D.Checked) {
					foreach (Datas d in projet.lstData)
						for (int pen = 0; pen < 16; pen++)
							d.palette[pen] = PaletteCpc.Palette[pen];

					DisplayList();
					FillTriangles();
					DisplayMemory();
				}
				else {
					for (int pen = 0; pen < 16; pen++)
						projet.SelImage().palette[pen] = PaletteCpc.Palette[pen];

					UpdatePalette();
					FillTriangles();
				}
			}
			Enabled = true;
		}

		private void BpSavePal_Click(object sender, EventArgs e) {
			Enabled = false;
			SaveFileDialog sf = new SaveFileDialog { Filter = "Fichiers palette (*.pal)|*.pal|Fichiers palette (*.kit)|*.kit|Tous les fichiers (*.*)|*.*\"'" };
			if (sf.ShowDialog() == DialogResult.OK)
				PaletteCpc.SauvePalette(sf.FileName, projet.mode);

			Enabled = true;
		}

		private void ChkAnim3D_CheckedChanged(object sender, EventArgs e) {
			bpMakeAnim3D.Visible = bpCpcEmul.Visible = bpSaveGif.Visible = chkAnim3D.Checked;
		}

		private void BpMakeAnim3D_Click(object sender, EventArgs e) {
			Enabled = false;
			new MakeAnim(projet, cpc, bmpFond).ShowDialog();
			projet.SelectImage(0);
			SetImageProjet();
			Enabled = true;
		}

		private void BpGenPal_Click(object sender, EventArgs e) {
			GenPalette g = new GenPalette(PaletteCpc.Palette, 1, DoGenPal);
			g.ShowDialog();
		}

		private void BpRazAll_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Confirmez l'effacement du projet", "Tout Effacer", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				projet.Clear();
				bmpFond.ClearAll();
				DisplayList();
				Reset();
				SetImageProjet();
			}
		}

		private void DoGenPal() {
			for (int c = 0; c < 16; c++) {
				int col = PaletteCpc.Palette[c];
				if (chkAnim3D.Checked) {
					foreach (Datas d in projet.lstData)
						d.palette[c] = col;
				}
				else
					projet.SelImage().palette[c] = col;

				colors[c].BackColor = Color.FromArgb((col & 0x0F) * 17, ((col & 0xF00) >> 8) * 17, ((col & 0xF0) >> 4) * 17);
				colors[c].Refresh();
			}
			UpdatePalette();
		}

		private void ComboNbColonnes_SelectedIndexChanged(object sender, EventArgs e) {
			int w = 192 * comboNbColonnes.SelectedIndex;
			pictureBox.Width = 768 + w;
			panel1.Left = 818 + w;
			Width = 1386 + w;
			for (int i = 0; i < 16; i++)
				colors[i].Left = 774 + w;

			projet.tailleColonnes = (byte)comboNbColonnes.SelectedIndex;
			SetNewMode(false);
		}

		private void BpSuprInactif_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Confirmez la suppression des triangles inactif ?", "Confirmation suppression", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				for (int i = projet.SelImage().lstTriangle.Count - 1; i >= 0; i--)
					if (!projet.SelImage().lstTriangle[i].enabled)
						projet.SelImage().lstTriangle.RemoveAt(i);

				InitImage();
			}
		}

		private void BpSaveGif_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Gif anim (*.gif)|*.gif" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				try {
					DirectBitmap tmp = new DirectBitmap(pictureBox.Width / 3, 256);
					byte[] GifAnimation = { 33, 255, 11, 78, 69, 84, 83, 67, 65, 80, 69, 50, 46, 48, 3, 1, 0, 0, 0 };
					byte[] tabByte = null;
					MemoryStream ms = new MemoryStream();
					BinaryWriter bWr = new BinaryWriter(new FileStream(dlg.FileName, FileMode.Create));
					for (int i = 0; i < projet.lstData.Count; i++) {
						MemImage();
						projet.SelectImage(i);
						if (bmpFond.NbImg > projet.selData)
							bmpFond.SelectBitmap(projet.selData);

						SetImageProjet();
						Graphics.FromImage(tmp.Bitmap).DrawImage(bmpLock.Bitmap, 0, 0, tmp.Width, tmp.Height);
						ms.SetLength(0);
						tmp.Bitmap.Save(ms, ImageFormat.Gif);
						tabByte = ms.ToArray();
						if (i == 0) {
							tabByte[10] = (byte)(tabByte[10] & 0X78); //No global color table
							bWr.Write(tabByte, 0, 13);
							bWr.Write(GifAnimation);
						}
						tabByte[785] = 5; // Temps d'affichage
						tabByte[786] = 0;
						tabByte[798] = (byte)(tabByte[798] | 0x87);
						bWr.Write(tabByte, 781, 18);
						bWr.Write(tabByte, 13, 768);
						bWr.Write(tabByte, 799, tabByte.Length - 800);
					}
					tmp.Dispose();
					bWr.Write(tabByte[tabByte.Length - 1]);
					bWr.Close();
					ms.Dispose();
				}
				catch (Exception ex) {
					SetInfo("Erreur sauvegarde GIF : " + ex.Message);
				}
			}

		}

		private void BpCpcEmul_Click(object sender, EventArgs e) {
			Enabled = false;
			projet.SendDataToCpc(cpc);
			Enabled = true;
		}

		private void ListTriangles_MouseDoubleClick(object sender, MouseEventArgs e) {
			triSel = projet.SelImage().SelectTriangle(listTriangles.SelectedIndex);
			if (triSel != null) {
				triSel.enabled = !triSel.enabled;
				projet.SelImage().CleanUp(bmpLock.Width, projet.tailleColonnes == 64 ? 256 : projet.tailleColonnes == 80 ? 200 : 168, true);
				DisplayList();
				FillTriangles();
			}
		}

		private void BpGen3D_Click(object sender, EventArgs e) {
			if (projet.SelImage().GetTriangleActif() > 0)
				new CreateObject(projet, bmpLock.Width, bmpLock.Height).ShowDialog();
		}
	}
}
