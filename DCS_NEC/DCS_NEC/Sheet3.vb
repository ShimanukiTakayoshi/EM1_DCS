Public Class frmSheet3
    Dim ItemCv(20) As Integer

    Private Sub frmSheet3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ItemCv(0) = 0
        ItemCv(1) = 1
        ItemCv(2) = 2
        ItemCv(3) = 5
        ItemCv(4) = 10
        ItemCv(5) = 11
        ItemCv(6) = 16
        ItemCv(7) = 17
        ItemCv(8) = 22
        ItemCv(9) = 23
        ItemCv(10) = 28
        ItemCv(11) = 29
        ItemCv(12) = 34
        ItemCv(13) = 35
        ItemCv(14) = 36
        ItemCv(15) = 39
        ItemCv(16) = 0
        ItemCv(17) = 0
        ItemCv(18) = 0
        ItemCv(19) = 0
        SheetInit3()
    End Sub

    Public Sub SheetInit3()
        Me.Width = 635 + 40 + 40
        Me.Height = 420
        Sheet3.Width = 613 + 40 + 40
        Sheet3.Height = 342
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        If frmMain.Sheet3FirstFlag Then
            Sheet3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim j As Integer = 0
            For i As Integer = 0 To 15
                If frmMain.ItemCheck(40 + i) Then
                    Sheet3.Columns.Add(Trim(Str(j)), frmMain.ItemName(frmMain.ItemSelect(40 + i)))
                    Sheet3.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Sheet3.Columns(j).Width = frmMain.ItemWidth(40 + i)
                    j = j + 1
                End If
            Next i
            For i As Integer = 0 To 99
                Sheet3.Rows.Add("")
            Next
            For i As Integer = 1 To 100
                Sheet3.Rows(i - 1).Height = 16
            Next
            Sheet3.RowHeadersVisible = False
        End If
    End Sub

    Public Sub DataSheet3()
        'Sheet3.Visible = False
        Sheet3.SuspendLayout()
        If frmMain.Sheet3FirstFlag Then
            frmMain.DGVClear(Sheet3)
            SheetInit3()
            frmMain.Sheet3FirstFlag = False
        End If
        'シート表示高速化
        Dim myType As System.Type = GetType(DataGridView)
        Dim myPropertyInfo As System.Reflection.PropertyInfo = myType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        myPropertyInfo.SetValue(Sheet3, True, Nothing)
        Sheet3.AllowUserToResizeRows = False
        Sheet3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Sheet3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        Sheet3.RowTemplate.Height = 10
        For i As Integer = 1 To frmMain.StackCounter
            Dim k As Integer = 0
            For j As Integer = 0 To 19
                Dim sn As String
                If frmMain.ItemCheck(40 + j) Then
                    Dim x As Integer = frmMain.ItemSelect(j)
                    Dim s As String = frmMain.StackData(1, 0)
                    sn = Trim(frmMain.StackData(i, ItemCv((frmMain.ItemSelect(40 + j)) - 40)))
                    Sheet3.Item(k, i).Value = sn
                    Sheet3.Item(k, i).Style.ForeColor = Color.Black
                    Select Case (frmMain.ItemSelect(40 + j) - 40)
                        Case 3
                            If sn <> "Pass" Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                        Case 4, 5
                            If Val(sn) < frmMain.LimOVLo Or Val(sn) > frmMain.LimOVHi Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                        Case 6, 7
                            If Val(sn) < frmMain.LimRVLo Or Val(sn) > frmMain.LimRVHi Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                        Case 8, 9
                            If Val(sn) < frmMain.LimNOLo Or Val(sn) > frmMain.LimNOHi Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                        Case 10 To 11
                            If Val(sn) < frmMain.LimNCLo Or Val(sn) > frmMain.LimNCHi Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                        Case 12, 13
                            If Val(sn) < frmMain.LimCGLo Or Val(sn) > frmMain.LimCGHi Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                        Case 14
                            If Val(sn) < frmMain.LimTOLo Or Val(sn) > frmMain.LimTOHi Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                        Case 15
                            If Val(sn) < frmMain.LimCRLo Or Val(sn) > frmMain.LimCRHi Then Sheet3.Item(k, i).Style.ForeColor = Color.Red
                    End Select
                    k = k + 1
                End If
            Next
        Next
        Sheet3.ResumeLayout()
        Sheet3.ScrollBars = ScrollBars.Both
        For i As Integer = 1 To frmMain.StackCounter
            Sheet3.Rows(i - 1).Height = 16
        Next
    End Sub

    Private Sub btnSheet3Close_Click(sender As Object, e As EventArgs) Handles btnSheet3Close.Click
        Me.Hide()
    End Sub
End Class