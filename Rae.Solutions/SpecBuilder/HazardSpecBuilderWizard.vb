Namespace SpecBuilder

   Public Class HazardSpecBuilderWizard
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
      Friend WithEvents lblStructuralBaseLabel As System.Windows.Forms.Label
      Friend WithEvents lblHazardLabel As System.Windows.Forms.Label
      Friend WithEvents lblCondenserFinsLabel As System.Windows.Forms.Label
      Friend WithEvents lblCondenserCasingsLabel As System.Windows.Forms.Label
      Friend WithEvents lblHazardousDutyClassificationLabel As System.Windows.Forms.Label
      Friend WithEvents chkHazard As System.Windows.Forms.CheckBox
      Friend WithEvents cboStructuralBase As System.Windows.Forms.ComboBox
      Friend WithEvents cboCondenserCasings As System.Windows.Forms.ComboBox
      Friend WithEvents cboCondenserFins As System.Windows.Forms.ComboBox
      Friend WithEvents chkHazardousDutyClassification As System.Windows.Forms.CheckBox
      Friend WithEvents panControls As System.Windows.Forms.Panel
      Friend WithEvents lblControlEnclosureLabel As System.Windows.Forms.Label
      Friend WithEvents cboControlEnclosure As System.Windows.Forms.ComboBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblStructuralBaseLabel = New System.Windows.Forms.Label
         Me.lblHazardLabel = New System.Windows.Forms.Label
         Me.lblCondenserFinsLabel = New System.Windows.Forms.Label
         Me.lblCondenserCasingsLabel = New System.Windows.Forms.Label
         Me.lblHazardousDutyClassificationLabel = New System.Windows.Forms.Label
         Me.lblControlEnclosureLabel = New System.Windows.Forms.Label
         Me.chkHazard = New System.Windows.Forms.CheckBox
         Me.cboStructuralBase = New System.Windows.Forms.ComboBox
         Me.cboCondenserCasings = New System.Windows.Forms.ComboBox
         Me.cboCondenserFins = New System.Windows.Forms.ComboBox
         Me.cboControlEnclosure = New System.Windows.Forms.ComboBox
         Me.chkHazardousDutyClassification = New System.Windows.Forms.CheckBox
         Me.panControls = New System.Windows.Forms.Panel
         Me.panMain.SuspendLayout()
         Me.panControls.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.Controls.Add(Me.panControls)
         Me.panMain.Controls.Add(Me.chkHazard)
         Me.panMain.Controls.Add(Me.lblHazardLabel)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.lblHazardLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.chkHazard, 0)
         Me.panMain.Controls.SetChildIndex(Me.panControls, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblStructuralBaseLabel
         '
         Me.lblStructuralBaseLabel.Location = New System.Drawing.Point(4, 4)
         Me.lblStructuralBaseLabel.Name = "lblStructuralBaseLabel"
         Me.lblStructuralBaseLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblStructuralBaseLabel.TabIndex = 2
         Me.lblStructuralBaseLabel.Text = "Cabinetry and structural base"
         Me.lblStructuralBaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblHazardLabel
         '
         Me.lblHazardLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.lblHazardLabel.Location = New System.Drawing.Point(20, 20)
         Me.lblHazardLabel.Name = "lblHazardLabel"
         Me.lblHazardLabel.Size = New System.Drawing.Size(196, 32)
         Me.lblHazardLabel.TabIndex = 3
         Me.lblHazardLabel.Text = "Corrosion resistance/hazardous duty options"
         Me.lblHazardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCondenserFinsLabel
         '
         Me.lblCondenserFinsLabel.Location = New System.Drawing.Point(4, 60)
         Me.lblCondenserFinsLabel.Name = "lblCondenserFinsLabel"
         Me.lblCondenserFinsLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblCondenserFinsLabel.TabIndex = 5
         Me.lblCondenserFinsLabel.Text = "Condenser fins"
         Me.lblCondenserFinsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCondenserCasingsLabel
         '
         Me.lblCondenserCasingsLabel.Location = New System.Drawing.Point(4, 32)
         Me.lblCondenserCasingsLabel.Name = "lblCondenserCasingsLabel"
         Me.lblCondenserCasingsLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblCondenserCasingsLabel.TabIndex = 4
         Me.lblCondenserCasingsLabel.Text = "Condenser casings"
         Me.lblCondenserCasingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblHazardousDutyClassificationLabel
         '
         Me.lblHazardousDutyClassificationLabel.Location = New System.Drawing.Point(4, 116)
         Me.lblHazardousDutyClassificationLabel.Name = "lblHazardousDutyClassificationLabel"
         Me.lblHazardousDutyClassificationLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblHazardousDutyClassificationLabel.TabIndex = 7
         Me.lblHazardousDutyClassificationLabel.Text = "Hazardous duty classification"
         Me.lblHazardousDutyClassificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblControlEnclosureLabel
         '
         Me.lblControlEnclosureLabel.Location = New System.Drawing.Point(4, 88)
         Me.lblControlEnclosureLabel.Name = "lblControlEnclosureLabel"
         Me.lblControlEnclosureLabel.Size = New System.Drawing.Size(196, 23)
         Me.lblControlEnclosureLabel.TabIndex = 6
         Me.lblControlEnclosureLabel.Text = "Control enclosure"
         Me.lblControlEnclosureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'chkHazard
         '
         Me.chkHazard.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkHazard.Location = New System.Drawing.Point(232, 20)
         Me.chkHazard.Name = "chkHazard"
         Me.chkHazard.TabIndex = 8
         '
         'cboStructuralBase
         '
         Me.cboStructuralBase.Items.AddRange(New Object() {"304 Stainless", "316 Stainless", "Epoxy Coated Inside and Out"})
         Me.cboStructuralBase.Location = New System.Drawing.Point(216, 4)
         Me.cboStructuralBase.Name = "cboStructuralBase"
         Me.cboStructuralBase.Size = New System.Drawing.Size(228, 21)
         Me.cboStructuralBase.TabIndex = 9
         Me.cboStructuralBase.Text = "304 Stainless"
         '
         'cboCondenserCasings
         '
         Me.cboCondenserCasings.Items.AddRange(New Object() {"304 Stainless", "Epoxy Coated"})
         Me.cboCondenserCasings.Location = New System.Drawing.Point(216, 32)
         Me.cboCondenserCasings.Name = "cboCondenserCasings"
         Me.cboCondenserCasings.Size = New System.Drawing.Size(228, 21)
         Me.cboCondenserCasings.TabIndex = 10
         Me.cboCondenserCasings.Text = "304 Stainless"
         '
         'cboCondenserFins
         '
         Me.cboCondenserFins.Items.AddRange(New Object() {"Aluminum", "Copper", "Phenolic Coated", "Electro-Fin", "Acrylic Coated"})
         Me.cboCondenserFins.Location = New System.Drawing.Point(216, 60)
         Me.cboCondenserFins.Name = "cboCondenserFins"
         Me.cboCondenserFins.Size = New System.Drawing.Size(228, 21)
         Me.cboCondenserFins.TabIndex = 11
         Me.cboCondenserFins.Text = "Aluminum"
         '
         'cboControlEnclosure
         '
         Me.cboControlEnclosure.DropDownWidth = 190
         Me.cboControlEnclosure.Items.AddRange(New Object() {"NEMA 7", "NEMA 4X", "NEMAX with Purge Manifold"})
         Me.cboControlEnclosure.Location = New System.Drawing.Point(216, 88)
         Me.cboControlEnclosure.Name = "cboControlEnclosure"
         Me.cboControlEnclosure.Size = New System.Drawing.Size(228, 21)
         Me.cboControlEnclosure.TabIndex = 12
         Me.cboControlEnclosure.Text = "NEMA 7"
         '
         'chkHazardousDutyClassification
         '
         Me.chkHazardousDutyClassification.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.chkHazardousDutyClassification.Location = New System.Drawing.Point(216, 116)
         Me.chkHazardousDutyClassification.Name = "chkHazardousDutyClassification"
         Me.chkHazardousDutyClassification.TabIndex = 13
         '
         'panControls
         '
         Me.panControls.Controls.Add(Me.chkHazardousDutyClassification)
         Me.panControls.Controls.Add(Me.cboCondenserCasings)
         Me.panControls.Controls.Add(Me.cboControlEnclosure)
         Me.panControls.Controls.Add(Me.cboCondenserFins)
         Me.panControls.Controls.Add(Me.lblCondenserFinsLabel)
         Me.panControls.Controls.Add(Me.lblStructuralBaseLabel)
         Me.panControls.Controls.Add(Me.lblControlEnclosureLabel)
         Me.panControls.Controls.Add(Me.lblHazardousDutyClassificationLabel)
         Me.panControls.Controls.Add(Me.cboStructuralBase)
         Me.panControls.Controls.Add(Me.lblCondenserCasingsLabel)
         Me.panControls.Location = New System.Drawing.Point(16, 52)
         Me.panControls.Name = "panControls"
         Me.panControls.Size = New System.Drawing.Size(484, 152)
         Me.panControls.TabIndex = 14
         '
         'HazardSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "HazardSpecBuilderWizard"
         Me.Tag = "Corrosion Resistance/Hazardous Duty Options"
         Me.Text = "Untitled - SpecBuilder - Hazard"
         Me.panMain.ResumeLayout(False)
         Me.panControls.ResumeLayout(False)

      End Sub

#End Region

      Dim optManager As New SpecBuilder.OptionManager(SpecData)


      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilder.SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub


#Region " Event Handlers"

      Private Sub HazardSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetHazardControls()
      End Sub

      Private Sub chkHazard_CheckedChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles chkHazard.CheckedChanged
         Me.SpecData.Hazard.Hazard = Me.chkHazard.Checked

         Me.SetHazardControls()
      End Sub

      Private Sub cboStructuralBase_SelectedIndexChanged(ByVal sender As System.Object _
      , ByVal e As System.EventArgs) Handles cboStructuralBase.SelectedIndexChanged
         Me.SpecData.Hazard.StructuralBase = Me.cboStructuralBase.Text
      End Sub

      Private Sub cboCondenserCasings_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboCondenserCasings.SelectedIndexChanged
         Me.SpecData.Hazard.CondenserCasings = Me.cboCondenserCasings.Text
      End Sub

      Private Sub cboCondenserFins_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboCondenserFins.SelectedIndexChanged
         Me.SpecData.Hazard.CondenserFins = Me.cboCondenserFins.Text
      End Sub

      Private Sub cboControlEnclosures_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboControlEnclosure.SelectedIndexChanged
         Me.SpecData.Hazard.ControlEnclosure = Me.cboControlEnclosure.Text
      End Sub

      Private Sub chkHazardousDutyClassification_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles chkHazardousDutyClassification.CheckedChanged
         Me.SpecData.Hazard.HazardousDutyClassification = _
            Me.chkHazardousDutyClassification.Checked
      End Sub

#End Region


      Private Sub SetHazardControls()
         Me.panControls.Enabled = Me.optManager.GetHazard.IsOption
      End Sub

   End Class

End Namespace
