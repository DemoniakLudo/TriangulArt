; Généré par TriangulArt le 07/05/2021 (10 28 46)
Piece
; 4 octets de palette
	DB	"@TDL"
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
	DB	#80,#01,#71,#04,#80,#2C,#01
	DB	#71,#04,#63,#0E,#80,#2C,#01
	DB	#63,#0E,#5A,#1A,#80,#2C,#01
	DB	#5A,#1A,#56,#2B,#80,#2C,#01
	DB	#80,#2C,#5A,#3B,#63,#48,#01
	DB	#56,#2B,#80,#2C,#5A,#3B,#01
	DB	#80,#2C,#63,#48,#69,#4E,#01
	DB	#80,#2C,#69,#4E,#80,#5C,#01
	DB	#69,#4E,#4F,#5C,#80,#5C,#01
	DB	#4F,#5C,#80,#5C,#6B,#66,#01
	DB	#80,#5C,#6B,#66,#64,#A4,#01
	DB	#80,#5C,#57,#C2,#80,#FF,#01
	DB	#5F,#AF,#56,#B6,#58,#C2,#01
	DB	#57,#C2,#3B,#EC,#80,#FF,#01
	DB	#3B,#EC,#3F,#FD,#80,#FF,#01
	DB	#57,#C2,#3C,#DF,#40,#E7,#01
	DB	#3B,#E8,#80,#EB,#80,#EE,#02
	DB	#57,#C3,#7E,#C6,#80,#C8,#02
	DB	#6A,#4E,#80,#50,#80,#53,#02
	DB	#6B,#65,#80,#67,#80,#69,#82
; Taille 140 octets
