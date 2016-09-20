<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmYieldColor
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAl1 = New System.Windows.Forms.TextBox()
        Me.txtAl2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAlSet = New System.Windows.Forms.Button()
        Me.btnAlClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "注意レベル"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Red
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(16, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "異常レベル"
        '
        'txtAl1
        '
        Me.txtAl1.BackColor = System.Drawing.Color.Yellow
        Me.txtAl1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAl1.Location = New System.Drawing.Point(144, 41)
        Me.txtAl1.Name = "txtAl1"
        Me.txtAl1.Size = New System.Drawing.Size(55, 28)
        Me.txtAl1.TabIndex = 2
        '
        'txtAl2
        '
        Me.txtAl2.BackColor = System.Drawing.Color.Red
        Me.txtAl2.CausesValidation = False
        Me.txtAl2.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtAl2.ForeColor = System.Drawing.Color.Yellow
        Me.txtAl2.Location = New System.Drawing.Point(144, 82)
        Me.txtAl2.Name = "txtAl2"
        Me.txtAl2.Size = New System.Drawing.Size(55, 28)
        Me.txtAl2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(205, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(205, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(217, 21)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "良品率異常レベル設定"
        '
        'btnAlSet
        '
        Me.btnAlSet.Location = New System.Drawing.Point(57, 126)
        Me.btnAlSet.Name = "btnAlSet"
        Me.btnAlSet.Size = New System.Drawing.Size(116, 24)
        Me.btnAlSet.TabIndex = 7
        Me.btnAlSet.Text = "SET"
        Me.btnAlSet.UseVisualStyleBackColor = True
        '
        'btnAlClose
        '
        Me.btnAlClose.Location = New System.Drawing.Point(55, 165)
        Me.btnAlClose.Name = "btnAlClose"
        Me.btnAlClose.Size = New System.Drawing.Size(117, 27)
        Me.btnAlClose.TabIndex = 8
        Me.btnAlClose.Text = "Close/Cancel"
        Me.btnAlClose.UseVisualStyleBackColor = True
        '
        'frmYieldColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 201)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAlClose)
        Me.Controls.Add(Me.btnAlSet)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAl2)
        Me.Controls.Add(Me.txtAl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmYieldColor"
        Me.Text = "良品率異常ﾚﾍﾞﾙ設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAl1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAl2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAlSet As System.Windows.Forms.Button
    Friend WithEvents btnAlClose As System.Windows.Forms.Button
End Class
