Public Class frmGouki

    Private Sub frmGouki_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblGouki.Text = Trim(Str(frmMain.Gouki))
    End Sub

    Private Sub btnGoukiUp_Click(sender As Object, e As EventArgs) Handles btnGoukiUp.Click
        If frmMain.Gouki < 9 Then
            frmMain.Gouki += 1
            lblGouki.Text = Trim(Str(frmMain.Gouki))
        End If
    End Sub

    Private Sub btnGoukiDown_Click(sender As Object, e As EventArgs) Handles btnGoukiDown.Click
        If frmMain.Gouki > 1 Then
            frmMain.Gouki -= 1
            lblGouki.Text = Trim(Str(frmMain.Gouki))
        End If
    End Sub

    Private Sub btnGoukiOk_Click(sender As Object, e As EventArgs) Handles btnGoukiOk.Click
        Me.Hide()
    End Sub
End Class