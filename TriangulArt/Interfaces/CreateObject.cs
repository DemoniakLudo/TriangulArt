using System;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class CreateObject : Form {
		private Projet projet;
		private int width, height;
		private Objet o = new Objet();

		public CreateObject(Projet p, int w, int h) {
			InitializeComponent();
			projet = p;
			width = w;
			height = h;
		}

		private bool CreePlat() {
			int nFace = 0;
			int nVertex = 0;
			int adjX = projet.mode == 0 ? 2 : 1;
			foreach (Triangle t in projet.SelImage().lstTriangle) {
				Vertex v1 = new Vertex(adjX * (t.x1 - width / 2), height / 2 - t.y1, 0);
				Vertex v2 = new Vertex(adjX * (t.x2 - width / 2), height / 2 - t.y2, 0);
				Vertex v3 = new Vertex(adjX * (t.x3 - width / 2), height / 2 - t.y3, 0);
				o.lstVertex.Add(v1);
				o.lstVertex.Add(v2);
				o.lstVertex.Add(v3);
				o.lstFace.Add(new Face(nFace++, nVertex, nVertex + 1, nVertex + 2, t.color));
				nVertex += 3;
			}
			return true;
		}

		private bool CreeEpais() {
			int epais = 0;
			int.TryParse(txbEpais.Text, out epais);
			if (epais > 0) {
				int nFace = 0;
				int nVertex = 0;
				int adjX = projet.mode == 0 ? 2 : 1;
				foreach (Triangle t in projet.SelImage().lstTriangle) {
					Vertex v1 = new Vertex(adjX * (t.x1 - width / 2), height / 2 - t.y1, 0);
					Vertex v2 = new Vertex(adjX * (t.x2 - width / 2), height / 2 - t.y2, 0);
					Vertex v3 = new Vertex(adjX * (t.x3 - width / 2), height / 2 - t.y3, 0);
					o.lstVertex.Add(v1);
					o.lstVertex.Add(v2);
					o.lstVertex.Add(v3);
					o.lstFace.Add(new Face(nFace++, nVertex, nVertex + 1, nVertex + 2, t.color));
					Vertex v4 = new Vertex(adjX * (t.x1 - width / 2), height / 2 - t.y1, epais);
					Vertex v5 = new Vertex(adjX * (t.x2 - width / 2), height / 2 - t.y2, epais);
					Vertex v6 = new Vertex(adjX * (t.x3 - width / 2), height / 2 - t.y3, epais);
					o.lstVertex.Add(v4);
					o.lstVertex.Add(v5);
					o.lstVertex.Add(v6);
					o.lstFace.Add(new Face(nFace++, nVertex + 3, nVertex + 4, nVertex + 5, t.color));
					o.lstFace.Add(new Face(nFace++, nVertex + 3, nVertex + 0, nVertex + 1, t.color));
					o.lstFace.Add(new Face(nFace++, nVertex + 3, nVertex + 4, nVertex + 1, t.color));
					o.lstFace.Add(new Face(nFace++, nVertex + 4, nVertex + 1, nVertex + 5, t.color));
					o.lstFace.Add(new Face(nFace++, nVertex + 1, nVertex + 5, nVertex + 2, t.color));
					o.lstFace.Add(new Face(nFace++, nVertex + 3, nVertex + 0, nVertex + 4, t.color));
					o.lstFace.Add(new Face(nFace++, nVertex + 3, nVertex + 4, nVertex + 5, t.color));
					nVertex += 6;
				}
				return true;
			}
			MessageBox.Show("L'épaisseur doit être supérieure à zéro.");
			return false;
		}

		private bool CreeCylindre() {
			int rayon = 0;
			int.TryParse(txbRayon.Text, out rayon);
			if (rayon >= 2 && rayon <= 16) {
				int nFace = 0;
				int nVertex = 0;
				int adjX = projet.mode == 0 ? 2 : 1;
				for (int r = 0; r < rayon; r++) {
					double ay = r * 360 / rayon;
					foreach (Triangle t in projet.SelImage().lstTriangle) {
						o.AddRotateVertex(adjX * (t.x1 - width / 2), height / 2 - t.y1, ay);
						o.AddRotateVertex(adjX * (t.x2 - width / 2), height / 2 - t.y2, ay);
						o.AddRotateVertex(adjX * (t.x3 - width / 2), height / 2 - t.y3, ay);
						o.lstFace.Add(new Face(nFace++, nVertex, nVertex + 1, nVertex + 2, t.color));
						nVertex += 3;
					}
				}
				return true;
			}
			MessageBox.Show("Le rayon doit être compris entre 2 et 16.");
			return false;
		}

		private void rbPlat_CheckedChanged(object sender, EventArgs e) {
			txbEpais.Enabled = false;
			txbRayon.Enabled = false;
		}

		private void rbEpais_CheckedChanged(object sender, EventArgs e) {
			txbEpais.Enabled = true;
			txbRayon.Enabled = false;
		}

		private void rbCylindre_CheckedChanged(object sender, EventArgs e) {
			txbEpais.Enabled = false;
			txbRayon.Enabled = true;
		}

		private void bpCreer_Click(object sender, EventArgs e) {
			Enabled = false;
			bool isOk = false;
			if (rbPlat.Checked)
				isOk = CreePlat();


			if (rbEpais.Checked)
				isOk = CreeEpais();

			if (rbCylindre.Checked)
				isOk = CreeCylindre();

			if (isOk) {
				Enabled = false;
				Close();
				new EditObjet(projet, o).ShowDialog();
			}
		}
	}
}
