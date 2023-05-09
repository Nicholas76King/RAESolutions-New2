<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaveOldRevisionAsRevisionForm
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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveOldRevisionAsRevisionForm))
      Me.newErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        ''Me.GradientPanel1 = New Rae.UI.Controls.GradientPanel
        Me.saveButton = New System.Windows.Forms.Button
      Me.cancel2Button = New System.Windows.Forms.Button
      Me.instructionLabel = New System.Windows.Forms.Label
        ''Me.GradientPanel3 = New Rae.UI.Controls.GradientPanel
        Me.saveDiskLabel = New System.Windows.Forms.Label
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.extraInfoLabel = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.saveAsRevisionLabel = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        ''Me.GradientPanel1.SuspendLayout()
        ''Me.GradientPanel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'newErrorProvider
      '
      Me.newErrorProvider.ContainerControl = Me
      Me.newErrorProvider.Icon = CType(resources.GetObject("newErrorProvider.Icon"), System.Drawing.Icon)
        '''
        '''GradientPanel1
        '''
        ''Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        ''Me.GradientPanel1.Controls.Add(Me.saveButton)
        ''Me.GradientPanel1.Controls.Add(Me.cancel2Button)
        ''Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        ''Me.GradientPanel1.Flip = False
        ''Me.GradientPanel1.GradientAngle = 90
        ''Me.GradientPanel1.GradientEndColor = System.Drawing.Color.SteelBlue
        ''Me.GradientPanel1.GradientStartColor = System.Drawing.Color.LightSteelBlue
        ''Me.GradientPanel1.HorizontalFillPercent = 100.0!
        ''Me.GradientPanel1.Location = New System.Drawing.Point(0, 273)
        ''Me.GradientPanel1.Name = "GradientPanel1"
        ''Me.GradientPanel1.Size = New System.Drawing.Size(523, 50)
        ''Me.GradientPanel1.TabIndex = 7
        ''Me.GradientPanel1.VerticalFillPercent = 100.0!
        '
        'saveButton
        '
        Me.saveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.saveButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.saveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.saveButton.Location = New System.Drawing.Point(247, 12)
      Me.saveButton.Margin = New System.Windows.Forms.Padding(4)
      Me.saveButton.Name = "saveButton"
      Me.saveButton.Size = New System.Drawing.Size(125, 25)
      Me.saveButton.TabIndex = 5
      Me.saveButton.Text = "Save as Revision"
      Me.saveButton.UseVisualStyleBackColor = True
      '
      'cancel2Button
      '
      Me.cancel2Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cancel2Button.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cancel2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cancel2Button.Location = New System.Drawing.Point(380, 12)
      Me.cancel2Button.Margin = New System.Windows.Forms.Padding(4)
      Me.cancel2Button.Name = "cancel2Button"
      Me.cancel2Button.Size = New System.Drawing.Size(125, 25)
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
      Me.instructionLabel.Location = New System.Drawing.Point(58, 11)
      Me.instructionLabel.Margin = New System.Windows.Forms.Padding(4)
      Me.instructionLabel.Name = "instructionLabel"
      Me.instructionLabel.Size = New System.Drawing.Size(448, 49)
      Me.instructionLabel.TabIndex = 8
      Me.instructionLabel.Text = "Do you want to save changes as the latest revision?"
      Me.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '''
        '''GradientPanel3
        '''
        ''Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        ''Me.GradientPanel3.Controls.Add(Me.saveDiskLabel)
        ''Me.GradientPanel3.Controls.Add(Me.instructionLabel)
        ''Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        ''Me.GradientPanel3.Flip = True
        ''Me.GradientPanel3.GradientAngle = 90
        ''Me.GradientPanel3.GradientEndColor = System.Drawing.Color.SteelBlue
        ''Me.GradientPanel3.GradientStartColor = System.Drawing.Color.LightSteelBlue
        ''Me.GradientPanel3.HorizontalFillPercent = 100.0!
        ''Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        ''Me.GradientPanel3.Name = "GradientPanel3"
        ''Me.GradientPanel3.Size = New System.Drawing.Size(523, 68)
        ''Me.GradientPanel3.TabIndex = 10
        ''Me.GradientPanel3.VerticalFillPercent = 100.0!
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
      'extraInfoLabel
      '
      Me.extraInfoLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.extraInfoLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.extraInfoLabel.ForeColor = System.Drawing.Color.DimGray
      Me.extraInfoLabel.Location = New System.Drawing.Point(42, 221)
      Me.extraInfoLabel.Name = "extraInfoLabel"
      Me.extraInfoLabel.Size = New System.Drawing.Size(464, 49)
      Me.extraInfoLabel.TabIndex = 11
      Me.extraInfoLabel.Text = "You are attempting to save a revision that is not the latest revision. In order t" & _
          "o save previous revisions, you must save them as the latest revision. "
      '
      'Label1
      '
      Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.DimGray
      Me.Label1.Location = New System.Drawing.Point(90, 102)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(416, 68)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "The changes to this old revision will be saved as a new revision that will be the" & _
          " latest revision. The current latest revision will not be affected, but it will " & _
          "no longer be the latest revision."
      '
      'saveAsRevisionLabel
      '
      Me.saveAsRevisionLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.saveAsRevisionLabel.ForeColor = System.Drawing.Color.SteelBlue
      Me.saveAsRevisionLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.SaveAsRevision
      Me.saveAsRevisionLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.saveAsRevisionLabel.Location = New System.Drawing.Point(60, 81)
      Me.saveAsRevisionLabel.Name = "saveAsRevisionLabel"
      Me.saveAsRevisionLabel.Size = New System.Drawing.Size(196, 21)
      Me.saveAsRevisionLabel.TabIndex = 13
      Me.saveAsRevisionLabel.Text = "       Save as (latest) revision"
      Me.saveAsRevisionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
      Me.Label2.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
      Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Label2.Location = New System.Drawing.Point(60, 161)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(196, 21)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "       Don't save"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label3
      '
      Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.DimGray
      Me.Label3.Location = New System.Drawing.Point(90, 182)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(416, 36)
      Me.Label3.TabIndex = 15
      Me.Label3.Text = "The changes you made to this old revision will be deleted."
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
      Me.PictureBox1.Location = New System.Drawing.Point(18, 221)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox1.TabIndex = 17
      Me.PictureBox1.TabStop = False
      '
      'SaveOldRevisionAsRevisionForm
      '
      Me.AcceptButton = Me.saveButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.ClientSize = New System.Drawing.Size(523, 323)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.saveAsRevisionLabel)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.extraInfoLabel)
        ''Me.Controls.Add(Me.GradientPanel3)
        ''Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SaveOldRevisionAsRevisionForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "RAESolutions"
      CType(Me.newErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        ''Me.GradientPanel1.ResumeLayout(False)
        ''Me.GradientPanel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

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
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents saveAsRevisionLabel As System.Windows.Forms.Label
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
