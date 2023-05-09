<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadProgressForm
    Inherits System.Windows.Forms.Form

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
      Me.okButton = New System.Windows.Forms.Button
      Me.infoLabel = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'okButton
      '
      Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.okButton.Location = New System.Drawing.Point(279, 51)
      Me.okButton.Name = "okButton"
      Me.okButton.Size = New System.Drawing.Size(75, 23)
      Me.okButton.TabIndex = 0
      Me.okButton.Text = "OK"
      Me.okButton.UseVisualStyleBackColor = True
      '
      'infoLabel
      '
      Me.infoLabel.Location = New System.Drawing.Point(13, 13)
      Me.infoLabel.Name = "infoLabel"
      Me.infoLabel.Size = New System.Drawing.Size(341, 35)
      Me.infoLabel.TabIndex = 1
      Me.infoLabel.Text = "The download is in progress. Please wait for the completion notification to occur" & _
          " before attempting to log in."
      '
      'DownloadProgressForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.ClientSize = New System.Drawing.Size(366, 86)
      Me.Controls.Add(Me.infoLabel)
      Me.Controls.Add(Me.okButton)
      Me.Name = "DownloadProgressForm"
      Me.Text = "RAESolutions - Download Progress"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents okButton As System.Windows.Forms.Button
   Friend WithEvents infoLabel As System.Windows.Forms.Label
End Class
