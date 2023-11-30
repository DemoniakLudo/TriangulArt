﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class MakeAnim : Form {
		private DirectBitmap bmpLock;
		private DirectBitmap bmpCalc;
		private Bitmap bmpFond;
		private Animation anim;
		private Projet projet;
		private bool inAnim = false, endAnim = false;

		public MakeAnim(Projet prj, Animation anm, ImageFond bf) {
			InitializeComponent();
			int width = prj.mode == 0 ? 192 : 384;
			bmpLock = new DirectBitmap(width, 272);
			bmpCalc = new DirectBitmap(width, 272);
			txbPx.Text = txbExprX.Text = (width / 2).ToString();
			projet = prj;
			anim = anm;
			bmpFond = bf.NbImg > 0 ? bf.GetImage : null;
			txbExprX.Text = anim.exprPosX == "" ? txbExprX.Text : anim.exprPosX;
			txbExprY.Text = anim.exprPosY == "" ? txbExprY.Text : anim.exprPosY;
			txbExprZx.Text = anim.exprZoomX == "" ? txbExprZx.Text : anim.exprZoomX;
			txbExprZy.Text = anim.exprZoomY == "" ? txbExprZy.Text : anim.exprZoomY;
			txbExprAx.Text = anim.exprAngX == "" ? txbExprAx.Text : anim.exprAngX;
			txbExprAy.Text = anim.exprAngY == "" ? txbExprAy.Text : anim.exprAngY;
			txbExprAz.Text = anim.exprAngZ == "" ? txbExprAz.Text : anim.exprAngZ;
			txbNbImages.Text = anim.lstSeq.Count > 0 ? anim.lstSeq.Count.ToString() : txbNbImages.Text;
			rbSeqExpression.Checked = anim.withExpression;
			InitBoutons();
			GenereSeq();
			DisplayFrame(0);
		}

		private void InitBoutons() {
			bpAnimate.Enabled = bpWriteTriangle.Enabled = bpRedraw.Enabled = !inAnim && anim.objet.lstFace.Count > 0;
			bpStopAnim.Enabled = inAnim;
			bpFusion.Enabled = !inAnim && projet.lstData.Count == Utils.ToInt(txbNbImages.Text);
			bpReadObject.Enabled = bpEditObject.Enabled = bpReadAnim.Enabled = bpSaveAnim.Enabled = bpExportSequence.Enabled = bpImportSequence.Enabled = !inAnim&& rbSeqIncrement.Checked;
			txbPx.Enabled = txbPy.Enabled = txbZx.Enabled = txbZy.Enabled = txbAx.Enabled = txbAy.Enabled = txbAz.Enabled =
			txbIncPx.Enabled = txbIncPy.Enabled = txbIncZx.Enabled = txbIncZy.Enabled = txbIncAx.Enabled = txbIncAy.Enabled = txbIncAz.Enabled = rbSeqIncrement.Checked;
			txbExprX.Enabled = txbExprY.Enabled = txbExprZx.Enabled = txbExprZy.Enabled = txbExprAx.Enabled = txbExprAy.Enabled = txbExprAz.Enabled = rbSeqExpression.Checked;
		}

		private void AddInfo(string msg) {
			lstInfo.Items.Add(msg);
			lstInfo.SelectedIndex = lstInfo.Items.Count - 1;
		}

		private void DisplayFrame(int index, List<Triangle> lstTriangle = null) {
			lblNumImage.Text = "Image " + String.Format("{0,3}", index);
			if (bmpFond != null) {
				for (int y = 0; y < bmpFond.Height; y++)
					for (int x = 0; x < bmpFond.Width; x++)
						bmpLock.SetPixel(x, y, bmpFond.GetPixel(x, y).ToArgb());
			}
			else
				bmpLock.Fill(PaletteCpc.GetColorPal(0).GetColorArgb);

			if (lstTriangle != null)
				bmpCalc.Fill(0xFFFFFF);

			Sequence s = anim.lstSeq[index];
			anim.objet.DrawObj(bmpLock, s.posx, s.posy, s.zoomx, s.zoomy, s.angx, s.angy, s.angz, -1, -1, lstTriangle, bmpCalc);
			pictureBoxScr.Image = bmpLock.Bitmap;
			pictureBoxScr.Refresh();
		}

		private void GenereSeq() {
			if (rbSeqIncrement.Checked) {
				// Génération séquence depuis incréments
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
					angx += Utils.ToDouble(txbIncAx.Text);
					angy += Utils.ToDouble(txbIncAy.Text);
					angz += Utils.ToDouble(txbIncAz.Text);
				}
			}
			else {
				// Génération séquence depuis expressions
				anim.Clear();
				anim.exprPosX = txbExprX.Text;
				anim.exprPosY = txbExprY.Text;
				anim.exprZoomX = txbExprZx.Text;
				anim.exprZoomY = txbExprZy.Text;
				anim.exprAngX = txbExprAx.Text;
				anim.exprAngY = txbExprAy.Text;
				anim.exprAngZ = txbExprAz.Text;
				string err = "";
				int nbImages = Utils.ToInt(txbNbImages.Text);
				for (int i = 0; i < nbImages; i++) {
					err = anim.AddEval();
					if (err != "") {
						AddInfo(err);
						break;
					}
				}
				trkIndex.Value = 0;
			}
		}

		private void Animate(bool setProjet = false, bool fusion = false) {
			GenereSeq();
			if (setProjet && !fusion)
				projet.lstData.Clear();

			InitBoutons();
			for (int i = 0; i < anim.lstSeq.Count; i++) {
				List<Triangle> lstTriangle = new List<Triangle>();
				DisplayFrame(i, lstTriangle);
				Application.DoEvents();
				if (setProjet) {
					Datas data = fusion ? projet.lstData[i] : new Datas();
					data.nomImage = "Frame_" + i.ToString();
					for (int t = 0; t < lstTriangle.Count; t++) {
						for (int y = 0; y < bmpCalc.Height; y++) {
							for (int x = 0; x < bmpCalc.Width; x++)
								if (bmpCalc.GetPixel(x, y) == t) {
									Triangle tr = lstTriangle[t];
									data.lstTriangle.Add(new Triangle(tr.x1, tr.y1, tr.x2, tr.y2, tr.x3, tr.y3, tr.color));
									y = bmpCalc.Height;
									break;
								}
						}
					}
					if (!fusion)
						projet.lstData.Add(data);
				}
				if (endAnim)
					break;
			}
			InitBoutons();
			if (setProjet) {
				int nbAvant = 0;
				int nbApres = 0;
				projet.Clean(bmpLock.Width, ref nbAvant, ref nbApres);
				if (fusion)
					AddInfo("Fusion de " + anim.lstSeq.Count.ToString() + " images avec le projet en cours.");
				else
					AddInfo("Création projet avec " + anim.lstSeq.Count.ToString() + " images.");
			}
		}

		private void TxbNbImages_TextChanged(object sender, EventArgs e) {
			int nbImages = Utils.ToInt(txbNbImages.Text);
			if (nbImages != 0) {
				trkIndex.Maximum = nbImages - 1;
				trkIndex.Value = 0;
				GenereSeq();
				DisplayFrame(0);
				InitBoutons();
				AddInfo("Regénération séquence avec " + nbImages + " images.");
			}
		}

		private void TrkIndex_Scroll(object sender, EventArgs e) {
			DisplayFrame(trkIndex.Value);
		}

		private void BpReadObject_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers objets ascii (*.asc)|*.asc|Tous les fichiers (*.*)|*.*\"'" };
			if (of.ShowDialog() == DialogResult.OK) {
				int numPen = 0;
				anim.objet.ReadObject(of.FileName, ref numPen);
				AddInfo("Objet " + Path.GetFileName(of.FileName) + " chargé. " + anim.objet.lstFace.Count + " Faces.");
			}
			DisplayFrame(trkIndex.Value);
			InitBoutons();
		}

		private void BpEditObject_Click(object sender, EventArgs e) {
			Enabled = false;
			new EditObjet(projet, anim.objet).ShowDialog();
			InitBoutons();
			Enabled = true;
		}

		private void BpRedraw_Click(object sender, EventArgs e) {
			GenereSeq();
			DisplayFrame(trkIndex.Value);
		}

		private void BpAnimate_Click(object sender, EventArgs e) {
			endAnim = false;
			inAnim = true;
			while (!endAnim) {
				Animate();
			}
		}

		private void bpStopAnim_Click(object sender, EventArgs e) {
			endAnim = true;
			inAnim = false;
		}

		private void BpWriteTriangle_Click(object sender, EventArgs e) {
			Enabled = false;
			Animate(true);
			Enabled = true;
		}
		private void bpFusion_Click(object sender, EventArgs e) {
			Enabled = false;
			Animate(true, true);
			Enabled = true;
		}

		private void BpGenSeqIncr_Click(object sender, EventArgs e) {
			GenereSeq();
			DisplayFrame(trkIndex.Value);
		}

		private void BpGenSeqExpr_Click(object sender, EventArgs e) {
			GenereSeq();
		}

		private void BpImportSequence_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers CSV (*.csv)|*.csv" };
			bool err = false;
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
					err = true;
					AddInfo("Erreur import séquence : " + ex.Message);
				}
				if (rd != null)
					rd.Close();


			}
			int nbImages = anim.lstSeq.Count;
			if (!err) {
				txbNbImages.Text = nbImages.ToString();
				AddInfo("Séquence importée avec " + nbImages.ToString() + " images.");
			}
			GenereSeq();
			DisplayFrame(0);
		}

		private void BpExportSequence_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers CSV (*.csv)|*.csv" };
			DialogResult result = dlg.ShowDialog();
			bool err = false;
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
					err = true;
					AddInfo("Erreur export séquence : " + ex.Message);
				}
				if (sw != null)
					sw.Close();

				if (!err)
					AddInfo("Séquence exportée.");
			}
		}

		private void BpReadAnim_Click(object sender, EventArgs e) {
			bool err = false;
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers XML (*.XML)|*.xml" };
			if (of.ShowDialog() == DialogResult.OK) {
				FileStream fileSeq = File.Open(of.FileName, FileMode.Open);
				try {
					anim = (Animation)new XmlSerializer(typeof(Animation)).Deserialize(fileSeq);
				}
				catch (Exception ex) {
					err = true;
					AddInfo("Erreur lecture animation : " + ex.Message);
				}
				fileSeq.Close();
			}
			int nbImage = anim.lstSeq.Count;
			if (!err)
				AddInfo("Animation chargée, " + nbImage + " images.");

			txbNbImages.Text = nbImage.ToString();
			txbExprX.Text = anim.exprPosX;
			txbExprY.Text = anim.exprPosY;
			txbExprZx.Text = anim.exprZoomX;
			txbExprZy.Text = anim.exprZoomY;
			txbExprAx.Text = anim.exprAngX;
			txbExprAy.Text = anim.exprAngY;
			txbExprAz.Text = anim.exprAngZ;
			txbNbImages.Text = anim.lstSeq.Count > 0 ? anim.lstSeq.Count.ToString() : txbNbImages.Text;
			rbSeqExpression.Checked = anim.withExpression;
			GenereSeq();
			DisplayFrame(0);
			InitBoutons();
		}

		private void BpSaveAnim_Click(object sender, EventArgs e) {
			bool err = false;
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers XML (*.XML)|*.xml" };
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Animation)).Serialize(file, anim);
				}
				catch (Exception ex) {
					err = true;
					AddInfo("Erreur sauvegarde animation : " + ex.Message);
				}
				file.Close();
				if (!err)
					AddInfo("Animation sauvegardée.");
			}
		}

		private void rbSeqIncrement_CheckedChanged(object sender, EventArgs e) {
			anim.withExpression = false;
			InitBoutons();
			GenereSeq();
		}

		private void rbSeqExpression_CheckedChanged(object sender, EventArgs e) {
			anim.withExpression = true;
			InitBoutons();
			GenereSeq();
		}
	}
}
