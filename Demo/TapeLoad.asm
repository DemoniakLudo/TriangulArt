START	EQU #6000
LENGTH	EQU 16244

	ORG #4000
	run	$

	DI
	LD	HL,Palette
	CALL	SetPalette
	LD	SP,#200
	LD	HL,DrawPixel
	LD	DE,TabPixel
	LDI
	LDI
	LDI
	LDI
; calculer adresse ecran pour chaque ligne
	LD	BC,#40			; 256 lignes, c=adresse haute a ne pas depasser
 	LD	DE,#C000		; adresse de depart
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
	JR	NC,CalcSuite
	PUSH	BC
	LD	B,#C0
	EX	DE,HL
	ADD	HL,BC
	EX	DE,HL
	POP	BC
CalcSuite:
	DJNZ	CalcAdr

	CALL	Cls
	LD	HL,CrtcValues
SetCrtc:
	LD	B,#BD
	OUTI
	LD	B,#BE
	OUTI
	LD	A,(HL)
	AND	A
	JR	NZ,SetCrtc
	LD HL,START
	LD DE,LENGTH
	LD	BC,#7F10
	OUT	(C),C    
	LD	A,#8D
	OUT	(C),A  
	LD	IX,TabColor 
	PUSH HL
	PUSH DE
	PUSH DE
	LD	BC,#F610	; Moteur on
	OUT	(C),C
	EXX 
	POP DE
	INC DE			; Ajouter un octet pour le checksum
	EXX 
	
	LD B,#F5
	IN A,(C)
	LD C,A			; Valeur lue dans C
LSHT:
	LD E,#20
LCNT:
	LD D,91
	LD A,9
	CALL LEDG2
	JR NC,LSHT
	LD A,145
	CP D
	JR NC,LSHT
	DEC E
	JR NZ,LCNT
LSYNC:
	LD D,91
	CALL LEDG1
	JR NC,LSHT
	LD A,112    ;91+21
	CP D
	JR C,LSYNC
	CALL LEDG1
	JR NC,LSHT
	LD DE,#B801			; E=1 pour que RL donne Carry a 1 si fait 8x  
L8BIT:
	LD A,9
L8BENT:
	CALL LEDG2
	JR NC,ERR
	LD A,#D4
	CP D
	RL E				; rotation bit, carry dans b0 de E
	LD D,#B8
	JR NC,L8BIT			; Si pas 8 bits, on continue
	LD (HL),E
	INC HL
	LD E,1
; Dessine le pixel du triangle
	EXX
	LD	HL,Length
	INC	HL
	LD	B,D
	LD	C,E
	XOR	A
	SBC	HL,BC			; HL = Nbre d'octets restant à lire
	LD	A,H
	ADD	HL,HL
	ADD	HL,HL
	INC	H			; H = nb (octets restant * 4) / 256  (nbre de ko * 16)
	PUSH	HL
	LD	L,H
	LD	H,TabAdr/256		; Adresse des poids faibles
	LD	C,(HL)
	INC	H			; Adresse des poids forts
	LD	B,(HL)
	LD	H,0
	LD	L,A			; Position X
	ADD	HL,BC
	LD	B,H
	LD	C,L
	POP	AF			; A = nbre de ko restant * 16
	AND	3
	LD	L,A			; Numero pixel
	LD	H,TabPixel/256
	LD	A,(HL)
	LD	(BC),A
	DEC DE
	LD A,D
	OR E
	EXX 
	LD A,6
	JR NZ,L8BENT
ERR:
	LD	BC,#F600
	OUT	(C),C			; arret moteur K7
	POP DE
	POP HL
	XOR A
CalcChecksum:
	ADD (HL)
	INC HL
	DEC DE
	LD C,A
	LD A,D
	OR E
	LD A,C
	JR NZ,CalcChecksum
	SUB (HL)
	CP 1          
	RET	NC			; Si pas carry, erreur checksum...
	CALL	Cls
	JP	#9F0B			; Executer decompactage demo
	
LEDG2:
	CALL LEDGE
	RET NC
LEDG1:
	LD A,11
LEDGE:
	DEC A				; Tempo
	JR NZ,LEDGE
LSAMP:
	INC D
	RET Z
	LD B,#F5
	IN A,(C)
	XOR C
	JP P,LSAMP			; Attente changement valeur
	LD A,C
	CPL 
	LD C,A				; Inversion valeur lue
	RRA 
	JR	C,TestVal		; Bit a 1 ?
; Changement couleur bordure
	INC	IX
TestVal
	LD	A,(IX+0)	
	AND	A
	JR	NZ,OutOk
	LD	IX,TabColor
	LD	A,(IX+0)
OutOk
	LD B,#7F			; Changement couleur bordure
	OUT (C),A
	SCF 
	RET 

Cls:
	LD	HL,#A000
	LD	DE,#A001
	LD	BC,#5FFF
	LD	(HL),L
	LDIR	
	RET

SetPalette
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


TabColor:
	DB	#55,#4B,#4C,0

DrawPixel
	DB	#10,#88,#40,#22

Palette
	DB	#44,#57,#4B,#53
	
CrtcValues
	DB	1,#20,2,#2A,6,#20,7,#22,12,#30,13,0,0

	align	256
TabPixel
	ds	256
TabAdr