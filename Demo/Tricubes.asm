; Généré par TriangulArt le 07/05/2021 (10 29 45)
Tricubes
; 4 octets de palette
	DB	"@SUD"
	DB	#04			; Tps d'affichage ?
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
	DB	#C4,#69,#9E,#69,#89,#8B,#03
	DB	#C4,#69,#89,#8B,#B1,#8B,#03
	DB	#A6,#78,#91,#9B,#A6,#BD,#01
	DB	#A6,#78,#BB,#9B,#A6,#BD,#01
	DB	#A6,#78,#BB,#9B,#E1,#9B,#02
	DB	#A6,#78,#CE,#78,#E1,#9B,#02
	DB	#E1,#9B,#BB,#9B,#A6,#BD,#03
	DB	#E1,#9B,#A6,#BD,#CE,#BD,#03
	DB	#C3,#AA,#AE,#CD,#C3,#EF,#01
	DB	#C3,#AA,#D8,#CD,#C3,#EF,#01
	DB	#C3,#AA,#D8,#CD,#FE,#CD,#02
	DB	#C3,#AA,#EB,#AA,#FE,#CD,#02
	DB	#FE,#CD,#D8,#CD,#C3,#EF,#03
	DB	#FE,#CD,#C3,#EF,#EB,#EF,#03
	DB	#89,#AA,#74,#CD,#89,#EF,#01
	DB	#89,#AA,#9E,#CD,#89,#EF,#01
	DB	#89,#AA,#9E,#CD,#C4,#CD,#02
	DB	#89,#AA,#B1,#AA,#C4,#CD,#02
	DB	#C4,#CD,#9E,#CD,#89,#EF,#03
	DB	#C4,#CD,#89,#EF,#B1,#EF,#03
	DB	#4F,#AA,#3A,#CD,#4F,#EF,#01
	DB	#4F,#AA,#64,#CD,#4F,#EF,#01
	DB	#4F,#AA,#64,#CD,#8A,#CD,#02
	DB	#4F,#AA,#77,#AA,#8A,#CD,#02
	DB	#8A,#CD,#64,#CD,#4F,#EF,#03
	DB	#8A,#CD,#4F,#EF,#77,#EF,#03
	DB	#15,#AA,#00,#CD,#15,#EF,#01
	DB	#15,#AA,#2A,#CD,#15,#EF,#01
	DB	#15,#AA,#2A,#CD,#50,#CD,#02
	DB	#15,#AA,#3D,#AA,#50,#CD,#02
	DB	#50,#CD,#2A,#CD,#15,#EF,#03
	DB	#50,#CD,#15,#EF,#3D,#EF,#03
	DB	#32,#78,#1D,#9B,#32,#BD,#01
	DB	#32,#78,#47,#9B,#32,#BD,#01
	DB	#32,#78,#47,#9B,#6D,#9B,#02
	DB	#32,#78,#5A,#78,#6D,#9B,#02
	DB	#6D,#9B,#47,#9B,#32,#BD,#03
	DB	#6D,#9B,#32,#BD,#5A,#BD,#03
	DB	#4F,#46,#3A,#69,#4F,#8B,#01
	DB	#4F,#46,#64,#69,#4F,#8B,#01
	DB	#4F,#46,#64,#69,#8A,#69,#02
	DB	#4F,#46,#77,#46,#8A,#69,#02
	DB	#8A,#69,#64,#69,#4F,#8B,#03
	DB	#8A,#69,#4F,#8B,#77,#8B,#03
	DB	#6C,#14,#57,#37,#6C,#59,#01
	DB	#6C,#14,#81,#37,#6C,#59,#01
	DB	#6C,#14,#81,#37,#A7,#37,#02
	DB	#6C,#14,#94,#14,#A7,#37,#02
	DB	#A7,#37,#81,#37,#6C,#59,#03
	DB	#A7,#37,#6C,#59,#94,#59,#03
	DB	#89,#46,#9E,#69,#89,#8B,#01
	DB	#89,#46,#74,#69,#89,#8B,#01
	DB	#89,#46,#9E,#69,#C4,#69,#02
	DB	#89,#46,#B1,#46,#C4,#69,#82
; Taille 378 octets
