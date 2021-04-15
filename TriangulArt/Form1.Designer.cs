namespace TriangulArt {
	partial class Form1 {
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent() {
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.lblInfoPos = new System.Windows.Forms.Label();
			this.bpAddTriangle = new System.Windows.Forms.Button();
			this.listInfo = new System.Windows.Forms.ListBox();
			this.bpLoad = new System.Windows.Forms.Button();
			this.bpSave = new System.Windows.Forms.Button();
			this.Color0 = new System.Windows.Forms.Label();
			this.Color1 = new System.Windows.Forms.Label();
			this.Color2 = new System.Windows.Forms.Label();
			this.Color3 = new System.Windows.Forms.Label();
			this.ColorSel = new System.Windows.Forms.Label();
			this.bpGenereAsm = new System.Windows.Forms.Button();
			this.bpAddCoord = new System.Windows.Forms.Button();
			this.txbX1 = new System.Windows.Forms.TextBox();
			this.txbY1 = new System.Windows.Forms.TextBox();
			this.txbX2 = new System.Windows.Forms.TextBox();
			this.txbY2 = new System.Windows.Forms.TextBox();
			this.txbX3 = new System.Windows.Forms.TextBox();
			this.txbY3 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.listTriangles = new System.Windows.Forms.ListBox();
			this.bpEdit = new System.Windows.Forms.Button();
			this.bpRedraw = new System.Windows.Forms.Button();
			this.bpDelete = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.chkPlus = new System.Windows.Forms.CheckBox();
			this.chkCodeAsm = new System.Windows.Forms.CheckBox();
			this.bpImport = new System.Windows.Forms.Button();
			this.bpImportImage = new System.Windows.Forms.Button();
			this.bpClear = new System.Windows.Forms.Button();
			this.bpMiroirHorizontal = new System.Windows.Forms.Button();
			this.bpMiroirVertical = new System.Windows.Forms.Button();
			this.bpUp = new System.Windows.Forms.Button();
			this.bpDown = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbStandard = new System.Windows.Forms.RadioButton();
			this.rbHorizontal = new System.Windows.Forms.RadioButton();
			this.rbVertical = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(6, 7);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(512, 512);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrtMouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrtMouseMove);
			// 
			// lblInfoPos
			// 
			this.lblInfoPos.AutoSize = true;
			this.lblInfoPos.Location = new System.Drawing.Point(524, 158);
			this.lblInfoPos.Name = "lblInfoPos";
			this.lblInfoPos.Size = new System.Drawing.Size(43, 13);
			this.lblInfoPos.TabIndex = 1;
			this.lblInfoPos.Text = "position";
			// 
			// bpAddTriangle
			// 
			this.bpAddTriangle.Location = new System.Drawing.Point(524, 183);
			this.bpAddTriangle.Name = "bpAddTriangle";
			this.bpAddTriangle.Size = new System.Drawing.Size(113, 23);
			this.bpAddTriangle.TabIndex = 2;
			this.bpAddTriangle.Text = "Ajouter triangle";
			this.bpAddTriangle.UseVisualStyleBackColor = true;
			this.bpAddTriangle.Click += new System.EventHandler(this.bpAddTriangle_Click);
			// 
			// listInfo
			// 
			this.listInfo.FormattingEnabled = true;
			this.listInfo.Location = new System.Drawing.Point(6, 582);
			this.listInfo.Name = "listInfo";
			this.listInfo.Size = new System.Drawing.Size(1027, 108);
			this.listInfo.TabIndex = 3;
			// 
			// bpLoad
			// 
			this.bpLoad.Location = new System.Drawing.Point(521, 7);
			this.bpLoad.Name = "bpLoad";
			this.bpLoad.Size = new System.Drawing.Size(116, 22);
			this.bpLoad.TabIndex = 4;
			this.bpLoad.Text = "Lire";
			this.bpLoad.UseVisualStyleBackColor = true;
			this.bpLoad.Click += new System.EventHandler(this.bpLoad_Click);
			// 
			// bpSave
			// 
			this.bpSave.Location = new System.Drawing.Point(521, 35);
			this.bpSave.Name = "bpSave";
			this.bpSave.Size = new System.Drawing.Size(116, 22);
			this.bpSave.TabIndex = 4;
			this.bpSave.Text = "Sauver";
			this.bpSave.UseVisualStyleBackColor = true;
			this.bpSave.Click += new System.EventHandler(this.bpSave_Click);
			// 
			// Color0
			// 
			this.Color0.BackColor = System.Drawing.Color.Transparent;
			this.Color0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color0.Location = new System.Drawing.Point(6, 522);
			this.Color0.Name = "Color0";
			this.Color0.Size = new System.Drawing.Size(82, 56);
			this.Color0.TabIndex = 5;
			this.Color0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color0_MouseClick);
			// 
			// Color1
			// 
			this.Color1.BackColor = System.Drawing.Color.Transparent;
			this.Color1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color1.Location = new System.Drawing.Point(149, 522);
			this.Color1.Name = "Color1";
			this.Color1.Size = new System.Drawing.Size(82, 56);
			this.Color1.TabIndex = 5;
			this.Color1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color1_MouseClick);
			// 
			// Color2
			// 
			this.Color2.BackColor = System.Drawing.Color.Transparent;
			this.Color2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color2.Location = new System.Drawing.Point(292, 522);
			this.Color2.Name = "Color2";
			this.Color2.Size = new System.Drawing.Size(82, 56);
			this.Color2.TabIndex = 5;
			this.Color2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color2_MouseClick);
			// 
			// Color3
			// 
			this.Color3.BackColor = System.Drawing.Color.Transparent;
			this.Color3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color3.Location = new System.Drawing.Point(435, 522);
			this.Color3.Name = "Color3";
			this.Color3.Size = new System.Drawing.Size(82, 56);
			this.Color3.TabIndex = 5;
			this.Color3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color3_MouseClick);
			// 
			// ColorSel
			// 
			this.ColorSel.BackColor = System.Drawing.Color.Transparent;
			this.ColorSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorSel.Location = new System.Drawing.Point(672, 500);
			this.ColorSel.Name = "ColorSel";
			this.ColorSel.Size = new System.Drawing.Size(82, 56);
			this.ColorSel.TabIndex = 5;
			// 
			// bpGenereAsm
			// 
			this.bpGenereAsm.Location = new System.Drawing.Point(521, 63);
			this.bpGenereAsm.Name = "bpGenereAsm";
			this.bpGenereAsm.Size = new System.Drawing.Size(116, 23);
			this.bpGenereAsm.TabIndex = 6;
			this.bpGenereAsm.Text = "Générer assembleur";
			this.bpGenereAsm.UseVisualStyleBackColor = true;
			this.bpGenereAsm.Click += new System.EventHandler(this.bpGenereAsm_Click);
			// 
			// bpAddCoord
			// 
			this.bpAddCoord.Location = new System.Drawing.Point(936, 484);
			this.bpAddCoord.Name = "bpAddCoord";
			this.bpAddCoord.Size = new System.Drawing.Size(94, 22);
			this.bpAddCoord.TabIndex = 7;
			this.bpAddCoord.Text = "Ajout direct";
			this.bpAddCoord.UseVisualStyleBackColor = true;
			this.bpAddCoord.Click += new System.EventHandler(this.bpAddCoord_Click);
			// 
			// txbX1
			// 
			this.txbX1.Location = new System.Drawing.Point(550, 459);
			this.txbX1.MaxLength = 3;
			this.txbX1.Name = "txbX1";
			this.txbX1.Size = new System.Drawing.Size(25, 20);
			this.txbX1.TabIndex = 8;
			// 
			// txbY1
			// 
			this.txbY1.Location = new System.Drawing.Point(619, 459);
			this.txbY1.MaxLength = 3;
			this.txbY1.Name = "txbY1";
			this.txbY1.Size = new System.Drawing.Size(25, 20);
			this.txbY1.TabIndex = 9;
			// 
			// txbX2
			// 
			this.txbX2.Location = new System.Drawing.Point(688, 459);
			this.txbX2.MaxLength = 3;
			this.txbX2.Name = "txbX2";
			this.txbX2.Size = new System.Drawing.Size(25, 20);
			this.txbX2.TabIndex = 10;
			// 
			// txbY2
			// 
			this.txbY2.Location = new System.Drawing.Point(757, 459);
			this.txbY2.MaxLength = 3;
			this.txbY2.Name = "txbY2";
			this.txbY2.Size = new System.Drawing.Size(25, 20);
			this.txbY2.TabIndex = 11;
			// 
			// txbX3
			// 
			this.txbX3.Location = new System.Drawing.Point(826, 459);
			this.txbX3.MaxLength = 3;
			this.txbX3.Name = "txbX3";
			this.txbX3.Size = new System.Drawing.Size(25, 20);
			this.txbX3.TabIndex = 12;
			// 
			// txbY3
			// 
			this.txbY3.Location = new System.Drawing.Point(895, 459);
			this.txbY3.MaxLength = 3;
			this.txbY3.Name = "txbY3";
			this.txbY3.Size = new System.Drawing.Size(25, 20);
			this.txbY3.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(531, 462);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "x1:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(600, 462);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "y1:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(669, 462);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "x2:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(738, 462);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "y2:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(807, 462);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(21, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "x3:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(876, 462);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "y3:";
			// 
			// listTriangles
			// 
			this.listTriangles.FormattingEnabled = true;
			this.listTriangles.Location = new System.Drawing.Point(521, 243);
			this.listTriangles.Name = "listTriangles";
			this.listTriangles.Size = new System.Drawing.Size(443, 186);
			this.listTriangles.TabIndex = 20;
			this.listTriangles.SelectedIndexChanged += new System.EventHandler(this.listTriangles_SelectedIndexChanged);
			// 
			// bpEdit
			// 
			this.bpEdit.Enabled = false;
			this.bpEdit.Location = new System.Drawing.Point(936, 459);
			this.bpEdit.Name = "bpEdit";
			this.bpEdit.Size = new System.Drawing.Size(94, 22);
			this.bpEdit.TabIndex = 7;
			this.bpEdit.Text = "Modifier";
			this.bpEdit.UseVisualStyleBackColor = true;
			this.bpEdit.Click += new System.EventHandler(this.bpEdit_Click);
			// 
			// bpRedraw
			// 
			this.bpRedraw.Location = new System.Drawing.Point(524, 212);
			this.bpRedraw.Name = "bpRedraw";
			this.bpRedraw.Size = new System.Drawing.Size(113, 25);
			this.bpRedraw.TabIndex = 21;
			this.bpRedraw.Text = "Redessiner";
			this.bpRedraw.UseVisualStyleBackColor = true;
			this.bpRedraw.Click += new System.EventHandler(this.bpRedraw_Click);
			// 
			// bpDelete
			// 
			this.bpDelete.Enabled = false;
			this.bpDelete.Location = new System.Drawing.Point(936, 435);
			this.bpDelete.Name = "bpDelete";
			this.bpDelete.Size = new System.Drawing.Size(94, 22);
			this.bpDelete.TabIndex = 22;
			this.bpDelete.Text = "Supprimer";
			this.bpDelete.UseVisualStyleBackColor = true;
			this.bpDelete.Click += new System.EventHandler(this.bpDelete_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(575, 522);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 13);
			this.label7.TabIndex = 23;
			this.label7.Text = "Couleur courante :";
			// 
			// chkPlus
			// 
			this.chkPlus.AutoSize = true;
			this.chkPlus.Location = new System.Drawing.Point(936, 539);
			this.chkPlus.Name = "chkPlus";
			this.chkPlus.Size = new System.Drawing.Size(89, 17);
			this.chkPlus.TabIndex = 24;
			this.chkPlus.Text = "Palette CPC+";
			this.chkPlus.UseVisualStyleBackColor = true;
			this.chkPlus.CheckedChanged += new System.EventHandler(this.chkPlus_CheckedChanged);
			// 
			// chkCodeAsm
			// 
			this.chkCodeAsm.AutoSize = true;
			this.chkCodeAsm.Location = new System.Drawing.Point(643, 67);
			this.chkCodeAsm.Name = "chkCodeAsm";
			this.chkCodeAsm.Size = new System.Drawing.Size(181, 17);
			this.chkCodeAsm.TabIndex = 25;
			this.chkCodeAsm.Text = "Ajouter code d\'affichage complet";
			this.chkCodeAsm.UseVisualStyleBackColor = true;
			// 
			// bpImport
			// 
			this.bpImport.Location = new System.Drawing.Point(715, 7);
			this.bpImport.Name = "bpImport";
			this.bpImport.Size = new System.Drawing.Size(139, 22);
			this.bpImport.TabIndex = 26;
			this.bpImport.Text = "Import data assembleur";
			this.bpImport.UseVisualStyleBackColor = true;
			this.bpImport.Click += new System.EventHandler(this.bpImport_Click);
			// 
			// bpImportImage
			// 
			this.bpImportImage.Location = new System.Drawing.Point(715, 35);
			this.bpImportImage.Name = "bpImportImage";
			this.bpImportImage.Size = new System.Drawing.Size(139, 22);
			this.bpImportImage.TabIndex = 27;
			this.bpImportImage.Text = "Import image fond";
			this.bpImportImage.UseVisualStyleBackColor = true;
			this.bpImportImage.Click += new System.EventHandler(this.bpImportImage_Click);
			// 
			// bpClear
			// 
			this.bpClear.Location = new System.Drawing.Point(909, 7);
			this.bpClear.Name = "bpClear";
			this.bpClear.Size = new System.Drawing.Size(116, 22);
			this.bpClear.TabIndex = 28;
			this.bpClear.Text = "Tout effacer";
			this.bpClear.UseVisualStyleBackColor = true;
			this.bpClear.Click += new System.EventHandler(this.bpClear_Click);
			// 
			// bpMiroirHorizontal
			// 
			this.bpMiroirHorizontal.Location = new System.Drawing.Point(909, 183);
			this.bpMiroirHorizontal.Name = "bpMiroirHorizontal";
			this.bpMiroirHorizontal.Size = new System.Drawing.Size(116, 23);
			this.bpMiroirHorizontal.TabIndex = 29;
			this.bpMiroirHorizontal.Text = "Miroir Horizontal";
			this.bpMiroirHorizontal.UseVisualStyleBackColor = true;
			this.bpMiroirHorizontal.Click += new System.EventHandler(this.bpMiroirHorizontal_Click);
			// 
			// bpMiroirVertical
			// 
			this.bpMiroirVertical.Location = new System.Drawing.Point(909, 214);
			this.bpMiroirVertical.Name = "bpMiroirVertical";
			this.bpMiroirVertical.Size = new System.Drawing.Size(116, 23);
			this.bpMiroirVertical.TabIndex = 30;
			this.bpMiroirVertical.Text = "Miroir Verticall";
			this.bpMiroirVertical.UseVisualStyleBackColor = true;
			this.bpMiroirVertical.Click += new System.EventHandler(this.bpMiroirVertical_Click);
			// 
			// bpUp
			// 
			this.bpUp.Location = new System.Drawing.Point(967, 243);
			this.bpUp.Name = "bpUp";
			this.bpUp.Size = new System.Drawing.Size(58, 27);
			this.bpUp.TabIndex = 31;
			this.bpUp.Text = "Up";
			this.bpUp.UseVisualStyleBackColor = true;
			this.bpUp.Visible = false;
			this.bpUp.Click += new System.EventHandler(this.bpUp_Click);
			// 
			// bpDown
			// 
			this.bpDown.Location = new System.Drawing.Point(972, 402);
			this.bpDown.Name = "bpDown";
			this.bpDown.Size = new System.Drawing.Size(58, 27);
			this.bpDown.TabIndex = 32;
			this.bpDown.Text = "Down";
			this.bpDown.UseVisualStyleBackColor = true;
			this.bpDown.Visible = false;
			this.bpDown.Click += new System.EventHandler(this.bpDown_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbVertical);
			this.groupBox1.Controls.Add(this.rbHorizontal);
			this.groupBox1.Controls.Add(this.rbStandard);
			this.groupBox1.Location = new System.Drawing.Point(527, 102);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(498, 42);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mod de rendu";
			// 
			// rbStandard
			// 
			this.rbStandard.AutoSize = true;
			this.rbStandard.Checked = true;
			this.rbStandard.Location = new System.Drawing.Point(9, 19);
			this.rbStandard.Name = "rbStandard";
			this.rbStandard.Size = new System.Drawing.Size(68, 17);
			this.rbStandard.TabIndex = 0;
			this.rbStandard.TabStop = true;
			this.rbStandard.Text = "Standard";
			this.rbStandard.UseVisualStyleBackColor = true;
			this.rbStandard.CheckedChanged += new System.EventHandler(this.rbStandard_CheckedChanged);
			// 
			// rbHorizontal
			// 
			this.rbHorizontal.AutoSize = true;
			this.rbHorizontal.Location = new System.Drawing.Point(116, 19);
			this.rbHorizontal.Name = "rbHorizontal";
			this.rbHorizontal.Size = new System.Drawing.Size(98, 17);
			this.rbHorizontal.TabIndex = 1;
			this.rbHorizontal.TabStop = true;
			this.rbHorizontal.Text = "Miroir horizontal";
			this.rbHorizontal.UseVisualStyleBackColor = true;
			this.rbHorizontal.CheckedChanged += new System.EventHandler(this.rbHorizontal_CheckedChanged);
			// 
			// rbVertical
			// 
			this.rbVertical.AutoSize = true;
			this.rbVertical.Enabled = false;
			this.rbVertical.Location = new System.Drawing.Point(253, 19);
			this.rbVertical.Name = "rbVertical";
			this.rbVertical.Size = new System.Drawing.Size(87, 17);
			this.rbVertical.TabIndex = 2;
			this.rbVertical.TabStop = true;
			this.rbVertical.Text = "Miroir vertical";
			this.rbVertical.UseVisualStyleBackColor = true;
			this.rbVertical.CheckedChanged += new System.EventHandler(this.rbVertical_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1038, 695);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bpDown);
			this.Controls.Add(this.bpUp);
			this.Controls.Add(this.bpMiroirVertical);
			this.Controls.Add(this.bpMiroirHorizontal);
			this.Controls.Add(this.bpClear);
			this.Controls.Add(this.bpImportImage);
			this.Controls.Add(this.bpImport);
			this.Controls.Add(this.chkCodeAsm);
			this.Controls.Add(this.chkPlus);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.bpDelete);
			this.Controls.Add(this.txbY3);
			this.Controls.Add(this.txbX3);
			this.Controls.Add(this.txbY2);
			this.Controls.Add(this.txbX2);
			this.Controls.Add(this.txbY1);
			this.Controls.Add(this.txbX1);
			this.Controls.Add(this.bpRedraw);
			this.Controls.Add(this.listTriangles);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bpEdit);
			this.Controls.Add(this.bpAddCoord);
			this.Controls.Add(this.bpGenereAsm);
			this.Controls.Add(this.Color3);
			this.Controls.Add(this.Color2);
			this.Controls.Add(this.Color1);
			this.Controls.Add(this.ColorSel);
			this.Controls.Add(this.Color0);
			this.Controls.Add(this.bpSave);
			this.Controls.Add(this.bpLoad);
			this.Controls.Add(this.listInfo);
			this.Controls.Add(this.bpAddTriangle);
			this.Controls.Add(this.lblInfoPos);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "TriangulArt";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label lblInfoPos;
		private System.Windows.Forms.Button bpAddTriangle;
		private System.Windows.Forms.ListBox listInfo;
		private System.Windows.Forms.Button bpLoad;
		private System.Windows.Forms.Button bpSave;
		private System.Windows.Forms.Label Color0;
		private System.Windows.Forms.Label Color1;
		private System.Windows.Forms.Label Color2;
		private System.Windows.Forms.Label Color3;
		private System.Windows.Forms.Label ColorSel;
		private System.Windows.Forms.Button bpGenereAsm;
		private System.Windows.Forms.Button bpAddCoord;
		private System.Windows.Forms.TextBox txbX1;
		private System.Windows.Forms.TextBox txbY1;
		private System.Windows.Forms.TextBox txbX2;
		private System.Windows.Forms.TextBox txbY2;
		private System.Windows.Forms.TextBox txbX3;
		private System.Windows.Forms.TextBox txbY3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListBox listTriangles;
		private System.Windows.Forms.Button bpEdit;
		private System.Windows.Forms.Button bpRedraw;
		private System.Windows.Forms.Button bpDelete;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkPlus;
		private System.Windows.Forms.CheckBox chkCodeAsm;
		private System.Windows.Forms.Button bpImport;
		private System.Windows.Forms.Button bpImportImage;
		private System.Windows.Forms.Button bpClear;
		private System.Windows.Forms.Button bpMiroirHorizontal;
		private System.Windows.Forms.Button bpMiroirVertical;
		private System.Windows.Forms.Button bpUp;
		private System.Windows.Forms.Button bpDown;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbVertical;
		private System.Windows.Forms.RadioButton rbHorizontal;
		private System.Windows.Forms.RadioButton rbStandard;
	}
}

