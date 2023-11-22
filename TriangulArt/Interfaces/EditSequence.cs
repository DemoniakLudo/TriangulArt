using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TriangulArt {
	public partial class EditSequence : Form {
		private FullSequence seq;

		public EditSequence(FullSequence s) {
			InitializeComponent();
			seq = s;
			DisplaySequence();
		}

		private void DisplaySequence() {
			dataGridViewSeq.Rows.Clear();
			txbExprAx.Text = seq.exprPosX;
			txbExprAy.Text = seq.exprPosY;
			txbExprZx.Text = seq.exprZoomX;
			txbExprZy.Text = seq.exprZoomY;
			txbExprAx.Text = seq.exprAngX;
			txbExprAy.Text = seq.exprAngY;
			txbExprAz.Text = seq.exprAngZ;
			int i = 0;
			foreach (Sequence s in seq.lstSeq)
				dataGridViewSeq.Rows.Add(i++, s.PosX, s.PosY, s.ZoomX, s.ZoomY, s.AngX, s.AngY, s.AngZ);
		}

		private void DataGridViewSeq_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			int v = Utils.ConvertToInt(dataGridViewSeq.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			Sequence s = seq.lstSeq[e.RowIndex];
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

		private void BpImportSequence_Click(object sender, EventArgs e) {
			OpenFileDialog of = new OpenFileDialog { Filter = "Fichiers XML (*.XML) |*.xml|Fichiers CSV (*.csv)|*.csv" };
			if (of.ShowDialog() == DialogResult.OK) {
				switch (of.FilterIndex) {
					case 1:
						FileStream fileSeq = File.Open(of.FileName, FileMode.Open);
						try {
							seq = (FullSequence)new XmlSerializer(typeof(FullSequence)).Deserialize(fileSeq);
						}
						catch (Exception ex) {
							MessageBox.Show(ex.Message, "Erreur lecture séquence.");
						}
						fileSeq.Close();
						break;

					case 2:
						seq.Clear();
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
										seq.Add(px, py, zx, zy, ax, ay, az);
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

						break;
				}
				DisplaySequence();
			}
		}

		private void BpExportSequence_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog { Filter = "Fichiers XML (*.XML) |*.xml|Fichiers CSV (*.csv)|*.csv" };
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				switch (dlg.FilterIndex) {
					case 1:
						FileStream file = File.Open(dlg.FileName, FileMode.Create);
						//try {
							new XmlSerializer(typeof(FullSequence)).Serialize(file, seq);
						//}
						//catch (Exception ex) {
						//	MessageBox.Show(ex.Message, "Erreur sauvegarde séquence.");
						//}
						file.Close();
						break;

					case 2:
						StreamWriter sw = null;
						try {
							sw = File.CreateText(dlg.FileName);
							int i = 0;
							sw.WriteLine("Numéro Frame;Position X;Position Y;Zoom X;Zoom Y;Angle X;Angle Y;Angle Z");
							foreach (Sequence s in seq.lstSeq) {
								sw.WriteLine(i + ";" + s.PosX + ";" + s.PosY + ";" + s.ZoomX + ";" + s.ZoomY + ";" + s.AngX + ";" + s.AngY + ";" + s.AngZ);
								i++;
							}
						}
						catch (Exception ex) {
							MessageBox.Show(ex.Message, "Erreur sauvegarde séquence.");
						}
						if (sw != null)
							sw.Close();
						break;
				}
			}
		}

		private void bpGenerate_Click(object sender, EventArgs e) {
			txbError.Text = "";
			seq.exprPosX = txbExprX.Text;
			seq.exprPosY = txbExprY.Text;
			seq.exprZoomX = txbExprZx.Text;
			seq.exprZoomY = txbExprZy.Text;
			seq.exprAngX = txbExprAx.Text;
			seq.exprAngY = txbExprAy.Text;
			seq.exprAngZ = txbExprAz.Text;
			string err = "";
			for (int i = 0; i < seq.lstSeq.Count; i++) {
				err = seq.Eval(i);
				if (err != "")
					break;
			}
			txbError.Text = err;
			DisplaySequence();
		}
	}
}
