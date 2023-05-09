<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactManagerControl
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
      Me.contactsGradientPanel = New Rae.Ui.Controls.GradientPanel
      Me.contactsFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.addContactToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.removeContactToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.contactsCollapsableHeader = New Rae.Ui.Controls.CollapsableHeader
      Me.contactsGradientPanel.SuspendLayout()
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'contactsGradientPanel
      '
      Me.contactsGradientPanel.BorderColor = System.Drawing.Color.Empty
      Me.contactsGradientPanel.BorderWidth = 0
      Me.contactsGradientPanel.Controls.Add(Me.contactsFlowLayoutPanel)
      Me.contactsGradientPanel.Controls.Add(Me.ToolStrip1)
      Me.contactsGradientPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.contactsGradientPanel.Flip = False
      Me.contactsGradientPanel.GradientAngle = 45
      Me.contactsGradientPanel.GradientEndColor = System.Drawing.Color.AliceBlue
      Me.contactsGradientPanel.GradientStartColor = System.Drawing.Color.White
      Me.contactsGradientPanel.HorizontalFillPercent = 100.0!
      Me.contactsGradientPanel.Location = New System.Drawing.Point(0, 30)
      Me.contactsGradientPanel.Name = "contactsGradientPanel"
      Me.contactsGradientPanel.Size = New System.Drawing.Size(553, 262)
      Me.contactsGradientPanel.TabIndex = 1
      Me.contactsGradientPanel.VerticalFillPercent = 100.0!
      '
      'contactsFlowLayoutPanel
      '
      Me.contactsFlowLayoutPanel.AutoScroll = True
      Me.contactsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.contactsFlowLayoutPanel.Location = New System.Drawing.Point(0, 25)
      Me.contactsFlowLayoutPanel.Name = "contactsFlowLayoutPanel"
      Me.contactsFlowLayoutPanel.Size = New System.Drawing.Size(553, 237)
      Me.contactsFlowLayoutPanel.TabIndex = 1
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.addContactToolStripButton, Me.removeContactToolStripButton})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(553, 25)
      Me.ToolStrip1.TabIndex = 0
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'addContactToolStripButton
      '
      Me.addContactToolStripButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.UserAdd
      Me.addContactToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.addContactToolStripButton.Name = "addContactToolStripButton"
      Me.addContactToolStripButton.Size = New System.Drawing.Size(113, 22)
      Me.addContactToolStripButton.Text = "Add Contact    "
      '
      'removeContactToolStripButton
      '
      Me.removeContactToolStripButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.UserDelete
      Me.removeContactToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.removeContactToolStripButton.Name = "removeContactToolStripButton"
      Me.removeContactToolStripButton.Size = New System.Drawing.Size(121, 22)
      Me.removeContactToolStripButton.Text = "Remove Contact"
      '
      'contactsCollapsableHeader
      '
      Me.contactsCollapsableHeader.BorderColor = System.Drawing.Color.Empty
      Me.contactsCollapsableHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.contactsCollapsableHeader.BorderWidth = 0
      Me.contactsCollapsableHeader.CollapsableControl = Me.contactsGradientPanel
      Me.contactsCollapsableHeader.Dock = System.Windows.Forms.DockStyle.Top
      Me.contactsCollapsableHeader.Flip = False
      Me.contactsCollapsableHeader.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
      Me.contactsCollapsableHeader.ForeColor = System.Drawing.Color.White
      Me.contactsCollapsableHeader.GradientAngle = 90
      Me.contactsCollapsableHeader.GradientEndColor = System.Drawing.Color.MidnightBlue
      Me.contactsCollapsableHeader.GradientStartColor = System.Drawing.Color.SteelBlue
      Me.contactsCollapsableHeader.HorizontalFillPercent = 100.0!
      Me.contactsCollapsableHeader.Location = New System.Drawing.Point(0, 0)
      Me.contactsCollapsableHeader.Name = "contactsCollapsableHeader"
      Me.contactsCollapsableHeader.ShouldCollapseContainer = True
      Me.contactsCollapsableHeader.Size = New System.Drawing.Size(553, 30)
      Me.contactsCollapsableHeader.TabIndex = 0
      Me.contactsCollapsableHeader.Text = "Contact Manager"
      Me.contactsCollapsableHeader.VerticalFillPercent = 100.0!
      '
      'ContactManagerControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.Controls.Add(Me.contactsGradientPanel)
      Me.Controls.Add(Me.contactsCollapsableHeader)
      Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.Name = "ContactManagerControl"
      Me.Size = New System.Drawing.Size(553, 292)
      Me.contactsGradientPanel.ResumeLayout(False)
      Me.contactsGradientPanel.PerformLayout()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents contactsCollapsableHeader As Rae.Ui.Controls.CollapsableHeader
   Friend WithEvents contactsGradientPanel As Rae.Ui.Controls.GradientPanel
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents addContactToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents removeContactToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents contactsFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel

End Class
