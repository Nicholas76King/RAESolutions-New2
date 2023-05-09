<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PumpPackageResultControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Me.cancButton = New System.Windows.Forms.Button
Me.completeButton = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'cancButton
'
Me.cancButton.Dock = System.Windows.Forms.DockStyle.Left
Me.cancButton.ForeColor = System.Drawing.Color.DimGray
Me.cancButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Cancel
Me.cancButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.cancButton.Location = New System.Drawing.Point(0, 0)
Me.cancButton.Name = "cancButton"
Me.cancButton.Size = New System.Drawing.Size(95, 29)
Me.cancButton.TabIndex = 0
Me.cancButton.Text = "Cancel"
Me.cancButton.UseVisualStyleBackColor = True
'
'completeButton
'
Me.completeButton.Dock = System.Windows.Forms.DockStyle.Fill
Me.completeButton.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.completeButton.ForeColor = System.Drawing.Color.Green
Me.completeButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Accept
Me.completeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.completeButton.Location = New System.Drawing.Point(95, 0)
Me.completeButton.Name = "completeButton"
Me.completeButton.Size = New System.Drawing.Size(437, 29)
Me.completeButton.TabIndex = 1
Me.completeButton.Text = "I'm done. Integrate with chiller."
Me.completeButton.UseVisualStyleBackColor = True
'
'PumpPackageResultControl
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.White
Me.Controls.Add(Me.completeButton)
Me.Controls.Add(Me.cancButton)
Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "PumpPackageResultControl"
Me.Size = New System.Drawing.Size(532, 29)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents cancButton As System.Windows.Forms.Button
    Friend WithEvents completeButton As System.Windows.Forms.Button

End Class
