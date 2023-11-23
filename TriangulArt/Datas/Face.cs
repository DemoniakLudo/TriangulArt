using System;

namespace TriangulArt {
	[Serializable]
	public class Face {
		public int a, b, c;
		public int num;
		public byte pen = 1;

		public Face() {
		}

		public Face(int num, int a, int b, int c) {
			this.num = num;
			SetNewVertex(a, b, c);
		}

		public void SetNewVertex(int a, int b, int c) {
			this.a = a;
			this.b = b;
			this.c = c;
		}
	}
}
