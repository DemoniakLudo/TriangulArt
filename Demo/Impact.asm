; Généré par TriangulArt le 07/05/2021 (10 28 04)
Impact
; 4 octets de palette
	DB	"XCNL"
	DB	#03			; Tps d'affichage ?
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
; Taille 567 octets
