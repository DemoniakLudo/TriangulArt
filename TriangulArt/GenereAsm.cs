﻿using System;
using System.IO;

namespace TriangulArt {
	public class GenereAsm {
		static public StreamWriter OpenAsm(string fileName) {
			StreamWriter sw = File.CreateText(fileName);
			sw.WriteLine("; Généré par TriangulArt le " + DateTime.Now.ToString("dd/MM/yyyy (HH mm ss)"));
			return sw;
		}

		static public void GenereDatas(StreamWriter sw, Datas data, string nom, bool cpcPlus, bool modePolice) {
			int nbOctets = 0;
			string s = "";

			sw.WriteLine(";" + nom);
			if (!modePolice) {
				if (cpcPlus) {
					string line = "";
					for (int i = 0; i < 4; i++) {
						int c = PaletteCpc.Palette[i];
						line += (line != "" ? "," : "") + "#" + ((byte)(((c >> 4) & 0x0F) | (c << 4))).ToString("X2") + ",#" + ((byte)(c >> 8)).ToString("X2");
					}
					//sw.WriteLine("; 8 octets (4 mots) de palette");
					sw.WriteLine("	DB	" + line);
				}
				else {
					for (int i = 0; i < 4; i++)
						s += PaletteCpc.CpcVGA[data.palette[i]];

					//sw.WriteLine("; 4 octets de palette");
					sw.WriteLine("	DB	\"" + s + "\"");
				}
				int tps = (int)Math.Max(Math.Min(255, data.tpsAttente / 3.333333), 1);
				sw.WriteLine("	DB	#" + tps.ToString("X2") + "			; Tps d'affichage");
				sw.WriteLine("	DB	#" + data.modeRendu.ToString("X2") + "			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)");
				//sw.WriteLine(";");
			}
			//sw.WriteLine("; Donnees des triangles a afficher.");
			//sw.WriteLine("; Chaque frame contient un ou plusieurs trianges defini de la sorte :");
			//sw.WriteLine("; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur");
			//sw.WriteLine("; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand");
			//sw.WriteLine("; Seulement 1 octet par coordonnees (donc de 0 a 255...)");
			//sw.WriteLine("; le 7eme octet de la structure (la couleur) defini le pen mode 1");
			//sw.WriteLine("; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame");
			//sw.WriteLine(";");
			int xMax = 0;
			for (int i = 0; i < data.lstTriangle.Count; i++) {
				Triangle t = data.lstTriangle[i];
				int color = i < data.lstTriangle.Count - 1 ? t.color : t.color + 0x80;
				s = "	DB	#" + t.x1.ToString("X2") + ",#" + t.y1.ToString("X2") + ",#" + t.x2.ToString("X2") + ",#" + t.y2.ToString("X2") + ",#" + t.x3.ToString("X2") + ",#" + t.y3.ToString("X2") + (modePolice ? "" : (",#" + color.ToString("X2")));
				xMax = Math.Max(Math.Max(Math.Max(t.x1, xMax), t.x2), t.x3);
				sw.WriteLine(s);
				nbOctets += (modePolice ? 6 : 7);
			}
			xMax++;
			if (modePolice)
				sw.WriteLine("	DB	128+" + xMax.ToString());

			sw.WriteLine("; Taille " + nbOctets.ToString() + " octets");
		}

		static public void GenereDrawTriangleCode(StreamWriter sw, string nom, bool cpcPlus) {
			GenereInitCode(sw, cpcPlus);
			GenereInitPalette(sw, nom, cpcPlus);
			GenereDrawTriangle(sw);
		}

		static private void GenereInitCode(StreamWriter sw, bool cpcPlus) {
			sw.WriteLine("	ORG	#8000");
			sw.WriteLine("	RUN	$");
			sw.WriteLine("	DI");
			sw.WriteLine(";");
			sw.WriteLine("; Formater ecran en 256x256 pixels");
			sw.WriteLine(";");
			sw.WriteLine("	LD	HL,#202A");
			sw.WriteLine("	LD	BC,#BC01");
			sw.WriteLine("	OUT	(C),C");
			sw.WriteLine("	INC	B");
			sw.WriteLine("	OUT	(C),H");
			sw.WriteLine("	DEC	B");
			sw.WriteLine("	INC	C");
			sw.WriteLine("	OUT	(C),C");
			sw.WriteLine("	INC	B");
			sw.WriteLine("	OUT	(C),L");
			sw.WriteLine("	LD	HL,#2022");
			sw.WriteLine("	LD	BC,#BC06");
			sw.WriteLine("	OUT	(C),C");
			sw.WriteLine("	INC	B");
			sw.WriteLine("	OUT	(C),H");
			sw.WriteLine("	DEC	B");
			sw.WriteLine("	INC	C");
			sw.WriteLine("	OUT	(C),C");
			sw.WriteLine("	INC	B");
			sw.WriteLine("	OUT	(C),L");
			sw.WriteLine("; efface ecran, utile ?");
			sw.WriteLine("	LD	HL,#C000");
			sw.WriteLine("	LD	D,H");
			sw.WriteLine("	LD	E,L");
			sw.WriteLine("	LD	BC,#3FFF");
			sw.WriteLine("	INC	DE");
			sw.WriteLine("	LD	(HL),L");
			sw.WriteLine("	LDIR");
			sw.WriteLine("; calculer adresse ecran pour chaque ligne");
			sw.WriteLine("	LD	B,0					; 256 lignes");
			sw.WriteLine(" 	LD	DE,#C000");
			sw.WriteLine("	LD	HL,TabAdr");
			sw.WriteLine("CalcAdr:");
			sw.WriteLine("	LD	(HL),E");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),D");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	INC	HL");
			sw.WriteLine("	LD	A,D");
			sw.WriteLine("	ADD	A,8");
			sw.WriteLine("	LD	D,A");
			sw.WriteLine("	JR	NC,CalcSuite");
			sw.WriteLine("	PUSH	BC");
			sw.WriteLine("	LD	BC,#C040");
			sw.WriteLine("	EX	DE,HL");
			sw.WriteLine("	ADD	HL,BC");
			sw.WriteLine("	EX	DE,HL");
			sw.WriteLine("	POP	BC");
			sw.WriteLine("CalcSuite:");
			sw.WriteLine("	DJNZ	CalcAdr");
			sw.WriteLine("; calculer points a afficher en fonction de la couleur");
			sw.WriteLine("	LD	DE,pen1");
			sw.WriteLine("	LD	HL,PtMode1C1");
			sw.WriteLine("	LD	B,32					; Tableau structure {Point} (32 valeurs)");
			sw.WriteLine("InitPen:");
			sw.WriteLine("	CALL	Set3Pen					; Ecriture Masque + premier octet a ecrire");
			sw.WriteLine("	LD	A,(DE)					; Octet suivant = nbre de pixels a soustraire");
			sw.WriteLine("	LD	(HL),A");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),A");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),A");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),A");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	INC	DE");
			sw.WriteLine("	CALL	Set3Pen					; Ecriture Masque + dernier octet a ecrire");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	INC	L					; 3 valeurs a zeros pour aligner sur 8 octets");
			sw.WriteLine("	DJNZ	InitPen");
			if (cpcPlus) {
				sw.WriteLine("	LD	BC,#BC11");
				sw.WriteLine("	LD	HL,UnlockAsic");
				sw.WriteLine("Unlock:");
				sw.WriteLine("	LD	A,(HL)");
				sw.WriteLine("	OUT	(C),A");
				sw.WriteLine("	INC	HL");
				sw.WriteLine("	DEC	C");
				sw.WriteLine("	JR	NZ,Unlock");
			}
			sw.WriteLine("	LD	BC,#7F8D			; Mode 1");
			sw.WriteLine("	OUT	(C),C");
			if (cpcPlus) {
				sw.WriteLine("	LD	A,#A0");
				sw.WriteLine("	OUT	(C),A");
			}
			sw.WriteLine("	LD	HL,NewIrq");
			sw.WriteLine("	LD	(#39),HL");
			sw.WriteLine("	EI");
		}

		static private void GenereInitPalette(StreamWriter sw, string nom, bool cpcPlus) {
			sw.WriteLine("	LD	IX," + nom + "			; Donnees triangle");
			sw.WriteLine("	PUSH	IX");
			sw.WriteLine("	POP	HL");
			if (cpcPlus) {
				sw.WriteLine("	LD	BC,#7FB8");
				sw.WriteLine("	OUT	(C),C");
				sw.WriteLine("	LD	DE,#6420");
				sw.WriteLine("	LDI");
				sw.WriteLine("	LDI");
				sw.WriteLine("	DEC	HL");
				sw.WriteLine("	DEC	HL");
				sw.WriteLine("	LD	E,0");
				sw.WriteLine("	LD	BC,8");
				sw.WriteLine("	LDIR");
				sw.WriteLine("	LD	BC,#7FA0");
				sw.WriteLine("	OUT	(C),C");
			}
			else {
				sw.WriteLine("	LD	BC,#7F10");
				sw.WriteLine("	LD	A,(HL)");
				sw.WriteLine("	OUT	(C),C");
				sw.WriteLine("	OUT	(C),A");
				sw.WriteLine("	XOR	A");
				sw.WriteLine("BclPalette:");
				sw.WriteLine("	OUT	(C),A");
				sw.WriteLine("	INC	B");
				sw.WriteLine("	OUTI");
				sw.WriteLine("	INC	A");
				sw.WriteLine("	CP	4");
				sw.WriteLine("	JR	NZ,BclPalette");
			}
		}

		static private void GenereDrawTriangle(StreamWriter sw) {
			sw.WriteLine("	LD	A,(HL)");
			sw.WriteLine("	INC	HL");
			sw.WriteLine("	LD	(TpsWaitTriangle+1),A");
			sw.WriteLine("	PUSH	HL");
			sw.WriteLine("	POP	IX");
			sw.WriteLine("	LD	A,(IX+0)				; Mode de trace");
			sw.WriteLine("	LD	(ModeDraw+1),A");
			sw.WriteLine("	INC	IX");
			sw.WriteLine("BclDrawFrame:");
			sw.WriteLine("	XOR	A");
			sw.WriteLine("	LD	(CntIrq+1),A");
			sw.WriteLine("	LD	A,(IX+6)				; Couleur");
			sw.WriteLine("	AND	3");
			sw.WriteLine("	ADD	A,PtMode1C1/256");
			sw.WriteLine("	LD	(DrawLigneCoul+1),A");
			sw.WriteLine("	LD	(DrawLigneCoul3+1),A");
			sw.WriteLine("	LD	H,A");
			sw.WriteLine("	LD	L,#61");
			sw.WriteLine("	LD	A,(HL)");
			sw.WriteLine("	LD	(DrawLigneCoul2+1),A");
			sw.WriteLine("	LD	B,(IX+0)				; X1");
			sw.WriteLine("	LD	C,(IX+1)				; Y1");
			sw.WriteLine("	LD	D,(IX+2)				; X2");
			sw.WriteLine("	LD	E,(IX+3)				; Y2");
			sw.WriteLine("	LD	H,(IX+4)				; X3");
			sw.WriteLine("	LD	L,(IX+5)				; Y3");

			sw.WriteLine("	CALL	DrawTriangle");
			sw.WriteLine("ModeDraw:");
			sw.WriteLine("	LD	A,0");
			sw.WriteLine("	AND	A");
			sw.WriteLine("	JR	Z,WaitTriangle");
			sw.WriteLine("	LD	L,255");
			sw.WriteLine("	LD	A,L");
			sw.WriteLine("	SUB	(IX+0)");
			sw.WriteLine("	LD	B,A");
			sw.WriteLine("	LD	C,(IX+1)");
			sw.WriteLine("	LD	A,L");
			sw.WriteLine("	SUB	(IX+2)");
			sw.WriteLine("	LD	D,A");
			sw.WriteLine("	LD	E,(IX+3)");
			sw.WriteLine("	LD	A,L");
			sw.WriteLine("	SUB	(IX+4)");
			sw.WriteLine("	LD	H,A");
			sw.WriteLine("	LD	L,(IX+5)");
			sw.WriteLine("	CALL	DrawTriangle");
			sw.WriteLine("WaitTriangle:");
			sw.WriteLine("	LD	A,(CntIrq+1)");
			sw.WriteLine("TpsWaitTriangle:");
			sw.WriteLine("	CP	0");
			sw.WriteLine("JR C,WaitTriangle");
			sw.WriteLine("	LD	HL,0");
			sw.WriteLine("	LD	A,(IX+6)");
			sw.WriteLine("	LD	BC,7");
			sw.WriteLine("	ADD	IX,BC");
			sw.WriteLine("	RLA");
			sw.WriteLine("	JR	NC,BclDrawFrame");
			sw.WriteLine("Termine:");
			sw.WriteLine("	JR	Termine");

			sw.WriteLine("DrawTriangle:");
			sw.WriteLine("	LD	A,H");
			sw.WriteLine("	SUB	B");
			sw.WriteLine("	JR	C,SetDx1Neg");
			sw.WriteLine("	LD	(DX1+1),A");
			sw.WriteLine("	LD	A,#04					; INC B");
			sw.WriteLine("	JR	SetSgn1");
			sw.WriteLine("SetDx1Neg:");
			sw.WriteLine("	NEG");
			sw.WriteLine("	LD	(DX1+1),A");
			sw.WriteLine("	LD	A,#05					; DEC B");
			sw.WriteLine("SetSgn1:");
			sw.WriteLine("	LD	(Sgn1),A");
			sw.WriteLine("	LD	A,H");
			sw.WriteLine("	SUB	D");
			sw.WriteLine("	JR	C,SetDx3Neg");
			sw.WriteLine("	LD	(DX3+1),A");
			sw.WriteLine("	LD	A,#0C					; INC C");
			sw.WriteLine("	JR	SetSgn3");
			sw.WriteLine("SetDx3Neg:");
			sw.WriteLine("	NEG");
			sw.WriteLine("	LD	(DX3+1),A");
			sw.WriteLine("	LD	A,#0D					; DEC C");
			sw.WriteLine("SetSgn3:");
			sw.WriteLine("	LD	(Sgn3+1),A");
			sw.WriteLine("	LD	A,L");
			sw.WriteLine("	LD	(Ymax+1),A");
			sw.WriteLine("	SUB	C");
			sw.WriteLine("	LD	H,A					; Reg.H = DY1");
			sw.WriteLine("	LD	A,L");
			sw.WriteLine("	SUB	E");
			sw.WriteLine("	LD	(DY3+1),A");
			sw.WriteLine("	LD	A,E");
			sw.WriteLine("	LD	(Y2+1),A");
			sw.WriteLine("	SUB	C");
			sw.WriteLine("	LD	L,A					; Reg.L = DY2");
			sw.WriteLine("	LD	A,D");
			sw.WriteLine("	SUB	B");
			sw.WriteLine("	JR	C,SetDx2Neg");
			sw.WriteLine("	LD	(DX2+1),A");
			sw.WriteLine("	LD	A,#0C					; INC C");
			sw.WriteLine("	JR	SetSgn2");
			sw.WriteLine("SetDx2Neg:");
			sw.WriteLine("	NEG");
			sw.WriteLine("	LD	(DX2+1),A");
			sw.WriteLine("	LD	A,#0D					; DEC C");
			sw.WriteLine("SetSgn2:");
			sw.WriteLine("	LD	(Sgn2),A");
			sw.WriteLine("	LD	A,C					; Y de depart = Reg.C");
			sw.WriteLine("	CP	E");
			sw.WriteLine("	LD	C,D");
			sw.WriteLine("	LD	DE,0					; Reg.D = Err2, Reg.E = Err1");
			sw.WriteLine("	JR	Z,BclDrawTriangle");
			sw.WriteLine("	LD	C,B");
			sw.WriteLine(";");
			sw.WriteLine("; Boucle principale du remplissage du triangle");
			sw.WriteLine("; on trace des lignes horizontales du haut vers le bas");
			sw.WriteLine("; Reg.A = y");
			sw.WriteLine("; Reg.B = x1");
			sw.WriteLine("; Reg.C = x2");
			sw.WriteLine(";");
			sw.WriteLine("BclDrawTriangle:");
			sw.WriteLine("	PUSH	BC");
			sw.WriteLine("	EXX");
			sw.WriteLine("	POP	BC");
			sw.WriteLine("	LD	L,A					; Reg.L = y");
			sw.WriteLine("	EX	AF,AF'");
			sw.WriteLine("	LD	A,B					; x");
			sw.WriteLine("	CP	C");
			sw.WriteLine("	JR	Z,LigneVide				; Si B = C, rien a faire");
			sw.WriteLine("	JR	C,DrawLigneCoordOk			; Si B < C, ok");
			sw.WriteLine("	LD	B,C					; Sinon on inverse");
			sw.WriteLine("	LD	C,A");
			sw.WriteLine("	LD	A,B					; x");
			sw.WriteLine("DrawLigneCoordOk:");
			sw.WriteLine("	LD	H,TabAdr/256				; Adresse des poids faibles");
			sw.WriteLine("	AND	A");
			sw.WriteLine("	RRA");
			sw.WriteLine("	AND	A");
			sw.WriteLine("	RRA						; x/4");
			sw.WriteLine("	ADD	A,(HL)");
			sw.WriteLine("	LD	E,A");
			sw.WriteLine("	INC	H					; Adresse des poids forts");
			sw.WriteLine("	LD	D,(HL)					; Reg.DE = adresse memoire ecran (0,y)");
			sw.WriteLine("");
			sw.WriteLine("	LD	A,B					; x");
			sw.WriteLine("	AND	3");
			sw.WriteLine("	LD	L,A					; Reg.L = position fine x (0 a 3)");
			sw.WriteLine("	LD	A,C					; xfin");
			sw.WriteLine("	SUB	B");
			sw.WriteLine("	LD	B,A					; Reg.B = nbre de points en x");
			sw.WriteLine("	DEC	A");
			sw.WriteLine("	CP	7");
			sw.WriteLine("	JR	C,DrawLigneOk");
			sw.WriteLine("	OR	4");
			sw.WriteLine("	AND	7");
			sw.WriteLine("DrawLigneOk:");
			sw.WriteLine("	RLCA");
			sw.WriteLine("	RLCA");
			sw.WriteLine("	OR	L");
			sw.WriteLine("	RLCA");
			sw.WriteLine("	RLCA");
			sw.WriteLine("	RLCA						; 8 octets par structure");
			sw.WriteLine("	LD	L,A");
			sw.WriteLine("DrawLigneCoul:");
			sw.WriteLine("	LD	H,PtMode1C1/256");
			sw.WriteLine("	LD	A,(DE)					; Octet memoire ecran");
			sw.WriteLine("	AND	(HL)					; Masque");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	OR	(HL)					; Premier octet");
			sw.WriteLine("	LD	(DE),A");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	INC	DE");
			sw.WriteLine("	LD	A,B					; Nbre de points");
			sw.WriteLine("	SUB	(HL)					; Nbre de points a soustraire");
			sw.WriteLine("	JR	C,DrawLigneFin");
			sw.WriteLine("	INC	A");
			sw.WriteLine("	RRA");
			sw.WriteLine("	AND	A");
			sw.WriteLine("	RRA");
			sw.WriteLine("	LD	C,A");
			sw.WriteLine("DrawLigneCoul2:");
			sw.WriteLine("	LD	A,#3E					; Octet du milieu (4 pixels allumes)");
			sw.WriteLine("	LD	(DE),A");
			sw.WriteLine("	LD	H,D");
			sw.WriteLine("	LD	A,L");
			sw.WriteLine("	LD	L,E");
			sw.WriteLine("	INC	DE");
			sw.WriteLine("	DEC	C");
			sw.WriteLine("	JR	Z,DrawLigneCoul3");
			sw.WriteLine("	LD	B,0");
			sw.WriteLine("	LDIR");
			sw.WriteLine("DrawLigneCoul3:");
			sw.WriteLine("	LD	H,PtMode1C1/256");
			sw.WriteLine("	LD	L,A");
			sw.WriteLine("");
			sw.WriteLine("DrawLigneFin:");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	LD	A,(DE)					; Octet memoire ecran");
			sw.WriteLine("	AND	(HL)					; Masque");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	OR	(HL)					; Dernier octet");
			sw.WriteLine("	LD	(DE),A");
			sw.WriteLine("LigneVide:");
			sw.WriteLine("	EXX");
			sw.WriteLine(";");
			sw.WriteLine("; Fin tracé de ligne");
			sw.WriteLine(";");
			sw.WriteLine("	LD	A,E					; Err1");
			sw.WriteLine("DX1:");
			sw.WriteLine("	ADD	A,0					; Err1=Err1+Dx1");
			sw.WriteLine("	JR	C,ForceErr1");
			sw.WriteLine("DY1:");
			sw.WriteLine("	CP	H");
			sw.WriteLine("	JR	C,SetErr1				; Si Err1<Dy1, arrêt de la boucle");
			sw.WriteLine("ForceErr1:");
			sw.WriteLine("	SUB	H					; - DY1");
			sw.WriteLine("SGN1:");
			sw.WriteLine("	INC	B					; OU DEC B (B=xl)");
			sw.WriteLine("	JR	DY1");
			sw.WriteLine("SetErr1:");
			sw.WriteLine("	LD	E,A					; Sauvegarde Err1");
			sw.WriteLine("	EX	AF,AF'					; Recupere ordonnee de la ligne en cours (Y)");
			sw.WriteLine("Y2:");
			sw.WriteLine("	CP	0					; Y==E ?");
			sw.WriteLine("	JR	Z,SetErr3					; Il est moins couteux en tps de faire");
			sw.WriteLine("							; un saut conditionnel dont la condition");
			sw.WriteLine("							; arrive peu frequement (ici le JR Z ne");
			sw.WriteLine("							; peut arriver qu'une seule fois)");
			sw.WriteLine("	EX	AF,AF'					; Re-sauvegarde Y");
			sw.WriteLine("	LD	A,D					; Err2");
			sw.WriteLine("DX2:");
			sw.WriteLine("	ADD	A,0");
			sw.WriteLine("	JR	C,ForceErr2");
			sw.WriteLine("DY2:");
			sw.WriteLine("	CP	L");
			sw.WriteLine("	JR	C,SetErr2");
			sw.WriteLine("ForceErr2:");
			sw.WriteLine("	SUB	L					; -DY2");
			sw.WriteLine("SGN2:");
			sw.WriteLine("	INC	C					; OU DEC C(C=xr)");
			sw.WriteLine("	JR	DY2");
			sw.WriteLine("SetErr2:");
			sw.WriteLine("	LD	D,A");
			sw.WriteLine("	EX	AF,AF'					; Recupere ordonee de la ligne en cours");
			sw.WriteLine("	INC	A");
			sw.WriteLine("Ymax:");
			sw.WriteLine("	CP	0					; Arrive en bas ?");
			sw.WriteLine("	JR	C,BclDrawTriangle");
			sw.WriteLine("	JR	FinTriangle");
			sw.WriteLine(";");
			sw.WriteLine("; Parametres pour tracer le deuxieme triangle");
			sw.WriteLine(";");
			sw.WriteLine("SetErr3:");
			sw.WriteLine("	EX	AF,AF'");
			sw.WriteLine("DX3:");
			sw.WriteLine("	LD	A,0");
			sw.WriteLine("	LD	(DX2+1),A");
			sw.WriteLine("Sgn3:");
			sw.WriteLine("	LD	A,0");
			sw.WriteLine("	LD	(Sgn2),A");
			sw.WriteLine("DY3:");
			sw.WriteLine("	LD	L,0");
			sw.WriteLine("	XOR	A");
			sw.WriteLine("	LD	D,A");
			sw.WriteLine("	JR	DX2");
			sw.WriteLine("FinTriangle:		");
			sw.WriteLine("	RET");
			sw.WriteLine("");
			sw.WriteLine("Set3Pen:");
			sw.WriteLine("	LD	A,(DE)					; Point en Pen 1");
			sw.WriteLine("	LD	C,A");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	OR	C");
			sw.WriteLine("	CPL						; Creation du masque");
			sw.WriteLine("	LD	(HL),A");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),A");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),A");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),A					; Stockage du masque pour les 3 pens");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	LD	(HL),0					; Pen 0");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	(HL),C					; Pen 1");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	LD	A,C");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	RRCA");
			sw.WriteLine("	LD	(HL),A					; Pen 2");
			sw.WriteLine("	INC	H");
			sw.WriteLine("	OR	C");
			sw.WriteLine("	LD	(HL),A					; Pen 3");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	DEC	H");
			sw.WriteLine("	INC	L");
			sw.WriteLine("	INC	DE");
			sw.WriteLine("	RET");
			sw.WriteLine("");
			sw.WriteLine("NewIrq:");
			sw.WriteLine("	PUSH	AF");
			sw.WriteLine("	CntIrq:");
			sw.WriteLine("	LD	A,0");
			sw.WriteLine("	INC	A");
			sw.WriteLine("	LD	(CntIrq+1),A");
			sw.WriteLine("	POP	AF");
			sw.WriteLine("	EI");
			sw.WriteLine("	RET");
		}

		static public void GenereDrawTriangleData(StreamWriter sw, bool cpcPlus) {
			if (cpcPlus) {
				sw.WriteLine("UnlockAsic:");
				sw.WriteLine("	DB	#FF,#00,#FF,#77,#B3,#51,#A8,#D4,#62,#39,#9C,#46,#2B,#15,#8A,#CD,#EE");
				sw.WriteLine(";");
			}
			sw.WriteLine("pen1:");
			sw.WriteLine(";");
			sw.WriteLine("; Structure");
			sw.WriteLine("; octet 0 = premier octet de la ligne");
			sw.WriteLine("; octet 1 = nbre d'octets a soustraire+1 du nombre de pixels");
			sw.WriteLine("; octet 2 = dernier octet de la ligne");
			sw.WriteLine(";");
			sw.WriteLine("	DB	#80,#02,#00");
			sw.WriteLine("	DB	#40,#02,#00");
			sw.WriteLine("	DB	#20,#02,#00");
			sw.WriteLine("	DB	#10,#02,#00");
			sw.WriteLine("	DB	#C0,#03,#00");
			sw.WriteLine("	DB	#60,#03,#00");
			sw.WriteLine("	DB	#30,#03,#00");
			sw.WriteLine("	DB	#10,#03,#80");
			sw.WriteLine("	DB	#E0,#04,#00");
			sw.WriteLine("	DB	#70,#04,#00");
			sw.WriteLine("	DB	#30,#04,#80");
			sw.WriteLine("	DB	#10,#04,#C0");
			sw.WriteLine("	DB	#F0,#05,#00");
			sw.WriteLine("	DB	#70,#05,#80");
			sw.WriteLine("	DB	#30,#05,#C0");
			sw.WriteLine("	DB	#10,#05,#E0");
			sw.WriteLine("	DB	#F0,#06,#80");
			sw.WriteLine("	DB	#70,#06,#C0");
			sw.WriteLine("	DB	#30,#06,#E0");
			sw.WriteLine("	DB	#10,#06,#F0");
			sw.WriteLine("	DB	#F0,#07,#C0");
			sw.WriteLine("	DB	#70,#07,#E0");
			sw.WriteLine("	DB	#30,#07,#F0");
			sw.WriteLine("	DB	#10,#03,#80");
			sw.WriteLine("	DB	#F0,#08,#E0");
			sw.WriteLine("	DB	#70,#08,#F0");
			sw.WriteLine("	DB	#30,#04,#80");
			sw.WriteLine("	DB	#10,#04,#C0");
			sw.WriteLine("	DB	#F0,#09,#F0");
			sw.WriteLine("	DB	#70,#05,#80");
			sw.WriteLine("	DB	#30,#05,#C0");
			sw.WriteLine("	DB	#10,#05,#E0");
			sw.WriteLine(";");
			sw.WriteLine("	align	256");
			sw.WriteLine("TabAdr");
			sw.WriteLine("	DS	512");
			sw.WriteLine("PtMode1C1");
		}

		static public void CloseAsm(StreamWriter sw) {
			sw.Close();
			sw.Dispose();
		}
	}
}
