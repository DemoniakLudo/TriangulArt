; Généré par TriangulArt le 03/05/2021 (20 00 38)
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
	DB	#89,#32,#74,#55,#89,#77,#01
	DB	#89,#32,#9E,#55,#89,#77,#01
	DB	#89,#32,#9E,#55,#C4,#55,#02
	DB	#89,#32,#B1,#32,#C4,#55,#02
	DB	#C4,#55,#9E,#55,#89,#77,#03
	DB	#C4,#55,#89,#77,#B1,#77,#83
; Taille 42 octets
