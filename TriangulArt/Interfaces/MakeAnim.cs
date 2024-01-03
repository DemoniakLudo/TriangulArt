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
            bpAnimate.Enabled = bpWriteTriangle.Enabled = bpRedraw.Enabled = !inAnim && anim.objet.lstFace.Count > 0 && anim.lstSeq.Count > 0;
            bpStopAnim.Enabled = inAnim;
            bpFusion.Enabled = !inAnim && projet.lstData.Count == Utils.ToInt(txbNbImages.Text);
            bpReadObject.Enabled = bpEditObject.Enabled = bpReadAnim.Enabled = bpSaveAnim.Enabled = !inAnim;
            txbPx.Enabled = txbPy.Enabled = txbZx.Enabled = txbZy.Enabled = txbAx.Enabled = txbAy.Enabled = txbAz.Enabled =
            txbIncPx.Enabled = txbIncPy.Enabled = txbIncZx.Enabled = txbIncZy.Enabled = txbIncAx.Enabled = txbIncAy.Enabled = txbIncAz.Enabled = rbSeqIncrement.Checked;
            txbExprX.Enabled = txbExprY.Enabled = txbExprZx.Enabled = txbExprZy.Enabled = txbExprAx.Enabled = txbExprAy.Enabled = txbExprAz.Enabled = rbSeqExpression.Checked;
            Text = "MakeAnim" + (String.IsNullOrEmpty(anim.Nom) ? "" : (" - " + anim.Nom));
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

            if (index < anim.lstSeq.Count) {
                Sequence s = anim.lstSeq[index];
                anim.objet.DrawObj(bmpLock, s.posx, s.posy, s.zoomx, s.zoomy, s.angx, s.angy, s.angz, -1, -1, lstTriangle, bmpCalc);
            }
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
                int nbImages = Utils.ToInt(txbNbImages.Text);
                for (int i = 0; i < nbImages; i++) {
                    string err = anim.AddEval();
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
            for (int i = 0; i < anim.lstSeq.Count && !endAnim; i++) {
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
                    anim = (Animation)new XmlSerializer(typeof(Animation)).Deserialize(fileSeq);
                    anim.Nom = Path.GetFileName(of.FileName);
                    InitBoutons();
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
            trkIndex.Maximum = Utils.ToInt(txbNbImages.Text) - 1;
            rbSeqExpression.Checked = anim.withExpression;
            GenereSeq();
            DisplayFrame(0);
            InitBoutons();
        }

        private void BpSaveAnim_Click(object sender, EventArgs e) {
            bool err = false;
            SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers XML (*.XML)|*.xml" };
            if (dlg.ShowDialog() == DialogResult.OK) {
                GenereSeq();
                FileStream file = File.Open(dlg.FileName, FileMode.Create);
                try {
                    new XmlSerializer(typeof(Animation)).Serialize(file, anim);
                    anim.Nom = Path.GetFileName(dlg.FileName);
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

        private void RbSeqIncrement_CheckedChanged(object sender, EventArgs e) {
            anim.withExpression = false;
            InitBoutons();
            GenereSeq();
        }

        private void RbSeqExpression_CheckedChanged(object sender, EventArgs e) {
            anim.withExpression = true;
            InitBoutons();
            GenereSeq();
        }
    }
}
