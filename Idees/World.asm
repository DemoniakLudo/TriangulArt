; Généré par TriangulArt le 07/05/2021 (11 41 47)
	ORG	#8000
	RUN	$
	DI
;
; Formater ecran en 256x256 pixels
;
	LD	HL,#202A
	LD	BC,#BC01
	OUT	(C),C
	INC	B
	OUT	(C),H
	DEC	B
	INC	C
	OUT	(C),C
	INC	B
	OUT	(C),L
	LD	HL,#2022
	LD	BC,#BC06
	OUT	(C),C
	INC	B
	OUT	(C),H
	DEC	B
	INC	C
	OUT	(C),C
	INC	B
	OUT	(C),L
; efface ecran, utile ?
	LD	HL,#C000
	LD	D,H
	LD	E,L
	LD	BC,#3FFF
	INC	DE
	LD	(HL),L
	LDIR
; calculer adresse ecran pour chaque ligne
	LD	B,0					; 256 lignes
 	LD	DE,#C000
	LD	HL,TabAdr
CalcAdr:
	LD	(HL),E
	INC	H
	LD	(HL),D
	DEC	H
	INC	HL
	LD	A,D
	ADD	A,8
	LD	D,A
	JR	NC,CalcSuite
	PUSH	BC
	LD	BC,#C040
	EX	DE,HL
	ADD	HL,BC
	EX	DE,HL
	POP	BC
CalcSuite:
	DJNZ	CalcAdr
; calculer points a afficher en fonction de la couleur
	LD	DE,pen1
	LD	HL,PtMode1C1
	LD	B,32					; Tableau structure {Point} (32 valeurs)
InitPen:
	CALL	Set3Pen					; Ecriture Masque + premier octet a ecrire
	LD	A,(DE)					; Octet suivant = nbre de pixels a soustraire
	LD	(HL),A
	INC	H
	LD	(HL),A
	INC	H
	LD	(HL),A
	INC	H
	LD	(HL),A
	DEC	H
	DEC	H
	DEC	H
	INC	L
	INC	DE
	CALL	Set3Pen					; Ecriture Masque + dernier octet a ecrire
	INC	L
	INC	L
	INC	L					; 3 valeurs a zeros pour aligner sur 8 octets
	DJNZ	InitPen
	LD	BC,#7F8D			; Mode 1
	OUT	(C),C

	LD	IX,World			; Donnees triangle
	PUSH	IX
	POP	HL
	LD	BC,#7F10
	LD	A,(HL)
	OUT	(C),C
	OUT	(C),A
	XOR	A
BclPalette:
	OUT	(C),A
	INC	B
	OUTI
	INC	A
	CP	4
	JR	NZ,BclPalette
	LD	E,(HL)
	INC	HL
	LD	D,(HL)
	INC	HL
	LD	(WaitTriangle+1),DE
	PUSH	HL
	POP	IX
	LD	A,(IX+0)				; Mode de trace
	LD	(ModeDraw+1),A
	INC	IX
BclDrawFrame:
	LD	A,(IX+6)				; Couleur
	AND	3
	ADD	A,PtMode1C1/256
	LD	(DrawLigneCoul+1),A
	LD	(DrawLigneCoul3+1),A
	LD	H,A
	LD	L,#61
	LD	A,(HL)
	LD	(DrawLigneCoul2+1),A
	LD	B,(IX+0)				; X1
	LD	C,(IX+1)				; Y1
	LD	D,(IX+2)				; X2
	LD	E,(IX+3)				; Y2
	LD	H,(IX+4)				; X3
	LD	L,(IX+5)				; Y3
	CALL	DrawTriangle
ModeDraw:
	LD	A,0
	AND	A
	JR	Z,WaitTriangle
	LD	L,255
	LD	A,L
	SUB	(IX+0)
	LD	B,A
	LD	C,(IX+1)
	LD	A,L
	SUB	(IX+2)
	LD	D,A
	LD	E,(IX+3)
	LD	A,L
	SUB	(IX+4)
	LD	H,A
	LD	L,(IX+5)
	CALL	DrawTriangle
WaitTriangle:
	LD	HL,0
WaitTriangle1:
	DEC HL
	LD A, H
	OR L
JR NZ, WaitTriangle1
	LD	HL,0
	LD	A,(IX+6)
	LD	BC,7
	ADD	IX,BC
	RLA
	JR	NC,BclDrawFrame
Termine:
	JR	Termine
DrawTriangle:
	LD	A,H
	SUB	B
	JR	C,SetDx1Neg
	LD	(DX1+1),A
	LD	A,#04					; INC B
	JR	SetSgn1
SetDx1Neg:
	NEG
	LD	(DX1+1),A
	LD	A,#05					; DEC B
SetSgn1:
	LD	(Sgn1),A
	LD	A,H
	SUB	D
	JR	C,SetDx3Neg
	LD	(DX3+1),A
	LD	A,#0C					; INC C
	JR	SetSgn3
SetDx3Neg:
	NEG
	LD	(DX3+1),A
	LD	A,#0D					; DEC C
SetSgn3:
	LD	(Sgn3+1),A
	LD	A,L
	LD	(Ymax+1),A
	SUB	C
	LD	H,A					; Reg.H = DY1
	LD	A,L
	SUB	E
	LD	(DY3+1),A
	LD	A,E
	LD	(Y2+1),A
	SUB	C
	LD	L,A					; Reg.L = DY2
	LD	A,D
	SUB	B
	JR	C,SetDx2Neg
	LD	(DX2+1),A
	LD	A,#0C					; INC C
	JR	SetSgn2
SetDx2Neg:
	NEG
	LD	(DX2+1),A
	LD	A,#0D					; DEC C
SetSgn2:
	LD	(Sgn2),A
	LD	A,C					; Y de depart = Reg.C
	CP	E
	LD	C,D
	LD	DE,0					; Reg.D = Err2, Reg.E = Err1
	JR	Z,BclDrawTriangle
	LD	C,B
;
; Boucle principale du remplissage du triangle
; on trace des lignes horizontales du haut vers le bas
; Reg.A = y
; Reg.B = x1
; Reg.C = x2
;
BclDrawTriangle:
	PUSH	BC
	EXX
	POP	BC
	LD	L,A					; Reg.L = y
	EX	AF,AF'
	LD	A,B					; x
	CP	C
	JR	Z,LigneVide				; Si B = C, rien a faire
	JR	C,DrawLigneCoordOk			; Si B < C, ok
	LD	B,C					; Sinon on inverse
	LD	C,A
	LD	A,B					; x
DrawLigneCoordOk:
	LD	H,TabAdr/256				; Adresse des poids faibles
	AND	A
	RRA
	AND	A
	RRA						; x/4
	ADD	A,(HL)
	LD	E,A
	INC	H					; Adresse des poids forts
	LD	D,(HL)					; Reg.DE = adresse memoire ecran (0,y)

	LD	A,B					; x
	AND	3
	LD	L,A					; Reg.L = position fine x (0 a 3)
	LD	A,C					; xfin
	SUB	B
	LD	B,A					; Reg.B = nbre de points en x
	DEC	A
	CP	7
	JR	C,DrawLigneOk
	OR	4
	AND	7
DrawLigneOk:
	RLCA
	RLCA
	OR	L
	RLCA
	RLCA
	RLCA						; 8 octets par structure
	LD	L,A
DrawLigneCoul:
	LD	H,PtMode1C1/256
	LD	A,(DE)					; Octet memoire ecran
	AND	(HL)					; Masque
	INC	L
	OR	(HL)					; Premier octet
	LD	(DE),A
	INC	L
	INC	DE
	LD	A,B					; Nbre de points
	SUB	(HL)					; Nbre de points a soustraire
	JR	C,DrawLigneFin
	INC	A
	RRA
	AND	A
	RRA
	LD	C,A
DrawLigneCoul2:
	LD	A,#3E					; Octet du milieu (4 pixels allumes)
	LD	(DE),A
	LD	H,D
	LD	A,L
	LD	L,E
	INC	DE
	DEC	C
	JR	Z,DrawLigneCoul3
	LD	B,0
	LDIR
DrawLigneCoul3:
	LD	H,PtMode1C1/256
	LD	L,A

DrawLigneFin:
	INC	L
	LD	A,(DE)					; Octet memoire ecran
	AND	(HL)					; Masque
	INC	L
	OR	(HL)					; Dernier octet
	LD	(DE),A
LigneVide:
	EXX
;
; Fin tracé de ligne
;
	LD	A,E					; Err1
DX1:
	ADD	A,0					; Err1=Err1+Dx1
	JR	C,ForceErr1
DY1:
	CP	H
	JR	C,SetErr1				; Si Err1<Dy1, arrêt de la boucle
ForceErr1:
	SUB	H					; - DY1
SGN1:
	INC	B					; OU DEC B (B=xl)
	JR	DY1
SetErr1:
	LD	E,A					; Sauvegarde Err1
	EX	AF,AF'					; Recupere ordonnee de la ligne en cours (Y)
Y2:
	CP	0					; Y==E ?
	JR	Z,SetErr3					; Il est moins couteux en tps de faire
							; un saut conditionnel dont la condition
							; arrive peu frequement (ici le JR Z ne
							; peut arriver qu'une seule fois)
	EX	AF,AF'					; Re-sauvegarde Y
	LD	A,D					; Err2
DX2:
	ADD	A,0
	JR	C,ForceErr2
DY2:
	CP	L
	JR	C,SetErr2
ForceErr2:
	SUB	L					; -DY2
SGN2:
	INC	C					; OU DEC C(C=xr)
	JR	DY2
SetErr2:
	LD	D,A
	EX	AF,AF'					; Recupere ordonee de la ligne en cours
	INC	A
Ymax:
	CP	0					; Arrive en bas ?
	JR	C,BclDrawTriangle
	JR	FinTriangle
;
; Parametres pour tracer le deuxieme triangle
;
SetErr3:
	EX	AF,AF'
DX3:
	LD	A,0
	LD	(DX2+1),A
Sgn3:
	LD	A,0
	LD	(Sgn2),A
DY3:
	LD	L,0
	XOR	A
	LD	D,A
	JR	DX2
FinTriangle:		
	RET

Set3Pen:
	LD	A,(DE)					; Point en Pen 1
	LD	C,A
	RRCA
	RRCA
	RRCA
	RRCA
	OR	C
	CPL						; Creation du masque
	LD	(HL),A
	INC	H
	LD	(HL),A
	INC	H
	LD	(HL),A
	INC	H
	LD	(HL),A					; Stockage du masque pour les 3 pens
	DEC	H
	DEC	H
	DEC	H
	INC	L
	LD	(HL),0					; Pen 0
	INC	H
	LD	(HL),C					; Pen 1
	INC	H
	LD	A,C
	RRCA
	RRCA
	RRCA
	RRCA
	LD	(HL),A					; Pen 2
	INC	H
	OR	C
	LD	(HL),A					; Pen 3
	DEC	H
	DEC	H
	DEC	H
	INC	L
	INC	DE
	RET
World
; 4 octets de palette
	DB	"DVNK"
	DW	#0800			; Tps d'affichage
	DB	#00			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#D6,#21,#E0,#2C,#D7,#2D,#01
	DB	#D7,#2D,#D2,#44,#D6,#4E,#01
	DB	#D6,#21,#C2,#2B,#D2,#45,#01
	DB	#C5,#1E,#D6,#21,#AE,#22,#01
	DB	#D6,#21,#AE,#22,#C2,#2B,#01
	DB	#C3,#2C,#AD,#3B,#CC,#4B,#01
	DB	#C3,#2C,#D2,#46,#CC,#4B,#01
	DB	#CD,#4B,#A7,#66,#B5,#70,#01
	DB	#AD,#3B,#CD,#4B,#A8,#67,#01
	DB	#AF,#22,#A7,#2A,#AD,#3C,#01
	DB	#AF,#22,#C4,#2D,#AD,#3C,#01
	DB	#8F,#46,#97,#58,#A8,#67,#01
	DB	#AD,#3C,#8F,#46,#A8,#67,#01
	DB	#8F,#29,#A8,#2A,#AD,#3C,#01
	DB	#8F,#29,#AE,#3C,#8F,#47,#01
	DB	#9C,#21,#B0,#22,#98,#28,#01
	DB	#B0,#22,#98,#28,#A8,#2C,#01
	DB	#7E,#1E,#8B,#25,#6D,#31,#01
	DB	#8B,#25,#6E,#32,#90,#47,#01
	DB	#6F,#32,#68,#34,#6B,#41,#01
	DB	#6F,#32,#6C,#42,#72,#43,#01
	DB	#6F,#33,#74,#44,#7A,#47,#01
	DB	#6F,#33,#87,#42,#7A,#47,#01
	DB	#87,#42,#82,#4E,#7A,#4E,#01
	DB	#87,#42,#7A,#47,#7A,#4E,#01
	DB	#5F,#40,#6D,#42,#67,#46,#01
	DB	#62,#34,#5F,#40,#6D,#43,#01
	DB	#68,#34,#62,#35,#62,#36,#01
	DB	#68,#35,#63,#36,#6D,#43,#01
	DB	#6D,#24,#68,#2E,#6F,#33,#01
	DB	#6D,#24,#67,#2A,#68,#2E,#01
	DB	#7E,#1F,#74,#20,#6F,#33,#01
	DB	#7E,#1F,#78,#2A,#70,#34,#01
	DB	#CD,#4B,#D2,#51,#CF,#62,#01
	DB	#CE,#4D,#BF,#60,#D0,#63,#01
	DB	#BF,#61,#B6,#71,#C8,#77,#01
	DB	#C0,#62,#D1,#71,#C8,#78,#01
	DB	#C0,#62,#CA,#62,#D1,#72,#01
	DB	#C9,#78,#CA,#7F,#C4,#83,#01
	DB	#BB,#76,#BE,#84,#C5,#84,#01
	DB	#BB,#76,#C9,#79,#C5,#84,#01
	DB	#B6,#72,#A9,#74,#AF,#7E,#01
	DB	#A9,#68,#B6,#72,#A9,#74,#01
	DB	#91,#47,#85,#52,#8A,#58,#01
	DB	#91,#47,#8A,#58,#98,#58,#01
	DB	#D6,#77,#D0,#7D,#D1,#88,#01
	DB	#D6,#88,#DD,#94,#DD,#A2,#01
	DB	#D6,#88,#D6,#9B,#DD,#A2,#01
	DB	#D7,#89,#D3,#90,#D7,#9C,#01
	DB	#E3,#92,#E8,#92,#E5,#9D,#01
	DB	#E9,#92,#F2,#9B,#E6,#9D,#01
	DB	#F2,#9B,#E7,#9E,#F0,#A1,#01
	DB	#53,#6A,#62,#7B,#5A,#82,#01
	DB	#62,#7B,#5A,#83,#6A,#87,#01
	DB	#7A,#6E,#63,#7E,#83,#95,#01
	DB	#68,#83,#84,#96,#6E,#A2,#01
	DB	#84,#96,#6E,#A3,#7F,#A9,#01
	DB	#7B,#6F,#88,#79,#84,#97,#01
	DB	#8B,#9E,#85,#A5,#8E,#A5,#01
	DB	#8E,#A5,#86,#A6,#88,#AD,#01
	DB	#3E,#15,#2E,#16,#3C,#1C,#01
	DB	#2E,#16,#38,#1B,#37,#25,#01
	DB	#30,#16,#22,#1E,#37,#26,#01
	DB	#11,#16,#23,#20,#0B,#2B,#01
	DB	#02,#15,#12,#17,#0B,#2A,#01
	DB	#0C,#2B,#03,#3E,#25,#4E,#01
	DB	#23,#1F,#0C,#2B,#25,#4D,#01
	DB	#23,#20,#31,#23,#25,#4D,#01
	DB	#31,#23,#35,#2E,#25,#4E,#01
	DB	#32,#24,#46,#28,#35,#2E,#01
	DB	#46,#28,#35,#2F,#46,#32,#01
	DB	#04,#3E,#26,#4E,#1D,#55,#01
	DB	#04,#3E,#1E,#57,#22,#73,#01
	DB	#23,#73,#0D,#8A,#14,#9A,#01
	DB	#23,#74,#14,#9B,#33,#A9,#01
	DB	#23,#75,#38,#93,#34,#AA,#01
	DB	#3B,#86,#41,#94,#35,#AA,#01
	DB	#2A,#7E,#3B,#87,#38,#93,#01
	DB	#16,#9B,#33,#B8,#27,#C4,#01
	DB	#16,#9B,#35,#AA,#34,#B9,#01
	DB	#19,#BC,#27,#C5,#17,#D1,#01
	DB	#8B,#58,#98,#59,#9A,#69,#02
	DB	#8B,#59,#85,#61,#92,#74,#02
	DB	#8B,#5A,#9A,#69,#92,#74,#02
	DB	#9B,#6A,#93,#74,#9B,#76,#02
	DB	#F5,#A3,#EE,#AD,#F9,#B2,#02
	DB	#F9,#B2,#FE,#BF,#EB,#C8,#02
	DB	#EF,#AE,#F9,#B3,#EB,#C9,#02
	DB	#E0,#AC,#F0,#AE,#EB,#C9,#02
	DB	#E1,#AD,#D5,#B9,#EB,#CA,#02
	DB	#D6,#BA,#EB,#CA,#DC,#CF,#02
	DB	#FF,#BE,#EC,#C8,#F0,#CF,#02
	DB	#FF,#BE,#F1,#CF,#FA,#DE,#02
	DB	#70,#4B,#58,#53,#53,#68,#02
	DB	#70,#4B,#53,#68,#61,#7E,#02
	DB	#70,#4B,#79,#6E,#62,#7E,#02
	DB	#6F,#A3,#80,#AB,#75,#B3,#02
	DB	#6F,#A4,#6B,#B5,#76,#B5,#02
	DB	#70,#4B,#7C,#55,#7A,#6F,#02
	DB	#7C,#55,#86,#62,#7A,#6F,#02
	DB	#86,#63,#7B,#6F,#88,#78,#02
	DB	#88,#79,#92,#7E,#84,#97,#02
	DB	#15,#9B,#17,#BB,#26,#C4,#02
	DB	#5F,#0E,#43,#0F,#57,#26,#03
	DB	#4C,#15,#58,#1D,#46,#1F,#03
	DB	#B1,#E7,#8A,#F1,#C3,#F1,#03
	DB	#28,#E6,#1C,#F1,#22,#F1,#83
; Taille 749 octets
pen1:
;
; Structure
; octet 0 = premier octet de la ligne
; octet 1 = nbre d'octets a soustraire+1 du nombre de pixels
; octet 2 = dernier octet de la ligne
;
	DB	#80,#02,#00
	DB	#40,#02,#00
	DB	#20,#02,#00
	DB	#10,#02,#00
	DB	#C0,#03,#00
	DB	#60,#03,#00
	DB	#30,#03,#00
	DB	#10,#03,#80
	DB	#E0,#04,#00
	DB	#70,#04,#00
	DB	#30,#04,#80
	DB	#10,#04,#C0
	DB	#F0,#05,#00
	DB	#70,#05,#80
	DB	#30,#05,#C0
	DB	#10,#05,#E0
	DB	#F0,#06,#80
	DB	#70,#06,#C0
	DB	#30,#06,#E0
	DB	#10,#06,#F0
	DB	#F0,#07,#C0
	DB	#70,#07,#E0
	DB	#30,#07,#F0
	DB	#10,#03,#80
	DB	#F0,#08,#E0
	DB	#70,#08,#F0
	DB	#30,#04,#80
	DB	#10,#04,#C0
	DB	#F0,#09,#F0
	DB	#70,#05,#80
	DB	#30,#05,#C0
	DB	#10,#05,#E0
;
	align	256
TabAdr
	DS	512
PtMode1C1
