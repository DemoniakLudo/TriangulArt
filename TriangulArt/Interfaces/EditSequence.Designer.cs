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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.bpImportSequence = new System.Windows.Forms.Button();
			this.bpExportSequence = new System.Windows.Forms.Button();
			this.dataGridViewSeq = new System.Windows.Forms.DataGridView();
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
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.NullValue = null;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewSeq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
			this.dataGridViewSeq.Location = new System.Drawing.Point(4, -1);
			this.dataGridViewSeq.Name = "dataGridViewSeq";
			this.dataGridViewSeq.Size = new System.Drawing.Size(1151, 756);
			this.dataGridViewSeq.TabIndex = 1;
			this.dataGridViewSeq.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSeq_CellEndEdit);
			// 
			// FrameNumber
			// 
			this.FrameNumber.Frozen = true;
			this.FrameNumber.HeaderText = "N° Frame";
			this.FrameNumber.Name = "FrameNumber";
			this.FrameNumber.ReadOnly = true;
			// 
			// PosX
			// 
			this.PosX.Frozen = true;
			this.PosX.HeaderText = "PosX";
			this.PosX.Name = "PosX";
			// 
			// PosY
			// 
			this.PosY.HeaderText = "PosY";
			this.PosY.Name = "PosY";
			// 
			// ZoomX
			// 
			this.ZoomX.HeaderText = "ZoomX";
			this.ZoomX.Name = "ZoomX";
			// 
			// ZoomY
			// 
			this.ZoomY.HeaderText = "ZoomY";
			this.ZoomY.Name = "ZoomY";
			// 
			// AngX
			// 
			this.AngX.HeaderText = "AngX";
			this.AngX.Name = "AngX";
			// 
			// AngY
			// 
			this.AngY.HeaderText = "AngY";
			this.AngY.Name = "AngY";
			// 
			// AngZ
			// 
			this.AngZ.HeaderText = "AngZ";
			this.AngZ.Name = "AngZ";
			// 
			// EditSequence
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1158, 785);
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

		}

		#endregion

		private System.Windows.Forms.Button bpImportSequence;
		private System.Windows.Forms.Button bpExportSequence;
		private System.Windows.Forms.DataGridView dataGridViewSeq;
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