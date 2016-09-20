Public Class frmPlcMonitor

    Private Sub frmPlcMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call frmMain.DGVClear(dgvPM)
        dgvPM.ColumnHeadersDefaultCellStyle.Font = New Font("ＭＳゴシック", 7)
        dgvPM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPM.Columns.Add("0", "項目")
        dgvPM.Columns.Add("1", "搬送")
        dgvPM.Columns.Add("2", "受信")
        'dgvPM.Columns.Add("3", "ST0")
        dgvPM.Columns.Add("4", "ST1")
        dgvPM.Columns.Add("5", "ST2")
        dgvPM.Columns.Add("6", "ST3")
        dgvPM.Columns.Add("7", "ST4")
        dgvPM.Columns.Add("8", "ST5")
        dgvPM.Columns.Add("9", "ST6")
        dgvPM.Columns.Add("10", "tmp")
        dgvPM.Columns.Add("11", "stack")
        dgvPM.Columns.Add("12", "Get")
        dgvPM.Columns.Add("13", "old")
        dgvPM.Columns.Add("14", "P/F")
        dgvPM.Columns.Add("15", "item")
        For i As Integer = 0 To 14
            dgvPM.Columns(i).Width = 40
        Next
        'dgvPM.RowsDefaultCellStyle.Font = New Font("ＭＳゴシック", 7)
        dgvPM.RowsDefaultCellStyle.Font = New Font("ＭＳUIゴシック", 7)
        dgvPM.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPM.RowHeadersVisible = False
        dgvPM.Rows.Add("3OVL")
        dgvPM.Rows.Add("3OVR")
        dgvPM.Rows.Add("3RVL")
        dgvPM.Rows.Add("3RVR")
        dgvPM.Rows.Add("1NCL")
        dgvPM.Rows.Add("1NCR")
        dgvPM.Rows.Add("1NOL")
        dgvPM.Rows.Add("1NOR")
        dgvPM.Rows.Add("1CGL")
        dgvPM.Rows.Add("1CGR")
        dgvPM.Rows.Add("2NCL")
        dgvPM.Rows.Add("2NCR")
        dgvPM.Rows.Add("2NOL")
        dgvPM.Rows.Add("2NOR")
        dgvPM.Rows.Add("2CGL")
        dgvPM.Rows.Add("2CGR")
        dgvPM.Rows.Add("3NCL")
        dgvPM.Rows.Add("3NCR")
        dgvPM.Rows.Add("3NOL")
        dgvPM.Rows.Add("3NOR")
        dgvPM.Rows.Add("3CGL")
        dgvPM.Rows.Add("3CGR")
        dgvPM.Rows.Add(" ")
        dgvPM.Rows.Add(" ")
        dgvPM.Rows.Add(" ")
        dgvPM.Rows.Add(" ")
        dgvPM.Rows.Add(" ")
        dgvPM.Rows.Add(" ")
        dgvPM.Rows.Add(" ")
        For i As Integer = 0 To 29
            dgvPM.Rows(i).Height = 13
        Next i
    End Sub

    Public Sub PM()
        'コントローラーリンク送信エリア
        For i As Integer = 0 To 9
            dgvPM.Item(1, i + 12).Value = frmMain.D10000(i)
        Next
        '受信エリア1（実測値）
        For i As Integer = 0 To 3
            dgvPM.Item(2, i).Value = frmMain.D13450(i)
        Next
        For i As Integer = 5 To 29
            dgvPM.Item(2, i - 1).Value = frmMain.D13450(i)
        Next
        '受信エリア２（OK/NG）
        For i As Integer = 0 To 29
            dgvPM.Item(13, i).Value = frmMain.D13500(i)
        Next
        For i As Integer = 0 To 21
            dgvPM.Item(6, i).Value = frmMain.St1a(i)
        Next
        For i As Integer = 0 To 21
            dgvPM.Item(4, i).Value = frmMain.St2a(i)
        Next
        For i As Integer = 0 To 21
            dgvPM.Item(5, i).Value = frmMain.St3a(i)
        Next
        For i As Integer = 0 To 21
            dgvPM.Item(7, i).Value = frmMain.St5a(i)
        Next
        For i As Integer = 0 To 21
            dgvPM.Item(8, i).Value = frmMain.St6a(i)
        Next
        For i As Integer = 0 To 21
            dgvPM.Item(9, i).Value = frmMain.TmpArea1(i + 1)
        Next
        For i As Integer = 1 To 22
            dgvPM.Item(10, i - 1).Value = frmMain.StackArea1(i)
        Next
        For i As Integer = 6 To 35
            dgvPM.Item(11, i - 6).Value = frmMain.GetData(i)
        Next
        For i As Integer = 6 To 35
            dgvPM.Item(12, i - 6).Value = frmMain.OldData(i)
        Next
        dgvPM.Item(14, 0).Value = "1OVL"
        dgvPM.Item(14, 1).Value = "1OVR"
        dgvPM.Item(14, 2).Value = "2OVL"
        dgvPM.Item(14, 3).Value = "2OVR"
        dgvPM.Item(14, 4).Value = "3OVL"
        dgvPM.Item(14, 5).Value = "3OVR"
        dgvPM.Item(14, 6).Value = "1RVL"
        dgvPM.Item(14, 7).Value = "1RVR"
        dgvPM.Item(14, 8).Value = "2RVL"
        dgvPM.Item(14, 9).Value = "2RVR"
        dgvPM.Item(14, 10).Value = "3RVL"
        dgvPM.Item(14, 11).Value = "3RVR"
        dgvPM.Item(14, 12).Value = "1NOL"
        dgvPM.Item(14, 13).Value = "1NOR"
        dgvPM.Item(14, 14).Value = "2NOL"
        dgvPM.Item(14, 15).Value = "2NOR"
        dgvPM.Item(14, 16).Value = "3NOL"
        dgvPM.Item(14, 17).Value = "3NOR"
        dgvPM.Item(14, 18).Value = "1NCL"
        dgvPM.Item(14, 19).Value = "1NCR"
        dgvPM.Item(14, 20).Value = "2NCL"
        dgvPM.Item(14, 21).Value = "2NCR"
        dgvPM.Item(14, 22).Value = "3NCL"
        dgvPM.Item(14, 23).Value = "3NCR"
        dgvPM.Item(14, 24).Value = "1CGL"
        dgvPM.Item(14, 25).Value = "1CGR"
        dgvPM.Item(14, 26).Value = "2CGL"
        dgvPM.Item(14, 27).Value = "2CGR"
        dgvPM.Item(14, 28).Value = "3CGL"
        dgvPM.Item(14, 29).Value = "3CGR"
    End Sub

End Class