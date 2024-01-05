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
			this.SuspendLayout();
			// 
			// rbVide
			// 
			this.rbVide.AutoSize = true;
			this.rbVide.Checked = true;
			this.rbVide.Location = new System.Drawing.Point(12, 27);
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
			this.rbCube.Location = new System.Drawing.Point(12, 50);
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
			this.bpCreate.Location = new System.Drawing.Point(360, 415);
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
			this.txbCubeArete.Location = new System.Drawing.Point(111, 48);
			this.txbCubeArete.Name = "txbCubeArete";
			this.txbCubeArete.Size = new System.Drawing.Size(45, 20);
			this.txbCubeArete.TabIndex = 3;
			this.txbCubeArete.Text = "300";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(162, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Taille arête";
			// 
			// txbDisqueRayon
			// 
			this.txbDisqueRayon.Enabled = false;
			this.txbDisqueRayon.Location = new System.Drawing.Point(111, 75);
			this.txbDisqueRayon.Name = "txbDisqueRayon";
			this.txbDisqueRayon.Size = new System.Drawing.Size(45, 20);
			this.txbDisqueRayon.TabIndex = 5;
			this.txbDisqueRayon.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(162, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Rayon";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(270, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Nbre Divisions";
			// 
			// txbDisqueDivision
			// 
			this.txbDisqueDivision.Enabled = false;
			this.txbDisqueDivision.Location = new System.Drawing.Point(219, 75);
			this.txbDisqueDivision.Name = "txbDisqueDivision";
			this.txbDisqueDivision.Size = new System.Drawing.Size(45, 20);
			this.txbDisqueDivision.TabIndex = 5;
			this.txbDisqueDivision.Text = "12";
			// 
			// rbDisque
			// 
			this.rbDisque.AutoSize = true;
			this.rbDisque.Location = new System.Drawing.Point(12, 77);
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
			this.rbSoucoupe.Location = new System.Drawing.Point(12, 101);
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
			this.label4.Location = new System.Drawing.Point(162, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Rayon";
			// 
			// txbSoucoupeRayon
			// 
			this.txbSoucoupeRayon.Enabled = false;
			this.txbSoucoupeRayon.Location = new System.Drawing.Point(111, 99);
			this.txbSoucoupeRayon.Name = "txbSoucoupeRayon";
			this.txbSoucoupeRayon.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeRayon.TabIndex = 5;
			this.txbSoucoupeRayon.Text = "300";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(270, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Nbre Divisions";
			// 
			// txbSoucoupeDivision
			// 
			this.txbSoucoupeDivision.Enabled = false;
			this.txbSoucoupeDivision.Location = new System.Drawing.Point(219, 99);
			this.txbSoucoupeDivision.Name = "txbSoucoupeDivision";
			this.txbSoucoupeDivision.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeDivision.TabIndex = 5;
			this.txbSoucoupeDivision.Text = "12";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(411, 103);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Hauteur 1";
			// 
			// txbSoucoupeHauteur1
			// 
			this.txbSoucoupeHauteur1.Enabled = false;
			this.txbSoucoupeHauteur1.Location = new System.Drawing.Point(360, 99);
			this.txbSoucoupeHauteur1.Name = "txbSoucoupeHauteur1";
			this.txbSoucoupeHauteur1.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeHauteur1.TabIndex = 5;
			this.txbSoucoupeHauteur1.Text = "100";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(555, 103);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Hauteur 2";
			// 
			// txbSoucoupeHauteur2
			// 
			this.txbSoucoupeHauteur2.Enabled = false;
			this.txbSoucoupeHauteur2.Location = new System.Drawing.Point(504, 99);
			this.txbSoucoupeHauteur2.Name = "txbSoucoupeHauteur2";
			this.txbSoucoupeHauteur2.Size = new System.Drawing.Size(45, 20);
			this.txbSoucoupeHauteur2.TabIndex = 5;
			this.txbSoucoupeHauteur2.Text = "-100";
			// 
			// NewObject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}