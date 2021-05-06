; Généré par TriangulArt le 02/05/2021 (11 22 15)
; 4 octets de palette
	DB	"KVNT"
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
	DB	#A5,#19,#8A,#2A,#8A,#43,#02
	DB	#A5,#19,#A5,#33,#8A,#43,#82
; Taille 14 octets
