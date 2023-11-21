using System;
using System.IO;

public class PaletteCpc {
	static public int[] Palette = { 1, 24, 20, 6, 26, 0, 2, 7, 10, 12, 14, 16, 18, 22, 1, 14, 1 };
	public const int Lum0 = 0x00;
	public const int Lum1 = 0x66;
	public const int Lum2 = 0xFF;
	static public RvbColor[] RgbCPC = {
							new RvbColor( Lum0, Lum0, Lum0),
							new RvbColor( Lum0, Lum0, Lum1),
							new RvbColor( Lum0, Lum0, Lum2),
							new RvbColor( Lum1, Lum0, Lum0),
							new RvbColor( Lum1, Lum0, Lum1),
							new RvbColor( Lum1, Lum0, Lum2),
							new RvbColor( Lum2, Lum0, Lum0),
							new RvbColor( Lum2, Lum0, Lum1),
							new RvbColor( Lum2, Lum0, Lum2),
							new RvbColor( Lum0, Lum1, Lum0),
							new RvbColor( Lum0, Lum1, Lum1),
							new RvbColor( Lum0, Lum1, Lum2),
							new RvbColor( Lum1, Lum1, Lum0),
							new RvbColor( Lum1, Lum1, Lum1),
							new RvbColor( Lum1, Lum1, Lum2),
							new RvbColor( Lum2, Lum1, Lum0),
							new RvbColor( Lum2, Lum1, Lum1),
							new RvbColor( Lum2, Lum1, Lum2),
							new RvbColor( Lum0, Lum2, Lum0),
							new RvbColor( Lum0, Lum2, Lum1),
							new RvbColor( Lum0, Lum2, Lum2),
							new RvbColor( Lum1, Lum2, Lum0),
							new RvbColor( Lum1, Lum2, Lum1),
							new RvbColor( Lum1, Lum2, Lum2),
							new RvbColor( Lum2, Lum2, Lum0),
							new RvbColor( Lum2, Lum2, Lum1),
							new RvbColor( Lum2, Lum2, Lum2)
							};

	static public string CpcVGA = "TDU\\X]LEMVFW^@_NGORBSZY[JCK";

	static public bool cpcPlus = false;

	static public RvbColor GetColorPal(int palEntry) {
		int col = Palette[palEntry];
		return cpcPlus ? new RvbColor((byte)((col & 0x0F) * 17), (byte)(((col & 0xF00) >> 8) * 17), (byte)(((col & 0xF0) >> 4) * 17)) : RgbCPC[col < 27 ? col : 0];
	}

	static public byte GetNumPen(RvbColor c) {
		for (int k = 16; k <= 64; k += 16) {
			for (int i = 15; i >= 0; i--) {
				RvbColor p = GetColorPal(i);
				if (Math.Abs(c.r - p.r) < k && Math.Abs(c.b - p.b) < k && Math.Abs(c.v - p.v) < k)
					return (byte)i;
			}
		}
		return 0;
	}


	static public void SauvePalette(string NomFic, int mode) {
		int i;
		byte[] pal = new byte[239];

		pal[0] = (byte)mode;
		int indexPal = 3;
		if (cpcPlus) {
			for (i = 0; i < 16; i++)
				for (int j = 0; j < 4; j++) {
					pal[indexPal++] = (byte)CpcVGA[26 - ((Palette[i] >> 4) & 0x0F)];
					pal[indexPal++] = (byte)CpcVGA[26 - (Palette[i] & 0x0F)];
					pal[indexPal++] = (byte)CpcVGA[26 - ((Palette[i] >> 8) & 0x0F)];
				}
			pal[195] = pal[3];
			pal[196] = pal[4];
			pal[197] = pal[5];
		}
		else {
			for (i = 0; i < 16; i++)
				for (int j = 0; j < 12; j++)
					pal[indexPal++] = (byte)CpcVGA[Palette[i]];

			for (i = 0; i < 12; i++)
				pal[indexPal++] = pal[i + 3];
		}
		CpcAmsdos entete = Cpc.CreeEntete(NomFic, (short)-30711, (short)pal.Length, (short)-30711);
		BinaryWriter fp = new BinaryWriter(new FileStream(NomFic, FileMode.Create));
		fp.Write(Cpc.AmsdosToByte(entete));
		fp.Write(pal, 0, pal.Length);
		fp.Close();
	}

	static public bool LirePalette(string NomFic) {
		byte[] entete = new byte[0x80];
		byte[] pal = new byte[239];

		BinaryReader fp = new BinaryReader(new FileStream(NomFic, FileMode.Open));
		if (fp != null) {
			fp.Read(entete, 0, entete.Length);
			fp.Read(pal, 0, pal.Length);
			fp.Close();
			if (Cpc.CheckAmsdos(entete) && pal[0] < 11) {
				if (cpcPlus) {
					for (int i = 0; i < 16; i++) {
						int r = 0, v = 0, b = 0;
						for (int k = 26; k-- > 0;) {
							if (pal[3 + i * 12] == (byte)CpcVGA[k])
								r = (26 - k) << 4;

							if (pal[4 + i * 12] == (byte)CpcVGA[k])
								b = 26 - k;

							if (pal[5 + i * 12] == (byte)CpcVGA[k])
								v = (26 - k) << 8;
						}
						Palette[i] = r + v + b;
					}
				}
				else {
					for (int i = 0; i < 16; i++)
						for (int j = 0; j < 27; j++)
							if (pal[3 + i * 12] == (byte)CpcVGA[j])
								Palette[i] = j;
				}
				return (true);
			}
		}
		return (false);
	}
}

public class RvbColor {
	public byte r, v, b;

	public int GetColor { get { return b + (v << 8) + (r << 16); } }
	public int GetColorArgb { get { return b + (v << 8) + (r << 16) + (255 << 24); } }

	public RvbColor(byte compR, byte compV, byte compB) {
		r = compR;
		v = compV;
		b = compB;
	}

	public RvbColor(int value) {
		r = (byte)(value >> 16);
		v = (byte)(value >> 8);
		b = (byte)value;
	}
}
