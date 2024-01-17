using System;
using System.Collections.Generic;
using System.Drawing;
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

		private void CalcAdrEcr(CpcEmul cpc, int width) {
			int nbLignes = 16384 / width;
			int adrEcr = 0x8000;
			int adr = 0x600;
			for (int l = 0; l < nbLignes; l++) {
				cpc.POKE16(adr, adrEcr);
				adr += 2;
				adrEcr += 0x800;
				if ((adrEcr & 0x4000) != 0)
					adrEcr = adrEcr - 0x4000 + width;
			}
			cpc.POKE8(0x311, (byte)((nbLignes - 1) & 0xF8));
		}

		public void SendDataToCpc(CpcEmul cpc) {
			int adr = 0x800;
			foreach (Datas data in lstData) {
				for (int i = 0; i < data.lstTriangle.Count; i++) {
					Triangle t = data.lstTriangle[i];
					if (t.enabled) {
						cpc.POKE8(adr++, (byte)t.x1);
						cpc.POKE8(adr++, (byte)t.y1);
						cpc.POKE8(adr++, (byte)t.x2);
						cpc.POKE8(adr++, (byte)t.y2);
						cpc.POKE8(adr++, (byte)t.x3);
						cpc.POKE8(adr++, (byte)t.y3);
						cpc.POKE8(adr++, (byte)(i < data.lstTriangle.Count - 1 ? t.color : t.color + 0x80));
					}
				}
			}
			cpc.POKE8(adr++, 0xFF);
			switch (tailleColonnes) {
				case 0:
					cpc.SetCrtcRegister(1, 0x20);
					cpc.SetCrtcRegister(2, 0x2A);
					cpc.SetCrtcRegister(6, 0x20);
					cpc.SetCrtcRegister(7, 0x22);
					CalcAdrEcr(cpc, 64);
					break;

				case 1:
					cpc.SetCrtcRegister(1, 0x28);
					cpc.SetCrtcRegister(2, 0x2E);
					cpc.SetCrtcRegister(6, 0x19);
					cpc.SetCrtcRegister(7, 0x1E);
					CalcAdrEcr(cpc, 80);
					break;

				case 2:
					cpc.SetCrtcRegister(1, 0x30);
					cpc.SetCrtcRegister(2, 0x32);
					cpc.SetCrtcRegister(6, 0x15);
					cpc.SetCrtcRegister(7, 0x1C);
					CalcAdrEcr(cpc, 96);
					break;
			}
			for (int i = 0; i < 17; i++) {
				RvbColor col = PaletteCpc.GetColorPal(i < 16 ? i : 0);
				cpc.SetColor(i, (col.GetColorArgb));
			}
			cpc.Run();
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
