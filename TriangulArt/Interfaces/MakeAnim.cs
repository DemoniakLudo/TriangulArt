﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class MakeAnim : Form {
		private DirectBitmap bmpLock, bmpCalc;
		private Bitmap bmpFond;
		private Projet projet;
		private bool inAnim = false, endAnim = false;
		private int selAnim = 0;
		private List<Sequence> lstSeq = new List<Sequence>();
		private int maxPen = 15;
		private CpcEmul cpc;

		public MakeAnim(Projet prj, CpcEmul cpc, ImageFond bf) {
			InitializeComponent();
			int width = prj.mode == 0 ? 192 : 384;
			bmpLock = new DirectBitmap(width, 272);
			bmpCalc = new DirectBitmap(width, 272);
			projet = prj;
			this.cpc = cpc;
			bmpFond = bf.NbImg > 0 ? bf.GetImage : null;
			chkImportPalette.Checked = chkImportPalette.Visible = prj.cpcPlus;
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
			bpAnimate.Enabled = bpCreateProjet.Enabled = bpRedraw.Enabled = !inAnim && projet.lstAnim[selAnim].objet.lstFace.Count > 0 && projet.lstAnim[selAnim].nbImages > 0;
			bpStopAnim.Enabled = inAnim;
			bpFusionProjet.Enabled = !inAnim && projet.lstData.Count == Utils.ToInt(txbNbImages.Text);
			bpAddProjet.Enabled = !inAnim && projet.lstData.Count > 0;
			bpReadObject.Enabled = bpEditObject.Enabled = bpReadAnim.Enabled = bpSaveAnim.Enabled = !inAnim;
			bpAnimPrec.Enabled = selAnim > 0;
			bpAnimSuiv.Enabled = selAnim < projet.lstAnim.Count - 1;
			bpDeleteAnim.Enabled = projet.lstAnim.Count > 1;
		}

		private void AddInfo(string msg) {
			lstInfo.Items.Add(msg);
			lstInfo.SelectedIndex = lstInfo.Items.Count - 1;
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

		private int DisplayFrame(int index, List<Triangle> lstTriangle = null, bool noDraw = false) {
			int ret = 0;
			lblNumImage.Text = "Image " + String.Format("{0,3}", index);
			if (!noDraw) {
				bmpLock.Fill(PaletteCpc.GetColorPal(0).GetColorArgb);
				if (bmpFond != null)
					bmpLock.Copy(bmpFond);
			}

			if (lstTriangle != null)
				bmpCalc.Fill(0xFFFFFF);

			if (index < lstSeq.Count) {
				Sequence s = lstSeq[index];
				ret = projet.lstAnim[selAnim].objet.DrawObj(noDraw ? null : bmpLock, s.posx, s.posy, s.zoomx, s.zoomy, s.angx, s.angy, s.angz, -1, -1, lstTriangle, bmpCalc);
			}
			pictureBoxScr.Image = bmpLock.Bitmap;
			pictureBoxScr.Refresh();
			return ret;
		}

		private int CreateFrame(int i, bool setProjet, bool fusion, List<Datas> lstData = null, bool noDraw = false, bool addProjet = false) {
			int nbTri = 0;
			List<Triangle> lstTriangle = new List<Triangle>();
			DisplayFrame(i, lstTriangle, noDraw);
			Datas data = lstData != null ? lstData[i] : fusion ? projet.lstData[i] : new Datas();
			if (!noDraw) {
				trkIndex.Value = i;
				Application.DoEvents();
				if (setProjet)
					data.nomImage = "Frame_" + i.ToString();
			}
			for (int t = 0; t < lstTriangle.Count; t++) {
				bool triangleOk = false;
				for (int y = 0; y < bmpCalc.Height; y++) {
					for (int x = 0; x < bmpCalc.Width; x++)
						if (bmpCalc.GetPixel(x, y) == t) {
							triangleOk = true;
							y = bmpCalc.Height;
							nbTri++;
							break;
						}
				}
				Triangle tr = lstTriangle[t];
				double maxY = projet.tailleColonnes == 64 ? 256 : projet.tailleColonnes == 80 ? 200 : 168;
				if (tr.y1 < maxY) {
					if (tr.y2 > maxY) {
						double deltax = tr.x2 - tr.x1;
						double div = tr.y2 / maxY;
						deltax = deltax / div;
						tr.x2 = tr.x1 + (int)deltax;
						tr.y2 = (int)maxY;
					}
					if (tr.y3 > maxY) {
						double deltax = tr.x3 - tr.x1;
						double div = tr.y3 / maxY;
						deltax = deltax / div;
						tr.x3 = tr.x1 + (int)deltax;
						tr.y3 = (int)maxY;
					}

					if (tr.x1 < 0 && tr.x2 < 0 && tr.x3 < 0)
						triangleOk = false;
					else {
						if (tr.x1 < 0)
							tr.x1 = 0;

						if (tr.x2 < 0)
							tr.x2 = 0;

						if (tr.x3 < 0)
							tr.x3 = 0;
					}
				}
				tr.enabled = triangleOk;
				if (setProjet)
					data.lstTriangle.Add(new Triangle(tr.x1, tr.y1, tr.x2, tr.y2, tr.x3, tr.y3, tr.color, null, tr.enabled));
			}
			if (setProjet && !fusion)
				projet.lstData.Add(data);

			return nbTri;
		}

		private void Animate(bool setProjet = false, bool fusion = false, bool add = false) {
			GenereSeq();
			if (setProjet && !fusion && !add)
				projet.lstData.Clear();

			int nbTri = 0;
			for (int i = 0; i < lstSeq.Count && !endAnim; i++)
				nbTri += CreateFrame(i, setProjet, fusion, null, false, add);

			AddInfo("Nbre de triangles de l'animation:" + nbTri.ToString());
			if (setProjet) {
				if (fusion)
					AddInfo("Fusion de " + lstSeq.Count.ToString() + " images avec le projet en cours.");
				else
					if (add)
						AddInfo("Ajout de " + lstSeq.Count.ToString() + " images au projet.");
					else
						AddInfo("Création projet avec " + lstSeq.Count.ToString() + " images.");
			}
			InitBoutons();
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
				int numPen = chkImportPalette.Checked ? maxPen : 0;
				projet.lstAnim[selAnim].objet.ReadObject(projet, of.FileName, ref numPen);
				if (chkImportPalette.Checked)
					maxPen = numPen;

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
			InitBoutons();
			lstInfo.Items.Clear();
			while (!endAnim) {
				Animate();
			}
		}

		private void BpStopAnim_Click(object sender, EventArgs e) {
			endAnim = true;
			inAnim = false;
			InitBoutons();
		}

		private void BpCreateProjet_Click(object sender, EventArgs e) {
			lstInfo.Items.Clear();
			Enabled = false;
			endAnim = inAnim = false;
			lstInfo.Items.Clear();
			Animate(true);
			Enabled = true;
		}

		private void BpFusionProjet_Click(object sender, EventArgs e) {
			lstInfo.Items.Clear();
			Enabled = false;
			endAnim = false;
			lstInfo.Items.Clear();
			Animate(true, true);
			Enabled = true;
		}


		private void bpAddProjet_Click(object sender, EventArgs e) {
			lstInfo.Items.Clear();
			Enabled = false;
			endAnim = false;
			lstInfo.Items.Clear();
			Animate(true, false, true);
			Enabled = true;

		}

		private void BpReadAnim_Click(object sender, EventArgs e) {
			bool err = false;
			lstInfo.Items.Clear();
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

		private void BpSaveGif_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Gif anim (*.gif)|*.gif" };
			if (dlg.ShowDialog() == DialogResult.OK) {
				GenereSeq();
				InitBoutons();
				try {
					DirectBitmap tmp = new DirectBitmap(384, 272);
					byte[] GifAnimation = { 33, 255, 11, 78, 69, 84, 83, 67, 65, 80, 69, 50, 46, 48, 3, 1, 0, 0, 0 };
					byte[] tabByte = null;
					MemoryStream ms = new MemoryStream();
					BinaryWriter bWr = new BinaryWriter(new FileStream(dlg.FileName, FileMode.Create));
					for (int i = 0; i < lstSeq.Count; i++) {
						DisplayFrame(i);
						Graphics.FromImage(tmp.Bitmap).DrawImage(bmpLock.Bitmap, 0, 0, tmp.Width, tmp.Height);
						ms.SetLength(0);
						tmp.Bitmap.Save(ms, ImageFormat.Gif);
						tabByte = ms.ToArray();
						if (i == 0) {
							tabByte[10] = (byte)(tabByte[10] & 0X78); //No global color table
							bWr.Write(tabByte, 0, 13);
							bWr.Write(GifAnimation);
						}
						tabByte[785] = 5; // Temps d'affichage
						tabByte[786] = 0;
						tabByte[798] = (byte)(tabByte[798] | 0x87);
						bWr.Write(tabByte, 781, 18);
						bWr.Write(tabByte, 13, 768);
						bWr.Write(tabByte, 799, tabByte.Length - 800);
					}
					tmp.Dispose();
					bWr.Write(tabByte[tabByte.Length - 1]);
					bWr.Close();
					ms.Dispose();
				}
				catch (Exception ex) {
					AddInfo("Erreur sauvegarde GIF : " + ex.Message);
				}
			}
		}

		private void BpCpcEmul_Click(object sender, EventArgs e) {
			Enabled = false;
			AddInfo("Préparation données pour émulation...");
			Application.DoEvents();
			GenereSeq();
			List<Datas> lstData = new List<Datas>();
			for (int f = 0; f < lstSeq.Count; f++) {
				lstData.Add(new Datas());
				CreateFrame(f, true, false, lstData, true);
			}
			AddInfo("Démarrage émulation...");
			Application.DoEvents();
			cpc.Run(projet.tailleColonnes, lstData);
			Enabled = true;
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
