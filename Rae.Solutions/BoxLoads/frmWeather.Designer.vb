<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmWeather
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
    Public WithEvents CmdClose As System.Windows.Forms.Button
	Public WithEvents TxtSDB As System.Windows.Forms.TextBox
	Public WithEvents TxtWWB As System.Windows.Forms.TextBox
	Public WithEvents TxtRH As System.Windows.Forms.TextBox
	Public WithEvents TxtSWB As System.Windows.Forms.TextBox
	Public WithEvents TxtWDB As System.Windows.Forms.TextBox
    Public WithEvents LblWWB As System.Windows.Forms.Label
	Public WithEvents LblRH As System.Windows.Forms.Label
	Public WithEvents LblSummer As System.Windows.Forms.Label
	Public WithEvents LblSDB As System.Windows.Forms.Label
	Public WithEvents LblSWB As System.Windows.Forms.Label
	Public WithEvents LblWinter As System.Windows.Forms.Label
	Public WithEvents LblWDB As System.Windows.Forms.Label
	Public WithEvents LblCity As System.Windows.Forms.Label
	Public WithEvents LblState As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.TxtSDB = New System.Windows.Forms.TextBox()
        Me.TxtWWB = New System.Windows.Forms.TextBox()
        Me.TxtRH = New System.Windows.Forms.TextBox()
        Me.TxtSWB = New System.Windows.Forms.TextBox()
        Me.TxtWDB = New System.Windows.Forms.TextBox()
        Me.LblWWB = New System.Windows.Forms.Label()
        Me.LblRH = New System.Windows.Forms.Label()
        Me.LblSummer = New System.Windows.Forms.Label()
        Me.LblSDB = New System.Windows.Forms.Label()
        Me.LblSWB = New System.Windows.Forms.Label()
        Me.LblWinter = New System.Windows.Forms.Label()
        Me.LblWDB = New System.Windows.Forms.Label()
        Me.LblCity = New System.Windows.Forms.Label()
        Me.LblState = New System.Windows.Forms.Label()
        Me.CBOState = New System.Windows.Forms.ComboBox()
        Me.cboCity = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.CmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdClose.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClose.Location = New System.Drawing.Point(384, 248)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdClose.Size = New System.Drawing.Size(57, 33)
        Me.CmdClose.TabIndex = 8
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'TxtSDB
        '
        Me.TxtSDB.AcceptsReturn = True
        Me.TxtSDB.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSDB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSDB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSDB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtSDB.Location = New System.Drawing.Point(264, 120)
        Me.TxtSDB.MaxLength = 0
        Me.TxtSDB.Multiline = True
        Me.TxtSDB.Name = "TxtSDB"
        Me.TxtSDB.ReadOnly = True
        Me.TxtSDB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtSDB.Size = New System.Drawing.Size(41, 19)
        Me.TxtSDB.TabIndex = 5
        Me.TxtSDB.TabStop = False
        Me.TxtSDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtWWB
        '
        Me.TxtWWB.AcceptsReturn = True
        Me.TxtWWB.BackColor = System.Drawing.SystemColors.Window
        Me.TxtWWB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtWWB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWWB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtWWB.Location = New System.Drawing.Point(112, 144)
        Me.TxtWWB.MaxLength = 0
        Me.TxtWWB.Multiline = True
        Me.TxtWWB.Name = "TxtWWB"
        Me.TxtWWB.ReadOnly = True
        Me.TxtWWB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtWWB.Size = New System.Drawing.Size(41, 19)
        Me.TxtWWB.TabIndex = 4
        Me.TxtWWB.TabStop = False
        Me.TxtWWB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtWWB.Visible = False
        '
        'TxtRH
        '
        Me.TxtRH.AcceptsReturn = True
        Me.TxtRH.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtRH.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtRH.Location = New System.Drawing.Point(384, 120)
        Me.TxtRH.MaxLength = 0
        Me.TxtRH.Multiline = True
        Me.TxtRH.Name = "TxtRH"
        Me.TxtRH.ReadOnly = True
        Me.TxtRH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtRH.Size = New System.Drawing.Size(41, 19)
        Me.TxtRH.TabIndex = 7
        Me.TxtRH.TabStop = False
        Me.TxtRH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSWB
        '
        Me.TxtSWB.AcceptsReturn = True
        Me.TxtSWB.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSWB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSWB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSWB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtSWB.Location = New System.Drawing.Point(264, 144)
        Me.TxtSWB.MaxLength = 0
        Me.TxtSWB.Multiline = True
        Me.TxtSWB.Name = "TxtSWB"
        Me.TxtSWB.ReadOnly = True
        Me.TxtSWB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtSWB.Size = New System.Drawing.Size(41, 19)
        Me.TxtSWB.TabIndex = 6
        Me.TxtSWB.TabStop = False
        Me.TxtSWB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtWDB
        '
        Me.TxtWDB.AcceptsReturn = True
        Me.TxtWDB.BackColor = System.Drawing.SystemColors.Window
        Me.TxtWDB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtWDB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWDB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtWDB.Location = New System.Drawing.Point(112, 120)
        Me.TxtWDB.MaxLength = 0
        Me.TxtWDB.Multiline = True
        Me.TxtWDB.Name = "TxtWDB"
        Me.TxtWDB.ReadOnly = True
        Me.TxtWDB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtWDB.Size = New System.Drawing.Size(41, 19)
        Me.TxtWDB.TabIndex = 3
        Me.TxtWDB.TabStop = False
        Me.TxtWDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblWWB
        '
        Me.LblWWB.BackColor = System.Drawing.Color.Transparent
        Me.LblWWB.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblWWB.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWWB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblWWB.Location = New System.Drawing.Point(8, 144)
        Me.LblWWB.Name = "LblWWB"
        Me.LblWWB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblWWB.Size = New System.Drawing.Size(97, 17)
        Me.LblWWB.TabIndex = 16
        Me.LblWWB.Text = "Wet Bulb (°F):"
        Me.LblWWB.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LblWWB.Visible = False
        '
        'LblRH
        '
        Me.LblRH.BackColor = System.Drawing.Color.Transparent
        Me.LblRH.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblRH.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblRH.Location = New System.Drawing.Point(328, 120)
        Me.LblRH.Name = "LblRH"
        Me.LblRH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblRH.Size = New System.Drawing.Size(49, 17)
        Me.LblRH.TabIndex = 15
        Me.LblRH.Text = "RH (%):"
        Me.LblRH.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblSummer
        '
        Me.LblSummer.BackColor = System.Drawing.Color.Transparent
        Me.LblSummer.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblSummer.Font = New System.Drawing.Font("Arial", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSummer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblSummer.Location = New System.Drawing.Point(254, 96)
        Me.LblSummer.Name = "LblSummer"
        Me.LblSummer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblSummer.Size = New System.Drawing.Size(65, 17)
        Me.LblSummer.TabIndex = 14
        Me.LblSummer.Text = "Summer"
        Me.LblSummer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblSDB
        '
        Me.LblSDB.BackColor = System.Drawing.Color.Transparent
        Me.LblSDB.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblSDB.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSDB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSDB.Location = New System.Drawing.Point(176, 120)
        Me.LblSDB.Name = "LblSDB"
        Me.LblSDB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblSDB.Size = New System.Drawing.Size(81, 17)
        Me.LblSDB.TabIndex = 13
        Me.LblSDB.Text = "Dry Bulb (°F):"
        Me.LblSDB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblSWB
        '
        Me.LblSWB.BackColor = System.Drawing.Color.Transparent
        Me.LblSWB.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblSWB.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSWB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSWB.Location = New System.Drawing.Point(136, 144)
        Me.LblSWB.Name = "LblSWB"
        Me.LblSWB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblSWB.Size = New System.Drawing.Size(121, 17)
        Me.LblSWB.TabIndex = 12
        Me.LblSWB.Text = "Wet Bulb (°F):"
        Me.LblSWB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblWinter
        '
        Me.LblWinter.BackColor = System.Drawing.Color.Transparent
        Me.LblWinter.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblWinter.Font = New System.Drawing.Font("Arial", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblWinter.Location = New System.Drawing.Point(100, 96)
        Me.LblWinter.Name = "LblWinter"
        Me.LblWinter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblWinter.Size = New System.Drawing.Size(65, 17)
        Me.LblWinter.TabIndex = 11
        Me.LblWinter.Text = "Winter"
        Me.LblWinter.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblWDB
        '
        Me.LblWDB.BackColor = System.Drawing.Color.Transparent
        Me.LblWDB.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblWDB.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWDB.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblWDB.Location = New System.Drawing.Point(8, 120)
        Me.LblWDB.Name = "LblWDB"
        Me.LblWDB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblWDB.Size = New System.Drawing.Size(97, 17)
        Me.LblWDB.TabIndex = 10
        Me.LblWDB.Text = "Dry Bulb (°F):"
        Me.LblWDB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblCity
        '
        Me.LblCity.BackColor = System.Drawing.Color.Transparent
        Me.LblCity.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblCity.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCity.Location = New System.Drawing.Point(233, 32)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblCity.Size = New System.Drawing.Size(33, 17)
        Me.LblCity.TabIndex = 9
        Me.LblCity.Text = "City:"
        Me.LblCity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblState
        '
        Me.LblState.BackColor = System.Drawing.Color.Transparent
        Me.LblState.Cursor = System.Windows.Forms.Cursors.Default
        Me.LblState.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblState.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblState.Location = New System.Drawing.Point(0, 32)
        Me.LblState.Name = "LblState"
        Me.LblState.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LblState.Size = New System.Drawing.Size(76, 17)
        Me.LblState.TabIndex = 0
        Me.LblState.Text = "State / Prov:"
        Me.LblState.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CBOState
        '
        Me.CBOState.FormattingEnabled = True
        Me.CBOState.Location = New System.Drawing.Point(82, 32)
        Me.CBOState.Name = "CBOState"
        Me.CBOState.Size = New System.Drawing.Size(145, 22)
        Me.CBOState.TabIndex = 17
        '
        'cboCity
        '
        Me.cboCity.FormattingEnabled = True
        Me.cboCity.Location = New System.Drawing.Point(272, 32)
        Me.cboCity.Name = "cboCity"
        Me.cboCity.Size = New System.Drawing.Size(169, 22)
        Me.cboCity.TabIndex = 18
        '
        'frmWeather
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(463, 308)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboCity)
        Me.Controls.Add(Me.CBOState)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.TxtSDB)
        Me.Controls.Add(Me.TxtWWB)
        Me.Controls.Add(Me.TxtRH)
        Me.Controls.Add(Me.TxtSWB)
        Me.Controls.Add(Me.TxtWDB)
        Me.Controls.Add(Me.LblWWB)
        Me.Controls.Add(Me.LblRH)
        Me.Controls.Add(Me.LblSummer)
        Me.Controls.Add(Me.LblSDB)
        Me.Controls.Add(Me.LblSWB)
        Me.Controls.Add(Me.LblWinter)
        Me.Controls.Add(Me.LblWDB)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.LblState)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(276, 731)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWeather"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Weather Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBOState As System.Windows.Forms.ComboBox
    Friend WithEvents cboCity As System.Windows.Forms.ComboBox
#End Region 
End Class