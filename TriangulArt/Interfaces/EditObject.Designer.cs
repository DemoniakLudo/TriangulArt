namespace TriangulArt {
	partial class EditObjet {
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
			System.Windows.Forms.ColumnHeader colColor;
			this.bpNewObject = new System.Windows.Forms.Button();
			this.bpReadObject = new System.Windows.Forms.Button();
			this.bpFusionObject = new System.Windows.Forms.Button();
			this.bpSaveObject = new System.Windows.Forms.Button();
			this.trackX = new System.Windows.Forms.TrackBar();
			this.trackY = new System.Windows.Forms.TrackBar();
			this.trackZ = new System.Windows.Forms.TrackBar();
			this.txbValX = new System.Windows.Forms.TextBox();
			this.txbValY = new System.Windows.Forms.TextBox();
			this.txbValZ = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.trackZoom = new System.Windows.Forms.TrackBar();
			this.txbZoom = new System.Windows.Forms.TextBox();
			this.txbFaceA = new System.Windows.Forms.TextBox();
			this.txbFaceB = new System.Windows.Forms.TextBox();
			this.txbFaceC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txbVertexX = new System.Windows.Forms.TextBox();
			this.txbVertexY = new System.Windows.Forms.TextBox();
			this.txbVertexZ = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.bpRedraw = new System.Windows.Forms.Button();
			this.lblFaceColor = new System.Windows.Forms.Label();
			this.lstViewFace = new System.Windows.Forms.ListView();
			this.colNumFace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVertexA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVertexB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colVertexC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lstViewVertex = new System.Windows.Forms.ListView();
			this.colNumVertex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colZ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chkImportPalette = new System.Windows.Forms.CheckBox();
			this.bpEditFace = new System.Windows.Forms.Button();
			this.bpEditVertex = new System.Windows.Forms.Button();
			this.bpSupFace = new System.Windows.Forms.Button();
			this.bpSupVertex = new System.Windows.Forms.Button();
			this.bpAddFace = new System.Windows.Forms.Button();
			this.bpAddVertex = new System.Windows.Forms.Button();
			this.pictureBoxObj = new System.Windows.Forms.PictureBox();
			this.bpParamObjet = new System.Windows.Forms.Button();
			this.bpModif = new System.Windows.Forms.Button();
			this.bpSupPtsNotUse = new System.Windows.Forms.Button();
			this.bpRecentre = new System.Windows.Forms.Button();
			this.bpSupFaceDouble = new System.Windows.Forms.Button();
			colColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.trackX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxObj)).BeginInit();
			this.SuspendLayout();
			// 
			// colColor
			// 
			colColor.Text = "Color";
			// 
			// bpNewObject
			// 
			this.bpNewObject.Location = new System.Drawing.Point(782, 4);
			this.bpNewObject.Name = "bpNewObject";
			this.bpNewObject.Size = new System.Drawing.Size(120, 23);
			this.bpNewObject.TabIndex = 1;
			this.bpNewObject.Text = "Nouvel objet";
			this.bpNewObject.UseVisualStyleBackColor = true;
			this.bpNewObject.Click += new System.EventHandler(this.BpNewObject_Click);
			// 
			// bpReadObject
			// 
			this.bpReadObject.Location = new System.Drawing.Point(782, 32);
			this.bpReadObject.Name = "bpReadObject";
			this.bpReadObject.Size = new System.Drawing.Size(120, 23);
			this.bpReadObject.TabIndex = 1;
			this.bpReadObject.Text = "Lire objet";
			this.bpReadObject.UseVisualStyleBackColor = true;
			this.bpReadObject.Click += new System.EventHandler(this.BpReadObject_Click);
			// 
			// bpFusionObject
			// 
			this.bpFusionObject.Enabled = false;
			this.bpFusionObject.Location = new System.Drawing.Point(908, 4);
			this.bpFusionObject.Name = "bpFusionObject";
			this.bpFusionObject.Size = new System.Drawing.Size(120, 23);
			this.bpFusionObject.TabIndex = 1;
			this.bpFusionObject.Text = "Fusionner objet";
			this.bpFusionObject.UseVisualStyleBackColor = true;
			this.bpFusionObject.Click += new System.EventHandler(this.BpFusionObject_Click);
			// 
			// bpSaveObject
			// 
			this.bpSaveObject.Enabled = false;
			this.bpSaveObject.Location = new System.Drawing.Point(908, 32);
			this.bpSaveObject.Name = "bpSaveObject";
			this.bpSaveObject.Size = new System.Drawing.Size(120, 23);
			this.bpSaveObject.TabIndex = 1;
			this.bpSaveObject.Text = "Sauver objet";
			this.bpSaveObject.UseVisualStyleBackColor = true;
			this.bpSaveObject.Click += new System.EventHandler(this.BpSaveObject_Click);
			// 
			// trackX
			// 
			this.trackX.Location = new System.Drawing.Point(777, 154);
			this.trackX.Maximum = 359;
			this.trackX.Name = "trackX";
			this.trackX.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.trackX.RightToLeftLayout = true;
			this.trackX.Size = new System.Drawing.Size(45, 327);
			this.trackX.TabIndex = 2;
			this.trackX.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackX.Scroll += new System.EventHandler(this.TrackX_Scroll);
			// 
			// trackY
			// 
			this.trackY.Location = new System.Drawing.Point(828, 154);
			this.trackY.Maximum = 359;
			this.trackY.Name = "trackY";
			this.trackY.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackY.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.trackY.RightToLeftLayout = true;
			this.trackY.Size = new System.Drawing.Size(45, 327);
			this.trackY.TabIndex = 2;
			this.trackY.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackY.Scroll += new System.EventHandler(this.TrackY_Scroll);
			// 
			// trackZ
			// 
			this.trackZ.Location = new System.Drawing.Point(879, 154);
			this.trackZ.Maximum = 359;
			this.trackZ.Name = "trackZ";
			this.trackZ.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackZ.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.trackZ.RightToLeftLayout = true;
			this.trackZ.Size = new System.Drawing.Size(45, 327);
			this.trackZ.TabIndex = 2;
			this.trackZ.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackZ.Scroll += new System.EventHandler(this.TrackZ_Scroll);
			// 
			// txbValX
			// 
			this.txbValX.Location = new System.Drawing.Point(794, 486);
			this.txbValX.Name = "txbValX";
			this.txbValX.ReadOnly = true;
			this.txbValX.Size = new System.Drawing.Size(30, 20);
			this.txbValX.TabIndex = 3;
			this.txbValX.Text = "0";
			// 
			// txbValY
			// 
			this.txbValY.Location = new System.Drawing.Point(846, 486);
			this.txbValY.Name = "txbValY";
			this.txbValY.ReadOnly = true;
			this.txbValY.Size = new System.Drawing.Size(30, 20);
			this.txbValY.TabIndex = 4;
			this.txbValY.Text = "0";
			// 
			// txbValZ
			// 
			this.txbValZ.Location = new System.Drawing.Point(897, 486);
			this.txbValZ.Name = "txbValZ";
			this.txbValZ.ReadOnly = true;
			this.txbValZ.Size = new System.Drawing.Size(30, 20);
			this.txbValZ.TabIndex = 5;
			this.txbValZ.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(802, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "X";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(851, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Y";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(904, 140);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Z";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(0, 524);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Zoom";
			// 
			// trackZoom
			// 
			this.trackZoom.Location = new System.Drawing.Point(84, 517);
			this.trackZoom.Maximum = 200000;
			this.trackZoom.Minimum = 500;
			this.trackZoom.Name = "trackZoom";
			this.trackZoom.Size = new System.Drawing.Size(684, 45);
			this.trackZoom.TabIndex = 8;
			this.trackZoom.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackZoom.Value = 500;
			this.trackZoom.Scroll += new System.EventHandler(this.TrackZoom_Scroll);
			// 
			// txbZoom
			// 
			this.txbZoom.Location = new System.Drawing.Point(40, 521);
			this.txbZoom.Name = "txbZoom";
			this.txbZoom.ReadOnly = true;
			this.txbZoom.Size = new System.Drawing.Size(43, 20);
			this.txbZoom.TabIndex = 3;
			this.txbZoom.Text = "500";
			// 
			// txbFaceA
			// 
			this.txbFaceA.Location = new System.Drawing.Point(663, 836);
			this.txbFaceA.Name = "txbFaceA";
			this.txbFaceA.Size = new System.Drawing.Size(51, 20);
			this.txbFaceA.TabIndex = 10;
			this.txbFaceA.Text = "0";
			// 
			// txbFaceB
			// 
			this.txbFaceB.Location = new System.Drawing.Point(741, 836);
			this.txbFaceB.Name = "txbFaceB";
			this.txbFaceB.Size = new System.Drawing.Size(51, 20);
			this.txbFaceB.TabIndex = 10;
			this.txbFaceB.Text = "0";
			// 
			// txbFaceC
			// 
			this.txbFaceC.Location = new System.Drawing.Point(820, 836);
			this.txbFaceC.Name = "txbFaceC";
			this.txbFaceC.Size = new System.Drawing.Size(51, 20);
			this.txbFaceC.TabIndex = 10;
			this.txbFaceC.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(645, 840);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "A";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(723, 840);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "B";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(802, 840);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "C";
			// 
			// txbVertexX
			// 
			this.txbVertexX.Location = new System.Drawing.Point(106, 836);
			this.txbVertexX.Name = "txbVertexX";
			this.txbVertexX.Size = new System.Drawing.Size(59, 20);
			this.txbVertexX.TabIndex = 10;
			this.txbVertexX.Text = "0";
			// 
			// txbVertexY
			// 
			this.txbVertexY.Location = new System.Drawing.Point(196, 836);
			this.txbVertexY.Name = "txbVertexY";
			this.txbVertexY.Size = new System.Drawing.Size(59, 20);
			this.txbVertexY.TabIndex = 10;
			this.txbVertexY.Text = "0";
			// 
			// txbVertexZ
			// 
			this.txbVertexZ.Location = new System.Drawing.Point(287, 836);
			this.txbVertexZ.Name = "txbVertexZ";
			this.txbVertexZ.Size = new System.Drawing.Size(59, 20);
			this.txbVertexZ.TabIndex = 10;
			this.txbVertexZ.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(88, 840);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(14, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "X";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(178, 840);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(14, 13);
			this.label9.TabIndex = 11;
			this.label9.Text = "Y";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(269, 840);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(14, 13);
			this.label10.TabIndex = 11;
			this.label10.Text = "Z";
			// 
			// bpRedraw
			// 
			this.bpRedraw.Location = new System.Drawing.Point(782, 515);
			this.bpRedraw.Name = "bpRedraw";
			this.bpRedraw.Size = new System.Drawing.Size(75, 23);
			this.bpRedraw.TabIndex = 13;
			this.bpRedraw.Text = "Redessiner";
			this.bpRedraw.UseVisualStyleBackColor = true;
			this.bpRedraw.Click += new System.EventHandler(this.BpRedraw_Click);
			// 
			// lblFaceColor
			// 
			this.lblFaceColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblFaceColor.Location = new System.Drawing.Point(902, 836);
			this.lblFaceColor.Name = "lblFaceColor";
			this.lblFaceColor.Size = new System.Drawing.Size(48, 32);
			this.lblFaceColor.TabIndex = 14;
			// 
			// lstViewFace
			// 
			this.lstViewFace.AutoArrange = false;
			this.lstViewFace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumFace,
            this.colVertexA,
            this.colVertexB,
            this.colVertexC,
            colColor});
			this.lstViewFace.FullRowSelect = true;
			this.lstViewFace.GridLines = true;
			this.lstViewFace.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstViewFace.HideSelection = false;
			this.lstViewFace.Location = new System.Drawing.Point(644, 566);
			this.lstViewFace.MultiSelect = false;
			this.lstViewFace.Name = "lstViewFace";
			this.lstViewFace.Size = new System.Drawing.Size(321, 264);
			this.lstViewFace.TabIndex = 15;
			this.lstViewFace.UseCompatibleStateImageBehavior = false;
			this.lstViewFace.View = System.Windows.Forms.View.Details;
			this.lstViewFace.SelectedIndexChanged += new System.EventHandler(this.LstViewFace_SelectedIndexChanged);
			// 
			// colNumFace
			// 
			this.colNumFace.Text = "Face";
			// 
			// colVertexA
			// 
			this.colVertexA.Text = "A";
			// 
			// colVertexB
			// 
			this.colVertexB.Text = "B";
			// 
			// colVertexC
			// 
			this.colVertexC.Text = "C";
			// 
			// lstViewVertex
			// 
			this.lstViewVertex.AutoArrange = false;
			this.lstViewVertex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumVertex,
            this.colX,
            this.colY,
            this.colZ});
			this.lstViewVertex.FullRowSelect = true;
			this.lstViewVertex.GridLines = true;
			this.lstViewVertex.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstViewVertex.HideSelection = false;
			this.lstViewVertex.Location = new System.Drawing.Point(40, 566);
			this.lstViewVertex.MultiSelect = false;
			this.lstViewVertex.Name = "lstViewVertex";
			this.lstViewVertex.Size = new System.Drawing.Size(322, 264);
			this.lstViewVertex.TabIndex = 16;
			this.lstViewVertex.UseCompatibleStateImageBehavior = false;
			this.lstViewVertex.View = System.Windows.Forms.View.Details;
			this.lstViewVertex.SelectedIndexChanged += new System.EventHandler(this.LstViewVertex_SelectedIndexChanged);
			// 
			// colNumVertex
			// 
			this.colNumVertex.Text = "Point";
			// 
			// colX
			// 
			this.colX.Text = "X";
			this.colX.Width = 80;
			// 
			// colY
			// 
			this.colY.Text = "Y";
			this.colY.Width = 80;
			// 
			// colZ
			// 
			this.colZ.Text = "Z";
			this.colZ.Width = 80;
			// 
			// chkImportPalette
			// 
			this.chkImportPalette.AutoSize = true;
			this.chkImportPalette.Location = new System.Drawing.Point(782, 61);
			this.chkImportPalette.Name = "chkImportPalette";
			this.chkImportPalette.Size = new System.Drawing.Size(159, 17);
			this.chkImportPalette.TabIndex = 17;
			this.chkImportPalette.Text = "Importer palette depuis objet";
			this.chkImportPalette.UseVisualStyleBackColor = true;
			// 
			// bpEditFace
			// 
			this.bpEditFace.Enabled = false;
			this.bpEditFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bpEditFace.Image = global::TriangulArt.Properties.Resources.Edit;
			this.bpEditFace.Location = new System.Drawing.Point(610, 836);
			this.bpEditFace.Name = "bpEditFace";
			this.bpEditFace.Size = new System.Drawing.Size(28, 28);
			this.bpEditFace.TabIndex = 12;
			this.bpEditFace.UseVisualStyleBackColor = true;
			this.bpEditFace.Click += new System.EventHandler(this.BpEditFace_Click);
			// 
			// bpEditVertex
			// 
			this.bpEditVertex.Enabled = false;
			this.bpEditVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bpEditVertex.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bpEditVertex.Image = global::TriangulArt.Properties.Resources.Edit;
			this.bpEditVertex.Location = new System.Drawing.Point(6, 836);
			this.bpEditVertex.Name = "bpEditVertex";
			this.bpEditVertex.Size = new System.Drawing.Size(28, 28);
			this.bpEditVertex.TabIndex = 12;
			this.bpEditVertex.UseVisualStyleBackColor = true;
			this.bpEditVertex.Click += new System.EventHandler(this.BpEditVertex_Click);
			// 
			// bpSupFace
			// 
			this.bpSupFace.Enabled = false;
			this.bpSupFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bpSupFace.Image = global::TriangulArt.Properties.Resources.Del;
			this.bpSupFace.Location = new System.Drawing.Point(610, 803);
			this.bpSupFace.Name = "bpSupFace";
			this.bpSupFace.Size = new System.Drawing.Size(28, 28);
			this.bpSupFace.TabIndex = 12;
			this.bpSupFace.UseVisualStyleBackColor = true;
			this.bpSupFace.Click += new System.EventHandler(this.BpSupFace_Click);
			// 
			// bpSupVertex
			// 
			this.bpSupVertex.Enabled = false;
			this.bpSupVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bpSupVertex.Image = global::TriangulArt.Properties.Resources.Del;
			this.bpSupVertex.Location = new System.Drawing.Point(6, 803);
			this.bpSupVertex.Name = "bpSupVertex";
			this.bpSupVertex.Size = new System.Drawing.Size(28, 28);
			this.bpSupVertex.TabIndex = 12;
			this.bpSupVertex.UseVisualStyleBackColor = true;
			this.bpSupVertex.Click += new System.EventHandler(this.BpSupVertex_Click);
			// 
			// bpAddFace
			// 
			this.bpAddFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bpAddFace.Image = global::TriangulArt.Properties.Resources.Add;
			this.bpAddFace.Location = new System.Drawing.Point(610, 770);
			this.bpAddFace.Name = "bpAddFace";
			this.bpAddFace.Size = new System.Drawing.Size(28, 28);
			this.bpAddFace.TabIndex = 12;
			this.bpAddFace.UseVisualStyleBackColor = true;
			this.bpAddFace.Click += new System.EventHandler(this.BpAddFace_Click);
			// 
			// bpAddVertex
			// 
			this.bpAddVertex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bpAddVertex.Image = global::TriangulArt.Properties.Resources.Add;
			this.bpAddVertex.Location = new System.Drawing.Point(6, 770);
			this.bpAddVertex.Name = "bpAddVertex";
			this.bpAddVertex.Size = new System.Drawing.Size(28, 28);
			this.bpAddVertex.TabIndex = 12;
			this.bpAddVertex.UseVisualStyleBackColor = true;
			this.bpAddVertex.Click += new System.EventHandler(this.BpAddVertex_Click);
			// 
			// pictureBoxObj
			// 
			this.pictureBoxObj.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxObj.Name = "pictureBoxObj";
			this.pictureBoxObj.Size = new System.Drawing.Size(768, 512);
			this.pictureBoxObj.TabIndex = 0;
			this.pictureBoxObj.TabStop = false;
			this.pictureBoxObj.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxObj_MouseDown);
			// 
			// bpParamObjet
			// 
			this.bpParamObjet.Location = new System.Drawing.Point(443, 568);
			this.bpParamObjet.Name = "bpParamObjet";
			this.bpParamObjet.Size = new System.Drawing.Size(113, 23);
			this.bpParamObjet.TabIndex = 18;
			this.bpParamObjet.Text = "Paramèrtres objet";
			this.bpParamObjet.UseVisualStyleBackColor = true;
			this.bpParamObjet.Click += new System.EventHandler(this.BpParamObjet_Click);
			// 
			// bpModif
			// 
			this.bpModif.Location = new System.Drawing.Point(428, 697);
			this.bpModif.Name = "bpModif";
			this.bpModif.Size = new System.Drawing.Size(75, 23);
			this.bpModif.TabIndex = 19;
			this.bpModif.Text = "Modif";
			this.bpModif.UseVisualStyleBackColor = true;
			this.bpModif.Click += new System.EventHandler(this.BpModif_Click);
			// 
			// bpSupPtsNotUse
			// 
			this.bpSupPtsNotUse.Location = new System.Drawing.Point(368, 773);
			this.bpSupPtsNotUse.Name = "bpSupPtsNotUse";
			this.bpSupPtsNotUse.Size = new System.Drawing.Size(135, 23);
			this.bpSupPtsNotUse.TabIndex = 20;
			this.bpSupPtsNotUse.Text = "Supprimer points inutilisés";
			this.bpSupPtsNotUse.UseVisualStyleBackColor = true;
			this.bpSupPtsNotUse.Click += new System.EventHandler(this.BpSupPtsNotUse_Click);
			// 
			// bpRecentre
			// 
			this.bpRecentre.Location = new System.Drawing.Point(443, 597);
			this.bpRecentre.Name = "bpRecentre";
			this.bpRecentre.Size = new System.Drawing.Size(113, 23);
			this.bpRecentre.TabIndex = 21;
			this.bpRecentre.Text = "Recentrer objet";
			this.bpRecentre.UseVisualStyleBackColor = true;
			this.bpRecentre.Click += new System.EventHandler(this.BpRecentre_Click);
			// 
			// bpSupFaceDouble
			// 
			this.bpSupFaceDouble.Location = new System.Drawing.Point(450, 804);
			this.bpSupFaceDouble.Name = "bpSupFaceDouble";
			this.bpSupFaceDouble.Size = new System.Drawing.Size(154, 23);
			this.bpSupFaceDouble.TabIndex = 22;
			this.bpSupFaceDouble.Text = "Supprimer faces redondantes";
			this.bpSupFaceDouble.UseVisualStyleBackColor = true;
			this.bpSupFaceDouble.Click += new System.EventHandler(this.BpSupFaceDouble_Click);
			// 
			// EditObjet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1047, 872);
			this.Controls.Add(this.bpSupFaceDouble);
			this.Controls.Add(this.bpRecentre);
			this.Controls.Add(this.bpSupPtsNotUse);
			this.Controls.Add(this.bpModif);
			this.Controls.Add(this.bpParamObjet);
			this.Controls.Add(this.chkImportPalette);
			this.Controls.Add(this.lstViewVertex);
			this.Controls.Add(this.lstViewFace);
			this.Controls.Add(this.lblFaceColor);
			this.Controls.Add(this.bpRedraw);
			this.Controls.Add(this.bpEditFace);
			this.Controls.Add(this.bpEditVertex);
			this.Controls.Add(this.bpSupFace);
			this.Controls.Add(this.bpSupVertex);
			this.Controls.Add(this.bpAddFace);
			this.Controls.Add(this.bpAddVertex);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txbVertexZ);
			this.Controls.Add(this.txbFaceC);
			this.Controls.Add(this.txbVertexY);
			this.Controls.Add(this.txbFaceB);
			this.Controls.Add(this.txbVertexX);
			this.Controls.Add(this.txbFaceA);
			this.Controls.Add(this.trackZoom);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txbValZ);
			this.Controls.Add(this.txbValY);
			this.Controls.Add(this.txbZoom);
			this.Controls.Add(this.txbValX);
			this.Controls.Add(this.trackZ);
			this.Controls.Add(this.trackY);
			this.Controls.Add(this.trackX);
			this.Controls.Add(this.bpSaveObject);
			this.Controls.Add(this.bpFusionObject);
			this.Controls.Add(this.bpReadObject);
			this.Controls.Add(this.bpNewObject);
			this.Controls.Add(this.pictureBoxObj);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditObjet";
			this.Text = "Editeur d\'objets";
			((System.ComponentModel.ISupportInitialize)(this.trackX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxObj)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxObj;
		private System.Windows.Forms.Button bpNewObject;
		private System.Windows.Forms.Button bpReadObject;
		private System.Windows.Forms.Button bpFusionObject;
		private System.Windows.Forms.Button bpSaveObject;
		private System.Windows.Forms.TrackBar trackX;
		private System.Windows.Forms.TrackBar trackY;
		private System.Windows.Forms.TrackBar trackZ;
		private System.Windows.Forms.TextBox txbValX;
		private System.Windows.Forms.TextBox txbValY;
		private System.Windows.Forms.TextBox txbValZ;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trackZoom;
		private System.Windows.Forms.TextBox txbZoom;
		private System.Windows.Forms.TextBox txbFaceA;
		private System.Windows.Forms.TextBox txbFaceB;
		private System.Windows.Forms.TextBox txbFaceC;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txbVertexX;
		private System.Windows.Forms.TextBox txbVertexY;
		private System.Windows.Forms.TextBox txbVertexZ;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button bpAddVertex;
		private System.Windows.Forms.Button bpSupVertex;
		private System.Windows.Forms.Button bpEditVertex;
		private System.Windows.Forms.Button bpAddFace;
		private System.Windows.Forms.Button bpSupFace;
		private System.Windows.Forms.Button bpEditFace;
		private System.Windows.Forms.Button bpRedraw;
		private System.Windows.Forms.Label lblFaceColor;
		private System.Windows.Forms.ListView lstViewFace;
		private System.Windows.Forms.ColumnHeader colNumFace;
		private System.Windows.Forms.ColumnHeader colVertexA;
		private System.Windows.Forms.ColumnHeader colVertexB;
		private System.Windows.Forms.ColumnHeader colVertexC;
		private System.Windows.Forms.ListView lstViewVertex;
		private System.Windows.Forms.ColumnHeader colNumVertex;
		private System.Windows.Forms.ColumnHeader colX;
		private System.Windows.Forms.ColumnHeader colY;
		private System.Windows.Forms.ColumnHeader colZ;
		private System.Windows.Forms.CheckBox chkImportPalette;
		private System.Windows.Forms.Button bpParamObjet;
		private System.Windows.Forms.Button bpModif;
		private System.Windows.Forms.Button bpSupPtsNotUse;
		private System.Windows.Forms.Button bpRecentre;
		private System.Windows.Forms.Button bpSupFaceDouble;
	}
}

