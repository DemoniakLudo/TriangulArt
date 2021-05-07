; Généré par TriangulArt le 07/05/2021 (15 13 23)
Etoile
; 4 octets de palette
	DB	"@OMX"
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
	DB	#4E,#07,#A6,#53,#53,#8E,#02
	DB	#50,#56,#75,#56,#00,#99,#03
	DB	#5C,#88,#A0,#99,#7A,#B1,#03
	DB	#A2,#00,#C4,#74,#49,#8D,#02
	DB	#B9,#4A,#53,#7C,#D5,#E3,#02
	DB	#4E,#07,#7F,#2C,#7C,#30,#03
	DB	#A2,#00,#7B,#31,#69,#5C,#03
	DB	#B5,#3F,#FF,#40,#B6,#43,#03
	DB	#5B,#41,#75,#42,#6A,#56,#01
	DB	#5B,#41,#6A,#56,#59,#5E,#01
	DB	#80,#74,#77,#98,#00,#99,#01
	DB	#69,#5C,#80,#74,#00,#99,#01
	DB	#FF,#40,#B5,#43,#B0,#68,#01
	DB	#FF,#40,#B0,#68,#C2,#7C,#01
	DB	#AE,#54,#C5,#64,#AB,#6A,#01
	DB	#C5,#64,#AB,#6A,#B5,#7D,#01
	DB	#88,#62,#92,#72,#80,#7B,#01
	DB	#92,#72,#80,#7B,#92,#8A,#01
	DB	#88,#62,#76,#6A,#80,#7B,#02
	DB	#76,#6A,#80,#7B,#6A,#7D,#02
	DB	#80,#7B,#6A,#7D,#92,#8A,#03
	DB	#A2,#00,#A4,#70,#A6,#70,#03
	DB	#A4,#70,#A6,#70,#D5,#E3,#03
	DB	#AE,#54,#C5,#64,#C5,#65,#03
	DB	#C5,#64,#C5,#65,#B5,#7D,#03
	DB	#C5,#64,#C5,#66,#B5,#7D,#83
; Taille 182 octets
