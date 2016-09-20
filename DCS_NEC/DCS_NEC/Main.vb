Option Strict On
Imports System.IO

Public Class frmMain
    Dim DummyData(80) As String
    Dim DummyDataCounter As Long = 0
    Dim StackData(200, 80) As String
    Dim StackCounter As Integer = 0
    Public ItemName(39) As String       '項目名
    Public ItemWidth(39) As Integer     '幅
    Public ItemCheck(39) As Boolean     '表示するorしない
    Public ItemSelect(39) As Integer    '項目
    'メイン画面歩留集計表
    Public TotalCount(2) As Integer
    Public PassCount(2) As Integer
    'メイン画面項目別集計表
    Public TotalMeasCount(29) As Integer
    Public PassMeasCount(29) As Integer
    Public SumValue(29) As Double

    Public MaxSeatCount As Integer = 200

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Initialize()
        Call LoadSettingData()
        Call DGVClear(Sheet)
        Call DGVClear(dgvYield)
        Call SheetInit()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim a As Integer
        StackCounter = StackCounter + 1
        Call GetDummyData()
        For i As Integer = 0 To 69
            StackData(StackCounter, i) = DummyData(i)
        Next

        If StackCounter > 100 Then
            Call StackDataShift()
            StackCounter = 100
        End If

        '歩留集計
        Call YieldCalc()
        Call DataCalc()

        a = Sheet.FirstDisplayedScrollingRowIndex
        Call DataSheet()
        Sheet.FirstDisplayedScrollingRowIndex = a
        Call YieldView()
        Call DataView()
        lblTest.Text = DummyData(3) + "\" + DummyData(4) + "\" + DummyData(5) + "\" + DummyData(6) + "\" + DummyData(7) + "\" + DummyData(8)
    End Sub

    Public Sub StackDataShift()
        For i As Integer = 1 To 100
            For j As Integer = 0 To 39
                StackData(i, j) = StackData(i + 1, j)
            Next
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
        Me.Sheet.RowHeadersVisible = False
    End Sub

    Public Sub DataView()
        Call DGVClear(dgvData)
        dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvData.Columns.Add("0", "項目")
        dgvData.Columns.Add("1", "総数")
        dgvData.Columns.Add("2", "良品数")
        dgvData.Columns.Add("3", "良品率[%]")
        dgvData.Columns.Add("4", "平均")
        dgvData.Columns.Add("5", "標準偏差")
        dgvData.Columns.Add("6", "Ｃｐｋ")
        dgvData.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvData.Columns(0).Width = 80
        dgvData.Columns(1).Width = 80
        dgvData.Columns(2).Width = 80
        dgvData.Columns(3).Width = 80
        dgvData.Columns(4).Width = 80
        dgvData.Columns(5).Width = 80
        dgvData.Columns(6).Width = 80
        dgvData.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvData.RowHeadersVisible = False
        dgvData.Rows.Add("PV-L")
        dgvData.Rows.Add("PV-R")
        dgvData.Rows.Add("DV-L")
        dgvData.Rows.Add("DV-R")
        dgvData.Rows.Add("NO-L")
        dgvData.Rows.Add("NO-R")
        dgvData.Rows.Add("NC-L")
        dgvData.Rows.Add("NC-R")
        dgvData.Rows.Add("CG-L")
        dgvData.Rows.Add("CG-R")
        For i As Integer = 0 To 9
            dgvData.Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next i
        dgvData.ScrollBars = ScrollBars.None
        For i As Integer = 0 To 4
            Dim a1 As Integer = TotalMeasCount(i * 6) + TotalMeasCount(i * 6 + 2) + TotalMeasCount(i * 6 + 4)
            Dim a2 As Integer = TotalMeasCount(i * 6 + 1) + TotalMeasCount(i * 6 + 3) + TotalMeasCount(i * 6 + 5)
            Dim a3 As Integer = PassMeasCount(i * 6) + PassMeasCount(i * 6 + 2) + PassMeasCount(i * 6 + 4)
            Dim a4 As Integer = PassMeasCount(i * 6 + 1) + PassMeasCount(i * 6 + 3) + PassMeasCount(i * 6 + 5)
            Dim a5 As Double = SumValue(i * 6) + SumValue(i * 6 + 2) + SumValue(i * 6 + 4)
            Dim a6 As Double = SumValue(i * 6 + 1) + SumValue(i * 6 + 3) + SumValue(i * 6 + 5)
            dgvData.Item(1, i * 2).Value = a1
            dgvData.Item(2, i * 2).Value = a3
            dgvData.Item(1, i * 2 + 1).Value = a2
            dgvData.Item(2, i * 2 + 1).Value = a4
            If a1 > 0 Then
                dgvData.Item(3, i * 2).Value = ColumnSetDecimal(CSng(a3 / a1 * 100), 2)
                If i <> 0 And i <> 1 Then
                    dgvData.Item(4, i * 2).Value = ColumnSetDecimal(CSng(a5 / a1), 2)
                Else
                    dgvData.Item(4, i * 2).Value = ColumnSetDecimal(CSng(a5 / TotalMeasCount(i * 6)), 2)
                End If
            End If
            If a2 > 0 Then
                dgvData.Item(3, i * 2 + 1).Value = ColumnSetDecimal(CSng(a4 / a2 * 100), 2)
                If i <> 0 And i <> 1 Then
                    dgvData.Item(4, i * 2 + 1).Value = ColumnSetDecimal(CSng(a6 / a2), 2)
                Else
                    dgvData.Item(4, i * 2 + 1).Value = ColumnSetDecimal(CSng(a6 / TotalMeasCount(i * 6 + 1)), 2)
                End If
            End If
        Next
    End Sub

    Public Sub DataCalc()
        For i As Integer = 0 To 29
            Dim s As String = StackData(StackCounter, 40 + i)
            Select Case StackData(StackCounter, 40 + i)
                Case "OK"
                    TotalMeasCount(i) = TotalMeasCount(i) + 1
                    PassMeasCount(i) = PassMeasCount(i) + 1
                    If i <> 2 And i <> 3 And i <> 4 And i <> 5 And i <> 8 And i <> 9 And i <> 10 And i <> 11 Then
                        SumValue(i) = SumValue(i) + Val(StackData(StackCounter, 6 + i))
                        Dim s1 As Double = Val(StackData(StackCounter, 6 + i))
                        s1 = s1 + 0
                    End If
                Case "NG"
                    TotalMeasCount(i) = TotalMeasCount(i) + 1
                    If i <> 2 And i <> 3 And i <> 4 And i <> 5 And i <> 8 And i <> 9 And i <> 10 And i <> 11 Then
                        SumValue(i) = SumValue(i) + Val(StackData(StackCounter, 6 + i))
                        Dim s1 As Double = Val(StackData(StackCounter, 6 + i))
                        s1 = s1 + 0
                    End If
                Case Else
                    '
            End Select
        Next
    End Sub


    Public Sub YieldView()
        Call DGVClear(dgvYield)
        dgvYield.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvYield.Columns.Add("0", "ch")
        dgvYield.Columns.Add("1", "総数")
        dgvYield.Columns.Add("2", "良品数")
        dgvYield.Columns.Add("3", "良品率[%]")
        dgvYield.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvYield.Columns(0).Width = 50
        dgvYield.Columns(1).Width = 70
        dgvYield.Columns(2).Width = 70
        dgvYield.Columns(3).Width = 80
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
        dgvYield.ScrollBars = ScrollBars.None
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
    End Sub

    Public Sub YieldCalc()
        For i As Integer = 0 To 2
            Select Case StackData(StackCounter, 3 + i)
                Case "Pass"
                    TotalCount(i) = TotalCount(i) + 1
                    PassCount(i) = PassCount(i) + 1
                Case "Fail"
                    TotalCount(i) = TotalCount(i) + 1
                Case Else
                    '
            End Select
        Next i
    End Sub


    Public Sub DataSheet()
        Dim a As Integer
        Me.Sheet.Visible = False
        Sheet.SuspendLayout()
        Call DGVClear(Sheet)
        Call SheetInit()
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
            Dim item As New DataGridViewRow
            item.CreateCells(Sheet)
            With item
                Dim k As Integer = 0
                For j As Integer = 0 To 39
                    If ItemCheck(j) = True Then
                        .Cells(k).Value = Trim(StackData(i, ItemSelect(j)))
                        k = k + 1
                    End If
                Next j
            End With
            Sheet.Rows.Add(item)
        Next i
        Sheet.ResumeLayout()
        Me.Sheet.Visible = True
        Me.Sheet.ScrollBars = ScrollBars.Both
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


    Public Sub SaveData()
        Dim ofile As String = "C:\Users\Kyoei_Shimanuki\Desktop\NEC_DCS\TestText3.csv"
        Dim InputString As String = ""
        Dim i As Integer
        For i = 0 To 34
            InputString = InputString + DummyData(i) + ","
        Next
        InputString = InputString + DummyData(35) + vbCrLf
        My.Computer.FileSystem.WriteAllText(ofile, InputString, True)
    End Sub

    Public Sub LoadSettingData()
        Dim sr As System.IO.StreamReader
        Dim ofile As String = "C:\Users\Kyoei_Shimanuki\Desktop\NEC_DCS\NEC_DCS_SETTING.txt"
        sr = New System.IO.StreamReader(ofile, System.Text.Encoding.GetEncoding(932))
        Try
            Dim b As String
            For i As Integer = 0 To 39
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
        DummyData(1) = "20" + ZeroPat(Str$(year), 2) + "/" + ZeroPat(Str$(month), 2) + "/" + ZeroPat(Str$(day), 2)
        'No.2：[時間]生成
        Dim Hour As Integer
        Dim Minute As Integer
        Dim Second As Integer
        Hour = CInt(Rnd(1) * 24)
        Minute = CInt(Rnd(1) * 60)
        Second = CInt(Rnd(1) * 60)
        DummyData(2) = ZeroPat(Str$(Hour), 2) + ":" + ZeroPat(Str$(Minute), 2) + ":" + ZeroPat(Str$(Second), 2)
        'No.3～5：[判定ch1～3]生成
        Dim i As Integer
        For i = 3 To 5
            DummyData(i) = DummyDataJudge()
        Next
        'No.6～7:[PV ch1L/R(実測値)]生成
        DummyData(6) = ColumnSetDecimal((DummyDataValu(7, 11)), 2)
        DummyData(7) = ColumnSetDecimal((DummyDataValu(7, 11)), 2)
        'No.8～11:[PV ch2～3L/R(OK/NG)]生成
        For i = 8 To 11
            DummyData(i) = DummyDataOkNg()
        Next i
        'No.12～13:[DV ch1L/R(実測値)]生成
        DummyData(12) = ColumnSetDecimal((DummyDataValu(3, 8)), 2)
        DummyData(13) = ColumnSetDecimal((DummyDataValu(3, 8)), 2)
        'No.14～17:[DV ch2～3L/R(OK/NG)]生成
        For i = 14 To 17
            DummyData(i) = DummyDataOkNg()
        Next i
        'No.18～23:[NOCP ch1～3L/R]生成
        For i = 18 To 23
            DummyData(i) = ColumnSetDecimal((DummyDataValu(3, 8)), 2)
        Next i
        'No.24～29:[NCCP ch1～3L/R]生成
        For i = 24 To 29
            DummyData(i) = ColumnSetDecimal((DummyDataValu(5, 14)), 2)
        Next i
        'No.30～35:[CG ch1～3L/R]生成
        For i = 30 To 35
            DummyData(i) = ColumnSetDecimal((DummyDataValu(0.2, 1.2)), 2)
        Next i
        'No.40～69:OK/NG
        For i = 40 To 69
            DummyData(i) = DummyDataOkNg()
        Next
    End Sub

    Public Sub Initialize()
        'データシートの項目名設定
        ItemName(0) = "No."
        ItemName(1) = "Date"
        ItemName(2) = "Time"
        ItemName(3) = "Judge1"
        ItemName(4) = "Judge2"
        ItemName(5) = "Judge3"
        ItemName(6) = "PV-L1"
        ItemName(7) = "PV-R1"
        ItemName(8) = "PV-L2"
        ItemName(9) = "PV-R2"
        ItemName(10) = "PV-L3"
        ItemName(11) = "PV-R3"
        ItemName(12) = "DV-L1"
        ItemName(13) = "DV-R1"
        ItemName(14) = "DV-L2"
        ItemName(15) = "DV-R2"
        ItemName(16) = "DV-L3"
        ItemName(17) = "DV-R3"
        ItemName(18) = "NO-L1"
        ItemName(19) = "NO-R1"
        ItemName(20) = "NO-L2"
        ItemName(21) = "NO-R2"
        ItemName(22) = "NO-L3"
        ItemName(23) = "NO-R3"
        ItemName(24) = "NC-L1"
        ItemName(25) = "NC-R1"
        ItemName(26) = "NC-L2"
        ItemName(27) = "NC-R2"
        ItemName(28) = "NC-L3"
        ItemName(29) = "NC-R3"
        ItemName(30) = "CG-L1"
        ItemName(31) = "CG-R1"
        ItemName(32) = "CG-L2"
        ItemName(33) = "CG-R2"
        ItemName(34) = "CG-L3"
        ItemName(35) = "CG-R3"
        ItemName(36) = ""
        ItemName(37) = ""
        ItemName(38) = ""
        ItemName(39) = ""

    End Sub

    Public Function DummyDataValu(Low As Single, High As Single) As Single
        '実数で「Low」～「High」までの乱数を発生させる
        DummyDataValu = Low + Rnd(1) * Math.Abs(High - Low)
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
        Dim a As Integer = CInt(Rnd(1) * 30)
        Select Case a
            Case 0
                DummyDataOkNg = "--"
            Case 1 To 2
                DummyDataOkNg = "NG"
            Case Else
                DummyDataOkNg = "OK"
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

    Private Sub btnSheetSetting_Click(sender As Object, e As EventArgs) Handles btnSheetSetting.Click
        frmSheetSetting.Show()
    End Sub
End Class
