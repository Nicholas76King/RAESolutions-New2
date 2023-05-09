<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrawingForm
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DrawingForm))
Me.AxEModelViewControl1 = New AxEModelView.AxEModelViewControl
CType(Me.AxEModelViewControl1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'AxEModelViewControl1
'
Me.AxEModelViewControl1.Dock = System.Windows.Forms.DockStyle.Fill
Me.AxEModelViewControl1.Enabled = True
Me.AxEModelViewControl1.Location = New System.Drawing.Point(0, 0)
Me.AxEModelViewControl1.Name = "AxEModelViewControl1"
Me.AxEModelViewControl1.OcxState = CType(resources.GetObject("AxEModelViewControl1.OcxState"), System.Windows.Forms.AxHost.State)
Me.AxEModelViewControl1.Size = New System.Drawing.Size(292, 266)
Me.AxEModelViewControl1.TabIndex = 0
'
'DrawingForm
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(292, 266)
Me.Controls.Add(Me.AxEModelViewControl1)
Me.Name = "DrawingForm"
Me.Text = "DrawingForm"
CType(Me.AxEModelViewControl1, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
    Friend WithEvents AxEModelViewControl1 As AxEModelView.AxEModelViewControl
End Class
