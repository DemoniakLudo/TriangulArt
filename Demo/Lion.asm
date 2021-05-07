; Généré par TriangulArt le 07/05/2021 (10 28 20)
Lion
; 4 octets de palette
	DB	"TJLK"
	DW	#0100			; Tps d'affichage ?
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
	DB	#48,#16,#3A,#21,#4A,#24,#01
	DB	#3A,#21,#4A,#24,#2C,#27,#01
	DB	#6C,#47,#5E,#4A,#65,#5D,#01
	DB	#6C,#47,#76,#5C,#65,#5D,#01
	DB	#76,#5C,#6C,#5D,#6D,#6B,#01
	DB	#61,#53,#65,#5B,#52,#6F,#01
	DB	#56,#71,#52,#76,#57,#78,#01
	DB	#52,#76,#5A,#79,#5C,#87,#01
	DB	#62,#75,#6D,#77,#69,#88,#01
	DB	#7B,#67,#6D,#72,#75,#83,#01
	DB	#76,#81,#6C,#8E,#6F,#9F,#01
	DB	#7B,#67,#80,#82,#6F,#9F,#01
	DB	#80,#82,#80,#9D,#6F,#9F,#01
	DB	#6D,#91,#66,#97,#6F,#9D,#01
	DB	#5E,#8D,#66,#97,#5A,#98,#01
	DB	#66,#97,#5A,#98,#60,#A8,#01
	DB	#66,#97,#69,#A4,#60,#A8,#01
	DB	#69,#A4,#60,#A8,#5D,#B7,#01
	DB	#69,#A4,#5D,#B7,#70,#BF,#01
	DB	#69,#A4,#80,#AC,#70,#BF,#01
	DB	#80,#C2,#67,#C6,#6E,#D8,#01
	DB	#80,#C2,#80,#D6,#6E,#D8,#01
	DB	#62,#D9,#56,#DF,#5D,#E6,#01
	DB	#56,#DF,#5D,#E6,#52,#EC,#01
	DB	#5B,#EC,#58,#F1,#5A,#F5,#01
	DB	#58,#F1,#5A,#F5,#50,#F6,#01
	DB	#45,#D8,#39,#E1,#42,#E5,#01
	DB	#39,#E1,#42,#E5,#39,#EF,#01
	DB	#2F,#CB,#36,#D1,#30,#D8,#01
	DB	#2C,#CB,#1F,#D1,#28,#D5,#01
	DB	#2B,#BF,#31,#C8,#21,#D0,#01
	DB	#27,#B8,#2A,#BE,#21,#CA,#01
	DB	#49,#9F,#26,#B6,#31,#C9,#01
	DB	#20,#A4,#40,#A5,#1C,#BD,#01
	DB	#3D,#8E,#1F,#A4,#3D,#A5,#01
	DB	#3A,#88,#2D,#8B,#11,#B2,#01
	DB	#2D,#8B,#13,#9C,#11,#B2,#01
	DB	#07,#77,#2D,#8A,#00,#AA,#01
	DB	#06,#7D,#00,#84,#00,#AA,#01
	DB	#30,#71,#06,#76,#2D,#8A,#01
	DB	#3A,#65,#30,#71,#06,#76,#01
	DB	#3A,#65,#20,#65,#06,#74,#01
	DB	#26,#50,#31,#5B,#06,#74,#01
	DB	#1F,#42,#27,#51,#20,#53,#01
	DB	#80,#08,#71,#0B,#72,#14,#02
	DB	#71,#0B,#5C,#1D,#74,#2C,#02
	DB	#68,#08,#6D,#0E,#5C,#1D,#02
	DB	#60,#08,#65,#0D,#62,#13,#02
	DB	#56,#0C,#62,#13,#5D,#1C,#02
	DB	#4F,#0B,#50,#18,#5A,#1D,#02
	DB	#4A,#16,#5C,#1D,#4C,#26,#02
	DB	#5C,#1D,#4C,#26,#73,#2C,#02
	DB	#4B,#26,#6A,#2A,#6A,#32,#02
	DB	#4B,#26,#6A,#32,#5C,#36,#02
	DB	#45,#23,#2E,#29,#57,#3E,#02
	DB	#45,#23,#5E,#3D,#56,#3F,#02
	DB	#2E,#29,#57,#3E,#3F,#59,#02
	DB	#25,#28,#2E,#29,#3F,#59,#02
	DB	#25,#28,#1E,#3B,#28,#3E,#02
	DB	#1E,#3B,#28,#3E,#23,#4E,#02
	DB	#2C,#34,#23,#4E,#40,#58,#02
	DB	#34,#54,#47,#5C,#2C,#63,#02
	DB	#47,#5C,#3A,#60,#36,#6D,#02
	DB	#22,#6C,#14,#74,#1B,#77,#02
	DB	#35,#6D,#4D,#85,#2E,#89,#02
	DB	#56,#6D,#69,#83,#50,#86,#02
	DB	#70,#83,#3B,#88,#3E,#A4,#02
	DB	#6B,#72,#73,#7D,#6A,#89,#02
	DB	#60,#60,#64,#64,#55,#6C,#02
	DB	#6D,#5D,#60,#60,#6B,#6A,#02
	DB	#78,#5D,#6E,#68,#75,#70,#02
	DB	#79,#5E,#80,#67,#80,#75,#02
	DB	#6D,#46,#7C,#47,#78,#5E,#02
	DB	#79,#43,#5D,#45,#80,#47,#02
	DB	#7C,#36,#80,#3A,#78,#42,#02
	DB	#75,#94,#80,#97,#80,#9C,#02
	DB	#16,#95,#00,#AB,#0E,#B2,#02
	DB	#00,#AB,#07,#AF,#00,#B1,#02
	DB	#1F,#A3,#0E,#B2,#19,#BA,#02
	DB	#0E,#B2,#0E,#BA,#19,#BA,#02
	DB	#28,#B7,#19,#BB,#20,#D0,#02
	DB	#51,#9D,#43,#A8,#4B,#B5,#02
	DB	#43,#A8,#4B,#B5,#3C,#B9,#02
	DB	#3C,#B9,#32,#CC,#3E,#D3,#02
	DB	#5E,#BB,#41,#CD,#4C,#D8,#02
	DB	#41,#CD,#41,#D8,#4C,#D8,#02
	DB	#51,#D1,#45,#E5,#4D,#F0,#02
	DB	#51,#D1,#68,#D1,#4D,#F0,#02
	DB	#68,#D1,#6E,#D7,#4D,#F0,#02
	DB	#74,#E0,#71,#E3,#77,#E6,#02
	DB	#7A,#E1,#80,#E1,#80,#EB,#02
	DB	#64,#6B,#62,#6C,#66,#6E,#02
	DB	#66,#6B,#68,#6C,#64,#6E,#02
	DB	#6D,#6C,#70,#70,#6C,#71,#03
	DB	#5D,#6D,#5C,#71,#5F,#73,#03
	DB	#5E,#6E,#61,#75,#69,#76,#03
	DB	#69,#9A,#6B,#A0,#69,#A1,#03
	DB	#76,#A8,#6F,#AB,#76,#AE,#03
	DB	#76,#AE,#69,#B0,#75,#B3,#03
	DB	#7E,#B0,#67,#B7,#74,#BF,#03
	DB	#7E,#B0,#80,#B5,#74,#BF,#03
	DB	#75,#C3,#69,#C6,#69,#CF,#03
	DB	#75,#C3,#7E,#C6,#69,#CF,#03
	DB	#7E,#C6,#69,#CF,#73,#D4,#03
	DB	#7E,#C6,#80,#D3,#73,#D4,#83
; Taille 735 octets
