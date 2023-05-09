<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FluidCoolerSpecsControl
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
        Me.chkCompressorWarranty = New System.Windows.Forms.CheckBox
        Me.txtAmbientTemp = New System.Windows.Forms.TextBox
        Me.lblAmbientTemp = New System.Windows.Forms.Label
        Me.lblAmbientTempUnits = New System.Windows.Forms.Label
        Me.fluidCoolerTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'lblAltitudeFeet
        '
        Me.lblAltitudeFeet.AutoSize = True
        Me.lblAltitudeFeet.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitudeFeet.Location = New System.Drawing.Point(193, 90)
        Me.lblAltitudeFeet.Name = "lblAltitudeFeet"
        Me.lblAltitudeFeet.Size = New System.Drawing.Size(24, 11)
        Me.lblAltitudeFeet.TabIndex = 174
        Me.lblAltitudeFeet.Text = "Feet"
        Me.lblAltitudeFeet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAltitude
        '
        Me.lblAltitude.BackColor = System.Drawing.Color.Transparent
        Me.lblAltitude.Location = New System.Drawing.Point(3, 81)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(110, 22)
        Me.lblAltitude.TabIndex = 172
        Me.lblAltitude.Text = "Altitude"
        Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAltitude
        '
        Me.txtAltitude.Location = New System.Drawing.Point(119, 81)
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(72, 21)
        Me.txtAltitude.TabIndex = 35
        '
        'txtGlycolPercent
        '
        Me.txtGlycolPercent.Location = New System.Drawing.Point(399, 54)
        Me.txtGlycolPercent.Name = "txtGlycolPercent"
        Me.txtGlycolPercent.Size = New System.Drawing.Size(72, 21)
        Me.txtGlycolPercent.TabIndex = 30
        '
        'lblGlycolPercent
        '
        Me.lblGlycolPercent.BackColor = System.Drawing.Color.Transparent
        Me.lblGlycolPercent.Location = New System.Drawing.Point(283, 54)
        Me.lblGlycolPercent.Name = "lblGlycolPercent"
        Me.lblGlycolPercent.Size = New System.Drawing.Size(110, 22)
        Me.lblGlycolPercent.TabIndex = 168
        Me.lblGlycolPercent.Text = "Glycol %"
        Me.lblGlycolPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEnteringFluidTempUnits
        '
        Me.lblEnteringFluidTempUnits.AutoSize = True
        Me.lblEnteringFluidTempUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnteringFluidTempUnits.Location = New System.Drawing.Point(193, 36)
        Me.lblEnteringFluidTempUnits.Name = "lblEnteringFluidTempUnits"
        Me.lblEnteringFluidTempUnits.Size = New System.Drawing.Size(15, 11)
        Me.lblEnteringFluidTempUnits.TabIndex = 178
        Me.lblEnteringFluidTempUnits.Text = "ºF"
        Me.lblEnteringFluidTempUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEnteringFluidTemp
        '
        Me.txtEnteringFluidTemp.Location = New System.Drawing.Point(119, 27)
        Me.txtEnteringFluidTemp.Name = "txtEnteringFluidTemp"
        Me.txtEnteringFluidTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtEnteringFluidTemp.TabIndex = 15
        '
        'lblEnteringFluidTemp
        '
        Me.lblEnteringFluidTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblEnteringFluidTemp.Location = New System.Drawing.Point(3, 27)
        Me.lblEnteringFluidTemp.Name = "lblEnteringFluidTemp"
        Me.lblEnteringFluidTemp.Size = New System.Drawing.Size(110, 22)
        Me.lblEnteringFluidTemp.TabIndex = 177
        Me.lblEnteringFluidTemp.Text = "Entering fluid temp."
        Me.lblEnteringFluidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.fluidCoolerTips.SetToolTip(Me.lblEnteringFluidTemp, "Entering fluid temperature in Fahrenheit")
        '
        'lblLeavingFluidTempUnits
        '
        Me.lblLeavingFluidTempUnits.AutoSize = True
        Me.lblLeavingFluidTempUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeavingFluidTempUnits.Location = New System.Drawing.Point(473, 36)
        Me.lblLeavingFluidTempUnits.Name = "lblLeavingFluidTempUnits"
        Me.lblLeavingFluidTempUnits.Size = New System.Drawing.Size(15, 11)
        Me.lblLeavingFluidTempUnits.TabIndex = 181
        Me.lblLeavingFluidTempUnits.Text = "ºF"
        Me.lblLeavingFluidTempUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLeavingFluidTemp
        '
        Me.txtLeavingFluidTemp.Location = New System.Drawing.Point(399, 27)
        Me.txtLeavingFluidTemp.Name = "txtLeavingFluidTemp"
        Me.txtLeavingFluidTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtLeavingFluidTemp.TabIndex = 20
        '
        'lblLeavingFluidTemp
        '
        Me.lblLeavingFluidTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblLeavingFluidTemp.Location = New System.Drawing.Point(283, 27)
        Me.lblLeavingFluidTemp.Name = "lblLeavingFluidTemp"
        Me.lblLeavingFluidTemp.Size = New System.Drawing.Size(110, 22)
        Me.lblLeavingFluidTemp.TabIndex = 180
        Me.lblLeavingFluidTemp.Text = "Leaving fluid temp."
        Me.lblLeavingFluidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.fluidCoolerTips.SetToolTip(Me.lblLeavingFluidTemp, "Leaving fluid temperature in Fahrenheit")
        '
        'lblFlowUnits
        '
        Me.lblFlowUnits.AutoSize = True
        Me.lblFlowUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlowUnits.Location = New System.Drawing.Point(473, 9)
        Me.lblFlowUnits.Name = "lblFlowUnits"
        Me.lblFlowUnits.Size = New System.Drawing.Size(26, 11)
        Me.lblFlowUnits.TabIndex = 184
        Me.lblFlowUnits.Text = "GPM"
        Me.lblFlowUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFlow
        '
        Me.txtFlow.Location = New System.Drawing.Point(399, 0)
        Me.txtFlow.Name = "txtFlow"
        Me.txtFlow.Size = New System.Drawing.Size(72, 21)
        Me.txtFlow.TabIndex = 10
        '
        'lblFlow
        '
        Me.lblFlow.BackColor = System.Drawing.Color.Transparent
        Me.lblFlow.Location = New System.Drawing.Point(283, 0)
        Me.lblFlow.Name = "lblFlow"
        Me.lblFlow.Size = New System.Drawing.Size(110, 22)
        Me.lblFlow.TabIndex = 183
        Me.lblFlow.Text = "Flow"
        Me.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapacityUnits
        '
        Me.lblCapacityUnits.AutoSize = True
        Me.lblCapacityUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacityUnits.Location = New System.Drawing.Point(193, 9)
        Me.lblCapacityUnits.Name = "lblCapacityUnits"
        Me.lblCapacityUnits.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacityUnits.TabIndex = 187
        Me.lblCapacityUnits.Text = "Tons"
        Me.lblCapacityUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCapacity
        '
        Me.txtCapacity.Location = New System.Drawing.Point(119, 0)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacity.TabIndex = 5
        '
        'lblCapacity
        '
        Me.lblCapacity.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity.Location = New System.Drawing.Point(3, 0)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity.TabIndex = 186
        Me.lblCapacity.Text = "Design Est. Capacity"
        Me.lblCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFluid
        '
        Me.lblFluid.Location = New System.Drawing.Point(3, 54)
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
        Me.cboFluid.Location = New System.Drawing.Point(119, 54)
        Me.cboFluid.Name = "cboFluid"
        Me.cboFluid.Size = New System.Drawing.Size(72, 21)
        Me.cboFluid.TabIndex = 25
        '
        'chkCompressorWarranty
        '
        Me.chkCompressorWarranty.AutoSize = True
        Me.chkCompressorWarranty.Location = New System.Drawing.Point(118, 108)
        Me.chkCompressorWarranty.Name = "chkCompressorWarranty"
        Me.chkCompressorWarranty.Size = New System.Drawing.Size(211, 17)
        Me.chkCompressorWarranty.TabIndex = 190
        Me.chkCompressorWarranty.Text = "4 year extended compressor warranty"
        Me.chkCompressorWarranty.UseVisualStyleBackColor = True
        Me.chkCompressorWarranty.Visible = False
        '
        'txtAmbientTemp
        '
        Me.txtAmbientTemp.Location = New System.Drawing.Point(399, 81)
        Me.txtAmbientTemp.Name = "txtAmbientTemp"
        Me.txtAmbientTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtAmbientTemp.TabIndex = 40
        '
        'lblAmbientTemp
        '
        Me.lblAmbientTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblAmbientTemp.Location = New System.Drawing.Point(283, 81)
        Me.lblAmbientTemp.Name = "lblAmbientTemp"
        Me.lblAmbientTemp.Size = New System.Drawing.Size(110, 22)
        Me.lblAmbientTemp.TabIndex = 192
        Me.lblAmbientTemp.Text = "Ambient temp."
        Me.lblAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.fluidCoolerTips.SetToolTip(Me.lblAmbientTemp, "Ambient temperature in Fahrenheit")
        '
        'lblAmbientTempUnits
        '
        Me.lblAmbientTempUnits.AutoSize = True
        Me.lblAmbientTempUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmbientTempUnits.Location = New System.Drawing.Point(473, 91)
        Me.lblAmbientTempUnits.Name = "lblAmbientTempUnits"
        Me.lblAmbientTempUnits.Size = New System.Drawing.Size(15, 11)
        Me.lblAmbientTempUnits.TabIndex = 193
        Me.lblAmbientTempUnits.Text = "ºF"
        Me.lblAmbientTempUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FluidCoolerSpecsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.lblAmbientTempUnits)
        Me.Controls.Add(Me.txtAmbientTemp)
        Me.Controls.Add(Me.lblAmbientTemp)
        Me.Controls.Add(Me.chkCompressorWarranty)
        Me.Controls.Add(Me.lblFluid)
        Me.Controls.Add(Me.cboFluid)
        Me.Controls.Add(Me.lblCapacityUnits)
        Me.Controls.Add(Me.txtCapacity)
        Me.Controls.Add(Me.lblCapacity)
        Me.Controls.Add(Me.lblFlowUnits)
        Me.Controls.Add(Me.txtFlow)
        Me.Controls.Add(Me.lblFlow)
        Me.Controls.Add(Me.lblLeavingFluidTempUnits)
        Me.Controls.Add(Me.txtLeavingFluidTemp)
        Me.Controls.Add(Me.lblLeavingFluidTemp)
        Me.Controls.Add(Me.lblEnteringFluidTempUnits)
        Me.Controls.Add(Me.txtEnteringFluidTemp)
        Me.Controls.Add(Me.lblEnteringFluidTemp)
        Me.Controls.Add(Me.lblAltitudeFeet)
        Me.Controls.Add(Me.lblAltitude)
        Me.Controls.Add(Me.txtAltitude)
        Me.Controls.Add(Me.txtGlycolPercent)
        Me.Controls.Add(Me.lblGlycolPercent)
        Me.Name = "FluidCoolerSpecsControl"
        Me.Size = New System.Drawing.Size(513, 296)
        Me.Controls.SetChildIndex(Me.lblGlycolPercent, 0)
        Me.Controls.SetChildIndex(Me.txtGlycolPercent, 0)
        Me.Controls.SetChildIndex(Me.txtAltitude, 0)
        Me.Controls.SetChildIndex(Me.lblAltitude, 0)
        Me.Controls.SetChildIndex(Me.lblAltitudeFeet, 0)
        Me.Controls.SetChildIndex(Me.lblEnteringFluidTemp, 0)
        Me.Controls.SetChildIndex(Me.txtEnteringFluidTemp, 0)
        Me.Controls.SetChildIndex(Me.lblEnteringFluidTempUnits, 0)
        Me.Controls.SetChildIndex(Me.lblLeavingFluidTemp, 0)
        Me.Controls.SetChildIndex(Me.txtLeavingFluidTemp, 0)
        Me.Controls.SetChildIndex(Me.lblLeavingFluidTempUnits, 0)
        Me.Controls.SetChildIndex(Me.lblFlow, 0)
        Me.Controls.SetChildIndex(Me.txtFlow, 0)
        Me.Controls.SetChildIndex(Me.lblFlowUnits, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity, 0)
        Me.Controls.SetChildIndex(Me.txtCapacity, 0)
        Me.Controls.SetChildIndex(Me.lblCapacityUnits, 0)
        Me.Controls.SetChildIndex(Me.cboFluid, 0)
        Me.Controls.SetChildIndex(Me.lblFluid, 0)
        Me.Controls.SetChildIndex(Me.chkCompressorWarranty, 0)
        Me.Controls.SetChildIndex(Me.lblAmbientTemp, 0)
        Me.Controls.SetChildIndex(Me.txtAmbientTemp, 0)
        Me.Controls.SetChildIndex(Me.lblAmbientTempUnits, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAltitudeFeet As System.Windows.Forms.Label
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
    Friend WithEvents chkCompressorWarranty As System.Windows.Forms.CheckBox
    Friend WithEvents txtAmbientTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblAmbientTemp As System.Windows.Forms.Label
    Friend WithEvents lblAmbientTempUnits As System.Windows.Forms.Label
    Friend WithEvents fluidCoolerTips As System.Windows.Forms.ToolTip

End Class
