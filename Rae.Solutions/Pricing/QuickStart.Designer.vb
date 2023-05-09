<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickStart
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
Me.newProjectLabel = New System.Windows.Forms.Label()
Me.openProjectLabel = New System.Windows.Forms.Label()
Me.newEquipmentLabel = New System.Windows.Forms.Label()
Me.newSelectionLabel = New System.Windows.Forms.Label()
Me.linksPanel = New System.Windows.Forms.FlowLayoutPanel()
Me.newBoxLoadLabel = New System.Windows.Forms.Label()
Me.lbl_select_unit_cooler = New System.Windows.Forms.Label()
        'Me.quickStartHeader = New Rae.Ui.Controls.CollapsableHeader()
        Me.linksPanel.SuspendLayout()
Me.SuspendLayout()
'
'newProjectLabel
'
Me.newProjectLabel.AutoEllipsis = True
Me.newProjectLabel.Cursor = System.Windows.Forms.Cursors.Hand
Me.newProjectLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.newProjectLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.newProjectLabel.ForeColor = System.Drawing.Color.RoyalBlue
Me.newProjectLabel.Location = New System.Drawing.Point(3, 3)
Me.newProjectLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
Me.newProjectLabel.Name = "newProjectLabel"
Me.newProjectLabel.Size = New System.Drawing.Size(160, 21)
Me.newProjectLabel.TabIndex = 1
Me.newProjectLabel.Text = "Create New Project..."
Me.newProjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'openProjectLabel
'
Me.openProjectLabel.AutoEllipsis = True
Me.openProjectLabel.Cursor = System.Windows.Forms.Cursors.Hand
Me.openProjectLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.openProjectLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.openProjectLabel.ForeColor = System.Drawing.Color.RoyalBlue
Me.openProjectLabel.Location = New System.Drawing.Point(3, 27)
Me.openProjectLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
Me.openProjectLabel.Name = "openProjectLabel"
Me.openProjectLabel.Size = New System.Drawing.Size(160, 21)
Me.openProjectLabel.TabIndex = 2
Me.openProjectLabel.Text = "Open Existing Project..."
Me.openProjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'newEquipmentLabel
'
Me.newEquipmentLabel.AutoEllipsis = True
Me.newEquipmentLabel.Cursor = System.Windows.Forms.Cursors.Hand
Me.newEquipmentLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.newEquipmentLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.newEquipmentLabel.ForeColor = System.Drawing.Color.RoyalBlue
Me.newEquipmentLabel.Location = New System.Drawing.Point(3, 51)
Me.newEquipmentLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
Me.newEquipmentLabel.Name = "newEquipmentLabel"
Me.newEquipmentLabel.Size = New System.Drawing.Size(160, 21)
Me.newEquipmentLabel.TabIndex = 3
Me.newEquipmentLabel.Text = "Price Equipment..."
Me.newEquipmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'newSelectionLabel
'
Me.newSelectionLabel.AutoEllipsis = True
Me.newSelectionLabel.Cursor = System.Windows.Forms.Cursors.Hand
Me.newSelectionLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.newSelectionLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.newSelectionLabel.ForeColor = System.Drawing.Color.RoyalBlue
Me.newSelectionLabel.Location = New System.Drawing.Point(3, 75)
Me.newSelectionLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
Me.newSelectionLabel.Name = "newSelectionLabel"
Me.newSelectionLabel.Size = New System.Drawing.Size(160, 21)
Me.newSelectionLabel.TabIndex = 4
Me.newSelectionLabel.Text = "Select or Rate Equipment..."
Me.newSelectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'linksPanel
'
Me.linksPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.linksPanel.Controls.Add(Me.newProjectLabel)
Me.linksPanel.Controls.Add(Me.openProjectLabel)
Me.linksPanel.Controls.Add(Me.newEquipmentLabel)
Me.linksPanel.Controls.Add(Me.newSelectionLabel)
Me.linksPanel.Controls.Add(Me.newBoxLoadLabel)
Me.linksPanel.Controls.Add(Me.lbl_select_unit_cooler)
Me.linksPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.linksPanel.Location = New System.Drawing.Point(0, 30)
Me.linksPanel.Margin = New System.Windows.Forms.Padding(0)
Me.linksPanel.Name = "linksPanel"
Me.linksPanel.Size = New System.Drawing.Size(166, 149)
Me.linksPanel.TabIndex = 6
'
'newBoxLoadLabel
'
Me.newBoxLoadLabel.AutoEllipsis = True
Me.newBoxLoadLabel.Cursor = System.Windows.Forms.Cursors.Hand
Me.newBoxLoadLabel.Dock = System.Windows.Forms.DockStyle.Top
Me.newBoxLoadLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.newBoxLoadLabel.ForeColor = System.Drawing.Color.RoyalBlue
Me.newBoxLoadLabel.Location = New System.Drawing.Point(3, 99)
Me.newBoxLoadLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
Me.newBoxLoadLabel.Name = "newBoxLoadLabel"
Me.newBoxLoadLabel.Size = New System.Drawing.Size(160, 21)
Me.newBoxLoadLabel.TabIndex = 5
Me.newBoxLoadLabel.Text = "Calculate Box Load"
Me.newBoxLoadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'lbl_select_unit_cooler
'
Me.lbl_select_unit_cooler.AutoEllipsis = True
Me.lbl_select_unit_cooler.Cursor = System.Windows.Forms.Cursors.Hand
Me.lbl_select_unit_cooler.Dock = System.Windows.Forms.DockStyle.Top
Me.lbl_select_unit_cooler.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lbl_select_unit_cooler.ForeColor = System.Drawing.Color.RoyalBlue
Me.lbl_select_unit_cooler.Location = New System.Drawing.Point(3, 123)
Me.lbl_select_unit_cooler.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
Me.lbl_select_unit_cooler.Name = "lbl_select_unit_cooler"
Me.lbl_select_unit_cooler.Size = New System.Drawing.Size(160, 21)
Me.lbl_select_unit_cooler.TabIndex = 6
Me.lbl_select_unit_cooler.Text = "Select Unit Cooler (beta)"
Me.lbl_select_unit_cooler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'quickStartHeader
        '
        'Me.quickStartHeader.BorderColor = System.Drawing.Color.Empty
        'Me.quickStartHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.quickStartHeader.BorderWidth = 0
        'Me.quickStartHeader.CollapsableControl = Me.linksPanel
        'Me.quickStartHeader.Dock = System.Windows.Forms.DockStyle.Top
        'Me.quickStartHeader.Flip = False
        'Me.quickStartHeader.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        'Me.quickStartHeader.ForeColor = System.Drawing.Color.White
        'Me.quickStartHeader.GradientAngle = 90
        'Me.quickStartHeader.GradientEndColor = System.Drawing.Color.MidnightBlue
        'Me.quickStartHeader.GradientStartColor = System.Drawing.Color.SteelBlue
        'Me.quickStartHeader.HorizontalFillPercent = 100.0!
        'Me.quickStartHeader.Location = New System.Drawing.Point(0, 0)
        'Me.quickStartHeader.Margin = New System.Windows.Forms.Padding(0)
        'Me.quickStartHeader.Name = "quickStartHeader"
        'Me.quickStartHeader.ShouldCollapseContainer = True
        'Me.quickStartHeader.Size = New System.Drawing.Size(166, 30)
        'Me.quickStartHeader.TabIndex = 5
        'Me.quickStartHeader.Text = "Quick Start"
        'Me.quickStartHeader.VerticalFillPercent = 100.0!
        '
        'QuickStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
Me.BackColor = System.Drawing.Color.White
Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Controls.Add(Me.linksPanel)
        'Me.Controls.Add(Me.quickStartHeader)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Name = "QuickStart"
Me.Size = New System.Drawing.Size(166, 179)
Me.linksPanel.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
   Friend WithEvents newProjectLabel As System.Windows.Forms.Label
   Friend WithEvents openProjectLabel As System.Windows.Forms.Label
   Friend WithEvents newEquipmentLabel As System.Windows.Forms.Label
   Friend WithEvents newSelectionLabel As System.Windows.Forms.Label
    'Friend WithEvents quickStartHeader As RAE.UI.Controls.CollapsableHeader
    Friend WithEvents linksPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents newBoxLoadLabel As System.Windows.Forms.Label
    Friend WithEvents lbl_select_unit_cooler As System.Windows.Forms.Label

End Class
