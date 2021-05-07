; Généré par TriangulArt le 07/05/2021 (10 29 09)
Pyramides
; 4 octets de palette
	DB	"KJLN"
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
	DB	#CF,#5A,#98,#AC,#E7,#C3,#03
	DB	#CF,#5A,#FE,#9A,#E7,#C3,#01
	DB	#3A,#73,#01,#C4,#52,#DC,#03
	DB	#3A,#73,#69,#B2,#52,#DC,#01
	DB	#55,#6C,#A5,#85,#6B,#D4,#03
	DB	#A5,#85,#D3,#C2,#6B,#D4,#01
	DB	#BD,#5B,#A5,#85,#D3,#C2,#01
	DB	#BD,#5B,#54,#6C,#A5,#85,#02
	DB	#A5,#85,#A6,#85,#D3,#C2,#03
	DB	#8C,#00,#53,#51,#A5,#69,#03
	DB	#8C,#00,#BB,#40,#A5,#69,#01
	DB	#AE,#97,#75,#E6,#C6,#FF,#03
	DB	#AE,#97,#DD,#D5,#C6,#FF,#01
	DB	#AE,#97,#DD,#D5,#DE,#D5,#03
	DB	#AE,#97,#AE,#98,#DD,#D5,#83
; Taille 105 octets
