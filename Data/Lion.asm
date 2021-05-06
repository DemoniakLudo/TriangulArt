; Généré par TriangulArt le 05/05/2021 (19 28 07)
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

	LD	IX,DataFrame			; Donnees triangle
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
	INC	HL						; passer le mot de temporisation
	INC	HL
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

DataFrame
; 4 octets de palette
	DB	"TJLK"
	DW	#2000			; Tps d'affichage ?
	DB	#01
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#48,#16,#3A,#21,#4A,#24,#01
	DB	#3A,#21,#4A,#24,#2C,#27,#01
	DB	#6C,#47,#5E,#4A,#65,#5D,#01
	DB	#6C,#47,#76,#5C,#65,#5D,#01
	DB	#76,#5C,#6C,#5D,#6D,#6B,#01
	DB	#61,#53,#65,#5B,#52,#6F,#01
	DB	#56,#71,#52,#76,#57,#78,#01
	DB	#52,#76,#5A,#79,#5C,#87,#01
	DB	#62,#75,#6D,#77,#69,#88,#01
	DB	#7B,#67,#6D,#72,#75,#83,#01
	DB	#76,#81,#6C,#8E,#6F,#9F,#01
	DB	#7B,#67,#80,#82,#6F,#9F,#01
	DB	#80,#82,#80,#9D,#6F,#9F,#01
	DB	#6D,#91,#66,#97,#6F,#9D,#01
	DB	#5E,#8D,#66,#97,#5A,#98,#01
	DB	#66,#97,#5A,#98,#60,#A8,#01
	DB	#66,#97,#69,#A4,#60,#A8,#01
	DB	#69,#A4,#60,#A8,#5D,#B7,#01
	DB	#69,#A4,#5D,#B7,#70,#BF,#01
	DB	#69,#A4,#80,#AC,#70,#BF,#01
	DB	#80,#C2,#67,#C6,#6E,#D8,#01
	DB	#80,#C2,#80,#D6,#6E,#D8,#01
	DB	#62,#D9,#56,#DF,#5D,#E6,#01
	DB	#56,#DF,#5D,#E6,#52,#EC,#01
	DB	#5B,#EC,#58,#F1,#5A,#F5,#01
	DB	#58,#F1,#5A,#F5,#50,#F6,#01
	DB	#45,#D8,#39,#E1,#42,#E5,#01
	DB	#39,#E1,#42,#E5,#39,#EF,#01
	DB	#2F,#CB,#36,#D1,#30,#D8,#01
	DB	#2C,#CB,#1F,#D1,#28,#D5,#01
	DB	#2B,#BF,#31,#C8,#21,#D0,#01
	DB	#27,#B8,#2A,#BE,#21,#CA,#01
	DB	#49,#9F,#26,#B6,#31,#C9,#01
	DB	#20,#A4,#40,#A5,#1C,#BD,#01
	DB	#3D,#8E,#1F,#A4,#3D,#A5,#01
	DB	#3A,#88,#2D,#8B,#11,#B2,#01
	DB	#2D,#8B,#13,#9C,#11,#B2,#01
	DB	#07,#77,#2D,#8A,#00,#AA,#01
	DB	#06,#7D,#00,#84,#00,#AA,#01
	DB	#30,#71,#06,#76,#2D,#8A,#01
	DB	#3A,#65,#30,#71,#06,#76,#01
	DB	#3A,#65,#20,#65,#06,#74,#01
	DB	#26,#50,#31,#5B,#06,#74,#01
	DB	#1F,#42,#27,#51,#20,#53,#01
	DB	#80,#08,#71,#0B,#72,#14,#02
	DB	#71,#0B,#5C,#1D,#74,#2C,#02
	DB	#68,#08,#6D,#0E,#5C,#1D,#02
	DB	#60,#08,#65,#0D,#62,#13,#02
	DB	#56,#0C,#62,#13,#5D,#1C,#02
	DB	#4F,#0B,#50,#18,#5A,#1D,#02
	DB	#4A,#16,#5C,#1D,#4C,#26,#02
	DB	#5C,#1D,#4C,#26,#73,#2C,#02
	DB	#4B,#26,#6A,#2A,#6A,#32,#02
	DB	#4B,#26,#6A,#32,#5C,#36,#02
	DB	#45,#23,#2E,#29,#57,#3E,#02
	DB	#45,#23,#5E,#3D,#56,#3F,#02
	DB	#2E,#29,#57,#3E,#3F,#59,#02
	DB	#25,#28,#2E,#29,#3F,#59,#02
	DB	#25,#28,#1E,#3B,#28,#3E,#02
	DB	#1E,#3B,#28,#3E,#23,#4E,#02
	DB	#2C,#34,#23,#4E,#40,#58,#02
	DB	#34,#54,#47,#5C,#2C,#63,#02
	DB	#47,#5C,#3A,#60,#36,#6D,#02
	DB	#22,#6C,#14,#74,#1B,#77,#02
	DB	#35,#6D,#4D,#85,#2E,#89,#02
	DB	#56,#6D,#69,#83,#50,#86,#02
	DB	#70,#83,#3B,#88,#3E,#A4,#02
	DB	#6B,#72,#73,#7D,#6A,#89,#02
	DB	#60,#60,#64,#64,#55,#6C,#02
	DB	#6D,#5D,#60,#60,#6B,#6A,#02
	DB	#78,#5D,#6E,#68,#75,#70,#02
	DB	#79,#5E,#80,#67,#80,#75,#02
	DB	#6D,#46,#7C,#47,#78,#5E,#02
	DB	#79,#43,#5D,#45,#80,#47,#02
	DB	#7C,#36,#80,#3A,#78,#42,#02
	DB	#75,#94,#80,#97,#80,#9C,#02
	DB	#16,#95,#00,#AB,#0E,#B2,#02
	DB	#00,#AB,#07,#AF,#00,#B1,#02
	DB	#1F,#A3,#0E,#B2,#19,#BA,#02
	DB	#0E,#B2,#0E,#BA,#19,#BA,#02
	DB	#28,#B7,#19,#BB,#20,#D0,#02
	DB	#51,#9D,#43,#A8,#4B,#B5,#02
	DB	#43,#A8,#4B,#B5,#3C,#B9,#02
	DB	#3C,#B9,#32,#CC,#3E,#D3,#02
	DB	#5E,#BB,#41,#CD,#4C,#D8,#02
	DB	#41,#CD,#41,#D8,#4C,#D8,#02
	DB	#51,#D1,#45,#E5,#4D,#F0,#02
	DB	#51,#D1,#68,#D1,#4D,#F0,#02
	DB	#68,#D1,#6E,#D7,#4D,#F0,#02
	DB	#74,#E0,#71,#E3,#77,#E6,#02
	DB	#7A,#E1,#80,#E1,#80,#EB,#02
	DB	#64,#6B,#62,#6C,#66,#6E,#02
	DB	#66,#6B,#68,#6C,#64,#6E,#02
	DB	#6D,#6C,#70,#70,#6C,#71,#03
	DB	#5D,#6D,#5C,#71,#5F,#73,#03
	DB	#5E,#6E,#61,#75,#69,#76,#03
	DB	#69,#9A,#6B,#A0,#69,#A1,#03
	DB	#76,#A8,#6F,#AB,#76,#AE,#03
	DB	#76,#AE,#69,#B0,#75,#B3,#03
	DB	#7E,#B0,#67,#B7,#74,#BF,#03
	DB	#7E,#B0,#80,#B5,#74,#BF,#03
	DB	#75,#C3,#69,#C6,#69,#CF,#03
	DB	#75,#C3,#7E,#C6,#69,#CF,#03
	DB	#7E,#C6,#69,#CF,#73,#D4,#03
	DB	#7E,#C6,#80,#D3,#73,#D4,#83
; Taille 735 octets
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
