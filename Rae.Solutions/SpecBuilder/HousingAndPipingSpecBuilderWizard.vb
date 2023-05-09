Imports Rae.RaeSolutions.SpecBuilder.SpecBuilderManager

Namespace SpecBuilder

   Public Class HousingAndPipingSpecBuilderWizard
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
      Friend WithEvents lblBaseFrame As System.Windows.Forms.Label
      Friend WithEvents lblHousing As System.Windows.Forms.Label
      Friend WithEvents lblEpoxyCoatedLabel As System.Windows.Forms.Label
      Friend WithEvents lblPiping As System.Windows.Forms.Label
      Friend WithEvents cboBaseFrame As System.Windows.Forms.ComboBox
      Friend WithEvents cboHousing As System.Windows.Forms.ComboBox
      Friend WithEvents cboPiping As System.Windows.Forms.ComboBox
      Friend WithEvents chkEpoxyCoated As System.Windows.Forms.CheckBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.cboBaseFrame = New System.Windows.Forms.ComboBox
         Me.cboHousing = New System.Windows.Forms.ComboBox
         Me.cboPiping = New System.Windows.Forms.ComboBox
         Me.chkEpoxyCoated = New System.Windows.Forms.CheckBox
         Me.lblBaseFrame = New System.Windows.Forms.Label
         Me.lblHousing = New System.Windows.Forms.Label
         Me.lblEpoxyCoatedLabel = New System.Windows.Forms.Label
         Me.lblPiping = New System.Windows.Forms.Label
         Me.panMain.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.Controls.Add(Me.lblPiping)
         Me.panMain.Controls.Add(Me.lblEpoxyCoatedLabel)
         Me.panMain.Controls.Add(Me.lblHousing)
         Me.panMain.Controls.Add(Me.lblBaseFrame)
         Me.panMain.Controls.Add(Me.chkEpoxyCoated)
         Me.panMain.Controls.Add(Me.cboPiping)
         Me.panMain.Controls.Add(Me.cboHousing)
         Me.panMain.Controls.Add(Me.cboBaseFrame)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.cboBaseFrame, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboHousing, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboPiping, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkEpoxyCoated, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblBaseFrame, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblHousing, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblEpoxyCoatedLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblPiping, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'cboBaseFrame
         '
         Me.cboBaseFrame.DropDownWidth = 250
         Me.cboBaseFrame.Items.AddRange(New Object() {"G-90 galvanized sheet metal 12 Ga. minimum", "epoxy coated structural carbon steel"})
         Me.cboBaseFrame.Location = New System.Drawing.Point(232, 20)
         Me.cboBaseFrame.Name = "cboBaseFrame"
         Me.cboBaseFrame.Size = New System.Drawing.Size(288, 21)
         Me.cboBaseFrame.TabIndex = 0
         Me.cboBaseFrame.Text = "G-90 galvanized sheet metal 12 Ga. minimum"
         '
         'cboHousing
         '
         Me.cboHousing.DropDownWidth = 230
         Me.cboHousing.Items.AddRange(New Object() {"heavy gauge G-90 galvanized steel", "304 stainless steel", "316 stainless steel with 304 SS hardware"})
         Me.cboHousing.Location = New System.Drawing.Point(232, 48)
         Me.cboHousing.Name = "cboHousing"
         Me.cboHousing.Size = New System.Drawing.Size(288, 21)
         Me.cboHousing.TabIndex = 1
         Me.cboHousing.Text = "heavy gauge G-90 galvanized steel"
         '
         'cboPiping
         '
         Me.cboPiping.DropDownWidth = 385
         Me.cboPiping.Items.AddRange(New Object() {"Type L hard copper [through 4"" pipe size]", "all ferrous Schedule 40 black piping with welded joints [6"" pipe and larger]"})
         Me.cboPiping.Location = New System.Drawing.Point(232, 108)
         Me.cboPiping.Name = "cboPiping"
         Me.cboPiping.Size = New System.Drawing.Size(288, 21)
         Me.cboPiping.TabIndex = 2
         Me.cboPiping.Text = "Type L hard copper [through 4"" pipe size]"
         '
         'chkEpoxyCoated
         '
         Me.chkEpoxyCoated.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkEpoxyCoated.Location = New System.Drawing.Point(248, 76)
         Me.chkEpoxyCoated.Name = "chkEpoxyCoated"
         Me.chkEpoxyCoated.TabIndex = 3
         '
         'lblBaseFrame
         '
         Me.lblBaseFrame.Location = New System.Drawing.Point(56, 20)
         Me.lblBaseFrame.Name = "lblBaseFrame"
         Me.lblBaseFrame.Size = New System.Drawing.Size(156, 23)
         Me.lblBaseFrame.TabIndex = 4
         Me.lblBaseFrame.Text = "Base frame"
         Me.lblBaseFrame.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblHousing
         '
         Me.lblHousing.Location = New System.Drawing.Point(56, 48)
         Me.lblHousing.Name = "lblHousing"
         Me.lblHousing.Size = New System.Drawing.Size(156, 23)
         Me.lblHousing.TabIndex = 5
         Me.lblHousing.Text = "Housing"
         Me.lblHousing.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblEpoxyCoatedLabel
         '
         Me.lblEpoxyCoatedLabel.Location = New System.Drawing.Point(56, 76)
         Me.lblEpoxyCoatedLabel.Name = "lblEpoxyCoatedLabel"
         Me.lblEpoxyCoatedLabel.Size = New System.Drawing.Size(156, 23)
         Me.lblEpoxyCoatedLabel.TabIndex = 6
         Me.lblEpoxyCoatedLabel.Text = "Epoxy coated"
         Me.lblEpoxyCoatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblPiping
         '
         Me.lblPiping.Location = New System.Drawing.Point(56, 108)
         Me.lblPiping.Name = "lblPiping"
         Me.lblPiping.Size = New System.Drawing.Size(156, 23)
         Me.lblPiping.TabIndex = 7
         Me.lblPiping.Text = "Interconnecting piping"
         Me.lblPiping.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'HousingAndPipingSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "HousingAndPipingSpecBuilderWizard"
         Me.Tag = "Housing and Interconnecting Piping"
         Me.Text = "Untitled - SpecBuilder - Housing and Interconnect Piping"
         Me.panMain.ResumeLayout(False)

      End Sub

#End Region

      Dim optManager As New OptionManager(SpecData)


      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilder.SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub


#Region " Event Handlers"

      Private Sub HousingAndPipingSpecBuilderWizard_Load( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles MyBase.Load
         Me.SetPipingControls()
         Me.SetEpoxyCoatedControls()
      End Sub


      Private Sub Me_VisbilityChanged(ByVal sender As Object, ByVal e As EventArgs) _
      Handles MyBase.VisibleChanged
         If Me.isDisposing Then Exit Sub
         Me.SetPipingControls()
         Me.SetEpoxyCoatedControls()
      End Sub


      Private Sub cboBaseFrame_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboBaseFrame.SelectedIndexChanged
         Me.SpecData.HousingAndPiping.BaseFrame = Me.cboBaseFrame.Text
      End Sub


      Private Sub cboHousing_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboHousing.SelectedIndexChanged
         Me.SpecData.HousingAndPiping.Housing = Me.cboHousing.Text
         Me.SetEpoxyCoatedControls()
      End Sub


      Private Sub chkEpoxyCoated_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkEpoxyCoated.CheckedChanged
         Me.SpecData.HousingAndPiping.EpoxyCoated = Me.chkEpoxyCoated.Checked
      End Sub


      Private Sub cboPiping_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboPiping.SelectedIndexChanged
         Me.SpecData.HousingAndPiping.Piping = Me.cboPiping.Text
      End Sub

#End Region


      Private Sub SetPipingControls()
         If optManager.GetPiping.IsOption Then
            EnableControls(Me.lblPiping, Me.cboPiping, Me.tip)
         Else
            DisableControls(Me.lblPiping, Me.cboPiping, _
               Me.tip, Me.optManager.GetPiping.Explanation)
         End If
      End Sub


      Private Sub SetEpoxyCoatedControls()
         If optManager.GetEpoxyCoated.IsOption Then
            EnableControls(Me.lblEpoxyCoatedLabel, Me.chkEpoxyCoated, Me.tip)
         Else
            DisableControls(Me.lblEpoxyCoatedLabel, Me.chkEpoxyCoated, Me.tip, _
               Me.optManager.GetEpoxyCoated.Explanation)
         End If
      End Sub


   End Class

End Namespace
