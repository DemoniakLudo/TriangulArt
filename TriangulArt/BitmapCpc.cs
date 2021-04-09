using System;
using System.Drawing;

public class BitmapCpc {
	private const int maxColsCpc = 96;
	private const int maxLignesCpc = 272;

	static private byte[] bufTmp = new byte[0x10000];
	public byte[] bmpCpc = new byte[0x10000];

	static public int[] Palette = { 1, 24, 20, 6, 26, 0, 2, 7, 10, 12, 14, 16, 18, 22, 1, 14, 1 };
	static public int[] tabOctetMode = { 0x00, 0x80, 0x08, 0x88, 0x20, 0xA0, 0x28, 0xA8, 0x02, 0x82, 0x0A, 0x8A, 0x22, 0xA2, 0x2A, 0xAA };
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

	static public byte[,,,] spritesHard = new byte[4, 16, 16, 16];
	static public int[] paletteSprite = new int[16];

	static public bool cpcPlus = false;
	static private int nbCol = 64;
	static public int NbCol { get { return nbCol; } }
	static public int TailleX {
		get { return nbCol << 3; }
	}
	static private int nbLig = 256;
	static public int NbLig { get { return nbLig; } }
	static public int TailleY {
		get { return nbLig << 1; }
	}
	static public int BitmapSize { get { return nbCol + GetAdrCpc((TailleY & 0x3F8) - 2); } }

	public bool isCalc = false;

	public BitmapCpc() {
	}

	public BitmapCpc(byte[] source, int offset) {
		Array.Copy(source, offset, bmpCpc, 0, source.Length - offset);
	}

	public BitmapCpc(byte[] source) {
		Array.Copy(source, bmpCpc, source.Length);
	}

	public RvbColor GetColorPal(int palEntry) {
		int col = Palette[palEntry];
		return cpcPlus ? new RvbColor((byte)((col & 0x0F) * 17), (byte)(((col & 0xF00) >> 8) * 17), (byte)(((col & 0xF0) >> 4) * 17)) : RgbCPC[col < 27 ? col : 0];
	}

	private void SetPalette(byte[] palStart, int startAdr, bool plus) {
		for (int i = 0; i < 16; i++)
			Palette[i] = plus ? ((palStart[startAdr + 1 + (i << 1)] << 4) & 0xF0) + (palStart[startAdr + 1 + (i << 1)] >> 4) + (palStart[startAdr + 2 + (i << 1)] << 8) : palStart[startAdr + i + 1];
	}

	static public int GetAdrCpc(int y) {
		int adrCPC = (y >> 4) * nbCol + (y & 14) * 0x400;
		if (y > 255 && (nbCol * nbLig > 0x4000))
			adrCPC += 0x3800;

		return adrCPC;
	}

	private int GetPalCPC(int c) {
		if (cpcPlus) {
			byte b = (byte)((c & 0x0F) * 17);
			byte r = (byte)(((c & 0xF0) >> 4) * 17);
			byte v = (byte)(((c & 0xF00) >> 8) * 17);
			return (int)(r + (v << 8) + (b << 16) + 0xFF000000);
		}
		return RgbCPC[c < 27 ? c : 0].GetColor;
	}

	public void CreeBmpCpc(DirectBitmap bmpLock, int lignestart = 0) {
		Array.Clear(bmpCpc, 0, bmpCpc.Length);
		for (int y = 0; y < TailleY; y += 2) {
			int adrCPC = GetAdrCpc(y);
			for (int x = 0; x < TailleX; x += 8) {
				byte pen = 0, octet = 0, decal = 0;
				for (int p = 0; p < 8; p += 2) {
					RvbColor col = bmpLock.GetPixelColor(x + p, y);
					for (pen = 0; pen < 4; pen++) {
						if (cpcPlus) {
							if ((col.v >> 4) == (Palette[pen] >> 8) && (col.b >> 4) == ((Palette[pen] >> 4) & 0x0F) && (col.r >> 4) == (Palette[pen] & 0x0F))
								break;
						}
						else {
							RvbColor fixedCol = RgbCPC[Palette[pen]];
							if (fixedCol.r == col.r && fixedCol.b == col.b && fixedCol.v == col.v)
								break;
						}
					}
					octet |= (byte)(tabOctetMode[pen % 16] >> (decal++));
				}
				bmpCpc[adrCPC + (x >> 3)] = octet;
			}
		}
	}

	public void CreeBmpCpcForceMode1(DirectBitmap bmpLock) {
		Array.Clear(bmpCpc, 0, bmpCpc.Length);
		for (int y = 0; y < TailleY; y += 2) {
			int adrCPC = GetAdrCpc(y);
			for (int x = 0; x < TailleX; x += 8) {
				byte pen = 0, octet = 0, decal = 0;
				for (int p = 0; p < 8; p += 2) {
					RvbColor col = bmpLock.GetPixelColor(x + p, y);
					for (pen = 0; pen < 4; pen++) {
						if (cpcPlus) {
							if ((col.v >> 4) == (Palette[pen] >> 8) && (col.b >> 4) == ((Palette[pen] >> 4) & 0x0F) && (col.r >> 4) == (Palette[pen] & 0x0F))
								break;
						}
						else {
							RvbColor fixedCol = RgbCPC[Palette[pen]];
							if (fixedCol.r == col.r && fixedCol.b == col.b && fixedCol.v == col.v)
								break;
						}
					}
					octet |= (byte)(tabOctetMode[Math.Min(3, (int)pen)] >> (decal++));
				}
				bmpCpc[adrCPC + (x >> 3)] = octet;
			}
		}
	}

	private int GetPenColor(DirectBitmap bmpLock, int x, int y) {
		int pen = 0;
		RvbColor col = bmpLock.GetPixelColor(x, y);
		if (cpcPlus) {
			for (pen = 0; pen < 16; pen++) {
				if ((col.v >> 4) == (Palette[pen] >> 8) && (col.r >> 4) == ((Palette[pen] >> 4) & 0x0F) && (col.b >> 4) == (Palette[pen] & 0x0F))
					break;
			}
		}
		else {
			for (pen = 0; pen < 16; pen++) {
				RvbColor fixedCol = RgbCPC[Palette[pen]];
				if (fixedCol.r == col.r && fixedCol.b == col.b && fixedCol.v == col.v)
					break;
			}
		}
		return pen;
	}

	public Bitmap CreateImageFromCpc(int length) {
		// Rendu dans un bitmap PC
		DirectBitmap loc = new DirectBitmap(nbCol << 3, nbLig * 2);
		for (int y = 0; y < nbLig << 1; y += 2) {
			int adrCPC = GetAdrCpc(y);
			int xBitmap = 0;
			for (int x = 0; x < nbCol; x++) {
				byte octet = bmpCpc[adrCPC + x];
				loc.SetHorLineDouble(xBitmap, y, 2, GetPalCPC(Palette[((octet >> 7) & 1) + ((octet >> 2) & 2)]));
				loc.SetHorLineDouble(xBitmap + 2, y, 2, GetPalCPC(Palette[((octet >> 6) & 1) + ((octet >> 1) & 2)]));
				loc.SetHorLineDouble(xBitmap + 4, y, 2, GetPalCPC(Palette[((octet >> 5) & 1) + ((octet >> 0) & 2)]));
				loc.SetHorLineDouble(xBitmap + 6, y, 2, GetPalCPC(Palette[((octet >> 4) & 1) + ((octet << 1) & 2)]));
				xBitmap += 8;
			}
		}
		return (loc.Bitmap);
	}
}
