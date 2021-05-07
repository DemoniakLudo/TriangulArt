; Généré par TriangulArt le 07/05/2021 (15 16 39)
Triangulart
; 4 octets de palette
	DB	"XCSL"
	DB	#16			; Tps d'affichage
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
	DB	#0B,#4D,#29,#4D,#06,#57,#01
	DB	#29,#4D,#24,#57,#06,#57,#01
	DB	#10,#57,#1A,#57,#01,#75,#01
	DB	#1A,#57,#0B,#75,#01,#75,#01
	DB	#1C,#61,#12,#75,#17,#75,#01
	DB	#1C,#61,#21,#61,#17,#75,#01
	DB	#21,#61,#2E,#61,#1E,#66,#01
	DB	#2E,#61,#2B,#66,#1B,#66,#01
	DB	#33,#61,#29,#75,#2E,#75,#01
	DB	#33,#61,#38,#61,#2E,#75,#01
	DB	#38,#57,#3D,#57,#35,#5C,#01
	DB	#3D,#57,#3A,#5C,#35,#5C,#01
	DB	#3D,#61,#35,#70,#3A,#70,#01
	DB	#3D,#61,#3F,#66,#3A,#70,#01
	DB	#3D,#61,#47,#61,#3F,#66,#01
	DB	#47,#61,#49,#66,#3F,#66,#01
	DB	#44,#66,#49,#66,#44,#70,#01
	DB	#49,#66,#44,#70,#49,#70,#01
	DB	#4C,#61,#49,#66,#49,#70,#01
	DB	#4C,#61,#51,#61,#49,#70,#01
	DB	#35,#70,#4E,#70,#38,#75,#01
	DB	#4E,#70,#4C,#75,#38,#75,#01
	DB	#5B,#61,#51,#75,#56,#75,#01
	DB	#5B,#61,#60,#61,#56,#75,#01
	DB	#60,#61,#5D,#66,#67,#66,#01
	DB	#60,#61,#6A,#61,#67,#66,#01
	DB	#6A,#61,#6C,#66,#67,#66,#01
	DB	#6C,#66,#67,#66,#60,#75,#01
	DB	#6C,#66,#65,#75,#60,#75,#01
	DB	#7B,#70,#79,#75,#6F,#75,#01
	DB	#7B,#70,#71,#70,#6F,#75,#01
	DB	#74,#61,#6C,#70,#6F,#75,#01
	DB	#74,#61,#76,#66,#6F,#75,#01
	DB	#74,#61,#76,#66,#85,#66,#01
	DB	#74,#61,#83,#61,#85,#66,#01
	DB	#80,#66,#85,#66,#76,#7A,#01
	DB	#85,#66,#7B,#7A,#76,#7A,#01
	DB	#71,#7A,#7B,#7A,#6F,#7F,#01
	DB	#7B,#7A,#79,#7F,#6F,#7F,#01
	DB	#8D,#61,#92,#61,#85,#70,#01
	DB	#92,#61,#8A,#70,#85,#70,#01
	DB	#85,#70,#94,#70,#88,#75,#01
	DB	#94,#70,#92,#75,#88,#75,#01
	DB	#9C,#61,#97,#75,#92,#75,#01
	DB	#9C,#61,#A1,#61,#97,#75,#01
	DB	#AB,#57,#9E,#70,#A3,#70,#01
	DB	#AB,#57,#B0,#57,#A3,#70,#01
	DB	#9E,#70,#A8,#70,#9C,#75,#01
	DB	#A8,#70,#A6,#75,#9C,#75,#01
	DB	#B5,#57,#B0,#61,#B5,#61,#01
	DB	#B5,#57,#BA,#57,#B5,#61,#01
	DB	#C9,#4D,#AB,#75,#C9,#75,#01
	DB	#C9,#4D,#D3,#4D,#C9,#75,#01
	DB	#C7,#5C,#C1,#75,#B5,#75,#00
	DB	#D8,#61,#CE,#75,#D3,#75,#01
	DB	#D8,#61,#DD,#61,#D3,#75,#01
	DB	#DD,#61,#E9,#61,#DA,#66,#01
	DB	#E9,#61,#E7,#66,#DA,#66,#01
	DB	#F6,#57,#FB,#57,#F9,#5C,#01
	DB	#F6,#57,#F4,#5C,#F9,#5C,#01
	DB	#EF,#5C,#FE,#5C,#EC,#61,#01
	DB	#FE,#5C,#FB,#61,#EC,#61,#01
	DB	#F1,#61,#F6,#61,#EA,#70,#01
	DB	#F6,#61,#EF,#70,#EA,#70,#01
	DB	#EA,#70,#F4,#70,#EC,#75,#01
	DB	#F4,#70,#F1,#75,#EC,#75,#81
; Taille 462 octets
