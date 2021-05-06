; Généré par TriangulArt le 05/05/2021 (19 44 12)
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
	DB	"G_[K"
	DW	#2000			; Tps d'affichage ?
	DB	#00
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#92,#2C,#85,#37,#9F,#57,#01
	DB	#92,#2C,#A6,#36,#9E,#57,#01
	DB	#AB,#3A,#9E,#57,#AE,#62,#01
	DB	#A6,#36,#AB,#3A,#9E,#56,#01
	DB	#B5,#39,#C3,#3C,#AC,#69,#01
	DB	#C3,#3C,#AC,#6A,#B1,#6E,#01
	DB	#C3,#3D,#CA,#4D,#B1,#6E,#01
	DB	#B9,#79,#BF,#81,#B2,#88,#01
	DB	#BF,#81,#B2,#88,#BC,#96,#01
	DB	#BD,#92,#BB,#95,#C2,#9F,#01
	DB	#D4,#80,#BF,#84,#DC,#A4,#01
	DB	#D2,#7F,#E3,#95,#DC,#A4,#01
	DB	#F0,#60,#EF,#67,#F7,#68,#01
	DB	#F6,#60,#EF,#60,#F7,#68,#01
	DB	#88,#40,#8E,#72,#7A,#7F,#01
	DB	#88,#40,#7A,#68,#7A,#7F,#01
	DB	#63,#3E,#44,#40,#58,#78,#01
	DB	#5B,#7F,#71,#90,#66,#99,#01
	DB	#5B,#7F,#7A,#81,#71,#90,#01
	DB	#33,#74,#58,#7B,#3F,#95,#01
	DB	#33,#49,#10,#58,#33,#6E,#01
	DB	#20,#7E,#11,#87,#3F,#98,#01
	DB	#11,#87,#3F,#98,#37,#A0,#01
	DB	#07,#78,#12,#83,#04,#87,#01
	DB	#18,#8E,#20,#A0,#15,#B3,#01
	DB	#19,#8E,#0C,#9E,#15,#B3,#01
	DB	#74,#95,#86,#BB,#75,#BD,#01
	DB	#7B,#88,#8A,#9D,#86,#BB,#01
	DB	#7B,#88,#73,#97,#85,#BA,#01
	DB	#A5,#90,#89,#9E,#9D,#B3,#01
	DB	#A5,#90,#AE,#AB,#9B,#B2,#01
	DB	#B6,#3C,#A9,#3D,#AF,#58,#02
	DB	#C6,#51,#B0,#6C,#C1,#82,#02
	DB	#C6,#54,#D2,#7A,#C3,#7D,#02
	DB	#E4,#94,#EA,#95,#DC,#A6,#02
	DB	#EA,#94,#F3,#A1,#DD,#A4,#02
	DB	#F8,#75,#EA,#95,#F3,#A0,#02
	DB	#F1,#74,#F7,#76,#EA,#95,#02
	DB	#F9,#66,#F1,#68,#F7,#74,#02
	DB	#F9,#66,#FE,#73,#F6,#75,#02
	DB	#AB,#5D,#95,#6D,#A8,#7F,#02
	DB	#AB,#5D,#B7,#6C,#AA,#7F,#02
	DB	#A8,#5F,#8D,#63,#97,#6D,#02
	DB	#87,#46,#A8,#5E,#8E,#61,#02
	DB	#8F,#73,#A2,#79,#79,#84,#02
	DB	#78,#87,#A9,#8F,#8E,#9A,#02
	DB	#97,#7F,#77,#88,#A9,#8F,#02
	DB	#AB,#AD,#9B,#B2,#A3,#C5,#02
	DB	#AB,#AD,#B1,#BF,#A2,#C5,#02
	DB	#B7,#BF,#9F,#C6,#A2,#CD,#02
	DB	#B7,#BF,#B5,#C8,#A2,#CC,#02
	DB	#85,#BC,#76,#BF,#73,#C8,#02
	DB	#85,#BC,#74,#C8,#85,#CB,#02
	DB	#85,#BC,#8B,#C6,#85,#CB,#02
	DB	#86,#43,#67,#46,#7C,#6C,#02
	DB	#63,#47,#7C,#6C,#58,#80,#02
	DB	#75,#74,#62,#7A,#74,#82,#02
	DB	#44,#42,#3A,#71,#58,#78,#02
	DB	#45,#42,#2D,#44,#3A,#71,#02
	DB	#13,#5B,#31,#70,#0A,#77,#02
	DB	#2C,#71,#0A,#77,#13,#85,#02
	DB	#31,#72,#23,#7E,#41,#99,#02
	DB	#59,#80,#3F,#94,#55,#A0,#02
	DB	#59,#83,#64,#97,#57,#99,#02
	DB	#1A,#8F,#2B,#B0,#3D,#C0,#02
	DB	#19,#8F,#38,#A1,#3D,#C0,#02
	DB	#0B,#A3,#01,#BA,#08,#C3,#02
	DB	#0B,#A3,#08,#C4,#1E,#C5,#02
	DB	#24,#AD,#24,#BE,#2D,#C6,#02
	DB	#23,#AA,#2D,#C6,#46,#C9,#82
; Taille 490 octets
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
