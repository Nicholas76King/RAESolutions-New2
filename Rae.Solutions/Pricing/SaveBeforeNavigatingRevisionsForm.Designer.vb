<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveBeforeNavigatingRevisionsForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveBeforeNavigatingRevisionsForm))
        Me.newErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.saveButton = New System.Windows.Forms.Button()
        Me.cancel2Button = New System.Windows.Forms.Button()
        Me.instructionLabel = New System.Windows.Forms.Label()
        Me.saveDiskLabel = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.extraInfoLabel = New System.Windows.Forms.Label()
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'newErrorProvider
        '
        Me.newErrorProvider.ContainerControl = Me
        Me.newErrorProvider.Icon = CType(resources.GetObject("newErrorProvider.Icon"), System.Drawing.Icon)
        '
        'saveButton
        '
        Me.saveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.saveButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.saveButton.Location = New System.Drawing.Point(151, 105)
        Me.saveButton.Margin = New System.Windows.Forms.Padding(4)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(100, 25)
        Me.saveButton.TabIndex = 5
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'cancel2Button
        '
        Me.cancel2Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel2Button.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancel2Button.Location = New System.Drawing.Point(259, 105)
        Me.cancel2Button.Margin = New System.Windows.Forms.Padding(4)
        Me.cancel2Button.Name = "cancel2Button"
        Me.cancel2Button.Size = New System.Drawing.Size(100, 25)
        Me.cancel2Button.TabIndex = 6
        Me.cancel2Button.Text = "Don't Save"
        Me.cancel2Button.UseVisualStyleBackColor = True
        '
        'instructionLabel
        '
        Me.instructionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.instructionLabel.BackColor = System.Drawing.Color.Transparent
        Me.instructionLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructionLabel.ForeColor = System.Drawing.Color.White
        Me.instructionLabel.Location = New System.Drawing.Point(54, 13)
        Me.instructionLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.instructionLabel.Name = "instructionLabel"
        Me.instructionLabel.Size = New System.Drawing.Size(372, 39)
        Me.instructionLabel.TabIndex = 8
        Me.instructionLabel.Text = "Do you want to save before navigating to another revision?"
        '
        'saveDiskLabel
        '
        Me.saveDiskLabel.BackColor = System.Drawing.Color.Transparent
        Me.saveDiskLabel.ImageIndex = 2
        Me.saveDiskLabel.ImageList = Me.ImageList1
        Me.saveDiskLabel.Location = New System.Drawing.Point(12, 17)
        Me.saveDiskLabel.Name = "saveDiskLabel"
        Me.saveDiskLabel.Size = New System.Drawing.Size(32, 32)
        Me.saveDiskLabel.TabIndex = 9
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "BeOS_Floppy.ico")
        Me.ImageList1.Images.SetKeyName(1, "none.ico")
        Me.ImageList1.Images.SetKeyName(2, "save.ico")
        '
        'extraInfoLabel
        '
        Me.extraInfoLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.extraInfoLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.extraInfoLabel.ForeColor = System.Drawing.Color.DimGray
        Me.extraInfoLabel.Location = New System.Drawing.Point(60, 8)
        Me.extraInfoLabel.Name = "extraInfoLabel"
        Me.extraInfoLabel.Size = New System.Drawing.Size(371, 44)
        Me.extraInfoLabel.TabIndex = 11
        Me.extraInfoLabel.Text = "You are navigating away from a revision that has unsaved changes. If you do not s" &
    "ave, unsaved changes will be deleted."
        Me.extraInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SaveBeforeNavigatingRevisionsForm
        '
        Me.AcceptButton = Me.saveButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(443, 168)
        Me.Controls.Add(Me.extraInfoLabel)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.cancel2Button)
        Me.Controls.Add(Me.saveDiskLabel)
        Me.Controls.Add(Me.instructionLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SaveBeforeNavigatingRevisionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAESolutions"
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents newErrorProvider As System.Windows.Forms.ErrorProvider
   Friend WithEvents saveButton As System.Windows.Forms.Button
   Friend WithEvents instructionLabel As System.Windows.Forms.Label
    ''Friend WithEvents GradientPanel1 As RAE.UI.Controls.GradientPanel
    Friend WithEvents cancel2Button As System.Windows.Forms.Button
    ''Friend WithEvents GradientPanel3 As RAE.UI.Controls.GradientPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents saveDiskLabel As System.Windows.Forms.Label
   Friend WithEvents extraInfoLabel As System.Windows.Forms.Label
End Class
