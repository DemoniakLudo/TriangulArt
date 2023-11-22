namespace TriangulArt {
	partial class EditSequence {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.bpImportSequence = new System.Windows.Forms.Button();
			this.bpExportSequence = new System.Windows.Forms.Button();
			this.dataGridViewSeq = new System.Windows.Forms.DataGridView();
			this.txbExprX = new System.Windows.Forms.TextBox();
			this.txbExprY = new System.Windows.Forms.TextBox();
			this.txbExprZx = new System.Windows.Forms.TextBox();
			this.txbExprZy = new System.Windows.Forms.TextBox();
			this.txbExprAx = new System.Windows.Forms.TextBox();
			this.txbExprAy = new System.Windows.Forms.TextBox();
			this.txbExprAz = new System.Windows.Forms.TextBox();
			this.txbError = new System.Windows.Forms.TextBox();
			this.bpGenerate = new System.Windows.Forms.Button();
			this.FrameNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PosX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PosY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ZoomX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ZoomY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AngX = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AngY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AngZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeq)).BeginInit();
			this.SuspendLayout();
			// 
			// bpImportSequence
			// 
			this.bpImportSequence.Location = new System.Drawing.Point(12, 761);
			this.bpImportSequence.Name = "bpImportSequence";
			this.bpImportSequence.Size = new System.Drawing.Size(115, 23);
			this.bpImportSequence.TabIndex = 0;
			this.bpImportSequence.Text = "Importer séquence";
			this.bpImportSequence.UseVisualStyleBackColor = true;
			this.bpImportSequence.Click += new System.EventHandler(this.BpImportSequence_Click);
			// 
			// bpExportSequence
			// 
			this.bpExportSequence.Location = new System.Drawing.Point(133, 761);
			this.bpExportSequence.Name = "bpExportSequence";
			this.bpExportSequence.Size = new System.Drawing.Size(115, 23);
			this.bpExportSequence.TabIndex = 0;
			this.bpExportSequence.Text = "Exporter séquence";
			this.bpExportSequence.UseVisualStyleBackColor = true;
			this.bpExportSequence.Click += new System.EventHandler(this.BpExportSequence_Click);
			// 
			// dataGridViewSeq
			// 
			this.dataGridViewSeq.AllowUserToAddRows = false;
			this.dataGridViewSeq.AllowUserToDeleteRows = false;
			this.dataGridViewSeq.AllowUserToResizeColumns = false;
			this.dataGridViewSeq.AllowUserToResizeRows = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.NullValue = null;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewSeq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewSeq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSeq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FrameNumber,
            this.PosX,
            this.PosY,
            this.ZoomX,
            this.ZoomY,
            this.AngX,
            this.AngY,
            this.AngZ});
			this.dataGridViewSeq.Location = new System.Drawing.Point(4, 29);
			this.dataGridViewSeq.Name = "dataGridViewSeq";
			this.dataGridViewSeq.Size = new System.Drawing.Size(1298, 726);
			this.dataGridViewSeq.TabIndex = 1;
			this.dataGridViewSeq.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSeq_CellEndEdit);
			// 
			// txbExprX
			// 
			this.txbExprX.Location = new System.Drawing.Point(96, 3);
			this.txbExprX.Name = "txbExprX";
			this.txbExprX.Size = new System.Drawing.Size(166, 20);
			this.txbExprX.TabIndex = 2;
			// 
			// txbExprY
			// 
			this.txbExprY.Location = new System.Drawing.Point(266, 3);
			this.txbExprY.Name = "txbExprY";
			this.txbExprY.Size = new System.Drawing.Size(166, 20);
			this.txbExprY.TabIndex = 2;
			// 
			// txbExprZx
			// 
			this.txbExprZx.Location = new System.Drawing.Point(436, 3);
			this.txbExprZx.Name = "txbExprZx";
			this.txbExprZx.Size = new System.Drawing.Size(166, 20);
			this.txbExprZx.TabIndex = 2;
			// 
			// txbExprZy
			// 
			this.txbExprZy.Location = new System.Drawing.Point(606, 3);
			this.txbExprZy.Name = "txbExprZy";
			this.txbExprZy.Size = new System.Drawing.Size(166, 20);
			this.txbExprZy.TabIndex = 2;
			// 
			// txbExprAx
			// 
			this.txbExprAx.Location = new System.Drawing.Point(776, 3);
			this.txbExprAx.Name = "txbExprAx";
			this.txbExprAx.Size = new System.Drawing.Size(166, 20);
			this.txbExprAx.TabIndex = 2;
			// 
			// txbExprAy
			// 
			this.txbExprAy.Location = new System.Drawing.Point(946, 3);
			this.txbExprAy.Name = "txbExprAy";
			this.txbExprAy.Size = new System.Drawing.Size(166, 20);
			this.txbExprAy.TabIndex = 2;
			// 
			// txbExprAz
			// 
			this.txbExprAz.Location = new System.Drawing.Point(1116, 3);
			this.txbExprAz.Name = "txbExprAz";
			this.txbExprAz.Size = new System.Drawing.Size(166, 20);
			this.txbExprAz.TabIndex = 2;
			// 
			// txbError
			// 
			this.txbError.Enabled = false;
			this.txbError.ForeColor = System.Drawing.Color.Red;
			this.txbError.Location = new System.Drawing.Point(254, 764);
			this.txbError.Name = "txbError";
			this.txbError.ReadOnly = true;
			this.txbError.Size = new System.Drawing.Size(1048, 20);
			this.txbError.TabIndex = 3;
			// 
			// bpGenerate
			// 
			this.bpGenerate.Location = new System.Drawing.Point(4, 0);
			this.bpGenerate.Name = "bpGenerate";
			this.bpGenerate.Size = new System.Drawing.Size(86, 23);
			this.bpGenerate.TabIndex = 4;
			this.bpGenerate.Text = "Générer =>";
			this.bpGenerate.UseVisualStyleBackColor = true;
			this.bpGenerate.Click += new System.EventHandler(this.bpGenerate_Click);
			// 
			// FrameNumber
			// 
			this.FrameNumber.Frozen = true;
			this.FrameNumber.HeaderText = "N° Frame";
			this.FrameNumber.Name = "FrameNumber";
			this.FrameNumber.ReadOnly = true;
			this.FrameNumber.Width = 50;
			// 
			// PosX
			// 
			this.PosX.Frozen = true;
			this.PosX.HeaderText = "PosX";
			this.PosX.Name = "PosX";
			this.PosX.Width = 170;
			// 
			// PosY
			// 
			this.PosY.HeaderText = "PosY";
			this.PosY.Name = "PosY";
			this.PosY.Width = 170;
			// 
			// ZoomX
			// 
			this.ZoomX.HeaderText = "ZoomX";
			this.ZoomX.Name = "ZoomX";
			this.ZoomX.Width = 170;
			// 
			// ZoomY
			// 
			this.ZoomY.HeaderText = "ZoomY";
			this.ZoomY.Name = "ZoomY";
			this.ZoomY.Width = 170;
			// 
			// AngX
			// 
			this.AngX.HeaderText = "AngX";
			this.AngX.Name = "AngX";
			this.AngX.Width = 170;
			// 
			// AngY
			// 
			this.AngY.HeaderText = "AngY";
			this.AngY.Name = "AngY";
			this.AngY.Width = 170;
			// 
			// AngZ
			// 
			this.AngZ.HeaderText = "AngZ";
			this.AngZ.Name = "AngZ";
			this.AngZ.Width = 170;
			// 
			// EditSequence
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1306, 785);
			this.Controls.Add(this.bpGenerate);
			this.Controls.Add(this.txbError);
			this.Controls.Add(this.txbExprAz);
			this.Controls.Add(this.txbExprAy);
			this.Controls.Add(this.txbExprAx);
			this.Controls.Add(this.txbExprZy);
			this.Controls.Add(this.txbExprZx);
			this.Controls.Add(this.txbExprY);
			this.Controls.Add(this.txbExprX);
			this.Controls.Add(this.dataGridViewSeq);
			this.Controls.Add(this.bpExportSequence);
			this.Controls.Add(this.bpImportSequence);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditSequence";
			this.Text = "EditSequence";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeq)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bpImportSequence;
		private System.Windows.Forms.Button bpExportSequence;
		private System.Windows.Forms.DataGridView dataGridViewSeq;
		private System.Windows.Forms.TextBox txbExprX;
		private System.Windows.Forms.TextBox txbExprY;
		private System.Windows.Forms.TextBox txbExprZx;
		private System.Windows.Forms.TextBox txbExprZy;
		private System.Windows.Forms.TextBox txbExprAx;
		private System.Windows.Forms.TextBox txbExprAy;
		private System.Windows.Forms.TextBox txbExprAz;
		private System.Windows.Forms.TextBox txbError;
		private System.Windows.Forms.Button bpGenerate;
		private System.Windows.Forms.DataGridViewTextBoxColumn FrameNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn PosX;
		private System.Windows.Forms.DataGridViewTextBoxColumn PosY;
		private System.Windows.Forms.DataGridViewTextBoxColumn ZoomX;
		private System.Windows.Forms.DataGridViewTextBoxColumn ZoomY;
		private System.Windows.Forms.DataGridViewTextBoxColumn AngX;
		private System.Windows.Forms.DataGridViewTextBoxColumn AngY;
		private System.Windows.Forms.DataGridViewTextBoxColumn AngZ;
	}
}