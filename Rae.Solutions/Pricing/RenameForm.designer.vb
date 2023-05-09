<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenameForm
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
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOk = New System.Windows.Forms.Button
      Me.lblNewName = New System.Windows.Forms.Label
      Me.txtNewName = New System.Windows.Forms.TextBox
      Me.SuspendLayout()
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(167, 45)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 25)
      Me.btnCancel.TabIndex = 3
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.Location = New System.Drawing.Point(86, 45)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 25)
      Me.btnOk.TabIndex = 2
      Me.btnOk.Text = "OK"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'lblNewName
      '
      Me.lblNewName.Location = New System.Drawing.Point(13, 13)
      Me.lblNewName.Name = "lblNewName"
      Me.lblNewName.Size = New System.Drawing.Size(75, 21)
      Me.lblNewName.TabIndex = 2
      Me.lblNewName.Text = "New name"
      Me.lblNewName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtNewName
      '
      Me.txtNewName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNewName.Location = New System.Drawing.Point(86, 13)
      Me.txtNewName.Name = "txtNewName"
      Me.txtNewName.Size = New System.Drawing.Size(156, 21)
      Me.txtNewName.TabIndex = 1
      '
      'RenameForm
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(254, 80)
      Me.Controls.Add(Me.txtNewName)
      Me.Controls.Add(Me.lblNewName)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.btnCancel)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RenameForm"
      Me.Text = "Rename Equipment"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents lblNewName As System.Windows.Forms.Label
   Friend WithEvents txtNewName As System.Windows.Forms.TextBox
End Class
