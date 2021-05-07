; Généré par TriangulArt le 07/05/2021 (10 26 07)
Batman2
; 4 octets de palette
	DB	"KUTJ"
	DW	#0200			; Tps d'affichage ?
	DB	#01
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#80,#00,#19,#C4,#80,#C4,#01
	DB	#60,#0C,#74,#17,#69,#2C,#01
	DB	#19,#C4,#2C,#C4,#23,#D2,#01
	DB	#2C,#C4,#3F,#C4,#36,#D2,#01
	DB	#3F,#C4,#52,#C4,#49,#D2,#01
	DB	#52,#C4,#65,#C4,#5C,#D2,#01
	DB	#65,#C4,#78,#C4,#6F,#D2,#01
	DB	#78,#C4,#80,#C4,#80,#D2,#01
	DB	#67,#1A,#70,#1C,#6A,#27,#02
	DB	#80,#18,#6A,#2D,#80,#2D,#02
	DB	#50,#9B,#58,#A1,#48,#C4,#02
	DB	#48,#9F,#40,#A5,#48,#A6,#02
	DB	#48,#A6,#40,#AB,#48,#AC,#02
	DB	#48,#AC,#40,#B2,#48,#B2,#02
	DB	#6B,#32,#7C,#35,#74,#38,#00
	DB	#60,#44,#80,#44,#80,#71,#00
	DB	#80,#73,#4F,#73,#6B,#9F,#00
	DB	#80,#73,#6B,#9F,#80,#9F,#00
	DB	#4F,#73,#59,#75,#4B,#9D,#00
	DB	#5C,#88,#50,#9C,#54,#9E,#00
	DB	#50,#73,#5E,#88,#50,#9C,#00
	DB	#50,#82,#51,#9D,#49,#9F,#00
	DB	#6D,#A8,#7E,#C3,#65,#F3,#00
	DB	#7B,#CA,#70,#E1,#71,#E2,#02
	DB	#67,#CA,#69,#CA,#67,#D8,#02
	DB	#6D,#D5,#62,#D9,#67,#F4,#01
	DB	#6D,#D5,#75,#DF,#67,#F4,#02
	DB	#6C,#EF,#6E,#F7,#4F,#FE,#01
	DB	#80,#7E,#7E,#88,#80,#88,#02
	DB	#80,#88,#7C,#88,#80,#96,#02
	DB	#72,#7C,#7D,#87,#76,#92,#02
	DB	#72,#7C,#6F,#86,#74,#86,#02
	DB	#80,#52,#7F,#53,#80,#63,#03
	DB	#80,#4D,#80,#50,#75,#50,#03
	DB	#5E,#9D,#6A,#9D,#6A,#A6,#03
	DB	#5E,#9D,#6A,#A6,#5E,#A6,#03
	DB	#6C,#9E,#6C,#A7,#78,#A7,#03
	DB	#6C,#9E,#78,#9E,#78,#A7,#03
	DB	#7A,#9E,#80,#9E,#80,#A8,#03
	DB	#7A,#9E,#80,#A8,#7A,#A8,#83
; Taille 280 octets
