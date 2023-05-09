<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewProjectAndEquipmentForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewProjectAndEquipmentForm))
        Me.projectNameLabel = New System.Windows.Forms.Label()
        Me.equipmentNameTextBox = New System.Windows.Forms.TextBox()
        Me.projectNameTextBox = New System.Windows.Forms.TextBox()
        Me.equipmentNameLabel = New System.Windows.Forms.Label()
        Me.newErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.okButton = New System.Windows.Forms.Button()
        Me.cancel2Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.saveDiskLabel = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'projectNameLabel
        '
        Me.projectNameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.projectNameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.projectNameLabel.Location = New System.Drawing.Point(18, 12)
        Me.projectNameLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.projectNameLabel.Name = "projectNameLabel"
        Me.projectNameLabel.Size = New System.Drawing.Size(103, 22)
        Me.projectNameLabel.TabIndex = 2
        Me.projectNameLabel.Text = "Project name"
        Me.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'equipmentNameTextBox
        '
        Me.equipmentNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.equipmentNameTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newErrorProvider.SetIconPadding(Me.equipmentNameTextBox, -18)
        Me.equipmentNameTextBox.Location = New System.Drawing.Point(136, 40)
        Me.equipmentNameTextBox.Name = "equipmentNameTextBox"
        Me.equipmentNameTextBox.Size = New System.Drawing.Size(212, 22)
        Me.equipmentNameTextBox.TabIndex = 2
        '
        'projectNameTextBox
        '
        Me.projectNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.projectNameTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newErrorProvider.SetIconPadding(Me.projectNameTextBox, -18)
        Me.projectNameTextBox.Location = New System.Drawing.Point(136, 13)
        Me.projectNameTextBox.Name = "projectNameTextBox"
        Me.projectNameTextBox.Size = New System.Drawing.Size(212, 22)
        Me.projectNameTextBox.TabIndex = 1
        '
        'equipmentNameLabel
        '
        Me.equipmentNameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.equipmentNameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.equipmentNameLabel.Location = New System.Drawing.Point(18, 40)
        Me.equipmentNameLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.equipmentNameLabel.Name = "equipmentNameLabel"
        Me.equipmentNameLabel.Size = New System.Drawing.Size(115, 22)
        Me.equipmentNameLabel.TabIndex = 6
        Me.equipmentNameLabel.Text = "Equipment name"
        Me.equipmentNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'newErrorProvider
        '
        Me.newErrorProvider.ContainerControl = Me
        Me.newErrorProvider.Icon = CType(resources.GetObject("newErrorProvider.Icon"), System.Drawing.Icon)
        '
        'okButton
        '
        Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.okButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.okButton.Location = New System.Drawing.Point(179, 69)
        Me.okButton.Margin = New System.Windows.Forms.Padding(4)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(80, 25)
        Me.okButton.TabIndex = 5
        Me.okButton.Text = " Save"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'cancel2Button
        '
        Me.cancel2Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel2Button.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancel2Button.Location = New System.Drawing.Point(267, 69)
        Me.cancel2Button.Margin = New System.Windows.Forms.Padding(4)
        Me.cancel2Button.Name = "cancel2Button"
        Me.cancel2Button.Size = New System.Drawing.Size(80, 25)
        Me.cancel2Button.TabIndex = 6
        Me.cancel2Button.Text = "Cancel"
        Me.cancel2Button.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(54, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(328, 39)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Choose names for the equipment and project before saving."
        '
        'saveDiskLabel
        '
        Me.saveDiskLabel.BackColor = System.Drawing.Color.Transparent
        Me.saveDiskLabel.ImageIndex = 2
        Me.saveDiskLabel.ImageList = Me.ImageList1
        Me.saveDiskLabel.Location = New System.Drawing.Point(14, 17)
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
        'NewProjectAndEquipmentForm
        '
        Me.AcceptButton = Me.okButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(360, 110)
        Me.Controls.Add(Me.projectNameTextBox)
        Me.Controls.Add(Me.equipmentNameTextBox)
        Me.Controls.Add(Me.equipmentNameLabel)
        Me.Controls.Add(Me.projectNameLabel)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.cancel2Button)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewProjectAndEquipmentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAESolutions"
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents projectNameLabel As System.Windows.Forms.Label
   Friend WithEvents equipmentNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents projectNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents equipmentNameLabel As System.Windows.Forms.Label
   Friend WithEvents newErrorProvider As System.Windows.Forms.ErrorProvider
   Friend WithEvents okButton As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents GradientPanel1 As RAE.UI.Controls.GradientPanel
    Friend WithEvents cancel2Button As System.Windows.Forms.Button
    'Friend WithEvents GradientPanel3 As RAE.UI.Controls.GradientPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents saveDiskLabel As System.Windows.Forms.Label
End Class
