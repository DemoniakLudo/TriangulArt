namespace TriangulArt {
	partial class MakeAnim {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pictureBoxScr = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.bpReadObject = new System.Windows.Forms.Button();
			this.bpRedraw = new System.Windows.Forms.Button();
			this.bpAnimate = new System.Windows.Forms.Button();
			this.bpWriteTriangle = new System.Windows.Forms.Button();
			this.txbNbImages = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.bpEditObject = new System.Windows.Forms.Button();
			this.txbExprX = new System.Windows.Forms.TextBox();
			this.txbExprY = new System.Windows.Forms.TextBox();
			this.txbExprZx = new System.Windows.Forms.TextBox();
			this.txbExprZy = new System.Windows.Forms.TextBox();
			this.txbExprAx = new System.Windows.Forms.TextBox();
			this.txbExprAy = new System.Windows.Forms.TextBox();
			this.txbExprAz = new System.Windows.Forms.TextBox();
			this.bpReadAnim = new System.Windows.Forms.Button();
			this.bpSaveAnim = new System.Windows.Forms.Button();
			this.trkIndex = new System.Windows.Forms.TrackBar();
			this.lblNumImage = new System.Windows.Forms.Label();
			this.bpFusion = new System.Windows.Forms.Button();
			this.lstInfo = new System.Windows.Forms.ListBox();
			this.bpStopAnim = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txbNom = new System.Windows.Forms.TextBox();
			this.lblInfoAnim = new System.Windows.Forms.Label();
			this.bpAnimSuiv = new System.Windows.Forms.Button();
			this.bpAnimPrec = new System.Windows.Forms.Button();
			this.bpAddAnimCopie = new System.Windows.Forms.Button();
			this.bpAddAnim = new System.Windows.Forms.Button();
			this.bpDeleteAnim = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxScr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkIndex)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxScr
			// 
			this.pictureBoxScr.Location = new System.Drawing.Point(0, 32);
			this.pictureBoxScr.Name = "pictureBoxScr";
			this.pictureBoxScr.Size = new System.Drawing.Size(768, 544);
			this.pictureBoxScr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxScr.TabIndex = 0;
			this.pictureBoxScr.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(771, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "PositionX";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(771, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "PositionY";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(779, 193);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "ZoomX";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(779, 271);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "ZoomY";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(779, 347);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(41, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "AngleX";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(779, 421);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "AngleY";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(779, 499);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(41, 13);
			this.label11.TabIndex = 1;
			this.label11.Text = "AngleZ";
			// 
			// bpReadObject
			// 
			this.bpReadObject.Location = new System.Drawing.Point(0, 673);
			this.bpReadObject.Name = "bpReadObject";
			this.bpReadObject.Size = new System.Drawing.Size(115, 38);
			this.bpReadObject.TabIndex = 4;
			this.bpReadObject.Text = "Lire objet";
			this.bpReadObject.UseVisualStyleBackColor = true;
			this.bpReadObject.Click += new System.EventHandler(this.BpReadObject_Click);
			// 
			// bpRedraw
			// 
			this.bpRedraw.Location = new System.Drawing.Point(774, 553);
			this.bpRedraw.Name = "bpRedraw";
			this.bpRedraw.Size = new System.Drawing.Size(75, 23);
			this.bpRedraw.TabIndex = 5;
			this.bpRedraw.Text = "Redraw";
			this.bpRedraw.UseVisualStyleBackColor = true;
			this.bpRedraw.Click += new System.EventHandler(this.BpRedraw_Click);
			// 
			// bpAnimate
			// 
			this.bpAnimate.Location = new System.Drawing.Point(0, 719);
			this.bpAnimate.Name = "bpAnimate";
			this.bpAnimate.Size = new System.Drawing.Size(115, 38);
			this.bpAnimate.TabIndex = 6;
			this.bpAnimate.Text = "Animer";
			this.bpAnimate.UseVisualStyleBackColor = true;
			this.bpAnimate.Click += new System.EventHandler(this.BpAnimate_Click);
			// 
			// bpWriteTriangle
			// 
			this.bpWriteTriangle.Location = new System.Drawing.Point(0, 764);
			this.bpWriteTriangle.Name = "bpWriteTriangle";
			this.bpWriteTriangle.Size = new System.Drawing.Size(115, 38);
			this.bpWriteTriangle.TabIndex = 7;
			this.bpWriteTriangle.Text = "Générer nouveau  projet";
			this.bpWriteTriangle.UseVisualStyleBackColor = true;
			this.bpWriteTriangle.Click += new System.EventHandler(this.BpWriteTriangle_Click);
			// 
			// txbNbImages
			// 
			this.txbNbImages.Location = new System.Drawing.Point(785, 587);
			this.txbNbImages.Name = "txbNbImages";
			this.txbNbImages.Size = new System.Drawing.Size(37, 20);
			this.txbNbImages.TabIndex = 1;
			this.txbNbImages.Text = "30";
			this.txbNbImages.TextChanged += new System.EventHandler(this.TxbNbImages_TextChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(828, 590);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(41, 13);
			this.label15.TabIndex = 10;
			this.label15.Text = "Images";
			// 
			// bpEditObject
			// 
			this.bpEditObject.Location = new System.Drawing.Point(121, 673);
			this.bpEditObject.Name = "bpEditObject";
			this.bpEditObject.Size = new System.Drawing.Size(115, 38);
			this.bpEditObject.TabIndex = 11;
			this.bpEditObject.Text = "Editeur d\'objet";
			this.bpEditObject.UseVisualStyleBackColor = true;
			this.bpEditObject.Click += new System.EventHandler(this.BpEditObject_Click);
			// 
			// txbExprX
			// 
			this.txbExprX.Location = new System.Drawing.Point(824, 38);
			this.txbExprX.Name = "txbExprX";
			this.txbExprX.Size = new System.Drawing.Size(534, 20);
			this.txbExprX.TabIndex = 14;
			this.txbExprX.Text = "96";
			// 
			// txbExprY
			// 
			this.txbExprY.Location = new System.Drawing.Point(824, 114);
			this.txbExprY.Name = "txbExprY";
			this.txbExprY.Size = new System.Drawing.Size(534, 20);
			this.txbExprY.TabIndex = 14;
			this.txbExprY.Text = "100";
			// 
			// txbExprZx
			// 
			this.txbExprZx.Location = new System.Drawing.Point(824, 190);
			this.txbExprZx.Name = "txbExprZx";
			this.txbExprZx.Size = new System.Drawing.Size(534, 20);
			this.txbExprZx.TabIndex = 14;
			this.txbExprZx.Text = "10000";
			// 
			// txbExprZy
			// 
			this.txbExprZy.Location = new System.Drawing.Point(824, 266);
			this.txbExprZy.Name = "txbExprZy";
			this.txbExprZy.Size = new System.Drawing.Size(534, 20);
			this.txbExprZy.TabIndex = 14;
			this.txbExprZy.Text = "10000";
			// 
			// txbExprAx
			// 
			this.txbExprAx.Location = new System.Drawing.Point(824, 342);
			this.txbExprAx.Name = "txbExprAx";
			this.txbExprAx.Size = new System.Drawing.Size(534, 20);
			this.txbExprAx.TabIndex = 14;
			this.txbExprAx.Text = "75";
			// 
			// txbExprAy
			// 
			this.txbExprAy.Location = new System.Drawing.Point(824, 418);
			this.txbExprAy.Name = "txbExprAy";
			this.txbExprAy.Size = new System.Drawing.Size(534, 20);
			this.txbExprAy.TabIndex = 14;
			this.txbExprAy.Text = "img*12";
			// 
			// txbExprAz
			// 
			this.txbExprAz.Location = new System.Drawing.Point(824, 494);
			this.txbExprAz.Name = "txbExprAz";
			this.txbExprAz.Size = new System.Drawing.Size(534, 20);
			this.txbExprAz.TabIndex = 14;
			this.txbExprAz.Text = "15";
			// 
			// bpReadAnim
			// 
			this.bpReadAnim.Location = new System.Drawing.Point(0, 629);
			this.bpReadAnim.Name = "bpReadAnim";
			this.bpReadAnim.Size = new System.Drawing.Size(115, 38);
			this.bpReadAnim.TabIndex = 20;
			this.bpReadAnim.Text = "Lecture animation";
			this.bpReadAnim.UseVisualStyleBackColor = true;
			this.bpReadAnim.Click += new System.EventHandler(this.BpReadAnim_Click);
			// 
			// bpSaveAnim
			// 
			this.bpSaveAnim.Location = new System.Drawing.Point(121, 629);
			this.bpSaveAnim.Name = "bpSaveAnim";
			this.bpSaveAnim.Size = new System.Drawing.Size(115, 38);
			this.bpSaveAnim.TabIndex = 20;
			this.bpSaveAnim.Text = "Sauvegarde animation";
			this.bpSaveAnim.UseVisualStyleBackColor = true;
			this.bpSaveAnim.Click += new System.EventHandler(this.BpSaveAnim_Click);
			// 
			// trkIndex
			// 
			this.trkIndex.Location = new System.Drawing.Point(58, 582);
			this.trkIndex.Maximum = 29;
			this.trkIndex.Name = "trkIndex";
			this.trkIndex.Size = new System.Drawing.Size(712, 45);
			this.trkIndex.TabIndex = 21;
			this.trkIndex.Scroll += new System.EventHandler(this.TrkIndex_Scroll);
			// 
			// lblNumImage
			// 
			this.lblNumImage.AutoSize = true;
			this.lblNumImage.Location = new System.Drawing.Point(3, 587);
			this.lblNumImage.Name = "lblNumImage";
			this.lblNumImage.Size = new System.Drawing.Size(51, 13);
			this.lblNumImage.TabIndex = 22;
			this.lblNumImage.Text = "Image   0";
			// 
			// bpFusion
			// 
			this.bpFusion.Location = new System.Drawing.Point(121, 764);
			this.bpFusion.Name = "bpFusion";
			this.bpFusion.Size = new System.Drawing.Size(115, 38);
			this.bpFusion.TabIndex = 23;
			this.bpFusion.Text = "Fusion avec projet existant";
			this.bpFusion.UseVisualStyleBackColor = true;
			this.bpFusion.Click += new System.EventHandler(this.BpFusion_Click);
			// 
			// lstInfo
			// 
			this.lstInfo.FormattingEnabled = true;
			this.lstInfo.Location = new System.Drawing.Point(242, 629);
			this.lstInfo.Name = "lstInfo";
			this.lstInfo.Size = new System.Drawing.Size(1112, 173);
			this.lstInfo.TabIndex = 25;
			// 
			// bpStopAnim
			// 
			this.bpStopAnim.Enabled = false;
			this.bpStopAnim.Location = new System.Drawing.Point(121, 719);
			this.bpStopAnim.Name = "bpStopAnim";
			this.bpStopAnim.Size = new System.Drawing.Size(115, 38);
			this.bpStopAnim.TabIndex = 26;
			this.bpStopAnim.Text = "Stop Anim.";
			this.bpStopAnim.UseVisualStyleBackColor = true;
			this.bpStopAnim.Click += new System.EventHandler(this.BpStopAnim_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "Nom:";
			// 
			// txbNom
			// 
			this.txbNom.Location = new System.Drawing.Point(36, 6);
			this.txbNom.Name = "txbNom";
			this.txbNom.Size = new System.Drawing.Size(371, 20);
			this.txbNom.TabIndex = 28;
			this.txbNom.TextChanged += new System.EventHandler(this.TxbNom_TextChanged);
			// 
			// lblInfoAnim
			// 
			this.lblInfoAnim.Location = new System.Drawing.Point(535, 6);
			this.lblInfoAnim.Name = "lblInfoAnim";
			this.lblInfoAnim.Size = new System.Drawing.Size(44, 13);
			this.lblInfoAnim.TabIndex = 31;
			this.lblInfoAnim.Text = "label15";
			this.lblInfoAnim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// bpAnimSuiv
			// 
			this.bpAnimSuiv.Location = new System.Drawing.Point(584, 1);
			this.bpAnimSuiv.Name = "bpAnimSuiv";
			this.bpAnimSuiv.Size = new System.Drawing.Size(35, 23);
			this.bpAnimSuiv.TabIndex = 29;
			this.bpAnimSuiv.Text = ">>";
			this.bpAnimSuiv.UseVisualStyleBackColor = true;
			this.bpAnimSuiv.Click += new System.EventHandler(this.BpAnimSuiv_Click);
			// 
			// bpAnimPrec
			// 
			this.bpAnimPrec.Location = new System.Drawing.Point(496, 1);
			this.bpAnimPrec.Name = "bpAnimPrec";
			this.bpAnimPrec.Size = new System.Drawing.Size(35, 23);
			this.bpAnimPrec.TabIndex = 30;
			this.bpAnimPrec.Text = "<<";
			this.bpAnimPrec.UseVisualStyleBackColor = true;
			this.bpAnimPrec.Click += new System.EventHandler(this.BpAnimPrec_Click);
			// 
			// bpAddAnimCopie
			// 
			this.bpAddAnimCopie.Location = new System.Drawing.Point(682, 1);
			this.bpAddAnimCopie.Name = "bpAddAnimCopie";
			this.bpAddAnimCopie.Size = new System.Drawing.Size(167, 23);
			this.bpAddAnimCopie.TabIndex = 32;
			this.bpAddAnimCopie.Text = "Ajout anim. (Copie précédente)";
			this.bpAddAnimCopie.UseVisualStyleBackColor = true;
			this.bpAddAnimCopie.Click += new System.EventHandler(this.BpAddAnimCopie_Click);
			// 
			// bpAddAnim
			// 
			this.bpAddAnim.Location = new System.Drawing.Point(855, 1);
			this.bpAddAnim.Name = "bpAddAnim";
			this.bpAddAnim.Size = new System.Drawing.Size(167, 23);
			this.bpAddAnim.TabIndex = 32;
			this.bpAddAnim.Text = "Ajout anim. vide";
			this.bpAddAnim.UseVisualStyleBackColor = true;
			this.bpAddAnim.Click += new System.EventHandler(this.BpAddAnim_Click);
			// 
			// bpDeleteAnim
			// 
			this.bpDeleteAnim.Location = new System.Drawing.Point(1028, 1);
			this.bpDeleteAnim.Name = "bpDeleteAnim";
			this.bpDeleteAnim.Size = new System.Drawing.Size(167, 23);
			this.bpDeleteAnim.TabIndex = 32;
			this.bpDeleteAnim.Text = "Supprimer anim";
			this.bpDeleteAnim.UseVisualStyleBackColor = true;
			this.bpDeleteAnim.Click += new System.EventHandler(this.BpDeleteAnim_Click);
			// 
			// MakeAnim
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1360, 806);
			this.Controls.Add(this.bpDeleteAnim);
			this.Controls.Add(this.bpAddAnim);
			this.Controls.Add(this.bpAddAnimCopie);
			this.Controls.Add(this.lblInfoAnim);
			this.Controls.Add(this.bpAnimSuiv);
			this.Controls.Add(this.bpAnimPrec);
			this.Controls.Add(this.txbNom);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.bpStopAnim);
			this.Controls.Add(this.lstInfo);
			this.Controls.Add(this.bpFusion);
			this.Controls.Add(this.lblNumImage);
			this.Controls.Add(this.trkIndex);
			this.Controls.Add(this.bpSaveAnim);
			this.Controls.Add(this.bpReadAnim);
			this.Controls.Add(this.txbExprAz);
			this.Controls.Add(this.txbExprAy);
			this.Controls.Add(this.txbExprAx);
			this.Controls.Add(this.txbExprZy);
			this.Controls.Add(this.txbExprZx);
			this.Controls.Add(this.txbExprY);
			this.Controls.Add(this.txbExprX);
			this.Controls.Add(this.bpEditObject);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.txbNbImages);
			this.Controls.Add(this.bpWriteTriangle);
			this.Controls.Add(this.bpAnimate);
			this.Controls.Add(this.bpRedraw);
			this.Controls.Add(this.bpReadObject);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBoxScr);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MakeAnim";
			this.Text = "MakeAnim";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxScr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkIndex)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxScr;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button bpReadObject;
		private System.Windows.Forms.Button bpRedraw;
		private System.Windows.Forms.Button bpAnimate;
		private System.Windows.Forms.Button bpWriteTriangle;
		private System.Windows.Forms.TextBox txbNbImages;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button bpEditObject;
		private System.Windows.Forms.TextBox txbExprX;
		private System.Windows.Forms.TextBox txbExprY;
		private System.Windows.Forms.TextBox txbExprZx;
		private System.Windows.Forms.TextBox txbExprZy;
		private System.Windows.Forms.TextBox txbExprAx;
		private System.Windows.Forms.TextBox txbExprAy;
		private System.Windows.Forms.TextBox txbExprAz;
		private System.Windows.Forms.Button bpReadAnim;
		private System.Windows.Forms.Button bpSaveAnim;
		private System.Windows.Forms.TrackBar trkIndex;
		private System.Windows.Forms.Label lblNumImage;
		private System.Windows.Forms.Button bpFusion;
		private System.Windows.Forms.ListBox lstInfo;
		private System.Windows.Forms.Button bpStopAnim;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txbNom;
		private System.Windows.Forms.Label lblInfoAnim;
		private System.Windows.Forms.Button bpAnimSuiv;
		private System.Windows.Forms.Button bpAnimPrec;
		private System.Windows.Forms.Button bpAddAnimCopie;
		private System.Windows.Forms.Button bpAddAnim;
		private System.Windows.Forms.Button bpDeleteAnim;
	}
}