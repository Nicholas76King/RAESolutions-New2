<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class chiller_specs_control
    Inherits RAESolutions.CommonSpecsControl

    'Form overrides dispose to clean up the component list.
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
Me.components = New System.ComponentModel.Container
Me.lblAltitudeFeet = New System.Windows.Forms.Label
Me.lblRefrigerant = New System.Windows.Forms.Label
Me.cboRefrigerant = New System.Windows.Forms.ComboBox
Me.lblAltitude = New System.Windows.Forms.Label
Me.txtAltitude = New System.Windows.Forms.TextBox
Me.txtGlycolPercent = New System.Windows.Forms.TextBox
Me.lblGlycolPercent = New System.Windows.Forms.Label
Me.lblEnteringFluidTempUnits = New System.Windows.Forms.Label
Me.txtEnteringFluidTemp = New System.Windows.Forms.TextBox
Me.lblEnteringFluidTemp = New System.Windows.Forms.Label
Me.lblLeavingFluidTempUnits = New System.Windows.Forms.Label
Me.txtLeavingFluidTemp = New System.Windows.Forms.TextBox
Me.lblLeavingFluidTemp = New System.Windows.Forms.Label
Me.lblFlowUnits = New System.Windows.Forms.Label
Me.txtFlow = New System.Windows.Forms.TextBox
Me.lblFlow = New System.Windows.Forms.Label
Me.lblCapacityUnits = New System.Windows.Forms.Label
Me.txtCapacity = New System.Windows.Forms.TextBox
Me.lblCapacity = New System.Windows.Forms.Label
Me.lblFluid = New System.Windows.Forms.Label
Me.cboFluid = New System.Windows.Forms.ComboBox
Me.lblAmbientTempUnits = New System.Windows.Forms.Label
Me.txtAmbientTemp = New System.Windows.Forms.TextBox
Me.lblAmbientTemp = New System.Windows.Forms.Label
Me.lblEvaporatorPressureDropUnits = New System.Windows.Forms.Label
Me.txtEvaporatorPressureDrop = New System.Windows.Forms.TextBox
Me.lblEvaporatorPressureDrop = New System.Windows.Forms.Label
Me.chillerTips = New System.Windows.Forms.ToolTip(Me.components)
Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
Me.panSplitCondenser = New System.Windows.Forms.Panel
Me.lblSplitCondenser = New System.Windows.Forms.Label
Me.lllSplitCondenser = New System.Windows.Forms.LinkLabel
Me.panChillerSpecs = New System.Windows.Forms.Panel
Me.txt_unit_efficiency = New System.Windows.Forms.TextBox
Me.FlowLayoutPanel1.SuspendLayout()
Me.panSplitCondenser.SuspendLayout()
Me.panChillerSpecs.SuspendLayout()
Me.SuspendLayout()
'
'lblAltitudeFeet
'
Me.lblAltitudeFeet.AutoSize = True
Me.lblAltitudeFeet.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblAltitudeFeet.Location = New System.Drawing.Point(470, 117)
Me.lblAltitudeFeet.Name = "lblAltitudeFeet"
Me.lblAltitudeFeet.Size = New System.Drawing.Size(24, 11)
Me.lblAltitudeFeet.TabIndex = 174
Me.lblAltitudeFeet.Text = "Feet"
Me.lblAltitudeFeet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'lblRefrigerant
'
Me.lblRefrigerant.Location = New System.Drawing.Point(0, 81)
Me.lblRefrigerant.Name = "lblRefrigerant"
Me.lblRefrigerant.Size = New System.Drawing.Size(110, 22)
Me.lblRefrigerant.TabIndex = 173
Me.lblRefrigerant.Text = "Refrigerant"
Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'cboRefrigerant
'
Me.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cboRefrigerant.Items.AddRange(New Object() {"R22", "R404a", "R134a", "R407c"})
Me.cboRefrigerant.Location = New System.Drawing.Point(116, 81)
Me.cboRefrigerant.Name = "cboRefrigerant"
Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
Me.cboRefrigerant.TabIndex = 35
'
'lblAltitude
'
Me.lblAltitude.BackColor = System.Drawing.Color.Transparent
Me.lblAltitude.Location = New System.Drawing.Point(280, 108)
Me.lblAltitude.Name = "lblAltitude"
Me.lblAltitude.Size = New System.Drawing.Size(110, 22)
Me.lblAltitude.TabIndex = 172
Me.lblAltitude.Text = "Altitude"
Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'txtAltitude
'
Me.txtAltitude.Location = New System.Drawing.Point(396, 108)
Me.txtAltitude.Name = "txtAltitude"
Me.txtAltitude.Size = New System.Drawing.Size(72, 21)
Me.txtAltitude.TabIndex = 50
'
'txtGlycolPercent
'
Me.txtGlycolPercent.Location = New System.Drawing.Point(396, 54)
Me.txtGlycolPercent.Name = "txtGlycolPercent"
Me.txtGlycolPercent.Size = New System.Drawing.Size(72, 21)
Me.txtGlycolPercent.TabIndex = 30
'
'lblGlycolPercent
'
Me.lblGlycolPercent.BackColor = System.Drawing.Color.Transparent
Me.lblGlycolPercent.Location = New System.Drawing.Point(280, 54)
Me.lblGlycolPercent.Name = "lblGlycolPercent"
Me.lblGlycolPercent.Size = New System.Drawing.Size(110, 22)
Me.lblGlycolPercent.TabIndex = 168
Me.lblGlycolPercent.Text = "Glycol %"
Me.lblGlycolPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chillerTips.SetToolTip(Me.lblGlycolPercent, "Percentage of glycol")
'
'lblEnteringFluidTempUnits
'
Me.lblEnteringFluidTempUnits.AutoSize = True
Me.lblEnteringFluidTempUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblEnteringFluidTempUnits.Location = New System.Drawing.Point(190, 36)
Me.lblEnteringFluidTempUnits.Name = "lblEnteringFluidTempUnits"
Me.lblEnteringFluidTempUnits.Size = New System.Drawing.Size(15, 11)
Me.lblEnteringFluidTempUnits.TabIndex = 178
Me.lblEnteringFluidTempUnits.Text = "ºF"
Me.lblEnteringFluidTempUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'txtEnteringFluidTemp
'
Me.txtEnteringFluidTemp.Location = New System.Drawing.Point(116, 27)
Me.txtEnteringFluidTemp.Name = "txtEnteringFluidTemp"
Me.txtEnteringFluidTemp.Size = New System.Drawing.Size(72, 21)
Me.txtEnteringFluidTemp.TabIndex = 15
'
'lblEnteringFluidTemp
'
Me.lblEnteringFluidTemp.BackColor = System.Drawing.Color.Transparent
Me.lblEnteringFluidTemp.Location = New System.Drawing.Point(0, 27)
Me.lblEnteringFluidTemp.Name = "lblEnteringFluidTemp"
Me.lblEnteringFluidTemp.Size = New System.Drawing.Size(110, 22)
Me.lblEnteringFluidTemp.TabIndex = 177
Me.lblEnteringFluidTemp.Text = "Entering fluid temp."
Me.lblEnteringFluidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chillerTips.SetToolTip(Me.lblEnteringFluidTemp, "Entering fluid temperature in Fahrenheit")
'
'lblLeavingFluidTempUnits
'
Me.lblLeavingFluidTempUnits.AutoSize = True
Me.lblLeavingFluidTempUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblLeavingFluidTempUnits.Location = New System.Drawing.Point(470, 36)
Me.lblLeavingFluidTempUnits.Name = "lblLeavingFluidTempUnits"
Me.lblLeavingFluidTempUnits.Size = New System.Drawing.Size(15, 11)
Me.lblLeavingFluidTempUnits.TabIndex = 181
Me.lblLeavingFluidTempUnits.Text = "ºF"
Me.lblLeavingFluidTempUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'txtLeavingFluidTemp
'
Me.txtLeavingFluidTemp.Location = New System.Drawing.Point(396, 27)
Me.txtLeavingFluidTemp.Name = "txtLeavingFluidTemp"
Me.txtLeavingFluidTemp.Size = New System.Drawing.Size(72, 21)
Me.txtLeavingFluidTemp.TabIndex = 20
'
'lblLeavingFluidTemp
'
Me.lblLeavingFluidTemp.BackColor = System.Drawing.Color.Transparent
Me.lblLeavingFluidTemp.Location = New System.Drawing.Point(280, 27)
Me.lblLeavingFluidTemp.Name = "lblLeavingFluidTemp"
Me.lblLeavingFluidTemp.Size = New System.Drawing.Size(110, 22)
Me.lblLeavingFluidTemp.TabIndex = 180
Me.lblLeavingFluidTemp.Text = "Leaving fluid temp."
Me.lblLeavingFluidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chillerTips.SetToolTip(Me.lblLeavingFluidTemp, "Leaving fluid temperature in Fahrenheit")
'
'lblFlowUnits
'
Me.lblFlowUnits.AutoSize = True
Me.lblFlowUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblFlowUnits.Location = New System.Drawing.Point(470, 90)
Me.lblFlowUnits.Name = "lblFlowUnits"
Me.lblFlowUnits.Size = New System.Drawing.Size(26, 11)
Me.lblFlowUnits.TabIndex = 184
Me.lblFlowUnits.Text = "GPM"
Me.lblFlowUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'txtFlow
'
Me.txtFlow.Location = New System.Drawing.Point(396, 81)
Me.txtFlow.Name = "txtFlow"
Me.txtFlow.Size = New System.Drawing.Size(72, 21)
Me.txtFlow.TabIndex = 40
'
'lblFlow
'
Me.lblFlow.BackColor = System.Drawing.Color.Transparent
Me.lblFlow.Location = New System.Drawing.Point(280, 81)
Me.lblFlow.Name = "lblFlow"
Me.lblFlow.Size = New System.Drawing.Size(110, 22)
Me.lblFlow.TabIndex = 183
Me.lblFlow.Text = "Flow"
Me.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chillerTips.SetToolTip(Me.lblFlow, "Flow in gallons per minute")
'
'lblCapacityUnits
'
Me.lblCapacityUnits.AutoSize = True
Me.lblCapacityUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblCapacityUnits.Location = New System.Drawing.Point(190, 9)
Me.lblCapacityUnits.Name = "lblCapacityUnits"
Me.lblCapacityUnits.Size = New System.Drawing.Size(25, 11)
Me.lblCapacityUnits.TabIndex = 187
Me.lblCapacityUnits.Text = "Tons"
Me.lblCapacityUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'txtCapacity
'
Me.txtCapacity.Location = New System.Drawing.Point(116, 0)
Me.txtCapacity.Name = "txtCapacity"
Me.txtCapacity.Size = New System.Drawing.Size(72, 21)
Me.txtCapacity.TabIndex = 5
'
'lblCapacity
'
Me.lblCapacity.BackColor = System.Drawing.Color.Transparent
Me.lblCapacity.Location = New System.Drawing.Point(0, 0)
Me.lblCapacity.Name = "lblCapacity"
Me.lblCapacity.Size = New System.Drawing.Size(110, 22)
Me.lblCapacity.TabIndex = 186
Me.lblCapacity.Text = "Design capacity"
Me.lblCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblFluid
'
Me.lblFluid.Location = New System.Drawing.Point(0, 54)
Me.lblFluid.Name = "lblFluid"
Me.lblFluid.Size = New System.Drawing.Size(110, 22)
Me.lblFluid.TabIndex = 189
Me.lblFluid.Text = "Fluid"
Me.lblFluid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'cboFluid
'
Me.cboFluid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cboFluid.Items.AddRange(New Object() {"Water", "Ethylene", "Propylene"})
Me.cboFluid.Location = New System.Drawing.Point(116, 54)
Me.cboFluid.Name = "cboFluid"
Me.cboFluid.Size = New System.Drawing.Size(72, 21)
Me.cboFluid.TabIndex = 25
'
'lblAmbientTempUnits
'
Me.lblAmbientTempUnits.AutoSize = True
Me.lblAmbientTempUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblAmbientTempUnits.Location = New System.Drawing.Point(470, 9)
Me.lblAmbientTempUnits.Name = "lblAmbientTempUnits"
Me.lblAmbientTempUnits.Size = New System.Drawing.Size(15, 11)
Me.lblAmbientTempUnits.TabIndex = 193
Me.lblAmbientTempUnits.Text = "ºF"
Me.lblAmbientTempUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'txtAmbientTemp
'
Me.txtAmbientTemp.Location = New System.Drawing.Point(396, 0)
Me.txtAmbientTemp.Name = "txtAmbientTemp"
Me.txtAmbientTemp.Size = New System.Drawing.Size(72, 21)
Me.txtAmbientTemp.TabIndex = 10
'
'lblAmbientTemp
'
Me.lblAmbientTemp.BackColor = System.Drawing.Color.Transparent
Me.lblAmbientTemp.Location = New System.Drawing.Point(280, 0)
Me.lblAmbientTemp.Name = "lblAmbientTemp"
Me.lblAmbientTemp.Size = New System.Drawing.Size(110, 22)
Me.lblAmbientTemp.TabIndex = 192
Me.lblAmbientTemp.Text = "Ambient temp."
Me.lblAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chillerTips.SetToolTip(Me.lblAmbientTemp, "Ambient temperature in Fahrenheit")
'
'lblEvaporatorPressureDropUnits
'
Me.lblEvaporatorPressureDropUnits.AutoSize = True
Me.lblEvaporatorPressureDropUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblEvaporatorPressureDropUnits.Location = New System.Drawing.Point(190, 117)
Me.lblEvaporatorPressureDropUnits.Name = "lblEvaporatorPressureDropUnits"
Me.lblEvaporatorPressureDropUnits.Size = New System.Drawing.Size(16, 11)
Me.lblEvaporatorPressureDropUnits.TabIndex = 196
Me.lblEvaporatorPressureDropUnits.Text = "psi"
Me.lblEvaporatorPressureDropUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'txtEvaporatorPressureDrop
'
Me.txtEvaporatorPressureDrop.Location = New System.Drawing.Point(116, 108)
Me.txtEvaporatorPressureDrop.Name = "txtEvaporatorPressureDrop"
Me.txtEvaporatorPressureDrop.Size = New System.Drawing.Size(72, 21)
Me.txtEvaporatorPressureDrop.TabIndex = 45
'
'lblEvaporatorPressureDrop
'
Me.lblEvaporatorPressureDrop.BackColor = System.Drawing.Color.Transparent
Me.lblEvaporatorPressureDrop.Location = New System.Drawing.Point(0, 108)
Me.lblEvaporatorPressureDrop.Name = "lblEvaporatorPressureDrop"
Me.lblEvaporatorPressureDrop.Size = New System.Drawing.Size(110, 22)
Me.lblEvaporatorPressureDrop.TabIndex = 195
Me.lblEvaporatorPressureDrop.Text = "Evap. press. drop"
Me.lblEvaporatorPressureDrop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chillerTips.SetToolTip(Me.lblEvaporatorPressureDrop, "Evaporator pressure drop")
'
'FlowLayoutPanel1
'
Me.FlowLayoutPanel1.Controls.Add(Me.panSplitCondenser)
Me.FlowLayoutPanel1.Controls.Add(Me.panChillerSpecs)
Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 3)
Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
Me.FlowLayoutPanel1.Size = New System.Drawing.Size(513, 143)
Me.FlowLayoutPanel1.TabIndex = 197
'
'panSplitCondenser
'
Me.panSplitCondenser.BackColor = System.Drawing.Color.LightYellow
Me.panSplitCondenser.Controls.Add(Me.lblSplitCondenser)
Me.panSplitCondenser.Controls.Add(Me.lllSplitCondenser)
Me.panSplitCondenser.Location = New System.Drawing.Point(0, 0)
Me.panSplitCondenser.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
Me.panSplitCondenser.Name = "panSplitCondenser"
Me.panSplitCondenser.Size = New System.Drawing.Size(513, 32)
Me.panSplitCondenser.TabIndex = 200
Me.panSplitCondenser.Visible = False
'
'lblSplitCondenser
'
Me.lblSplitCondenser.Location = New System.Drawing.Point(-3, 5)
Me.lblSplitCondenser.Name = "lblSplitCondenser"
Me.lblSplitCondenser.Size = New System.Drawing.Size(113, 21)
Me.lblSplitCondenser.TabIndex = 198
Me.lblSplitCondenser.Text = "Split condenser"
Me.lblSplitCondenser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lllSplitCondenser
'
Me.lllSplitCondenser.AutoSize = True
Me.lllSplitCondenser.Cursor = System.Windows.Forms.Cursors.Hand
Me.lllSplitCondenser.Location = New System.Drawing.Point(118, 9)
Me.lllSplitCondenser.Name = "lllSplitCondenser"
Me.lllSplitCondenser.Size = New System.Drawing.Size(0, 13)
Me.lllSplitCondenser.TabIndex = 199
'
'panChillerSpecs
'
Me.panChillerSpecs.Controls.Add(Me.txt_unit_efficiency)
Me.panChillerSpecs.Controls.Add(Me.lblCapacity)
Me.panChillerSpecs.Controls.Add(Me.lblGlycolPercent)
Me.panChillerSpecs.Controls.Add(Me.txtGlycolPercent)
Me.panChillerSpecs.Controls.Add(Me.lblEvaporatorPressureDropUnits)
Me.panChillerSpecs.Controls.Add(Me.txtAltitude)
Me.panChillerSpecs.Controls.Add(Me.txtEvaporatorPressureDrop)
Me.panChillerSpecs.Controls.Add(Me.lblAltitude)
Me.panChillerSpecs.Controls.Add(Me.lblEvaporatorPressureDrop)
Me.panChillerSpecs.Controls.Add(Me.cboRefrigerant)
Me.panChillerSpecs.Controls.Add(Me.lblAmbientTempUnits)
Me.panChillerSpecs.Controls.Add(Me.lblRefrigerant)
Me.panChillerSpecs.Controls.Add(Me.txtAmbientTemp)
Me.panChillerSpecs.Controls.Add(Me.lblAltitudeFeet)
Me.panChillerSpecs.Controls.Add(Me.lblAmbientTemp)
Me.panChillerSpecs.Controls.Add(Me.lblEnteringFluidTemp)
Me.panChillerSpecs.Controls.Add(Me.lblFluid)
Me.panChillerSpecs.Controls.Add(Me.txtEnteringFluidTemp)
Me.panChillerSpecs.Controls.Add(Me.cboFluid)
Me.panChillerSpecs.Controls.Add(Me.lblEnteringFluidTempUnits)
Me.panChillerSpecs.Controls.Add(Me.lblCapacityUnits)
Me.panChillerSpecs.Controls.Add(Me.lblLeavingFluidTemp)
Me.panChillerSpecs.Controls.Add(Me.txtCapacity)
Me.panChillerSpecs.Controls.Add(Me.txtLeavingFluidTemp)
Me.panChillerSpecs.Controls.Add(Me.lblLeavingFluidTempUnits)
Me.panChillerSpecs.Controls.Add(Me.lblFlowUnits)
Me.panChillerSpecs.Controls.Add(Me.lblFlow)
Me.panChillerSpecs.Controls.Add(Me.txtFlow)
Me.panChillerSpecs.Location = New System.Drawing.Point(516, 3)
Me.panChillerSpecs.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
Me.panChillerSpecs.Name = "panChillerSpecs"
Me.panChillerSpecs.Size = New System.Drawing.Size(510, 131)
Me.panChillerSpecs.TabIndex = 0
'
'txt_unit_efficiency
'
Me.txt_unit_efficiency.Location = New System.Drawing.Point(217, 81)
Me.txt_unit_efficiency.Name = "txt_unit_efficiency"
Me.txt_unit_efficiency.Size = New System.Drawing.Size(100, 21)
Me.txt_unit_efficiency.TabIndex = 197
Me.txt_unit_efficiency.Visible = False
'
'chiller_specs_control
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.Controls.Add(Me.FlowLayoutPanel1)
Me.Name = "chiller_specs_control"
Me.Size = New System.Drawing.Size(513, 336)
Me.Controls.SetChildIndex(Me.FlowLayoutPanel1, 0)
Me.FlowLayoutPanel1.ResumeLayout(False)
Me.panSplitCondenser.ResumeLayout(False)
Me.panSplitCondenser.PerformLayout()
Me.panChillerSpecs.ResumeLayout(False)
Me.panChillerSpecs.PerformLayout()
Me.ResumeLayout(False)

End Sub
   Friend WithEvents lblAltitudeFeet As System.Windows.Forms.Label
   Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
   Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
   Friend WithEvents lblAltitude As System.Windows.Forms.Label
   Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
   Friend WithEvents txtGlycolPercent As System.Windows.Forms.TextBox
   Friend WithEvents lblGlycolPercent As System.Windows.Forms.Label
   Friend WithEvents lblEnteringFluidTempUnits As System.Windows.Forms.Label
   Friend WithEvents txtEnteringFluidTemp As System.Windows.Forms.TextBox
   Friend WithEvents lblEnteringFluidTemp As System.Windows.Forms.Label
   Friend WithEvents lblLeavingFluidTempUnits As System.Windows.Forms.Label
   Friend WithEvents txtLeavingFluidTemp As System.Windows.Forms.TextBox
   Friend WithEvents lblLeavingFluidTemp As System.Windows.Forms.Label
   Friend WithEvents lblFlowUnits As System.Windows.Forms.Label
   Friend WithEvents txtFlow As System.Windows.Forms.TextBox
   Friend WithEvents lblFlow As System.Windows.Forms.Label
   Friend WithEvents lblCapacityUnits As System.Windows.Forms.Label
   Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity As System.Windows.Forms.Label
   Friend WithEvents lblFluid As System.Windows.Forms.Label
   Friend WithEvents cboFluid As System.Windows.Forms.ComboBox
   Friend WithEvents lblAmbientTempUnits As System.Windows.Forms.Label
   Friend WithEvents txtAmbientTemp As System.Windows.Forms.TextBox
   Friend WithEvents lblAmbientTemp As System.Windows.Forms.Label
   Friend WithEvents lblEvaporatorPressureDropUnits As System.Windows.Forms.Label
   Friend WithEvents txtEvaporatorPressureDrop As System.Windows.Forms.TextBox
   Friend WithEvents lblEvaporatorPressureDrop As System.Windows.Forms.Label
   Friend WithEvents chillerTips As System.Windows.Forms.ToolTip
   Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents panSplitCondenser As System.Windows.Forms.Panel
   Friend WithEvents lblSplitCondenser As System.Windows.Forms.Label
   Friend WithEvents lllSplitCondenser As System.Windows.Forms.LinkLabel
   Friend WithEvents panChillerSpecs As System.Windows.Forms.Panel
   Friend WithEvents txt_unit_efficiency As System.Windows.Forms.TextBox

End Class
