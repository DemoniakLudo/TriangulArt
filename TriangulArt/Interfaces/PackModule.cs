using System.Drawing;
using System.Windows.Forms;

namespace TriangulArt {
	public partial class PackModule : Form {
		private const int MAX_OFFSET_ZX0 = 32640;
		private const int MAX_SCALE = 50;

		private Block ghostRoot;
		private Block[] deadArray;
		private int deadArraySize = 0;
		private int outputIndex, bitIndex, bitMask;
		private bool backTrack;

		public PackModule() {
			InitializeComponent();
		}

		private Block Allocate(int bits, int index, int offset, Block chain) {
			Block ptr;

			if (ghostRoot == null)
				ptr = new Block();
			else {
				ptr = ghostRoot;
				ghostRoot = ptr.ghostChain;
				if (ptr.chain != null && --ptr.chain.references == 0) {
					ptr.chain.ghostChain = ghostRoot;
					ghostRoot = ptr.chain;
				}
			}
			ptr.bits = bits;
			ptr.index = index;
			ptr.offset = offset;
			if (chain != null)
				chain.references++;

			ptr.chain = chain;
			ptr.references = 0;
			return ptr;
		}

		private int EliasGammaBits(int value) {
			int bits = 1;
			while ((value >>= 1) != 0)
				bits += 2;
			return bits;
		}

		private void WriteBit(int value, byte[] outputData) {
			if (backTrack) {
				if (value != 0)
					outputData[outputIndex - 1] |= 1;

				backTrack = false;
			}
			else {
				if (bitMask == 0) {
					bitMask = 128;
					bitIndex = outputIndex;
					outputData[outputIndex++] = 0;
				}
				if (value != 0)
					outputData[bitIndex] |= (byte)bitMask;

				bitMask >>= 1;
			}
		}

		private void WriteInterlacedEliasGammaZX0(int value, byte[] outputData, bool invertMode) {
			int i;

			for (i = 2; i <= value; i <<= 1)
				;
			i >>= 1;
			while ((i >>= 1) != 0) {
				WriteBit(0, outputData);
				WriteBit(invertMode ? (value & i) == 0 ? 1 : 0 : value & i, outputData);
			}
			WriteBit(1, outputData);
		}

		public int PackZX0(byte[] inputData, int inputSize, byte[] outputData, bool v2) {
			Show();
			int bits, length;
			int maxOffset = inputSize - 1 > MAX_OFFSET_ZX0 ? MAX_OFFSET_ZX0 : inputSize - 1 < 1 ? 1 : inputSize - 1;
			int dots = 0;
			Block[] lastLiteral = new Block[maxOffset + 1];
			Block[] lastMatch = new Block[maxOffset + 1];
			Block[] tabOptimal = new Block[inputSize + 1];
			int[] matchLength = new int[maxOffset + 1];
			int[] bestLength = new int[inputSize + 2];

			bestLength[2] = 2;
			Block chain = Allocate(-1, 0 - 1, 1, null);
			chain.references++;
			if (lastMatch[1] != null && --lastMatch[1].references == 0) {
				lastMatch[1].ghostChain = ghostRoot;
				ghostRoot = lastMatch[1];
			}
			lastMatch[1] = chain;
			for (int index = 0; index < inputSize; index++) {
				int bestLengthSize = 2;
				maxOffset = index > MAX_OFFSET_ZX0 ? MAX_OFFSET_ZX0 : index < 1 ? 1 : index;
				for (int offset = 1; offset <= maxOffset; offset++) {
					if (index != 0 && index >= offset && inputData[index] == inputData[index - offset]) {
						if (lastLiteral[offset] != null) {
							length = index - lastLiteral[offset].index;
							bits = lastLiteral[offset].bits + 1 + EliasGammaBits(length);
							chain = Allocate(bits, index, offset, lastLiteral[offset]);
							chain.references++;
							if (lastMatch[offset] != null && --lastMatch[offset].references == 0) {
								lastMatch[offset].ghostChain = ghostRoot;
								ghostRoot = lastMatch[offset];
							}
							lastMatch[offset] = chain;
							if (tabOptimal[index] == null || tabOptimal[index].bits > bits) {
								chain = lastMatch[offset];
								chain.references++;
								if (tabOptimal[index] != null && --tabOptimal[index].references == 0) {
									tabOptimal[index].ghostChain = ghostRoot;
									ghostRoot = tabOptimal[index];
								}
								tabOptimal[index] = chain;
							}
						}
						if (++matchLength[offset] > 1) {
							if (bestLengthSize < matchLength[offset]) {
								bits = tabOptimal[index - bestLength[bestLengthSize]].bits + EliasGammaBits(bestLength[bestLengthSize] - 1);
								do {
									bestLengthSize++;
									int bits2 = tabOptimal[index - bestLengthSize].bits + EliasGammaBits(bestLengthSize - 1);
									if (bits2 <= bits) {
										bestLength[bestLengthSize] = bestLengthSize;
										bits = bits2;
									}
									else
										bestLength[bestLengthSize] = bestLength[bestLengthSize - 1];

								} while (bestLengthSize < matchLength[offset]);
							}
							length = bestLength[matchLength[offset]];
							bits = tabOptimal[index - length].bits + 8 + EliasGammaBits((offset - 1) / 128 + 1) + EliasGammaBits(length - 1);
							if (lastMatch[offset] == null || lastMatch[offset].index != index || lastMatch[offset].bits > bits) {
								chain = Allocate(bits, index, offset, tabOptimal[index - length]);
								chain.references++;
								if (lastMatch[offset] != null && --lastMatch[offset].references == 0) {
									lastMatch[offset].ghostChain = ghostRoot;
									ghostRoot = lastMatch[offset];
								}
								lastMatch[offset] = chain;
								if (tabOptimal[index] == null || tabOptimal[index].bits > bits) {
									chain = lastMatch[offset];
									chain.references++;
									if (tabOptimal[index] != null && --tabOptimal[index].references == 0) {
										tabOptimal[index].ghostChain = ghostRoot;
										ghostRoot = tabOptimal[index];
									}
									tabOptimal[index] = chain;
								}
							}
						}
					}
					else {
						matchLength[offset] = 0;
						if (lastMatch[offset] != null) {
							length = index - lastMatch[offset].index;
							bits = lastMatch[offset].bits + 1 + EliasGammaBits(length) + (length << 3);
							chain = Allocate(bits, index, 0, lastMatch[offset]);
							chain.references++;
							if (lastLiteral[offset] != null && --lastLiteral[offset].references == 0) {
								lastLiteral[offset].ghostChain = ghostRoot;
								ghostRoot = lastLiteral[offset];
							}
							lastLiteral[offset] = chain;
							if (tabOptimal[index] == null || tabOptimal[index].bits > bits) {
								chain = lastLiteral[offset];
								chain.references++;
								if (tabOptimal[index] != null && --tabOptimal[index].references == 0) {
									tabOptimal[index].ghostChain = ghostRoot;
									ghostRoot = tabOptimal[index];
								}
								tabOptimal[index] = chain;
							}
						}
					}
				}
				if (index * MAX_SCALE / inputSize > dots) {
					progressBar1.Value = 100 * ++dots / MAX_SCALE;
					Application.DoEvents();
				}
			}
			Block prev = null, next, optimal = tabOptimal[inputSize - 1];
			int outputSize = (optimal.bits + 25) / 8;
			while (optimal != null) {
				next = optimal.chain;
				optimal.chain = prev;
				prev = optimal;
				optimal = next;
			}
			outputIndex = 0;
			bitMask = 0;
			int lastOffset = 1;
			int inputIndex = 0;
			backTrack = true;
			for (optimal = prev.chain; optimal != null; prev = optimal, optimal = optimal.chain) {
				length = optimal.index - prev.index;

				if (optimal.offset == 0) {
					WriteBit(0, outputData);
					WriteInterlacedEliasGammaZX0(length, outputData, false);
					for (int i = 0; i < length; i++)
						outputData[outputIndex++] = inputData[inputIndex++];
				}
				else if (optimal.offset == lastOffset) {
					WriteBit(0, outputData);
					WriteInterlacedEliasGammaZX0(length, outputData, false);
					inputIndex += length;
				}
				else {
					WriteBit(1, outputData);
					WriteInterlacedEliasGammaZX0((optimal.offset - 1) / 128 + 1, outputData, v2);
					outputData[outputIndex++] = (byte)((127 - (optimal.offset - 1) % 128) << 1);
					backTrack = true;
					WriteInterlacedEliasGammaZX0(length - 1, outputData, false);
					inputIndex += length;
					lastOffset = optimal.offset;
				}
			}
			WriteBit(1, outputData);
			WriteInterlacedEliasGammaZX0(256, outputData, v2);
			Hide();
			return outputSize;
		}
	}

	public class Block {
		public Block chain, ghostChain;
		public int bits, index, offset, references;
	}
}
