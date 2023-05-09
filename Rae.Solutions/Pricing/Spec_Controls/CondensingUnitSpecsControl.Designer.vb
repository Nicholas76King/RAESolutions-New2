<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CondensingUnitSpecsControl
   Inherits CommonSpecsControl

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
        Me.lblAltitudeFeet = New System.Windows.Forms.Label()
        Me.lblRefrigerant = New System.Windows.Forms.Label()
        Me.cboRefrigerant = New System.Windows.Forms.ComboBox()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.txtAltitude = New System.Windows.Forms.TextBox()
        Me.lblCapacity2Units = New System.Windows.Forms.Label()
        Me.lblCapacity1Units = New System.Windows.Forms.Label()
        Me.lblEvaporatorTempF = New System.Windows.Forms.Label()
        Me.lblAmbientTempF = New System.Windows.Forms.Label()
        Me.txtAmbientTemp = New System.Windows.Forms.TextBox()
        Me.lblAmbientTemp = New System.Windows.Forms.Label()
        Me.txtSuctionTemp = New System.Windows.Forms.TextBox()
        Me.lblSuctionTemp = New System.Windows.Forms.Label()
        Me.txtCapacity1 = New System.Windows.Forms.TextBox()
        Me.lblCapacity1 = New System.Windows.Forms.Label()
        Me.txtCapacity2 = New System.Windows.Forms.TextBox()
        Me.lblCapacity2 = New System.Windows.Forms.Label()
        Me.lblCapacity4Units = New System.Windows.Forms.Label()
        Me.lblCapacity3Units = New System.Windows.Forms.Label()
        Me.txtCapacity3 = New System.Windows.Forms.TextBox()
        Me.lblCapacity3 = New System.Windows.Forms.Label()
        Me.txtCapacity4 = New System.Windows.Forms.TextBox()
        Me.lblCapacity4 = New System.Windows.Forms.Label()
        Me.chkCompressorWarranty = New System.Windows.Forms.CheckBox()
        Me.condensingUnitTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEvapTemp = New System.Windows.Forms.TextBox()
        Me.lblEvapTemp = New System.Windows.Forms.Label()
        Me.lblEERUnit = New System.Windows.Forms.Label()
        Me.txtEER = New System.Windows.Forms.TextBox()
        Me.lblEER = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblAltitudeFeet
        '
        Me.lblAltitudeFeet.AutoSize = True
        Me.lblAltitudeFeet.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitudeFeet.Location = New System.Drawing.Point(193, 120)
        Me.lblAltitudeFeet.Name = "lblAltitudeFeet"
        Me.lblAltitudeFeet.Size = New System.Drawing.Size(24, 11)
        Me.lblAltitudeFeet.TabIndex = 133
        Me.lblAltitudeFeet.Text = "Feet"
        Me.lblAltitudeFeet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRefrigerant
        '
        Me.lblRefrigerant.Location = New System.Drawing.Point(4, 28)
        Me.lblRefrigerant.Name = "lblRefrigerant"
        Me.lblRefrigerant.Size = New System.Drawing.Size(110, 22)
        Me.lblRefrigerant.TabIndex = 132
        Me.lblRefrigerant.Text = "Refrigerant"
        Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRefrigerant
        '
        Me.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRefrigerant.Items.AddRange(New Object() {"R507", "R22", "R404a", "R134a", "R407a", "R407c", "R407f", "R448a", "R449a"})
        Me.cboRefrigerant.Location = New System.Drawing.Point(120, 28)
        Me.cboRefrigerant.Name = "cboRefrigerant"
        Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cboRefrigerant.TabIndex = 11
        '
        'lblAltitude
        '
        Me.lblAltitude.BackColor = System.Drawing.Color.Transparent
        Me.lblAltitude.Location = New System.Drawing.Point(4, 112)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(110, 22)
        Me.lblAltitude.TabIndex = 131
        Me.lblAltitude.Text = "Altitude"
        Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAltitude
        '
        Me.txtAltitude.Location = New System.Drawing.Point(120, 112)
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(72, 21)
        Me.txtAltitude.TabIndex = 40
        '
        'lblCapacity2Units
        '
        Me.lblCapacity2Units.AutoSize = True
        Me.lblCapacity2Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity2Units.Location = New System.Drawing.Point(473, 65)
        Me.lblCapacity2Units.Name = "lblCapacity2Units"
        Me.lblCapacity2Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity2Units.TabIndex = 130
        Me.lblCapacity2Units.Text = "Tons"
        Me.lblCapacity2Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCapacity1Units
        '
        Me.lblCapacity1Units.AutoSize = True
        Me.lblCapacity1Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity1Units.Location = New System.Drawing.Point(194, 65)
        Me.lblCapacity1Units.Name = "lblCapacity1Units"
        Me.lblCapacity1Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity1Units.TabIndex = 129
        Me.lblCapacity1Units.Text = "Tons"
        Me.lblCapacity1Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEvaporatorTempF
        '
        Me.lblEvaporatorTempF.AutoSize = True
        Me.lblEvaporatorTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporatorTempF.Location = New System.Drawing.Point(474, 9)
        Me.lblEvaporatorTempF.Name = "lblEvaporatorTempF"
        Me.lblEvaporatorTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblEvaporatorTempF.TabIndex = 128
        Me.lblEvaporatorTempF.Text = "ºF"
        Me.lblEvaporatorTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAmbientTempF
        '
        Me.lblAmbientTempF.AutoSize = True
        Me.lblAmbientTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmbientTempF.Location = New System.Drawing.Point(194, 9)
        Me.lblAmbientTempF.Name = "lblAmbientTempF"
        Me.lblAmbientTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblAmbientTempF.TabIndex = 127
        Me.lblAmbientTempF.Text = "ºF"
        Me.lblAmbientTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAmbientTemp
        '
        Me.txtAmbientTemp.Location = New System.Drawing.Point(120, 0)
        Me.txtAmbientTemp.Name = "txtAmbientTemp"
        Me.txtAmbientTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtAmbientTemp.TabIndex = 5
        '
        'lblAmbientTemp
        '
        Me.lblAmbientTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblAmbientTemp.Location = New System.Drawing.Point(4, 0)
        Me.lblAmbientTemp.Name = "lblAmbientTemp"
        Me.lblAmbientTemp.Size = New System.Drawing.Size(110, 22)
        Me.lblAmbientTemp.TabIndex = 117
        Me.lblAmbientTemp.Text = "Ambient temp."
        Me.lblAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condensingUnitTips.SetToolTip(Me.lblAmbientTemp, "Ambient temperature in Fahrenheit")
        '
        'txtSuctionTemp
        '
        Me.txtSuctionTemp.Location = New System.Drawing.Point(400, 0)
        Me.txtSuctionTemp.Name = "txtSuctionTemp"
        Me.txtSuctionTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtSuctionTemp.TabIndex = 10
        '
        'lblSuctionTemp
        '
        Me.lblSuctionTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblSuctionTemp.Location = New System.Drawing.Point(284, 0)
        Me.lblSuctionTemp.Name = "lblSuctionTemp"
        Me.lblSuctionTemp.Size = New System.Drawing.Size(110, 22)
        Me.lblSuctionTemp.TabIndex = 118
        Me.lblSuctionTemp.Text = "Sat. suction temp."
        Me.lblSuctionTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condensingUnitTips.SetToolTip(Me.lblSuctionTemp, "Saturated suction temperature in Fahrenheit")
        '
        'txtCapacity1
        '
        Me.txtCapacity1.BackColor = System.Drawing.SystemColors.Window
        Me.txtCapacity1.Location = New System.Drawing.Point(120, 56)
        Me.txtCapacity1.Name = "txtCapacity1"
        Me.txtCapacity1.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacity1.TabIndex = 15
        '
        'lblCapacity1
        '
        Me.lblCapacity1.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity1.Location = New System.Drawing.Point(4, 56)
        Me.lblCapacity1.Name = "lblCapacity1"
        Me.lblCapacity1.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity1.TabIndex = 119
        Me.lblCapacity1.Text = "Capacity circuit 1"
        Me.lblCapacity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapacity2
        '
        Me.txtCapacity2.Location = New System.Drawing.Point(400, 56)
        Me.txtCapacity2.Name = "txtCapacity2"
        Me.txtCapacity2.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacity2.TabIndex = 20
        '
        'lblCapacity2
        '
        Me.lblCapacity2.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity2.Location = New System.Drawing.Point(284, 56)
        Me.lblCapacity2.Name = "lblCapacity2"
        Me.lblCapacity2.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity2.TabIndex = 120
        Me.lblCapacity2.Text = "Capacity circuit 2"
        Me.lblCapacity2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCapacity4Units
        '
        Me.lblCapacity4Units.AutoSize = True
        Me.lblCapacity4Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity4Units.Location = New System.Drawing.Point(473, 93)
        Me.lblCapacity4Units.Name = "lblCapacity4Units"
        Me.lblCapacity4Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity4Units.TabIndex = 144
        Me.lblCapacity4Units.Text = "Tons"
        Me.lblCapacity4Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCapacity3Units
        '
        Me.lblCapacity3Units.AutoSize = True
        Me.lblCapacity3Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity3Units.Location = New System.Drawing.Point(194, 93)
        Me.lblCapacity3Units.Name = "lblCapacity3Units"
        Me.lblCapacity3Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity3Units.TabIndex = 143
        Me.lblCapacity3Units.Text = "Tons"
        Me.lblCapacity3Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCapacity3
        '
        Me.txtCapacity3.Location = New System.Drawing.Point(120, 83)
        Me.txtCapacity3.Name = "txtCapacity3"
        Me.txtCapacity3.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacity3.TabIndex = 25
        '
        'lblCapacity3
        '
        Me.lblCapacity3.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity3.Location = New System.Drawing.Point(4, 84)
        Me.lblCapacity3.Name = "lblCapacity3"
        Me.lblCapacity3.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity3.TabIndex = 139
        Me.lblCapacity3.Text = "Capacity circuit 3"
        Me.lblCapacity3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapacity4
        '
        Me.txtCapacity4.Location = New System.Drawing.Point(400, 84)
        Me.txtCapacity4.Name = "txtCapacity4"
        Me.txtCapacity4.Size = New System.Drawing.Size(72, 21)
        Me.txtCapacity4.TabIndex = 30
        '
        'lblCapacity4
        '
        Me.lblCapacity4.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity4.Location = New System.Drawing.Point(284, 84)
        Me.lblCapacity4.Name = "lblCapacity4"
        Me.lblCapacity4.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity4.TabIndex = 140
        Me.lblCapacity4.Text = "Capacity circuit 4"
        Me.lblCapacity4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkCompressorWarranty
        '
        Me.chkCompressorWarranty.AutoSize = True
        Me.chkCompressorWarranty.Location = New System.Drawing.Point(269, 114)
        Me.chkCompressorWarranty.Name = "chkCompressorWarranty"
        Me.chkCompressorWarranty.Size = New System.Drawing.Size(211, 17)
        Me.chkCompressorWarranty.TabIndex = 50
        Me.chkCompressorWarranty.Text = "4 year extended compressor warranty"
        Me.chkCompressorWarranty.UseVisualStyleBackColor = True
        Me.chkCompressorWarranty.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(474, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 11)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "ºF"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEvapTemp
        '
        Me.txtEvapTemp.BackColor = System.Drawing.SystemColors.Window
        Me.txtEvapTemp.Location = New System.Drawing.Point(400, 28)
        Me.txtEvapTemp.Name = "txtEvapTemp"
        Me.txtEvapTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtEvapTemp.TabIndex = 12
        '
        'lblEvapTemp
        '
        Me.lblEvapTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblEvapTemp.Location = New System.Drawing.Point(284, 28)
        Me.lblEvapTemp.Name = "lblEvapTemp"
        Me.lblEvapTemp.Size = New System.Drawing.Size(110, 22)
        Me.lblEvapTemp.TabIndex = 146
        Me.lblEvapTemp.Text = "Evap. temp."
        Me.lblEvapTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEERUnit
        '
        Me.lblEERUnit.AutoSize = True
        Me.lblEERUnit.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEERUnit.Location = New System.Drawing.Point(194, 93)
        Me.lblEERUnit.Name = "lblEERUnit"
        Me.lblEERUnit.Size = New System.Drawing.Size(23, 11)
        Me.lblEERUnit.TabIndex = 150
        Me.lblEERUnit.Text = "EER"
        Me.lblEERUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEERUnit.Visible = False
        '
        'txtEER
        '
        Me.txtEER.Location = New System.Drawing.Point(120, 84)
        Me.txtEER.Name = "txtEER"
        Me.txtEER.Size = New System.Drawing.Size(72, 21)
        Me.txtEER.TabIndex = 148
        Me.txtEER.Visible = False
        '
        'lblEER
        '
        Me.lblEER.BackColor = System.Drawing.Color.Transparent
        Me.lblEER.Location = New System.Drawing.Point(4, 84)
        Me.lblEER.Name = "lblEER"
        Me.lblEER.Size = New System.Drawing.Size(110, 22)
        Me.lblEER.TabIndex = 149
        Me.lblEER.Text = "Efficiency"
        Me.lblEER.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblEER.Visible = False
        '
        'CondensingUnitSpecsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblEERUnit)
        Me.Controls.Add(Me.txtEER)
        Me.Controls.Add(Me.lblEER)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEvapTemp)
        Me.Controls.Add(Me.lblEvapTemp)
        Me.Controls.Add(Me.chkCompressorWarranty)
        Me.Controls.Add(Me.lblCapacity4Units)
        Me.Controls.Add(Me.lblCapacity3Units)
        Me.Controls.Add(Me.txtCapacity3)
        Me.Controls.Add(Me.lblCapacity3)
        Me.Controls.Add(Me.txtCapacity4)
        Me.Controls.Add(Me.lblCapacity4)
        Me.Controls.Add(Me.lblAltitudeFeet)
        Me.Controls.Add(Me.lblRefrigerant)
        Me.Controls.Add(Me.cboRefrigerant)
        Me.Controls.Add(Me.lblAltitude)
        Me.Controls.Add(Me.txtAltitude)
        Me.Controls.Add(Me.lblCapacity2Units)
        Me.Controls.Add(Me.lblCapacity1Units)
        Me.Controls.Add(Me.lblEvaporatorTempF)
        Me.Controls.Add(Me.lblAmbientTempF)
        Me.Controls.Add(Me.txtAmbientTemp)
        Me.Controls.Add(Me.lblAmbientTemp)
        Me.Controls.Add(Me.txtSuctionTemp)
        Me.Controls.Add(Me.lblSuctionTemp)
        Me.Controls.Add(Me.txtCapacity1)
        Me.Controls.Add(Me.lblCapacity1)
        Me.Controls.Add(Me.txtCapacity2)
        Me.Controls.Add(Me.lblCapacity2)
        Me.Name = "CondensingUnitSpecsControl"
        Me.Size = New System.Drawing.Size(513, 329)
        Me.Controls.SetChildIndex(Me.lblCapacity2, 0)
        Me.Controls.SetChildIndex(Me.txtCapacity2, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity1, 0)
        Me.Controls.SetChildIndex(Me.txtCapacity1, 0)
        Me.Controls.SetChildIndex(Me.lblSuctionTemp, 0)
        Me.Controls.SetChildIndex(Me.txtSuctionTemp, 0)
        Me.Controls.SetChildIndex(Me.lblAmbientTemp, 0)
        Me.Controls.SetChildIndex(Me.txtAmbientTemp, 0)
        Me.Controls.SetChildIndex(Me.lblAmbientTempF, 0)
        Me.Controls.SetChildIndex(Me.lblEvaporatorTempF, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity1Units, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity2Units, 0)
        Me.Controls.SetChildIndex(Me.txtAltitude, 0)
        Me.Controls.SetChildIndex(Me.lblAltitude, 0)
        Me.Controls.SetChildIndex(Me.cboRefrigerant, 0)
        Me.Controls.SetChildIndex(Me.lblRefrigerant, 0)
        Me.Controls.SetChildIndex(Me.lblAltitudeFeet, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity4, 0)
        Me.Controls.SetChildIndex(Me.txtCapacity4, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity3, 0)
        Me.Controls.SetChildIndex(Me.txtCapacity3, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity3Units, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity4Units, 0)
        Me.Controls.SetChildIndex(Me.chkCompressorWarranty, 0)
        Me.Controls.SetChildIndex(Me.lblEvapTemp, 0)
        Me.Controls.SetChildIndex(Me.txtEvapTemp, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblEER, 0)
        Me.Controls.SetChildIndex(Me.txtEER, 0)
        Me.Controls.SetChildIndex(Me.lblEERUnit, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents lblAltitudeFeet As System.Windows.Forms.Label
   Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
   Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
   Friend WithEvents lblAltitude As System.Windows.Forms.Label
   Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity2Units As System.Windows.Forms.Label
   Friend WithEvents lblCapacity1Units As System.Windows.Forms.Label
   Friend WithEvents lblEvaporatorTempF As System.Windows.Forms.Label
   Friend WithEvents lblAmbientTempF As System.Windows.Forms.Label
   Friend WithEvents txtAmbientTemp As System.Windows.Forms.TextBox
   Friend WithEvents lblAmbientTemp As System.Windows.Forms.Label
   Friend WithEvents txtSuctionTemp As System.Windows.Forms.TextBox
   Friend WithEvents lblSuctionTemp As System.Windows.Forms.Label
   Friend WithEvents txtCapacity1 As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity1 As System.Windows.Forms.Label
   Friend WithEvents txtCapacity2 As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity2 As System.Windows.Forms.Label
   Friend WithEvents lblCapacity4Units As System.Windows.Forms.Label
   Friend WithEvents lblCapacity3Units As System.Windows.Forms.Label
   Friend WithEvents txtCapacity3 As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity3 As System.Windows.Forms.Label
   Friend WithEvents txtCapacity4 As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity4 As System.Windows.Forms.Label
   Friend WithEvents chkCompressorWarranty As System.Windows.Forms.CheckBox
   Friend WithEvents condensingUnitTips As System.Windows.Forms.ToolTip
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtEvapTemp As System.Windows.Forms.TextBox
    Friend WithEvents lblEvapTemp As System.Windows.Forms.Label
    Friend WithEvents lblEERUnit As System.Windows.Forms.Label
    Friend WithEvents txtEER As System.Windows.Forms.TextBox
    Friend WithEvents lblEER As System.Windows.Forms.Label

End Class
