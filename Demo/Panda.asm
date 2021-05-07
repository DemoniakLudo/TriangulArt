; Généré par TriangulArt le 07/05/2021 (10 28 40)
Panda
; 4 octets de palette
	DB	"RKTL"
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
	DB	#17,#A7,#75,#AE,#36,#B0,#01
	DB	#03,#8B,#17,#A7,#75,#AE,#01
	DB	#04,#75,#03,#8B,#75,#AE,#01
	DB	#0E,#54,#04,#75,#75,#AE,#01
	DB	#2A,#3D,#0E,#54,#75,#AE,#01
	DB	#6A,#3C,#2A,#3D,#75,#AE,#01
	DB	#6A,#3C,#98,#5A,#75,#AE,#01
	DB	#9D,#4E,#DA,#AE,#75,#AE,#01
	DB	#9D,#4E,#F1,#A5,#DA,#AE,#01
	DB	#9D,#4E,#FF,#8D,#F1,#A5,#01
	DB	#AC,#48,#9D,#4E,#EE,#84,#01
	DB	#AC,#48,#CA,#55,#EE,#84,#01
	DB	#CA,#55,#DA,#6B,#F0,#77,#01
	DB	#DA,#6B,#F0,#77,#EE,#84,#01
	DB	#0E,#4D,#14,#50,#0D,#57,#02
	DB	#0E,#4D,#05,#55,#0D,#57,#02
	DB	#05,#55,#0E,#57,#09,#66,#02
	DB	#20,#66,#03,#75,#03,#8C,#02
	DB	#20,#66,#2C,#6D,#03,#8C,#02
	DB	#2C,#6D,#39,#82,#03,#8C,#02
	DB	#39,#82,#2E,#88,#03,#8C,#02
	DB	#2E,#88,#03,#8C,#22,#98,#02
	DB	#03,#8C,#22,#98,#17,#A7,#02
	DB	#22,#98,#17,#A7,#3C,#B2,#02
	DB	#2F,#9B,#32,#A7,#3C,#B2,#02
	DB	#37,#8C,#2F,#9B,#3C,#B2,#02
	DB	#43,#87,#37,#8C,#3C,#B2,#02
	DB	#43,#87,#52,#9E,#3C,#B2,#02
	DB	#52,#9E,#42,#B0,#3C,#B2,#02
	DB	#69,#3B,#59,#88,#8E,#92,#02
	DB	#59,#88,#8E,#92,#61,#9D,#02
	DB	#8E,#92,#61,#9D,#71,#AF,#02
	DB	#8E,#92,#71,#AF,#99,#BA,#02
	DB	#8E,#92,#A4,#9B,#99,#BA,#02
	DB	#A4,#9B,#B7,#AB,#99,#BA,#02
	DB	#B7,#AB,#BF,#BA,#99,#BA,#02
	DB	#9E,#4F,#95,#5E,#A1,#66,#02
	DB	#9E,#4F,#AF,#58,#A1,#66,#02
	DB	#AB,#47,#9E,#4F,#AF,#58,#02
	DB	#AB,#47,#B3,#4C,#AF,#58,#02
	DB	#B7,#48,#B3,#4C,#C9,#55,#02
	DB	#C4,#47,#B7,#48,#C9,#55,#02
	DB	#C4,#47,#CA,#4C,#C9,#55,#02
	DB	#BA,#90,#DB,#98,#C6,#9C,#02
	DB	#D9,#79,#BA,#90,#DB,#98,#02
	DB	#D9,#79,#C4,#7E,#BA,#90,#02
	DB	#D9,#79,#E2,#89,#DB,#98,#02
	DB	#F7,#8E,#FF,#8E,#F7,#9C,#82
; Taille 336 octets
