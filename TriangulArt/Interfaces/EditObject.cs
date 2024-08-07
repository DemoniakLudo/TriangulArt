﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class EditObjet : Form {
		private Objet objet;
		private DirectBitmap bmpLock = new DirectBitmap(768, 512);
		private int numFace = -1, numVertex = -1;
		private Label[] colors = new Label[16];
		private CheckBox[] lockColors = new CheckBox[16];
		private Label lblLock;
		private int[] lockState = new int[16];
		private byte selColor = 1;
		private int maxPen = 15;
		private Projet projet;
		private enum LstSel { SelPoint, SelFace };
		private LstSel lastSel;

		public EditObjet(Projet p, Objet o) {
			InitializeComponent();
			projet = p;
			chkImportPalette.Checked = chkImportPalette.Visible = p.cpcPlus;
			objet = o != null ? o : new Objet();
			for (int i = 0; i < 16; i++) {
				colors[i] = new Label {
					BorderStyle = BorderStyle.FixedSingle,
					Location = new Point(974, 76 + i * 48),
					Size = new Size(40, 32),
					Tag = i,
					TextAlign = ContentAlignment.MiddleCenter,
					Text = i.ToString()
				};
				colors[i].MouseClick += ClickColor;
				Controls.Add(colors[i]);
				if (p.cpcPlus) {
					if (i == 0) {
						// Affichage de "Lock"
						lblLock = new Label {
							Location = new System.Drawing.Point(1013, 58),
							Size = new System.Drawing.Size(31, 13),
							Text = "Lock"
						};
					}
					Controls.Add(lblLock);
					// Générer les contrôles de "bloquage couleur"
					lockColors[i] = new CheckBox {
						Location = new Point(974 + 48, 80 + i * 48),
						Size = new Size(20, 20),
						Tag = i
					};
					lockColors[i].Click += ClickLock;
					Controls.Add(lockColors[i]);
					lockColors[i].Update();
				}
			}
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
			UpdatePalette();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			switch (keyData) {
				case Keys.Left:
					return true;

				case Keys.Right:
					return true;

				case Keys.Delete:
					switch (lastSel) {
						case LstSel.SelPoint:
							bool errFace = numVertex == -1;
							if (!errFace)
								for (int i = 0; i < objet.lstFace.Count; i++) {
									if (objet.lstFace[i].a == numVertex || objet.lstFace[i].b == numVertex || objet.lstFace[i].c == numVertex) {
										errFace = true;
										break;
									}
								}
							if (!errFace)
								DeleteVertex();
							break;

						case LstSel.SelFace:
							if (numFace != -1)
								DeleteFace();
							break;
					}
					return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void DisplayBoutons() {
			bool errFace = numVertex == -1;
			if (numVertex != -1)
				for (int i = 0; i < objet.lstFace.Count; i++) {
					if (objet.lstFace[i].a == numVertex || objet.lstFace[i].b == numVertex || objet.lstFace[i].c == numVertex) {
						errFace = true;
						break;
					}
				}
			bpEditVertex.Enabled = objet.lstVertex.Count > 0 && numVertex != -1;
			bpSupVertex.Enabled = !errFace;
			bpEditFace.Enabled = bpSupFace.Enabled = objet.lstFace.Count > 0 && numFace != -1;
			bpFusionObject.Enabled = bpSaveObject.Enabled = bpParamObjet.Enabled = objet.lstFace.Count > 0;
		}

		private void DisplayVertex(int selVertex) {
			DisplayBoutons();
			lstViewVertex.Items.Clear();
			int i = 0;
			foreach (Vertex v in objet.lstVertex) {
				string[] s = { "V." + i++.ToString("000"), v.x.ToString("0.0000"), v.y.ToString("0.0000"), v.z.ToString("0.0000") };
				lstViewVertex.Items.Add(new ListViewItem(s));
			}
			numVertex = selVertex;
			if (selVertex != -1) {
				lstViewVertex.Items[selVertex].Selected = true;
				lstViewVertex.TopItem = lstViewVertex.Items[selVertex];
				lstViewVertex.Select();
			}
		}

		private void DisplayFace(int selFace) {
			DisplayBoutons();
			lstViewFace.Items.Clear();
			for (int i = 0; i < objet.lstFace.Count; i++) {
				Face f = objet.lstFace[i];
				string[] s = { "F." + i.ToString("000"), f.a.ToString(), f.b.ToString(), f.c.ToString(), f.pen.ToString() };
				ListViewItem item = new ListViewItem(s);
				item.UseItemStyleForSubItems = false;
				RvbColor faceColor = PaletteCpc.GetColorPal(f.pen);
				item.SubItems[4].BackColor = Color.FromArgb(faceColor.GetColorArgb);
				int val = faceColor.r * 9798 + faceColor.v * 19235 + faceColor.b * 3735;
				item.SubItems[4].ForeColor = val > 4194304 ? Color.Black : Color.White;
				lstViewFace.Items.Add(item);
			}
			numFace = selFace;
			if (selFace != -1) {
				lstViewFace.Items[selFace].Selected = true;
				lstViewFace.TopItem = lstViewFace.Items[selFace];
				lstViewFace.Select();
			}
		}

		private void DisplayObj() {
			Text = "EditObject" + (String.IsNullOrEmpty(objet.nom) ? "" : (" - " + objet.nom));
			DisplayBoutons();
			bmpLock.Fill(PaletteCpc.GetColorPal(0).GetColorArgb);
			int zoom = Utils.ToInt(txbZoom.Text);
			int angx = Utils.ToInt(txbValX.Text);
			int angy = Utils.ToInt(txbValY.Text);
			int angz = Utils.ToInt(txbValZ.Text);
			objet.DrawObj(bmpLock, 384, 256, zoom, zoom, angx, angy, angz, numFace, numVertex);
			pictureBoxObj.Image = bmpLock.Bitmap;
			pictureBoxObj.Refresh();
		}

		private void UpdatePalette() {
			for (int i = 0; i < 16; i++) {
				RvbColor col = PaletteCpc.GetColorPal(i);
				colors[i].BackColor = Color.FromArgb(col.GetColorArgb);
				colors[i].ForeColor = (col.r * 9798 + col.v * 19235 + col.b * 3735) > 0x400000 ? Color.Black : Color.White;
			}
			lblFaceColor.BackColor = Color.FromArgb(PaletteCpc.GetColorPal(selColor).GetColorArgb);
		}

		private void DeleteVertex() {
			if (MessageBox.Show("Confirmer la supperssion du point " + numVertex, "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				objet.lstVertex.RemoveAt(numVertex);
				for (int i = 0; i < objet.lstFace.Count; i++) {
					if (objet.lstFace[i].a >= numVertex)
						objet.lstFace[i].a--;

					if (objet.lstFace[i].b >= numVertex)
						objet.lstFace[i].b--;

					if (objet.lstFace[i].c >= numVertex)
						objet.lstFace[i].c--;
				}
				BpRedraw_Click(null, null);
			}
		}

		private void DeleteFace() {
			if (MessageBox.Show("Confirmer la supperssion de la face " + numFace, "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				objet.lstFace.RemoveAt(numFace);
				BpRedraw_Click(null, null);
			}
		}

		private void LstViewVertex_SelectedIndexChanged(object sender, EventArgs e) {
			numVertex = lstViewVertex.SelectedIndices.Count > 0 ? lstViewVertex.SelectedIndices[0] : -1;
			if (numVertex != -1) {
				Vertex v = objet.lstVertex[numVertex];
				txbVertexX.Text = v.x.ToString();
				txbVertexY.Text = v.y.ToString();
				txbVertexZ.Text = v.z.ToString();
				lastSel = LstSel.SelPoint;
			}
			DisplayObj();
		}

		private void LstViewFace_SelectedIndexChanged(object sender, EventArgs e) {
			numFace = lstViewFace.SelectedIndices.Count > 0 ? lstViewFace.SelectedIndices[0] : -1;
			if (numFace != -1) {
				Face f = objet.lstFace[numFace];
				txbFaceA.Text = f.a.ToString();
				txbFaceB.Text = f.b.ToString();
				txbFaceC.Text = f.c.ToString();
				selColor = f.pen;
				RvbColor faceColor = PaletteCpc.GetColorPal(f.pen);
				lblFaceColor.BackColor = Color.FromArgb(faceColor.GetColorArgb);
				lastSel = LstSel.SelFace;
			}
			DisplayObj();
		}

		#region gestion trackbars
		private void TrackX_Scroll(object sender, EventArgs e) {
			txbValX.Text = trackX.Value.ToString();
			DisplayObj();
		}

		private void TrackY_Scroll(object sender, EventArgs e) {
			txbValY.Text = trackY.Value.ToString();
			DisplayObj();
		}

		private void TrackZ_Scroll(object sender, EventArgs e) {
			txbValZ.Text = trackZ.Value.ToString();
			DisplayObj();
		}

		private void TrackZoom_Scroll(object sender, EventArgs e) {
			txbZoom.Text = trackZoom.Value.ToString();
			DisplayObj();
		}
		#endregion

		#region gestion boutons
		private void BpNewObject_Click(object sender, EventArgs e) {
			new NewObject(objet).ShowDialog();
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
		}

		private void ReadObject(bool withFusion = false) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == DialogResult.OK) {
				int numPen = chkImportPalette.Checked ? maxPen : 0;
				objet.ReadObject(projet, of.FileName, ref numPen, lockState, withFusion);
				if (chkImportPalette.Checked)
					maxPen = numPen;
			}
			UpdatePalette();
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
		}

		private void BpReadObject_Click(object sender, EventArgs e) {
			maxPen = 15;
			ReadObject();
		}

		private void BpFusionObject_Click(object sender, EventArgs e) {
			ReadObject(true);
		}

		private void BpSaveObject_Click(object sender, EventArgs e) {
			SaveFileDialog sd = new SaveFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (sd.ShowDialog() == DialogResult.OK) {
				objet.SaveObject(sd.FileName);
			}
		}

		private void RedrawAll() {
			DisplayVertex(numVertex);
			DisplayFace(numFace);
			DisplayObj();
		}

		private void BpRedraw_Click(object sender, EventArgs e) {
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
			bpEditVertex.Enabled = bpSupVertex.Enabled = bpEditFace.Enabled = bpSupFace.Enabled = false;
		}

		private void BpAddVertex_Click(object sender, EventArgs e) {
			objet.lstVertex.Add(new Vertex(Utils.ToDouble(txbVertexX.Text), Utils.ToDouble(txbVertexY.Text), Utils.ToDouble(txbVertexZ.Text)));
			DisplayVertex(objet.lstVertex.Count - 1);
		}

		private void BpEditVertex_Click(object sender, EventArgs e) {
			objet.lstVertex[numVertex].SetNewCoord(Utils.ToDouble(txbVertexX.Text), Utils.ToDouble(txbVertexY.Text), Utils.ToDouble(txbVertexZ.Text));
			RedrawAll();
		}

		private void BpSupVertex_Click(object sender, EventArgs e) {
			DeleteVertex();
		}

		private void BpAddFace_Click(object sender, EventArgs e) {
			int a = Utils.ToInt(txbFaceA.Text);
			int b = Utils.ToInt(txbFaceB.Text);
			int c = Utils.ToInt(txbFaceC.Text);
			if (a >= 0 && b >= 0 && c >= 0 && a < objet.lstVertex.Count && b < objet.lstVertex.Count && c < objet.lstVertex.Count) {
				objet.lstFace.Add(new Face(numFace++, a, b, c, selColor));
				DisplayFace(objet.lstFace.Count - 1);
			}
			else
				MessageBox.Show("Certains points n'existent pas.");
		}

		private void BpEditFace_Click(object sender, EventArgs e) {
			int a = Utils.ToInt(txbFaceA.Text);
			int b = Utils.ToInt(txbFaceB.Text);
			int c = Utils.ToInt(txbFaceC.Text);
			if (a >= 0 && b >= 0 && c >= 0 && a < objet.lstVertex.Count && b < objet.lstVertex.Count && c < objet.lstVertex.Count) {
				Face f = objet.lstFace[numFace];
				f.SetNewVertex(a, b, c);
				f.pen = selColor;
				RedrawAll();
			}
			else
				MessageBox.Show("Certains points n'existent pas.");
		}

		private void BpSupFace_Click(object sender, EventArgs e) {
			DeleteFace();
		}

		private void ClickColor(object sender, MouseEventArgs e) {
			if (numFace != -1) {
				Label colorClick = sender as Label;
				selColor = (byte)(colorClick.Tag != null ? (int)colorClick.Tag : 0);
				objet.lstFace[numFace].pen = selColor;

				UpdatePalette();
				RedrawAll();
			}
		}

		private void ClickLock(object sender, EventArgs e) {
			CheckBox colorLock = sender as CheckBox;
			lockState[colorLock.Tag != null ? (int)colorLock.Tag : 0] = colorLock.Checked ? 1 : 0;
		}

		private void BpModif_Click(object sender, EventArgs e) {
			objet.ModifObject(384, 256);
			BpRedraw_Click(sender, e);
		}

		private void BpParamObjet_Click(object sender, EventArgs e) {
			new ParamObjet(objet).ShowDialog();
			BpRedraw_Click(sender, e);
		}

		private void BpRecentre_Click(object sender, EventArgs e) {
			objet.RecentrePoints();
			BpRedraw_Click(sender, e);
		}

		private void BpSupFaceDouble_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Confirmer la supperssion des faces redondantes", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				DisplayObj();
				for (int j = objet.lstFace.Count - 1; j >= 0; j--) {
					for (int i = j - 1; i >= 0; i--) {
						Face f1 = objet.lstFace[i];
						Face f2 = objet.lstFace[j];

						Vertex vf1a = objet.lstVertex[f1.a];
						Vertex vf1b = objet.lstVertex[f1.b];
						Vertex vf1c = objet.lstVertex[f1.c];

						Vertex vf2a = objet.lstVertex[f2.a];
						Vertex vf2b = objet.lstVertex[f2.b];
						Vertex vf2c = objet.lstVertex[f2.c];

						if (vf1a.x == vf2a.x && vf1a.y == vf2a.y && vf1a.z == vf2a.z &&
							vf1b.x == vf2b.x && vf1b.y == vf2b.y && vf1b.z == vf2b.z &&
							vf1c.x == vf2c.x && vf1c.y == vf2c.y && vf1c.z == vf2c.z) {
							objet.lstFace.RemoveAt(j);
							break;
						}
					}
				}
				BpRedraw_Click(sender, e);
			}
		}

		private void PictureBoxObj_MouseDown(object sender, MouseEventArgs e) {
			int yReel = e.Y;
			int xReel = e.X;
			if (e.Button == MouseButtons.Right) {
				Face f = objet.GetSelFace(xReel, yReel, bmpLock);
				if (f != null) {
					for (int i = 0; i < objet.lstFace.Count; i++)
						if (objet.lstFace[i] == f) {
							numFace = i;
							break;
						}
					if (numFace != -1) {
						lstViewFace.Items[numFace].Selected = true;
						lstViewFace.TopItem = lstViewFace.Items[numFace];
						lstViewFace.Select();
					}
				}
			}
		}

		private void BpSupPtsNotUse_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Confirmer la supperssion des points inutilisés", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				// Remplacer les points identiques
				for (int i = 0; i < objet.lstVertex.Count - 1; i++) {
					for (int j = i + 1; j < objet.lstVertex.Count; j++) {
						Vertex v1 = objet.lstVertex[i];
						Vertex v2 = objet.lstVertex[j];
						if (Math.Abs(v1.px - v2.px) < 0.01 && Math.Abs(v1.py - v2.py) < 0.01 && Math.Abs(v1.pz - v2.pz) < 0.01) {
							for (int f = 0; f < objet.lstFace.Count; f++) {
								if (objet.lstFace[f].a == j)
									objet.lstFace[f].a = i;

								if (objet.lstFace[f].b == j)
									objet.lstFace[f].b = i;

								if (objet.lstFace[f].c == j)
									objet.lstFace[f].c = i;
							}
						}
					}
				}
				// Vérifier points liés à aucune faces
				for (int v = objet.lstVertex.Count - 1; v >= 0; v--) {
					bool errFace = false;
					for (int i = 0; i < objet.lstFace.Count; i++) {
						if (objet.lstFace[i].a == v || objet.lstFace[i].b == v || objet.lstFace[i].c == v) {
							errFace = true;
							break;
						}
					}
					if (!errFace) {
						objet.lstVertex.RemoveAt(v);
						for (int i = 0; i < objet.lstFace.Count; i++) {
							if (objet.lstFace[i].a >= v)
								objet.lstFace[i].a--;

							if (objet.lstFace[i].b >= v)
								objet.lstFace[i].b--;

							if (objet.lstFace[i].c >= v)
								objet.lstFace[i].c--;
						}
					}
				}
				BpRedraw_Click(sender, e);
			}
		}
		#endregion
	}
}
