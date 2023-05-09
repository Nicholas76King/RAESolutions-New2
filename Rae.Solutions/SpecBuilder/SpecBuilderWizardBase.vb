Imports Forms = System.Windows.Forms

Namespace SpecBuilder

   Public Class SpecBuilderWizardBase
      Inherits Wizard.WizardBase

        Protected isDisposing As Boolean
        Protected htmlCommand As Boolean
        Friend WithEvents ToolStripLabel1 As ToolStripLabel
        Protected wordCommand As Boolean

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
            Me.isDisposing = True
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        ''Friend WithEvents mainDock As C1.Win.C1Command.C1CommandDock
        ''Friend WithEvents standardToolBar As C1.Win.C1Command.C1ToolBar
        ''Friend WithEvents openCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents openLink As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents newLink As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents newCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents saveLink As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents saveCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents buildLink As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents buildCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents mainHolder As C1.Win.C1Command.C1CommandHolder
        Protected WithEvents panMain As System.Windows.Forms.Panel
        ''Friend WithEvents closeLink As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents closeCommand As C1.Win.C1Command.C1Command
        Friend WithEvents tip As System.Windows.Forms.ToolTip
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents ToolStrip1 As ToolStrip
        Friend WithEvents btnNew As ToolStripButton
        Friend WithEvents btnOpen As ToolStripButton
        Friend WithEvents btnSave As ToolStripButton
        Friend WithEvents btnSaveAs As ToolStripButton
        Friend WithEvents btnBuild As ToolStripButton
        Friend WithEvents btnClose As ToolStripButton
        Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
        Friend WithEvents ExportFormatToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents HTMLToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents MSWordToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        ''Friend WithEvents optionsLink As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents optionsCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents optionsMenu As C1.Win.C1Command.C1CommandMenu
        ''Friend WithEvents htmlCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents wordCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents exportCommand As C1.Win.C1Command.C1CommandMenu
        ''Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
        ''Friend WithEvents saveAsCommand As C1.Win.C1Command.C1Command
        ''Friend WithEvents saveAsLink As C1.Win.C1Command.C1CommandLink
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.panMain = New System.Windows.Forms.Panel()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
            Me.btnNew = New System.Windows.Forms.ToolStripButton()
            Me.btnOpen = New System.Windows.Forms.ToolStripButton()
            Me.btnSave = New System.Windows.Forms.ToolStripButton()
            Me.btnSaveAs = New System.Windows.Forms.ToolStripButton()
            Me.btnBuild = New System.Windows.Forms.ToolStripButton()
            Me.btnClose = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
            Me.ExportFormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.HTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.MSWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
            Me.tip = New System.Windows.Forms.ToolTip(Me.components)
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.panBottom.SuspendLayout()
            Me.panMain.SuspendLayout()
            Me.ToolStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'panBottom
            '
            Me.panBottom.BackColor = System.Drawing.Color.LightSteelBlue
            Me.panBottom.Location = New System.Drawing.Point(0, 496)
            Me.panBottom.Size = New System.Drawing.Size(556, 48)
            '
            'panMain
            '
            Me.panMain.BackColor = System.Drawing.Color.White
            Me.panMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panMain.Controls.Add(Me.Panel2)
            Me.panMain.Controls.Add(Me.Panel1)
            Me.panMain.Controls.Add(Me.ToolStrip1)
            Me.panMain.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panMain.Location = New System.Drawing.Point(0, 0)
            Me.panMain.Name = "panMain"
            Me.panMain.Size = New System.Drawing.Size(556, 496)
            Me.panMain.TabIndex = 4
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.IndianRed
            Me.Panel2.Location = New System.Drawing.Point(11, 53)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(200, 8)
            Me.Panel2.TabIndex = 1
            Me.Panel2.Visible = False
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.IndianRed
            Me.Panel1.Location = New System.Drawing.Point(207, 45)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(16, 240)
            Me.Panel1.TabIndex = 0
            Me.Panel1.Visible = False
            '
            'ToolStrip1
            '
            Me.ToolStrip1.CanOverflow = False
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnOpen, Me.btnSave, Me.btnSaveAs, Me.btnBuild, Me.btnClose, Me.ToolStripDropDownButton1, Me.ToolStripLabel1})
            Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
            Me.ToolStrip1.Name = "ToolStrip1"
            Me.ToolStrip1.Size = New System.Drawing.Size(552, 25)
            Me.ToolStrip1.TabIndex = 2
            Me.ToolStrip1.Text = "ToolStrip1"
            '
            'btnNew
            '
            Me.btnNew.Image = Global.Rae.RaeSolutions.My.Resources.Resources.NewDocument
            Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(51, 22)
            Me.btnNew.Text = "New"
            '
            'btnOpen
            '
            Me.btnOpen.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
            Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnOpen.Name = "btnOpen"
            Me.btnOpen.Size = New System.Drawing.Size(56, 22)
            Me.btnOpen.Text = "Open"
            '
            'btnSave
            '
            Me.btnSave.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
            Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(51, 22)
            Me.btnSave.Text = "Save"
            '
            'btnSaveAs
            '
            Me.btnSaveAs.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
            Me.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnSaveAs.Name = "btnSaveAs"
            Me.btnSaveAs.Size = New System.Drawing.Size(76, 22)
            Me.btnSaveAs.Text = "Save As..."
            Me.btnSaveAs.ToolTipText = "Save As..."
            '
            'btnBuild
            '
            Me.btnBuild.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Lightning
            Me.btnBuild.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnBuild.Name = "btnBuild"
            Me.btnBuild.Size = New System.Drawing.Size(54, 22)
            Me.btnBuild.Text = "Build"
            '
            'btnClose
            '
            Me.btnClose.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Cancel
            Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(56, 22)
            Me.btnClose.Text = "Close"
            '
            'ToolStripDropDownButton1
            '
            Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportFormatToolStripMenuItem})
            Me.ToolStripDropDownButton1.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
            Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
            Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(78, 22)
            Me.ToolStripDropDownButton1.Text = "Options"
            '
            'ExportFormatToolStripMenuItem
            '
            Me.ExportFormatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HTMLToolStripMenuItem, Me.MSWordToolStripMenuItem})
            Me.ExportFormatToolStripMenuItem.Name = "ExportFormatToolStripMenuItem"
            Me.ExportFormatToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
            Me.ExportFormatToolStripMenuItem.Text = "Export Format"
            '
            'HTMLToolStripMenuItem
            '
            Me.HTMLToolStripMenuItem.Name = "HTMLToolStripMenuItem"
            Me.HTMLToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
            Me.HTMLToolStripMenuItem.Text = "HTML"
            '
            'MSWordToolStripMenuItem
            '
            Me.MSWordToolStripMenuItem.Name = "MSWordToolStripMenuItem"
            Me.MSWordToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
            Me.MSWordToolStripMenuItem.Text = "MS Word"
            '
            'ToolStripLabel1
            '
            Me.ToolStripLabel1.Name = "ToolStripLabel1"
            Me.ToolStripLabel1.Size = New System.Drawing.Size(87, 22)
            Me.ToolStripLabel1.Text = "ToolStripLabel1"
            '
            'tip
            '
            Me.tip.AutoPopDelay = 5000
            Me.tip.InitialDelay = 1000
            Me.tip.ReshowDelay = 1000
            Me.tip.ShowAlways = True
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
            '
            'SpecBuilderWizardBase
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
            Me.ClientSize = New System.Drawing.Size(556, 544)
            Me.Controls.Add(Me.panMain)
            Me.Name = "SpecBuilderWizardBase"
            Me.Text = "Base - SpecBuilder"
            Me.Controls.SetChildIndex(Me.panBottom, 0)
            Me.Controls.SetChildIndex(Me.panMain, 0)
            Me.panBottom.ResumeLayout(False)
            Me.panMain.ResumeLayout(False)
            Me.panMain.PerformLayout()
            Me.ToolStrip1.ResumeLayout(False)
            Me.ToolStrip1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region


#Region " Declarations"
        Private _specData As New SpecBuilder.SpecBuilderData
#End Region


#Region " Properties"

        Public Property SpecData() As SpecBuilder.SpecBuilderData
            Get
                Return Me._specData
            End Get
            Set(ByVal Value As SpecBuilder.SpecBuilderData)
                Me._specData = Value
            End Set
        End Property


        Public FilePath As String

#End Region


#Region " Public Methods"

        Public Sub New(ByVal wizard As Wizard.Wizard,
      ByVal specData As SpecBuilder.SpecBuilderData)
            Me.New()
            Me.Wizard = wizard
            Me.SpecData = specData

        End Sub

#End Region


#Region " Event Handlers"

        Protected Overridable Sub SpecBuilderWizardBase_Load(ByVal sender As Object,
      ByVal e As System.EventArgs) Handles MyBase.Load
            Dim fileExtension As String

            'sets form's title
            Me.SetText()
            Me.htmlCommand = True
            Me.ToolStripLabel1.Text = "HTML"
            fileExtension = My.Settings.ExportExtension
            'reads file extension from configuration file
            'fileExtension = ConfigurationManager.ReadDeviceConfiguration().SpecBuilderExportFormat
            If fileExtension = "html" Then
                'sets export format to html
                Me.htmlCommand = True
                Me.ToolStripLabel1.Text = "HTML"
                'deselects other options
                Me.wordCommand = False
            ElseIf fileExtension = "doc" Then
                'sets export format to Word
                Me.wordCommand = True
                Me.ToolStripLabel1.Text = "MS Word"
                'deselects other options
                Me.htmlCommand = False
            End If
        End Sub


        Protected Overridable Sub text_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.TextChanged
            Me.SpecData.Name = Me.Text.Substring(0, Me.Text.IndexOf("-")).Trim
        End Sub


        ''Protected Overridable Sub newCommand_Click(ByVal sender As System.Object, _
        ''ByVal e As C1.Win.C1Command.ClickEventArgs) Handles newCommand.Click
        ''   ' gets a default specbuilder wizard
        ''   Dim wiz As Rae.Wizard.Wizard = SpecBuilderManager.GetDefaultSpecBuilderWizard()
        ''   For i As Integer = 0 To wiz.Forms.Count - 1
        ''      ' sets mdi parent of each form in wizard
        ''      wiz.Forms.Item(i).MdiParent = Me.MdiParent
        ''   Next
        ''   'starts default SpecBuilder
        ''   wiz.Start()
        ''End Sub


        ''  Private Sub openCommand_Click(ByVal sender As System.Object, _
        ''ByVal e As C1.Win.C1Command.ClickEventArgs) Handles openCommand.Click
        ''   Dim filePath As String
        ''   Dim specData As SpecBuilderData
        ''   Dim wiz As Wizard.Wizard

        ''   'gets user's open file path
        ''   filePath = Me.GetUsersOpenFilePath()
        ''   'exits, if open dialog was canceled
        ''   If filePath = String.Empty Then Exit Sub

        ''   'gets default wizard
        ''   wiz = SpecBuilderManager.GetDefaultSpecBuilderWizard()
        ''   For i As Integer = 0 To wiz.Forms.Count - 1
        ''      ' sets mdiparent for each form
        ''      wiz.Forms.Item(i).MdiParent = Me.MdiParent
        ''      ' sets file path for each form
        ''      DirectCast(wiz.Forms.Item(i), SpecBuilderWizardBase).FilePath = filePath
        ''   Next
        ''   'starts SpecBuilder
        ''   wiz.Start()
        ''   'sets SpecBuilder data to the data in file
        ''   specData = SpecBuilderManager.GetExistingSpec(filePath)

        ''   'fill controls with opened SpecBuilder data
        ''   'unit
        ''   With CType(wiz.Forms(0), UnitSpecBuilderWizard)
        ''      .Text = .GenerateFormTitle(specData.Name, .Tag.ToString)
        ''      .cboUnit.Text = specData.Unit
        ''      .cboCoolingSolution.Text = specData.CoolingSolution
        ''      .txtCoolingSolutionPercentage.Text = specData.SolutionPercentage
        ''   End With

        ''   'housing and piping
        ''   With CType(wiz.Forms(1), HousingAndPipingSpecBuilderWizard)
        ''      .cboBaseFrame.Text = specData.HousingAndPiping.BaseFrame
        ''      .cboHousing.Text = specData.HousingAndPiping.Housing
        ''      .chkEpoxyCoated.Checked = specData.HousingAndPiping.EpoxyCoated
        ''      .cboPiping.Text = specData.HousingAndPiping.Piping
        ''   End With

        ''   'compressor
        ''   With CType(wiz.Forms(2), CompressorSpecBuilderWizard)
        ''      .cboCompressor.Text = specData.Compressor.Compressor
        ''      .cboRefrigerant.Text = specData.Compressor.Refrigerant
        ''      .radCylinderLoadingYes.Checked = specData.Compressor.CylinderLoading
        ''      .cboCylinderLoading.Text = specData.Compressor.CylinderLoadingOption
        ''      .cboModulation.Text = specData.Compressor.CapacitySlideValveModulation
        ''   End With

        ''   'evaporator
        ''   With CType(wiz.Forms(3), EvaporatorSpecBuilderWizard)
        ''      .cboEvaporator.Text = specData.Evaporator.Evaporator
        ''      .cboPressure.Text = specData.Evaporator.Pressure
        ''   End With

        ''   'condenser
        ''   With CType(wiz.Forms(4), CondenserSpecBuilderWizard)
        ''      .cboCondenser.Text = specData.Condenser.Condenser
        ''      'air-cooled
        ''      .cboDesign.Text = specData.Condenser.CondenserDesign
        ''      .cboFinMaterial.Text = specData.Condenser.FinMaterial
        ''      .cboCasingsAndTubeSheets.Text = specData.Condenser.CasingsAndTubeSheets
        ''      .cboTubeThickness.Text = specData.Condenser.TubeThickness
        ''      .cboFinThickness.Text = specData.Condenser.FinThickness
        ''      .cboCondenserType.Text = specData.Condenser.CondenserType
        ''      .cboDischarge.Text = specData.Condenser.Discharge
        ''      .chkRainHood.Checked = specData.Condenser.RainHood
        ''      .radSubCoolingCircuitYes.Checked = specData.Condenser.SubCoolingCircuit
        ''      .cboMotor.Text = specData.Condenser.Motor
        ''      .cboLowAmbient.Text = specData.Condenser.LowAmbient
        ''      .cboAmbient.Text = specData.Condenser.Ambient
        ''      .chkFloodedCondenserControl.Checked = specData.Condenser.FloodedCondenserControl
        ''      .chkHeatedAndInsulatedReceivers.Checked = specData.Condenser.HeatedAndInsulatedReceivers
        ''      'water-cooled
        ''      .radWaterValvesYes.Checked = specData.Condenser.WaterValves
        ''      .cboHeatExchanger.Text = specData.Condenser.HeatExchanger
        ''      'evaporative-cooled
        ''      .cboMaterial.Text = specData.Condenser.Material
        ''      .cboHeadPressure.Text = specData.Condenser.HeadPressure
        ''      .cboCoil.Text = specData.Condenser.Coil
        ''      .chkAcousticAttenuatorsIntake.Checked = specData.Condenser.AcousticAttenuatorsIntake
        ''      .chkAcousticAttenuatorsDischarge.Checked = specData.Condenser.AcousticAttenuatorsDischarge
        ''   End With

        ''   'refrigerant circuit
        ''   With CType(wiz.Forms(5), RefrigerantSpecBuilderWizard)
        ''      .radSolenoidYes.Checked = specData.Refrigerant.Solenoid
        ''      .radFilterYes.Checked = specData.Refrigerant.FilterDrier
        ''      .cboFilterDrier.Text = specData.Refrigerant.FilterDrierType
        ''      .cboExpansionValve.Text = specData.Refrigerant.ExpansionValve
        ''      .chkPressureReliefHigh.Checked = specData.Refrigerant.PressureReliefHigh
        ''      .chkPressureReliefLow.Checked = specData.Refrigerant.PressureReliefLow
        ''      .cboSuctionAccumulators.Text = specData.Refrigerant.SuctionAccumulators
        ''      .radDischargeMufflerYes.Checked = specData.Refrigerant.HotGasDischargeMuffler
        ''      .radOilSeperatorYes.Checked = specData.Refrigerant.OilSeperator
        ''      .radSuctionFilterYes.Checked = specData.Refrigerant.SuctionFilter
        ''      .cboSuctionFilter.Text = specData.Refrigerant.SuctionFilterType
        ''      .cboVibratorbers.Text = specData.Refrigerant.Vibratorbers
        ''      .radHotGasBypassYes.Checked = specData.Refrigerant.HotGasBypass
        ''      .cboHotGasBypass.Text = specData.Refrigerant.HotGasBypassDesign
        ''      .cboHotGasBypassTons.Text = specData.Refrigerant.HotGasBypassTons
        ''      .cboLiquidReceiver.Text = specData.Refrigerant.LiquidReceiver
        ''      .chkLiquidReceiverHandValves.Checked = specData.Refrigerant.LiquidReceiverHandValves
        ''   End With

        ''   'controls circuit
        ''   With CType(wiz.Forms(6), ControlsSpecBuilderWizard)
        ''      .cboControls.Text = specData.Controls.ControlsType
        ''      .cboPowerConnection.Text = specData.Controls.PowerConnection
        ''      .radDisconnectOptionYes.Checked = specData.Controls.DisconnectOption
        ''      .cboDisconnectOption.Text = specData.Controls.DisconnectOptionType
        ''      .chkCompressorStatusLight.Checked = specData.Controls.CompressorStatusLight
        ''      .chkFailureStatusLight.Checked = specData.Controls.FailureStatusLight
        ''      .chkPumpStatusLight.Checked = specData.Controls.PumpStatusLight
        ''      .radDisconnectSwitchYes.Checked = specData.Controls.MoldedCaseDisconnectSwitch
        ''      .cboCompressorLeadLagSwitch.Text = specData.Controls.CompressorLeadLagSwitch
        ''      .radUnitPhaseMonitorYes.Checked = specData.Controls.UnitPhaseMonitor
        ''      .cboUnitPhaseMonitorScope.Text = specData.Controls.UnitPhaseMonitorScope
        ''      .radRefrigerantAndOilGaugesYes.Checked = specData.Controls.RefrigerantAndOilGauges
        ''      .radLcdYes.Checked = specData.Controls.Lcd
        ''      .chkLcdDemandLimitingSetpoint.Checked = specData.Controls.LcdDemandLimitingSetPoint
        ''      .chkLcdChilledWaterSetpoint.Checked = specData.Controls.LcdChilledWaterSetPoint
        ''      .chkLcdCompressorAmps.Checked = specData.Controls.LcdCompressorAmps
        ''      .chkLcdCompressorStatus.Checked = specData.Controls.LcdCompressorStatus
        ''      .chkLcdRefrigerantDischarge.Checked = specData.Controls.LcdRefrigerantDischargePressureAndTemperature
        ''      .chkLcdRefrigerantSuction.Checked = specData.Controls.LcdRefrigerantSuctionPressureAndTemperature
        ''      .chkLcdFailureAndAlarmHistory.Checked = specData.Controls.LcdFailureAndAlarmHistory
        ''      .chkLcdWaterTemperatures.Checked = specData.Controls.LcdWaterTemperatures
        ''   End With

        ''   With CType(wiz.Forms(7), PumpSpecBuilderWizard)
        ''      .chkPumpPackage.Checked = specData.Pump.PumpPackage
        ''      .cboDesignCriteria.Text = specData.Pump.DesignCriteria
        ''      .cboDesignCriteriaDualOption.Text = specData.Pump.DesignCriteriaDualOption
        ''      .cboPackage.Text = specData.Pump.PackageDesign
        ''      .cboSpeed.Text = specData.Pump.Speed
        ''      .cboType.Text = specData.Pump.PumpType
        ''      .chkAirSeperator.Checked = specData.Pump.AirSeperator
        ''      .cboAirSeperator.Text = specData.Pump.AirSeperatorDesign
        ''      .chkExpansionTank.Checked = specData.Pump.ExpansionTank
        ''      .cboExpansionTankType.Text = specData.Pump.ExpansionTankType
        ''      .cboSuctionStrainer.Text = specData.Pump.SuctionStrainer
        ''      .cboSuctionTrim.Text = specData.Pump.SuctionTrim
        ''      .chkStorageTank.Checked = specData.Pump.StorageTank
        ''      .cboStorageTankType.Text = specData.Pump.StorageTankType
        ''      .txtStorageTankVolume.Text = specData.Pump.StorageTankVolume
        ''      .cboStorageRatingAsm.Text = specData.Pump.StorageTankRatingAsm
        ''      .cboStorageTankRatingPsi.Text = specData.Pump.StorageTankRatingPsi
        ''   End With

        ''   With CType(wiz.Forms(8), HazardSpecBuilderWizard)
        ''      .chkHazard.Checked = specData.Hazard.Hazard
        ''      .cboStructuralBase.Text = specData.Hazard.StructuralBase
        ''      .cboCondenserCasings.Text = specData.Hazard.CondenserCasings
        ''      .cboCondenserFins.Text = specData.Hazard.CondenserFins
        ''      .cboControlEnclosure.Text = specData.Hazard.ControlEnclosure
        ''      .chkHazardousDutyClassification.Checked = specData.Hazard.HazardousDutyClassification
        ''   End With

        ''   With CType(wiz.Forms(9), AcousticSpecBuilderWizard)
        ''      .chkAcoustic.Checked = specData.Acoustic.Acoustic
        ''      .chkCompressors.Checked = specData.Acoustic.Compressors
        ''      .cboCovering.Text = specData.Acoustic.CompressorCovering
        ''      .chkSpringIsolators.Checked = specData.Acoustic.CompressorSpringIsolator
        ''      .chkCondenserFans.Checked = specData.Acoustic.CondenserFans
        ''      .cboFanType.Text = specData.Acoustic.CondenserFanType
        ''      .chkShroud.Checked = specData.Acoustic.CondenserShroud
        ''   End With

        ''   With CType(wiz.Forms(10), OtherSpecBuilderWizard)
        ''      .chkWatersideEconomizer.Checked = specData.Other.WatersideEconomizer
        ''      .chkAdditionalWarranty.Checked = specData.Other.AdditionalWarranty
        ''      .chkSupervisedStartup.Checked = specData.Other.SupervisedStartup
        ''   End With
        ''   'MAINTAIN: add code to open new SpecBuilder data here

        ''End Sub


        ''  Private Sub saveCommand_Click(ByVal sender As System.Object, _
        ''ByVal e As C1.Win.C1Command.ClickEventArgs) Handles saveCommand.Click
        ''   'saves current spec to file
        ''   Me.Save()
        ''End Sub


        ''  Private Sub buildCommand_Click(ByVal sender As System.Object, _
        ''ByVal e As C1.Win.C1Command.ClickEventArgs) Handles buildCommand.Click
        ''   Dim i, originalIndex As Integer
        ''   Dim html As String
        ''   Dim specExporter As Exporter
        ''   Dim temporaryFilePath, fileName As String

        ''   'removes the file extension (.spec)
        ''   fileName = System.IO.Path.GetFileNameWithoutExtension(Me.SpecData.Name)
        ''   'removes the file extension (.rae)
        ''   fileName = System.IO.Path.GetFileNameWithoutExtension(fileName)
        ''   'adds extension
        ''   If Me.htmlCommand.Checked Then
        ''      fileName &= ".html"
        ''   Else
        ''      fileName &= ".doc"
        ''   End If
        ''   'combines file name with file path
        ''   temporaryFilePath = System.IO.Path.Combine(Application.LocalUserAppDataPath, fileName)

        ''   'gets the original index before all the forms are iterated through
        ''   originalIndex = Me.Wizard.CurrentIndex
        ''   'steps through each form so that all business logic is ran in order
        ''   For i = 0 To Me.Wizard.Forms.Count - 1
        ''      Me.Wizard.GoTo(i)
        ''   Next
        ''   'returns to the original form that was being displayed
        ''   Me.Wizard.GoTo(originalIndex)
        ''   'constructs exporter object with latest SpecBuilder data
        ''   specExporter = New Exporter(Me.SpecData)
        ''   'builds a spec from the data passed
        ''   html = specExporter.BuildHtmlSpec()

        ''   Try
        ''      'exports outline
        ''      Exporter.WriteHtml(html, temporaryFilePath)
        ''   Catch fileInUseException As System.IO.IOException
        ''      Ui.MessageBox.Show(fileInUseException.Message & Environment.NewLine & Environment.NewLine & _
        ''         "Close untitled SpecBuilder Word documents, and try build again.", MessageBoxIcon.Warning)
        ''      Exit Sub
        ''   End Try

        ''   Try
        ''      'opens outline (usually if .doc then in Word, if .html then IE)
        ''      System.Diagnostics.Process.Start(temporaryFilePath)
        ''   Catch noApplicationException As System.ComponentModel.Win32Exception
        ''      Ui.MessageBox.Show(noApplicationException.Message, MessageBoxIcon.Warning)
        ''   End Try
        ''   'Exporter.OpenWordDoc(temporaryFilePath, MSWordPath)
        ''   '"C:\Program Files\Microsoft Office\OFFICE11\WINWORD.EXE"
        ''End Sub


        ''  Private Sub wordCommand_Click(ByVal sender As System.Object, _
        ''ByVal e As C1.Win.C1Command.ClickEventArgs) Handles wordCommand.Click
        ''   'Dim config As DeviceConfiguration

        ''   If Me.wordCommand.Checked Then
        ''      My.Settings.ExportExtension = "doc"
        ''      My.Settings.Save()
        ''      ''reads current configuration settings
        ''      'config = ConfigurationManager.ReadDeviceConfiguration()
        ''      ''sets export format
        ''      'config.SpecBuilderExportFormat = "doc"
        ''      ''writes changes to configuration file
        ''      'ConfigurationManager.WriteDeviceConfiguration(config)

        ''      'deselects previously selected menu item
        ''      Me.htmlCommand.Checked = False
        ''   End If
        ''End Sub


        ''  Private Sub htmlCommand_Click(ByVal sender As System.Object, _
        ''ByVal e As C1.Win.C1Command.ClickEventArgs) Handles htmlCommand.Click
        ''   'Dim config As DeviceConfiguration

        ''   If Me.htmlCommand.Checked Then
        ''      'reads current configuration settings
        ''      'config = ConfigurationManager.ReadDeviceConfiguration()
        ''      ''sets export format
        ''      'config.SpecBuilderExportFormat = "html"
        ''      ''writes changes to configuration file
        ''      'ConfigurationManager.WriteDeviceConfiguration(config)

        ''      My.Settings.ExportExtension = "html"
        ''      My.Settings.Save()
        ''      Me.wordCommand.Checked = False
        ''   End If
        ''End Sub


        ''  Private Sub closeCommand_Click(ByVal sender As System.Object, _
        ''ByVal e As C1.Win.C1Command.ClickEventArgs) Handles closeCommand.Click
        ''   Me.Close()
        ''End Sub


        Protected Overrides Sub Me_Closing(ByVal sender As Object,
      ByVal e As System.ComponentModel.CancelEventArgs)
            If Me.Wizard.Forms.Count <> 0 Then
                Dim message As String
                Dim result As DialogResult

                message = "Do you want to save before closing?"

                'asks user if they want to save before closing
                result = MessageBox.Show(message, "RAESolutions",
               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

                If result = Forms.DialogResult.Cancel Then
                    e.Cancel = True
                    Exit Sub
                ElseIf result = Forms.DialogResult.No Then
                    'do nothing
                ElseIf result = Forms.DialogResult.Yes Then
                    'saves current spec to file
                    Me.Save()
                End If
            End If

            'closes all forms in wizard
            Me.Wizard.Close()
        End Sub

#End Region


#Region " Private Methods"


        Private Sub SaveAs()
            Dim filePath As String
            Dim specFile As System.IO.FileInfo
            Dim i As Integer

            'gets file path selected by user to save to
            filePath = Me.GetUsersSaveFilePath()
            'exits subroutine, if save dialog was canceled
            If filePath = String.Empty Then Exit Sub
            ' sets file path property
            Me.FilePath = filePath

            'used to get the file name (not the entire path)
            specFile = New System.IO.FileInfo(filePath)
            'stores file name
            Me.SpecData.Name = specFile.Name
            'saves current spec to file
            SpecBuilder.SpecBuilderManager.SaveSpec(Me.SpecData, filePath)
            For i = 0 To Me.Wizard.Forms.Count - 1
                ' sets text in title bar
                CType(Me.Wizard.Forms(i), SpecBuilderWizardBase).SetText()
                ' sets file path property on all forms in wizard
                DirectCast(Me.Wizard.Forms(i), SpecBuilderWizardBase).FilePath = filePath
            Next
        End Sub


        Private Sub Save()
            If Me.FilePath <> String.Empty Then
                ' saves spec to file
                SpecBuilder.SpecBuilderManager.SaveSpec(Me.SpecData, Me.FilePath)
            Else
                ' saves spec to file and lets user set file path
                Me.SaveAs()
            End If
        End Sub




        Private Function GetUsersOpenFilePath() As String
            Dim filePath As String
            Dim result As DialogResult
            Dim specFileDialog As New OpenFileDialog

            With specFileDialog
                'sets default extension, if user doesn't type extension
                .DefaultExt = "rae.spec"
                'sets filters for viewing files by file extension type
                .Filter = "SpecBuilder files|*.rae.spec|All files|*.*"
            End With
            'shows open dialog and gets users result
            result = specFileDialog.ShowDialog()

            If result <> Forms.DialogResult.OK Then
                filePath = String.Empty
            Else
                'sets users chosen file path
                filePath = specFileDialog.FileName
            End If

            Return filePath
        End Function


        Private Function GetUsersSaveFilePath() As String
            Dim filePath As String
            Dim result As DialogResult
            Dim specFileDialog As New SaveFileDialog

            With specFileDialog
                'sets default extension, if user doesn't type extension
                .DefaultExt = "rae.spec"
                'sets filters for viewing files by file extension type
                .Filter = "SpecBuilder files|*.rae.spec|All files|*.*"
                .FileName = Me.SpecData.Name
            End With
            'shows open dialog and gets users result
            result = specFileDialog.ShowDialog()

            If result <> Forms.DialogResult.OK Then
                filePath = String.Empty
            Else
                'sets users chosen file path
                filePath = specFileDialog.FileName
            End If

            Return filePath
        End Function


        Protected Sub SetText()
            'SpecBuilder forms' tag property should be set to the name of the form
            'ex. filename.rae.spec - SpecBuilder - Compressor
            If Me.DesignMode Then Exit Sub
            If Me.SpecData IsNot Nothing Then
                Console.WriteLine("In SetText not null")
                Me.Text = Me.GenerateFormTitle(Me.SpecData.Name, Me.Tag.ToString)
            End If
        End Sub


        Protected Function GenerateFormTitle(ByVal filename As String, ByVal formTitle As String) As String
            Return filename & " - SpecBuilder - " & formTitle
        End Function

        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            ' gets a default specbuilder wizard
            Dim wiz As Rae.Wizard.Wizard = SpecBuilderManager.GetDefaultSpecBuilderWizard()
            For i As Integer = 0 To wiz.Forms.Count - 1
                ' sets mdi parent of each form in wizard
                wiz.Forms.Item(i).MdiParent = Me.MdiParent
            Next
            'starts default SpecBuilder
            wiz.Start()
        End Sub

        Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
            Dim filePath As String
            Dim specData As SpecBuilderData
            Dim wiz As Wizard.Wizard

            'gets user's open file path
            filePath = Me.GetUsersOpenFilePath()
            'exits, if open dialog was canceled
            If filePath = String.Empty Then Exit Sub

            'gets default wizard
            wiz = SpecBuilderManager.GetDefaultSpecBuilderWizard()
            For i As Integer = 0 To wiz.Forms.Count - 1
                ' sets mdiparent for each form
                wiz.Forms.Item(i).MdiParent = Me.MdiParent
                ' sets file path for each form
                DirectCast(wiz.Forms.Item(i), SpecBuilderWizardBase).FilePath = filePath
            Next
            'starts SpecBuilder
            wiz.Start()
            'sets SpecBuilder data to the data in file
            specData = SpecBuilderManager.GetExistingSpec(filePath)

            'fill controls with opened SpecBuilder data
            'unit
            With CType(wiz.Forms(0), UnitSpecBuilderWizard)
                .Text = .GenerateFormTitle(specData.Name, .Tag.ToString)
                .cboUnit.Text = specData.Unit
                .cboCoolingSolution.Text = specData.CoolingSolution
                .txtCoolingSolutionPercentage.Text = specData.SolutionPercentage
            End With

            'housing and piping
            With CType(wiz.Forms(1), HousingAndPipingSpecBuilderWizard)
                .cboBaseFrame.Text = specData.HousingAndPiping.BaseFrame
                .cboHousing.Text = specData.HousingAndPiping.Housing
                .chkEpoxyCoated.Checked = specData.HousingAndPiping.EpoxyCoated
                .cboPiping.Text = specData.HousingAndPiping.Piping
            End With

            'compressor
            With CType(wiz.Forms(2), CompressorSpecBuilderWizard)
                .cboCompressor.Text = specData.Compressor.Compressor
                .cboRefrigerant.Text = specData.Compressor.Refrigerant
                .radCylinderLoadingYes.Checked = specData.Compressor.CylinderLoading
                .cboCylinderLoading.Text = specData.Compressor.CylinderLoadingOption
                .cboModulation.Text = specData.Compressor.CapacitySlideValveModulation
            End With

            'evaporator
            With CType(wiz.Forms(3), EvaporatorSpecBuilderWizard)
                .cboEvaporator.Text = specData.Evaporator.Evaporator
                .cboPressure.Text = specData.Evaporator.Pressure
            End With

            'condenser
            With CType(wiz.Forms(4), CondenserSpecBuilderWizard)
                .cboCondenser.Text = specData.Condenser.Condenser
                'air-cooled
                .cboDesign.Text = specData.Condenser.CondenserDesign
                .cboFinMaterial.Text = specData.Condenser.FinMaterial
                .cboCasingsAndTubeSheets.Text = specData.Condenser.CasingsAndTubeSheets
                .cboTubeThickness.Text = specData.Condenser.TubeThickness
                .cboFinThickness.Text = specData.Condenser.FinThickness
                .cboCondenserType.Text = specData.Condenser.CondenserType
                .cboDischarge.Text = specData.Condenser.Discharge
                .chkRainHood.Checked = specData.Condenser.RainHood
                .radSubCoolingCircuitYes.Checked = specData.Condenser.SubCoolingCircuit
                .cboMotor.Text = specData.Condenser.Motor
                .cboLowAmbient.Text = specData.Condenser.LowAmbient
                .cboAmbient.Text = specData.Condenser.Ambient
                .chkFloodedCondenserControl.Checked = specData.Condenser.FloodedCondenserControl
                .chkHeatedAndInsulatedReceivers.Checked = specData.Condenser.HeatedAndInsulatedReceivers
                'water-cooled
                .radWaterValvesYes.Checked = specData.Condenser.WaterValves
                .cboHeatExchanger.Text = specData.Condenser.HeatExchanger
                'evaporative-cooled
                .cboMaterial.Text = specData.Condenser.Material
                .cboHeadPressure.Text = specData.Condenser.HeadPressure
                .cboCoil.Text = specData.Condenser.Coil
                .chkAcousticAttenuatorsIntake.Checked = specData.Condenser.AcousticAttenuatorsIntake
                .chkAcousticAttenuatorsDischarge.Checked = specData.Condenser.AcousticAttenuatorsDischarge
            End With

            'refrigerant circuit
            With CType(wiz.Forms(5), RefrigerantSpecBuilderWizard)
                .radSolenoidYes.Checked = specData.Refrigerant.Solenoid
                .radFilterYes.Checked = specData.Refrigerant.FilterDrier
                .cboFilterDrier.Text = specData.Refrigerant.FilterDrierType
                .cboExpansionValve.Text = specData.Refrigerant.ExpansionValve
                .chkPressureReliefHigh.Checked = specData.Refrigerant.PressureReliefHigh
                .chkPressureReliefLow.Checked = specData.Refrigerant.PressureReliefLow
                .cboSuctionAccumulators.Text = specData.Refrigerant.SuctionAccumulators
                .radDischargeMufflerYes.Checked = specData.Refrigerant.HotGasDischargeMuffler
                .radOilSeperatorYes.Checked = specData.Refrigerant.OilSeperator
                .radSuctionFilterYes.Checked = specData.Refrigerant.SuctionFilter
                .cboSuctionFilter.Text = specData.Refrigerant.SuctionFilterType
                .cboVibratorbers.Text = specData.Refrigerant.Vibratorbers
                .radHotGasBypassYes.Checked = specData.Refrigerant.HotGasBypass
                .cboHotGasBypass.Text = specData.Refrigerant.HotGasBypassDesign
                .cboHotGasBypassTons.Text = specData.Refrigerant.HotGasBypassTons
                .cboLiquidReceiver.Text = specData.Refrigerant.LiquidReceiver
                .chkLiquidReceiverHandValves.Checked = specData.Refrigerant.LiquidReceiverHandValves
            End With

            'controls circuit
            With CType(wiz.Forms(6), ControlsSpecBuilderWizard)
                .cboControls.Text = specData.Controls.ControlsType
                .cboPowerConnection.Text = specData.Controls.PowerConnection
                .radDisconnectOptionYes.Checked = specData.Controls.DisconnectOption
                .cboDisconnectOption.Text = specData.Controls.DisconnectOptionType
                .chkCompressorStatusLight.Checked = specData.Controls.CompressorStatusLight
                .chkFailureStatusLight.Checked = specData.Controls.FailureStatusLight
                .chkPumpStatusLight.Checked = specData.Controls.PumpStatusLight
                .radDisconnectSwitchYes.Checked = specData.Controls.MoldedCaseDisconnectSwitch
                .cboCompressorLeadLagSwitch.Text = specData.Controls.CompressorLeadLagSwitch
                .radUnitPhaseMonitorYes.Checked = specData.Controls.UnitPhaseMonitor
                .cboUnitPhaseMonitorScope.Text = specData.Controls.UnitPhaseMonitorScope
                .radRefrigerantAndOilGaugesYes.Checked = specData.Controls.RefrigerantAndOilGauges
                .radLcdYes.Checked = specData.Controls.Lcd
                .chkLcdDemandLimitingSetpoint.Checked = specData.Controls.LcdDemandLimitingSetPoint
                .chkLcdChilledWaterSetpoint.Checked = specData.Controls.LcdChilledWaterSetPoint
                .chkLcdCompressorAmps.Checked = specData.Controls.LcdCompressorAmps
                .chkLcdCompressorStatus.Checked = specData.Controls.LcdCompressorStatus
                .chkLcdRefrigerantDischarge.Checked = specData.Controls.LcdRefrigerantDischargePressureAndTemperature
                .chkLcdRefrigerantSuction.Checked = specData.Controls.LcdRefrigerantSuctionPressureAndTemperature
                .chkLcdFailureAndAlarmHistory.Checked = specData.Controls.LcdFailureAndAlarmHistory
                .chkLcdWaterTemperatures.Checked = specData.Controls.LcdWaterTemperatures
            End With

            With CType(wiz.Forms(7), PumpSpecBuilderWizard)
                .chkPumpPackage.Checked = specData.Pump.PumpPackage
                .cboDesignCriteria.Text = specData.Pump.DesignCriteria
                .cboDesignCriteriaDualOption.Text = specData.Pump.DesignCriteriaDualOption
                .cboPackage.Text = specData.Pump.PackageDesign
                .cboSpeed.Text = specData.Pump.Speed
                .cboType.Text = specData.Pump.PumpType
                .chkAirSeperator.Checked = specData.Pump.AirSeperator
                .cboAirSeperator.Text = specData.Pump.AirSeperatorDesign
                .chkExpansionTank.Checked = specData.Pump.ExpansionTank
                .cboExpansionTankType.Text = specData.Pump.ExpansionTankType
                .cboSuctionStrainer.Text = specData.Pump.SuctionStrainer
                .cboSuctionTrim.Text = specData.Pump.SuctionTrim
                .chkStorageTank.Checked = specData.Pump.StorageTank
                .cboStorageTankType.Text = specData.Pump.StorageTankType
                .txtStorageTankVolume.Text = specData.Pump.StorageTankVolume
                .cboStorageRatingAsm.Text = specData.Pump.StorageTankRatingAsm
                .cboStorageTankRatingPsi.Text = specData.Pump.StorageTankRatingPsi
            End With

            With CType(wiz.Forms(8), HazardSpecBuilderWizard)
                .chkHazard.Checked = specData.Hazard.Hazard
                .cboStructuralBase.Text = specData.Hazard.StructuralBase
                .cboCondenserCasings.Text = specData.Hazard.CondenserCasings
                .cboCondenserFins.Text = specData.Hazard.CondenserFins
                .cboControlEnclosure.Text = specData.Hazard.ControlEnclosure
                .chkHazardousDutyClassification.Checked = specData.Hazard.HazardousDutyClassification
            End With

            With CType(wiz.Forms(9), AcousticSpecBuilderWizard)
                .chkAcoustic.Checked = specData.Acoustic.Acoustic
                .chkCompressors.Checked = specData.Acoustic.Compressors
                .cboCovering.Text = specData.Acoustic.CompressorCovering
                .chkSpringIsolators.Checked = specData.Acoustic.CompressorSpringIsolator
                .chkCondenserFans.Checked = specData.Acoustic.CondenserFans
                .cboFanType.Text = specData.Acoustic.CondenserFanType
                .chkShroud.Checked = specData.Acoustic.CondenserShroud
            End With

            With CType(wiz.Forms(10), OtherSpecBuilderWizard)
                .chkWatersideEconomizer.Checked = specData.Other.WatersideEconomizer
                .chkAdditionalWarranty.Checked = specData.Other.AdditionalWarranty
                .chkSupervisedStartup.Checked = specData.Other.SupervisedStartup
            End With
            'MAINTAIN: add code to open new SpecBuilder data here

        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            'saves current spec to file
            Me.Save()
        End Sub

        Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
            Me.SaveAs()
        End Sub

        Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
            Dim i, originalIndex As Integer
            Dim html As String
            Dim specExporter As Exporter
            Dim temporaryFilePath, fileName As String

            'removes the file extension (.spec)
            fileName = System.IO.Path.GetFileNameWithoutExtension(Me.SpecData.Name)
            'removes the file extension (.rae)
            fileName = System.IO.Path.GetFileNameWithoutExtension(fileName)
            'adds extension
            If Me.htmlCommand Then
                fileName &= ".html"
            Else
                fileName &= ".doc"
            End If
            'combines file name with file path
            temporaryFilePath = System.IO.Path.Combine(Application.LocalUserAppDataPath, fileName)

            'gets the original index before all the forms are iterated through
            originalIndex = Me.Wizard.CurrentIndex
            'steps through each form so that all business logic is ran in order
            For i = 0 To Me.Wizard.Forms.Count - 1
                Me.Wizard.GoTo(i)
            Next
            'returns to the original form that was being displayed
            Me.Wizard.GoTo(originalIndex)
            'constructs exporter object with latest SpecBuilder data
            specExporter = New Exporter(Me.SpecData)
            'builds a spec from the data passed
            html = specExporter.BuildHtmlSpec()

            Try
                'exports outline
                Exporter.WriteHtml(html, temporaryFilePath)
            Catch fileInUseException As System.IO.IOException
                Ui.MessageBox.Show(fileInUseException.Message & Environment.NewLine & Environment.NewLine &
                   "Close untitled SpecBuilder Word documents, and try build again.", MessageBoxIcon.Warning)
                Exit Sub
            End Try

            Try
                'opens outline (usually if .doc then in Word, if .html then IE)
                System.Diagnostics.Process.Start(temporaryFilePath)
            Catch noApplicationException As System.ComponentModel.Win32Exception
                Ui.MessageBox.Show(noApplicationException.Message, MessageBoxIcon.Warning)
            End Try
            'Exporter.OpenWordDoc(temporaryFilePath, MSWordPath)
            '"C:\Program Files\Microsoft Office\OFFICE11\WINWORD.EXE"
        End Sub

        Private Sub HTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem.Click
            'Dim config As DeviceConfiguration

            If Me.htmlCommand Then
                'reads current configuration settings
                'config = ConfigurationManager.ReadDeviceConfiguration()
                ''sets export format
                'config.SpecBuilderExportFormat = "html"
                ''writes changes to configuration file
                'ConfigurationManager.WriteDeviceConfiguration(config)

                My.Settings.ExportExtension = "html"
                My.Settings.Save()
                Me.wordCommand = False
                Me.ToolStripLabel1.Text = "HTML"
            End If
        End Sub

        Private Sub MSWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MSWordToolStripMenuItem.Click
            'Dim config As DeviceConfiguration

            If Me.wordCommand Then
                My.Settings.ExportExtension = "doc"
                My.Settings.Save()
                ''reads current configuration settings
                'config = ConfigurationManager.ReadDeviceConfiguration()
                ''sets export format
                'config.SpecBuilderExportFormat = "doc"
                ''writes changes to configuration file
                'ConfigurationManager.WriteDeviceConfiguration(config)

                'deselects previously selected menu item
                Me.htmlCommand = False
                Me.ToolStripLabel1.Text = "MS Word"
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub


#End Region


        ''Private Sub saveAsCommand_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) _
        ''Handles saveAsCommand.Click
        ''   Me.SaveAs()
        ''End Sub


    End Class

End Namespace