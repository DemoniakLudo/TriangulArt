; Généré par TriangulArt le 07/05/2021 (10 26 37)
Cylindre
; 4 octets de palette
	DB	"DUWL"
	DW	#0200			; Tps d'affichage ?
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
	DB	#8B,#ED,#5A,#F1,#7A,#F1,#02
	DB	#0D,#53,#08,#64,#02,#6E,#01
	DB	#15,#45,#0D,#53,#08,#64,#01
	DB	#18,#CA,#22,#CD,#3C,#E5,#01
	DB	#18,#CA,#30,#DF,#3C,#E5,#01
	DB	#02,#6E,#05,#88,#01,#8F,#02
	DB	#08,#64,#02,#6E,#05,#88,#02
	DB	#8B,#ED,#6C,#ED,#5A,#F1,#02
	DB	#01,#8F,#0F,#AD,#08,#AF,#01
	DB	#05,#88,#01,#8F,#0F,#AD,#01
	DB	#3C,#E5,#6C,#ED,#5A,#F1,#01
	DB	#4D,#DF,#3C,#E5,#6C,#ED,#01
	DB	#2B,#2E,#25,#40,#15,#45,#01
	DB	#3B,#28,#2B,#2E,#25,#40,#01
	DB	#67,#16,#5C,#1E,#4C,#23,#02
	DB	#67,#16,#57,#1B,#4C,#23,#02
	DB	#9C,#E6,#6C,#ED,#8B,#ED,#01
	DB	#08,#AF,#18,#CA,#22,#CD,#02
	DB	#15,#45,#19,#60,#08,#64,#02
	DB	#25,#40,#15,#45,#19,#60,#02
	DB	#22,#CD,#4D,#DF,#3C,#E5,#02
	DB	#33,#C8,#22,#CD,#4D,#DF,#02
	DB	#3B,#28,#36,#3A,#25,#40,#02
	DB	#4C,#23,#3B,#28,#36,#3A,#02
	DB	#F4,#50,#FD,#74,#A3,#74,#01
	DB	#08,#64,#17,#84,#05,#88,#01
	DB	#19,#60,#08,#64,#17,#84,#01
	DB	#0F,#AD,#33,#C8,#22,#CD,#01
	DB	#20,#A8,#0F,#AD,#33,#C8,#01
	DB	#9C,#E6,#7C,#E6,#6C,#ED,#02
	DB	#0F,#AD,#08,#AF,#22,#CD,#02
	DB	#A3,#74,#FD,#74,#FC,#98,#02
	DB	#05,#88,#20,#A8,#0F,#AD,#02
	DB	#17,#84,#05,#88,#20,#A8,#02
	DB	#E1,#2F,#F4,#50,#A3,#74,#02
	DB	#79,#10,#67,#16,#5C,#1E,#01
	DB	#79,#10,#6E,#17,#5C,#1E,#01
	DB	#AC,#E2,#7C,#E6,#9C,#E6,#02
	DB	#A3,#74,#FC,#98,#EE,#B7,#01
	DB	#57,#1B,#4C,#23,#3B,#28,#01
	DB	#4D,#DF,#7C,#E6,#6C,#ED,#02
	DB	#5C,#DA,#4D,#DF,#7C,#E6,#02
	DB	#A9,#0B,#C7,#18,#A3,#74,#02
	DB	#25,#40,#2A,#5A,#19,#60,#01
	DB	#36,#3A,#25,#40,#2A,#5A,#01
	DB	#33,#C8,#5C,#DA,#4D,#DF,#01
	DB	#43,#C2,#33,#C8,#5C,#DA,#01
	DB	#AC,#E2,#8D,#E2,#7C,#E6,#02
	DB	#4C,#23,#47,#36,#36,#3A,#01
	DB	#5C,#1E,#4C,#23,#47,#36,#01
	DB	#19,#60,#28,#7F,#17,#84,#02
	DB	#2A,#5A,#19,#60,#28,#7F,#02
	DB	#5C,#DA,#8D,#E2,#7C,#E6,#01
	DB	#6E,#D5,#5C,#DA,#8D,#E2,#01
	DB	#A9,#0B,#89,#0B,#A3,#74,#01
	DB	#C7,#18,#E1,#2F,#A3,#74,#01
	DB	#A3,#74,#EE,#B7,#DA,#CF,#02
	DB	#20,#A8,#43,#C2,#33,#C8,#02
	DB	#30,#A3,#20,#A8,#43,#C2,#02
	DB	#BC,#DB,#8D,#E2,#AC,#E2,#01
	DB	#A3,#74,#DA,#CF,#BC,#DB,#01
	DB	#28,#7F,#17,#84,#30,#A3,#01
	DB	#89,#0B,#79,#10,#6E,#17,#01
	DB	#17,#84,#30,#A3,#20,#A8,#01
	DB	#36,#3A,#3A,#55,#2A,#5A,#02
	DB	#47,#36,#36,#3A,#3A,#55,#02
	DB	#43,#C2,#6E,#D5,#5C,#DA,#02
	DB	#55,#BD,#43,#C2,#6E,#D5,#02
	DB	#BC,#DB,#9E,#DC,#8D,#E2,#01
	DB	#5C,#1E,#58,#2F,#47,#36,#02
	DB	#6E,#17,#5C,#1E,#58,#2F,#02
	DB	#2A,#5A,#38,#79,#28,#7F,#01
	DB	#3A,#55,#2A,#5A,#38,#79,#01
	DB	#30,#A3,#55,#BD,#43,#C2,#01
	DB	#41,#9D,#30,#A3,#55,#BD,#01
	DB	#28,#7F,#41,#9D,#30,#A3,#02
	DB	#38,#79,#28,#7F,#41,#9D,#02
	DB	#6E,#17,#58,#2F,#A3,#74,#01
	DB	#6E,#D5,#9E,#DC,#8D,#E2,#02
	DB	#7E,#CF,#6E,#D5,#9E,#DC,#02
	DB	#89,#0B,#6E,#17,#A3,#74,#02
	DB	#A3,#74,#BC,#DB,#9E,#DC,#02
	DB	#47,#36,#4B,#4F,#3A,#55,#01
	DB	#58,#2F,#47,#36,#4B,#4F,#01
	DB	#A3,#74,#7E,#CF,#9E,#DC,#01
	DB	#55,#BD,#7E,#CF,#6E,#D5,#01
	DB	#64,#B8,#55,#BD,#7E,#CF,#01
	DB	#A3,#74,#64,#B8,#7E,#CF,#02
	DB	#4B,#4F,#A3,#74,#4A,#74,#01
	DB	#3A,#55,#4A,#74,#38,#79,#02
	DB	#4B,#4F,#3A,#55,#4A,#74,#02
	DB	#41,#9D,#64,#B8,#55,#BD,#02
	DB	#52,#98,#41,#9D,#64,#B8,#02
	DB	#58,#2F,#4B,#4F,#A3,#74,#02
	DB	#38,#79,#52,#98,#41,#9D,#01
	DB	#4A,#74,#38,#79,#52,#98,#01
	DB	#A3,#74,#52,#98,#64,#B8,#01
	DB	#A3,#74,#4A,#74,#52,#98,#82
; Taille 686 octets
