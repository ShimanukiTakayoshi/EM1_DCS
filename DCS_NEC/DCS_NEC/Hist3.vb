Public Class frmHist3

    Private Sub frmHist3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HistInit3()
        Call HistMain3()
    End Sub

    Public Sub HistInit3()
        Me.Width = 430
        Me.Height = 335
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        picHist3.Width = 390
        picHist3.Height = 240
        If frmMain.HistInitFlag3 = False Then
            With cbxCh3
                .Items.Add("Total")
                .Items.Add("Ch-1")
                .Items.Add("Ch-2")
                .Items.Add("Ch-3")
            End With
            cbxCh3.Text = "Total"
            With cbxItem3
                .Items.Add("OV")
                .Items.Add("RV")
                .Items.Add("NO")
                .Items.Add("NC")
                .Items.Add("CG")
                .Items.Add("TS")
                .Items.Add("CR")
            End With
            cbxItem3.Text = "OV"
            frmMain.HistInitFlag3 = True
        End If
    End Sub

    Public Sub HistMain3()
        Dim ch As Integer = cbxCh3.SelectedIndex                    'Ch取得
        Dim Item As Integer = cbxItem3.SelectedIndex                '項目取得
        Dim ll As Single = CSng(frmMain.TypeData(frmMain.TypeCode, Item * 4 + 2))   '下限規格値取得
        Dim hl As Single = CSng(frmMain.TypeData(frmMain.TypeCode, Item * 4 + 3))   '上限規格値取得
        Dim gl As Single = CSng(frmMain.TypeData(frmMain.TypeCode, Item * 4 + 4))   'グラフ下限値取得
        Dim gh As Single = CSng(frmMain.TypeData(frmMain.TypeCode, Item * 4 + 5))   'グラフ上限値取得
        Dim Div As Single = (gh - gl) / 20                          '分割幅取得
        Dim HistL(20) As Integer
        Dim HistR(20) As Integer
        Dim DataL(300) As Single    '有効データL
        Dim DataR(300) As Single    '有効データR
        Dim ValidL As Integer = 0   '有効データ数L
        Dim ValidR As Integer = 0   '有効データ数R
        Dim backimage As New Bitmap(picHist3.Width, picHist3.Height)
        Dim gx As Graphics = Graphics.FromImage(backimage)
        '分布元データ取得
        For i As Integer = 1 To frmMain.StackCounter                            'stackCounter
            For j As Short = 0 To 2
                Select Case Item
                    Case 0, 1
                        If ch = 0 Or ch = 3 Then
                            If frmMain.StackData(i, Item * 6 + j * 2 + 40) <> "--" And frmMain.MathCheck(frmMain.StackData(i, Item * 6 + j * 2 + 6)) = True Then
                                ValidL += 1
                                DataL(ValidL) = CSng(frmMain.StackData(i, Item * 6 + j * 2 + 6))
                            End If
                            If frmMain.StackData(i, Item * 6 + j * 2 + 41) <> "--" And frmMain.MathCheck(frmMain.StackData(i, Item * 6 + j * 2 + 7)) = True Then
                                ValidR += 1
                                DataR(ValidR) = CSng(frmMain.StackData(i, Item * 6 + j * 2 + 7))
                            End If
                        End If
                    Case 5
                        If ch = 0 Or ch = 3 Then
                            If frmMain.StackData(i, Item * 6 + 40) <> "--" And frmMain.MathCheck(frmMain.StackData(i, Item * 6 + 6)) = True Then
                                ValidL += 1
                                DataL(ValidL) = CSng(frmMain.StackData(i, Item * 6 + 6))
                            End If
                        End If
                    Case 6
                        If ch = 0 Or (ch = j + 1) Then
                            If frmMain.StackData(i, Item * 6 + j + 41) <> "--" And frmMain.MathCheck(frmMain.StackData(i, Item * 6 + j + 1)) = True Then
                                ValidL += 1
                                DataL(ValidL) = CSng(frmMain.StackData(i, Item * 6 + j + 1))
                            End If
                        End If
                   Case Else
                        If ch = 0 Or (ch = j + 1) Then
                            If frmMain.StackData(i, Item * 6 + j * 2 + 40) <> "--" And frmMain.MathCheck(frmMain.StackData(i, Item * 6 + j * 2 + 6)) = True Then
                                ValidL += 1
                                DataL(ValidL) = CSng(frmMain.StackData(i, Item * 6 + j * 2 + 6))
                            End If
                            If frmMain.StackData(i, Item * 6 + j * 2 + 41) <> "--" And frmMain.MathCheck(frmMain.StackData(i, Item * 6 + j * 2 + 7)) = True Then
                                ValidR += 1
                                DataR(ValidR) = CSng(frmMain.StackData(i, Item * 6 + j * 2 + 7))
                            End If
                        End If
                End Select
            Next j
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
        Dim Rx As Single = CSng(picHist3.Size.Width / 1000)
        Dim Ry As Single = CSng(picHist3.Size.Height / 1000)
        Dim Pen1 As Pen = New Pen(Color.Black, 1)
        Dim g As Graphics = picHist3.CreateGraphics
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
        Dim ds As String = frmMain.ColumnSetDecimal(gl, 1)
        Dim df As New Font("ＭＳゴシック", 8)
        Dim db As New SolidBrush(Color.Black)
        g.DrawString(frmMain.ColumnSetDecimal(gl, 1), df, db, Rx * 80, Ry * 910)
        g.DrawString(frmMain.ColumnSetDecimal(gh, 1), df, db, Rx * 880, Ry * 910)
        Select Case Item
            Case 0, 1, 5
                g.DrawString("[V]", df, db, Rx * 870, Ry * 950)
            Case 2, 3
                g.DrawString("[x9.8mN]", df, db, Rx * 870, Ry * 950)
            Case 4
                g.DrawString("[mm]", df, db, Rx * 870, Ry * 950)
            Case Else
                g.DrawString("[mΩ]", df, db, Rx * 870, Ry * 950)
        End Select
        For i As Integer = 2 To 19 Step 2
            Dim x1 As Single = Rx * 80 + (Rx * 800 / 20) * i
            g.DrawString(frmMain.ColumnSetDecimal(gl + Div * i, 1), df, db, x1, Ry * 910)
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
        Dim Tmp1 As Single = CSng(HistLMax / ValidL)
        Dim tmp2 As Single = CSng(HistRMax / ValidR)
        If ValidL = 0 Then Tmp1 = 0 Else Tmp1 = CSng(HistLMax / ValidL)
        If ValidR = 0 Then tmp2 = 0 Else tmp2 = CSng(HistRMax / ValidR)
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
        For i As Integer = 1 To 3
            Dim Tmp3 As Single = CSng((YaxisUpper / 4) * i)
            If Tmp3 < 10 Then
                g.DrawString(Str(Math.Abs(Tmp3)), df, db, Rx * 73, Ry * (880 - 200 * i))
            Else
                g.DrawString(Str(Math.Abs(Tmp3)), df, db, Rx * 50, Ry * (880 - 200 * i))
            End If
        Next i
        g.DrawString("[%]", df, db, Rx * 55, Ry * 35)
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
            If Item <> 5 Or Item <> 6 Then
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
        g.DrawString(frmMain.ColumnSetDecimal(ll, 2), df, db, Rx * (x2 - 20), Ry * 135)
        x2 = (800 / (gh - gl) * (hl - gl)) + 100
        g.DrawLine(Pen1, Rx * x2, Ry * 899, Rx * x2, Ry * 200)
        g.DrawLine(Pen1, Rx * (x2 - 50), Ry * 200, Rx * x2, Ry * 200)
        g.DrawString(frmMain.ColumnSetDecimal(hl, 2), df, db, Rx * (x2 - 20), Ry * 135)
    End Sub


    Private Sub cbxCh3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCh3.SelectedIndexChanged
        If frmMain.StackCounter > 0 Then
            HistMain3()
        End If
    End Sub

    Private Sub cbxItem3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxItem3.SelectedIndexChanged
        If frmMain.StackCounter > 0 Then
            HistMain3()
        End If
    End Sub

    Private Sub btnCloseHist3_Click(sender As Object, e As EventArgs) Handles btnCloseHist3.Click
        Me.Hide()
    End Sub

    Private Sub timHist2_Tick_1(sender As Object, e As EventArgs) Handles timHist3.Tick
        HistMain3()
    End Sub

End Class