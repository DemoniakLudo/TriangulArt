; Généré par TriangulArt le 07/05/2021 (15 12 39)
Donut
; 4 octets de palette
	DB	"XCSL"
	DB	#06			; Tps d'affichage
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
	DB	#55,#A2,#81,#A2,#8C,#C6,#03
	DB	#8C,#C6,#3E,#EA,#97,#EA,#03
	DB	#C4,#A2,#EA,#B4,#97,#EA,#03
	DB	#B8,#7F,#C4,#A2,#81,#A2,#03
	DB	#C4,#A2,#8C,#C6,#97,#EA,#01
	DB	#81,#A2,#C4,#A2,#8C,#C6,#01
	DB	#55,#A2,#60,#C6,#8C,#C6,#01
	DB	#60,#C6,#8C,#C6,#3E,#EA,#01
	DB	#34,#7F,#55,#A2,#60,#C6,#03
	DB	#34,#7F,#02,#90,#55,#A2,#01
	DB	#B8,#7F,#CE,#80,#C4,#A2,#01
	DB	#CE,#80,#C4,#A2,#EA,#B4,#01
	DB	#C4,#5C,#B8,#7F,#CE,#80,#03
	DB	#FF,#6E,#CE,#80,#EA,#B4,#03
	DB	#0D,#B4,#60,#C6,#3E,#EA,#03
	DB	#02,#90,#0D,#B4,#3E,#EA,#01
	DB	#34,#7F,#3E,#A2,#60,#C6,#01
	DB	#3E,#A2,#0D,#B4,#60,#C6,#01
	DB	#CF,#37,#F5,#4A,#FF,#6E,#01
	DB	#AE,#5B,#FF,#6E,#CE,#80,#01
	DB	#18,#49,#02,#90,#0D,#B4,#03
	DB	#C4,#15,#CF,#37,#F5,#4A,#03
	DB	#23,#6D,#3E,#A2,#0D,#B4,#03
	DB	#CF,#37,#AE,#5B,#FF,#6E,#03
	DB	#23,#6D,#4A,#80,#3E,#A2,#01
	DB	#18,#49,#23,#6D,#0D,#B4,#01
	DB	#CF,#37,#AE,#5B,#82,#5B,#01
	DB	#6C,#14,#18,#49,#23,#6D,#03
	DB	#C4,#15,#CF,#37,#77,#37,#01
	DB	#6C,#14,#C4,#15,#77,#37,#03
	DB	#77,#37,#82,#5B,#4A,#80,#01
	DB	#CF,#37,#77,#37,#82,#5B,#03
	DB	#77,#37,#23,#6D,#4A,#80,#03
	DB	#6C,#14,#77,#37,#23,#6D,#81
; Taille 238 octets
