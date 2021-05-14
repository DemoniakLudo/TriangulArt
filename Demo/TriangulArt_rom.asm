TpsWaitImage1	EQU	#7780		; Temps de pause entre chaque images (première partie)

StartCharAscii	EQU	48		; début des caractères ASCII dans la police

	ORG	#8000,#2000
	RUN	$

	Write direct "Demo.bin"

	DI
	LD	BC,#7F8D		; Mode 1
	OUT	(C),C
	LD	HL,#8000				; Effacer 2 buffers video
	LD	SP,HL


; calculer adresse ecran pour chaque ligne
	LD	BC,#40			; 256 lignes, c=adresse haute a ne pas depasser
 	LD	DE,#0		; adresse de depart
	LD	HL,TabAdr
CalcAdr:
	LD	(HL),E			; Poids faibles
	INC	H
	LD	(HL),D			; Poids forts
	DEC	H
	INC	HL
	LD	A,D
	ADD	A,8
	LD	D,A
	CP	C
	JR	C,CalcSuite
	PUSH	BC
	LD	B,#C0
	EX	DE,HL
	ADD	HL,BC
	EX	DE,HL
	POP	BC
CalcSuite:
	DJNZ	CalcAdr
	
; calculer points a afficher en fonction de la couleur
	LD	DE,pen1
	LD	HL,PtMode1C1 
	LD	B,32			; Tableau structure {Point} (32 valeurs)
InitPen:
	CALL	Set3Pen			; Ecriture Masque + premier octet a ecrire
	LD	A,(DE)			; Octet suivant = nbre de pixels a soustraire
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
	CALL	Set3Pen			; Ecriture Masque + dernier octet a ecrire
	INC	L
	INC	L
	INC	L			; 3 valeurs a zeros pour aligner sur 8 octets
	DJNZ	InitPen
	LD	HL,NewIrq
	LD	(#39),HL

;
; Formater ecran en 256x256 pixels, mode 1
;
Debut
	DI
	CALL	Init			; Initialisation de la musique
	EI
	LD	HL,#202A
	LD	BC,#BC01		; 64 colones
	OUT	(C),C
	INC	B
	OUT	(C),H
	DEC	B
	INC	C
	OUT	(C),C
	INC	B
	OUT	(C),L
	LD	HL,#2022
	LD	BC,#BC06		; 256 lignes
	OUT	(C),C
	INC	B
	OUT	(C),H
	DEC	B
	INC	C
	OUT	(C),C
	INC	B
	OUT	(C),L
	LD	BC,#BC0C
	OUT	(C),C
	LD	BC,#BD10		; Memoire video en #C000
	OUT	(C),C
	CALL	CopyAndClearScreen

	LD	A,#40
	LD	(OffsetVideo+1),A	; Trace de triangles en #C000

;
;	JR	MoreSpeed	; decommenter pour aller direcement a la 2e partie
;
;	JP	EndMess		; decommenter pour aller directement au message de fin
;
;	JP	StartAnim	; decommenter pour aller directement a l'anim
;
; Debut, premiere image = logo impact
;
	LD	IX,Impact
	LD	A,#C1
	LD	(LogoBarre),A		; Pause entre la croix et le logo Apple
	LD	A,#FF
	LD	(Glaive),A		; Ne pas afficher le glaive
BoucleNormale
	PUSH	IX
	POP	HL	
	CALL	SetPalette		; Palette de l'image
	LD	A,(HL)
	INC	HL
	LD	(TpsWaitTriangle+1),A	; Temps de pause entre chaque triangles
	PUSH	HL
	CALL	ClearScreen		; Effacer ecran
	LD	BC,#BD10
	OUT	(C),C
	POP	IX
BoucleNorm2
	CALL	DrawFrame		; Afficher image
	LD	C,A			; memo octet de fin (pour logo apple barre)
	LD	HL,TpsWaitImage1	; Temps de pause pour affichage image
Wait1
	DEC	HL
	LD	B,16
Wait2
	DJNZ	Wait2
	LD	A,H
	OR	L
	JR	NZ,Wait1		; Boucle pour temps de pause
	LD	A,C			; Recupere octet de fin
	RLA
	JR	NC,Wait3		; Si bit 6=1 => croix sur logo Apple
	DEC	IX				
	JR	BoucleNorm2		; Affichage croix sans effacer ecran
Wait3:
	LD	A,(IX+0)
	INC	A
	JR	NZ,BoucleNormale	; Si pas fin des images, on continue
;
; Message "We want true speed"
;
MoreSpeed:
	XOR	A
	LD	(DoWait+1),A		; ne plus faire de pauses entre chaque triangles
	CALL	CopyAndClearScreen	; Copier ecran en #8000 et effacer #C000
	CALL	WaitVBL
	LD	BC,#BD10
	OUT (C),C
	LD	HL,Message1		; message "WE WANT TRUE SPEED NOW"
	CALL	PrintMess
	LD	B,4
WaitMess1
	XOR	A
	LD	(CntIrq+1),A
WaitMess2
	LD	A,(CntIrq+1)		; Attendre 256 interruptions (a peu pres 0.8 secondes)
	INC	A
	JR	NZ,WaitMess2
	DJNZ	WaitMess1		; Boucler 4 fois (soit 3.2 secondes)
;
; Affichage rapide des images
;
	
	LD	A,1
	LD	(LogoBarre),A		; supprimer la pause de la croix sur le logo pour l'option rapide
	LD	A,'K'
	LD	(Glaive),A		; Afficher le glaive
	LD	IX,Triangle
BoucleRapide
	CALL	CopyAndClearScreen	; Copier ecran en #8000 et basculer video en #8000
	PUSH	IX
	LD	BC,5
	ADD	IX,BC
	CALL	DrawFrame		; Afficher l'image en #C000
	CALL	ClearScroll		; Efface image en #8000 et bascule video en #C000
BoucleRapide2
	LD	A,0
	INC	A
	LD	(BoucleRapide2+1),A
	CP	7			; Une fois sur 7, flash de l'ecran
	JR	C,BoucleRapide3
	XOR A				
	LD	(BoucleRapide2+1),A
	LD	HL,PaletteBlack		; Passe l'ecran en noir
	CALL	SetPalette
	CALL	WaitVbl
	CALL	SetPalette		; Passe l'ecran en blanc
	CALL	WaitVbl
	LD	HL,PaletteBlack		; Passe l'ecren en noir
	CALL	SetPalette
BoucleRapide3	
	POP	HL			; Recupere palette de l'image
	CALL	SetPalette
	LD	A,(IX+0)
	INC	A
	JR	NZ,BoucleRapide		; Boucler tant qu'il y a des images

	LD	B,10
WaitForMess:
	PUSH	BC
	CALL	WaitVbl
	POP	BC
	DJNZ	WaitForMess		; Pause pour affichage derniere image
;
; Message de fin...
;
EndMess
	XOR	A
	LD	(CntVblMess+1),A
	CALL	CopyAndClearScreen
	CALL	WaitVBL
	LD	BC,#BD10
	OUT	(C),C
	LD	HL,Message2
BclEndMess
	CALL	PrintMess		; Affichage page complete
	LD	B,8
WaitReadMess
	XOR	A
	LD	(CntIrq+1),A
WaitReadMess2
	LD	A,(CntIrq+1)
	INC	A
	JR	NZ,WaitReadMess2	
	DJNZ	WaitReadMess		; 8 x 256 IRQ pour le temps de pause (6.8 sec)
	PUSH	HL
	CALL	CopyAndClearScreen
	CALL	ClearScroll
	POP	HL
	INC	HL
	LD	A,(HL)
	INC	A
	JR	NZ,BclEndMess		; Tant qu'il y a des pages a afficher...		
;
; Animation rotation 3D
;
StartAnim
	LD	HL,PalAnim
	CALL	SetPalette
	LD	A,#2E
	LD	BC,#BC02		; Decentrer ecran (anim calculee en 320x200....)
	OUT	(C),C
	INC	B
	OUT	(C),A
	LD	BC,#BC0C
	OUT	(C),C
	LD	HL,0
	LD	(IrqSwapColor+1),HL	; Plus de clignottement de couleurs
	CALL	CopyAndClearScreen
	LD	HL,MessageEnd1		; Message "THE END" en #C000
	CALL	PrintMess
	XOR	A
	LD	(OffsetVideo+1),A
	LD	HL,MessageEnd2		; Message "THE END" en #8000
	CALL	PrintMess

	LD	IY,Frame_58		; Avant derniere frame
InitAnim:
	LD	IX,Frame_0		; Premiere frame
BclAnim
	CALL	WaitVbl
MemVideo:
	LD	A,#0			; Memoire ecran
	LD	(OffsetVideo+1),A
	LD	(OffsetVideoClear+1),A
	XOR	#40			; Swap memoire ecran
	LD	(MemVideo+1),A
	RRA
	RRA
	LD	B,#BD
	OUT	(C),A			; Selection memoire video a afficher
BclClearFrame:
	LD	A,(ZoneYmin+1)
	LD	C,(IY+1)
	CP	C
	JR	C,CalcCoord2
	LD	A,C
	LD	(ZoneYmin+1),A
CalcCoord2:
	LD	A,(ZoneYmax+1)
	LD	L,(IY+5)
	CP	L
	JR	NC,CalcCoord3
	LD	A,L
	LD	(ZoneYmax+1),A
CalcCoord3:
	LD	D,(IY+0)
	LD	A,D
	LD	B,(IY+2)
	CP	B
	JR	NC,CalcCoord4		; si B<D
	LD	D,B			; Sinon on inverse B et D
	LD	B,A
CalcCoord4:
	LD	A,D
	LD	H,(IY+4)
	CP	H
	JR	C,CalcCoord5		; si D<H
	LD	D,H			; sinon on inverse D et H
	LD	H,A
CalcCoord5:
	LD	A,(ZoneXmax+1)
	CP	H
	JR	NC,CalcCoord6
	LD	A,H
	LD	(ZoneXmax+1),A
CalcCoord6:
	LD	A,(ZoneXmin+1)
	CP	B
	JR	C,CalcCoord7
	LD	A,B
	LD	(ZoneXmin+1),A
CalcCoord7:		
	LD	A,(IY+6)
	LD	BC,7
	ADD	IY,BC
	RLA
	JR	NC,BclClearFrame
	XOR	A
	LD	B,A			; Parce que A vaut zero
ZoneXMin:
	LD	A,0
	LD	C,A
	RRA
	AND	A
	RRA
	LD	(OffsetClear+1),A	; X/4 = debut a effacer
ZoneXMax:
	LD	A,0
	SUB	C
	ADD	A,7
	RRA
	AND	A
	RRA
	LD	(BclClearZone+1),A	; Nbre d'octets a effacer
ZoneYMin:
	LD	A,0			; Position y de depart

BclClearZone:
	LD	C,0			; Nbre d'octets a effacer
	LD	L,A			; Reg.L = y
	EX	AF,AF'			; Sauvegarde position Y
	LD	H,TabAdr/256
	LD	A,(HL)			; Poids faible adresse ecran
	INC	H
OffsetClear:
	OR	#F6			; Sera remplacé par #80 ou #C0
	LD	E,A
	LD	A,(HL)			; Poids fort adresse ecran
OffsetVideoClear:
	OR	#C0
	LD	H,A
	LD	L,E			; Reg HL = adresse memoire ecran (x,y)
	LD	(HL),B			; Efface premier octet
	DEC	C			; Si un seul octet a effacer
	JR	Z,FinClear		; Alors on a fini
	LD	D,H
	INC	DE
	LDIR
FinClear:
	EX	AF,AF'			; Recupere position Y
	INC	A
ZoneYMax:
	CP	0			; Y = Ymax ?
	JR	NZ,BclClearZone
	XOR	A			; Mettre les "max" a Zero
	LD	(ZoneYmax+1),A
	LD	(ZoneXmax+1),A
	DEC	A			; Mettre les "min" a 255
	LD	(ZoneYmin+1),A
	LD	(ZoneXmin+1),A
	LD	A,(IY+0)
	INC	A
	JR	NZ,BclDrawFrame
	LD	IY,Frame_0		; Si A=#FF, fin des frames, on recommence
BclDrawFrame:
	LD	A,(IX+6)
	CALL	SetTriangleColor
	LD	B,(IX+0)
	LD	C,(IX+1)
	LD	D,(IX+2)
	LD	E,(IX+3)
	LD	H,(IX+4)
	LD	L,(IX+5)
	CALL	DrawTriangle
	LD	A,(IX+6)
	LD	BC,7
	ADD	IX,BC
	RLA
	JR	NC,BclDrawFrame
	LD	A,(IX+0)
	INC	A
	JP	NZ,BclAnim
NbBclAnim:
	LD	A,0
	INC	A
	LD	(NbBclAnim+1),A
	CP	9
	JP	C,InitAnim
	XOR	A
	LD	(NbBclAnim+1),A
	CALL	ClearScreen
	JP	Debut

;
; Fonctions
;
SetPalette
	CALL	WaitVBL
	LD	BC,#7F10
	LD	A,(HL)
	OUT	(C),C
	OUT	(C),A	
	XOR	A
BclPalette
	OUT	(C),A
	INC	B	
	OUTI
	INC	A
	CP	4
	JR	NZ,BclPalette
	RET

CopyAndClearScreen
	LD	HL,#C000
	LD	DE,#8000
	LD	BC,#3FFF
	LDIR
	
ClearScreen
	LD	BC,#BC0C
	OUT	(C),C
	LD	BC,#BD00
	OUT	(C),C
	CALL	WaitVBL
	LD	HL,#C000
	LD	DE,#C001
	LD	BC,#3FFF
	LD	(HL),L
	LDIR
	RET
	
WaitVbl
	LD	B,#F5
	IN	A,(C)
	RRA
	JR	NC,WaitVbl
WaitEndVBL
	IN	A,(C)
	RRA
	JR	C,WaitEndVBL
	RET

ClearScroll
	LD	A,0
	XOR	1			; Une fois scrollV, une fois scrollH
	LD	(ClearScroll+1),A
	JR	Z,ClearScroll2
	CALL	ClearScrollH		; Efface image en #8000 et bascule video en #C000
	JR	ClearScroll3
ClearScroll2
	CALL	ClearScrollV		; Efface image en #8000 et bascule video en #C000
ClearScroll3
	LD	BC,#BC0C
	LD	HL,#3000
	OUT	(C),C
	INC	B
	OUT	(C),H
	DEC	B
	INC	C
	OUT	(C),C
	INC	B
	OUT	(C),L
	RET

ClearScrollV:
	LD	HL,#20
	XOR	A
BclClearScrollV:
	PUSH	AF
	PUSH	HL
	LD	E,A
	LD	BC,#BC0C
	OUT	(C),C
	LD	A,H
	OR	#20
	INC	B
	OUT	(C),A
	DEC	B
	INC	C
	OUT	(C),C
	INC	B
	OUT	(C),L
	LD	D,8
BclClearScrollV2:
	PUSH	DE
	LD	H,TabAdr/256		; Adresse des poids faibles
	LD	L,E
	LD	E,(HL)
	INC	H			; Adresse des poids forts
	LD	D,(HL)
	LD	H,D
	LD	L,E
	LD	BC,63
	LD	(HL),B
	INC DE
	LDIR
	POP	DE
	LD	B,64
BclClearScrollV3:
	DJNZ	BclClearScrollV3
	INC	E
	DEC	D
	JR	NZ,BclClearScrollV2
	POP	HL
	POP	AF
	LD	BC,#20
	ADD	HL,BC
	ADD	A,8
	JR	NZ,BclClearScrollV
	RET
	
ClearScrollH:
	XOR	A
BclClearScrollH:
	PUSH	AF
	LD	BC,#BC0D
	OUT	(C),C
	INC	B
	OUT	(C),A
	LD	B,0
	LD	C,A
BclClearScrollH2:
	LD	H,TabAdr/256		; Adresse des poids faibles
	LD	L,B
	LD	E,(HL)
	INC	H			; Adresse des poids forts
	LD	D,(HL)
	EX	DE,HL
	LD	D,0
	LD	A,C
	ADD	A,A
	LD	E,A
	ADD	HL,DE
	LD	(HL),D
	INC	HL
	LD	(HL),D
	DJNZ	BclClearScrollH2
	POP	AF
	INC	A
	CP	32
	JR	NZ,BclClearScrollH
	RET
	
;
; Dessine les triangles d'une image
;
DrawFrame
	LD	A,(IX+0)		; Mode de trace
	LD	(ModeDraw+1),A
	INC	IX
BclDrawImage
	XOR	A
	LD	(CntIrq+1),A
	LD	A,(IX+6)		; Couleur
	CALL	SetTriangleColor	
	LD	B,(IX+0)		; X1
	LD	C,(IX+1)		; Y1
	LD	D,(IX+2)		; X2
	LD	E,(IX+3)		; Y2
	LD	H,(IX+4)		; X3
	LD	L,(IX+5)		; Y3
	CALL	DrawTriangle
ModeDraw
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
DoWait
	LD	A,1
	AND	A
	JR	Z,EndWait	

WaitTriangle
	LD	A,(CntIrq+1)
TpsWaitTriangle
	CP	0
	JR	C,WaitTriangle

EndWait
	LD	A,(IX+6)
	LD	BC,7
	ADD	IX,BC
	RLA
	JR	NC,BclDrawImage
	RET

;----------------------------
;-                          -
;- Fonctions du text-writer -
;-                          -
;----------------------------

;
; Initialise la couleur 
;
PrintMessColor
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
PrintMessPos
	INC	HL
	LD	A,(HL)
	LD	(PrintMessX+1),A
	INC	HL
	LD	A,(HL)
	LD	(PrintMessY+1),A
	INC	HL
	JR	PrintMess
	
;
; Changement de palette
;
PrintMessPalette
	INC	HL
	CALL	SetPalette
	JR	PrintMess
	
;
; Swap de 2 couleurs pendant le message (Pen 2 & 3)
;
PrintMessSwapInk
	INC	HL
	LD	D,(HL)
	INC	HL
	LD	E,(HL)
	INC	HL
	LD	(IrqSwapColor+1),DE
	JR	PrintMess
	
PrintMessAutoCenter
	INC	HL
	LD	A,(HL)
	LD	(PrintMessY+1),A
	INC	HL
	PUSH	HL
	LD	B,0
PrintMessAutoCenter1
	LD	A,(HL)
	CP	32
	JR	C,PrintMessAutoCenterOk
	EXX
	JR	Z,PrintMessAutoCenterSpace	
	SUB	StartCharAscii
	ADD	A,A
	LD	HL,Alphabet
	LD	C,A
	LD	B,0
	ADD	HL,BC
	LD	E,(HL)
	INC	HL
	LD	D,(HL)
	PUSH	DE
	POP	IX
PrintMessAutoCenter2
	LD	A,(IX+6)
	SUB	#80
	JR	NC,PrintMessAutoCenterAdd
	LD	BC,6
	ADD	IX,BC
	JR	PrintMessAutoCenter2
PrintMessAutoCenterSpace:
	LD	A,12
PrintMessAutoCenterAdd
	EXX
	ADD	A,B
	LD	B,A
	INC	HL
	JR	PrintMessAutoCenter1
PrintMessAutoCenterOk:	
	POP	HL
	LD	A,B
	NEG
	SRL	A
	LD	(PrintMessX+1),A
	JR	PrintMess
	
PrintMessSetSwapInk
	INC	HL
	LD	A,(HL)
	LD	(PrintSwapInk+1),A
	INC	HL
;
; Affiche un message avec des lettres en triangle
; HL = adresse du message
; B = posX depart, C = posY depart
;
PrintMess
	LD	A,(HL)
	AND	A
	RET	Z
	CP	1
	JR	Z,PrintMessColor
	CP	2
	JR	Z,PrintMessPos
	CP	3
	JR	Z,PrintMessPalette
	CP	4
	JR	Z,PrintMessSwapInk
	CP	5
	JR	Z,PrintMessAutoCenter
	CP	6
	JR	Z,PrintMessSetSwapInk
	LD	B,12
	CP	32
	JR	Z,PrintSpace
	SUB	StartCharAscii
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
PrintSwapInk:
	LD	A,0
	AND	A
	JR	Z,PrintMessX
	XOR	1
	LD	(PrintSwapInk+1),A
	CALL	SetTriangleColor
PrintMessX
	LD	B,0			; Position X
PrintMessY
	LD	C,0			; Position Y
	LD	H,(IX+2)		; X2
	LD	L,(IX+3)		; Y2
	ADD	HL,BC
	EX	DE,HL
	LD	H,(IX+4)		; X3
	LD	L,(IX+5)		; Y3
	ADD	HL,BC
	LD	A,(IX+0)		; X1
	ADD	A,B
	LD	B,A	
	LD	A,(IX+1)		; Y1
	ADD	A,C
	LD	C,A	
	CALL	DrawTriangle
	LD	A,(IX+6)
	LD	BC,6
	ADD	IX,BC
	LD	A,(IX+0)
	BIT	7,A
	JR	Z,PrintMessX
	AND	#3F
	LD	B,A			; Largeur lettre
	POP	HL
PrintSpace
	INC	HL
	LD	A,(PrintMessX+1)
	ADD	A,B
	LD	(PrintMessX+1),A
	JR	PrintMess

;
; Initialise la couleur du trace du triangle
;
SetTriangleColor
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
	LD	A,#04			; INC B
	JR	SetSgn1
SetDx1Neg:
	NEG
	LD	(DX1+1),A
	LD	A,#05			; DEC B
SetSgn1:
	LD	(Sgn1),A
	LD	A,H
	SUB	D
	JR	C,SetDx3Neg
	LD	(DX3+1),A
	LD	A,#0C			; INC C
	JR	SetSgn3
SetDx3Neg:
	NEG
	LD	(DX3+1),A
	LD	A,#0D			; DEC C
SetSgn3:
	LD	(Sgn3+1),A
	LD	A,L
	LD	(Ymax+1),A
	SUB	C
	LD	H,A			; Reg.H = DY1
	LD	A,L
	SUB	E
	LD	(DY3+1),A
	LD	A,E
	LD	(Y2+1),A
	SUB	C
	LD	L,A			; Reg.L = DY2
	LD	A,D
	SUB	B
	JR	C,SetDx2Neg
	LD	(DX2+1),A
	LD	A,#0C			; INC C
	JR	SetSgn2
SetDx2Neg:
	NEG
	LD	(DX2+1),A
	LD	A,#0D			; DEC C
SetSgn2:
	LD	(Sgn2),A
	LD	A,C			; Y de depart = Reg.C
	CP	E
	LD	C,D
	LD	DE,0			; Reg.D = Err2, Reg.E = Err1
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
	LD	L,A			; Reg.L = y
	EX	AF,AF'
	LD	A,B			; x
	CP	C
	JR	Z,LigneVide		; Si B = C, rien a faire
	JR	C,DrawLigneCoordOk	; Si B < C, ok
	LD	B,C			; Sinon on inverse
	LD	C,A
	LD	A,B			; x
DrawLigneCoordOk:
	LD	H,TabAdr/256		; Adresse des poids faibles
	AND	A
	RRA
	AND	A
	RRA				; x/4
	ADD	A,(HL)
	LD	E,A
	INC	H			; Adresse des poids forts
	LD	A,(HL)			; Reg.DE = adresse memoire ecran (0,y)
OffsetVideo
	OR	#F6			; Sera remplacé par #80 ou #C0
	LD	D,A
	
	LD	A,B			; x
	AND	3
	LD	L,A			; Reg.L = position fine x (0 a 3)
	LD	A,C			; xfin
	SUB	B
	LD	B,A			; Reg.B = nbre de points en x
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
	RLCA				; 8 octets par structure
	LD	L,A
DrawLigneCoul:
	LD	H,PtMode1C1/256
	LD	A,(DE)			; Octet memoire ecran
	AND	(HL)			; Masque
	INC	L
	OR	(HL)			; Premier octet
	LD	(DE),A
	INC	L
	INC	DE
	LD	A,B			; Nbre de points
	SUB	(HL)			; Nbre de points a soustraire
	JR	C,DrawLigneFin
	INC	A
	RRA
	AND	A
	RRA
	LD	C,A
DrawLigneCoul2:
	LD	A,#3E			; Octet du milieu (4 pixels allumes)
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
	LD	A,(DE)			; Octet memoire ecran
	AND	(HL)			; Masque
	INC	L
	OR	(HL)			; Dernier octet
	LD	(DE),A
LigneVide:
	EXX
;
; Fin trace de ligne
;
	LD	A,E			; Err1
DX1:
	ADD	A,0			; Err1=Err1+Dx1
	JR	C,ForceErr1
DY1:
	CP	H
	JR	C,SetErr1		; Si Err1<Dy1, arret de la boucle
ForceErr1:
	SUB	H			; - DY1
SGN1:
	INC	B			; OU DEC B (B=xl)
	JR	DY1
SetErr1:
	LD	E,A			; Sauvegarde Err1
	EX	AF,AF'			; Recupere ordonnee de la ligne en cours (Y)
Y2:
	CP	0			; Y==E ?
	JR	Z,SetErr3		; Il est moins couteux en tps de faire
					; un saut conditionnel dont la condition
					; arrive peu frequement (ici le JR Z ne
					; peut arriver qu'une seule fois)
	EX	AF,AF'			; Re-sauvegarde Y
	LD	A,D			; Err2
DX2:
	ADD	A,0
	JR	C,ForceErr2
DY2:
	CP	L
	JR	C,SetErr2
ForceErr2:
	SUB	L			; -DY2
SGN2:
	INC	C			; OU DEC C(C=xr)
	JR	DY2
SetErr2:
	LD	D,A
	EX	AF,AF'			; Recupere ordonee de la ligne en cours
	INC	A
Ymax:
	CP	0			; Arrive en bas ?
	JP	C,BclDrawTriangle
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

;
; Creation donnees pixels couleurs trace ligne mode 1
;
Set3Pen:
	LD	A,(DE)			; Point en Pen 1
	LD	C,A
	RRCA
	RRCA
	RRCA
	RRCA
	OR	C
	CPL				; Creation du masque
	LD	(HL),A
	INC	H
	LD	(HL),A
	INC	H
	LD	(HL),A
	INC	H
	LD	(HL),A			; Stockage du masque pour les 3 pens
	DEC	H
	DEC	H
	DEC	H
	INC	L
	LD	(HL),0			; Pen 0
	INC	H
	LD	(HL),C			; Pen 1
	INC	H
	LD	A,C
	RRCA
	RRCA
	RRCA
	RRCA
	LD	(HL),A			; Pen 2
	INC	H
	OR	C
	LD	(HL),A			; Pen 3
	DEC	H
	DEC	H
	DEC	H
	INC	L
	INC	DE
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
	LD	B,#F5
	IN	A,(C)
	RRA
	JR	NC,CntIrq
	CALL	Play			; Jouer la musique sur detection VBL
	
IrqSwapColor:	
	LD	DE,0
	LD	A,D
	XOR	E
	AND	A			; Si demande swap couleur
	JR	Z,CntIrq
CntVblMess:
	LD	A,0
	INC	A
	LD	(CntVblMess+1),A
	CP	20			; Attendre 20 VBL
	JR	C,CntIrq
	XOR	A
	LD	(CntVblMess+1),A
	LD	BC,#7F02		; Swap PEN 2 et PEN 3
	OUT	(C),C
	OUT	(C),D
	INC	C
	OUT	(C),C
	OUT	(C),E
	LD	A,D
	LD	D,E
	LD	E,A
	LD	(IrqSwapColor+1),DE
	
CntIrq
	LD	A,0
	INC	A
	LD	(CntIrq+1),A		; Compter les IRQ
	POP	AF
	EX	AF,AF'
	POP	IX
	POP	HL
	POP	DE
	POP	BC
	POP	AF
	EI
	RET

	nolist

	Read	"DataRotation.asm"

PaletteBlack
	DB	"TTTT"
;PaletteWhite
	DB	"KKKK"
PalAnim
	DB	"TUWS"

	Read	"DataImages.asm"
	
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

	Read	"police.asm"

	Read	"Messages.asm"
	
MDLADDR:
	INCBIN	"Rage.pt2"

	Read	"PT2PlayCPC_V5.asm"

	list

	align	256
TabAdr
	DS	512
PtMode1C1
