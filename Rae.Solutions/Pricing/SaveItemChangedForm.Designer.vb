<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveItemChangedForm
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
        Me.radSaveRev = New System.Windows.Forms.RadioButton()
        Me.radDoNotSave = New System.Windows.Forms.RadioButton()
        Me.radSave = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.projectNamePanel = New System.Windows.Forms.Panel()
        Me.captionLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'radSaveRev
        '
        Me.radSaveRev.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.radSaveRev.ForeColor = System.Drawing.Color.SteelBlue
        Me.radSaveRev.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
        Me.radSaveRev.Location = New System.Drawing.Point(77, 105)
        Me.radSaveRev.Name = "radSaveRev"
        Me.radSaveRev.Size = New System.Drawing.Size(227, 25)
        Me.radSaveRev.TabIndex = 0
        Me.radSaveRev.Text = " Save changes as revision."
        Me.radSaveRev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.radSaveRev.UseVisualStyleBackColor = True
        '
        'radDoNotSave
        '
        Me.radDoNotSave.Checked = True
        Me.radDoNotSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.radDoNotSave.ForeColor = System.Drawing.Color.SteelBlue
        Me.radDoNotSave.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.radDoNotSave.Location = New System.Drawing.Point(77, 136)
        Me.radDoNotSave.Name = "radDoNotSave"
        Me.radDoNotSave.Size = New System.Drawing.Size(209, 25)
        Me.radDoNotSave.TabIndex = 2
        Me.radDoNotSave.TabStop = True
        Me.radDoNotSave.Text = " Nothing - Do not save."
        Me.radDoNotSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.radDoNotSave.UseVisualStyleBackColor = True
        '
        'radSave
        '
        Me.radSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.radSave.ForeColor = System.Drawing.Color.SteelBlue
        Me.radSave.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.radSave.Location = New System.Drawing.Point(77, 74)
        Me.radSave.Name = "radSave"
        Me.radSave.Size = New System.Drawing.Size(156, 25)
        Me.radSave.TabIndex = 1
        Me.radSave.Text = " Save changes."
        Me.radSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.radSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(153, 185)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'projectNamePanel
        '
        Me.projectNamePanel.AutoSize = True
        Me.projectNamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.projectNamePanel.Location = New System.Drawing.Point(0, 0)
        Me.projectNamePanel.Name = "projectNamePanel"
        Me.projectNamePanel.Size = New System.Drawing.Size(397, 0)
        Me.projectNamePanel.TabIndex = 14
        Me.projectNamePanel.Visible = False
        '
        'captionLabel
        '
        Me.captionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.captionLabel.BackColor = System.Drawing.Color.Transparent
        Me.captionLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.captionLabel.ForeColor = System.Drawing.Color.White
        Me.captionLabel.Location = New System.Drawing.Point(4, 13)
        Me.captionLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.captionLabel.Name = "captionLabel"
        Me.captionLabel.Size = New System.Drawing.Size(387, 47)
        Me.captionLabel.TabIndex = 8
        Me.captionLabel.Text = "Changes have been made since your last save.  What would you like to do?"
        '
        'SaveItemChangedForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(397, 220)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.radSaveRev)
        Me.Controls.Add(Me.projectNamePanel)
        Me.Controls.Add(Me.radDoNotSave)
        Me.Controls.Add(Me.radSave)
        Me.Name = "SaveItemChangedForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAE Solutions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents radSaveRev As System.Windows.Forms.RadioButton
   Friend WithEvents radDoNotSave As System.Windows.Forms.RadioButton
   Friend WithEvents radSave As System.Windows.Forms.RadioButton
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents projectNamePanel As System.Windows.Forms.Panel
    ''Friend WithEvents GradientPanel3 As RAE.UI.Controls.GradientPanel
    Friend WithEvents captionLabel As System.Windows.Forms.Label
    ''Friend WithEvents GradientPanel1 As RAE.UI.Controls.GradientPanel
End Class
