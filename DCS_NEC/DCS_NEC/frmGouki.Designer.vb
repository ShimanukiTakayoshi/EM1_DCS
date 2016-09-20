<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGouki
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
        Me.lblGouki = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGoukiUp = New System.Windows.Forms.Button()
        Me.btnGoukiDown = New System.Windows.Forms.Button()
        Me.btnGoukiOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblGouki
        '
        Me.lblGouki.AutoSize = True
        Me.lblGouki.Font = New System.Drawing.Font("ＭＳ ゴシック", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGouki.Location = New System.Drawing.Point(260, 9)
        Me.lblGouki.Name = "lblGouki"
        Me.lblGouki.Size = New System.Drawing.Size(91, 97)
        Me.lblGouki.TabIndex = 0
        Me.lblGouki.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 48)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ラインNo."
        '
        'btnGoukiUp
        '
        Me.btnGoukiUp.Font = New System.Drawing.Font("ＭＳ ゴシック", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnGoukiUp.Location = New System.Drawing.Point(456, 17)
        Me.btnGoukiUp.Name = "btnGoukiUp"
        Me.btnGoukiUp.Size = New System.Drawing.Size(85, 70)
        Me.btnGoukiUp.TabIndex = 2
        Me.btnGoukiUp.Text = "+"
        Me.btnGoukiUp.UseVisualStyleBackColor = True
        '
        'btnGoukiDown
        '
        Me.btnGoukiDown.Font = New System.Drawing.Font("ＭＳ ゴシック", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnGoukiDown.Location = New System.Drawing.Point(365, 17)
        Me.btnGoukiDown.Name = "btnGoukiDown"
        Me.btnGoukiDown.Size = New System.Drawing.Size(85, 70)
        Me.btnGoukiDown.TabIndex = 3
        Me.btnGoukiDown.Text = "-"
        Me.btnGoukiDown.UseVisualStyleBackColor = True
        '
        'btnGoukiOk
        '
        Me.btnGoukiOk.Font = New System.Drawing.Font("ＭＳ ゴシック", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnGoukiOk.Location = New System.Drawing.Point(132, 137)
        Me.btnGoukiOk.Name = "btnGoukiOk"
        Me.btnGoukiOk.Size = New System.Drawing.Size(303, 86)
        Me.btnGoukiOk.TabIndex = 4
        Me.btnGoukiOk.Text = "OK"
        Me.btnGoukiOk.UseVisualStyleBackColor = True
        '
        'frmGouki
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnGoukiOk)
        Me.Controls.Add(Me.btnGoukiDown)
        Me.Controls.Add(Me.btnGoukiUp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblGouki)
        Me.Name = "frmGouki"
        Me.Text = "生産ライン番号設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGouki As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGoukiUp As System.Windows.Forms.Button
    Friend WithEvents btnGoukiDown As System.Windows.Forms.Button
    Friend WithEvents btnGoukiOk As System.Windows.Forms.Button
End Class
