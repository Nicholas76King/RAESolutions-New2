<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactCompanyControl
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
      Me.components = New System.ComponentModel.Container
      Me.companyLabel = New System.Windows.Forms.Label
      Me.companyComboBox = New System.Windows.Forms.ComboBox
      Me.contactComboBox = New System.Windows.Forms.ComboBox
      Me.contactLabel = New System.Windows.Forms.Label
      Me.tip = New System.Windows.Forms.ToolTip(Me.components)
      Me.contactPanel = New System.Windows.Forms.Panel
      Me.actionsPanel = New System.Windows.Forms.Panel
      Me.addCompanyRolloverPictureBox = New Rae.Ui.Controls.RolloverPictureBox
      Me.addContactRolloverPictureBox = New Rae.Ui.Controls.RolloverPictureBox
      Me.editCompanyRolloverPictureBox = New Rae.Ui.Controls.RolloverPictureBox
      Me.editContactRolloverPictureBox = New Rae.Ui.Controls.RolloverPictureBox
      Me.contactPanel.SuspendLayout()
      Me.actionsPanel.SuspendLayout()
      CType(Me.addCompanyRolloverPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.addContactRolloverPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.editCompanyRolloverPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.editContactRolloverPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'companyLabel
      '
      Me.companyLabel.ForeColor = System.Drawing.Color.DimGray
      Me.companyLabel.Location = New System.Drawing.Point(3, 2)
      Me.companyLabel.Name = "companyLabel"
      Me.companyLabel.Size = New System.Drawing.Size(69, 24)
      Me.companyLabel.TabIndex = 0
      Me.companyLabel.Text = "Company"
      Me.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'companyComboBox
      '
      Me.companyComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.companyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.companyComboBox.FormattingEnabled = True
      Me.companyComboBox.Location = New System.Drawing.Point(75, 2)
      Me.companyComboBox.Name = "companyComboBox"
      Me.companyComboBox.Size = New System.Drawing.Size(204, 24)
      Me.companyComboBox.TabIndex = 1
      '
      'contactComboBox
      '
      Me.contactComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.contactComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.contactComboBox.FormattingEnabled = True
      Me.contactComboBox.Location = New System.Drawing.Point(75, 32)
      Me.contactComboBox.Name = "contactComboBox"
      Me.contactComboBox.Size = New System.Drawing.Size(204, 24)
      Me.contactComboBox.TabIndex = 3
      '
      'contactLabel
      '
      Me.contactLabel.ForeColor = System.Drawing.Color.DimGray
      Me.contactLabel.Location = New System.Drawing.Point(3, 32)
      Me.contactLabel.Name = "contactLabel"
      Me.contactLabel.Size = New System.Drawing.Size(69, 24)
      Me.contactLabel.TabIndex = 2
      Me.contactLabel.Text = "Contact"
      Me.contactLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tip
      '
      Me.tip.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.tip.IsBalloon = True
      '
      'contactPanel
      '
      Me.contactPanel.Controls.Add(Me.companyLabel)
      Me.contactPanel.Controls.Add(Me.companyComboBox)
      Me.contactPanel.Controls.Add(Me.contactLabel)
      Me.contactPanel.Controls.Add(Me.contactComboBox)
      Me.contactPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.contactPanel.Location = New System.Drawing.Point(0, 0)
      Me.contactPanel.Name = "contactPanel"
      Me.contactPanel.Size = New System.Drawing.Size(282, 58)
      Me.contactPanel.TabIndex = 8
      '
      'actionsPanel
      '
      Me.actionsPanel.Controls.Add(Me.addCompanyRolloverPictureBox)
      Me.actionsPanel.Controls.Add(Me.addContactRolloverPictureBox)
      Me.actionsPanel.Controls.Add(Me.editCompanyRolloverPictureBox)
      Me.actionsPanel.Controls.Add(Me.editContactRolloverPictureBox)
      Me.actionsPanel.Dock = System.Windows.Forms.DockStyle.Right
      Me.actionsPanel.Location = New System.Drawing.Point(282, 0)
      Me.actionsPanel.Name = "actionsPanel"
      Me.actionsPanel.Size = New System.Drawing.Size(41, 58)
      Me.actionsPanel.TabIndex = 9
      '
      'addCompanyRolloverPictureBox
      '
      Me.addCompanyRolloverPictureBox.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Add
      Me.addCompanyRolloverPictureBox.Location = New System.Drawing.Point(0, 2)
      Me.addCompanyRolloverPictureBox.Name = "addCompanyRolloverPictureBox"
      Me.addCompanyRolloverPictureBox.RolloverCursor = System.Windows.Forms.Cursors.Hand
      Me.addCompanyRolloverPictureBox.RolloverImage = Global.Rae.RaeSolutions.My.Resources.Resources.Add
      Me.addCompanyRolloverPictureBox.Size = New System.Drawing.Size(20, 24)
      Me.addCompanyRolloverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.addCompanyRolloverPictureBox.TabIndex = 4
      Me.addCompanyRolloverPictureBox.TabStop = False
      Me.tip.SetToolTip(Me.addCompanyRolloverPictureBox, "Add a company")
      '
      'addContactRolloverPictureBox
      '
      Me.addContactRolloverPictureBox.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Add
      Me.addContactRolloverPictureBox.Location = New System.Drawing.Point(0, 32)
      Me.addContactRolloverPictureBox.Name = "addContactRolloverPictureBox"
      Me.addContactRolloverPictureBox.RolloverCursor = System.Windows.Forms.Cursors.Hand
      Me.addContactRolloverPictureBox.RolloverImage = Nothing
      Me.addContactRolloverPictureBox.Size = New System.Drawing.Size(20, 24)
      Me.addContactRolloverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.addContactRolloverPictureBox.TabIndex = 5
      Me.addContactRolloverPictureBox.TabStop = False
      Me.tip.SetToolTip(Me.addContactRolloverPictureBox, "Add a contact")
      '
      'editCompanyRolloverPictureBox
      '
      Me.editCompanyRolloverPictureBox.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Pencil
      Me.editCompanyRolloverPictureBox.Location = New System.Drawing.Point(20, 2)
      Me.editCompanyRolloverPictureBox.Name = "editCompanyRolloverPictureBox"
      Me.editCompanyRolloverPictureBox.RolloverCursor = System.Windows.Forms.Cursors.Hand
      Me.editCompanyRolloverPictureBox.RolloverImage = Nothing
      Me.editCompanyRolloverPictureBox.Size = New System.Drawing.Size(20, 24)
      Me.editCompanyRolloverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.editCompanyRolloverPictureBox.TabIndex = 6
      Me.editCompanyRolloverPictureBox.TabStop = False
      Me.tip.SetToolTip(Me.editCompanyRolloverPictureBox, "Edit the selected company")
      '
      'editContactRolloverPictureBox
      '
      Me.editContactRolloverPictureBox.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Pencil
      Me.editContactRolloverPictureBox.Location = New System.Drawing.Point(20, 32)
      Me.editContactRolloverPictureBox.Name = "editContactRolloverPictureBox"
      Me.editContactRolloverPictureBox.RolloverCursor = System.Windows.Forms.Cursors.Hand
      Me.editContactRolloverPictureBox.RolloverImage = Nothing
      Me.editContactRolloverPictureBox.Size = New System.Drawing.Size(20, 24)
      Me.editContactRolloverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.editContactRolloverPictureBox.TabIndex = 7
      Me.editContactRolloverPictureBox.TabStop = False
      Me.tip.SetToolTip(Me.editContactRolloverPictureBox, "Edit the selected contact")
      '
      'ContactCompanyControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Transparent
      Me.Controls.Add(Me.contactPanel)
      Me.Controls.Add(Me.actionsPanel)
      Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.Name = "ContactCompanyControl"
      Me.Size = New System.Drawing.Size(323, 58)
      Me.contactPanel.ResumeLayout(False)
      Me.actionsPanel.ResumeLayout(False)
      CType(Me.addCompanyRolloverPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.addContactRolloverPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.editCompanyRolloverPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.editContactRolloverPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents companyLabel As System.Windows.Forms.Label
   Friend WithEvents companyComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents contactComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents contactLabel As System.Windows.Forms.Label
   Friend WithEvents addCompanyRolloverPictureBox As Rae.Ui.Controls.RolloverPictureBox
   Friend WithEvents addContactRolloverPictureBox As Rae.Ui.Controls.RolloverPictureBox
   Friend WithEvents editContactRolloverPictureBox As Rae.Ui.Controls.RolloverPictureBox
   Friend WithEvents editCompanyRolloverPictureBox As Rae.Ui.Controls.RolloverPictureBox
   Friend WithEvents tip As System.Windows.Forms.ToolTip
   Friend WithEvents contactPanel As System.Windows.Forms.Panel
   Friend WithEvents actionsPanel As System.Windows.Forms.Panel

End Class
