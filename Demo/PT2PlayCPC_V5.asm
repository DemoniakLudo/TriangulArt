;
; mettre la musique a l'adresse MDLADDR
;
; LD HL,MDLADDR : CALL INIT
; PUIS CALL PLAY (sauver AF')

TonA    EQU 0
TonB    EQU 2
TonC    EQU 4
Noise    EQU 6
Mixer    EQU 7
AmplA    EQU 8
AmplB    EQU 9
AmplC    EQU 10
Env    EQU 11
EnvTp    EQU 13


INIT:
		LD	HL,MdlAddr
        LD A,(HL)
        LD (PL1D+1),A
        PUSH HL
        INC HL
        INC HL
        LD A,(HL)
        EX AF,AF'
        INC HL
        LD (SamPtrs+1),HL
        LD E,(HL)
        INC HL
        LD D,(HL)
        LD A,E
        OR D
        CALL NZ,PhF2PT
        LD DE,63
        ADD HL,DE
        LD (OrnPtrs+1),HL
        LD E,32
        ADD HL,DE
        LD C,(HL)
        INC HL
        LD B,(HL)
        LD E,30
        ADD HL,DE
        LD (CrPsPtr+1),HL
        INC HL
        EX AF,AF'
        LD E,A
        ADD HL,DE
        LD (LPosPtr+1),HL
        POP HL
        ADD HL,BC
        LD (PatsPtr+1),HL
        LD HL,VARS
        LD (HL),D
        LD DE,VARS+1
        LD BC,VAR0END-VARS-1
        LDIR
        LD (AdInPtA+1),HL ;ptr to zero
        LD HL,#F01 ;H - Volume, L - SkpCnt
        LD (ChanA+SkpCnt),HL
        LD (ChanB+SkpCnt),HL
        LD (ChanC+SkpCnt),HL
        LD A,L
        LD (DelyCnt),A
        LD HL,EMPTYORN
        LD (ChanA+OrnPtr),HL
        LD (ChanB+OrnPtr),HL
        LD (ChanC+OrnPtr),HL

;note table creator (same as PT3 table #1)
;(c)Ivan Roshin

        LD HL,NTBL
        LD DE,NT_
        LD B,12
L1:
        PUSH BC
        LD C,(HL)
        INC HL
        PUSH HL
        LD B,(HL)
        PUSH DE
        EX DE,HL
        LD DE,23
        DB #DD:LD H,8
L2:
        SRL B
        RR C
        LD (HL),C
        INC HL
        LD (HL),B
        ADD HL,DE
        DB #DD:DEC H
        JR NZ,L2
        POP DE
        INC DE
        INC DE
        POP HL
        INC HL
        POP BC
        DJNZ L1
        LD A,#FD
        LD (NT_+#2E),A
        LD A,#0A
        LD (NT_+#5C),A

;vol table creator (same as PT3.5+ table)
;(c)Ivan Roshin

        LD HL,#11
        LD D,H
        LD E,H
        LD IX,VT_+16
        LD C,#10
INITV2:
        PUSH HL
        ADD HL,DE
        EX DE,HL
        SBC HL,HL
INITV1:
        LD A,L
        RLA
        LD A,H
        ADC A,0
        LD (IX+0),A
        INC IX
        ADD HL,DE
        INC C
        LD A,C
        AND 15
        JR NZ,INITV1
        POP HL
        LD A,E
        CP #77
        JR NZ,M3
        INC E
M3:
        LD A,C
        AND A
        JR NZ,INITV2
        JP ROUT_A0

PhF2PT:
;Convert PT v2.4 Phantom Family to standard PT2
;No integrity checking (can deadlock)

        PUSH HL
        DEC HL
        LD B,32+16
        CALL SUBAREA
        LD C,(HL)
        INC HL
        LD B,(HL)
        PUSH BC
        LD BC,31
        ADD HL,BC
MFLP:
        LD A,(HL)
        ADD A,A
        JR C,MFOUND
        INC HL
        RRCA
        CP B
        JR C,MFLP
        LD B,A
        JR MFLP
MFOUND:
        INC B
        LD A,B
        ADD A,A
        ADD A,B
        LD HL,(MODADDR+1)
        POP BC
        ADD HL,BC
        LD B,A
        CALL SUBAREA
        POP HL
        RET

SUBAREA:
        LD A,(HL)
        SUB E
        LD (HL),A
        INC HL
        LD A,(HL)
        SBC A,D
        LD (HL),A
        INC HL
        DJNZ SUBAREA
        RET

PD_SAM:
        ADD A,A
        LD E,A
        LD D,0
SamPtrs:
        LD HL,#2121
        ADD HL,DE
        LD E,(HL)
        INC HL
        LD D,(HL)
MODADDR:
        LD HL,MdlAddr
        ADD HL,DE
        LD (IX+SamPtr),L
        LD (IX+SamPtr+1),H
        JR PD_LOOP

PD_EOff:
        LD (IX+Env_En),A
        JR PD_LOOP

PD_ENV:
        LD (IX+Env_En),16
        LD (AYREGS+EnvTp),A
        LD A,(BC)
        INC BC
        LD L,A
        LD A,(BC)
        INC BC
        LD H,A
        LD (AYREGS+Env),HL
        JR PD_LOOP

PD_ORN:
        ADD A,A
        LD E,A
        LD D,0
OrnPtrs:
        LD HL,#2121
        ADD HL,DE
        LD E,(HL)
        INC HL
        LD D,(HL)
        LD HL,MdlAddr
        ADD HL,DE
        LD (IX+OrnPtr),L
        LD (IX+OrnPtr+1),H
        JR PD_LOOP

PD_SKIP:
        INC A
        LD (IX+Skip),A
        JR PD_LOOP

PD_VOL:
        LD (IX+Volume),A
        JR PD_LOOP

PD_DEL:
        LD A,(BC)
        INC BC
        LD (PL1D+1),A
        JR PD_LOOP

PD_GLIS:
        SET 2,(IX+Flags)
        SET 1,(IX+Flags)
        LD A,(BC)
        INC BC
        LD (IX+TSlStp),A
        ADD A,A
        SBC A,A
        LD (IX+TSlStp+1),A
        SCF
        JR PD_LP2

PTDECOD:
        AND A

PD_LP2:
        EX AF,AF'

PD_LOOP:
        LD A,(BC)
        INC BC
        ADD A,#20
        JR Z,PD_REL
        JR C,PD_SAM
        ADD A,96
        JR C,PD_NOTE
        INC A
        JR Z,PD_EOff
        ADD A,15
        JP Z,PD_QUIT
        JR C,PD_ENV
        ADD A,#10
        JR C,PD_ORN
        ADD A,#40
        JR C,PD_SKIP
        ADD A,#10
        JR C,PD_VOL
        INC A
        JR Z,PD_DEL
        INC A
        JR Z,PD_GLIS
        INC A
        JR Z,PD_PORT
        INC A
        JR Z,PD_STOP
        LD A,(BC)
        INC BC
        LD (IX+AddToN),A
        JR PD_LOOP

PD_PORT:
        RES 2,(IX+Flags)
        SET 1,(IX+Flags)
        LD A,(BC)
        INC BC
        INC BC ;ignoring precalc delta to right sound
        INC BC
        SCF
        JR PD_LP2

PD_STOP:
        RES 1,(IX+Flags)
        JR PD_LOOP

PD_REL:
        LD (IX+Flags),A
        JR PD_EXIT

PD_NOTE:
        LD L,A
        SET 0,(IX+Flags)
        EX AF,AF'
        JR NC,NOGLISS
        BIT 2,(IX+Flags)
        JR NZ,NOPORT
        LD (IX+SlToNt),L

        PUSH BC
        LD DE,NT_
        SLA L
        LD H,0
        ADD HL,DE
        LD C,(HL)
        INC HL
        LD B,(HL)
        LD L,(IX+Note)
        SLA L
        LD H,0
        ADD HL,DE
        LD E,(HL)
        INC HL
        LD D,(HL)
        LD L,C
        LD H,B
        SBC HL,DE
        LD (IX+TnDelt),L
        LD (IX+TnDelt+1),H
        JP P,DELTP
        AND A
        JP M,SET_STP
        JR NEG_STP
DELTP:
        AND A
        JP P,SET_STP
NEG_STP:
        NEG
SET_STP:
        LD (IX+TSlStp),A
        ADD A,A
        SBC A,A
        LD (IX+TSlStp+1),A
        POP BC
        JR PD_EX1

NOGLISS:
        RES 1,(IX+Flags)
NOPORT:
        LD (IX+Note),L

PD_EX1:
        XOR A

PD_EXIT:
        LD (IX+PsInSm),A
        LD (IX+PsInOr),A
        LD (IX+CrTnSl),A
        LD (IX+CrTnSl+1),A
PD_QUIT:
        LD A,(IX+Skip)
        LD (IX+SkpCnt),A
        RET

CHREGS:
        XOR A
        LD (Ampl),A
        PUSH HL
        BIT 0,(IX+Flags)
        JP Z,CH_EXIT
        LD (CSP_+1),SP
        LD L,(IX+OrnPtr)
        LD H,(IX+OrnPtr+1)
        LD SP,HL
        POP DE
        LD H,A
        LD A,(IX+PsInOr)
        LD L,A
        ADD HL,SP
        INC A
        CP E
        JR C,CH_ORPS
        LD A,D
CH_ORPS:
        LD (IX+PsInOr),A
        LD A,(IX+Note)
        ADD A,(HL)
        JP P,CH_NTP
        XOR A
CH_NTP:
        CP 96
        JR C,CH_NOK
        LD A,95
CH_NOK:
        ADD A,A
        EX AF,AF'
        LD L,(IX+SamPtr)
        LD H,(IX+SamPtr+1)
        LD SP,HL
        POP DE
        LD H,0
        LD A,(IX+PsInSm)
        LD B,A
        ADD A,A
        ADD A,B
        LD L,A
        ADD HL,SP
        LD SP,HL
        LD A,B
        INC A
        CP E
        JR C,CH_SMPS
        LD A,D
CH_SMPS:
        LD (IX+PsInSm),A
        POP BC
        POP DE
        LD D,B
        LD L,(IX+CrTnSl)
        LD H,(IX+CrTnSl+1)
        BIT 2,C
        JR Z,TSUB
        ADD HL,DE
        ADD HL,DE
TSUB:
        EX AF,AF'
        SBC HL,DE
        EX DE,HL
        LD L,A
        LD H,0
        LD SP,NT_
        ADD HL,SP
        LD SP,HL
        POP HL
        ADD HL,DE
CSP_:
        LD SP,#3131
        EX (SP),HL

        BIT 1,(IX+Flags)
        JR Z,CH_AMP
        LD L,(IX+CrTnSl)
        LD H,(IX+CrTnSl+1)
        LD E,(IX+TSlStp)
        LD D,(IX+TSlStp+1)
        ADD HL,DE
        LD (IX+CrTnSl),L
        LD (IX+CrTnSl+1),H
        BIT 2,(IX+Flags)
        JR NZ,CH_AMP
        LD E,(IX+TnDelt)
        LD D,(IX+TnDelt+1)
        LD A,(IX+TSlStp+1)
        AND A
        JR Z,CH_STPP
        EX DE,HL
CH_STPP:
        SBC HL,DE
        JP M,CH_AMP
        LD A,(IX+SlToNt)
        LD (IX+Note),A
        XOR A
        RES 1,(IX+Flags)
        LD (IX+CrTnSl),A
        LD (IX+CrTnSl+1),A

CH_AMP:
        LD A,B
        AND #F0
        OR (IX+Volume)
        RRCA
        RRCA
        RRCA
        RRCA
        LD L,A
        LD H,0
        LD DE,VT_
        ADD HL,DE
        LD A,(HL)
        OR (IX+Env_En)
        LD (Ampl),A
        RRC C
        SBC A,A
        AND #40
        JR NZ,NONS
        LD A,C
        RRCA
        RRCA
        ADD A,(IX+AddToN)
        LD (AYREGS+Noise),A
        XOR A
NONS:
        RRC C
        JR NC,CH_EXIT
        OR 8

CH_EXIT:
        LD HL,AYREGS+Mixer
        OR (HL)
        RRCA
        LD (HL),A
        POP HL
        RET

PLAY:
        XOR A
        LD (AYREGS+Mixer),A
        DEC A
        LD (AYREGS+EnvTp),A
        LD HL,DelyCnt
        DEC (HL)
        JR NZ,PL2
        LD HL,ChanA+SkpCnt
        DEC (HL)
        JR NZ,PL1B
AdInPtA:
        LD BC,#0101
        LD A,(BC)
        AND A
        JR NZ,PL1A
        LD D,A
CrPsPtr
        LD HL,0
        INC HL
        LD A,(HL)
        ADD A,A
        JR NC,PLNLP
LPosPtr:
        LD HL,#2121
        LD A,(HL)
        ADD A,A
PLNLP:
        LD (CrPsPtr+1),HL
        ADD A,(HL)
        ADD A,A
        LD E,A
        RL D
PatsPtr:
        LD HL,#2121
        ADD HL,DE
        LD DE,(MODADDR+1)
        LD (PSP_+1),SP
        LD SP,HL
        POP HL
        ADD HL,DE
        LD B,H
        LD C,L
        POP HL
        ADD HL,DE
        LD (AdInPtB+1),HL
        POP HL
        ADD HL,DE
        LD (AdInPtC+1),HL
PSP_:
        LD SP,#3131
PL1A:
        LD IX,ChanA
        CALL PTDECOD
        LD (AdInPtA+1),BC

PL1B:
        LD HL,ChanB+SkpCnt
        DEC (HL)
        JR NZ,PL1C
        LD IX,ChanB
AdInPtB:
        LD BC,#0101
        CALL PTDECOD
        LD (AdInPtB+1),BC

PL1C:
        LD HL,ChanC+SkpCnt
        DEC (HL)
        JR NZ,PL1D
        LD IX,ChanC
AdInPtC:
        LD BC,#0101
        CALL PTDECOD
        LD (AdInPtC+1),BC

PL1D:
        LD A,#3E
        LD (DelyCnt),A

PL2:
        LD IX,ChanA
        LD HL,(AYREGS+TonA)
        CALL CHREGS
        LD (AYREGS+TonA),HL
        LD A,(Ampl)
        LD (AYREGS+AmplA),A
        LD IX,ChanB
        LD HL,(AYREGS+TonB)
        CALL CHREGS
        LD (AYREGS+TonB),HL
        LD A,(Ampl)
        LD (AYREGS+AmplB),A
        LD IX,ChanC
        LD HL,(AYREGS+TonC)
        CALL CHREGS
        LD (AYREGS+TonC),HL
        XOR     A
ROUT_A0:
        LD      DE,#0DF4
        LD      HL,AYREGS
Rout1:
        LD      B,E
        OUT     (C),A
        LD      BC,#F6C0
        OUT     (C),C
        DB      #ED,#71     ; OUT   (C),0
        DEC     B
        OUTI
        LD      BC,#F680
        OUT     (C),C
        DB      #ED,#71     ; OUT   (C),0
        INC     A
        CP      D
        JR      NZ,Rout1
        LD      B,E
        OUT     (C),A
        LD      A,(HL)
        AND     A
        RET     M
        LD      BC,#F6C0
        OUT     (C),C
        DB      #ED,#71     ; OUT   (C),0
        LD      B,E
        OUT     (C),A
        LD      BC,#F680
        OUT     (C),C
        DB      #ED,#71     ; OUT   (C),0
        RET

NTBL:

        DW      #10E0, #0FD0, #0F10, #0E10, #0D50, #0C90
        DW      #0BE0, #0B30, #0A90, #0A00, #0960, #08E0

VARS

DelyCnt DB 0

PsInSm  EQU     0
PsInOr  EQU     1
CrTnSl  EQU     2
Flags   EQU     4
TSlStp  EQU     5
SamPtr  EQU     7
OrnPtr  EQU     9
SlToNt  EQU     11
Note    EQU     12
TnDelt  EQU     13
Skip    EQU     15
SkpCnt  EQU     16
Volume  EQU     17
Env_En  EQU     18
AddToN  EQU     19

ChanA   DS      21
ChanB   DS      21
ChanC   DS      21

AYREGS  DS      14

Ampl    EQU     AYREGS+AmplC

VT_     DS      256

VAR0END EQU     VT_+16 ;zeroing area end

EMPTYORN EQU    VT_+31 ;1,0,0 sequence

NT_     DS      192

