using System;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class ParamObjet : Form {
		private Objet objet;
		private Vertex centre = new Vertex();
		private Vertex taille = new Vertex();

		public ParamObjet(Objet o) {
			InitializeComponent();
			objet = o;
			o.CalcParamObjet(ref centre, ref taille);
			txbPosX.Text = centre.x.ToString("0.0000");
			txbPosY.Text = centre.y.ToString("0.0000");
			txbPosZ.Text = centre.z.ToString("0.0000");
			txbZoomX.Text = taille.x.ToString("0.0000");
			txbZoomY.Text = taille.y.ToString("0.0000");
			txbZoomZ.Text = taille.z.ToString("0.0000");
		}

		private void chkLies_CheckedChanged(object sender, EventArgs e) {
			txbZoomY.Enabled = !chkLies.Checked;
			txbZoomZ.Enabled = !chkLies.Checked;
		}

		private void bpAppliquer_Click(object sender, EventArgs e) {
			Vertex newCentre = new Vertex(Utils.ToDouble(txbPosX.Text), Utils.ToDouble(txbPosY.Text), Utils.ToDouble(txbPosZ.Text));
			Vertex newTaille = new Vertex();
			newTaille.x = Utils.ToDouble(txbZoomX.Text);
			// Coeff. de zoom liés ?
			if (chkLies.Checked) {
				if (taille.x != 0) {
					newTaille.y = taille.y * newTaille.x / taille.x;
					newTaille.z = taille.z * newTaille.x / taille.x;
				}
				else
					newTaille.y = newTaille.z = 0;
			}
			else {
				newTaille.y = Utils.ToDouble(txbZoomX.Text);
				newTaille.z = Utils.ToDouble(txbZoomX.Text);
			}
			newTaille.x = taille.x != 0 ? newTaille.x / taille.x : 0;
			newTaille.y = taille.y != 0 ? newTaille.y / taille.y : 0;
			newTaille.z = taille.z != 0 ? newTaille.z / taille.z : 0;
			newCentre.x -= centre.x;
			newCentre.y -= centre.y;
			newCentre.z -= centre.z;
			objet.SetParamObjet(newCentre, newTaille);
			Close();
		}
	}
}
