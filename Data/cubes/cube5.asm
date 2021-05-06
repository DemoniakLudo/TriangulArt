; Généré par TriangulArt le 03/05/2021 (19 58 41)
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
	DB	#4F,#96,#3A,#B9,#4F,#DB,#01
	DB	#4F,#96,#64,#B9,#4F,#DB,#01
	DB	#4F,#96,#64,#B9,#8A,#B9,#02
	DB	#4F,#96,#77,#96,#8A,#B9,#02
	DB	#8A,#B9,#64,#B9,#4F,#DB,#03
	DB	#8A,#B9,#4F,#DB,#77,#DB,#83
; Taille 42 octets
