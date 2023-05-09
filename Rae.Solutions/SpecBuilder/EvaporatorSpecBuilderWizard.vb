Namespace SpecBuilder

   Public Class EvaporatorSpecBuilderWizard
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
      Friend WithEvents lblEvaporatorLabel As System.Windows.Forms.Label
      Friend WithEvents lblPressureLabel As System.Windows.Forms.Label
      Friend WithEvents cboEvaporator As System.Windows.Forms.ComboBox
      Friend WithEvents cboPressure As System.Windows.Forms.ComboBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblEvaporatorLabel = New System.Windows.Forms.Label
         Me.lblPressureLabel = New System.Windows.Forms.Label
         Me.cboEvaporator = New System.Windows.Forms.ComboBox
         Me.cboPressure = New System.Windows.Forms.ComboBox
         Me.panMain.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.Controls.Add(Me.cboPressure)
         Me.panMain.Controls.Add(Me.cboEvaporator)
         Me.panMain.Controls.Add(Me.lblPressureLabel)
         Me.panMain.Controls.Add(Me.lblEvaporatorLabel)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.lblEvaporatorLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblPressureLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboEvaporator, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboPressure, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblEvaporatorLabel
         '
         Me.lblEvaporatorLabel.Location = New System.Drawing.Point(40, 20)
         Me.lblEvaporatorLabel.Name = "lblEvaporatorLabel"
         Me.lblEvaporatorLabel.Size = New System.Drawing.Size(176, 23)
         Me.lblEvaporatorLabel.TabIndex = 2
         Me.lblEvaporatorLabel.Text = "Evaporator"
         Me.lblEvaporatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblPressureLabel
         '
         Me.lblPressureLabel.Location = New System.Drawing.Point(40, 48)
         Me.lblPressureLabel.Name = "lblPressureLabel"
         Me.lblPressureLabel.Size = New System.Drawing.Size(176, 23)
         Me.lblPressureLabel.TabIndex = 3
         Me.lblPressureLabel.Text = "Water side pressure rating"
         Me.lblPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboEvaporator
         '
         Me.cboEvaporator.DropDownWidth = 180
         Me.cboEvaporator.Items.AddRange(New Object() {"Shell and tube", "Brazed plate heat exchanger"})
         Me.cboEvaporator.Location = New System.Drawing.Point(232, 20)
         Me.cboEvaporator.Name = "cboEvaporator"
         Me.cboEvaporator.Size = New System.Drawing.Size(216, 21)
         Me.cboEvaporator.TabIndex = 4
         Me.cboEvaporator.Text = "Shell and tube"
         '
         'cboPressure
         '
         Me.cboPressure.DropDownWidth = 180
         Me.cboPressure.Items.AddRange(New Object() {"250 psig [up to 30 ton loads]", "150 psig [over 30 ton loads]"})
         Me.cboPressure.Location = New System.Drawing.Point(232, 48)
         Me.cboPressure.Name = "cboPressure"
         Me.cboPressure.Size = New System.Drawing.Size(216, 21)
         Me.cboPressure.TabIndex = 5
         Me.cboPressure.Text = "250 psig [up to 30 ton loads]"
         '
         'EvaporatorSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "EvaporatorSpecBuilderWizard"
         Me.Tag = "Evaporator"
         Me.Text = "Untitled - SpecBuilder - Evaporator"
         Me.panMain.ResumeLayout(False)

      End Sub

#End Region


      Dim optManager As New OptionManager(SpecData)



      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub


#Region " Event Handlers"

      Private Sub EvaporatorSpecBuilderWizard_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles MyBase.Load
         Me.SetEvaporatorControls()
         Me.SetPressureControls()
      End Sub


      Private Sub Me_VisibileChanged(ByVal sender As Object, ByVal e As EventArgs) _
      Handles MyBase.VisibleChanged
         If Me.isDisposing Then Exit Sub
         Me.SetEvaporatorControls()
         Me.SetPressureControls()
      End Sub


      Private Sub cboEvaporator_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboEvaporator.SelectedIndexChanged
         Me.SpecData.Evaporator.Evaporator = Me.cboEvaporator.Text

         Me.SetPressureControls()
      End Sub


      Private Sub cboPressure_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboPressure.SelectedIndexChanged
         Me.SpecData.Evaporator.Pressure = Me.cboPressure.Text
      End Sub

#End Region


      Private Sub SetEvaporatorControls()
         If Me.optManager.GetEvaporator.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblEvaporatorLabel, _
               Me.cboEvaporator, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblEvaporatorLabel, _
               Me.cboEvaporator, Me.tip, Me.optManager.GetEvaporator.Explanation)
         End If
      End Sub


      Private Sub SetPressureControls()
         If Me.optManager.GetPressure.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblPressureLabel, _
               Me.cboPressure, Me.tip)
         Else
            If Not Me.isDisposing Then
               SpecBuilderManager.DisableControls(Me.lblPressureLabel, _
                  Me.cboPressure, Me.tip, Me.optManager.GetPressure.Explanation)
            End If
            End If
      End Sub


   End Class

End Namespace
