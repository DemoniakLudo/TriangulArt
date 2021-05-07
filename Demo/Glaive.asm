; Généré par TriangulArt le 07/05/2021 (10 27 40)
Glaive
; 4 octets de palette
	DB	"K@FN"
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
	DB	#80,#00,#7D,#01,#80,#0A,#01
	DB	#7D,#01,#79,#08,#80,#0A,#01
	DB	#79,#08,#80,#0A,#76,#11,#01
	DB	#80,#0A,#76,#11,#80,#1A,#01
	DB	#76,#11,#74,#1A,#80,#1A,#01
	DB	#74,#1A,#80,#1A,#80,#83,#01
	DB	#74,#1A,#74,#82,#80,#83,#01
	DB	#75,#82,#80,#83,#75,#BA,#01
	DB	#80,#83,#75,#BA,#80,#C2,#01
	DB	#75,#BA,#80,#C2,#72,#CC,#02
	DB	#75,#BA,#69,#CC,#72,#CC,#02
	DB	#6E,#C3,#67,#C9,#69,#CC,#02
	DB	#6F,#B7,#74,#B9,#6E,#C3,#02
	DB	#68,#AF,#6F,#B7,#6E,#C3,#02
	DB	#68,#AF,#5F,#AF,#6E,#C3,#02
	DB	#5F,#AF,#6E,#C3,#67,#C9,#02
	DB	#6E,#C3,#67,#C9,#69,#CC,#02
	DB	#80,#C2,#75,#CA,#77,#CD,#02
	DB	#80,#C2,#80,#CD,#77,#CD,#02
	DB	#77,#CD,#80,#CD,#77,#EF,#03
	DB	#80,#CD,#77,#EF,#80,#F0,#03
	DB	#77,#EF,#80,#F0,#79,#F5,#03
	DB	#80,#F0,#79,#F5,#80,#F9,#03
	DB	#79,#F5,#80,#F9,#78,#FE,#03
	DB	#80,#F9,#78,#FE,#80,#FF,#83
; Taille 175 octets
