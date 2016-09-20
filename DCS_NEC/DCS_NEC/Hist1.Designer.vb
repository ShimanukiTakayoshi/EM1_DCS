<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHist1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cbxCh1 = New System.Windows.Forms.ComboBox()
        Me.cbxItem1 = New System.Windows.Forms.ComboBox()
        Me.picHist1 = New System.Windows.Forms.PictureBox()
        Me.btnCloseHist1 = New System.Windows.Forms.Button()
        Me.timHist1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.picHist1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxCh1
        '
        Me.cbxCh1.FormattingEnabled = True
        Me.cbxCh1.Location = New System.Drawing.Point(13, 21)
        Me.cbxCh1.Name = "cbxCh1"
        Me.cbxCh1.Size = New System.Drawing.Size(96, 20)
        Me.cbxCh1.TabIndex = 0
        '
        'cbxItem1
        '
        Me.cbxItem1.FormattingEnabled = True
        Me.cbxItem1.Location = New System.Drawing.Point(115, 21)
        Me.cbxItem1.Name = "cbxItem1"
        Me.cbxItem1.Size = New System.Drawing.Size(101, 20)
        Me.cbxItem1.TabIndex = 1
        '
        'picHist1
        '
        Me.picHist1.Location = New System.Drawing.Point(13, 47)
        Me.picHist1.Name = "picHist1"
        Me.picHist1.Size = New System.Drawing.Size(390, 240)
        Me.picHist1.TabIndex = 2
        Me.picHist1.TabStop = False
        '
        'btnCloseHist1
        '
        Me.btnCloseHist1.Location = New System.Drawing.Point(306, 18)
        Me.btnCloseHist1.Name = "btnCloseHist1"
        Me.btnCloseHist1.Size = New System.Drawing.Size(97, 25)
        Me.btnCloseHist1.TabIndex = 3
        Me.btnCloseHist1.Text = "Close"
        Me.btnCloseHist1.UseVisualStyleBackColor = True
        '
        'timHist1
        '
        Me.timHist1.Enabled = True
        Me.timHist1.Interval = 1000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DarkOrange
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(263, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 12)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "--R--"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.OliveDrab
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(222, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "--L--"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(124, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Item"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 12)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Ch"
        '
        'frmHist1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCloseHist1)
        Me.Controls.Add(Me.picHist1)
        Me.Controls.Add(Me.cbxItem1)
        Me.Controls.Add(Me.cbxCh1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHist1"
        Me.Text = "Histogram 1"
        CType(Me.picHist1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxCh1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxItem1 As System.Windows.Forms.ComboBox
    Friend WithEvents picHist1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCloseHist1 As System.Windows.Forms.Button
    Friend WithEvents timHist1 As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
