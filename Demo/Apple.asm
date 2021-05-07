; Généré par TriangulArt le 07/05/2021 (10 25 54)
Apple
; 4 octets de palette
	DB	"@TWK"
	DB	#12			; Tps d'affichage ?
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
	DB	#00,#00,#6C,#7F,#00,#FF,#02
	DB	#00,#00,#85,#00,#6C,#7F,#02
	DB	#6C,#7F,#8E,#7F,#00,#FF,#02
	DB	#8E,#7F,#00,#FF,#99,#FF,#02
	DB	#85,#00,#FF,#00,#6C,#7F,#03
	DB	#FF,#00,#FF,#7F,#6C,#7F,#03
	DB	#8E,#7F,#FF,#FF,#99,#FF,#03
	DB	#8E,#7F,#FF,#7F,#FF,#FF,#03
	DB	#47,#44,#42,#49,#4D,#49,#01
	DB	#42,#49,#4C,#49,#4D,#5D,#01
	DB	#42,#49,#4D,#5D,#42,#5D,#01
	DB	#42,#5D,#4C,#5D,#48,#62,#01
	DB	#B8,#43,#B3,#48,#BE,#48,#01
	DB	#B3,#48,#BD,#48,#BD,#5C,#01
	DB	#B3,#48,#B3,#5C,#BE,#5C,#01
	DB	#B3,#5C,#BD,#5C,#B9,#61,#01
	DB	#36,#9E,#30,#A4,#44,#B7,#01
	DB	#36,#9E,#48,#AF,#44,#B7,#01
	DB	#48,#AF,#44,#B7,#58,#C1,#01
	DB	#48,#AF,#5B,#B8,#58,#C1,#01
	DB	#5B,#B8,#58,#C1,#6E,#C5,#01
	DB	#5B,#B8,#70,#BD,#6E,#C5,#01
	DB	#70,#BD,#6E,#C5,#8D,#C5,#01
	DB	#70,#BD,#8D,#BD,#8D,#C5,#01
	DB	#8D,#BD,#A5,#C0,#8D,#C5,#01
	DB	#A2,#B8,#8D,#BD,#A5,#C0,#01
	DB	#A2,#B8,#B7,#B8,#A5,#C0,#01
	DB	#B3,#B1,#B7,#B8,#A2,#B8,#01
	DB	#C9,#9E,#B3,#B1,#B7,#B8,#01
	DB	#C9,#9E,#CF,#A4,#B7,#B8,#81
; Taille 210 octets
