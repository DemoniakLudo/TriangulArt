; Généré par TriangulArt le 07/05/2021 (10 28 11)
Linux
; 4 octets de palette
	DB	"WKTL"
	DB	#08		; Tps d'affichage ?
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
	DB	#AC,#19,#80,#36,#BF,#3F,#01
	DB	#80,#36,#AA,#54,#9A,#5C,#01
	DB	#80,#36,#BF,#3E,#AA,#54,#01
	DB	#81,#21,#A0,#21,#80,#36,#01
	DB	#A1,#12,#AC,#19,#80,#37,#01
	DB	#92,#10,#A1,#12,#8F,#2A,#01
	DB	#7B,#01,#93,#10,#90,#23,#01
	DB	#7C,#01,#72,#04,#90,#23,#01
	DB	#81,#37,#6F,#57,#9A,#5C,#01
	DB	#6F,#57,#9A,#5C,#63,#8F,#01
	DB	#9A,#5C,#62,#8F,#99,#91,#01
	DB	#62,#8F,#9A,#91,#64,#B8,#01
	DB	#99,#91,#64,#B8,#A6,#C0,#01
	DB	#64,#B8,#A6,#C0,#6E,#E4,#01
	DB	#A5,#C0,#B9,#D1,#6E,#E4,#01
	DB	#B9,#D1,#6E,#E4,#8A,#F8,#01
	DB	#B7,#D2,#8A,#F8,#A5,#FE,#01
	DB	#6E,#E4,#5F,#F3,#89,#F7,#01
	DB	#5F,#F3,#89,#F7,#67,#F8,#01
	DB	#8B,#F8,#88,#FE,#A5,#FE,#01
	DB	#AA,#F0,#A6,#FC,#AC,#FE,#01
	DB	#72,#04,#90,#23,#82,#23,#02
	DB	#81,#37,#63,#55,#6F,#58,#02
	DB	#63,#55,#53,#89,#62,#8E,#02
	DB	#63,#55,#6F,#58,#63,#8F,#02
	DB	#52,#88,#63,#8E,#54,#B7,#02
	DB	#63,#8E,#54,#B7,#64,#C0,#02
	DB	#BF,#3E,#A8,#55,#D1,#76,#02
	DB	#A8,#55,#D1,#76,#D1,#A4,#02
	DB	#A8,#55,#9A,#5C,#99,#90,#02
	DB	#A8,#55,#99,#91,#A6,#C1,#02
	DB	#A8,#55,#D1,#A4,#A5,#C0,#02
	DB	#D1,#A3,#A5,#C0,#BB,#D3,#02
	DB	#D1,#A3,#D1,#B9,#BB,#D3,#02
	DB	#9B,#19,#99,#1D,#9B,#20,#02
	DB	#9B,#19,#A1,#19,#A3,#1D,#02
	DB	#A3,#1D,#9B,#20,#A1,#21,#02
	DB	#9B,#19,#A3,#1D,#9B,#20,#82
; Taille 266 octets
