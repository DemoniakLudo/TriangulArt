BUILDCPR
BANK 0

RelocDemo	EQU	#8000

	org	0


	DI                  ; Disable Interruptions
	LD	SP,#8000
	
	LD	A,#C0
	LD	BC,#7FA0
	OUT	(C),C
	OUT	(C),A
	LD	A,#89
	OUT	(C),A
	LD	HL,#1044
	OUT	(C),H
	OUT	(C),L
	EXX					; Pour sauvegarder B
	LD	HL,0
	LD	DE,0
	LD	BC,#3FFF
	LDIR
	
	LD	HL,StartDemo
	LD	DE,RelocDemo
	ld	bc,#ffff			; preserve default offset 1
	push	bc
	inc	bc
	ld	a,#80
dzx0s_literals:
	call	dzx0s_elias		; obtain length
	ldir					; copy literals

; Amigaaaaaaaaaaaaaa
	LD	I,A
	AND	#1F
	OR	#40
	EXX						; Récuperer B=#7F
	OUT	(C),A
	EXX
	LD	A,I

	add	a,a					; copy from last offset or new offset?
	jr	c,dzx0s_new_offset
	call	dzx0s_elias		; obtain length
dzx0s_copy:
	ex	(sp),hl				; preserve source,restore offset
	push	hl				; preserve offset
	add	hl,de				; calculate destination - offset
	ldir					; copy from offset

; Amigaaaaaaaaaaaaaa
	LD	I,A
	AND	#1F
	OR	#40
	EXX
	OUT	(C),A
	EXX
	LD	A,I

	pop	hl					; restore offset
	ex	(sp),hl				; preserve offset,restore source
	add	a,a					; copy from literals or new offset?
	jr	nc,dzx0s_literals
dzx0s_new_offset:
	call	dzx0s_elias		; obtain offset MSB
	ld b,a
	pop	af					; discard last offset
	xor	a					; adjust for negative offset
	sub	c
	jr	z,initdemo			; Plus d'octets à traiter = fini

	ld	c,a
	ld	a,b
	ld	b,c
	ld	c,(hl)				; obtain offset LSB
	inc	hl
	rr	b					; last offset bit becomes first length bit
	rr	c
	push	bc				; preserve new offset
	ld	bc,1				; obtain length
	call	nc,dzx0s_elias_backtrack
	inc	bc
	jr	dzx0s_copy
dzx0s_elias:
	inc	c					; interlaced Elias gamma coding
dzx0s_elias_loop:
	add	a,a
	jr	nz,dzx0s_elias_skip
	ld	a,(hl)				; load another group of 8 bits
	inc	hl
	rla
dzx0s_elias_skip:
	ret 	c
dzx0s_elias_backtrack:
	add	a,a
	rl	c
	rl	b
	jr	dzx0s_elias_loop

initdemo
	EXX
	LD	HL,#558D
	OUT	(C),H			; Border bleu
	OUT	(C),L			; Mode 1 et roms off
	LD	A,#C3
	LD	(#38),A			; Jump en rst 38
	IM	1
	
	LD   BC,#F782 ; PPi In
	OUT  (C),C

	LD   BC,#DF80
	OUT  (C),C

	LD	HL,RelocDemo
	LD	DE,#200
	LD	BC,#6200
	LDIR
	LD	HL,#8000
	LD	D,H
	LD	E,L
	LD	B,H
	LD	C,L
	INC	DE
	LD	(HL),L
	LDIR
	LD	BC,#7F54		; Border noir
	OUT	(C),C
	LD	HL,Crtc
	LD	BC,#BC00
SetCrtcValue:
	LD	A,(HL)
	OUT	(C),C
	INC	B
	OUT	(C),A
	DEC B
	INC	HL
	INC	C
	LD	A,C
	CP	10
	JR	C,SetCrtcValue
	JP	#200
	
Crtc
	DB	#3F,#28,#2E,#8E,#26,#00,#19,#1E,#00,#07
	
StartDemo
	INCZX0 'demo.bin'
