; Généré par TriangulArt le 07/05/2021 (10 27 11)
Elephant2
; 4 octets de palette
	DB	"O_[K"
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
	DB	#92,#2C,#85,#37,#9F,#57,#01
	DB	#92,#2C,#A6,#36,#9E,#57,#01
	DB	#AB,#3A,#9D,#57,#AE,#62,#01
	DB	#A6,#36,#AB,#3A,#9E,#56,#01
	DB	#B5,#39,#C3,#3C,#AC,#69,#01
	DB	#C3,#3C,#AC,#6A,#B1,#6E,#01
	DB	#C2,#3C,#CA,#4D,#B1,#6E,#01
	DB	#B9,#79,#BF,#81,#B2,#88,#01
	DB	#BF,#81,#B2,#88,#BC,#96,#01
	DB	#BD,#92,#BB,#95,#C2,#9F,#01
	DB	#D4,#80,#BF,#84,#DC,#A4,#01
	DB	#D2,#7F,#E3,#95,#DC,#A4,#01
	DB	#F0,#60,#EF,#67,#F7,#68,#01
	DB	#F6,#60,#EF,#60,#F7,#68,#01
	DB	#88,#40,#8E,#72,#7A,#7F,#01
	DB	#88,#40,#7A,#68,#7A,#7F,#01
	DB	#63,#3E,#44,#40,#58,#78,#01
	DB	#5B,#7F,#71,#90,#66,#99,#01
	DB	#5B,#7F,#7A,#81,#71,#90,#01
	DB	#33,#74,#58,#7B,#3F,#95,#01
	DB	#33,#49,#10,#58,#33,#6E,#01
	DB	#20,#7E,#11,#87,#3F,#98,#01
	DB	#11,#87,#3F,#98,#37,#A0,#01
	DB	#07,#78,#12,#83,#04,#87,#01
	DB	#18,#8E,#20,#A0,#15,#B3,#01
	DB	#19,#8E,#0C,#9E,#15,#B3,#01
	DB	#74,#95,#86,#BB,#75,#BD,#01
	DB	#7B,#88,#8A,#9D,#85,#BB,#01
	DB	#7B,#88,#73,#97,#85,#BA,#01
	DB	#A5,#90,#89,#9E,#9D,#B3,#01
	DB	#A5,#90,#AE,#AB,#9B,#B2,#01
	DB	#B6,#3C,#A9,#3D,#AF,#58,#02
	DB	#C6,#51,#B0,#6C,#C1,#82,#02
	DB	#C6,#54,#D2,#7A,#C3,#7D,#02
	DB	#E4,#94,#EA,#95,#DC,#A6,#02
	DB	#EA,#94,#F5,#A1,#DD,#A4,#02
	DB	#F7,#75,#EA,#95,#F3,#A0,#02
	DB	#F1,#74,#F7,#76,#EA,#95,#02
	DB	#F9,#66,#F1,#68,#F7,#74,#02
	DB	#F9,#66,#FE,#73,#F6,#75,#02
	DB	#AB,#5D,#95,#6D,#A8,#7F,#02
	DB	#AB,#5D,#B7,#6C,#AA,#7F,#02
	DB	#A8,#5F,#8D,#63,#97,#6D,#02
	DB	#87,#46,#A8,#5E,#8E,#61,#02
	DB	#8F,#73,#A2,#79,#79,#84,#02
	DB	#78,#87,#A9,#8F,#8E,#9A,#02
	DB	#97,#7F,#77,#88,#A9,#8F,#02
	DB	#AB,#AD,#9B,#B2,#A3,#C5,#02
	DB	#AB,#AD,#B1,#BF,#A2,#C5,#02
	DB	#B7,#BF,#9F,#C6,#A2,#CD,#02
	DB	#B7,#BF,#B5,#C8,#A2,#CC,#02
	DB	#85,#BD,#76,#BF,#73,#C8,#02
	DB	#85,#BC,#74,#C7,#85,#CB,#02
	DB	#85,#BC,#8B,#C6,#85,#CB,#02
	DB	#86,#43,#67,#46,#7C,#6C,#02
	DB	#63,#47,#7C,#6C,#58,#80,#02
	DB	#75,#74,#62,#7A,#74,#82,#02
	DB	#44,#42,#3A,#71,#58,#78,#02
	DB	#45,#42,#2D,#44,#3A,#71,#02
	DB	#13,#5B,#31,#70,#0A,#77,#02
	DB	#2C,#70,#0A,#77,#13,#85,#02
	DB	#31,#72,#23,#7E,#41,#99,#02
	DB	#59,#80,#3F,#94,#55,#A0,#02
	DB	#59,#83,#64,#97,#57,#99,#02
	DB	#1A,#8F,#2B,#B0,#3D,#C0,#02
	DB	#19,#8F,#38,#A1,#3D,#C0,#02
	DB	#0B,#A3,#01,#BA,#08,#C3,#02
	DB	#0B,#A3,#08,#C4,#1E,#C5,#02
	DB	#24,#AA,#24,#BE,#2D,#C6,#02
	DB	#23,#AA,#2D,#C6,#46,#C9,#82
; Taille 490 octets
