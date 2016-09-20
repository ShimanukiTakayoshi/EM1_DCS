<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Sheet = New System.Windows.Forms.DataGridView()
        Me.btnSheetSetting = New System.Windows.Forms.Button()
        Me.dgvYield = New System.Windows.Forms.DataGridView()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        CType(Me.Sheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvYield, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(49, 58)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(132, 39)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.Location = New System.Drawing.Point(52, 17)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(38, 12)
        Me.lblTest.TabIndex = 1
        Me.lblTest.Text = "Label1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(48, 134)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(123, 19)
        Me.TextBox1.TabIndex = 2
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(205, 137)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(41, 19)
        Me.TextBox2.TabIndex = 3
        '
        'Sheet
        '
        Me.Sheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Sheet.Location = New System.Drawing.Point(32, 319)
        Me.Sheet.Name = "Sheet"
        Me.Sheet.RowTemplate.Height = 21
        Me.Sheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Sheet.Size = New System.Drawing.Size(1175, 272)
        Me.Sheet.TabIndex = 4
        '
        'btnSheetSetting
        '
        Me.btnSheetSetting.Location = New System.Drawing.Point(215, 63)
        Me.btnSheetSetting.Name = "btnSheetSetting"
        Me.btnSheetSetting.Size = New System.Drawing.Size(103, 33)
        Me.btnSheetSetting.TabIndex = 5
        Me.btnSheetSetting.Text = "Button1"
        Me.btnSheetSetting.UseVisualStyleBackColor = True
        '
        'dgvYield
        '
        Me.dgvYield.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYield.Location = New System.Drawing.Point(340, 17)
        Me.dgvYield.Name = "dgvYield"
        Me.dgvYield.RowTemplate.Height = 21
        Me.dgvYield.Size = New System.Drawing.Size(262, 105)
        Me.dgvYield.TabIndex = 6
        '
        'dgvData
        '
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(658, 17)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowTemplate.Height = 21
        Me.dgvData.Size = New System.Drawing.Size(565, 232)
        Me.dgvData.TabIndex = 7
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1235, 603)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.dgvYield)
        Me.Controls.Add(Me.btnSheetSetting)
        Me.Controls.Add(Me.Sheet)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "frmMain"
        Me.Text = "Dcas_Prototype"
        CType(Me.Sheet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvYield, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblTest As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Sheet As System.Windows.Forms.DataGridView
    Friend WithEvents btnSheetSetting As System.Windows.Forms.Button
    Friend WithEvents dgvYield As System.Windows.Forms.DataGridView
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView

End Class
