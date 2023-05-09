Namespace SpecBuilder

   Public Class UnitSpecBuilderWizard
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
      Friend WithEvents lblUnitLabel As System.Windows.Forms.Label
      Friend WithEvents lblCoolingSolutionLabel As System.Windows.Forms.Label
      Friend WithEvents lblCoolingSolutionPercentageLabel As System.Windows.Forms.Label
      Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
      Friend WithEvents cboCoolingSolution As System.Windows.Forms.ComboBox
      Friend WithEvents txtCoolingSolutionPercentage As System.Windows.Forms.TextBox
      <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
         Me.lblUnitLabel = New System.Windows.Forms.Label
         Me.lblCoolingSolutionLabel = New System.Windows.Forms.Label
         Me.lblCoolingSolutionPercentageLabel = New System.Windows.Forms.Label
         Me.cboUnit = New System.Windows.Forms.ComboBox
         Me.cboCoolingSolution = New System.Windows.Forms.ComboBox
         Me.txtCoolingSolutionPercentage = New System.Windows.Forms.TextBox
         Me.panMain.SuspendLayout()
         '
         'panMain
         '
         Me.panMain.Controls.Add(Me.txtCoolingSolutionPercentage)
         Me.panMain.Controls.Add(Me.lblUnitLabel)
         Me.panMain.Controls.Add(Me.cboUnit)
         Me.panMain.Controls.Add(Me.lblCoolingSolutionLabel)
         Me.panMain.Controls.Add(Me.cboCoolingSolution)
         Me.panMain.Controls.Add(Me.lblCoolingSolutionPercentageLabel)
         Me.panMain.Name = "panMain"
         Me.panMain.Controls.SetChildIndex(Me.lblCoolingSolutionPercentageLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboCoolingSolution, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblCoolingSolutionLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.cboUnit, 0)
         Me.panMain.Controls.SetChildIndex(Me.lblUnitLabel, 0)
         Me.panMain.Controls.SetChildIndex(Me.txtCoolingSolutionPercentage, 0)
         '
         'panBottom
         '
         Me.panBottom.Name = "panBottom"
         '
         'lblUnitLabel
         '
         Me.lblUnitLabel.Location = New System.Drawing.Point(64, 20)
         Me.lblUnitLabel.Name = "lblUnitLabel"
         Me.lblUnitLabel.Size = New System.Drawing.Size(152, 23)
         Me.lblUnitLabel.TabIndex = 0
         Me.lblUnitLabel.Text = "Unit type"
         Me.lblUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCoolingSolutionLabel
         '
         Me.lblCoolingSolutionLabel.Location = New System.Drawing.Point(64, 48)
         Me.lblCoolingSolutionLabel.Name = "lblCoolingSolutionLabel"
         Me.lblCoolingSolutionLabel.Size = New System.Drawing.Size(152, 23)
         Me.lblCoolingSolutionLabel.TabIndex = 1
         Me.lblCoolingSolutionLabel.Text = "Cooling solution"
         Me.lblCoolingSolutionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'lblCoolingSolutionPercentageLabel
         '
         Me.lblCoolingSolutionPercentageLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.lblCoolingSolutionPercentageLabel.Location = New System.Drawing.Point(64, 76)
         Me.lblCoolingSolutionPercentageLabel.Name = "lblCoolingSolutionPercentageLabel"
         Me.lblCoolingSolutionPercentageLabel.Size = New System.Drawing.Size(152, 23)
         Me.lblCoolingSolutionPercentageLabel.TabIndex = 2
         Me.lblCoolingSolutionPercentageLabel.Text = "Percentage concentrate"
         Me.lblCoolingSolutionPercentageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         '
         'cboUnit
         '
         Me.cboUnit.Items.AddRange(New Object() {"Condensing unit", "Water chiller"})
         Me.cboUnit.Location = New System.Drawing.Point(232, 20)
         Me.cboUnit.Name = "cboUnit"
         Me.cboUnit.Size = New System.Drawing.Size(152, 21)
         Me.cboUnit.TabIndex = 3
         Me.cboUnit.Text = "Condensing unit"
         '
         'cboCoolingSolution
         '
         Me.cboCoolingSolution.Items.AddRange(New Object() {"Water", "Ethylene glycol", "Propylene glycol"})
         Me.cboCoolingSolution.Location = New System.Drawing.Point(232, 48)
         Me.cboCoolingSolution.Name = "cboCoolingSolution"
         Me.cboCoolingSolution.Size = New System.Drawing.Size(152, 21)
         Me.cboCoolingSolution.TabIndex = 4
         Me.cboCoolingSolution.Text = "Water"
         '
         'txtCoolingSolutionPercentage
         '
         Me.txtCoolingSolutionPercentage.Location = New System.Drawing.Point(232, 76)
         Me.txtCoolingSolutionPercentage.MaxLength = 3
         Me.txtCoolingSolutionPercentage.Name = "txtCoolingSolutionPercentage"
         Me.txtCoolingSolutionPercentage.Size = New System.Drawing.Size(132, 21)
         Me.txtCoolingSolutionPercentage.TabIndex = 5
         Me.txtCoolingSolutionPercentage.Text = "0"
         '
         'UnitSpecBuilderWizard
         '
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
         Me.ClientSize = New System.Drawing.Size(556, 466)
         Me.Name = "UnitSpecBuilderWizard"
         Me.Tag = "Unit"
         Me.Text = "Untitled - Unit - SpecBuilder"
         Me.panMain.ResumeLayout(False)

      End Sub

#End Region


      Dim optManager As New OptionManager(SpecData)


#Region " Event Handlers"

      Protected Overrides Sub SpecBuilderWizardBase_Load(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) ' Handles MyBase.Load
         MyBase.SpecBuilderWizardBase_Load(sender, e)
      End Sub


      'unit type changed
      Private Sub cboUnit_SelectedIndexChanged(ByVal sender As System.Object, _
      ByVal e As System.EventArgs) Handles cboUnit.SelectedIndexChanged
         Me.SpecData.Unit = Me.cboUnit.Text

         'cooling solution
         Me.SetCoolingSolutionControls()
         'cooling solution percentage
         Me.SetCoolingSolutionPercentageControls()
      End Sub


      Private Sub cboCoolingSolution_SelectedIndexChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cboCoolingSolution.SelectedIndexChanged
         Me.SpecData.CoolingSolution = Me.cboCoolingSolution.Text
         Me.SetCoolingSolutionPercentageControls()
      End Sub


      Private Sub txtCoolingSolutionPercentage_TextChanged( _
      ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles txtCoolingSolutionPercentage.TextChanged
         Me.SpecData.SolutionPercentage = ConvertNull.ToInteger(Me.txtCoolingSolutionPercentage.Text)
      End Sub


#End Region


#Region " Public Methods"

      Public Sub New(ByVal wizard As Wizard.Wizard, _
      ByVal specData As SpecBuilder.SpecBuilderData)
         MyBase.New(wizard, specData)

         Me.InitializeComponent()
      End Sub

#End Region


      'cooling solution
      Private Sub SetCoolingSolutionControls()
         If Me.optManager.GetCoolingSolution.IsOption Then
            SpecBuilderManager.EnableControls(Me.lblCoolingSolutionLabel, _
               Me.cboCoolingSolution, Me.tip)
         Else
            SpecBuilderManager.DisableControls(Me.lblCoolingSolutionLabel, _
               Me.cboCoolingSolution, Me.tip, _
               Me.optManager.GetCoolingSolution.Explanation)
         End If
      End Sub


      'sets cooling solution percentage control's properties based on cooling
      'solution selected
      Private Sub SetCoolingSolutionPercentageControls()
         If Me.optManager.GetCoolingSolutionPercentage.IsOption Then
            SpecBuilderManager.EnableControls( _
               Me.lblCoolingSolutionPercentageLabel, _
               Me.txtCoolingSolutionPercentage, Me.tip)
         Else
            SpecBuilderManager.DisableControls( _
               Me.lblCoolingSolutionPercentageLabel, _
               Me.txtCoolingSolutionPercentage, Me.tip, _
               Me.optManager.GetCoolingSolutionPercentage.Explanation)
         End If
      End Sub

   End Class

End Namespace