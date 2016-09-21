Option Strict On
Imports System
Imports System.IO
'Imports System.Management

'Imports System.Net
'Imports System.Runtime.InteropServices
'Imports System.Text


Public Class frmMain
    Dim DummyData(80) As String                 'デバッグ用ダミーデータ
    Dim DummyDataCounter As Long = 0            'デバッグ用ダミーデーターカウンター
    Public GetData(80) As String                'PLCから読込んだデータを項目毎に分割＆フォーマットしたもの
    Public OldData(80) As String                'デバッグ用
    Dim Datacounter As Long = 0                 '通し番号
    Public StackData(200, 80) As String         '直近n=100個分データ
    Public StackCounter As Integer = 0          '保存データカウンター
    Public ItemName(59) As String               '表の項目名
    Public ItemWidth(59) As Integer             '表の幅
    Public ItemCheck(59) As Boolean             '表の表示するorしない
    Public ItemSelect(59) As Integer            '表の項目
    'メイン画面歩留集計表
    Public TotalCount(2) As Integer             'ch毎測定数
    Public PassCount(2) As Integer              'ch毎良品数
    'メイン画面項目別集計表
    Public TotalMeasCount(41) As Integer        '項目毎測定数（直近100個）
    Public PassMeasCount(41) As Integer         '項目毎良品数（直近100個）
    Public FullTotalMeasCount(41) As Integer    '項目毎測定数
    Public FullPassMeasCount(41) As Integer     '項目毎良品数
    Public SumValue(41) As Double               '平均値算出用測定値総合計
    Public TypeData(9, 29) As String            '各機種規格データ
    Public TypeCode As Integer                  '機種コード
    Public HistInitFlag1 As Boolean = False     '分布図1初期化済フラグ
    Public HistInitFlag2 As Boolean = False     '分布図2初期化済フラグ
    Public HistInitFlag3 As Boolean = False     '分布図3初期化済フラグ

    Public SaveFolder As String = "C:\DCS\DATA" 'CSVファイル保存先ホルダ
    Public SaveSubFolder As String = ""         'CSVファイル保存先サブホルダ
    Public SaveFileName As String = ""          'CSVファイル名
    Public PassWord As String                   'パスワード
    Public PassWordFlag As Boolean = False      'パスワード解除フラグ

    Public YieldViewFirstFlag As Boolean = True 'DGV初回フラグ(ch毎歩留表示)
    Public DataViewFirstFlag As Boolean = True  'DGV初回フラグ(項目毎歩留表示)
    Public SheetFirstFlag As Boolean = True     'DGV初回フラグ(総合データシート表示)
    Public Sheet1FirstFlag As Boolean = True    'DGV初回フラグ(ch1データシート表示)
    Public Sheet2FirstFlag As Boolean = True    'DGV初回フラグ(ch2データシート表示)
    Public Sheet3FirstFlag As Boolean = True    'DGV初回フラグ(ch3データシート表示)
    Public StartFlag As Boolean = False         '収集開始フラグ
    Public DummyDataFlag As Boolean = True        'デバッグ用ダミーデータ使用フラグ
    Public DebugFlag As Boolean = True   'デバッグモードフラグ
    Public PlcMonitorFlag As Boolean = False    'PLCモニターフラグ

    Public LimOVLo As Single = 0    '収集該当機種OV下限規格値
    Public LimOVHi As Single = 0    '収集該当機種OV上限規格値
    Public LimRVLo As Single = 0    '収集該当機種RV下限規格値
    Public LimRVHi As Single = 0    '収集該当機種RV上限規格値
    Public LimNOLo As Single = 0    '収集該当機種NO下限規格値
    Public LimNOHi As Single = 0    '収集該当機種NO上限規格値
    Public LimNCLo As Single = 0    '収集該当機種NC下限規格値
    Public LimNCHi As Single = 0    '収集該当機種NC上限規格値
    Public LimCGLo As Single = 0    '収集該当機種CG下限規格値
    Public LimCGHi As Single = 0    '収集該当機種CG上限規格値
    Public LimTOLo As Single = 0    '収集該当機種TO下限規格値
    Public LimTOHi As Single = 0    '収集該当機種TO上限規格値
    Public LimCRLo As Single = 0    '収集該当機種CR下限規格値
    Public LimCRHi As Single = 0    '収集該当機種CR上限規格値

    Public Const PlcDataAddress As Long = 11000                 'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ データ有無
    Public Const LinkAddressPlcDataGetOk As Long = 11998        'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ PLC読込み許可フラグ
    Public Const LinkAddressPlcDataGetOkClear As Long = 11999   'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ PLC読込み完了フラグクリア依頼
    Public Const LinkAddressPlcDataGet As Long = 12000          'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ PLC読込み完了フラグ
    Public Const LinkAddressAppStart As Long = 12001            'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ PCｱﾌﾟﾘ起動中ﾊﾟﾙｽ
    Public Const LinkAddressBufferClear As Long = 12002         'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ PLCﾃﾞｰﾀﾊﾞｯﾌｧｰｸﾘｱﾄﾘｶﾞ
    Public Const LinkAddressPlcMonitor As Long = 12003          'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ PLCﾓﾆﾀｰ動作ﾌﾗｸﾞ
    Public Const LinkAddressPlcInitialize As Long = 12004       'ｺﾝﾄﾛｰﾗﾘﾝｸ通信用DMｱﾄﾞﾚｽ PLC初期化ﾄﾘｶﾞ

    Public AlarmLevel1 As Single    '総歩留警報ﾚﾍﾞﾙ
    Public AlarmLevel2 As Single    '総歩留異常ﾚﾍﾞﾙ

    Public D10000(100) As String        'PLCﾓﾆﾀｰ用
    Public D13450(100) As String
    Public D13500(100) As String
    Public St1a(100) As String
    Public St2a(100) As String
    Public St3a(100) As String
    Public St5a(100) As String
    Public St6a(100) As String
    Public TmpArea1(100) As String
    Public StackArea1(100) As String
    'Public St1b(100) As String
    'Public St2b(100) As String
    'Public St3b(100) As String
    'Public St5b(100) As String
    'Public St6b(100) As String
    'Public TmpArea2(100) As String
    'Public StackArea2(100) As String

    Public ssumx As Double = 0
    Public Scnt As Integer = 0
    Public sxx As String = ""

    Public SoukanMode As Boolean = False
    Public SoukanData(20) As String

    Public GraphSelect As Boolean = True
    Public TrCounter(30) As Long
    Public TrData(37, 1000) As Single
    Public TrAve As Integer = 10
    Public TrCo As Long
    Public Gouki As Integer

    Public Function AscCng4(a As String) As String
        If a <> "" Then
            Select Case a
                Case "FEFF"
                    a = "--"
                Case "DDDD"
                    a = "DD"
                Case "EEEE"
                    a = "EE"
                Case "FFFF"
                    a = "FF"
                Case Else
                    If Strings.Left(a, 3) = "000" Then
                        a = "x" + Strings.Right(a, 1)
                    Else
                        Dim a1 As String = Strings.Left(a, 2)
                        Dim a2 As String = Strings.Right(a, 2)
                        If Val("&h" + a1) > &H29 And Val("&h" + a1) < &H40 Then a1 = Chr(CInt("&h" + a1))
                        If Val("&h" + a2) > &H29 And Val("&h" + a2) < &H40 Then a2 = Chr(CInt("&h" + a2))
                        a = a1 + a2
                    End If
            End Select
        End If
        AscCng4 = a
    End Function

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize()                            '初期設定
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        cbxAve.Visible = False
        Label10.Visible = False
        If DebugFlag = False Then
            PlcWrite(LinkAddressPlcInitialize, 1)   'PLC初期化開始
        End If
        TypeCode = 0                            '機種コード設定
        LoadSettingData()                       'データシート設定
        LoadTypeData()                          '機種情報設定
        LoadAlarmLevel()                        'アラームレベル設定
        LoadGouki()                             '号機設定
        InitFileSystem()                        'ファイルシステム設定
        LoadPassword()                          'パスワード設定
        DGVClear(Sheet)                         '総合ﾃﾞｰﾀｼｰﾄDGVｸﾘｱ
        DGVClear(dgvYield)                      'ch毎歩留表示DGVｸﾘｱ
        SheetInit()                             '総合ﾃﾞｰﾀｼｰﾄ初期設定
        HistInit()                              'ﾒｲﾝHist初期設定
        If DebugFlag = False Then
            PlcWrite(LinkAddressPlcDataGet, 0)      'PLC読込完了ﾌﾗｸﾞ ﾘｾｯﾄ
            PlcWrite(LinkAddressAppStart, 0)        'PCｱﾌﾟﾘ起動中ﾊﾟﾙｽ ﾘｾｯﾄ
            PlcWrite(LinkAddressPlcMonitor, 0)      'PCｱﾌﾟﾘ起動中ﾊﾟﾙｽ ﾘｾｯﾄ
            PlcWrite(LinkAddressPlcInitialize, 0)   'PLC初期化終了
        End If
        frmHist1.HistInit1()                    '分布図1表示準備
        frmHist2.HistInit2()                    '分布図2表示準備
        frmHist3.HistInit3()                    '分布図3表示準備
        txtType.Text = Trim(Str(TypeCode))      '機種コード表示
        txtName.Text = TypeData(TypeCode, 1)    '機種名表示
        SaveTitle()                             '保存CSVファイルの先頭に項目名を入れる
        If SoukanMode Then
            PlcWrite(12004, 1)
        End If
    End Sub

    Public Sub PlcMonitor()
        Dim tmp1 As String
        '搬送PLCｺﾝﾄﾛｰﾗｰﾘﾝｸ通信エリア
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 10000, 50))
        For i As Integer = 0 To 49
            D10000(i) = AscCng4(Strings.Mid(tmp1, i * 4 + 1, 4))
        Next
        '計測器データ受信エリア
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11200, 50))
        For i As Integer = 0 To 49
            D13450(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        'シフトエリアＳＴ４
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11250, 50))
        For i As Integer = 0 To 49
            St1a(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        'シフトエリアＳＴ２
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11300, 50))
        For i As Integer = 0 To 49
            St2a(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        'シフトエリアＳＴ３
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11350, 50))
        For i As Integer = 0 To 49
            St3a(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        'シフトエリアＳＴ５
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11400, 50))
        For i As Integer = 0 To 49
            St5a(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        'シフトエリアＳＴ６
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11900, 50))
        For i As Integer = 0 To 49
            St6a(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        'ＴＭＰエリア
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11450, 50))
        For i As Integer = 0 To 49
            TmpArea1(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        'スタックエリア先頭
        tmp1 = CStr(SysmacCJ1.ReadMemory(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11500, 50))
        For i As Integer = 0 To 49
            StackArea1(i) = AscCng4(Strings.Mid(tmp1, i * 8 + 1, 4)) + AscCng4(Strings.Mid(tmp1, i * 8 + 5, 4))
        Next
        frmPlcMonitor.PM()
    End Sub

    Public Sub Main()
        'データ取得
        If DummyDataFlag = True Then
            StackCounter += 1
            GetDummyData()
        ElseIf DebugFlag = True Then
            StackCounter += 1
            GetPlcData()
        ElseIf PlcRead(PlcDataAddress) = 1 And PlcRead(LinkAddressPlcDataGetOk) = 1 And PlcRead(LinkAddressPlcDataGetOkClear) = 0 Then
            StackCounter += 1
            GetPlcData()
            PlcWrite(LinkAddressPlcDataGet, 1)
        Else
            Exit Sub
        End If
        'スタック変数へデータ転送
        For i As Integer = 0 To 74
            StackData(StackCounter, i) = GetData(i)
        Next
        'データ保存
        SaveData()
        'データ数１００以上ならばデータシフト
        If StackCounter > 100 Then
            StackDataShift()
            StackCounter = 100
        End If

        YieldCalc()    '歩留集計-
        DataCalc2()    '測定値集計
        'データシート表示
        Dim a As Integer = Sheet.FirstDisplayedScrollingRowIndex
        Dim a1 As Integer = frmSheet1.Sheet1.FirstDisplayedScrollingRowIndex
        Dim a2 As Integer = frmSheet2.Sheet2.FirstDisplayedScrollingRowIndex
        Dim a3 As Integer = frmSheet3.Sheet3.FirstDisplayedScrollingRowIndex
        DataSheet()
        frmSheet1.DataSheet1()
        frmSheet2.DataSheet2()
        frmSheet3.DataSheet3()
        If a < 1 Then a = 1
        If a1 < 1 Then a1 = 1
        If a2 < 1 Then a2 = 1
        If a3 < 1 Then a3 = 1
        Sheet.FirstDisplayedScrollingRowIndex = a
        frmSheet1.Sheet1.FirstDisplayedScrollingRowIndex = a1
        frmSheet2.Sheet2.FirstDisplayedScrollingRowIndex = a2
        frmSheet3.Sheet3.FirstDisplayedScrollingRowIndex = a3
        YieldView()    '歩留集計表示
        DataView()     '測定値集計表示
        If GraphSelect Then
            HistMain()     '分布表示
        Else
            Transition()    '推移表示
        End If
        frmHist1.HistMain1()
        frmHist2.HistMain2()
        frmHist3.HistMain3()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If StartFlag Then
            StartFlag = False
            btnStart.Text = "START"
            If DebugFlag = False Then
                PlcWrite(LinkAddressAppStart, 0)
            End If
        Else
            StartFlag = True
            btnStart.Text = "STOP"
            If DebugFlag = False Then
                PlcWrite(LinkAddressAppStart, 1)
            End If
        End If
    End Sub

    Public Sub HistInit()
        With cbxCh0
            .Items.Add("Total")
            .Items.Add("Ch-1")
            .Items.Add("Ch-2")
            .Items.Add("Ch-3")
        End With
        cbxCh0.Text = "Total"
        With cbxItem0
            .Items.Add("OV")
            .Items.Add("RV")
            .Items.Add("NO")
            .Items.Add("NC")
            .Items.Add("CG")
            .Items.Add("TS")
            .Items.Add("CR")
        End With
        cbxItem0.Text = "OV"
        With cbxAve
            .Items.Add("1")
            .Items.Add("2")
            .Items.Add("5")
            .Items.Add("10")
            .Items.Add("20")
            .Items.Add("50")
            .Items.Add("100")
        End With
        cbxAve.Text = "10"
    End Sub

    Public Sub HistMain()
        cbxAve.Visible = False
        Label10.Visible = False
        Dim ch As Integer = cbxCh0.SelectedIndex                    'Ch取得
        Dim Item As Integer = cbxItem0.SelectedIndex                '項目取得
        Dim ll As Single = CSng(TypeData(TypeCode, Item * 4 + 2))   '下限規格値取得
        Dim hl As Single = CSng(TypeData(TypeCode, Item * 4 + 3))   '上限規格値取得
        Dim gl As Single = CSng(TypeData(TypeCode, Item * 4 + 4))   'グラフ下限値取得
        Dim gh As Single = CSng(TypeData(TypeCode, Item * 4 + 5))   'グラフ上限値取得
        Dim Div As Single = (gh - gl) / 20                          '分割幅取得
        Dim HistL(20) As Integer
        Dim HistR(20) As Integer
        Dim DataL(300) As Single    '有効データL
        Dim DataR(300) As Single    '有効データR
        Dim ValidL As Integer = 0   '有効データ数L
        Dim ValidR As Integer = 0   '有効データ数R
        '分布元データ取得
        For i As Integer = 1 To StackCounter
            For j As Short = 0 To 2
                Select Case Item
                    Case 0, 1
                        If ch = 0 Or ch = 3 Then
                            If StackData(i, Item * 6 + j * 2 + 40) <> "--" And MathCheck(StackData(i, Item * 6 + j * 2 + 6)) = True Then
                                ValidL += 1
                                DataL(ValidL) = CSng(StackData(i, Item * 6 + j * 2 + 6))
                            End If
                            If StackData(i, Item * 6 + j * 2 + 41) <> "--" And MathCheck(StackData(i, Item * 6 + j * 2 + 7)) = True Then
                                ValidR += 1
                                DataR(ValidR) = CSng(StackData(i, Item * 6 + j * 2 + 7))
                            End If
                        End If
                    Case 5
                        If ch = 0 Or ch = 3 Then
                            If StackData(i, Item * 6 + 40) <> "--" And MathCheck(StackData(i, Item * 6 + 6)) = True Then
                                ValidL += 1
                                DataL(ValidL) = CSng(StackData(i, Item * 6 + 6))
                            End If
                            If StackData(i, Item * 6 + 41) <> "--" And MathCheck(StackData(i, Item * 6 + 7)) = True Then
                                ValidR += 1
                                DataR(ValidR) = CSng(StackData(i, Item * 6 + 7))
                            End If
                        End If
                    Case Else
                        If ch = 0 Or (ch = j + 1) Then
                            If StackData(i, Item * 6 + j * 2 + 40) <> "--" And MathCheck(StackData(i, Item * 6 + j * 2 + 6)) = True Then
                                ValidL += 1
                                DataL(ValidL) = CSng(StackData(i, Item * 6 + j * 2 + 6))
                            End If
                            If StackData(i, Item * 6 + j * 2 + 41) <> "--" And MathCheck(StackData(i, Item * 6 + j * 2 + 7)) = True Then
                                ValidR += 1
                                DataR(ValidR) = CSng(StackData(i, Item * 6 + j * 2 + 7))
                            End If
                        End If
                End Select
            Next j
            'For j As Integer = 0 To 2
            '    If (((Item = 0 Or Item = 1) And j < 2) Or ((Item = 0 Or Item = 1) And ch < 3 And ch > 0)) Or _
            '            (Item > 1 And ch = 1 And j <> 0) Or _
            '            (Item > 1 And ch = 2 And j <> 1) Or _
            '            (Item > 1 And ch = 3 And j <> 2) Then
            '    Else
            '        If StackData(i, Item * 6 + j * 2 + 40) <> "--" And MathCheck(StackData(i, Item * 6 + j * 2 + 6)) = True Then
            '            ValidL += 1
            '            Dim xy As String = StackData(i, Item * 6 + j * 2 + 40)
            '            Dim xx As String = StackData(i, Item * 6 + j * 2 + 6)
            '            DataL(ValidL) = CSng(StackData(i, Item * 6 + j * 2 + 6))
            '        End If
            '        If StackData(i, Item * 6 + j * 2 + 41) <> "--" And MathCheck(StackData(i, Item * 6 + j * 2 + 7)) = True Then
            '            ValidR += 1
            '            DataR(ValidR) = CSng(StackData(i, Item * 6 + j * 2 + 7))
            '        End If
            '    End If
            'Next j
        Next i
        '表示用分布データ作成
        For i As Integer = 1 To ValidL
            For j As Integer = 1 To 20
                If gl + Div * j > DataL(i) Then
                    HistL(j) += 1
                    Exit For
                ElseIf j = 20 Then
                    HistL(j) += 1
                End If
            Next
        Next
        For i As Integer = 1 To ValidR
            For j As Integer = 1 To 20
                If gl + Div * j > DataR(i) Then
                    HistR(j) += 1
                    Exit For
                ElseIf j = 20 Then
                    HistR(j) += 1
                End If
            Next
        Next
        '分布図スケール初期設定
        Dim Rx As Single = CSng(picHist0.Size.Width / 1000)
        Dim Ry As Single = CSng(picHist0.Size.Height / 1000)
        Dim Pen1 As Pen = New Pen(Color.Black, 1)
        Dim g As Graphics = picHist0.CreateGraphics
        g.Clear(Color.White)
        ''外枠を描く
        g.DrawRectangle(Pen1, 0, 0, Rx * 1000 - 1, Ry * 1000 - 1)
        g.DrawRectangle(Pen1, Rx * 100, Ry * 100, Rx * 800, Ry * 800)
        'Ｘ軸分割線を描く
        For i As Integer = 1 To 19
            Dim x1 As Single = Rx * 100 + (Rx * 800 / 20) * i
            g.DrawLine(Pen1, x1, Ry * 870, x1, Ry * 900)
        Next i
        'Ｘ軸分割数値を表示
        Dim ds As String = ColumnSetDecimal(gl, 1)
        Dim df As New Font("ＭＳゴシック", 8)
        Dim db As New SolidBrush(Color.Black)
        g.DrawString(ColumnSetDecimal(gl, 1), df, db, Rx * 80, Ry * 910)
        g.DrawString(ColumnSetDecimal(gh, 1), df, db, Rx * 880, Ry * 910)
        Select Case Item
            Case 0 To 1
                g.DrawString("[V]", df, db, Rx * 870, Ry * 950)
            Case 2 To 3
                g.DrawString("[x9.8mN]", df, db, Rx * 870, Ry * 950)
            Case Else
                g.DrawString("[mm]", df, db, Rx * 870, Ry * 950)
        End Select
        For i As Integer = 2 To 19 Step 2
            Dim x1 As Single = Rx * 80 + (Rx * 800 / 20) * i
            If Item = 4 Then
                g.DrawString(ColumnSetDecimal(gl + Div * i, 2), df, db, x1 - 10, Ry * 910)
            Else
                g.DrawString(ColumnSetDecimal(gl + Div * i, 1), df, db, x1, Ry * 910)
            End If
        Next i
        '一番大きいセグメントを調べる
        Dim HistLMax As Integer = HistL(0)
        Dim HistRMax As Integer = HistR(0)
        For i As Integer = 1 To 19
            If HistLMax < HistL(i) Then HistLMax = HistL(i)
            If HistRMax < HistR(i) Then HistRMax = HistR(i)
        Next
        'Ｙ軸の分割数を決める
        Dim tmp0 As Single = 0
        Dim Tmp1 As Single = 0
        Dim tmp2 As Single = 0
        If ValidL = 0 Then Tmp1 = 0 Else Tmp1 = CSng(HistLMax / ValidL)
        If ValidR = 0 Then tmp2 = 0 Else tmp2 = CSng(HistRMax / ValidR)
        'Dim Tmp1 As Single = CSng(HistLMax / ValidL)
        'Dim tmp2 As Single = CSng(HistRMax / ValidR)
        '
        Dim ValidMax As Integer = 0
        If Tmp1 > tmp2 Then
            tmp0 = Tmp1
            ValidMax = ValidL
        Else
            tmp0 = tmp2
            ValidMax = ValidR
        End If
        Dim YaxisUpper As Integer = 0
        If tmp0 > 0.8 Then
            YaxisUpper = 100
        ElseIf tmp0 > 0.6 Then
            YaxisUpper = 80
        ElseIf tmp0 > 0.4 Then
            YaxisUpper = 60
        ElseIf tmp0 > 0.2 Then
            YaxisUpper = 40
        Else
            YaxisUpper = 20
        End If
        'Ｙ軸分割数値を表示
        g.DrawLine(Pen1, Rx * 100, Ry * 300, Rx * 900, Ry * 300)
        g.DrawLine(Pen1, Rx * 100, Ry * 500, Rx * 900, Ry * 500)
        g.DrawLine(Pen1, Rx * 100, Ry * 700, Rx * 900, Ry * 700)
        If YaxisUpper > 90 Then
            g.DrawString(Str(YaxisUpper), df, db, Rx * 32, Ry * 90)
        Else
            g.DrawString(Str(YaxisUpper), df, db, Rx * 50, Ry * 90)
        End If
        g.DrawString("[%]", df, db, Rx * 55, Ry * 35)
        For i As Integer = 1 To 3
            Dim Tmp3 As Single = CSng((YaxisUpper / 4) * i)
            If Tmp3 < 10 Then
                g.DrawString(Str(Math.Abs(Tmp3)), df, db, Rx * 73, Ry * (880 - 200 * i))
            Else
                g.DrawString(Str(Math.Abs(Tmp3)), df, db, Rx * 50, Ry * (880 - 200 * i))
            End If
        Next i
        'ヒストデータ表示
        Dim Digit As Single = CSng(ValidMax * (YaxisUpper / 100))
        Dim PenL As Pen = New Pen(Color.DarkOliveGreen, Rx * 15)
        Dim PenR As Pen = New Pen(Color.DarkOrange, Rx * 15)
        For i As Integer = 1 To 20
            Dim a1 As Integer = HistL(i)
            If HistL(i) > 0 Then
                Dim x1 As Single = CSng(100 + (800 / 20) * (i - 1) + 10)
                g.DrawLine(PenL, Rx * x1, Ry * 899, Rx * x1, Ry * (800 - (HistL(i) / Digit) * 800 + 99))
            End If
            If Item <> 5 Then
                If HistR(i) > 0 Then
                    Dim x1 As Single = CSng(100 + (800 / 20) * (i - 1) + 30)
                    g.DrawLine(PenR, Rx * x1, Ry * 899, Rx * x1, Ry * (800 - (HistR(i) / Digit) * 800 + 99))
                End If
            End If
        Next
        '規格範囲線を描く
        Dim x2 As Single = (800 / (gh - gl)) * (ll - gl) + 100
        g.DrawLine(Pen1, Rx * x2, Ry * 899, Rx * x2, Ry * 200)
        g.DrawLine(Pen1, Rx * (x2 + 50), Ry * 200, Rx * x2, Ry * 200)
        g.DrawString(ColumnSetDecimal(ll, 2), df, db, Rx * (x2 - 20), Ry * 135)
        x2 = (800 / (gh - gl) * (hl - gl)) + 100
        g.DrawLine(Pen1, Rx * x2, Ry * 899, Rx * x2, Ry * 200)
        g.DrawLine(Pen1, Rx * (x2 - 50), Ry * 200, Rx * x2, Ry * 200)
        g.DrawString(ColumnSetDecimal(hl, 2), df, db, Rx * (x2 - 20), Ry * 135)
    End Sub

    Public Sub Transition()
        cbxAve.Visible = True
        Label10.Visible = True
        Dim ch As Integer = cbxCh0.SelectedIndex                    'Ch取得
        Dim Item As Integer = cbxItem0.SelectedIndex                '項目取得
        Dim ll As Single = CSng(TypeData(TypeCode, Item * 4 + 2))   '下限規格値取得
        Dim hl As Single = CSng(TypeData(TypeCode, Item * 4 + 3))   '上限規格値取得
        Dim gl As Single = CSng(TypeData(TypeCode, Item * 4 + 4))   'グラフ下限値取得
        Dim gh As Single = CSng(TypeData(TypeCode, Item * 4 + 5))   'グラフ上限値取得
        Dim Div As Single = (gh - gl) / 20                          '分割幅取得
        '分布図スケール初期設定
        Dim Rx As Single = CSng(picHist0.Size.Width / 1000)
        Dim Ry As Single = CSng(picHist0.Size.Height / 1000)
        Dim Pen1 As Pen = New Pen(Color.Black, 1)
        Dim g As Graphics = picHist0.CreateGraphics
        g.Clear(Color.White)
        ''外枠を描く
        g.DrawRectangle(Pen1, 0, 0, Rx * 1000 - 1, Ry * 1000 - 1)
        g.DrawRectangle(Pen1, Rx * 100, Ry * 100, Rx * 800, Ry * 800)
        'Ｘ軸分割線を描く
        For i As Integer = 1 To 8
            Dim x1 As Single = Rx * 100 + (Rx * 800 / 8) * i
            g.DrawLine(Pen1, x1, Ry * 870, x1, Ry * 900)
        Next i
        'Ｘ軸分割数値を表示
        Dim ds As String = ColumnSetDecimal(gl, 1)
        Dim df As New Font("ＭＳゴシック", 8)
        Dim db As New SolidBrush(Color.Black)
        g.DrawString("0", df, db, Rx * 80, Ry * 910)
        g.DrawString("[x100cyc]", df, db, Rx * 820, Ry * 950)
        For i As Integer = 1 To 8
            Dim x1 As Long = CLng(Rx * 80 + (Rx * 800 / 8) * i)
            g.DrawString(Str(i), df, db, x1, Ry * 910)
        Next i
        '規格範囲線を描く
        Dim y2 As Single = 900 - (800 / (gh - gl)) * (ll - gl)
        g.DrawLine(Pen1, Rx * 100, Ry * y2, Rx * 800, Ry * y2)
        g.DrawLine(Pen1, Rx * 800, Ry * y2, Rx * 800, Ry * y2 - 20)
        g.DrawString(ColumnSetDecimal(ll, 2), df, db, Rx * 810, Ry * y2 - 5)
        y2 = 900 - (800 / (gh - gl)) * (hl - gl)
        g.DrawLine(Pen1, Rx * 100, Ry * y2, Rx * 800, Ry * y2)
        g.DrawLine(Pen1, Rx * 800, Ry * y2, Rx * 800, Ry * y2 + 20)
        g.DrawString(ColumnSetDecimal(hl, 2), df, db, Rx * 810, Ry * y2 - 10)
        'Ｘ軸分割線を描く
        For i As Integer = 1 To 19
            Dim y1 As Single = Ry * 100 + (Ry * 800 / 20) * i
            g.DrawLine(Pen1, Rx * 100, y1, Rx * 130, y1)
        Next i
        'Ｘ軸分割数値を表示
        Dim dsx As String = ColumnSetDecimal(gl, 1)
        Dim dfx As New Font("ＭＳゴシック", 8)
        Dim dbx As New SolidBrush(Color.Black)
        g.DrawString(ColumnSetDecimal(gl, 2), dfx, dbx, Rx * 35, Ry * 880)
        g.DrawString(ColumnSetDecimal(gh, 2), dfx, dbx, Rx * 35, Ry * 80)
        Select Case Item
            Case 0 To 1
                g.DrawString("[V]", dfx, dbx, Rx * 40, Ry * 35)
            Case 2 To 3
                g.DrawString("[x9.8mN]", dfx, dbx, Rx * 40, Ry * 35)
            Case Else
                g.DrawString("[mm]", dfx, dbx, Rx * 40, Ry * 35)
        End Select
        For i As Integer = 2 To 19 Step 2
            Dim y1 As Single = Ry * 80 + (Ry * 800 / 20) * (20 - i)
            g.DrawString(ColumnSetDecimal(gl + Div * i, 2), dfx, dbx, Rx * 35, y1)
        Next i
        '
        Dim PenL As Pen = New Pen(Color.DarkOliveGreen, Rx * 3)
        Dim PenR As Pen = New Pen(Color.DarkOrange, Rx * 3)
        If TrCo > 2 Then
            Dim Digit As Single = 800 / (gh - gl)
            'Digit = 1
            Dim L0 As Single
            Dim L1 As Single
            Dim R0 As Single
            Dim R1 As Single
            Dim XL0 As Single
            Dim XL1 As Single
            Dim XR0 As Single
            Dim XR1 As Single
            If ch = 0 Then
                For i As Integer = 1 To CInt(TrCo - 1)
                    If Item = 0 Or Item = 1 Or Item = 5 Then
                        If Item = 5 Then
                            L0 = TrData(Item * 6 + 0 + 6, i - 1)
                            L1 = TrData(Item * 6 + 0 + 6, i)
                            'R0 = TrData(Item * 6 + 1 + 6, i - 1)
                            'R1 = TrData(Item * 6 + 1 + 6, i)
                        Else
                            L0 = TrData(Item * 6 + 4 + 6, i - 1)
                            L1 = TrData(Item * 6 + 4 + 6, i)
                            R0 = TrData(Item * 6 + 5 + 6, i - 1)
                            R1 = TrData(Item * 6 + 5 + 6, i)
                        End If
                    Else
                        L0 = (TrData(Item * 6 + 6, i - 1) + TrData(Item * 6 + 2 + 6, i - 1) + TrData(Item * 6 + 4 + 6, i - 1)) / 3
                        L1 = (TrData(Item * 6 + 6, i) + TrData(Item * 6 + 2 + 6, i) + TrData(Item * 6 + 4 + 6, i)) / 3
                        R0 = (TrData(Item * 6 + 1 + 6, i - 1) + TrData(Item * 6 + 3 + 6, i - 1) + TrData(Item * 6 + 5 + 6, i - 1)) / 3
                        R1 = (TrData(Item * 6 + 1 + 6, i) + TrData(Item * 6 + 3 + 6, i) + TrData(Item * 6 + 5 + 6, i)) / 3
                    End If
                        XL0 = Ry * (900 - (L0 - gl) * Digit)
                        XL1 = Ry * (900 - (L1 - gl) * Digit)
                        XR0 = Ry * (900 - (R0 - gl) * Digit)
                        XR1 = Ry * (900 - (R1 - gl) * Digit)
                        g.DrawLine(PenL, Rx * (100 + i), XL0, Rx * (100 + i + 1), XL1)
                        g.DrawLine(PenR, Rx * (100 + i), XR0, Rx * (100 + i + 1), XR1)
                Next
            Else
                If (Item <> 0 And Item <> 1 And Item <> 5) Or (Item = 0 And ch = 3) Or (Item = 1 And ch = 3) Or (Item = 5 And ch = 3) Then
                    For i As Integer = 1 To CInt(TrCo - 1)
                        If Item = 0 Or Item = 1 Or Item = 5 Then
                            If Item = 5 Then
                                L0 = TrData(Item * 6 + 0 + 6, i - 1)
                                L1 = TrData(Item * 6 + 0 + 6, i)
                                'R0 = TrData(Item * 6 + 1 + 6, i - 1)
                                'R1 = TrData(Item * 6 + 1 + 6, i)
                            Else
                                L0 = TrData(Item * 6 + 4 + 6, i - 1)
                                L1 = TrData(Item * 6 + 4 + 6, i)
                                R0 = TrData(Item * 6 + 5 + 6, i - 1)
                                R1 = TrData(Item * 6 + 5 + 6, i)
                            End If
                        Else
                            L0 = TrData(Item * 6 + (ch - 1) * 2 + 6, i - 1)
                            L1 = TrData(Item * 6 + (ch - 1) * 2 + 6, i)
                            R0 = TrData(Item * 6 + (ch - 1) * 2 + 1 + 6, i - 1)
                            R1 = TrData(Item * 6 + (ch - 1) * 2 + 1 + 6, i)
                        End If
                            XL0 = Ry * (900 - (L0 - gl) * Digit)
                            XL1 = Ry * (900 - (L1 - gl) * Digit)
                            XR0 = Ry * (900 - (R0 - gl) * Digit)
                            XR1 = Ry * (900 - (R1 - gl) * Digit)
                            g.DrawLine(PenL, Rx * (100 + i), XL0, Rx * (100 + i + 1), XL1)
                            g.DrawLine(PenR, Rx * (100 + i), XR0, Rx * (100 + i + 1), XR1)
                    Next
                End If
            End If
        End If
    End Sub

    Public Sub StackDataShift()
        For i As Integer = 1 To 100
            For j As Integer = 0 To 73
                StackData(i, j) = StackData(i + 1, j)
            Next
        Next
    End Sub

    Public Sub DataView()
        If DataViewFirstFlag = True Then
            Call DGVClear(dgvData)
            dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.Columns.Add("0", "項目")
            dgvData.Columns.Add("1", "総数")
            dgvData.Columns.Add("2", "良品")
            dgvData.Columns.Add("3", "％")
            dgvData.Columns.Add("4", "平均")
            dgvData.Columns.Add("5", "σ")
            dgvData.Columns.Add("6", "Cpk")
            dgvData.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvData.Columns(0).Width = 55
            dgvData.Columns(1).Width = 55
            dgvData.Columns(2).Width = 55
            dgvData.Columns(3).Width = 55
            dgvData.Columns(4).Width = 55
            dgvData.Columns(5).Width = 55
            dgvData.Columns(6).Width = 55
            dgvData.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvData.RowHeadersVisible = False
            dgvData.Rows.Add("OV-L")
            dgvData.Rows.Add("OV-R")
            dgvData.Rows.Add("RV-L")
            dgvData.Rows.Add("RV-R")
            dgvData.Rows.Add("NO-L")
            dgvData.Rows.Add("NO-R")
            dgvData.Rows.Add("NC-L")
            dgvData.Rows.Add("NC-R")
            dgvData.Rows.Add("CG-L")
            dgvData.Rows.Add("CG-R")
            dgvData.Rows.Add("TSO")
            dgvData.Rows.Add("CR")
            For i As Integer = 0 To 11
                dgvData.Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvData.Rows(i).Height = 16
            Next i
            dgvData.ScrollBars = ScrollBars.None
            DataViewFirstFlag = False
        End If

        Dim a1 As Integer = 0
        Dim a2 As Integer = 0
        Dim a3 As Integer = 0
        Dim a4 As Integer = 0
        Dim a5 As Double = 0
        Dim a6 As Double = 0
        Dim a7 As Double = 0
        Dim a8 As Double = 0
        Dim a9 As Double = 0
        Dim a10 As Double = 0
        Dim YieldL As String = ""
        Dim YieldR As String = ""
        Dim AverageL As String = ""
        Dim AverageR As String = ""
        Dim SigmaL As String = ""
        Dim SigmaR As String = ""

        For i As Integer = 0 To 6
            Dim ll As Single = CSng(TypeData(TypeCode, i * 4 + 2))
            Dim hl As Single = CSng(TypeData(TypeCode, i * 4 + 3))
            'If i <> 5 Then
            '    a1 = TotalMeasCount(i * 6) + TotalMeasCount(i * 6 + 2) + TotalMeasCount(i * 6 + 4)
            '    a2 = TotalMeasCount(i * 6 + 1) + TotalMeasCount(i * 6 + 3) + TotalMeasCount(i * 6 + 5)
            '    a3 = PassMeasCount(i * 6) + PassMeasCount(i * 6 + 2) + PassMeasCount(i * 6 + 4)
            '    a4 = PassMeasCount(i * 6 + 1) + PassMeasCount(i * 6 + 3) + PassMeasCount(i * 6 + 5)
            '    a5 = SumValue(i * 6) + SumValue(i * 6 + 2) + SumValue(i * 6 + 4)      'SumL
            '    a6 = SumValue(i * 6 + 1) + SumValue(i * 6 + 3) + SumValue(i * 6 + 5)  'SumR
            '    a7 = FullTotalMeasCount(i * 6) + FullTotalMeasCount(i * 6 + 2) + FullTotalMeasCount(i * 6 + 4)
            '    a8 = FullTotalMeasCount(i * 6 + 1) + FullTotalMeasCount(i * 6 + 3) + FullTotalMeasCount(i * 6 + 5)
            '    a9 = FullPassMeasCount(i * 6) + FullPassMeasCount(i * 6 + 2) + FullPassMeasCount(i * 6 + 4)
            '    a10 = FullPassMeasCount(i * 6 + 1) + FullPassMeasCount(i * 6 + 3) + FullPassMeasCount(i * 6 + 5)
            'Else
            '    a1 = TotalMeasCount(i * 6)
            '    a2 = TotalMeasCount(i * 6 + 1)
            '    a3 = PassMeasCount(i * 6)
            '    a4 = PassMeasCount(i * 6 + 1)
            '    a5 = SumValue(i * 6)
            '    a6 = SumValue(i * 6 + 1)
            '    a7 = FullTotalMeasCount(i * 6)
            '    a8 = FullTotalMeasCount(i * 6 + 1)
            '    a9 = FullPassMeasCount(i * 6)
            '    a10 = FullPassMeasCount(i * 6 + 1)
            'End If
            i = i
            Select Case i
                Case 5
                    a1 = TotalMeasCount(30)
                    a3 = PassMeasCount(30)
                    a5 = SumValue(30)
                    a7 = FullTotalMeasCount(30)
                    a9 = FullPassMeasCount(30)
                Case 6
                    a1 = TotalMeasCount(31) + TotalMeasCount(32) + TotalMeasCount(33)
                    a3 = PassMeasCount(31) + PassMeasCount(32) + PassMeasCount(33)
                    a5 = SumValue(31) + SumValue(32) + SumValue(33)      'SumL
                    a7 = FullTotalMeasCount(31) + FullTotalMeasCount(32) + FullTotalMeasCount(33)
                    a9 = FullPassMeasCount(31) + FullPassMeasCount(32) + FullPassMeasCount(33)
                Case Else
                    a1 = TotalMeasCount(i * 6) + TotalMeasCount(i * 6 + 2) + TotalMeasCount(i * 6 + 4)
                    a2 = TotalMeasCount(i * 6 + 1) + TotalMeasCount(i * 6 + 3) + TotalMeasCount(i * 6 + 5)
                    a3 = PassMeasCount(i * 6) + PassMeasCount(i * 6 + 2) + PassMeasCount(i * 6 + 4)
                    a4 = PassMeasCount(i * 6 + 1) + PassMeasCount(i * 6 + 3) + PassMeasCount(i * 6 + 5)
                    a5 = SumValue(i * 6) + SumValue(i * 6 + 2) + SumValue(i * 6 + 4)      'SumL
                    a6 = SumValue(i * 6 + 1) + SumValue(i * 6 + 3) + SumValue(i * 6 + 5)  'SumR
                    a7 = FullTotalMeasCount(i * 6) + FullTotalMeasCount(i * 6 + 2) + FullTotalMeasCount(i * 6 + 4)
                    a8 = FullTotalMeasCount(i * 6 + 1) + FullTotalMeasCount(i * 6 + 3) + FullTotalMeasCount(i * 6 + 5)
                    a9 = FullPassMeasCount(i * 6) + FullPassMeasCount(i * 6 + 2) + FullPassMeasCount(i * 6 + 4)
                    a10 = FullPassMeasCount(i * 6 + 1) + FullPassMeasCount(i * 6 + 3) + FullPassMeasCount(i * 6 + 5)
            End Select
            Select Case i
                Case 5
                    dgvData.Item(1, 10).Value = a7   'TotalCountL
                    dgvData.Item(2, 10).Value = a9   'PassCountL
                Case 6
                    dgvData.Item(1, 11).Value = a7   'TotalCountL
                    dgvData.Item(2, 11).Value = a9   'PassCountL
                Case Else
                    dgvData.Item(1, i * 2).Value = a7   'TotalCountL
                    dgvData.Item(1, i * 2 + 1).Value = a8   'TotalCountR
                    dgvData.Item(2, i * 2).Value = a9   'PassCountL
                    dgvData.Item(2, i * 2 + 1).Value = a10   'PassCountR
            End Select
            If a1 > 0 Then
                'dgvData.Item(3, i * 2).Value = ColumnSetDecimal(CSng(a3 / a1 * 100), 2)
                YieldL = ColumnSetDecimal(CSng(a3 / a1 * 100), 2)
                If i <> 0 And i <> 1 Then
                    If i = 4 Then
                        Scnt = 0
                    End If
                    'Average
                    Dim ave As Single = CSng(a5 / a1)
                    AverageL = ColumnSetDecimal(CSng(ave), 2)
                    'If i <> 6 Then
                    '    dgvData.Item(4, i * 2).Value = ColumnSetDecimal(CSng(ave), 2)
                    'Else
                    '    dgvData.Item(4, 11).Value = ColumnSetDecimal(CSng(ave), 2)
                    'End If
                    'Sigma
                    Dim Ssum As Double = 0
                    Scnt = 0
                    If i <> 6 Then
                        For j As Integer = 1 To StackCounter
                            If StackData(j, i * 6 + 0 + 40) = "OK" Or StackData(j, i * 6 + 0 + 40) = "NG" Then
                                Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 0)) - ave) ^ 2
                                Scnt += 1
                            End If
                            If StackData(j, i * 6 + 2 + 40) = "OK" Or StackData(j, i * 6 + 2 + 40) = "NG" Then
                                Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 2)) - ave) ^ 2
                                Scnt += 1
                            End If
                            If StackData(j, i * 6 + 4 + 40) = "OK" Or StackData(j, i * 6 + 4 + 40) = "NG" Then
                                Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 4)) - ave) ^ 2
                                Scnt += 1
                            End If
                        Next j
                    Else
                        For j As Integer = 1 To StackCounter
                            If StackData(j, 31 + 40) = "OK" Or StackData(j, 31 + 40) = "NG" Then
                                Ssum = Ssum + (Val(StackData(j, 37)) - ave) ^ 2
                                Scnt += 1
                            End If
                            If StackData(j, 32 + 40) = "OK" Or StackData(j, 32 + 40) = "NG" Then
                                Ssum = Ssum + (Val(StackData(j, 38)) - ave) ^ 2
                                Scnt += 1
                            End If
                            If StackData(j, 33 + 40) = "OK" Or StackData(j, 33 + 40) = "NG" Then
                                Ssum = Ssum + (Val(StackData(j, 39)) - ave) ^ 2
                                Scnt += 1
                            End If
                        Next j
                    End If
                    Dim sigma As Single = CSng(Math.Sqrt(Ssum / Scnt))
                    SigmaL = ColumnSetDecimal(CSng(sigma), 2)
                    'Cpk
                    dgvData.Item(6, i * 2).Value = ColumnSetDecimal(Cpk(ll, hl, ave, sigma), 2)
                Else
                    'Average
                    Dim ave As Single = 0
                    If TotalMeasCount(i * 6 + 4) > 0 Then
                        ave = CSng(SumValue(i * 6 + 4) / TotalMeasCount(i * 6 + 4))
                        dgvData.Item(4, i * 2).Value = ColumnSetDecimal(CSng(ave), 2)
                    Else
                        dgvData.Item(4, i * 2).Value = "---"
                    End If
                    'Sigma
                    Dim Ssum As Double = 0
                    Scnt = 0
                    For j As Integer = 1 To StackCounter
                        If StackData(j, i * 6 + 40) = "OK" Or StackData(j, i * 6 + 40) = "NG" Then
                            Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 4)) - ave) ^ 2
                            Scnt += 1
                        End If
                    Next j
                    Dim sigma As Single = CSng(Math.Sqrt(Ssum / Scnt))
                    If sigma > 0 Then
                        dgvData.Item(5, i * 2).Value = ColumnSetDecimal(CSng(sigma), 2)
                        'Cpk
                        dgvData.Item(6, i * 2).Value = ColumnSetDecimal(Cpk(ll, hl, ave, sigma), 2)
                    Else
                        dgvData.Item(5, i * 2).Value = "---"
                        dgvData.Item(6, i * 2).Value = "---"
                    End If
                End If
            End If
            If a2 > 0 And i <> 5 And i <> 6 Then
                dgvData.Item(3, i * 2 + 1).Value = ColumnSetDecimal(CSng(a4 / a2 * 100), 2)
                If i <> 0 And i <> 1 Then
                    'Average
                    Dim ave As Single = CSng(a6 / a2)
                    dgvData.Item(4, i * 2 + 1).Value = ColumnSetDecimal(CSng(ave), 2)
                    'Sigma
                    Dim Ssum As Double = 0
                    Scnt = 0
                    For j As Integer = 1 To StackCounter
                        If StackData(j, i * 6 + 1 + 40) = "OK" Or StackData(j, i * 6 + 1 + 40) = "NG" Then
                            Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 1)) - ave) ^ 2
                            Scnt += 1
                        End If
                        If StackData(j, i * 6 + 3 + 40) = "OK" Or StackData(j, i * 6 + 3 + 40) = "NG" Then
                            Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 3)) - ave) ^ 2
                            Scnt += 1
                        End If
                        If StackData(j, i * 6 + 5 + 40) = "OK" Or StackData(j, i * 6 + 5 + 40) = "NG" Then
                            Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 5)) - ave) ^ 2
                            Scnt += 1
                        End If
                    Next j
                    Dim sigma As Single = CSng(Math.Sqrt(Ssum / Scnt))
                    dgvData.Item(5, i * 2 + 1).Value = ColumnSetDecimal(CSng(sigma), 2)
                    'Cpk
                    dgvData.Item(6, i * 2 + 1).Value = ColumnSetDecimal(Cpk(ll, hl, ave, sigma), 2)
                Else
                    'Average
                    Dim ave As Single = 0
                    If TotalMeasCount(i * 6 + 5) > 0 Then
                        ave = CSng(SumValue(i * 6 + 5) / TotalMeasCount(i * 6 + 5))
                        dgvData.Item(4, i * 2 + 1).Value = ColumnSetDecimal(CSng(ave), 2)
                    Else
                        dgvData.Item(4, i * 2 + 1).Value = "---"
                    End If
                    'Sigma
                    Dim Ssum As Double = 0
                    Scnt = 0
                    For j As Integer = 1 To StackCounter
                        If StackData(j, i * 6 + 1 + 40) = "OK" Or StackData(j, i * 6 + 1 + 40) = "NG" Then
                            Ssum = Ssum + (Val(StackData(j, (i + 1) * 6 + 5)) - ave) ^ 2
                            Scnt += 1
                        End If
                    Next j
                    Dim sigma As Single = CSng(Math.Sqrt(Ssum / Scnt))
                    If sigma > 0 Then
                        dgvData.Item(5, i * 2 + 1).Value = ColumnSetDecimal(CSng(sigma), 2)
                        'Cpk
                        dgvData.Item(6, i * 2 + 1).Value = ColumnSetDecimal(Cpk(ll, hl, ave, sigma), 2)
                    Else
                        dgvData.Item(5, i * 2 + 1).Value = "---"
                        dgvData.Item(6, i * 2 + 1).Value = "---"
                    End If
                End If
            End If
            'Select Case i
            '    Case 6
            '        dgvData.Item(3, 11).Value = YieldL
            '        dgvData.Item(4, 11).Value = AverageL
            '        dgvData.Item(5, 11).Value = SigmaL
            '    Case Else
            '        dgvData.Item(3, i * 2).Value = YieldL
            '        'dgvData.Item(4, i * 2).Value = AverageL
            '        dgvData.Item(5, i * 2).Value = SigmaL
            'End Select
        Next
        '推移グラフ用平均データ取得
        For i As Integer = 6 To 37
            Dim tmp As Single
            Dim co As Integer = 0
            For j As Integer = 0 To TrAve - 1
                If StackCounter - j > 0 Then
                    If MathCheck(StackData(StackCounter - j, i)) = True Then
                        tmp = tmp + CSng(Val(StackData(StackCounter - j, i)))
                        co += 1
                    End If
                End If
            Next j
            If co > 0 Then
                TrData(i, CInt(TrCo)) = tmp / co
            End If
            tmp = 0
            co = 0
        Next i
        '推移グラフ データシフト
        TrCo += 1
        If TrCo > 700 Then
            TrCo = 700
            For i As Integer = 0 To 37
                For j As Integer = 0 To 700
                    TrData(i, j) = TrData(i, j + 1)
                Next
            Next
        End If

    End Sub

    Public Sub DataCalc2()
        For i As Integer = 0 To 36
            TotalMeasCount(i) = 0
            PassMeasCount(i) = 0
            SumValue(i) = 0
        Next
        For i As Integer = 1 To StackCounter
            For j As Integer = 0 To 36
                If StackData(i, 40 + j) <> "--" Then
                    TotalMeasCount(j) += 1
                    If j <> 2 And j <> 3 And j <> 0 And j <> 1 And j <> 8 And j <> 9 And j <> 6 And j <> 7 Then
                        SumValue(j) = SumValue(j) + Val(StackData(i, 6 + j))
                    End If
                    If StackData(i, 40 + j) = "OK" Then
                        PassMeasCount(j) += 1
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub YieldView()
        If YieldViewFirstFlag = True Then
            Call DGVClear(dgvYield)
            dgvYield.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvYield.Columns.Add("0", "ch")
            dgvYield.Columns.Add("1", "総数")
            dgvYield.Columns.Add("2", "良品")
            dgvYield.Columns.Add("3", "％")
            dgvYield.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvYield.Columns(0).Width = 40
            dgvYield.Columns(1).Width = 55
            dgvYield.Columns(2).Width = 55
            dgvYield.Columns(3).Width = 50
            dgvYield.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvYield.RowHeadersVisible = False
            dgvYield.Rows.Add("Ch1")
            dgvYield.Rows.Add("Ch2")
            dgvYield.Rows.Add("Ch3")
            dgvYield.Rows.Add("合計")
            dgvYield.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvYield.Rows(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvYield.Rows(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvYield.Rows(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For i As Integer = 0 To 3
                dgvYield.Rows(i).Height = 16
            Next i
            dgvYield.ScrollBars = ScrollBars.None
            YieldViewFirstFlag = False
        End If
        For i As Integer = 0 To 2
            dgvYield.Item(1, i).Value = TotalCount(i)
            dgvYield.Item(2, i).Value = PassCount(i)
            If TotalCount(i) > 0 Then
                dgvYield.Item(3, i).Value = ColumnSetDecimal(CSng(PassCount(i) / TotalCount(i) * 100), 2)
            End If
        Next
        Dim a1 As Integer = TotalCount(0) + TotalCount(1) + TotalCount(2)
        Dim a2 As Integer = PassCount(0) + PassCount(1) + PassCount(2)
        dgvYield.Item(1, 3).Value = a1
        dgvYield.Item(2, 3).Value = a2
        If a1 > 0 Then
            dgvYield(3, 3).Value = ColumnSetDecimal(CSng(a2 / a1 * 100), 2)
        End If
        If a1 > 0 Then
            Dim TotalYield As Single = CSng(a2 / a1 * 100)
            If TotalYield = 100 Then
                txtYield.BackColor = Color.Azure
                txtYield.ForeColor = Color.Blue
                txtYield.Text = " 100%"
            ElseIf TotalYield > AlarmLevel1 Then
                txtYield.BackColor = Color.Azure
                txtYield.ForeColor = Color.Blue
                txtYield.Text = ColumnSetDecimal(CSng(a2 / a1 * 100), 1) + "%"
            ElseIf TotalYield > AlarmLevel2 Then
                txtYield.BackColor = Color.Yellow
                txtYield.ForeColor = Color.Black
                txtYield.Text = ColumnSetDecimal(CSng(a2 / a1 * 100), 1) + "%"
            Else
                txtYield.BackColor = Color.Red
                txtYield.ForeColor = Color.Yellow
                txtYield.Text = ColumnSetDecimal(CSng(a2 / a1 * 100), 1) + "%"
            End If
        End If
        '進捗ﾓﾆﾀｰへ無調率データ送信
        If DebugFlag = False And a1 > 0 Then
            Dim NonAdjRate As Integer = CInt(a2 / a1 * 10000)
            If NonAdjRate < 0 Or NonAdjRate > &HFFF0 Then NonAdjRate = 0
            PlcWrite(12010, NonAdjRate)
        End If
    End Sub

    Public Sub YieldCalc()
        For i As Integer = 0 To 2
            Select Case StackData(StackCounter, 3 + i)
                Case "Pass"
                    TotalCount(i) += 1
                    PassCount(i) += 1
                Case "Fail"
                    TotalCount(i) += 1
                Case Else
                    '
            End Select
        Next i
        For i As Integer = 0 To 35
            If StackData(StackCounter, 40 + i) <> "--" Then
                FullTotalMeasCount(i) += 1
                If StackData(StackCounter, 40 + i) = "OK" Then
                    FullPassMeasCount(i) += 1
                End If
            End If
        Next
    End Sub

    Public Sub SheetInit()
        Me.Sheet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Dim j As Integer = 0
        For i As Integer = 0 To 39
            If ItemCheck(i) = True Then
                Me.Sheet.Columns.Add(Trim(Str(j)), ItemName(ItemSelect(i)))
                Me.Sheet.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.Sheet.Columns(j).Width = ItemWidth(i)
                j = j + 1
            End If
        Next i
        For i As Integer = 0 To 99
            Sheet.Rows.Add("")
        Next
        For i As Integer = 1 To 100
            Sheet.Rows(i - 1).Height = 16
        Next
        Me.Sheet.RowHeadersVisible = False
    End Sub

    Public Sub DataSheet()
        Sheet.SuspendLayout()
        If SheetFirstFlag = True Then
            Call DGVClear(Sheet)
            Call SheetInit()
            SheetFirstFlag = False
        End If
        'シート表示高速化
        Dim myType As System.Type = GetType(DataGridView)
        Dim myPropertyInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        myPropertyInfo.SetValue(Sheet, True, Nothing)
        Sheet.AllowUserToResizeRows = False '<br />
        Sheet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None '<br />
        Sheet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None '<br />
        Sheet.RowTemplate.Height = 10 '<br />
        'シート表示
        For i As Integer = 1 To StackCounter
            Dim k As Integer = 0
            For j As Integer = 0 To 39
                Dim sn As String
                If ItemCheck(j) Then
                    Dim x As Integer = ItemSelect(j)
                    Dim s As String = StackData(1, 0)
                    sn = Trim(StackData(i, ItemSelect(j)))
                    Sheet.Item(k, i).Value = sn
                    Sheet.Item(k, i).Style.ForeColor = Color.Black
                    Select Case ItemSelect(j)
                        Case 3 To 5
                            If sn <> "Pass" Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 6 To 9, 12 To 15
                            If sn <> "OK" Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 10, 11
                            If Val(sn) < LimOVLo Or Val(sn) > LimOVHi Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 16, 17
                            If Val(sn) < LimRVLo Or Val(sn) > LimRVHi Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 18 To 23
                            If Val(sn) < LimNOLo Or Val(sn) > LimNOHi Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 24 To 29
                            If Val(sn) < LimNCLo Or Val(sn) > LimNCHi Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 30 To 35
                            If Val(sn) < LimCGLo Or Val(sn) > LimCGHi Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 36
                            If Val(sn) < LimTOLo Or Val(sn) > LimTOHi Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                        Case 37 To 39
                            If Val(sn) < LimCRLo Or Val(sn) > LimCRHi Then Sheet.Item(k, i).Style.ForeColor = Color.Red
                    End Select
                    k = k + 1
                End If
            Next
        Next
        Sheet.ResumeLayout()
        Me.Sheet.ScrollBars = ScrollBars.Both
        For i As Integer = 1 To StackCounter
            For j As Integer = 0 To 33
                Dim ax As String = StackData(i, 40 + j)
                Select Case ax
                    Case "OK"
                        If j Mod 2 = 0 Then
                            Sheet.Item(j + 6, i).Style.BackColor = Color.Azure
                        Else
                            Sheet.Item(j + 6, i).Style.BackColor = Color.AntiqueWhite
                        End If
                    Case "NG"
                        Sheet.Item(j + 6, i).Style.BackColor = Color.Aqua
                    Case "--"
                        Sheet.Item(j + 6, i).Style.BackColor = Color.LightGreen
                    Case Else
                        Sheet.Item(j + 6, i).Style.BackColor = Color.LightYellow
                End Select
            Next
        Next
    End Sub

    Public Sub DGVClear(ByVal dgv As DataGridView)
        With dgv
            '列数が>0なら表示されていると判断し、一旦消去(表示速度には影響なし)
            If .Rows.Count > 0 Then
                .Columns.Clear()                          'コレクションを空にします(行・列削除)
                .DataSource = Nothing                     'DataSource に既定値を設定
                .DefaultCellStyle = Nothing               'セルスタイルを初期値に設定
                .RowHeadersDefaultCellStyle = Nothing     '行ヘッダーを初期値に設定
                .RowHeadersVisible = True                 '行ヘッダーを表示
                'フォントの高さ＋9 (フォントサイズ 9 の場合、12+9= 21 となる
                .RowTemplate.Height = 21                  'デフォルトの行の高さを設定(表示後では有効にならない)
                .ColumnHeadersDefaultCellStyle = Nothing  '列ヘッダーを初期値に設定
                .ColumnHeadersVisible = True              '列ヘッダーを表示
                .ColumnHeadersHeight = 23                 '列ヘッダーの高さを既定値に設定
                .TopLeftHeaderCell = Nothing              '左端上端のヘッダーを初期値に設定
                '奇数行に適用される既定のセルスタイルを初期値に設定   
                .AlternatingRowsDefaultCellStyle = Nothing
                'セルの境界線スタイルを初期値(一重線の境界線)に設定
                .AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
                .GridColor = SystemColors.ControlDark     'セルを区切るグリッド線の色を初期値に設定
                .Refresh()                                '再描画
            End If
        End With
        '※ 上記設定は、必要により、追加・削除してください。
    End Sub

    Public Sub SaveTitle()
        Dim Title As String = ""
        For i As Integer = 0 To 39
            Title = Title + ItemName(i) + ","
        Next
        Title = Title + "Type" + vbCrLf
        My.Computer.FileSystem.WriteAllText(SaveFolder + "\" + SaveSubFolder + "\" + "No" + Trim(Str(Gouki)) + "_" + SaveFileName + ".CSV", Title, True)
        My.Computer.FileSystem.WriteAllText(SaveFolder + "\" + SaveSubFolder + "\" + "No" + Trim(Str(Gouki)) + "_" + SaveFileName + ".BKF", Title, True)
    End Sub

    Public Sub SaveData()
        Dim InputString As String = ""
        For i As Integer = 0 To 39
            InputString = InputString + StackData(StackCounter, i) + ","
        Next
        InputString = InputString + Trim(Str(TypeCode)) + vbCrLf
        My.Computer.FileSystem.WriteAllText(SaveFolder + "\" + SaveSubFolder + "\" + "No" + Trim(Str(Gouki)) + "_" + SaveFileName + ".CSV", InputString, True)
        My.Computer.FileSystem.WriteAllText(SaveFolder + "\" + SaveSubFolder + "\" + "No" + Trim(Str(Gouki)) + "_" + SaveFileName + ".BKF", InputString, True)
    End Sub

    Public Sub SaveSoukanData()
        Dim tmp As String
        tmp = SysmacCJ1.ReadMemoryString(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, 11500, 36)
        For i As Integer = 0 To 17
            SoukanData(i) = Strings.Mid(tmp, i * 4 + 1, 4)
        Next
        Dim InputString As String = ""
        For i As Integer = 0 To 17
            InputString = InputString + SoukanData(i) + ","
        Next
        Label12.Text = InputString + "abc"
        InputString = InputString + Trim(Str(TypeCode)) + vbCrLf
        My.Computer.FileSystem.WriteAllText(SaveFolder + "\" + SaveSubFolder + "\" + SaveFileName + "soukan.CSV", InputString, True)
    End Sub

    Public Sub LoadSettingData()
        Dim sr As System.IO.StreamReader
        Dim ofile As String = "C:\DCS\0_DCS_System\SETTING.txt"
        sr = New System.IO.StreamReader(ofile, System.Text.Encoding.GetEncoding(932))
        Try
            Dim b As String
            For i As Integer = 0 To 59
                b = sr.ReadLine()
                If Strings.Left(b, InStr(b, ",") - 1) = "0" Then
                    ItemCheck(i) = False
                Else
                    ItemCheck(i) = True
                End If
                b = Strings.Right(b, Len(b) - InStr(b, ","))
                ItemSelect(i) = CInt(Strings.Left(b, InStr(b, ",") - 1))
                ItemWidth(i) = CInt(Strings.Right(b, Len(b) - InStr(b, ",")))
            Next
            sr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Public Sub LoadTypeData()
        Dim sr As System.IO.StreamReader
        Dim ofile As String = "C:\DCS\0_DCS_System\Type.txt"
        sr = New System.IO.StreamReader(ofile, System.Text.Encoding.GetEncoding(932))
        Try
            Dim b As String
            Dim j As Integer
            Dim a As Integer
            For i As Integer = 0 To 9
                j = 0
                b = sr.ReadLine()
                Do
                    a = InStr(b, ",")
                    If a = 0 Then
                        TypeData(i, j) = b
                        Exit Do
                    End If
                    TypeData(i, j) = Strings.Left$(b, a - 1)
                    b = Strings.Right(b, Len(b) - a)
                    j = j + 1
                Loop
            Next
            sr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
        LimOVLo = CSng(TypeData(TypeCode, 2))
        LimOVHi = CSng(TypeData(TypeCode, 3))
        LimRVLo = CSng(TypeData(TypeCode, 6))
        LimRVHi = CSng(TypeData(TypeCode, 7))
        LimNOLo = CSng(TypeData(TypeCode, 10))
        LimNOHi = CSng(TypeData(TypeCode, 11))
        LimNCLo = CSng(TypeData(TypeCode, 14))
        LimNCHi = CSng(TypeData(TypeCode, 15))
        LimCGLo = CSng(TypeData(TypeCode, 18))
        LimCGHi = CSng(TypeData(TypeCode, 19))
        LimTOLo = CSng(TypeData(TypeCode, 22))
        LimTOHi = CSng(TypeData(TypeCode, 23))
        LimCRLo = CSng(TypeData(TypeCode, 26))
        LimCRHi = CSng(TypeData(TypeCode, 27))
    End Sub

    Public Sub LoadPassword()
        Dim sr As System.IO.StreamReader
        Dim ofile As String = "C:\DCS\0_DCS_System\pw.txt"
        sr = New System.IO.StreamReader(ofile, System.Text.Encoding.GetEncoding(932))
        Try
            PassWord = sr.ReadLine()
            sr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Public Sub LoadAlarmLevel()
        Dim sr As System.IO.StreamReader
        Dim ofile As String = "C:\DCS\0_DCS_System\AlarmLevel.txt"
        sr = New System.IO.StreamReader(ofile, System.Text.Encoding.GetEncoding(932))
        Try
            AlarmLevel1 = CSng(sr.ReadLine())
            AlarmLevel2 = CSng(sr.ReadLine())
            sr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Public Sub LoadGouki()
        Dim sr As System.IO.StreamReader
        Dim ofile As String = "C:\DCS\0_DCS_System\Gouki.txt"
        sr = New System.IO.StreamReader(ofile, System.Text.Encoding.GetEncoding(932))
        Try
            Gouki = CInt(sr.ReadLine())
            sr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Public Sub GetDummyData()
        'No.0：[通し番号]生成
        DummyDataCounter = DummyDataCounter + 1
        DummyData(0) = ColumnSet(Str(DummyDataCounter), 8)
        'No.1：[日付]生成
        Dim year As Integer
        Dim month As Integer
        Dim day As Integer
        year = CInt(Rnd(1) * 30)
        month = CInt((Rnd(1) * 12) + 1)
        day = CInt((Rnd(1) * 30) + 1)
        DummyData(1) = "" + ZeroPat(Str$(year), 2) + "/" + ZeroPat(Str$(month), 2) + "/" + ZeroPat(Str$(day), 2)
        'No.2：[時間]生成
        Dim Hour As Integer
        Dim Minute As Integer
        Dim Second As Integer
        Hour = CInt(Rnd(1) * 24)
        Minute = CInt(Rnd(1) * 60)
        Second = CInt(Rnd(1) * 60)
        DummyData(2) = ZeroPat(Str$(Hour), 2) + ":" + ZeroPat(Str$(Minute), 2) + ":" + ZeroPat(Str$(Second), 2)
        Dim i As Integer
        'No.3～5：[判定ch1～3]生成
        'For i = 3 To 5
        '    DummyData(i) = DummyDataJudge()
        'Next
        'No.6～9:[PV ch2～3L/R(OK/NG)]生成
        For i = 6 To 9
            DummyData(i) = DummyDataOkNg()
            DummyData(40 + i - 6) = DummyData(i)
        Next i
        'No.10～11:[PV ch1L/R(実測値)]生成
        DummyData(10) = ColumnSetDecimal((DummyDataValu(CSng(LimOVLo * 0.995), CSng(LimOVHi * 1.005))), 2)
        DummyData(11) = ColumnSetDecimal((DummyDataValu(CSng(LimOVLo * 0.995), CSng(LimOVHi * 1.005))), 2)
        If LimOVLo <= Val(DummyData(10)) And LimOVHi >= Val(DummyData(10)) Then DummyData(40 + 10 - 6) = "OK" Else DummyData(40 + 10 - 6) = "NG"
        If LimOVLo <= Val(DummyData(11)) And LimOVHi >= Val(DummyData(11)) Then DummyData(40 + 11 - 6) = "OK" Else DummyData(40 + 11 - 6) = "NG"
        'No.12～15:[DV ch2～3L/R(OK/NG)]生成
        For i = 12 To 15
            DummyData(i) = DummyDataOkNg()
            DummyData(40 + i - 6) = DummyData(i)
        Next i
        'No.16～17:[DV ch1L/R(実測値)]生成
        DummyData(16) = ColumnSetDecimal((DummyDataValu(CSng(LimRVLo * 0.995), CSng(LimRVHi * 1.005))), 2)
        DummyData(17) = ColumnSetDecimal((DummyDataValu(CSng(LimRVLo * 0.995), CSng(LimRVHi * 1.005))), 2)
        If LimRVLo <= Val(DummyData(16)) And LimRVHi >= Val(DummyData(16)) Then DummyData(40 + 16 - 6) = "OK" Else DummyData(40 + 16 - 6) = "NG"
        If LimRVLo <= Val(DummyData(17)) And LimRVHi >= Val(DummyData(17)) Then DummyData(40 + 17 - 6) = "OK" Else DummyData(40 + 17 - 6) = "NG"
        'No.18～23:[NOCP ch1～3L/R]生成
        For i = 18 To 23
            DummyData(i) = ColumnSetDecimal((DummyDataValu(CSng(LimNOLo * 0.995), CSng(LimNOHi * 1.005))), 2)
            If LimNOLo <= Val(DummyData(i)) And LimNOHi >= Val(DummyData(i)) Then DummyData(40 + i - 6) = "OK" Else DummyData(40 + i - 6) = "NG"
        Next i
        'No.24～29:[NCCP ch1～3L/R]生成
        For i = 24 To 29
            DummyData(i) = ColumnSetDecimal((DummyDataValu(CSng(LimNCLo * 0.995), CSng(LimNCHi * 1.005))), 2)
            If LimNCLo <= Val(DummyData(i)) And LimNCHi >= Val(DummyData(i)) Then DummyData(40 + i - 6) = "OK" Else DummyData(40 + i - 6) = "NG"
        Next i
        'No.30～35:[CG ch1～3L/R]生成
        For i = 30 To 35
            DummyData(i) = ColumnSetDecimal((DummyDataValu(CSng(LimCGLo * 0.995), CSng(LimCGHi * 1.005))), 2)
            If LimCGLo <= Val(DummyData(i)) And LimCGHi >= Val(DummyData(i)) Then DummyData(40 + i - 6) = "OK" Else DummyData(40 + i - 6) = "NG"
        Next i
        'No.36:[TSO ch3]生成
        DummyData(36) = ColumnSetDecimal((DummyDataValu(CSng(LimTOHi * 0.95), CSng(LimTOHi * 1.002))), 2)
        If LimTOLo <= Val(DummyData(36)) And LimTOHi >= Val(DummyData(36)) Then DummyData(40 + 36 - 6) = "OK" Else DummyData(40 + 36 - 6) = "NG"
        'No.37～39:[CR ch1～3]生成
        For i = 37 To 39
            DummyData(i) = ColumnSetDecimal((DummyDataValu(CSng(LimCRLo * 0.995), CSng(LimCRHi * 1.005))), 1)
            If LimCRLo <= Val(DummyData(i)) And LimCRHi >= Val(DummyData(i)) Then DummyData(40 + i - 6) = "OK" Else DummyData(40 + i - 6) = "NG"
        Next i
        'No.3～5：[判定ch1～3]生成
        Dim judge As Boolean
        For i = 0 To 2
            DummyData(3 + i) = "Pass"
            judge = True
            For j As Integer = 0 To 4
                If DummyData(40 + i * 2 + j * 6) = "NG" Or DummyData(40 + i * 2 + j * 6 + 1) = "NG" Then
                    DummyData(3 + i) = "Fail"
                    Exit For
                End If
            Next
        Next
        If DummyData(70) = "NG" Then DummyData(5) = "Fail"
        If DummyData(71) = "NG" Then DummyData(3) = "Fail"
        If DummyData(72) = "NG" Then DummyData(4) = "Fail"
        If DummyData(73) = "NG" Then DummyData(5) = "Fail"
        For i = 0 To 73
            GetData(i) = DummyData(i)
        Next
        i = i
    End Sub

    Public Function GetDummyData2() As String
        GetDummyData2 = ""
        Dim x(80) As String
        x(0) = DummyDataValu2(250, 740)     'ch3 OV L
        x(1) = DummyDataValu2(250, 740)     'ch3 OV R
        x(2) = DummyDataValu2(50, 530)      'Ch3 RV L
        x(3) = DummyDataValu2(50, 530)      'ch3 RV R
        x(4) = DummyDataValu2(850, 3150)    'ch1 NC L
        x(5) = DummyDataValu2(850, 3150)    'ch1 NC R
        x(6) = DummyDataValu2(2000, 5400)     'ch1 NO L
        x(7) = DummyDataValu2(2000, 5400)     'ch1 NO R
        x(8) = DummyDataValu2(90, 400)        'ch1 CG L
        x(9) = DummyDataValu2(90, 400)        'ch1 CG R
        x(10) = DummyDataValu2(850, 3150)   'ch2 NC L
        x(11) = DummyDataValu2(850, 3150)   'ch2 NC R
        x(12) = DummyDataValu2(2000, 5400)    'ch2 NO L
        x(13) = DummyDataValu2(2000, 5400)    'ch2 NO R
        x(14) = DummyDataValu2(90, 400)       'ch2 CG L
        x(15) = DummyDataValu2(90, 400)       'ch2 CG R
        x(16) = DummyDataValu2(850, 3150)   'ch3 NC L
        x(17) = DummyDataValu2(850, 3150)   'ch3 NC R
        x(18) = DummyDataValu2(2000, 5400)    'ch3 NO L
        x(19) = DummyDataValu2(2000, 5400)    'ch3 NO R
        x(20) = DummyDataValu2(90, 400)       'ch3 CG L
        x(21) = DummyDataValu2(90, 400)       'ch3 CG R
        For i As Integer = 0 To 29
            x(22 + i) = DummyDataOkNg2()
        Next
        For i As Integer = 0 To 51
            GetDummyData2 = GetDummyData2 + x(i)
        Next
        x(21) = x(21)
    End Function

    Public Function DataMaching(Data As String) As String
        Dim dx(26) As String
        Dim dy(31) As String
        For i As Integer = 0 To 23
            dx(i) = Strings.Mid(Data, i * 4 + 1, 4)
            If dx(i) = "DDDD" Then
                dx(i) = dx(i)
            End If
        Next
        For i As Integer = 0 To 31
            dy(i) = Strings.Mid(Data, i * 2 + 101, 2)
        Next
        For i As Integer = 0 To 26
            If MathCheck(dx(i)) = False Then
                Select Case i
                    Case 0, 1
                        dy(4 + i) = "02"
                    Case 2, 3
                        dy(8 + i) = "02"
                    Case Else
                        dy(8 + i) = "02"
                End Select
            Else
                Dim ix As Integer = 0
                ix = 1
            End If
        Next
        Dim tmp As String = ""
        For i As Integer = 0 To 26
            tmp = tmp + dx(i)
        Next
        For i As Integer = 0 To 31
            tmp = tmp + dy(i)
        Next
        DataMaching = tmp
    End Function

    Public Function MathCheck(a As String) As Boolean
        MathCheck = True
        For i As Integer = 1 To Len(a)
            Dim AscCode As Integer = Asc(Strings.Mid(a, i, 1))
            If (AscCode < &H30 Or AscCode > &H39) And AscCode <> &H2E Then MathCheck = False
        Next
    End Function

    Public Sub GetPlcData()
        If PlcRead(CLng(PlcDataAddress)) <> 0 Then
            'Dim DataCounter As Long = 0
            Dim tmp As String = ""
            Dim tmp2 As String = ""
            If DebugFlag = False Then
                Try
                    tmp2 = SysmacCJ1.ReadMemoryString(OMRON.Compolet.SYSMAC.SysmacCJ.MemoryTypes.DM, PlcDataAddress + 2, 98)
                    tmp = DataMaching(tmp2)
                Catch ex As Exception
                    If MsgBox("PLC－PC通信ｴﾗｰ" & vbCr & "DCSを終了してよいですか？", CType(vbOKCancel + vbExclamation, MsgBoxStyle)) = vbOK Then
                        Application.Exit()
                    End If
                End Try
            Else
                tmp = GetDummyData2()
                'Console.WriteLine(tmp)
            End If
            'No.0:通し番号
            Datacounter += 1
            GetData(0) = ColumnSet(Str(Datacounter), 8)
            'No.1/2：[日時]
            Dim dt As DateTime = DateTime.Now()
            GetData(1) = Strings.Mid(Trim(CStr(dt)), 3, 8)
            GetData(2) = Strings.Right(Trim(CStr(dt)), 8)
            'No.3～5：[判定ch1～3]生成
            Dim sy0 As String = ""
            For i As Integer = 0 To 23
                Dim sy1 As String = Strings.Mid(tmp, i * 4 + 1, 4)
                If sy1 = "????" Then sy1 = "----"
                sy0 = sy0 + sy1
            Next
            Dim sx0 As String = Strings.Right(tmp, 64)
            For i As Integer = 0 To 2
                Dim sx As String = Strings.Mid(sx0, 1 + i * 4, 4) + Strings.Mid(sx0, 13 + i * 4, 4) + Strings.Mid(sx0, 25 + i * 12, 12)
                Select Case sx
                    Case "01010101010101010101"
                        GetData(3 + i) = "Pass"
                    Case "02020202020202020202"
                        GetData(3 + i) = "----"
                    Case Else
                        GetData(3 + i) = "Fail"
                End Select
            Next
            'No.6～9:[OV ch1～2L/R(OK/NG)]生成
            Dim OkNg(4) As String
            OkNg(0) = Strings.Mid(sx0, 1, 2)
            OkNg(1) = Strings.Mid(sx0, 3, 2)
            OkNg(2) = Strings.Mid(sx0, 5, 2)
            OkNg(3) = Strings.Mid(sx0, 7, 2)
            For i As Integer = 0 To 3
                Select Case OkNg(i)
                    Case "01"
                        GetData(6 + i) = "OK"
                    Case "00"
                        GetData(6 + i) = "NG"
                    Case Else
                        GetData(6 + i) = "--"
                End Select
            Next i
            'No.10～11:[OV ch3L/R(実測値)]生成
            GetData(10) = Strings.Mid(sy0, 1, 2) + "." + Strings.Mid(sy0, 3, 2)
            GetData(11) = Strings.Mid(sy0, 5, 2) + "." + Strings.Mid(sy0, 7, 2)
            'No.12～15:[RV ch1～2L/R(OK/NG)]生成
            OkNg(0) = Strings.Mid(sx0, 13, 2)
            OkNg(1) = Strings.Mid(sx0, 15, 2)
            OkNg(2) = Strings.Mid(sx0, 17, 2)
            OkNg(3) = Strings.Mid(sx0, 19, 2)
            For i As Integer = 0 To 3
                Select Case OkNg(i)
                    Case "01"
                        GetData(12 + i) = "OK"
                    Case "00"
                        GetData(12 + i) = "NG"
                    Case Else
                        GetData(12 + i) = "--"
                End Select
            Next i
            'No.16～17:[RV ch3L/R(実測値)]生成
            GetData(16) = Strings.Mid(sy0, 9, 2) + "." + Strings.Mid(sy0, 11, 2)
            GetData(17) = Strings.Mid(sy0, 13, 2) + "." + Strings.Mid(sy0, 15, 2)
            'No.18～23:[NOCP ch1～3L/R]生成
            Dim p As Integer = 25
            GetData(18) = Strings.Mid(sy0, p, 2) + "." + Strings.Mid(sy0, p + 2, 2)
            GetData(19) = Strings.Mid(sy0, p + 4, 2) + "." + Strings.Mid(sy0, p + 6, 2)
            GetData(20) = Strings.Mid(sy0, p + 24, 2) + "." + Strings.Mid(sy0, p + 26, 2)
            GetData(21) = Strings.Mid(sy0, p + 28, 2) + "." + Strings.Mid(sy0, p + 30, 2)
            GetData(22) = Strings.Mid(sy0, p + 48, 2) + "." + Strings.Mid(sy0, p + 50, 2)
            GetData(23) = Strings.Mid(sy0, p + 52, 2) + "." + Strings.Mid(sy0, p + 54, 2)
            'No.24～29:[NCCP ch1～3L/R]生成
            p = 17
            GetData(24) = Strings.Mid(sy0, p, 2) + "." + Strings.Mid(sy0, p + 2, 2)
            GetData(25) = Strings.Mid(sy0, p + 4, 2) + "." + Strings.Mid(sy0, p + 6, 2)
            GetData(26) = Strings.Mid(sy0, p + 24, 2) + "." + Strings.Mid(sy0, p + 26, 2)
            GetData(27) = Strings.Mid(sy0, p + 28, 2) + "." + Strings.Mid(sy0, p + 30, 2)
            GetData(28) = Strings.Mid(sy0, p + 48, 2) + "." + Strings.Mid(sy0, p + 50, 2)
            GetData(29) = Strings.Mid(sy0, p + 52, 2) + "." + Strings.Mid(sy0, p + 54, 2)
            'No.30～35:[CG ch1～3L/R]生成
            p = 33
            GetData(30) = Strings.Mid(sy0, p, 1) + "." + Strings.Mid(sy0, p + 1, 3)
            GetData(31) = Strings.Mid(sy0, p + 4, 1) + "." + Strings.Mid(sy0, p + 5, 3)
            GetData(32) = Strings.Mid(sy0, p + 24, 1) + "." + Strings.Mid(sy0, p + 25, 3)
            GetData(33) = Strings.Mid(sy0, p + 28, 1) + "." + Strings.Mid(sy0, p + 29, 3)
            GetData(34) = Strings.Mid(sy0, p + 48, 1) + "." + Strings.Mid(sy0, p + 49, 3)
            GetData(35) = Strings.Mid(sy0, p + 52, 1) + "." + Strings.Mid(sy0, p + 53, 3)
            'No.36～37:[TSO ch3L/R(実測値)]生成
            GetData(36) = Strings.Mid(sy0, 89, 2) + "." + Strings.Mid(sy0, 91, 2)
            'GetData(37) = Strings.Mid(sy0, 93, 2) + "." + Strings.Mid(sy0, 95, 2)
            'No.40～71:OK/NG
            For i As Integer = 0 To 30
                Dim xx As String = Strings.Mid(sx0, 1 + i * 2, 2)
                'GetData(40 + i) = ChangeOkNg(xx)
                Select Case i
                    Case 0 To 11, 28, 29, 30, 31
                        GetData(40 + i) = ChangeOkNg(xx)
                    Case 12, 13
                        GetData(46 + i) = ChangeOkNg(xx)
                    Case 14, 15
                        GetData(38 + i) = ChangeOkNg(xx)
                    Case 16, 17
                        GetData(48 + i) = ChangeOkNg(xx)
                    Case 18, 19
                        GetData(42 + i) = ChangeOkNg(xx)
                    Case 20, 21
                        GetData(34 + i) = ChangeOkNg(xx)
                    Case 22, 23
                        GetData(44 + i) = ChangeOkNg(xx)
                    Case 24, 25
                        GetData(38 + i) = ChangeOkNg(xx)
                    Case 26, 27
                        GetData(30 + i) = ChangeOkNg(xx)
                End Select
            Next i
            'OK/NG 測定値優先化
            If MathCheck(GetData(10)) Then
                If LimOVLo <= CDbl(GetData(10)) And LimOVHi >= CDbl(GetData(10)) Then
                    GetData(44) = "OK"
                Else
                    GetData(44) = "NG"
                End If
            End If
            If MathCheck(GetData(11)) Then
                If LimOVLo <= CDbl(GetData(11)) And LimOVHi >= CDbl(GetData(11)) Then
                    GetData(45) = "OK"
                Else
                    GetData(45) = "NG"
                End If
            End If
            If MathCheck(GetData(16)) Then
                If LimRVLo <= CDbl(GetData(16)) And LimRVHi >= CDbl(GetData(16)) Then
                    GetData(50) = "OK"
                Else
                    GetData(50) = "NG"
                End If
            End If
            If MathCheck(GetData(17)) Then
                If LimRVLo <= CDbl(GetData(17)) And LimRVHi >= CDbl(GetData(17)) Then
                    GetData(51) = "OK"
                Else
                    GetData(51) = "NG"
                End If
            End If
            For i As Integer = 0 To 5
                If MathCheck(GetData(18 + i)) Then
                    If LimNOLo <= CDbl(GetData(18 + i)) And LimNOHi >= CDbl(GetData(18 + i)) Then
                        GetData(52 + i) = "OK"
                    Else
                        GetData(52 + i) = "NG"
                    End If
                End If
            Next i
            For i As Integer = 0 To 5
                If MathCheck(GetData(24 + i)) Then
                    If LimNCLo <= CDbl(GetData(24 + i)) And LimNCHi >= CDbl(GetData(24 + i)) Then
                        GetData(58 + i) = "OK"
                    Else
                        GetData(58 + i) = "NG"
                    End If
                End If
            Next i
            For i As Integer = 0 To 5
                If MathCheck(GetData(30 + i)) Then
                    If LimCGLo <= CDbl(GetData(30 + i)) And LimCGHi >= CDbl(GetData(30 + i)) Then
                        GetData(64 + i) = "OK"
                    Else
                        GetData(64 + i) = "NG"
                    End If
                End If
            Next i
            For i As Integer = 0 To 0
                If MathCheck(GetData(36 + i)) Then
                    Dim aaa As String = GetData(36)
                    aaa = aaa
                    If LimCGLo <= CDbl(GetData(36 + i)) And LimCGHi >= CDbl(GetData(36 + i)) Then
                        GetData(70 + i) = "OK"
                    Else
                        GetData(70 + i) = "NG"
                    End If
                End If
            Next i
            GetData(70) = GetData(50)
        End If
    End Sub

    Public Function ChangeOkNg(a As String) As String
        Select Case a
            Case "01"
                ChangeOkNg = "OK"
            Case "00"
                ChangeOkNg = "NG"
            Case Else
                ChangeOkNg = "--"
        End Select
    End Function

    Public Sub Initialize()
        'frmMain 設定
        Me.Width = 1800 '1024
        Me.Height = 405 + 16 '768
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        'dgvYield 設定
        dgvYield.Width = 202
        dgvYield.Height = 85
        'dgvData 設定
        dgvData.Width = 385
        dgvData.Height = 181 + 16 + 16
        'Sheet 設定
        Sheet.Width = 813 + 180 + 660
        Sheet.Height = 295 + 64 - 32
        'picHist0 設定
        picHist0.Width = 411 + 192
        picHist0.Height = 282 + 13 + 16
        'データシートの項目名設定
        ItemName(0) = "No."
        ItemName(1) = "Date"
        ItemName(2) = "Time"
        ItemName(3) = "P/F1"
        ItemName(4) = "P/F2"
        ItemName(5) = "P/F3"
        ItemName(6) = "OVL1"
        ItemName(7) = "OVR1"
        ItemName(8) = "OVL2"
        ItemName(9) = "OVR2"
        ItemName(10) = "OVL3"
        ItemName(11) = "OVR3"
        ItemName(12) = "RVL1"
        ItemName(13) = "RVR1"
        ItemName(14) = "RVL2"
        ItemName(15) = "RVR2"
        ItemName(16) = "RVL3"
        ItemName(17) = "RVR3"
        ItemName(18) = "NOL1"
        ItemName(19) = "NOR1"
        ItemName(20) = "NOL2"
        ItemName(21) = "NOR2"
        ItemName(22) = "NOL3"
        ItemName(23) = "NOR3"
        ItemName(24) = "NCL1"
        ItemName(25) = "NCR1"
        ItemName(26) = "NCL2"
        ItemName(27) = "NCR2"
        ItemName(28) = "NCL3"
        ItemName(29) = "NCR3"
        ItemName(30) = "CGL1"
        ItemName(31) = "CGR1"
        ItemName(32) = "CGL2"
        ItemName(33) = "CGR2"
        ItemName(34) = "CGL3"
        ItemName(35) = "CGR3"
        ItemName(36) = "TSO"
        ItemName(37) = "CR1"
        ItemName(38) = "CR2"
        ItemName(39) = "CR3"
        ItemName(40) = "No."
        ItemName(41) = "Date"
        ItemName(42) = "Time"
        ItemName(43) = "P/F"
        ItemName(44) = "OVL"
        ItemName(45) = "OVR"
        ItemName(46) = "RVL"
        ItemName(47) = "RVR"
        ItemName(48) = "NOL"
        ItemName(49) = "NOR"
        ItemName(50) = "NCL"
        ItemName(51) = "NCR"
        ItemName(52) = "CGL"
        ItemName(53) = "CGR"
        ItemName(54) = "TSO"
        ItemName(55) = "CR"
        ItemName(56) = ""
        ItemName(57) = ""
        ItemName(58) = ""
        ItemName(59) = ""
    End Sub

    Public Function DummyDataValu(Low As Single, High As Single) As Single
        '実数で「Low」～「High」までの乱数を発生させる
        DummyDataValu = Low + Rnd(1) * Math.Abs(High - Low)
    End Function

    Public Function DummyDataValu2(low As Integer, high As Integer) As String
        Dim a As Integer = CInt(low + Rnd(1) * Math.Abs(high - low))
        Dim s As String = Trim(Str(a))
        Dim b As Integer = Len(s)
        DummyDataValu2 = Strings.Left("0000", 4 - b) & s
    End Function

    Public Function DummyDataJudge() As String
        'ダミーデータ「Pass/Fail」生成
        Dim a As Integer = CInt(Rnd(1) * 30)
        Select Case a
            Case 0
                DummyDataJudge = "----"
            Case 1 To 2
                DummyDataJudge = "Fail"
            Case Else
                DummyDataJudge = "Pass"
        End Select
    End Function

    Public Function DummyDataOkNg() As String
        'ダミーデータ「OK/NG」生成
        Dim a As Integer = CInt(Rnd(1) * 100)
        Select Case a
            Case 0
                DummyDataOkNg = "--"
            Case 1 To 2
                DummyDataOkNg = "NG"
            Case Else
                DummyDataOkNg = "OK"
        End Select
    End Function

    Public Function DummyDataOkNg2() As String
        'ダミーデータ「OK/NG」生成
        Dim a As Integer = CInt(Rnd(1) * 300)
        Select Case a
            Case 0
                DummyDataOkNg2 = "2"
            Case 1 To 2
                DummyDataOkNg2 = "1"
            Case Else
                DummyDataOkNg2 = "0"
        End Select
    End Function

    Public Function ColumnSet(x As String, y As Integer) As String
        '文字列xの文字数をy文字数にそろえる。
        '(y文字未満は右詰めで空いた部分はスペース"&H20"で埋める)
        '(y文字以上は左側を切り捨てる)
        If y < 1 Then y = 0
        If y < Len(Trim(x)) Then
            ColumnSet = Strings.Right(Trim(x), y)
        ElseIf y = Len(Trim(x)) Then
            ColumnSet = Trim(x)
        Else
            ColumnSet = Space(y - Len(Trim(x))) + Trim(x)
        End If
    End Function

    Public Function ColumnSetDecimal(x As Single, y As Integer) As String
        '実数値xの小数部の桁数をy文字分にそろえる
        '足りない部分は"0"を追加する。
        Dim s1 As String
        Dim a1 As Integer
        Dim TotalLength As Integer
        Dim DecimalLength As Integer
        Dim DecimalString As String
        If y > 4 Then y = 4
        s1 = Trim(Str(x))
        If Strings.Left(s1, 1) = "." Then s1 = "0" + s1
        TotalLength = Len(s1)
        a1 = InStr(s1, ".")
        If a1 = 0 Then
            DecimalLength = 0
        ElseIf TotalLength - a1 > 4 Then
            DecimalLength = 4
        Else
            DecimalLength = TotalLength - a1
        End If
        If DecimalLength >= y Then
            DecimalString = Strings.Mid(s1, a1 + 1, y)
        Else
            DecimalString = Strings.Right(s1, TotalLength - a1) + Strings.Right("0000", y - DecimalLength)
        End If
        If a1 = 0 Then
            ColumnSetDecimal = s1 + "." + Strings.Right("0000", y)
        Else
            ColumnSetDecimal = Strings.Left(s1, a1) + DecimalString
        End If
    End Function

    Public Function ZeroPat(x As String, y As Integer) As String
        'ゼロパッティング
        '文字列xをy文字にそろえる。
        '(y文字未満は右詰めで空いた部分は"0"で埋める)
        '(y文字以上は左側を切り捨てる)
        '(y=8文字以上は左側を切り捨てる)
        If y < 1 Then y = 0
        If y > 8 Then y = 8
        If y < Len(Trim(x)) Then
            ZeroPat = Strings.Right(Trim(x), y)
        ElseIf y = Len(Trim(x)) Then
            ZeroPat = Trim(x)
        Else
            ZeroPat = Strings.Right("00000000", y - Len(Trim(x))) + Trim(x)
        End If
    End Function

    Public Function Cpk(LowLimit As Single, HiLimit As Single, Average As Single, Sigma As Single) As Single
        Dim cpl As Single = Math.Abs(Average - LowLimit) / (3 * Sigma)
        Dim cpu As Single = Math.Abs(HiLimit - Average) / (3 * Sigma)
        If cpl < cpu Then
            Cpk = cpl
        Else
            Cpk = cpu
        End If
    End Function

    Private Sub cbxCh0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCh0.SelectedIndexChanged
        If StackCounter > 0 Then
            If RadioButton2.Checked Then
                GraphSelect = False
                Transition()
            Else
                GraphSelect = True
                HistMain()
            End If
        End If
    End Sub

    Private Sub cbxItem0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxItem0.SelectedIndexChanged
        If StackCounter > 0 Then
            If RadioButton2.Checked Then
                GraphSelect = False
                Transition()
            Else
                GraphSelect = True
                HistMain()
            End If
        End If
    End Sub

    Private Sub cbxAve_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAve.SelectedIndexChanged
        Select Case cbxAve.SelectedIndex
            Case 0
                TrAve = 1
            Case 1
                TrAve = 2
            Case 2
                TrAve = 5
            Case 3
                TrAve = 10
            Case 4
                TrAve = 20
            Case 5
                TrAve = 50
            Case Else
                TrAve = 100
        End Select
    End Sub

    Private Sub mnuSE_Click(sender As Object, e As EventArgs) Handles mnuSE.Click
        If StartFlag = False Then
            If DebugFlag = False Then
                PlcWrite(LinkAddressPlcMonitor, 0)
                Application.Exit()
            Else
                Application.Exit()
            End If
        Else
            MessageBox.Show("ﾃﾞｰﾀ収集を停止して下さい")
        End If

    End Sub

    Private Sub mnuSI_Click(sender As Object, e As EventArgs) Handles mnuSI.Click
        If StartFlag = False Then
            If PassWordFlag = True Then
                frmTypeSetting.Show()
            Else
                MessageBox.Show("ﾊﾟｽﾜｰﾄﾞを解除して下さい")
            End If
        Else
            MessageBox.Show("ﾃﾞｰﾀ収集を停止して下さい")
        End If
    End Sub

    Private Sub mnuST_Click(sender As Object, e As EventArgs) Handles mnuST.Click
        If StartFlag = False Then
            frmTypeSelect.Show()
        Else
            MessageBox.Show("ﾃﾞｰﾀ収集を停止して下さい")
        End If
    End Sub

    Private Sub mnuSJ_Click(sender As Object, e As EventArgs) Handles mnuSJ.Click
        If StartFlag = False Then
            If PassWordFlag = True Then
                frmSheetSetting.Show()
            Else
                MessageBox.Show("ﾊﾟｽﾜｰﾄﾞを解除して下さい")
            End If
        Else
            MessageBox.Show("ﾃﾞｰﾀ収集を停止して下さい")
        End If
    End Sub

    Private Sub mnuVD_Click(sender As Object, e As EventArgs) Handles mnuVD.Click
        frmSheet1.Show()
        frmSheet2.Show()
        frmSheet3.Show()
        Call frmSheet1.DataSheet1()
        Call frmSheet2.DataSheet2()
        Call frmSheet3.DataSheet3()
    End Sub

    Private Sub mnuV1_Click(sender As Object, e As EventArgs) Handles mnuV1.Click
        frmHist1.Show()
        Call frmHist1.HistMain1()
    End Sub

    Private Sub mnuV2_Click(sender As Object, e As EventArgs) Handles mnuV2.Click
        frmHist2.Show()
        Call frmHist2.HistMain2()
    End Sub

    Private Sub mnuV3_Click(sender As Object, e As EventArgs) Handles mnuV3.Click
        frmHist3.Show()
        Call frmHist3.HistMain3()
    End Sub

    Private Sub mnuSF_Click(sender As Object, e As EventArgs) Handles mnuSF.Click
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        FolderBrowserDialog1.SelectedPath = SaveFolder
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Private Sub InitFileSystem()
        Dim dt As DateTime = DateTime.Now
        Dim b As String = dt.ToString
        SaveFileName = Strings.Left(Trim(b), 4) + Strings.Mid(Trim(b), 6, 2) + Strings.Mid(Trim(b), 9, 2)
        SaveSubFolder = Strings.Left(Trim(b), 4) + Strings.Mid(Trim(b), 6, 2)
        Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(SaveFolder + "\" + SaveSubFolder)
        di.Create()
    End Sub

    Private Sub mnuSP_Click(sender As Object, e As EventArgs) Handles mnuSP.Click
        frmPassword.Show()
    End Sub

    Private Sub mnuVC_Click(sender As Object, e As EventArgs) Handles mnuVC.Click
        If StartFlag = False Then
            For i As Integer = 1 To StackCounter
                For j As Integer = 0 To 69
                    StackData(i, j) = ""
                Next
            Next
            Call DGVClear(Sheet)
            Call DGVClear(dgvData)
            Call DGVClear(dgvYield)
            Call DGVClear(frmSheet1.Sheet1)
            Call DGVClear(frmSheet2.Sheet2)
            Call DGVClear(frmSheet3.Sheet3)
            For i As Integer = 0 To 2
                TotalCount(i) = 0
                PassCount(i) = 0
            Next
            Dim canvas As New Bitmap(picHist0.Width, picHist0.Height)
            Dim g As Graphics = Graphics.FromImage(canvas)
            g.FillRectangle(Brushes.White, 10, 20, 100, 80)
            g.Dispose()
            picHist0.Image = canvas
            StackCounter = 0
            YieldViewFirstFlag = True
            DataViewFirstFlag = True
            SheetFirstFlag = True
            Sheet1FirstFlag = True
            Sheet2FirstFlag = True
            Sheet3FirstFlag = True
            txtYield.BackColor = Color.Azure
            txtYield.ForeColor = Color.Blue
            txtYield.Text = "-----"
            For i As Short = 0 To 35
                TotalMeasCount(i) = 0
                PassMeasCount(i) = 0
                FullTotalMeasCount(i) = 0
                FullPassMeasCount(i) = 0
                SumValue(i) = 0
            Next i
        Else
            MessageBox.Show("ﾃﾞｰﾀ収集を停止して下さい")
        End If
    End Sub

    Private Sub timMain_Tick(sender As Object, e As EventArgs) Handles timMain.Tick
        If StartFlag Then
            timHeartPulse.Enabled = True
            Main()
        Else
            timHeartPulse.Enabled = False
        End If
    End Sub

    Public Function PlcRead(address As Long) As Long
        '－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        'シーケンサーのDMメモリーより「address」にて指定したアドレスの内容を読み込む
        '－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        If DebugFlag = False Then
            Try
                PlcRead = SysmacCJ1.DM(address)
            Catch ex As Exception
                If MsgBox("PLC－PC通信ｴﾗｰ" & vbCr & "DCSを終了してよいですか？", CType(vbOKCancel + vbExclamation, MsgBoxStyle)) = vbOK Then
                    Application.Exit()
                End If
                PlcRead = 0
            End Try
        Else
            PlcRead = 99
        End If
    End Function

    Public Sub PlcWrite(address As Long, value As Long)
        '－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        'シーケンサーのDMメモリーへ「address」にて指定したアドレスに｢value｣の値を書き込む
        '－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        Try
            SysmacCJ1.DM(address) = value
        Catch ex As Exception
            If MsgBox("PLC－PC通信ｴﾗｰ" & vbCr & "DCSを終了してよいですか？", CType(vbOKCancel + vbExclamation, MsgBoxStyle)) = vbOK Then
                Application.Exit()
            End If
        End Try
    End Sub

    Private Sub mnuTotalDataSheetOpen_Click(sender As Object, e As EventArgs) Handles mnuTotalDataSheetOpen.Click
        Me.Width = 1800 '1024
        Me.Height = 730 '768
    End Sub

    Private Sub mnuTotalDataSheetClose_Click(sender As Object, e As EventArgs) Handles mnuTotalDataSheetClose.Click
        Me.Width = 1024
        Me.Height = 405
    End Sub

    Private Sub timPlcScan_Tick(sender As Object, e As EventArgs) Handles timPlcScan.Tick
        If DebugFlag = False Then
            If PlcRead(LinkAddressPlcDataGetOkClear) = 1 Then
                PlcWrite(LinkAddressPlcDataGet, 0)
            End If
        End If
    End Sub

    Private Sub timHeartPulse_Tick(sender As Object, e As EventArgs) Handles timHeartPulse.Tick
        If DebugFlag = False Then
            If PlcMonitorFlag = True Then
                PlcMonitor()
            End If
            If PlcRead(LinkAddressAppStart) = 0 Then
                PlcWrite(LinkAddressAppStart, 1)
            Else
                PlcWrite(LinkAddressAppStart, 0)
            End If
        End If
    End Sub

    Private Sub mnuPlcMonitorOpen_Click(sender As Object, e As EventArgs) Handles mnuPlcMonitorOpen.Click
        PlcMonitorFlag = True
        PlcWrite(LinkAddressPlcMonitor, 1)
        frmPlcMonitor.Show()
    End Sub

    Private Sub mnuPlcMonitorClose_Click(sender As Object, e As EventArgs) Handles mnuPlcMonitorClose.Click
        PlcMonitorFlag = False
        PlcWrite(LinkAddressPlcMonitor, 0)
        frmPlcMonitor.Hide()
    End Sub

    Private Sub mnuBufferClear_Click(sender As Object, e As EventArgs) Handles mnuBufferClear.Click
        If StartFlag = False Then
            If PassWordFlag = True Then
                PlcWrite(LinkAddressBufferClear, 1)
                For i As Long = 0 To 100000000
                    'wait
                Next
            Else
                MessageBox.Show("ﾊﾟｽﾜｰﾄﾞを解除して下さい")
            End If
            If PlcRead(LinkAddressBufferClear) = 1 Then
                PlcWrite(LinkAddressBufferClear, 0)
                PassWordFlag = False
            End If
        Else
            MessageBox.Show("ﾃﾞｰﾀ収集を停止して下さい")
        End If
    End Sub

    Private Sub mnuAlarmLevelSet_Click(sender As Object, e As EventArgs) Handles mnuAlarmLevelSet.Click
        frmYieldColor.Show()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            GraphSelect = True
        Else
            GraphSelect = False
        End If
        If StackCounter > 0 Then
            HistMain()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            GraphSelect = False
        Else
            GraphSelect = True
        End If
        If StackCounter > 0 Then
            Transition()
        End If
    End Sub

    Private Function ColumnSetDecimal(p1 As Long) As String
        Throw New NotImplementedException
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SoukanMode Then
            SaveSoukanData()
        End If
    End Sub

    Private Sub mnuGouki_Click(sender As Object, e As EventArgs) Handles mnuGouki.Click
        If StartFlag = False Then
            If PassWordFlag = True Then
                frmGouki.Show()
            Else
                MessageBox.Show("ﾊﾟｽﾜｰﾄﾞを解除して下さい")
            End If
        Else
            MessageBox.Show("ﾃﾞｰﾀ収集を停止して下さい")
        End If

    End Sub

End Class



