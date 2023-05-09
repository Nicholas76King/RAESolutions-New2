namespace evaporative_condenser_chillers

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class option_control
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
Me.chk_option = New System.Windows.Forms.CheckBox
Me.lbl_long_description = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'chk_option
'
Me.chk_option.BackColor = System.Drawing.Color.White
Me.chk_option.Dock = System.Windows.Forms.DockStyle.Top
Me.chk_option.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.chk_option.Location = New System.Drawing.Point(0, 0)
Me.chk_option.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
Me.chk_option.Name = "chk_option"
Me.chk_option.Padding = New System.Windows.Forms.Padding(8, 0, 6, 0)
Me.chk_option.Size = New System.Drawing.Size(347, 20)
Me.chk_option.TabIndex = 1
Me.chk_option.Text = "Super Option"
Me.chk_option.UseVisualStyleBackColor = False
'
'lbl_long_description
'
Me.lbl_long_description.BackColor = System.Drawing.Color.GhostWhite
Me.lbl_long_description.Dock = System.Windows.Forms.DockStyle.Top
Me.lbl_long_description.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lbl_long_description.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
Me.lbl_long_description.Location = New System.Drawing.Point(0, 20)
Me.lbl_long_description.Name = "lbl_long_description"
Me.lbl_long_description.Padding = New System.Windows.Forms.Padding(4, 0, 0, 3)
Me.lbl_long_description.Size = New System.Drawing.Size(347, 23)
Me.lbl_long_description.TabIndex = 0
Me.lbl_long_description.Text = "Description with lots of great detail"
Me.lbl_long_description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.lbl_long_description.Visible = False
'
'option_control
'
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
Me.AutoSize = True
Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
Me.Controls.Add(Me.lbl_long_description)
Me.Controls.Add(Me.chk_option)
Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.ForeColor = System.Drawing.Color.Black
Me.Name = "option_control"
Me.Size = New System.Drawing.Size(347, 43)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents chk_option As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_long_description As System.Windows.Forms.Label

End Class
end namespace