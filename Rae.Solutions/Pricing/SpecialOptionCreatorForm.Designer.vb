<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialOptionCreatorForm
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
      Me.SpecialOptionCreatorControl1 = New RAE.RAESolutions.SpecialOptionCreatorControl
      Me.btnCancel = New System.Windows.Forms.Button
      Me.btnOk = New System.Windows.Forms.Button
      Me.lblInstructions = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'SpecialOptionCreatorControl1
      '
      Me.SpecialOptionCreatorControl1.BackColor = System.Drawing.Color.White
      Me.SpecialOptionCreatorControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.SpecialOptionCreatorControl1.Location = New System.Drawing.Point(12, 41)
      Me.SpecialOptionCreatorControl1.Name = "SpecialOptionCreatorControl1"
      Me.SpecialOptionCreatorControl1.Size = New System.Drawing.Size(390, 78)
      Me.SpecialOptionCreatorControl1.TabIndex = 0
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(321, 134)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 25)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.Location = New System.Drawing.Point(240, 134)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 25)
      Me.btnOk.TabIndex = 2
      Me.btnOk.Text = "OK"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'lblInstructions
      '
      Me.lblInstructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblInstructions.ForeColor = System.Drawing.Color.Blue
      Me.lblInstructions.Image = Global.RAE.RAESolutions.My.Resources.Resources.Info
      Me.lblInstructions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.lblInstructions.Location = New System.Drawing.Point(12, 9)
      Me.lblInstructions.Name = "lblInstructions"
      Me.lblInstructions.Size = New System.Drawing.Size(384, 21)
      Me.lblInstructions.TabIndex = 3
      Me.lblInstructions.Text = "        Complete the form below and click OK to create a special option."
      Me.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'SpecialOptionCreatorForm
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(408, 171)
      Me.Controls.Add(Me.lblInstructions)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.SpecialOptionCreatorControl1)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "SpecialOptionCreatorForm"
      Me.Text = "Special Option Creator"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents SpecialOptionCreatorControl1 As RAE.RAESolutions.SpecialOptionCreatorControl
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents lblInstructions As System.Windows.Forms.Label
End Class
