<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewItemForm2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewItemForm2))
        Me.equipmentNameTextBox = New System.Windows.Forms.TextBox()
        Me.equipmentNameLabel = New System.Windows.Forms.Label()
        Me.newErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.projectNameTextBox = New System.Windows.Forms.TextBox()
        Me.selectionNameTextBox = New System.Windows.Forms.TextBox()
        Me.txtRevDesc = New System.Windows.Forms.TextBox()
        Me.GradientPanel1 = New Rae.Ui.Controls.GradientPanel()
        Me.okButton = New System.Windows.Forms.Button()
        Me.cancel2Button = New System.Windows.Forms.Button()
        Me.captionLabel = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Rae.Ui.Controls.GradientPanel()
        Me.saveDiskLabel = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.projectNamePanel = New System.Windows.Forms.Panel()
        Me.projectNameLabel = New System.Windows.Forms.Label()
        Me.equipmentNamePanel = New System.Windows.Forms.Panel()
        Me.equipmentAdditionalInfoPanel = New System.Windows.Forms.Panel()
        Me.equipmentTypeLabel = New System.Windows.Forms.Label()
        Me.divisionNameLabel = New System.Windows.Forms.Label()
        Me.cboEquipmentType = New System.Windows.Forms.ComboBox()
        Me.cboDivision = New System.Windows.Forms.ComboBox()
        Me.selectionNamePanel = New System.Windows.Forms.Panel()
        Me.selectionNameLabel = New System.Windows.Forms.Label()
        Me.pnlRevDesc = New System.Windows.Forms.Panel()
        Me.lblRevDesc = New System.Windows.Forms.Label()
        Me.selectionTypePanel = New System.Windows.Forms.Panel()
        Me.cboProcessTypes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel3.SuspendLayout()
        Me.projectNamePanel.SuspendLayout()
        Me.equipmentNamePanel.SuspendLayout()
        Me.equipmentAdditionalInfoPanel.SuspendLayout()
        Me.selectionNamePanel.SuspendLayout()
        Me.pnlRevDesc.SuspendLayout()
        Me.selectionTypePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'equipmentNameTextBox
        '
        Me.equipmentNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.equipmentNameTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newErrorProvider.SetIconPadding(Me.equipmentNameTextBox, -18)
        Me.equipmentNameTextBox.Location = New System.Drawing.Point(174, 3)
        Me.equipmentNameTextBox.Name = "equipmentNameTextBox"
        Me.equipmentNameTextBox.Size = New System.Drawing.Size(197, 22)
        Me.equipmentNameTextBox.TabIndex = 1
        '
        'equipmentNameLabel
        '
        Me.equipmentNameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.equipmentNameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.equipmentNameLabel.Location = New System.Drawing.Point(34, 3)
        Me.equipmentNameLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.equipmentNameLabel.Name = "equipmentNameLabel"
        Me.equipmentNameLabel.Size = New System.Drawing.Size(137, 22)
        Me.equipmentNameLabel.TabIndex = 6
        Me.equipmentNameLabel.Text = "Equipment name"
        Me.equipmentNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'newErrorProvider
        '
        Me.newErrorProvider.ContainerControl = Me
        Me.newErrorProvider.Icon = CType(resources.GetObject("newErrorProvider.Icon"), System.Drawing.Icon)
        '
        'projectNameTextBox
        '
        Me.projectNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.projectNameTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newErrorProvider.SetIconPadding(Me.projectNameTextBox, -18)
        Me.projectNameTextBox.Location = New System.Drawing.Point(174, 3)
        Me.projectNameTextBox.Name = "projectNameTextBox"
        Me.projectNameTextBox.Size = New System.Drawing.Size(197, 22)
        Me.projectNameTextBox.TabIndex = 0
        '
        'selectionNameTextBox
        '
        Me.selectionNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectionNameTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newErrorProvider.SetIconPadding(Me.selectionNameTextBox, -18)
        Me.selectionNameTextBox.Location = New System.Drawing.Point(174, 3)
        Me.selectionNameTextBox.Name = "selectionNameTextBox"
        Me.selectionNameTextBox.Size = New System.Drawing.Size(197, 22)
        Me.selectionNameTextBox.TabIndex = 4
        '
        'txtRevDesc
        '
        Me.txtRevDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRevDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newErrorProvider.SetIconPadding(Me.txtRevDesc, -18)
        Me.txtRevDesc.Location = New System.Drawing.Point(174, 3)
        Me.txtRevDesc.Name = "txtRevDesc"
        Me.txtRevDesc.Size = New System.Drawing.Size(197, 22)
        Me.txtRevDesc.TabIndex = 4
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Empty
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.BorderWidth = 0
        Me.GradientPanel1.Controls.Add(Me.okButton)
        Me.GradientPanel1.Controls.Add(Me.cancel2Button)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel1.Flip = False
        Me.GradientPanel1.GradientAngle = 90
        Me.GradientPanel1.GradientEndColor = System.Drawing.Color.SteelBlue
        Me.GradientPanel1.GradientStartColor = System.Drawing.Color.LightSteelBlue
        Me.GradientPanel1.HorizontalFillPercent = 100.0!
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 270)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(399, 50)
        Me.GradientPanel1.TabIndex = 7
        Me.GradientPanel1.VerticalFillPercent = 100.0!
        '
        'okButton
        '
        Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.okButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.okButton.Location = New System.Drawing.Point(216, 12)
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
        Me.cancel2Button.Location = New System.Drawing.Point(304, 12)
        Me.cancel2Button.Margin = New System.Windows.Forms.Padding(4)
        Me.cancel2Button.Name = "cancel2Button"
        Me.cancel2Button.Size = New System.Drawing.Size(80, 25)
        Me.cancel2Button.TabIndex = 6
        Me.cancel2Button.Text = "Cancel"
        Me.cancel2Button.UseVisualStyleBackColor = True
        '
        'captionLabel
        '
        Me.captionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.captionLabel.BackColor = System.Drawing.Color.Transparent
        Me.captionLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.captionLabel.ForeColor = System.Drawing.Color.White
        Me.captionLabel.Location = New System.Drawing.Point(54, 13)
        Me.captionLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.captionLabel.Name = "captionLabel"
        Me.captionLabel.Size = New System.Drawing.Size(328, 39)
        Me.captionLabel.TabIndex = 8
        Me.captionLabel.Text = "Please choose project name before saving."
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Empty
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.BorderWidth = 0
        Me.GradientPanel3.Controls.Add(Me.saveDiskLabel)
        Me.GradientPanel3.Controls.Add(Me.captionLabel)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel3.Flip = True
        Me.GradientPanel3.GradientAngle = 90
        Me.GradientPanel3.GradientEndColor = System.Drawing.Color.SteelBlue
        Me.GradientPanel3.GradientStartColor = System.Drawing.Color.LightSteelBlue
        Me.GradientPanel3.HorizontalFillPercent = 100.0!
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(399, 68)
        Me.GradientPanel3.TabIndex = 10
        Me.GradientPanel3.VerticalFillPercent = 100.0!
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
        'projectNamePanel
        '
        Me.projectNamePanel.AutoSize = True
        Me.projectNamePanel.Controls.Add(Me.projectNameTextBox)
        Me.projectNamePanel.Controls.Add(Me.projectNameLabel)
        Me.projectNamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.projectNamePanel.Location = New System.Drawing.Point(0, 68)
        Me.projectNamePanel.Name = "projectNamePanel"
        Me.projectNamePanel.Size = New System.Drawing.Size(399, 29)
        Me.projectNamePanel.TabIndex = 11
        Me.projectNamePanel.Visible = False
        '
        'projectNameLabel
        '
        Me.projectNameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.projectNameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.projectNameLabel.Location = New System.Drawing.Point(34, 3)
        Me.projectNameLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.projectNameLabel.Name = "projectNameLabel"
        Me.projectNameLabel.Size = New System.Drawing.Size(125, 22)
        Me.projectNameLabel.TabIndex = 4
        Me.projectNameLabel.Text = "Project name"
        Me.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'equipmentNamePanel
        '
        Me.equipmentNamePanel.AutoSize = True
        Me.equipmentNamePanel.Controls.Add(Me.equipmentAdditionalInfoPanel)
        Me.equipmentNamePanel.Controls.Add(Me.equipmentNameTextBox)
        Me.equipmentNamePanel.Controls.Add(Me.equipmentNameLabel)
        Me.equipmentNamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.equipmentNamePanel.Location = New System.Drawing.Point(0, 97)
        Me.equipmentNamePanel.Name = "equipmentNamePanel"
        Me.equipmentNamePanel.Size = New System.Drawing.Size(399, 86)
        Me.equipmentNamePanel.TabIndex = 12
        Me.equipmentNamePanel.Visible = False
        '
        'equipmentAdditionalInfoPanel
        '
        Me.equipmentAdditionalInfoPanel.Controls.Add(Me.equipmentTypeLabel)
        Me.equipmentAdditionalInfoPanel.Controls.Add(Me.divisionNameLabel)
        Me.equipmentAdditionalInfoPanel.Controls.Add(Me.cboEquipmentType)
        Me.equipmentAdditionalInfoPanel.Controls.Add(Me.cboDivision)
        Me.equipmentAdditionalInfoPanel.Location = New System.Drawing.Point(0, 25)
        Me.equipmentAdditionalInfoPanel.Name = "equipmentAdditionalInfoPanel"
        Me.equipmentAdditionalInfoPanel.Size = New System.Drawing.Size(399, 58)
        Me.equipmentAdditionalInfoPanel.TabIndex = 7
        Me.equipmentAdditionalInfoPanel.Visible = False
        '
        'equipmentTypeLabel
        '
        Me.equipmentTypeLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.equipmentTypeLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.equipmentTypeLabel.Location = New System.Drawing.Point(34, 33)
        Me.equipmentTypeLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.equipmentTypeLabel.Name = "equipmentTypeLabel"
        Me.equipmentTypeLabel.Size = New System.Drawing.Size(137, 22)
        Me.equipmentTypeLabel.TabIndex = 9
        Me.equipmentTypeLabel.Text = "Equipment type"
        Me.equipmentTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'divisionNameLabel
        '
        Me.divisionNameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.divisionNameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.divisionNameLabel.Location = New System.Drawing.Point(34, 5)
        Me.divisionNameLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.divisionNameLabel.Name = "divisionNameLabel"
        Me.divisionNameLabel.Size = New System.Drawing.Size(137, 22)
        Me.divisionNameLabel.TabIndex = 8
        Me.divisionNameLabel.Text = "Division"
        Me.divisionNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEquipmentType
        '
        Me.cboEquipmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEquipmentType.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboEquipmentType.Location = New System.Drawing.Point(174, 34)
        Me.cboEquipmentType.Name = "cboEquipmentType"
        Me.cboEquipmentType.Size = New System.Drawing.Size(197, 22)
        Me.cboEquipmentType.TabIndex = 3
        '
        'cboDivision
        '
        Me.cboDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDivision.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboDivision.FormattingEnabled = True
        Me.cboDivision.Location = New System.Drawing.Point(174, 6)
        Me.cboDivision.Name = "cboDivision"
        Me.cboDivision.Size = New System.Drawing.Size(197, 22)
        Me.cboDivision.TabIndex = 2
        '
        'selectionNamePanel
        '
        Me.selectionNamePanel.AutoSize = True
        Me.selectionNamePanel.Controls.Add(Me.selectionNameTextBox)
        Me.selectionNamePanel.Controls.Add(Me.selectionNameLabel)
        Me.selectionNamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.selectionNamePanel.Location = New System.Drawing.Point(0, 212)
        Me.selectionNamePanel.Name = "selectionNamePanel"
        Me.selectionNamePanel.Size = New System.Drawing.Size(399, 29)
        Me.selectionNamePanel.TabIndex = 13
        Me.selectionNamePanel.Visible = False
        '
        'selectionNameLabel
        '
        Me.selectionNameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectionNameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.selectionNameLabel.Location = New System.Drawing.Point(34, 3)
        Me.selectionNameLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.selectionNameLabel.Name = "selectionNameLabel"
        Me.selectionNameLabel.Size = New System.Drawing.Size(137, 22)
        Me.selectionNameLabel.TabIndex = 6
        Me.selectionNameLabel.Text = "Selection name"
        Me.selectionNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlRevDesc
        '
        Me.pnlRevDesc.AutoSize = True
        Me.pnlRevDesc.Controls.Add(Me.txtRevDesc)
        Me.pnlRevDesc.Controls.Add(Me.lblRevDesc)
        Me.pnlRevDesc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRevDesc.Location = New System.Drawing.Point(0, 183)
        Me.pnlRevDesc.Name = "pnlRevDesc"
        Me.pnlRevDesc.Size = New System.Drawing.Size(399, 29)
        Me.pnlRevDesc.TabIndex = 14
        Me.pnlRevDesc.Visible = False
        '
        'lblRevDesc
        '
        Me.lblRevDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevDesc.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRevDesc.Location = New System.Drawing.Point(36, 3)
        Me.lblRevDesc.Margin = New System.Windows.Forms.Padding(4)
        Me.lblRevDesc.Name = "lblRevDesc"
        Me.lblRevDesc.Size = New System.Drawing.Size(135, 22)
        Me.lblRevDesc.TabIndex = 6
        Me.lblRevDesc.Text = "Revision Description"
        Me.lblRevDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'selectionTypePanel
        '
        Me.selectionTypePanel.AutoSize = True
        Me.selectionTypePanel.Controls.Add(Me.cboProcessTypes)
        Me.selectionTypePanel.Controls.Add(Me.Label1)
        Me.selectionTypePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.selectionTypePanel.Location = New System.Drawing.Point(0, 241)
        Me.selectionTypePanel.Name = "selectionTypePanel"
        Me.selectionTypePanel.Size = New System.Drawing.Size(399, 29)
        Me.selectionTypePanel.TabIndex = 1
        Me.selectionTypePanel.Visible = False
        '
        'cboProcessTypes
        '
        Me.cboProcessTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProcessTypes.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cboProcessTypes.Location = New System.Drawing.Point(174, 3)
        Me.cboProcessTypes.Name = "cboProcessTypes"
        Me.cboProcessTypes.Size = New System.Drawing.Size(197, 22)
        Me.cboProcessTypes.Sorted = True
        Me.cboProcessTypes.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(34, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 22)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Selection type"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NewItemForm2
        '
        Me.AcceptButton = Me.okButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(399, 320)
        Me.Controls.Add(Me.selectionTypePanel)
        Me.Controls.Add(Me.selectionNamePanel)
        Me.Controls.Add(Me.pnlRevDesc)
        Me.Controls.Add(Me.equipmentNamePanel)
        Me.Controls.Add(Me.projectNamePanel)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewItemForm2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAESolutions"
        CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel3.ResumeLayout(False)
        Me.projectNamePanel.ResumeLayout(False)
        Me.projectNamePanel.PerformLayout()
        Me.equipmentNamePanel.ResumeLayout(False)
        Me.equipmentNamePanel.PerformLayout()
        Me.equipmentAdditionalInfoPanel.ResumeLayout(False)
        Me.selectionNamePanel.ResumeLayout(False)
        Me.selectionNamePanel.PerformLayout()
        Me.pnlRevDesc.ResumeLayout(False)
        Me.pnlRevDesc.PerformLayout()
        Me.selectionTypePanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents equipmentNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents equipmentNameLabel As System.Windows.Forms.Label
    Friend WithEvents newErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents captionLabel As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Rae.Ui.Controls.GradientPanel
    Friend WithEvents cancel2Button As System.Windows.Forms.Button
    Friend WithEvents GradientPanel3 As Rae.Ui.Controls.GradientPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents saveDiskLabel As System.Windows.Forms.Label
    Friend WithEvents projectNamePanel As System.Windows.Forms.Panel
    Friend WithEvents projectNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents projectNameLabel As System.Windows.Forms.Label
    Friend WithEvents equipmentNamePanel As System.Windows.Forms.Panel
    Friend WithEvents selectionNamePanel As System.Windows.Forms.Panel
    Friend WithEvents selectionNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents selectionNameLabel As System.Windows.Forms.Label
    Friend WithEvents equipmentAdditionalInfoPanel As System.Windows.Forms.Panel
    Friend WithEvents equipmentTypeLabel As System.Windows.Forms.Label
    Friend WithEvents divisionNameLabel As System.Windows.Forms.Label
    Friend WithEvents cboEquipmentType As System.Windows.Forms.ComboBox
    Friend WithEvents cboDivision As System.Windows.Forms.ComboBox
    Friend WithEvents pnlRevDesc As System.Windows.Forms.Panel
    Friend WithEvents txtRevDesc As System.Windows.Forms.TextBox
    Friend WithEvents lblRevDesc As System.Windows.Forms.Label
    Friend WithEvents selectionTypePanel As System.Windows.Forms.Panel
    Friend WithEvents cboProcessTypes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
