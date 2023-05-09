Namespace SpecBuilder

   Public Class CompressorSpecBuilderWizard
      Inherits SpecBuilder.SpecBuilderWizardBase

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
      Friend WithEvents lblCompressorLabel As System.Windows.Forms.Label
      Friend WithEvents lblRefrigerantLabel As System.Windows.Forms.Label
      Friend WithEvents lblCylinderLoadingLabel As System.Windows.Forms.Label
      Friend WithEvents radCylinderLoadingYes As System.Windows.Forms.RadioButton
      Friend WithEvents radCylinderLoadingNo As System.Windows.Forms.RadioButton
      Friend WithEvents cboCylinderLoading As System.Windows.Forms.ComboBox
      Friend WithEvents lblModulationLabel As System.Windows.Forms.Label
      Friend WithEvents cboModulation As System.Windows.Forms.ComboBox
      Friend WithEvents cboCompressor As System.Windows.Forms.ComboBox
      Friend WithEvents cboRefrigerant As System.Windows.Forms.ComboBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblCompressorLabel = New System.Windows.Forms.Label
         Me.lblRefrigerantLabel = New System.Windows.Forms.Label
         Me.lblCylinderLoadingLabel = New System.Windows.Forms.Label
         Me.lblModulationLabel = New System.Windows.Forms.Label
         Me.cboCompressor = New System.Windows.Forms.ComboBox
         Me.cboRefrigerant = New System.Windows.Forms.ComboBox
         Me.radCylinderLoadingYes = New System.Windows.Forms.RadioButton
         Me.radCylinderLoadingNo = New System.Windows.Forms.RadioButton
         Me.cboCylinderLoading = New System.Windows.Forms.ComboBox
         Me.cboModulation = New System.Windows.Forms.ComboBox
         Me.panMain.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.Controls.Add(Me.cboModulation)
         Me.panMain.Controls.Add(Me.cboCylinderLoading)
         Me.panMain.Controls.Add(Me.cboRefrigerant)
         Me.panMain.Controls.Add(Me.cboCompressor)
         Me.panMain.Controls.Add(Me.lblModulationLabel)
         Me.panMain.Controls.Add(Me.lblCylinderLoadingLabel)
         Me.panMain.Controls.Add(Me.lblRefrigerantLabel)
         Me.panMain.Controls.Add(Me.lblCompressorLabel)
         Me.panMain.Controls.Add(Me.radCylinderLoadingYes)
         Me.panMain.Controls.Add(Me.radCylinderLoadingNo)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.radCylinderLoadingNo, 0)
         Me.panMain.Controls.SetChildIndex(Me.radCylinderLoadingYes, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblCompressorLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblRefrigerantLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblCylinderLoadingLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblModulationLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboCompressor, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboRefrigerant, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboCylinderLoading, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboModulation, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblCompressorLabel
         '
         Me.lblCompressorLabel.Location = New System.Drawing.Point(16, 20)
         Me.lblCompressorLabel.Name = "lblCompressorLabel"
         Me.lblCompressorLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblCompressorLabel.TabIndex = 2
         Me.lblCompressorLabel.Text = "Compressor type"
         Me.lblCompressorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblRefrigerantLabel
         '
         Me.lblRefrigerantLabel.Location = New System.Drawing.Point(16, 48)
         Me.lblRefrigerantLabel.Name = "lblRefrigerantLabel"
         Me.lblRefrigerantLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblRefrigerantLabel.TabIndex = 3
         Me.lblRefrigerantLabel.Text = "Refrigerant"
         Me.lblRefrigerantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCylinderLoadingLabel
         '
         Me.lblCylinderLoadingLabel.Location = New System.Drawing.Point(16, 76)
         Me.lblCylinderLoadingLabel.Name = "lblCylinderLoadingLabel"
         Me.lblCylinderLoadingLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblCylinderLoadingLabel.TabIndex = 4
         Me.lblCylinderLoadingLabel.Text = "Cylinder unloading"
         Me.lblCylinderLoadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblModulationLabel
         '
         Me.lblModulationLabel.Location = New System.Drawing.Point(16, 136)
         Me.lblModulationLabel.Name = "lblModulationLabel"
         Me.lblModulationLabel.Size = New System.Drawing.Size(200, 23)
         Me.lblModulationLabel.TabIndex = 5
         Me.lblModulationLabel.Text = "Capacity slide valve modulation"
         Me.lblModulationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboCompressor
         '
         Me.cboCompressor.DropDownWidth = 200
         Me.cboCompressor.Items.AddRange(New Object() {"reciprocating (semi-hermetic)", "scroll (full hermetic)", "rotary screw (semi-hermetic)"})
         Me.cboCompressor.Location = New System.Drawing.Point(232, 20)
         Me.cboCompressor.Name = "cboCompressor"
         Me.cboCompressor.Size = New System.Drawing.Size(304, 21)
         Me.cboCompressor.TabIndex = 6
         Me.cboCompressor.Text = "reciprocating (semi-hermetic)"
         '
         'cboRefrigerant
         '
         Me.cboRefrigerant.Items.AddRange(New Object() {"R-22", "R-404a", "R-134a", "R-407C"})
         Me.cboRefrigerant.Location = New System.Drawing.Point(232, 48)
         Me.cboRefrigerant.Name = "cboRefrigerant"
         Me.cboRefrigerant.Size = New System.Drawing.Size(304, 21)
         Me.cboRefrigerant.TabIndex = 7
         Me.cboRefrigerant.Text = "R-22"
         '
         'radCylinderLoadingYes
         '
         Me.radCylinderLoadingYes.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radCylinderLoadingYes.Location = New System.Drawing.Point(232, 76)
         Me.radCylinderLoadingYes.Name = "radCylinderLoadingYes"
         Me.radCylinderLoadingYes.Size = New System.Drawing.Size(56, 24)
         Me.radCylinderLoadingYes.TabIndex = 8
         Me.radCylinderLoadingYes.Text = "Yes"
         '
         'radCylinderLoadingNo
         '
         Me.radCylinderLoadingNo.Checked = True
         Me.radCylinderLoadingNo.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me.radCylinderLoadingNo.Location = New System.Drawing.Point(288, 76)
         Me.radCylinderLoadingNo.Name = "radCylinderLoadingNo"
         Me.radCylinderLoadingNo.Size = New System.Drawing.Size(56, 24)
         Me.radCylinderLoadingNo.TabIndex = 9
         Me.radCylinderLoadingNo.TabStop = True
         Me.radCylinderLoadingNo.Text = "No"
         '
         'cboCylinderLoading
         '
         Me.cboCylinderLoading.DropDownWidth = 290
         Me.cboCylinderLoading.Items.AddRange(New Object() {"an electronic signal based on return water temperature", "based on refrigerant suction pressure"})
         Me.cboCylinderLoading.Location = New System.Drawing.Point(232, 108)
         Me.cboCylinderLoading.Name = "cboCylinderLoading"
         Me.cboCylinderLoading.Size = New System.Drawing.Size(304, 21)
         Me.cboCylinderLoading.TabIndex = 11
         Me.cboCylinderLoading.Text = "an electronic signal based on return water temperature"
         '
         'cboModulation
         '
         Me.cboModulation.Items.AddRange(New Object() {"Infinite control", "Step control"})
         Me.cboModulation.Location = New System.Drawing.Point(232, 136)
         Me.cboModulation.Name = "cboModulation"
         Me.cboModulation.Size = New System.Drawing.Size(304, 21)
         Me.cboModulation.TabIndex = 12
         Me.cboModulation.Text = "Infinite control"
         '
         'CompressorSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "CompressorSpecBuilderWizard"
         Me.Tag = "Compressor"
         Me.Text = "Untitled - Compressor - SpecBuilder"
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

      Private Sub CompressorSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetCylinderLoadingControls()
         Me.SetCylinderLoadingOptionControls()
         Me.SetCapacityModulationControls()
      End Sub


      Private Sub cboCompressor_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboCompressor.SelectedIndexChanged
         Me.SpecData.Compressor.Compressor = Me.cboCompressor.Text

         Me.SetCylinderLoadingControls()
         Me.SetCylinderLoadingOptionControls()
         Me.SetCapacityModulationControls()
      End Sub


      Private Sub radCylinderLoadingYes_CheckedChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles radCylinderLoadingYes.CheckedChanged
         Me.SpecData.Compressor.CylinderLoading = Me.radCylinderLoadingYes.Checked
         Me.SetCylinderLoadingOptionControls()
      End Sub


      Private Sub cboRefrigerant_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboRefrigerant.SelectedIndexChanged
         Me.SpecData.Compressor.Refrigerant = Me.cboRefrigerant.Text
      End Sub


      Private Sub cboCylinderLoading_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboCylinderLoading.SelectedIndexChanged
         Me.SpecData.Compressor.CylinderLoadingOption = Me.cboCylinderLoading.Text
      End Sub

      Private Sub cboModulation_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboModulation.SelectedIndexChanged
         Me.SpecData.Compressor.CapacitySlideValveModulation = Me.cboModulation.Text
      End Sub

#End Region


      Private Sub SetCylinderLoadingControls()
         If Me.optManager.GetCylinderLoading.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblCylinderLoadingLabel, Me.radCylinderLoadingYes, Me.tip)
            SpecBuilderManager.EnableControls(Me.lblCylinderLoadingLabel, Me.radCylinderLoadingNo, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblCylinderLoadingLabel, Me.radCylinderLoadingYes, Me.tip, _
               Me.optManager.GetCylinderLoading.Explanation)
            SpecBuilderManager.DisableControls(Me.lblCylinderLoadingLabel, Me.radCylinderLoadingNo, Me.tip, _
               Me.optManager.GetCylinderLoading.Explanation)
         End If
      End Sub


      Private Sub SetCylinderLoadingOptionControls()
         If Me.optManager.GetCylinderLoadingOption.IsOption Then
            SpecBuilderManager.EnableControls(New Label, Me.cboCylinderLoading, _
               Me.tip)
         Else
            SpecBuilderManager.DisableControls(New Label, Me.cboCylinderLoading, _
               Me.tip, Me.optManager.GetCylinderLoadingOption.Explanation)
         End If
      End Sub


      Private Sub SetCapacityModulationControls()
         If Me.optManager.GetCapacitySlideValveModulation.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblModulationLabel, _
               Me.cboModulation, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblModulationLabel, Me.cboModulation, _
               Me.tip, Me.optManager.GetCapacitySlideValveModulation.Explanation)
         End If
      End Sub

   End Class

End Namespace