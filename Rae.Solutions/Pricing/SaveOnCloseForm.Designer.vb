<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveOnCloseForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveOnCloseForm))
        Me.projectNamePanel = New System.Windows.Forms.Panel()
        Me.saveDiskLabel = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.instructionLabel = New System.Windows.Forms.Label()
        Me.saveLabel = New System.Windows.Forms.Label()
        Me.saveAsRevisionLabel = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cancelLabel = New System.Windows.Forms.Label()
        Me.doNotSaveLabel = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnSaveRevsion = New System.Windows.Forms.Button()
        Me.btnDoNotSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'projectNamePanel
        '
        Me.projectNamePanel.AutoSize = True
        Me.projectNamePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.projectNamePanel.Location = New System.Drawing.Point(0, 0)
        Me.projectNamePanel.Name = "projectNamePanel"
        Me.projectNamePanel.Size = New System.Drawing.Size(299, 0)
        Me.projectNamePanel.TabIndex = 14
        Me.projectNamePanel.Visible = False
        '
        'saveDiskLabel
        '
        Me.saveDiskLabel.BackColor = System.Drawing.Color.Transparent
        Me.saveDiskLabel.ImageIndex = 0
        Me.saveDiskLabel.ImageList = Me.ImageList1
        Me.saveDiskLabel.Location = New System.Drawing.Point(14, 8)
        Me.saveDiskLabel.Name = "saveDiskLabel"
        Me.saveDiskLabel.Size = New System.Drawing.Size(32, 32)
        Me.saveDiskLabel.TabIndex = 10
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "save.ico")
        '
        'instructionLabel
        '
        Me.instructionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.instructionLabel.BackColor = System.Drawing.Color.Transparent
        Me.instructionLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.instructionLabel.ForeColor = System.Drawing.Color.White
        Me.instructionLabel.Location = New System.Drawing.Point(55, 4)
        Me.instructionLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.instructionLabel.Name = "instructionLabel"
        Me.instructionLabel.Size = New System.Drawing.Size(237, 40)
        Me.instructionLabel.TabIndex = 8
        Me.instructionLabel.Text = "Select a saving option."
        Me.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'saveLabel
        '
        Me.saveLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveLabel.ForeColor = System.Drawing.Color.DimGray
        Me.saveLabel.Location = New System.Drawing.Point(57, 107)
        Me.saveLabel.Name = "saveLabel"
        Me.saveLabel.Size = New System.Drawing.Size(230, 23)
        Me.saveLabel.TabIndex = 15
        Me.saveLabel.Text = "Save changes and close form"
        Me.saveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'saveAsRevisionLabel
        '
        Me.saveAsRevisionLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveAsRevisionLabel.ForeColor = System.Drawing.Color.DimGray
        Me.saveAsRevisionLabel.Location = New System.Drawing.Point(57, 175)
        Me.saveAsRevisionLabel.Name = "saveAsRevisionLabel"
        Me.saveAsRevisionLabel.Size = New System.Drawing.Size(236, 23)
        Me.saveAsRevisionLabel.TabIndex = 16
        Me.saveAsRevisionLabel.Text = "Save to new revision and close form"
        Me.saveAsRevisionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList2.Images.SetKeyName(0, "NoAction.bmp")
        '
        'cancelLabel
        '
        Me.cancelLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelLabel.ForeColor = System.Drawing.Color.DimGray
        Me.cancelLabel.Location = New System.Drawing.Point(57, 311)
        Me.cancelLabel.Name = "cancelLabel"
        Me.cancelLabel.Size = New System.Drawing.Size(236, 23)
        Me.cancelLabel.TabIndex = 18
        Me.cancelLabel.Text = "Do not save and return to form"
        Me.cancelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'doNotSaveLabel
        '
        Me.doNotSaveLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.doNotSaveLabel.ForeColor = System.Drawing.Color.DimGray
        Me.doNotSaveLabel.Location = New System.Drawing.Point(57, 243)
        Me.doNotSaveLabel.Name = "doNotSaveLabel"
        Me.doNotSaveLabel.Size = New System.Drawing.Size(236, 23)
        Me.doNotSaveLabel.TabIndex = 19
        Me.doNotSaveLabel.Text = "Do not save and close form"
        Me.doNotSaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(39, 65)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(224, 39)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnSaveRevsion
        '
        Me.btnSaveRevsion.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveRevsion.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
        Me.btnSaveRevsion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveRevsion.Location = New System.Drawing.Point(39, 136)
        Me.btnSaveRevsion.Name = "btnSaveRevsion"
        Me.btnSaveRevsion.Size = New System.Drawing.Size(224, 39)
        Me.btnSaveRevsion.TabIndex = 21
        Me.btnSaveRevsion.Text = "Save as Revision"
        Me.btnSaveRevsion.UseVisualStyleBackColor = True
        '
        'btnDoNotSave
        '
        Me.btnDoNotSave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoNotSave.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.btnDoNotSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDoNotSave.Location = New System.Drawing.Point(39, 201)
        Me.btnDoNotSave.Name = "btnDoNotSave"
        Me.btnDoNotSave.Size = New System.Drawing.Size(224, 39)
        Me.btnDoNotSave.TabIndex = 22
        Me.btnDoNotSave.Text = "Do not Save"
        Me.btnDoNotSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(39, 271)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(224, 39)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(-1, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 51)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Select a saving option."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(-1, 347)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(301, 28)
        Me.Label2.TabIndex = 25
        '
        'SaveOnCloseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(299, 374)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDoNotSave)
        Me.Controls.Add(Me.btnSaveRevsion)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.doNotSaveLabel)
        Me.Controls.Add(Me.saveAsRevisionLabel)
        Me.Controls.Add(Me.saveLabel)
        Me.Controls.Add(Me.projectNamePanel)
        Me.Controls.Add(Me.cancelLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SaveOnCloseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAESolutions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents projectNamePanel As System.Windows.Forms.Panel
    ''Friend WithEvents topGradientPanel As RAE.UI.Controls.GradientPanel
    Friend WithEvents instructionLabel As System.Windows.Forms.Label
    ''Friend WithEvents bottomGradientPanel As RAE.UI.Controls.GradientPanel
    Friend WithEvents saveLabel As System.Windows.Forms.Label
   Friend WithEvents saveDiskLabel As System.Windows.Forms.Label
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents saveAsRevisionLabel As System.Windows.Forms.Label
   Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents cancelLabel As System.Windows.Forms.Label
    Friend WithEvents doNotSaveLabel As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSaveRevsion As System.Windows.Forms.Button
    Friend WithEvents btnDoNotSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
