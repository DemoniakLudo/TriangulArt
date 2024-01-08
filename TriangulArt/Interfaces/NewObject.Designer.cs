namespace TriangulArt {
    partial class NewObject {
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
			this.rbVide = new System.Windows.Forms.RadioButton();
			this.rbCube = new System.Windows.Forms.RadioButton();
			this.bpCreate = new System.Windows.Forms.Button();
			this.txbCubeArete = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txbDisqueRayon = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txbDisqueDivision = new System.Windows.Forms.TextBox();
			this.rbDisque = new System.Windows.Forms.RadioButton();
			this.rbSoucoupe = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.txbSoucoupeRayon = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txbSoucoupeDivision = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txbSoucoupeHauteur1 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txbSoucoupeHauteur2 = new System.Windows.Forms.TextBox();
			this.rbPyramide = new System.Windows.Forms.RadioButton();
			this.label8 = new System.Windows.Forms.Label();
			this.txbPyraBase = new System.Windows.Forms.TextBox();
			this.txbPyraHauteur = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txbPosX = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txbPosY = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txbPosZ = new System.Windows.Forms.TextBox();
			this.chkClearObj = new System.Windows.Forms.CheckBox();
			this.chkYorient = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// rbVide
			// 
			this.rbVide.AutoSize = true;
			this.rbVide.Checked = true;
			this.rbVide.Location = new System.Drawing.Point(13, 27);
			this.rbVide.Name = "rbVide";
			this.rbVide.Size = new System.Drawing.Size(165, 17);
			this.rbVide.TabIndex = 0;
			this.rbVide.TabStop = true;
			this.rbVide.Text = "Objet vide (création manuelle)";
			this.rbVide.UseVisualStyleBackColor = true;
			this.rbVide.CheckedChanged += new System.EventHandler(this.RbVide_CheckedChanged);
			// 
			// rbCube
			// 
			this.rbCube.AutoSize = true;
			this.rbCube.Location = new System.Drawing.Point(13, 77);
			this.rbCube.Name = "rbCube";
			this.rbCube.Size = new System.Drawing.Size(50, 17);
			this.rbCube.TabIndex = 1;
			this.rbCube.TabStop = true;
			this.rbCube.Text = "Cube";
			this.rbCube.UseVisualStyleBackColor = true;
			this.rbCube.CheckedChanged += new System.EventHandler(this.RbCube_CheckedChanged);
			// 
			// bpCreate
			// 
			this.bpCreate.Location = new System.Drawing.Point(274, 336);
			this.bpCreate.Name = "bpCreate";
			this.bpCreate.Size = new System.Drawing.Size(75, 23);
			this.bpCreate.TabIndex = 2;
			this.bpCreate.Text = "Créer objet";
			this.bpCreate.UseVisualStyleBackColor = true;
			this.bpCreate.Click += new System.EventHandler(this.BpCreate_Click);
			// 
			// txbCubeArete
			// 
			this.txbCubeArete.Enabled = false;
			this.txbCubeArete.Location = new System.Drawing.Point(112, 73);
			this.txbCubeArete.Name = "txbCubeArete";
			this.txbCubeArete.Size = new System.Drawing.Size(45, 20);
			this.txbCubeArete.TabIndex = 3;
			this.txbCubeArete.Text = "300";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(163, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Taille arête";
			// 
			// txbDisqueRayon
			// 
			this.txbDisqueRayon.Enabled = false;
			this.txbDisqueRayon.Location = new System.Drawing.Point(112, 99);
			this.txbDisqueRayon.Name = "txbDisqueRayon";
			this.txbDisqueRayon.Size = new System.Drawing.Size(45, 20);
			this.txbDisqueRayon.TabIndex = 5;
			this.txbDisqueRayon.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(163, 103);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Rayon";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(271, 107);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Nbre Divisions";
			// 
			// txbDisqueDivision
			// 
			this.txbDisqueDivision.Enabled = false;
			this.txbDisqueDivision.Location = new System.Drawing.Point(220, 103);
			this.txbDisqueDivision.Name = "txbDisqueDivision";
			this.txbDisqueDivision.Size = new System.Drawing.Size(45, 20);
			this.txbDisqueDivision.TabIndex = 5;
			this.txbDisqueDivision.Text = "12";
			// 
			// rbDisque
			// 
			this.rbDisque.AutoSize = true;
			this.rbDisque.Location = new System.Drawing.Point(13, 102);
			this.rbDisque.Name = "rbDisque";
			this.rbDisque.Size = new System.Drawing.Size(58, 17);
			this.rbDisque.TabIndex = 1;
			this.rbDisque.TabStop = true;
			this.rbDisque.Text = "Disque";
			this.rbDisque.UseVisualStyleBackColor = true;
			this.rbDisque.CheckedChanged += new System.EventHandler(this.RbDisque_CheckedChanged);
			// 
			// rbSoucoupe
			// 
			this.rbSoucoupe.AutoSize = true;
			this.rbSoucoupe.Location = new System.Drawing.Point(13, 127);
			this.rbSoucoupe.Name = "rbSoucoupe";
			this.rbSoucoupe.Size = new System.Drawing.Size(74, 17);
			this.rbSoucoupe.TabIndex = 1;
			this.rbSoucoupe.TabStop = true;
			this.rbSoucoupe.Text = "Soucoupe";
			this.rbSoucoupe.UseVisualStyleBackColor = true;
			this.rbSoucoupe.CheckedChanged += new System.EventHandler(this.RbSoucoupe_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(163, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Rayon";
			// 
			// txbSoucoupeRayon
			// 
			this.txbSoucoupeRayon.Enabled = false;
			this.txbSoucoupeRayon.Location = new System.Drawing.Point(112, 125);
			this.txbSoucoupeRayon.Name = "txbSoucoupeRayon";
			this.txbSoucoupeRayon.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeRayon.TabIndex = 5;
			this.txbSoucoupeRayon.Text = "300";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(271, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Nbre Divisions";
			// 
			// txbSoucoupeDivision
			// 
			this.txbSoucoupeDivision.Enabled = false;
			this.txbSoucoupeDivision.Location = new System.Drawing.Point(220, 127);
			this.txbSoucoupeDivision.Name = "txbSoucoupeDivision";
			this.txbSoucoupeDivision.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeDivision.TabIndex = 5;
			this.txbSoucoupeDivision.Text = "12";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(412, 131);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Hauteur 1";
			// 
			// txbSoucoupeHauteur1
			// 
			this.txbSoucoupeHauteur1.Enabled = false;
			this.txbSoucoupeHauteur1.Location = new System.Drawing.Point(361, 127);
			this.txbSoucoupeHauteur1.Name = "txbSoucoupeHauteur1";
			this.txbSoucoupeHauteur1.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeHauteur1.TabIndex = 5;
			this.txbSoucoupeHauteur1.Text = "100";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(556, 131);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Hauteur 2";
			// 
			// txbSoucoupeHauteur2
			// 
			this.txbSoucoupeHauteur2.Enabled = false;
			this.txbSoucoupeHauteur2.Location = new System.Drawing.Point(505, 127);
			this.txbSoucoupeHauteur2.Name = "txbSoucoupeHauteur2";
			this.txbSoucoupeHauteur2.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeHauteur2.TabIndex = 5;
			this.txbSoucoupeHauteur2.Text = "-100";
			// 
			// rbPyramide
			// 
			this.rbPyramide.AutoSize = true;
			this.rbPyramide.Location = new System.Drawing.Point(13, 52);
			this.rbPyramide.Name = "rbPyramide";
			this.rbPyramide.Size = new System.Drawing.Size(68, 17);
			this.rbPyramide.TabIndex = 6;
			this.rbPyramide.TabStop = true;
			this.rbPyramide.Text = "Pyramide";
			this.rbPyramide.UseVisualStyleBackColor = true;
			this.rbPyramide.CheckedChanged += new System.EventHandler(this.rbPyramide_CheckedChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(162, 51);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Taille base";
			// 
			// txbPyraBase
			// 
			this.txbPyraBase.Enabled = false;
			this.txbPyraBase.Location = new System.Drawing.Point(111, 47);
			this.txbPyraBase.Name = "txbPyraBase";
			this.txbPyraBase.Size = new System.Drawing.Size(45, 20);
			this.txbPyraBase.TabIndex = 7;
			this.txbPyraBase.Text = "300";
			// 
			// txbPyraHauteur
			// 
			this.txbPyraHauteur.Enabled = false;
			this.txbPyraHauteur.Location = new System.Drawing.Point(244, 49);
			this.txbPyraHauteur.Name = "txbPyraHauteur";
			this.txbPyraHauteur.Size = new System.Drawing.Size(45, 20);
			this.txbPyraHauteur.TabIndex = 10;
			this.txbPyraHauteur.Text = "300";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(295, 53);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "Hauteur";
			// 
			// txbPosX
			// 
			this.txbPosX.Location = new System.Drawing.Point(297, 239);
			this.txbPosX.Name = "txbPosX";
			this.txbPosX.Size = new System.Drawing.Size(53, 20);
			this.txbPosX.TabIndex = 11;
			this.txbPosX.Text = "0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(136, 267);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(143, 13);
			this.label10.TabIndex = 12;
			this.label10.Text = "Position du centre de l\'objet :";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(356, 242);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(14, 13);
			this.label11.TabIndex = 13;
			this.label11.Text = "X";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(356, 267);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(14, 13);
			this.label12.TabIndex = 15;
			this.label12.Text = "Y";
			// 
			// txbPosY
			// 
			this.txbPosY.Location = new System.Drawing.Point(297, 264);
			this.txbPosY.Name = "txbPosY";
			this.txbPosY.Size = new System.Drawing.Size(53, 20);
			this.txbPosY.TabIndex = 14;
			this.txbPosY.Text = "0";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(356, 293);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(14, 13);
			this.label13.TabIndex = 17;
			this.label13.Text = "Z";
			// 
			// txbPosZ
			// 
			this.txbPosZ.Location = new System.Drawing.Point(297, 290);
			this.txbPosZ.Name = "txbPosZ";
			this.txbPosZ.Size = new System.Drawing.Size(53, 20);
			this.txbPosZ.TabIndex = 16;
			this.txbPosZ.Text = "0";
			// 
			// chkClearObj
			// 
			this.chkClearObj.AutoSize = true;
			this.chkClearObj.Checked = true;
			this.chkClearObj.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkClearObj.Location = new System.Drawing.Point(13, 179);
			this.chkClearObj.Name = "chkClearObj";
			this.chkClearObj.Size = new System.Drawing.Size(137, 17);
			this.chkClearObj.TabIndex = 18;
			this.chkClearObj.Text = "Effacer objet précédent";
			this.chkClearObj.UseVisualStyleBackColor = true;
			// 
			// chkYorient
			// 
			this.chkYorient.AutoSize = true;
			this.chkYorient.Location = new System.Drawing.Point(460, 267);
			this.chkYorient.Name = "chkYorient";
			this.chkYorient.Size = new System.Drawing.Size(110, 17);
			this.chkYorient.TabIndex = 19;
			this.chkYorient.Text = "Orientation vers Y";
			this.chkYorient.UseVisualStyleBackColor = true;
			// 
			// NewObject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 371);
			this.Controls.Add(this.chkYorient);
			this.Controls.Add(this.chkClearObj);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txbPosZ);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txbPosY);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txbPosX);
			this.Controls.Add(this.txbPyraHauteur);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txbPyraBase);
			this.Controls.Add(this.rbPyramide);
			this.Controls.Add(this.txbSoucoupeHauteur2);
			this.Controls.Add(this.txbSoucoupeHauteur1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txbSoucoupeDivision);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txbDisqueDivision);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txbSoucoupeRayon);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txbDisqueRayon);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txbCubeArete);
			this.Controls.Add(this.bpCreate);
			this.Controls.Add(this.rbSoucoupe);
			this.Controls.Add(this.rbDisque);
			this.Controls.Add(this.rbCube);
			this.Controls.Add(this.rbVide);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewObject";
			this.Text = "NewObject";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbVide;
        private System.Windows.Forms.RadioButton rbCube;
        private System.Windows.Forms.Button bpCreate;
        private System.Windows.Forms.TextBox txbCubeArete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDisqueRayon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDisqueDivision;
        private System.Windows.Forms.RadioButton rbDisque;
        private System.Windows.Forms.RadioButton rbSoucoupe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbSoucoupeRayon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbSoucoupeDivision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbSoucoupeHauteur1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbSoucoupeHauteur2;
		private System.Windows.Forms.RadioButton rbPyramide;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txbPyraBase;
		private System.Windows.Forms.TextBox txbPyraHauteur;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txbPosX;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txbPosY;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txbPosZ;
		private System.Windows.Forms.CheckBox chkClearObj;
		private System.Windows.Forms.CheckBox chkYorient;
	}
}