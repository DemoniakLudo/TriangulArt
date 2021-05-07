; Généré par TriangulArt le 07/05/2021 (10 26 31)
ChessBoard
; 4 octets de palette
	DB	"@KT["
	DB	#03			; Tps d'affichage ?
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
	DB	#F9,#4F,#3B,#50,#EB,#9E,#02
	DB	#3B,#50,#00,#9B,#EB,#9E,#02
	DB	#3B,#50,#52,#50,#4D,#58,#01
	DB	#3B,#50,#4D,#58,#35,#58,#01
	DB	#68,#50,#80,#50,#7C,#58,#01
	DB	#68,#50,#7C,#58,#64,#58,#01
	DB	#98,#50,#AF,#50,#AC,#58,#01
	DB	#98,#50,#AC,#58,#94,#58,#01
	DB	#C7,#50,#E1,#50,#DD,#58,#01
	DB	#4D,#58,#64,#58,#5E,#61,#01
	DB	#C7,#50,#DE,#58,#C5,#58,#01
	DB	#4D,#58,#5E,#61,#46,#61,#01
	DB	#7C,#58,#94,#58,#90,#61,#01
	DB	#7C,#58,#90,#61,#77,#61,#01
	DB	#AC,#58,#C5,#58,#C2,#61,#01
	DB	#2F,#61,#46,#61,#40,#69,#01
	DB	#AC,#58,#C2,#61,#A9,#61,#01
	DB	#2F,#61,#40,#69,#28,#69,#01
	DB	#DE,#58,#F7,#58,#F5,#5F,#01
	DB	#5E,#61,#77,#61,#72,#69,#01
	DB	#DE,#58,#F5,#5F,#DB,#5F,#01
	DB	#5E,#61,#72,#69,#59,#69,#01
	DB	#90,#61,#A9,#61,#A5,#69,#01
	DB	#90,#61,#A5,#69,#8C,#69,#01
	DB	#DC,#5F,#C2,#61,#DA,#69,#01
	DB	#40,#69,#59,#69,#54,#72,#01
	DB	#C2,#61,#DA,#69,#C0,#69,#01
	DB	#40,#69,#54,#72,#3A,#72,#01
	DB	#72,#69,#8C,#69,#87,#72,#01
	DB	#72,#69,#87,#72,#6D,#72,#01
	DB	#A5,#69,#C0,#69,#BC,#72,#01
	DB	#21,#72,#3A,#72,#34,#7B,#01
	DB	#A5,#69,#BC,#72,#A2,#72,#01
	DB	#21,#72,#34,#7B,#19,#7B,#01
	DB	#DA,#69,#F5,#69,#F3,#72,#01
	DB	#54,#72,#6D,#72,#68,#7B,#01
	DB	#DA,#69,#F3,#72,#D7,#72,#01
	DB	#54,#72,#68,#7B,#4E,#7B,#01
	DB	#87,#72,#A2,#72,#9E,#7C,#01
	DB	#87,#72,#82,#7B,#9E,#7C,#01
	DB	#BC,#72,#D7,#72,#D5,#7C,#01
	DB	#34,#7B,#4E,#7B,#48,#85,#01
	DB	#BC,#72,#D5,#7C,#B9,#7C,#01
	DB	#34,#7B,#48,#85,#2C,#85,#01
	DB	#68,#7B,#82,#7B,#7D,#86,#01
	DB	#68,#7B,#7D,#86,#62,#86,#01
	DB	#9E,#7C,#B9,#7C,#B6,#86,#01
	DB	#12,#85,#2C,#85,#25,#90,#01
	DB	#9E,#7C,#B6,#86,#9A,#86,#01
	DB	#12,#85,#25,#90,#09,#90,#01
	DB	#D5,#7C,#F1,#7C,#EF,#86,#01
	DB	#48,#85,#62,#86,#5D,#90,#01
	DB	#D5,#7C,#EF,#86,#D2,#86,#01
	DB	#48,#85,#5D,#90,#40,#90,#01
	DB	#7D,#86,#9A,#86,#95,#91,#01
	DB	#7D,#86,#78,#90,#95,#91,#01
	DB	#B6,#86,#D2,#86,#D0,#91,#01
	DB	#25,#90,#40,#90,#39,#9C,#01
	DB	#B6,#86,#D0,#91,#B3,#91,#01
	DB	#25,#90,#39,#9C,#1D,#9C,#01
	DB	#5D,#90,#78,#90,#73,#9D,#01
	DB	#5D,#90,#57,#9C,#73,#9D,#01
	DB	#95,#91,#B3,#91,#AF,#9E,#01
	DB	#95,#91,#91,#9D,#AF,#9E,#01
	DB	#D0,#91,#EE,#91,#EB,#9E,#01
	DB	#D0,#91,#CD,#9D,#EB,#9E,#81
; Taille 462 octets
