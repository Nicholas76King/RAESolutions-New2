<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitCoolerSpecsControl
    Inherits RaeSolutions.CommonSpecsControl

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
        Me.components = New System.ComponentModel.Container()
        Me.txtAltitude = New System.Windows.Forms.TextBox()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.lblUnitCapacity = New System.Windows.Forms.Label()
        Me.txtUnitCapacity = New System.Windows.Forms.TextBox()
        Me.lblLiquidTemp = New System.Windows.Forms.Label()
        Me.txtLiquidTemp = New System.Windows.Forms.TextBox()
        Me.lblEvaporatorTemp = New System.Windows.Forms.Label()
        Me.txtEvaporatorTemp = New System.Windows.Forms.TextBox()
        Me.lblCondensingTemp = New System.Windows.Forms.Label()
        Me.txtCondensingTemp = New System.Windows.Forms.TextBox()
        Me.lblTempDifference = New System.Windows.Forms.Label()
        Me.txtTempDifference = New System.Windows.Forms.TextBox()
        Me.lblBoxTemp = New System.Windows.Forms.Label()
        Me.txtBoxTemp = New System.Windows.Forms.TextBox()
        Me.cboRefrigerant = New System.Windows.Forms.ComboBox()
        Me.lblRefrigerant = New System.Windows.Forms.Label()
        Me.panType = New System.Windows.Forms.Panel()
        Me.lblType = New System.Windows.Forms.Label()
        Me.radRecirc = New System.Windows.Forms.RadioButton()
        Me.radFlooded = New System.Windows.Forms.RadioButton()
        Me.radDx = New System.Windows.Forms.RadioButton()
        Me.lblLiquidTempF = New System.Windows.Forms.Label()
        Me.lblEvaporatorTempF = New System.Windows.Forms.Label()
        Me.lblCondensingTempF = New System.Windows.Forms.Label()
        Me.lblBoxTempF = New System.Windows.Forms.Label()
        Me.lblTempDifferenceF = New System.Windows.Forms.Label()
        Me.lblUnitCapacityUnits = New System.Windows.Forms.Label()
        Me.lblAltitudeUnits = New System.Windows.Forms.Label()
        Me.unitCoolerTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.fanVoltageCombo = New System.Windows.Forms.ComboBox()
        Me.defrostVoltageCombo = New System.Windows.Forms.ComboBox()
        Me.fanVoltageLabel = New System.Windows.Forms.Label()
        Me.defrostVoltageLabel = New System.Windows.Forms.Label()
        Me.panType.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAltitude
        '
        Me.txtAltitude.Location = New System.Drawing.Point(120, 81)
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(72, 21)
        Me.txtAltitude.TabIndex = 35
        '
        'lblAltitude
        '
        Me.lblAltitude.Location = New System.Drawing.Point(-21, 81)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(107, 22)
        Me.lblAltitude.TabIndex = 168
        Me.lblAltitude.Text = "Altitude"
        Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUnitCapacity
        '
        Me.lblUnitCapacity.Location = New System.Drawing.Point(-16, -2)
        Me.lblUnitCapacity.Name = "lblUnitCapacity"
        Me.lblUnitCapacity.Size = New System.Drawing.Size(107, 22)
        Me.lblUnitCapacity.TabIndex = 170
        Me.lblUnitCapacity.Text = "Unit Est. Capacity"
        Me.lblUnitCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnitCapacity
        '
        Me.txtUnitCapacity.Location = New System.Drawing.Point(120, 0)
        Me.txtUnitCapacity.Name = "txtUnitCapacity"
        Me.txtUnitCapacity.Size = New System.Drawing.Size(72, 21)
        Me.txtUnitCapacity.TabIndex = 5
        '
        'lblLiquidTemp
        '
        Me.lblLiquidTemp.Location = New System.Drawing.Point(254, -2)
        Me.lblLiquidTemp.Name = "lblLiquidTemp"
        Me.lblLiquidTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblLiquidTemp.TabIndex = 172
        Me.lblLiquidTemp.Text = "Liquid temp."
        Me.lblLiquidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.unitCoolerTips.SetToolTip(Me.lblLiquidTemp, "Liquid temperature in Fahrenheit")
        '
        'txtLiquidTemp
        '
        Me.txtLiquidTemp.Location = New System.Drawing.Point(399, 0)
        Me.txtLiquidTemp.Name = "txtLiquidTemp"
        Me.txtLiquidTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtLiquidTemp.TabIndex = 10
        '
        'lblEvaporatorTemp
        '
        Me.lblEvaporatorTemp.Location = New System.Drawing.Point(-18, 27)
        Me.lblEvaporatorTemp.Name = "lblEvaporatorTemp"
        Me.lblEvaporatorTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblEvaporatorTemp.TabIndex = 174
        Me.lblEvaporatorTemp.Text = "Evaporator temp."
        Me.lblEvaporatorTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.unitCoolerTips.SetToolTip(Me.lblEvaporatorTemp, "Evaporator temperature in Fahrenheit")
        '
        'txtEvaporatorTemp
        '
        Me.txtEvaporatorTemp.Location = New System.Drawing.Point(120, 27)
        Me.txtEvaporatorTemp.Name = "txtEvaporatorTemp"
        Me.txtEvaporatorTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtEvaporatorTemp.TabIndex = 15
        '
        'lblCondensingTemp
        '
        Me.lblCondensingTemp.Location = New System.Drawing.Point(254, 27)
        Me.lblCondensingTemp.Name = "lblCondensingTemp"
        Me.lblCondensingTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblCondensingTemp.TabIndex = 176
        Me.lblCondensingTemp.Text = "Condensing temp."
        Me.lblCondensingTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.unitCoolerTips.SetToolTip(Me.lblCondensingTemp, "Condensing temperature in Fahrenheit")
        '
        'txtCondensingTemp
        '
        Me.txtCondensingTemp.Location = New System.Drawing.Point(399, 27)
        Me.txtCondensingTemp.Name = "txtCondensingTemp"
        Me.txtCondensingTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtCondensingTemp.TabIndex = 20
        '
        'lblTempDifference
        '
        Me.lblTempDifference.Location = New System.Drawing.Point(254, 53)
        Me.lblTempDifference.Name = "lblTempDifference"
        Me.lblTempDifference.Size = New System.Drawing.Size(107, 22)
        Me.lblTempDifference.TabIndex = 180
        Me.lblTempDifference.Text = "Temp. difference"
        Me.lblTempDifference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.unitCoolerTips.SetToolTip(Me.lblTempDifference, "Temperature difference in Fahrenheit")
        '
        'txtTempDifference
        '
        Me.txtTempDifference.Location = New System.Drawing.Point(399, 54)
        Me.txtTempDifference.Name = "txtTempDifference"
        Me.txtTempDifference.Size = New System.Drawing.Size(72, 21)
        Me.txtTempDifference.TabIndex = 30
        '
        'lblBoxTemp
        '
        Me.lblBoxTemp.Location = New System.Drawing.Point(-19, 53)
        Me.lblBoxTemp.Name = "lblBoxTemp"
        Me.lblBoxTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblBoxTemp.TabIndex = 178
        Me.lblBoxTemp.Text = "Box temp."
        Me.lblBoxTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.unitCoolerTips.SetToolTip(Me.lblBoxTemp, "Box temperature in Fahrenheit")
        '
        'txtBoxTemp
        '
        Me.txtBoxTemp.Location = New System.Drawing.Point(120, 54)
        Me.txtBoxTemp.Name = "txtBoxTemp"
        Me.txtBoxTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtBoxTemp.TabIndex = 25
        '
        'cboRefrigerant
        '
        Me.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRefrigerant.FormattingEnabled = True
        Me.cboRefrigerant.Items.AddRange(New Object() {"R507", "R22", "R404a", "R134a", "R407a", "R407c", "R407f"})
        Me.cboRefrigerant.Location = New System.Drawing.Point(399, 81)
        Me.cboRefrigerant.Name = "cboRefrigerant"
        Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cboRefrigerant.TabIndex = 40
        '
        'lblRefrigerant
        '
        Me.lblRefrigerant.Location = New System.Drawing.Point(254, 82)
        Me.lblRefrigerant.Name = "lblRefrigerant"
        Me.lblRefrigerant.Size = New System.Drawing.Size(107, 22)
        Me.lblRefrigerant.TabIndex = 182
        Me.lblRefrigerant.Text = "Refrigerant"
        Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panType
        '
        Me.panType.Controls.Add(Me.lblType)
        Me.panType.Controls.Add(Me.radRecirc)
        Me.panType.Controls.Add(Me.radFlooded)
        Me.panType.Controls.Add(Me.radDx)
        Me.panType.Location = New System.Drawing.Point(6, 107)
        Me.panType.Name = "panType"
        Me.panType.Size = New System.Drawing.Size(465, 26)
        Me.panType.TabIndex = 50
        '
        'lblType
        '
        Me.lblType.Location = New System.Drawing.Point(0, 0)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(107, 22)
        Me.lblType.TabIndex = 184
        Me.lblType.Text = "Type"
        Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'radRecirc
        '
        Me.radRecirc.AutoSize = True
        Me.radRecirc.Location = New System.Drawing.Point(272, 3)
        Me.radRecirc.Name = "radRecirc"
        Me.radRecirc.Size = New System.Drawing.Size(54, 17)
        Me.radRecirc.TabIndex = 2
        Me.radRecirc.TabStop = True
        Me.radRecirc.Text = "Recirc"
        Me.radRecirc.UseVisualStyleBackColor = True
        '
        'radFlooded
        '
        Me.radFlooded.AutoSize = True
        Me.radFlooded.Location = New System.Drawing.Point(182, 3)
        Me.radFlooded.Name = "radFlooded"
        Me.radFlooded.Size = New System.Drawing.Size(63, 17)
        Me.radFlooded.TabIndex = 1
        Me.radFlooded.TabStop = True
        Me.radFlooded.Text = "Flooded"
        Me.radFlooded.UseVisualStyleBackColor = True
        '
        'radDx
        '
        Me.radDx.AutoSize = True
        Me.radDx.Location = New System.Drawing.Point(113, 3)
        Me.radDx.Name = "radDx"
        Me.radDx.Size = New System.Drawing.Size(38, 17)
        Me.radDx.TabIndex = 0
        Me.radDx.TabStop = True
        Me.radDx.Text = "DX"
        Me.radDx.UseVisualStyleBackColor = True
        '
        'lblLiquidTempF
        '
        Me.lblLiquidTempF.AutoSize = True
        Me.lblLiquidTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiquidTempF.Location = New System.Drawing.Point(473, 9)
        Me.lblLiquidTempF.Name = "lblLiquidTempF"
        Me.lblLiquidTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblLiquidTempF.TabIndex = 184
        Me.lblLiquidTempF.Text = "ºF"
        Me.lblLiquidTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvaporatorTempF
        '
        Me.lblEvaporatorTempF.AutoSize = True
        Me.lblEvaporatorTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporatorTempF.Location = New System.Drawing.Point(194, 37)
        Me.lblEvaporatorTempF.Name = "lblEvaporatorTempF"
        Me.lblEvaporatorTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblEvaporatorTempF.TabIndex = 185
        Me.lblEvaporatorTempF.Text = "ºF"
        Me.lblEvaporatorTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCondensingTempF
        '
        Me.lblCondensingTempF.AutoSize = True
        Me.lblCondensingTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondensingTempF.Location = New System.Drawing.Point(473, 37)
        Me.lblCondensingTempF.Name = "lblCondensingTempF"
        Me.lblCondensingTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblCondensingTempF.TabIndex = 186
        Me.lblCondensingTempF.Text = "ºF"
        Me.lblCondensingTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBoxTempF
        '
        Me.lblBoxTempF.AutoSize = True
        Me.lblBoxTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxTempF.Location = New System.Drawing.Point(194, 63)
        Me.lblBoxTempF.Name = "lblBoxTempF"
        Me.lblBoxTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblBoxTempF.TabIndex = 187
        Me.lblBoxTempF.Text = "ºF"
        Me.lblBoxTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTempDifferenceF
        '
        Me.lblTempDifferenceF.AutoSize = True
        Me.lblTempDifferenceF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempDifferenceF.Location = New System.Drawing.Point(473, 63)
        Me.lblTempDifferenceF.Name = "lblTempDifferenceF"
        Me.lblTempDifferenceF.Size = New System.Drawing.Size(15, 11)
        Me.lblTempDifferenceF.TabIndex = 188
        Me.lblTempDifferenceF.Text = "ºF"
        Me.lblTempDifferenceF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitCapacityUnits
        '
        Me.lblUnitCapacityUnits.AutoSize = True
        Me.lblUnitCapacityUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitCapacityUnits.Location = New System.Drawing.Point(194, 9)
        Me.lblUnitCapacityUnits.Name = "lblUnitCapacityUnits"
        Me.lblUnitCapacityUnits.Size = New System.Drawing.Size(31, 11)
        Me.lblUnitCapacityUnits.TabIndex = 189
        Me.lblUnitCapacityUnits.Text = "BTUH"
        Me.lblUnitCapacityUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAltitudeUnits
        '
        Me.lblAltitudeUnits.AutoSize = True
        Me.lblAltitudeUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitudeUnits.Location = New System.Drawing.Point(194, 90)
        Me.lblAltitudeUnits.Name = "lblAltitudeUnits"
        Me.lblAltitudeUnits.Size = New System.Drawing.Size(24, 11)
        Me.lblAltitudeUnits.TabIndex = 190
        Me.lblAltitudeUnits.Text = "Feet"
        Me.lblAltitudeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fanVoltageCombo
        '
        Me.fanVoltageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fanVoltageCombo.FormattingEnabled = True
        Me.fanVoltageCombo.Items.AddRange(New Object() {"460/3/60", "230/3/60", "230/1/60"})
        Me.fanVoltageCombo.Location = New System.Drawing.Point(120, 135)
        Me.fanVoltageCombo.Name = "fanVoltageCombo"
        Me.fanVoltageCombo.Size = New System.Drawing.Size(72, 21)
        Me.fanVoltageCombo.TabIndex = 191
        '
        'defrostVoltageCombo
        '
        Me.defrostVoltageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.defrostVoltageCombo.FormattingEnabled = True
        Me.defrostVoltageCombo.Items.AddRange(New Object() {"460/3/60", "230/3/60", "230/1/60"})
        Me.defrostVoltageCombo.Location = New System.Drawing.Point(399, 135)
        Me.defrostVoltageCombo.Name = "defrostVoltageCombo"
        Me.defrostVoltageCombo.Size = New System.Drawing.Size(72, 21)
        Me.defrostVoltageCombo.TabIndex = 192
        '
        'fanVoltageLabel
        '
        Me.fanVoltageLabel.Location = New System.Drawing.Point(7, 134)
        Me.fanVoltageLabel.Name = "fanVoltageLabel"
        Me.fanVoltageLabel.Size = New System.Drawing.Size(107, 22)
        Me.fanVoltageLabel.TabIndex = 193
        Me.fanVoltageLabel.Text = "Fan voltage"
        Me.fanVoltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'defrostVoltageLabel
        '
        Me.defrostVoltageLabel.Location = New System.Drawing.Point(286, 134)
        Me.defrostVoltageLabel.Name = "defrostVoltageLabel"
        Me.defrostVoltageLabel.Size = New System.Drawing.Size(107, 22)
        Me.defrostVoltageLabel.TabIndex = 194
        Me.defrostVoltageLabel.Text = "Defrost voltage"
        Me.defrostVoltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UnitCoolerSpecsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.defrostVoltageLabel)
        Me.Controls.Add(Me.fanVoltageLabel)
        Me.Controls.Add(Me.defrostVoltageCombo)
        Me.Controls.Add(Me.fanVoltageCombo)
        Me.Controls.Add(Me.lblAltitudeUnits)
        Me.Controls.Add(Me.lblUnitCapacityUnits)
        Me.Controls.Add(Me.lblTempDifferenceF)
        Me.Controls.Add(Me.lblBoxTempF)
        Me.Controls.Add(Me.lblCondensingTempF)
        Me.Controls.Add(Me.lblEvaporatorTempF)
        Me.Controls.Add(Me.lblLiquidTempF)
        Me.Controls.Add(Me.panType)
        Me.Controls.Add(Me.lblRefrigerant)
        Me.Controls.Add(Me.cboRefrigerant)
        Me.Controls.Add(Me.lblTempDifference)
        Me.Controls.Add(Me.txtTempDifference)
        Me.Controls.Add(Me.lblBoxTemp)
        Me.Controls.Add(Me.txtBoxTemp)
        Me.Controls.Add(Me.lblCondensingTemp)
        Me.Controls.Add(Me.txtCondensingTemp)
        Me.Controls.Add(Me.lblEvaporatorTemp)
        Me.Controls.Add(Me.txtEvaporatorTemp)
        Me.Controls.Add(Me.lblLiquidTemp)
        Me.Controls.Add(Me.txtLiquidTemp)
        Me.Controls.Add(Me.lblUnitCapacity)
        Me.Controls.Add(Me.txtUnitCapacity)
        Me.Controls.Add(Me.lblAltitude)
        Me.Controls.Add(Me.txtAltitude)
        Me.Name = "UnitCoolerSpecsControl"
        Me.Size = New System.Drawing.Size(513, 349)
        Me.Controls.SetChildIndex(Me.txtAltitude, 0)
        Me.Controls.SetChildIndex(Me.lblAltitude, 0)
        Me.Controls.SetChildIndex(Me.txtUnitCapacity, 0)
        Me.Controls.SetChildIndex(Me.lblUnitCapacity, 0)
        Me.Controls.SetChildIndex(Me.txtLiquidTemp, 0)
        Me.Controls.SetChildIndex(Me.lblLiquidTemp, 0)
        Me.Controls.SetChildIndex(Me.txtEvaporatorTemp, 0)
        Me.Controls.SetChildIndex(Me.lblEvaporatorTemp, 0)
        Me.Controls.SetChildIndex(Me.txtCondensingTemp, 0)
        Me.Controls.SetChildIndex(Me.lblCondensingTemp, 0)
        Me.Controls.SetChildIndex(Me.txtBoxTemp, 0)
        Me.Controls.SetChildIndex(Me.lblBoxTemp, 0)
        Me.Controls.SetChildIndex(Me.txtTempDifference, 0)
        Me.Controls.SetChildIndex(Me.lblTempDifference, 0)
        Me.Controls.SetChildIndex(Me.cboRefrigerant, 0)
        Me.Controls.SetChildIndex(Me.lblRefrigerant, 0)
        Me.Controls.SetChildIndex(Me.panType, 0)
        Me.Controls.SetChildIndex(Me.lblLiquidTempF, 0)
        Me.Controls.SetChildIndex(Me.lblEvaporatorTempF, 0)
        Me.Controls.SetChildIndex(Me.lblCondensingTempF, 0)
        Me.Controls.SetChildIndex(Me.lblBoxTempF, 0)
        Me.Controls.SetChildIndex(Me.lblTempDifferenceF, 0)
        Me.Controls.SetChildIndex(Me.lblUnitCapacityUnits, 0)
        Me.Controls.SetChildIndex(Me.lblAltitudeUnits, 0)
        Me.Controls.SetChildIndex(Me.fanVoltageCombo, 0)
        Me.Controls.SetChildIndex(Me.defrostVoltageCombo, 0)
        Me.Controls.SetChildIndex(Me.fanVoltageLabel, 0)
        Me.Controls.SetChildIndex(Me.defrostVoltageLabel, 0)
        Me.panType.ResumeLayout(False)
        Me.panType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents lblUnitCapacity As System.Windows.Forms.Label
    Friend WithEvents txtUnitCapacity As System.Windows.Forms.TextBox
    Friend WithEvents lblLiquidTemp As System.Windows.Forms.Label
    Friend WithEvents txtLiquidTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblEvaporatorTemp As System.Windows.Forms.Label
    Friend WithEvents lblCondensingTemp As System.Windows.Forms.Label
    Friend WithEvents txtCondensingTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblTempDifference As System.Windows.Forms.Label
    Friend WithEvents txtTempDifference As System.Windows.Forms.TextBox
    Friend WithEvents lblBoxTemp As System.Windows.Forms.Label
    Friend WithEvents txtBoxTemp As System.Windows.Forms.TextBox
    Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
    Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
    Friend WithEvents panType As System.Windows.Forms.Panel
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents radRecirc As System.Windows.Forms.RadioButton
    Friend WithEvents radFlooded As System.Windows.Forms.RadioButton
    Friend WithEvents radDx As System.Windows.Forms.RadioButton
    Friend WithEvents lblLiquidTempF As System.Windows.Forms.Label
    Friend WithEvents lblEvaporatorTempF As System.Windows.Forms.Label
    Friend WithEvents lblCondensingTempF As System.Windows.Forms.Label
    Friend WithEvents lblBoxTempF As System.Windows.Forms.Label
    Friend WithEvents lblTempDifferenceF As System.Windows.Forms.Label
    Friend WithEvents lblUnitCapacityUnits As System.Windows.Forms.Label
    Friend WithEvents lblAltitudeUnits As System.Windows.Forms.Label
    Friend WithEvents unitCoolerTips As System.Windows.Forms.ToolTip
    Friend WithEvents fanVoltageCombo As System.Windows.Forms.ComboBox
    Friend WithEvents defrostVoltageCombo As System.Windows.Forms.ComboBox
    Friend WithEvents fanVoltageLabel As System.Windows.Forms.Label
    Friend WithEvents defrostVoltageLabel As System.Windows.Forms.Label
    Public WithEvents txtEvaporatorTemp As System.Windows.Forms.TextBox

End Class
