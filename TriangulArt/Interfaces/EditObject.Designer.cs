﻿namespace TriangulArt {
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
			this.pictureBoxObj = new System.Windows.Forms.PictureBox();
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
			this.listVertex = new System.Windows.Forms.ListBox();
			this.listFace = new System.Windows.Forms.ListBox();
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
			this.bpAddVertex = new System.Windows.Forms.Button();
			this.bpSupVertex = new System.Windows.Forms.Button();
			this.bpEditVertex = new System.Windows.Forms.Button();
			this.bpAddFace = new System.Windows.Forms.Button();
			this.bpSupFace = new System.Windows.Forms.Button();
			this.bpEditFace = new System.Windows.Forms.Button();
			this.bpRedraw = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxObj)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxObj
			// 
			this.pictureBoxObj.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxObj.Name = "pictureBoxObj";
			this.pictureBoxObj.Size = new System.Drawing.Size(640, 400);
			this.pictureBoxObj.TabIndex = 0;
			this.pictureBoxObj.TabStop = false;
			// 
			// bpNewObject
			// 
			this.bpNewObject.Enabled = false;
			this.bpNewObject.Location = new System.Drawing.Point(646, 0);
			this.bpNewObject.Name = "bpNewObject";
			this.bpNewObject.Size = new System.Drawing.Size(90, 23);
			this.bpNewObject.TabIndex = 1;
			this.bpNewObject.Text = "Nouvel objet";
			this.bpNewObject.UseVisualStyleBackColor = true;
			this.bpNewObject.Click += new System.EventHandler(this.bpNewObject_Click);
			// 
			// bpReadObject
			// 
			this.bpReadObject.Location = new System.Drawing.Point(646, 29);
			this.bpReadObject.Name = "bpReadObject";
			this.bpReadObject.Size = new System.Drawing.Size(90, 23);
			this.bpReadObject.TabIndex = 1;
			this.bpReadObject.Text = "Lire objet";
			this.bpReadObject.UseVisualStyleBackColor = true;
			this.bpReadObject.Click += new System.EventHandler(this.bpReadObject_Click);
			// 
			// bpFusionObject
			// 
			this.bpFusionObject.Enabled = false;
			this.bpFusionObject.Location = new System.Drawing.Point(646, 58);
			this.bpFusionObject.Name = "bpFusionObject";
			this.bpFusionObject.Size = new System.Drawing.Size(90, 23);
			this.bpFusionObject.TabIndex = 1;
			this.bpFusionObject.Text = "Fusionner objet";
			this.bpFusionObject.UseVisualStyleBackColor = true;
			this.bpFusionObject.Click += new System.EventHandler(this.bpFusionObject_Click);
			// 
			// bpSaveObject
			// 
			this.bpSaveObject.Enabled = false;
			this.bpSaveObject.Location = new System.Drawing.Point(646, 87);
			this.bpSaveObject.Name = "bpSaveObject";
			this.bpSaveObject.Size = new System.Drawing.Size(90, 23);
			this.bpSaveObject.TabIndex = 1;
			this.bpSaveObject.Text = "Sauver objet";
			this.bpSaveObject.UseVisualStyleBackColor = true;
			this.bpSaveObject.Click += new System.EventHandler(this.bpSaveObject_Click);
			// 
			// trackX
			// 
			this.trackX.Location = new System.Drawing.Point(642, 130);
			this.trackX.Maximum = 359;
			this.trackX.Name = "trackX";
			this.trackX.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.trackX.RightToLeftLayout = true;
			this.trackX.Size = new System.Drawing.Size(45, 246);
			this.trackX.TabIndex = 2;
			this.trackX.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackX.Scroll += new System.EventHandler(this.trackX_Scroll);
			// 
			// trackY
			// 
			this.trackY.Location = new System.Drawing.Point(693, 130);
			this.trackY.Maximum = 359;
			this.trackY.Name = "trackY";
			this.trackY.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackY.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.trackY.RightToLeftLayout = true;
			this.trackY.Size = new System.Drawing.Size(45, 246);
			this.trackY.TabIndex = 2;
			this.trackY.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackY.Scroll += new System.EventHandler(this.trackY_Scroll);
			// 
			// trackZ
			// 
			this.trackZ.Location = new System.Drawing.Point(744, 130);
			this.trackZ.Maximum = 359;
			this.trackZ.Name = "trackZ";
			this.trackZ.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackZ.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.trackZ.RightToLeftLayout = true;
			this.trackZ.Size = new System.Drawing.Size(45, 246);
			this.trackZ.TabIndex = 2;
			this.trackZ.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackZ.Scroll += new System.EventHandler(this.trackZ_Scroll);
			// 
			// txbValX
			// 
			this.txbValX.Location = new System.Drawing.Point(659, 380);
			this.txbValX.Name = "txbValX";
			this.txbValX.ReadOnly = true;
			this.txbValX.Size = new System.Drawing.Size(30, 20);
			this.txbValX.TabIndex = 3;
			this.txbValX.Text = "0";
			// 
			// txbValY
			// 
			this.txbValY.Location = new System.Drawing.Point(711, 380);
			this.txbValY.Name = "txbValY";
			this.txbValY.ReadOnly = true;
			this.txbValY.Size = new System.Drawing.Size(30, 20);
			this.txbValY.TabIndex = 4;
			this.txbValY.Text = "0";
			// 
			// txbValZ
			// 
			this.txbValZ.Location = new System.Drawing.Point(762, 380);
			this.txbValZ.Name = "txbValZ";
			this.txbValZ.ReadOnly = true;
			this.txbValZ.Size = new System.Drawing.Size(30, 20);
			this.txbValZ.TabIndex = 5;
			this.txbValZ.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(671, 122);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "X";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(720, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Y";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(773, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Z";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1, 413);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Zoom";
			// 
			// trackZoom
			// 
			this.trackZoom.Location = new System.Drawing.Point(82, 406);
			this.trackZoom.Maximum = 200000;
			this.trackZoom.Minimum = 1;
			this.trackZoom.Name = "trackZoom";
			this.trackZoom.Size = new System.Drawing.Size(558, 45);
			this.trackZoom.TabIndex = 8;
			this.trackZoom.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackZoom.Value = 1;
			this.trackZoom.Scroll += new System.EventHandler(this.trackZoom_Scroll);
			// 
			// txbZoom
			// 
			this.txbZoom.Location = new System.Drawing.Point(38, 410);
			this.txbZoom.Name = "txbZoom";
			this.txbZoom.ReadOnly = true;
			this.txbZoom.Size = new System.Drawing.Size(43, 20);
			this.txbZoom.TabIndex = 3;
			this.txbZoom.Text = "1";
			// 
			// listVertex
			// 
			this.listVertex.FormattingEnabled = true;
			this.listVertex.Location = new System.Drawing.Point(76, 446);
			this.listVertex.Name = "listVertex";
			this.listVertex.Size = new System.Drawing.Size(308, 264);
			this.listVertex.TabIndex = 9;
			this.listVertex.SelectedIndexChanged += new System.EventHandler(this.listVertex_SelectedIndexChanged);
			// 
			// listFace
			// 
			this.listFace.FormattingEnabled = true;
			this.listFace.Location = new System.Drawing.Point(642, 446);
			this.listFace.Name = "listFace";
			this.listFace.Size = new System.Drawing.Size(299, 264);
			this.listFace.TabIndex = 9;
			this.listFace.SelectedIndexChanged += new System.EventHandler(this.listFace_SelectedIndexChanged);
			// 
			// txbFaceA
			// 
			this.txbFaceA.Location = new System.Drawing.Point(661, 716);
			this.txbFaceA.Name = "txbFaceA";
			this.txbFaceA.Size = new System.Drawing.Size(51, 20);
			this.txbFaceA.TabIndex = 10;
			this.txbFaceA.Text = "0";
			// 
			// txbFaceB
			// 
			this.txbFaceB.Location = new System.Drawing.Point(779, 716);
			this.txbFaceB.Name = "txbFaceB";
			this.txbFaceB.Size = new System.Drawing.Size(51, 20);
			this.txbFaceB.TabIndex = 10;
			this.txbFaceB.Text = "0";
			// 
			// txbFaceC
			// 
			this.txbFaceC.Location = new System.Drawing.Point(890, 716);
			this.txbFaceC.Name = "txbFaceC";
			this.txbFaceC.Size = new System.Drawing.Size(51, 20);
			this.txbFaceC.TabIndex = 10;
			this.txbFaceC.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(643, 719);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "A";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(759, 719);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "B";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(870, 719);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "C";
			// 
			// txbVertexX
			// 
			this.txbVertexX.Location = new System.Drawing.Point(105, 716);
			this.txbVertexX.Name = "txbVertexX";
			this.txbVertexX.Size = new System.Drawing.Size(51, 20);
			this.txbVertexX.TabIndex = 10;
			this.txbVertexX.Text = "0";
			// 
			// txbVertexY
			// 
			this.txbVertexY.Location = new System.Drawing.Point(223, 716);
			this.txbVertexY.Name = "txbVertexY";
			this.txbVertexY.Size = new System.Drawing.Size(51, 20);
			this.txbVertexY.TabIndex = 10;
			this.txbVertexY.Text = "0";
			// 
			// txbVertexZ
			// 
			this.txbVertexZ.Location = new System.Drawing.Point(334, 716);
			this.txbVertexZ.Name = "txbVertexZ";
			this.txbVertexZ.Size = new System.Drawing.Size(51, 20);
			this.txbVertexZ.TabIndex = 10;
			this.txbVertexZ.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(87, 719);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(14, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "X";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(203, 719);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(14, 13);
			this.label9.TabIndex = 11;
			this.label9.Text = "Y";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(314, 719);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(14, 13);
			this.label10.TabIndex = 11;
			this.label10.Text = "Z";
			// 
			// bpAddVertex
			// 
			this.bpAddVertex.Location = new System.Drawing.Point(0, 658);
			this.bpAddVertex.Name = "bpAddVertex";
			this.bpAddVertex.Size = new System.Drawing.Size(75, 23);
			this.bpAddVertex.TabIndex = 12;
			this.bpAddVertex.Text = "Ajouter";
			this.bpAddVertex.UseVisualStyleBackColor = true;
			this.bpAddVertex.Click += new System.EventHandler(this.bpAddVertex_Click);
			// 
			// bpSupVertex
			// 
			this.bpSupVertex.Enabled = false;
			this.bpSupVertex.Location = new System.Drawing.Point(0, 687);
			this.bpSupVertex.Name = "bpSupVertex";
			this.bpSupVertex.Size = new System.Drawing.Size(75, 23);
			this.bpSupVertex.TabIndex = 12;
			this.bpSupVertex.Text = "Supprimer";
			this.bpSupVertex.UseVisualStyleBackColor = true;
			this.bpSupVertex.Click += new System.EventHandler(this.bpSupVertex_Click);
			// 
			// bpEditVertex
			// 
			this.bpEditVertex.Enabled = false;
			this.bpEditVertex.Location = new System.Drawing.Point(0, 716);
			this.bpEditVertex.Name = "bpEditVertex";
			this.bpEditVertex.Size = new System.Drawing.Size(75, 23);
			this.bpEditVertex.TabIndex = 12;
			this.bpEditVertex.Text = "Modifier";
			this.bpEditVertex.UseVisualStyleBackColor = true;
			this.bpEditVertex.Click += new System.EventHandler(this.bpEditVertex_Click);
			// 
			// bpAddFace
			// 
			this.bpAddFace.Location = new System.Drawing.Point(561, 658);
			this.bpAddFace.Name = "bpAddFace";
			this.bpAddFace.Size = new System.Drawing.Size(75, 23);
			this.bpAddFace.TabIndex = 12;
			this.bpAddFace.Text = "Ajouter";
			this.bpAddFace.UseVisualStyleBackColor = true;
			this.bpAddFace.Click += new System.EventHandler(this.bpAddFace_Click);
			// 
			// bpSupFace
			// 
			this.bpSupFace.Enabled = false;
			this.bpSupFace.Location = new System.Drawing.Point(561, 687);
			this.bpSupFace.Name = "bpSupFace";
			this.bpSupFace.Size = new System.Drawing.Size(75, 23);
			this.bpSupFace.TabIndex = 12;
			this.bpSupFace.Text = "Supprimer";
			this.bpSupFace.UseVisualStyleBackColor = true;
			this.bpSupFace.Click += new System.EventHandler(this.bpSupFace_Click);
			// 
			// bpEditFace
			// 
			this.bpEditFace.Enabled = false;
			this.bpEditFace.Location = new System.Drawing.Point(561, 716);
			this.bpEditFace.Name = "bpEditFace";
			this.bpEditFace.Size = new System.Drawing.Size(75, 23);
			this.bpEditFace.TabIndex = 12;
			this.bpEditFace.Text = "Modifier";
			this.bpEditFace.UseVisualStyleBackColor = true;
			this.bpEditFace.Click += new System.EventHandler(this.bpEditFace_Click);
			// 
			// bpRedraw
			// 
			this.bpRedraw.Location = new System.Drawing.Point(646, 410);
			this.bpRedraw.Name = "bpRedraw";
			this.bpRedraw.Size = new System.Drawing.Size(75, 23);
			this.bpRedraw.TabIndex = 13;
			this.bpRedraw.Text = "Redessiner";
			this.bpRedraw.UseVisualStyleBackColor = true;
			this.bpRedraw.Click += new System.EventHandler(this.bpRedraw_Click);
			// 
			// EditObjet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(956, 759);
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
			this.Controls.Add(this.listFace);
			this.Controls.Add(this.listVertex);
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxObj)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
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
		private System.Windows.Forms.ListBox listVertex;
		private System.Windows.Forms.ListBox listFace;
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
	}
}
