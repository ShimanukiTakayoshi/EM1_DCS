Public Class frmPassword

    Private Sub frmPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnPasswordOk_Click(sender As Object, e As EventArgs) Handles btnPasswordOk.Click
        PasswordCheck()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Return Then
            PasswordCheck()
        End If
    End Sub

    Private Sub PasswordCheck()
        If frmMain.PassWord = Trim(txtPassword.Text) Then
            frmMain.PassWordFlag = True
            Me.Close()
        Else
            MessageBox.Show("ﾊﾟｽﾜｰﾄﾞが間違っています")
        End If
    End Sub
End Class