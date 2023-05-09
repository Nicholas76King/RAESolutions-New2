Namespace SpecBuilder

   Public Class RefrigerantSpecBuilderWizard
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
      Friend WithEvents lblSolenoidLabel As System.Windows.Forms.Label
      Friend WithEvents radSolenoidYes As System.Windows.Forms.RadioButton
      Friend WithEvents radSolenoidNo As System.Windows.Forms.RadioButton
      Friend WithEvents lblFilterLabel As System.Windows.Forms.Label
      Friend WithEvents panSolenoid As System.Windows.Forms.Panel
      Friend WithEvents radFilterYes As System.Windows.Forms.RadioButton
      Friend WithEvents radFilterNo As System.Windows.Forms.RadioButton
      Friend WithEvents lblExpansionValveLabel As System.Windows.Forms.Label
      Friend WithEvents cboFilterDrier As System.Windows.Forms.ComboBox
      Friend WithEvents cboExpansionValve As System.Windows.Forms.ComboBox
      Friend WithEvents lblPressureReliefLabel As System.Windows.Forms.Label
      Friend WithEvents chkPressureReliefHigh As System.Windows.Forms.CheckBox
      Friend WithEvents chkPressureReliefLow As System.Windows.Forms.CheckBox
      Friend WithEvents lblSuctionAccumulatorsLabel As System.Windows.Forms.Label
      Friend WithEvents lblDischargeMufflerLabel As System.Windows.Forms.Label
      Friend WithEvents cboSuctionAccumulators As System.Windows.Forms.ComboBox
      Friend WithEvents lblSuctionAccumulatorNote As System.Windows.Forms.Label
      Friend WithEvents radDischargeMufflerNo As System.Windows.Forms.RadioButton
      Friend WithEvents radDischargeMufflerYes As System.Windows.Forms.RadioButton
      Friend WithEvents cboHotGasBypass As System.Windows.Forms.ComboBox
      Friend WithEvents panOilSeperator As System.Windows.Forms.Panel
      Friend WithEvents radOilSeperatorNo As System.Windows.Forms.RadioButton
      Friend WithEvents radOilSeperatorYes As System.Windows.Forms.RadioButton
      Friend WithEvents lblOilSeperatorLabel As System.Windows.Forms.Label
      Friend WithEvents lblSuctionFilterLabel As System.Windows.Forms.Label
      Friend WithEvents lblVibratorbersLabel As System.Windows.Forms.Label
      Friend WithEvents panSuctionFilter As System.Windows.Forms.Panel
      Friend WithEvents radSuctionFilterNo As System.Windows.Forms.RadioButton
      Friend WithEvents radSuctionFilterYes As System.Windows.Forms.RadioButton
      Friend WithEvents cboSuctionFilter As System.Windows.Forms.ComboBox
      Friend WithEvents cboVibratorbers As System.Windows.Forms.ComboBox
      Friend WithEvents panDischargeMuffler As System.Windows.Forms.Panel
      Friend WithEvents lblLiquidReceiverLabel As System.Windows.Forms.Label
      Friend WithEvents panHotGasBypass As System.Windows.Forms.Panel
      Friend WithEvents radHotGasBypassNo As System.Windows.Forms.RadioButton
      Friend WithEvents radHotGasBypassYes As System.Windows.Forms.RadioButton
      Friend WithEvents cboHotGasBypassTons As System.Windows.Forms.ComboBox
      Friend WithEvents cboLiquidReceiver As System.Windows.Forms.ComboBox
      Friend WithEvents chkLiquidReceiverHandValves As System.Windows.Forms.CheckBox
      Friend WithEvents panFilter As System.Windows.Forms.Panel
      Friend WithEvents lblHotGasBypassLabel As System.Windows.Forms.Label
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblSolenoidLabel = New System.Windows.Forms.Label
         Me.lblFilterLabel = New System.Windows.Forms.Label
         Me.lblExpansionValveLabel = New System.Windows.Forms.Label
         Me.lblPressureReliefLabel = New System.Windows.Forms.Label
         Me.lblSuctionAccumulatorsLabel = New System.Windows.Forms.Label
         Me.lblDischargeMufflerLabel = New System.Windows.Forms.Label
         Me.panSolenoid = New System.Windows.Forms.Panel
         Me.radSolenoidNo = New System.Windows.Forms.RadioButton
         Me.radSolenoidYes = New System.Windows.Forms.RadioButton
         Me.cboFilterDrier = New System.Windows.Forms.ComboBox
         Me.panFilter = New System.Windows.Forms.Panel
         Me.radFilterYes = New System.Windows.Forms.RadioButton
         Me.radFilterNo = New System.Windows.Forms.RadioButton
         Me.cboExpansionValve = New System.Windows.Forms.ComboBox
         Me.chkPressureReliefHigh = New System.Windows.Forms.CheckBox
         Me.chkPressureReliefLow = New System.Windows.Forms.CheckBox
         Me.cboSuctionAccumulators = New System.Windows.Forms.ComboBox
         Me.lblSuctionAccumulatorNote = New System.Windows.Forms.Label
         Me.panDischargeMuffler = New System.Windows.Forms.Panel
         Me.radDischargeMufflerNo = New System.Windows.Forms.RadioButton
         Me.radDischargeMufflerYes = New System.Windows.Forms.RadioButton
         Me.cboHotGasBypass = New System.Windows.Forms.ComboBox
         Me.panOilSeperator = New System.Windows.Forms.Panel
         Me.radOilSeperatorNo = New System.Windows.Forms.RadioButton
         Me.radOilSeperatorYes = New System.Windows.Forms.RadioButton
         Me.lblOilSeperatorLabel = New System.Windows.Forms.Label
         Me.lblSuctionFilterLabel = New System.Windows.Forms.Label
         Me.lblVibratorbersLabel = New System.Windows.Forms.Label
         Me.lblHotGasBypassLabel = New System.Windows.Forms.Label
         Me.lblLiquidReceiverLabel = New System.Windows.Forms.Label
         Me.panSuctionFilter = New System.Windows.Forms.Panel
         Me.radSuctionFilterNo = New System.Windows.Forms.RadioButton
         Me.radSuctionFilterYes = New System.Windows.Forms.RadioButton
         Me.cboSuctionFilter = New System.Windows.Forms.ComboBox
         Me.cboVibratorbers = New System.Windows.Forms.ComboBox
         Me.panHotGasBypass = New System.Windows.Forms.Panel
         Me.radHotGasBypassNo = New System.Windows.Forms.RadioButton
         Me.radHotGasBypassYes = New System.Windows.Forms.RadioButton
         Me.cboHotGasBypassTons = New System.Windows.Forms.ComboBox
         Me.cboLiquidReceiver = New System.Windows.Forms.ComboBox
         Me.chkLiquidReceiverHandValves = New System.Windows.Forms.CheckBox
         Me.panMain.SuspendLayout()
         Me.panSolenoid.SuspendLayout()
         Me.panFilter.SuspendLayout()
         Me.panDischargeMuffler.SuspendLayout()
         Me.panOilSeperator.SuspendLayout()
         Me.panSuctionFilter.SuspendLayout()
         Me.panHotGasBypass.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.AutoScroll = True
         Me.panMain.Controls.Add(Me.chkLiquidReceiverHandValves)
         Me.panMain.Controls.Add(Me.cboLiquidReceiver)
         Me.panMain.Controls.Add(Me.cboHotGasBypassTons)
         Me.panMain.Controls.Add(Me.panHotGasBypass)
         Me.panMain.Controls.Add(Me.cboVibratorbers)
         Me.panMain.Controls.Add(Me.cboSuctionFilter)
         Me.panMain.Controls.Add(Me.panSuctionFilter)
         Me.panMain.Controls.Add(Me.lblLiquidReceiverLabel)
         Me.panMain.Controls.Add(Me.lblHotGasBypassLabel)
         Me.panMain.Controls.Add(Me.lblVibratorbersLabel)
         Me.panMain.Controls.Add(Me.lblSuctionFilterLabel)
         Me.panMain.Controls.Add(Me.lblOilSeperatorLabel)
         Me.panMain.Controls.Add(Me.panOilSeperator)
         Me.panMain.Controls.Add(Me.cboHotGasBypass)
         Me.panMain.Controls.Add(Me.panDischargeMuffler)
         Me.panMain.Controls.Add(Me.lblSuctionAccumulatorNote)
         Me.panMain.Controls.Add(Me.cboSuctionAccumulators)
         Me.panMain.Controls.Add(Me.chkPressureReliefLow)
         Me.panMain.Controls.Add(Me.chkPressureReliefHigh)
         Me.panMain.Controls.Add(Me.cboExpansionValve)
         Me.panMain.Controls.Add(Me.panFilter)
         Me.panMain.Controls.Add(Me.cboFilterDrier)
         Me.panMain.Controls.Add(Me.panSolenoid)
         Me.panMain.Controls.Add(Me.lblDischargeMufflerLabel)
         Me.panMain.Controls.Add(Me.lblSuctionAccumulatorsLabel)
         Me.panMain.Controls.Add(Me.lblPressureReliefLabel)
         Me.panMain.Controls.Add(Me.lblExpansionValveLabel)
         Me.panMain.Controls.Add(Me.lblFilterLabel)
         Me.panMain.Controls.Add(Me.lblSolenoidLabel)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.lblSolenoidLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblFilterLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblExpansionValveLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblPressureReliefLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblSuctionAccumulatorsLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblDischargeMufflerLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.panSolenoid, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboFilterDrier, 0)
         Me.panMain.Controls.SetChildIndex(Me.panFilter, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboExpansionValve, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkPressureReliefHigh, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkPressureReliefLow, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboSuctionAccumulators, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblSuctionAccumulatorNote, 0)
         Me.panMain.Controls.SetChildIndex(Me.panDischargeMuffler, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboHotGasBypass, 0)
         Me.panMain.Controls.SetChildIndex(Me.panOilSeperator, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblOilSeperatorLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblSuctionFilterLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblVibratorbersLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblHotGasBypassLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblLiquidReceiverLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.panSuctionFilter, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboSuctionFilter, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboVibratorbers, 0)
         Me.panMain.Controls.SetChildIndex(Me.panHotGasBypass, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboHotGasBypassTons, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboLiquidReceiver, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkLiquidReceiverHandValves, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblSolenoidLabel
         '
         Me.lblSolenoidLabel.Location = New System.Drawing.Point(16, 20)
         Me.lblSolenoidLabel.Name = "lblSolenoidLabel"
         Me.lblSolenoidLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblSolenoidLabel.TabIndex = 2
         Me.lblSolenoidLabel.Text = "Liquid line solenoid"
         Me.lblSolenoidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblFilterLabel
         '
         Me.lblFilterLabel.Location = New System.Drawing.Point(16, 48)
         Me.lblFilterLabel.Name = "lblFilterLabel"
         Me.lblFilterLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblFilterLabel.TabIndex = 3
         Me.lblFilterLabel.Text = "Liquid line filter drier with sight glass"
         Me.lblFilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblExpansionValveLabel
         '
         Me.lblExpansionValveLabel.Location = New System.Drawing.Point(16, 76)
         Me.lblExpansionValveLabel.Name = "lblExpansionValveLabel"
         Me.lblExpansionValveLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblExpansionValveLabel.TabIndex = 4
         Me.lblExpansionValveLabel.Text = "Expansion valve"
         Me.lblExpansionValveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblPressureReliefLabel
         '
         Me.lblPressureReliefLabel.Location = New System.Drawing.Point(16, 104)
         Me.lblPressureReliefLabel.Name = "lblPressureReliefLabel"
         Me.lblPressureReliefLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblPressureReliefLabel.TabIndex = 5
         Me.lblPressureReliefLabel.Text = "Pressure relief device"
         Me.lblPressureReliefLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblSuctionAccumulatorsLabel
         '
         Me.lblSuctionAccumulatorsLabel.Location = New System.Drawing.Point(16, 132)
         Me.lblSuctionAccumulatorsLabel.Name = "lblSuctionAccumulatorsLabel"
         Me.lblSuctionAccumulatorsLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblSuctionAccumulatorsLabel.TabIndex = 6
         Me.lblSuctionAccumulatorsLabel.Text = "Suction accumulators"
         Me.lblSuctionAccumulatorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblDischargeMufflerLabel
         '
         Me.lblDischargeMufflerLabel.Location = New System.Drawing.Point(16, 160)
         Me.lblDischargeMufflerLabel.Name = "lblDischargeMufflerLabel"
         Me.lblDischargeMufflerLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblDischargeMufflerLabel.TabIndex = 7
         Me.lblDischargeMufflerLabel.Text = "Hot gas discharge muffler"
         Me.lblDischargeMufflerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'panSolenoid
         '
         Me.panSolenoid.Controls.Add(Me.radSolenoidNo)
         Me.panSolenoid.Controls.Add(Me.radSolenoidYes)
         Me.panSolenoid.Location = New System.Drawing.Point(232, 16)
         Me.panSolenoid.Name = "panSolenoid"
         Me.panSolenoid.Size = New System.Drawing.Size(124, 28)
         Me.panSolenoid.TabIndex = 8
         '
         'radSolenoidNo
         '
         Me.radSolenoidNo.Checked = True
         Me.radSolenoidNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radSolenoidNo.Location = New System.Drawing.Point(72, 4)
         Me.radSolenoidNo.Name = "radSolenoidNo"
         Me.radSolenoidNo.Size = New System.Drawing.Size(56, 24)
         Me.radSolenoidNo.TabIndex = 1
         Me.radSolenoidNo.TabStop = True
         Me.radSolenoidNo.Text = "No"
         '
         'radSolenoidYes
         '
         Me.radSolenoidYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radSolenoidYes.Location = New System.Drawing.Point(0, 4)
         Me.radSolenoidYes.Name = "radSolenoidYes"
         Me.radSolenoidYes.Size = New System.Drawing.Size(60, 24)
         Me.radSolenoidYes.TabIndex = 0
         Me.radSolenoidYes.Text = "Yes"
         '
         'cboFilterDrier
         '
         Me.cboFilterDrier.DropDownWidth = 220
         Me.cboFilterDrier.Items.AddRange(New Object() {"sealed type", "replaceable core type", "replaceable core type with 3-valve bypass"})
         Me.cboFilterDrier.Location = New System.Drawing.Point(356, 48)
         Me.cboFilterDrier.Name = "cboFilterDrier"
         Me.cboFilterDrier.Size = New System.Drawing.Size(152, 21)
         Me.cboFilterDrier.TabIndex = 9
         Me.cboFilterDrier.Text = "sealed type"
         '
         'panFilter
         '
         Me.panFilter.Controls.Add(Me.radFilterYes)
         Me.panFilter.Controls.Add(Me.radFilterNo)
         Me.panFilter.Location = New System.Drawing.Point(232, 44)
         Me.panFilter.Name = "panFilter"
         Me.panFilter.Size = New System.Drawing.Size(124, 28)
         Me.panFilter.TabIndex = 10
         '
         'radFilterYes
         '
         Me.radFilterYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radFilterYes.Location = New System.Drawing.Point(0, 4)
         Me.radFilterYes.Name = "radFilterYes"
         Me.radFilterYes.Size = New System.Drawing.Size(60, 24)
         Me.radFilterYes.TabIndex = 11
         Me.radFilterYes.Text = "Yes"
         '
         'radFilterNo
         '
         Me.radFilterNo.Checked = True
         Me.radFilterNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radFilterNo.Location = New System.Drawing.Point(72, 4)
         Me.radFilterNo.Name = "radFilterNo"
         Me.radFilterNo.Size = New System.Drawing.Size(56, 24)
         Me.radFilterNo.TabIndex = 12
         Me.radFilterNo.TabStop = True
         Me.radFilterNo.Text = "No"
         '
         'cboExpansionValve
         '
         Me.cboExpansionValve.DropDownWidth = 250
         Me.cboExpansionValve.Items.AddRange(New Object() {"thermostatic", "electronic with internal controller"})
         Me.cboExpansionValve.Location = New System.Drawing.Point(232, 76)
         Me.cboExpansionValve.Name = "cboExpansionValve"
         Me.cboExpansionValve.Size = New System.Drawing.Size(276, 21)
         Me.cboExpansionValve.TabIndex = 11
         Me.cboExpansionValve.Text = "thermostatic"
         '
         'chkPressureReliefHigh
         '
         Me.chkPressureReliefHigh.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkPressureReliefHigh.Location = New System.Drawing.Point(232, 104)
         Me.chkPressureReliefHigh.Name = "chkPressureReliefHigh"
         Me.chkPressureReliefHigh.Size = New System.Drawing.Size(80, 24)
         Me.chkPressureReliefHigh.TabIndex = 12
         Me.chkPressureReliefHigh.Text = "High side"
         '
         'chkPressureReliefLow
         '
         Me.chkPressureReliefLow.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkPressureReliefLow.Location = New System.Drawing.Point(312, 104)
         Me.chkPressureReliefLow.Name = "chkPressureReliefLow"
         Me.chkPressureReliefLow.TabIndex = 13
         Me.chkPressureReliefLow.Text = "Low side"
         '
         'cboSuctionAccumulators
         '
         Me.cboSuctionAccumulators.Items.AddRange(New Object() {"no suction accumulator", "without heat exchanger", "with heat exchanger"})
         Me.cboSuctionAccumulators.Location = New System.Drawing.Point(232, 132)
         Me.cboSuctionAccumulators.Name = "cboSuctionAccumulators"
         Me.cboSuctionAccumulators.Size = New System.Drawing.Size(152, 21)
         Me.cboSuctionAccumulators.TabIndex = 14
         Me.cboSuctionAccumulators.Text = "no suction accumulator"
         '
         'lblSuctionAccumulatorNote
         '
         Me.lblSuctionAccumulatorNote.ForeColor = System.Drawing.SystemColors.ControlText
         Me.lblSuctionAccumulatorNote.Location = New System.Drawing.Point(388, 124)
         Me.lblSuctionAccumulatorNote.Name = "lblSuctionAccumulatorNote"
         Me.lblSuctionAccumulatorNote.Size = New System.Drawing.Size(132, 36)
         Me.lblSuctionAccumulatorNote.TabIndex = 15
         Me.lblSuctionAccumulatorNote.Text = "Recommended for low temperature applications"
         Me.lblSuctionAccumulatorNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'panDischargeMuffler
         '
         Me.panDischargeMuffler.Controls.Add(Me.radDischargeMufflerNo)
         Me.panDischargeMuffler.Controls.Add(Me.radDischargeMufflerYes)
         Me.panDischargeMuffler.Location = New System.Drawing.Point(232, 156)
         Me.panDischargeMuffler.Name = "panDischargeMuffler"
         Me.panDischargeMuffler.Size = New System.Drawing.Size(124, 28)
         Me.panDischargeMuffler.TabIndex = 18
         '
         'radDischargeMufflerNo
         '
         Me.radDischargeMufflerNo.Checked = True
         Me.radDischargeMufflerNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radDischargeMufflerNo.Location = New System.Drawing.Point(72, 4)
         Me.radDischargeMufflerNo.Name = "radDischargeMufflerNo"
         Me.radDischargeMufflerNo.Size = New System.Drawing.Size(56, 24)
         Me.radDischargeMufflerNo.TabIndex = 1
         Me.radDischargeMufflerNo.TabStop = True
         Me.radDischargeMufflerNo.Text = "No"
         '
         'radDischargeMufflerYes
         '
         Me.radDischargeMufflerYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radDischargeMufflerYes.Location = New System.Drawing.Point(0, 4)
         Me.radDischargeMufflerYes.Name = "radDischargeMufflerYes"
         Me.radDischargeMufflerYes.Size = New System.Drawing.Size(60, 24)
         Me.radDischargeMufflerYes.TabIndex = 0
         Me.radDischargeMufflerYes.Text = "Yes"
         '
         'cboHotGasBypass
         '
         Me.cboHotGasBypass.DropDownWidth = 370
         Me.cboHotGasBypass.Items.AddRange(New Object() {"standard design", "desuper heated (includes suction accumulator and liquid injection valve)"})
         Me.cboHotGasBypass.Location = New System.Drawing.Point(232, 304)
         Me.cboHotGasBypass.Name = "cboHotGasBypass"
         Me.cboHotGasBypass.Size = New System.Drawing.Size(276, 21)
         Me.cboHotGasBypass.TabIndex = 19
         Me.cboHotGasBypass.Text = "standard design"
         '
         'panOilSeperator
         '
         Me.panOilSeperator.Controls.Add(Me.radOilSeperatorNo)
         Me.panOilSeperator.Controls.Add(Me.radOilSeperatorYes)
         Me.panOilSeperator.Location = New System.Drawing.Point(232, 184)
         Me.panOilSeperator.Name = "panOilSeperator"
         Me.panOilSeperator.Size = New System.Drawing.Size(124, 28)
         Me.panOilSeperator.TabIndex = 20
         '
         'radOilSeperatorNo
         '
         Me.radOilSeperatorNo.Checked = True
         Me.radOilSeperatorNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radOilSeperatorNo.Location = New System.Drawing.Point(72, 4)
         Me.radOilSeperatorNo.Name = "radOilSeperatorNo"
         Me.radOilSeperatorNo.Size = New System.Drawing.Size(56, 24)
         Me.radOilSeperatorNo.TabIndex = 1
         Me.radOilSeperatorNo.TabStop = True
         Me.radOilSeperatorNo.Text = "No"
         '
         'radOilSeperatorYes
         '
         Me.radOilSeperatorYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radOilSeperatorYes.Location = New System.Drawing.Point(0, 4)
         Me.radOilSeperatorYes.Name = "radOilSeperatorYes"
         Me.radOilSeperatorYes.Size = New System.Drawing.Size(60, 24)
         Me.radOilSeperatorYes.TabIndex = 0
         Me.radOilSeperatorYes.Text = "Yes"
         '
         'lblOilSeperatorLabel
         '
         Me.lblOilSeperatorLabel.Location = New System.Drawing.Point(16, 188)
         Me.lblOilSeperatorLabel.Name = "lblOilSeperatorLabel"
         Me.lblOilSeperatorLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblOilSeperatorLabel.TabIndex = 21
         Me.lblOilSeperatorLabel.Text = "Oil seperator with oil reservior"
         Me.lblOilSeperatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblSuctionFilterLabel
         '
         Me.lblSuctionFilterLabel.Location = New System.Drawing.Point(16, 216)
         Me.lblSuctionFilterLabel.Name = "lblSuctionFilterLabel"
         Me.lblSuctionFilterLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblSuctionFilterLabel.TabIndex = 22
         Me.lblSuctionFilterLabel.Text = "Suction filter"
         Me.lblSuctionFilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblVibratorbersLabel
         '
         Me.lblVibratorbersLabel.Location = New System.Drawing.Point(16, 244)
         Me.lblVibratorbersLabel.Name = "lblVibratorbersLabel"
         Me.lblVibratorbersLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblVibratorbersLabel.TabIndex = 23
         Me.lblVibratorbersLabel.Text = "Vibratorbers mounted"
         Me.lblVibratorbersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblHotGasBypassLabel
         '
         Me.lblHotGasBypassLabel.Location = New System.Drawing.Point(16, 272)
         Me.lblHotGasBypassLabel.Name = "lblHotGasBypassLabel"
         Me.lblHotGasBypassLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblHotGasBypassLabel.TabIndex = 24
         Me.lblHotGasBypassLabel.Text = "Hot-gas bypass"
         Me.lblHotGasBypassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblLiquidReceiverLabel
         '
         Me.lblLiquidReceiverLabel.Location = New System.Drawing.Point(16, 360)
         Me.lblLiquidReceiverLabel.Name = "lblLiquidReceiverLabel"
         Me.lblLiquidReceiverLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblLiquidReceiverLabel.TabIndex = 25
         Me.lblLiquidReceiverLabel.Text = "Liquid receiver per circuit"
         Me.lblLiquidReceiverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'panSuctionFilter
         '
         Me.panSuctionFilter.Controls.Add(Me.radSuctionFilterNo)
         Me.panSuctionFilter.Controls.Add(Me.radSuctionFilterYes)
         Me.panSuctionFilter.Location = New System.Drawing.Point(232, 212)
         Me.panSuctionFilter.Name = "panSuctionFilter"
         Me.panSuctionFilter.Size = New System.Drawing.Size(124, 28)
         Me.panSuctionFilter.TabIndex = 27
         '
         'radSuctionFilterNo
         '
         Me.radSuctionFilterNo.Checked = True
         Me.radSuctionFilterNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radSuctionFilterNo.Location = New System.Drawing.Point(72, 4)
         Me.radSuctionFilterNo.Name = "radSuctionFilterNo"
         Me.radSuctionFilterNo.Size = New System.Drawing.Size(56, 24)
         Me.radSuctionFilterNo.TabIndex = 1
         Me.radSuctionFilterNo.TabStop = True
         Me.radSuctionFilterNo.Text = "No"
         '
         'radSuctionFilterYes
         '
         Me.radSuctionFilterYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radSuctionFilterYes.Location = New System.Drawing.Point(0, 4)
         Me.radSuctionFilterYes.Name = "radSuctionFilterYes"
         Me.radSuctionFilterYes.Size = New System.Drawing.Size(60, 24)
         Me.radSuctionFilterYes.TabIndex = 0
         Me.radSuctionFilterYes.Text = "Yes"
         '
         'cboSuctionFilter
         '
         Me.cboSuctionFilter.DropDownWidth = 220
         Me.cboSuctionFilter.Items.AddRange(New Object() {"sealed type", "replaceable core type", "replaceable core type with 3-valve bypass"})
         Me.cboSuctionFilter.Location = New System.Drawing.Point(356, 216)
         Me.cboSuctionFilter.Name = "cboSuctionFilter"
         Me.cboSuctionFilter.Size = New System.Drawing.Size(152, 21)
         Me.cboSuctionFilter.TabIndex = 28
         Me.cboSuctionFilter.Text = "sealed type"
         '
         'cboVibratorbers
         '
         Me.cboVibratorbers.Items.AddRange(New Object() {"Discharge only", "Suction only", "Suction and discharge"})
         Me.cboVibratorbers.Location = New System.Drawing.Point(232, 244)
         Me.cboVibratorbers.Name = "cboVibratorbers"
         Me.cboVibratorbers.Size = New System.Drawing.Size(152, 21)
         Me.cboVibratorbers.TabIndex = 29
         Me.cboVibratorbers.Text = "Discharge only"
         '
         'panHotGasBypass
         '
         Me.panHotGasBypass.Controls.Add(Me.radHotGasBypassNo)
         Me.panHotGasBypass.Controls.Add(Me.radHotGasBypassYes)
         Me.panHotGasBypass.Location = New System.Drawing.Point(232, 268)
         Me.panHotGasBypass.Name = "panHotGasBypass"
         Me.panHotGasBypass.Size = New System.Drawing.Size(124, 28)
         Me.panHotGasBypass.TabIndex = 30
         '
         'radHotGasBypassNo
         '
         Me.radHotGasBypassNo.Checked = True
         Me.radHotGasBypassNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radHotGasBypassNo.Location = New System.Drawing.Point(72, 4)
         Me.radHotGasBypassNo.Name = "radHotGasBypassNo"
         Me.radHotGasBypassNo.Size = New System.Drawing.Size(56, 24)
         Me.radHotGasBypassNo.TabIndex = 1
         Me.radHotGasBypassNo.TabStop = True
         Me.radHotGasBypassNo.Text = "No"
         '
         'radHotGasBypassYes
         '
         Me.radHotGasBypassYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radHotGasBypassYes.Location = New System.Drawing.Point(0, 4)
         Me.radHotGasBypassYes.Name = "radHotGasBypassYes"
         Me.radHotGasBypassYes.Size = New System.Drawing.Size(60, 24)
         Me.radHotGasBypassYes.TabIndex = 0
         Me.radHotGasBypassYes.Text = "Yes"
         '
         'cboHotGasBypassTons
         '
         Me.cboHotGasBypassTons.Items.AddRange(New Object() {"4.1 Tons", "11.3 Tons", "25 Tons"})
         Me.cboHotGasBypassTons.Location = New System.Drawing.Point(232, 332)
         Me.cboHotGasBypassTons.Name = "cboHotGasBypassTons"
         Me.cboHotGasBypassTons.Size = New System.Drawing.Size(276, 21)
         Me.cboHotGasBypassTons.TabIndex = 31
         Me.cboHotGasBypassTons.Text = "4.1 Tons"
         '
         'cboLiquidReceiver
         '
         Me.cboLiquidReceiver.Items.AddRange(New Object() {"5 in. x 14 in.", "6 in. x 28 in.", "6 in. x 36 in.", "8 in. x 36 in.", "8 in. x 60 in.", "10 in. x 60 in.", "12 in. x 60 in."})
         Me.cboLiquidReceiver.Location = New System.Drawing.Point(232, 360)
         Me.cboLiquidReceiver.Name = "cboLiquidReceiver"
         Me.cboLiquidReceiver.Size = New System.Drawing.Size(276, 21)
         Me.cboLiquidReceiver.TabIndex = 32
         Me.cboLiquidReceiver.Text = "5 in. x 14 in."
         '
         'chkLiquidReceiverHandValves
         '
         Me.chkLiquidReceiverHandValves.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkLiquidReceiverHandValves.Location = New System.Drawing.Point(232, 388)
         Me.chkLiquidReceiverHandValves.Name = "chkLiquidReceiverHandValves"
         Me.chkLiquidReceiverHandValves.Size = New System.Drawing.Size(148, 24)
         Me.chkLiquidReceiverHandValves.TabIndex = 33
         Me.chkLiquidReceiverHandValves.Text = "with hand valves"
         '
         'RefrigerantSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "RefrigerantSpecBuilderWizard"
         Me.Tag = "Refrigerant Circuit"
         Me.Text = "Untitled - SpecBuilder - Refrigerant Circuit"
         Me.panMain.ResumeLayout(False)
         Me.panSolenoid.ResumeLayout(False)
         Me.panFilter.ResumeLayout(False)
         Me.panDischargeMuffler.ResumeLayout(False)
         Me.panOilSeperator.ResumeLayout(False)
         Me.panSuctionFilter.ResumeLayout(False)
         Me.panHotGasBypass.ResumeLayout(False)

      End Sub

#End Region


      Dim optManager As New SpecBuilder.OptionManager(SpecData)


      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilder.SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub


      Private Sub RefrigerantSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetSolenoidControls()
         Me.SetFilterDrierControls()
         Me.SetFilterDrierTypeControls()
         Me.SetSuctionFilterTypeControls()
         Me.SetHotGasByPassDesignControls()
         Me.SetHotGasBypassTonsControls()
         Me.SetExpansionValveControls()
      End Sub


      Private Sub RefrigerantSpecBuilderWizard_VisibleChanged(ByVal sender As Object, _
      ByVal e As EventArgs) Handles MyBase.VisibleChanged
         If Me.isDisposing Then Exit Sub
         Me.SetSolenoidControls()
         Me.SetFilterDrierControls()
         Me.SetExpansionValveControls()
      End Sub

      Private Sub radSolenoidYes_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles radSolenoidYes.CheckedChanged
         Me.SpecData.Refrigerant.Solenoid = Me.radSolenoidYes.Checked
      End Sub

      Private Sub radFilterYes_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles radFilterYes.CheckedChanged
         Me.SpecData.Refrigerant.FilterDrier = Me.radFilterYes.Checked

         Me.SetFilterDrierTypeControls()
      End Sub

      Private Sub cboFilterDrier_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboFilterDrier.SelectedIndexChanged
         Me.SpecData.Refrigerant.FilterDrierType = Me.cboFilterDrier.Text
      End Sub

      Private Sub cboExpansionValve_SelectedIndexChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles cboExpansionValve.SelectedIndexChanged
         Me.SpecData.Refrigerant.ExpansionValve = Me.cboExpansionValve.Text
      End Sub

      Private Sub chkPressureReliefHigh_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkPressureReliefHigh.CheckedChanged
         Me.SpecData.Refrigerant.PressureReliefHigh = Me.chkPressureReliefHigh.Checked
      End Sub

      Private Sub chkPressureReliefLow_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkPressureReliefLow.CheckedChanged
         Me.SpecData.Refrigerant.PressureReliefLow = Me.chkPressureReliefLow.Checked
      End Sub

      Private Sub cboSuctionAccumulators_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboSuctionAccumulators.SelectedIndexChanged
         Me.SpecData.Refrigerant.SuctionAccumulators = Me.cboSuctionAccumulators.Text
      End Sub

      Private Sub radDischargeMufflerYes_CheckedChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles radDischargeMufflerYes.CheckedChanged
         Me.SpecData.Refrigerant.HotGasDischargeMuffler = _
            Me.radDischargeMufflerYes.Checked
      End Sub

      Private Sub radOilSeperatorYes_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles radOilSeperatorYes.CheckedChanged
         Me.SpecData.Refrigerant.OilSeperator = Me.radOilSeperatorYes.Checked
      End Sub

      Private Sub radSuctionFilterYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSuctionFilterYes.CheckedChanged
         Me.SpecData.Refrigerant.SuctionFilter = Me.radSuctionFilterYes.Checked

         Me.SetSuctionFilterTypeControls()
      End Sub

      Private Sub cboSuctionFilter_SelectedIndexChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles cboSuctionFilter.SelectedIndexChanged
         Me.SpecData.Refrigerant.SuctionFilterType = Me.cboSuctionFilter.Text
      End Sub

      Private Sub cboVibratorbers_SelectedIndexChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles cboVibratorbers.SelectedIndexChanged
         Me.SpecData.Refrigerant.Vibratorbers = Me.cboVibratorbers.Text
      End Sub

      Private Sub radHotGasBypassYes_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles radHotGasBypassYes.CheckedChanged
         Me.SpecData.Refrigerant.HotGasBypass = Me.radHotGasBypassYes.Checked

         Me.SetHotGasByPassDesignControls()
         Me.SetHotGasBypassTonsControls()
      End Sub

      Private Sub cboHotGasBypass_SelectedIndexChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles cboHotGasBypass.SelectedIndexChanged
         Me.SpecData.Refrigerant.HotGasBypassDesign = Me.cboHotGasBypass.Text
      End Sub

      Private Sub cboHotGasBypassTons_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboHotGasBypassTons.SelectedIndexChanged
         Me.SpecData.Refrigerant.HotGasBypassTons = Me.cboHotGasBypassTons.Text
      End Sub

      Private Sub cboLiquidReceiver_SelectedIndexChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles cboLiquidReceiver.SelectedIndexChanged
         Me.SpecData.Refrigerant.LiquidReceiver = Me.cboLiquidReceiver.Text
      End Sub

      Private Sub chkLiquidReceiverHandValves_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkLiquidReceiverHandValves.CheckedChanged
         Me.SpecData.Refrigerant.LiquidReceiverHandValves = _
            Me.chkLiquidReceiverHandValves.Checked
      End Sub


      Private Sub SetFilterDrierTypeControls()
         If Me.optManager.GetFilterDrierType.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboFilterDrier, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboFilterDrier, _
               Me.tip, Me.optManager.GetFilterDrierType.Explanation)
         End If
      End Sub

      Private Sub SetSuctionFilterTypeControls()
         If Me.optManager.GetSuctionFilterType.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboSuctionFilter, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboSuctionFilter, _
               Me.tip, Me.optManager.GetSuctionFilterType.Explanation)
         End If
      End Sub

      Private Sub SetHotGasByPassDesignControls()
         If Me.optManager.GetHotGasBypassDesign.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboHotGasBypass, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboHotGasBypass, _
               Me.tip, Me.optManager.GetHotGasBypassDesign.Explanation)
         End If
      End Sub

      Private Sub SetHotGasBypassTonsControls()
         If Me.optManager.GetHotGasBypassTons.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboHotGasBypassTons, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboHotGasBypassTons, _
               Me.tip, Me.optManager.GetHotGasBypassTons.Explanation)
         End If
      End Sub

      Private Sub SetSolenoidControls()
         If Me.optManager.GetSolenoid.IsOption Then
            Me.radSolenoidNo.Enabled = True
            Me.radSolenoidYes.Enabled = True
            Me.tip.SetToolTip(Me.lblSolenoidLabel, String.Empty)
         Else
            'solenoid is standard w/ water chiller
            Me.radSolenoidYes.Checked = True
            Me.radSolenoidYes.Enabled = False
            Me.radSolenoidNo.Enabled = False
            Me.tip.SetToolTip(Me.lblSolenoidLabel, Me.optManager.GetSolenoid.Explanation)
         End If
      End Sub

      Private Sub SetFilterDrierControls()
         If Me.optManager.GetFilterDrier.IsOption Then
            Me.radFilterNo.Enabled = True
            Me.radFilterYes.Enabled = True
            Me.tip.SetToolTip(Me.lblFilterLabel, String.Empty)
         Else
            Me.radFilterYes.Checked = True
            Me.radFilterYes.Enabled = False
            Me.radFilterNo.Enabled = False
            Me.tip.SetToolTip(Me.lblFilterLabel, Me.optManager.GetFilterDrier.Explanation)
         End If
      End Sub

      Private Sub SetExpansionValveControls()
         If Me.optManager.GetExpansionValve.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblExpansionValveLabel, _
               Me.cboExpansionValve, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblExpansionValveLabel, _
               Me.cboExpansionValve, Me.tip, _
               Me.optManager.GetExpansionValve.Explanation)
         End If
      End Sub


   End Class

End Namespace
