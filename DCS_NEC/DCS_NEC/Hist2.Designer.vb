<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHist2
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
        Me.cbxCh2 = New System.Windows.Forms.ComboBox()
        Me.cbxItem2 = New System.Windows.Forms.ComboBox()
        Me.btnCloseHist2 = New System.Windows.Forms.Button()
        Me.picHist2 = New System.Windows.Forms.PictureBox()
        Me.timHist2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.picHist2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxCh2
        '
        Me.cbxCh2.FormattingEnabled = True
        Me.cbxCh2.Location = New System.Drawing.Point(12, 28)
        Me.cbxCh2.Name = "cbxCh2"
        Me.cbxCh2.Size = New System.Drawing.Size(87, 20)
        Me.cbxCh2.TabIndex = 0
        '
        'cbxItem2
        '
        Me.cbxItem2.FormattingEnabled = True
        Me.cbxItem2.Location = New System.Drawing.Point(105, 28)
        Me.cbxItem2.Name = "cbxItem2"
        Me.cbxItem2.Size = New System.Drawing.Size(91, 20)
        Me.cbxItem2.TabIndex = 1
        '
        'btnCloseHist2
        '
        Me.btnCloseHist2.Location = New System.Drawing.Point(300, 28)
        Me.btnCloseHist2.Name = "btnCloseHist2"
        Me.btnCloseHist2.Size = New System.Drawing.Size(101, 20)
        Me.btnCloseHist2.TabIndex = 2
        Me.btnCloseHist2.Text = "Close"
        Me.btnCloseHist2.UseVisualStyleBackColor = True
        '
        'picHist2
        '
        Me.picHist2.Location = New System.Drawing.Point(11, 54)
        Me.picHist2.Name = "picHist2"
        Me.picHist2.Size = New System.Drawing.Size(392, 237)
        Me.picHist2.TabIndex = 3
        Me.picHist2.TabStop = False
        '
        'timHist2
        '
        Me.timHist2.Enabled = True
        Me.timHist2.Interval = 1000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DarkOrange
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(252, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 12)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "--R--"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.OliveDrab
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(211, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "--L--"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Item"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 12)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Ch"
        '
        'frmHist2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 297)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.picHist2)
        Me.Controls.Add(Me.btnCloseHist2)
        Me.Controls.Add(Me.cbxItem2)
        Me.Controls.Add(Me.cbxCh2)
        Me.MaximizeBox = False
        Me.Name = "frmHist2"
        Me.Text = "Histogram 2"
        CType(Me.picHist2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxCh2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxItem2 As System.Windows.Forms.ComboBox
    Friend WithEvents btnCloseHist2 As System.Windows.Forms.Button
    Friend WithEvents picHist2 As System.Windows.Forms.PictureBox
    Friend WithEvents timHist2 As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
