; Généré par TriangulArt le 07/05/2021 (10 29 54)
TriTriangle
; 4 octets de palette
	DB	"TNL\"
	DB	#05			; Tps d'affichage ?
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
	DB	#55,#00,#69,#00,#00,#AA,#01
	DB	#69,#00,#1E,#96,#00,#AA,#01
	DB	#1E,#96,#96,#AA,#00,#AA,#01
	DB	#1E,#96,#8C,#96,#96,#AA,#01
	DB	#91,#00,#5A,#96,#46,#96,#01
	DB	#91,#00,#A5,#00,#5A,#96,#01
	DB	#B4,#96,#C8,#96,#BE,#AA,#01
	DB	#C8,#96,#D2,#AA,#BE,#AA,#01
	DB	#32,#BE,#28,#D2,#3C,#D2,#01
	DB	#32,#BE,#46,#BE,#3C,#D2,#01
	DB	#28,#D2,#AA,#D2,#1E,#E6,#01
	DB	#AA,#D2,#B4,#E6,#1E,#E6,#01
	DB	#69,#28,#5F,#3C,#69,#50,#02
	DB	#69,#28,#73,#3C,#69,#50,#02
	DB	#A5,#28,#9B,#3C,#F0,#BE,#02
	DB	#9B,#3C,#D2,#AA,#F0,#BE,#02
	DB	#D2,#AA,#C8,#BE,#F0,#BE,#02
	DB	#D2,#AA,#BE,#AA,#C8,#BE,#02
	DB	#87,#64,#7D,#78,#D2,#FA,#02
	DB	#7D,#78,#B4,#E6,#D2,#FA,#02
	DB	#B4,#E6,#28,#FA,#D2,#FA,#02
	DB	#B4,#E6,#1E,#E6,#28,#FA,#02
	DB	#00,#AA,#0A,#BE,#A0,#BE,#02
	DB	#00,#AA,#96,#AA,#A0,#BE,#02
	DB	#69,#00,#69,#28,#32,#96,#03
	DB	#69,#00,#1E,#96,#32,#96,#03
	DB	#69,#00,#69,#28,#73,#3C,#03
	DB	#69,#00,#7D,#28,#73,#3C,#03
	DB	#A5,#00,#6E,#96,#5A,#96,#03
	DB	#A5,#00,#A5,#28,#6E,#96,#03
	DB	#A5,#00,#A5,#28,#F0,#BE,#03
	DB	#A5,#00,#FA,#AA,#F0,#BE,#03
	DB	#91,#50,#87,#64,#D2,#FA,#03
	DB	#91,#50,#DC,#E6,#D2,#FA,#03
	DB	#46,#BE,#5A,#BE,#3C,#D2,#03
	DB	#5A,#BE,#50,#D2,#3C,#D2,#83
; Taille 252 octets
