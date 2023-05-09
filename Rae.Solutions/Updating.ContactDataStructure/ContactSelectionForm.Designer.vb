Namespace Updating.ContactDataStructure

   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class ContactSelectionForm
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
         Me.Label1 = New System.Windows.Forms.Label
         Me.selectButton = New System.Windows.Forms.Button
         Me.cancelButton2 = New System.Windows.Forms.Button
            Me.ContactSelectionControl1 = New Rae.RaeSolutions.ContactSelectionControl
            Me.SuspendLayout()
         '
         'Label1
         '
         Me.Label1.AutoSize = True
         Me.Label1.Location = New System.Drawing.Point(14, 9)
         Me.Label1.Name = "Label1"
         Me.Label1.Size = New System.Drawing.Size(183, 16)
         Me.Label1.TabIndex = 1
         Me.Label1.Text = "Select the contact from the list"
         '
         'selectButton
         '
         Me.selectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.selectButton.Location = New System.Drawing.Point(181, 146)
         Me.selectButton.Name = "selectButton"
         Me.selectButton.Size = New System.Drawing.Size(75, 27)
         Me.selectButton.TabIndex = 2
         Me.selectButton.Text = "Select"
         Me.selectButton.UseVisualStyleBackColor = True
         '
         'cancelButton2
         '
         Me.cancelButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.cancelButton2.ForeColor = System.Drawing.Color.DimGray
         Me.cancelButton2.Location = New System.Drawing.Point(262, 146)
         Me.cancelButton2.Name = "cancelButton2"
         Me.cancelButton2.Size = New System.Drawing.Size(75, 27)
         Me.cancelButton2.TabIndex = 3
         Me.cancelButton2.Text = "Cancel"
         Me.cancelButton2.UseVisualStyleBackColor = True
            '
            'ContactSelectionControl1
            '
            Me.ContactSelectionControl1.ActionsVisible = True
            Me.ContactSelectionControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ContactSelectionControl1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ContactSelectionControl1.Location = New System.Drawing.Point(17, 33)
            Me.ContactSelectionControl1.Margin = New System.Windows.Forms.Padding(8)
            Me.ContactSelectionControl1.Name = "ContactSelectionControl1"
            Me.ContactSelectionControl1.SelectedContact = Nothing
            Me.ContactSelectionControl1.Size = New System.Drawing.Size(320, 95)
            Me.ContactSelectionControl1.TabIndex = 0
            '
            'ContactSelectionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.ClientSize = New System.Drawing.Size(352, 185)
         Me.Controls.Add(Me.cancelButton2)
         Me.Controls.Add(Me.selectButton)
         Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ContactSelectionControl1)
            Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
         Me.Name = "ContactSelectionForm"
         Me.Text = "Contact Selector"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
        Friend WithEvents ContactSelectionControl1 As Rae.RaeSolutions.ContactSelectionControl
        Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents selectButton As System.Windows.Forms.Button
      Friend WithEvents cancelButton2 As System.Windows.Forms.Button
   End Class

End Namespace