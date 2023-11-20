using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class EditSequence : Form {
		private List<Sequence> lstSeq;
		public EditSequence(List<Sequence> l) {
			InitializeComponent();
			lstSeq = l;
			DisplaySequence();
		}

		private void DisplaySequence() {
			dataGridViewSeq.Rows.Clear();
			int i = 0;
			foreach (Sequence s in lstSeq)
				dataGridViewSeq.Rows.Add(i++, s.PosX, s.PosY, s.ZoomX, s.ZoomY, s.AngX, s.AngY, s.AngZ);
		}

		private void BpImportSequence_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers CSV (*.csv)|*.csv" };
			if (of.ShowDialog() == DialogResult.OK) {
				lstSeq.Clear();
				StreamReader rd = null;
				try {
					rd = File.OpenText(of.FileName);
					string s;
					int i = 0;
					do {
						s = rd.ReadLine();
						if (s != null && i++ > 0) {
							string[] tabVal = s.Split(';');
							if (tabVal.Length == 8) {
								double px = Utils.ConvertToDouble(tabVal[1]);
								double py = Utils.ConvertToDouble(tabVal[2]);
								double zx = Utils.ConvertToDouble(tabVal[3]);
								double zy = Utils.ConvertToDouble(tabVal[4]);
								double ax = Utils.ConvertToDouble(tabVal[5]);
								double ay = Utils.ConvertToDouble(tabVal[6]);
								double az = Utils.ConvertToDouble(tabVal[7]);
								lstSeq.Add(new Sequence(px, py, zx, zy, ax, ay, az));
							}
						}
					}
					while (s != null);
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message, "Erreur lecture séquence.");
				}
				if (rd != null)
					rd.Close();

				DisplaySequence();
			}
		}

		private void BpExportSequence_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers CSV (*.csv)|*.csv" };
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				StreamWriter sw =null;
				try {
					sw = File.CreateText(dlg.FileName);
					int i = 0;
					sw.WriteLine("Numéro Frame;Position X;Position Y;Zoom X;Zoom Y;Angle X;Angle Y;Angle Z");
					foreach (Sequence s in lstSeq) {
						sw.WriteLine(i + ";" + s.PosX + ";" + s.PosY + ";" + s.ZoomX + ";" + s.ZoomY + ";" + s.AngX + ";" + s.AngY + ";" + s.AngZ);
						i++;
					}
				}
				catch (Exception ex) {
					MessageBox.Show(ex.Message, "Erreur sauvegarde séquence.");
				}
				if (sw != null)
					sw.Close();
			}
		}

		private void DataGridViewSeq_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			int v = Utils.ConvertToInt(dataGridViewSeq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			Sequence s = lstSeq[e.RowIndex];
			switch (e.ColumnIndex) {
				case 1:
					s.PosX = v;
					break;
				case 2:
					s.PosY = v;
					break;
				case 3:
					s.ZoomX = v;
					break;
				case 4:
					s.ZoomX = v;
					break;
				case 5:
					s.AngX = v;
					break;
				case 6:
					s.AngY = v;
					break;
				case 7:
					s.AngZ = v;
					break;
			}
		}
	}
}
