using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class MakeAnim : Form {
		private DirectBitmap bmpLock = new DirectBitmap(384, 272);
		private DirectBitmap bmpCalc = new DirectBitmap(384, 272);
		private Animation anim = new Animation();
		private Projet projet;

		public MakeAnim(Projet prj) {
			InitializeComponent();
			InitBoutons();
			CreateSequence();
			DisplayFrame(0);
			projet = prj;
		}

		private void InitBoutons() {
			bpAnimate.Enabled = bpWriteTriangle.Enabled = bpRedraw.Enabled = anim.objet.lstFace.Count > 0;
		}

		private void DisplayFrame(int index, List<Triangle> lstTriangle = null) {
			bmpLock.Fill(PaletteCpc.GetColorPal(0).GetColorArgb);
			if (lstTriangle != null)
				bmpCalc.Fill(0xFFFFFF);

			Sequence s = anim.lstSeq[index];
			anim.objet.DrawObj(bmpLock, s.posx, s.posy, s.zoomx, s.zoomy, s.angx, s.angy, s.angz, -1, -1, lstTriangle, bmpCalc);
			pictureBoxScr.Image = bmpLock.Bitmap;
			pictureBoxScr.Refresh();
		}

		private void CreateSequence() {
			double posx = Utils.ToDouble(txbPx.Text);
			double posy = Utils.ToDouble(txbPy.Text);
			double zoomx = Utils.ToDouble(txbZx.Text);
			double zoomy = Utils.ToDouble(txbZy.Text);
			double angx = Utils.ToDouble(txbAx.Text);
			double angy = Utils.ToDouble(txbAy.Text);
			double angz = Utils.ToDouble(txbAz.Text);
			int nbImages = Utils.ToInt(txbNbImages.Text);
			anim.Clear();
			for (int i = 0; i < nbImages; i++) {
				anim.Add(posx, posy, zoomx, zoomy, angx, angy, angz);
				posx += Utils.ToDouble(txbIncPx.Text);
				posy += Utils.ToDouble(txbIncPy.Text);
				zoomx += Utils.ToDouble(txbIncZx.Text);
				zoomy += Utils.ToDouble(txbIncZy.Text);
				angx = (angx + Utils.ToDouble(txbIncAx.Text)) % 360;
				angy = (angy + Utils.ToDouble(txbIncAy.Text)) % 360;
				angz = (angz + Utils.ToDouble(txbIncAz.Text)) % 360;
			}
		}

		private void Animate(bool setProjet = false) {
			Enabled = false;

			if (setProjet)
				projet.lstData.Clear();

			for (int i = 0; i < anim.lstSeq.Count; i++) {
				List<Triangle> lstTriangle = new List<Triangle>();
				DisplayFrame(i, lstTriangle);
				if (setProjet) {
					Datas data = new Datas();
					data.nomImage = "Frame_" + i.ToString();
					for (int t = 0; t < lstTriangle.Count; t++) {
						for (int y = 0; y < bmpCalc.Height; y++) {
							for (int x = 0; x < bmpCalc.Width; x++)
								if (bmpCalc.GetPixel(x, y) == t) {
									Triangle tr = lstTriangle[t];
									int x1 = projet.mode == 0 ? tr.x1 >> 1 : tr.x1;
									int x2 = projet.mode == 0 ? tr.x2 >> 1 : tr.x2;
									int x3 = projet.mode == 0 ? tr.x3 >> 1 : tr.x3;
									data.lstTriangle.Add(new Triangle(x1, tr.y1, x2, tr.y2, x3, tr.y3, tr.color));
									y = bmpCalc.Height;
									break;
								}
						}
					}
					projet.lstData.Add(data);
				}
			}
			Enabled = true;
		}

		private void TxbNbImages_TextChanged(object sender, EventArgs e) {
			int nbImages = Utils.ToInt(txbNbImages.Text);
			if (nbImages != 0) {
				trkIndex.Maximum = nbImages - 1;
				trkIndex.Value = 0;
				CreateSequence();
				DisplayFrame(0);
			}
		}

		private void TrkIndex_Scroll(object sender, EventArgs e) {
			DisplayFrame(trkIndex.Value);
		}

		private void BpReadObject_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == DialogResult.OK) {
				anim.objet.ReadObject(of.FileName);
			}
			DisplayFrame(trkIndex.Value);
			InitBoutons();
		}

		private void BpEditObject_Click(object sender, EventArgs e) {
			Enabled = false;
			new EditObjet(anim.objet).ShowDialog();
			Enabled = true;
		}

		private void BpRedraw_Click(object sender, EventArgs e) {
			DisplayFrame(trkIndex.Value);
		}

		private void BpAnimate_Click(object sender, EventArgs e) {
			Animate();
		}

		private void BpWriteTriangle_Click(object sender, EventArgs e) {
			Animate(true);
		}

		private void BpGenSeqIncr_Click(object sender, EventArgs e) {
			CreateSequence();
			DisplayFrame(trkIndex.Value);
		}

		private void BpGenSeqExpr_Click(object sender, EventArgs e) {
			txbError.Text = "";
			anim.exprPosX = txbExprX.Text;
			anim.exprPosY = txbExprY.Text;
			anim.exprZoomX = txbExprZx.Text;
			anim.exprZoomY = txbExprZy.Text;
			anim.exprAngX = txbExprAx.Text;
			anim.exprAngY = txbExprAy.Text;
			anim.exprAngZ = txbExprAz.Text;
			string err = "";
			for (int i = 0; i < anim.lstSeq.Count; i++) {
				err = anim.Eval(i);
				if (err != "")
					break;
			}
			txbError.Text = err;
			trkIndex.Value = 0;
			DisplayFrame(0);
		}

		private void BpImportSequence_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers CSV (*.csv)|*.csv" };
			if (of.ShowDialog() == DialogResult.OK) {
				anim.Clear();
				StreamReader rd = null;
				try {
					rd = File.OpenText(of.FileName);
					string s;
					int i = 0;
					do {
						s = rd.ReadLine();
						if (s != null && i++ > 0) {
							string[] t = s.Split(';');
							if (t.Length == 8)
								anim.Add(Utils.ToDouble(t[1]), Utils.ToDouble(t[2]), Utils.ToDouble(t[3]), Utils.ToDouble(t[4]), Utils.ToDouble(t[5]), Utils.ToDouble(t[6]), Utils.ToDouble(t[7]));
						}
					}
					while (s != null);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message, "Erreur import séquence.");
				}
				if (rd != null)
					rd.Close();
			}
			txbNbImages.Text = anim.lstSeq.Count.ToString();
			DisplayFrame(0);
		}

		private void BpExportSequence_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers CSV (*.csv)|*.csv" };
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				StreamWriter sw = null;
				try {
					sw = File.CreateText(dlg.FileName);
					int i = 0;
					sw.WriteLine("N.Frame;Position X;Position Y;Zoom X;Zoom Y;Angle X;Angle Y;Angle Z");
					foreach (Sequence s in anim.lstSeq)
						sw.WriteLine(i++ + ";" + s.posx + ";" + s.posy + ";" + s.zoomx + ";" + s.zoomy + ";" + s.angx + ";" + s.angy + ";" + s.angz);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message, "Erreur export séquence.");
				}
				if (sw != null)
					sw.Close();
			}
		}

		private void BpReadAnim_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers XML (*.XML)|*.xml" };
			if (of.ShowDialog() == DialogResult.OK) {
				FileStream fileSeq = File.Open(of.FileName, FileMode.Open);
				try {
					anim = (Animation)new XmlSerializer(typeof(Animation)).Deserialize(fileSeq);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message, "Erreur lecture animation.");
				}
				fileSeq.Close();
				anim.RebuildObject();
			}
			txbNbImages.Text = anim.lstSeq.Count.ToString();
			txbExprX.Text = anim.exprPosX;
			txbExprY.Text = anim.exprPosY;
			txbExprZx.Text = anim.exprZoomX;
			txbExprZy.Text = anim.exprZoomY;
			txbExprAx.Text = anim.exprAngX;
			txbExprAy.Text = anim.exprAngY;
			txbExprAz.Text = anim.exprAngZ;
			DisplayFrame(0);
			InitBoutons();
		}

		private void BpSaveAnim_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers XML (*.XML)|*.xml" };
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Animation)).Serialize(file, anim);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message, "Erreur sauvegarde animation.");
				}
				file.Close();
			}
		}
	}
}
