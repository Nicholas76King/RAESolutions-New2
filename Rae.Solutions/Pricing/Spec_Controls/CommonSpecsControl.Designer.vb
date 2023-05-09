<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommonSpecsControl
   Inherits System.Windows.Forms.UserControl

   'UserControl overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblRlaUnits = New System.Windows.Forms.Label()
        Me.lblMcaUnits = New System.Windows.Forms.Label()
        Me.lblRla = New System.Windows.Forms.Label()
        Me.txtRla = New System.Windows.Forms.TextBox()
        Me.txtMca = New System.Windows.Forms.TextBox()
        Me.lblMca = New System.Windows.Forms.Label()
        Me.cboControlVoltage = New System.Windows.Forms.ComboBox()
        Me.lblControlVoltage = New System.Windows.Forms.Label()
        Me.txtEstShippingWeight = New System.Windows.Forms.TextBox()
        Me.lblEstShippingWeight = New System.Windows.Forms.Label()
        Me.lblHeightUnits = New System.Windows.Forms.Label()
        Me.lblEstOperatingWeightUnits = New System.Windows.Forms.Label()
        Me.lblEstShippingWeightUnits = New System.Windows.Forms.Label()
        Me.lblEstOperatingWeight = New System.Windows.Forms.Label()
        Me.txtEstOperatingWeight = New System.Windows.Forms.TextBox()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.lblUnitVoltage = New System.Windows.Forms.Label()
        Me.cboUnitVoltage = New System.Windows.Forms.ComboBox()
        Me.txtTag = New System.Windows.Forms.TextBox()
        Me.lblTag = New System.Windows.Forms.Label()
        Me.txtSpecialInstructions = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.panCommonSpecs = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.commonTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.panCommonSpecs.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWidth
        '
        Me.lblWidth.BackColor = System.Drawing.Color.Transparent
        Me.lblWidth.Location = New System.Drawing.Point(207, 84)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(44, 22)
        Me.lblWidth.TabIndex = 135
        Me.lblWidth.Text = "Width"
        Me.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRlaUnits
        '
        Me.lblRlaUnits.AutoSize = True
        Me.lblRlaUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRlaUnits.Location = New System.Drawing.Point(473, 38)
        Me.lblRlaUnits.Name = "lblRlaUnits"
        Me.lblRlaUnits.Size = New System.Drawing.Size(29, 11)
        Me.lblRlaUnits.TabIndex = 155
        Me.lblRlaUnits.Text = "Amps"
        Me.lblRlaUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMcaUnits
        '
        Me.lblMcaUnits.AutoSize = True
        Me.lblMcaUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMcaUnits.Location = New System.Drawing.Point(193, 38)
        Me.lblMcaUnits.Name = "lblMcaUnits"
        Me.lblMcaUnits.Size = New System.Drawing.Size(29, 11)
        Me.lblMcaUnits.TabIndex = 154
        Me.lblMcaUnits.Text = "Amps"
        Me.lblMcaUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRla
        '
        Me.lblRla.Location = New System.Drawing.Point(283, 30)
        Me.lblRla.Name = "lblRla"
        Me.lblRla.Size = New System.Drawing.Size(110, 22)
        Me.lblRla.TabIndex = 153
        Me.lblRla.Text = "RLA"
        Me.lblRla.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.commonTips.SetToolTip(Me.lblRla, "Run load amperes")
        '
        'txtRla
        '
        Me.txtRla.BackColor = System.Drawing.SystemColors.Window
        Me.txtRla.Location = New System.Drawing.Point(399, 30)
        Me.txtRla.Name = "txtRla"
        Me.txtRla.Size = New System.Drawing.Size(72, 21)
        Me.txtRla.TabIndex = 20
        '
        'txtMca
        '
        Me.txtMca.BackColor = System.Drawing.SystemColors.Window
        Me.txtMca.Location = New System.Drawing.Point(119, 30)
        Me.txtMca.Name = "txtMca"
        Me.txtMca.Size = New System.Drawing.Size(72, 21)
        Me.txtMca.TabIndex = 15
        '
        'lblMca
        '
        Me.lblMca.Location = New System.Drawing.Point(3, 30)
        Me.lblMca.Name = "lblMca"
        Me.lblMca.Size = New System.Drawing.Size(110, 22)
        Me.lblMca.TabIndex = 152
        Me.lblMca.Text = "MCA"
        Me.lblMca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.commonTips.SetToolTip(Me.lblMca, "Minimum circuit ampacity")
        '
        'cboControlVoltage
        '
        Me.cboControlVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboControlVoltage.Items.AddRange(New Object() {"230", "208", "115", "115/24"})
        Me.cboControlVoltage.Location = New System.Drawing.Point(399, 3)
        Me.cboControlVoltage.Name = "cboControlVoltage"
        Me.cboControlVoltage.Size = New System.Drawing.Size(72, 21)
        Me.cboControlVoltage.TabIndex = 10
        '
        'lblControlVoltage
        '
        Me.lblControlVoltage.BackColor = System.Drawing.Color.Transparent
        Me.lblControlVoltage.Location = New System.Drawing.Point(283, 3)
        Me.lblControlVoltage.Name = "lblControlVoltage"
        Me.lblControlVoltage.Size = New System.Drawing.Size(110, 22)
        Me.lblControlVoltage.TabIndex = 137
        Me.lblControlVoltage.Text = "Control voltage"
        Me.lblControlVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEstShippingWeight
        '
        Me.txtEstShippingWeight.BackColor = System.Drawing.SystemColors.Window
        Me.txtEstShippingWeight.Location = New System.Drawing.Point(119, 57)
        Me.txtEstShippingWeight.Name = "txtEstShippingWeight"
        Me.txtEstShippingWeight.Size = New System.Drawing.Size(72, 21)
        Me.txtEstShippingWeight.TabIndex = 140
        '
        'lblEstShippingWeight
        '
        Me.lblEstShippingWeight.Location = New System.Drawing.Point(3, 57)
        Me.lblEstShippingWeight.Name = "lblEstShippingWeight"
        Me.lblEstShippingWeight.Size = New System.Drawing.Size(110, 22)
        Me.lblEstShippingWeight.TabIndex = 156
        Me.lblEstShippingWeight.Text = "Est. shipping weight"
        Me.lblEstShippingWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.commonTips.SetToolTip(Me.lblEstShippingWeight, "Estimated shipping weight in pounds")
        '
        'lblHeightUnits
        '
        Me.lblHeightUnits.AutoSize = True
        Me.lblHeightUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeightUnits.Location = New System.Drawing.Point(473, 93)
        Me.lblHeightUnits.Name = "lblHeightUnits"
        Me.lblHeightUnits.Size = New System.Drawing.Size(17, 11)
        Me.lblHeightUnits.TabIndex = 148
        Me.lblHeightUnits.Text = "In."
        Me.lblHeightUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstOperatingWeightUnits
        '
        Me.lblEstOperatingWeightUnits.AutoSize = True
        Me.lblEstOperatingWeightUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstOperatingWeightUnits.Location = New System.Drawing.Point(473, 65)
        Me.lblEstOperatingWeightUnits.Name = "lblEstOperatingWeightUnits"
        Me.lblEstOperatingWeightUnits.Size = New System.Drawing.Size(21, 11)
        Me.lblEstOperatingWeightUnits.TabIndex = 159
        Me.lblEstOperatingWeightUnits.Text = "Lbs."
        Me.lblEstOperatingWeightUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstShippingWeightUnits
        '
        Me.lblEstShippingWeightUnits.AutoSize = True
        Me.lblEstShippingWeightUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstShippingWeightUnits.Location = New System.Drawing.Point(193, 65)
        Me.lblEstShippingWeightUnits.Name = "lblEstShippingWeightUnits"
        Me.lblEstShippingWeightUnits.Size = New System.Drawing.Size(21, 11)
        Me.lblEstShippingWeightUnits.TabIndex = 158
        Me.lblEstShippingWeightUnits.Text = "Lbs."
        Me.lblEstShippingWeightUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstOperatingWeight
        '
        Me.lblEstOperatingWeight.Location = New System.Drawing.Point(274, 57)
        Me.lblEstOperatingWeight.Name = "lblEstOperatingWeight"
        Me.lblEstOperatingWeight.Size = New System.Drawing.Size(120, 22)
        Me.lblEstOperatingWeight.TabIndex = 157
        Me.lblEstOperatingWeight.Text = "Est. operating weight"
        Me.lblEstOperatingWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.commonTips.SetToolTip(Me.lblEstOperatingWeight, "Estimated operating weight in pounds")
        '
        'txtEstOperatingWeight
        '
        Me.txtEstOperatingWeight.BackColor = System.Drawing.SystemColors.Window
        Me.txtEstOperatingWeight.Location = New System.Drawing.Point(399, 57)
        Me.txtEstOperatingWeight.Name = "txtEstOperatingWeight"
        Me.txtEstOperatingWeight.Size = New System.Drawing.Size(72, 21)
        Me.txtEstOperatingWeight.TabIndex = 141
        '
        'txtLength
        '
        Me.txtLength.BackColor = System.Drawing.SystemColors.Window
        Me.txtLength.Location = New System.Drawing.Point(119, 84)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(72, 21)
        Me.txtLength.TabIndex = 143
        '
        'lblLength
        '
        Me.lblLength.BackColor = System.Drawing.Color.Transparent
        Me.lblLength.Location = New System.Drawing.Point(3, 84)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(110, 22)
        Me.lblLength.TabIndex = 134
        Me.lblLength.Text = "Length"
        Me.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWidth
        '
        Me.txtWidth.BackColor = System.Drawing.SystemColors.Window
        Me.txtWidth.Location = New System.Drawing.Point(257, 84)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(72, 21)
        Me.txtWidth.TabIndex = 144
        '
        'lblHeight
        '
        Me.lblHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblHeight.Location = New System.Drawing.Point(345, 84)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(48, 22)
        Me.lblHeight.TabIndex = 136
        Me.lblHeight.Text = "Height"
        Me.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHeight
        '
        Me.txtHeight.BackColor = System.Drawing.SystemColors.Window
        Me.txtHeight.Location = New System.Drawing.Point(399, 84)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(72, 21)
        Me.txtHeight.TabIndex = 145
        '
        'lblUnitVoltage
        '
        Me.lblUnitVoltage.BackColor = System.Drawing.Color.Transparent
        Me.lblUnitVoltage.Location = New System.Drawing.Point(3, 3)
        Me.lblUnitVoltage.Name = "lblUnitVoltage"
        Me.lblUnitVoltage.Size = New System.Drawing.Size(110, 22)
        Me.lblUnitVoltage.TabIndex = 160
        Me.lblUnitVoltage.Text = "Unit voltage"
        Me.lblUnitVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUnitVoltage
        '
        Me.cboUnitVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnitVoltage.Enabled = False
        Me.cboUnitVoltage.Items.AddRange(New Object() {"575/3/60", "460/3/60", "230/3/60", "208/3/60", "460/1/60", "230/1/60", "208/1/60", "115/1/60"})
        Me.cboUnitVoltage.Location = New System.Drawing.Point(119, 3)
        Me.cboUnitVoltage.Name = "cboUnitVoltage"
        Me.cboUnitVoltage.Size = New System.Drawing.Size(72, 21)
        Me.cboUnitVoltage.TabIndex = 5
        '
        'txtTag
        '
        Me.txtTag.Location = New System.Drawing.Point(119, 111)
        Me.txtTag.Name = "txtTag"
        Me.txtTag.Size = New System.Drawing.Size(352, 21)
        Me.txtTag.TabIndex = 164
        '
        'lblTag
        '
        Me.lblTag.BackColor = System.Drawing.Color.Transparent
        Me.lblTag.Location = New System.Drawing.Point(3, 111)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(110, 22)
        Me.lblTag.TabIndex = 162
        Me.lblTag.Text = "Tag / mark"
        Me.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSpecialInstructions
        '
        Me.txtSpecialInstructions.BackColor = System.Drawing.Color.White
        Me.txtSpecialInstructions.ForeColor = System.Drawing.Color.Black
        Me.txtSpecialInstructions.Location = New System.Drawing.Point(119, 138)
        Me.txtSpecialInstructions.MaxLength = 255
        Me.txtSpecialInstructions.Multiline = True
        Me.txtSpecialInstructions.Name = "txtSpecialInstructions"
        Me.txtSpecialInstructions.Size = New System.Drawing.Size(352, 47)
        Me.txtSpecialInstructions.TabIndex = 165
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.Location = New System.Drawing.Point(3, 138)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(110, 22)
        Me.lblRemarks.TabIndex = 163
        Me.lblRemarks.Text = "Special instructions"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panCommonSpecs
        '
        Me.panCommonSpecs.Controls.Add(Me.PictureBox1)
        Me.panCommonSpecs.Controls.Add(Me.lblUnitVoltage)
        Me.panCommonSpecs.Controls.Add(Me.txtTag)
        Me.panCommonSpecs.Controls.Add(Me.lblTag)
        Me.panCommonSpecs.Controls.Add(Me.txtSpecialInstructions)
        Me.panCommonSpecs.Controls.Add(Me.lblRemarks)
        Me.panCommonSpecs.Controls.Add(Me.txtHeight)
        Me.panCommonSpecs.Controls.Add(Me.lblHeightUnits)
        Me.panCommonSpecs.Controls.Add(Me.lblHeight)
        Me.panCommonSpecs.Controls.Add(Me.cboUnitVoltage)
        Me.panCommonSpecs.Controls.Add(Me.txtWidth)
        Me.panCommonSpecs.Controls.Add(Me.lblLength)
        Me.panCommonSpecs.Controls.Add(Me.lblWidth)
        Me.panCommonSpecs.Controls.Add(Me.txtLength)
        Me.panCommonSpecs.Controls.Add(Me.lblRlaUnits)
        Me.panCommonSpecs.Controls.Add(Me.txtEstOperatingWeight)
        Me.panCommonSpecs.Controls.Add(Me.lblMcaUnits)
        Me.panCommonSpecs.Controls.Add(Me.lblEstOperatingWeight)
        Me.panCommonSpecs.Controls.Add(Me.lblRla)
        Me.panCommonSpecs.Controls.Add(Me.lblEstShippingWeightUnits)
        Me.panCommonSpecs.Controls.Add(Me.txtRla)
        Me.panCommonSpecs.Controls.Add(Me.lblEstOperatingWeightUnits)
        Me.panCommonSpecs.Controls.Add(Me.txtMca)
        Me.panCommonSpecs.Controls.Add(Me.lblEstShippingWeight)
        Me.panCommonSpecs.Controls.Add(Me.lblMca)
        Me.panCommonSpecs.Controls.Add(Me.txtEstShippingWeight)
        Me.panCommonSpecs.Controls.Add(Me.cboControlVoltage)
        Me.panCommonSpecs.Controls.Add(Me.lblControlVoltage)
        Me.panCommonSpecs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panCommonSpecs.Location = New System.Drawing.Point(0, 0)
        Me.panCommonSpecs.Name = "panCommonSpecs"
        Me.panCommonSpecs.Size = New System.Drawing.Size(513, 190)
        Me.panCommonSpecs.TabIndex = 100
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Rae.RaeSolutions.My.Resources.Resources.help
        Me.PictureBox1.Location = New System.Drawing.Point(94, 159)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 166
        Me.PictureBox1.TabStop = False
        Me.commonTips.SetToolTip(Me.PictureBox1, "Please verify that special instructions are not truncated in reports. The order w" & _
                "rite up report only show 4 lines.")
        '
        'commonTips
        '
        Me.commonTips.AutoPopDelay = 9000
        Me.commonTips.InitialDelay = 500
        Me.commonTips.IsBalloon = True
        Me.commonTips.ReshowDelay = 100
        '
        'CommonSpecsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.panCommonSpecs)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CommonSpecsControl"
        Me.Size = New System.Drawing.Size(513, 190)
        Me.panCommonSpecs.ResumeLayout(False)
        Me.panCommonSpecs.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
   Friend WithEvents lblWidth As System.Windows.Forms.Label
   Friend WithEvents lblRlaUnits As System.Windows.Forms.Label
   Friend WithEvents lblMcaUnits As System.Windows.Forms.Label
   Friend WithEvents lblRla As System.Windows.Forms.Label
   Friend WithEvents txtRla As System.Windows.Forms.TextBox
   Friend WithEvents txtMca As System.Windows.Forms.TextBox
   Friend WithEvents lblMca As System.Windows.Forms.Label
   Friend WithEvents cboControlVoltage As System.Windows.Forms.ComboBox
   Friend WithEvents lblControlVoltage As System.Windows.Forms.Label
   Friend WithEvents txtEstShippingWeight As System.Windows.Forms.TextBox
   Friend WithEvents lblEstShippingWeight As System.Windows.Forms.Label
   Friend WithEvents lblHeightUnits As System.Windows.Forms.Label
   Friend WithEvents lblEstOperatingWeightUnits As System.Windows.Forms.Label
   Friend WithEvents lblEstShippingWeightUnits As System.Windows.Forms.Label
   Friend WithEvents lblEstOperatingWeight As System.Windows.Forms.Label
   Friend WithEvents txtEstOperatingWeight As System.Windows.Forms.TextBox
   Friend WithEvents txtLength As System.Windows.Forms.TextBox
   Friend WithEvents lblLength As System.Windows.Forms.Label
   Friend WithEvents txtWidth As System.Windows.Forms.TextBox
   Friend WithEvents lblHeight As System.Windows.Forms.Label
   Friend WithEvents txtHeight As System.Windows.Forms.TextBox
   Friend WithEvents lblUnitVoltage As System.Windows.Forms.Label
   Friend WithEvents cboUnitVoltage As System.Windows.Forms.ComboBox
   Friend WithEvents txtTag As System.Windows.Forms.TextBox
   Friend WithEvents lblTag As System.Windows.Forms.Label
   Friend WithEvents txtSpecialInstructions As System.Windows.Forms.TextBox
   Friend WithEvents lblRemarks As System.Windows.Forms.Label
   Friend WithEvents panCommonSpecs As System.Windows.Forms.Panel
   Friend WithEvents commonTips As System.Windows.Forms.ToolTip
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
