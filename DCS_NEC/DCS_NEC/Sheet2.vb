Public Class frmSheet2
    Dim ItemCv(20) As Integer

    Private Sub frmSheet2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ItemCv(0) = 0
        ItemCv(1) = 1
        ItemCv(2) = 2
        ItemCv(3) = 4
        ItemCv(4) = 8
        ItemCv(5) = 9
        ItemCv(6) = 14
        ItemCv(7) = 15
        ItemCv(8) = 20
        ItemCv(9) = 21
        ItemCv(10) = 26
        ItemCv(11) = 27
        ItemCv(12) = 32
        ItemCv(13) = 33
        ItemCv(14) = 38
        ItemCv(15) = 0
        ItemCv(16) = 0
        ItemCv(17) = 0
        ItemCv(18) = 0
        ItemCv(19) = 0
        SheetInit2()
    End Sub

    Public Sub SheetInit2()
        Me.Width = 635 + 40
        Me.Height = 420
        Sheet2.Width = 613 + 40
        Sheet2.Height = 342
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        If frmMain.Sheet2FirstFlag Then
            Sheet2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim j As Integer = 0
            For i As Integer = 0 To 13
                If frmMain.ItemCheck(40 + i) Then
                    Sheet2.Columns.Add(Trim(Str(j)), frmMain.ItemName(frmMain.ItemSelect(40 + i)))
                    Sheet2.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Sheet2.Columns(j).Width = frmMain.ItemWidth(40 + i)
                    j = j + 1
                End If
            Next i
            If frmMain.ItemCheck(40 + 15) Then
                Sheet2.Columns.Add(Trim(Str(j)), frmMain.ItemName(frmMain.ItemSelect(40 + 15)))
                Sheet2.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Sheet2.Columns(j).Width = frmMain.ItemWidth(40 + 15)
            End If
            For i As Integer = 0 To 99
                Sheet2.Rows.Add("")
            Next
            For i As Integer = 1 To 100
                Sheet2.Rows(i - 1).Height = 16
            Next
            Sheet2.RowHeadersVisible = False
        End If
    End Sub

    Public Sub DataSheet2()
        'Sheet2.Visible = False
        Sheet2.SuspendLayout()
        If frmMain.Sheet2FirstFlag Then
            frmMain.DGVClear(Sheet2)
            SheetInit2()
            frmMain.Sheet2FirstFlag = False
        End If
        'シート表示高速化
        Dim myType As System.Type = GetType(DataGridView)
        Dim myPropertyInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        myPropertyInfo.SetValue(Sheet2, True, Nothing)
        Sheet2.AllowUserToResizeRows = False
        Sheet2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Sheet2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Sheet2.RowTemplate.Height = 10
        For i As Integer = 1 To frmMain.StackCounter
            Dim k As Integer = 0
            For j As Integer = 0 To 14
                Dim sn As String
                If frmMain.ItemCheck(40 + j) Then
                    Dim x As Integer = frmMain.ItemSelect(j)
                    Dim s As String = frmMain.StackData(1, 0)
                    sn = Trim(frmMain.StackData(i, ItemCv((frmMain.ItemSelect(40 + j)) - 40)))
                    Sheet2.Item(k, i).Value = sn
                    Sheet2.Item(k, i).Style.ForeColor = Color.Black
                    Select Case (frmMain.ItemSelect(40 + j) - 40)
                        Case 3
                            If sn <> "Pass" Then Sheet2.Item(k, i).Style.ForeColor = Color.Red
                        Case 4 To 7
                            If sn <> "OK" Then Sheet2.Item(k, i).Style.ForeColor = Color.Red
                        Case 8, 9
                            If Val(sn) < frmMain.LimNOLo Or Val(sn) > frmMain.LimNOHi Then Sheet2.Item(k, i).Style.ForeColor = Color.Red
                        Case 10, 11
                            If Val(sn) < frmMain.LimNCLo Or Val(sn) > frmMain.LimNCHi Then Sheet2.Item(k, i).Style.ForeColor = Color.Red
                        Case 12, 13
                            If Val(sn) < frmMain.LimCGLo Or Val(sn) > frmMain.LimCGHi Then Sheet2.Item(k, i).Style.ForeColor = Color.Red
                        Case 14
                            If Val(sn) < frmMain.LimCRLo Or Val(sn) > frmMain.LimCRHi Then Sheet2.Item(k, i).Style.ForeColor = Color.Red
                    End Select
                    k = k + 1
                End If
            Next
        Next
        Sheet2.ResumeLayout()
        Sheet2.ScrollBars = ScrollBars.Both
        For i As Integer = 1 To frmMain.StackCounter
            Sheet2.Rows(i - 1).Height = 16
        Next
    End Sub

    Private Sub btnSheet2Close_Click(sender As Object, e As EventArgs) Handles btnSheet2Close.Click
        Me.Hide()
    End Sub
End Class