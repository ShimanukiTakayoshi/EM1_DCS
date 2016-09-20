Public Class frmTypeSelect
    Public SelectCode As Integer = 0

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If SelectCode < 9 Then
            SelectCode += 1
            txtTypeCode.Text = Trim(Str(SelectCode))
            TxtTypeName.Text = frmMain.TypeData(SelectCode, 1)
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If SelectCode > 0 Then
            SelectCode -= 1
            txtTypeCode.Text = Trim(Str(SelectCode))
            TxtTypeName.Text = frmMain.TypeData(SelectCode, 1)
        End If
    End Sub

    Private Sub frmTypeSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelectCode = frmMain.TypeCode
        txtTypeCode.Text = Trim(Str(SelectCode))
        TxtTypeName.Text = frmMain.TypeData(SelectCode, 1)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        frmMain.TypeCode = SelectCode
        frmMain.txtType.Text = Trim(Str(frmMain.TypeCode))
        frmMain.txtName.Text = Trim(frmMain.TypeData(SelectCode, 1))
        Me.Close()
    End Sub
End Class