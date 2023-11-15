namespace TriangulArt {
	public class Vertex {
		private double x, y, z;
		private int px, py, pz;

		public double X {
			get { return x; }
			set { x = value; }
		}

		public double Y {
			get { return y; }
			set { y = value; }
		}

		public double Z {
			get { return z; }
			set { z = value; }
		}

		public int Px {
			get { return px; }
			set { px = value; }
		}

		public int Py {
			get { return py; }
			set { py = value; }
		}

		public int Pz {
			get { return pz; }
			set { pz = value; }
		}

		public Vertex(double x, double y, double z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public void SetPoint(int px, int py, int pz) {
			this.px = px;
			this.py = py;
			this.pz = pz;
		}
	}
}
