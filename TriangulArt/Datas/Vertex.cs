using System;

namespace TriangulArt {
	[Serializable]
	public class Vertex {
		public double x, y, z;
		public double px, py, pz;

		public Vertex() {
		}

		public Vertex(double x, double y, double z) {
			SetNewCoord(x, y, z);
		}

		public void SetNewCoord(double x, double y, double z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public void SetPoint(double px, double py, double pz) {
			this.px = px;
			this.py = py;
			this.pz = pz;
		}
	}
}
