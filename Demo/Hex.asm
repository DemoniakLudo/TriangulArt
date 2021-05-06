; Généré par TriangulArt le 22/04/2021 (15 18 04)
; 4 octets de palette
	DB	"DUWS"
	DW	#0200			; Tps d'affichage ?
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
	DB	#52,#17,#95,#24,#21,#3D,#01
	DB	#21,#3D,#34,#72,#77,#7F,#01
	DB	#95,#23,#A7,#57,#77,#7F,#01
	DB	#95,#23,#21,#3D,#77,#7F,#01
	DB	#21,#3D,#34,#72,#34,#81,#02
	DB	#21,#3D,#21,#51,#34,#81,#02
	DB	#57,#26,#63,#3F,#34,#41,#02
	DB	#63,#3F,#34,#41,#41,#66,#03
	DB	#63,#3F,#41,#66,#70,#70,#02
	DB	#63,#3F,#7E,#4A,#70,#70,#00
	DB	#7E,#4A,#88,#5D,#70,#70,#00
	DB	#63,#3F,#7B,#41,#7E,#4A,#00
	DB	#57,#26,#85,#2E,#85,#2F,#00
	DB	#85,#2E,#85,#2F,#63,#3F,#00
	DB	#63,#41,#94,#53,#94,#54,#00
	DB	#94,#54,#70,#6D,#70,#70,#00
	DB	#84,#2E,#85,#2F,#94,#54,#00
	DB	#85,#2C,#7C,#41,#7B,#41,#00
	DB	#7C,#41,#94,#53,#94,#54,#00
	DB	#A8,#57,#EB,#64,#77,#7D,#01
	DB	#77,#7D,#8A,#B2,#CD,#BF,#01
	DB	#EB,#63,#FD,#97,#CD,#BF,#01
	DB	#EB,#63,#77,#7D,#CD,#BF,#01
	DB	#8A,#B2,#CD,#BF,#8A,#C1,#02
	DB	#CD,#BF,#8A,#C1,#CD,#CE,#02
	DB	#FD,#97,#CD,#BF,#CD,#CE,#02
	DB	#FD,#97,#FD,#A6,#CD,#CE,#02
	DB	#AD,#66,#B9,#7F,#8A,#81,#02
	DB	#B9,#7F,#8A,#81,#97,#A6,#03
	DB	#B9,#7F,#97,#A6,#C6,#B0,#02
	DB	#B9,#7F,#D4,#8A,#C6,#B0,#00
	DB	#D4,#8A,#DE,#9D,#C6,#B0,#00
	DB	#B9,#7F,#D1,#81,#D4,#8A,#00
	DB	#AD,#66,#DB,#6E,#DB,#6F,#00
	DB	#DB,#6E,#DB,#6F,#B9,#7F,#00
	DB	#B9,#81,#EA,#93,#EA,#94,#00
	DB	#EA,#94,#C6,#AD,#C6,#B0,#00
	DB	#DA,#6E,#DB,#6F,#EA,#94,#00
	DB	#DB,#6C,#D2,#81,#D1,#81,#00
	DB	#D2,#81,#EA,#93,#EA,#94,#00
	DB	#35,#72,#78,#7F,#04,#98,#01
	DB	#04,#98,#17,#CD,#5A,#DA,#01
	DB	#78,#7E,#8A,#B2,#5A,#DA,#01
	DB	#78,#7E,#04,#98,#5A,#DA,#01
	DB	#04,#98,#17,#CD,#17,#DC,#02
	DB	#04,#98,#04,#AC,#17,#DC,#02
	DB	#17,#CD,#5A,#DA,#17,#DC,#02
	DB	#5A,#DA,#17,#DC,#5A,#E9,#02
	DB	#8A,#B2,#5A,#DA,#5A,#E9,#02
	DB	#8A,#B2,#8A,#C1,#5A,#E9,#02
	DB	#3A,#81,#46,#9A,#17,#9C,#02
	DB	#46,#9A,#17,#9C,#24,#C1,#03
	DB	#46,#9A,#24,#C1,#53,#CB,#02
	DB	#46,#9A,#61,#A5,#53,#CB,#00
	DB	#61,#A5,#6B,#B8,#53,#CB,#00
	DB	#46,#9A,#5E,#9C,#61,#A5,#00
	DB	#3A,#81,#68,#89,#68,#8A,#00
	DB	#68,#89,#68,#8A,#46,#9A,#00
	DB	#46,#9C,#77,#AE,#77,#AF,#00
	DB	#77,#AF,#53,#C8,#53,#CB,#00
	DB	#67,#89,#68,#8A,#77,#AF,#00
	DB	#68,#87,#5F,#9C,#5E,#9C,#00
	DB	#5F,#9C,#77,#AE,#77,#AF,#80
; Taille 441 octets
