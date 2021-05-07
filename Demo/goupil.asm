; Généré par TriangulArt le 07/05/2021 (15 14 35)
Goupil
; 4 octets de palette
	DB	"JKNT"
	DB	#0F			; Tps d'affichage
	DB	#00			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#16,#00,#40,#21,#37,#28,#02
	DB	#16,#00,#37,#28,#1F,#39,#01
	DB	#72,#00,#48,#21,#51,#28,#02
	DB	#72,#00,#51,#28,#69,#39,#01
	DB	#44,#1E,#00,#4D,#43,#56,#01
	DB	#11,#6E,#77,#6E,#44,#E0,#02
	DB	#44,#1E,#87,#4D,#43,#56,#01
	DB	#44,#44,#11,#6E,#44,#95,#01
	DB	#44,#44,#77,#6E,#44,#95,#01
	DB	#44,#1E,#24,#34,#44,#77,#02
	DB	#44,#1E,#64,#34,#44,#77,#02
	DB	#44,#1E,#35,#6B,#44,#6D,#02
	DB	#44,#1E,#53,#6B,#44,#6D,#02
	DB	#32,#41,#3C,#41,#3D,#4B,#03
	DB	#4C,#41,#57,#41,#4C,#4B,#03
	DB	#44,#6C,#3C,#77,#44,#77,#03
	DB	#41,#6C,#3C,#77,#4C,#77,#03
	DB	#41,#6C,#47,#6C,#4C,#77,#03
	DB	#35,#6B,#3A,#70,#3C,#77,#03
	DB	#53,#6C,#4E,#70,#4B,#77,#03
	DB	#29,#80,#5F,#80,#45,#E0,#01
	DB	#64,#88,#89,#96,#45,#E0,#02
	DB	#89,#96,#A6,#AE,#45,#E0,#02
	DB	#A6,#AE,#A6,#E0,#45,#E0,#02
	DB	#DA,#7A,#A6,#86,#A6,#E0,#02
	DB	#DA,#4C,#DA,#7A,#A6,#86,#02
	DB	#DA,#4C,#FF,#79,#DA,#7A,#02
	DB	#FF,#79,#DA,#7A,#A6,#E0,#02
	DB	#FF,#4B,#DA,#4C,#FF,#79,#81
; Taille 203 octets
