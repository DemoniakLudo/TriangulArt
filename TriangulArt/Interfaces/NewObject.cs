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
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbPyraBase.Enabled = txbPyraHauteur.Enabled = false;
		}

		private void RbCube_CheckedChanged(object sender, EventArgs e) {
			txbCubeArete.Enabled = true;
			txbDisqueDivision.Enabled = txbDisqueRayon.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbPyraBase.Enabled = txbPyraHauteur.Enabled = false;
		}

		private void RbDisque_CheckedChanged(object sender, EventArgs e) {
			txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = true;
			txbCubeArete.Enabled = txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbPyraBase.Enabled = txbPyraHauteur.Enabled = false;
		}

		private void RbSoucoupe_CheckedChanged(object sender, EventArgs e) {
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled = true;
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled =
			txbPyraBase.Enabled = txbPyraHauteur.Enabled = false;
		}

		private void rbPyramide_CheckedChanged(object sender, EventArgs e) {
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled =
		txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled = false;
			txbPyraBase.Enabled = txbPyraHauteur.Enabled = true;
		}

		private void BpCreate_Click(object sender, EventArgs e) {
			bool err = false;
			int division = 0;
			double arete = 0, rayon = 0, hauteur1 = 0, hauteur2 = 0;
			double posx = 0, posy = 0, posz = 0;
			double.TryParse(txbPosX.Text, out posx);
			double.TryParse(txbPosY.Text, out posy);
			double.TryParse(txbPosZ.Text, out posz);
			if (chkClearObj.Checked)
				obj.Clear();

			if (rbPyramide.Checked) {
				if (double.TryParse(txbPyraBase.Text, out arete) && double.TryParse(txbPyraHauteur.Text, out hauteur1) && arete > 0 && hauteur1 != 0)
					obj.CreePyramide(posx, posy, posz, arete, hauteur1, chkYorient.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'une pyramide sont invalide", "Erreur");
				}
			}
			if (rbCube.Checked) {
				if (double.TryParse(txbCubeArete.Text, out arete) && arete != 0)
					obj.CreeCube(posx, posy, posz, arete);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'un cube sont invalide", "Erreur");
				}
			}
			if (rbDisque.Checked) {
				if (double.TryParse(txbDisqueRayon.Text, out rayon) && int.TryParse(txbDisqueDivision.Text, out division) && rayon > 0 && division > 0)
					obj.CreeDisque(posx, posy, posz, rayon, division, chkYorient.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'un disque sont invalide", "Erreur");
				}
			}
			if (rbSoucoupe.Checked) {
				if (double.TryParse(txbSoucoupeRayon.Text, out rayon) && int.TryParse(txbSoucoupeDivision.Text, out division)
					&& double.TryParse(txbSoucoupeHauteur1.Text, out hauteur1) && double.TryParse(txbSoucoupeHauteur2.Text, out hauteur2)
					&& rayon > 0 && division > 0 && hauteur1 != hauteur2)
					obj.CreeDoubleDisque(posx, posy, posz, rayon, division, hauteur1, hauteur2, chkYorient.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'une soucoupe sont invalide", "Erreur");
				}
			}
			if (!err) {
				Close();
			}
		}
	}
}
