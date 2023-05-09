<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAshrae
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents TxtHeatB As System.Windows.Forms.TextBox
	Public WithEvents TxtHeatA As System.Windows.Forms.TextBox
	Public WithEvents TxtLatent As System.Windows.Forms.TextBox
	Public WithEvents TxtRespire As System.Windows.Forms.TextBox
	Public WithEvents TxtHFreeze As System.Windows.Forms.TextBox
	Public WithEvents TxtWater As System.Windows.Forms.TextBox
	Public WithEvents TxtSLife As System.Windows.Forms.TextBox
	Public WithEvents TxtRH As System.Windows.Forms.TextBox
	Public WithEvents TxtSTemp As System.Windows.Forms.TextBox
    Public WithEvents CmdClose As System.Windows.Forms.Button
    Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents LblType As System.Windows.Forms.Label
	Public WithEvents LblCommodity As System.Windows.Forms.Label
	Public WithEvents LblCategory As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtHeatB = New System.Windows.Forms.TextBox
        Me.TxtHeatA = New System.Windows.Forms.TextBox
        Me.TxtLatent = New System.Windows.Forms.TextBox
        Me.TxtRespire = New System.Windows.Forms.TextBox
        Me.TxtHFreeze = New System.Windows.Forms.TextBox
        Me.TxtWater = New System.Windows.Forms.TextBox
        Me.TxtSLife = New System.Windows.Forms.TextBox
        Me.TxtRH = New System.Windows.Forms.TextBox
        Me.TxtSTemp = New System.Windows.Forms.TextBox
        Me.CmdClose = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblType = New System.Windows.Forms.Label
        Me.LblCommodity = New System.Windows.Forms.Label
        Me.LblCategory = New System.Windows.Forms.Label
        Me.cboproduct = New System.Windows.Forms.ComboBox
        Me.Cbotype = New System.Windows.Forms.ComboBox
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.btnEdit = New System.Windows.Forms.Button
        Me.chkFromRep = New System.Windows.Forms.CheckBox
        Me.txtMyCounter = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TxtHeatB
        '
        Me.TxtHeatB.AcceptsReturn = True
        Me.TxtHeatB.BackColor = System.Drawing.SystemColors.Window
        Me.TxtHeatB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtHeatB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeatB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtHeatB.Location = New System.Drawing.Point(344, 184)
        Me.TxtHeatB.MaxLength = 0
        Me.TxtHeatB.Multiline = True
        Me.TxtHeatB.Name = "TxtHeatB"
        Me.TxtHeatB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtHeatB.Size = New System.Drawing.Size(33, 19)
        Me.TxtHeatB.TabIndex = 10
        Me.TxtHeatB.TabStop = False
        Me.TxtHeatB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtHeatA
        '
        Me.TxtHeatA.AcceptsReturn = True
        Me.TxtHeatA.BackColor = System.Drawing.SystemColors.Window
        Me.TxtHeatA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtHeatA.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHeatA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtHeatA.Location = New System.Drawing.Point(144, 184)
        Me.TxtHeatA.MaxLength = 0
        Me.TxtHeatA.Multiline = True
        Me.TxtHeatA.Name = "TxtHeatA"
        Me.TxtHeatA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtHeatA.Size = New System.Drawing.Size(33, 19)
        Me.TxtHeatA.TabIndex = 9
        Me.TxtHeatA.TabStop = False
        Me.TxtHeatA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtLatent
        '
        Me.TxtLatent.AcceptsReturn = True
        Me.TxtLatent.BackColor = System.Drawing.SystemColors.Window
        Me.TxtLatent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtLatent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLatent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtLatent.Location = New System.Drawing.Point(144, 208)
        Me.TxtLatent.MaxLength = 0
        Me.TxtLatent.Multiline = True
        Me.TxtLatent.Name = "TxtLatent"
        Me.TxtLatent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtLatent.Size = New System.Drawing.Size(33, 19)
        Me.TxtLatent.TabIndex = 11
        Me.TxtLatent.TabStop = False
        Me.TxtLatent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtRespire
        '
        Me.TxtRespire.AcceptsReturn = True
        Me.TxtRespire.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRespire.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtRespire.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRespire.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtRespire.Location = New System.Drawing.Point(344, 208)
        Me.TxtRespire.MaxLength = 0
        Me.TxtRespire.Multiline = True
        Me.TxtRespire.Name = "TxtRespire"
        Me.TxtRespire.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtRespire.Size = New System.Drawing.Size(33, 19)
        Me.TxtRespire.TabIndex = 12
        Me.TxtRespire.TabStop = False
        Me.TxtRespire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtHFreeze
        '
        Me.TxtHFreeze.AcceptsReturn = True
        Me.TxtHFreeze.BackColor = System.Drawing.SystemColors.Window
        Me.TxtHFreeze.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtHFreeze.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHFreeze.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtHFreeze.Location = New System.Drawing.Point(144, 160)
        Me.TxtHFreeze.MaxLength = 0
        Me.TxtHFreeze.Multiline = True
        Me.TxtHFreeze.Name = "TxtHFreeze"
        Me.TxtHFreeze.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtHFreeze.Size = New System.Drawing.Size(33, 19)
        Me.TxtHFreeze.TabIndex = 8
        Me.TxtHFreeze.TabStop = False
        Me.TxtHFreeze.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtWater
        '
        Me.TxtWater.AcceptsReturn = True
        Me.TxtWater.BackColor = System.Drawing.SystemColors.Window
        Me.TxtWater.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtWater.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWater.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtWater.Location = New System.Drawing.Point(416, 136)
        Me.TxtWater.MaxLength = 0
        Me.TxtWater.Multiline = True
        Me.TxtWater.Name = "TxtWater"
        Me.TxtWater.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtWater.Size = New System.Drawing.Size(33, 19)
        Me.TxtWater.TabIndex = 7
        Me.TxtWater.TabStop = False
        Me.TxtWater.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSLife
        '
        Me.TxtSLife.AcceptsReturn = True
        Me.TxtSLife.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSLife.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSLife.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSLife.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtSLife.Location = New System.Drawing.Point(144, 136)
        Me.TxtSLife.MaxLength = 0
        Me.TxtSLife.Multiline = True
        Me.TxtSLife.Name = "TxtSLife"
        Me.TxtSLife.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtSLife.Size = New System.Drawing.Size(121, 19)
        Me.TxtSLife.TabIndex = 6
        Me.TxtSLife.TabStop = False
        Me.TxtSLife.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtRH
        '
        Me.TxtRH.AcceptsReturn = True
        Me.TxtRH.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtRH.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtRH.Location = New System.Drawing.Point(344, 112)
        Me.TxtRH.MaxLength = 0
        Me.TxtRH.Multiline = True
        Me.TxtRH.Name = "TxtRH"
        Me.TxtRH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtRH.Size = New System.Drawing.Size(105, 19)
        Me.TxtRH.TabIndex = 5
        Me.TxtRH.TabStop = False
        Me.TxtRH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSTemp
        '
        Me.TxtSTemp.AcceptsReturn = True
        Me.TxtSTemp.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSTemp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSTemp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSTemp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtSTemp.Location = New System.Drawing.Point(144, 112)
        Me.TxtSTemp.MaxLength = 0
        Me.TxtSTemp.Multiline = True
        Me.TxtSTemp.Name = "TxtSTemp"
        Me.TxtSTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtSTemp.Size = New System.Drawing.Size(121, 19)
        Me.TxtSTemp.TabIndex = 3
        Me.TxtSTemp.TabStop = False
        Me.TxtSTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.CmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdClose.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClose.Location = New System.Drawing.Point(392, 248)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdClose.Size = New System.Drawing.Size(57, 33)
        Me.CmdClose.TabIndex = 4
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(200, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(137, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Specific Heat Below:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(129, 17)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Specific Heat Above:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(64, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(73, 17)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Latent Heat:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(192, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(145, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Heat Of Respiration:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(113, 17)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "High Freeze (°F):"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(296, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(113, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Water Content (%):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(64, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Store Life:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(280, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "RH (%):"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(0, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(137, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Store Temperature (°F):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblType
        '
        Me.LblType.BackColor = System.Drawing.Color.Transparent
        Me.LblType.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblType.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblType.Location = New System.Drawing.Point(24, 68)
        Me.LblType.Name = "LblType"
        Me.LblType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblType.Size = New System.Drawing.Size(65, 17)
        Me.LblType.TabIndex = 15
        Me.LblType.Text = "Type:"
        Me.LblType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCommodity
        '
        Me.LblCommodity.BackColor = System.Drawing.Color.Transparent
        Me.LblCommodity.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblCommodity.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCommodity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCommodity.Location = New System.Drawing.Point(16, 40)
        Me.LblCommodity.Name = "LblCommodity"
        Me.LblCommodity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCommodity.Size = New System.Drawing.Size(75, 17)
        Me.LblCommodity.TabIndex = 14
        Me.LblCommodity.Text = "Commodity:"
        Me.LblCommodity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCategory
        '
        Me.LblCategory.BackColor = System.Drawing.Color.Transparent
        Me.LblCategory.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblCategory.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCategory.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCategory.Location = New System.Drawing.Point(26, 13)
        Me.LblCategory.Name = "LblCategory"
        Me.LblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCategory.Size = New System.Drawing.Size(65, 17)
        Me.LblCategory.TabIndex = 13
        Me.LblCategory.Text = "Category:"
        Me.LblCategory.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboproduct
        '
        Me.cboproduct.FormattingEnabled = True
        Me.cboproduct.Location = New System.Drawing.Point(99, 36)
        Me.cboproduct.Name = "cboproduct"
        Me.cboproduct.Size = New System.Drawing.Size(350, 22)
        Me.cboproduct.TabIndex = 25
        '
        'Cbotype
        '
        Me.Cbotype.FormattingEnabled = True
        Me.Cbotype.Location = New System.Drawing.Point(99, 64)
        Me.Cbotype.Name = "Cbotype"
        Me.Cbotype.Size = New System.Drawing.Size(350, 22)
        Me.Cbotype.TabIndex = 26
        '
        'cboCategory
        '
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(99, 8)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(350, 22)
        Me.cboCategory.TabIndex = 27
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(214, 273)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 28
        Me.btnEdit.Text = "Clone"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'chkFromRep
        '
        Me.chkFromRep.AutoSize = True
        Me.chkFromRep.Enabled = False
        Me.chkFromRep.Location = New System.Drawing.Point(56, 248)
        Me.chkFromRep.Name = "chkFromRep"
        Me.chkFromRep.Size = New System.Drawing.Size(72, 18)
        Me.chkFromRep.TabIndex = 29
        Me.chkFromRep.Text = "From Rep"
        Me.chkFromRep.UseVisualStyleBackColor = True
        '
        'txtMyCounter
        '
        Me.txtMyCounter.Location = New System.Drawing.Point(214, 229)
        Me.txtMyCounter.Name = "txtMyCounter"
        Me.txtMyCounter.Size = New System.Drawing.Size(83, 20)
        Me.txtMyCounter.TabIndex = 30
        Me.txtMyCounter.Visible = False
        '
        'frmAshrae
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(463, 308)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtMyCounter)
        Me.Controls.Add(Me.chkFromRep)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Cbotype)
        Me.Controls.Add(Me.cboproduct)
        Me.Controls.Add(Me.TxtHeatB)
        Me.Controls.Add(Me.TxtHeatA)
        Me.Controls.Add(Me.TxtLatent)
        Me.Controls.Add(Me.TxtRespire)
        Me.Controls.Add(Me.TxtHFreeze)
        Me.Controls.Add(Me.TxtWater)
        Me.Controls.Add(Me.TxtSLife)
        Me.Controls.Add(Me.TxtRH)
        Me.Controls.Add(Me.TxtSTemp)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.LblCommodity)
        Me.Controls.Add(Me.LblCategory)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(454, 668)
        Me.Name = "frmAshrae"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASHRAE Product Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboproduct As System.Windows.Forms.ComboBox
    Friend WithEvents Cbotype As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents chkFromRep As System.Windows.Forms.CheckBox
    Friend WithEvents txtMyCounter As System.Windows.Forms.TextBox
#End Region 
End Class