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
			this.txbY1 = new System.Windows.Forms.TextBox();
			this.txbX2 = new System.Windows.Forms.TextBox();
			this.txbY2 = new System.Windows.Forms.TextBox();
			this.txbX3 = new System.Windows.Forms.TextBox();
			this.txbY3 = new System.Windows.Forms.TextBox();
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
			this.bpUp = new System.Windows.Forms.Button();
			this.bpDown = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbVertical = new System.Windows.Forms.RadioButton();
			this.rbHorizontal = new System.Windows.Forms.RadioButton();
			this.rbStandard = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bpDeplace = new System.Windows.Forms.Button();
			this.txbTrY = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.bpZoom = new System.Windows.Forms.Button();
			this.txbTrX = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.rbDepImage = new System.Windows.Forms.RadioButton();
			this.rbDepTriangle = new System.Windows.Forms.RadioButton();
			this.lblInfoVersion = new System.Windows.Forms.Label();
			this.chkClearData = new System.Windows.Forms.CheckBox();
			this.bpClearList = new System.Windows.Forms.Button();
			this.bpClean = new System.Windows.Forms.Button();
			this.bpRapproche = new System.Windows.Forms.Button();
			this.bpAjoutQuadri = new System.Windows.Forms.Button();
			this.txbY4 = new System.Windows.Forms.TextBox();
			this.txbX4 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txbTpsAttente = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txbX1 = new System.Windows.Forms.TextBox();
			this.txbPos = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.chkCenterZoom = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(768, 768);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrtMouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// lblInfoPos
			// 
			this.lblInfoPos.AutoSize = true;
			this.lblInfoPos.Location = new System.Drawing.Point(869, 145);
			this.lblInfoPos.Name = "lblInfoPos";
			this.lblInfoPos.Size = new System.Drawing.Size(43, 13);
			this.lblInfoPos.TabIndex = 1;
			this.lblInfoPos.Text = "position";
			// 
			// bpAddTriangle
			// 
			this.bpAddTriangle.Location = new System.Drawing.Point(866, 167);
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
			this.listInfo.Location = new System.Drawing.Point(855, 632);
			this.listInfo.Name = "listInfo";
			this.listInfo.Size = new System.Drawing.Size(663, 108);
			this.listInfo.TabIndex = 3;
			// 
			// bpLoad
			// 
			this.bpLoad.Location = new System.Drawing.Point(866, 9);
			this.bpLoad.Name = "bpLoad";
			this.bpLoad.Size = new System.Drawing.Size(116, 22);
			this.bpLoad.TabIndex = 4;
			this.bpLoad.Text = "Lire";
			this.bpLoad.UseVisualStyleBackColor = true;
			this.bpLoad.Click += new System.EventHandler(this.bpLoad_Click);
			// 
			// bpSave
			// 
			this.bpSave.Location = new System.Drawing.Point(866, 37);
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
			this.Color0.Location = new System.Drawing.Point(774, 9);
			this.Color0.Name = "Color0";
			this.Color0.Size = new System.Drawing.Size(82, 56);
			this.Color0.TabIndex = 5;
			this.Color0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color0_MouseClick);
			// 
			// Color1
			// 
			this.Color1.BackColor = System.Drawing.Color.Transparent;
			this.Color1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color1.Location = new System.Drawing.Point(774, 105);
			this.Color1.Name = "Color1";
			this.Color1.Size = new System.Drawing.Size(82, 56);
			this.Color1.TabIndex = 5;
			this.Color1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color1_MouseClick);
			// 
			// Color2
			// 
			this.Color2.BackColor = System.Drawing.Color.Transparent;
			this.Color2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color2.Location = new System.Drawing.Point(774, 201);
			this.Color2.Name = "Color2";
			this.Color2.Size = new System.Drawing.Size(82, 56);
			this.Color2.TabIndex = 5;
			this.Color2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color2_MouseClick);
			// 
			// Color3
			// 
			this.Color3.BackColor = System.Drawing.Color.Transparent;
			this.Color3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color3.Location = new System.Drawing.Point(774, 297);
			this.Color3.Name = "Color3";
			this.Color3.Size = new System.Drawing.Size(82, 56);
			this.Color3.TabIndex = 5;
			this.Color3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Color3_MouseClick);
			// 
			// ColorSel
			// 
			this.ColorSel.BackColor = System.Drawing.Color.Transparent;
			this.ColorSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorSel.Location = new System.Drawing.Point(950, 558);
			this.ColorSel.Name = "ColorSel";
			this.ColorSel.Size = new System.Drawing.Size(82, 56);
			this.ColorSel.TabIndex = 5;
			// 
			// bpGenereAsm
			// 
			this.bpGenereAsm.Location = new System.Drawing.Point(866, 65);
			this.bpGenereAsm.Name = "bpGenereAsm";
			this.bpGenereAsm.Size = new System.Drawing.Size(116, 23);
			this.bpGenereAsm.TabIndex = 6;
			this.bpGenereAsm.Text = "Générer assembleur";
			this.bpGenereAsm.UseVisualStyleBackColor = true;
			this.bpGenereAsm.Click += new System.EventHandler(this.bpGenereAsm_Click);
			// 
			// bpAddCoord
			// 
			this.bpAddCoord.Location = new System.Drawing.Point(1398, 542);
			this.bpAddCoord.Name = "bpAddCoord";
			this.bpAddCoord.Size = new System.Drawing.Size(108, 22);
			this.bpAddCoord.TabIndex = 7;
			this.bpAddCoord.Text = "Ajout direct";
			this.bpAddCoord.UseVisualStyleBackColor = true;
			this.bpAddCoord.Click += new System.EventHandler(this.bpAddCoord_Click);
			// 
			// txbY1
			// 
			this.txbY1.Location = new System.Drawing.Point(1026, 495);
			this.txbY1.MaxLength = 3;
			this.txbY1.Name = "txbY1";
			this.txbY1.Size = new System.Drawing.Size(25, 20);
			this.txbY1.TabIndex = 9;
			// 
			// txbX2
			// 
			this.txbX2.Location = new System.Drawing.Point(1083, 495);
			this.txbX2.MaxLength = 3;
			this.txbX2.Name = "txbX2";
			this.txbX2.Size = new System.Drawing.Size(25, 20);
			this.txbX2.TabIndex = 10;
			// 
			// txbY2
			// 
			this.txbY2.Location = new System.Drawing.Point(1140, 495);
			this.txbY2.MaxLength = 3;
			this.txbY2.Name = "txbY2";
			this.txbY2.Size = new System.Drawing.Size(25, 20);
			this.txbY2.TabIndex = 11;
			// 
			// txbX3
			// 
			this.txbX3.Location = new System.Drawing.Point(1197, 495);
			this.txbX3.MaxLength = 3;
			this.txbX3.Name = "txbX3";
			this.txbX3.Size = new System.Drawing.Size(25, 20);
			this.txbX3.TabIndex = 12;
			// 
			// txbY3
			// 
			this.txbY3.Location = new System.Drawing.Point(1254, 495);
			this.txbY3.MaxLength = 3;
			this.txbY3.Name = "txbY3";
			this.txbY3.Size = new System.Drawing.Size(25, 20);
			this.txbY3.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1007, 498);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "y1:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1064, 498);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "x2:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1121, 498);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "y2:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(1178, 498);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(21, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "x3:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1235, 498);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "y3:";
			// 
			// listTriangles
			// 
			this.listTriangles.FormattingEnabled = true;
			this.listTriangles.Location = new System.Drawing.Point(866, 263);
			this.listTriangles.Name = "listTriangles";
			this.listTriangles.Size = new System.Drawing.Size(584, 225);
			this.listTriangles.TabIndex = 20;
			this.listTriangles.SelectedIndexChanged += new System.EventHandler(this.listTriangles_SelectedIndexChanged);
			// 
			// bpEdit
			// 
			this.bpEdit.Enabled = false;
			this.bpEdit.Location = new System.Drawing.Point(1398, 517);
			this.bpEdit.Name = "bpEdit";
			this.bpEdit.Size = new System.Drawing.Size(108, 22);
			this.bpEdit.TabIndex = 7;
			this.bpEdit.Text = "Modifier";
			this.bpEdit.UseVisualStyleBackColor = true;
			this.bpEdit.Click += new System.EventHandler(this.bpEdit_Click);
			// 
			// bpRedraw
			// 
			this.bpRedraw.Location = new System.Drawing.Point(866, 232);
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
			this.bpDelete.Location = new System.Drawing.Point(1398, 493);
			this.bpDelete.Name = "bpDelete";
			this.bpDelete.Size = new System.Drawing.Size(108, 22);
			this.bpDelete.TabIndex = 22;
			this.bpDelete.Text = "Supprimer";
			this.bpDelete.UseVisualStyleBackColor = true;
			this.bpDelete.Click += new System.EventHandler(this.bpDelete_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(855, 580);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 13);
			this.label7.TabIndex = 23;
			this.label7.Text = "Couleur courante :";
			// 
			// chkPlus
			// 
			this.chkPlus.AutoSize = true;
			this.chkPlus.Location = new System.Drawing.Point(1398, 597);
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
			this.chkCodeAsm.Location = new System.Drawing.Point(988, 69);
			this.chkCodeAsm.Name = "chkCodeAsm";
			this.chkCodeAsm.Size = new System.Drawing.Size(181, 17);
			this.chkCodeAsm.TabIndex = 25;
			this.chkCodeAsm.Text = "Ajouter code d\'affichage complet";
			this.chkCodeAsm.UseVisualStyleBackColor = true;
			// 
			// bpImport
			// 
			this.bpImport.Location = new System.Drawing.Point(1060, 9);
			this.bpImport.Name = "bpImport";
			this.bpImport.Size = new System.Drawing.Size(139, 22);
			this.bpImport.TabIndex = 26;
			this.bpImport.Text = "Import data assembleur";
			this.bpImport.UseVisualStyleBackColor = true;
			this.bpImport.Click += new System.EventHandler(this.bpImport_Click);
			// 
			// bpImportImage
			// 
			this.bpImportImage.Location = new System.Drawing.Point(1060, 37);
			this.bpImportImage.Name = "bpImportImage";
			this.bpImportImage.Size = new System.Drawing.Size(139, 22);
			this.bpImportImage.TabIndex = 27;
			this.bpImportImage.Text = "Import image fond";
			this.bpImportImage.UseVisualStyleBackColor = true;
			this.bpImportImage.Click += new System.EventHandler(this.bpImportImage_Click);
			// 
			// bpClear
			// 
			this.bpClear.Location = new System.Drawing.Point(1273, 69);
			this.bpClear.Name = "bpClear";
			this.bpClear.Size = new System.Drawing.Size(116, 22);
			this.bpClear.TabIndex = 28;
			this.bpClear.Text = "Tout effacer";
			this.bpClear.UseVisualStyleBackColor = true;
			this.bpClear.Click += new System.EventHandler(this.bpClear_Click);
			// 
			// bpUp
			// 
			this.bpUp.Location = new System.Drawing.Point(1456, 263);
			this.bpUp.Name = "bpUp";
			this.bpUp.Size = new System.Drawing.Size(50, 27);
			this.bpUp.TabIndex = 31;
			this.bpUp.Text = "Up";
			this.bpUp.UseVisualStyleBackColor = true;
			this.bpUp.Visible = false;
			this.bpUp.Click += new System.EventHandler(this.bpUp_Click);
			// 
			// bpDown
			// 
			this.bpDown.Location = new System.Drawing.Point(1456, 460);
			this.bpDown.Name = "bpDown";
			this.bpDown.Size = new System.Drawing.Size(50, 27);
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
			this.groupBox1.Location = new System.Drawing.Point(872, 97);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(517, 42);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mode de rendu";
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
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkCenterZoom);
			this.groupBox2.Controls.Add(this.bpDeplace);
			this.groupBox2.Controls.Add(this.txbTrY);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.bpZoom);
			this.groupBox2.Controls.Add(this.txbTrX);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.rbDepImage);
			this.groupBox2.Controls.Add(this.rbDepTriangle);
			this.groupBox2.Location = new System.Drawing.Point(1002, 145);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(448, 73);
			this.groupBox2.TabIndex = 34;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Opération spéciale";
			// 
			// bpDeplace
			// 
			this.bpDeplace.Location = new System.Drawing.Point(238, 16);
			this.bpDeplace.Name = "bpDeplace";
			this.bpDeplace.Size = new System.Drawing.Size(106, 24);
			this.bpDeplace.TabIndex = 18;
			this.bpDeplace.Text = "Déplacement relatif";
			this.bpDeplace.UseVisualStyleBackColor = true;
			this.bpDeplace.Click += new System.EventHandler(this.bpDeplace_Click);
			// 
			// txbTrY
			// 
			this.txbTrY.Location = new System.Drawing.Point(172, 45);
			this.txbTrY.Name = "txbTrY";
			this.txbTrY.Size = new System.Drawing.Size(32, 20);
			this.txbTrY.TabIndex = 16;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(157, 49);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(15, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "y:";
			// 
			// bpZoom
			// 
			this.bpZoom.Location = new System.Drawing.Point(238, 46);
			this.bpZoom.Name = "bpZoom";
			this.bpZoom.Size = new System.Drawing.Size(106, 24);
			this.bpZoom.TabIndex = 35;
			this.bpZoom.Text = "Zoom";
			this.bpZoom.UseVisualStyleBackColor = true;
			this.bpZoom.Click += new System.EventHandler(this.bpZoom_Click);
			// 
			// txbTrX
			// 
			this.txbTrX.Location = new System.Drawing.Point(172, 19);
			this.txbTrX.Name = "txbTrX";
			this.txbTrX.Size = new System.Drawing.Size(32, 20);
			this.txbTrX.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(157, 23);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(15, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "x:";
			// 
			// rbDepImage
			// 
			this.rbDepImage.AutoSize = true;
			this.rbDepImage.Location = new System.Drawing.Point(12, 48);
			this.rbDepImage.Name = "rbDepImage";
			this.rbDepImage.Size = new System.Drawing.Size(120, 17);
			this.rbDepImage.TabIndex = 1;
			this.rbDepImage.Text = "De l\'image complète";
			this.rbDepImage.UseVisualStyleBackColor = true;
			// 
			// rbDepTriangle
			// 
			this.rbDepTriangle.AutoSize = true;
			this.rbDepTriangle.Checked = true;
			this.rbDepTriangle.Location = new System.Drawing.Point(12, 25);
			this.rbDepTriangle.Name = "rbDepTriangle";
			this.rbDepTriangle.Size = new System.Drawing.Size(115, 17);
			this.rbDepTriangle.TabIndex = 0;
			this.rbDepTriangle.TabStop = true;
			this.rbDepTriangle.Text = "Du triangle courant";
			this.rbDepTriangle.UseVisualStyleBackColor = true;
			// 
			// lblInfoVersion
			// 
			this.lblInfoVersion.AutoSize = true;
			this.lblInfoVersion.Location = new System.Drawing.Point(852, 745);
			this.lblInfoVersion.Name = "lblInfoVersion";
			this.lblInfoVersion.Size = new System.Drawing.Size(42, 13);
			this.lblInfoVersion.TabIndex = 36;
			this.lblInfoVersion.Text = "Version";
			// 
			// chkClearData
			// 
			this.chkClearData.AutoSize = true;
			this.chkClearData.Location = new System.Drawing.Point(1213, 13);
			this.chkClearData.Name = "chkClearData";
			this.chkClearData.Size = new System.Drawing.Size(165, 17);
			this.chkClearData.TabIndex = 37;
			this.chkClearData.Text = "Effacer données avant import";
			this.chkClearData.UseVisualStyleBackColor = true;
			// 
			// bpClearList
			// 
			this.bpClearList.Location = new System.Drawing.Point(1398, 745);
			this.bpClearList.Name = "bpClearList";
			this.bpClearList.Size = new System.Drawing.Size(120, 23);
			this.bpClearList.TabIndex = 38;
			this.bpClearList.Text = "Effacer la liste";
			this.bpClearList.UseVisualStyleBackColor = true;
			this.bpClearList.Click += new System.EventHandler(this.bpClearList_Click);
			// 
			// bpClean
			// 
			this.bpClean.Location = new System.Drawing.Point(1456, 362);
			this.bpClean.Name = "bpClean";
			this.bpClean.Size = new System.Drawing.Size(61, 25);
			this.bpClean.TabIndex = 39;
			this.bpClean.Text = "Clean";
			this.bpClean.UseVisualStyleBackColor = true;
			this.bpClean.Click += new System.EventHandler(this.bpClean_Click);
			// 
			// bpRapproche
			// 
			this.bpRapproche.Location = new System.Drawing.Point(1456, 405);
			this.bpRapproche.Name = "bpRapproche";
			this.bpRapproche.Size = new System.Drawing.Size(62, 23);
			this.bpRapproche.TabIndex = 40;
			this.bpRapproche.Text = "Rapproche";
			this.bpRapproche.UseVisualStyleBackColor = true;
			this.bpRapproche.Click += new System.EventHandler(this.bpRapproche_Click);
			// 
			// bpAjoutQuadri
			// 
			this.bpAjoutQuadri.Location = new System.Drawing.Point(866, 197);
			this.bpAjoutQuadri.Name = "bpAjoutQuadri";
			this.bpAjoutQuadri.Size = new System.Drawing.Size(113, 23);
			this.bpAjoutQuadri.TabIndex = 41;
			this.bpAjoutQuadri.Text = "Ajouter quadrilatère";
			this.bpAjoutQuadri.UseVisualStyleBackColor = true;
			this.bpAjoutQuadri.Click += new System.EventHandler(this.bpAjoutQuadri_Click);
			// 
			// txbY4
			// 
			this.txbY4.Location = new System.Drawing.Point(1368, 495);
			this.txbY4.MaxLength = 3;
			this.txbY4.Name = "txbY4";
			this.txbY4.Size = new System.Drawing.Size(25, 20);
			this.txbY4.TabIndex = 43;
			// 
			// txbX4
			// 
			this.txbX4.Location = new System.Drawing.Point(1311, 495);
			this.txbX4.MaxLength = 3;
			this.txbX4.Name = "txbX4";
			this.txbX4.Size = new System.Drawing.Size(25, 20);
			this.txbX4.TabIndex = 42;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(1345, 498);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(27, 13);
			this.label10.TabIndex = 45;
			this.label10.Text = "(y4):";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(1288, 498);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(27, 13);
			this.label11.TabIndex = 44;
			this.label11.Text = "(x4):";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(1057, 244);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(249, 13);
			this.label12.TabIndex = 46;
			this.label12.Text = "Temps d\'attente entre chaque triangles (1-850 ms) :";
			// 
			// txbTpsAttente
			// 
			this.txbTpsAttente.Location = new System.Drawing.Point(1312, 241);
			this.txbTpsAttente.Name = "txbTpsAttente";
			this.txbTpsAttente.Size = new System.Drawing.Size(39, 20);
			this.txbTpsAttente.TabIndex = 47;
			this.txbTpsAttente.Text = "16";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(950, 498);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "x1:";
			// 
			// txbX1
			// 
			this.txbX1.Location = new System.Drawing.Point(969, 495);
			this.txbX1.MaxLength = 3;
			this.txbX1.Name = "txbX1";
			this.txbX1.Size = new System.Drawing.Size(25, 20);
			this.txbX1.TabIndex = 8;
			// 
			// txbPos
			// 
			this.txbPos.Location = new System.Drawing.Point(895, 495);
			this.txbPos.MaxLength = 3;
			this.txbPos.Name = "txbPos";
			this.txbPos.Size = new System.Drawing.Size(40, 20);
			this.txbPos.TabIndex = 48;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(866, 498);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(30, 13);
			this.label13.TabIndex = 49;
			this.label13.Text = "pos :";
			// 
			// chkCenterZoom
			// 
			this.chkCenterZoom.AutoSize = true;
			this.chkCenterZoom.Location = new System.Drawing.Point(350, 50);
			this.chkCenterZoom.Name = "chkCenterZoom";
			this.chkCenterZoom.Size = new System.Drawing.Size(86, 17);
			this.chkCenterZoom.TabIndex = 36;
			this.chkCenterZoom.Text = "Zoom centré";
			this.chkCenterZoom.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1529, 774);
			this.Controls.Add(this.txbPos);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txbTpsAttente);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txbY4);
			this.Controls.Add(this.txbX4);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.bpAjoutQuadri);
			this.Controls.Add(this.bpRapproche);
			this.Controls.Add(this.bpClean);
			this.Controls.Add(this.bpClearList);
			this.Controls.Add(this.chkClearData);
			this.Controls.Add(this.lblInfoVersion);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bpDown);
			this.Controls.Add(this.bpUp);
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
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
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
		private System.Windows.Forms.TextBox txbY1;
		private System.Windows.Forms.TextBox txbX2;
		private System.Windows.Forms.TextBox txbY2;
		private System.Windows.Forms.TextBox txbX3;
		private System.Windows.Forms.TextBox txbY3;
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
		private System.Windows.Forms.Button bpUp;
		private System.Windows.Forms.Button bpDown;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbVertical;
		private System.Windows.Forms.RadioButton rbHorizontal;
		private System.Windows.Forms.RadioButton rbStandard;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button bpDeplace;
		private System.Windows.Forms.TextBox txbTrY;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txbTrX;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton rbDepImage;
		private System.Windows.Forms.RadioButton rbDepTriangle;
		private System.Windows.Forms.Button bpZoom;
		private System.Windows.Forms.Label lblInfoVersion;
		private System.Windows.Forms.CheckBox chkClearData;
		private System.Windows.Forms.Button bpClearList;
		private System.Windows.Forms.Button bpClean;
		private System.Windows.Forms.Button bpRapproche;
		private System.Windows.Forms.Button bpAjoutQuadri;
		private System.Windows.Forms.TextBox txbY4;
		private System.Windows.Forms.TextBox txbX4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txbTpsAttente;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txbX1;
		private System.Windows.Forms.TextBox txbPos;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox chkCenterZoom;
	}
}

