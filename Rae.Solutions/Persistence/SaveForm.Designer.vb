<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
Me.SuspendLayout()
'
'SaveForm
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.White
Me.ClientSize = New System.Drawing.Size(389, 331)
Me.ControlBox = False
Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Margin = New System.Windows.Forms.Padding(4)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "SaveForm"
Me.Padding = New System.Windows.Forms.Padding(10)
Me.ShowIcon = False
Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
Me.Text = "Save"
Me.ResumeLayout(False)

End Sub
End Class
