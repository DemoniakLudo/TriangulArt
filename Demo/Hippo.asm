; Généré par TriangulArt le 07/05/2021 (10 27 58)
Hippo
; 4 octets de palette
	DB	"D@TL"
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
	DB	#65,#0A,#80,#0F,#80,#34,#01
	DB	#65,#0A,#4B,#0E,#80,#34,#01
	DB	#4B,#0E,#36,#34,#80,#34,#01
	DB	#44,#02,#30,#02,#4B,#0E,#01
	DB	#30,#02,#4B,#0E,#30,#14,#01
	DB	#4B,#0E,#30,#14,#43,#1D,#01
	DB	#36,#34,#80,#34,#44,#78,#01
	DB	#80,#34,#44,#78,#48,#B0,#01
	DB	#44,#78,#48,#B0,#21,#BE,#01
	DB	#80,#34,#21,#BE,#73,#FF,#01
	DB	#80,#34,#80,#FF,#73,#FF,#01
	DB	#3A,#48,#49,#4D,#42,#53,#02
	DB	#59,#AC,#47,#B1,#63,#BF,#02
	DB	#47,#B1,#63,#BF,#4E,#C4,#02
	DB	#21,#BE,#2D,#E4,#73,#FF,#81
; Taille 105 octets
