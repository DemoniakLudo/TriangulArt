using System;
using System.Collections.Generic;
using System.IO;

namespace TriangulArt {
	[Serializable]
	public class Projet {
		public List<Datas> lstData = new List<Datas>();
		public int nbData = 0, selData = 0;

		public Datas AddData() {
			selData = lstData.Count;
			Datas d = new Datas();
			lstData.Add(d);
			nbData++;
			return d;
		}

		public Datas SelectImage(int index) {
			if (index >= 0 && index < lstData.Count) {
				selData = index;
				return lstData[selData];
			}
			return null;
		}

		public Datas SelImage() {
			return lstData[selData];
		}

		public void SetImage(Datas d) {
			lstData[selData] = d;
		}

		public void GenereSourceAsm(string fileName) {
			StreamWriter sw = GenereAsm.OpenAsm(fileName);
			foreach (Datas d in lstData) {
				GenereAsm.GenereDatas(sw, d, d.nomImage, d.cpcPlus);
			}
			GenereAsm.CloseAsm(sw);
		}
	}
}
