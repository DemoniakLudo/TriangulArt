	ORG	#6000

	Write	direct	"triangul.art"

CodeDemo:
	INCBIN	"Demo.ZX0"

; Decompactage
; HL = adresse source (compacte)
; DE = adresse destination
	run	$

	DI
	LD	BC,#BC01
	XOR	A
	OUT	(C),C
	INC	B
	OUT	(C),A
	LD	BC,#7F10
	OUT	(C),C
	EXX
	LD	HL,CodeDemo
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
_EndCode:
