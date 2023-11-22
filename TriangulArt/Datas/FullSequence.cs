using System;
using System.Collections.Generic;

namespace TriangulArt {
	[Serializable]
	public class FullSequence {
		public string exprPosX, exprPosY, exprZoomX, exprZoomY, exprAngX, exprAngY, exprAngZ;
		public List<Sequence> lstSeq = new List<Sequence>();

		public void Clear() {
			lstSeq.Clear();
			exprPosX = exprPosY = exprZoomX = exprZoomY = exprAngX = exprAngY = exprAngZ = "";
		}

		public void Add(double posx, double posy, double zoomx, double zoomy, double angx, double angy, double angz) {
			lstSeq.Add(new Sequence(posx, posy, zoomx, zoomy, angx, angy, angz));
		}

		public string Eval(int pos) {
			MathParser p = new MathParser('.');
			string champ = "", err = "";
			try {
				if (exprPosX != "") {
					champ = "PosX";
					lstSeq[pos].PosX = (int)p.Parse(exprPosX, pos, false);
				}
				if (exprPosY != "") {
					champ = "PosY";
					lstSeq[pos].PosY = (int)p.Parse(exprPosY, pos, false);
				}
				if (exprZoomX != "") {
					champ = "ZoomX";
					lstSeq[pos].ZoomX = (int)p.Parse(exprZoomX, pos, false);
				}
				if (exprZoomY != "") {
					champ = "ZoomY";
					lstSeq[pos].ZoomY = (int)p.Parse(exprZoomY, pos, false);
				}
				if (exprAngX != "") {
					champ = "AngX";
					lstSeq[pos].AngX = (int)p.Parse(exprAngX, pos, false);
				}
				if (exprAngY != "") {
					champ = "AngY";
					lstSeq[pos].AngY = (int)p.Parse(exprAngY, pos, false);
				}
				if (exprAngZ != "") {
					champ = "AngZ";
					lstSeq[pos].AngZ = (int)p.Parse(exprAngZ, pos, false);
				}
			}
			catch (Exception ex) {
				err = champ += " : " + ex.Message;
			}
			return err;
		}
	}
}