; Généré par TriangulArt le 07/05/2021 (10 26 24)
Cerf
; 4 octets de palette
	DB	"V\NT"
	DB	#0A			; Tps d'affichage ?
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
	DB	#33,#00,#2D,#22,#37,#29,#01
	DB	#2D,#22,#37,#29,#1A,#30,#01
	DB	#37,#29,#1A,#30,#21,#38,#01
	DB	#19,#02,#1A,#2F,#10,#36,#01
	DB	#1A,#2F,#10,#36,#35,#62,#01
	DB	#1A,#2F,#3B,#55,#35,#62,#01
	DB	#64,#39,#3B,#55,#49,#5A,#01
	DB	#3B,#55,#35,#62,#5F,#71,#01
	DB	#3B,#55,#6F,#66,#5F,#71,#01
	DB	#6F,#66,#5F,#71,#63,#7E,#01
	DB	#6F,#66,#7B,#78,#63,#7E,#01
	DB	#80,#76,#59,#80,#62,#F2,#02
	DB	#80,#76,#62,#F2,#80,#FF,#02
	DB	#5D,#AC,#56,#C9,#61,#D8,#02
	DB	#5B,#98,#3B,#A3,#5D,#AC,#02
	DB	#44,#86,#5B,#98,#3B,#A3,#02
	DB	#21,#85,#44,#86,#3B,#A3,#02
	DB	#1C,#6F,#21,#85,#44,#86,#02
	DB	#1C,#6F,#4B,#81,#44,#86,#03
	DB	#4B,#81,#44,#86,#5B,#98,#03
	DB	#1C,#6F,#4D,#72,#4B,#81,#02
	DB	#4D,#72,#62,#7F,#4B,#81,#02
	DB	#62,#7F,#4B,#81,#5B,#99,#02
	DB	#63,#9D,#6A,#A6,#66,#AA,#83
; Taille 168 octets
