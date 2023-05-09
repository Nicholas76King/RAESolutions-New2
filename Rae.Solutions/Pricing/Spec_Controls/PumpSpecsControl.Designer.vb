<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PumpSpecsControl
    Inherits RaeSolutions.CommonSpecsControl

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
Me.pumpView = New Rae.RaeSolutions.PumpSelectionView
Me.SuspendLayout()
'
'pumpView
'
Me.pumpView.BackColor = System.Drawing.Color.White
Me.pumpView.Dock = System.Windows.Forms.DockStyle.Top
Me.pumpView.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.pumpView.Location = New System.Drawing.Point(0, 0)
Me.pumpView.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
Me.pumpView.Name = "pumpView"
Me.pumpView.Size = New System.Drawing.Size(513, 181)
Me.pumpView.TabIndex = 110
'
'PumpSpecsControl
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.Controls.Add(Me.pumpView)
Me.Name = "PumpSpecsControl"
Me.Size = New System.Drawing.Size(513, 376)
Me.Controls.SetChildIndex(Me.pumpView, 0)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents pumpView As Rae.RaeSolutions.PumpSelectionView

End Class
