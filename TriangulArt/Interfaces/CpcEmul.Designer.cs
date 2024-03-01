namespace TriangulArt {
	partial class CpcEmul {
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.bpExit = new System.Windows.Forms.Button();
			this.bpStart = new System.Windows.Forms.Button();
			this.bpStop = new System.Windows.Forms.Button();
			this.bpReadData = new System.Windows.Forms.Button();
			this.txtDataAdr = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.bpFillMemory = new System.Windows.Forms.Button();
			this.txbFillValue = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(768, 544);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// bpExit
			// 
			this.bpExit.Location = new System.Drawing.Point(879, 2);
			this.bpExit.Name = "bpExit";
			this.bpExit.Size = new System.Drawing.Size(53, 23);
			this.bpExit.TabIndex = 7;
			this.bpExit.Text = "EXIT";
			this.bpExit.UseVisualStyleBackColor = true;
			this.bpExit.Click += new System.EventHandler(this.BpExit_Click);
			// 
			// bpStart
			// 
			this.bpStart.Location = new System.Drawing.Point(776, 2);
			this.bpStart.Name = "bpStart";
			this.bpStart.Size = new System.Drawing.Size(97, 23);
			this.bpStart.TabIndex = 8;
			this.bpStart.Text = "Start";
			this.bpStart.UseVisualStyleBackColor = true;
			this.bpStart.Click += new System.EventHandler(this.BpStart_Click);
			// 
			// bpStop
			// 
			this.bpStop.Location = new System.Drawing.Point(776, 31);
			this.bpStop.Name = "bpStop";
			this.bpStop.Size = new System.Drawing.Size(97, 23);
			this.bpStop.TabIndex = 8;
			this.bpStop.Text = "Stop";
			this.bpStop.UseVisualStyleBackColor = true;
			this.bpStop.Click += new System.EventHandler(this.BpStop_Click);
			// 
			// bpReadData
			// 
			this.bpReadData.Enabled = false;
			this.bpReadData.Location = new System.Drawing.Point(776, 85);
			this.bpReadData.Name = "bpReadData";
			this.bpReadData.Size = new System.Drawing.Size(97, 23);
			this.bpReadData.TabIndex = 9;
			this.bpReadData.Text = "Read data";
			this.bpReadData.UseVisualStyleBackColor = true;
			this.bpReadData.Click += new System.EventHandler(this.BpReadData_Click);
			// 
			// txtDataAdr
			// 
			this.txtDataAdr.Enabled = false;
			this.txtDataAdr.Location = new System.Drawing.Point(888, 85);
			this.txtDataAdr.MaxLength = 4;
			this.txtDataAdr.Name = "txtDataAdr";
			this.txtDataAdr.Size = new System.Drawing.Size(44, 20);
			this.txtDataAdr.TabIndex = 10;
			this.txtDataAdr.Text = "4000";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(874, 88);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(14, 13);
			this.label16.TabIndex = 11;
			this.label16.Text = "#";
			// 
			// bpFillMemory
			// 
			this.bpFillMemory.Location = new System.Drawing.Point(776, 149);
			this.bpFillMemory.Name = "bpFillMemory";
			this.bpFillMemory.Size = new System.Drawing.Size(97, 23);
			this.bpFillMemory.TabIndex = 12;
			this.bpFillMemory.Text = "Fill memory with";
			this.bpFillMemory.UseVisualStyleBackColor = true;
			this.bpFillMemory.Click += new System.EventHandler(this.BpFillMemory_Click);
			// 
			// txbFillValue
			// 
			this.txbFillValue.Enabled = false;
			this.txbFillValue.Location = new System.Drawing.Point(888, 149);
			this.txbFillValue.MaxLength = 2;
			this.txbFillValue.Name = "txbFillValue";
			this.txbFillValue.Size = new System.Drawing.Size(28, 20);
			this.txbFillValue.TabIndex = 10;
			this.txbFillValue.Text = "00";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(874, 152);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(14, 13);
			this.label17.TabIndex = 11;
			this.label17.Text = "#";
			// 
			// CpcEmul
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(936, 552);
			this.Controls.Add(this.bpFillMemory);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.txbFillValue);
			this.Controls.Add(this.txtDataAdr);
			this.Controls.Add(this.bpReadData);
			this.Controls.Add(this.bpStop);
			this.Controls.Add(this.bpStart);
			this.Controls.Add(this.bpExit);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CpcEmul";
			this.Text = "CpcEmul";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button bpExit;
		private System.Windows.Forms.Button bpStart;
		private System.Windows.Forms.Button bpStop;
		private System.Windows.Forms.Button bpReadData;
		private System.Windows.Forms.TextBox txtDataAdr;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button bpFillMemory;
		private System.Windows.Forms.TextBox txbFillValue;
		private System.Windows.Forms.Label label17;
	}
}

