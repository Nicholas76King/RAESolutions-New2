<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CondenserSpecsControl
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
        Me.lblAltitudeFeet = New System.Windows.Forms.Label()
        Me.lblRefrigerant = New System.Windows.Forms.Label()
        Me.cboRefrigerant = New System.Windows.Forms.ComboBox()
        Me.lblAltitude = New System.Windows.Forms.Label()
        Me.txtAltitude = New System.Windows.Forms.TextBox()
        Me.lblAmbientTempF = New System.Windows.Forms.Label()
        Me.txtAmbientTemp = New System.Windows.Forms.TextBox()
        Me.lblAmbientTemp = New System.Windows.Forms.Label()
        Me.lblCapacity4Units = New System.Windows.Forms.Label()
        Me.lblCapacity3Units = New System.Windows.Forms.Label()
        Me.txtTotalHeatRejection3 = New System.Windows.Forms.TextBox()
        Me.lblCapacity3 = New System.Windows.Forms.Label()
        Me.txtTotalHeatRejection4 = New System.Windows.Forms.TextBox()
        Me.lblCapacity4 = New System.Windows.Forms.Label()
        Me.lblCapacity2Units = New System.Windows.Forms.Label()
        Me.lblCapacity1Units = New System.Windows.Forms.Label()
        Me.txtTotalHeatRejection1 = New System.Windows.Forms.TextBox()
        Me.lblCapacity1 = New System.Windows.Forms.Label()
        Me.txtTotalHeatRejection2 = New System.Windows.Forms.TextBox()
        Me.lblTotalHeatRejection2 = New System.Windows.Forms.Label()
        Me.lblCondenserTDUnits = New System.Windows.Forms.Label()
        Me.txtCondenserTD = New System.Windows.Forms.TextBox()
        Me.lblCondenserTD = New System.Windows.Forms.Label()
        Me.lblFinsPerInch = New System.Windows.Forms.Label()
        Me.cboFinsPerInch = New System.Windows.Forms.ComboBox()
        Me.chkSubCooling = New System.Windows.Forms.CheckBox()
        Me.condenserTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'lblAltitudeFeet
        '
        Me.lblAltitudeFeet.AutoSize = True
        Me.lblAltitudeFeet.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltitudeFeet.Location = New System.Drawing.Point(473, 91)
        Me.lblAltitudeFeet.Name = "lblAltitudeFeet"
        Me.lblAltitudeFeet.Size = New System.Drawing.Size(24, 11)
        Me.lblAltitudeFeet.TabIndex = 174
        Me.lblAltitudeFeet.Text = "Feet"
        Me.lblAltitudeFeet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRefrigerant
        '
        Me.lblRefrigerant.Location = New System.Drawing.Point(3, 82)
        Me.lblRefrigerant.Name = "lblRefrigerant"
        Me.lblRefrigerant.Size = New System.Drawing.Size(110, 22)
        Me.lblRefrigerant.TabIndex = 173
        Me.lblRefrigerant.Text = "Refrigerant"
        Me.lblRefrigerant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRefrigerant
        '
        Me.cboRefrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRefrigerant.Items.AddRange(New Object() {"R22", "R404a", "R507", "R134a", "R407c", "R410a"})
        Me.cboRefrigerant.Location = New System.Drawing.Point(119, 82)
        Me.cboRefrigerant.Name = "cboRefrigerant"
        Me.cboRefrigerant.Size = New System.Drawing.Size(72, 21)
        Me.cboRefrigerant.TabIndex = 35
        '
        'lblAltitude
        '
        Me.lblAltitude.BackColor = System.Drawing.Color.Transparent
        Me.lblAltitude.Location = New System.Drawing.Point(283, 82)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(110, 22)
        Me.lblAltitude.TabIndex = 172
        Me.lblAltitude.Text = "Altitude"
        Me.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAltitude
        '
        Me.txtAltitude.Location = New System.Drawing.Point(399, 82)
        Me.txtAltitude.Name = "txtAltitude"
        Me.txtAltitude.Size = New System.Drawing.Size(72, 21)
        Me.txtAltitude.TabIndex = 55
        '
        'lblAmbientTempF
        '
        Me.lblAmbientTempF.AutoSize = True
        Me.lblAmbientTempF.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmbientTempF.Location = New System.Drawing.Point(193, 9)
        Me.lblAmbientTempF.Name = "lblAmbientTempF"
        Me.lblAmbientTempF.Size = New System.Drawing.Size(15, 11)
        Me.lblAmbientTempF.TabIndex = 171
        Me.lblAmbientTempF.Text = "ºF"
        Me.lblAmbientTempF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAmbientTemp
        '
        Me.txtAmbientTemp.Location = New System.Drawing.Point(119, 0)
        Me.txtAmbientTemp.Name = "txtAmbientTemp"
        Me.txtAmbientTemp.Size = New System.Drawing.Size(72, 21)
        Me.txtAmbientTemp.TabIndex = 5
        '
        'lblAmbientTemp
        '
        Me.lblAmbientTemp.BackColor = System.Drawing.Color.Transparent
        Me.lblAmbientTemp.Location = New System.Drawing.Point(3, 0)
        Me.lblAmbientTemp.Name = "lblAmbientTemp"
        Me.lblAmbientTemp.Size = New System.Drawing.Size(110, 22)
        Me.lblAmbientTemp.TabIndex = 168
        Me.lblAmbientTemp.Text = "Ambient temp."
        Me.lblAmbientTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condenserTips.SetToolTip(Me.lblAmbientTemp, "Ambient temperature in Fahrenheit")
        '
        'lblCapacity4Units
        '
        Me.lblCapacity4Units.AutoSize = True
        Me.lblCapacity4Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity4Units.Location = New System.Drawing.Point(473, 64)
        Me.lblCapacity4Units.Name = "lblCapacity4Units"
        Me.lblCapacity4Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity4Units.TabIndex = 186
        Me.lblCapacity4Units.Text = "Tons"
        Me.lblCapacity4Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCapacity3Units
        '
        Me.lblCapacity3Units.AutoSize = True
        Me.lblCapacity3Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity3Units.Location = New System.Drawing.Point(193, 64)
        Me.lblCapacity3Units.Name = "lblCapacity3Units"
        Me.lblCapacity3Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity3Units.TabIndex = 185
        Me.lblCapacity3Units.Text = "Tons"
        Me.lblCapacity3Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalHeatRejection3
        '
        Me.txtTotalHeatRejection3.Location = New System.Drawing.Point(119, 55)
        Me.txtTotalHeatRejection3.Name = "txtTotalHeatRejection3"
        Me.txtTotalHeatRejection3.Size = New System.Drawing.Size(72, 21)
        Me.txtTotalHeatRejection3.TabIndex = 25
        '
        'lblCapacity3
        '
        Me.lblCapacity3.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity3.Location = New System.Drawing.Point(3, 55)
        Me.lblCapacity3.Name = "lblCapacity3"
        Me.lblCapacity3.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity3.TabIndex = 181
        Me.lblCapacity3.Text = "THR circuit 3"
        Me.lblCapacity3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condenserTips.SetToolTip(Me.lblCapacity3, "Total heat rejection of circuit 3")
        '
        'txtTotalHeatRejection4
        '
        Me.txtTotalHeatRejection4.Location = New System.Drawing.Point(399, 55)
        Me.txtTotalHeatRejection4.Name = "txtTotalHeatRejection4"
        Me.txtTotalHeatRejection4.Size = New System.Drawing.Size(72, 21)
        Me.txtTotalHeatRejection4.TabIndex = 30
        '
        'lblCapacity4
        '
        Me.lblCapacity4.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity4.Location = New System.Drawing.Point(283, 55)
        Me.lblCapacity4.Name = "lblCapacity4"
        Me.lblCapacity4.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity4.TabIndex = 182
        Me.lblCapacity4.Text = "THR circuit 4"
        Me.lblCapacity4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condenserTips.SetToolTip(Me.lblCapacity4, "Total heat rejection of circuit 4")
        '
        'lblCapacity2Units
        '
        Me.lblCapacity2Units.AutoSize = True
        Me.lblCapacity2Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity2Units.Location = New System.Drawing.Point(473, 36)
        Me.lblCapacity2Units.Name = "lblCapacity2Units"
        Me.lblCapacity2Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity2Units.TabIndex = 180
        Me.lblCapacity2Units.Text = "Tons"
        Me.lblCapacity2Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCapacity1Units
        '
        Me.lblCapacity1Units.AutoSize = True
        Me.lblCapacity1Units.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity1Units.Location = New System.Drawing.Point(193, 36)
        Me.lblCapacity1Units.Name = "lblCapacity1Units"
        Me.lblCapacity1Units.Size = New System.Drawing.Size(25, 11)
        Me.lblCapacity1Units.TabIndex = 179
        Me.lblCapacity1Units.Text = "Tons"
        Me.lblCapacity1Units.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalHeatRejection1
        '
        Me.txtTotalHeatRejection1.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotalHeatRejection1.Location = New System.Drawing.Point(119, 27)
        Me.txtTotalHeatRejection1.Name = "txtTotalHeatRejection1"
        Me.txtTotalHeatRejection1.Size = New System.Drawing.Size(72, 21)
        Me.txtTotalHeatRejection1.TabIndex = 15
        '
        'lblCapacity1
        '
        Me.lblCapacity1.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacity1.Location = New System.Drawing.Point(3, 27)
        Me.lblCapacity1.Name = "lblCapacity1"
        Me.lblCapacity1.Size = New System.Drawing.Size(110, 22)
        Me.lblCapacity1.TabIndex = 177
        Me.lblCapacity1.Text = "THR circuit 1"
        Me.lblCapacity1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condenserTips.SetToolTip(Me.lblCapacity1, "Total heat rejection for circuit 1")
        '
        'txtTotalHeatRejection2
        '
        Me.txtTotalHeatRejection2.Location = New System.Drawing.Point(399, 27)
        Me.txtTotalHeatRejection2.Name = "txtTotalHeatRejection2"
        Me.txtTotalHeatRejection2.Size = New System.Drawing.Size(72, 21)
        Me.txtTotalHeatRejection2.TabIndex = 20
        '
        'lblTotalHeatRejection2
        '
        Me.lblTotalHeatRejection2.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalHeatRejection2.Location = New System.Drawing.Point(283, 27)
        Me.lblTotalHeatRejection2.Name = "lblTotalHeatRejection2"
        Me.lblTotalHeatRejection2.Size = New System.Drawing.Size(110, 22)
        Me.lblTotalHeatRejection2.TabIndex = 178
        Me.lblTotalHeatRejection2.Text = "THR circuit 2"
        Me.lblTotalHeatRejection2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condenserTips.SetToolTip(Me.lblTotalHeatRejection2, "Total heat rejection for circuit 2")
        '
        'lblCondenserTDUnits
        '
        Me.lblCondenserTDUnits.AutoSize = True
        Me.lblCondenserTDUnits.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondenserTDUnits.Location = New System.Drawing.Point(473, 9)
        Me.lblCondenserTDUnits.Name = "lblCondenserTDUnits"
        Me.lblCondenserTDUnits.Size = New System.Drawing.Size(15, 11)
        Me.lblCondenserTDUnits.TabIndex = 189
        Me.lblCondenserTDUnits.Text = "ºF"
        Me.lblCondenserTDUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCondenserTD
        '
        Me.txtCondenserTD.Location = New System.Drawing.Point(399, 0)
        Me.txtCondenserTD.Name = "txtCondenserTD"
        Me.txtCondenserTD.Size = New System.Drawing.Size(72, 21)
        Me.txtCondenserTD.TabIndex = 10
        '
        'lblCondenserTD
        '
        Me.lblCondenserTD.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCondenserTD.BackColor = System.Drawing.Color.Transparent
        Me.lblCondenserTD.Location = New System.Drawing.Point(283, 0)
        Me.lblCondenserTD.Name = "lblCondenserTD"
        Me.lblCondenserTD.Size = New System.Drawing.Size(110, 22)
        Me.lblCondenserTD.TabIndex = 188
        Me.lblCondenserTD.Text = "TD"
        Me.lblCondenserTD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.condenserTips.SetToolTip(Me.lblCondenserTD, "Temperature difference in Fahrenheit")
        '
        'lblFinsPerInch
        '
        Me.lblFinsPerInch.Location = New System.Drawing.Point(3, 109)
        Me.lblFinsPerInch.Name = "lblFinsPerInch"
        Me.lblFinsPerInch.Size = New System.Drawing.Size(110, 22)
        Me.lblFinsPerInch.TabIndex = 191
        Me.lblFinsPerInch.Text = "Fins per inch"
        Me.lblFinsPerInch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFinsPerInch
        '
        Me.cboFinsPerInch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFinsPerInch.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14"})
        Me.cboFinsPerInch.Location = New System.Drawing.Point(119, 109)
        Me.cboFinsPerInch.Name = "cboFinsPerInch"
        Me.cboFinsPerInch.Size = New System.Drawing.Size(72, 21)
        Me.cboFinsPerInch.TabIndex = 45
        '
        'chkSubCooling
        '
        Me.chkSubCooling.AutoSize = True
        Me.chkSubCooling.Location = New System.Drawing.Point(399, 111)
        Me.chkSubCooling.Name = "chkSubCooling"
        Me.chkSubCooling.Size = New System.Drawing.Size(80, 17)
        Me.chkSubCooling.TabIndex = 50
        Me.chkSubCooling.Text = "Sub cooling"
        Me.chkSubCooling.UseVisualStyleBackColor = True
        '
        'CondenserSpecsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.chkSubCooling)
        Me.Controls.Add(Me.lblFinsPerInch)
        Me.Controls.Add(Me.cboFinsPerInch)
        Me.Controls.Add(Me.lblCondenserTDUnits)
        Me.Controls.Add(Me.txtCondenserTD)
        Me.Controls.Add(Me.lblCondenserTD)
        Me.Controls.Add(Me.lblCapacity4Units)
        Me.Controls.Add(Me.lblCapacity3Units)
        Me.Controls.Add(Me.txtTotalHeatRejection3)
        Me.Controls.Add(Me.lblCapacity3)
        Me.Controls.Add(Me.txtTotalHeatRejection4)
        Me.Controls.Add(Me.lblCapacity4)
        Me.Controls.Add(Me.lblCapacity2Units)
        Me.Controls.Add(Me.lblCapacity1Units)
        Me.Controls.Add(Me.txtTotalHeatRejection1)
        Me.Controls.Add(Me.lblCapacity1)
        Me.Controls.Add(Me.txtTotalHeatRejection2)
        Me.Controls.Add(Me.lblTotalHeatRejection2)
        Me.Controls.Add(Me.lblAltitudeFeet)
        Me.Controls.Add(Me.lblRefrigerant)
        Me.Controls.Add(Me.cboRefrigerant)
        Me.Controls.Add(Me.lblAltitude)
        Me.Controls.Add(Me.txtAltitude)
        Me.Controls.Add(Me.lblAmbientTempF)
        Me.Controls.Add(Me.txtAmbientTemp)
        Me.Controls.Add(Me.lblAmbientTemp)
        Me.Name = "CondenserSpecsControl"
        Me.Size = New System.Drawing.Size(513, 323)
        Me.Controls.SetChildIndex(Me.lblAmbientTemp, 0)
        Me.Controls.SetChildIndex(Me.txtAmbientTemp, 0)
        Me.Controls.SetChildIndex(Me.lblAmbientTempF, 0)
        Me.Controls.SetChildIndex(Me.txtAltitude, 0)
        Me.Controls.SetChildIndex(Me.lblAltitude, 0)
        Me.Controls.SetChildIndex(Me.cboRefrigerant, 0)
        Me.Controls.SetChildIndex(Me.lblRefrigerant, 0)
        Me.Controls.SetChildIndex(Me.lblAltitudeFeet, 0)
        Me.Controls.SetChildIndex(Me.lblTotalHeatRejection2, 0)
        Me.Controls.SetChildIndex(Me.txtTotalHeatRejection2, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity1, 0)
        Me.Controls.SetChildIndex(Me.txtTotalHeatRejection1, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity1Units, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity2Units, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity4, 0)
        Me.Controls.SetChildIndex(Me.txtTotalHeatRejection4, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity3, 0)
        Me.Controls.SetChildIndex(Me.txtTotalHeatRejection3, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity3Units, 0)
        Me.Controls.SetChildIndex(Me.lblCapacity4Units, 0)
        Me.Controls.SetChildIndex(Me.lblCondenserTD, 0)
        Me.Controls.SetChildIndex(Me.txtCondenserTD, 0)
        Me.Controls.SetChildIndex(Me.lblCondenserTDUnits, 0)
        Me.Controls.SetChildIndex(Me.cboFinsPerInch, 0)
        Me.Controls.SetChildIndex(Me.lblFinsPerInch, 0)
        Me.Controls.SetChildIndex(Me.chkSubCooling, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents lblAltitudeFeet As System.Windows.Forms.Label
   Friend WithEvents lblRefrigerant As System.Windows.Forms.Label
   Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
   Friend WithEvents lblAltitude As System.Windows.Forms.Label
   Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
   Friend WithEvents lblAmbientTempF As System.Windows.Forms.Label
   Friend WithEvents txtAmbientTemp As System.Windows.Forms.TextBox
   Friend WithEvents lblAmbientTemp As System.Windows.Forms.Label
   Friend WithEvents lblCapacity4Units As System.Windows.Forms.Label
   Friend WithEvents lblCapacity3Units As System.Windows.Forms.Label
   Friend WithEvents txtTotalHeatRejection3 As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity3 As System.Windows.Forms.Label
   Friend WithEvents txtTotalHeatRejection4 As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity4 As System.Windows.Forms.Label
   Friend WithEvents lblCapacity2Units As System.Windows.Forms.Label
   Friend WithEvents lblCapacity1Units As System.Windows.Forms.Label
   Friend WithEvents txtTotalHeatRejection1 As System.Windows.Forms.TextBox
   Friend WithEvents lblCapacity1 As System.Windows.Forms.Label
   Friend WithEvents txtTotalHeatRejection2 As System.Windows.Forms.TextBox
   Friend WithEvents lblTotalHeatRejection2 As System.Windows.Forms.Label
   Friend WithEvents lblCondenserTDUnits As System.Windows.Forms.Label
   Friend WithEvents txtCondenserTD As System.Windows.Forms.TextBox
   Friend WithEvents lblCondenserTD As System.Windows.Forms.Label
   Friend WithEvents lblFinsPerInch As System.Windows.Forms.Label
   Friend WithEvents cboFinsPerInch As System.Windows.Forms.ComboBox
   Friend WithEvents chkSubCooling As System.Windows.Forms.CheckBox
   Friend WithEvents condenserTips As System.Windows.Forms.ToolTip

End Class
