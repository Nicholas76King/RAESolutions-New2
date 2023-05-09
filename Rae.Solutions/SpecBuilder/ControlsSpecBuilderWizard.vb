Namespace SpecBuilder

   Public Class ControlsSpecBuilderWizard
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
      Friend WithEvents cboControls As System.Windows.Forms.ComboBox
      Friend WithEvents lblControlsLabel As System.Windows.Forms.Label
      Friend WithEvents cboPowerConnection As System.Windows.Forms.ComboBox
      Friend WithEvents lblPowerConnectionLabel As System.Windows.Forms.Label
      Friend WithEvents lblDisconnectOptionLabel As System.Windows.Forms.Label
      Friend WithEvents radDisconnectOptionYes As System.Windows.Forms.RadioButton
      Friend WithEvents radDisconnectOptionNo As System.Windows.Forms.RadioButton
      Friend WithEvents cboDisconnectOption As System.Windows.Forms.ComboBox
      Friend WithEvents lblIndicatingLightsLabel As System.Windows.Forms.Label
      Friend WithEvents chkCompressorStatusLight As System.Windows.Forms.CheckBox
      Friend WithEvents chkFailureStatusLight As System.Windows.Forms.CheckBox
      Friend WithEvents chkPumpStatusLight As System.Windows.Forms.CheckBox
      Friend WithEvents lblDisconnectSwitchLabel As System.Windows.Forms.Label
      Friend WithEvents radDisconnectSwitchYes As System.Windows.Forms.RadioButton
      Friend WithEvents radDisconnectSwitchNo As System.Windows.Forms.RadioButton
      Friend WithEvents lblCompressorLeadLagSwitchLabel As System.Windows.Forms.Label
      Friend WithEvents cboCompressorLeadLagSwitch As System.Windows.Forms.ComboBox
      Friend WithEvents radUnitPhaseMonitorNo As System.Windows.Forms.RadioButton
      Friend WithEvents radUnitPhaseMonitorYes As System.Windows.Forms.RadioButton
      Friend WithEvents lblUnitPhaseMonitorLabel As System.Windows.Forms.Label
      Friend WithEvents cboUnitPhaseMonitorScope As System.Windows.Forms.ComboBox
      Friend WithEvents lblRefrigerantAndOilGaugesLabel As System.Windows.Forms.Label
      Friend WithEvents panDisconnectOption As System.Windows.Forms.Panel
      Friend WithEvents panDisconnectSwitch As System.Windows.Forms.Panel
      Friend WithEvents panUnitPhaseMonitor As System.Windows.Forms.Panel
      Friend WithEvents panRefrigerantAndOilGauges As System.Windows.Forms.Panel
      Friend WithEvents radRefrigerantAndOilGaugesYes As System.Windows.Forms.RadioButton
      Friend WithEvents radRefrigerantAndOilGaugesNo As System.Windows.Forms.RadioButton
      Friend WithEvents lblLcdLabel As System.Windows.Forms.Label
      Friend WithEvents chkLcdDemandLimitingSetpoint As System.Windows.Forms.CheckBox
      Friend WithEvents panLcd As System.Windows.Forms.Panel
      Friend WithEvents radLcdYes As System.Windows.Forms.RadioButton
      Friend WithEvents radLcdNo As System.Windows.Forms.RadioButton
      Friend WithEvents chkLcdCompressorAmps As System.Windows.Forms.CheckBox
      Friend WithEvents chkLcdCompressorStatus As System.Windows.Forms.CheckBox
      Friend WithEvents chkLcdChilledWaterSetpoint As System.Windows.Forms.CheckBox
      Friend WithEvents chkLcdRefrigerantDischarge As System.Windows.Forms.CheckBox
      Friend WithEvents chkLcdRefrigerantSuction As System.Windows.Forms.CheckBox
      Friend WithEvents chkLcdWaterTemperatures As System.Windows.Forms.CheckBox
      Friend WithEvents panLcdOptions As System.Windows.Forms.Panel
      Friend WithEvents chkLcdFailureAndAlarmHistory As System.Windows.Forms.CheckBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.cboControls = New System.Windows.Forms.ComboBox
         Me.lblControlsLabel = New System.Windows.Forms.Label
         Me.cboPowerConnection = New System.Windows.Forms.ComboBox
         Me.lblPowerConnectionLabel = New System.Windows.Forms.Label
         Me.lblDisconnectOptionLabel = New System.Windows.Forms.Label
         Me.radDisconnectOptionYes = New System.Windows.Forms.RadioButton
         Me.radDisconnectOptionNo = New System.Windows.Forms.RadioButton
         Me.cboDisconnectOption = New System.Windows.Forms.ComboBox
         Me.lblIndicatingLightsLabel = New System.Windows.Forms.Label
         Me.chkCompressorStatusLight = New System.Windows.Forms.CheckBox
         Me.chkFailureStatusLight = New System.Windows.Forms.CheckBox
         Me.chkPumpStatusLight = New System.Windows.Forms.CheckBox
         Me.lblDisconnectSwitchLabel = New System.Windows.Forms.Label
         Me.radDisconnectSwitchYes = New System.Windows.Forms.RadioButton
         Me.radDisconnectSwitchNo = New System.Windows.Forms.RadioButton
         Me.lblCompressorLeadLagSwitchLabel = New System.Windows.Forms.Label
         Me.cboCompressorLeadLagSwitch = New System.Windows.Forms.ComboBox
         Me.radUnitPhaseMonitorNo = New System.Windows.Forms.RadioButton
         Me.radUnitPhaseMonitorYes = New System.Windows.Forms.RadioButton
         Me.lblUnitPhaseMonitorLabel = New System.Windows.Forms.Label
         Me.cboUnitPhaseMonitorScope = New System.Windows.Forms.ComboBox
         Me.lblRefrigerantAndOilGaugesLabel = New System.Windows.Forms.Label
         Me.panDisconnectOption = New System.Windows.Forms.Panel
         Me.panDisconnectSwitch = New System.Windows.Forms.Panel
         Me.panUnitPhaseMonitor = New System.Windows.Forms.Panel
         Me.panRefrigerantAndOilGauges = New System.Windows.Forms.Panel
         Me.radRefrigerantAndOilGaugesYes = New System.Windows.Forms.RadioButton
         Me.radRefrigerantAndOilGaugesNo = New System.Windows.Forms.RadioButton
         Me.lblLcdLabel = New System.Windows.Forms.Label
         Me.chkLcdDemandLimitingSetpoint = New System.Windows.Forms.CheckBox
         Me.panLcd = New System.Windows.Forms.Panel
         Me.radLcdYes = New System.Windows.Forms.RadioButton
         Me.radLcdNo = New System.Windows.Forms.RadioButton
         Me.chkLcdCompressorAmps = New System.Windows.Forms.CheckBox
         Me.chkLcdCompressorStatus = New System.Windows.Forms.CheckBox
         Me.chkLcdChilledWaterSetpoint = New System.Windows.Forms.CheckBox
         Me.chkLcdRefrigerantDischarge = New System.Windows.Forms.CheckBox
         Me.chkLcdFailureAndAlarmHistory = New System.Windows.Forms.CheckBox
         Me.chkLcdRefrigerantSuction = New System.Windows.Forms.CheckBox
         Me.chkLcdWaterTemperatures = New System.Windows.Forms.CheckBox
         Me.panLcdOptions = New System.Windows.Forms.Panel
         Me.panMain.SuspendLayout()
         Me.panDisconnectOption.SuspendLayout()
         Me.panDisconnectSwitch.SuspendLayout()
         Me.panUnitPhaseMonitor.SuspendLayout()
         Me.panRefrigerantAndOilGauges.SuspendLayout()
         Me.panLcd.SuspendLayout()
         Me.panLcdOptions.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.AutoScroll = True
         Me.panMain.Controls.Add(Me.panLcdOptions)
         Me.panMain.Controls.Add(Me.panLcd)
         Me.panMain.Controls.Add(Me.lblLcdLabel)
         Me.panMain.Controls.Add(Me.panRefrigerantAndOilGauges)
         Me.panMain.Controls.Add(Me.panUnitPhaseMonitor)
         Me.panMain.Controls.Add(Me.panDisconnectSwitch)
         Me.panMain.Controls.Add(Me.panDisconnectOption)
         Me.panMain.Controls.Add(Me.lblRefrigerantAndOilGaugesLabel)
         Me.panMain.Controls.Add(Me.cboUnitPhaseMonitorScope)
         Me.panMain.Controls.Add(Me.lblUnitPhaseMonitorLabel)
         Me.panMain.Controls.Add(Me.cboCompressorLeadLagSwitch)
         Me.panMain.Controls.Add(Me.lblCompressorLeadLagSwitchLabel)
         Me.panMain.Controls.Add(Me.lblDisconnectSwitchLabel)
         Me.panMain.Controls.Add(Me.chkPumpStatusLight)
         Me.panMain.Controls.Add(Me.chkFailureStatusLight)
         Me.panMain.Controls.Add(Me.chkCompressorStatusLight)
         Me.panMain.Controls.Add(Me.lblIndicatingLightsLabel)
         Me.panMain.Controls.Add(Me.cboDisconnectOption)
         Me.panMain.Controls.Add(Me.lblDisconnectOptionLabel)
         Me.panMain.Controls.Add(Me.lblPowerConnectionLabel)
         Me.panMain.Controls.Add(Me.cboPowerConnection)
         Me.panMain.Controls.Add(Me.lblControlsLabel)
         Me.panMain.Controls.Add(Me.cboControls)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.cboControls, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblControlsLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboPowerConnection, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblPowerConnectionLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblDisconnectOptionLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboDisconnectOption, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblIndicatingLightsLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkCompressorStatusLight, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkFailureStatusLight, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkPumpStatusLight, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblDisconnectSwitchLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblCompressorLeadLagSwitchLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboCompressorLeadLagSwitch, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblUnitPhaseMonitorLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboUnitPhaseMonitorScope, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblRefrigerantAndOilGaugesLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.panDisconnectOption, 0)
         Me.panMain.Controls.SetChildIndex(Me.panDisconnectSwitch, 0)
         Me.panMain.Controls.SetChildIndex(Me.panUnitPhaseMonitor, 0)
         Me.panMain.Controls.SetChildIndex(Me.panRefrigerantAndOilGauges, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblLcdLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.panLcd, 0)
         Me.panMain.Controls.SetChildIndex(Me.panLcdOptions, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'cboControls
         '
         Me.cboControls.Items.AddRange(New Object() {"Electronic", "DDC Controls"})
         Me.cboControls.Location = New System.Drawing.Point(232, 20)
         Me.cboControls.Name = "cboControls"
         Me.cboControls.Size = New System.Drawing.Size(152, 21)
         Me.cboControls.TabIndex = 2
         Me.cboControls.Text = "Electronic"
         '
         'lblControlsLabel
         '
         Me.lblControlsLabel.Location = New System.Drawing.Point(32, 20)
         Me.lblControlsLabel.Name = "lblControlsLabel"
         Me.lblControlsLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblControlsLabel.TabIndex = 3
         Me.lblControlsLabel.Text = "Controls"
         Me.lblControlsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboPowerConnection
         '
         Me.cboPowerConnection.Items.AddRange(New Object() {"Single Point", "Dual Point"})
         Me.cboPowerConnection.Location = New System.Drawing.Point(232, 48)
         Me.cboPowerConnection.Name = "cboPowerConnection"
         Me.cboPowerConnection.Size = New System.Drawing.Size(152, 21)
         Me.cboPowerConnection.TabIndex = 4
         Me.cboPowerConnection.Text = "Single Point"
         '
         'lblPowerConnectionLabel
         '
         Me.lblPowerConnectionLabel.Location = New System.Drawing.Point(32, 48)
         Me.lblPowerConnectionLabel.Name = "lblPowerConnectionLabel"
         Me.lblPowerConnectionLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblPowerConnectionLabel.TabIndex = 5
         Me.lblPowerConnectionLabel.Text = "Power connection"
         Me.lblPowerConnectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblDisconnectOptionLabel
         '
         Me.lblDisconnectOptionLabel.Location = New System.Drawing.Point(32, 76)
         Me.lblDisconnectOptionLabel.Name = "lblDisconnectOptionLabel"
         Me.lblDisconnectOptionLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblDisconnectOptionLabel.TabIndex = 6
         Me.lblDisconnectOptionLabel.Text = "Disconnect option"
         Me.lblDisconnectOptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'radDisconnectOptionYes
         '
         Me.radDisconnectOptionYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radDisconnectOptionYes.Location = New System.Drawing.Point(0, 4)
         Me.radDisconnectOptionYes.Name = "radDisconnectOptionYes"
         Me.radDisconnectOptionYes.Size = New System.Drawing.Size(64, 24)
         Me.radDisconnectOptionYes.TabIndex = 7
         Me.radDisconnectOptionYes.Text = "Yes"
         '
         'radDisconnectOptionNo
         '
         Me.radDisconnectOptionNo.Checked = True
         Me.radDisconnectOptionNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radDisconnectOptionNo.Location = New System.Drawing.Point(68, 4)
         Me.radDisconnectOptionNo.Name = "radDisconnectOptionNo"
         Me.radDisconnectOptionNo.Size = New System.Drawing.Size(60, 24)
         Me.radDisconnectOptionNo.TabIndex = 8
         Me.radDisconnectOptionNo.TabStop = True
         Me.radDisconnectOptionNo.Text = "No"
         '
         'cboDisconnectOption
         '
         Me.cboDisconnectOption.Items.AddRange(New Object() {"Non-fused", "Fused"})
         Me.cboDisconnectOption.Location = New System.Drawing.Point(364, 76)
         Me.cboDisconnectOption.Name = "cboDisconnectOption"
         Me.cboDisconnectOption.Size = New System.Drawing.Size(140, 21)
         Me.cboDisconnectOption.TabIndex = 9
         Me.cboDisconnectOption.Text = "Non-fused"
         '
         'lblIndicatingLightsLabel
         '
         Me.lblIndicatingLightsLabel.Location = New System.Drawing.Point(32, 104)
         Me.lblIndicatingLightsLabel.Name = "lblIndicatingLightsLabel"
         Me.lblIndicatingLightsLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblIndicatingLightsLabel.TabIndex = 10
         Me.lblIndicatingLightsLabel.Text = "Indicating lights"
         Me.lblIndicatingLightsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkCompressorStatusLight
         '
         Me.chkCompressorStatusLight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkCompressorStatusLight.Location = New System.Drawing.Point(232, 104)
         Me.chkCompressorStatusLight.Name = "chkCompressorStatusLight"
         Me.chkCompressorStatusLight.Size = New System.Drawing.Size(128, 24)
         Me.chkCompressorStatusLight.TabIndex = 11
         Me.chkCompressorStatusLight.Text = "Compressor Status"
         '
         'chkFailureStatusLight
         '
         Me.chkFailureStatusLight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkFailureStatusLight.Location = New System.Drawing.Point(232, 128)
         Me.chkFailureStatusLight.Name = "chkFailureStatusLight"
         Me.chkFailureStatusLight.TabIndex = 12
         Me.chkFailureStatusLight.Text = "Failure Status"
         '
         'chkPumpStatusLight
         '
         Me.chkPumpStatusLight.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkPumpStatusLight.Location = New System.Drawing.Point(232, 152)
         Me.chkPumpStatusLight.Name = "chkPumpStatusLight"
         Me.chkPumpStatusLight.TabIndex = 13
         Me.chkPumpStatusLight.Text = "Pump Status"
         '
         'lblDisconnectSwitchLabel
         '
         Me.lblDisconnectSwitchLabel.Location = New System.Drawing.Point(32, 180)
         Me.lblDisconnectSwitchLabel.Name = "lblDisconnectSwitchLabel"
         Me.lblDisconnectSwitchLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblDisconnectSwitchLabel.TabIndex = 14
         Me.lblDisconnectSwitchLabel.Text = "Molded case disconnect switch"
         Me.lblDisconnectSwitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'radDisconnectSwitchYes
         '
         Me.radDisconnectSwitchYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radDisconnectSwitchYes.Location = New System.Drawing.Point(4, 4)
         Me.radDisconnectSwitchYes.Name = "radDisconnectSwitchYes"
         Me.radDisconnectSwitchYes.Size = New System.Drawing.Size(60, 24)
         Me.radDisconnectSwitchYes.TabIndex = 15
         Me.radDisconnectSwitchYes.Text = "Yes"
         '
         'radDisconnectSwitchNo
         '
         Me.radDisconnectSwitchNo.Checked = True
         Me.radDisconnectSwitchNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radDisconnectSwitchNo.Location = New System.Drawing.Point(72, 4)
         Me.radDisconnectSwitchNo.Name = "radDisconnectSwitchNo"
         Me.radDisconnectSwitchNo.Size = New System.Drawing.Size(60, 24)
         Me.radDisconnectSwitchNo.TabIndex = 16
         Me.radDisconnectSwitchNo.TabStop = True
         Me.radDisconnectSwitchNo.Text = "No"
         '
         'lblCompressorLeadLagSwitchLabel
         '
         Me.lblCompressorLeadLagSwitchLabel.Location = New System.Drawing.Point(32, 208)
         Me.lblCompressorLeadLagSwitchLabel.Name = "lblCompressorLeadLagSwitchLabel"
         Me.lblCompressorLeadLagSwitchLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblCompressorLeadLagSwitchLabel.TabIndex = 17
         Me.lblCompressorLeadLagSwitchLabel.Text = "Compressor lead-lag switch"
         Me.lblCompressorLeadLagSwitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboCompressorLeadLagSwitch
         '
         Me.cboCompressorLeadLagSwitch.Items.AddRange(New Object() {"Manual", "Auto"})
         Me.cboCompressorLeadLagSwitch.Location = New System.Drawing.Point(232, 208)
         Me.cboCompressorLeadLagSwitch.Name = "cboCompressorLeadLagSwitch"
         Me.cboCompressorLeadLagSwitch.Size = New System.Drawing.Size(152, 21)
         Me.cboCompressorLeadLagSwitch.TabIndex = 18
         Me.cboCompressorLeadLagSwitch.Text = "Manual"
         '
         'radUnitPhaseMonitorNo
         '
         Me.radUnitPhaseMonitorNo.Checked = True
         Me.radUnitPhaseMonitorNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radUnitPhaseMonitorNo.Location = New System.Drawing.Point(72, 4)
         Me.radUnitPhaseMonitorNo.Name = "radUnitPhaseMonitorNo"
         Me.radUnitPhaseMonitorNo.Size = New System.Drawing.Size(60, 24)
         Me.radUnitPhaseMonitorNo.TabIndex = 20
         Me.radUnitPhaseMonitorNo.TabStop = True
         Me.radUnitPhaseMonitorNo.Text = "No"
         '
         'radUnitPhaseMonitorYes
         '
         Me.radUnitPhaseMonitorYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radUnitPhaseMonitorYes.Location = New System.Drawing.Point(4, 4)
         Me.radUnitPhaseMonitorYes.Name = "radUnitPhaseMonitorYes"
         Me.radUnitPhaseMonitorYes.Size = New System.Drawing.Size(60, 24)
         Me.radUnitPhaseMonitorYes.TabIndex = 19
         Me.radUnitPhaseMonitorYes.Text = "Yes"
         '
         'lblUnitPhaseMonitorLabel
         '
         Me.lblUnitPhaseMonitorLabel.Location = New System.Drawing.Point(32, 236)
         Me.lblUnitPhaseMonitorLabel.Name = "lblUnitPhaseMonitorLabel"
         Me.lblUnitPhaseMonitorLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblUnitPhaseMonitorLabel.TabIndex = 21
         Me.lblUnitPhaseMonitorLabel.Text = "Unit phase monitor"
         Me.lblUnitPhaseMonitorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboUnitPhaseMonitorScope
         '
         Me.cboUnitPhaseMonitorScope.Items.AddRange(New Object() {"For Entire Unit", "Per Compressor"})
         Me.cboUnitPhaseMonitorScope.Location = New System.Drawing.Point(364, 236)
         Me.cboUnitPhaseMonitorScope.Name = "cboUnitPhaseMonitorScope"
         Me.cboUnitPhaseMonitorScope.Size = New System.Drawing.Size(140, 21)
         Me.cboUnitPhaseMonitorScope.TabIndex = 22
         Me.cboUnitPhaseMonitorScope.Text = "For Entire Unit"
         '
         'lblRefrigerantAndOilGaugesLabel
         '
         Me.lblRefrigerantAndOilGaugesLabel.Location = New System.Drawing.Point(32, 264)
         Me.lblRefrigerantAndOilGaugesLabel.Name = "lblRefrigerantAndOilGaugesLabel"
         Me.lblRefrigerantAndOilGaugesLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblRefrigerantAndOilGaugesLabel.TabIndex = 23
         Me.lblRefrigerantAndOilGaugesLabel.Text = "Refrigerant and oil gauges"
         Me.lblRefrigerantAndOilGaugesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'panDisconnectOption
         '
         Me.panDisconnectOption.Controls.Add(Me.radDisconnectOptionYes)
         Me.panDisconnectOption.Controls.Add(Me.radDisconnectOptionNo)
         Me.panDisconnectOption.Location = New System.Drawing.Point(232, 72)
         Me.panDisconnectOption.Name = "panDisconnectOption"
         Me.panDisconnectOption.Size = New System.Drawing.Size(132, 32)
         Me.panDisconnectOption.TabIndex = 24
         '
         'panDisconnectSwitch
         '
         Me.panDisconnectSwitch.Controls.Add(Me.radDisconnectSwitchYes)
         Me.panDisconnectSwitch.Controls.Add(Me.radDisconnectSwitchNo)
         Me.panDisconnectSwitch.Location = New System.Drawing.Point(232, 176)
         Me.panDisconnectSwitch.Name = "panDisconnectSwitch"
         Me.panDisconnectSwitch.Size = New System.Drawing.Size(144, 32)
         Me.panDisconnectSwitch.TabIndex = 25
         '
         'panUnitPhaseMonitor
         '
         Me.panUnitPhaseMonitor.Controls.Add(Me.radUnitPhaseMonitorYes)
         Me.panUnitPhaseMonitor.Controls.Add(Me.radUnitPhaseMonitorNo)
         Me.panUnitPhaseMonitor.Location = New System.Drawing.Point(232, 232)
         Me.panUnitPhaseMonitor.Name = "panUnitPhaseMonitor"
         Me.panUnitPhaseMonitor.Size = New System.Drawing.Size(132, 32)
         Me.panUnitPhaseMonitor.TabIndex = 26
         '
         'panRefrigerantAndOilGauges
         '
         Me.panRefrigerantAndOilGauges.Controls.Add(Me.radRefrigerantAndOilGaugesYes)
         Me.panRefrigerantAndOilGauges.Controls.Add(Me.radRefrigerantAndOilGaugesNo)
         Me.panRefrigerantAndOilGauges.Location = New System.Drawing.Point(232, 260)
         Me.panRefrigerantAndOilGauges.Name = "panRefrigerantAndOilGauges"
         Me.panRefrigerantAndOilGauges.Size = New System.Drawing.Size(132, 32)
         Me.panRefrigerantAndOilGauges.TabIndex = 27
         '
         'radRefrigerantAndOilGaugesYes
         '
         Me.radRefrigerantAndOilGaugesYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radRefrigerantAndOilGaugesYes.Location = New System.Drawing.Point(4, 4)
         Me.radRefrigerantAndOilGaugesYes.Name = "radRefrigerantAndOilGaugesYes"
         Me.radRefrigerantAndOilGaugesYes.Size = New System.Drawing.Size(60, 24)
         Me.radRefrigerantAndOilGaugesYes.TabIndex = 19
         Me.radRefrigerantAndOilGaugesYes.Text = "Yes"
         '
         'radRefrigerantAndOilGaugesNo
         '
         Me.radRefrigerantAndOilGaugesNo.Checked = True
         Me.radRefrigerantAndOilGaugesNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radRefrigerantAndOilGaugesNo.Location = New System.Drawing.Point(72, 4)
         Me.radRefrigerantAndOilGaugesNo.Name = "radRefrigerantAndOilGaugesNo"
         Me.radRefrigerantAndOilGaugesNo.Size = New System.Drawing.Size(60, 24)
         Me.radRefrigerantAndOilGaugesNo.TabIndex = 20
         Me.radRefrigerantAndOilGaugesNo.TabStop = True
         Me.radRefrigerantAndOilGaugesNo.Text = "No"
         '
         'lblLcdLabel
         '
         Me.lblLcdLabel.Location = New System.Drawing.Point(32, 292)
         Me.lblLcdLabel.Name = "lblLcdLabel"
         Me.lblLcdLabel.Size = New System.Drawing.Size(184, 23)
         Me.lblLcdLabel.TabIndex = 28
         Me.lblLcdLabel.Text = "LCD"
         Me.lblLcdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkLcdDemandLimitingSetpoint
         '
         Me.chkLcdDemandLimitingSetpoint.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdDemandLimitingSetpoint.Location = New System.Drawing.Point(4, 4)
         Me.chkLcdDemandLimitingSetpoint.Name = "chkLcdDemandLimitingSetpoint"
         Me.chkLcdDemandLimitingSetpoint.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdDemandLimitingSetpoint.TabIndex = 29
         Me.chkLcdDemandLimitingSetpoint.Text = "Demand Limiting Setpoint"
         '
         'panLcd
         '
         Me.panLcd.Controls.Add(Me.radLcdYes)
         Me.panLcd.Controls.Add(Me.radLcdNo)
         Me.panLcd.Location = New System.Drawing.Point(232, 288)
         Me.panLcd.Name = "panLcd"
         Me.panLcd.Size = New System.Drawing.Size(132, 32)
         Me.panLcd.TabIndex = 30
         '
         'radLcdYes
         '
         Me.radLcdYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radLcdYes.Location = New System.Drawing.Point(4, 4)
         Me.radLcdYes.Name = "radLcdYes"
         Me.radLcdYes.Size = New System.Drawing.Size(60, 24)
         Me.radLcdYes.TabIndex = 19
         Me.radLcdYes.Text = "Yes"
         '
         'radLcdNo
         '
         Me.radLcdNo.Checked = True
         Me.radLcdNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radLcdNo.Location = New System.Drawing.Point(72, 4)
         Me.radLcdNo.Name = "radLcdNo"
         Me.radLcdNo.Size = New System.Drawing.Size(60, 24)
         Me.radLcdNo.TabIndex = 20
         Me.radLcdNo.TabStop = True
         Me.radLcdNo.Text = "No"
         '
         'chkLcdCompressorAmps
         '
         Me.chkLcdCompressorAmps.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdCompressorAmps.Location = New System.Drawing.Point(4, 52)
         Me.chkLcdCompressorAmps.Name = "chkLcdCompressorAmps"
         Me.chkLcdCompressorAmps.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdCompressorAmps.TabIndex = 31
         Me.chkLcdCompressorAmps.Text = "Compressor Operating Amps"
         '
         'chkLcdCompressorStatus
         '
         Me.chkLcdCompressorStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdCompressorStatus.Location = New System.Drawing.Point(4, 76)
         Me.chkLcdCompressorStatus.Name = "chkLcdCompressorStatus"
         Me.chkLcdCompressorStatus.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdCompressorStatus.TabIndex = 32
         Me.chkLcdCompressorStatus.Text = "Compressor Operating Status"
         '
         'chkLcdChilledWaterSetpoint
         '
         Me.chkLcdChilledWaterSetpoint.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdChilledWaterSetpoint.Location = New System.Drawing.Point(4, 28)
         Me.chkLcdChilledWaterSetpoint.Name = "chkLcdChilledWaterSetpoint"
         Me.chkLcdChilledWaterSetpoint.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdChilledWaterSetpoint.TabIndex = 33
         Me.chkLcdChilledWaterSetpoint.Text = "Chilled Water Setpoint"
         '
         'chkLcdRefrigerantDischarge
         '
         Me.chkLcdRefrigerantDischarge.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdRefrigerantDischarge.Location = New System.Drawing.Point(4, 100)
         Me.chkLcdRefrigerantDischarge.Name = "chkLcdRefrigerantDischarge"
         Me.chkLcdRefrigerantDischarge.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdRefrigerantDischarge.TabIndex = 34
         Me.chkLcdRefrigerantDischarge.Text = "Refrigerant Discharge Pressure and Temperature"
         '
         'chkLcdFailureAndAlarmHistory
         '
         Me.chkLcdFailureAndAlarmHistory.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdFailureAndAlarmHistory.Location = New System.Drawing.Point(4, 148)
         Me.chkLcdFailureAndAlarmHistory.Name = "chkLcdFailureAndAlarmHistory"
         Me.chkLcdFailureAndAlarmHistory.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdFailureAndAlarmHistory.TabIndex = 35
         Me.chkLcdFailureAndAlarmHistory.Text = "Failure Status and Alarm History"
         '
         'chkLcdRefrigerantSuction
         '
         Me.chkLcdRefrigerantSuction.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdRefrigerantSuction.Location = New System.Drawing.Point(4, 124)
         Me.chkLcdRefrigerantSuction.Name = "chkLcdRefrigerantSuction"
         Me.chkLcdRefrigerantSuction.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdRefrigerantSuction.TabIndex = 36
         Me.chkLcdRefrigerantSuction.Text = "Refrigerant Suction Pressure and Temperature"
         '
         'chkLcdWaterTemperatures
         '
         Me.chkLcdWaterTemperatures.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLcdWaterTemperatures.Location = New System.Drawing.Point(4, 172)
         Me.chkLcdWaterTemperatures.Name = "chkLcdWaterTemperatures"
         Me.chkLcdWaterTemperatures.Size = New System.Drawing.Size(280, 24)
         Me.chkLcdWaterTemperatures.TabIndex = 37
         Me.chkLcdWaterTemperatures.Text = "Supply and Return Water Temperatures"
         '
         'panLcdOptions
         '
         Me.panLcdOptions.Controls.Add(Me.chkLcdCompressorAmps)
         Me.panLcdOptions.Controls.Add(Me.chkLcdChilledWaterSetpoint)
         Me.panLcdOptions.Controls.Add(Me.chkLcdWaterTemperatures)
         Me.panLcdOptions.Controls.Add(Me.chkLcdRefrigerantDischarge)
         Me.panLcdOptions.Controls.Add(Me.chkLcdDemandLimitingSetpoint)
         Me.panLcdOptions.Controls.Add(Me.chkLcdFailureAndAlarmHistory)
         Me.panLcdOptions.Controls.Add(Me.chkLcdRefrigerantSuction)
         Me.panLcdOptions.Controls.Add(Me.chkLcdCompressorStatus)
         Me.panLcdOptions.Location = New System.Drawing.Point(232, 316)
         Me.panLcdOptions.Name = "panLcdOptions"
         Me.panLcdOptions.Size = New System.Drawing.Size(286, 210)
         Me.panLcdOptions.TabIndex = 38
         '
         'ControlsSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "ControlsSpecBuilderWizard"
         Me.Tag = "Controls"
         Me.Text = "Untitled - SpecBuilder - Controls"
         Me.panMain.ResumeLayout(False)
         Me.panDisconnectOption.ResumeLayout(False)
         Me.panDisconnectSwitch.ResumeLayout(False)
         Me.panUnitPhaseMonitor.ResumeLayout(False)
         Me.panRefrigerantAndOilGauges.ResumeLayout(False)
         Me.panLcd.ResumeLayout(False)
         Me.panLcdOptions.ResumeLayout(False)

      End Sub

#End Region


      Dim optManager As New OptionManager(SpecData)


      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilder.SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub


#Region " Event Handlers"

      Private Sub ControlsSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetDisconnectControls()
         Me.SetPumpControls()
         Me.SetCompressorLeadLagSwitch()
         Me.SetUnitPhaseMonitorScope()
         Me.SetLcd()
         Me.SetLcdOptions()
      End Sub


      Private Sub ControlsSpecBuilderWizard_VisibleChanged(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
         If Me.isDisposing Then Exit Sub
         Me.SetPumpControls()
      End Sub


      Private Sub cboControls_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboControls.SelectedIndexChanged
         Me.SpecData.Controls.ControlsType = Me.cboControls.Text

         Me.SetCompressorLeadLagSwitch()
         Me.SetLcd()
         Me.SetLcdOptions()
      End Sub

      Private Sub cboPowerConnection_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboPowerConnection.SelectedIndexChanged
         Me.SpecData.Controls.PowerConnection = Me.cboPowerConnection.Text
      End Sub

      Private Sub radDisconnectOptionYes_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles radDisconnectOptionYes.CheckedChanged
         Me.SpecData.Controls.DisconnectOption = Me.radDisconnectOptionYes.Checked

         Me.SetDisconnectControls()
      End Sub

      Private Sub cboDisconnectOption_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboDisconnectOption.SelectedIndexChanged
         Me.SpecData.Controls.DisconnectOptionType = Me.cboDisconnectOption.Text
      End Sub

      Private Sub chkCompressorStatusLight_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkCompressorStatusLight.CheckedChanged
         Me.SpecData.Controls.CompressorStatusLight = Me.chkCompressorStatusLight.Checked
      End Sub

      Private Sub chkFailureStatusLight_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkFailureStatusLight.CheckedChanged
         Me.SpecData.Controls.FailureStatusLight = Me.chkFailureStatusLight.Checked
      End Sub

      Private Sub chkPumpStatusLight_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkPumpStatusLight.CheckedChanged
         Me.SpecData.Controls.PumpStatusLight = Me.chkPumpStatusLight.Checked
      End Sub

      Private Sub radDisconnectSwitchYes_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles radDisconnectSwitchYes.CheckedChanged
         Me.SpecData.Controls.MoldedCaseDisconnectSwitch = _
            Me.radDisconnectSwitchYes.Checked
      End Sub

      Private Sub cboCompressorLeadLagSwitch_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboCompressorLeadLagSwitch.SelectedIndexChanged
         Me.SpecData.Controls.CompressorLeadLagSwitch = _
            Me.cboCompressorLeadLagSwitch.Text
      End Sub

      Private Sub radUnitPhaseMonitorYes_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles radUnitPhaseMonitorYes.CheckedChanged
         Me.SpecData.Controls.UnitPhaseMonitor = Me.radUnitPhaseMonitorYes.Checked

         Me.SetUnitPhaseMonitorScope()
      End Sub

      Private Sub cboUnitPhaseMonitorScope_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboUnitPhaseMonitorScope.SelectedIndexChanged
         Me.SpecData.Controls.UnitPhaseMonitorScope = _
            Me.cboUnitPhaseMonitorScope.Text
      End Sub

      Private Sub radRefrigerantAndOilGaugesYes_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles radRefrigerantAndOilGaugesYes.CheckedChanged
         Me.SpecData.Controls.RefrigerantAndOilGauges = _
            Me.radRefrigerantAndOilGaugesYes.Checked
      End Sub

      Private Sub radLcdYes_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles radLcdYes.CheckedChanged
         Me.SpecData.Controls.Lcd = Me.radLcdYes.Checked

         Me.SetLcdOptions()
      End Sub

      Private Sub chkLcdDemandLimitingSetpoint_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLcdDemandLimitingSetpoint.CheckedChanged
         Me.SpecData.Controls.LcdDemandLimitingSetPoint = _
            Me.chkLcdDemandLimitingSetpoint.Checked
      End Sub

      Private Sub chkLcdChilledWaterSetpoint_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLcdChilledWaterSetpoint.CheckedChanged
         Me.SpecData.Controls.LcdChilledWaterSetPoint = _
            Me.chkLcdChilledWaterSetpoint.Checked
      End Sub

      Private Sub chkLcdCompressorAmps_CheckedChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles chkLcdCompressorAmps.CheckedChanged
         Me.SpecData.Controls.LcdCompressorAmps = Me.chkLcdCompressorAmps.Checked
      End Sub

      Private Sub chkLcdCompressorStatus_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLcdCompressorStatus.CheckedChanged
         Me.SpecData.Controls.LcdCompressorStatus = Me.chkLcdCompressorStatus.Checked
      End Sub

      Private Sub chkLcdRefrigerantDischarge_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLcdRefrigerantDischarge.CheckedChanged
         Me.SpecData.Controls.LcdRefrigerantDischargePressureAndTemperature = _
            Me.chkLcdRefrigerantDischarge.Checked
      End Sub

      Private Sub chkLcdRefrigerantSuction_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLcdRefrigerantSuction.CheckedChanged
         Me.SpecData.Controls.LcdRefrigerantSuctionPressureAndTemperature = _
            Me.chkLcdRefrigerantSuction.Checked
      End Sub

      Private Sub chkLcdFailureAndAlarmHistory_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLcdFailureAndAlarmHistory.CheckedChanged
         Me.SpecData.Controls.LcdFailureAndAlarmHistory = _
            Me.chkLcdFailureAndAlarmHistory.Checked
      End Sub

      Private Sub chkLcdWaterTemperatures_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLcdWaterTemperatures.CheckedChanged
         Me.SpecData.Controls.LcdWaterTemperatures = _
            Me.chkLcdWaterTemperatures.Checked
      End Sub

#End Region


#Region " Set Controls"

      Private Sub SetDisconnectControls()
         If Me.optManager.GetDisconnectOptionType.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboDisconnectOption, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboDisconnectOption, _
               Me.tip, Me.optManager.GetDisconnectOptionType.Explanation)
         End If
      End Sub

      Private Sub SetPumpControls()
         If Me.optManager.GetPumpStatusLight.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.chkPumpStatusLight, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.chkPumpStatusLight, _
               Me.tip, Me.optManager.GetPumpStatusLight.Explanation)
         End If
      End Sub

      Private Sub SetCompressorLeadLagSwitch()
         If Me.optManager.GetCompressorLeadLagSwitch.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblCompressorLeadLagSwitchLabel, _
               Me.cboCompressorLeadLagSwitch, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblCompressorLeadLagSwitchLabel, _
               Me.cboCompressorLeadLagSwitch, Me.tip, _
               Me.optManager.GetCompressorLeadLagSwitch.Explanation)
         End If
      End Sub

      Private Sub SetUnitPhaseMonitorScope()
         If Me.optManager.GetUnitPhaseMonitorScope.IsOption Then
            SpecBuilderManager.EnableControls(New Label, _
               Me.cboUnitPhaseMonitorScope, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, _
               Me.cboUnitPhaseMonitorScope, Me.tip, _
               Me.optManager.GetUnitPhaseMonitorScope.Explanation)
         End If
      End Sub

      Private Sub SetLcd()
         If Me.optManager.GetLcd.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblLcdLabel, Me.radLcdYes, Me.tip)
            SpecBuilderManager.EnableControls(Me.lblLcdLabel, Me.radLcdNo, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblLcdLabel, Me.radLcdYes, _
               Me.tip, Me.optManager.GetLcd.Explanation)
            SpecBuilderManager.DisableControls(Me.lblLcdLabel, Me.radLcdNo, _
               Me.tip, Me.optManager.GetLcd.Explanation)
         End If

      End Sub

      Private Sub SetLcdOptions()
         Me.panLcdOptions.Enabled = Me.optManager.GetLcdOptions.IsOption
      End Sub

#End Region

      
   End Class

End Namespace
