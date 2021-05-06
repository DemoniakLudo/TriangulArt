
; 4 octets de palette
	DB	"DT\L"
	DW	#200			; Tps d'affichage ?
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
	DB	#77,#1C,#99,#22,#73,#38,#02
	DB	#98,#22,#9D,#37,#73,#38,#02
	DB	#D9,#1E,#D7,#39,#CD,#3B,#01
	DB	#8F,#27,#8F,#2D,#7E,#2F,#01
	DB	#89,#26,#8F,#27,#7E,#2F,#01
	DB	#CE,#00,#C5,#06,#D8,#0B,#01
	DB	#CD,#00,#D7,#04,#D7,#0A,#01
	DB	#C7,#05,#99,#22,#9E,#37,#02
	DB	#C7,#05,#D7,#0B,#9E,#37,#02
	DB	#D7,#0B,#D9,#1E,#9E,#37,#02
	DB	#D9,#1E,#9E,#37,#CD,#3A,#02
	DB	#78,#1C,#5F,#25,#45,#50,#02
	DB	#77,#1D,#46,#4D,#6E,#5E,#02
	DB	#DE,#37,#E4,#3F,#C4,#71,#02
	DB	#DF,#37,#C8,#3D,#C4,#70,#02
	DB	#73,#37,#CC,#38,#65,#F1,#02
	DB	#49,#47,#A9,#6F,#10,#73,#02
	DB	#2E,#71,#15,#A0,#DF,#B9,#02
	DB	#B9,#56,#82,#A6,#DF,#B8,#02
	DB	#C7,#40,#B7,#58,#C4,#73,#02
	DB	#6F,#6F,#2E,#72,#6D,#8C,#02
	DB	#DF,#B8,#C4,#F5,#D8,#FE,#02
	DB	#DE,#B9,#64,#E6,#B8,#F6,#02
	DB	#8B,#AC,#DE,#B9,#6B,#E7,#02
	DB	#7E,#EB,#B7,#F5,#A2,#F9,#02
	DB	#86,#DA,#97,#F4,#84,#F9,#02
	DB	#8F,#C3,#67,#ED,#80,#F2,#02
	DB	#15,#A0,#96,#AD,#21,#AE,#02
	DB	#63,#A6,#20,#AE,#46,#F5,#02
	DB	#7C,#C8,#49,#EC,#55,#F8,#02
	DB	#72,#5F,#6A,#D5,#49,#EB,#82
; Taille 217 octets
