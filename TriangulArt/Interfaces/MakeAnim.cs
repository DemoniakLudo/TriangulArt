using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class MakeAnim : Form {
		private Objet objet = new Objet();
		private DirectBitmap bmpLock = new DirectBitmap(384, 272);
		private DirectBitmap bmpCalc = new DirectBitmap(384, 272);
		private List<Sequence> lstSeq = new List<Sequence>();
		private Projet projet;

		public MakeAnim(Projet prj) {
			InitializeComponent();
			InitBoutons();
			CreateSequence();
			DisplayFrame(lstSeq[0]);
			projet = prj;
		}

		private void InitBoutons() {
			bpAnimate.Enabled = bpWriteTriangle.Enabled = bpRedraw.Enabled = objet.lstFace.Count > 0;
		}

		private void DisplayFrame(Sequence s, List<Triangle> lstTriangle = null) {
			bmpLock.Fill(PaletteCpc.GetColorPal(0).GetColorArgb);
			if (lstTriangle != null)
				bmpCalc.Fill(0xFFFFFF);

			objet.DrawObj(bmpLock, s.PosX, s.PosY, s.ZoomX, s.ZoomY, s.AngX, s.AngY, s.AngZ, -1, -1, lstTriangle, bmpCalc);
			pictureBoxScr.Image = bmpLock.Bitmap;
			pictureBoxScr.Refresh();
		}

		private void CreateSequence() {
			double posx = Utils.ConvertToDouble(txbPx.Text);
			double posy = Utils.ConvertToDouble(txbPy.Text);
			double zoomx = Utils.ConvertToDouble(txbZx.Text);
			double zoomy = Utils.ConvertToDouble(txbZy.Text);
			double angx = Utils.ConvertToDouble(txbAx.Text);
			double angy = Utils.ConvertToDouble(txbAy.Text);
			double angz = Utils.ConvertToDouble(txbAz.Text);
			int nbImages = Utils.ConvertToInt(txbNbImages.Text);
			lstSeq.Clear();
			for (int i = 0; i < nbImages; i++) {
				lstSeq.Add(new Sequence(posx, posy, zoomx, zoomy, angx, angy, angz));
				posx += Utils.ConvertToDouble(txbIncPx.Text);
				posy += Utils.ConvertToDouble(txbIncPy.Text);
				zoomx += Utils.ConvertToDouble(txbIncZx.Text);
				zoomy += Utils.ConvertToDouble(txbIncZy.Text);
				angx = (angx + Utils.ConvertToDouble(txbIncAx.Text)) % 360;
				angy = (angy + Utils.ConvertToDouble(txbIncAy.Text)) % 360;
				angz = (angz + Utils.ConvertToDouble(txbIncAz.Text)) % 360;
			}
		}

		private void Animate(bool setProjet = false) {
			Enabled = false;
			if (!chkUseSeq.Checked)
				CreateSequence();

			if (setProjet)
				projet.lstData.Clear();

			for (int i = 0; i < lstSeq.Count; i++) {
				Image img = new Image();
				DisplayFrame(lstSeq[i], img.lstTriangle);
				if (setProjet) {
					img.Optimize(bmpCalc);
					Datas d = new Datas();
					projet.lstData.Add(d);
					img.GenereDatas(d, i, rbMode0.Checked);
				}
			}
			Enabled = true;
		}

		private void ChkUseSeq_CheckedChanged(object sender, EventArgs e) {
			txbPx.Enabled = txbPy.Enabled = txbZx.Enabled = txbZy.Enabled = txbAx.Enabled = txbAy.Enabled = txbAz.Enabled =
			txbIncPx.Enabled = txbIncPy.Enabled = txbIncZx.Enabled = txbIncZy.Enabled = txbIncAx.Enabled = txbIncAy.Enabled = txbIncAz.Enabled = !chkUseSeq.Checked;
		}

		private void BpEditSequence_Click(object sender, EventArgs e) {
			Enabled = false;
			new EditSequence(lstSeq).ShowDialog();
			Enabled = true;
		}

		private void BpReadObject_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == DialogResult.OK) {
				objet.ReadObject(of.FileName);
			}
			DisplayFrame(lstSeq[0]);
			InitBoutons();
			if (!chkUseSeq.Checked)
				CreateSequence();
		}

		private void BpEditObject_Click(object sender, EventArgs e) {
			Enabled = false;
			new EditObjet().ShowDialog();
			Enabled = true;
		}

		private void BpRedraw_Click(object sender, EventArgs e) {
			if (!chkUseSeq.Checked)
				CreateSequence();

			DisplayFrame(lstSeq[0]);
		}

		private void BpAnimate_Click(object sender, EventArgs e) {
			Animate();
		}

		private void BpWriteTriangle_Click(object sender, EventArgs e) {
			Animate(true);
		}
	}
}
