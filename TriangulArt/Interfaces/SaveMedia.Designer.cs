﻿namespace TriangulArt {
	partial class SaveMedia {
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
			this.txbLabelMedia = new System.Windows.Forms.TextBox();
			this.bpOk = new System.Windows.Forms.Button();
			this.txbLabelPalette = new System.Windows.Forms.TextBox();
			this.chkLabelMedia = new System.Windows.Forms.CheckBox();
			this.chkLabelPalette = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txbLabelMedia
			// 
			this.txbLabelMedia.Location = new System.Drawing.Point(163, 20);
			this.txbLabelMedia.Name = "txbLabelMedia";
			this.txbLabelMedia.Size = new System.Drawing.Size(324, 20);
			this.txbLabelMedia.TabIndex = 2;
			// 
			// bpOk
			// 
			this.bpOk.Location = new System.Drawing.Point(409, 99);
			this.bpOk.Name = "bpOk";
			this.bpOk.Size = new System.Drawing.Size(75, 23);
			this.bpOk.TabIndex = 5;
			this.bpOk.Text = "Ok";
			this.bpOk.UseVisualStyleBackColor = true;
			this.bpOk.Click += new System.EventHandler(this.bpOk_Click);
			// 
			// txbLabelPalette
			// 
			this.txbLabelPalette.Location = new System.Drawing.Point(163, 46);
			this.txbLabelPalette.Name = "txbLabelPalette";
			this.txbLabelPalette.Size = new System.Drawing.Size(324, 20);
			this.txbLabelPalette.TabIndex = 2;
			// 
			// chkLabelMedia
			// 
			this.chkLabelMedia.AutoSize = true;
			this.chkLabelMedia.Checked = true;
			this.chkLabelMedia.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkLabelMedia.Location = new System.Drawing.Point(18, 23);
			this.chkLabelMedia.Name = "chkLabelMedia";
			this.chkLabelMedia.Size = new System.Drawing.Size(15, 14);
			this.chkLabelMedia.TabIndex = 6;
			this.chkLabelMedia.UseVisualStyleBackColor = true;
			this.chkLabelMedia.CheckedChanged += new System.EventHandler(this.ChkLabelMedia_CheckedChanged);
			// 
			// chkLabelPalette
			// 
			this.chkLabelPalette.AutoSize = true;
			this.chkLabelPalette.Checked = true;
			this.chkLabelPalette.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkLabelPalette.Location = new System.Drawing.Point(18, 49);
			this.chkLabelPalette.Name = "chkLabelPalette";
			this.chkLabelPalette.Size = new System.Drawing.Size(15, 14);
			this.chkLabelPalette.TabIndex = 6;
			this.chkLabelPalette.UseVisualStyleBackColor = true;
			this.chkLabelPalette.CheckedChanged += new System.EventHandler(this.ChkLabelPalette_CheckedChanged);
			// 
			// SaveMedia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 127);
			this.Controls.Add(this.chkLabelPalette);
			this.Controls.Add(this.chkLabelMedia);
			this.Controls.Add(this.bpOk);
			this.Controls.Add(this.txbLabelPalette);
			this.Controls.Add(this.txbLabelMedia);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveMedia";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txbLabelMedia;
		private System.Windows.Forms.Button bpOk;
		private System.Windows.Forms.TextBox txbLabelPalette;
		private System.Windows.Forms.CheckBox chkLabelMedia;
		private System.Windows.Forms.CheckBox chkLabelPalette;
	}
}