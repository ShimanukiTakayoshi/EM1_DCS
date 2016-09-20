Public Class frmPassword

    Private Sub frmPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnPasswordOk_Click(sender As Object, e As EventArgs) Handles btnPasswordOk.Click
        If frmMain.PassWord = Trim(txtPassword.Text) Then
            frmMain.PassWordFlag = True
            Me.Close()
        Else
            MessageBox.Show("ﾊﾟｽﾜｰﾄﾞが間違っています")
        End If
    End Sub
End Class