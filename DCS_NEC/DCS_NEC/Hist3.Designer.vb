<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHist3
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
        Me.cbxCh3 = New System.Windows.Forms.ComboBox()
        Me.cbxItem3 = New System.Windows.Forms.ComboBox()
        Me.btnCloseHist3 = New System.Windows.Forms.Button()
        Me.picHist3 = New System.Windows.Forms.PictureBox()
        Me.timHist3 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.picHist3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxCh3
        '
        Me.cbxCh3.FormattingEnabled = True
        Me.cbxCh3.Location = New System.Drawing.Point(6, 25)
        Me.cbxCh3.Name = "cbxCh3"
        Me.cbxCh3.Size = New System.Drawing.Size(87, 20)
        Me.cbxCh3.TabIndex = 0
        '
        'cbxItem3
        '
        Me.cbxItem3.FormattingEnabled = True
        Me.cbxItem3.Location = New System.Drawing.Point(99, 25)
        Me.cbxItem3.Name = "cbxItem3"
        Me.cbxItem3.Size = New System.Drawing.Size(93, 20)
        Me.cbxItem3.TabIndex = 1
        '
        'btnCloseHist3
        '
        Me.btnCloseHist3.Location = New System.Drawing.Point(305, 25)
        Me.btnCloseHist3.Name = "btnCloseHist3"
        Me.btnCloseHist3.Size = New System.Drawing.Size(96, 21)
        Me.btnCloseHist3.TabIndex = 2
        Me.btnCloseHist3.Text = "Close"
        Me.btnCloseHist3.UseVisualStyleBackColor = True
        '
        'picHist3
        '
        Me.picHist3.Location = New System.Drawing.Point(6, 51)
        Me.picHist3.Name = "picHist3"
        Me.picHist3.Size = New System.Drawing.Size(401, 241)
        Me.picHist3.TabIndex = 3
        Me.picHist3.TabStop = False
        '
        'timHist3
        '
        Me.timHist3.Enabled = True
        Me.timHist3.Interval = 1000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DarkOrange
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(249, 29)
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
        Me.Label5.Location = New System.Drawing.Point(208, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "--L--"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Item"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 12)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Ch"
        '
        'frmHist3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 296)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.picHist3)
        Me.Controls.Add(Me.btnCloseHist3)
        Me.Controls.Add(Me.cbxItem3)
        Me.Controls.Add(Me.cbxCh3)
        Me.MaximizeBox = False
        Me.Name = "frmHist3"
        Me.Text = "Histogram 3"
        CType(Me.picHist3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxCh3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxItem3 As System.Windows.Forms.ComboBox
    Friend WithEvents btnCloseHist3 As System.Windows.Forms.Button
    Friend WithEvents picHist3 As System.Windows.Forms.PictureBox
    Friend WithEvents timHist3 As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
