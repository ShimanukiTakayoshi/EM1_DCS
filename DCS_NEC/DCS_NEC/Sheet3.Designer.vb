<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSheet3
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
        Me.Sheet3 = New System.Windows.Forms.DataGridView()
        Me.btnSheet3Close = New System.Windows.Forms.Button()
        CType(Me.Sheet3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Text = "Ch-3"
        '
        'Sheet3
        '
        Me.Sheet3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Sheet3.Location = New System.Drawing.Point(3, 36)
        Me.Sheet3.Name = "Sheet3"
        Me.Sheet3.RowTemplate.Height = 21
        Me.Sheet3.Size = New System.Drawing.Size(631, 342)
        Me.Sheet3.TabIndex = 1
        '
        'btnSheet3Close
        '
        Me.btnSheet3Close.Location = New System.Drawing.Point(507, 9)
        Me.btnSheet3Close.Name = "btnSheet3Close"
        Me.btnSheet3Close.Size = New System.Drawing.Size(88, 21)
        Me.btnSheet3Close.TabIndex = 2
        Me.btnSheet3Close.Text = "Close"
        Me.btnSheet3Close.UseVisualStyleBackColor = True
        '
        'frmSheet3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 381)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSheet3Close)
        Me.Controls.Add(Me.Sheet3)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmSheet3"
        Me.Text = "Data Sheet Ch-3"
        CType(Me.Sheet3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Sheet3 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSheet3Close As System.Windows.Forms.Button
End Class
