	ORG #C000

	Write	direct	"Triangul.rom"

	DEFB 1 ;ROM type ... background
	DEFB 1 ;mark 1
	DEFB 1 ;version 1
	DEFB 1 ;modification 1

	DEFW name_table
	JP initialise_ROM 
	JP triangulart

name_table:
	DEFB "IMPX RO","M"+#80   ;bad name
	DEFB "TRIANGULAR","T"+#80       
	DEFB 0

initialise_ROM:
	PUSH DE
	PUSH HL ;save DE/HL
	CALL print_string; print power-up message
	DEFB "|triangulart to start"
	DEFB 13,10,13,10
	DEFB 0
	POP HL
	POP DE ;restore HL/DE
	AND A
	LD BC,15
	SBC HL,BC ;grab 15 bytes from top of memory
	SCF
	RET 

print_string:
	POP HL ;get string address
sp_loop:
	LD A,(HL)
	CALL #BB5A ;print character
	INC HL
	OR A ;done?
	JR NZ,sp_loop
	JP (HL)

triangulart
	LD	HL,StartReloc
	LD	DE,#6000
	LD	BC,#4000
	LDIR
	JP	Depack

StartReloc
CodeDemo
	org	#6000,StartReloc
	INCBIN	"Demo.ZX0"
	DB	0
Depack
	DI

	LD	SP,#200
	LD	BC,#BC01
	XOR	A
	OUT	(C),C
	INC	B
	OUT	(C),A
	LD	BC,#7F10
	OUT	(C),C
	LD	A,#8D
	OUT	(C),A
	EXX
	LD	HL,#A000
	LD	DE,#A001
	LD	BC,#5FFF
	LD	(HL),L
	LDIR
	LD	HL,#6000
	LD	DE,#200
	PUSH	DE
	ld	bc,#ffff			; preserve default offset 1
	push	bc
	inc	bc
	ld	a,#80
dzx0s_literals:
	call	dzx0s_elias		; obtain length
	ldir					; copy literals
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
	EXX						; Récuperer B=#7F
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
	RET	Z		; Plus d'octets Ã  traiter = fini

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

	nolist

	list
_endcode