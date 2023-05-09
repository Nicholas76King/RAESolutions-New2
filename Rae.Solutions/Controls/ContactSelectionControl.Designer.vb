<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactSelectionControl
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
        Me.GradientPanel1 = New Rae.Ui.Controls.GradientPanel()
        Me.roleComboBox = New System.Windows.Forms.ComboBox()
        Me.roleLabel = New System.Windows.Forms.Label()
        Me.ContactCompanyControl1 = New Rae.RaeSolutions.ContactCompanyControl()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderWidth = 1
        Me.GradientPanel1.Controls.Add(Me.roleComboBox)
        Me.GradientPanel1.Controls.Add(Me.roleLabel)
        Me.GradientPanel1.Controls.Add(Me.ContactCompanyControl1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Flip = False
        Me.GradientPanel1.GradientAngle = 225
        Me.GradientPanel1.GradientEndColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientStartColor = System.Drawing.Color.AliceBlue
        Me.GradientPanel1.HorizontalFillPercent = 100.0!
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(320, 95)
        Me.GradientPanel1.TabIndex = 3
        Me.GradientPanel1.VerticalFillPercent = 100.0!
        '
        'roleComboBox
        '
        Me.roleComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.roleComboBox.FormattingEnabled = True
        Me.roleComboBox.Items.AddRange(New Object() {"Representative", "Contractor", "End User", "General Contractor", "Engineer", "Architect", "Employee"})
        Me.roleComboBox.Location = New System.Drawing.Point(75, 5)
        Me.roleComboBox.Name = "roleComboBox"
        Me.roleComboBox.Size = New System.Drawing.Size(199, 24)
        Me.roleComboBox.TabIndex = 1
        '
        'roleLabel
        '
        Me.roleLabel.AutoEllipsis = True
        Me.roleLabel.BackColor = System.Drawing.Color.Transparent
        Me.roleLabel.ForeColor = System.Drawing.Color.DimGray
        Me.roleLabel.Location = New System.Drawing.Point(3, 5)
        Me.roleLabel.Name = "roleLabel"
        Me.roleLabel.Size = New System.Drawing.Size(66, 24)
        Me.roleLabel.TabIndex = 2
        Me.roleLabel.Text = "Role"
        Me.roleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContactCompanyControl1
        '
        Me.ContactCompanyControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContactCompanyControl1.BackColor = System.Drawing.Color.Transparent
        Me.ContactCompanyControl1.Category = Nothing
        Me.ContactCompanyControl1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactCompanyControl1.Location = New System.Drawing.Point(0, 33)
        Me.ContactCompanyControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ContactCompanyControl1.Name = "ContactCompanyControl1"
        Me.ContactCompanyControl1.SelectedCompany = Nothing
        Me.ContactCompanyControl1.SelectedContact = Nothing
        Me.ContactCompanyControl1.Size = New System.Drawing.Size(318, 58)
        Me.ContactCompanyControl1.TabIndex = 0
        '
        'ContactSelectionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(8)
        Me.Name = "ContactSelectionControl"
        Me.Size = New System.Drawing.Size(320, 95)
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
   Friend WithEvents ContactCompanyControl1 As Rae.RaeSolutions.ContactCompanyControl
   Friend WithEvents roleComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents roleLabel As System.Windows.Forms.Label
   Friend WithEvents GradientPanel1 As Rae.Ui.Controls.GradientPanel

End Class
