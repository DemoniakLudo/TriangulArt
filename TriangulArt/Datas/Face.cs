﻿using System;
using System.Collections.Generic;

namespace TriangulArt {
	[Serializable]
	public class Face {
		public int a, b, c;
		public int num;
		public byte pen = 1;

		public Face() {
		}

		public Face(int n, int a, int b, int c, byte p) {
			num = n;
			pen = p;
			SetNewVertex(a, b, c);
		}

		public void SetNewVertex(int a, int b, int c) {
			this.a = a;
			this.b = b;
			this.c = c;
		}

		public Triangle GetTriangleCalc(List<Vertex> lstVertex, byte pen, DirectBitmap bm = null) {
			return new Triangle((int)lstVertex[a].px, (int)lstVertex[a].py, (int)lstVertex[b].px, (int)lstVertex[b].py, (int)lstVertex[c].px, (int)lstVertex[c].py, pen, bm);
		}

		public int GetZFace(List<Vertex> lstVertex) {
			return (int)((lstVertex[a].pz + lstVertex[b].pz + lstVertex[c].pz) / 3);
		}
	}
}
