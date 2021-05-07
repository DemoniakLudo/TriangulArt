; Généré par TriangulArt le 07/05/2021 (15 12 21)
Dolphin
; 4 octets de palette
	DB	"D_ST"
	DB	#09			; Tps d'affichage
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
	DB	#82,#A3,#74,#AC,#82,#BC,#01
	DB	#BF,#29,#DF,#4C,#CC,#5C,#01
	DB	#DE,#4C,#CC,#5C,#E0,#74,#01
	DB	#D4,#21,#B5,#22,#CD,#37,#01
	DB	#D2,#2C,#C6,#32,#DE,#4B,#01
	DB	#BF,#28,#CD,#5D,#B6,#66,#01
	DB	#99,#0F,#D4,#21,#B4,#25,#01
	DB	#9B,#0F,#E2,#12,#D2,#23,#01
	DB	#D6,#02,#99,#10,#E2,#12,#01
	DB	#82,#A3,#A6,#A8,#83,#BB,#01
	DB	#A6,#A7,#81,#BB,#96,#C4,#01
	DB	#A6,#A6,#B8,#BA,#94,#C6,#01
	DB	#B8,#BA,#95,#C5,#B5,#D3,#01
	DB	#95,#C5,#B6,#D2,#91,#D7,#01
	DB	#93,#D5,#9B,#EA,#AE,#EC,#01
	DB	#B5,#D2,#93,#D6,#AE,#ED,#01
	DB	#9C,#EA,#AE,#EC,#98,#FD,#01
	DB	#AC,#9B,#A5,#A6,#B9,#BB,#01
	DB	#D9,#97,#AC,#9C,#B4,#BC,#01
	DB	#CA,#5A,#E1,#73,#D8,#95,#01
	DB	#CC,#5D,#B6,#66,#D9,#99,#01
	DB	#B8,#67,#D9,#98,#B2,#9B,#01
	DB	#97,#0F,#C0,#29,#B7,#64,#01
	DB	#71,#00,#A9,#0A,#84,#3B,#01
	DB	#9D,#15,#84,#39,#B0,#50,#01
	DB	#74,#00,#58,#05,#84,#3A,#01
	DB	#87,#39,#85,#4E,#71,#51,#01
	DB	#86,#4E,#6F,#50,#81,#6A,#01
	DB	#84,#4F,#91,#68,#81,#6A,#01
	DB	#58,#05,#87,#3B,#6F,#52,#01
	DB	#58,#05,#68,#39,#45,#43,#01
	DB	#58,#04,#3B,#1B,#4B,#38,#01
	DB	#3B,#19,#32,#2E,#4C,#37,#01
	DB	#32,#2E,#47,#35,#23,#3E,#01
	DB	#34,#2E,#1E,#38,#25,#3E,#01
	DB	#4A,#36,#45,#45,#2B,#48,#01
	DB	#21,#45,#35,#47,#2C,#4C,#01
	DB	#56,#06,#77,#0B,#54,#11,#02
	DB	#56,#07,#4D,#0F,#56,#11,#02
	DB	#5B,#39,#4E,#41,#6B,#43,#02
	DB	#67,#39,#5B,#3A,#6A,#43,#02
	DB	#87,#3A,#86,#45,#B1,#50,#02
	DB	#86,#45,#AF,#4F,#B8,#65,#02
	DB	#A3,#56,#B8,#64,#B7,#81,#02
	DB	#B7,#82,#B4,#9F,#A6,#A6,#02
	DB	#B4,#7A,#B9,#82,#B2,#8C,#02
	DB	#55,#28,#59,#2F,#50,#30,#03
	DB	#55,#28,#5D,#28,#59,#2F,#83
; Taille 336 octets
