; Généré par TriangulArt le 07/05/2021 (10 27 32)
Girafe
; 4 octets de palette
	DB	"WJNT"
	DW	#0800			; Tps d'affichage ?
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
	DB	#61,#01,#54,#0E,#5E,#37,#01
	DB	#61,#01,#74,#04,#5E,#37,#01
	DB	#74,#04,#5E,#37,#6A,#43,#02
	DB	#5E,#37,#6A,#43,#54,#4C,#01
	DB	#6A,#43,#54,#4C,#80,#53,#02
	DB	#54,#4C,#80,#53,#56,#63,#01
	DB	#80,#53,#56,#63,#72,#7C,#02
	DB	#56,#63,#55,#73,#72,#7C,#01
	DB	#55,#73,#72,#7C,#60,#87,#01
	DB	#55,#73,#52,#82,#60,#87,#01
	DB	#52,#82,#60,#87,#4A,#8D,#01
	DB	#60,#87,#4A,#8D,#52,#96,#01
	DB	#56,#63,#55,#73,#46,#7B,#01
	DB	#4E,#6E,#2F,#73,#46,#7B,#01
	DB	#33,#54,#4E,#6E,#2F,#73,#01
	DB	#45,#4C,#33,#54,#4E,#6E,#03
	DB	#45,#4C,#56,#63,#4E,#6E,#02
	DB	#30,#47,#45,#4C,#33,#54,#03
	DB	#1A,#43,#30,#47,#33,#54,#03
	DB	#1A,#43,#1B,#4E,#33,#54,#01
	DB	#1B,#4E,#33,#54,#2F,#74,#01
	DB	#54,#73,#46,#7B,#4A,#84,#03
	DB	#54,#73,#52,#82,#4A,#84,#03
	DB	#52,#82,#4A,#85,#4A,#8E,#01
	DB	#80,#53,#72,#7C,#80,#9A,#02
	DB	#72,#7C,#80,#9A,#74,#A1,#01
	DB	#80,#9A,#74,#A1,#73,#C8,#01
	DB	#80,#9A,#73,#C8,#80,#CC,#02
	DB	#73,#C8,#80,#CC,#78,#E1,#03
	DB	#80,#CC,#78,#E1,#80,#FA,#02
	DB	#78,#E1,#68,#EA,#80,#FA,#01
	DB	#68,#EA,#70,#FA,#80,#FA,#02
	DB	#66,#D2,#78,#E1,#68,#EA,#01
	DB	#74,#C8,#66,#D2,#78,#E1,#02
	DB	#74,#A2,#74,#C8,#66,#D2,#02
	DB	#74,#A2,#58,#C3,#66,#D2,#01
	DB	#57,#A0,#74,#A2,#58,#C3,#02
	DB	#68,#81,#57,#A0,#74,#A2,#01
	DB	#72,#7B,#68,#81,#74,#A2,#02
	DB	#68,#81,#52,#94,#57,#A0,#81
; Taille 280 octets
