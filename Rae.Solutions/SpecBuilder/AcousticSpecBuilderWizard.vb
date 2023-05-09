Namespace SpecBuilder

   Public Class AcousticSpecBuilderWizard
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
      Friend WithEvents lblAcousticLabel As System.Windows.Forms.Label
      Friend WithEvents chkAcoustic As System.Windows.Forms.CheckBox
      Friend WithEvents lblCompressorsLabel As System.Windows.Forms.Label
      Friend WithEvents chkCompressors As System.Windows.Forms.CheckBox
      Friend WithEvents chkCondenserFans As System.Windows.Forms.CheckBox
      Friend WithEvents lblCondenserFansLabel As System.Windows.Forms.Label
      Friend WithEvents lblSpringIsolatorsLabel As System.Windows.Forms.Label
      Friend WithEvents lblCoveringLabel As System.Windows.Forms.Label
      Friend WithEvents cboCovering As System.Windows.Forms.ComboBox
      Friend WithEvents chkSpringIsolators As System.Windows.Forms.CheckBox
      Friend WithEvents cboFanType As System.Windows.Forms.ComboBox
      Friend WithEvents lblShroudLabel As System.Windows.Forms.Label
      Friend WithEvents chkShroud As System.Windows.Forms.CheckBox
        'Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
        Friend WithEvents panControls As System.Windows.Forms.Panel
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblAcousticLabel = New System.Windows.Forms.Label
         Me.chkAcoustic = New System.Windows.Forms.CheckBox
         Me.lblCompressorsLabel = New System.Windows.Forms.Label
         Me.lblSpringIsolatorsLabel = New System.Windows.Forms.Label
         Me.lblCoveringLabel = New System.Windows.Forms.Label
         Me.chkCompressors = New System.Windows.Forms.CheckBox
         Me.cboCovering = New System.Windows.Forms.ComboBox
         Me.chkSpringIsolators = New System.Windows.Forms.CheckBox
         Me.chkCondenserFans = New System.Windows.Forms.CheckBox
         Me.lblCondenserFansLabel = New System.Windows.Forms.Label
         Me.cboFanType = New System.Windows.Forms.ComboBox
         Me.lblShroudLabel = New System.Windows.Forms.Label
         Me.chkShroud = New System.Windows.Forms.CheckBox
         Me.panControls = New System.Windows.Forms.Panel
            ''Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder
            Me.panMain.SuspendLayout()
         Me.panBottom.SuspendLayout()
         Me.panControls.SuspendLayout()
            ''CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.Controls.Add(Me.panControls)
         Me.panMain.Controls.Add(Me.chkAcoustic)
         Me.panMain.Controls.Add(Me.lblAcousticLabel)
         Me.panMain.Controls.SetChildIndex(Me.lblAcousticLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkAcoustic, 0)
         Me.panMain.Controls.SetChildIndex(Me.panControls, 0)
         '
         'lblAcousticLabel
         '
         Me.lblAcousticLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.lblAcousticLabel.Location = New System.Drawing.Point(20, 20)
         Me.lblAcousticLabel.Name = "lblAcousticLabel"
         Me.lblAcousticLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblAcousticLabel.TabIndex = 2
         Me.lblAcousticLabel.Text = "Acoustic Treatment"
         Me.lblAcousticLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkAcoustic
         '
         Me.chkAcoustic.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkAcoustic.Location = New System.Drawing.Point(232, 20)
         Me.chkAcoustic.Name = "chkAcoustic"
         Me.chkAcoustic.Size = New System.Drawing.Size(104, 24)
         Me.chkAcoustic.TabIndex = 3
         '
         'lblCompressorsLabel
         '
         Me.lblCompressorsLabel.Location = New System.Drawing.Point(4, 4)
         Me.lblCompressorsLabel.Name = "lblCompressorsLabel"
         Me.lblCompressorsLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblCompressorsLabel.TabIndex = 4
         Me.lblCompressorsLabel.Text = "Compressors"
         Me.lblCompressorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblSpringIsolatorsLabel
         '
         Me.lblSpringIsolatorsLabel.Location = New System.Drawing.Point(4, 60)
         Me.lblSpringIsolatorsLabel.Name = "lblSpringIsolatorsLabel"
         Me.lblSpringIsolatorsLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblSpringIsolatorsLabel.TabIndex = 6
         Me.lblSpringIsolatorsLabel.Text = "Install compressor on spring isolators"
         Me.lblSpringIsolatorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCoveringLabel
         '
         Me.lblCoveringLabel.Location = New System.Drawing.Point(4, 32)
         Me.lblCoveringLabel.Name = "lblCoveringLabel"
         Me.lblCoveringLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblCoveringLabel.TabIndex = 5
         Me.lblCoveringLabel.Text = "Compressor covering"
         Me.lblCoveringLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkCompressors
         '
         Me.chkCompressors.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkCompressors.Location = New System.Drawing.Point(216, 4)
         Me.chkCompressors.Name = "chkCompressors"
         Me.chkCompressors.Size = New System.Drawing.Size(104, 24)
         Me.chkCompressors.TabIndex = 7
         '
         'cboCovering
         '
         Me.cboCovering.DropDownWidth = 190
         Me.cboCovering.Items.AddRange(New Object() {"None", "Compressor Wraps", "Acoustically Lined Compressor House"})
         Me.cboCovering.Location = New System.Drawing.Point(248, 32)
         Me.cboCovering.Name = "cboCovering"
         Me.cboCovering.Size = New System.Drawing.Size(220, 21)
         Me.cboCovering.TabIndex = 8
         Me.cboCovering.Text = "None"
         '
         'chkSpringIsolators
         '
         Me.chkSpringIsolators.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkSpringIsolators.Location = New System.Drawing.Point(248, 60)
         Me.chkSpringIsolators.Name = "chkSpringIsolators"
         Me.chkSpringIsolators.Size = New System.Drawing.Size(104, 24)
         Me.chkSpringIsolators.TabIndex = 9
         '
         'chkCondenserFans
         '
         Me.chkCondenserFans.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkCondenserFans.Location = New System.Drawing.Point(216, 88)
         Me.chkCondenserFans.Name = "chkCondenserFans"
         Me.chkCondenserFans.Size = New System.Drawing.Size(104, 24)
         Me.chkCondenserFans.TabIndex = 11
         '
         'lblCondenserFansLabel
         '
         Me.lblCondenserFansLabel.Location = New System.Drawing.Point(4, 88)
         Me.lblCondenserFansLabel.Name = "lblCondenserFansLabel"
         Me.lblCondenserFansLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblCondenserFansLabel.TabIndex = 10
         Me.lblCondenserFansLabel.Text = "Condenser fans"
         Me.lblCondenserFansLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboFanType
         '
         Me.cboFanType.Items.AddRange(New Object() {"850 RPM", "Low Speed Centrifugal"})
         Me.cboFanType.Location = New System.Drawing.Point(248, 88)
         Me.cboFanType.Name = "cboFanType"
         Me.cboFanType.Size = New System.Drawing.Size(220, 21)
         Me.cboFanType.TabIndex = 13
         Me.cboFanType.Text = "850 RPM"
         '
         'lblShroudLabel
         '
         Me.lblShroudLabel.Location = New System.Drawing.Point(4, 116)
         Me.lblShroudLabel.Name = "lblShroudLabel"
         Me.lblShroudLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblShroudLabel.TabIndex = 14
         Me.lblShroudLabel.Text = "18"" acoustic permiter shroud"
         Me.lblShroudLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkShroud
         '
         Me.chkShroud.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkShroud.Location = New System.Drawing.Point(248, 116)
         Me.chkShroud.Name = "chkShroud"
         Me.chkShroud.Size = New System.Drawing.Size(104, 24)
         Me.chkShroud.TabIndex = 15
         '
         'panControls
         '
         Me.panControls.Controls.Add(Me.chkCompressors)
         Me.panControls.Controls.Add(Me.chkSpringIsolators)
         Me.panControls.Controls.Add(Me.cboCovering)
         Me.panControls.Controls.Add(Me.cboFanType)
         Me.panControls.Controls.Add(Me.lblCondenserFansLabel)
         Me.panControls.Controls.Add(Me.chkCondenserFans)
         Me.panControls.Controls.Add(Me.lblCompressorsLabel)
         Me.panControls.Controls.Add(Me.lblShroudLabel)
         Me.panControls.Controls.Add(Me.lblSpringIsolatorsLabel)
         Me.panControls.Controls.Add(Me.chkShroud)
         Me.panControls.Controls.Add(Me.lblCoveringLabel)
         Me.panControls.Location = New System.Drawing.Point(16, 44)
         Me.panControls.Name = "panControls"
         Me.panControls.Size = New System.Drawing.Size(508, 152)
         Me.panControls.TabIndex = 16
            '
            'C1CommandHolder1
            '
            ''Me.C1CommandHolder1.Owner = Me
            '
            'AcousticSpecBuilderWizard
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "AcousticSpecBuilderWizard"
         Me.Tag = "Acoustic Treatment"
         Me.Text = "Untitled - SpecBuilder - Acoustic"
         Me.panMain.ResumeLayout(False)
         Me.panBottom.ResumeLayout(False)
         Me.panControls.ResumeLayout(False)
            ''CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

      End Sub

#End Region

      Dim optManager As New OptionManager(SpecData)

      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilder.SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub

#Region " Event Handlers"

      Private Sub AcousticSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetAcousticControls()
         Me.SetCompressorCovering()
         Me.SetCompressorSpringIsolators()
         Me.SetCondenserFanType()
         Me.SetCondenserShroud()
      End Sub

      Private Sub AcousticSpecBuilderWizard_VisibleChanged(ByVal sender As Object, _
      ByVal e As EventArgs) Handles MyBase.VisibleChanged
         If Me.isDisposing Then Exit Sub
         Me.SetCompressorSpringIsolators()
      End Sub

      Private Sub chkAcoustic_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkAcoustic.CheckedChanged
         Me.SpecData.Acoustic.Acoustic = Me.chkAcoustic.Checked

         Me.SetAcousticControls()
      End Sub

      Private Sub chkCompressors_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkCompressors.CheckedChanged
         Me.SpecData.Acoustic.Compressors = Me.chkCompressors.Checked

         Me.SetCompressorSpringIsolators()
         Me.SetCompressorCovering()
      End Sub

      Private Sub cboCovering_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboCovering.SelectedIndexChanged
         Me.SpecData.Acoustic.CompressorCovering = Me.cboCovering.Text
      End Sub

      Private Sub chkSpringIsolators_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkSpringIsolators.CheckedChanged
         Me.SpecData.Acoustic.CompressorSpringIsolator = _
            Me.chkSpringIsolators.Checked
      End Sub

      Private Sub chkCondenserFans_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkCondenserFans.CheckedChanged
         Me.SpecData.Acoustic.CondenserFans = Me.chkCondenserFans.Checked

         Me.SetCondenserFanType()
         Me.SetCondenserShroud()
      End Sub

      Private Sub cboFanType_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboFanType.SelectedIndexChanged
         Me.SpecData.Acoustic.CondenserFanType = Me.cboFanType.Text
      End Sub

      Private Sub chkShroud_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkShroud.CheckedChanged
         Me.SpecData.Acoustic.CondenserShroud = Me.chkShroud.Checked
      End Sub

#End Region

#Region " Set Controls"

      Private Sub SetAcousticControls()
         Me.panControls.Enabled = Me.SpecData.Acoustic.Acoustic
      End Sub

      Private Sub SetCompressorCovering()
         If Me.optManager.GetCompressorCovering.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblCoveringLabel, Me.cboCovering, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblCoveringLabel, _
               Me.cboCovering, Me.tip, _
               Me.optManager.GetCompressorCovering.Explanation)
         End If
      End Sub

      Private Sub SetCompressorSpringIsolators()
         If Me.optManager.GetCompressorSpringIsolators.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblSpringIsolatorsLabel, _
               Me.chkSpringIsolators, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblSpringIsolatorsLabel, _
               Me.chkSpringIsolators, Me.tip, _
               Me.optManager.GetCompressorSpringIsolators.Explanation)
         End If
      End Sub

      Private Sub SetCondenserFanType()
         If Me.optManager.GetCondenserFanType.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboFanType, Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboFanType, Me.tip, _
               Me.optManager.GetCondenserFanType.Explanation)
         End If
      End Sub

      Private Sub SetCondenserShroud()
         If Me.optManager.GetCondenserShroud.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblShroudLabel, Me.chkShroud, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblShroudLabel, Me.chkShroud, _
               Me.tip, Me.optManager.GetCondenserShroud.Explanation)
         End If
      End Sub

#End Region

   End Class

End Namespace