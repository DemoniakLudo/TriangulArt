using System;
using System.Collections.Generic;

namespace TriangulArt {
	[Serializable]
	public class Animation {
		public Objet objet = new Objet();
		public string exprPosX = "", exprPosY = "", exprZoomX = "", exprZoomY = "", exprAngX = "", exprAngY = "", exprAngZ = "";
		public int nbImages;
		public string nom;

		public Animation() {
		}

		public string AddEval(List<Sequence> lstSeq) {
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