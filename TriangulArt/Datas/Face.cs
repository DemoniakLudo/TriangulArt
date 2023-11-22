using System;

namespace TriangulArt {
	[Serializable]
	public class Face {
		public Vertex a, b, c;
		public int num;
		public byte pen = 1;

		public Face() {
		}

		public Face(int num, Vertex a, Vertex b, Vertex c) {
			this.num = num;
			SetNewVertex(a, b, c);
		}

		public void SetNewVertex(Vertex a, Vertex b, Vertex c) {
			this.a = a;
			this.b = b;
			this.c = c;
		}
	}
}
