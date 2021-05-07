; Généré par TriangulArt le 07/05/2021 (10 26 12)
Bidul
; 4 octets de palette
	DB	"CNL\"
	DW	#0400			; Tps d'affichage ?
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
	DB	#28,#68,#1D,#7B,#43,#A7,#02
	DB	#43,#A7,#6C,#D7,#5B,#E0,#01
	DB	#92,#2D,#E3,#44,#C0,#56,#03
	DB	#E3,#44,#C0,#56,#D4,#96,#03
	DB	#3D,#14,#92,#2D,#67,#3D,#03
	DB	#D4,#96,#AE,#AF,#C3,#EC,#03
	DB	#3D,#14,#67,#3D,#28,#68,#03
	DB	#AE,#AF,#6C,#D7,#C3,#EC,#03
	DB	#AA,#10,#C0,#56,#96,#6B,#02
	DB	#C0,#56,#96,#6B,#F3,#84,#01
	DB	#AA,#10,#67,#3D,#96,#6B,#01
	DB	#53,#97,#82,#CB,#6C,#D7,#02
	DB	#96,#6B,#F3,#84,#AE,#AF,#02
	DB	#67,#3D,#36,#51,#96,#6B,#02
	DB	#96,#6B,#AE,#AF,#82,#CB,#01
	DB	#36,#51,#96,#6B,#53,#97,#01
	DB	#96,#6B,#53,#97,#82,#CB,#02
	DB	#34,#37,#13,#C0,#6C,#D7,#83
; Taille 126 octets
