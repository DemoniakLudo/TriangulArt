StartAnim
        LD      IY,Frame_58             ; Avant dernière frame
        LD      BC,#BC0C
        OUT     (C),C
InitAnim:
        LD      IX,Frame_0              ; Première frame
Bcl:
        LD      B,#F5
        IN      A,(C)
        RRA
        JR      NC,Bcl                  ; Synchro VBL
Mem:
        LD      A,#C0                   ; Mémoire écran
        LD      (OffsetVideo+1),A
        LD      (OffsetVideoClear+1),A
        XOR     #40                     ; Swap mémoire écran
        LD      (Mem+1),A
        RRA
        RRA
        LD      B,#BD
        OUT     (C),A                   ; Sélection mémoire vidéo à afficher
BclClearFrame:
        LD      A,(ZoneYmin+1)
        LD      C,(IY+1)
        CP      C
        JR      C,CalcCoord2
        LD      A,C
        LD      (ZoneYmin+1),A
CalcCoord2:
        LD      A,(ZoneYmax+1)
        LD      L,(IY+5)
        CP      L
        JR      NC,CalcCoord3
        LD      A,L
        LD      (ZoneYmax+1),A
CalcCoord3:
        LD      B,(IY+0)
        LD      A,B
        LD      D,(IY+2)
        CP      D
        JR      C,CalcCoord4            ; si B<D
        LD      B,D                     ; Sinon on inverse B et D
        LD      D,A
CalcCoord4:
        LD      A,D
        LD      H,(IY+4)
        CP      H
        JR      C,CalcCoord5            ; si D<H
        LD      D,H                     ; sinon on inverse D et H
        LD      H,A
CalcCoord5:
        LD      A,(ZoneXmax+1)
        CP      H
        JR      NC,CalcCoord6
        LD      A,H
        LD      (ZoneXmax+1),A
CalcCoord6:
        LD      A,(ZoneXmin+1)
        CP      B
        JR      C,CalcCoord7
        LD      A,B
        LD      (ZoneXmin+1),A
CalcCoord7:		
        LD      A,(IY+6)
        LD      BC,7
        ADD     IY,BC
        RLA
        JR      NC,BclClearFrame
        XOR     A
        LD      B,A                     ; Parce que A vaut zéro
ZoneXMin:
        LD      A,0
        LD      C,A
        RRA
        AND     A
        RRA
        LD      (OffsetClear+1),A       ; X/4 = début à effacer
ZoneXMax:
        LD      A,0
        SUB     C
        ADD     A,7
        RRA
        AND     A
        RRA
        LD      (BclClearZone+1),A      ; Nbre d'octets à effacer
ZoneYMin:
        LD      A,0                     ; Position y de départ

BclClearZone:
        LD      C,0                     ; Nbre d'octets à éffacer
        LD      L,A                     ; Reg.L = y
        EX      AF,AF'                  ; Sauvegarde position Y
        LD      H,TabAdr/256
        LD      A,(HL)                  ; Poids faible adresse écran
        INC     H
OffsetClear:
        ADD     A,0
        LD      E,A
        LD      A,(HL)                  ; Poids fort adresse écran
OffsetVideoClear:
        ADC     A,#C0
        LD      H,A
        LD      L,E                     ; Reg HL = adresse mémoire écran (x,y)
        LD      (HL),B                  ; Efface premier octet
        DEC     C                       ; Si un seul octet à effacer
        JR      Z,FinClear              ; Alors on a fini
        LD      D,H
        INC     DE
        LDIR
FinClear:
        EX      AF,AF'                  ; Récupère position Y
        INC     A
ZoneYMax:
        CP      0                       ; Y = Ymax ?
        JR      NZ,BclClearZone
        XOR     A                       ; Mettre les "max" à Zéro
        LD      (ZoneYmax+1),A
        LD      (ZoneXmax+1),A
        DEC     A                       ; Mettre les "min" à 255
        LD      (ZoneYmin+1),A
        LD      (ZoneXmin+1),A
        LD      A,(IY+0)
        INC     A
        JR      NZ,BclDrawFrame
        LD      IY,Frames               ; Si A=#FF, fin des frames, on recommence
BclDrawFrame:
        LD      A,(IX+6)
	CALL	SetTriangleColor
        LD      B,(IX+0)
        LD      C,(IX+1)
        LD      D,(IX+2)
        LD      E,(IX+3)
        LD      H,(IX+4)
        LD      L,(IX+5)
	CALL	DrawTriangle
	LD      A,(IX+6)
        LD      BC,7
        ADD     IX,BC
        RLA
        JR      NC,BclDrawFrame
        LD      A,(IX+0)
        INC     A
        JP      NZ,Bcl
        JP      InitAnim

Frames:
 
; Frame 0 - Nb triangles 2
Frame_0:
        DB      #77, #64, #C8, #64, #A0, #B4, #01
        DB      #A0, #14, #77, #64, #C8, #64, #82

; Frame 1 - Nb triangles 4
Frame_1:
        DB      #95, #16, #80, #64, #72, #6D, #01
        DB      #80, #64, #72, #6D, #AA, #B4, #03
        DB      #95, #16, #CF, #5B, #80, #64, #02
        DB      #CF, #5B, #80, #64, #AA, #B4, #81

; Frame 2 - Nb triangles 4
Frame_2:
        DB      #89, #1A, #89, #61, #6E, #77, #01
        DB      #89, #61, #6E, #77, #B7, #B0, #03
        DB      #89, #1A, #D2, #51, #89, #61, #02
        DB      #D2, #51, #89, #61, #B7, #B0, #81

; Frame 3 - Nb triangles 4
Frame_3:
        DB      #7B, #21, #92, #5C, #6F, #81, #01
        DB      #7B, #21, #D0, #48, #92, #5C, #02
        DB      #92, #5C, #6F, #81, #C5, #A9, #03
        DB      #D0, #48, #92, #5C, #C5, #A9, #81

; Frame 4 - Nb triangles 4
Frame_4:
        DB      #6C, #2C, #CA, #40, #99, #55, #02
        DB      #6C, #2C, #99, #55, #75, #89, #01
        DB      #CA, #40, #99, #55, #D4, #9E, #01
        DB      #99, #55, #75, #89, #D4, #9E, #83

; Frame 5 - Nb triangles 4
Frame_5:
        DB      #5F, #3A, #C1, #3B, #9E, #4E, #02
        DB      #5F, #3A, #9E, #4E, #7E, #8F, #01
        DB      #C1, #3B, #9E, #4E, #E1, #90, #01
        DB      #9E, #4E, #7E, #8F, #E1, #90, #83

; Frame 6 - Nb triangles 4
Frame_6:
        DB      #B4, #39, #A1, #46, #56, #4B, #02
        DB      #B4, #39, #A1, #46, #EA, #7F, #01
        DB      #A1, #46, #56, #4B, #8A, #92, #01
        DB      #A1, #46, #EA, #7F, #8A, #92, #83

; Frame 7 - Nb triangles 3
Frame_7:
        DB      #A7, #3B, #A0, #3F, #EF, #6D, #01
        DB      #A0, #3F, #50, #5C, #98, #90, #01
        DB      #A0, #3F, #EF, #6D, #98, #90, #83

; Frame 8 - Nb triangles 3
Frame_8:
        DB      #50, #6D, #A7, #8A, #A1, #8F, #02
        DB      #9E, #39, #EF, #5C, #A7, #8A, #03
        DB      #9E, #39, #50, #6D, #A7, #8A, #81

; Frame 9 - Nb triangles 4
Frame_9:
        DB      #E9, #4F, #B4, #80, #A5, #93, #01
        DB      #55, #7B, #B4, #80, #A5, #93, #02
        DB      #9A, #35, #E9, #4F, #B4, #80, #03
        DB      #9A, #35, #55, #7B, #B4, #80, #81

; Frame 10 - Nb triangles 3
Frame_10:
        DB      #94, #32, #DF, #45, #C0, #74, #03
        DB      #C0, #74, #5E, #85, #AB, #96, #02
        DB      #94, #32, #C0, #74, #5E, #85, #81

; Frame 11 - Nb triangles 3
Frame_11:
        DB      #8E, #32, #D2, #41, #C8, #66, #03
        DB      #C8, #66, #6A, #8A, #B1, #96, #02
        DB      #8E, #32, #C8, #66, #6A, #8A, #81

; Frame 12 - Nb triangles 4
Frame_12:
        DB      #87, #33, #C4, #43, #CC, #58, #03
        DB      #87, #33, #74, #70, #79, #89, #02
        DB      #CC, #58, #79, #89, #B7, #96, #02
        DB      #87, #33, #CC, #58, #79, #89, #81

; Frame 13 - Nb triangles 3
Frame_13:
        DB      #81, #35, #73, #7D, #88, #81, #02
        DB      #CD, #4C, #88, #81, #BD, #93, #02
        DB      #81, #35, #CD, #4C, #88, #81, #81

; Frame 14 - Nb triangles 4
Frame_14:
        DB      #95, #75, #74, #86, #C3, #90, #01
        DB      #7C, #38, #95, #75, #74, #86, #02
        DB      #CB, #42, #95, #75, #C3, #90, #02
        DB      #7C, #38, #CB, #42, #95, #75, #81

; Frame 15 - Nb triangles 4
Frame_15:
        DB      #C7, #3C, #77, #3D, #A0, #64, #01
        DB      #77, #3D, #A0, #64, #78, #8D, #02
        DB      #A0, #64, #C8, #8C, #78, #8D, #01
        DB      #C7, #3C, #A0, #64, #C8, #8C, #82

; Frame 16 - Nb triangles 4
Frame_16:
        DB      #C3, #3B, #74, #41, #A6, #52, #01
        DB      #C3, #3B, #A6, #52, #CB, #88, #02
        DB      #74, #41, #A6, #52, #7C, #8F, #02
        DB      #A6, #52, #CB, #88, #7C, #8F, #81

; Frame 17 - Nb triangles 4
Frame_17:
        DB      #BF, #3C, #AA, #41, #71, #46, #01
        DB      #BF, #3C, #AA, #41, #CE, #84, #02
        DB      #AA, #41, #71, #46, #80, #8E, #02
        DB      #AA, #41, #CE, #84, #80, #8E, #81

; Frame 18 - Nb triangles 4
Frame_18:
        DB      #D0, #7F, #83, #89, #96, #95, #03
        DB      #A9, #31, #BB, #41, #D0, #7F, #02
        DB      #A9, #31, #6F, #4B, #83, #89, #02
        DB      #A9, #31, #D0, #7F, #83, #89, #81

; Frame 19 - Nb triangles 3
Frame_19:
        DB      #D1, #79, #84, #81, #98, #A2, #03
        DB      #A7, #24, #6F, #50, #84, #81, #02
        DB      #A7, #24, #D1, #79, #84, #81, #81

; Frame 20 - Nb triangles 3
Frame_20:
        DB      #D1, #74, #82, #79, #9B, #AB, #03
        DB      #A4, #1B, #6F, #56, #82, #79, #02
        DB      #A4, #1B, #D1, #74, #82, #79, #81

; Frame 21 - Nb triangles 3
Frame_21:
        DB      #A1, #16, #72, #5C, #7F, #70, #02
        DB      #CF, #6E, #7F, #70, #9E, #B1, #03
        DB      #A1, #16, #CF, #6E, #7F, #70, #81

; Frame 22 - Nb triangles 3
Frame_22:
        DB      #A0, #14, #76, #62, #7A, #68, #02
        DB      #7A, #68, #CB, #68, #9F, #B4, #03
        DB      #A0, #14, #7A, #68, #CB, #68, #81

; Frame 23 - Nb triangles 4
Frame_23:
        DB      #A0, #15, #C5, #62, #CA, #67, #02
        DB      #C5, #62, #CA, #67, #9F, #B5, #01
        DB      #A0, #15, #74, #62, #C5, #62, #01
        DB      #74, #62, #C5, #62, #9F, #B5, #83

; Frame 24 - Nb triangles 4
Frame_24:
        DB      #A1, #16, #BD, #5C, #D0, #6B, #02
        DB      #BD, #5C, #D0, #6B, #9E, #B4, #01
        DB      #A1, #16, #BD, #5C, #6E, #5E, #01
        DB      #BD, #5C, #6E, #5E, #9E, #B4, #83

; Frame 25 - Nb triangles 4
Frame_25:
        DB      #A4, #18, #B3, #58, #D4, #6C, #02
        DB      #A4, #18, #B3, #58, #6A, #5D, #01
        DB      #B3, #58, #D4, #6C, #9B, #B3, #01
        DB      #B3, #58, #6A, #5D, #9B, #B3, #83

; Frame 26 - Nb triangles 4
Frame_26:
        DB      #A7, #19, #A7, #55, #D7, #6C, #02
        DB      #A7, #19, #A7, #55, #67, #5D, #01
        DB      #A7, #55, #D7, #6C, #98, #B2, #01
        DB      #A7, #55, #67, #5D, #98, #B2, #83

; Frame 27 - Nb triangles 4
Frame_27:
        DB      #A9, #18, #9A, #55, #68, #5F, #01
        DB      #A9, #18, #9A, #55, #D8, #6A, #02
        DB      #9A, #55, #68, #5F, #96, #B2, #03
        DB      #9A, #55, #D8, #6A, #96, #B2, #81

; Frame 28 - Nb triangles 4
Frame_28:
        DB      #A9, #17, #8D, #58, #6B, #62, #01
        DB      #8D, #58, #6B, #62, #96, #B3, #03
        DB      #A9, #17, #8D, #58, #D5, #67, #02
        DB      #8D, #58, #D5, #67, #96, #B3, #81

; Frame 29 - Nb triangles 4
Frame_29:
        DB      #A6, #16, #81, #5D, #71, #64, #01
        DB      #81, #5D, #71, #64, #99, #B4, #03
        DB      #A6, #16, #81, #5D, #D0, #65, #02
        DB      #81, #5D, #D0, #65, #99, #B4, #81

; Frame 30 - Nb triangles 2
Frame_30:
        DB      #C8, #64, #77, #65, #A0, #B4, #01
        DB      #9F, #14, #C8, #64, #77, #65, #82

; Frame 31 - Nb triangles 4
Frame_31:
        DB      #CD, #5C, #BF, #65, #AA, #B3, #03
        DB      #95, #15, #CD, #5C, #BF, #65, #01
        DB      #BF, #65, #70, #6E, #AA, #B3, #01
        DB      #95, #15, #BF, #65, #70, #6E, #82

; Frame 32 - Nb triangles 4
Frame_32:
        DB      #D1, #52, #B6, #68, #B6, #AF, #03
        DB      #88, #19, #D1, #52, #B6, #68, #01
        DB      #B6, #68, #6D, #78, #B6, #AF, #01
        DB      #88, #19, #B6, #68, #6D, #78, #82

; Frame 33 - Nb triangles 4
Frame_33:
        DB      #D0, #48, #AD, #6D, #C4, #A8, #03
        DB      #AD, #6D, #6F, #81, #C4, #A8, #01
        DB      #7A, #20, #D0, #48, #AD, #6D, #01
        DB      #7A, #20, #AD, #6D, #6F, #81, #82

; Frame 34 - Nb triangles 4
Frame_34:
        DB      #A6, #74, #75, #89, #D3, #9D, #01
        DB      #CA, #40, #A6, #74, #D3, #9D, #03
        DB      #6B, #2B, #A6, #74, #75, #89, #02
        DB      #6B, #2B, #CA, #40, #A6, #74, #81

; Frame 35 - Nb triangles 4
Frame_35:
        DB      #A1, #7B, #7E, #8E, #E0, #8F, #01
        DB      #C1, #3A, #A1, #7B, #E0, #8F, #03
        DB      #5E, #39, #A1, #7B, #7E, #8E, #02
        DB      #5E, #39, #C1, #3A, #A1, #7B, #81

; Frame 36 - Nb triangles 4
Frame_36:
        DB      #E9, #7E, #9E, #83, #8B, #90, #01
        DB      #55, #4A, #9E, #83, #8B, #90, #02
        DB      #B5, #37, #E9, #7E, #9E, #83, #03
        DB      #B5, #37, #55, #4A, #9E, #83, #81

; Frame 37 - Nb triangles 3
Frame_37:
        DB      #50, #5C, #9F, #8A, #98, #8E, #02
        DB      #A7, #39, #EF, #6D, #9F, #8A, #03
        DB      #A7, #39, #50, #5C, #9F, #8A, #81

; Frame 38 - Nb triangles 3
Frame_38:
        DB      #9E, #3A, #98, #3F, #EF, #5C, #01
        DB      #98, #3F, #50, #6D, #A1, #90, #01
        DB      #98, #3F, #EF, #5C, #A1, #90, #83

; Frame 39 - Nb triangles 4
Frame_39:
        DB      #9A, #36, #8B, #49, #56, #7A, #02
        DB      #9A, #36, #8B, #49, #EA, #4E, #01
        DB      #8B, #49, #56, #7A, #A5, #94, #01
        DB      #8B, #49, #EA, #4E, #A5, #94, #83

; Frame 40 - Nb triangles 3
Frame_40:
        DB      #7F, #55, #60, #84, #AB, #97, #01
        DB      #94, #33, #E1, #44, #7F, #55, #01
        DB      #E1, #44, #7F, #55, #AB, #97, #83

; Frame 41 - Nb triangles 3
Frame_41:
        DB      #77, #63, #6D, #88, #B1, #97, #01
        DB      #8E, #33, #D5, #3F, #77, #63, #01
        DB      #D5, #3F, #77, #63, #B1, #97, #83

; Frame 42 - Nb triangles 4
Frame_42:
        DB      #73, #71, #7B, #86, #B8, #96, #01
        DB      #C6, #40, #CB, #59, #B8, #96, #01
        DB      #88, #33, #C6, #40, #73, #71, #01
        DB      #C6, #40, #73, #71, #B8, #96, #83

; Frame 43 - Nb triangles 4
Frame_43:
        DB      #82, #36, #B7, #48, #CC, #4C, #03
        DB      #B7, #48, #CC, #4C, #BE, #94, #01
        DB      #82, #36, #B7, #48, #72, #7D, #01
        DB      #B7, #48, #72, #7D, #BE, #94, #83

; Frame 44 - Nb triangles 4
Frame_44:
        DB      #7C, #39, #CB, #43, #AA, #54, #03
        DB      #CB, #43, #AA, #54, #C3, #91, #01
        DB      #7C, #39, #AA, #54, #74, #87, #01
        DB      #AA, #54, #74, #87, #C3, #91, #83

; Frame 45 - Nb triangles 4
Frame_45:
        DB      #C7, #3C, #77, #3D, #9F, #65, #03
        DB      #77, #3D, #9F, #65, #78, #8D, #01
        DB      #9F, #65, #C8, #8C, #78, #8D, #03
        DB      #C7, #3C, #9F, #65, #C8, #8C, #81

; Frame 46 - Nb triangles 4
Frame_46:
        DB      #99, #77, #CB, #88, #7C, #8E, #03
        DB      #74, #41, #99, #77, #7C, #8E, #01
        DB      #C3, #3A, #99, #77, #CB, #88, #01
        DB      #C3, #3A, #74, #41, #99, #77, #83

; Frame 47 - Nb triangles 4
Frame_47:
        DB      #CE, #83, #95, #88, #80, #8D, #03
        DB      #71, #45, #95, #88, #80, #8D, #01
        DB      #BF, #3B, #CE, #83, #95, #88, #01
        DB      #BF, #3B, #71, #45, #95, #88, #83

; Frame 48 - Nb triangles 4
Frame_48:
        DB      #A9, #34, #BC, #40, #6F, #4A, #01
        DB      #6F, #4A, #84, #88, #96, #98, #01
        DB      #BC, #40, #D0, #7E, #96, #98, #01
        DB      #BC, #40, #6F, #4A, #96, #98, #83

; Frame 49 - Nb triangles 3
Frame_49:
        DB      #A7, #27, #BB, #48, #6E, #50, #01
        DB      #BB, #48, #D0, #79, #98, #A5, #01
        DB      #BB, #48, #6E, #50, #98, #A5, #83

; Frame 50 - Nb triangles 3
Frame_50:
        DB      #A4, #1E, #BD, #50, #6E, #55, #01
        DB      #BD, #50, #D0, #73, #9B, #AE, #01
        DB      #BD, #50, #6E, #55, #9B, #AE, #83

; Frame 51 - Nb triangles 3
Frame_51:
        DB      #C0, #59, #CD, #6D, #9E, #B3, #01
        DB      #A1, #18, #C0, #59, #70, #5B, #01
        DB      #C0, #59, #70, #5B, #9E, #B3, #83

; Frame 52 - Nb triangles 3
Frame_52:
        DB      #C5, #61, #C9, #67, #9F, #B5, #01
        DB      #A0, #15, #74, #61, #C5, #61, #01
        DB      #74, #61, #C5, #61, #9F, #B5, #83

; Frame 53 - Nb triangles 3
Frame_53:
        DB      #A0, #14, #75, #62, #7A, #67, #02
        DB      #7A, #67, #CB, #67, #9F, #B4, #03
        DB      #A0, #14, #7A, #67, #CB, #67, #81

; Frame 54 - Nb triangles 4
Frame_54:
        DB      #6F, #5E, #82, #6D, #9E, #B3, #01
        DB      #A1, #15, #6F, #5E, #82, #6D, #02
        DB      #D1, #6B, #82, #6D, #9E, #B3, #03
        DB      #A1, #15, #D1, #6B, #82, #6D, #81

; Frame 55 - Nb triangles 4
Frame_55:
        DB      #6B, #5D, #8C, #71, #9B, #B1, #01
        DB      #D5, #6C, #8C, #71, #9B, #B1, #03
        DB      #A4, #16, #6B, #5D, #8C, #71, #02
        DB      #A4, #16, #D5, #6C, #8C, #71, #81

; Frame 56 - Nb triangles 4
Frame_56:
        DB      #68, #5D, #98, #74, #98, #B0, #01
        DB      #D8, #6C, #98, #74, #98, #B0, #03
        DB      #A7, #17, #68, #5D, #98, #74, #02
        DB      #A7, #17, #D8, #6C, #98, #74, #81

; Frame 57 - Nb triangles 4
Frame_57:
        DB      #D7, #6A, #A5, #74, #96, #B1, #03
        DB      #67, #5F, #A5, #74, #96, #B1, #01
        DB      #A9, #17, #D7, #6A, #A5, #74, #01
        DB      #A9, #17, #67, #5F, #A5, #74, #82

; Frame 58 - Nb triangles 4
Frame_58:
        DB      #D4, #67, #B2, #71, #96, #B2, #03
        DB      #A9, #16, #D4, #67, #B2, #71, #01
        DB      #6A, #62, #B2, #71, #96, #B2, #01
        DB      #A9, #16, #6A, #62, #B2, #71, #82

; Frame 59 - Nb triangles 4
Frame_59:
        DB      #CE, #65, #BE, #6C, #99, #B3, #03
        DB      #A6, #15, #CE, #65, #BE, #6C, #01
        DB      #6F, #64, #BE, #6C, #99, #B3, #01
        DB      #A6, #15, #6F, #64, #BE, #6C, #82
        DB      #FF ; fin des frames
_EndFrame

