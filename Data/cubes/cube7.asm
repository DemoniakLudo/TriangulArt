; Généré par TriangulArt le 03/05/2021 (19 58 57)
; 4 octets de palette
	DB	"DJSL"
	DW	#2000			; Tps d'affichage ?
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
	DB	#C3,#96,#AE,#B9,#C3,#DB,#01
	DB	#C3,#96,#D8,#B9,#C3,#DB,#01
	DB	#C3,#96,#D8,#B9,#FE,#B9,#02
	DB	#C3,#96,#EB,#96,#FE,#B9,#02
	DB	#FE,#B9,#D8,#B9,#C3,#DB,#03
	DB	#FE,#B9,#C3,#DB,#EB,#DB,#83
; Taille 42 octets
