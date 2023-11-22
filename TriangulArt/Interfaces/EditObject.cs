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

		public EditObjet(Objet o) {
			InitializeComponent();
			objet = o != null ? o : new Objet();
			for (int i = 0; i < 16; i++) {
				colors[i] = new Label {
					BorderStyle = BorderStyle.FixedSingle,
					Location = new Point(966, 4 + i * 48),
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
			bpEditVertex.Enabled = bpSupVertex.Enabled = objet.lstVertex.Count > 0 && numVertex != -1;
			bpEditFace.Enabled = bpSupFace.Enabled = objet.lstFace.Count > 0 && numFace != -1;
			bpSaveObject.Enabled = objet.lstFace.Count > 0;
		}

		private void DisplayVertex(int selVertex) {
			DisplayBoutons();
			listVertex.Items.Clear();
			int i = 0;
			foreach (Vertex v in objet.lstVertex) {
				string item = "V." + i++.ToString("000") + "\t" + v.x.ToString("0.0000") + "\t" + v.y.ToString("0.0000") + "\t" + v.z.ToString("0.0000");
				listVertex.Items.Add(item);
			}
			numVertex = selVertex;
			if (selVertex != -1)
				listVertex.SelectedIndex = selVertex;
		}

		private void DisplayFace(int selFace) {
			DisplayBoutons();
			lstViewFace.Items.Clear();
			for (int i = 0; i < objet.lstFace.Count; i++) {
				Face f = objet.lstFace[i];
				int a = objet.lstVertex.IndexOf(f.a);
				int b = objet.lstVertex.IndexOf(f.b);
				int c = objet.lstVertex.IndexOf(f.c);
				string[] s = { "F." + i.ToString("000"), a.ToString(), b.ToString(), c.ToString(), f.pen.ToString() };
				ListViewItem item = new ListViewItem(s);
				item.UseItemStyleForSubItems = false;
				item.SubItems[4].BackColor = Color.FromArgb(PaletteCpc.GetColorPal(f.pen).GetColorArgb);
				lstViewFace.Items.Add(item);
			}
			numFace = selFace;
			if (selFace != -1) {
				lstViewFace.Items[selFace].Selected = true;
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

		private void ListVertex_SelectedIndexChanged(object sender, EventArgs e) {
			numVertex = listVertex.SelectedIndex;
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
				txbFaceA.Text = objet.lstVertex.IndexOf(f.a).ToString();
				txbFaceB.Text = objet.lstVertex.IndexOf(f.b).ToString();
				txbFaceC.Text = objet.lstVertex.IndexOf(f.c).ToString();
				lblFaceColor.BackColor = Color.FromArgb(PaletteCpc.GetColorPal(f.pen).GetColorArgb);
				selColor = f.pen;
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
		}

		private void BpReadObject_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == DialogResult.OK) {
				objet.ReadObject(of.FileName);
			}
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
		}

		private void BpFusionObject_Click(object sender, EventArgs e) {
		}

		private void BpSaveObject_Click(object sender, EventArgs e) {
			SaveFileDialog sd = new SaveFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (sd.ShowDialog() == DialogResult.OK) {
				objet.SaveObject(sd.FileName);
			}
		}

		private void RedrawAll() {
			DisplayVertex(listVertex.SelectedIndex);
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
			bool err = false;
			Vertex v = objet.lstVertex[numVertex];
			for (int i = 0; i < objet.lstFace.Count; i++) {
				if (objet.lstFace[i].a == v || objet.lstFace[i].b == v || objet.lstFace[i].c == v) {
					err = true;
					break;
				}
			}
			if (!err) {
				objet.lstVertex.RemoveAt(numVertex);
				BpRedraw_Click(sender, e);
			}
			else
				MessageBox.Show("Erreur: ce point est utilisé dans au moins une face.");
		}

		private void BpAddFace_Click(object sender, EventArgs e) {
			int a = Utils.ToInt(txbFaceA.Text);
			int b = Utils.ToInt(txbFaceB.Text);
			int c = Utils.ToInt(txbFaceC.Text);
			if (a >= 0 && b >= 0 && c >= 0 && a < objet.lstVertex.Count && b < objet.lstVertex.Count && c < objet.lstVertex.Count) {
				Face f = new Face(numFace++, objet.lstVertex[a], objet.lstVertex[b], objet.lstVertex[c]);
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
				f.SetNewVertex(objet.lstVertex[a], objet.lstVertex[b], objet.lstVertex[c]);
				f.pen = selColor;
				RedrawAll();
			}
			else
				MessageBox.Show("Certains points n'existent pas.");
		}

		private void BpSupFace_Click(object sender, EventArgs e) {
			objet.lstFace.RemoveAt(numFace);
			BpRedraw_Click(sender, e);
		}

		private void ClickColor(object sender, MouseEventArgs e) {
			Label colorClick = sender as Label;
			selColor = (byte)(colorClick.Tag != null ? (int)colorClick.Tag : 0);
			UpdatePalette();
		}
		#endregion
	}
}
