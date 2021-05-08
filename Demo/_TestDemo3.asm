TpsWaitImage1	EQU	#6600

	ORG	#200
	RUN	$

;	Write direct "demo.bin"

	DI
	LD	HL,#8000
	LD	SP,HL
	LD	D,H
	LD	E,L
	LD	B,H
	LD	C,L
	LD	(HL),L
	INC	DE
	DEC	BC
	LDIR
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
	LD	HL,NewIrq
	LD	(#39),HL
	LD	BC,#7F8D
	OUT	(C),C
	LD	BC,#BC0C
	OUT	(C),C
; initialisation musique
	LD	HL,MDLADDR
	CALL	INIT
	EI
;
;	JR	MoreSpeed	; decommenter pour aller direcement a la 2e partie
;	JP	EndMess		; decommenter pour aller directement au message de fin
;
; Debut, premiere image = logo impact
;
Debut
	LD	IX,Logos
Boucle:
	PUSH	IX
	POP	HL	
	CALL	WaitVBL
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
	LD	A,(HL)
	INC	HL
	LD	(TpsWaitTriangle+1),A
	PUSH	HL
	CALL	ClearScreen
	LD	BC,#BD30
	OUT	(C),C
	POP	IX
	CALL	DrawFrame
; Temps de pause pour affichage image
	LD	HL,TpsWaitImage1
Wait1:
	DEC	HL
	LD	B,16
Wait2:
	DJNZ	Wait2
	LD	A,H
	OR	L
	JR	NZ,Wait1
	LD	A,(IX+0)
	INC	A
	JR	NZ,Boucle
;
; Message "We want more speed"
;
MoreSpeed:
	XOR	A
	LD	(DoWait+1),A
	CALL	CopyScreen
	CALL	WaitVBL
	LD	BC,#BD30
	OUT (C),C
	LD	HL,Message1
	CALL	PrintMess
	LD	B,4
WaitMess1:
	XOR	A
	LD	(CntIrq+1),A
WaitMess2:
	LD	A,(CntIrq+1)
	INC	A
	JR	NZ,WaitMess2
	DJNZ	WaitMess1
;
; Affichage rapide des images
;
	LD	IX,Logos
Boucle2:
	CALL	CopyScreen
	PUSH	IX
	LD	BC,5
	ADD	IX,BC
	XOR	A
	LD	(CntIrq+1),A
	CALL	DrawFrame
	POP	HL	
	CALL	WaitVBL
	LD	BC,#BD30
	OUT	(C),C
	LD	BC,#7F10
	LD	A,(HL)
	OUT	(C),C
	OUT	(C),A
	XOR	A
BclPalette2:
	OUT	(C),A
	INC	B	
	OUTI
	INC	A
	CP	4
	JR	NZ,BclPalette2
Wait12:
	LD	A,(CntIrq+1)
	AND	A
	JR	NZ,Wait12
	LD	A,(IX+0)
	INC	A
	JR	NZ,Boucle2
;
; Message de fin...
;
EndMess
	CALL	CopyScreen
	CALL	WaitVBL
	LD	BC,#BD30
	OUT	(C),C
	LD	HL,Message2
	CALL	PrintMess

FinDemo
	JR	FinDemo
;
; Fonctions
;
CopyScreen:
	LD	HL,#C000
	LD	DE,#8000
	LD	BC,#3FFF
	LDIR
	
ClearScreen:
	LD	BC,#BD20
	OUT (C),C
	CALL	WaitVBL
	LD	HL,#C000
	LD	DE,#C001
	LD	BC,#3FFF
	LD	(HL),L
	LDIR
	RET
	
WaitVbl:
	LD	B,#F5
	IN	A,(C)
	RRA
	JR	NC,WaitVbl
WaitEndVBL:
	IN	A,(C)
	RRA
	JR	C,WaitEndVBL
	RET
	
;
; IRQ
;
NewIrq
	PUSH	AF
	PUSH	BC
	PUSH	DE
	PUSH	HL
	PUSH	IX
	EX	AF,AF'
	PUSH	AF
Cnt50hZ:
	LD	A,0
	INC	A
	LD	(Cnt50hZ+1),A
	CP	6
	JR	NZ,CntIrq
	XOR	A
	LD	(Cnt50hz+1),A
	CALL	Play
CntIrq:
	LD	A,0
	INC	A
	LD	(CntIrq+1),A
	POP	AF
	EX	AF,AF'
	POP	IX
	POP	HL
	POP	DE
	POP	BC
	POP	AF
	EI
	RET

;
; Dessine les triangles d'une image
;
DrawFrame:
	LD	A,(IX+0)				; Mode de trace
	LD	(ModeDraw+1),A
	INC	IX
BclDrawFrame:
	XOR	A
	LD	(CntIrq+1),A
	LD	A,(IX+6)				; Couleur
	CALL	SetTriangleColor	
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
DoWait:
	LD	A,1
	AND	A
	JR	Z,EndWait	

WaitTriangle:
	LD	A,(CntIrq+1)
TpsWaitTriangle:
	CP	0
	JR	C,WaitTriangle

EndWait:
	LD	A,(IX+6)
	LD	BC,7
	ADD	IX,BC
	RLA
	JR	NC,BclDrawFrame
	RET

;
; Affiche un message avec des lettres en triangle
; HL = adresse du message
; B = posX depart, C = posY depart
;
PrintMess:
	LD	A,(HL)
	AND	A
	RET	Z
	CP	1
	JR	Z,PrintMessColor
	CP	2
	JR	Z,PrintMessPos
	LD	B,12
	CP	' '
	JR	Z,PrintSpace
	SUB	'A'
	ADD	A,A
	PUSH	HL
	LD	HL,Alphabet
	LD	C,A
	LD	B,0
	ADD	HL,BC
	LD	E,(HL)
	INC	HL
	LD	D,(HL)
	PUSH	DE
	POP	IX
PrintMessX:
	LD	H,0
PrintMessY:
	LD	L,0
	LD	A,(IX+0)				; X1
	ADD	A,H
	LD	B,A	
	LD	A,(IX+1)				; Y1
	ADD	A,L
	LD	C,A	
	LD	A,(IX+2)				; X2
	ADD	A,H
	LD	D,A	
	LD	A,(IX+3)				; Y2
	ADD	A,L
	LD	E,A	
	LD	A,(IX+4)				; X3
	ADD	A,H
	LD	H,A	
	LD	A,(IX+5)				; Y3
	ADD	A,L
	LD	L,A	
	CALL	DrawTriangle
	LD	A,(IX+6)
	LD	BC,6
	ADD	IX,BC
	LD	A,(IX+0)
	BIT	7,A
	JR	Z,PrintMessX
	AND	#3F
	LD	B,A					; Largeur lettre
	POP	HL
PrintSpace:
	INC	HL
	LD	A,(PrintMessX+1)
	ADD	A,B
	LD	(PrintMessX+1),A
	CP	235
	JR	C,PrintMess
	XOR	A
	LD	(PrintMessX+1),A
	LD	A,(PrintMessY+1)
	ADD	A,24
	LD	(PrintMessY+1),A
	JR	PrintMess
;
; Initialise la couleur 
;
PrintMessColor:
	INC	HL
	LD	A,(HL)
	PUSH	HL
	CALL	SetTriangleColor
	POP	HL
	INC	HL
	JR	PrintMess
;
; Positionne les coordonnees du message a afficher
;
PrintMessPos:
	INC	HL
	LD	A,(HL)
	LD	(PrintMessX+1),A
	INC	HL
	LD	A,(HL)
	LD	(PrintMessY+1),A
	INC	HL
	JP	PrintMess

;
; Initialise la couleur du trace du triangle
;
SetTriangleColor:
	AND	3
	ADD	A,PtMode1C1/256
	LD	(DrawLigneCoul+1),A
	LD	(DrawLigneCoul3+1),A
	LD	H,A
	LD	L,#61
	LD	A,(HL)
	LD	(DrawLigneCoul2+1),A	; Initialisation couleur du triangle
	RET

;
; Dessine un triangle - (B=X1 C=Y1), (D=X2 E=Y2), (H=X3 L=Y3)
;
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

	Read	"PT2PlayCPC_V4.asm"
MDLADDR:
	INCBIN	"Rage.pt2"

	Read	"alphabet3.asm"

Message1
	DB	1,1
	DB	2,0,96
	DB	"WE WANT"
	DB	1,2
	DB	2,32,128
	DB	"TRUE SPEED"
	DB	2,64,160
	DB	1,3
	DB	"NOW [[[[[",0

message2
	DB	1,2
	DB	2,0,0
	DB	"\\\\\\\\\\\\"
	DB	2,0,24,"\"
	DB	2,231,24,"\"
	DB	2,0,48,"\"
	DB	2,231,48,"\"
	DB	2,0,72,"\"
	DB	2,231,72,"\"
	DB	2,0,96,"\"
	DB	2,231,96,"\"
	DB	2,0,120,"\"
	DB	2,231,120,"\"
	DB	2,0,144,"\"
	DB	2,231,144,"\"
	DB	2,0,168,"\"
	DB	2,231,168,"\"
	DB	2,0,192,"\"
	DB	2,231,192,"\"
	DB	2,0,216,"\\\\\\\\\\\\"

	DB	1,3
	DB	2,90,58,"YOU"
	DB	2,60,106,"WATCHED"
	DB	1,1
	DB	2,20,154,"TRIANGULART"

	DB	0

;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
Logos
	Read	"DataDemo.asm"
	DB	#FF
	
;
; Structure
; octet 0 = premier octet de la ligne
; octet 1 = nbre d'octets a soustraire+1 du nombre de pixels
; octet 2 = dernier octet de la ligne
;
pen1:
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
