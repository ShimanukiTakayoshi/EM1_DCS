Public Class frmPlcMonitor

    Private Sub frmPlcMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 400 '1024 '1800 '1024
        Me.Height = 768 '405 + 16 '768
        Call frmMain.DGVClear(dgvPM)
        dgvPM.ColumnHeadersDefaultCellStyle.Font = New Font("ＭＳゴシック", 5)
        dgvPM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPM.Columns.Add("0", "項目")
        dgvPM.Columns.Add("1", "実測")
        dgvPM.Columns.Add("2", "ST1")
        dgvPM.Columns.Add("3", "ST2")
        dgvPM.Columns.Add("4", "ST3")
        dgvPM.Columns.Add("5", "ST4")
        dgvPM.Columns.Add("6", "ST5")
        dgvPM.Columns.Add("7", "ST6")
        dgvPM.Columns.Add("8", "tmp")
        For i As Integer = 0 To 8
            dgvPM.Columns(i).Width = 25
        Next
        dgvPM.RowsDefaultCellStyle.Font = New Font("ＭＳゴシック", 5)
        dgvPM.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPM.RowHeadersVisible = False
        dgvPM.Rows.Add("3OVL")
        dgvPM.Rows.Add("3OVR")
        dgvPM.Rows.Add("3RVL")
        dgvPM.Rows.Add("3RVR")
        dgvPM.Rows.Add("3TSO")
        dgvPM.Rows.Add("1CR")
        dgvPM.Rows.Add("2CR")
        dgvPM.Rows.Add("3CR")
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
        dgvPM.Rows.Add("1OVL")
        dgvPM.Rows.Add("1OVR")
        dgvPM.Rows.Add("2OVL")
        dgvPM.Rows.Add("2OVR")
        dgvPM.Rows.Add("3OVL")
        dgvPM.Rows.Add("3OVR")
        dgvPM.Rows.Add("1RVL")
        dgvPM.Rows.Add("1RVR")
        dgvPM.Rows.Add("2RVL")
        dgvPM.Rows.Add("2RVR")
        dgvPM.Rows.Add("3RVL")
        dgvPM.Rows.Add("3RVR")
        dgvPM.Rows.Add("3TSO")
        dgvPM.Rows.Add("1CR")
        dgvPM.Rows.Add("2CR")
        dgvPM.Rows.Add("3CR")
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
        For i As Integer = 0 To 60
            dgvPM.Rows(i).Height = 10
        Next i
        'PM2
        Call frmMain.DGVClear(dgvPM2)
        dgvPM2.ColumnHeadersDefaultCellStyle.Font = New Font("ＭＳゴシック", 4)
        dgvPM2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPM2.Columns.Add("0", "項目")
        dgvPM2.Columns.Add("1", "値")
        For i As Integer = 0 To 1
            dgvPM2.Columns(i).Width = 35
        Next
        dgvPM2.RowsDefaultCellStyle.Font = New Font("ＭＳゴシック", 5)
        dgvPM2.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPM2.RowHeadersVisible = False
        dgvPM2.Rows.Add("No")
        dgvPM2.Rows.Add("Date")
        dgvPM2.Rows.Add("Time")
        dgvPM2.Rows.Add("P/F1")
        dgvPM2.Rows.Add("P/F2")
        dgvPM2.Rows.Add("P/F3")
        dgvPM2.Rows.Add("1OVL")
        dgvPM2.Rows.Add("1OVR")
        dgvPM2.Rows.Add("2OVL")
        dgvPM2.Rows.Add("2OVR")
        dgvPM2.Rows.Add("3OVL")
        dgvPM2.Rows.Add("3OVR")
        dgvPM2.Rows.Add("1RVL")
        dgvPM2.Rows.Add("1RVR")
        dgvPM2.Rows.Add("2RVL")
        dgvPM2.Rows.Add("2RVR")
        dgvPM2.Rows.Add("3RVL")
        dgvPM2.Rows.Add("3RVR")
        dgvPM2.Rows.Add("1NCL")
        dgvPM2.Rows.Add("1NCR")
        dgvPM2.Rows.Add("2NCL")
        dgvPM2.Rows.Add("2NCR")
        dgvPM2.Rows.Add("3NCL")
        dgvPM2.Rows.Add("3NCR")
        dgvPM2.Rows.Add("1NOL")
        dgvPM2.Rows.Add("1NOR")
        dgvPM2.Rows.Add("2NOL")
        dgvPM2.Rows.Add("2NOR")
        dgvPM2.Rows.Add("3NOL")
        dgvPM2.Rows.Add("3NOR")
        dgvPM2.Rows.Add("1CGL")
        dgvPM2.Rows.Add("1CGR")
        dgvPM2.Rows.Add("2CGL")
        dgvPM2.Rows.Add("2CGR")
        dgvPM2.Rows.Add("3CGL")
        dgvPM2.Rows.Add("3CGR")
        dgvPM2.Rows.Add("3TSO")
        dgvPM2.Rows.Add("1CR")
        dgvPM2.Rows.Add("2CR")
        dgvPM2.Rows.Add("3CR")
        dgvPM2.Rows.Add("1OVL")
        dgvPM2.Rows.Add("1OVR")
        dgvPM2.Rows.Add("2OVL")
        dgvPM2.Rows.Add("2OVR")
        dgvPM2.Rows.Add("3OVL")
        dgvPM2.Rows.Add("3OVR")
        dgvPM2.Rows.Add("1RVL")
        dgvPM2.Rows.Add("1RVR")
        dgvPM2.Rows.Add("2RVL")
        dgvPM2.Rows.Add("2RVR")
        dgvPM2.Rows.Add("3RVL")
        dgvPM2.Rows.Add("3RVR")
        dgvPM2.Rows.Add("1NCL")
        dgvPM2.Rows.Add("1NCR")
        dgvPM2.Rows.Add("2NCL")
        dgvPM2.Rows.Add("2NCR")
        dgvPM2.Rows.Add("3NCL")
        dgvPM2.Rows.Add("3NCR")
        dgvPM2.Rows.Add("1NOL")
        dgvPM2.Rows.Add("1NOR")
        dgvPM2.Rows.Add("2NOL")
        dgvPM2.Rows.Add("2NOR")
        dgvPM2.Rows.Add("3NOL")
        dgvPM2.Rows.Add("3NOR")
        dgvPM2.Rows.Add("1CGL")
        dgvPM2.Rows.Add("1CGR")
        dgvPM2.Rows.Add("2CGL")
        dgvPM2.Rows.Add("2CGR")
        dgvPM2.Rows.Add("3CGL")
        dgvPM2.Rows.Add("3CGR")
        dgvPM2.Rows.Add("3TSO")
        dgvPM2.Rows.Add("1CR")
        dgvPM2.Rows.Add("2CR")
        dgvPM2.Rows.Add("3CR")
        For i As Integer = 0 To 73
            dgvPM2.Rows(i).Height = 10
        Next i
    End Sub

    Public Sub PM()
        '受信エリア
        For i As Short = 1 To 60
            dgvPM.Item(1, i - 1).Value = frmMain.ViRs(i)
        Next
        'シフトエリア
        For i As Short = 1 To 6
            For j As Short = 1 To 60
                dgvPM.Item(1 + i, j - 1).Value = frmMain.ViSt(i, j)
            Next
        Next
        'Tmpエリア
        For i As Short = 1 To 60
            dgvPM.Item(8, i - 1).Value = frmMain.ViTmp(i)
        Next
        '転送エリア
        For i As Short = 0 To 73
            dgvPM2.Item(1, i).Value = frmMain.ViTr(i)
        Next

    End Sub

End Class