<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTypeSetting
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
        Me.dgvType = New System.Windows.Forms.DataGridView()
        Me.btnTypeWrite = New System.Windows.Forms.Button()
        Me.btnTypeDataClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvType
        '
        Me.dgvType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvType.Location = New System.Drawing.Point(12, 50)
        Me.dgvType.Name = "dgvType"
        Me.dgvType.RowTemplate.Height = 21
        Me.dgvType.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvType.Size = New System.Drawing.Size(1288, 231)
        Me.dgvType.TabIndex = 0
        '
        'btnTypeWrite
        '
        Me.btnTypeWrite.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnTypeWrite.Location = New System.Drawing.Point(231, 5)
        Me.btnTypeWrite.Name = "btnTypeWrite"
        Me.btnTypeWrite.Size = New System.Drawing.Size(157, 39)
        Me.btnTypeWrite.TabIndex = 1
        Me.btnTypeWrite.Text = "Set"
        Me.btnTypeWrite.UseVisualStyleBackColor = True
        '
        'btnTypeDataClose
        '
        Me.btnTypeDataClose.Font = New System.Drawing.Font("ＭＳ ゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnTypeDataClose.Location = New System.Drawing.Point(415, 5)
        Me.btnTypeDataClose.Name = "btnTypeDataClose"
        Me.btnTypeDataClose.Size = New System.Drawing.Size(167, 38)
        Me.btnTypeDataClose.TabIndex = 2
        Me.btnTypeDataClose.Text = "Close/Cancel"
        Me.btnTypeDataClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "機種情報設定"
        '
        'frmTypeSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1307, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTypeDataClose)
        Me.Controls.Add(Me.btnTypeWrite)
        Me.Controls.Add(Me.dgvType)
        Me.MaximizeBox = False
        Me.Name = "frmTypeSetting"
        Me.Text = "Type Data"
        CType(Me.dgvType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvType As System.Windows.Forms.DataGridView
    Friend WithEvents btnTypeWrite As System.Windows.Forms.Button
    Friend WithEvents btnTypeDataClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
