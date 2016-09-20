Option Strict On
Imports System.IO


Public Class frmSheetSetting
  
    Private Sub frmSheetSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ラベルの左スパンと上スパン
        Const intOffsetX As Integer = 10, intOffsetY As Integer = 50
        'コントロールの高さと幅
        Const intHeight As Integer = 20, intWidth As Integer = 100
        'コントロールとコントロールのスパン
        Const intVspan As Integer = 20, intHspan As Integer = 10
        'コントロールの位置を設定
        For i As Integer = 1 To 40
            With Label(i)
                .SetBounds(intOffsetX, intVspan * (i - 1) + _
                            intOffsetY, intWidth, intHeight)
                .Text = "項目" & i.ToString
            End With
            With CheckBox(i)
                .SetBounds(Label(1).Left + Label(1).Width + intHspan, intVspan * (i - 1) + _
                             intOffsetY, intWidth, intHeight)
                .Text = ""
            End With
            With ListBox(i)
                .SetBounds(CheckBox(1).Left + Label(1).Width - 10, intVspan * (i - 1) + _
                             intOffsetY, intWidth, intHeight)
                '.Text = ""
            End With
            'テキストボックスは２倍の幅を設定
            With TextBox(i)
                .SetBounds(ListBox(1).Left + ListBox(1).Width + intHspan, _
                        intVspan * (i - 1) + intOffsetY, CInt(intWidth / 4), intHeight)
                .Text = String.Empty
            End With
        Next

        For i As Integer = 41 To 60
            With Label(i)
                .SetBounds(intOffsetX + 300, intVspan * (i - 1 - 40) + _
                            intOffsetY, intWidth, intHeight)
                .Text = "項目" & i.ToString
            End With
            With CheckBox(i)
                .SetBounds(Label(41).Left + Label(41).Width + intHspan, intVspan * (i - 1 - 40) + _
                             intOffsetY, intWidth, intHeight)
                .Text = ""
            End With
            With ListBox(i)
                .SetBounds(CheckBox(41).Left + Label(41).Width - 10, intVspan * (i - 1 - 40) + _
                             intOffsetY, intWidth, intHeight)
                '.Text = ""
            End With
            'テキストボックスは２倍の幅を設定
            With TextBox(i)
                .SetBounds(ListBox(41).Left + ListBox(41).Width + intHspan, _
                        intVspan * (i - 1 - 40) + intOffsetY, CInt(intWidth / 4), intHeight)
                .Text = String.Empty
            End With
        Next
        'イベントの追加
        For i As Integer = 1 To 40
            'AddHandler Button(i).Click, AddressOf Button_Click
            AddHandler CheckBox(i).CheckedChanged, AddressOf CheckBox_Checked
            AddHandler ListBox(i).SelectedIndexChanged, AddressOf ListBox_IndexChanged
        Next

        For i As Integer = 41 To 60
            AddHandler CheckBox(i).CheckedChanged, AddressOf CheckBox_Checked
            AddHandler ListBox(i).SelectedIndexChanged, AddressOf ListBox_IndexChanged
        Next

        For i As Integer = 1 To 60
            With ListBox(i)
                For j As Integer = 0 To 59
                    .Items.Add(frmMain.ItemName(j))
                Next j
            End With
        Next
        For i As Integer = 0 To 59
            With CheckBox(i + 1)
                If frmMain.ItemCheck(i) = True Then
                    .CheckState = CheckState.Checked
                Else
                    .CheckState = CheckState.Unchecked
                End If
            End With
            With ListBox(i + 1)
                .SelectedIndex = frmMain.ItemSelect(i)
            End With
            With TextBox(i + 1)
                .Text = Str(frmMain.ItemWidth(i))
            End With
        Next
    End Sub

    '引数indexに番号を受け取って、その番号が付いたLabelコントロールを返す
    Private Function Label(ByVal index As Integer) As Label
        Return DirectCast(Me.Controls("Label" & index.ToString), Label)
    End Function
    '引数indexに番号を受け取って、その番号が付いたCheckBoxコントロールを返す
    Private Function CheckBox(ByVal index As Integer) As CheckBox
        Return DirectCast(Me.Controls("CheckBox" & index.ToString), CheckBox)
    End Function
    '引数indexに番号を受け取って、その番号が付いたListBoxコントロールを返す
    Private Function ListBox(ByVal index As Integer) As ListBox
        Return DirectCast(Me.Controls("ListBox" & index.ToString), ListBox)
    End Function
    '引数indexに番号を受け取って、その番号が付いたTextBoxコントロールを返す
    Private Function TextBox(ByVal index As Integer) As TextBox
        Return DirectCast(Me.Controls("TextBox" & index.ToString), TextBox)
    End Function
    '引数indexに番号を受け取って、その番号が付いたButtonコントロールを返す
    Private Function Button(ByVal index As Integer) As Button
        Return DirectCast(Me.Controls("Button" & index.ToString), Button)
    End Function

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'イベントの送り側の名前を取得
        Dim senderName As String = DirectCast(sender, Button).Name
        'ボタンのベース名　長さの取得に使用
        Dim strBut As String = "Button"
        'Buttonxxのxxを取得して数字に直している
        Dim index As Integer = CInt(senderName.Substring(strBut.Length, _
                                    senderName.Length - strBut.Length))
        '取得したインデックスで各ボタンのクリックイベントを処理
        Select Case index
            Case 1
                TextBox(1).Text = "ボタン１が押されました"
            Case 2
                TextBox(2).Text = "ボタン２が押されました"
            Case Else
                TextBox(index).Text = "ボタン" & index.ToString & "が押されました"
        End Select
    End Sub

    Private Sub CheckBox_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'イベントの送り側の名前を取得
        Dim senderName As String = DirectCast(sender, CheckBox).Name
        'ボタンのベース名　長さの取得に使用
        Dim strBut As String = "CheckBox"
        'Buttonxxのxxを取得して数字に直している
        Dim index As Integer = CInt(senderName.Substring(strBut.Length, _
                                    senderName.Length - strBut.Length))
        '取得したインデックスで各ボタンのクリックイベントを処理
        'Select Case index
        '    Case 1
        '        If CheckBox(1).Checked = True Then
        '            TextBox(1).Text = "check1 True"
        '        Else
        '            TextBox(1).Text = "check1 False"
        '        End If
        '    Case 2
        '        TextBox(2).Text = "check２が押されました"
        '    Case Else
        '        TextBox(index).Text = "check" & index.ToString & "が押されました"
        'End Select
    End Sub

    Private Sub ListBox_IndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'イベントの送り側の名前を取得
        Dim senderName As String = DirectCast(sender, ListBox).Name
        'ボタンのベース名　長さの取得に使用
        Dim strBut As String = "ListBox"
        'Buttonxxのxxを取得して数字に直している
        Dim index As Integer = CInt(senderName.Substring(strBut.Length, _
                                    senderName.Length - strBut.Length))
        ''取得したインデックスで各ボタンのクリックイベントを処理
        'Select Case index
        '    Case 1
        '        TextBox(1).Text = Str(ListBox(1).SelectedIndex)
        '    Case 2
        '        TextBox(2).Text = Str(ListBox(index).SelectedIndex)
        '    Case Else
        '        TextBox(index).Text = Str(ListBox(index).SelectedIndex)
        'End Select
    End Sub

    Private Sub btnSettingCancel_Click(sender As Object, e As EventArgs) Handles btnSettingCancel.Click
        frmMain.PassWordFlag = False
        Me.Close()
    End Sub

    Private Sub btnSettingSet_Click(sender As Object, e As EventArgs) Handles btnSettingSet.Click
        For i As Integer = 0 To 59
            frmMain.ItemCheck(i) = CheckBox(i + 1).Checked
            frmMain.ItemSelect(i) = ListBox(i + 1).SelectedIndex
            frmMain.ItemWidth(i) = CInt(Val(TextBox(i + 1).Text))
        Next
        Try
            Dim ofile As String = "C:\DCS\0_DCS_System\SETTING.txt"
            System.IO.File.Delete(ofile)
            Dim sw As System.IO.StreamWriter
            sw = New System.IO.StreamWriter(ofile, True, System.Text.Encoding.GetEncoding(932))
            For i As Integer = 0 To 59
                Dim CheckBoxVale As String
                If frmMain.ItemCheck(i) = True Then
                    CheckBoxVale = "1"
                Else
                    CheckBoxVale = "0"
                End If
                sw.WriteLine(CheckBoxVale + "," + Str(frmMain.ItemSelect(i)) + "," + Str(frmMain.ItemWidth(i)))
            Next i
            frmMain.PassWordFlag = False
            sw.Close()
            Call frmMain.DGVClear(frmMain.Sheet)
            Call frmMain.SheetInit()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub
End Class