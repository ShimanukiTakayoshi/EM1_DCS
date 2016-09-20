<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSheet2
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
        Me.Sheet2 = New System.Windows.Forms.DataGridView()
        Me.btnSheet2Close = New System.Windows.Forms.Button()
        CType(Me.Sheet2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Text = "Ch-2"
        '
        'Sheet2
        '
        Me.Sheet2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Sheet2.Location = New System.Drawing.Point(5, 36)
        Me.Sheet2.Name = "Sheet2"
        Me.Sheet2.RowTemplate.Height = 21
        Me.Sheet2.Size = New System.Drawing.Size(632, 342)
        Me.Sheet2.TabIndex = 1
        '
        'btnSheet2Close
        '
        Me.btnSheet2Close.Location = New System.Drawing.Point(502, 10)
        Me.btnSheet2Close.Name = "btnSheet2Close"
        Me.btnSheet2Close.Size = New System.Drawing.Size(95, 20)
        Me.btnSheet2Close.TabIndex = 2
        Me.btnSheet2Close.Text = "Close"
        Me.btnSheet2Close.UseVisualStyleBackColor = True
        '
        'frmSheet2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 381)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSheet2Close)
        Me.Controls.Add(Me.Sheet2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmSheet2"
        Me.Text = "Data Sheet Ch-2"
        CType(Me.Sheet2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Sheet2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSheet2Close As System.Windows.Forms.Button
End Class
