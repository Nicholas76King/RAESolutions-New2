<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackupForm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BackupForm))
        Me.saveBackup = New System.Windows.Forms.SaveFileDialog
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.imglSave = New System.Windows.Forms.ImageList(Me.components)
        Me.buToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'saveBackup
        '
        Me.saveBackup.DefaultExt = "mdb"
        Me.saveBackup.FileName = "Projects.mdb"
        Me.saveBackup.Filter = "Access files|*.mdb"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(109, 9)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(259, 20)
        Me.txtLocation.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Backup Location:"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdBrowse.Image = Global.Rae.RaeSolutions.My.Resources.Resources.PrintPreview
        Me.cmdBrowse.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.cmdBrowse.Location = New System.Drawing.Point(374, 7)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(27, 23)
        Me.cmdBrowse.TabIndex = 2
        Me.buToolTip.SetToolTip(Me.cmdBrowse, "Browse for File")
        Me.cmdBrowse.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdSave.Enabled = False
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.cmdSave.ImageIndex = 0
        Me.cmdSave.ImageList = Me.imglSave
        Me.cmdSave.Location = New System.Drawing.Point(407, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(24, 23)
        Me.cmdSave.TabIndex = 3
        Me.buToolTip.SetToolTip(Me.cmdSave, "Save BackUp")
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'imglSave
        '
        Me.imglSave.ImageStream = CType(resources.GetObject("imglSave.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglSave.TransparentColor = System.Drawing.Color.Transparent
        Me.imglSave.Images.SetKeyName(0, "Save_Disabled.ico")
        Me.imglSave.Images.SetKeyName(1, "Save.ico")
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.cmdCancel.Location = New System.Drawing.Point(437, 7)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(25, 23)
        Me.cmdCancel.TabIndex = 4
        Me.buToolTip.SetToolTip(Me.cmdCancel, "Cancel Backup")
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "WARNING!"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(16, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(446, 64)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "This backup will save a copy of your projects in their current state.  Any future" & _
            " restoration of your projects from this backup will overwrite any additions/modi" & _
            "fications made since this backup."
        '
        'BackupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(494, 140)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLocation)
        Me.Name = "BackupForm"
        Me.Text = "BackupForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents saveBackup As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents buToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents imglSave As System.Windows.Forms.ImageList
End Class
