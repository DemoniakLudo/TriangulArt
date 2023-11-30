using System;
using System.Collections.Generic;

namespace TriangulArt {
	[Serializable]
	public class Animation {
		public Objet objet = new Objet();
		public string exprPosX = "", exprPosY = "", exprZoomX = "", exprZoomY = "", exprAngX = "", exprAngY = "", exprAngZ = "";
		public List<Sequence> lstSeq = new List<Sequence>();
		public bool withExpression = false;
		private string nom;
		public string Nom {
			get { return nom; }
			set { nom = value; }
		}
		
		public void Clear() {
			lstSeq.Clear();
		}

		public void Add(double posx, double posy, double zoomx, double zoomy, double angx, double angy, double angz) {
			lstSeq.Add(new Sequence(posx, posy, zoomx, zoomy, angx, angy, angz));
		}

		public void DrawObj(int index, DirectBitmap bmpLock, DirectBitmap bmpCalc, List<Triangle> lstTriangle = null) {
			if (lstTriangle != null)
				bmpCalc.Fill(0xFFFFFF);

			Sequence s = lstSeq[index];
			objet.DrawObj(bmpLock, s.posx, s.posy, s.zoomx, s.zoomy, s.angx, s.angy, s.angz, -1, -1, lstTriangle, bmpCalc);
		}

		public string AddEval() {
			MathParser p = new MathParser('.');
			string champ = "", err = "";
			int pos = lstSeq.Count;
			lstSeq.Add(new Sequence());
			try {
				if (exprPosX != "") {
					champ = "PosX";
					lstSeq[pos].posx = (int)p.Parse(exprPosX, pos, false);
				}
				if (exprPosY != "") {
					champ = "PosY";
					lstSeq[pos].posy = (int)p.Parse(exprPosY, pos, false);
				}
				if (exprZoomX != "") {
					champ = "ZoomX";
					lstSeq[pos].zoomx = (int)p.Parse(exprZoomX, pos, false);
				}
				if (exprZoomY != "") {
					champ = "ZoomY";
					lstSeq[pos].zoomy = (int)p.Parse(exprZoomY, pos, false);
				}
				if (exprAngX != "") {
					champ = "AngX";
					lstSeq[pos].angx = (int)p.Parse(exprAngX, pos, false);
				}
				if (exprAngY != "") {
					champ = "AngY";
					lstSeq[pos].angy = (int)p.Parse(exprAngY, pos, false);
				}
				if (exprAngZ != "") {
					champ = "AngZ";
					lstSeq[pos].angz = (int)p.Parse(exprAngZ, pos, false);
				}
			}
			catch (Exception ex) {
				err = champ += " : " + ex.Message;
			}
			return err;
		}
	}
}