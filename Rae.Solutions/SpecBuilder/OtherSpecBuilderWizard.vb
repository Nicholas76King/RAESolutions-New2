Namespace SpecBuilder

   Public Class OtherSpecBuilderWizard
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
      Friend WithEvents lblWatersideEconomizerLabel As System.Windows.Forms.Label
      Friend WithEvents chkWatersideEconomizer As System.Windows.Forms.CheckBox
      Friend WithEvents lblAdditionalWarrantyLabel As System.Windows.Forms.Label
      Friend WithEvents lblSupervisedStartupLabel As System.Windows.Forms.Label
      Friend WithEvents chkAdditionalWarranty As System.Windows.Forms.CheckBox
      Friend WithEvents chkSupervisedStartup As System.Windows.Forms.CheckBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblWatersideEconomizerLabel = New System.Windows.Forms.Label
         Me.lblAdditionalWarrantyLabel = New System.Windows.Forms.Label
         Me.lblSupervisedStartupLabel = New System.Windows.Forms.Label
         Me.chkWatersideEconomizer = New System.Windows.Forms.CheckBox
         Me.chkAdditionalWarranty = New System.Windows.Forms.CheckBox
         Me.chkSupervisedStartup = New System.Windows.Forms.CheckBox
         Me.panMain.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.Controls.Add(Me.chkSupervisedStartup)
         Me.panMain.Controls.Add(Me.chkAdditionalWarranty)
         Me.panMain.Controls.Add(Me.chkWatersideEconomizer)
         Me.panMain.Controls.Add(Me.lblSupervisedStartupLabel)
         Me.panMain.Controls.Add(Me.lblAdditionalWarrantyLabel)
         Me.panMain.Controls.Add(Me.lblWatersideEconomizerLabel)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.lblWatersideEconomizerLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblAdditionalWarrantyLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblSupervisedStartupLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkWatersideEconomizer, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkAdditionalWarranty, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkSupervisedStartup, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblWatersideEconomizerLabel
         '
         Me.lblWatersideEconomizerLabel.Location = New System.Drawing.Point(20, 20)
         Me.lblWatersideEconomizerLabel.Name = "lblWatersideEconomizerLabel"
         Me.lblWatersideEconomizerLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblWatersideEconomizerLabel.TabIndex = 2
         Me.lblWatersideEconomizerLabel.Text = "Waterside economizer"
         Me.lblWatersideEconomizerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblAdditionalWarrantyLabel
         '
         Me.lblAdditionalWarrantyLabel.Location = New System.Drawing.Point(20, 48)
         Me.lblAdditionalWarrantyLabel.Name = "lblAdditionalWarrantyLabel"
         Me.lblAdditionalWarrantyLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblAdditionalWarrantyLabel.TabIndex = 3
         Me.lblAdditionalWarrantyLabel.Text = "Additional warranty"
         Me.lblAdditionalWarrantyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblSupervisedStartupLabel
         '
         Me.lblSupervisedStartupLabel.Location = New System.Drawing.Point(20, 76)
         Me.lblSupervisedStartupLabel.Name = "lblSupervisedStartupLabel"
         Me.lblSupervisedStartupLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblSupervisedStartupLabel.TabIndex = 4
         Me.lblSupervisedStartupLabel.Text = "Factory supervised startup"
         Me.lblSupervisedStartupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkWatersideEconomizer
         '
         Me.chkWatersideEconomizer.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkWatersideEconomizer.Location = New System.Drawing.Point(232, 20)
         Me.chkWatersideEconomizer.Name = "chkWatersideEconomizer"
         Me.chkWatersideEconomizer.TabIndex = 5
         '
         'chkAdditionalWarranty
         '
         Me.chkAdditionalWarranty.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkAdditionalWarranty.Location = New System.Drawing.Point(232, 48)
         Me.chkAdditionalWarranty.Name = "chkAdditionalWarranty"
         Me.chkAdditionalWarranty.Size = New System.Drawing.Size(300, 24)
         Me.chkAdditionalWarranty.TabIndex = 6
         Me.chkAdditionalWarranty.Text = "Additional 4 yr warranty on parts for compressor only"
         '
         'chkSupervisedStartup
         '
         Me.chkSupervisedStartup.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkSupervisedStartup.Location = New System.Drawing.Point(232, 76)
         Me.chkSupervisedStartup.Name = "chkSupervisedStartup"
         Me.chkSupervisedStartup.TabIndex = 7
         '
         'OtherSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "OtherSpecBuilderWizard"
         Me.Tag = "Other"
         Me.Text = "Untitled - SpecBuilder - Other"
         Me.panMain.ResumeLayout(False)

      End Sub

#End Region


      Dim optManager As New OptionManager(SpecData)


      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilder.SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub

      Private Sub OtherSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetWatersideEconomizerControls()
      End Sub

      Private Sub OtherSpecBuilderWizard_VisibleChanged(ByVal sender As Object, _
      ByVal e As EventArgs) Handles MyBase.VisibleChanged
         If Me.isDisposing Then Exit Sub
         Me.SetWatersideEconomizerControls()
      End Sub

      Private Sub chkWatersideEconomizer_CheckedChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles chkWatersideEconomizer.CheckedChanged
         Me.SpecData.Other.WatersideEconomizer = Me.chkWatersideEconomizer.Checked
      End Sub

      Private Sub chkAdditionalWarranty_CheckedChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles chkAdditionalWarranty.CheckedChanged
         Me.SpecData.Other.AdditionalWarranty = Me.chkAdditionalWarranty.Checked
      End Sub

      Private Sub chkSupervisedStartup_CheckedChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles chkSupervisedStartup.CheckedChanged
         Me.SpecData.Other.SupervisedStartup = Me.chkSupervisedStartup.Checked
      End Sub


      Private Sub SetWatersideEconomizerControls()
         If Me.optManager.GetWatersideEconomizer.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblWatersideEconomizerLabel, _
               Me.chkWatersideEconomizer, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblWatersideEconomizerLabel, _
               Me.chkWatersideEconomizer, Me.tip, _
               Me.optManager.GetWatersideEconomizer.Explanation)
         End If
      End Sub


   End Class
End Namespace