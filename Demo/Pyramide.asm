; Généré par TriangulArt le 07/05/2021 (10 28 53)
Pyramide
; 4 octets de palette
	DB	"]C^N"
	DB	#08			; Tps d'affichage ?
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
	DB	#C6,#9D,#2B,#A5,#2B,#B0,#01
	DB	#C6,#9D,#C6,#A7,#2B,#B0,#01
	DB	#85,#14,#D0,#99,#C7,#9C,#01
	DB	#91,#14,#85,#16,#D0,#99,#01
	DB	#91,#0D,#91,#14,#85,#16,#02
	DB	#91,#0D,#91,#14,#D0,#99,#02
	DB	#91,#14,#D1,#96,#D0,#99,#02
	DB	#79,#17,#1B,#A2,#26,#A8,#01
	DB	#CB,#A0,#B8,#DA,#AF,#DB,#01
	DB	#79,#17,#82,#1D,#26,#A8,#01
	DB	#D1,#A0,#CB,#A0,#B8,#DA,#01
	DB	#B8,#DA,#AF,#DB,#AF,#E7,#01
	DB	#B8,#DA,#B9,#E7,#AF,#E7,#01
	DB	#D1,#9F,#B8,#DA,#B9,#E7,#02
	DB	#D1,#9F,#D1,#A7,#B9,#E7,#02
	DB	#27,#AA,#1F,#AE,#A7,#E4,#01
	DB	#1F,#AE,#A7,#E4,#A1,#E9,#01
	DB	#A7,#E4,#A1,#E9,#A1,#F4,#01
	DB	#A7,#E4,#A7,#EE,#A1,#F4,#01
	DB	#1F,#AE,#A1,#E9,#A1,#F4,#02
	DB	#1F,#AE,#1F,#B8,#A1,#F4,#02
	DB	#90,#14,#83,#16,#A6,#E1,#01
	DB	#90,#14,#B2,#DF,#A6,#E1,#01
	DB	#90,#14,#B4,#D1,#B2,#DF,#02
	DB	#90,#14,#94,#1A,#B4,#D1,#82
; Taille 175 octets
