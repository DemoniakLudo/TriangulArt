namespace TriangulArt {
	public class Face {
		private Vertex a, b, c;
		private int num;

		public Vertex GetA { get { return a; } }
		public Vertex GetB { get { return b; } }
		public Vertex GetC { get { return c; } }

		public int Num { get { return num; } }
		public RvbColor Color = new RvbColor(0);

		public Face(int num, Vertex a, Vertex b, Vertex c) {
			this.num = num;
			this.a = a;
			this.b = b;
			this.c = c;
		}
	}
}
