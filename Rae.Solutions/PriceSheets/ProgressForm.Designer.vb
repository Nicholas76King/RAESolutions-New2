<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressForm
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
      Me.components = New System.ComponentModel.Container
      Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
      Me.Label2 = New System.Windows.Forms.Label
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.SuspendLayout()
      '
      'ProgressBar1
      '
      Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ProgressBar1.Location = New System.Drawing.Point(21, 34)
      Me.ProgressBar1.Name = "ProgressBar1"
      Me.ProgressBar1.Size = New System.Drawing.Size(445, 13)
      Me.ProgressBar1.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.Location = New System.Drawing.Point(18, 9)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(448, 21)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "Generating the price sheets may take a few minutes."
      '
      'Timer1
      '
      Me.Timer1.Interval = 500
      '
      'ProgressForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.ClientSize = New System.Drawing.Size(490, 59)
      Me.Controls.Add(Me.ProgressBar1)
      Me.Controls.Add(Me.Label2)
      Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ProgressForm"
      Me.ShowIcon = False
      Me.Text = "Generating Price Sheets"
      Me.TopMost = True
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
