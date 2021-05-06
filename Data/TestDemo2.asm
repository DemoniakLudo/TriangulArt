; Généré par TriangulArt le 11/04/2021 (11 33 34)
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

Init
	LD	IX,Frame_0
Boucle:
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
	LD	BC,#BC0C
	OUT	(C),C
	LD	BC,#BD10
	OUT	(C),C
	LD	HL,#C000
	LD	DE,#C001
	LD	BC,#3FFF
	LD	(HL),L
	LDIR
	LD	BC,#BD30
	OUT	(C),C
	POP	IX
	CALL	DrawFrame
	LD	HL,0
Wait1:
	DEC	HL
	LD	B,8
Wait2:
	DJNZ	Wait2
	LD	A,H
	OR	L
	JR	NZ,Wait1
	LD	A,(IX+0)
	INC	A
	JR	NZ,Boucle
	JR	Init

DrawFrame:
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
	DEC	HL
	LD	A,H
	OR	L
	JR	NZ,WaitTriangle1
	LD	A,(IX+6)
	LD	BC,7
	ADD	IX,BC
	RLA
	JR	NC,BclDrawFrame
	RET

DrawTriangle
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

	nolist

;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
Frame_0
_Impact
	DB	"XCNL"
	DW	#400
	DB	0	; mode (0=normal, 1=miroir vertical)
	DB	#00,#64,#00,#96,#0A,#96,#01
	DB	#00,#64,#0A,#64,#0A,#96,#01
	DB	#0A,#64,#0A,#96,#0F,#96,#02
	DB	#0A,#64,#0F,#64,#0F,#96,#02
	DB	#14,#64,#14,#96,#1E,#96,#01
	DB	#14,#64,#1E,#64,#1E,#96,#01
	DB	#1E,#78,#1E,#96,#23,#96,#02
	DB	#1E,#78,#23,#7D,#23,#96,#02
	DB	#1E,#64,#28,#6E,#1E,#78,#01
	DB	#1E,#64,#23,#64,#28,#6E,#02
	DB	#23,#64,#2A,#6B,#28,#6E,#02
	DB	#28,#6E,#1E,#78,#32,#78,#01
	DB	#1E,#78,#32,#78,#28,#82,#01
	DB	#32,#78,#2D,#82,#28,#82,#02
	DB	#32,#78,#32,#7D,#2D,#82,#02
	DB	#32,#64,#28,#6E,#32,#78,#01
	DB	#32,#64,#32,#96,#3C,#96,#01
	DB	#3C,#64,#32,#64,#3C,#96,#01
	DB	#3C,#64,#3C,#96,#41,#96,#02
	DB	#3C,#64,#41,#64,#41,#96,#02
	DB	#46,#64,#46,#96,#50,#96,#01
	DB	#46,#64,#50,#64,#50,#96,#01
	DB	#50,#6E,#50,#78,#55,#78,#02
	DB	#50,#6E,#55,#6E,#55,#78,#02
	DB	#50,#82,#50,#96,#55,#96,#02
	DB	#50,#82,#55,#82,#55,#96,#02
	DB	#50,#64,#50,#6E,#64,#6E,#01
	DB	#50,#64,#64,#64,#64,#6E,#01
	DB	#50,#78,#50,#82,#64,#82,#01
	DB	#50,#78,#64,#78,#64,#82,#01
	DB	#64,#64,#64,#82,#6E,#82,#01
	DB	#64,#64,#6E,#64,#6E,#82,#01
	DB	#6E,#64,#6E,#82,#73,#82,#02
	DB	#6E,#64,#73,#64,#73,#82,#02
	DB	#87,#64,#73,#96,#82,#96,#01
	DB	#87,#64,#8C,#7D,#82,#96,#01
	DB	#87,#64,#91,#64,#8C,#7D,#01
	DB	#8C,#7D,#82,#96,#87,#96,#02
	DB	#8C,#7D,#8E,#82,#87,#96,#02
	DB	#91,#64,#8C,#7D,#96,#96,#01
	DB	#91,#64,#96,#96,#A5,#96,#01
	DB	#91,#64,#96,#64,#A5,#96,#02
	DB	#96,#64,#A5,#96,#AA,#96,#02
	DB	#B4,#64,#AA,#6E,#AA,#8C,#01
	DB	#B4,#64,#AA,#8C,#B4,#96,#01
	DB	#B4,#64,#C3,#64,#B4,#73,#01
	DB	#C3,#64,#B9,#6E,#C3,#6E,#01
	DB	#BE,#6E,#B9,#6E,#B9,#73,#02
	DB	#B9,#6E,#B4,#73,#B9,#73,#02
	DB	#B4,#73,#B4,#87,#B9,#87,#02
	DB	#B4,#73,#B9,#73,#B9,#87,#02
	DB	#B4,#87,#B4,#96,#C3,#96,#01
	DB	#B9,#8C,#C3,#8C,#C3,#96,#01
	DB	#B4,#87,#B9,#87,#B9,#8C,#02
	DB	#B9,#87,#B9,#8C,#BE,#8C,#02
	DB	#C3,#64,#C3,#6E,#D2,#6E,#01
	DB	#C3,#64,#C8,#64,#D2,#6E,#01
	DB	#C3,#6E,#D2,#6E,#C8,#73,#01
	DB	#D2,#6E,#C8,#73,#D2,#78,#01
	DB	#C8,#73,#C8,#78,#D2,#78,#01
	DB	#CD,#64,#D2,#6E,#D7,#6E,#02
	DB	#CD,#64,#C8,#64,#D2,#6E,#02
	DB	#D2,#6E,#D2,#78,#D7,#78,#02
	DB	#D2,#6E,#D7,#6E,#D7,#78,#02
	DB	#C3,#8C,#D2,#8C,#C3,#96,#01
	DB	#D2,#8C,#C3,#96,#C8,#96,#01
	DB	#C8,#87,#C3,#8C,#D2,#8C,#01
	DB	#D2,#82,#C8,#87,#D2,#8C,#01
	DB	#C8,#82,#D2,#82,#C8,#87,#01
	DB	#D2,#82,#D7,#8C,#D2,#8C,#02
	DB	#D2,#82,#D7,#82,#D7,#8C,#02
	DB	#D2,#8C,#C8,#96,#CD,#96,#02
	DB	#D2,#8C,#D7,#8C,#CD,#96,#02
	DB	#DC,#64,#FA,#64,#DC,#6E,#01
	DB	#FA,#64,#DC,#6E,#FA,#6E,#01
	DB	#FA,#64,#FA,#6E,#FF,#6E,#02
	DB	#FA,#64,#FF,#64,#FF,#6E,#02
	DB	#E6,#6E,#F0,#6E,#E6,#96,#01
	DB	#F0,#6E,#F0,#96,#E6,#96,#01
	DB	#F0,#6E,#F0,#96,#F5,#96,#02
	DB	#F0,#6E,#F5,#6E,#F5,#96,#82


_TriangulArt
	DB	"XCSL"
	DW	#2000			
	DB	#00
	DB	#0B,#4D,#29,#4D,#06,#57,#01
	DB	#29,#4D,#24,#57,#06,#57,#01
	DB	#10,#57,#1A,#57,#01,#75,#01
	DB	#1A,#57,#0B,#75,#01,#75,#01
	DB	#1C,#61,#12,#75,#17,#75,#01
	DB	#1C,#61,#21,#61,#17,#75,#01
	DB	#21,#61,#2E,#61,#1E,#66,#01
	DB	#2E,#61,#2B,#66,#1B,#66,#01
	DB	#33,#61,#29,#75,#2E,#75,#01
	DB	#33,#61,#38,#61,#2E,#75,#01
	DB	#38,#57,#3D,#57,#35,#5C,#01
	DB	#3D,#57,#3A,#5C,#35,#5C,#01
	DB	#3D,#61,#35,#70,#3A,#70,#01
	DB	#3D,#61,#3F,#66,#3A,#70,#01
	DB	#3D,#61,#47,#61,#3F,#66,#01
	DB	#47,#61,#49,#66,#3F,#66,#01
	DB	#44,#66,#49,#66,#44,#70,#01
	DB	#49,#66,#44,#70,#49,#70,#01
	DB	#4C,#61,#49,#66,#49,#70,#01
	DB	#4C,#61,#51,#61,#49,#70,#01
	DB	#35,#70,#4E,#70,#38,#75,#01
	DB	#4E,#70,#4C,#75,#38,#75,#01
	DB	#5B,#61,#51,#75,#56,#75,#01
	DB	#5B,#61,#60,#61,#56,#75,#01
	DB	#60,#61,#5D,#66,#67,#66,#01
	DB	#60,#61,#6A,#61,#67,#66,#01
	DB	#6A,#61,#6C,#66,#67,#66,#01
	DB	#6C,#66,#67,#66,#60,#75,#01
	DB	#6C,#66,#65,#75,#60,#75,#01
	DB	#7B,#70,#79,#75,#6F,#75,#01
	DB	#7B,#70,#71,#70,#6F,#75,#01
	DB	#74,#61,#6C,#70,#6F,#75,#01
	DB	#74,#61,#76,#66,#6F,#75,#01
	DB	#74,#61,#76,#66,#85,#66,#01
	DB	#74,#61,#83,#61,#85,#66,#01
	DB	#80,#66,#85,#66,#76,#7A,#01
	DB	#85,#66,#7B,#7A,#76,#7A,#01
	DB	#71,#7A,#7B,#7A,#6F,#7F,#01
	DB	#7B,#7A,#79,#7F,#6F,#7F,#01
	DB	#8D,#61,#92,#61,#85,#70,#01
	DB	#92,#61,#8A,#70,#85,#70,#01
	DB	#85,#70,#94,#70,#88,#75,#01
	DB	#94,#70,#92,#75,#88,#75,#01
	DB	#9C,#61,#97,#75,#92,#75,#01
	DB	#9C,#61,#A1,#61,#97,#75,#01
	DB	#AB,#57,#9E,#70,#A3,#70,#01
	DB	#AB,#57,#B0,#57,#A3,#70,#01
	DB	#9E,#70,#A8,#70,#9C,#75,#01
	DB	#A8,#70,#A6,#75,#9C,#75,#01
	DB	#B5,#57,#B0,#61,#B5,#61,#01
	DB	#B5,#57,#BA,#57,#B5,#61,#01
	DB	#C9,#4D,#AB,#75,#C9,#75,#01
	DB	#C9,#4D,#D3,#4D,#C9,#75,#01
	DB	#C7,#5C,#C1,#75,#B5,#75,#00
	DB	#D8,#61,#CE,#75,#D3,#75,#01
	DB	#D8,#61,#DD,#61,#D3,#75,#01
	DB	#DD,#61,#E9,#61,#DA,#66,#01
	DB	#E9,#61,#E7,#66,#DA,#66,#01
	DB	#F6,#57,#FB,#57,#F9,#5C,#01
	DB	#F6,#57,#F4,#5C,#F9,#5C,#01
	DB	#EF,#5C,#FE,#5C,#EC,#61,#01
	DB	#FE,#5C,#FB,#61,#EC,#61,#01
	DB	#F1,#61,#F6,#61,#EA,#70,#01
	DB	#F6,#61,#EF,#70,#EA,#70,#01
	DB	#EA,#70,#F4,#70,#EC,#75,#01
	DB	#F4,#70,#F1,#75,#EC,#75,#81

_Triangle
	DB	"T\LN"
	DW	#2000
	DB	0	; mode (0=normal, 1=miroir vertical)
	DB	#28,#00,#00,#14,#F0,#64,#01
	DB	#00,#14,#A0,#64,#F0,#64,#01
	DB	#00,#14,#A0,#64,#78,#78,#02
	DB	#00,#14,#28,#50,#78,#78,#02
	DB	#00,#14,#00,#DC,#28,#F0,#02
	DB	#00,#14,#28,#50,#28,#F0,#02
	DB	#28,#50,#50,#64,#28,#F0,#03
	DB	#50,#64,#50,#B4,#28,#F0,#03
	DB	#F0,#64,#50,#B4,#28,#F0,#03
	DB	#F0,#64,#F0,#8C,#28,#F0,#03
	DB	#A0,#64,#F0,#64,#50,#8C,#01
	DB	#F0,#64,#50,#8C,#50,#B4,#81

_Batman
	DB	"KTSL"
	DW	#1000
	DB	1	; mode (0=normal, 1=miroir vertical)
	DB	#04,#57,#58,#57,#18,#62,#01
	DB	#58,#57,#18,#62,#23,#6C,#01
	DB	#58,#57,#23,#6C,#29,#76,#01
	DB	#58,#57,#29,#76,#28,#88,#01
	DB	#58,#57,#28,#88,#49,#89,#01
	DB	#58,#57,#49,#89,#58,#8B,#01
	DB	#58,#57,#58,#8B,#6D,#94,#01
	DB	#58,#57,#67,#69,#6D,#94,#01
	DB	#67,#69,#80,#6A,#6D,#94,#01
	DB	#80,#6A,#6D,#94,#76,#9B,#01
	DB	#80,#6A,#76,#9B,#80,#AF,#01
	DB	#7C,#56,#77,#6A,#80,#6A,#81

_Piece
	DB	"@TDL"
	DW	#800	
	DB	#01
	DB	#80,#01,#71,#04,#80,#2C,#01
	DB	#71,#04,#63,#0E,#80,#2C,#01
	DB	#63,#0E,#5A,#1A,#80,#2C,#01
	DB	#5A,#1A,#56,#2B,#80,#2C,#01
	DB	#80,#2C,#5A,#3B,#63,#48,#01
	DB	#56,#2B,#80,#2C,#5A,#3B,#01
	DB	#80,#2C,#63,#48,#69,#4E,#01
	DB	#80,#2C,#69,#4E,#80,#5C,#01
	DB	#69,#4E,#4F,#5C,#80,#5C,#01
	DB	#4F,#5C,#80,#5C,#6B,#66,#01
	DB	#80,#5C,#6B,#66,#64,#A4,#01
	DB	#80,#5C,#57,#C2,#80,#FF,#01
	DB	#5F,#AF,#56,#B6,#58,#C2,#01
	DB	#57,#C2,#3B,#EC,#80,#FF,#01
	DB	#3B,#EC,#3F,#FD,#80,#FF,#01
	DB	#57,#C2,#3C,#DF,#40,#E7,#01
	DB	#3B,#E8,#80,#EB,#80,#EE,#02
	DB	#57,#C3,#7E,#C6,#80,#C8,#02
	DB	#6A,#4E,#80,#50,#80,#53,#02
	DB	#6B,#65,#80,#67,#80,#69,#82

_ChessBoard
; 4 octets de palette
	DB	"@KT["
	DW	#200			; Tps d'affichage ?
	DB	#00
	DB	#F9,#4F,#3B,#50,#EB,#9E,#02
	DB	#3B,#50,#00,#9B,#EB,#9E,#02
	DB	#3B,#50,#52,#50,#4D,#58,#01
	DB	#3B,#50,#4D,#58,#35,#58,#01
	DB	#68,#50,#80,#50,#7C,#58,#01
	DB	#68,#50,#7C,#58,#64,#58,#01
	DB	#98,#50,#AF,#50,#AC,#58,#01
	DB	#98,#50,#AC,#58,#94,#58,#01
	DB	#C7,#50,#E1,#50,#DD,#58,#01
	DB	#4D,#58,#64,#58,#5E,#61,#01
	DB	#C7,#50,#DE,#58,#C5,#58,#01
	DB	#4D,#58,#5E,#61,#46,#61,#01
	DB	#7C,#58,#94,#58,#90,#61,#01
	DB	#7C,#58,#90,#61,#77,#61,#01
	DB	#AC,#58,#C5,#58,#C2,#61,#01
	DB	#2F,#61,#46,#61,#40,#69,#01
	DB	#AC,#58,#C2,#61,#A9,#61,#01
	DB	#2F,#61,#40,#69,#28,#69,#01
	DB	#DE,#58,#F7,#58,#F5,#5F,#01
	DB	#5E,#61,#77,#61,#72,#69,#01
	DB	#DE,#58,#F5,#5F,#DB,#5F,#01
	DB	#5E,#61,#72,#69,#59,#69,#01
	DB	#90,#61,#A9,#61,#A5,#69,#01
	DB	#90,#61,#A5,#69,#8C,#69,#01
	DB	#DC,#5F,#C2,#61,#DA,#69,#01
	DB	#40,#69,#59,#69,#54,#72,#01
	DB	#C2,#61,#DA,#69,#C0,#69,#01
	DB	#40,#69,#54,#72,#3A,#72,#01
	DB	#72,#69,#8C,#69,#87,#72,#01
	DB	#72,#69,#87,#72,#6D,#72,#01
	DB	#A5,#69,#C0,#69,#BC,#72,#01
	DB	#21,#72,#3A,#72,#34,#7B,#01
	DB	#A5,#69,#BC,#72,#A2,#72,#01
	DB	#21,#72,#34,#7B,#19,#7B,#01
	DB	#DA,#69,#F5,#69,#F3,#72,#01
	DB	#54,#72,#6D,#72,#68,#7B,#01
	DB	#DA,#69,#F3,#72,#D7,#72,#01
	DB	#54,#72,#68,#7B,#4E,#7B,#01
	DB	#87,#72,#A2,#72,#9E,#7C,#01
	DB	#87,#72,#82,#7B,#9E,#7C,#01
	DB	#BC,#72,#D7,#72,#D5,#7C,#01
	DB	#34,#7B,#4E,#7B,#48,#85,#01
	DB	#BC,#72,#D5,#7C,#B9,#7C,#01
	DB	#34,#7B,#48,#85,#2C,#85,#01
	DB	#68,#7B,#82,#7B,#7D,#86,#01
	DB	#68,#7B,#7D,#86,#62,#86,#01
	DB	#9E,#7C,#B9,#7C,#B6,#86,#01
	DB	#12,#85,#2C,#85,#25,#90,#01
	DB	#9E,#7C,#B6,#86,#9A,#86,#01
	DB	#12,#85,#25,#90,#09,#90,#01
	DB	#D5,#7C,#F1,#7C,#EF,#86,#01
	DB	#48,#85,#62,#86,#5D,#90,#01
	DB	#D5,#7C,#EF,#86,#D2,#86,#01
	DB	#48,#85,#5D,#90,#40,#90,#01
	DB	#7D,#86,#9A,#86,#95,#91,#01
	DB	#7D,#86,#78,#90,#95,#91,#01
	DB	#B6,#86,#D2,#86,#D0,#91,#01
	DB	#25,#90,#40,#90,#39,#9C,#01
	DB	#B6,#86,#D0,#91,#B3,#91,#01
	DB	#25,#90,#39,#9C,#1D,#9C,#01
	DB	#5D,#90,#78,#90,#73,#9D,#01
	DB	#5D,#90,#57,#9C,#73,#9D,#01
	DB	#95,#91,#B3,#91,#AF,#9E,#01
	DB	#95,#91,#91,#9D,#AF,#9E,#01
	DB	#D0,#91,#EE,#91,#EB,#9E,#01
	DB	#D0,#91,#CD,#9D,#EB,#9E,#81

_Floral
	DB	"CYSO"
	DW	#200			; Tps d'affichage ?
	DB	#01
	DB	#18,#00,#00,#00,#00,#18,#01
	DB	#00,#E7,#00,#FF,#18,#FF,#01
	DB	#30,#00,#00,#30,#30,#30,#02
	DB	#00,#CF,#30,#CF,#30,#FF,#02
	DB	#48,#18,#18,#48,#48,#48,#03
	DB	#18,#B7,#48,#B7,#48,#E7,#03
	DB	#60,#30,#60,#60,#30,#60,#01
	DB	#30,#9F,#60,#9F,#60,#CF,#01
	DB	#78,#48,#78,#78,#48,#78,#02
	DB	#48,#87,#78,#87,#78,#B7,#02
	DB	#80,#6F,#70,#7F,#80,#8E,#03
	DB	#48,#6B,#33,#80,#48,#94,#03
	DB	#32,#6B,#1D,#80,#32,#94,#01
	DB	#1C,#6B,#08,#80,#1C,#94,#82

_Glaive
	DB	"K@FN"
	DW	#1000
	DB	1	; mode (0=normal, 1=miroir vertical)
	DB	#80,#00,#7D,#01,#80,#0A,#01
	DB	#7D,#01,#79,#08,#80,#0A,#01
	DB	#79,#08,#80,#0A,#76,#11,#01
	DB	#80,#0A,#76,#11,#80,#1A,#01
	DB	#76,#11,#74,#1A,#80,#1A,#01
	DB	#74,#1A,#80,#1A,#80,#83,#01
	DB	#74,#1A,#74,#82,#80,#83,#01
	DB	#75,#82,#80,#83,#75,#BA,#01
	DB	#80,#83,#75,#BA,#80,#C2,#01
	DB	#75,#BA,#80,#C2,#72,#CC,#02
	DB	#75,#BA,#69,#CC,#72,#CC,#02
	DB	#6E,#C3,#67,#C9,#69,#CC,#02
	DB	#6F,#B7,#74,#B9,#6E,#C3,#02
	DB	#68,#AF,#6F,#B7,#6E,#C3,#02
	DB	#68,#AF,#5F,#AF,#6E,#C3,#02
	DB	#5F,#AF,#6E,#C3,#67,#C9,#02
	DB	#6E,#C3,#67,#C9,#69,#CC,#02
	DB	#80,#C2,#75,#CA,#77,#CD,#02
	DB	#80,#C2,#80,#CD,#77,#CD,#02
	DB	#77,#CD,#80,#CD,#77,#EF,#03
	DB	#80,#CD,#77,#EF,#80,#F0,#03
	DB	#77,#EF,#80,#F0,#79,#F5,#03
	DB	#80,#F0,#79,#F5,#80,#F9,#03
	DB	#79,#F5,#80,#F9,#78,#FE,#03
	DB	#80,#F9,#78,#FE,#80,#FF,#83

_Apple
	DB	"@TWK"
	DW	#2000
	DB	0	; mode (0=normal, 1=miroir vertical)
	DB	#00,#00,#6C,#7F,#00,#FF,#02
	DB	#00,#00,#85,#00,#6C,#7F,#02
	DB	#6C,#7F,#8E,#7F,#00,#FF,#02
	DB	#8E,#7F,#00,#FF,#99,#FF,#02
	DB	#85,#00,#FF,#00,#6C,#7F,#03
	DB	#FF,#00,#FF,#7F,#6C,#7F,#03
	DB	#8E,#7F,#FF,#FF,#99,#FF,#03
	DB	#8E,#7F,#FF,#7F,#FF,#FF,#03
	DB	#47,#44,#42,#49,#4D,#49,#01
	DB	#42,#49,#4C,#49,#4D,#5D,#01
	DB	#42,#49,#4D,#5D,#42,#5D,#01
	DB	#42,#5D,#4C,#5D,#48,#62,#01
	DB	#B8,#43,#B3,#48,#BE,#48,#01
	DB	#B3,#48,#BD,#48,#BD,#5C,#01
	DB	#B3,#48,#B3,#5C,#BE,#5C,#01
	DB	#B3,#5C,#BD,#5C,#B9,#61,#01
	DB	#36,#9E,#30,#A4,#44,#B7,#01
	DB	#36,#9E,#48,#AF,#44,#B7,#01
	DB	#48,#AF,#44,#B7,#58,#C1,#01
	DB	#48,#AF,#5B,#B8,#58,#C1,#01
	DB	#5B,#B8,#58,#C1,#6E,#C5,#01
	DB	#5B,#B8,#70,#BD,#6E,#C5,#01
	DB	#70,#BD,#6E,#C5,#8D,#C5,#01
	DB	#70,#BD,#8D,#BD,#8D,#C5,#01
	DB	#8D,#BD,#A5,#C0,#8D,#C5,#01
	DB	#A2,#B8,#8D,#BD,#A5,#C0,#01
	DB	#A2,#B8,#B7,#B8,#A5,#C0,#01
	DB	#B3,#B1,#B7,#B8,#A2,#B8,#01
	DB	#C9,#9E,#B3,#B1,#B7,#B8,#01
	DB	#C9,#9E,#CF,#A4,#B7,#B8,#81

_Bidul
	DB	"CNL\"
	DW	#400			; Tps d'affichage ?
	DB	#00
	DB	#28,#68,#1D,#7B,#43,#A7,#02
	DB	#43,#A7,#6C,#D7,#5B,#E0,#01
	DB	#92,#2D,#E3,#44,#C0,#56,#03
	DB	#E3,#44,#C0,#56,#D4,#96,#03
	DB	#3D,#14,#92,#2D,#67,#3D,#03
	DB	#D4,#96,#AE,#AF,#C3,#EC,#03
	DB	#3D,#14,#67,#3D,#28,#68,#03
	DB	#AE,#AF,#6C,#D7,#C3,#EC,#03
	DB	#AA,#10,#C0,#56,#96,#6B,#02
	DB	#C0,#56,#96,#6B,#F3,#84,#01
	DB	#AA,#10,#67,#3D,#96,#6B,#01
	DB	#53,#97,#82,#CB,#6C,#D7,#02
	DB	#96,#6B,#F3,#84,#AE,#AF,#02
	DB	#67,#3D,#36,#51,#96,#6B,#02
	DB	#96,#6B,#AE,#AF,#82,#CB,#01
	DB	#36,#51,#96,#6B,#53,#97,#01
	DB	#96,#6B,#53,#97,#82,#CB,#02
	DB	#34,#37,#13,#C0,#6C,#D7,#83

_Donut
	DB	"XCSL"
	DW	#800
	DB	#00
	DB	#55,#A4,#81,#A4,#8C,#C8,#03
	DB	#8C,#C8,#3E,#EC,#97,#EC,#03
	DB	#C4,#A4,#EA,#B6,#97,#EC,#03
	DB	#B8,#81,#C4,#A4,#81,#A4,#03
	DB	#C4,#A4,#8C,#C8,#97,#EC,#01
	DB	#81,#A4,#C4,#A4,#8C,#C8,#01
	DB	#55,#A4,#60,#C8,#8C,#C8,#01
	DB	#60,#C8,#8C,#C8,#3E,#EC,#01
	DB	#34,#81,#55,#A4,#60,#C8,#03
	DB	#34,#81,#02,#92,#55,#A4,#01
	DB	#B8,#81,#CE,#82,#C4,#A4,#01
	DB	#CE,#82,#C4,#A4,#EA,#B6,#01
	DB	#C4,#5E,#B8,#81,#CE,#82,#03
	DB	#FF,#70,#CE,#82,#EA,#B6,#03
	DB	#0D,#B6,#60,#C8,#3E,#EC,#03
	DB	#02,#92,#0D,#B6,#3E,#EC,#01
	DB	#34,#81,#3E,#A4,#60,#C8,#01
	DB	#3E,#A4,#0D,#B6,#60,#C8,#01
	DB	#CF,#39,#F5,#4C,#FF,#70,#01
	DB	#AE,#5D,#FF,#70,#CE,#82,#01
	DB	#18,#4B,#02,#92,#0D,#B6,#03
	DB	#C4,#17,#CF,#39,#F5,#4C,#03
	DB	#23,#6F,#3E,#A4,#0D,#B6,#03
	DB	#CF,#39,#AE,#5D,#FF,#70,#03
	DB	#23,#6F,#4A,#82,#3E,#A4,#01
	DB	#18,#4B,#23,#6F,#0D,#B6,#01
	DB	#CF,#39,#AE,#5D,#82,#5D,#01
	DB	#6C,#16,#18,#4B,#23,#6F,#03
	DB	#C4,#17,#CF,#39,#77,#39,#01
	DB	#6C,#16,#C4,#17,#77,#39,#03
	DB	#77,#39,#82,#5D,#4A,#82,#01
	DB	#CF,#39,#77,#39,#82,#5D,#03
	DB	#77,#39,#23,#6F,#4A,#82,#03
	DB	#6C,#16,#77,#39,#23,#6F,#81

_Cylindre
	DB	"DUWL"
	DW	#400	
	DB	#00
	DB	#8B,#ED,#5A,#F1,#7A,#F1,#02
	DB	#0D,#53,#08,#64,#02,#6E,#02
	DB	#18,#CA,#30,#DF,#3C,#E5,#01
	DB	#15,#45,#0D,#53,#08,#64,#01
	DB	#08,#AF,#18,#CA,#22,#CD,#02
	DB	#02,#6E,#05,#88,#01,#8F,#02
	DB	#2B,#2E,#25,#40,#15,#45,#01
	DB	#8B,#ED,#6C,#ED,#5A,#F1,#02
	DB	#01,#8F,#0F,#AD,#08,#AF,#01
	DB	#18,#CA,#22,#CD,#3C,#E5,#01
	DB	#3C,#E5,#6C,#ED,#5A,#F1,#01
	DB	#3B,#28,#2B,#2E,#25,#40,#02
	DB	#08,#64,#02,#6E,#05,#88,#02
	DB	#67,#16,#57,#1B,#4C,#23,#02
	DB	#57,#1B,#4C,#23,#3B,#28,#01
	DB	#0F,#AD,#08,#AF,#22,#CD,#02
	DB	#9C,#E6,#6C,#ED,#8B,#ED,#01
	DB	#05,#88,#01,#8F,#0F,#AD,#01
	DB	#15,#45,#19,#60,#08,#64,#02
	DB	#4D,#DF,#3C,#E5,#6C,#ED,#01
	DB	#22,#CD,#4D,#DF,#3C,#E5,#02
	DB	#25,#40,#15,#45,#19,#60,#02
	DB	#3B,#28,#36,#3A,#25,#40,#02
	DB	#9C,#E6,#7C,#E6,#6C,#ED,#02
	DB	#F4,#50,#FD,#74,#A3,#74,#01
	DB	#08,#64,#17,#84,#05,#88,#01
	DB	#E1,#2F,#F4,#50,#A3,#74,#02
	DB	#0F,#AD,#33,#C8,#22,#CD,#01
	DB	#4D,#DF,#7C,#E6,#6C,#ED,#02
	DB	#4C,#23,#3B,#28,#36,#3A,#01
	DB	#33,#C8,#22,#CD,#4D,#DF,#02
	DB	#A3,#74,#FD,#74,#FC,#98,#02
	DB	#05,#88,#20,#A8,#0F,#AD,#02
	DB	#67,#16,#5C,#1E,#4C,#23,#02
	DB	#19,#60,#08,#64,#17,#84,#01
	DB	#79,#10,#67,#16,#5C,#1E,#02
	DB	#C7,#18,#E1,#2F,#A3,#74,#01
	DB	#AC,#E2,#7C,#E6,#9C,#E6,#02
	DB	#A3,#74,#FC,#98,#EE,#B7,#01
	DB	#17,#84,#05,#88,#20,#A8,#02
	DB	#20,#A8,#0F,#AD,#33,#C8,#01
	DB	#25,#40,#2A,#5A,#19,#60,#01
	DB	#A9,#0B,#C7,#18,#A3,#74,#02
	DB	#5C,#DA,#4D,#DF,#7C,#E6,#02
	DB	#33,#C8,#5C,#DA,#4D,#DF,#01
	DB	#36,#3A,#25,#40,#2A,#5A,#01
	DB	#A3,#74,#EE,#B7,#DA,#CF,#02
	DB	#AC,#E2,#8D,#E2,#7C,#E6,#02
	DB	#4C,#23,#47,#36,#36,#3A,#01
	DB	#5C,#1E,#4C,#23,#47,#36,#02
	DB	#19,#60,#28,#7F,#17,#84,#02
	DB	#20,#A8,#43,#C2,#33,#C8,#02
	DB	#5C,#DA,#8D,#E2,#7C,#E6,#01
	DB	#17,#84,#30,#A3,#20,#A8,#01
	DB	#A9,#0B,#89,#0B,#A3,#74,#01
	DB	#79,#10,#6E,#17,#5C,#1E,#02
	DB	#43,#C2,#33,#C8,#5C,#DA,#01
	DB	#2A,#5A,#19,#60,#28,#7F,#02
	DB	#89,#0B,#79,#10,#6E,#17,#01
	DB	#BC,#DB,#8D,#E2,#AC,#E2,#01
	DB	#A3,#74,#DA,#CF,#BC,#DB,#01
	DB	#28,#7F,#17,#84,#30,#A3,#01
	DB	#30,#A3,#20,#A8,#43,#C2,#02
	DB	#6E,#D5,#5C,#DA,#8D,#E2,#01
	DB	#36,#3A,#3A,#55,#2A,#5A,#02
	DB	#89,#0B,#6E,#17,#A3,#74,#02
	DB	#43,#C2,#6E,#D5,#5C,#DA,#02
	DB	#47,#36,#36,#3A,#3A,#55,#02
	DB	#BC,#DB,#9E,#DC,#8D,#E2,#01
	DB	#5C,#1E,#58,#2F,#47,#36,#02
	DB	#A3,#74,#BC,#DB,#9E,#DC,#02
	DB	#2A,#5A,#38,#79,#28,#7F,#01
	DB	#6E,#D5,#9E,#DC,#8D,#E2,#02
	DB	#30,#A3,#55,#BD,#43,#C2,#01
	DB	#6E,#17,#5C,#1E,#58,#2F,#01
	DB	#28,#7F,#41,#9D,#30,#A3,#02
	DB	#55,#BD,#43,#C2,#6E,#D5,#02
	DB	#6E,#17,#58,#2F,#A3,#74,#01
	DB	#3A,#55,#2A,#5A,#38,#79,#01
	DB	#A3,#74,#7E,#CF,#9E,#DC,#01
	DB	#38,#79,#28,#7F,#41,#9D,#02
	DB	#41,#9D,#30,#A3,#55,#BD,#01
	DB	#47,#36,#4B,#4F,#3A,#55,#01
	DB	#58,#2F,#4B,#4F,#A3,#74,#02
	DB	#7E,#CF,#6E,#D5,#9E,#DC,#02
	DB	#55,#BD,#7E,#CF,#6E,#D5,#01
	DB	#58,#2F,#47,#36,#4B,#4F,#01
	DB	#A3,#74,#64,#B8,#7E,#CF,#02
	DB	#4B,#4F,#A3,#74,#4A,#74,#01
	DB	#3A,#55,#4A,#74,#38,#79,#02
	DB	#A3,#74,#52,#98,#64,#B8,#01
	DB	#41,#9D,#64,#B8,#55,#BD,#02
	DB	#A3,#74,#4A,#74,#52,#98,#02
	DB	#64,#B8,#55,#BD,#7E,#CF,#01
	DB	#38,#79,#52,#98,#41,#9D,#01
	DB	#4B,#4F,#3A,#55,#4A,#74,#02
	DB	#4A,#74,#38,#79,#52,#98,#01
	DB	#52,#98,#41,#9D,#64,#B8,#82

_Elephant
	DB	"TFLN"
	DW	#1000
	DB	0	; mode (0=normal, 1=miroir vertical)
	DB	#7F,#12,#61,#1B,#6E,#65,#02
	DB	#7F,#12,#9F,#1B,#93,#65,#02
	DB	#93,#65,#93,#9E,#70,#A3,#02
	DB	#93,#65,#6E,#65,#70,#A3,#03
	DB	#7F,#12,#6E,#65,#93,#65,#03
	DB	#61,#1B,#4F,#2E,#6E,#65,#03
	DB	#9F,#1B,#B1,#2E,#93,#65,#03
	DB	#4F,#2E,#50,#59,#6E,#65,#01
	DB	#B1,#2E,#AF,#59,#93,#65,#01
	DB	#93,#9E,#70,#A3,#73,#C1,#03
	DB	#93,#9E,#73,#C1,#88,#E2,#01
	DB	#73,#C1,#70,#E1,#88,#E2,#03
	DB	#70,#E1,#88,#E2,#84,#F3,#01
	DB	#70,#E1,#84,#F3,#6F,#F5,#03
	DB	#6E,#65,#56,#9B,#70,#A3,#01
	DB	#93,#65,#AA,#9B,#93,#9E,#01
	DB	#50,#59,#6E,#65,#61,#78,#03
	DB	#AF,#59,#93,#65,#9F,#78,#03
	DB	#80,#53,#6E,#65,#93,#65,#01
	DB	#31,#11,#61,#1B,#4F,#2E,#01
	DB	#CE,#11,#9F,#1B,#B1,#2E,#01
	DB	#31,#11,#14,#2B,#4F,#2E,#03
	DB	#CE,#11,#EB,#2B,#B1,#2E,#03
	DB	#14,#2B,#4F,#2E,#01,#5C,#01
	DB	#EB,#2B,#B1,#2E,#FE,#5C,#01
	DB	#50,#59,#01,#5C,#10,#73,#03
	DB	#AF,#59,#FE,#5C,#EF,#73,#03
	DB	#50,#59,#10,#73,#25,#7C,#01
	DB	#AF,#59,#EF,#73,#DA,#7C,#01
	DB	#50,#59,#25,#7C,#45,#9B,#03
	DB	#AF,#59,#DA,#7C,#BB,#9B,#03
	DB	#50,#59,#56,#9B,#45,#9B,#01
	DB	#AF,#59,#AA,#9B,#BB,#9B,#01
	DB	#56,#9B,#70,#A3,#64,#A8,#03
	DB	#AA,#9B,#93,#9E,#9B,#A8,#03
	DB	#5B,#A0,#64,#A8,#56,#C5,#02
	DB	#A3,#A1,#9B,#A8,#A9,#C5,#02
	DB	#5B,#A0,#4C,#C2,#56,#C5,#03
	DB	#A3,#A1,#B3,#C2,#A9,#C5,#03
	DB	#4C,#C2,#56,#C5,#56,#CF,#02
	DB	#B3,#C2,#A9,#C5,#AA,#CF,#82

_Girafe
	DB	"WJNT"
	DW	#2000			; Tps d'affichage ?
	DB	#01
	DB	#61,#01,#54,#0E,#5E,#37,#01
	DB	#61,#01,#74,#04,#5E,#37,#01
	DB	#74,#04,#5E,#37,#6A,#43,#02
	DB	#5E,#37,#6A,#43,#54,#4C,#01
	DB	#6A,#43,#54,#4C,#80,#53,#02
	DB	#54,#4C,#80,#53,#56,#63,#01
	DB	#80,#53,#56,#63,#72,#7C,#02
	DB	#56,#63,#55,#73,#72,#7C,#01
	DB	#55,#73,#72,#7C,#60,#87,#01
	DB	#55,#73,#52,#82,#60,#87,#01
	DB	#52,#82,#60,#87,#4A,#8D,#01
	DB	#60,#87,#4A,#8D,#52,#96,#01
	DB	#56,#63,#55,#73,#46,#7B,#01
	DB	#4E,#6E,#2F,#73,#46,#7B,#01
	DB	#33,#54,#4E,#6E,#2F,#73,#01
	DB	#45,#4C,#33,#54,#4E,#6E,#03
	DB	#45,#4C,#56,#63,#4E,#6E,#02
	DB	#30,#47,#45,#4C,#33,#54,#03
	DB	#1A,#43,#30,#47,#33,#54,#03
	DB	#1A,#43,#1B,#4E,#33,#54,#01
	DB	#1B,#4E,#33,#54,#2F,#74,#01
	DB	#54,#73,#46,#7B,#4A,#84,#03
	DB	#54,#73,#52,#82,#4A,#84,#03
	DB	#52,#82,#4A,#85,#4A,#8E,#01
	DB	#80,#53,#72,#7C,#80,#9A,#02
	DB	#72,#7C,#80,#9A,#74,#A1,#01
	DB	#80,#9A,#74,#A1,#73,#C8,#01
	DB	#80,#9A,#73,#C8,#80,#CC,#02
	DB	#73,#C8,#80,#CC,#78,#E1,#03
	DB	#80,#CC,#78,#E1,#80,#FA,#02
	DB	#78,#E1,#68,#EA,#80,#FA,#01
	DB	#68,#EA,#70,#FA,#80,#FA,#02
	DB	#66,#D2,#78,#E1,#68,#EA,#01
	DB	#74,#C8,#66,#D2,#78,#E1,#02
	DB	#74,#A2,#74,#C8,#66,#D2,#02
	DB	#74,#A2,#58,#C3,#66,#D2,#01
	DB	#57,#A0,#74,#A2,#58,#C3,#02
	DB	#68,#81,#57,#A0,#74,#A2,#01
	DB	#72,#7B,#68,#81,#74,#A2,#02
	DB	#68,#81,#52,#94,#57,#A0,#81

_Dolphin
	DB	"D_ST"
	DW	#800
	DB	#00
	DB	#82,#A3,#74,#AC,#82,#BC,#01
	DB	#BF,#29,#DF,#4C,#CC,#5C,#01
	DB	#DE,#4C,#CC,#5C,#E0,#74,#01
	DB	#D4,#21,#B5,#22,#CD,#37,#01
	DB	#D2,#2C,#C6,#32,#DE,#4B,#01
	DB	#BF,#28,#CD,#5D,#B6,#66,#01
	DB	#99,#0F,#D4,#21,#B4,#25,#01
	DB	#9B,#0F,#E2,#12,#D2,#23,#01
	DB	#D6,#02,#99,#10,#E2,#12,#01
	DB	#82,#A3,#A6,#A8,#83,#BB,#01
	DB	#A6,#A7,#81,#BB,#96,#C4,#01
	DB	#A6,#A6,#B8,#BA,#94,#C6,#01
	DB	#B8,#BA,#95,#C5,#B5,#D3,#01
	DB	#95,#C5,#B6,#D2,#91,#D7,#01
	DB	#93,#D5,#9B,#EA,#AE,#EC,#01
	DB	#B5,#D2,#93,#D6,#AE,#ED,#01
	DB	#9C,#EA,#AE,#EC,#98,#FD,#01
	DB	#AC,#9B,#A5,#A6,#B9,#BB,#01
	DB	#D9,#97,#AC,#9C,#B4,#BC,#01
	DB	#CA,#5A,#E1,#73,#D8,#95,#01
	DB	#CC,#5D,#B6,#66,#D9,#99,#01
	DB	#B8,#67,#D9,#98,#B2,#9B,#01
	DB	#97,#0F,#C0,#29,#B7,#64,#01
	DB	#71,#00,#A9,#0A,#84,#3B,#01
	DB	#9D,#15,#84,#39,#B0,#50,#01
	DB	#74,#00,#58,#05,#84,#3A,#01
	DB	#87,#39,#85,#4E,#71,#51,#01
	DB	#86,#4E,#6F,#50,#81,#6A,#01
	DB	#84,#4F,#91,#68,#81,#6A,#01
	DB	#58,#05,#87,#3B,#6F,#52,#01
	DB	#58,#05,#68,#39,#45,#43,#01
	DB	#58,#04,#3B,#1B,#4B,#38,#01
	DB	#3B,#19,#32,#2E,#4C,#37,#01
	DB	#32,#2E,#47,#35,#23,#3E,#01
	DB	#34,#2E,#1E,#38,#25,#3E,#01
	DB	#4A,#36,#45,#45,#2B,#48,#01
	DB	#21,#45,#35,#47,#2C,#4C,#01
	DB	#56,#06,#77,#0B,#54,#11,#02
	DB	#56,#07,#4D,#0F,#56,#11,#02
	DB	#5B,#39,#4E,#41,#6B,#43,#02
	DB	#67,#39,#5B,#3A,#6A,#43,#02
	DB	#87,#3A,#86,#45,#B1,#50,#02
	DB	#86,#45,#AF,#4F,#B8,#65,#02
	DB	#A3,#56,#B8,#64,#B7,#81,#02
	DB	#B7,#82,#B4,#9F,#A6,#A6,#02
	DB	#B4,#7A,#B9,#82,#B2,#8C,#02
	DB	#55,#28,#59,#2F,#50,#30,#03
	DB	#55,#28,#5D,#28,#59,#2F,#83

_Loup
	DB	"DT\L"
	DW	#200			
	DB	#00
	DB	#77,#1C,#99,#22,#73,#38,#02
	DB	#98,#22,#9D,#37,#73,#38,#02
	DB	#D9,#1E,#D7,#39,#CD,#3B,#01
	DB	#8F,#27,#8F,#2D,#7E,#2F,#01
	DB	#89,#26,#8F,#27,#7E,#2F,#01
	DB	#CE,#00,#C5,#06,#D8,#0B,#01
	DB	#CD,#00,#D7,#04,#D7,#0A,#01
	DB	#C7,#05,#99,#22,#9E,#37,#02
	DB	#C7,#05,#D7,#0B,#9E,#37,#02
	DB	#D7,#0B,#D9,#1E,#9E,#37,#02
	DB	#D9,#1E,#9E,#37,#CD,#3A,#02
	DB	#78,#1C,#5F,#25,#45,#50,#02
	DB	#77,#1D,#46,#4D,#6E,#5E,#02
	DB	#DE,#37,#E4,#3F,#C4,#71,#02
	DB	#DF,#37,#C8,#3D,#C4,#70,#02
	DB	#73,#37,#CC,#38,#65,#F1,#02
	DB	#49,#47,#A9,#6F,#10,#73,#02
	DB	#2E,#71,#15,#A0,#DF,#B9,#02
	DB	#B9,#56,#82,#A6,#DF,#B8,#02
	DB	#C7,#40,#B7,#58,#C4,#73,#02
	DB	#6F,#6F,#2E,#72,#6D,#8C,#02
	DB	#DF,#B8,#C4,#F5,#D8,#FE,#02
	DB	#DE,#B9,#64,#E6,#B8,#F6,#02
	DB	#8B,#AC,#DE,#B9,#6B,#E7,#02
	DB	#7E,#EB,#B7,#F5,#A2,#F9,#02
	DB	#86,#DA,#97,#F4,#84,#F9,#02
	DB	#8F,#C3,#67,#ED,#80,#F2,#02
	DB	#15,#A0,#96,#AD,#21,#AE,#02
	DB	#63,#A6,#20,#AE,#46,#F5,#02
	DB	#7C,#C8,#49,#EC,#55,#F8,#02
	DB	#72,#5F,#6A,#D5,#49,#EB,#82

_Lion
	DB	"TJLK"
	DW	#100
	DB	1	; mode (0=normal, 1=miroir vertical)
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

	DB	#FF

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
	list

	align	256
TabAdr
	DS	512
PtMode1C1
