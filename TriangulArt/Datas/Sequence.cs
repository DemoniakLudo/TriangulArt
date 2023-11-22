namespace TriangulArt {
	public class Sequence {
		private double posx, posy, zoomx, zoomy, angx, angy, angz;
		public int PosX {
			get { return (int)posx; }
			set { posx = value; }
		}
		public int PosY {
			get { return (int)posy; }
			set { posy = value; }
		}
		public int ZoomX {
			get { return (int)zoomx; }
			set { zoomx = value; }
		}
		public int ZoomY {
			get { return (int)zoomy; }
			set { zoomy = value; }
		}
		public int AngX {
			get { return (int)angx; }
			set { angx = value; }
		}
		public int AngY {
			get { return (int)angy; }
			set { angy = value; }
		}
		public int AngZ {
			get { return (int)angz; }
			set { angz = value; }
		}

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
