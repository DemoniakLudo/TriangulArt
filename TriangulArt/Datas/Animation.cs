using System;
using System.Collections.Generic;

namespace TriangulArt {
	[Serializable]
	public class Animation {
		public Objet objet = new Objet();
		public string exprPosX, exprPosY, exprZoomX, exprZoomY, exprAngX, exprAngY, exprAngZ;
		public List<Sequence> lstSeq = new List<Sequence>();

		public void Clear() {
			lstSeq.Clear();
			exprPosX = exprPosY = exprZoomX = exprZoomY = exprAngX = exprAngY = exprAngZ = "";
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

		public void RebuildObject() {
			for (int nf = 0; nf < objet.lstFace.Count; nf++) {
				Face f = objet.lstFace[nf];
				for (int nv = 0; nv < objet.lstVertex.Count; nv++) {
					Vertex v = objet.lstVertex[nv];
					if (v.px == f.a.px && v.py == f.a.py && v.pz == f.a.pz && v.x == f.a.x && v.y == f.a.y && v.z == f.a.z)
						f.a=v;

					if (v.px == f.b.px && v.py == f.b.py && v.pz == f.b.pz && v.x == f.b.x && v.y == f.b.y && v.z == f.b.z)
						f.b=v;

					if (v.px == f.c.px && v.py == f.c.py && v.pz == f.c.pz && v.x == f.c.x && v.y == f.c.y && v.z == f.c.z)
						f.c=v;
				}
			}
		}

		public string Eval(int pos) {
			MathParser p = new MathParser('.');
			string champ = "", err = "";
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