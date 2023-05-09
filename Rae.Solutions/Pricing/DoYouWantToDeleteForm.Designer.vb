<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DoYouWantToDeleteForm
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
        Me.captionLabel = New System.Windows.Forms.Label()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.projectNameLabel = New System.Windows.Forms.Label()
        Me.notePanel = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'captionLabel
        '
        Me.captionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.captionLabel.BackColor = System.Drawing.Color.Transparent
        Me.captionLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.captionLabel.ForeColor = System.Drawing.Color.White
        Me.captionLabel.Location = New System.Drawing.Point(31, 13)
        Me.captionLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.captionLabel.Name = "captionLabel"
        Me.captionLabel.Size = New System.Drawing.Size(284, 39)
        Me.captionLabel.TabIndex = 8
        Me.captionLabel.Text = "Are you sure you want to delete this project?"
        '
        'deleteButton
        '
        Me.deleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.deleteButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.deleteButton.Location = New System.Drawing.Point(170, 98)
        Me.deleteButton.Margin = New System.Windows.Forms.Padding(4)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(80, 25)
        Me.deleteButton.TabIndex = 5
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.deleteButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cancelButton.Location = New System.Drawing.Point(262, 98)
        Me.cancelButton.Margin = New System.Windows.Forms.Padding(4)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(80, 25)
        Me.cancelButton.TabIndex = 6
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'projectNameLabel
        '
        Me.projectNameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.projectNameLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.projectNameLabel.Location = New System.Drawing.Point(32, 59)
        Me.projectNameLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.projectNameLabel.Name = "projectNameLabel"
        Me.projectNameLabel.Size = New System.Drawing.Size(308, 22)
        Me.projectNameLabel.TabIndex = 4
        Me.projectNameLabel.Text = "Note: You will not be able to undo this action."
        Me.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'notePanel
        '
        Me.notePanel.AutoSize = True
        Me.notePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.notePanel.Location = New System.Drawing.Point(0, 0)
        Me.notePanel.Name = "notePanel"
        Me.notePanel.Size = New System.Drawing.Size(355, 0)
        Me.notePanel.TabIndex = 14
        '
        'DoYouWantToDeleteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(355, 147)
        Me.Controls.Add(Me.projectNameLabel)
        Me.Controls.Add(Me.notePanel)
        Me.Controls.Add(Me.captionLabel)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.deleteButton)
        Me.Name = "DoYouWantToDeleteForm"
        Me.Text = "Delete Confirmation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    ''Friend WithEvents GradientPanel3 As RAE.UI.Controls.GradientPanel
    Friend WithEvents captionLabel As System.Windows.Forms.Label
    ''Friend WithEvents GradientPanel1 As RAE.UI.Controls.GradientPanel
    Friend WithEvents deleteButton As System.Windows.Forms.Button
   Friend WithEvents cancelButton As System.Windows.Forms.Button
   Friend WithEvents projectNameLabel As System.Windows.Forms.Label
   Friend WithEvents notePanel As System.Windows.Forms.Panel
End Class
