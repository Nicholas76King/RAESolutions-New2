<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeWizardForm
    Inherits RaeSolutions.Updating.ContactDataStructure.WizardFormBase

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeWizardForm))
      Me.Label5 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'cancelButton2
      '
      '
      'continueButton
      '
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.ForeColor = System.Drawing.Color.DimGray
      Me.Label5.Location = New System.Drawing.Point(16, 315)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(308, 16)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Note: This is only required once per existing project."
      '
      'Label4
      '
      Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.ForeColor = System.Drawing.Color.DimGray
      Me.Label4.Location = New System.Drawing.Point(16, 251)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(635, 64)
      Me.Label4.TabIndex = 10
      Me.Label4.Text = resources.GetString("Label4.Text")
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 235)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(39, 16)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "Why?"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(16, 100)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(310, 16)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "Please update the contact information in this project."
      '
      'WelcomeWizardForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
      Me.ClientSize = New System.Drawing.Size(666, 413)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Name = "WelcomeWizardForm"
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.Controls.SetChildIndex(Me.Label4, 0)
      Me.Controls.SetChildIndex(Me.Label5, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
