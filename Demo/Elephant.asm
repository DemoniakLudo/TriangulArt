; Généré par TriangulArt le 07/05/2021 (10 27 00)
Elephant
; 4 octets de palette
	DB	"TFLN"
	DW	#1000			; Tps d'affichage ?
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
	DB	#7F,#12,#61,#1B,#6E,#65,#02
	DB	#7F,#12,#9F,#1B,#93,#65,#02
	DB	#93,#65,#93,#9E,#70,#A3,#02
	DB	#93,#65,#6E,#65,#70,#A3,#03
	DB	#7F,#12,#6E,#65,#93,#65,#03
	DB	#61,#1B,#4F,#2E,#6E,#65,#03
	DB	#9F,#1B,#B1,#2E,#93,#65,#03
	DB	#4F,#2E,#50,#59,#6E,#65,#01
	DB	#B1,#2E,#AF,#59,#93,#65,#01
	DB	#93,#9E,#70,#A3,#73,#C1,#03
	DB	#93,#9E,#73,#C1,#88,#E2,#01
	DB	#73,#C1,#70,#E1,#88,#E2,#03
	DB	#70,#E1,#88,#E2,#84,#F3,#01
	DB	#70,#E1,#84,#F3,#6F,#F5,#03
	DB	#6E,#65,#56,#9B,#70,#A3,#01
	DB	#93,#65,#AA,#9B,#93,#9E,#01
	DB	#50,#59,#6E,#65,#61,#78,#03
	DB	#AF,#59,#93,#65,#9F,#78,#03
	DB	#80,#53,#6E,#65,#93,#65,#01
	DB	#31,#11,#61,#1B,#4F,#2E,#01
	DB	#CE,#11,#9F,#1B,#B1,#2E,#01
	DB	#31,#11,#14,#2B,#4F,#2E,#03
	DB	#CE,#11,#EB,#2B,#B1,#2E,#03
	DB	#14,#2B,#4F,#2E,#01,#5C,#01
	DB	#EB,#2B,#B1,#2E,#FE,#5C,#01
	DB	#50,#59,#01,#5C,#10,#73,#03
	DB	#AF,#59,#FE,#5C,#EF,#73,#03
	DB	#50,#59,#10,#73,#25,#7C,#01
	DB	#AF,#59,#EF,#73,#DA,#7C,#01
	DB	#50,#59,#25,#7C,#45,#9B,#03
	DB	#AF,#59,#DA,#7C,#BB,#9B,#03
	DB	#50,#59,#56,#9B,#45,#9B,#01
	DB	#AF,#59,#AA,#9B,#BB,#9B,#01
	DB	#56,#9B,#70,#A3,#64,#A8,#03
	DB	#AA,#9B,#93,#9E,#9B,#A8,#03
	DB	#5B,#A0,#64,#A8,#56,#C5,#02
	DB	#A3,#A1,#9B,#A8,#A9,#C5,#02
	DB	#5B,#A0,#4C,#C2,#56,#C5,#03
	DB	#A3,#A1,#B3,#C2,#A9,#C5,#03
	DB	#4C,#C2,#56,#C5,#56,#CF,#02
	DB	#B3,#C2,#A9,#C5,#AA,#CF,#82
; Taille 287 octets
