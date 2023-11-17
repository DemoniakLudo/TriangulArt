using System;
using System.Drawing;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class EditObjet : Form {
		private Objet objet = new Objet();
		private DirectBitmap bmpLock = new DirectBitmap(640, 400);
		private int numFace = -1, numVertex = -1;
		private Label[] colors = new Label[16];
		private byte selColor = 1;

		public EditObjet() {
			InitializeComponent();
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
			DisplayObj();
			UpdatePalette();
		}

		private void DisplayBoutons() {
			bpEditVertex.Enabled = bpSupVertex.Enabled = objet.lstVertex.Count > 0 && numVertex != -1;
			bpEditFace.Enabled = bpSupFace.Enabled = bpSaveObject.Enabled = objet.lstFace.Count > 0 && numFace != -1;
		}

		private void DisplayVertex(int selVertex) {
			DisplayBoutons();
			listVertex.Items.Clear();
			int i = 0;
			foreach (Vertex v in objet.lstVertex) {
				string item = "V." + i++.ToString("000") + "\t" + v.X.ToString("0.0000") + "\t" + v.Y.ToString("0.0000") + "\t" + v.Z.ToString("0.0000");
				listVertex.Items.Add(item);
			}
			numVertex = selVertex;
			if (selVertex != -1)
				listVertex.SelectedIndex = selVertex;
		}

		private void DisplayFace(int selFace) {
			DisplayBoutons();
			listFace.Items.Clear();
			for (int i = 0; i < objet.lstFace.Count; i++) {
				Face f = objet.lstFace[i];
				int a = objet.lstVertex.IndexOf(f.GetA);
				int b = objet.lstVertex.IndexOf(f.GetB);
				int c = objet.lstVertex.IndexOf(f.GetC);
				string item = "F." + i.ToString("000") + "\t" + a.ToString() + "\t" + b.ToString() + "\t" + c.ToString();
				listFace.Items.Add(item);
			}
			numFace = selFace;
			if (selFace != -1)
				listFace.SelectedIndex = selFace;
		}

		private void DisplayObj() {
			DisplayBoutons();
			bmpLock.Fill(PaletteCpc.GetColorPal(0).GetColorArgb);
			int zoom = Utils.ConvertToInt(txbZoom.Text);
			int angx = Utils.ConvertToInt(txbValX.Text);
			int angy = Utils.ConvertToInt(txbValY.Text);
			int angz = Utils.ConvertToInt(txbValZ.Text);
			objet.DrawObj(bmpLock, 320, 200, zoom, zoom, angx, angy, angz, numFace, numVertex);
			pictureBoxObj.Image = bmpLock.Bitmap;
			pictureBoxObj.Refresh();
		}

		private void ListVertex_SelectedIndexChanged(object sender, EventArgs e) {
			numVertex = listVertex.SelectedIndex;
			if (numVertex!=-1) {
				Vertex v = objet.lstVertex[numVertex];
				txbVertexX.Text = v.X.ToString();
				txbVertexY.Text = v.Y.ToString();
				txbVertexZ.Text = v.Z.ToString();
			}
			DisplayObj();
		}

		private void UpdatePalette() {
			for (int i = 0; i < 16; i++)
				colors[i].BackColor = Color.FromArgb(PaletteCpc.GetColorPal(i).GetColorArgb);

			lblFaceColor.BackColor = Color.FromArgb(PaletteCpc.GetColorPal(selColor).GetColorArgb);
		}

		private void ListFace_SelectedIndexChanged(object sender, EventArgs e) {
			numFace = listFace.SelectedIndex;
			if (numFace!=-1) {
				Face f = objet.lstFace[numFace];
				txbFaceA.Text = objet.lstVertex.IndexOf(f.GetA).ToString();
				txbFaceB.Text = objet.lstVertex.IndexOf(f.GetB).ToString();
				txbFaceC.Text = objet.lstVertex.IndexOf(f.GetC).ToString();
				lblFaceColor.BackColor = Color.FromArgb(PaletteCpc.GetColorPal(f.pen).GetColorArgb);
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
			DisplayFace(listFace.SelectedIndex);
			DisplayObj();
		}

		private void BpRedraw_Click(object sender, EventArgs e) {
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
			bpEditVertex.Enabled = bpSupVertex.Enabled = bpEditFace.Enabled = bpSupFace.Enabled = false;
		}

		private void BpAddVertex_Click(object sender, EventArgs e) {
			double x = Utils.ConvertToDouble(txbVertexX.Text);
			double y = Utils.ConvertToDouble(txbVertexY.Text);
			double z = Utils.ConvertToDouble(txbVertexZ.Text);
			objet.lstVertex.Add(new Vertex(x, y, z));
			DisplayVertex(objet.lstVertex.Count - 1);
		}

		private void BpEditVertex_Click(object sender, EventArgs e) {
			Vertex v = objet.lstVertex[numVertex];
			double x = Utils.ConvertToDouble(txbVertexX.Text);
			double y = Utils.ConvertToDouble(txbVertexY.Text);
			double z = Utils.ConvertToDouble(txbVertexZ.Text);
			v.SetNewCoord(x, y, z);
			RedrawAll();
		}

		private void BpSupVertex_Click(object sender, EventArgs e) {
			bool err = false;
			Vertex v = objet.lstVertex[numVertex];
			for (int i = 0; i < objet.lstFace.Count; i++) {
				if (objet.lstFace[i].GetA == v || objet.lstFace[i].GetB == v || objet.lstFace[i].GetB == v) {
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
			int a = Utils.ConvertToInt(txbFaceA.Text);
			int b = Utils.ConvertToInt(txbFaceB.Text);
			int c = Utils.ConvertToInt(txbFaceC.Text);
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
			int a = Utils.ConvertToInt(txbFaceA.Text);
			int b = Utils.ConvertToInt(txbFaceB.Text);
			int c = Utils.ConvertToInt(txbFaceC.Text);
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
			byte pen = colorClick.Tag != null ? (byte)colorClick.Tag :(byte)0;
			selColor = pen;
			UpdatePalette();
		}
		#endregion
	}
}
