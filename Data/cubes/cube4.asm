; Généré par TriangulArt le 03/05/2021 (19 57 40)
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
	DB	#15,#96,#00,#B9,#15,#DB,#01
	DB	#15,#96,#2A,#B9,#15,#DB,#01
	DB	#15,#96,#2A,#B9,#50,#B9,#02
	DB	#15,#96,#3D,#96,#50,#B9,#02
	DB	#50,#B9,#2A,#B9,#15,#DB,#03
	DB	#50,#B9,#15,#DB,#3D,#DB,#83
; Taille 42 octets
