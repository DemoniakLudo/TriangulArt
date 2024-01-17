﻿using System;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class CpcEmul : Form {

		static public byte[] Code3D = {
			0xF3,0x31,0x00,0x02,0x01,0x8C,0x7F,0xED,0x49,0x01,0x0C,0xBC,0xED,0x49,0xDD,0x21,
			0x00,0x08,0xDD,0x7E,0x00,0x3C,0x28,0xF6,0x06,0xF5,0xED,0x78,0x1F,0x30,0xF9,0x3E,
			0xC0,0x57,0xEE,0x32,0x32,0x9A,0x03,0xEE,0x72,0x32,0x20,0x02,0x1F,0x1F,0x06,0xBD,
			0xED,0x79,0xCB,0xBA,0x1E,0x00,0xED,0x53,0x3C,0x02,0xAF,0x11,0x00,0x00,0x26,0x03,
			0x6F,0x08,0x29,0x7E,0x2C,0x66,0x6F,0x19,0x54,0x5D,0xCB,0xBC,0xCB,0xF4,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,
			0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0xED,0xA0,0x08,0x3C,
			0xFE,0xA8,0xDA,0x3B,0x02,0xCD,0x26,0x03,0xDD,0x7E,0x06,0x01,0x07,0x00,0xDD,0x09,
			0x17,0x30,0xF2,0xC3,0x12,0x02,0xDD,0x7E,0x06,0x87,0x87,0x32,0x9C,0x03,0xDD,0x46,
			0x00,0xDD,0x4E,0x01,0xDD,0x56,0x02,0xDD,0x5E,0x03,0xDD,0x66,0x04,0xDD,0x6E,0x05,
			0x7C,0x90,0x30,0x02,0xED,0x44,0x32,0x56,0x04,0x3E,0x02,0x8F,0x32,0x5D,0x04,0x7C,
			0x92,0x30,0x02,0xED,0x44,0x32,0x7E,0x04,0x3E,0x06,0x8F,0x32,0x83,0x04,0x7D,0x32,
			0x77,0x04,0x91,0x67,0x7D,0x93,0x32,0x88,0x04,0x7B,0x32,0x63,0x04,0x91,0x6F,0x7A,
			0x90,0x30,0x02,0xED,0x44,0x32,0x69,0x04,0x3E,0x06,0x8F,0x32,0x70,0x04,0x79,0xBB,
			0x4A,0x11,0x00,0x00,0x28,0x01,0x48,0xC5,0xD9,0xC1,0x26,0x03,0x6F,0x08,0x79,0xB8,
			0x30,0x02,0x48,0x47,0x0C,0x29,0x5E,0x23,0x56,0xCB,0xF2,0x21,0x00,0x05,0x78,0x1F,
			0x30,0x0E,0x83,0x30,0x01,0x14,0x5F,0x1A,0xE6,0xAA,0xB6,0x12,0x04,0x13,0x18,0x05,
			0x83,0x30,0x01,0x14,0x5F,0x2C,0x79,0x90,0xFE,0x02,0xDA,0x48,0x04,0xE6,0xFE,0xD6,
			0x81,0x2F,0x32,0xC7,0x03,0x7E,0x18,0xFE,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,
			0x12,0x13,0x12,0x13,0x12,0x13,0x12,0x13,0x79,0x90,0x1F,0x30,0x06,0x2C,0x1A,0xE6,
			0x55,0xB6,0x12,0xD9,0x7B,0xC6,0x00,0x38,0x03,0xBC,0x38,0x04,0x94,0x04,0x18,0xF9,
			0x5F,0x08,0xFE,0xFE,0x28,0x16,0x08,0x7A,0xC6,0xC6,0x38,0x03,0xBD,0x38,0x04,0x95,
			0x0C,0x18,0xF9,0x57,0x08,0x3C,0xFE,0xFE,0xDA,0x87,0x03,0xC9,0x08,0x3E,0x3E,0x32,
			0x69,0x04,0x3E,0x3E,0x32,0x70,0x04,0x2E,0x2E,0xAF,0x57,0x18,0xDB,0x00,0x00,0x00,
			0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
			0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
			0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
			0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
			0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
			0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
			0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,

			0x00,0x00,0x00,0x00,0x40,0xC0,0x80,0x00,0x04,0x0C,0x08,0x00,0x44,0xCC,0x88,0x00,
			0x10,0x30,0x20,0x00,0x50,0xF0,0xA0,0x00,0x14,0x3C,0x28,0x00,0x54,0xFC,0xA8,0x00,
			0x01,0x03,0x02,0x00,0x41,0xC3,0x82,0x00,0x05,0x0F,0x0A,0x00,0x45,0xCF,0x8A,0x00,
			0x11,0x33,0x22,0x00,0x51,0xF3,0xA2,0x00,0x15,0x3F,0x2A,0x00,0x55,0xFF,0xAA,0x00};

		private bool finMain = false;
		private Desasm desasm = new Desasm();

		private void DoRefresh() {
			string str = "";
			desasm.SetLigne(Z80.PC.Word, ref str);
			Instr.Text = str;
			AF.Text = Z80.AF.Word.ToString("X4");
			BC.Text = Z80.BC.Word.ToString("X4");
			DE.Text = Z80.DE.Word.ToString("X4");
			HL.Text = Z80.HL.Word.ToString("X4");
			AF_.Text = Z80._AF.Word.ToString("X4");
			BC_.Text = Z80._BC.Word.ToString("X4");
			DE_.Text = Z80._DE.Word.ToString("X4");
			HL_.Text = Z80._HL.Word.ToString("X4");
			PC.Text = Z80.PC.Word.ToString("X4");
			SP.Text = Z80.SP.Word.ToString("X4");
			IX.Text = Z80.IX.Word.ToString("X4");
			IY.Text = Z80.IY.Word.ToString("X4");
			I.Text = Z80.IR.High.ToString("X2");
			R.Text = Z80.IR.Low.ToString("X2");
			IM.Text = Z80.InterruptMode.ToString();
			pictureBox1.Refresh();
			Application.DoEvents();
		}

		public CpcEmul() {
			InitializeComponent();
			desasm.Init();
			Z80.Init();
			PPI.Init();
			CRTC.Init();
			pictureBox1.Image = VGA.Init(pictureBox1.Width, pictureBox1.Height);
			VGA.CopyMemory(Code3D, 0x200);
		}

		public void SetCrtcRegister(int numReg, int val) {
			CRTC.RegsCRTC[numReg] = val;
		}

		public void SetColor(int pen, int col) {
			VGA.SetColor(pen, col);
		}

		public void POKE8(int adr, byte value) {
			VGA.POKE8(adr, value);
		}

		public void POKE16(int adr, int value) {
			VGA.POKE16((ushort)adr, (ushort)value);
		}

		public void Run() {
			Z80.PC.Word = 0x200;
			int nbCycles = 0;
			finMain = false;
			Show();
			while (!finMain) {
				int cycle = Z80.ExecInstr();
				nbCycles += cycle;
				bool DoResync = CRTC.CycleCRTC(cycle);
				if ((DoResync && nbCycles > 1000) || nbCycles > 100000) {
					DoRefresh();
					nbCycles = 0;
				}
			}
		}

		private void BpStop_Click(object sender, EventArgs e) {
			finMain = true;
			Hide();
		}
	}
}
