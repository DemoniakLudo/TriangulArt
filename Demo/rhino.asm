; Généré par TriangulArt le 07/05/2021 (10 29 19)
Rhino
; 4 octets de palette
	DB	"N@KT"
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
	DB	#5D,#00,#29,#0F,#89,#27,#01
	DB	#29,#0F,#89,#27,#0A,#38,#01
	DB	#89,#27,#0A,#38,#00,#6E,#01
	DB	#89,#27,#00,#6E,#0C,#B7,#01
	DB	#89,#27,#0C,#B7,#20,#D3,#01
	DB	#89,#27,#20,#D3,#57,#EC,#01
	DB	#89,#27,#60,#EC,#57,#EC,#01
	DB	#89,#27,#72,#E7,#57,#EC,#01
	DB	#89,#27,#83,#D6,#72,#E7,#01
	DB	#89,#27,#9B,#31,#83,#D6,#01
	DB	#9B,#31,#AE,#48,#83,#D6,#01
	DB	#AE,#48,#D0,#94,#83,#D6,#01
	DB	#D0,#94,#83,#D6,#9D,#F0,#01
	DB	#D0,#94,#9D,#F0,#B4,#FD,#01
	DB	#D0,#94,#CE,#F8,#B4,#FD,#01
	DB	#D0,#94,#DE,#EB,#CE,#F8,#01
	DB	#D0,#94,#E6,#DD,#DE,#EB,#01
	DB	#D7,#97,#C8,#CF,#E0,#D4,#01
	DB	#CA,#90,#D7,#97,#CF,#DE,#01
	DB	#A8,#19,#9B,#31,#AE,#48,#01
	DB	#A8,#19,#B7,#3B,#AE,#48,#01
	DB	#B8,#0E,#A8,#19,#B7,#3B,#01
	DB	#B8,#0E,#CB,#18,#B7,#3B,#01
	DB	#C7,#63,#B1,#81,#B9,#92,#02
	DB	#C7,#63,#CF,#81,#B9,#92,#02
	DB	#CF,#81,#CC,#92,#B9,#92,#02
	DB	#F9,#67,#F0,#79,#FF,#84,#02
	DB	#F0,#79,#FF,#84,#E1,#92,#02
	DB	#FF,#84,#E1,#92,#FC,#A6,#02
	DB	#E1,#92,#D9,#98,#FC,#A6,#02
	DB	#D9,#98,#FC,#A6,#E1,#CD,#02
	DB	#D9,#98,#E1,#CD,#D6,#CF,#02
	DB	#D9,#98,#C3,#C4,#D6,#CF,#02
	DB	#D9,#98,#BF,#B2,#C3,#C4,#02
	DB	#D9,#98,#C7,#9B,#BF,#B2,#02
	DB	#A5,#E3,#B2,#E3,#B9,#EB,#03
	DB	#A5,#E3,#AC,#EA,#B9,#EB,#03
	DB	#98,#A9,#8A,#AB,#93,#AE,#03
	DB	#83,#9D,#98,#A9,#8A,#AB,#03
	DB	#5B,#10,#5C,#10,#69,#3F,#03
	DB	#5B,#10,#3E,#18,#3E,#19,#03
	DB	#3E,#19,#53,#37,#54,#37,#03
	DB	#58,#38,#57,#39,#4B,#74,#03
	DB	#4A,#74,#4B,#74,#4E,#9A,#03
	DB	#4C,#9B,#69,#C6,#6A,#C6,#03
	DB	#69,#C6,#82,#D6,#83,#D6,#83
; Taille 322 octets
