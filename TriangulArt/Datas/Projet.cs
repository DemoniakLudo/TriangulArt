using System;
using System.Collections.Generic;
using System.IO;

namespace TriangulArt {
	[Serializable]
	public class Projet {
		public List<Datas> lstData = new List<Datas>();
		public int selData = 0;
		public int mode = 1;
		public bool cpcPlus = false;
		public List<Animation> lstAnim = new List<Animation>();
		public byte tailleColonnes = 0;

		public Projet() {
		}

		public void Init() {
			AddData();
			lstAnim.Add(new Animation());
		}

		public Datas AddData() {
			selData = lstData.Count;
			Datas d = new Datas();
			lstData.Add(d);
			return d;
		}

		public void Clear() {
			lstData.Clear();
			lstAnim.Clear();
			Init();
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

		public void RemoveImage() {
			lstData.RemoveAt(selData);
			if (selData >= lstData.Count)
				selData--;
		}

		public void Clean(int width, ref int nbAvant, ref int nbApres) {
			nbAvant = nbApres = 0;
			foreach (Datas d in lstData) {
				nbAvant += d.GetTriangleActif();
				d.CleanUp(width);
				nbApres += d.GetTriangleActif();
			}
		}

		public void SendDataToCpc(CpcEmul cpc) {
			cpc.Run(tailleColonnes, lstData);
		}

		public void GenereSourceAsm(string fileName, bool modePolice, bool mode3D, bool zx0) {
			StreamWriter sw = GenereAsm.OpenAsm(fileName);
			if (zx0) {
				byte[] datas = new byte[0x10000];
				byte[] dataPack = new byte[0x10000];
				int posData = 0;
				foreach (Datas d in lstData) {
					for (int i = 0; i < d.lstTriangle.Count; i++) {
						Triangle t = d.lstTriangle[i];
						if (t.enabled) {
							int color = i < d.lstTriangle.Count - 1 ? t.color : t.color + 0x80;
							datas[posData++] = (byte)t.x1;
							datas[posData++] = (byte)t.y1;
							datas[posData++] = (byte)t.x2;
							datas[posData++] = (byte)t.y2;
							datas[posData++] = (byte)t.x3;
							datas[posData++] = (byte)t.y3;
							datas[posData++] = (byte)(i < d.lstTriangle.Count - 1 ? t.color : t.color + 0x80);
						}
					}
				}
				datas[posData++] = 0xFF;
				PackModule pk = new PackModule();
				int lpack = pk.PackZX0(datas, posData, dataPack, dataPack.Length);
				GenereAsm.GenereDatas(sw, dataPack, lpack, 16);
			}
			else
				foreach (Datas d in lstData)
					GenereAsm.GenereDatas(sw, d, d.nomImage, mode, cpcPlus, modePolice, mode3D);

			GenereAsm.CloseAsm(sw);
		}
	}
}
