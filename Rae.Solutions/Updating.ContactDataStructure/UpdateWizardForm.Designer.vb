<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateWizardForm
   Inherits Rae.RaeSolutions.Updating.ContactDataStructure.WizardFormBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateWizardForm))
      Me.Label2 = New System.Windows.Forms.Label
      Me.ContactConverterControl1 = New Rae.RaeSolutions.ContactConverterControl
      Me.SuspendLayout()
      '
      'cancelButton2
      '
      Me.cancelButton2.Location = New System.Drawing.Point(568, 17)
      '
      'continueButton
      '
      Me.continueButton.Location = New System.Drawing.Point(476, 17)
      Me.continueButton.Visible = False
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(16, 85)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(628, 64)
      Me.Label2.TabIndex = 24
      Me.Label2.Text = resources.GetString("Label2.Text")
      '
      'ContactConverterControl1
      '
      Me.ContactConverterControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ContactConverterControl1.BackColor = System.Drawing.Color.White
      Me.ContactConverterControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ContactConverterControl1.Location = New System.Drawing.Point(19, 155)
      Me.ContactConverterControl1.Margin = New System.Windows.Forms.Padding(4, 6, 4, 4)
      Me.ContactConverterControl1.Name = "ContactConverterControl1"
      Me.ContactConverterControl1.Size = New System.Drawing.Size(625, 173)
      Me.ContactConverterControl1.TabIndex = 28
      '
      'UpdateWizardForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
      Me.ClientSize = New System.Drawing.Size(666, 413)
      Me.Controls.Add(Me.ContactConverterControl1)
      Me.Controls.Add(Me.Label2)
      Me.Name = "UpdateWizardForm"
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.ContactConverterControl1, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents ContactConverterControl1 As Rae.RaeSolutions.ContactConverterControl

End Class
