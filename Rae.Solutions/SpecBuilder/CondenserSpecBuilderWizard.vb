Namespace SpecBuilder

   Public Class CondenserSpecBuilderWizard
      Inherits RaeSolutions.SpecBuilder.SpecBuilderWizardBase


#Region " Windows Form Designer generated code "

      Public Sub New()
         MyBase.New()

         'This call is required by the Windows Form Designer.
         InitializeComponent()

         'Add any initialization after the InitializeComponent() call

      End Sub

      'Form overrides dispose to clean up the component list.
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not (components Is Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

      'Required by the Windows Form Designer
      Private components As System.ComponentModel.IContainer

      'NOTE: The following procedure is required by the Windows Form Designer
      'It can be modified using the Windows Form Designer.  
      'Do not modify it using the code editor.
      Friend WithEvents lblCondenserLabel As System.Windows.Forms.Label
      Friend WithEvents cboCondenser As System.Windows.Forms.ComboBox
      Friend WithEvents lblFinMaterialLabel As System.Windows.Forms.Label
      Friend WithEvents lblCasingsAndTubeSheetsLabel As System.Windows.Forms.Label
      Friend WithEvents cboDesign As System.Windows.Forms.ComboBox
      Friend WithEvents cboFinMaterial As System.Windows.Forms.ComboBox
      Friend WithEvents cboCasingsAndTubeSheets As System.Windows.Forms.ComboBox
      Friend WithEvents cboTubeThickness As System.Windows.Forms.ComboBox
      Friend WithEvents lblDesignLabel As System.Windows.Forms.Label
      Friend WithEvents lblTubeThicknessLabel As System.Windows.Forms.Label
      Friend WithEvents cboFinThickness As System.Windows.Forms.ComboBox
      Friend WithEvents lblFinThicknessLabel As System.Windows.Forms.Label
      Friend WithEvents lblCondenserTypeLabel As System.Windows.Forms.Label
      Friend WithEvents cboCondenserType As System.Windows.Forms.ComboBox
      Friend WithEvents cboDischarge As System.Windows.Forms.ComboBox
      Friend WithEvents chkRainHood As System.Windows.Forms.CheckBox
      Friend WithEvents panAirCooled As System.Windows.Forms.Panel
      Friend WithEvents lblSubCoolingCircuitLabel As System.Windows.Forms.Label
      Friend WithEvents lblMotorLabel As System.Windows.Forms.Label
      Friend WithEvents lblLowAmbientLabel As System.Windows.Forms.Label
      Friend WithEvents radSubCoolingCircuitYes As System.Windows.Forms.RadioButton
      Friend WithEvents radSubCoolingCircuitNo As System.Windows.Forms.RadioButton
      Friend WithEvents cboMotor As System.Windows.Forms.ComboBox
      Friend WithEvents cboLowAmbient As System.Windows.Forms.ComboBox
      Friend WithEvents cboAmbient As System.Windows.Forms.ComboBox
      Friend WithEvents chkFloodedCondenserControl As System.Windows.Forms.CheckBox
      Friend WithEvents panWaterCooled As System.Windows.Forms.Panel
      Friend WithEvents lblWaterValvesLabel As System.Windows.Forms.Label
      Friend WithEvents lblHeatExchangerLabel As System.Windows.Forms.Label
      Friend WithEvents radWaterValvesYes As System.Windows.Forms.RadioButton
      Friend WithEvents radWaterValvesNo As System.Windows.Forms.RadioButton
      Friend WithEvents lblFactoryMounted As System.Windows.Forms.Label
      Friend WithEvents cboHeatExchanger As System.Windows.Forms.ComboBox
      Friend WithEvents panEvaporativeCooled As System.Windows.Forms.Panel
      Friend WithEvents lblMaterialLabel As System.Windows.Forms.Label
      Friend WithEvents lblAcousticAttenuatorsLabel As System.Windows.Forms.Label
      Friend WithEvents lblCoilLabel As System.Windows.Forms.Label
      Friend WithEvents lblHeadPressureLabel As System.Windows.Forms.Label
      Friend WithEvents cboMaterial As System.Windows.Forms.ComboBox
      Friend WithEvents cboHeadPressure As System.Windows.Forms.ComboBox
      Friend WithEvents cboCoil As System.Windows.Forms.ComboBox
      Friend WithEvents chkAcousticAttenuatorsIntake As System.Windows.Forms.CheckBox
      Friend WithEvents chkAcousticAttenuatorsDischarge As System.Windows.Forms.CheckBox
      Friend WithEvents chkHeatedAndInsulatedReceivers As System.Windows.Forms.CheckBox
      Friend WithEvents lblDischargeLabel As System.Windows.Forms.Label
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblCondenserLabel = New System.Windows.Forms.Label
         Me.lblDesignLabel = New System.Windows.Forms.Label
         Me.lblFinMaterialLabel = New System.Windows.Forms.Label
         Me.lblCasingsAndTubeSheetsLabel = New System.Windows.Forms.Label
         Me.lblTubeThicknessLabel = New System.Windows.Forms.Label
         Me.cboCondenser = New System.Windows.Forms.ComboBox
         Me.cboDesign = New System.Windows.Forms.ComboBox
         Me.cboFinMaterial = New System.Windows.Forms.ComboBox
         Me.cboCasingsAndTubeSheets = New System.Windows.Forms.ComboBox
         Me.cboTubeThickness = New System.Windows.Forms.ComboBox
         Me.cboFinThickness = New System.Windows.Forms.ComboBox
         Me.lblFinThicknessLabel = New System.Windows.Forms.Label
         Me.lblCondenserTypeLabel = New System.Windows.Forms.Label
         Me.cboCondenserType = New System.Windows.Forms.ComboBox
         Me.lblDischargeLabel = New System.Windows.Forms.Label
         Me.cboDischarge = New System.Windows.Forms.ComboBox
         Me.chkRainHood = New System.Windows.Forms.CheckBox
         Me.panAirCooled = New System.Windows.Forms.Panel
         Me.chkHeatedAndInsulatedReceivers = New System.Windows.Forms.CheckBox
         Me.chkFloodedCondenserControl = New System.Windows.Forms.CheckBox
         Me.cboAmbient = New System.Windows.Forms.ComboBox
         Me.cboLowAmbient = New System.Windows.Forms.ComboBox
         Me.cboMotor = New System.Windows.Forms.ComboBox
         Me.radSubCoolingCircuitNo = New System.Windows.Forms.RadioButton
         Me.radSubCoolingCircuitYes = New System.Windows.Forms.RadioButton
         Me.lblLowAmbientLabel = New System.Windows.Forms.Label
         Me.lblMotorLabel = New System.Windows.Forms.Label
         Me.lblSubCoolingCircuitLabel = New System.Windows.Forms.Label
         Me.panWaterCooled = New System.Windows.Forms.Panel
         Me.cboHeatExchanger = New System.Windows.Forms.ComboBox
         Me.lblFactoryMounted = New System.Windows.Forms.Label
         Me.radWaterValvesNo = New System.Windows.Forms.RadioButton
         Me.radWaterValvesYes = New System.Windows.Forms.RadioButton
         Me.lblHeatExchangerLabel = New System.Windows.Forms.Label
         Me.lblWaterValvesLabel = New System.Windows.Forms.Label
         Me.panEvaporativeCooled = New System.Windows.Forms.Panel
         Me.chkAcousticAttenuatorsDischarge = New System.Windows.Forms.CheckBox
         Me.chkAcousticAttenuatorsIntake = New System.Windows.Forms.CheckBox
         Me.cboCoil = New System.Windows.Forms.ComboBox
         Me.cboHeadPressure = New System.Windows.Forms.ComboBox
         Me.cboMaterial = New System.Windows.Forms.ComboBox
         Me.lblHeadPressureLabel = New System.Windows.Forms.Label
         Me.lblCoilLabel = New System.Windows.Forms.Label
         Me.lblAcousticAttenuatorsLabel = New System.Windows.Forms.Label
         Me.lblMaterialLabel = New System.Windows.Forms.Label
         Me.panMain.SuspendLayout()
         Me.panAirCooled.SuspendLayout()
         Me.panWaterCooled.SuspendLayout()
         Me.panEvaporativeCooled.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.AutoScroll = True
         Me.panMain.Controls.Add(Me.panEvaporativeCooled)
         Me.panMain.Controls.Add(Me.panAirCooled)
         Me.panMain.Controls.Add(Me.panWaterCooled)
         Me.panMain.Controls.Add(Me.cboCondenser)
         Me.panMain.Controls.Add(Me.lblCondenserLabel)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.lblCondenserLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboCondenser, 0)
         Me.panMain.Controls.SetChildIndex(Me.panWaterCooled, 0)
         Me.panMain.Controls.SetChildIndex(Me.panAirCooled, 0)
         Me.panMain.Controls.SetChildIndex(Me.panEvaporativeCooled, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblCondenserLabel
         '
         Me.lblCondenserLabel.Location = New System.Drawing.Point(36, 20)
         Me.lblCondenserLabel.Name = "lblCondenserLabel"
         Me.lblCondenserLabel.Size = New System.Drawing.Size(180, 23)
         Me.lblCondenserLabel.TabIndex = 2
         Me.lblCondenserLabel.Text = "Condenser"
         Me.lblCondenserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblDesignLabel
         '
         Me.lblDesignLabel.Location = New System.Drawing.Point(12, 4)
         Me.lblDesignLabel.Name = "lblDesignLabel"
         Me.lblDesignLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblDesignLabel.TabIndex = 3
         Me.lblDesignLabel.Text = "Condenser design"
         Me.lblDesignLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblFinMaterialLabel
         '
         Me.lblFinMaterialLabel.Location = New System.Drawing.Point(12, 32)
         Me.lblFinMaterialLabel.Name = "lblFinMaterialLabel"
         Me.lblFinMaterialLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblFinMaterialLabel.TabIndex = 4
         Me.lblFinMaterialLabel.Text = "Fin material"
         Me.lblFinMaterialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCasingsAndTubeSheetsLabel
         '
         Me.lblCasingsAndTubeSheetsLabel.Location = New System.Drawing.Point(12, 60)
         Me.lblCasingsAndTubeSheetsLabel.Name = "lblCasingsAndTubeSheetsLabel"
         Me.lblCasingsAndTubeSheetsLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblCasingsAndTubeSheetsLabel.TabIndex = 5
         Me.lblCasingsAndTubeSheetsLabel.Text = "Casings and tube sheets"
         Me.lblCasingsAndTubeSheetsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblTubeThicknessLabel
         '
         Me.lblTubeThicknessLabel.Location = New System.Drawing.Point(12, 88)
         Me.lblTubeThicknessLabel.Name = "lblTubeThicknessLabel"
         Me.lblTubeThicknessLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblTubeThicknessLabel.TabIndex = 6
         Me.lblTubeThicknessLabel.Text = "Tube thickness"
         Me.lblTubeThicknessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboCondenser
         '
         Me.cboCondenser.Items.AddRange(New Object() {"Air-cooled", "Water-cooled", "Evaporative-cooled"})
         Me.cboCondenser.Location = New System.Drawing.Point(232, 20)
         Me.cboCondenser.Name = "cboCondenser"
         Me.cboCondenser.Size = New System.Drawing.Size(200, 21)
         Me.cboCondenser.TabIndex = 7
         Me.cboCondenser.Text = "Air-cooled"
         '
         'cboDesign
         '
         Me.cboDesign.Items.AddRange(New Object() {"Packaged system", "Remote condenser"})
         Me.cboDesign.Location = New System.Drawing.Point(176, 4)
         Me.cboDesign.Name = "cboDesign"
         Me.cboDesign.Size = New System.Drawing.Size(204, 21)
         Me.cboDesign.TabIndex = 8
         Me.cboDesign.Text = "Packaged system"
         '
         'cboFinMaterial
         '
         Me.cboFinMaterial.Items.AddRange(New Object() {"aluminum", "copper", "phenolic coated", "electro-fin", "acrylic coated"})
         Me.cboFinMaterial.Location = New System.Drawing.Point(176, 32)
         Me.cboFinMaterial.Name = "cboFinMaterial"
         Me.cboFinMaterial.Size = New System.Drawing.Size(204, 21)
         Me.cboFinMaterial.TabIndex = 9
         Me.cboFinMaterial.Text = "aluminum"
         '
         'cboCasingsAndTubeSheets
         '
         Me.cboCasingsAndTubeSheets.Items.AddRange(New Object() {"galvanized steel", "304 stainless steel"})
         Me.cboCasingsAndTubeSheets.Location = New System.Drawing.Point(176, 60)
         Me.cboCasingsAndTubeSheets.Name = "cboCasingsAndTubeSheets"
         Me.cboCasingsAndTubeSheets.Size = New System.Drawing.Size(204, 21)
         Me.cboCasingsAndTubeSheets.TabIndex = 10
         Me.cboCasingsAndTubeSheets.Text = "galvanized steel"
         '
         'cboTubeThickness
         '
         Me.cboTubeThickness.Items.AddRange(New Object() {"0.017""", "0.025""", "0.035"""})
         Me.cboTubeThickness.Location = New System.Drawing.Point(176, 88)
         Me.cboTubeThickness.Name = "cboTubeThickness"
         Me.cboTubeThickness.Size = New System.Drawing.Size(204, 21)
         Me.cboTubeThickness.TabIndex = 11
         Me.cboTubeThickness.Text = "0.017"""
         '
         'cboFinThickness
         '
         Me.cboFinThickness.Items.AddRange(New Object() {"0.006""", "0.008""", "0.010"""})
         Me.cboFinThickness.Location = New System.Drawing.Point(176, 116)
         Me.cboFinThickness.Name = "cboFinThickness"
         Me.cboFinThickness.Size = New System.Drawing.Size(204, 21)
         Me.cboFinThickness.TabIndex = 12
         Me.cboFinThickness.Text = "0.006"""
         '
         'lblFinThicknessLabel
         '
         Me.lblFinThicknessLabel.Location = New System.Drawing.Point(12, 116)
         Me.lblFinThicknessLabel.Name = "lblFinThicknessLabel"
         Me.lblFinThicknessLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblFinThicknessLabel.TabIndex = 13
         Me.lblFinThicknessLabel.Text = "Fin thickness"
         Me.lblFinThicknessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCondenserTypeLabel
         '
         Me.lblCondenserTypeLabel.Location = New System.Drawing.Point(12, 144)
         Me.lblCondenserTypeLabel.Name = "lblCondenserTypeLabel"
         Me.lblCondenserTypeLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblCondenserTypeLabel.TabIndex = 14
         Me.lblCondenserTypeLabel.Text = "Condenser type"
         Me.lblCondenserTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboCondenserType
         '
         Me.cboCondenserType.Items.AddRange(New Object() {"Prop fans", "Centrifugal blowers"})
         Me.cboCondenserType.Location = New System.Drawing.Point(176, 144)
         Me.cboCondenserType.Name = "cboCondenserType"
         Me.cboCondenserType.Size = New System.Drawing.Size(204, 21)
         Me.cboCondenserType.TabIndex = 15
         Me.cboCondenserType.Text = "Prop fans"
         '
         'lblDischargeLabel
         '
         Me.lblDischargeLabel.Location = New System.Drawing.Point(12, 172)
         Me.lblDischargeLabel.Name = "lblDischargeLabel"
         Me.lblDischargeLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblDischargeLabel.TabIndex = 16
         Me.lblDischargeLabel.Text = "Discharge"
         Me.lblDischargeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboDischarge
         '
         Me.cboDischarge.Items.AddRange(New Object() {"horizontal", "vertical"})
         Me.cboDischarge.Location = New System.Drawing.Point(176, 172)
         Me.cboDischarge.Name = "cboDischarge"
         Me.cboDischarge.Size = New System.Drawing.Size(204, 21)
         Me.cboDischarge.TabIndex = 17
         Me.cboDischarge.Text = "horizontal"
         '
         'chkRainHood
         '
         Me.chkRainHood.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkRainHood.Location = New System.Drawing.Point(388, 172)
         Me.chkRainHood.Name = "chkRainHood"
         Me.chkRainHood.Size = New System.Drawing.Size(76, 24)
         Me.chkRainHood.TabIndex = 18
         Me.chkRainHood.Text = "rain hood"
         '
         'panAirCooled
         '
         Me.panAirCooled.Controls.Add(Me.chkHeatedAndInsulatedReceivers)
         Me.panAirCooled.Controls.Add(Me.chkFloodedCondenserControl)
         Me.panAirCooled.Controls.Add(Me.cboAmbient)
         Me.panAirCooled.Controls.Add(Me.cboLowAmbient)
         Me.panAirCooled.Controls.Add(Me.cboMotor)
         Me.panAirCooled.Controls.Add(Me.radSubCoolingCircuitNo)
         Me.panAirCooled.Controls.Add(Me.radSubCoolingCircuitYes)
         Me.panAirCooled.Controls.Add(Me.lblLowAmbientLabel)
         Me.panAirCooled.Controls.Add(Me.lblMotorLabel)
         Me.panAirCooled.Controls.Add(Me.lblSubCoolingCircuitLabel)
         Me.panAirCooled.Controls.Add(Me.cboFinMaterial)
         Me.panAirCooled.Controls.Add(Me.cboCasingsAndTubeSheets)
         Me.panAirCooled.Controls.Add(Me.lblCasingsAndTubeSheetsLabel)
         Me.panAirCooled.Controls.Add(Me.cboCondenserType)
         Me.panAirCooled.Controls.Add(Me.cboTubeThickness)
         Me.panAirCooled.Controls.Add(Me.cboFinThickness)
         Me.panAirCooled.Controls.Add(Me.lblFinThicknessLabel)
         Me.panAirCooled.Controls.Add(Me.lblCondenserTypeLabel)
         Me.panAirCooled.Controls.Add(Me.cboDischarge)
         Me.panAirCooled.Controls.Add(Me.lblDischargeLabel)
         Me.panAirCooled.Controls.Add(Me.lblDesignLabel)
         Me.panAirCooled.Controls.Add(Me.lblTubeThicknessLabel)
         Me.panAirCooled.Controls.Add(Me.cboDesign)
         Me.panAirCooled.Controls.Add(Me.lblFinMaterialLabel)
         Me.panAirCooled.Controls.Add(Me.chkRainHood)
         Me.panAirCooled.Location = New System.Drawing.Point(56, 44)
         Me.panAirCooled.Name = "panAirCooled"
         Me.panAirCooled.Size = New System.Drawing.Size(472, 336)
         Me.panAirCooled.TabIndex = 19
         '
         'chkHeatedAndInsulatedReceivers
         '
         Me.chkHeatedAndInsulatedReceivers.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkHeatedAndInsulatedReceivers.Location = New System.Drawing.Point(176, 308)
         Me.chkHeatedAndInsulatedReceivers.Name = "chkHeatedAndInsulatedReceivers"
         Me.chkHeatedAndInsulatedReceivers.Size = New System.Drawing.Size(216, 24)
         Me.chkHeatedAndInsulatedReceivers.TabIndex = 28
         Me.chkHeatedAndInsulatedReceivers.Text = "Heated and insulated receivers"
         '
         'chkFloodedCondenserControl
         '
         Me.chkFloodedCondenserControl.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkFloodedCondenserControl.Location = New System.Drawing.Point(176, 284)
         Me.chkFloodedCondenserControl.Name = "chkFloodedCondenserControl"
         Me.chkFloodedCondenserControl.Size = New System.Drawing.Size(216, 24)
         Me.chkFloodedCondenserControl.TabIndex = 27
         Me.chkFloodedCondenserControl.Text = "Flooded condenser control"
         '
         'cboAmbient
         '
         Me.cboAmbient.Items.AddRange(New Object() {"20 F", "0 F"})
         Me.cboAmbient.Location = New System.Drawing.Point(388, 256)
         Me.cboAmbient.Name = "cboAmbient"
         Me.cboAmbient.Size = New System.Drawing.Size(68, 21)
         Me.cboAmbient.TabIndex = 26
         Me.cboAmbient.Text = "20 F"
         '
         'cboLowAmbient
         '
         Me.cboLowAmbient.DropDownWidth = 200
         Me.cboLowAmbient.Items.AddRange(New Object() {"fan cycling", "variable speed control on last stage"})
         Me.cboLowAmbient.Location = New System.Drawing.Point(176, 256)
         Me.cboLowAmbient.Name = "cboLowAmbient"
         Me.cboLowAmbient.Size = New System.Drawing.Size(204, 21)
         Me.cboLowAmbient.TabIndex = 25
         Me.cboLowAmbient.Text = "fan cycling"
         '
         'cboMotor
         '
         Me.cboMotor.DropDownWidth = 200
         Me.cboMotor.Items.AddRange(New Object() {"Open drip proof", "Totally enclose - air over", "Severe duty rated"})
         Me.cboMotor.Location = New System.Drawing.Point(176, 228)
         Me.cboMotor.Name = "cboMotor"
         Me.cboMotor.Size = New System.Drawing.Size(204, 21)
         Me.cboMotor.TabIndex = 24
         Me.cboMotor.Text = "Open drip proof"
         '
         'radSubCoolingCircuitNo
         '
         Me.radSubCoolingCircuitNo.Checked = True
         Me.radSubCoolingCircuitNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radSubCoolingCircuitNo.Location = New System.Drawing.Point(236, 200)
         Me.radSubCoolingCircuitNo.Name = "radSubCoolingCircuitNo"
         Me.radSubCoolingCircuitNo.Size = New System.Drawing.Size(56, 24)
         Me.radSubCoolingCircuitNo.TabIndex = 23
         Me.radSubCoolingCircuitNo.TabStop = True
         Me.radSubCoolingCircuitNo.Text = "No"
         '
         'radSubCoolingCircuitYes
         '
         Me.radSubCoolingCircuitYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radSubCoolingCircuitYes.Location = New System.Drawing.Point(176, 200)
         Me.radSubCoolingCircuitYes.Name = "radSubCoolingCircuitYes"
         Me.radSubCoolingCircuitYes.Size = New System.Drawing.Size(56, 24)
         Me.radSubCoolingCircuitYes.TabIndex = 22
         Me.radSubCoolingCircuitYes.Text = "Yes"
         '
         'lblLowAmbientLabel
         '
         Me.lblLowAmbientLabel.Location = New System.Drawing.Point(12, 256)
         Me.lblLowAmbientLabel.Name = "lblLowAmbientLabel"
         Me.lblLowAmbientLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblLowAmbientLabel.TabIndex = 21
         Me.lblLowAmbientLabel.Text = "Low ambient operation"
         Me.lblLowAmbientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblMotorLabel
         '
         Me.lblMotorLabel.Location = New System.Drawing.Point(12, 228)
         Me.lblMotorLabel.Name = "lblMotorLabel"
         Me.lblMotorLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblMotorLabel.TabIndex = 20
         Me.lblMotorLabel.Text = "Motor type"
         Me.lblMotorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblSubCoolingCircuitLabel
         '
         Me.lblSubCoolingCircuitLabel.Location = New System.Drawing.Point(12, 200)
         Me.lblSubCoolingCircuitLabel.Name = "lblSubCoolingCircuitLabel"
         Me.lblSubCoolingCircuitLabel.Size = New System.Drawing.Size(148, 23)
         Me.lblSubCoolingCircuitLabel.TabIndex = 19
         Me.lblSubCoolingCircuitLabel.Text = "Integral sub-cooling circuit"
         Me.lblSubCoolingCircuitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'panWaterCooled
         '
         Me.panWaterCooled.Controls.Add(Me.cboHeatExchanger)
         Me.panWaterCooled.Controls.Add(Me.lblFactoryMounted)
         Me.panWaterCooled.Controls.Add(Me.radWaterValvesNo)
         Me.panWaterCooled.Controls.Add(Me.radWaterValvesYes)
         Me.panWaterCooled.Controls.Add(Me.lblHeatExchangerLabel)
         Me.panWaterCooled.Controls.Add(Me.lblWaterValvesLabel)
         Me.panWaterCooled.Location = New System.Drawing.Point(16, 44)
         Me.panWaterCooled.Name = "panWaterCooled"
         Me.panWaterCooled.Size = New System.Drawing.Size(500, 60)
         Me.panWaterCooled.TabIndex = 20
         '
         'cboHeatExchanger
         '
         Me.cboHeatExchanger.Items.AddRange(New Object() {"shell and tube", "brazed plate"})
         Me.cboHeatExchanger.Location = New System.Drawing.Point(216, 32)
         Me.cboHeatExchanger.Name = "cboHeatExchanger"
         Me.cboHeatExchanger.Size = New System.Drawing.Size(152, 21)
         Me.cboHeatExchanger.TabIndex = 6
         Me.cboHeatExchanger.Text = "shell and tube"
         '
         'lblFactoryMounted
         '
         Me.lblFactoryMounted.Location = New System.Drawing.Point(340, 4)
         Me.lblFactoryMounted.Name = "lblFactoryMounted"
         Me.lblFactoryMounted.TabIndex = 5
         Me.lblFactoryMounted.Text = "mounted at factory"
         Me.lblFactoryMounted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'radWaterValvesNo
         '
         Me.radWaterValvesNo.Checked = True
         Me.radWaterValvesNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radWaterValvesNo.Location = New System.Drawing.Point(280, 4)
         Me.radWaterValvesNo.Name = "radWaterValvesNo"
         Me.radWaterValvesNo.Size = New System.Drawing.Size(64, 24)
         Me.radWaterValvesNo.TabIndex = 4
         Me.radWaterValvesNo.TabStop = True
         Me.radWaterValvesNo.Text = "No"
         '
         'radWaterValvesYes
         '
         Me.radWaterValvesYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radWaterValvesYes.Location = New System.Drawing.Point(216, 4)
         Me.radWaterValvesYes.Name = "radWaterValvesYes"
         Me.radWaterValvesYes.Size = New System.Drawing.Size(64, 24)
         Me.radWaterValvesYes.TabIndex = 3
         Me.radWaterValvesYes.Text = "Yes"
         '
         'lblHeatExchangerLabel
         '
         Me.lblHeatExchangerLabel.Location = New System.Drawing.Point(12, 32)
         Me.lblHeatExchangerLabel.Name = "lblHeatExchangerLabel"
         Me.lblHeatExchangerLabel.Size = New System.Drawing.Size(188, 23)
         Me.lblHeatExchangerLabel.TabIndex = 1
         Me.lblHeatExchangerLabel.Text = "Heat exchanger design"
         Me.lblHeatExchangerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblWaterValvesLabel
         '
         Me.lblWaterValvesLabel.Location = New System.Drawing.Point(12, 4)
         Me.lblWaterValvesLabel.Name = "lblWaterValvesLabel"
         Me.lblWaterValvesLabel.Size = New System.Drawing.Size(188, 23)
         Me.lblWaterValvesLabel.TabIndex = 0
         Me.lblWaterValvesLabel.Text = "Condenser water regulating valves"
         Me.lblWaterValvesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'panEvaporativeCooled
         '
         Me.panEvaporativeCooled.Controls.Add(Me.chkAcousticAttenuatorsDischarge)
         Me.panEvaporativeCooled.Controls.Add(Me.chkAcousticAttenuatorsIntake)
         Me.panEvaporativeCooled.Controls.Add(Me.cboCoil)
         Me.panEvaporativeCooled.Controls.Add(Me.cboHeadPressure)
         Me.panEvaporativeCooled.Controls.Add(Me.cboMaterial)
         Me.panEvaporativeCooled.Controls.Add(Me.lblHeadPressureLabel)
         Me.panEvaporativeCooled.Controls.Add(Me.lblCoilLabel)
         Me.panEvaporativeCooled.Controls.Add(Me.lblAcousticAttenuatorsLabel)
         Me.panEvaporativeCooled.Controls.Add(Me.lblMaterialLabel)
         Me.panEvaporativeCooled.Location = New System.Drawing.Point(16, 44)
         Me.panEvaporativeCooled.Name = "panEvaporativeCooled"
         Me.panEvaporativeCooled.Size = New System.Drawing.Size(532, 116)
         Me.panEvaporativeCooled.TabIndex = 21
         '
         'chkAcousticAttenuatorsDischarge
         '
         Me.chkAcousticAttenuatorsDischarge.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkAcousticAttenuatorsDischarge.Location = New System.Drawing.Point(296, 88)
         Me.chkAcousticAttenuatorsDischarge.Name = "chkAcousticAttenuatorsDischarge"
         Me.chkAcousticAttenuatorsDischarge.Size = New System.Drawing.Size(80, 24)
         Me.chkAcousticAttenuatorsDischarge.TabIndex = 8
         Me.chkAcousticAttenuatorsDischarge.Text = "Discharge"
         '
         'chkAcousticAttenuatorsIntake
         '
         Me.chkAcousticAttenuatorsIntake.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkAcousticAttenuatorsIntake.Location = New System.Drawing.Point(216, 88)
         Me.chkAcousticAttenuatorsIntake.Name = "chkAcousticAttenuatorsIntake"
         Me.chkAcousticAttenuatorsIntake.Size = New System.Drawing.Size(80, 24)
         Me.chkAcousticAttenuatorsIntake.TabIndex = 7
         Me.chkAcousticAttenuatorsIntake.Text = "Intake"
         '
         'cboCoil
         '
         Me.cboCoil.Items.AddRange(New Object() {"Steel tube", "Copper tube"})
         Me.cboCoil.Location = New System.Drawing.Point(216, 60)
         Me.cboCoil.Name = "cboCoil"
         Me.cboCoil.Size = New System.Drawing.Size(308, 21)
         Me.cboCoil.TabIndex = 6
         Me.cboCoil.Text = "Steel tube"
         '
         'cboHeadPressure
         '
         Me.cboHeadPressure.Items.AddRange(New Object() {"2 speed fan motors", "VFD fan control"})
         Me.cboHeadPressure.Location = New System.Drawing.Point(216, 32)
         Me.cboHeadPressure.Name = "cboHeadPressure"
         Me.cboHeadPressure.Size = New System.Drawing.Size(308, 21)
         Me.cboHeadPressure.TabIndex = 5
         Me.cboHeadPressure.Text = "2 speed fan motors"
         '
         'cboMaterial
         '
         Me.cboMaterial.DropDownWidth = 300
         Me.cboMaterial.Items.AddRange(New Object() {"G-235 galvanize sump", "304 stainless steel sump", "304 stainless steel water-touch (sump and wet surfaces)", "All stainless constructions (sump, wet surfaces, cabinet)"})
         Me.cboMaterial.Location = New System.Drawing.Point(216, 4)
         Me.cboMaterial.Name = "cboMaterial"
         Me.cboMaterial.Size = New System.Drawing.Size(308, 21)
         Me.cboMaterial.TabIndex = 4
         Me.cboMaterial.Text = "G-235 galvanize sump"
         '
         'lblHeadPressureLabel
         '
         Me.lblHeadPressureLabel.Location = New System.Drawing.Point(8, 32)
         Me.lblHeadPressureLabel.Name = "lblHeadPressureLabel"
         Me.lblHeadPressureLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblHeadPressureLabel.TabIndex = 3
         Me.lblHeadPressureLabel.Text = "Head pressure control"
         Me.lblHeadPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCoilLabel
         '
         Me.lblCoilLabel.Location = New System.Drawing.Point(8, 60)
         Me.lblCoilLabel.Name = "lblCoilLabel"
         Me.lblCoilLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblCoilLabel.TabIndex = 2
         Me.lblCoilLabel.Text = "Condenser coil"
         Me.lblCoilLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblAcousticAttenuatorsLabel
         '
         Me.lblAcousticAttenuatorsLabel.Location = New System.Drawing.Point(8, 88)
         Me.lblAcousticAttenuatorsLabel.Name = "lblAcousticAttenuatorsLabel"
         Me.lblAcousticAttenuatorsLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblAcousticAttenuatorsLabel.TabIndex = 1
         Me.lblAcousticAttenuatorsLabel.Text = "Acoustic attenuators (shipped loose)"
         Me.lblAcousticAttenuatorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblMaterialLabel
         '
         Me.lblMaterialLabel.Location = New System.Drawing.Point(8, 4)
         Me.lblMaterialLabel.Name = "lblMaterialLabel"
         Me.lblMaterialLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblMaterialLabel.TabIndex = 0
         Me.lblMaterialLabel.Text = "Condenser material"
         Me.lblMaterialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'CondenserSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "CondenserSpecBuilderWizard"
         Me.Tag = "Condenser"
         Me.Text = "Untitled - Condenser - SpecBuilder"
         Me.panMain.ResumeLayout(False)
         Me.panAirCooled.ResumeLayout(False)
         Me.panWaterCooled.ResumeLayout(False)
         Me.panEvaporativeCooled.ResumeLayout(False)

      End Sub

#End Region


      Dim optManager As New OptionManager(SpecData)


      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub


#Region " Event Handler"

      Private Sub CondenserSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetAirCooledControls()
         Me.SetWaterCooledControls()
         Me.SetEvaporativeCooledControls()
         Me.SetDischargeControls()
         Me.SetRainHoodControl()
         Me.SetHeatedAndInsulatedReceivers()
      End Sub


      Private Sub cboCondenser_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboCondenser.SelectedIndexChanged
         Me.SpecData.Condenser.Condenser = Me.cboCondenser.Text

         Me.SetAirCooledControls()
         Me.SetWaterCooledControls()
         Me.SetEvaporativeCooledControls()
      End Sub


      Private Sub cboDesign_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboDesign.SelectedIndexChanged
         Me.SpecData.Condenser.CondenserDesign = Me.cboDesign.Text
      End Sub


      Private Sub cboFinMaterial_SelectedIndexChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles cboFinMaterial.SelectedIndexChanged
         Me.SpecData.Condenser.FinMaterial = Me.cboFinMaterial.Text
      End Sub


      Private Sub cboCasingsAndTubeSheets_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboCasingsAndTubeSheets.SelectedIndexChanged
         Me.SpecData.Condenser.CasingsAndTubeSheets = _
            Me.cboCasingsAndTubeSheets.Text
      End Sub


      Private Sub cboTubeThickness_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboTubeThickness.SelectedIndexChanged
         Me.SpecData.Condenser.TubeThickness = Me.cboTubeThickness.Text
      End Sub


      Private Sub cboFinThickness_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboFinThickness.SelectedIndexChanged
         Me.SpecData.Condenser.FinThickness = Me.cboFinThickness.Text
      End Sub


      Private Sub cboCondenserType_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboCondenserType.SelectedIndexChanged
         Me.SpecData.Condenser.CondenserType = Me.cboCondenserType.Text

         Me.SetDischargeControls()
         Me.SetRainHoodControl()
      End Sub


      Private Sub cboDischarge_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboDischarge.SelectedIndexChanged
         Me.SpecData.Condenser.Discharge = Me.cboDischarge.Text
      End Sub


      Private Sub chkRainHood_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkRainHood.CheckedChanged
         Me.SpecData.Condenser.RainHood = Me.chkRainHood.Checked
      End Sub


      Private Sub radSubCoolingCircuitYes_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles radSubCoolingCircuitYes.CheckedChanged
         Me.SpecData.Condenser.SubCoolingCircuit = Me.radSubCoolingCircuitYes.Checked
      End Sub


      Private Sub cboMotor_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboMotor.SelectedIndexChanged
         Me.SpecData.Condenser.Motor = Me.cboMotor.Text
      End Sub


      Private Sub cboLowAmbient_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboLowAmbient.SelectedIndexChanged
         Me.SpecData.Condenser.LowAmbient = Me.cboLowAmbient.Text
      End Sub


      Private Sub cboAmbient_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboAmbient.SelectedIndexChanged
         Me.SpecData.Condenser.Ambient = Me.cboAmbient.Text
      End Sub


      Private Sub chkFloodedCondenserControl_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkFloodedCondenserControl.CheckedChanged
         Me.SpecData.Condenser.FloodedCondenserControl = _
            Me.chkFloodedCondenserControl.Checked

         Me.SetHeatedAndInsulatedReceivers()
      End Sub


      Private Sub chkHeatedAndInsulatedReceivers_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkHeatedAndInsulatedReceivers.CheckedChanged
         Me.SpecData.Condenser.HeatedAndInsulatedReceivers = _
            Me.chkHeatedAndInsulatedReceivers.Checked
      End Sub


      Private Sub radWaterValvesYes_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles radWaterValvesYes.CheckedChanged
         Me.SpecData.Condenser.WaterValves = Me.radWaterValvesYes.Checked
      End Sub


      Private Sub cboHeatExchanger_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboHeatExchanger.SelectedIndexChanged
         Me.SpecData.Condenser.HeatExchanger = Me.cboHeatExchanger.Text
      End Sub


      Private Sub cboMaterial_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboMaterial.SelectedIndexChanged
         Me.SpecData.Condenser.Material = Me.cboMaterial.Text
      End Sub


      Private Sub cboHeadPressure_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboHeadPressure.SelectedIndexChanged
         Me.SpecData.Condenser.HeadPressure = Me.cboHeadPressure.Text
      End Sub


      Private Sub cboCoil_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboCoil.SelectedIndexChanged
         Me.SpecData.Condenser.Coil = Me.cboCoil.Text
      End Sub


      Private Sub chkAcousticAttenuatorsIntake_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkAcousticAttenuatorsIntake.CheckedChanged
         Me.SpecData.Condenser.AcousticAttenuatorsIntake = _
            Me.chkAcousticAttenuatorsIntake.Checked
      End Sub


      Private Sub chkAcousticAttenuatorsDischarge_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkAcousticAttenuatorsDischarge.CheckedChanged
         Me.SpecData.Condenser.AcousticAttenuatorsDischarge = _
            Me.chkAcousticAttenuatorsDischarge.Checked
      End Sub

#End Region


#Region " Set Controls"

      Private Sub SetAirCooledControls()
         Me.panAirCooled.Visible = Me.optManager.GetAirCooled.IsOption
      End Sub

      Private Sub SetWaterCooledControls()
         Me.panWaterCooled.Visible = Me.optManager.GetWaterCooled.IsOption
      End Sub

      Private Sub SetEvaporativeCooledControls()
         Me.panEvaporativeCooled.Visible = _
            Me.optManager.GetEvaporativeCooled.IsOption
      End Sub

      Private Sub SetDischargeControls()
         If Me.optManager.GetDischarge.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblDischargeLabel, Me.cboDischarge _
               , Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblDischargeLabel, _
               Me.cboDischarge, Me.tip, Me.optManager.GetDischarge.Explanation)
         End If
      End Sub

      Private Sub SetRainHoodControl()
         If Me.optManager.GetDischarge.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.chkRainHood, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.chkRainHood, Me.tip, _
               Me.optManager.GetRainHood.Explanation)
         End If
      End Sub

      Private Sub SetHeatedAndInsulatedReceivers()
         If Me.optManager.GetHeatedAndInsulatedReceivers.IsOption Then
            SpecBuilderManager.EnableControls(New Label, _
               Me.chkHeatedAndInsulatedReceivers, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, _
               Me.chkHeatedAndInsulatedReceivers, Me.tip, _
               Me.optManager.GetHeatedAndInsulatedReceivers.Explanation)
         End If
      End Sub

#End Region

      
   End Class

End Namespace
