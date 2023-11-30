using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public class DirectBitmap : IDisposable {
	public Bitmap Bitmap { get; private set; }
	public uint[] tabBits { get; private set; }
	public bool Disposed { get; private set; }
	public int Height { get; private set; }
	public int Width { get; private set; }
	public int Length { get { return Width * Height; } }
	public int Tps { get; set; }

	protected GCHandle BitsHandle { get; private set; }

	public DirectBitmap(int width, int height) {
		CreateBitmap(width, height);
	}

	public void CopyBits(DirectBitmap source) {
		Array.Copy(source.tabBits, tabBits, tabBits.Length);
	}

	private void CreateBitmap(int width, int height) {
		Width = width;
		Height = height;
		tabBits = new uint[width * height];
		BitsHandle = GCHandle.Alloc(tabBits, GCHandleType.Pinned);
		Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppRgb, BitsHandle.AddrOfPinnedObject());
	}

	public void Fill(int c) {
		for (int i = 0; i < tabBits.Length; i++)
			tabBits[i] = (uint)c;
	}

	public void SetPixel(int x, int y, int c) {
		if (x >= 0 && y >= 0 && y < Height && x < Width)
			tabBits[x + (y * Width)] = (uint)c | 0xFF000000;
	}

	public void SetPixel(int x, int y, RvbColor color) {
		SetPixel(x, y, color.GetColorArgb);
	}

	public int GetPixel(int x, int y) {
		return (int)(tabBits[y < Height ? (x + (y * Width)) : 0] & 0xFFFFFF);
	}

	public void SetHorLine(int pixelX, int pixelY, int lineLength, int c, bool increment = false) {
		uint color = (uint)c | 0xFF000000;
		int index = pixelX + (pixelY * Width);
		for (; lineLength-- > 0;) {
			if (index < Length)
				tabBits[index] = color;

			index++;
			if (increment)
				color += 2381;
		}
	}

	public void DrawLine(int x1, int y1, int x2, int y2, int c, bool selected) {
		if (x2 < x1) {
			int a = x2;
			x2 = x1;
			x1 = a;
			a = y2;
			y2 = y1;
			y1 = a;
		}
		int dx = x2 - x1;
		if (dx == 0 && y1 > y2) {
			int a = y2;
			y2 = y1;
			y1 = a;
		}
		int dy = y2 - y1;
		int e;
		if (dx != 0) {
			if (dy != 0) {
				if (dy > 0) {
					if (dx >= dy) {
						e = dx;
						dx <<= 1;
						dy <<= 1;
						while (x1 != x2) {
							SetPixel(x1, y1, selected ? (y1 << 13) + (y1 << 4) + (y1 << 22) + (x1 << 5) : c);
							x1++;
							e -= dy;
							if (e < 0) {
								y1++;
								e += dx;
							};
						}
					}
					else {
						e = dy;
						dy <<= 1;
						dx <<= 1;
						while (y1 != y2) {
							SetPixel(x1, y1, selected ? (y1 << 13) + (y1 << 4) + (y1 << 22) + (x1 << 5) : c);
							y1++;
							e -= dx;
							if (e < 0) {
								x1++;
								e += dy;
							}
						}
					}
				}
				else {
					if (dx >= -dy) {
						e = dx;
						dy <<= 1;
						dx <<= 1;
						while (x1 != x2) {
							SetPixel(x1, y1, selected ? (y1 << 13) + (y1 << 4) + (y1 << 22) + (x1 << 5) : c);
							x1++;
							e += dy;
							if (e < 0) {
								y1--;
								e += dx;
							}
						}
					}
					else {
						e = dy;
						dy <<= 1;
						dx <<= 1;
						while (y1 != y2) {
							SetPixel(x1, y1, selected ? (y1 << 13) + (y1 << 4) + (y1 << 22) + (x1 << 5) : c);
							y1--;
							e += dx;
							if (e > 0) {
								x1++;
								e += dy;
							}
						}
					}
				}
			}
			else {  // dy = 0 (et dx > 0)
				do {
					SetPixel(x1, y1, selected ? (y1 << 13) + (y1 << 4) + (y1 << 22) + (x1 << 5) : c);
					x1++;
				}
				while (x1 != x2);
			}
		}
		else {  // dx = 0
			if (dy != 0) {
				do {
					SetPixel(x1, y1, selected ? (y1 << 13) + (y1 << 4) + (y1 << 22) + (x1 << 5) : c);
					y1++;
				} while (y1 != y2);
			}
		}
	}

	public void Dispose() {
		if (!Disposed) {
			Disposed = true;
			Bitmap.Dispose();
			BitsHandle.Free();
		}
	}
}
