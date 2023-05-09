Namespace SpecBuilder

   Public Class PumpSpecBuilderWizard
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
      Friend WithEvents lblPumpPackageLabel As System.Windows.Forms.Label
      Friend WithEvents chkPumpPackage As System.Windows.Forms.CheckBox
      Friend WithEvents lblDesignCriteriaLabel As System.Windows.Forms.Label
      Friend WithEvents cboDesignCriteria As System.Windows.Forms.ComboBox
      Friend WithEvents lblPackageLabel As System.Windows.Forms.Label
      Friend WithEvents lblSpeedLabel As System.Windows.Forms.Label
      Friend WithEvents lblTypeLabel As System.Windows.Forms.Label
      Friend WithEvents cboSpeed As System.Windows.Forms.ComboBox
      Friend WithEvents cboType As System.Windows.Forms.ComboBox
      Friend WithEvents chkAirSeperator As System.Windows.Forms.CheckBox
      Friend WithEvents lblAirSeperatorLabel As System.Windows.Forms.Label
      Friend WithEvents cboAirSeperator As System.Windows.Forms.ComboBox
      Friend WithEvents lblExpansionTankLabel As System.Windows.Forms.Label
      Friend WithEvents chkExpansionTank As System.Windows.Forms.CheckBox
      Friend WithEvents cboExpansionTankType As System.Windows.Forms.ComboBox
      Friend WithEvents cboStorageRatingAsm As System.Windows.Forms.ComboBox
      Friend WithEvents txtStorageTankVolume As System.Windows.Forms.TextBox
      Friend WithEvents lblStorageTankVolumeLimit As System.Windows.Forms.Label
      Friend WithEvents lblStorageTankVolumeLabel As System.Windows.Forms.Label
      Friend WithEvents lblStorageTankRating As System.Windows.Forms.Label
      Friend WithEvents cboStorageTankRatingPsi As System.Windows.Forms.ComboBox
      Friend WithEvents lblStorageTankRatingPsiLabel As System.Windows.Forms.Label
      Friend WithEvents lblSuctionStrainerLabel As System.Windows.Forms.Label
      Friend WithEvents lblSuctionTrimLabel As System.Windows.Forms.Label
      Friend WithEvents cboSuctionStrainer As System.Windows.Forms.ComboBox
      Friend WithEvents cboSuctionTrim As System.Windows.Forms.ComboBox
      Friend WithEvents lblStorageTankLabel As System.Windows.Forms.Label
      Friend WithEvents chkStorageTank As System.Windows.Forms.CheckBox
      Friend WithEvents cboPackage As System.Windows.Forms.ComboBox
      Friend WithEvents panMessage As System.Windows.Forms.Panel
      Friend WithEvents lblMessage As System.Windows.Forms.Label
      Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
      Friend WithEvents panControls As System.Windows.Forms.Panel
      Friend WithEvents cboDesignCriteriaDualOption As System.Windows.Forms.ComboBox
      Friend WithEvents lblDualPumpLabel As System.Windows.Forms.Label
      Friend WithEvents cboStorageTankType As System.Windows.Forms.ComboBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PumpSpecBuilderWizard))
         Me.lblPumpPackageLabel = New System.Windows.Forms.Label
         Me.chkPumpPackage = New System.Windows.Forms.CheckBox
         Me.lblDesignCriteriaLabel = New System.Windows.Forms.Label
         Me.lblPackageLabel = New System.Windows.Forms.Label
         Me.cboDesignCriteria = New System.Windows.Forms.ComboBox
         Me.cboDesignCriteriaDualOption = New System.Windows.Forms.ComboBox
         Me.lblSpeedLabel = New System.Windows.Forms.Label
         Me.lblTypeLabel = New System.Windows.Forms.Label
         Me.cboSpeed = New System.Windows.Forms.ComboBox
         Me.cboType = New System.Windows.Forms.ComboBox
         Me.chkAirSeperator = New System.Windows.Forms.CheckBox
         Me.lblAirSeperatorLabel = New System.Windows.Forms.Label
         Me.cboAirSeperator = New System.Windows.Forms.ComboBox
         Me.lblExpansionTankLabel = New System.Windows.Forms.Label
         Me.chkExpansionTank = New System.Windows.Forms.CheckBox
         Me.cboExpansionTankType = New System.Windows.Forms.ComboBox
         Me.cboStorageRatingAsm = New System.Windows.Forms.ComboBox
         Me.txtStorageTankVolume = New System.Windows.Forms.TextBox
         Me.lblStorageTankVolumeLimit = New System.Windows.Forms.Label
         Me.lblStorageTankVolumeLabel = New System.Windows.Forms.Label
         Me.lblStorageTankRating = New System.Windows.Forms.Label
         Me.cboStorageTankRatingPsi = New System.Windows.Forms.ComboBox
         Me.lblStorageTankRatingPsiLabel = New System.Windows.Forms.Label
         Me.lblSuctionStrainerLabel = New System.Windows.Forms.Label
         Me.lblSuctionTrimLabel = New System.Windows.Forms.Label
         Me.cboSuctionStrainer = New System.Windows.Forms.ComboBox
         Me.cboSuctionTrim = New System.Windows.Forms.ComboBox
         Me.lblStorageTankLabel = New System.Windows.Forms.Label
         Me.chkStorageTank = New System.Windows.Forms.CheckBox
         Me.cboPackage = New System.Windows.Forms.ComboBox
         Me.panMessage = New System.Windows.Forms.Panel
         Me.PictureBox1 = New System.Windows.Forms.PictureBox
         Me.lblMessage = New System.Windows.Forms.Label
         Me.panControls = New System.Windows.Forms.Panel
         Me.cboStorageTankType = New System.Windows.Forms.ComboBox
         Me.lblDualPumpLabel = New System.Windows.Forms.Label
         Me.panMain.SuspendLayout()
         Me.panMessage.SuspendLayout()
         Me.panControls.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.AutoScroll = True
         Me.panMain.Controls.Add(Me.panMessage)
         Me.panMain.Controls.Add(Me.panControls)
         Me.panMain.Controls.Add(Me.lblPumpPackageLabel)
         Me.panMain.Controls.Add(Me.chkPumpPackage)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.chkPumpPackage, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblPumpPackageLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.panControls, 0)
         Me.panMain.Controls.SetChildIndex(Me.panMessage, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblPumpPackageLabel
         '
         Me.lblPumpPackageLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.lblPumpPackageLabel.Location = New System.Drawing.Point(24, 20)
         Me.lblPumpPackageLabel.Name = "lblPumpPackageLabel"
         Me.lblPumpPackageLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblPumpPackageLabel.TabIndex = 2
         Me.lblPumpPackageLabel.Text = "Integral pump package"
         Me.lblPumpPackageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkPumpPackage
         '
         Me.chkPumpPackage.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkPumpPackage.Location = New System.Drawing.Point(232, 20)
         Me.chkPumpPackage.Name = "chkPumpPackage"
         Me.chkPumpPackage.Size = New System.Drawing.Size(60, 24)
         Me.chkPumpPackage.TabIndex = 3
         '
         'lblDesignCriteriaLabel
         '
         Me.lblDesignCriteriaLabel.Location = New System.Drawing.Point(8, 4)
         Me.lblDesignCriteriaLabel.Name = "lblDesignCriteriaLabel"
         Me.lblDesignCriteriaLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblDesignCriteriaLabel.TabIndex = 4
         Me.lblDesignCriteriaLabel.Text = "Design criteria"
         Me.lblDesignCriteriaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblPackageLabel
         '
         Me.lblPackageLabel.Location = New System.Drawing.Point(8, 60)
         Me.lblPackageLabel.Name = "lblPackageLabel"
         Me.lblPackageLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblPackageLabel.TabIndex = 5
         Me.lblPackageLabel.Text = "Package design"
         Me.lblPackageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboDesignCriteria
         '
         Me.cboDesignCriteria.Items.AddRange(New Object() {"Single", "Dual"})
         Me.cboDesignCriteria.Location = New System.Drawing.Point(216, 4)
         Me.cboDesignCriteria.Name = "cboDesignCriteria"
         Me.cboDesignCriteria.Size = New System.Drawing.Size(172, 21)
         Me.cboDesignCriteria.TabIndex = 6
         Me.cboDesignCriteria.Text = "Single"
         '
         'cboDesignCriteriaDualOption
         '
         Me.cboDesignCriteriaDualOption.DropDownWidth = 250
         Me.cboDesignCriteriaDualOption.Items.AddRange(New Object() {"Primary/Standby Design (100% Redundancy)", "Primary/Secondary (Simultaneous Operation)"})
         Me.cboDesignCriteriaDualOption.Location = New System.Drawing.Point(248, 32)
         Me.cboDesignCriteriaDualOption.Name = "cboDesignCriteriaDualOption"
         Me.cboDesignCriteriaDualOption.Size = New System.Drawing.Size(260, 21)
         Me.cboDesignCriteriaDualOption.TabIndex = 7
         Me.cboDesignCriteriaDualOption.Text = "Primary/Standby Design (100% Redundancy)"
         '
         'lblSpeedLabel
         '
         Me.lblSpeedLabel.Location = New System.Drawing.Point(8, 88)
         Me.lblSpeedLabel.Name = "lblSpeedLabel"
         Me.lblSpeedLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblSpeedLabel.TabIndex = 10
         Me.lblSpeedLabel.Text = "Pump speed"
         Me.lblSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblTypeLabel
         '
         Me.lblTypeLabel.Location = New System.Drawing.Point(8, 116)
         Me.lblTypeLabel.Name = "lblTypeLabel"
         Me.lblTypeLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblTypeLabel.TabIndex = 11
         Me.lblTypeLabel.Text = "Pump type"
         Me.lblTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboSpeed
         '
         Me.cboSpeed.Items.AddRange(New Object() {"1750 RPM", "3500 RPM"})
         Me.cboSpeed.Location = New System.Drawing.Point(216, 88)
         Me.cboSpeed.Name = "cboSpeed"
         Me.cboSpeed.Size = New System.Drawing.Size(172, 21)
         Me.cboSpeed.TabIndex = 12
         Me.cboSpeed.Text = "1750 RPM"
         '
         'cboType
         '
         Me.cboType.Items.AddRange(New Object() {"End-Suction Centrifugal", "In-Line"})
         Me.cboType.Location = New System.Drawing.Point(216, 116)
         Me.cboType.Name = "cboType"
         Me.cboType.Size = New System.Drawing.Size(172, 21)
         Me.cboType.TabIndex = 13
         Me.cboType.Text = "End-Suction Centrifugal"
         '
         'chkAirSeperator
         '
         Me.chkAirSeperator.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkAirSeperator.Location = New System.Drawing.Point(216, 144)
         Me.chkAirSeperator.Name = "chkAirSeperator"
         Me.chkAirSeperator.Size = New System.Drawing.Size(32, 24)
         Me.chkAirSeperator.TabIndex = 14
         '
         'lblAirSeperatorLabel
         '
         Me.lblAirSeperatorLabel.Location = New System.Drawing.Point(8, 144)
         Me.lblAirSeperatorLabel.Name = "lblAirSeperatorLabel"
         Me.lblAirSeperatorLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblAirSeperatorLabel.TabIndex = 15
         Me.lblAirSeperatorLabel.Text = "Air seperator"
         Me.lblAirSeperatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboAirSeperator
         '
         Me.cboAirSeperator.Items.AddRange(New Object() {"In-Line", "Tangential"})
         Me.cboAirSeperator.Location = New System.Drawing.Point(248, 144)
         Me.cboAirSeperator.Name = "cboAirSeperator"
         Me.cboAirSeperator.Size = New System.Drawing.Size(168, 21)
         Me.cboAirSeperator.TabIndex = 16
         Me.cboAirSeperator.Text = "In-Line"
         '
         'lblExpansionTankLabel
         '
         Me.lblExpansionTankLabel.Location = New System.Drawing.Point(8, 172)
         Me.lblExpansionTankLabel.Name = "lblExpansionTankLabel"
         Me.lblExpansionTankLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblExpansionTankLabel.TabIndex = 18
         Me.lblExpansionTankLabel.Text = "Expansion tank"
         Me.lblExpansionTankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkExpansionTank
         '
         Me.chkExpansionTank.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkExpansionTank.Location = New System.Drawing.Point(216, 172)
         Me.chkExpansionTank.Name = "chkExpansionTank"
         Me.chkExpansionTank.Size = New System.Drawing.Size(32, 24)
         Me.chkExpansionTank.TabIndex = 17
         '
         'cboExpansionTankType
         '
         Me.cboExpansionTankType.Items.AddRange(New Object() {"Diaphragm Type", "Compression Type"})
         Me.cboExpansionTankType.Location = New System.Drawing.Point(248, 172)
         Me.cboExpansionTankType.Name = "cboExpansionTankType"
         Me.cboExpansionTankType.Size = New System.Drawing.Size(168, 21)
         Me.cboExpansionTankType.TabIndex = 19
         Me.cboExpansionTankType.Text = "Diaphragm Type"
         '
         'cboStorageRatingAsm
         '
         Me.cboStorageRatingAsm.Items.AddRange(New Object() {"Non-ASM", "ASM Rated"})
         Me.cboStorageRatingAsm.Location = New System.Drawing.Point(248, 312)
         Me.cboStorageRatingAsm.Name = "cboStorageRatingAsm"
         Me.cboStorageRatingAsm.Size = New System.Drawing.Size(88, 21)
         Me.cboStorageRatingAsm.TabIndex = 21
         Me.cboStorageRatingAsm.Text = "Non-ASM"
         '
         'txtStorageTankVolume
         '
         Me.txtStorageTankVolume.Location = New System.Drawing.Point(248, 284)
         Me.txtStorageTankVolume.Name = "txtStorageTankVolume"
         Me.txtStorageTankVolume.Size = New System.Drawing.Size(132, 21)
         Me.txtStorageTankVolume.TabIndex = 22
         Me.txtStorageTankVolume.Text = "0"
         '
         'lblStorageTankVolumeLimit
         '
         Me.lblStorageTankVolumeLimit.Location = New System.Drawing.Point(384, 284)
         Me.lblStorageTankVolumeLimit.Name = "lblStorageTankVolumeLimit"
         Me.lblStorageTankVolumeLimit.Size = New System.Drawing.Size(108, 23)
         Me.lblStorageTankVolumeLimit.TabIndex = 23
         Me.lblStorageTankVolumeLimit.Text = "Up to 1000 gallons"
         Me.lblStorageTankVolumeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'lblStorageTankVolumeLabel
         '
         Me.lblStorageTankVolumeLabel.Location = New System.Drawing.Point(8, 284)
         Me.lblStorageTankVolumeLabel.Name = "lblStorageTankVolumeLabel"
         Me.lblStorageTankVolumeLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblStorageTankVolumeLabel.TabIndex = 24
         Me.lblStorageTankVolumeLabel.Text = "Storage tank volume"
         Me.lblStorageTankVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblStorageTankRating
         '
         Me.lblStorageTankRating.Location = New System.Drawing.Point(8, 312)
         Me.lblStorageTankRating.Name = "lblStorageTankRating"
         Me.lblStorageTankRating.Size = New System.Drawing.Size(192, 23)
         Me.lblStorageTankRating.TabIndex = 25
         Me.lblStorageTankRating.Text = "Storage tank rating"
         Me.lblStorageTankRating.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboStorageTankRatingPsi
         '
         Me.cboStorageTankRatingPsi.Items.AddRange(New Object() {"75 psi", "125 psi"})
         Me.cboStorageTankRatingPsi.Location = New System.Drawing.Point(340, 312)
         Me.cboStorageTankRatingPsi.Name = "cboStorageTankRatingPsi"
         Me.cboStorageTankRatingPsi.Size = New System.Drawing.Size(76, 21)
         Me.cboStorageTankRatingPsi.TabIndex = 26
         Me.cboStorageTankRatingPsi.Text = "75 psi"
         '
         'lblStorageTankRatingPsiLabel
         '
         Me.lblStorageTankRatingPsiLabel.Location = New System.Drawing.Point(420, 312)
         Me.lblStorageTankRatingPsiLabel.Name = "lblStorageTankRatingPsiLabel"
         Me.lblStorageTankRatingPsiLabel.Size = New System.Drawing.Size(92, 23)
         Me.lblStorageTankRatingPsiLabel.TabIndex = 27
         Me.lblStorageTankRatingPsiLabel.Text = "Pressure rating"
         Me.lblStorageTankRatingPsiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'lblSuctionStrainerLabel
         '
         Me.lblSuctionStrainerLabel.Location = New System.Drawing.Point(8, 200)
         Me.lblSuctionStrainerLabel.Name = "lblSuctionStrainerLabel"
         Me.lblSuctionStrainerLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblSuctionStrainerLabel.TabIndex = 28
         Me.lblSuctionStrainerLabel.Text = "Suction strainer"
         Me.lblSuctionStrainerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblSuctionTrimLabel
         '
         Me.lblSuctionTrimLabel.Location = New System.Drawing.Point(8, 228)
         Me.lblSuctionTrimLabel.Name = "lblSuctionTrimLabel"
         Me.lblSuctionTrimLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblSuctionTrimLabel.TabIndex = 29
         Me.lblSuctionTrimLabel.Text = "Suction trim"
         Me.lblSuctionTrimLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboSuctionStrainer
         '
         Me.cboSuctionStrainer.Items.AddRange(New Object() {"Basket Type", "Wye Type"})
         Me.cboSuctionStrainer.Location = New System.Drawing.Point(216, 200)
         Me.cboSuctionStrainer.Name = "cboSuctionStrainer"
         Me.cboSuctionStrainer.Size = New System.Drawing.Size(172, 21)
         Me.cboSuctionStrainer.TabIndex = 30
         Me.cboSuctionStrainer.Text = "Basket Type"
         '
         'cboSuctionTrim
         '
         Me.cboSuctionTrim.DropDownWidth = 220
         Me.cboSuctionTrim.Items.AddRange(New Object() {"Ball Balve, through 2 1/2"" Pipe Size", "Butterfly valve, 3"" pipe size and larger"})
         Me.cboSuctionTrim.Location = New System.Drawing.Point(216, 228)
         Me.cboSuctionTrim.Name = "cboSuctionTrim"
         Me.cboSuctionTrim.Size = New System.Drawing.Size(256, 21)
         Me.cboSuctionTrim.TabIndex = 31
         Me.cboSuctionTrim.Text = "Ball Balve, through 2 1/2"" Pipe Size"
         '
         'lblStorageTankLabel
         '
         Me.lblStorageTankLabel.Location = New System.Drawing.Point(8, 256)
         Me.lblStorageTankLabel.Name = "lblStorageTankLabel"
         Me.lblStorageTankLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblStorageTankLabel.TabIndex = 32
         Me.lblStorageTankLabel.Text = "Mass storage tank"
         Me.lblStorageTankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkStorageTank
         '
         Me.chkStorageTank.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkStorageTank.Location = New System.Drawing.Point(216, 256)
         Me.chkStorageTank.Name = "chkStorageTank"
         Me.chkStorageTank.Size = New System.Drawing.Size(36, 24)
         Me.chkStorageTank.TabIndex = 33
         '
         'cboPackage
         '
         Me.cboPackage.DropDownWidth = 168
         Me.cboPackage.Items.AddRange(New Object() {"Integral with Chiller", "Stand Alone (Seperate Base)"})
         Me.cboPackage.Location = New System.Drawing.Point(216, 60)
         Me.cboPackage.Name = "cboPackage"
         Me.cboPackage.Size = New System.Drawing.Size(172, 21)
         Me.cboPackage.TabIndex = 34
         Me.cboPackage.Text = "Integral with Chiller"
         '
         'panMessage
         '
         Me.panMessage.BackColor = System.Drawing.SystemColors.Control
         Me.panMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panMessage.Controls.Add(Me.PictureBox1)
         Me.panMessage.Controls.Add(Me.lblMessage)
         Me.panMessage.Dock = System.Windows.Forms.DockStyle.Top
         Me.panMessage.Location = New System.Drawing.Point(0, 0)
         Me.panMessage.Name = "panMessage"
         Me.panMessage.Size = New System.Drawing.Size(552, 24)
         Me.panMessage.TabIndex = 35
         Me.panMessage.Visible = False
         '
         'PictureBox1
         '
         Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
         Me.PictureBox1.Location = New System.Drawing.Point(12, 2)
         Me.PictureBox1.Name = "PictureBox1"
         Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
         Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
         Me.PictureBox1.TabIndex = 1
         Me.PictureBox1.TabStop = False
         '
         'lblMessage
         '
         Me.lblMessage.Location = New System.Drawing.Point(36, 0)
         Me.lblMessage.Name = "lblMessage"
         Me.lblMessage.Size = New System.Drawing.Size(360, 22)
         Me.lblMessage.TabIndex = 0
         Me.lblMessage.Text = "Pump package is only an option with a water chiller."
         Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         '
         'panControls
         '
         Me.panControls.Controls.Add(Me.cboStorageTankType)
         Me.panControls.Controls.Add(Me.lblDualPumpLabel)
         Me.panControls.Controls.Add(Me.cboStorageTankRatingPsi)
         Me.panControls.Controls.Add(Me.lblStorageTankRatingPsiLabel)
         Me.panControls.Controls.Add(Me.lblSuctionStrainerLabel)
         Me.panControls.Controls.Add(Me.lblSuctionTrimLabel)
         Me.panControls.Controls.Add(Me.cboSuctionStrainer)
         Me.panControls.Controls.Add(Me.cboSuctionTrim)
         Me.panControls.Controls.Add(Me.lblStorageTankLabel)
         Me.panControls.Controls.Add(Me.chkStorageTank)
         Me.panControls.Controls.Add(Me.cboPackage)
         Me.panControls.Controls.Add(Me.lblDesignCriteriaLabel)
         Me.panControls.Controls.Add(Me.lblPackageLabel)
         Me.panControls.Controls.Add(Me.cboDesignCriteria)
         Me.panControls.Controls.Add(Me.cboDesignCriteriaDualOption)
         Me.panControls.Controls.Add(Me.lblSpeedLabel)
         Me.panControls.Controls.Add(Me.lblTypeLabel)
         Me.panControls.Controls.Add(Me.cboSpeed)
         Me.panControls.Controls.Add(Me.cboType)
         Me.panControls.Controls.Add(Me.chkAirSeperator)
         Me.panControls.Controls.Add(Me.lblAirSeperatorLabel)
         Me.panControls.Controls.Add(Me.cboAirSeperator)
         Me.panControls.Controls.Add(Me.lblExpansionTankLabel)
         Me.panControls.Controls.Add(Me.chkExpansionTank)
         Me.panControls.Controls.Add(Me.cboExpansionTankType)
         Me.panControls.Controls.Add(Me.cboStorageRatingAsm)
         Me.panControls.Controls.Add(Me.txtStorageTankVolume)
         Me.panControls.Controls.Add(Me.lblStorageTankVolumeLimit)
         Me.panControls.Controls.Add(Me.lblStorageTankVolumeLabel)
         Me.panControls.Controls.Add(Me.lblStorageTankRating)
         Me.panControls.Location = New System.Drawing.Point(16, 44)
         Me.panControls.Name = "panControls"
         Me.panControls.Size = New System.Drawing.Size(520, 340)
         Me.panControls.TabIndex = 36
         '
         'cboStorageTankType
         '
         Me.cboStorageTankType.Items.AddRange(New Object() {"Open, Vented Tank", "Closed, Pressurized Tank"})
         Me.cboStorageTankType.Location = New System.Drawing.Point(248, 256)
         Me.cboStorageTankType.Name = "cboStorageTankType"
         Me.cboStorageTankType.Size = New System.Drawing.Size(168, 21)
         Me.cboStorageTankType.TabIndex = 36
         Me.cboStorageTankType.Text = "Open, Vented Tank"
         '
         'lblDualPumpLabel
         '
         Me.lblDualPumpLabel.Location = New System.Drawing.Point(8, 32)
         Me.lblDualPumpLabel.Name = "lblDualPumpLabel"
         Me.lblDualPumpLabel.Size = New System.Drawing.Size(192, 23)
         Me.lblDualPumpLabel.TabIndex = 35
         Me.lblDualPumpLabel.Text = "Dual pump option"
         Me.lblDualPumpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'PumpSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "PumpSpecBuilderWizard"
         Me.Tag = "Pump Package"
         Me.Text = "Untitled - SpecBuilder - Pump"
         Me.panMain.ResumeLayout(False)
         Me.panMessage.ResumeLayout(False)
         Me.panControls.ResumeLayout(False)

      End Sub

#End Region


      Dim optManager As New OptionManager(SpecData)


      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub


#Region " Event Handlers"

      Private Sub PumpSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetPump()
         Me.SetPumpControls()
         Me.SetDualPumpOptions()
         Me.SetAirSeperatorType()
         Me.SetExpansionTankType()
         Me.SetStorageTankType()
         Me.SetStorageTankVolume()
         Me.SetStorageTankRatingAsm()
         Me.SetStorageTankRatingPsi()
      End Sub

      Private Sub PumpSpecBuilderWizard_VisibleChanged(ByVal sender As Object, _
      ByVal e As EventArgs) Handles MyBase.VisibleChanged
         Me.SetPump()
         Me.SetPumpControls()
      End Sub

      Private Sub chkPumpPackage_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkPumpPackage.CheckedChanged
         Me.SpecData.Pump.PumpPackage = Me.chkPumpPackage.Checked

         Me.SetPumpControls()
      End Sub

      Private Sub cboDesignCriteria_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboDesignCriteria.SelectedIndexChanged
         Me.SpecData.Pump.DesignCriteria = Me.cboDesignCriteria.Text

         Me.SetDualPumpOptions()
      End Sub

      Private Sub cboDesignCriteriaDualOption_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboDesignCriteriaDualOption.SelectedIndexChanged
         Me.SpecData.Pump.DesignCriteriaDualOption = _
            Me.cboDesignCriteriaDualOption.Text
      End Sub

      Private Sub cboPackage_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboPackage.SelectedIndexChanged
         Me.SpecData.Pump.PackageDesign = Me.cboPackage.Text
      End Sub

      Private Sub cboSpeed_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboSpeed.SelectedIndexChanged
         Me.SpecData.Pump.Speed = Me.cboSpeed.Text
      End Sub

      Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
         Me.SpecData.Pump.PumpType = Me.cboType.Text
      End Sub

      Private Sub chkAirSeperator_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkAirSeperator.CheckedChanged
         Me.SpecData.Pump.AirSeperator = Me.chkAirSeperator.Checked

         Me.SetAirSeperatorType()
      End Sub

      Private Sub cboAirSeperator_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboAirSeperator.SelectedIndexChanged
         Me.SpecData.Pump.AirSeperatorDesign = Me.cboAirSeperator.Text
      End Sub

      Private Sub chkExpansionTank_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkExpansionTank.CheckedChanged
         Me.SpecData.Pump.ExpansionTank = Me.chkExpansionTank.Checked

         Me.SetExpansionTankType()
      End Sub

      Private Sub cboExpansionTankType_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboExpansionTankType.SelectedIndexChanged
         Me.SpecData.Pump.ExpansionTankType = Me.cboExpansionTankType.Text
      End Sub

      Private Sub cboSuctionStrainer_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboSuctionStrainer.SelectedIndexChanged
         Me.SpecData.Pump.SuctionStrainer = Me.cboSuctionStrainer.Text
      End Sub

      Private Sub cboSuctionTrim_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboSuctionTrim.SelectedIndexChanged
         Me.SpecData.Pump.SuctionTrim = Me.cboSuctionTrim.Text
      End Sub

      Private Sub chkStorageTank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStorageTank.CheckedChanged
         Me.SpecData.Pump.StorageTank = Me.chkStorageTank.Checked

         Me.SetStorageTankType()
         Me.SetStorageTankVolume()
         Me.SetStorageTankRatingAsm()
         Me.SetStorageTankRatingPsi()
      End Sub

      Private Sub txtStorageTankVolume_TextChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles txtStorageTankVolume.TextChanged
         Me.SpecData.Pump.StorageTankVolume = _
            CSng(Me.txtStorageTankVolume.Text)
      End Sub

      Private Sub cboStorageRatingAsm_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboStorageRatingAsm.SelectedIndexChanged
         Me.SpecData.Pump.StorageTankRatingAsm = Me.cboStorageRatingAsm.Text
      End Sub

      Private Sub cboStorageTankRatingPsi_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboStorageTankRatingPsi.SelectedIndexChanged
         Me.SpecData.Pump.StorageTankRatingPsi = Me.cboStorageTankRatingPsi.Text
      End Sub

      Private Sub cboStorageTankType_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboStorageTankType.SelectedIndexChanged
         Me.SpecData.Pump.StorageTankType = Me.cboStorageTankType.Text

         Me.SetStorageTankRatingPsi()
         Me.SetStorageTankRatingAsm()
      End Sub

#End Region


#Region " Set Controls"

      Private Sub SetPump()
         Dim pumpMessage As String

         pumpMessage = Me.optManager.GetPump.Explanation

         If Me.optManager.GetPump.IsOption Then
            'hide message
            Me.panMessage.Visible = False
            'enable controls
            Me.panControls.Enabled = True
            SpecBuilderManager.EnableControls(Me.lblPumpPackageLabel, Me.chkPumpPackage, Me.tip)
            Me.lblMessage.Text = String.Empty
         Else
            Me.panMessage.Visible = True
            'disables controls
            Me.panControls.Enabled = False
            SpecBuilderManager.DisableControls(Me.lblPumpPackageLabel, Me.chkPumpPackage, _
               Me.tip, pumpMessage)
            Me.lblMessage.Text = pumpMessage
         End If
      End Sub

      Private Sub SetPumpControls()
         If Me.optManager.GetPumpControls.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.panControls, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.panControls, _
               Me.tip, Me.optManager.GetPumpControls.Explanation)
         End If
      End Sub

      Private Sub SetDualPumpOptions()
         If Me.optManager.GetDualPumpOption.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblDualPumpLabel, _
               Me.cboDesignCriteriaDualOption, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblDualPumpLabel, _
               Me.cboDesignCriteriaDualOption, Me.tip, _
               Me.optManager.GetDualPumpOption.Explanation)
         End If
      End Sub

      Private Sub SetAirSeperatorType()
         If Me.optManager.GetAirSeperatorType.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboAirSeperator, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboAirSeperator, _
               Me.tip, Me.optManager.GetAirSeperatorType.Explanation)
         End If
      End Sub

      Private Sub SetExpansionTankType()
         If Me.optManager.GetExpansionTankType.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboExpansionTankType, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboExpansionTankType, _
               Me.tip, Me.optManager.GetExpansionTankType.Explanation)
         End If
      End Sub

      Private Sub SetStorageTankType()
         If Me.optManager.GetStorageTankType.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboStorageTankType, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboStorageTankType, _
               Me.tip, Me.optManager.GetStorageTankType.Explanation)
         End If
      End Sub

      Private Sub SetStorageTankVolume()
         If Me.optManager.GetStorageTankVolume.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblStorageTankVolumeLabel, _
               Me.txtStorageTankVolume, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblStorageTankVolumeLabel, _
               Me.txtStorageTankVolume, Me.tip, _
               Me.optManager.GetStorageTankVolume.Explanation)
         End If
      End Sub

      Private Sub SetStorageTankRatingAsm()
         If Me.optManager.GetStorageTankRatingAsm.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblStorageTankRating, _
               Me.cboStorageRatingAsm, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblStorageTankRating, _
               Me.cboStorageRatingAsm, Me.tip, _
               Me.optManager.GetStorageTankRatingAsm.Explanation)
         End If
      End Sub

      Private Sub SetStorageTankRatingPsi()
         If Me.optManager.GetStorageTankRatingPsi.IsOption Then
            SpecBuilderManager.EnableControls(New Label, _
               Me.cboStorageTankRatingPsi, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, _
               Me.cboStorageTankRatingPsi, Me.tip, _
               Me.optManager.GetStorageTankRatingPsi.Explanation)
         End If
      End Sub

#End Region


   End Class

End Namespace
