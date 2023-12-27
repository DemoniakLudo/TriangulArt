namespace TriangulArt {
	partial class CreateObject {
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
			this.rbPlat = new System.Windows.Forms.RadioButton();
			this.rbEpais = new System.Windows.Forms.RadioButton();
			this.rbCylindre = new System.Windows.Forms.RadioButton();
			this.bpCreer = new System.Windows.Forms.Button();
			this.txbEpais = new System.Windows.Forms.TextBox();
			this.txbRayon = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// rbPlat
			// 
			this.rbPlat.AutoSize = true;
			this.rbPlat.Checked = true;
			this.rbPlat.Location = new System.Drawing.Point(12, 12);
			this.rbPlat.Name = "rbPlat";
			this.rbPlat.Size = new System.Drawing.Size(70, 17);
			this.rbPlat.TabIndex = 0;
			this.rbPlat.TabStop = true;
			this.rbPlat.Text = "Objet plat";
			this.rbPlat.UseVisualStyleBackColor = true;
			this.rbPlat.CheckedChanged += new System.EventHandler(this.rbPlat_CheckedChanged);
			// 
			// rbEpais
			// 
			this.rbEpais.AutoSize = true;
			this.rbEpais.Location = new System.Drawing.Point(12, 50);
			this.rbEpais.Name = "rbEpais";
			this.rbEpais.Size = new System.Drawing.Size(125, 17);
			this.rbEpais.TabIndex = 1;
			this.rbEpais.Text = "Objet avec épaisseur";
			this.rbEpais.UseVisualStyleBackColor = true;
			this.rbEpais.CheckedChanged += new System.EventHandler(this.rbEpais_CheckedChanged);
			// 
			// rbCylindre
			// 
			this.rbCylindre.AutoSize = true;
			this.rbCylindre.Location = new System.Drawing.Point(12, 88);
			this.rbCylindre.Name = "rbCylindre";
			this.rbCylindre.Size = new System.Drawing.Size(103, 17);
			this.rbCylindre.TabIndex = 2;
			this.rbCylindre.Text = "Objet cylindrique";
			this.rbCylindre.UseVisualStyleBackColor = true;
			this.rbCylindre.CheckedChanged += new System.EventHandler(this.rbCylindre_CheckedChanged);
			// 
			// bpCreer
			// 
			this.bpCreer.Location = new System.Drawing.Point(76, 128);
			this.bpCreer.Name = "bpCreer";
			this.bpCreer.Size = new System.Drawing.Size(113, 23);
			this.bpCreer.TabIndex = 3;
			this.bpCreer.Text = "Créer objet";
			this.bpCreer.UseVisualStyleBackColor = true;
			this.bpCreer.Click += new System.EventHandler(this.bpCreer_Click);
			// 
			// txbEpais
			// 
			this.txbEpais.Enabled = false;
			this.txbEpais.Location = new System.Drawing.Point(143, 50);
			this.txbEpais.Name = "txbEpais";
			this.txbEpais.Size = new System.Drawing.Size(46, 20);
			this.txbEpais.TabIndex = 4;
			this.txbEpais.Text = "20";
			// 
			// txbRayon
			// 
			this.txbRayon.Enabled = false;
			this.txbRayon.Location = new System.Drawing.Point(143, 88);
			this.txbRayon.Name = "txbRayon";
			this.txbRayon.Size = new System.Drawing.Size(46, 20);
			this.txbRayon.TabIndex = 4;
			this.txbRayon.Text = "8";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(195, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "épaisseur";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(195, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Rayons";
			// 
			// CreateObject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(268, 163);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txbRayon);
			this.Controls.Add(this.txbEpais);
			this.Controls.Add(this.bpCreer);
			this.Controls.Add(this.rbCylindre);
			this.Controls.Add(this.rbEpais);
			this.Controls.Add(this.rbPlat);
			this.Name = "CreateObject";
			this.Text = "CreateObject";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbPlat;
		private System.Windows.Forms.RadioButton rbEpais;
		private System.Windows.Forms.RadioButton rbCylindre;
		private System.Windows.Forms.Button bpCreer;
		private System.Windows.Forms.TextBox txbEpais;
		private System.Windows.Forms.TextBox txbRayon;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}