Public Class frmSheet1
    Dim ItemCv(20) As Integer

    Private Sub frmSheet1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ItemCv(0) = 0
        ItemCv(1) = 1
        ItemCv(2) = 2
        ItemCv(3) = 3
        ItemCv(4) = 6
        ItemCv(5) = 7
        ItemCv(6) = 12
        ItemCv(7) = 13
        ItemCv(8) = 18
        ItemCv(9) = 19
        ItemCv(10) = 24
        ItemCv(11) = 25
        ItemCv(12) = 30
        ItemCv(13) = 31
        ItemCv(14) = 37
        ItemCv(15) = 0
        ItemCv(16) = 0
        ItemCv(17) = 0
        ItemCv(18) = 0
        ItemCv(19) = 0
        SheetInit1()
    End Sub

    Public Sub SheetInit1()
        Me.Width = 635 + 40
        Me.Height = 420
        Sheet1.Width = 613 + 40
        Sheet1.Height = 342
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        If frmMain.Sheet1FirstFlag Then
            Sheet1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim j As Integer = 0
            For i As Integer = 0 To 13
                If frmMain.ItemCheck(40 + i) Then
                    Sheet1.Columns.Add(Trim(Str(j)), frmMain.ItemName(frmMain.ItemSelect(40 + i)))
                    Sheet1.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Sheet1.Columns(j).Width = frmMain.ItemWidth(40 + i)
                    j = j + 1
                End If
            Next i
            If frmMain.ItemCheck(40 + 15) Then
                Sheet1.Columns.Add(Trim(Str(j)), frmMain.ItemName(frmMain.ItemSelect(40 + 15)))
                Sheet1.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Sheet1.Columns(j).Width = frmMain.ItemWidth(40 + 15)
            End If
            For i As Integer = 0 To 99
                Sheet1.Rows.Add("")
            Next
            For i As Integer = 1 To 100
                Sheet1.Rows(i - 1).Height = 16
            Next
            Sheet1.RowHeadersVisible = False
        End If
    End Sub

    Public Sub DataSheet1()
        Sheet1.SuspendLayout()
        If frmMain.Sheet1FirstFlag Then
            frmMain.DGVClear(Sheet1)
            SheetInit1()
            frmMain.Sheet1FirstFlag = False
        End If
        'シート表示高速化
        Dim myType As System.Type = GetType(DataGridView)
        Dim myPropertyInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        myPropertyInfo.SetValue(Sheet1, True, Nothing)
        Sheet1.AllowUserToResizeRows = False
        Sheet1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Sheet1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Sheet1.RowTemplate.Height = 10
        'シート表示
        For i As Integer = 1 To frmMain.StackCounter
            Dim k As Integer = 0
            For j As Integer = 0 To 14
                Dim sn As String
                If frmMain.ItemCheck(40 + j) Then
                    Dim x As Integer = frmMain.ItemSelect(j)
                    Dim s As String = frmMain.StackData(1, 0)
                    sn = Trim(frmMain.StackData(i, ItemCv((frmMain.ItemSelect(40 + j)) - 40)))
                    Sheet1.Item(k, i).Value = sn
                    Sheet1.Item(k, i).Style.ForeColor = Color.Black
                    Select Case (frmMain.ItemSelect(40 + j) - 40)
                        Case 3
                            If sn <> "Pass" Then Sheet1.Item(k, i).Style.ForeColor = Color.Red
                        Case 4 To 7
                            If sn <> "OK" Then Sheet1.Item(k, i).Style.ForeColor = Color.Red
                        Case 8, 9
                            If Val(sn) < frmMain.LimNOLo Or Val(sn) > frmMain.LimNOHi Then Sheet1.Item(k, i).Style.ForeColor = Color.Red
                        Case 10, 11
                            If Val(sn) < frmMain.LimNCLo Or Val(sn) > frmMain.LimNCHi Then Sheet1.Item(k, i).Style.ForeColor = Color.Red
                        Case 12, 13
                            If Val(sn) < frmMain.LimCGLo Or Val(sn) > frmMain.LimCGHi Then Sheet1.Item(k, i).Style.ForeColor = Color.Red
                        Case 14
                            If Val(sn) < frmMain.LimCRLo Or Val(sn) > frmMain.LimCRHi Then Sheet1.Item(k, i).Style.ForeColor = Color.Red
                    End Select
                    k = k + 1
                End If
            Next
        Next
        Sheet1.ResumeLayout()
        Sheet1.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub btnSheet1Close_Click(sender As Object, e As EventArgs) Handles btnSheet1Close.Click
        Me.Hide()
    End Sub
End Class