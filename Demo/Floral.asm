; Généré par TriangulArt le 07/05/2021 (10 27 24)
Floral
; 4 octets de palette
	DB	"CYSO"
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
	DB	#18,#00,#00,#00,#00,#18,#01
	DB	#00,#E7,#00,#FF,#18,#FF,#01
	DB	#30,#00,#00,#30,#30,#30,#02
	DB	#00,#CF,#30,#CF,#30,#FF,#02
	DB	#48,#18,#18,#48,#48,#48,#03
	DB	#18,#B7,#48,#B7,#48,#E7,#03
	DB	#60,#30,#60,#60,#30,#60,#01
	DB	#30,#9F,#60,#9F,#60,#CF,#01
	DB	#78,#48,#78,#78,#48,#78,#02
	DB	#48,#87,#78,#87,#78,#B7,#02
	DB	#80,#6F,#70,#7F,#80,#8E,#03
	DB	#48,#6B,#33,#80,#48,#94,#03
	DB	#32,#6B,#1D,#80,#32,#94,#01
	DB	#1C,#6B,#08,#80,#1C,#94,#82
; Taille 98 octets
