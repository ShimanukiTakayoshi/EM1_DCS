Public Class frmYieldColor
    Private Sub frmYieldColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAl1.Text = Str(frmMain.AlarmLevel1)
        txtAl2.Text = Str(frmMain.AlarmLevel2)
    End Sub

    Private Sub btnAlSet_Click(sender As Object, e As EventArgs) Handles btnAlSet.Click
        Dim s1 As String = Trim(txtAl1.Text)
        Dim s2 As String = Trim(txtAl2.Text)
        If frmMain.MathCheck(s1) = True And frmMain.MathCheck(s2) = True And s1 <> "" And s2 <> "" Then
            Dim a1 As Single = CSng(Val(s1))
            Dim a2 As Single = CSng(Val(s2))
            If s1 > s2 Then
                frmMain.AlarmLevel1 = a1
                frmMain.AlarmLevel2 = a2
            Else
                MessageBox.Show("[注意ﾚﾍﾞﾙ]＞[異常ﾚﾍﾞﾙ]になるようにして下さい")
            End If
            frmMain.AlarmLevel2 = CSng(txtAl2.Text)
        Else
            MessageBox.Show("数値を入力して下さい")
            Exit Sub
        End If
    End Sub

    Private Sub btnAlClose_Click(sender As Object, e As EventArgs) Handles btnAlClose.Click
        Try
            Dim ofile As String = "C:\DCS\0_DCS_System\AlarmLevel.txt"
            System.IO.File.Delete(ofile)
            Dim sw As System.IO.StreamWriter
            sw = New System.IO.StreamWriter(ofile, True, System.Text.Encoding.GetEncoding(932))
            sw.WriteLine(Str(frmMain.AlarmLevel1))
            sw.WriteLine(Str(frmMain.AlarmLevel2))
            sw.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
        Me.Close()
    End Sub

End Class