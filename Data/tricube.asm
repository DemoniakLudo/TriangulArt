; Généré par TriangulArt le 05/05/2021 (12 32 19)
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
	DB	"KVNT"
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
	DB	#B2,#1E,#B2,#36,#9C,#43,#02
	DB	#80,#00,#80,#19,#4E,#1E,#01
	DB	#80,#19,#4E,#1E,#65,#2A,#01
	DB	#80,#00,#80,#19,#B2,#1E,#01
	DB	#80,#19,#B2,#1E,#9C,#2A,#01
	DB	#4E,#1E,#4E,#34,#65,#43,#03
	DB	#4F,#83,#4F,#9B,#65,#AA,#03
	DB	#44,#24,#5A,#30,#12,#41,#01
	DB	#5A,#30,#3E,#41,#12,#41,#01
	DB	#59,#96,#3E,#A6,#3E,#C0,#02
	DB	#3E,#87,#28,#94,#28,#CC,#02
	DB	#BC,#23,#A7,#30,#EE,#41,#01
	DB	#3E,#87,#3E,#C0,#28,#CC,#02
	DB	#A7,#30,#C2,#40,#EE,#41,#01
	DB	#59,#96,#59,#AF,#3E,#C0,#02
	DB	#A7,#50,#A7,#6A,#BC,#77,#03
	DB	#C2,#40,#EE,#41,#A7,#50,#01
	DB	#EE,#41,#A7,#50,#BC,#5C,#01
	DB	#9C,#56,#B2,#63,#4F,#83,#01
	DB	#B2,#63,#4F,#83,#65,#90,#01
	DB	#43,#89,#3E,#8D,#3E,#A6,#01
	DB	#43,#89,#59,#96,#3E,#A6,#01
	DB	#59,#B6,#44,#C3,#44,#DC,#02
	DB	#59,#B6,#59,#CF,#44,#DC,#02
	DB	#3E,#A6,#28,#B3,#59,#B6,#01
	DB	#28,#B3,#59,#B6,#44,#C3,#01
	DB	#65,#BC,#4F,#C9,#6A,#D9,#01
	DB	#A7,#B6,#A7,#D0,#BD,#DD,#03
	DB	#65,#BC,#6A,#BF,#6A,#D9,#01
	DB	#9C,#BB,#96,#C0,#B2,#C9,#01
	DB	#96,#C0,#B2,#C9,#96,#D9,#01
	DB	#D8,#B3,#A7,#B6,#BD,#C3,#01
	DB	#C2,#A6,#D8,#B3,#A7,#B6,#01
	DB	#BD,#89,#C2,#8D,#C2,#A6,#01
	DB	#80,#46,#6A,#53,#80,#60,#01
	DB	#80,#46,#96,#53,#80,#60,#01
	DB	#28,#7A,#12,#87,#28,#94,#01
	DB	#28,#7A,#3E,#87,#28,#94,#01
	DB	#80,#AB,#6A,#B8,#80,#C5,#01
	DB	#80,#AB,#96,#B8,#80,#C5,#01
	DB	#D8,#7A,#C2,#87,#D8,#94,#01
	DB	#D8,#7A,#EE,#87,#D8,#94,#01
	DB	#80,#19,#65,#2A,#65,#43,#02
	DB	#80,#19,#80,#33,#65,#43,#02
	DB	#B2,#1E,#9C,#2A,#9C,#43,#02
	DB	#96,#26,#80,#33,#80,#54,#02
	DB	#96,#26,#96,#46,#80,#54,#02
	DB	#B2,#63,#B2,#7D,#65,#AA,#02
	DB	#B2,#83,#9C,#90,#9C,#AA,#02
	DB	#B2,#83,#B2,#9E,#9C,#AA,#02
	DB	#BD,#89,#A7,#96,#C2,#A6,#01
	DB	#B2,#63,#65,#90,#65,#AA,#02
	DB	#96,#8D,#80,#9A,#80,#B9,#02
	DB	#3E,#41,#3E,#7A,#28,#86,#02
	DB	#96,#8D,#96,#AD,#80,#B9,#02
	DB	#58,#50,#58,#6A,#44,#77,#02
	DB	#4E,#64,#B2,#83,#9C,#90,#01
	DB	#65,#57,#4E,#64,#B2,#83,#01
	DB	#96,#53,#80,#60,#80,#80,#02
	DB	#3E,#41,#28,#4E,#28,#86,#02
	DB	#96,#53,#96,#73,#80,#80,#02
	DB	#5A,#30,#5A,#4A,#3E,#58,#02
	DB	#5A,#30,#3E,#41,#3E,#58,#02
	DB	#12,#41,#58,#50,#44,#5E,#01
	DB	#3E,#41,#12,#41,#58,#50,#01
	DB	#58,#50,#44,#5D,#44,#77,#02
	DB	#96,#B8,#80,#C5,#80,#FF,#02
	DB	#96,#B8,#96,#F3,#80,#FF,#02
	DB	#B2,#C9,#96,#D9,#96,#F3,#02
	DB	#B2,#C9,#B2,#E2,#96,#F3,#02
	DB	#EE,#87,#D8,#94,#EE,#BE,#02
	DB	#D8,#94,#EE,#BE,#D8,#CC,#02
	DB	#D8,#B3,#BD,#C3,#BD,#DD,#02
	DB	#D8,#B3,#D8,#CC,#BD,#DD,#02
	DB	#D8,#4C,#BC,#5C,#BC,#77,#02
	DB	#EE,#40,#EE,#79,#D8,#87,#02
	DB	#EE,#40,#D8,#4C,#D8,#87,#02
	DB	#D8,#4C,#D8,#66,#BC,#77,#02
	DB	#80,#19,#9C,#2A,#80,#33,#03
	DB	#9C,#2A,#80,#33,#9C,#43,#03
	DB	#A7,#30,#C2,#40,#A7,#4A,#03
	DB	#C2,#40,#A7,#4A,#AC,#4D,#03
	DB	#12,#41,#44,#5E,#44,#78,#03
	DB	#12,#41,#28,#4E,#28,#86,#03
	DB	#12,#41,#12,#79,#28,#86,#03
	DB	#12,#41,#12,#5C,#44,#78,#03
	DB	#6A,#53,#80,#60,#6A,#74,#03
	DB	#80,#60,#6A,#74,#80,#80,#03
	DB	#80,#80,#80,#9A,#9C,#AA,#03
	DB	#80,#80,#9C,#90,#9C,#AA,#03
	DB	#4E,#64,#6B,#74,#4E,#7C,#03
	DB	#6A,#74,#4E,#7C,#54,#80,#03
	DB	#4F,#83,#65,#90,#65,#AA,#03
	DB	#80,#9A,#6A,#AC,#80,#B9,#03
	DB	#80,#9A,#6A,#A7,#6A,#AC,#03
	DB	#80,#33,#6A,#47,#80,#54,#03
	DB	#80,#33,#6A,#40,#6A,#47,#03
	DB	#D8,#66,#C2,#79,#D8,#86,#03
	DB	#D8,#66,#C2,#73,#C2,#79,#03
	DB	#4E,#1E,#65,#2A,#65,#43,#03
	DB	#A7,#50,#BC,#5C,#BC,#77,#03
	DB	#A7,#96,#C2,#A6,#A7,#AF,#03
	DB	#C2,#A6,#A7,#AF,#AD,#B3,#03
	DB	#A7,#B6,#BD,#C3,#BD,#DD,#03
	DB	#C2,#87,#D8,#94,#D8,#B3,#03
	DB	#C2,#87,#C2,#A6,#D8,#B3,#03
	DB	#6A,#B8,#80,#C5,#80,#FF,#03
	DB	#6A,#B8,#6A,#F2,#80,#FF,#03
	DB	#4F,#C8,#4F,#E2,#80,#FF,#03
	DB	#4F,#C9,#6A,#D9,#6A,#F0,#03
	DB	#12,#87,#28,#94,#28,#CC,#03
	DB	#12,#87,#12,#BF,#28,#CC,#03
	DB	#44,#C3,#28,#CC,#44,#DC,#03
	DB	#28,#B3,#44,#C3,#28,#CC,#83
; Taille 798 octets
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
