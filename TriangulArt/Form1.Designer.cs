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
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 12);
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
			this.lblInfoPos.Location = new System.Drawing.Point(556, 22);
			this.lblInfoPos.Name = "lblInfoPos";
			this.lblInfoPos.Size = new System.Drawing.Size(43, 13);
			this.lblInfoPos.TabIndex = 1;
			this.lblInfoPos.Text = "position";
			// 
			// bpAddTriangle
			// 
			this.bpAddTriangle.Location = new System.Drawing.Point(547, 92);
			this.bpAddTriangle.Name = "bpAddTriangle";
			this.bpAddTriangle.Size = new System.Drawing.Size(94, 23);
			this.bpAddTriangle.TabIndex = 2;
			this.bpAddTriangle.Text = "Ajouter triangle";
			this.bpAddTriangle.UseVisualStyleBackColor = true;
			this.bpAddTriangle.Click += new System.EventHandler(this.bpAddTriangle_Click);
			// 
			// listInfo
			// 
			this.listInfo.FormattingEnabled = true;
			this.listInfo.Location = new System.Drawing.Point(547, 132);
			this.listInfo.Name = "listInfo";
			this.listInfo.Size = new System.Drawing.Size(555, 147);
			this.listInfo.TabIndex = 3;
			// 
			// bpLoad
			// 
			this.bpLoad.Location = new System.Drawing.Point(547, 331);
			this.bpLoad.Name = "bpLoad";
			this.bpLoad.Size = new System.Drawing.Size(99, 22);
			this.bpLoad.TabIndex = 4;
			this.bpLoad.Text = "Lire";
			this.bpLoad.UseVisualStyleBackColor = true;
			this.bpLoad.Click += new System.EventHandler(this.bpLoad_Click);
			// 
			// bpSave
			// 
			this.bpSave.Location = new System.Drawing.Point(547, 359);
			this.bpSave.Name = "bpSave";
			this.bpSave.Size = new System.Drawing.Size(99, 22);
			this.bpSave.TabIndex = 4;
			this.bpSave.Text = "Sauver";
			this.bpSave.UseVisualStyleBackColor = true;
			this.bpSave.Click += new System.EventHandler(this.bpSave_Click);
			// 
			// Color0
			// 
			this.Color0.BackColor = System.Drawing.Color.Transparent;
			this.Color0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color0.Location = new System.Drawing.Point(12, 527);
			this.Color0.Name = "Color0";
			this.Color0.Size = new System.Drawing.Size(82, 56);
			this.Color0.TabIndex = 5;
			this.Color0.Click += new System.EventHandler(this.Color0_Click);
			// 
			// Color1
			// 
			this.Color1.BackColor = System.Drawing.Color.Transparent;
			this.Color1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color1.Location = new System.Drawing.Point(155, 527);
			this.Color1.Name = "Color1";
			this.Color1.Size = new System.Drawing.Size(82, 56);
			this.Color1.TabIndex = 5;
			this.Color1.Click += new System.EventHandler(this.Color1_Click);
			// 
			// Color2
			// 
			this.Color2.BackColor = System.Drawing.Color.Transparent;
			this.Color2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color2.Location = new System.Drawing.Point(298, 527);
			this.Color2.Name = "Color2";
			this.Color2.Size = new System.Drawing.Size(82, 56);
			this.Color2.TabIndex = 5;
			this.Color2.Click += new System.EventHandler(this.Color2_Click);
			// 
			// Color3
			// 
			this.Color3.BackColor = System.Drawing.Color.Transparent;
			this.Color3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Color3.Location = new System.Drawing.Point(441, 527);
			this.Color3.Name = "Color3";
			this.Color3.Size = new System.Drawing.Size(82, 56);
			this.Color3.TabIndex = 5;
			this.Color3.Click += new System.EventHandler(this.Color3_Click);
			// 
			// ColorSel
			// 
			this.ColorSel.BackColor = System.Drawing.Color.Transparent;
			this.ColorSel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorSel.Location = new System.Drawing.Point(658, 59);
			this.ColorSel.Name = "ColorSel";
			this.ColorSel.Size = new System.Drawing.Size(82, 56);
			this.ColorSel.TabIndex = 5;
			this.ColorSel.Click += new System.EventHandler(this.Color0_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1114, 701);
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
	}
}

