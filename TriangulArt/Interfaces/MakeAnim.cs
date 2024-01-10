using System;
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
		private Projet projet;
		private bool inAnim = false, endAnim = false;
		private int selAnim = 0;
		private List<Sequence> lstSeq = new List<Sequence>();

		public MakeAnim(Projet prj, ImageFond bf) {
			InitializeComponent();
			int width = prj.mode == 0 ? 192 : 384;
			bmpLock = new DirectBitmap(width, 272);
			bmpCalc = new DirectBitmap(width, 272);
			projet = prj;
			bmpFond = bf.NbImg > 0 ? bf.GetImage : null;
			InitInfoAnim();
		}

		private void InitInfoAnim() {
			txbExprX.Text = projet.lstAnim[selAnim].exprPosX == "" ? projet.mode == 0 ? "96" : "192" : projet.lstAnim[selAnim].exprPosX;
			txbExprY.Text = projet.lstAnim[selAnim].exprPosY == "" ? txbExprY.Text : projet.lstAnim[selAnim].exprPosY;
			txbExprZx.Text = projet.lstAnim[selAnim].exprZoomX == "" ? txbExprZx.Text : projet.lstAnim[selAnim].exprZoomX;
			txbExprZy.Text = projet.lstAnim[selAnim].exprZoomY == "" ? txbExprZy.Text : projet.lstAnim[selAnim].exprZoomY;
			txbExprAx.Text = projet.lstAnim[selAnim].exprAngX == "" ? txbExprAx.Text : projet.lstAnim[selAnim].exprAngX;
			txbExprAy.Text = projet.lstAnim[selAnim].exprAngY == "" ? txbExprAy.Text : projet.lstAnim[selAnim].exprAngY;
			txbExprAz.Text = projet.lstAnim[selAnim].exprAngZ == "" ? txbExprAz.Text : projet.lstAnim[selAnim].exprAngZ;
			txbNbImages.Text = projet.lstAnim[selAnim].nbImages > 0 ? projet.lstAnim[selAnim].nbImages.ToString() : txbNbImages.Text;
			txbNom.Text = projet.lstAnim[selAnim].nom;
			lblInfoAnim.Text = (selAnim + 1).ToString() + "/" + projet.lstAnim.Count.ToString();
			InitBoutons();
			GenereSeq();
			DisplayFrame(0);
		}

		private void InitBoutons() {
			bpAnimate.Enabled = bpWriteTriangle.Enabled = bpRedraw.Enabled = !inAnim && projet.lstAnim[selAnim].objet.lstFace.Count > 0 && projet.lstAnim[selAnim].nbImages > 0;
			bpStopAnim.Enabled = inAnim;
			bpFusion.Enabled = !inAnim && projet.lstData.Count == Utils.ToInt(txbNbImages.Text);
			bpReadObject.Enabled = bpEditObject.Enabled = bpReadAnim.Enabled = bpSaveAnim.Enabled = !inAnim;
			bpAnimPrec.Enabled = selAnim > 0;
			bpAnimSuiv.Enabled = selAnim < projet.lstAnim.Count - 1;
			bpDeleteAnim.Enabled = projet.lstAnim.Count > 1;
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

			if (index < lstSeq.Count) {
				Sequence s = lstSeq[index];
				projet.lstAnim[selAnim].objet.DrawObj(bmpLock, s.posx, s.posy, s.zoomx, s.zoomy, s.angx, s.angy, s.angz, -1, -1, lstTriangle, bmpCalc);
			}
			pictureBoxScr.Image = bmpLock.Bitmap;
			pictureBoxScr.Refresh();
		}

		private void GenereSeq() {
			// Génération séquence depuis expressions
			lstSeq.Clear();
			projet.lstAnim[selAnim].nbImages = Convert.ToInt32(txbNbImages.Text);
			projet.lstAnim[selAnim].exprPosX = txbExprX.Text;
			projet.lstAnim[selAnim].exprPosY = txbExprY.Text;
			projet.lstAnim[selAnim].exprZoomX = txbExprZx.Text;
			projet.lstAnim[selAnim].exprZoomY = txbExprZy.Text;
			projet.lstAnim[selAnim].exprAngX = txbExprAx.Text;
			projet.lstAnim[selAnim].exprAngY = txbExprAy.Text;
			projet.lstAnim[selAnim].exprAngZ = txbExprAz.Text;
			int nbImages = Utils.ToInt(txbNbImages.Text);
			for (int i = 0; i < nbImages; i++) {
				string err = projet.lstAnim[selAnim].AddEval(lstSeq);
				if (err != "") {
					AddInfo(err);
					break;
				}
			}
			trkIndex.Value = 0;
		}

		private void Animate(bool setProjet = false, bool fusion = false) {
			GenereSeq();
			if (setProjet && !fusion)
				projet.lstData.Clear();

			InitBoutons();
			for (int i = 0; i < lstSeq.Count && !endAnim; i++) {
				trkIndex.Value = i;
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
				else
					System.Threading.Thread.Sleep(20);
			}
			InitBoutons();
			if (setProjet) {
				int nbAvant = 0;
				int nbApres = 0;
				AddInfo("Nettoyage triangles non visibles...");
				projet.Clean(bmpLock.Width, ref nbAvant, ref nbApres);
				AddInfo("Nombre de triangles nettoyés : " + (nbAvant - nbApres).ToString());
				if (fusion)
					AddInfo("Fusion de " + lstSeq.Count.ToString() + " images avec le projet en cours.");
				else
					AddInfo("Création projet avec " + lstSeq.Count.ToString() + " images.");
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
				projet.lstAnim[selAnim].objet.ReadObject(projet, of.FileName, ref numPen);
				AddInfo("Objet " + Path.GetFileName(of.FileName) + " chargé. " + projet.lstAnim[selAnim].objet.lstFace.Count + " Faces.");
			}
			DisplayFrame(trkIndex.Value);
			InitBoutons();
		}

		private void BpEditObject_Click(object sender, EventArgs e) {
			Enabled = false;
			new EditObjet(projet, projet.lstAnim[selAnim].objet).ShowDialog();
			InitBoutons();
			DisplayFrame(trkIndex.Value);
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

		private void BpStopAnim_Click(object sender, EventArgs e) {
			endAnim = true;
			inAnim = false;
			InitBoutons();
		}

		private void BpWriteTriangle_Click(object sender, EventArgs e) {
			Enabled = false;
			endAnim = false;
			inAnim = false;
			Animate(true);
			Enabled = true;
		}

		private void BpFusion_Click(object sender, EventArgs e) {
			Enabled = false;
			endAnim = false;
			Animate(true, true);
			Enabled = true;
		}

		private void BpReadAnim_Click(object sender, EventArgs e) {
			bool err = false;
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers XML (*.XML)|*.xml" };
			if (of.ShowDialog() == DialogResult.OK) {
				FileStream fileSeq = File.Open(of.FileName, FileMode.Open);
				try {
					projet.lstAnim[selAnim] = (Animation)new XmlSerializer(typeof(Animation)).Deserialize(fileSeq);
					InitBoutons();
				}
				catch (Exception ex) {
					err = true;
					AddInfo("Erreur lecture animation : " + ex.Message);
				}
				fileSeq.Close();
			}
			if (!err) {
				AddInfo("Animation chargée, " + projet.lstAnim[selAnim].nbImages + " images.");
				txbNbImages.Text = projet.lstAnim[selAnim].nbImages.ToString();
				txbExprX.Text = projet.lstAnim[selAnim].exprPosX;
				txbExprY.Text = projet.lstAnim[selAnim].exprPosY;
				txbExprZx.Text = projet.lstAnim[selAnim].exprZoomX;
				txbExprZy.Text = projet.lstAnim[selAnim].exprZoomY;
				txbExprAx.Text = projet.lstAnim[selAnim].exprAngX;
				txbExprAy.Text = projet.lstAnim[selAnim].exprAngY;
				txbExprAz.Text = projet.lstAnim[selAnim].exprAngZ;
				txbNbImages.Text = lstSeq.Count > 0 ? lstSeq.Count.ToString() : txbNbImages.Text;
				txbNom.Text = projet.lstAnim[selAnim].nom;
				trkIndex.Maximum = Utils.ToInt(txbNbImages.Text) - 1;
				GenereSeq();
				DisplayFrame(0);
				InitBoutons();
			}
		}

		private void BpSaveAnim_Click(object sender, EventArgs e) {
			bool err = false;
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers XML (*.XML)|*.xml" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				GenereSeq();
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Animation)).Serialize(file, projet.lstAnim[selAnim]);
					InitBoutons();
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

		private void TxbNom_TextChanged(object sender, EventArgs e) {
			projet.lstAnim[selAnim].nom = txbNom.Text;
		}

		private void BpAnimPrec_Click(object sender, EventArgs e) {
			selAnim--;
			InitInfoAnim();
		}

		private void BpAnimSuiv_Click(object sender, EventArgs e) {
			selAnim++;
			InitInfoAnim();
		}

		private void BpAddAnimCopie_Click(object sender, EventArgs e) {
			Animation copie = new Animation {
				objet = projet.lstAnim[selAnim].objet,
				exprPosX = projet.lstAnim[selAnim].exprPosX,
				exprPosY = projet.lstAnim[selAnim].exprPosY,
				exprZoomX = projet.lstAnim[selAnim].exprZoomX,
				exprZoomY = projet.lstAnim[selAnim].exprZoomY,
				exprAngX = projet.lstAnim[selAnim].exprAngX,
				exprAngY = projet.lstAnim[selAnim].exprAngY,
				exprAngZ = projet.lstAnim[selAnim].exprAngZ,
				nbImages = projet.lstAnim[selAnim].nbImages,
				nom = projet.lstAnim[selAnim].nom
			};
			projet.lstAnim.Add(copie);
			selAnim++;
			InitInfoAnim();
		}

		private void BpAddAnim_Click(object sender, EventArgs e) {
			projet.lstAnim.Add(new Animation());
			selAnim++;
			InitInfoAnim();
		}

		private void BpDeleteAnim_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Confirmer la supperssion de cette animation", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				projet.lstAnim.RemoveAt(selAnim);
				if (selAnim >= projet.lstAnim.Count)
					selAnim--;

				InitInfoAnim();
			}
		}
	}
}
