using System;

namespace TriangulArt {
	[Serializable]
	public class Sequence {
		public double posx, posy, zoomx, zoomy, angx, angy, angz;

		public Sequence() {
		}

		public Sequence(double px, double py, double zx, double zy, double ax, double ay, double az) {
			posx = px;
			posy = py;
			zoomx = zx;
			zoomy = zy;
			angx = ax;
			angy = ay;
			angz = az;
		}
	}
}
