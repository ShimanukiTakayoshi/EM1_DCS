Public Class frmTypeSetting
    Dim TypeSheetMakingFlag As Boolean = False

    Private Sub frmTypeSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TypeSheetMakingFlag = True
        Call frmMain.DGVClear(dgvType)
        dgvType.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvType.Columns.Add("0", "Code")
        dgvType.Columns.Add("1", "機種名")
        dgvType.Columns.Add("2", "OVL")
        dgvType.Columns.Add("3", "OVH")
        dgvType.Columns.Add("4", "OVLG")
        dgvType.Columns.Add("5", "OVHG")
        dgvType.Columns.Add("6", "RVL")
        dgvType.Columns.Add("7", "RVH")
        dgvType.Columns.Add("8", "RVLG")
        dgvType.Columns.Add("9", "RVHG")
        dgvType.Columns.Add("10", "NOL")
        dgvType.Columns.Add("11", "NOH")
        dgvType.Columns.Add("12", "NOLG")
        dgvType.Columns.Add("13", "NOHG")
        dgvType.Columns.Add("14", "NCL")
        dgvType.Columns.Add("15", "NCH")
        dgvType.Columns.Add("16", "NCLG")
        dgvType.Columns.Add("17", "NCHG")
        dgvType.Columns.Add("18", "CGL")
        dgvType.Columns.Add("19", "CGH")
        dgvType.Columns.Add("20", "CGLG")
        dgvType.Columns.Add("21", "CGHG")
        dgvType.Columns.Add("22", "TSL")
        dgvType.Columns.Add("23", "TSH")
        dgvType.Columns.Add("24", "TSLG")
        dgvType.Columns.Add("25", "TSHG")
        dgvType.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        For i As Integer = 0 To 25
            dgvType.Columns(i).Width = 40
        Next
        dgvType.Columns(1).Width = 125
        dgvType.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvType.RowHeadersVisible = False
        For i As Integer = 0 To 9
            dgvType.Rows.Add("0")
        Next i
        dgvType.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        For i As Integer = 0 To 9
            For j As Integer = 0 To 25
                Dim b As String
                b = frmMain.TypeData(i, j)
                dgvType.Item(j, i).Value = frmMain.TypeData(i, j)
                dgvType.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        Next
        dgvType.ScrollBars = ScrollBars.Horizontal
        dgvType.Columns(0).ReadOnly = True
        dgvType.Columns(0).Frozen = True
        TypeSheetMakingFlag = False
    End Sub

    Private Sub dgvType_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvType.CellValueChanged
        '機種データ一覧表編集
        '一覧表描写中はこのイベントを無視する。
        If TypeSheetMakingFlag = True Then Exit Sub
        'アクティブな行、桁を取得する
        Dim ActRow As Integer = dgvType.CurrentCell.RowIndex
        Dim ActCol As Integer = dgvType.CurrentCell.ColumnIndex
        '機種名の欄の場合はこのイベントを無視する。
        If ActCol = 1 Then Exit Sub
        '変更された値が数値以外の場合、前の値に戻す。
        Try
            Dim actVal As String = dgvType.CurrentCell.Value.ToString()
            actVal = Trim(actVal)
            If Len(actVal) = 0 Then
                dgvType.Item(ActRow, ActCol).Value = frmMain.TypeData(ActCol, ActRow)
                Exit Sub
            End If
            For i As Integer = 1 To Len(actVal)
                Dim s1 As Integer = Asc(Strings.Mid(actVal, i, 1))
                If (s1 < &H30 Or s1 > &H39) And s1 <> &H2E Then
                    dgvType.Item(ActCol, ActRow).Value = frmMain.TypeData(ActRow, ActCol)
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            'DGVより取得した値が""ヌルの場合エラーになるので回避
            dgvType.Item(ActCol, ActRow).Value = frmMain.TypeData(ActRow, ActCol)
        End Try
    End Sub

    Private Sub btnTypeWrite_Click(sender As Object, e As EventArgs) Handles btnTypeWrite.Click
        For i As Integer = 0 To 9
            For j As Integer = 0 To 25
                frmMain.TypeData(i, j) = CStr(dgvType.Item(j, i).Value)
            Next
        Next
        Try
            Dim ofile As String = "C:\DCS\0_DCS_System\TYPE.txt"
            System.IO.File.Delete(ofile)
            Dim sw As System.IO.StreamWriter
            sw = New System.IO.StreamWriter(ofile, True, System.Text.Encoding.GetEncoding(932))

            For i As Integer = 0 To 9
                Dim b As String = ""
                For j As Integer = 0 To 24
                    b = b + frmMain.TypeData(i, j) + ","
                Next
                b = b + frmMain.TypeData(i, 25)
                sw.WriteLine(b)
            Next
            sw.Close()
            frmMain.LoadTypeData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Private Sub btnTypeDataClose_Click(sender As Object, e As EventArgs) Handles btnTypeDataClose.Click
        frmMain.PassWordFlag = False
        Me.Close()
    End Sub
End Class