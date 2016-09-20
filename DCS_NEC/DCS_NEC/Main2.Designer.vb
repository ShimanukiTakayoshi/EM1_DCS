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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Sheet = New System.Windows.Forms.DataGridView()
        Me.dgvYield = New System.Windows.Forms.DataGridView()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.picHist0 = New System.Windows.Forms.PictureBox()
        Me.cbxCh0 = New System.Windows.Forms.ComboBox()
        Me.cbxItem0 = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuS = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSF = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSP = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuST = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSI = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSJ = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAlarmLevelSet = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGouki = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVD = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuV1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuV2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuV3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuVC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTotalDataSheetOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTotalDataSheetClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlcMonitorOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlcMonitorClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.PLCPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuBufferClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtYield = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.timMain = New System.Windows.Forms.Timer(Me.components)
        Me.SysmacCJ1 = New OMRON.Compolet.SYSMAC.SysmacCJ(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.timPlcScan = New System.Windows.Forms.Timer(Me.components)
        Me.timHeartPulse = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbxAve = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.Sheet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvYield, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHist0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(216, 116)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(176, 47)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Sheet
        '
        Me.Sheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Sheet.Location = New System.Drawing.Point(8, 367)
        Me.Sheet.Name = "Sheet"
        Me.Sheet.RowTemplate.Height = 21
        Me.Sheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Sheet.Size = New System.Drawing.Size(801, 283)
        Me.Sheet.TabIndex = 4
        '
        'dgvYield
        '
        Me.dgvYield.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYield.Location = New System.Drawing.Point(8, 77)
        Me.dgvYield.Name = "dgvYield"
        Me.dgvYield.RowTemplate.Height = 21
        Me.dgvYield.Size = New System.Drawing.Size(202, 86)
        Me.dgvYield.TabIndex = 6
        '
        'dgvData
        '
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(8, 165)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowTemplate.Height = 21
        Me.dgvData.Size = New System.Drawing.Size(384, 180)
        Me.dgvData.TabIndex = 7
        '
        'picHist0
        '
        Me.picHist0.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.picHist0.Location = New System.Drawing.Point(398, 67)
        Me.picHist0.Name = "picHist0"
        Me.picHist0.Size = New System.Drawing.Size(411, 282)
        Me.picHist0.TabIndex = 9
        Me.picHist0.TabStop = False
        '
        'cbxCh0
        '
        Me.cbxCh0.FormattingEnabled = True
        Me.cbxCh0.Location = New System.Drawing.Point(395, 41)
        Me.cbxCh0.Name = "cbxCh0"
        Me.cbxCh0.Size = New System.Drawing.Size(52, 20)
        Me.cbxCh0.TabIndex = 10
        '
        'cbxItem0
        '
        Me.cbxItem0.FormattingEnabled = True
        Me.cbxItem0.Location = New System.Drawing.Point(453, 41)
        Me.cbxItem0.Name = "cbxItem0"
        Me.cbxItem0.Size = New System.Drawing.Size(54, 20)
        Me.cbxItem0.TabIndex = 11
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuS, Me.mnuV, Me.PLCPToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuS
        '
        Me.mnuS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSF, Me.mnuSP, Me.mnuST, Me.mnuSI, Me.mnuSJ, Me.mnuAlarmLevelSet, Me.mnuGouki, Me.mnuSE})
        Me.mnuS.Name = "mnuS"
        Me.mnuS.Size = New System.Drawing.Size(61, 20)
        Me.mnuS.Text = "設定(&S)"
        '
        'mnuSF
        '
        Me.mnuSF.Name = "mnuSF"
        Me.mnuSF.Size = New System.Drawing.Size(200, 22)
        Me.mnuSF.Text = "保存先フォルダ(&F)"
        '
        'mnuSP
        '
        Me.mnuSP.Name = "mnuSP"
        Me.mnuSP.Size = New System.Drawing.Size(200, 22)
        Me.mnuSP.Text = "パスワード(&P)"
        '
        'mnuST
        '
        Me.mnuST.Name = "mnuST"
        Me.mnuST.Size = New System.Drawing.Size(200, 22)
        Me.mnuST.Text = "機種(&T)"
        '
        'mnuSI
        '
        Me.mnuSI.Name = "mnuSI"
        Me.mnuSI.Size = New System.Drawing.Size(200, 22)
        Me.mnuSI.Text = "機種情報(&I)"
        '
        'mnuSJ
        '
        Me.mnuSJ.Name = "mnuSJ"
        Me.mnuSJ.Size = New System.Drawing.Size(200, 22)
        Me.mnuSJ.Text = "データシート表示項目(&J)"
        '
        'mnuAlarmLevelSet
        '
        Me.mnuAlarmLevelSet.Name = "mnuAlarmLevelSet"
        Me.mnuAlarmLevelSet.Size = New System.Drawing.Size(200, 22)
        Me.mnuAlarmLevelSet.Text = "良品率異常ﾚﾍﾞﾙ設定(&Y)"
        '
        'mnuGouki
        '
        Me.mnuGouki.Name = "mnuGouki"
        Me.mnuGouki.Size = New System.Drawing.Size(200, 22)
        Me.mnuGouki.Text = "生産ライン番号設定(&G)"
        '
        'mnuSE
        '
        Me.mnuSE.Name = "mnuSE"
        Me.mnuSE.Size = New System.Drawing.Size(200, 22)
        Me.mnuSE.Text = "終了(&E)"
        '
        'mnuV
        '
        Me.mnuV.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVD, Me.mnuV1, Me.mnuV2, Me.mnuV3, Me.ToolStripMenuItem1, Me.mnuVC, Me.ToolStripMenuItem2, Me.mnuTotalDataSheetOpen, Me.mnuTotalDataSheetClose, Me.ToolStripMenuItem3, Me.mnuPlcMonitorOpen, Me.mnuPlcMonitorClose})
        Me.mnuV.Name = "mnuV"
        Me.mnuV.Size = New System.Drawing.Size(61, 20)
        Me.mnuV.Text = "表示(&V)"
        '
        'mnuVD
        '
        Me.mnuVD.Name = "mnuVD"
        Me.mnuVD.Size = New System.Drawing.Size(194, 22)
        Me.mnuVD.Text = "データシート(&D)"
        '
        'mnuV1
        '
        Me.mnuV1.Name = "mnuV1"
        Me.mnuV1.Size = New System.Drawing.Size(194, 22)
        Me.mnuV1.Text = "ヒストグラム1(&1)"
        '
        'mnuV2
        '
        Me.mnuV2.Name = "mnuV2"
        Me.mnuV2.Size = New System.Drawing.Size(194, 22)
        Me.mnuV2.Text = "ヒストグラム2(&2)"
        '
        'mnuV3
        '
        Me.mnuV3.Name = "mnuV3"
        Me.mnuV3.Size = New System.Drawing.Size(194, 22)
        Me.mnuV3.Text = "ヒストグラム3(&3)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(191, 6)
        '
        'mnuVC
        '
        Me.mnuVC.Name = "mnuVC"
        Me.mnuVC.Size = New System.Drawing.Size(194, 22)
        Me.mnuVC.Text = "データークリア(&C)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(191, 6)
        '
        'mnuTotalDataSheetOpen
        '
        Me.mnuTotalDataSheetOpen.Name = "mnuTotalDataSheetOpen"
        Me.mnuTotalDataSheetOpen.Size = New System.Drawing.Size(194, 22)
        Me.mnuTotalDataSheetOpen.Text = "ﾄｰﾀﾙﾃﾞｰﾀｼｰﾄ表示(&T)"
        '
        'mnuTotalDataSheetClose
        '
        Me.mnuTotalDataSheetClose.Name = "mnuTotalDataSheetClose"
        Me.mnuTotalDataSheetClose.Size = New System.Drawing.Size(194, 22)
        Me.mnuTotalDataSheetClose.Text = "ﾄｰﾀﾙﾃﾞｰﾀｼｰﾄ非表示(&X)"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(191, 6)
        '
        'mnuPlcMonitorOpen
        '
        Me.mnuPlcMonitorOpen.Name = "mnuPlcMonitorOpen"
        Me.mnuPlcMonitorOpen.Size = New System.Drawing.Size(194, 22)
        Me.mnuPlcMonitorOpen.Text = "PLCﾓﾆﾀｰ表示(&P)"
        '
        'mnuPlcMonitorClose
        '
        Me.mnuPlcMonitorClose.Name = "mnuPlcMonitorClose"
        Me.mnuPlcMonitorClose.Size = New System.Drawing.Size(194, 22)
        Me.mnuPlcMonitorClose.Text = "PLCﾓﾆﾀｰ非表示(&Z)"
        '
        'PLCPToolStripMenuItem
        '
        Me.PLCPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBufferClear})
        Me.PLCPToolStripMenuItem.Name = "PLCPToolStripMenuItem"
        Me.PLCPToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.PLCPToolStripMenuItem.Text = "PLC(&P)"
        '
        'mnuBufferClear
        '
        Me.mnuBufferClear.Name = "mnuBufferClear"
        Me.mnuBufferClear.Size = New System.Drawing.Size(186, 22)
        Me.mnuBufferClear.Text = "バッファーデータクリア(&C)"
        '
        'txtType
        '
        Me.txtType.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtType.Location = New System.Drawing.Point(8, 41)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(34, 31)
        Me.txtType.TabIndex = 13
        Me.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("ＭＳ ゴシック", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtName.Location = New System.Drawing.Point(46, 41)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(164, 31)
        Me.txtName.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 12)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 12)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Name"
        '
        'txtYield
        '
        Me.txtYield.Font = New System.Drawing.Font("ＭＳ ゴシック", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtYield.Location = New System.Drawing.Point(216, 39)
        Me.txtYield.Name = "txtYield"
        Me.txtYield.Size = New System.Drawing.Size(173, 71)
        Me.txtYield.TabIndex = 17
        '
        'timMain
        '
        Me.timMain.Enabled = True
        Me.timMain.Interval = 500
        '
        'SysmacCJ1
        '
        Me.SysmacCJ1.Active = True
        Me.SysmacCJ1.DeviceName = ""
        Me.SysmacCJ1.HeartBeatTimer = CType(0, Long)
        Me.SysmacCJ1.NetworkAddress = CType(0, Short)
        Me.SysmacCJ1.NodeAddress = CType(1, Short)
        Me.SysmacCJ1.ReceiveTimeLimit = CType(750, Long)
        Me.SysmacCJ1.RetryCount = 0
        Me.SysmacCJ1.UnitAddress = CType(0, Short)
        Me.SysmacCJ1.UseNameServer = False
        Me.SysmacCJ1.UseSpecificPort = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(402, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Ch"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(451, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Item"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DarkOrange
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(631, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 12)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "--R--"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.OliveDrab
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(590, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "--L--"
        '
        'timPlcScan
        '
        Me.timPlcScan.Enabled = True
        Me.timPlcScan.Interval = 10
        '
        'timHeartPulse
        '
        Me.timHeartPulse.Interval = 2000
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label7.Location = New System.Drawing.Point(393, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 12)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "----/DDDD：未検査"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label8.Location = New System.Drawing.Point(516, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 12)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "EEEE：空振り"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label9.Location = New System.Drawing.Point(602, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 12)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "FFFF：ﾌﾟﾛｰﾌﾞｴﾗｰ"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(696, 27)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton1.TabIndex = 25
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "分布図"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(696, 45)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(70, 16)
        Me.RadioButton2.TabIndex = 26
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "推移ｸﾞﾗﾌ"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1170, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 12)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Label11"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(1173, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "aaaaaa"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1152, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbxAve
        '
        Me.cbxAve.FormattingEnabled = True
        Me.cbxAve.Location = New System.Drawing.Point(513, 41)
        Me.cbxAve.Name = "cbxAve"
        Me.cbxAve.Size = New System.Drawing.Size(54, 20)
        Me.cbxAve.TabIndex = 31
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(516, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 12)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Ave"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbxAve)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtYield)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.cbxItem0)
        Me.Controls.Add(Me.cbxCh0)
        Me.Controls.Add(Me.picHist0)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.dgvYield)
        Me.Controls.Add(Me.Sheet)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Kyoei Data Collecting System"
        CType(Me.Sheet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvYield, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHist0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Sheet As System.Windows.Forms.DataGridView
    Friend WithEvents dgvYield As System.Windows.Forms.DataGridView
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents picHist0 As System.Windows.Forms.PictureBox
    Friend WithEvents cbxCh0 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxItem0 As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuST As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuVD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuV1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuV2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuV3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuVC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSJ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtYield As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents timMain As System.Windows.Forms.Timer
    Friend WithEvents SysmacCJ1 As OMRON.Compolet.SYSMAC.SysmacCJ
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTotalDataSheetOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTotalDataSheetClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents timPlcScan As System.Windows.Forms.Timer
    Friend WithEvents timHeartPulse As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPlcMonitorOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlcMonitorClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PLCPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBufferClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAlarmLevelSet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents mnuGouki As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbxAve As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
