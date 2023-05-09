<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductCoolerSpecsControl
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
        Me.components = New System.ComponentModel.Container()
        Me.lblAltitudeUnits = New System.Windows.Forms.Label()
        Me.lblUnitCapacityUnits = New System.Windows.Forms.Label()
        Me.lblTempDifferenceF = New System.Windows.Forms.Label()
        Me.lblBoxTempF = New System.Windows.Forms.Label()
        Me.lblCondensingTempF = New System.Windows.Forms.Label()
        Me.lblEvaporatorTempF = New System.Windows.Forms.Label()
        Me.lblLiquidTempF = New System.Windows.Forms.Label()
        Me.panType = New System.Windows.Forms.Panel()
        Me.lblType = New System.Windows.Forms.Label()
        Me.radRecirc = New System.Windows.Forms.RadioButton()
        Me.radFlooded = New System.Windows.Forms.RadioButton()
        Me.radDx = New System.Windows.Forms.RadioButton()
        Me.lblRefrigerant = New System.Windows.Forms.Label()
        Me.cboRefrigerant = New System.Windows.Forms.ComboBox()
        Me.lblTempDifference = New System.Windows.Forms.Label()
        Me.txtTempDifference = New System.Windows.Forms.TextBox()
        Me.lblBoxTemp = New System.Windows.Forms.Label()
        Me.txtBoxTemp = New System.Windows.Forms.TextBox()
        Me.lblCondensingTemp = New System.Windows.Forms.Label()
        Me.txtCondensingTemp = New System.Windows.Forms.TextBox()
        Me.lblEvaporatorTemp = New System.Windows.Forms.Label()
        Me.txtEvaporatorTemp = New System.Windows.Forms.TextBox()
        Me.lblLiquidTemp = New System.Windows.Forms.Label()
        Me.txtLiquidTemp = New System.Windows.Forms.TextBox()
        Me.lblUnitCapacity = New System.Windows.Forms.Label()
        Me.txtUnitCapacity = New System.Windows.Forms.TextBox()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.txtAltitude = New System.Windows.Forms.TextBox()
        Me.productCoolerTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBlowerDCPosition = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCFM = New System.Windows.Forms.TextBox()
        Me.txtPSI = New System.Windows.Forms.TextBox()
        Me.cboBlowerDCPosition = New System.Windows.Forms.ComboBox()
        Me.cboHand = New System.Windows.Forms.ComboBox()
        Me.cboFanMotorHP = New System.Windows.Forms.ComboBox()
        Me.cboFanMotorType = New System.Windows.Forms.ComboBox()
        Me.cboMotorLocation = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.panType.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAltitudeUnits
        '
        Me.lblAltitudeUnits.AutoSize = True
        Me.lblAltitudeUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitudeUnits.Location = New System.Drawing.Point(193, 90)
        Me.lblAltitudeUnits.Name = "lblAltitudeUnits"
        Me.lblAltitudeUnits.Size = New System.Drawing.Size(24, 11)
        Me.lblAltitudeUnits.TabIndex = 214
        Me.lblAltitudeUnits.Text = "Feet"
        Me.lblAltitudeUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitCapacityUnits
        '
        Me.lblUnitCapacityUnits.AutoSize = True
        Me.lblUnitCapacityUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitCapacityUnits.Location = New System.Drawing.Point(193, 9)
        Me.lblUnitCapacityUnits.Name = "lblUnitCapacityUnits"
        Me.lblUnitCapacityUnits.Size = New System.Drawing.Size(31, 11)
        Me.lblUnitCapacityUnits.TabIndex = 213
        Me.lblUnitCapacityUnits.Text = "BTUH"
        Me.lblUnitCapacityUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTempDifferenceF
        '
        Me.lblTempDifferenceF.AutoSize = True
        Me.lblTempDifferenceF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempDifferenceF.Location = New System.Drawing.Point(472, 63)
        Me.lblTempDifferenceF.Name = "lblTempDifferenceF"
        Me.lblTempDifferenceF.Size = New System.Drawing.Size(15, 11)
        Me.lblTempDifferenceF.TabIndex = 212
        Me.lblTempDifferenceF.Text = "ºF"
        Me.lblTempDifferenceF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBoxTempF
        '
        Me.lblBoxTempF.AutoSize = True
        Me.lblBoxTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxTempF.Location = New System.Drawing.Point(193, 63)
        Me.lblBoxTempF.Name = "lblBoxTempF"
        Me.lblBoxTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblBoxTempF.TabIndex = 211
        Me.lblBoxTempF.Text = "ºF"
        Me.lblBoxTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCondensingTempF
        '
        Me.lblCondensingTempF.AutoSize = True
        Me.lblCondensingTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondensingTempF.Location = New System.Drawing.Point(472, 37)
        Me.lblCondensingTempF.Name = "lblCondensingTempF"
        Me.lblCondensingTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblCondensingTempF.TabIndex = 210
        Me.lblCondensingTempF.Text = "ºF"
        Me.lblCondensingTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvaporatorTempF
        '
        Me.lblEvaporatorTempF.AutoSize = True
        Me.lblEvaporatorTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporatorTempF.Location = New System.Drawing.Point(193, 37)
        Me.lblEvaporatorTempF.Name = "lblEvaporatorTempF"
        Me.lblEvaporatorTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblEvaporatorTempF.TabIndex = 209
        Me.lblEvaporatorTempF.Text = "ºF"
        Me.lblEvaporatorTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLiquidTempF
        '
        Me.lblLiquidTempF.AutoSize = True
        Me.lblLiquidTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiquidTempF.Location = New System.Drawing.Point(472, 9)
        Me.lblLiquidTempF.Name = "lblLiquidTempF"
        Me.lblLiquidTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblLiquidTempF.TabIndex = 208
        Me.lblLiquidTempF.Text = "ºF"
        Me.lblLiquidTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panType
        '
        Me.panType.Controls.Add(Me.lblType)
        Me.panType.Controls.Add(Me.radRecirc)
        Me.panType.Controls.Add(Me.radFlooded)
        Me.panType.Controls.Add(Me.radDx)
        Me.panType.Location = New System.Drawing.Point(29, 218)
        Me.panType.Name = "panType"
        Me.panType.Size = New System.Drawing.Size(465, 26)
        Me.panType.TabIndex = 45
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
        'lblRefrigerant
        '
        Me.lblRefrigerant.Location = New System.Drawing.Point(285, 81)
        Me.lblRefrigerant.Name = "lblRefrigerant"
        Me.lblRefrigerant.Size = New System.Drawing.Size(107, 22)
        Me.lblRefrigerant.TabIndex = 207
        Me.lblRefrigerant.Text = "Refrigerant"
        Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRefrigerant
        '
        Me.cboRefrigerant.FormattingEnabled = True
        Me.cboRefrigerant.Items.AddRange(New Object() {"R404a", "R507"})
        Me.cboRefrigerant.Location = New System.Drawing.Point(399, 81)
        Me.cboRefrigerant.Name = "cboRefrigerant"
        Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cboRefrigerant.TabIndex = 36
        '
        'lblTempDifference
        '
        Me.lblTempDifference.Location = New System.Drawing.Point(285, 54)
        Me.lblTempDifference.Name = "lblTempDifference"
        Me.lblTempDifference.Size = New System.Drawing.Size(107, 22)
        Me.lblTempDifference.TabIndex = 206
        Me.lblTempDifference.Text = "Temp. difference"
        Me.lblTempDifference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.productCoolerTips.SetToolTip(Me.lblTempDifference, "Temperature difference in Fahrenheit")
        '
        'txtTempDifference
        '
        Me.txtTempDifference.Location = New System.Drawing.Point(398, 54)
        Me.txtTempDifference.Name = "txtTempDifference"
        Me.txtTempDifference.Size = New System.Drawing.Size(72, 21)
        Me.txtTempDifference.TabIndex = 30
        '
        'lblBoxTemp
        '
        Me.lblBoxTemp.Location = New System.Drawing.Point(6, 56)
        Me.lblBoxTemp.Name = "lblBoxTemp"
        Me.lblBoxTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblBoxTemp.TabIndex = 205
        Me.lblBoxTemp.Text = "Box temp."
        Me.lblBoxTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.productCoolerTips.SetToolTip(Me.lblBoxTemp, "Box temperature in Fahrenheit")
        '
        'txtBoxTemp
        '
        Me.txtBoxTemp.Location = New System.Drawing.Point(119, 54)
        Me.txtBoxTemp.Name = "txtBoxTemp"
        Me.txtBoxTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtBoxTemp.TabIndex = 25
        '
        'lblCondensingTemp
        '
        Me.lblCondensingTemp.Location = New System.Drawing.Point(285, 27)
        Me.lblCondensingTemp.Name = "lblCondensingTemp"
        Me.lblCondensingTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblCondensingTemp.TabIndex = 204
        Me.lblCondensingTemp.Text = "Condensing temp."
        Me.lblCondensingTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.productCoolerTips.SetToolTip(Me.lblCondensingTemp, "Condensing temperature in Fahrenheit")
        '
        'txtCondensingTemp
        '
        Me.txtCondensingTemp.Location = New System.Drawing.Point(398, 27)
        Me.txtCondensingTemp.Name = "txtCondensingTemp"
        Me.txtCondensingTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtCondensingTemp.TabIndex = 20
        '
        'lblEvaporatorTemp
        '
        Me.lblEvaporatorTemp.Location = New System.Drawing.Point(6, 27)
        Me.lblEvaporatorTemp.Name = "lblEvaporatorTemp"
        Me.lblEvaporatorTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblEvaporatorTemp.TabIndex = 203
        Me.lblEvaporatorTemp.Text = "Evaporator temp."
        Me.lblEvaporatorTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.productCoolerTips.SetToolTip(Me.lblEvaporatorTemp, "Evaporator temperature in Fahrenheit")
        '
        'txtEvaporatorTemp
        '
        Me.txtEvaporatorTemp.Location = New System.Drawing.Point(119, 27)
        Me.txtEvaporatorTemp.Name = "txtEvaporatorTemp"
        Me.txtEvaporatorTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtEvaporatorTemp.TabIndex = 15
        '
        'lblLiquidTemp
        '
        Me.lblLiquidTemp.Location = New System.Drawing.Point(285, 0)
        Me.lblLiquidTemp.Name = "lblLiquidTemp"
        Me.lblLiquidTemp.Size = New System.Drawing.Size(107, 22)
        Me.lblLiquidTemp.TabIndex = 202
        Me.lblLiquidTemp.Text = "Liquid temp."
        Me.lblLiquidTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.productCoolerTips.SetToolTip(Me.lblLiquidTemp, "Liquid temperature in Fahrenheit")
        '
        'txtLiquidTemp
        '
        Me.txtLiquidTemp.Location = New System.Drawing.Point(398, 0)
        Me.txtLiquidTemp.Name = "txtLiquidTemp"
        Me.txtLiquidTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtLiquidTemp.TabIndex = 10
        '
        'lblUnitCapacity
        '
        Me.lblUnitCapacity.Location = New System.Drawing.Point(6, 0)
        Me.lblUnitCapacity.Name = "lblUnitCapacity"
        Me.lblUnitCapacity.Size = New System.Drawing.Size(107, 22)
        Me.lblUnitCapacity.TabIndex = 201
        Me.lblUnitCapacity.Text = "Unit Est. Capacity"
        Me.lblUnitCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnitCapacity
        '
        Me.txtUnitCapacity.Location = New System.Drawing.Point(119, 0)
        Me.txtUnitCapacity.Name = "txtUnitCapacity"
        Me.txtUnitCapacity.Size = New System.Drawing.Size(72, 21)
        Me.txtUnitCapacity.TabIndex = 5
        '
        'lblAltitude
        '
        Me.lblAltitude.Location = New System.Drawing.Point(6, 81)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(107, 22)
        Me.lblAltitude.TabIndex = 200
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(70, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 22)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "CFM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 22)
        Me.Label2.TabIndex = 216
        Me.Label2.Text = "Ext. Static Pressure"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(283, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 22)
        Me.Label3.TabIndex = 217
        Me.Label3.Text = "Fan Motor HP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'lblBlowerDCPosition
        '
        Me.lblBlowerDCPosition.Location = New System.Drawing.Point(-13, 156)
        Me.lblBlowerDCPosition.Name = "lblBlowerDCPosition"
        Me.lblBlowerDCPosition.Size = New System.Drawing.Size(126, 33)
        Me.lblBlowerDCPosition.TabIndex = 218
        Me.lblBlowerDCPosition.Text = "Blower D/C Position"
        Me.lblBlowerDCPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(283, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 22)
        Me.Label5.TabIndex = 219
        Me.Label5.Text = "Fan Motor Type"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(283, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 22)
        Me.Label6.TabIndex = 220
        Me.Label6.Text = "Motor Location"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(64, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 22)
        Me.Label7.TabIndex = 221
        Me.Label7.Text = "Hand"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCFM
        '
        Me.txtCFM.Location = New System.Drawing.Point(119, 108)
        Me.txtCFM.Name = "txtCFM"
        Me.txtCFM.Size = New System.Drawing.Size(72, 21)
        Me.txtCFM.TabIndex = 37
        '
        'txtPSI
        '
        Me.txtPSI.Location = New System.Drawing.Point(119, 137)
        Me.txtPSI.Name = "txtPSI"
        Me.txtPSI.Size = New System.Drawing.Size(72, 21)
        Me.txtPSI.TabIndex = 39
        '
        'cboBlowerDCPosition
        '
        Me.cboBlowerDCPosition.FormattingEnabled = True
        Me.cboBlowerDCPosition.Location = New System.Drawing.Point(119, 164)
        Me.cboBlowerDCPosition.Name = "cboBlowerDCPosition"
        Me.cboBlowerDCPosition.Size = New System.Drawing.Size(72, 21)
        Me.cboBlowerDCPosition.TabIndex = 41
        '
        'cboHand
        '
        Me.cboHand.FormattingEnabled = True
        Me.cboHand.Items.AddRange(New Object() {"Left", "Right"})
        Me.cboHand.Location = New System.Drawing.Point(119, 191)
        Me.cboHand.Name = "cboHand"
        Me.cboHand.Size = New System.Drawing.Size(72, 21)
        Me.cboHand.TabIndex = 43
        '
        'cboFanMotorHP
        '
        Me.cboFanMotorHP.FormattingEnabled = True
        Me.cboFanMotorHP.Items.AddRange(New Object() {"1/2", "3/4", "1", "1 1/2", "2", "3", "5", "7 1/2", "10", "15", "20", "25", "30"})
        Me.cboFanMotorHP.Location = New System.Drawing.Point(399, 108)
        Me.cboFanMotorHP.Name = "cboFanMotorHP"
        Me.cboFanMotorHP.Size = New System.Drawing.Size(72, 21)
        Me.cboFanMotorHP.TabIndex = 38
        Me.cboFanMotorHP.Visible = False
        '
        'cboFanMotorType
        '
        Me.cboFanMotorType.FormattingEnabled = True
        Me.cboFanMotorType.Items.AddRange(New Object() {"ODP", "TEFC"})
        Me.cboFanMotorType.Location = New System.Drawing.Point(399, 136)
        Me.cboFanMotorType.Name = "cboFanMotorType"
        Me.cboFanMotorType.Size = New System.Drawing.Size(72, 21)
        Me.cboFanMotorType.TabIndex = 40
        Me.cboFanMotorType.Visible = False
        '
        'cboMotorLocation
        '
        Me.cboMotorLocation.FormattingEnabled = True
        Me.cboMotorLocation.Items.AddRange(New Object() {"Top Right", "Top Left", "Rear Right", "Rear Left", "Front Right", "Front Left"})
        Me.cboMotorLocation.Location = New System.Drawing.Point(398, 163)
        Me.cboMotorLocation.Name = "cboMotorLocation"
        Me.cboMotorLocation.Size = New System.Drawing.Size(72, 21)
        Me.cboMotorLocation.TabIndex = 42
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(193, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 11)
        Me.Label8.TabIndex = 229
        Me.Label8.Text = "psi"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(472, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 11)
        Me.Label9.TabIndex = 230
        Me.Label9.Text = "HP"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Visible = False
        '
        'ProductCoolerSpecsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboMotorLocation)
        Me.Controls.Add(Me.cboFanMotorType)
        Me.Controls.Add(Me.cboFanMotorHP)
        Me.Controls.Add(Me.cboHand)
        Me.Controls.Add(Me.cboBlowerDCPosition)
        Me.Controls.Add(Me.txtPSI)
        Me.Controls.Add(Me.txtCFM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblBlowerDCPosition)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAltitudeUnits)
        Me.Controls.Add(Me.lblUnitCapacityUnits)
        Me.Controls.Add(Me.lblTempDifferenceF)
        Me.Controls.Add(Me.lblBoxTempF)
        Me.Controls.Add(Me.lblCondensingTempF)
        Me.Controls.Add(Me.lblEvaporatorTempF)
        Me.Controls.Add(Me.lblLiquidTempF)
        Me.Controls.Add(Me.lblRefrigerant)
        Me.Controls.Add(Me.panType)
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
        Me.Name = "ProductCoolerSpecsControl"
        Me.Size = New System.Drawing.Size(513, 432)
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
        Me.Controls.SetChildIndex(Me.panType, 0)
        Me.Controls.SetChildIndex(Me.lblRefrigerant, 0)
        Me.Controls.SetChildIndex(Me.lblLiquidTempF, 0)
        Me.Controls.SetChildIndex(Me.lblEvaporatorTempF, 0)
        Me.Controls.SetChildIndex(Me.lblCondensingTempF, 0)
        Me.Controls.SetChildIndex(Me.lblBoxTempF, 0)
        Me.Controls.SetChildIndex(Me.lblTempDifferenceF, 0)
        Me.Controls.SetChildIndex(Me.lblUnitCapacityUnits, 0)
        Me.Controls.SetChildIndex(Me.lblAltitudeUnits, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.lblBlowerDCPosition, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtCFM, 0)
        Me.Controls.SetChildIndex(Me.txtPSI, 0)
        Me.Controls.SetChildIndex(Me.cboBlowerDCPosition, 0)
        Me.Controls.SetChildIndex(Me.cboHand, 0)
        Me.Controls.SetChildIndex(Me.cboFanMotorHP, 0)
        Me.Controls.SetChildIndex(Me.cboFanMotorType, 0)
        Me.Controls.SetChildIndex(Me.cboMotorLocation, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.panType.ResumeLayout(False)
        Me.panType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAltitudeUnits As System.Windows.Forms.Label
    Friend WithEvents lblUnitCapacityUnits As System.Windows.Forms.Label
    Friend WithEvents lblTempDifferenceF As System.Windows.Forms.Label
    Friend WithEvents lblBoxTempF As System.Windows.Forms.Label
    Friend WithEvents lblCondensingTempF As System.Windows.Forms.Label
    Friend WithEvents lblEvaporatorTempF As System.Windows.Forms.Label
    Friend WithEvents lblLiquidTempF As System.Windows.Forms.Label
    Friend WithEvents panType As System.Windows.Forms.Panel
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents radRecirc As System.Windows.Forms.RadioButton
    Friend WithEvents radFlooded As System.Windows.Forms.RadioButton
    Friend WithEvents radDx As System.Windows.Forms.RadioButton
    Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
    Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
    Friend WithEvents lblTempDifference As System.Windows.Forms.Label
    Friend WithEvents txtTempDifference As System.Windows.Forms.TextBox
    Friend WithEvents lblBoxTemp As System.Windows.Forms.Label
    Friend WithEvents txtBoxTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblCondensingTemp As System.Windows.Forms.Label
    Friend WithEvents txtCondensingTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblEvaporatorTemp As System.Windows.Forms.Label
    Friend WithEvents txtEvaporatorTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblLiquidTemp As System.Windows.Forms.Label
    Friend WithEvents txtLiquidTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblUnitCapacity As System.Windows.Forms.Label
    Friend WithEvents txtUnitCapacity As System.Windows.Forms.TextBox
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
    Friend WithEvents productCoolerTips As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBlowerDCPosition As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCFM As System.Windows.Forms.TextBox
    Friend WithEvents txtPSI As System.Windows.Forms.TextBox
    Friend WithEvents cboBlowerDCPosition As System.Windows.Forms.ComboBox
    Friend WithEvents cboHand As System.Windows.Forms.ComboBox
    Friend WithEvents cboFanMotorHP As System.Windows.Forms.ComboBox
    Friend WithEvents cboFanMotorType As System.Windows.Forms.ComboBox
    Friend WithEvents cboMotorLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
