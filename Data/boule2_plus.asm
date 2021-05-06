; Généré par TriangulArt le 02/05/2021 (09 50 02)
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
	LD	BC,#BC11
	LD	HL,UnlockAsic
Unlock:
	LD	A,(HL)
	OUT	(C),A
	INC	HL
	DEC	C
	JR	NZ,Unlock
	LD	BC,#7FA0
	LD	A,#8C
	OUT	(C),A
	OUT	(C),C

	LD	IX,DataFrame			; Donnees triangle
	PUSH	IX
	POP	HL
	LD	BC,#7FB8
	OUT	(C),C
	LD	DE,#6420
	LDI
	LDI
	DEC	HL
	DEC	HL
	LD	E,0
	LD	BC,8
	LDIR
	LD	BC,#7FA0
	OUT	(C),C
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
; 4 mots de palette
	DB		#10,#00,#05,#00,#0A,#00,#0F,#00
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
	DB	#8B,#ED,#5A,#F1,#7A,#F1,#02
	DB	#0D,#53,#08,#64,#02,#6E,#01
	DB	#15,#45,#0D,#53,#08,#64,#01
	DB	#18,#CA,#22,#CD,#3C,#E5,#01
	DB	#18,#CA,#30,#DF,#3C,#E5,#01
	DB	#02,#6E,#05,#88,#01,#8F,#02
	DB	#08,#64,#02,#6E,#05,#88,#02
	DB	#8B,#ED,#6C,#ED,#5A,#F1,#02
	DB	#01,#8F,#0F,#AD,#08,#AF,#01
	DB	#05,#88,#01,#8F,#0F,#AD,#01
	DB	#3C,#E5,#6C,#ED,#5A,#F1,#01
	DB	#4D,#DF,#3C,#E5,#6C,#ED,#01
	DB	#2B,#2E,#25,#40,#15,#45,#01
	DB	#3B,#28,#2B,#2E,#25,#40,#01
	DB	#67,#16,#5C,#1E,#4C,#23,#02
	DB	#67,#16,#57,#1B,#4C,#23,#02
	DB	#9C,#E6,#6C,#ED,#8B,#ED,#01
	DB	#08,#AF,#18,#CA,#22,#CD,#02
	DB	#15,#45,#19,#60,#08,#64,#02
	DB	#25,#40,#15,#45,#19,#60,#02
	DB	#22,#CD,#4D,#DF,#3C,#E5,#02
	DB	#33,#C8,#22,#CD,#4D,#DF,#02
	DB	#3B,#28,#36,#3A,#25,#40,#02
	DB	#4C,#23,#3B,#28,#36,#3A,#02
	DB	#F4,#50,#FD,#74,#A3,#74,#01
	DB	#08,#64,#17,#84,#05,#88,#01
	DB	#19,#60,#08,#64,#17,#84,#01
	DB	#0F,#AD,#33,#C8,#22,#CD,#01
	DB	#20,#A8,#0F,#AD,#33,#C8,#01
	DB	#9C,#E6,#7C,#E6,#6C,#ED,#02
	DB	#0F,#AD,#08,#AF,#22,#CD,#02
	DB	#A3,#74,#FD,#74,#FC,#98,#02
	DB	#05,#88,#20,#A8,#0F,#AD,#02
	DB	#17,#84,#05,#88,#20,#A8,#02
	DB	#E1,#2F,#F4,#50,#A3,#74,#02
	DB	#79,#10,#67,#16,#5C,#1E,#01
	DB	#79,#10,#6E,#17,#5C,#1E,#01
	DB	#AC,#E2,#7C,#E6,#9C,#E6,#02
	DB	#A3,#74,#FC,#98,#EE,#B7,#01
	DB	#57,#1B,#4C,#23,#3B,#28,#01
	DB	#4D,#DF,#7C,#E6,#6C,#ED,#02
	DB	#5C,#DA,#4D,#DF,#7C,#E6,#02
	DB	#A9,#0B,#C7,#18,#A3,#74,#02
	DB	#25,#40,#2A,#5A,#19,#60,#01
	DB	#36,#3A,#25,#40,#2A,#5A,#01
	DB	#33,#C8,#5C,#DA,#4D,#DF,#01
	DB	#43,#C2,#33,#C8,#5C,#DA,#01
	DB	#AC,#E2,#8D,#E2,#7C,#E6,#02
	DB	#4C,#23,#47,#36,#36,#3A,#01
	DB	#5C,#1E,#4C,#23,#47,#36,#01
	DB	#19,#60,#28,#7F,#17,#84,#02
	DB	#2A,#5A,#19,#60,#28,#7F,#02
	DB	#5C,#DA,#8D,#E2,#7C,#E6,#01
	DB	#6E,#D5,#5C,#DA,#8D,#E2,#01
	DB	#A9,#0B,#89,#0B,#A3,#74,#01
	DB	#C7,#18,#E1,#2F,#A3,#74,#01
	DB	#A3,#74,#EE,#B7,#DA,#CF,#02
	DB	#20,#A8,#43,#C2,#33,#C8,#02
	DB	#30,#A3,#20,#A8,#43,#C2,#02
	DB	#BC,#DB,#8D,#E2,#AC,#E2,#01
	DB	#A3,#74,#DA,#CF,#BC,#DB,#01
	DB	#28,#7F,#17,#84,#30,#A3,#01
	DB	#89,#0B,#79,#10,#6E,#17,#01
	DB	#17,#84,#30,#A3,#20,#A8,#01
	DB	#36,#3A,#3A,#55,#2A,#5A,#02
	DB	#47,#36,#36,#3A,#3A,#55,#02
	DB	#43,#C2,#6E,#D5,#5C,#DA,#02
	DB	#55,#BD,#43,#C2,#6E,#D5,#02
	DB	#BC,#DB,#9E,#DC,#8D,#E2,#01
	DB	#5C,#1E,#58,#2F,#47,#36,#02
	DB	#6E,#17,#5C,#1E,#58,#2F,#02
	DB	#2A,#5A,#38,#79,#28,#7F,#01
	DB	#3A,#55,#2A,#5A,#38,#79,#01
	DB	#30,#A3,#55,#BD,#43,#C2,#01
	DB	#41,#9D,#30,#A3,#55,#BD,#01
	DB	#28,#7F,#41,#9D,#30,#A3,#02
	DB	#38,#79,#28,#7F,#41,#9D,#02
	DB	#6E,#17,#58,#2F,#A3,#74,#01
	DB	#6E,#D5,#9E,#DC,#8D,#E2,#02
	DB	#7E,#CF,#6E,#D5,#9E,#DC,#02
	DB	#89,#0B,#6E,#17,#A3,#74,#02
	DB	#A3,#74,#BC,#DB,#9E,#DC,#02
	DB	#47,#36,#4B,#4F,#3A,#55,#01
	DB	#58,#2F,#47,#36,#4B,#4F,#01
	DB	#A3,#74,#7E,#CF,#9E,#DC,#01
	DB	#55,#BD,#7E,#CF,#6E,#D5,#01
	DB	#64,#B8,#55,#BD,#7E,#CF,#01
	DB	#A3,#74,#64,#B8,#7E,#CF,#02
	DB	#4B,#4F,#A3,#74,#4A,#74,#01
	DB	#3A,#55,#4A,#74,#38,#79,#02
	DB	#4B,#4F,#3A,#55,#4A,#74,#02
	DB	#41,#9D,#64,#B8,#55,#BD,#02
	DB	#52,#98,#41,#9D,#64,#B8,#02
	DB	#58,#2F,#4B,#4F,#A3,#74,#02
	DB	#38,#79,#52,#98,#41,#9D,#01
	DB	#4A,#74,#38,#79,#52,#98,#01
	DB	#A3,#74,#52,#98,#64,#B8,#01
	DB	#A3,#74,#4A,#74,#52,#98,#82
; Taille 686 octets
UnlockAsic:
	DB	#FF,#00,#FF,#77,#B3,#51,#A8,#D4,#62,#39,#9C,#46,#2B,#15,#8A,#CD,#EE
;
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
