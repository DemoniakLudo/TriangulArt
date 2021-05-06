; 4 octets de palette
	DB	"KTSL"
	DW	#0A00			; Tps d'affichage ?
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
	DB	#04,#57,#58,#57,#18,#62,#01
	DB	#58,#57,#18,#62,#23,#6C,#01
	DB	#58,#57,#23,#6C,#29,#76,#01
	DB	#58,#57,#29,#76,#28,#88,#01
	DB	#58,#57,#28,#88,#49,#89,#01
	DB	#58,#57,#49,#89,#58,#8B,#01
	DB	#58,#57,#58,#8B,#6D,#94,#01
	DB	#58,#57,#67,#69,#6D,#94,#01
	DB	#67,#69,#80,#6A,#6D,#94,#01
	DB	#80,#6A,#6D,#94,#76,#9B,#01
	DB	#80,#6A,#76,#9B,#80,#AF,#01
	DB	#7C,#56,#77,#6A,#80,#6A,#81
