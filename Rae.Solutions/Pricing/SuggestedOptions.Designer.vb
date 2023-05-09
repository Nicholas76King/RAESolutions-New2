<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuggestedOptionsForm
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
        Me.components = New System.ComponentModel.Container()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.btnInfo = New System.Windows.Forms.Button()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlSubText = New System.Windows.Forms.Panel()
        Me.lblSubText = New System.Windows.Forms.Label()
        Me.pnlSubText.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaption.BackColor = System.Drawing.Color.Transparent
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.White
        Me.lblCaption.Location = New System.Drawing.Point(2, 4)
        Me.lblCaption.Margin = New System.Windows.Forms.Padding(4)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(301, 56)
        Me.lblCaption.TabIndex = 8
        Me.lblCaption.Text = "Would you like an additional four years on your compressor warranty?"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnInfo
        '
        Me.btnInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInfo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInfo.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.btnInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInfo.Location = New System.Drawing.Point(219, 87)
        Me.btnInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInfo.Name = "btnInfo"
        Me.btnInfo.Size = New System.Drawing.Size(51, 25)
        Me.btnInfo.TabIndex = 7
        Me.btnInfo.Text = "Info"
        Me.btnInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnInfo, "More information on compressor warranty...")
        Me.btnInfo.UseVisualStyleBackColor = True
        '
        'btnYes
        '
        Me.btnYes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYes.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnYes.Location = New System.Drawing.Point(43, 87)
        Me.btnYes.Margin = New System.Windows.Forms.Padding(4)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(80, 25)
        Me.btnYes.TabIndex = 5
        Me.btnYes.Text = "Yes"
        Me.ToolTip1.SetToolTip(Me.btnYes, "Yes, I want to add an extended compressor warranty.")
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNo.Location = New System.Drawing.Point(131, 87)
        Me.btnNo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(80, 25)
        Me.btnNo.TabIndex = 6
        Me.btnNo.Text = "No"
        Me.ToolTip1.SetToolTip(Me.btnNo, "No, I do not want to add an extended compressor warranty.")
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'pnlSubText
        '
        Me.pnlSubText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSubText.Controls.Add(Me.btnInfo)
        Me.pnlSubText.Controls.Add(Me.btnNo)
        Me.pnlSubText.Controls.Add(Me.lblSubText)
        Me.pnlSubText.Controls.Add(Me.btnYes)
        Me.pnlSubText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSubText.Location = New System.Drawing.Point(0, 0)
        Me.pnlSubText.Name = "pnlSubText"
        Me.pnlSubText.Size = New System.Drawing.Size(304, 153)
        Me.pnlSubText.TabIndex = 16
        '
        'lblSubText
        '
        Me.lblSubText.BackColor = System.Drawing.Color.Transparent
        Me.lblSubText.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSubText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubText.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblSubText.Location = New System.Drawing.Point(0, 0)
        Me.lblSubText.Margin = New System.Windows.Forms.Padding(4)
        Me.lblSubText.Name = "lblSubText"
        Me.lblSubText.Size = New System.Drawing.Size(304, 37)
        Me.lblSubText.TabIndex = 16
        Me.lblSubText.Text = "This will make a total 5 year compressor warranty."
        Me.lblSubText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SuggestedOptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(304, 153)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlSubText)
        Me.Controls.Add(Me.lblCaption)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SuggestedOptionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RAE Solutions"
        Me.TransparencyKey = System.Drawing.Color.Crimson
        Me.pnlSubText.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    ''Friend WithEvents GradientPanel1 As Rae.Ui.Controls.GradientPanel
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents btnInfo As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlSubText As Panel
    Friend WithEvents lblSubText As Label
End Class
