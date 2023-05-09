<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewUnknownTypePricingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewUnknownTypePricingForm))
        Me.equipmentTypeLabel = New System.Windows.Forms.Label()
        Me.newErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.viewButton = New System.Windows.Forms.Button()
        Me.cancel2Button = New System.Windows.Forms.Button()
        Me.instructionLabel = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.typeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'equipmentTypeLabel
        '
        Me.equipmentTypeLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.equipmentTypeLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.equipmentTypeLabel.Location = New System.Drawing.Point(21, 60)
        Me.equipmentTypeLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.equipmentTypeLabel.Name = "equipmentTypeLabel"
        Me.equipmentTypeLabel.Size = New System.Drawing.Size(115, 22)
        Me.equipmentTypeLabel.TabIndex = 6
        Me.equipmentTypeLabel.Text = "Equipment type"
        Me.equipmentTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'newErrorProvider
        '
        Me.newErrorProvider.ContainerControl = Me
        Me.newErrorProvider.Icon = CType(resources.GetObject("newErrorProvider.Icon"), System.Drawing.Icon)
        '
        'viewButton
        '
        Me.viewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.viewButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.viewButton.Location = New System.Drawing.Point(170, 100)
        Me.viewButton.Margin = New System.Windows.Forms.Padding(4)
        Me.viewButton.Name = "viewButton"
        Me.viewButton.Size = New System.Drawing.Size(80, 25)
        Me.viewButton.TabIndex = 2
        Me.viewButton.Text = "OK"
        Me.viewButton.UseVisualStyleBackColor = True
        '
        'cancel2Button
        '
        Me.cancel2Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel2Button.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancel2Button.Location = New System.Drawing.Point(258, 100)
        Me.cancel2Button.Margin = New System.Windows.Forms.Padding(4)
        Me.cancel2Button.Name = "cancel2Button"
        Me.cancel2Button.Size = New System.Drawing.Size(80, 25)
        Me.cancel2Button.TabIndex = 3
        Me.cancel2Button.Text = "Cancel"
        Me.cancel2Button.UseVisualStyleBackColor = True
        '
        'instructionLabel
        '
        Me.instructionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.instructionLabel.BackColor = System.Drawing.Color.DodgerBlue
        Me.instructionLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructionLabel.ForeColor = System.Drawing.Color.White
        Me.instructionLabel.Location = New System.Drawing.Point(0, -2)
        Me.instructionLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.instructionLabel.Name = "instructionLabel"
        Me.instructionLabel.Size = New System.Drawing.Size(367, 54)
        Me.instructionLabel.TabIndex = 8
        Me.instructionLabel.Text = "Choose an equipment type to view."
        Me.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "BeOS_Floppy.ico")
        Me.ImageList1.Images.SetKeyName(1, "none.ico")
        Me.ImageList1.Images.SetKeyName(2, "save.ico")
        '
        'typeComboBox
        '
        Me.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typeComboBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.typeComboBox.FormattingEnabled = True
        Me.typeComboBox.Location = New System.Drawing.Point(139, 60)
        Me.typeComboBox.Name = "typeComboBox"
        Me.typeComboBox.Size = New System.Drawing.Size(211, 22)
        Me.typeComboBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ForeColor = System.Drawing.Color.Coral
        Me.Label1.Location = New System.Drawing.Point(-6, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(373, 61)
        Me.Label1.TabIndex = 10
        '
        'NewUnknownTypePricingForm
        '
        Me.AcceptButton = Me.viewButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(365, 138)
        Me.Controls.Add(Me.instructionLabel)
        Me.Controls.Add(Me.typeComboBox)
        Me.Controls.Add(Me.cancel2Button)
        Me.Controls.Add(Me.viewButton)
        Me.Controls.Add(Me.equipmentTypeLabel)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewUnknownTypePricingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAESolutions"
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents equipmentTypeLabel As System.Windows.Forms.Label
   Friend WithEvents newErrorProvider As System.Windows.Forms.ErrorProvider
   Friend WithEvents viewButton As System.Windows.Forms.Button
   Friend WithEvents instructionLabel As System.Windows.Forms.Label
    ''Friend WithEvents GradientPanel1 As RAE.UI.Controls.GradientPanel
    Friend WithEvents cancel2Button As System.Windows.Forms.Button
    ''Friend WithEvents GradientPanel3 As RAE.UI.Controls.GradientPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents typeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As Label
End Class
