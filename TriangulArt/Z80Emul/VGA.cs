﻿using System.Drawing;

static class VGA {
	public const int ROMINF_OFF = 0x04;
	public const int ROMSUP_OFF = 0x08;
	public const int BANK_SIZE = 0x4000;
	public const int MAX_ROMS = 256;
	public const int LOWER_ROM_INDEX = 255;
	public const int BASIC_ROM_INDEX = 0;
	private const int LOWER_ROM_OFFSET = 0x1FF * BANK_SIZE;
	static public byte[] ram = new byte[512 * BANK_SIZE];
	static public byte NumRomExt = 0;
	static private readonly int[][] TabPeek = new int[8][];
	static private readonly int[][] TabPoke = new int[8][];
	static public int MemoMode = 0;
	static public byte bank = 0;
	static private byte PenSelect;
	static private int MemoColor = 0xFF;
	static public int DecodeurAdresse = 0;
	static public int DelayGa = 0;
	static public int CntHSync = 0;
	static private DirectBitmap source = null;
	private static readonly int[][][] TabPoints = new int[4][][];
	static private int[] tabCoul = new int[32];

	static void SetPeekMode() {
		for (int b = 0; b < 8; b++) {
			TabPeek[b][0] = (DecodeurAdresse & ROMINF_OFF) == 0 ? LOWER_ROM_OFFSET : TabPoke[b][0];
			TabPeek[b][3] = (DecodeurAdresse & ROMSUP_OFF) == 0 ? (0x100 + NumRomExt) * BANK_SIZE : TabPoke[b][3];
		}
	}

	static public void POKE8(int adr, byte value) {
		ram[TabPoke[bank][adr >> 14] + (adr & 0x3FFF)] = value;
	}

	static public byte PEEK8(int adr) {
		return ram[TabPeek[bank][adr >> 14] + (adr & 0x3FFF)];
	}

	static public ushort PEEK16(int adr) {
		ushort r = ram[TabPeek[bank][adr >> 14] + (adr & 0x3FFF)];
		adr = adr + 1 & 0xFFFF;
		r += (ushort)(ram[TabPeek[bank][adr >> 14] + (adr & 0x3FFF)] << 8);
		return r;
	}

	static public void POKE16(ushort adr, ushort r) {
		ram[TabPoke[bank][adr >> 14] + (adr & 0x3FFF)] = (byte)r;
		adr++;
		ram[TabPoke[bank][adr >> 14] + (adr & 0x3FFF)] = (byte)(r >> 8);
	}

	static public void SyncColor() {
		if (MemoColor != 0xFF) {
			if (DelayGa == 0) {
				tabCoul[PenSelect] = PaletteCpc.RgbCPC[MemoColor].GetColorArgb;
				MemoColor = 0xFF;
			}
			else
				DelayGa--;
		}
	}

	static public void Write(int val) {
		int newVal = val & 0x1F;
		switch (val >> 6) {
			case 0:
				PenSelect = (byte)(newVal < 16 ? newVal : 16);
				break;

			case 1:
				MemoColor = newVal;
				break;

			case 2:
				MemoMode = val & 3;
				DecodeurAdresse = val;
				SetPeekMode();
				if ((val & 16) == 16) {
					CntHSync = 0;
					Z80.IRQ = 0;
				}
				break;

			case 3:
				bank = (byte)(val & 7);
				break;
		}
	}

	static public void WriteROM(int val) {
		NumRomExt = (byte)val;
		SetPeekMode();
	}

	static public void TraceMot(int x, int y, int adrMemCpc) {
		x <<= 1;
		y <<= 1;
		if (adrMemCpc < 0) {
			for (int i = 0; i < 16; i++) {
				source.SetPixelDoubleHeight(x + i, y, tabCoul[16]);
				if (i == 7)
					SyncColor();
			}
		}
		else {
			int oct = ram[adrMemCpc++];
			for (int i = 0; i < 16; i++) {
				source.SetPixelDoubleHeight(x + i, y, tabCoul[TabPoints[CRTC.LastMode][oct][i & 7]]);
				if (i == 7) {
					SyncColor();
					oct = ram[adrMemCpc];
				}
			}
		}
	}

	static public void CopyMemory(byte[] code, int startAdr) {
		for (int i = 0; i < code.Length; i++)
			POKE8(i + startAdr, code[i]);
	}

	static public void SetColor(int pen, int color) {
		tabCoul[pen] = color;
	}

	static public void FillMemory(byte value) {
		for (int i = 0; i < ram.Length; i++)
			ram[i] = value;
	}

	static public Bitmap Init(int width, int height, byte[] code = null, int startAdr = 0) {
		TabPeek[0] = new int[4] { 0x00000, 0x04000, 0x08000, 0x0C000 };
		TabPeek[1] = new int[4] { 0x00000, 0x04000, 0x08000, 0x1C000 };
		TabPeek[2] = new int[4] { 0x10000, 0x14000, 0x18000, 0x1C000 };
		TabPeek[3] = new int[4] { 0x00000, 0x0C000, 0x08000, 0x1C000 };
		TabPeek[4] = new int[4] { 0x00000, 0x10000, 0x08000, 0x0C000 };
		TabPeek[5] = new int[4] { 0x00000, 0x14000, 0x08000, 0x0C000 };
		TabPeek[6] = new int[4] { 0x00000, 0x18000, 0x08000, 0x0C000 };
		TabPeek[7] = new int[4] { 0x00000, 0x1C000, 0x08000, 0x0C000 };
		TabPoke[0] = new int[4] { 0x00000, 0x04000, 0x08000, 0x0C000 };
		TabPoke[1] = new int[4] { 0x00000, 0x04000, 0x08000, 0x1C000 };
		TabPoke[2] = new int[4] { 0x10000, 0x14000, 0x18000, 0x1C000 };
		TabPoke[3] = new int[4] { 0x00000, 0x0C000, 0x08000, 0x1C000 };
		TabPoke[4] = new int[4] { 0x00000, 0x10000, 0x08000, 0x0C000 };
		TabPoke[5] = new int[4] { 0x00000, 0x14000, 0x08000, 0x0C000 };
		TabPoke[6] = new int[4] { 0x00000, 0x18000, 0x08000, 0x0C000 };
		TabPoke[7] = new int[4] { 0x00000, 0x1C000, 0x08000, 0x0C000 };
		DecodeurAdresse = 0;
		SetPeekMode();
		for (int i = 0; i < 16; i++) {
			char c = PaletteCpc.CpcVGA[PaletteCpc.Palette[i]];
			Write(i);
			Write(c);
			SyncColor();
		}
		Write(0x8C);
		if (code != null)
			CopyMemory(code, startAdr);

		source = new DirectBitmap(width, height);
		for (int i = 0; i < 4; i++)
			TabPoints[i] = new int[256][];

		for (int i = 0; i < 256; i++) {
			int b0 = i & 1;
			int b1 = i & 2;
			int b2 = (i & 4) >> 1;
			int b3 = (i & 8) >> 2;
			int b4 = (i & 0x10) >> 4;
			int b5 = (i & 0x20) >> 5;
			int b6 = (i & 0x40) >> 6;
			int b7 = i >> 7;

			// Mode 0
			TabPoints[0][i] = new int[8];
			TabPoints[0][i][0] = TabPoints[0][i][1] = TabPoints[0][i][2] = TabPoints[0][i][3] = b7 + (b5 << 2) + b3 + (b1 << 2);
			TabPoints[0][i][4] = TabPoints[0][i][5] = TabPoints[0][i][6] = TabPoints[0][i][7] = b6 + (b4 << 2) + b2 + (b0 << 3);

			// Mode 1
			TabPoints[1][i] = new int[8];
			TabPoints[1][i][0] = TabPoints[1][i][1] = b7 + b3;
			TabPoints[1][i][2] = TabPoints[1][i][3] = b6 + b2;
			TabPoints[1][i][4] = TabPoints[1][i][5] = b5 + b1;
			TabPoints[1][i][6] = TabPoints[1][i][7] = b4 + (b0 << 1);

			// Mode 2
			TabPoints[2][i] = new int[8];
			TabPoints[2][i][0] = b7;
			TabPoints[2][i][1] = b6;
			TabPoints[2][i][2] = b5;
			TabPoints[2][i][3] = b4;
			TabPoints[2][i][4] = (b3 >> 1);
			TabPoints[2][i][5] = (b2 >> 1);
			TabPoints[2][i][6] = (b1 >> 1);
			TabPoints[2][i][7] = b0;

			// Mode 3
			TabPoints[3][i] = new int[8];
			TabPoints[3][i][0] = TabPoints[3][i][1] = TabPoints[3][i][2] = TabPoints[3][i][3] = b7 + b3;
			TabPoints[3][i][4] = TabPoints[3][i][5] = TabPoints[3][i][6] = TabPoints[3][i][7] = b6 + b2;
		}
		return source.Bitmap;
	}
}
