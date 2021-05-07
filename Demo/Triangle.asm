; Généré par TriangulArt le 07/05/2021 (10 29 25)
Triangle
; 4 octets de palette
	DB	"T\LN"
	DB	#12			; Tps d'affichage ?
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
	DB	#28,#00,#00,#14,#F0,#64,#01
	DB	#00,#14,#A0,#64,#F0,#64,#01
	DB	#00,#14,#A0,#64,#78,#78,#02
	DB	#00,#14,#28,#50,#78,#78,#02
	DB	#00,#14,#00,#DC,#28,#F0,#02
	DB	#00,#14,#28,#50,#28,#F0,#02
	DB	#28,#50,#50,#64,#28,#F0,#03
	DB	#50,#64,#50,#B4,#28,#F0,#03
	DB	#F0,#64,#50,#B4,#28,#F0,#03
	DB	#F0,#64,#F0,#8C,#28,#F0,#03
	DB	#A0,#64,#F0,#64,#50,#8C,#01
	DB	#F0,#64,#50,#8C,#50,#B4,#81
; Taille 84 octets
