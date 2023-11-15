using System;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class EditObjet : Form {
		private Objet objet = new Objet();
		private DirectBitmap bmpLock = new DirectBitmap(640, 400);
		private int numFace = -1, numVertex = -1;

		public EditObjet() {
			InitializeComponent();
			DisplayObj();
		}

		private void DisplayVertex(int selVertex) {
			listVertex.Items.Clear();
			int i = 0;
			foreach (Vertex v in objet.lstVertex) {
				string item = "V." + i.ToString("000") + "\t" + v.X.ToString("0.0000") + "\t" + v.Y.ToString("0.0000") + "\t" + v.Z.ToString("0.0000");
				listVertex.Items.Add(item);
				i++;
			}
			numVertex = selVertex;
			if (selVertex != -1)
				listVertex.SelectedIndex = selVertex;
		}

		private void DisplayFace(int selFace) {
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
			bmpLock.Fill(0x808080);
			int zoom = Utils.ConvertToInt(txbZoom.Text);
			int angx = Utils.ConvertToInt(txbValX.Text);
			int angy = Utils.ConvertToInt(txbValY.Text);
			int angz = Utils.ConvertToInt(txbValZ.Text);
			objet.DrawObj(bmpLock, 320, 200, zoom, zoom, angx, angy, angz, numFace, numVertex);
			pictureBoxObj.Image = bmpLock.Bitmap;
			pictureBoxObj.Refresh();
		}

		private void listVertex_SelectedIndexChanged(object sender, EventArgs e) {
			numVertex = listVertex.SelectedIndex;
			Vertex v = objet.lstVertex[numVertex];
			txbVertexX.Text = v.X.ToString();
			txbVertexY.Text = v.Y.ToString();
			txbVertexZ.Text = v.Z.ToString();
			DisplayObj();
			bpEditVertex.Enabled = bpSupVertex.Enabled = true;
		}

		private void listFace_SelectedIndexChanged(object sender, EventArgs e) {
			numFace = listFace.SelectedIndex;
			Face f = objet.lstFace[numFace];
			txbFaceA.Text = objet.lstVertex.IndexOf(f.GetA).ToString();
			txbFaceB.Text = objet.lstVertex.IndexOf(f.GetB).ToString();
			txbFaceC.Text = objet.lstVertex.IndexOf(f.GetC).ToString();
			DisplayObj();
			bpEditFace.Enabled = bpSupFace.Enabled = true;
		}

		#region gestion trackbars
		private void trackX_Scroll(object sender, EventArgs e) {
			txbValX.Text = trackX.Value.ToString();
			DisplayObj();
		}

		private void trackY_Scroll(object sender, EventArgs e) {
			txbValY.Text = trackY.Value.ToString();
			DisplayObj();
		}

		private void trackZ_Scroll(object sender, EventArgs e) {
			txbValZ.Text = trackZ.Value.ToString();
			DisplayObj();
		}

		private void trackZoom_Scroll(object sender, EventArgs e) {
			txbZoom.Text = trackZoom.Value.ToString();
			DisplayObj();
		}
		#endregion

		#region gestion boutons
		private void bpNewObject_Click(object sender, EventArgs e) {
		}

		private void bpReadObject_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				objet.ReadObject(of.FileName);
			}
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
		}

		private void bpFusionObject_Click(object sender, EventArgs e) {
		}

		private void bpSaveObject_Click(object sender, EventArgs e) {
		}

		private void bpRedraw_Click(object sender, EventArgs e) {
			DisplayVertex(-1);
			DisplayFace(-1);
			DisplayObj();
			bpEditVertex.Enabled = bpSupVertex.Enabled = bpEditFace.Enabled = bpSupFace.Enabled = false;
		}

		private void bpAddVertex_Click(object sender, EventArgs e) {
			double x = Convert.ToDouble(txbVertexX.Text);
			double y = Convert.ToDouble(txbVertexY.Text);
			double z = Convert.ToDouble(txbVertexZ.Text);
			objet.lstVertex.Add(new Vertex(x, y, z));
			DisplayVertex(objet.lstVertex.Count - 1);
		}

		private void bpSupVertex_Click(object sender, EventArgs e) {
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
				bpRedraw_Click(sender, e);
			}
			else
				MessageBox.Show("Erreur: ce point est utilisé dans au moins une face.");
		}

		private void bpEditVertex_Click(object sender, EventArgs e) {
		}

		private void bpAddFace_Click(object sender, EventArgs e) {
		}

		private void bpSupFace_Click(object sender, EventArgs e) {
		}

		private void bpEditFace_Click(object sender, EventArgs e) {
		}
		#endregion
	}
}
