using System;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class NewObject : Form {
		private Objet obj;
		public NewObject(Objet o) {
			InitializeComponent();
			obj = o;
		}

		private void RbVide_CheckedChanged(object sender, EventArgs e) {
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled = false;
		}

		private void RbCube_CheckedChanged(object sender, EventArgs e) {
			txbCubeArete.Enabled = true;
			txbDisqueDivision.Enabled = txbDisqueRayon.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled = false;
		}

		private void RbDisque_CheckedChanged(object sender, EventArgs e) {
			txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = true;
			txbCubeArete.Enabled = txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled = false;
		}

		private void RbSoucoupe_CheckedChanged(object sender, EventArgs e) {
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled = true;
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = false;
		}

		private void BpCreate_Click(object sender, EventArgs e) {
			bool err = false;
			int division = 0;
			double arete = 0, rayon = 0, hauteur1 = 0, hauteur2 = 0;
			obj.Clear();
			if (rbCube.Checked) {
				double.TryParse(txbCubeArete.Text, out arete);
				if (arete != 0)
					obj.CreeCube(arete);
				else {
					err = true;
				}
			}
			if (rbDisque.Checked) {
				double.TryParse(txbDisqueRayon.Text, out rayon);
				int.TryParse(txbDisqueDivision.Text, out division);
				if (rayon > 0 && division > 0)
					obj.CreeDisque(rayon, division);
				else {
					err = true;
				}
			}
			if (rbSoucoupe.Checked) {
				double.TryParse(txbSoucoupeRayon.Text, out rayon);
				int.TryParse(txbSoucoupeDivision.Text, out division);
				double.TryParse(txbSoucoupeHauteur1.Text, out hauteur1);
				double.TryParse(txbSoucoupeHauteur2.Text, out hauteur2);
				if (rayon > 0 && division > 0 && hauteur1 != hauteur2)
					obj.CreeDoubleDisque(rayon, division, hauteur1, hauteur2);
				else {
					err = true;
				}
			}
			if (!err)
				Close();
		}
	}
}
