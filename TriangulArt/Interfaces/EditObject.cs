using System;
using System.Drawing;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class EditObjet : Form {
		private Objet objet;
		private DirectBitmap bmpLock = new DirectBitmap(768, 512);
		private int numFace = -1, numVertex = -1;
		private Label[] colors = new Label[16];
		private byte selColor = 1;
		private int maxPen = 15;

		public EditObjet(Projet p, Objet o) {
			InitializeComponent();
			chkImportPalette.Visible= p.cpcPlus;
			objet = o != null ? o : new Objet();
			for (int i = 0; i < 16; i++) {
				colors[i] = new Label {
					BorderStyle = BorderStyle.FixedSingle,
					Location = new Point(974, 76 + i * 48),
					Size = new Size(40, 32),
					Tag = i
				};
				colors[i].MouseClick += ClickColor;
				Controls.Add(colors[i]);
			}
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
			UpdatePalette();
		}

		private void DisplayBoutons() {
			bool errFace = true;
			if (numVertex != -1) {
				errFace = false;
				for (int i = 0; i < objet.lstFace.Count; i++) {
					if (objet.lstFace[i].a == numVertex || objet.lstFace[i].b == numVertex || objet.lstFace[i].c == numVertex) {
						errFace = true;
						break;
					}
				}
			}
			bpEditVertex.Enabled = objet.lstVertex.Count > 0 && numVertex != -1;
			bpSupVertex.Enabled = !errFace;
			bpEditFace.Enabled = bpSupFace.Enabled = objet.lstFace.Count > 0 && numFace != -1;
			bpFusionObject.Enabled = bpSaveObject.Enabled = objet.lstFace.Count > 0;
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
				if (val > 4194304)
					item.SubItems[4].ForeColor = Color.Black;
				else
					item.SubItems[4].ForeColor = Color.White;

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

		private void lstViewVertex_SelectedIndexChanged(object sender, EventArgs e) {
			numVertex = lstViewVertex.SelectedIndices.Count > 0 ? lstViewVertex.SelectedIndices[0] : -1;
			if (numVertex != -1) {
				Vertex v = objet.lstVertex[numVertex];
				txbVertexX.Text = v.x.ToString();
				txbVertexY.Text = v.y.ToString();
				txbVertexZ.Text = v.z.ToString();
			}
			DisplayObj();
		}

		private void UpdatePalette() {
			for (int i = 0; i < 16; i++)
				colors[i].BackColor = Color.FromArgb(PaletteCpc.GetColorPal(i).GetColorArgb);

			lblFaceColor.BackColor = Color.FromArgb(PaletteCpc.GetColorPal(selColor).GetColorArgb);
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
			if (MessageBox.Show("Confirmer la création d'un nouvel objet", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				objet.Clear();
				DisplayVertex(-1);
				DisplayFace(-1);
				DisplayObj();
			}
		}

		private void ReadObject(bool withFusion = false) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == DialogResult.OK) {
				int numPen =  chkImportPalette.Checked ? maxPen : 0;
				objet.ReadObject(of.FileName, ref numPen, withFusion);
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
			double x = Utils.ToDouble(txbVertexX.Text);
			double y = Utils.ToDouble(txbVertexY.Text);
			double z = Utils.ToDouble(txbVertexZ.Text);
			objet.lstVertex.Add(new Vertex(x, y, z));
			DisplayVertex(objet.lstVertex.Count - 1);
		}

		private void BpEditVertex_Click(object sender, EventArgs e) {
			Vertex v = objet.lstVertex[numVertex];
			double x = Utils.ToDouble(txbVertexX.Text);
			double y = Utils.ToDouble(txbVertexY.Text);
			double z = Utils.ToDouble(txbVertexZ.Text);
			v.SetNewCoord(x, y, z);
			RedrawAll();
		}

		private void BpSupVertex_Click(object sender, EventArgs e) {
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
				BpRedraw_Click(sender, e);
			}
		}

		private void BpAddFace_Click(object sender, EventArgs e) {
			int a = Utils.ToInt(txbFaceA.Text);
			int b = Utils.ToInt(txbFaceB.Text);
			int c = Utils.ToInt(txbFaceC.Text);
			if (a >= 0 && b >= 0 && c >= 0 && a < objet.lstVertex.Count && b < objet.lstVertex.Count && c < objet.lstVertex.Count) {
				Face f = new Face(numFace++, a, b, c);
				f.pen = selColor;
				objet.lstFace.Add(f);
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
			if (MessageBox.Show("Confirmer la supperssion de la face " + numFace, "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				objet.lstFace.RemoveAt(numFace);
				BpRedraw_Click(sender, e);
			}
		}

		private void ClickColor(object sender, MouseEventArgs e) {
			Label colorClick = sender as Label;
			selColor = (byte)(colorClick.Tag != null ? (int)colorClick.Tag : 0);
			if (numFace != -1)
				objet.lstFace[numFace].pen = selColor;

			UpdatePalette();
			RedrawAll();
		}
		#endregion
	}
}
