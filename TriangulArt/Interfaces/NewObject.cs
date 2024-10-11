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
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = txbDisqueHauteur.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			 txbPyra3Base.Enabled = txbPyra3Hauteur.Enabled = txbPyra4Base.Enabled = txbPyra4Hauteur.Enabled =
			 txbSphereDivH.Enabled = txbSphereDivV.Enabled = txbSphereRayon.Enabled = txbAltCoulHoriz.Enabled = txbAltCoulVert.Enabled = chkSphere12.Enabled = false;
		}

		private void RbCube_CheckedChanged(object sender, EventArgs e) {
			txbCubeArete.Enabled = true;
			txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = txbDisqueHauteur.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbPyra3Base.Enabled = txbPyra3Hauteur.Enabled = txbPyra4Base.Enabled = txbPyra4Hauteur.Enabled =
			txbSphereDivH.Enabled = txbSphereDivV.Enabled = txbSphereRayon.Enabled = txbAltCoulHoriz.Enabled = txbAltCoulVert.Enabled = chkSphere12.Enabled = false;
		}

		private void RbDisque_CheckedChanged(object sender, EventArgs e) {
			txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = txbDisqueHauteur.Enabled = true;
			txbCubeArete.Enabled = txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbPyra3Base.Enabled = txbPyra3Hauteur.Enabled = txbPyra4Base.Enabled = txbPyra4Hauteur.Enabled =
			txbSphereDivH.Enabled = txbSphereDivV.Enabled = txbSphereRayon.Enabled = txbAltCoulHoriz.Enabled = txbAltCoulVert.Enabled = chkSphere12.Enabled = false;
		}

		private void RbSoucoupe_CheckedChanged(object sender, EventArgs e) {
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled = true;
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = txbDisqueHauteur.Enabled =
			txbPyra3Base.Enabled = txbPyra3Hauteur.Enabled = txbPyra4Base.Enabled = txbPyra4Hauteur.Enabled =
			txbSphereDivH.Enabled = txbSphereDivV.Enabled = txbSphereRayon.Enabled = txbAltCoulHoriz.Enabled = txbAltCoulVert.Enabled = chkSphere12.Enabled = false;
		}

		private void RbPyramide3Faces_CheckedChanged(object sender, EventArgs e) {
			txbPyra3Base.Enabled = txbPyra3Hauteur.Enabled = true;
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = txbPyra4Base.Enabled = txbPyra4Hauteur.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbSphereDivH.Enabled = txbSphereDivV.Enabled = txbSphereRayon.Enabled = txbAltCoulHoriz.Enabled = txbAltCoulVert.Enabled = chkSphere12.Enabled = false;
		}

		private void RbPyramide4Faces_CheckedChanged(object sender, EventArgs e) {
			txbPyra4Base.Enabled = txbPyra4Hauteur.Enabled = true;
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = txbDisqueHauteur.Enabled = txbPyra3Base.Enabled = txbPyra3Hauteur.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbSphereDivH.Enabled = txbSphereDivV.Enabled = txbSphereRayon.Enabled = txbAltCoulHoriz.Enabled = txbAltCoulVert.Enabled = chkSphere12.Enabled = false;
		}
		private void RbSphere_CheckedChanged(object sender, EventArgs e) {
			txbSphereDivH.Enabled = txbSphereDivV.Enabled = txbSphereRayon.Enabled = txbAltCoulHoriz.Enabled = txbAltCoulVert.Enabled = chkSphere12.Enabled = true;
			txbCubeArete.Enabled = txbDisqueDivision.Enabled = txbDisqueRayon.Enabled = txbDisqueHauteur.Enabled = txbPyra3Base.Enabled = txbPyra3Hauteur.Enabled =
			txbSoucoupeDivision.Enabled = txbSoucoupeHauteur1.Enabled = txbSoucoupeHauteur2.Enabled = txbSoucoupeRayon.Enabled =
			txbPyra4Base.Enabled = txbPyra4Hauteur.Enabled = false;
		}

		private void BpCreate_Click(object sender, EventArgs e) {
			bool err = false;
			int divh = 0, divv = 0;
			double arete = 0, rayon = 0, param1 = 0, param2 = 0, posx = 0, posy = 0, posz = 0;
			double.TryParse(txbPosX.Text, out posx);
			double.TryParse(txbPosY.Text, out posy);
			double.TryParse(txbPosZ.Text, out posz);
			if (chkClearObj.Checked)
				obj.Clear();

			if (rbPyramide3Faces.Checked) {
				if (double.TryParse(txbPyra3Base.Text, out arete) && double.TryParse(txbPyra3Hauteur.Text, out param1) && arete > 0 && param1 != 0)
					obj.CreePyramide3Faces(posx, posy, posz, arete, param1, chkYorient.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'une pyramide à 3 faces sont invalide", "Erreur");
				}
			}
			if (rbPyramide4Faces.Checked) {
				if (double.TryParse(txbPyra4Base.Text, out arete) && double.TryParse(txbPyra4Hauteur.Text, out param1) && arete > 0 && param1 != 0)
					obj.CreePyramide4Faces(posx, posy, posz, arete, param1, chkYorient.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'une pyramide à 4 faces sont invalide", "Erreur");
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
				if (double.TryParse(txbDisqueRayon.Text, out rayon) && int.TryParse(txbDisqueDivision.Text, out divh)
					&& double.TryParse(txbDisqueHauteur.Text, out param1) && rayon > 0 && divh > 0)
					obj.CreeDisque(posx, posy, posz, rayon, divh, param1, chkYorient.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'un disque sont invalide", "Erreur");
				}
			}
			if (rbSoucoupe.Checked) {
				if (double.TryParse(txbSoucoupeRayon.Text, out rayon) && int.TryParse(txbSoucoupeDivision.Text, out divh)
					&& double.TryParse(txbSoucoupeHauteur1.Text, out param1) && double.TryParse(txbSoucoupeHauteur2.Text, out param2)
					&& rayon > 0 && divh > 0 && param1 != param2)
					obj.CreeDoubleDisque(posx, posy, posz, rayon, divh, param1, param2, chkYorient.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'une soucoupe sont invalide", "Erreur");
				}
			}
			if (rbSphere.Checked) {
				if (double.TryParse(txbSphereRayon.Text, out rayon) && int.TryParse(txbSphereDivH.Text, out divh) && int.TryParse(txbSphereDivV.Text, out divv)
					&& double.TryParse(txbAltCoulHoriz.Text, out param1) && double.TryParse(txbAltCoulVert.Text, out param2)
					&& param1 >= 1 && param2 >= 1 && param1 <= 15 && param2 <= 15)
					obj.CreeSphere(posx, posy, posz, rayon, divh, divv, (int)param1, (int)param2, chkSphere12.Checked);
				else {
					err = true;
					MessageBox.Show("Les données pour la création d'une sphère sont invalide", "Erreur");
				}
			}
			if (!err)
				Close();
		}
	}
}
