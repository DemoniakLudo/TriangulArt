; Généré par TriangulArt le 07/05/2021 (10 26 18)
BouBoule
; 4 octets de palette
	DB	"K_WU"
	DW	#0800			; Tps d'affichage ?
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
	DB	#8A,#00,#6E,#0F,#BB,#19,#03
	DB	#8A,#00,#6C,#0F,#3D,#11,#03
	DB	#6D,#10,#3E,#12,#1F,#3D,#03
	DB	#3C,#12,#1D,#3E,#09,#4B,#03
	DB	#1E,#3E,#09,#4C,#00,#83,#03
	DB	#00,#84,#0A,#AC,#1D,#D1,#03
	DB	#1E,#D1,#42,#E9,#6E,#FF,#03
	DB	#AA,#DA,#BA,#EE,#6E,#FF,#03
	DB	#EF,#B5,#AB,#D9,#BB,#EE,#03
	DB	#F0,#59,#F7,#7B,#F0,#B4,#03
	DB	#BD,#1A,#DB,#2E,#F0,#59,#03
	DB	#BD,#1B,#AB,#46,#EE,#58,#02
	DB	#AC,#47,#EF,#59,#CE,#8F,#02
	DB	#EF,#5A,#CE,#90,#EF,#B3,#02
	DB	#CE,#91,#EF,#B4,#AD,#D7,#02
	DB	#5A,#D3,#A9,#DA,#6E,#FE,#02
	DB	#1E,#D1,#59,#D2,#6C,#FD,#02
	DB	#2A,#92,#1E,#D1,#58,#D1,#02
	DB	#01,#85,#29,#91,#1D,#D0,#02
	DB	#1F,#3E,#01,#84,#29,#90,#02
	DB	#20,#3F,#5A,#4F,#2A,#8E,#02
	DB	#6C,#12,#1F,#3E,#59,#4E,#02
	DB	#6D,#11,#AB,#45,#5A,#4F,#02
	DB	#6D,#10,#BC,#1A,#AB,#44,#02
	DB	#AB,#46,#CD,#90,#83,#95,#01
	DB	#CD,#91,#84,#96,#AB,#D8,#01
	DB	#82,#95,#5B,#D2,#AB,#D9,#01
	DB	#2A,#91,#81,#95,#5A,#D2,#01
	DB	#5A,#50,#2A,#90,#81,#94,#01
	DB	#AA,#46,#5B,#50,#82,#95,#81
; Taille 210 octets
