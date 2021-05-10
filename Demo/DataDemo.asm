; Généré par TriangulArt le 08/05/2021 (18 13 34)
Impact
; 4 octets de palette
	DB	"XMOC"
	DB	#04			; Tps d'affichage
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
	DB	#4E,#17,#03,#26,#03,#2F,#03
	DB	#4E,#14,#4E,#17,#03,#26,#03
	DB	#32,#20,#22,#25,#2A,#6D,#03
	DB	#22,#25,#2A,#6D,#25,#6F,#03
	DB	#54,#56,#56,#5C,#03,#79,#03
	DB	#56,#5C,#03,#79,#06,#AD,#03
	DB	#3C,#31,#44,#59,#39,#5D,#03
	DB	#4B,#1E,#3C,#31,#44,#59,#03
	DB	#69,#07,#5C,#10,#5C,#30,#03
	DB	#69,#07,#5C,#30,#60,#86,#03
	DB	#6E,#14,#74,#49,#6B,#4D,#03
	DB	#75,#0D,#6E,#14,#74,#49,#03
	DB	#96,#05,#75,#0D,#96,#12,#03
	DB	#75,#0D,#96,#12,#75,#1E,#03
	DB	#96,#12,#96,#26,#8E,#2B,#03
	DB	#96,#12,#8C,#14,#8E,#2B,#03
	DB	#8E,#23,#74,#2D,#74,#3B,#03
	DB	#8E,#23,#8E,#2B,#74,#3B,#03
	DB	#A9,#02,#92,#70,#84,#70,#03
	DB	#A9,#02,#A4,#04,#84,#70,#03
	DB	#9E,#34,#B8,#37,#9C,#3F,#03
	DB	#B7,#28,#9E,#34,#B8,#37,#03
	DB	#A8,#04,#B6,#06,#A7,#0B,#03
	DB	#B6,#01,#A8,#04,#A7,#0B,#03
	DB	#B0,#02,#B8,#89,#C6,#92,#03
	DB	#B5,#01,#B0,#02,#C6,#92,#03
	DB	#D2,#00,#B8,#02,#D6,#0A,#03
	DB	#B8,#02,#D6,#0A,#B9,#0D,#03
	DB	#B9,#0D,#C4,#65,#D3,#75,#03
	DB	#BD,#0B,#B9,#0D,#D3,#75,#03
	DB	#DE,#5B,#CE,#62,#E5,#6B,#03
	DB	#CE,#62,#E5,#6B,#D1,#74,#03
	DB	#FF,#00,#D8,#02,#FF,#0E,#03
	DB	#D8,#00,#FF,#0E,#C9,#24,#03
	DB	#E3,#19,#E0,#58,#F7,#8D,#03
	DB	#EE,#12,#E3,#19,#F7,#8D,#03
	DB	#4B,#1E,#48,#30,#52,#38,#03
	DB	#52,#1A,#4B,#1F,#52,#38,#03
	DB	#51,#1B,#5C,#24,#52,#36,#03
	DB	#5C,#0F,#51,#1B,#5C,#24,#03
	DB	#A7,#7F,#7D,#8F,#9A,#D3,#02
	DB	#7D,#8F,#9A,#D3,#8B,#DB,#02
	DB	#A3,#DA,#88,#E7,#AB,#F3,#02
	DB	#88,#E7,#AB,#F3,#88,#F8,#02
	DB	#AE,#6F,#A7,#7F,#7D,#90,#01
	DB	#AE,#6F,#83,#81,#7D,#90,#01
	DB	#AE,#6F,#9F,#D0,#9A,#D3,#01
	DB	#AE,#6F,#A7,#7F,#9A,#D3,#01
	DB	#A6,#D1,#8C,#DE,#88,#E7,#01
	DB	#A6,#D1,#A3,#DA,#88,#E7,#01
	DB	#A3,#DA,#AF,#EE,#AB,#F3,#01
	DB	#A6,#D1,#A3,#DA,#AF,#EE,#81
; Taille 364 octets
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
Triangle
; 4 octets de palette
	DB	"T\LN"
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
TriTriangle
; 4 octets de palette
	DB	"TNL\"
	DB	#07			; Tps d'affichage
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
	DB	#55,#00,#69,#00,#00,#AA,#01
	DB	#69,#00,#1E,#96,#00,#AA,#01
	DB	#1E,#96,#96,#AA,#00,#AA,#01
	DB	#1E,#96,#8C,#96,#96,#AA,#01
	DB	#91,#00,#5A,#96,#46,#96,#01
	DB	#91,#00,#A5,#00,#5A,#96,#01
	DB	#B4,#96,#C8,#96,#BE,#AA,#01
	DB	#C8,#96,#D2,#AA,#BE,#AA,#01
	DB	#32,#BE,#28,#D2,#3C,#D2,#01
	DB	#32,#BE,#46,#BE,#3C,#D2,#01
	DB	#28,#D2,#AA,#D2,#1E,#E6,#01
	DB	#AA,#D2,#B4,#E6,#1E,#E6,#01
	DB	#69,#28,#5F,#3C,#69,#50,#02
	DB	#69,#28,#73,#3C,#69,#50,#02
	DB	#A5,#28,#9B,#3C,#F0,#BE,#02
	DB	#9B,#3C,#D2,#AA,#F0,#BE,#02
	DB	#D2,#AA,#C8,#BE,#F0,#BE,#02
	DB	#D2,#AA,#BE,#AA,#C8,#BE,#02
	DB	#87,#64,#7D,#78,#D2,#FA,#02
	DB	#7D,#78,#B4,#E6,#D2,#FA,#02
	DB	#B4,#E6,#28,#FA,#D2,#FA,#02
	DB	#B4,#E6,#1E,#E6,#28,#FA,#02
	DB	#00,#AA,#0A,#BE,#A0,#BE,#02
	DB	#00,#AA,#96,#AA,#A0,#BE,#02
	DB	#69,#00,#69,#28,#32,#96,#03
	DB	#69,#00,#1E,#96,#32,#96,#03
	DB	#69,#00,#69,#28,#73,#3C,#03
	DB	#69,#00,#7D,#28,#73,#3C,#03
	DB	#A5,#00,#6E,#96,#5A,#96,#03
	DB	#A5,#00,#A5,#28,#6E,#96,#03
	DB	#A5,#00,#A5,#28,#F0,#BE,#03
	DB	#A5,#00,#FA,#AA,#F0,#BE,#03
	DB	#91,#50,#87,#64,#D2,#FA,#03
	DB	#91,#50,#DC,#E6,#D2,#FA,#03
	DB	#46,#BE,#5A,#BE,#3C,#D2,#03
	DB	#5A,#BE,#50,#D2,#3C,#D2,#83
; Taille 252 octets
Pyramide
; 4 octets de palette
	DB	"]C^N"
	DB	#0F			; Tps d'affichage
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
	DB	#C6,#9D,#2B,#A5,#2B,#B0,#01
	DB	#C6,#9D,#C6,#A7,#2B,#B0,#01
	DB	#85,#14,#D0,#99,#C7,#9C,#01
	DB	#91,#14,#85,#16,#D0,#99,#01
	DB	#91,#0D,#91,#14,#85,#16,#02
	DB	#91,#0D,#91,#14,#D0,#99,#02
	DB	#91,#14,#D1,#96,#D0,#99,#02
	DB	#79,#17,#1B,#A2,#26,#A8,#01
	DB	#CB,#A0,#B8,#DA,#AF,#DB,#01
	DB	#79,#17,#82,#1D,#26,#A8,#01
	DB	#D1,#A0,#CB,#A0,#B8,#DA,#01
	DB	#B8,#DA,#AF,#DB,#AF,#E7,#01
	DB	#B8,#DA,#B9,#E7,#AF,#E7,#01
	DB	#D1,#9F,#B8,#DA,#B9,#E7,#02
	DB	#D1,#9F,#D1,#A7,#B9,#E7,#02
	DB	#27,#AA,#1F,#AE,#A7,#E4,#01
	DB	#1F,#AE,#A7,#E4,#A1,#E9,#01
	DB	#A7,#E4,#A1,#E9,#A1,#F4,#01
	DB	#A7,#E4,#A7,#EE,#A1,#F4,#01
	DB	#1F,#AE,#A1,#E9,#A1,#F4,#02
	DB	#1F,#AE,#1F,#B8,#A1,#F4,#02
	DB	#90,#14,#83,#16,#A6,#E1,#01
	DB	#90,#14,#B2,#DF,#A6,#E1,#01
	DB	#90,#14,#B4,#D1,#B2,#DF,#02
	DB	#90,#14,#94,#1A,#B4,#D1,#82
; Taille 175 octets
Pyramides
; 4 octets de palette
	DB	"KJLN"
	DB	#0F			; Tps d'affichage
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
	DB	#CF,#5A,#98,#AC,#E7,#C3,#03
	DB	#CF,#5A,#FE,#9A,#E7,#C3,#01
	DB	#3A,#73,#01,#C4,#52,#DC,#03
	DB	#3A,#73,#69,#B2,#52,#DC,#01
	DB	#55,#6C,#A5,#85,#6B,#D4,#03
	DB	#A5,#85,#D3,#C2,#6B,#D4,#01
	DB	#BD,#5B,#A5,#85,#D3,#C2,#01
	DB	#BD,#5B,#54,#6C,#A5,#85,#02
	DB	#A5,#85,#A6,#85,#D3,#C2,#03
	DB	#8C,#00,#53,#51,#A5,#69,#03
	DB	#8C,#00,#BB,#40,#A5,#69,#01
	DB	#AE,#97,#75,#E6,#C6,#FF,#03
	DB	#AE,#97,#DD,#D5,#C6,#FF,#01
	DB	#AE,#97,#DD,#D5,#DE,#D5,#03
	DB	#AE,#97,#AE,#98,#DD,#D5,#83
; Taille 105 octets
Tricubes
; 4 octets de palette
	DB	"@SUD"
	DB	#06			; Tps d'affichage
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
	DB	#C4,#69,#9E,#69,#89,#8B,#03
	DB	#C4,#69,#89,#8B,#B1,#8B,#03
	DB	#A6,#78,#91,#9B,#A6,#BD,#01
	DB	#A6,#78,#BB,#9B,#A6,#BD,#01
	DB	#A6,#78,#BB,#9B,#E1,#9B,#02
	DB	#A6,#78,#CE,#78,#E1,#9B,#02
	DB	#E1,#9B,#BB,#9B,#A6,#BD,#03
	DB	#E1,#9B,#A6,#BD,#CE,#BD,#03
	DB	#C3,#AA,#AE,#CD,#C3,#EF,#01
	DB	#C3,#AA,#D8,#CD,#C3,#EF,#01
	DB	#C3,#AA,#D8,#CD,#FE,#CD,#02
	DB	#C3,#AA,#EB,#AA,#FE,#CD,#02
	DB	#FE,#CD,#D8,#CD,#C3,#EF,#03
	DB	#FE,#CD,#C3,#EF,#EB,#EF,#03
	DB	#89,#AA,#74,#CD,#89,#EF,#01
	DB	#89,#AA,#9E,#CD,#89,#EF,#01
	DB	#89,#AA,#9E,#CD,#C4,#CD,#02
	DB	#89,#AA,#B1,#AA,#C4,#CD,#02
	DB	#C4,#CD,#9E,#CD,#89,#EF,#03
	DB	#C4,#CD,#89,#EF,#B1,#EF,#03
	DB	#4F,#AA,#3A,#CD,#4F,#EF,#01
	DB	#4F,#AA,#64,#CD,#4F,#EF,#01
	DB	#4F,#AA,#64,#CD,#8A,#CD,#02
	DB	#4F,#AA,#77,#AA,#8A,#CD,#02
	DB	#8A,#CD,#64,#CD,#4F,#EF,#03
	DB	#8A,#CD,#4F,#EF,#77,#EF,#03
	DB	#15,#AA,#00,#CD,#15,#EF,#01
	DB	#15,#AA,#2A,#CD,#15,#EF,#01
	DB	#15,#AA,#2A,#CD,#50,#CD,#02
	DB	#15,#AA,#3D,#AA,#50,#CD,#02
	DB	#50,#CD,#2A,#CD,#15,#EF,#03
	DB	#50,#CD,#15,#EF,#3D,#EF,#03
	DB	#32,#78,#1D,#9B,#32,#BD,#01
	DB	#32,#78,#47,#9B,#32,#BD,#01
	DB	#32,#78,#47,#9B,#6D,#9B,#02
	DB	#32,#78,#5A,#78,#6D,#9B,#02
	DB	#6D,#9B,#47,#9B,#32,#BD,#03
	DB	#6D,#9B,#32,#BD,#5A,#BD,#03
	DB	#4F,#46,#3A,#69,#4F,#8B,#01
	DB	#4F,#46,#64,#69,#4F,#8B,#01
	DB	#4F,#46,#64,#69,#8A,#69,#02
	DB	#4F,#46,#77,#46,#8A,#69,#02
	DB	#8A,#69,#64,#69,#4F,#8B,#03
	DB	#8A,#69,#4F,#8B,#77,#8B,#03
	DB	#6C,#14,#57,#37,#6C,#59,#01
	DB	#6C,#14,#81,#37,#6C,#59,#01
	DB	#6C,#14,#81,#37,#A7,#37,#02
	DB	#6C,#14,#94,#14,#A7,#37,#02
	DB	#A7,#37,#81,#37,#6C,#59,#03
	DB	#A7,#37,#6C,#59,#94,#59,#03
	DB	#89,#46,#9E,#69,#89,#8B,#01
	DB	#89,#46,#74,#69,#89,#8B,#01
	DB	#89,#46,#9E,#69,#C4,#69,#02
	DB	#89,#46,#B1,#46,#C4,#69,#82
; Taille 378 octets
Tricube
; 4 octets de palette
	DB	"KVNT"
	DB	#01			; Tps d'affichage
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
	DB	#B9,#1E,#B9,#36,#A0,#43,#02
	DB	#80,#00,#80,#19,#46,#1E,#01
	DB	#80,#19,#46,#1E,#61,#2A,#01
	DB	#80,#00,#80,#19,#B9,#1E,#01
	DB	#80,#19,#B9,#1E,#A0,#2A,#01
	DB	#46,#1E,#46,#34,#61,#43,#03
	DB	#47,#83,#47,#9B,#61,#AA,#03
	DB	#3B,#24,#54,#30,#01,#41,#01
	DB	#54,#30,#34,#41,#01,#41,#01
	DB	#53,#96,#34,#A6,#34,#C0,#02
	DB	#34,#87,#1A,#94,#1A,#CC,#02
	DB	#C5,#23,#AD,#30,#FF,#41,#01
	DB	#34,#87,#34,#C0,#1A,#CC,#02
	DB	#AD,#30,#CC,#40,#FF,#41,#01
	DB	#53,#96,#53,#AF,#34,#C0,#02
	DB	#AD,#50,#AD,#6A,#C5,#77,#03
	DB	#CC,#3F,#FE,#41,#AD,#50,#01
	DB	#FE,#41,#AD,#50,#C5,#5C,#01
	DB	#A0,#56,#B9,#63,#47,#83,#01
	DB	#B9,#63,#47,#83,#61,#90,#01
	DB	#3A,#89,#34,#8D,#34,#A6,#01
	DB	#3A,#89,#53,#96,#34,#A6,#01
	DB	#53,#B6,#3B,#C3,#3B,#DC,#02
	DB	#53,#B6,#53,#CF,#3B,#DC,#02
	DB	#34,#A6,#1A,#B3,#53,#B6,#01
	DB	#1A,#B3,#53,#B6,#3B,#C3,#01
	DB	#61,#BC,#47,#C9,#66,#D9,#01
	DB	#AD,#B6,#AD,#D0,#C6,#DD,#03
	DB	#61,#BC,#66,#BF,#66,#D9,#01
	DB	#A0,#BB,#99,#C0,#B9,#C9,#01
	DB	#99,#C0,#B9,#C9,#99,#D9,#01
	DB	#E5,#B3,#AD,#B6,#C6,#C3,#01
	DB	#CC,#A6,#E5,#B3,#AD,#B6,#01
	DB	#C6,#89,#CC,#8D,#CC,#A6,#01
	DB	#80,#46,#66,#53,#80,#60,#01
	DB	#80,#46,#99,#53,#80,#60,#01
	DB	#1A,#7A,#01,#87,#1A,#94,#01
	DB	#1A,#7A,#34,#87,#1A,#94,#01
	DB	#80,#AB,#66,#B8,#80,#C5,#01
	DB	#80,#AB,#99,#B8,#80,#C5,#01
	DB	#E5,#7A,#CC,#87,#E5,#94,#01
	DB	#E5,#7A,#FE,#87,#E5,#94,#01
	DB	#80,#19,#61,#2A,#61,#43,#02
	DB	#80,#19,#80,#33,#61,#43,#02
	DB	#B9,#1E,#A0,#2A,#A0,#43,#02
	DB	#99,#26,#80,#33,#80,#54,#02
	DB	#99,#26,#99,#46,#80,#54,#02
	DB	#B9,#63,#B9,#7D,#61,#AA,#02
	DB	#B9,#83,#A0,#90,#A0,#AA,#02
	DB	#B9,#83,#B9,#9E,#A0,#AA,#02
	DB	#C6,#89,#AD,#96,#CC,#A6,#01
	DB	#B9,#63,#61,#90,#61,#AA,#02
	DB	#99,#8D,#80,#9A,#80,#B9,#02
	DB	#34,#41,#34,#7A,#1A,#86,#02
	DB	#99,#8D,#99,#AD,#80,#B9,#02
	DB	#52,#50,#52,#6A,#3B,#77,#02
	DB	#46,#64,#B9,#83,#A0,#90,#01
	DB	#61,#57,#46,#64,#B9,#83,#01
	DB	#99,#53,#80,#60,#80,#80,#02
	DB	#34,#41,#1A,#4E,#1A,#86,#02
	DB	#99,#53,#99,#73,#80,#80,#02
	DB	#54,#30,#54,#4A,#34,#58,#02
	DB	#54,#30,#34,#41,#34,#58,#02
	DB	#01,#41,#52,#50,#3B,#5E,#01
	DB	#34,#41,#01,#41,#52,#50,#01
	DB	#52,#50,#3B,#5D,#3B,#77,#02
	DB	#99,#B8,#80,#C5,#80,#FF,#02
	DB	#99,#B8,#99,#F3,#80,#FF,#02
	DB	#B9,#C9,#99,#D9,#99,#F3,#02
	DB	#B9,#C9,#B9,#E2,#99,#F3,#02
	DB	#FE,#87,#E5,#94,#FE,#BE,#02
	DB	#E5,#94,#FE,#BE,#E5,#CC,#02
	DB	#E5,#B3,#C6,#C3,#C6,#DD,#02
	DB	#E5,#B3,#E5,#CC,#C6,#DD,#02
	DB	#E5,#4C,#C5,#5C,#C5,#77,#02
	DB	#FE,#40,#FE,#79,#E5,#87,#02
	DB	#FE,#40,#E5,#4C,#E5,#87,#02
	DB	#E5,#4C,#E5,#66,#C5,#77,#02
	DB	#80,#19,#A0,#2A,#80,#33,#03
	DB	#A0,#2A,#80,#33,#A0,#43,#03
	DB	#AD,#30,#CC,#40,#AD,#4A,#03
	DB	#CC,#40,#AD,#4A,#B3,#4D,#03
	DB	#01,#41,#3B,#5E,#3B,#78,#03
	DB	#01,#41,#1A,#4E,#1A,#86,#03
	DB	#01,#41,#01,#79,#1A,#86,#03
	DB	#01,#41,#01,#5C,#3B,#78,#03
	DB	#66,#53,#80,#60,#66,#74,#03
	DB	#80,#60,#66,#74,#80,#80,#03
	DB	#80,#80,#80,#9A,#A0,#AA,#03
	DB	#80,#80,#A0,#90,#A0,#AA,#03
	DB	#46,#64,#68,#74,#46,#7C,#03
	DB	#66,#74,#46,#7C,#4D,#80,#03
	DB	#47,#83,#61,#90,#61,#AA,#03
	DB	#80,#9A,#66,#AC,#80,#B9,#03
	DB	#80,#9A,#66,#A7,#66,#AC,#03
	DB	#80,#33,#66,#47,#80,#54,#03
	DB	#80,#33,#66,#40,#66,#47,#03
	DB	#E5,#66,#CC,#79,#E5,#86,#03
	DB	#E5,#66,#CC,#73,#CC,#79,#03
	DB	#46,#1E,#61,#2A,#61,#43,#03
	DB	#AD,#50,#C5,#5C,#C5,#77,#03
	DB	#AD,#96,#CC,#A6,#AD,#AF,#03
	DB	#CC,#A6,#AD,#AF,#B3,#B3,#03
	DB	#AD,#B6,#C6,#C3,#C6,#DD,#03
	DB	#CC,#87,#E5,#94,#E5,#B3,#03
	DB	#CC,#87,#CC,#A6,#E5,#B3,#03
	DB	#66,#B8,#80,#C5,#80,#FF,#03
	DB	#66,#B8,#66,#F2,#80,#FF,#03
	DB	#47,#C8,#47,#E2,#80,#FF,#03
	DB	#47,#C9,#66,#D9,#66,#F0,#03
	DB	#01,#87,#1A,#94,#1A,#CC,#03
	DB	#01,#87,#01,#BF,#1A,#CC,#03
	DB	#3B,#C3,#1A,#CC,#3B,#DC,#03
	DB	#1A,#B3,#3B,#C3,#1A,#CC,#83
; Taille 798 octets
Batman
; 4 octets de palette
	DB	"KTSL"
	DB	#0F			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
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
; Taille 84 octets
Batman2
; 4 octets de palette
	DB	"KUTN"
	DB	#07			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#80,#00,#19,#C4,#80,#C4,#01
	DB	#60,#0C,#74,#17,#69,#2C,#01
	DB	#19,#C4,#2C,#C4,#23,#D2,#01
	DB	#2C,#C4,#3F,#C4,#36,#D2,#01
	DB	#3F,#C4,#52,#C4,#49,#D2,#01
	DB	#52,#C4,#65,#C4,#5C,#D2,#01
	DB	#65,#C4,#78,#C4,#6F,#D2,#01
	DB	#78,#C4,#80,#C4,#80,#D2,#01
	DB	#67,#1A,#70,#1C,#6A,#27,#02
	DB	#80,#18,#6A,#2D,#80,#2D,#02
	DB	#50,#9B,#58,#A1,#48,#C4,#02
	DB	#48,#9F,#40,#A5,#48,#A6,#02
	DB	#48,#A6,#40,#AB,#48,#AC,#02
	DB	#48,#AC,#40,#B2,#48,#B2,#02
	DB	#6B,#32,#7C,#35,#74,#38,#00
	DB	#60,#44,#80,#44,#80,#71,#00
	DB	#80,#73,#4F,#73,#6B,#9F,#00
	DB	#80,#73,#6B,#9F,#80,#9F,#00
	DB	#4F,#73,#59,#75,#4B,#9D,#00
	DB	#5C,#88,#50,#9C,#54,#9E,#00
	DB	#50,#73,#5E,#88,#50,#9C,#00
	DB	#50,#82,#51,#9D,#49,#9F,#00
	DB	#6D,#A8,#7E,#C3,#65,#F3,#00
	DB	#7B,#CA,#70,#E1,#71,#E2,#02
	DB	#67,#CA,#69,#CA,#67,#D8,#02
	DB	#6D,#D5,#62,#D9,#67,#F4,#01
	DB	#6D,#D5,#75,#DF,#67,#F4,#02
	DB	#6C,#EF,#6E,#F7,#4F,#FE,#01
	DB	#80,#7E,#7E,#88,#80,#88,#02
	DB	#80,#88,#7C,#88,#80,#96,#02
	DB	#72,#7C,#7D,#87,#76,#92,#02
	DB	#72,#7C,#6F,#86,#74,#86,#02
	DB	#80,#52,#7F,#53,#80,#63,#03
	DB	#80,#4D,#80,#50,#75,#50,#03
	DB	#5E,#9D,#6A,#9D,#6A,#A6,#03
	DB	#5E,#9D,#6A,#A6,#5E,#A6,#03
	DB	#6C,#9E,#6C,#A7,#78,#A7,#03
	DB	#6C,#9E,#78,#9E,#78,#A7,#03
	DB	#7A,#9E,#80,#9E,#80,#A8,#03
	DB	#7A,#9E,#80,#A8,#7A,#A8,#83
; Taille 280 octets
Piece
; 4 octets de palette
	DB	"@TDL"
	DB	#0F			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
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
ChessBoard
; 4 octets de palette
	DB	"@KT["
	DB	#03			; Tps d'affichage
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
Montagne
; 4 octets de palette
	DB	"S@KL"
	DB	#06			; Tps d'affichage
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
	DB	#1C,#89,#00,#A4,#12,#A4,#01
	DB	#48,#6F,#1C,#87,#12,#A4,#01
	DB	#30,#73,#39,#78,#27,#82,#01
	DB	#5D,#5A,#6C,#69,#12,#A4,#01
	DB	#74,#62,#84,#73,#12,#A4,#01
	DB	#8D,#70,#84,#70,#12,#A4,#01
	DB	#8D,#70,#A1,#82,#12,#A4,#01
	DB	#A1,#82,#B5,#A3,#12,#A4,#01
	DB	#AF,#7C,#A1,#82,#B5,#A3,#01
	DB	#AF,#7C,#B5,#7F,#B5,#A3,#01
	DB	#C1,#77,#B5,#7F,#B5,#A3,#01
	DB	#C1,#77,#B5,#A3,#FF,#A4,#01
	DB	#CE,#73,#C1,#79,#E1,#8E,#01
	DB	#11,#93,#0D,#97,#28,#A0,#02
	DB	#1A,#8B,#15,#8F,#25,#99,#02
	DB	#27,#79,#34,#87,#2A,#96,#02
	DB	#32,#73,#3D,#78,#37,#8D,#02
	DB	#3D,#78,#45,#8C,#37,#8D,#02
	DB	#47,#7F,#41,#83,#45,#8C,#02
	DB	#45,#8C,#37,#8D,#3C,#90,#02
	DB	#31,#8C,#39,#94,#29,#96,#02
	DB	#4F,#6D,#55,#70,#4E,#7D,#02
	DB	#4E,#7D,#4D,#8D,#59,#9A,#02
	DB	#4E,#7D,#5E,#8D,#59,#9A,#02
	DB	#5E,#66,#6C,#6B,#55,#70,#02
	DB	#75,#62,#69,#69,#7F,#7A,#02
	DB	#84,#6F,#8F,#70,#7B,#83,#02
	DB	#8F,#70,#7B,#83,#8E,#8F,#02
	DB	#7F,#85,#8E,#8F,#79,#99,#02
	DB	#8E,#8F,#79,#99,#84,#A0,#02
	DB	#8E,#8F,#9D,#9F,#84,#A0,#02
	DB	#8E,#8F,#9B,#95,#9D,#9F,#02
	DB	#8F,#71,#8E,#85,#9B,#8B,#02
	DB	#8F,#71,#A3,#83,#9B,#8B,#02
	DB	#AF,#7C,#A3,#83,#AF,#8B,#02
	DB	#AF,#7C,#AF,#8B,#C1,#90,#02
	DB	#AF,#8B,#C1,#90,#BC,#9C,#02
	DB	#55,#7A,#78,#85,#65,#95,#02
	DB	#7C,#78,#55,#7A,#76,#84,#02
	DB	#5E,#6F,#55,#7A,#78,#85,#02
	DB	#6C,#6B,#5E,#6E,#76,#72,#02
	DB	#D0,#75,#D9,#82,#C7,#85,#02
	DB	#D9,#82,#C7,#85,#CD,#92,#02
	DB	#D9,#82,#E1,#8E,#CD,#92,#02
	DB	#E1,#8E,#CD,#92,#DD,#9B,#02
	DB	#E1,#8E,#FF,#A4,#D9,#A4,#02
	DB	#5E,#5A,#6E,#6A,#5D,#6E,#82
; Taille 329 octets
Floral
; 4 octets de palette
	DB	"CYSO"
	DB	#03			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#18,#00,#00,#00,#00,#18,#01
	DB	#00,#E7,#00,#FF,#18,#FF,#01
	DB	#30,#00,#00,#30,#30,#30,#02
	DB	#00,#CF,#30,#CF,#30,#FF,#02
	DB	#48,#18,#18,#48,#48,#48,#03
	DB	#18,#B7,#48,#B7,#48,#E7,#03
	DB	#60,#30,#60,#60,#30,#60,#01
	DB	#30,#9F,#60,#9F,#60,#CF,#01
	DB	#78,#48,#78,#78,#48,#78,#02
	DB	#48,#87,#78,#87,#78,#B7,#02
	DB	#80,#6F,#70,#7F,#80,#8E,#03
	DB	#48,#6B,#33,#80,#48,#94,#03
	DB	#32,#6B,#1D,#80,#32,#94,#01
	DB	#1C,#6B,#08,#80,#1C,#94,#82
; Taille 98 octets
Glaive
; 4 octets de palette
	DB	"K@FN"
	DB	#09			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
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
Apple
; 4 octets de palette
	DB	"@TWK"
	DB	#0F			; Tps d'affichage
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
	DB	#00,#00,#6C,#7F,#00,#FF,#02
	DB	#00,#00,#85,#00,#6C,#7F,#02
	DB	#6C,#7F,#8E,#7F,#00,#FF,#02
	DB	#8E,#7F,#00,#FF,#99,#FF,#02
	DB	#85,#00,#FF,#00,#6C,#7F,#03
	DB	#FF,#00,#FF,#7F,#6C,#7F,#03
	DB	#8E,#7F,#FF,#FF,#99,#FF,#03
	DB	#8E,#7F,#FF,#7F,#FF,#FF,#03
	DB	#47,#44,#42,#49,#4D,#49,#01
	DB	#42,#49,#4C,#49,#4D,#5D,#01
	DB	#42,#49,#4D,#5D,#42,#5D,#01
	DB	#42,#5D,#4C,#5D,#48,#62,#01
	DB	#B8,#43,#B3,#48,#BE,#48,#01
	DB	#B3,#48,#BD,#48,#BD,#5C,#01
	DB	#B3,#48,#B3,#5C,#BE,#5C,#01
	DB	#B3,#5C,#BD,#5C,#B9,#61,#01
	DB	#36,#9E,#30,#A4,#44,#B7,#01
	DB	#36,#9E,#48,#AF,#44,#B7,#01
	DB	#48,#AF,#44,#B7,#58,#C1,#01
	DB	#48,#AF,#5B,#B8,#58,#C1,#01
	DB	#5B,#B8,#58,#C1,#6E,#C5,#01
	DB	#5B,#B8,#70,#BD,#6E,#C5,#01
	DB	#70,#BD,#6E,#C5,#8D,#C5,#01
	DB	#70,#BD,#8D,#BD,#8D,#C5,#01
	DB	#8D,#BD,#A5,#C0,#8D,#C5,#01
	DB	#A2,#B8,#8D,#BD,#A5,#C0,#01
	DB	#A2,#B8,#B7,#B8,#A5,#C0,#01
	DB	#B3,#B1,#B7,#B8,#A2,#B8,#01
	DB	#C9,#9E,#B3,#B1,#B7,#B8,#01
	DB	#C9,#9E,#CF,#A4,#B7,#B8,#81
; Taille 210 octets
Linux
; 4 octets de palette
	DB	"WKTL"
	DB	#08			; Tps d'affichage
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
	DB	#AC,#19,#80,#36,#BF,#3F,#01
	DB	#80,#36,#AA,#54,#9A,#5C,#01
	DB	#80,#36,#BF,#3E,#AA,#54,#01
	DB	#81,#21,#A0,#21,#80,#36,#01
	DB	#A1,#12,#AC,#19,#80,#37,#01
	DB	#92,#10,#A1,#12,#8F,#2A,#01
	DB	#7B,#01,#93,#10,#90,#23,#01
	DB	#7C,#01,#72,#04,#90,#23,#01
	DB	#81,#37,#6F,#57,#9A,#5C,#01
	DB	#6F,#57,#9A,#5C,#63,#8F,#01
	DB	#9A,#5C,#62,#8F,#99,#91,#01
	DB	#62,#8F,#9A,#91,#64,#B8,#01
	DB	#99,#91,#64,#B8,#A6,#C0,#01
	DB	#64,#B8,#A6,#C0,#6E,#E4,#01
	DB	#A5,#C0,#B9,#D1,#6E,#E4,#01
	DB	#B9,#D1,#6E,#E4,#8A,#F8,#01
	DB	#B7,#D2,#8A,#F8,#A5,#FE,#01
	DB	#6E,#E4,#5F,#F3,#89,#F7,#01
	DB	#5F,#F3,#89,#F7,#67,#F8,#01
	DB	#8B,#F8,#88,#FE,#A5,#FE,#01
	DB	#AA,#F0,#A6,#FC,#AC,#FE,#01
	DB	#72,#04,#90,#23,#82,#23,#02
	DB	#81,#37,#63,#55,#6F,#58,#02
	DB	#63,#55,#53,#89,#62,#8E,#02
	DB	#63,#55,#6F,#58,#63,#8F,#02
	DB	#52,#88,#63,#8E,#54,#B7,#02
	DB	#63,#8E,#54,#B7,#64,#C0,#02
	DB	#BF,#3E,#A8,#55,#D1,#76,#02
	DB	#A8,#55,#D1,#76,#D1,#A4,#02
	DB	#A8,#55,#9A,#5C,#99,#90,#02
	DB	#A8,#55,#99,#91,#A6,#C1,#02
	DB	#A8,#55,#D1,#A4,#A5,#C0,#02
	DB	#D1,#A3,#A5,#C0,#BB,#D3,#02
	DB	#D1,#A3,#D1,#B9,#BB,#D3,#02
	DB	#9B,#19,#99,#1D,#9B,#20,#02
	DB	#9B,#19,#A1,#19,#A3,#1D,#02
	DB	#A3,#1D,#9B,#20,#A1,#21,#02
	DB	#9B,#19,#A3,#1D,#9B,#20,#82
; Taille 266 octets
Amstrad
; 4 octets de palette
	DB	"@EKL"
	DB	#01			; Tps d'affichage
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
	DB	#9F,#4C,#DF,#4C,#AC,#B3,#01
	DB	#9F,#4C,#AC,#B3,#6B,#B3,#01
	DB	#07,#5D,#00,#A1,#0F,#A1,#02
	DB	#07,#5D,#11,#5D,#0F,#A1,#02
	DB	#1B,#5D,#11,#5D,#14,#A1,#02
	DB	#1B,#5D,#23,#A1,#14,#A1,#02
	DB	#0E,#88,#13,#88,#0E,#94,#02
	DB	#13,#88,#13,#94,#0E,#94,#02
	DB	#25,#5D,#33,#5D,#33,#A1,#02
	DB	#25,#5D,#33,#A1,#25,#A1,#02
	DB	#33,#5D,#39,#5D,#3B,#6E,#02
	DB	#33,#5D,#3C,#6E,#33,#92,#02
	DB	#3E,#5D,#3B,#6E,#44,#92,#02
	DB	#3E,#5D,#44,#5D,#44,#92,#02
	DB	#44,#5D,#52,#5D,#52,#A1,#02
	DB	#44,#5D,#52,#A1,#44,#A1,#02
	DB	#33,#92,#36,#A1,#41,#A1,#02
	DB	#33,#92,#44,#92,#41,#A1,#02
	DB	#3B,#6C,#44,#92,#33,#92,#02
	DB	#5A,#5D,#6E,#5D,#53,#64,#02
	DB	#6E,#5D,#53,#64,#75,#64,#02
	DB	#65,#64,#65,#75,#75,#75,#02
	DB	#65,#64,#75,#64,#75,#75,#02
	DB	#63,#64,#65,#64,#65,#6A,#02
	DB	#63,#64,#65,#6A,#63,#6A,#02
	DB	#53,#64,#63,#64,#63,#73,#02
	DB	#53,#64,#63,#73,#53,#79,#02
	DB	#63,#73,#53,#79,#75,#81,#02
	DB	#53,#79,#75,#81,#65,#86,#02
	DB	#75,#81,#65,#86,#75,#9A,#02
	DB	#65,#86,#65,#93,#75,#9A,#02
	DB	#65,#93,#75,#9A,#6E,#A1,#02
	DB	#65,#93,#5A,#A1,#6E,#A1,#02
	DB	#65,#93,#53,#9B,#5A,#A1,#02
	DB	#53,#86,#63,#86,#63,#96,#02
	DB	#53,#85,#63,#94,#53,#9B,#02
	DB	#75,#5D,#93,#5D,#93,#69,#02
	DB	#75,#5D,#93,#69,#75,#69,#02
	DB	#7C,#69,#7B,#A1,#8C,#A1,#02
	DB	#7C,#69,#8C,#69,#8C,#A1,#02
	DB	#95,#5D,#A5,#5D,#A5,#A1,#02
	DB	#95,#5D,#A5,#A1,#95,#A1,#02
	DB	#A5,#5D,#B0,#5D,#A7,#6C,#02
	DB	#A5,#5D,#A5,#69,#A7,#6C,#02
	DB	#B0,#5D,#B7,#64,#A7,#6C,#02
	DB	#B7,#64,#A8,#6B,#B7,#7A,#02
	DB	#A8,#6B,#A6,#7A,#B7,#7A,#02
	DB	#A5,#7A,#B7,#7A,#A5,#85,#02
	DB	#B7,#7A,#A5,#85,#A8,#89,#02
	DB	#B4,#7D,#B7,#84,#A8,#88,#02
	DB	#B7,#84,#A8,#88,#B7,#A1,#02
	DB	#A8,#88,#B7,#A1,#A8,#A1,#02
	DB	#C0,#5D,#B9,#A1,#C8,#A1,#02
	DB	#C0,#5D,#CA,#5D,#C8,#A1,#02
	DB	#D4,#5D,#CA,#5D,#CD,#A1,#02
	DB	#D4,#5D,#DC,#A1,#CD,#A1,#02
	DB	#C7,#88,#CC,#88,#C7,#94,#02
	DB	#CC,#88,#CC,#94,#C7,#94,#02
	DB	#DD,#5D,#F8,#5D,#F8,#A1,#02
	DB	#DD,#5D,#F8,#A1,#DD,#A1,#02
	DB	#ED,#6A,#EF,#6A,#EF,#95,#00
	DB	#ED,#6A,#EF,#95,#ED,#95,#00
	DB	#F8,#5D,#FF,#64,#FF,#9B,#02
	DB	#F8,#5D,#FF,#9B,#F8,#A1,#82
; Taille 448 octets
World
; 4 octets de palette
	DB	"DVNK"
	DB	#06			; Tps d'affichage
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
	DB	#D6,#21,#E0,#2C,#D7,#2D,#01
	DB	#D7,#2D,#D2,#44,#D6,#4E,#01
	DB	#D6,#21,#C2,#2B,#D2,#45,#01
	DB	#C5,#1E,#D6,#21,#AE,#22,#01
	DB	#D6,#21,#AE,#22,#C2,#2B,#01
	DB	#C3,#2C,#AD,#3B,#CC,#4B,#01
	DB	#C3,#2C,#D2,#46,#CC,#4B,#01
	DB	#CD,#4B,#A7,#66,#B5,#70,#01
	DB	#AD,#3B,#CD,#4B,#A8,#67,#01
	DB	#AF,#22,#A7,#2A,#AD,#3C,#01
	DB	#AF,#22,#C4,#2D,#AD,#3C,#01
	DB	#8F,#46,#97,#58,#A8,#67,#01
	DB	#AD,#3C,#8F,#46,#A8,#67,#01
	DB	#8F,#29,#A8,#2A,#AD,#3C,#01
	DB	#8F,#29,#AE,#3C,#8F,#47,#01
	DB	#9C,#21,#B0,#22,#98,#28,#01
	DB	#B0,#22,#98,#28,#A8,#2C,#01
	DB	#7E,#1E,#8B,#25,#6D,#31,#01
	DB	#8B,#25,#6E,#32,#90,#47,#01
	DB	#6F,#32,#68,#34,#6B,#41,#01
	DB	#6F,#32,#6C,#42,#72,#43,#01
	DB	#6F,#33,#74,#44,#7A,#47,#01
	DB	#6F,#33,#87,#42,#7A,#47,#01
	DB	#87,#42,#82,#4E,#7A,#4E,#01
	DB	#87,#42,#7A,#47,#7A,#4E,#01
	DB	#5F,#40,#6D,#42,#67,#46,#01
	DB	#62,#34,#5F,#40,#6D,#43,#01
	DB	#68,#34,#62,#35,#62,#36,#01
	DB	#68,#35,#63,#36,#6D,#43,#01
	DB	#6D,#24,#68,#2E,#6F,#33,#01
	DB	#6D,#24,#67,#2A,#68,#2E,#01
	DB	#7E,#1F,#74,#20,#6F,#33,#01
	DB	#7E,#1F,#78,#2A,#70,#34,#01
	DB	#CD,#4B,#D2,#51,#CF,#62,#01
	DB	#CE,#4D,#BF,#60,#D0,#63,#01
	DB	#BF,#61,#B6,#71,#C8,#77,#01
	DB	#C0,#62,#D1,#71,#C8,#78,#01
	DB	#C0,#62,#CA,#62,#D1,#72,#01
	DB	#C9,#78,#CA,#7F,#C4,#83,#01
	DB	#BB,#76,#BE,#84,#C5,#84,#01
	DB	#BB,#76,#C9,#79,#C5,#84,#01
	DB	#B6,#72,#A9,#74,#AF,#7E,#01
	DB	#A9,#68,#B6,#72,#A9,#74,#01
	DB	#91,#47,#85,#52,#8A,#58,#01
	DB	#91,#47,#8A,#58,#98,#58,#01
	DB	#D6,#77,#D0,#7D,#D1,#88,#01
	DB	#D6,#88,#DD,#94,#DD,#A2,#01
	DB	#D6,#88,#D6,#9B,#DD,#A2,#01
	DB	#D7,#89,#D3,#90,#D7,#9C,#01
	DB	#E3,#92,#E8,#92,#E5,#9D,#01
	DB	#E9,#92,#F2,#9B,#E6,#9D,#01
	DB	#F2,#9B,#E7,#9E,#F0,#A1,#01
	DB	#53,#6A,#62,#7B,#5A,#82,#01
	DB	#62,#7B,#5A,#83,#6A,#87,#01
	DB	#7A,#6E,#63,#7E,#83,#95,#01
	DB	#68,#83,#84,#96,#6E,#A2,#01
	DB	#84,#96,#6E,#A3,#7F,#A9,#01
	DB	#7B,#6F,#88,#79,#84,#97,#01
	DB	#8B,#9E,#85,#A5,#8E,#A5,#01
	DB	#8E,#A5,#86,#A6,#88,#AD,#01
	DB	#3E,#15,#2E,#16,#3C,#1C,#01
	DB	#2E,#16,#38,#1B,#37,#25,#01
	DB	#30,#16,#22,#1E,#37,#26,#01
	DB	#11,#16,#23,#20,#0B,#2B,#01
	DB	#02,#15,#12,#17,#0B,#2A,#01
	DB	#0C,#2B,#03,#3E,#25,#4E,#01
	DB	#23,#1F,#0C,#2B,#25,#4D,#01
	DB	#23,#20,#31,#23,#25,#4D,#01
	DB	#31,#23,#35,#2E,#25,#4E,#01
	DB	#32,#24,#46,#28,#35,#2E,#01
	DB	#46,#28,#35,#2F,#46,#32,#01
	DB	#04,#3E,#26,#4E,#1D,#55,#01
	DB	#04,#3E,#1E,#57,#22,#73,#01
	DB	#23,#73,#0D,#8A,#14,#9A,#01
	DB	#23,#74,#14,#9B,#33,#A9,#01
	DB	#23,#75,#38,#93,#34,#AA,#01
	DB	#3B,#86,#41,#94,#35,#AA,#01
	DB	#2A,#7E,#3B,#87,#38,#93,#01
	DB	#16,#9B,#33,#B8,#27,#C4,#01
	DB	#16,#9B,#35,#AA,#34,#B9,#01
	DB	#19,#BC,#27,#C5,#17,#D1,#01
	DB	#8B,#58,#98,#59,#9A,#69,#02
	DB	#8B,#59,#85,#61,#92,#74,#02
	DB	#8B,#5A,#9A,#69,#92,#74,#02
	DB	#9B,#6A,#93,#74,#9B,#76,#02
	DB	#F5,#A3,#EE,#AD,#F9,#B2,#02
	DB	#F9,#B2,#FE,#BF,#EB,#C8,#02
	DB	#EF,#AE,#F9,#B3,#EB,#C9,#02
	DB	#E0,#AC,#F0,#AE,#EB,#C9,#02
	DB	#E1,#AD,#D5,#B9,#EB,#CA,#02
	DB	#D6,#BA,#EB,#CA,#DC,#CF,#02
	DB	#FF,#BE,#EC,#C8,#F0,#CF,#02
	DB	#FF,#BE,#F1,#CF,#FA,#DE,#02
	DB	#70,#4B,#58,#53,#53,#68,#02
	DB	#70,#4B,#53,#68,#61,#7E,#02
	DB	#70,#4B,#79,#6E,#62,#7E,#02
	DB	#6F,#A3,#80,#AB,#75,#B3,#02
	DB	#6F,#A4,#6B,#B5,#76,#B5,#02
	DB	#70,#4B,#7C,#55,#7A,#6F,#02
	DB	#7C,#55,#86,#62,#7A,#6F,#02
	DB	#86,#63,#7B,#6F,#88,#78,#02
	DB	#88,#79,#92,#7E,#84,#97,#02
	DB	#15,#9B,#17,#BB,#26,#C4,#02
	DB	#5F,#0E,#43,#0F,#57,#26,#03
	DB	#4C,#15,#58,#1D,#46,#1F,#03
	DB	#B1,#E7,#8A,#F1,#C3,#F1,#03
	DB	#28,#E6,#1C,#F1,#22,#F1,#83
; Taille 749 octets
Bidul
; 4 octets de palette
	DB	"CNL\"
	DB	#0F			; Tps d'affichage
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
Etoile
; 4 octets de palette
	DB	"@OMX"
	DB	#0F			; Tps d'affichage
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
	DB	#4E,#07,#A6,#53,#53,#8E,#02
	DB	#50,#56,#75,#56,#00,#99,#03
	DB	#5C,#88,#A0,#99,#7A,#B1,#03
	DB	#A2,#00,#C4,#74,#49,#8D,#02
	DB	#B9,#4A,#53,#7C,#D5,#E3,#02
	DB	#4E,#07,#7F,#2C,#7C,#30,#03
	DB	#A2,#00,#7B,#31,#69,#5C,#03
	DB	#B5,#3F,#FF,#40,#B6,#43,#03
	DB	#5B,#41,#75,#42,#6A,#56,#01
	DB	#5B,#41,#6A,#56,#59,#5E,#01
	DB	#80,#74,#77,#98,#00,#99,#01
	DB	#69,#5C,#80,#74,#00,#99,#01
	DB	#FF,#40,#B5,#43,#B0,#68,#01
	DB	#FF,#40,#B0,#68,#C2,#7C,#01
	DB	#AE,#54,#C5,#64,#AB,#6A,#01
	DB	#C5,#64,#AB,#6A,#B5,#7D,#01
	DB	#88,#62,#92,#72,#80,#7B,#01
	DB	#92,#72,#80,#7B,#92,#8A,#01
	DB	#88,#62,#76,#6A,#80,#7B,#02
	DB	#76,#6A,#80,#7B,#6A,#7D,#02
	DB	#80,#7B,#6A,#7D,#92,#8A,#03
	DB	#A2,#00,#A4,#70,#A6,#70,#03
	DB	#A4,#70,#A6,#70,#D5,#E3,#03
	DB	#AE,#54,#C5,#64,#C5,#65,#03
	DB	#C5,#64,#C5,#65,#B5,#7D,#03
	DB	#C5,#64,#C5,#66,#B5,#7D,#83
; Taille 182 octets
Bouboule
; 4 octets de palette
	DB	"K_WU"
	DB	#0F			; Tps d'affichage
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
	DB	#8A,#00,#6E,#0F,#BB,#19,#03
	DB	#8A,#00,#6C,#0F,#3D,#11,#03
	DB	#6D,#10,#3E,#12,#1F,#3D,#03
	DB	#3C,#12,#1D,#3E,#09,#4B,#03
	DB	#1E,#3E,#09,#4C,#00,#83,#03
	DB	#00,#84,#0A,#AC,#1D,#D1,#03
	DB	#1E,#D1,#42,#E9,#6E,#FF,#03
	DB	#AA,#DA,#BA,#EE,#6E,#FF,#03
	DB	#EF,#B5,#AB,#D9,#BB,#EE,#03
	DB	#F0,#59,#F7,#7B,#F0,#B4,#03
	DB	#BD,#1A,#DB,#2E,#F0,#59,#03
	DB	#BD,#1B,#AB,#46,#EE,#58,#02
	DB	#AC,#47,#EF,#59,#CE,#8F,#02
	DB	#EF,#5A,#CE,#90,#EF,#B3,#02
	DB	#CE,#91,#EF,#B4,#AD,#D7,#02
	DB	#5A,#D3,#A9,#DA,#6E,#FE,#02
	DB	#1E,#D1,#59,#D2,#6C,#FD,#02
	DB	#2A,#92,#1E,#D1,#58,#D1,#02
	DB	#01,#85,#29,#91,#1D,#D0,#02
	DB	#1F,#3E,#01,#84,#29,#90,#02
	DB	#20,#3F,#5A,#4F,#2A,#8E,#02
	DB	#6C,#12,#1F,#3E,#59,#4E,#02
	DB	#6D,#11,#AB,#45,#5A,#4F,#02
	DB	#6D,#10,#BC,#1A,#AB,#44,#02
	DB	#AB,#46,#CD,#90,#83,#95,#01
	DB	#CD,#91,#84,#96,#AB,#D8,#01
	DB	#82,#95,#5B,#D2,#AB,#D9,#01
	DB	#2A,#91,#81,#95,#5A,#D2,#01
	DB	#5A,#50,#2A,#90,#81,#94,#01
	DB	#AA,#46,#5B,#50,#82,#95,#81
; Taille 210 octets
Donut
; 4 octets de palette
	DB	"XCSL"
	DB	#06			; Tps d'affichage
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
	DB	#55,#A2,#81,#A2,#8C,#C6,#03
	DB	#8C,#C6,#3E,#EA,#97,#EA,#03
	DB	#C4,#A2,#EA,#B4,#97,#EA,#03
	DB	#B8,#7F,#C4,#A2,#81,#A2,#03
	DB	#C4,#A2,#8C,#C6,#97,#EA,#01
	DB	#81,#A2,#C4,#A2,#8C,#C6,#01
	DB	#55,#A2,#60,#C6,#8C,#C6,#01
	DB	#60,#C6,#8C,#C6,#3E,#EA,#01
	DB	#34,#7F,#55,#A2,#60,#C6,#03
	DB	#34,#7F,#02,#90,#55,#A2,#01
	DB	#B8,#7F,#CE,#80,#C4,#A2,#01
	DB	#CE,#80,#C4,#A2,#EA,#B4,#01
	DB	#C4,#5C,#B8,#7F,#CE,#80,#03
	DB	#FF,#6E,#CE,#80,#EA,#B4,#03
	DB	#0D,#B4,#60,#C6,#3E,#EA,#03
	DB	#02,#90,#0D,#B4,#3E,#EA,#01
	DB	#34,#7F,#3E,#A2,#60,#C6,#01
	DB	#3E,#A2,#0D,#B4,#60,#C6,#01
	DB	#CF,#37,#F5,#4A,#FF,#6E,#01
	DB	#AE,#5B,#FF,#6E,#CE,#80,#01
	DB	#18,#49,#02,#90,#0D,#B4,#03
	DB	#C4,#15,#CF,#37,#F5,#4A,#03
	DB	#23,#6D,#3E,#A2,#0D,#B4,#03
	DB	#CF,#37,#AE,#5B,#FF,#6E,#03
	DB	#23,#6D,#4A,#80,#3E,#A2,#01
	DB	#18,#49,#23,#6D,#0D,#B4,#01
	DB	#CF,#37,#AE,#5B,#82,#5B,#01
	DB	#6C,#14,#18,#49,#23,#6D,#03
	DB	#C4,#15,#CF,#37,#77,#37,#01
	DB	#6C,#14,#C4,#15,#77,#37,#03
	DB	#77,#37,#82,#5B,#4A,#80,#01
	DB	#CF,#37,#77,#37,#82,#5B,#03
	DB	#77,#37,#23,#6D,#4A,#80,#03
	DB	#6C,#14,#77,#37,#23,#6D,#81
; Taille 238 octets
Cylindre
; 4 octets de palette
	DB	"DUWL"
	DB	#03			; Tps d'affichage
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
Hex
; 4 octets de palette
	DB	"DUWS"
	DB	#02			; Tps d'affichage
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
	DB	#52,#17,#95,#24,#21,#3D,#01
	DB	#21,#3D,#34,#72,#77,#7F,#01
	DB	#95,#23,#A7,#57,#77,#7F,#01
	DB	#95,#23,#21,#3D,#77,#7F,#01
	DB	#21,#3D,#34,#72,#34,#81,#02
	DB	#21,#3D,#21,#51,#34,#81,#02
	DB	#57,#26,#63,#3F,#34,#41,#02
	DB	#63,#3F,#34,#41,#41,#66,#03
	DB	#63,#3F,#41,#66,#70,#70,#02
	DB	#63,#3F,#7E,#4A,#70,#70,#00
	DB	#7E,#4A,#88,#5D,#70,#70,#00
	DB	#63,#3F,#7B,#41,#7E,#4A,#00
	DB	#57,#26,#85,#2E,#85,#2F,#00
	DB	#85,#2E,#85,#2F,#63,#3F,#00
	DB	#63,#41,#94,#53,#94,#54,#00
	DB	#94,#54,#70,#6D,#70,#70,#00
	DB	#84,#2E,#85,#2F,#94,#54,#00
	DB	#85,#2C,#7C,#41,#7B,#41,#00
	DB	#7C,#41,#94,#53,#94,#54,#00
	DB	#A8,#57,#EB,#64,#77,#7D,#01
	DB	#77,#7D,#8A,#B2,#CD,#BF,#01
	DB	#EB,#63,#FD,#97,#CD,#BF,#01
	DB	#EB,#63,#77,#7D,#CD,#BF,#01
	DB	#8A,#B2,#CD,#BF,#8A,#C1,#02
	DB	#CD,#BF,#8A,#C1,#CD,#CE,#02
	DB	#FD,#97,#CD,#BF,#CD,#CE,#02
	DB	#FD,#97,#FD,#A6,#CD,#CE,#02
	DB	#AD,#66,#B9,#7F,#8A,#81,#02
	DB	#B9,#7F,#8A,#81,#97,#A6,#03
	DB	#B9,#7F,#97,#A6,#C6,#B0,#02
	DB	#B9,#7F,#D4,#8A,#C6,#B0,#00
	DB	#D4,#8A,#DE,#9D,#C6,#B0,#00
	DB	#B9,#7F,#D1,#81,#D4,#8A,#00
	DB	#AD,#66,#DB,#6E,#DB,#6F,#00
	DB	#DB,#6E,#DB,#6F,#B9,#7F,#00
	DB	#B9,#81,#EA,#93,#EA,#94,#00
	DB	#EA,#94,#C6,#AD,#C6,#B0,#00
	DB	#DA,#6E,#DB,#6F,#EA,#94,#00
	DB	#DB,#6C,#D2,#81,#D1,#81,#00
	DB	#D2,#81,#EA,#93,#EA,#94,#00
	DB	#35,#72,#78,#7F,#04,#98,#01
	DB	#04,#98,#17,#CD,#5A,#DA,#01
	DB	#78,#7E,#8A,#B2,#5A,#DA,#01
	DB	#78,#7E,#04,#98,#5A,#DA,#01
	DB	#04,#98,#17,#CD,#17,#DC,#02
	DB	#04,#98,#04,#AC,#17,#DC,#02
	DB	#17,#CD,#5A,#DA,#17,#DC,#02
	DB	#5A,#DA,#17,#DC,#5A,#E9,#02
	DB	#8A,#B2,#5A,#DA,#5A,#E9,#02
	DB	#8A,#B2,#8A,#C1,#5A,#E9,#02
	DB	#3A,#81,#46,#9A,#17,#9C,#02
	DB	#46,#9A,#17,#9C,#24,#C1,#03
	DB	#46,#9A,#24,#C1,#53,#CB,#02
	DB	#46,#9A,#61,#A5,#53,#CB,#00
	DB	#61,#A5,#6B,#B8,#53,#CB,#00
	DB	#46,#9A,#5E,#9C,#61,#A5,#00
	DB	#3A,#81,#68,#89,#68,#8A,#00
	DB	#68,#89,#68,#8A,#46,#9A,#00
	DB	#46,#9C,#77,#AE,#77,#AF,#00
	DB	#77,#AF,#53,#C8,#53,#CB,#00
	DB	#67,#89,#68,#8A,#77,#AF,#00
	DB	#68,#87,#5F,#9C,#5E,#9C,#00
	DB	#5F,#9C,#77,#AE,#77,#AF,#80
; Taille 441 octets
Hippo
; 4 octets de palette
	DB	"D@T\"
	DB	#08			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#65,#0A,#80,#0F,#80,#34,#01
	DB	#65,#0A,#4B,#0E,#80,#34,#01
	DB	#4B,#0E,#36,#34,#80,#34,#01
	DB	#44,#02,#30,#02,#4B,#0E,#01
	DB	#30,#02,#4B,#0E,#30,#14,#01
	DB	#4B,#0E,#30,#14,#43,#1D,#01
	DB	#36,#34,#80,#34,#44,#78,#01
	DB	#80,#34,#44,#78,#48,#B0,#01
	DB	#44,#78,#48,#B0,#21,#BE,#01
	DB	#80,#34,#21,#BE,#73,#FF,#01
	DB	#80,#34,#80,#FF,#73,#FF,#01
	DB	#3A,#48,#49,#4D,#42,#53,#02
	DB	#59,#AC,#47,#B1,#63,#BF,#02
	DB	#47,#B1,#63,#BF,#4E,#C4,#02
	DB	#21,#BE,#2D,#E4,#73,#FF,#01
	DB	#91,#61,#96,#7F,#94,#94,#03
	DB	#7D,#F1,#83,#F2,#60,#F5,#03
	DB	#34,#05,#42,#0B,#45,#17,#03
	DB	#38,#37,#4A,#39,#4E,#3D,#03
	DB	#4C,#38,#4B,#3B,#52,#47,#03
	DB	#50,#67,#43,#7B,#41,#80,#03
	DB	#33,#AE,#2D,#C0,#2E,#C2,#03
	DB	#5A,#AF,#65,#BF,#64,#C1,#83
; Taille 161 octets
Elephant
; 4 octets de palette
	DB	"TFLN"
	DB	#0F			; Tps d'affichage
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
	DB	#7F,#12,#61,#1B,#6E,#65,#02
	DB	#7F,#12,#9F,#1B,#93,#65,#02
	DB	#93,#65,#93,#9E,#70,#A3,#02
	DB	#93,#65,#6E,#65,#70,#A3,#03
	DB	#7F,#12,#6E,#65,#93,#65,#03
	DB	#61,#1B,#4F,#2E,#6E,#65,#03
	DB	#9F,#1B,#B1,#2E,#93,#65,#03
	DB	#4F,#2E,#50,#59,#6E,#65,#01
	DB	#B1,#2E,#AF,#59,#93,#65,#01
	DB	#93,#9E,#70,#A3,#73,#C1,#03
	DB	#93,#9E,#73,#C1,#88,#E2,#01
	DB	#73,#C1,#70,#E1,#88,#E2,#03
	DB	#70,#E1,#88,#E2,#84,#F3,#01
	DB	#70,#E1,#84,#F3,#6F,#F5,#03
	DB	#6E,#65,#56,#9B,#70,#A3,#01
	DB	#93,#65,#AA,#9B,#93,#9E,#01
	DB	#50,#59,#6E,#65,#61,#78,#03
	DB	#AF,#59,#93,#65,#9F,#78,#03
	DB	#80,#53,#6E,#65,#93,#65,#01
	DB	#31,#11,#61,#1B,#4F,#2E,#01
	DB	#CE,#11,#9F,#1B,#B1,#2E,#01
	DB	#31,#11,#14,#2B,#4F,#2E,#03
	DB	#CE,#11,#EB,#2B,#B1,#2E,#03
	DB	#14,#2B,#4F,#2E,#01,#5C,#01
	DB	#EB,#2B,#B1,#2E,#FE,#5C,#01
	DB	#50,#59,#01,#5C,#10,#73,#03
	DB	#AF,#59,#FE,#5C,#EF,#73,#03
	DB	#50,#59,#10,#73,#25,#7C,#01
	DB	#AF,#59,#EF,#73,#DA,#7C,#01
	DB	#50,#59,#25,#7C,#45,#9B,#03
	DB	#AF,#59,#DA,#7C,#BB,#9B,#03
	DB	#50,#59,#56,#9B,#45,#9B,#01
	DB	#AF,#59,#AA,#9B,#BB,#9B,#01
	DB	#56,#9B,#70,#A3,#64,#A8,#03
	DB	#AA,#9B,#93,#9E,#9B,#A8,#03
	DB	#5B,#A0,#64,#A8,#56,#C5,#02
	DB	#A3,#A1,#9B,#A8,#A9,#C5,#02
	DB	#5B,#A0,#4C,#C2,#56,#C5,#03
	DB	#A3,#A1,#B3,#C2,#A9,#C5,#03
	DB	#4C,#C2,#56,#C5,#56,#CF,#02
	DB	#B3,#C2,#A9,#C5,#AA,#CF,#82
; Taille 287 octets
Elephant2
; 4 octets de palette
	DB	"O_[K"
	DB	#07			; Tps d'affichage
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
	DB	#92,#2C,#85,#37,#9F,#57,#01
	DB	#92,#2C,#A6,#36,#9E,#57,#01
	DB	#AB,#3A,#9D,#57,#AE,#62,#01
	DB	#A6,#36,#AB,#3A,#9E,#56,#01
	DB	#B5,#39,#C3,#3C,#AC,#69,#01
	DB	#C3,#3C,#AC,#6A,#B1,#6E,#01
	DB	#C2,#3C,#CA,#4D,#B1,#6E,#01
	DB	#B9,#79,#BF,#81,#B2,#88,#01
	DB	#BF,#81,#B2,#88,#BC,#96,#01
	DB	#BD,#92,#BB,#95,#C2,#9F,#01
	DB	#D4,#80,#BF,#84,#DC,#A4,#01
	DB	#D2,#7F,#E3,#95,#DC,#A4,#01
	DB	#F0,#60,#EF,#67,#F7,#68,#01
	DB	#F6,#60,#EF,#60,#F7,#68,#01
	DB	#88,#40,#8E,#72,#7A,#7F,#01
	DB	#88,#40,#7A,#68,#7A,#7F,#01
	DB	#63,#3E,#44,#40,#58,#78,#01
	DB	#5B,#7F,#71,#90,#66,#99,#01
	DB	#5B,#7F,#7A,#81,#71,#90,#01
	DB	#33,#74,#58,#7B,#3F,#95,#01
	DB	#33,#49,#10,#58,#33,#6E,#01
	DB	#20,#7E,#11,#87,#3F,#98,#01
	DB	#11,#87,#3F,#98,#37,#A0,#01
	DB	#07,#78,#12,#83,#04,#87,#01
	DB	#18,#8E,#20,#A0,#15,#B3,#01
	DB	#19,#8E,#0C,#9E,#15,#B3,#01
	DB	#74,#95,#86,#BB,#75,#BD,#01
	DB	#7B,#88,#8A,#9D,#85,#BB,#01
	DB	#7B,#88,#73,#97,#85,#BA,#01
	DB	#A5,#90,#89,#9E,#9D,#B3,#01
	DB	#A5,#90,#AE,#AB,#9B,#B2,#01
	DB	#B6,#3C,#A9,#3D,#AF,#58,#02
	DB	#C6,#51,#B0,#6C,#C1,#82,#02
	DB	#C6,#54,#D2,#7A,#C3,#7D,#02
	DB	#E4,#94,#EA,#95,#DC,#A6,#02
	DB	#EA,#94,#F5,#A1,#DD,#A4,#02
	DB	#F7,#75,#EA,#95,#F3,#A0,#02
	DB	#F1,#74,#F7,#76,#EA,#95,#02
	DB	#F9,#66,#F1,#68,#F7,#74,#02
	DB	#F9,#66,#FE,#73,#F6,#75,#02
	DB	#AB,#5D,#95,#6D,#A8,#7F,#02
	DB	#AB,#5D,#B7,#6C,#AA,#7F,#02
	DB	#A8,#5F,#8D,#63,#97,#6D,#02
	DB	#87,#46,#A8,#5E,#8E,#61,#02
	DB	#8F,#73,#A2,#79,#79,#84,#02
	DB	#78,#87,#A9,#8F,#8E,#9A,#02
	DB	#97,#7F,#77,#88,#A9,#8F,#02
	DB	#AB,#AD,#9B,#B2,#A3,#C5,#02
	DB	#AB,#AD,#B1,#BF,#A2,#C5,#02
	DB	#B7,#BF,#9F,#C6,#A2,#CD,#02
	DB	#B7,#BF,#B5,#C8,#A2,#CC,#02
	DB	#85,#BD,#76,#BF,#73,#C8,#02
	DB	#85,#BC,#74,#C7,#85,#CB,#02
	DB	#85,#BC,#8B,#C6,#85,#CB,#02
	DB	#86,#43,#67,#46,#7C,#6C,#02
	DB	#63,#47,#7C,#6C,#58,#80,#02
	DB	#75,#74,#62,#7A,#74,#82,#02
	DB	#44,#42,#3A,#71,#58,#78,#02
	DB	#45,#42,#2D,#44,#3A,#71,#02
	DB	#13,#5B,#31,#70,#0A,#77,#02
	DB	#2C,#70,#0A,#77,#13,#85,#02
	DB	#31,#72,#23,#7E,#41,#99,#02
	DB	#59,#80,#3F,#94,#55,#A0,#02
	DB	#59,#83,#64,#97,#57,#99,#02
	DB	#1A,#8F,#2B,#B0,#3D,#C0,#02
	DB	#19,#8F,#38,#A1,#3D,#C0,#02
	DB	#0B,#A3,#01,#BA,#08,#C3,#02
	DB	#0B,#A3,#08,#C4,#1E,#C5,#02
	DB	#24,#AA,#24,#BE,#2D,#C6,#02
	DB	#23,#AA,#2D,#C6,#46,#C9,#82
; Taille 490 octets
Girafe
; 4 octets de palette
	DB	"WJNT"
	DB	#07			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
;
; Donnees des triangles a afficher.
; Chaque frame contient un ou plusieurs trianges defini de la sorte :
; coordonnees X1,Y1,X2,Y2,X3,Y3 puis couleur
; Les coordonnees des triangles doivent etre triees des Y les plus petit au plus grand
; Seulement 1 octet par coordonnees (donc de 0 a 255...)
; le 7eme octet de la structure (la couleur) defini le pen mode 1
; Si le bit 7 de cet octet est positionne, cela signifie la fin d'une frame
;
	DB	#61,#01,#54,#0E,#5E,#37,#01
	DB	#61,#01,#74,#04,#5E,#37,#01
	DB	#74,#04,#5E,#37,#6A,#43,#02
	DB	#5E,#37,#6A,#43,#54,#4C,#01
	DB	#6A,#43,#54,#4C,#80,#53,#02
	DB	#54,#4C,#80,#53,#56,#63,#01
	DB	#80,#53,#56,#63,#72,#7C,#02
	DB	#56,#63,#55,#73,#72,#7C,#01
	DB	#55,#73,#72,#7C,#60,#87,#01
	DB	#55,#73,#52,#82,#60,#87,#01
	DB	#52,#82,#60,#87,#4A,#8D,#01
	DB	#60,#87,#4A,#8D,#52,#96,#01
	DB	#56,#63,#55,#73,#46,#7B,#01
	DB	#4E,#6E,#2F,#73,#46,#7B,#01
	DB	#33,#54,#4E,#6E,#2F,#73,#01
	DB	#45,#4C,#33,#54,#4E,#6E,#03
	DB	#45,#4C,#56,#63,#4E,#6E,#02
	DB	#30,#47,#45,#4C,#33,#54,#03
	DB	#1A,#43,#30,#47,#33,#54,#03
	DB	#1A,#43,#1B,#4E,#33,#54,#01
	DB	#1B,#4E,#33,#54,#2F,#74,#01
	DB	#54,#73,#46,#7B,#4A,#84,#03
	DB	#54,#73,#52,#82,#4A,#84,#03
	DB	#52,#82,#4A,#85,#4A,#8E,#01
	DB	#80,#53,#72,#7C,#80,#9A,#02
	DB	#72,#7C,#80,#9A,#74,#A1,#01
	DB	#80,#9A,#74,#A1,#73,#C8,#01
	DB	#80,#9A,#73,#C8,#80,#CC,#02
	DB	#73,#C8,#80,#CC,#78,#E1,#03
	DB	#80,#CC,#78,#E1,#80,#FA,#02
	DB	#78,#E1,#68,#EA,#80,#FA,#01
	DB	#68,#EA,#70,#FA,#80,#FA,#02
	DB	#66,#D2,#78,#E1,#68,#EA,#01
	DB	#74,#C8,#66,#D2,#78,#E1,#02
	DB	#74,#A2,#74,#C8,#66,#D2,#02
	DB	#74,#A2,#58,#C3,#66,#D2,#01
	DB	#57,#A0,#74,#A2,#58,#C3,#02
	DB	#68,#81,#57,#A0,#74,#A2,#01
	DB	#72,#7B,#68,#81,#74,#A2,#02
	DB	#68,#81,#52,#94,#57,#A0,#81
; Taille 280 octets
Rhino
; 4 octets de palette
	DB	"N@KT"
	DB	#09			; Tps d'affichage
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
	DB	#5D,#00,#29,#0F,#89,#27,#01
	DB	#29,#0F,#89,#27,#0A,#38,#01
	DB	#89,#27,#0A,#38,#00,#6E,#01
	DB	#89,#27,#00,#6E,#0C,#B7,#01
	DB	#89,#27,#0C,#B7,#20,#D3,#01
	DB	#89,#27,#20,#D3,#57,#EC,#01
	DB	#89,#27,#60,#EC,#57,#EC,#01
	DB	#89,#27,#72,#E7,#57,#EC,#01
	DB	#89,#27,#83,#D6,#72,#E7,#01
	DB	#89,#27,#9B,#31,#83,#D6,#01
	DB	#9B,#31,#AE,#48,#83,#D6,#01
	DB	#AE,#48,#D0,#94,#83,#D6,#01
	DB	#D0,#94,#83,#D6,#9D,#F0,#01
	DB	#D0,#94,#9D,#F0,#B4,#FD,#01
	DB	#D0,#94,#CE,#F8,#B4,#FD,#01
	DB	#D0,#94,#DE,#EB,#CE,#F8,#01
	DB	#D0,#94,#E6,#DD,#DE,#EB,#01
	DB	#D7,#97,#C8,#CF,#E0,#D4,#01
	DB	#CA,#90,#D7,#97,#CF,#DE,#01
	DB	#A8,#19,#9B,#31,#AE,#48,#01
	DB	#A8,#19,#B7,#3B,#AE,#48,#01
	DB	#B8,#0E,#A8,#19,#B7,#3B,#01
	DB	#B8,#0E,#CB,#18,#B7,#3B,#01
	DB	#C7,#63,#B1,#81,#B9,#92,#02
	DB	#C7,#63,#CF,#81,#B9,#92,#02
	DB	#CF,#81,#CC,#92,#B9,#92,#02
	DB	#F9,#67,#F0,#79,#FF,#84,#02
	DB	#F0,#79,#FF,#84,#E1,#92,#02
	DB	#FF,#84,#E1,#92,#FC,#A6,#02
	DB	#E1,#92,#D9,#98,#FC,#A6,#02
	DB	#D9,#98,#FC,#A6,#E1,#CD,#02
	DB	#D9,#98,#E1,#CD,#D6,#CF,#02
	DB	#D9,#98,#C3,#C4,#D6,#CF,#02
	DB	#D9,#98,#BF,#B2,#C3,#C4,#02
	DB	#D9,#98,#C7,#9B,#BF,#B2,#02
	DB	#A5,#E3,#B2,#E3,#B9,#EB,#03
	DB	#A5,#E3,#AC,#EA,#B9,#EB,#03
	DB	#98,#A9,#8A,#AB,#93,#AE,#03
	DB	#83,#9D,#98,#A9,#8A,#AB,#03
	DB	#5B,#10,#5C,#10,#69,#3F,#03
	DB	#5B,#10,#3E,#18,#3E,#19,#03
	DB	#3E,#19,#53,#37,#54,#37,#03
	DB	#58,#38,#57,#39,#4B,#74,#03
	DB	#4A,#74,#4B,#74,#4E,#9A,#03
	DB	#4C,#9B,#69,#C6,#6A,#C6,#03
	DB	#69,#C6,#82,#D6,#83,#D6,#83
; Taille 322 octets

; 4 octets de palette
	DB	"D_ST"
	DB	#09			; Tps d'affichage
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
	DB	#82,#A3,#74,#AC,#82,#BC,#01
	DB	#BF,#29,#DF,#4C,#CC,#5C,#01
	DB	#DE,#4C,#CC,#5C,#E0,#74,#01
	DB	#D4,#21,#B5,#22,#CD,#37,#01
	DB	#D2,#2C,#C6,#32,#DE,#4B,#01
	DB	#BF,#28,#CD,#5D,#B6,#66,#01
	DB	#99,#0F,#D4,#21,#B4,#25,#01
	DB	#9B,#0F,#E2,#12,#D2,#23,#01
	DB	#D6,#02,#99,#10,#E2,#12,#01
	DB	#82,#A3,#A6,#A8,#83,#BB,#01
	DB	#A6,#A7,#81,#BB,#96,#C4,#01
	DB	#A6,#A6,#B8,#BA,#94,#C6,#01
	DB	#B8,#BA,#95,#C5,#B5,#D3,#01
	DB	#95,#C5,#B6,#D2,#91,#D7,#01
	DB	#93,#D5,#9B,#EA,#AE,#EC,#01
	DB	#B5,#D2,#93,#D6,#AE,#ED,#01
	DB	#9C,#EA,#AE,#EC,#98,#FD,#01
	DB	#AC,#9B,#A5,#A6,#B9,#BB,#01
	DB	#D9,#97,#AC,#9C,#B4,#BC,#01
	DB	#CA,#5A,#E1,#73,#D8,#95,#01
	DB	#CC,#5D,#B6,#66,#D9,#99,#01
	DB	#B8,#67,#D9,#98,#B2,#9B,#01
	DB	#97,#0F,#C0,#29,#B7,#64,#01
	DB	#71,#00,#A9,#0A,#84,#3B,#01
	DB	#9D,#15,#84,#39,#B0,#50,#01
	DB	#74,#00,#58,#05,#84,#3A,#01
	DB	#87,#39,#85,#4E,#71,#51,#01
	DB	#86,#4E,#6F,#50,#81,#6A,#01
	DB	#84,#4F,#91,#68,#81,#6A,#01
	DB	#58,#05,#87,#3B,#6F,#52,#01
	DB	#58,#05,#68,#39,#45,#43,#01
	DB	#58,#04,#3B,#1B,#4B,#38,#01
	DB	#3B,#19,#32,#2E,#4C,#37,#01
	DB	#32,#2E,#47,#35,#23,#3E,#01
	DB	#34,#2E,#1E,#38,#25,#3E,#01
	DB	#4A,#36,#45,#45,#2B,#48,#01
	DB	#21,#45,#35,#47,#2C,#4C,#01
	DB	#56,#06,#77,#0B,#54,#11,#02
	DB	#56,#07,#4D,#0F,#56,#11,#02
	DB	#5B,#39,#4E,#41,#6B,#43,#02
	DB	#67,#39,#5B,#3A,#6A,#43,#02
	DB	#87,#3A,#86,#45,#B1,#50,#02
	DB	#86,#45,#AF,#4F,#B8,#65,#02
	DB	#A3,#56,#B8,#64,#B7,#81,#02
	DB	#B7,#82,#B4,#9F,#A6,#A6,#02
	DB	#B4,#7A,#B9,#82,#B2,#8C,#02
	DB	#55,#28,#59,#2F,#50,#30,#03
	DB	#55,#28,#5D,#28,#59,#2F,#83
; Taille 336 octets

; 4 octets de palette
	DB	"JKNT"
	DB	#0F			; Tps d'affichage
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
	DB	#16,#00,#40,#21,#37,#28,#02
	DB	#16,#00,#37,#28,#1F,#39,#01
	DB	#72,#00,#48,#21,#51,#28,#02
	DB	#72,#00,#51,#28,#69,#39,#01
	DB	#44,#1E,#00,#4D,#43,#56,#01
	DB	#11,#6E,#77,#6E,#44,#E0,#02
	DB	#44,#1E,#87,#4D,#43,#56,#01
	DB	#44,#44,#11,#6E,#44,#95,#01
	DB	#44,#44,#77,#6E,#44,#95,#01
	DB	#44,#1E,#24,#34,#44,#77,#02
	DB	#44,#1E,#64,#34,#44,#77,#02
	DB	#44,#1E,#35,#6B,#44,#6D,#02
	DB	#44,#1E,#53,#6B,#44,#6D,#02
	DB	#32,#41,#3C,#41,#3D,#4B,#03
	DB	#4C,#41,#57,#41,#4C,#4B,#03
	DB	#44,#6C,#3C,#77,#44,#77,#03
	DB	#41,#6C,#3C,#77,#4C,#77,#03
	DB	#41,#6C,#47,#6C,#4C,#77,#03
	DB	#35,#6B,#3A,#70,#3C,#77,#03
	DB	#53,#6C,#4E,#70,#4B,#77,#03
	DB	#29,#80,#5F,#80,#45,#E0,#01
	DB	#64,#88,#89,#96,#45,#E0,#02
	DB	#89,#96,#A6,#AE,#45,#E0,#02
	DB	#A6,#AE,#A6,#E0,#45,#E0,#02
	DB	#DA,#7A,#A6,#86,#A6,#E0,#02
	DB	#DA,#4C,#DA,#7A,#A6,#86,#02
	DB	#DA,#4C,#FF,#79,#DA,#7A,#02
	DB	#FF,#79,#DA,#7A,#A6,#E0,#02
	DB	#FF,#4B,#DA,#4C,#FF,#79,#81
; Taille 203 octets

; 4 octets de palette
	DB	"V\NT"
	DB	#0F			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
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

; 4 octets de palette
	DB	"DT\L"
	DB	#08			; Tps d'affichage
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
	DB	#77,#1C,#99,#22,#73,#38,#02
	DB	#98,#22,#9D,#37,#73,#38,#02
	DB	#D9,#1E,#D7,#39,#CD,#3B,#01
	DB	#8F,#27,#8F,#2D,#7E,#2F,#01
	DB	#89,#26,#8F,#27,#7E,#2F,#01
	DB	#CE,#00,#C5,#06,#D8,#0B,#01
	DB	#CD,#00,#D7,#04,#D7,#0A,#01
	DB	#C7,#05,#99,#22,#9E,#37,#02
	DB	#C7,#05,#D7,#0B,#9E,#37,#02
	DB	#D7,#0B,#D9,#1E,#9E,#37,#02
	DB	#D9,#1E,#9E,#37,#CD,#3A,#02
	DB	#78,#1C,#5F,#25,#45,#50,#02
	DB	#77,#1D,#46,#4D,#6E,#5E,#02
	DB	#DE,#37,#E4,#3F,#C4,#71,#02
	DB	#DF,#37,#C8,#3D,#C4,#70,#02
	DB	#73,#37,#CC,#38,#65,#F1,#02
	DB	#49,#47,#A9,#6F,#10,#73,#02
	DB	#2E,#71,#15,#A0,#DF,#B9,#02
	DB	#B9,#56,#82,#A6,#DF,#B8,#02
	DB	#C7,#40,#B7,#58,#C4,#73,#02
	DB	#6F,#6F,#2E,#72,#6D,#8C,#02
	DB	#DF,#B8,#C4,#F5,#D8,#FE,#02
	DB	#DE,#B9,#64,#E6,#B8,#F6,#02
	DB	#8B,#AC,#DE,#B9,#6B,#E7,#02
	DB	#7E,#EB,#B7,#F5,#A2,#F9,#02
	DB	#86,#DA,#97,#F4,#84,#F9,#02
	DB	#8F,#C3,#67,#ED,#80,#F2,#02
	DB	#15,#A0,#96,#AD,#21,#AE,#02
	DB	#63,#A6,#20,#AE,#46,#F5,#02
	DB	#7C,#C8,#49,#EC,#55,#F8,#02
	DB	#72,#5F,#6A,#D5,#49,#EB,#82
; Taille 217 octets

; 4 octets de palette
	DB	"RKTL"
	DB	#08			; Tps d'affichage
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
	DB	#17,#A7,#75,#AE,#36,#B0,#01
	DB	#03,#8B,#17,#A7,#75,#AE,#01
	DB	#04,#75,#03,#8B,#75,#AE,#01
	DB	#0E,#54,#04,#75,#75,#AE,#01
	DB	#2A,#3D,#0E,#54,#75,#AE,#01
	DB	#6A,#3C,#2A,#3D,#75,#AE,#01
	DB	#6A,#3C,#98,#5A,#75,#AE,#01
	DB	#9D,#4E,#DA,#AE,#75,#AE,#01
	DB	#9D,#4E,#F1,#A5,#DA,#AE,#01
	DB	#9D,#4E,#FF,#8D,#F1,#A5,#01
	DB	#AC,#48,#9D,#4E,#EE,#84,#01
	DB	#AC,#48,#CA,#55,#EE,#84,#01
	DB	#CA,#55,#DA,#6B,#F0,#77,#01
	DB	#DA,#6B,#F0,#77,#EE,#84,#01
	DB	#0E,#4D,#14,#50,#0D,#57,#02
	DB	#0E,#4D,#05,#55,#0D,#57,#02
	DB	#05,#55,#0E,#57,#09,#66,#02
	DB	#20,#66,#03,#75,#03,#8C,#02
	DB	#20,#66,#2C,#6D,#03,#8C,#02
	DB	#2C,#6D,#39,#82,#03,#8C,#02
	DB	#39,#82,#2E,#88,#03,#8C,#02
	DB	#2E,#88,#03,#8C,#22,#98,#02
	DB	#03,#8C,#22,#98,#17,#A7,#02
	DB	#22,#98,#17,#A7,#3C,#B2,#02
	DB	#2F,#9B,#32,#A7,#3C,#B2,#02
	DB	#37,#8C,#2F,#9B,#3C,#B2,#02
	DB	#43,#87,#37,#8C,#3C,#B2,#02
	DB	#43,#87,#52,#9E,#3C,#B2,#02
	DB	#52,#9E,#42,#B0,#3C,#B2,#02
	DB	#69,#3B,#59,#88,#8E,#92,#02
	DB	#59,#88,#8E,#92,#61,#9D,#02
	DB	#8E,#92,#61,#9D,#71,#AF,#02
	DB	#8E,#92,#71,#AF,#99,#BA,#02
	DB	#8E,#92,#A4,#9B,#99,#BA,#02
	DB	#A4,#9B,#B7,#AB,#99,#BA,#02
	DB	#B7,#AB,#BF,#BA,#99,#BA,#02
	DB	#9E,#4F,#95,#5E,#A1,#66,#02
	DB	#9E,#4F,#AF,#58,#A1,#66,#02
	DB	#AB,#47,#9E,#4F,#AF,#58,#02
	DB	#AB,#47,#B3,#4C,#AF,#58,#02
	DB	#B7,#48,#B3,#4C,#C9,#55,#02
	DB	#C4,#47,#B7,#48,#C9,#55,#02
	DB	#C4,#47,#CA,#4C,#C9,#55,#02
	DB	#BA,#90,#DB,#98,#C6,#9C,#02
	DB	#D9,#79,#BA,#90,#DB,#98,#02
	DB	#D9,#79,#C4,#7E,#BA,#90,#02
	DB	#D9,#79,#E2,#89,#DB,#98,#02
	DB	#F7,#8E,#FF,#8E,#F7,#9C,#82
; Taille 336 octets
Lion
; 4 octets de palette
	DB	"TJLK"
	DB	#09			; Tps d'affichage
	DB	#01			; Mode rendu (0=normal, 1=miroir horizontal, 2=miroir vertical)
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
; Taille 728 octets
