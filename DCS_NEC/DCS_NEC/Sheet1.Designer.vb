<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSheet1
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
        Me.Sheet1 = New System.Windows.Forms.DataGridView()
        Me.btnSheet1Close = New System.Windows.Forms.Button()
        CType(Me.Sheet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ch-1"
        '
        'Sheet1
        '
        Me.Sheet1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Sheet1.Location = New System.Drawing.Point(4, 36)
        Me.Sheet1.Name = "Sheet1"
        Me.Sheet1.RowTemplate.Height = 21
        Me.Sheet1.Size = New System.Drawing.Size(631, 340)
        Me.Sheet1.TabIndex = 1
        '
        'btnSheet1Close
        '
        Me.btnSheet1Close.Location = New System.Drawing.Point(506, 9)
        Me.btnSheet1Close.Name = "btnSheet1Close"
        Me.btnSheet1Close.Size = New System.Drawing.Size(99, 22)
        Me.btnSheet1Close.TabIndex = 2
        Me.btnSheet1Close.Text = "Close"
        Me.btnSheet1Close.UseVisualStyleBackColor = True
        '
        'frmSheet1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 377)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSheet1Close)
        Me.Controls.Add(Me.Sheet1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmSheet1"
        Me.Text = "Data Sheet Ch-1"
        CType(Me.Sheet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Sheet1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSheet1Close As System.Windows.Forms.Button
End Class
