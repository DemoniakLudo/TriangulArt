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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1114, 701);
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
	}
}

