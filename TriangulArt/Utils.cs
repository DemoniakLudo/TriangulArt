namespace TriangulArt {
	public class Utils {
		static public int ToInt(object v) {
			int r = 0;
			int.TryParse(v.ToString(), out r);
			return r;
		}

		static public double ToDouble(object v) {
			double r = 0;
			double.TryParse(v.ToString().Replace('.',','), out r);
			return r;
		}
	}
}
