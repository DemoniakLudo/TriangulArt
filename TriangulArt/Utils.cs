namespace TriangulArt {
	public class Utils {
		static public int ConvertToInt(object v) {
			int r = 0;
			int.TryParse(v.ToString(), out r);
			return r;
		}

		static public double ConvertToDouble(object v) {
			double r = 0;
			double.TryParse(v.ToString(), out r);
			return r;
		}
	}
}
