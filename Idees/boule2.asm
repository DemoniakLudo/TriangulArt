; Généré par TriangulArt le 07/05/2021 (13 04 26)
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

	LD	IX,boule2			; Donnees triangle
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
	LD	HL,NewIrq
	LD	(#39),HL
	EI
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

NewIrq:
	PUSH	AF
	PUSH	BC
	PUSH	DE
	PUSH	HL

	LD	B,#F5
	IN	A,(C)
	RRA
	JR	NC,EndIrq
CntVbl:
	LD	A,0
	INC	A
	LD	(CntVbl+1),A
	CP	8
	JR	C,EndIrq
	XOR	A
	LD	(CntVbl+1),A
	LD	HL,Boule2+1
	LD	DE,Boule2+2
	LD	A,(HL)
	EX	DE,HL
	LDI
	LDI
	LD	(DE),A
	LD	HL,Boule2
	LD	B,#7F
	XOR	A
SetPalIrq:
	OUT	(C),A
	INC	B
	OUTI
	INC	A
	CP	4
	JR	NZ,SetPalIrq
EndIrq:
	POP	HL
	POP	DE
	POP	BC
	POP	AF
	EI
	RET

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
boule2
; 4 octets de palette
	DB	"@SWU"
	DW	#2400			; Tps d'affichage
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
	DB	#80,#80,#9D,#8C,#99,#93,#01
	DB	#80,#80,#9F,#84,#9D,#8C,#02
	DB	#9F,#7B,#80,#80,#9F,#84,#03
	DB	#9D,#73,#9F,#7B,#80,#80,#01
	DB	#99,#6C,#9D,#73,#80,#80,#02
	DB	#93,#66,#99,#6C,#80,#80,#03
	DB	#8C,#62,#93,#66,#80,#80,#01
	DB	#84,#60,#8C,#62,#80,#80,#02
	DB	#7B,#60,#84,#60,#80,#80,#03
	DB	#7B,#60,#73,#62,#80,#80,#01
	DB	#73,#62,#6C,#66,#80,#80,#02
	DB	#6C,#66,#66,#6C,#80,#80,#03
	DB	#66,#6C,#62,#73,#80,#80,#01
	DB	#62,#73,#60,#7B,#80,#80,#02
	DB	#60,#7B,#80,#80,#60,#84,#03
	DB	#80,#80,#60,#84,#62,#8C,#01
	DB	#80,#80,#62,#8C,#66,#93,#02
	DB	#80,#80,#66,#93,#6C,#99,#03
	DB	#80,#80,#6C,#99,#73,#9D,#01
	DB	#80,#80,#73,#9D,#7B,#9F,#02
	DB	#80,#80,#7B,#9F,#84,#9F,#03
	DB	#80,#80,#8C,#9D,#84,#9F,#01
	DB	#80,#80,#93,#99,#8C,#9D,#02
	DB	#80,#80,#99,#93,#93,#99,#03
	DB	#9D,#8C,#99,#93,#B5,#9E,#03
	DB	#93,#99,#8C,#9D,#9E,#B5,#01
	DB	#9F,#84,#9D,#8C,#BB,#90,#01
	DB	#8C,#9D,#84,#9F,#90,#BB,#03
	DB	#9F,#7B,#BD,#80,#9F,#84,#02
	DB	#84,#9F,#7B,#9F,#80,#BD,#02
	DB	#BB,#6F,#9D,#73,#9F,#7B,#03
	DB	#73,#9D,#7B,#9F,#6F,#BB,#01
	DB	#B5,#61,#99,#6C,#9D,#73,#01
	DB	#6C,#99,#73,#9D,#61,#B5,#03
	DB	#AB,#54,#93,#66,#99,#6C,#02
	DB	#99,#93,#93,#99,#AB,#AB,#02
	DB	#9E,#4A,#8C,#62,#93,#66,#03
	DB	#66,#93,#6C,#99,#54,#AB,#02
	DB	#90,#44,#84,#60,#8C,#62,#01
	DB	#62,#8C,#66,#93,#4A,#9E,#01
	DB	#80,#42,#84,#60,#7B,#60,#02
	DB	#60,#84,#62,#8C,#44,#90,#03
	DB	#6F,#44,#7B,#60,#73,#62,#03
	DB	#60,#7B,#42,#80,#60,#84,#02
	DB	#61,#4A,#73,#62,#6C,#66,#01
	DB	#44,#6F,#62,#73,#60,#7B,#01
	DB	#54,#54,#6C,#66,#66,#6C,#02
	DB	#4A,#61,#66,#6C,#62,#73,#03
	DB	#54,#54,#4A,#61,#66,#6C,#02
	DB	#4A,#61,#44,#6F,#62,#73,#03
	DB	#61,#4A,#54,#54,#6C,#66,#01
	DB	#44,#6F,#60,#7B,#42,#80,#01
	DB	#6F,#44,#61,#4A,#73,#62,#03
	DB	#42,#80,#60,#84,#44,#90,#02
	DB	#80,#42,#6F,#44,#7B,#60,#02
	DB	#62,#8C,#44,#90,#4A,#9E,#03
	DB	#80,#42,#90,#44,#84,#60,#01
	DB	#66,#93,#4A,#9E,#54,#AB,#01
	DB	#90,#44,#9E,#4A,#8C,#62,#03
	DB	#6C,#99,#54,#AB,#61,#B5,#02
	DB	#AB,#54,#B5,#61,#99,#6C,#01
	DB	#73,#9D,#61,#B5,#6F,#BB,#03
	DB	#B5,#61,#BB,#6F,#9D,#73,#03
	DB	#7B,#9F,#6F,#BB,#80,#BD,#01
	DB	#BB,#6F,#9F,#7B,#BD,#80,#02
	DB	#84,#9F,#90,#BB,#80,#BD,#02
	DB	#BD,#80,#9F,#84,#BB,#90,#01
	DB	#8C,#9D,#9E,#B5,#90,#BB,#03
	DB	#9D,#8C,#BB,#90,#B5,#9E,#03
	DB	#93,#99,#AB,#AB,#9E,#B5,#01
	DB	#9E,#4A,#AB,#54,#93,#66,#02
	DB	#99,#93,#B5,#9E,#AB,#AB,#02
	DB	#BB,#90,#B5,#9E,#D1,#A1,#02
	DB	#AB,#AB,#9E,#B5,#B5,#C5,#03
	DB	#BD,#80,#D7,#8B,#BB,#90,#03
	DB	#9E,#B5,#90,#BB,#A1,#D1,#02
	DB	#BB,#6F,#D7,#74,#BD,#80,#01
	DB	#90,#BB,#80,#BD,#8B,#D7,#01
	DB	#D1,#5E,#B5,#61,#BB,#6F,#02
	DB	#6F,#BB,#80,#BD,#74,#D7,#03
	DB	#C5,#4A,#AB,#54,#B5,#61,#03
	DB	#61,#B5,#6F,#BB,#5E,#D1,#02
	DB	#B5,#3A,#9E,#4A,#AB,#54,#01
	DB	#54,#AB,#61,#B5,#4A,#C5,#01
	DB	#A1,#2E,#90,#44,#9E,#4A,#02
	DB	#4A,#9E,#54,#AB,#3A,#B5,#03
	DB	#8B,#28,#80,#42,#90,#44,#03
	DB	#44,#90,#4A,#9E,#2E,#A1,#02
	DB	#74,#28,#80,#42,#6F,#44,#01
	DB	#42,#80,#28,#8B,#44,#90,#01
	DB	#5E,#2E,#6F,#44,#61,#4A,#02
	DB	#44,#6F,#28,#74,#42,#80,#03
	DB	#4A,#3A,#61,#4A,#54,#54,#03
	DB	#2E,#5E,#4A,#61,#44,#6F,#02
	DB	#3A,#4A,#54,#54,#4A,#61,#01
	DB	#B5,#9E,#AB,#AB,#C5,#B5,#01
	DB	#4A,#3A,#3A,#4A,#54,#54,#03
	DB	#2E,#5E,#44,#6F,#28,#74,#02
	DB	#5E,#2E,#4A,#3A,#61,#4A,#02
	DB	#28,#74,#42,#80,#28,#8B,#03
	DB	#74,#28,#5E,#2E,#6F,#44,#01
	DB	#28,#8B,#44,#90,#2E,#A1,#01
	DB	#74,#28,#8B,#28,#80,#42,#03
	DB	#4A,#9E,#2E,#A1,#3A,#B5,#02
	DB	#8B,#28,#A1,#2E,#90,#44,#02
	DB	#54,#AB,#3A,#B5,#4A,#C5,#03
	DB	#A1,#2E,#B5,#3A,#9E,#4A,#01
	DB	#61,#B5,#4A,#C5,#5E,#D1,#01
	DB	#B5,#3A,#C5,#4A,#AB,#54,#03
	DB	#6F,#BB,#5E,#D1,#74,#D7,#02
	DB	#C5,#4A,#D1,#5E,#B5,#61,#02
	DB	#80,#BD,#74,#D7,#8B,#D7,#03
	DB	#D1,#5E,#BB,#6F,#D7,#74,#01
	DB	#90,#BB,#A1,#D1,#8B,#D7,#01
	DB	#D7,#74,#BD,#80,#D7,#8B,#03
	DB	#9E,#B5,#B5,#C5,#A1,#D1,#02
	DB	#D7,#8B,#BB,#90,#D1,#A1,#02
	DB	#AB,#AB,#C5,#B5,#B5,#C5,#03
	DB	#3A,#4A,#2E,#5E,#4A,#61,#01
	DB	#B5,#9E,#D1,#A1,#C5,#B5,#01
	DB	#D7,#8B,#E8,#9B,#D1,#A1,#01
	DB	#C5,#B5,#B5,#C5,#CC,#CC,#02
	DB	#D7,#74,#EB,#80,#D7,#8B,#02
	DB	#B5,#C5,#A1,#D1,#B5,#DD,#01
	DB	#D1,#5E,#E8,#64,#D7,#74,#03
	DB	#C5,#4A,#DD,#4A,#D1,#5E,#01
	DB	#CC,#33,#B5,#3A,#C5,#4A,#02
	DB	#B5,#22,#A1,#2E,#B5,#3A,#03
	DB	#4A,#C5,#5E,#D1,#4A,#DD,#03
	DB	#9B,#17,#8B,#28,#A1,#2E,#01
	DB	#3A,#B5,#4A,#C5,#33,#CC,#02
	DB	#80,#14,#8B,#28,#74,#28,#02
	DB	#2E,#A1,#3A,#B5,#22,#B5,#01
	DB	#64,#17,#74,#28,#5E,#2E,#03
	DB	#28,#8B,#17,#9B,#2E,#A1,#03
	DB	#4A,#22,#5E,#2E,#4A,#3A,#01
	DB	#28,#74,#14,#80,#28,#8B,#02
	DB	#33,#33,#4A,#3A,#3A,#4A,#02
	DB	#2E,#5E,#17,#64,#28,#74,#01
	DB	#3A,#4A,#22,#4A,#2E,#5E,#03
	DB	#D1,#A1,#C5,#B5,#DD,#B5,#03
	DB	#33,#33,#22,#4A,#3A,#4A,#02
	DB	#17,#64,#28,#74,#14,#80,#01
	DB	#4A,#22,#33,#33,#4A,#3A,#01
	DB	#14,#80,#28,#8B,#17,#9B,#02
	DB	#64,#17,#4A,#22,#5E,#2E,#03
	DB	#17,#9B,#2E,#A1,#22,#B5,#03
	DB	#80,#14,#64,#17,#74,#28,#02
	DB	#22,#B5,#3A,#B5,#33,#CC,#01
	DB	#80,#14,#9B,#17,#8B,#28,#01
	DB	#4A,#C5,#33,#CC,#4A,#DD,#02
	DB	#9B,#17,#B5,#22,#A1,#2E,#03
	DB	#5E,#D1,#4A,#DD,#64,#E8,#03
	DB	#B5,#22,#CC,#33,#B5,#3A,#02
	DB	#74,#D7,#64,#E8,#80,#EB,#01
	DB	#CC,#33,#DD,#4A,#C5,#4A,#01
	DB	#8B,#D7,#9B,#E8,#80,#EB,#02
	DB	#DD,#4A,#D1,#5E,#E8,#64,#03
	DB	#A1,#D1,#B5,#DD,#9B,#E8,#03
	DB	#E8,#64,#D7,#74,#EB,#80,#02
	DB	#B5,#C5,#CC,#CC,#B5,#DD,#01
	DB	#EB,#80,#D7,#8B,#E8,#9B,#01
	DB	#DD,#B5,#C5,#B5,#CC,#CC,#02
	DB	#22,#4A,#2E,#5E,#17,#64,#03
	DB	#E8,#9B,#D1,#A1,#DD,#B5,#03
	DB	#EB,#80,#F7,#8F,#E8,#9B,#03
	DB	#DD,#B5,#DF,#C9,#CC,#CC,#01
	DB	#E8,#64,#F7,#70,#EB,#80,#01
	DB	#CC,#CC,#B5,#DD,#C9,#DF,#03
	DB	#DD,#4A,#EF,#51,#E8,#64,#02
	DB	#B5,#DD,#9B,#E8,#AE,#EF,#02
	DB	#CC,#33,#DF,#36,#DD,#4A,#03
	DB	#9B,#E8,#80,#EB,#8F,#F7,#01
	DB	#C9,#20,#B5,#22,#CC,#33,#01
	DB	#64,#E8,#80,#EB,#70,#F7,#03
	DB	#AE,#10,#9B,#17,#B5,#22,#02
	DB	#4A,#DD,#64,#E8,#51,#EF,#02
	DB	#8F,#08,#80,#14,#9B,#17,#03
	DB	#33,#CC,#4A,#DD,#36,#DF,#01
	DB	#70,#08,#80,#14,#64,#17,#01
	DB	#22,#B5,#20,#C9,#33,#CC,#03
	DB	#51,#10,#64,#17,#4A,#22,#02
	DB	#17,#9B,#10,#AE,#22,#B5,#02
	DB	#36,#20,#4A,#22,#33,#33,#03
	DB	#14,#80,#08,#8F,#17,#9B,#01
	DB	#33,#33,#20,#36,#22,#4A,#01
	DB	#17,#64,#08,#70,#14,#80,#03
	DB	#22,#4A,#10,#51,#17,#64,#02
	DB	#E8,#9B,#EF,#AE,#DD,#B5,#02
	DB	#20,#36,#22,#4A,#10,#51,#01
	DB	#08,#70,#14,#80,#08,#8F,#03
	DB	#36,#20,#33,#33,#20,#36,#03
	DB	#08,#8F,#17,#9B,#10,#AE,#01
	DB	#51,#10,#36,#20,#4A,#22,#02
	DB	#10,#AE,#22,#B5,#20,#C9,#02
	DB	#70,#08,#51,#10,#64,#17,#01
	DB	#20,#C9,#33,#CC,#36,#DF,#03
	DB	#70,#08,#8F,#08,#80,#14,#03
	DB	#4A,#DD,#36,#DF,#51,#EF,#01
	DB	#8F,#08,#AE,#10,#9B,#17,#02
	DB	#64,#E8,#51,#EF,#70,#F7,#02
	DB	#AE,#10,#C9,#20,#B5,#22,#01
	DB	#80,#EB,#70,#F7,#8F,#F7,#03
	DB	#C9,#20,#CC,#33,#DF,#36,#03
	DB	#9B,#E8,#AE,#EF,#8F,#F7,#01
	DB	#DF,#36,#DD,#4A,#EF,#51,#02
	DB	#B5,#DD,#C9,#DF,#AE,#EF,#02
	DB	#EF,#51,#E8,#64,#F7,#70,#01
	DB	#DF,#C9,#CC,#CC,#C9,#DF,#03
	DB	#F7,#70,#EB,#80,#F7,#8F,#03
	DB	#EF,#AE,#DD,#B5,#DF,#C9,#01
	DB	#10,#51,#17,#64,#08,#70,#02
	DB	#F7,#8F,#E8,#9B,#EF,#AE,#02
	DB	#5E,#D1,#74,#D7,#64,#E8,#01
	DB	#74,#D7,#8B,#D7,#80,#EB,#02
	DB	#A1,#D1,#8B,#D7,#9B,#E8,#83
; Taille 1512 octets
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
