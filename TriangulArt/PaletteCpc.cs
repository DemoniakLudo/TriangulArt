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

	static public bool SetPaletteFromColor(RvbColor c, int newPen) {
		int found = -1;
		for (int i = 15; i >= 0; i--) {
			RvbColor p = GetColorPal(i);
			if (Math.Abs(c.r - p.r) < 16 && Math.Abs(c.b - p.b) < 16 && Math.Abs(c.v - p.v) < 16)
				found = i;
		}
		if (found == -1) {
			int r = c.r / 17;
			int v = c.v / 17;
			int b = c.b / 17;
			Palette[newPen] = (v << 8) + (b << 4) + r;
			return true;
		}
		return false;
	}

	static public void SauvePalette(string NomFic, int mode) {
		if (Path.GetExtension(NomFic).ToUpper() == ".KIT") {
			CpcAmsdos entete = Cpc.CreeEntete(Path.GetFileName(NomFic), -32768, 30, 0);
			BinaryWriter fp = new BinaryWriter(new FileStream(NomFic, FileMode.Create));
			fp.Write(Cpc.AmsdosToByte(entete));
			for (int i = 0; i < 16; i++) {
				int kit = Palette[i];
				byte c1 = (byte)(((kit & 0x0F) << 4) + ((kit & 0xF0) >> 4));
				byte c2 = (byte)(kit >> 8);
				fp.Write(c1);
				fp.Write(c2);
				fp.Close();
			}
		}
		else {
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
	}

	static public bool LirePalette(string NomFic) {
		if (File.Exists(NomFic)) {
			FileStream fileScr = new FileStream(NomFic, FileMode.Open, FileAccess.Read);
			byte[] entete = new byte[0x80];
			byte[] tabBytes = new byte[fileScr.Length - 0x80];
			fileScr.Read(entete, 0, entete.Length);
			fileScr.Read(tabBytes, 0, tabBytes.Length);
			fileScr.Close();
			if (Cpc.CheckAmsdos(entete)) {
				if (Path.GetExtension(NomFic).ToUpper() == ".KIT") {
					if ((tabBytes.Length == 30 || tabBytes.Length == 32)) {
						int start = 0;
						for (int i = tabBytes.Length == 32 ? 0 : 1; i < 16; i++) {
							int kit = tabBytes[start] + (tabBytes[start + 1] << 8);
							int col = (kit & 0xF00) + ((kit & 0x0F) << 4) + ((kit & 0xF0) >> 4);
							Palette[i] = col;
							start += 2;
						}
						return true;
					}
				}
				else {
					if (cpcPlus) {
						for (int i = 0; i < 16; i++) {
							int r = 0, v = 0, b = 0;
							for (int k = 26; k-- > 0;) {
								if (tabBytes[3 + i * 12] == (byte)CpcVGA[k])
									r = (26 - k) << 4;

								if (tabBytes[4 + i * 12] == (byte)CpcVGA[k])
									b = 26 - k;

								if (tabBytes[5 + i * 12] == (byte)CpcVGA[k])
									v = (26 - k) << 8;
							}
							Palette[i] = r + v + b;
						}
					}
					else {
						for (int i = 0; i < 16; i++)
							for (int j = 0; j < 27; j++)
								if (tabBytes[3 + i * 12] == (byte)CpcVGA[j])
									Palette[i] = j;
					}
					return true;
				}
			}
		}
		return false;
	}
}

public class RvbColor {
	public byte r, v, b;

	public int GetColorArgb { get { return b + (v << 8) + (r << 16) + (255 << 24); } }

	public RvbColor(byte compR, byte compV, byte compB) {
		r = compR;
		v = compV;
		b = compB;
	}
}
