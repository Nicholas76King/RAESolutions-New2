<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RevisionView
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
      Me.components = New System.ComponentModel.Container
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.tsFirstRev = New System.Windows.Forms.ToolStripButton
      Me.tsPrevRev = New System.Windows.Forms.ToolStripButton
      Me.tsNextRev = New System.Windows.Forms.ToolStripButton
      Me.tsLatestRev = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.tsSelectRevision = New System.Windows.Forms.ToolStripComboBox
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.tsWarning = New System.Windows.Forms.ToolStripLabel
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
      Me.RevisionViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuOpenRev = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuPrevRev = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuNextRev = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.mnuFirstRev = New System.Windows.Forms.ToolStripMenuItem
      Me.mnuLatestRev = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStrip1.SuspendLayout()
      Me.MenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.tsFirstRev, Me.tsPrevRev, Me.tsNextRev, Me.tsLatestRev, Me.ToolStripSeparator1, Me.tsSelectRevision, Me.ToolStripSeparator5, Me.tsWarning})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(700, 25)
      Me.ToolStrip1.TabIndex = 4
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'ToolStripLabel1
      '
      Me.ToolStripLabel1.Image = Global.Rae.RaeSolutions.My.Resources.Resources.PrintPreview
      Me.ToolStripLabel1.Name = "ToolStripLabel1"
      Me.ToolStripLabel1.Size = New System.Drawing.Size(98, 22)
      Me.ToolStripLabel1.Text = "Revision Viewer"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'tsFirstRev
      '
      Me.tsFirstRev.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tsFirstRev.Image = Global.Rae.RaeSolutions.My.Resources.Resources.First
      Me.tsFirstRev.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsFirstRev.Name = "tsFirstRev"
      Me.tsFirstRev.Size = New System.Drawing.Size(23, 22)
      Me.tsFirstRev.ToolTipText = "Click to view the first revision..."
      '
      'tsPrevRev
      '
      Me.tsPrevRev.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tsPrevRev.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Previous
      Me.tsPrevRev.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsPrevRev.Name = "tsPrevRev"
      Me.tsPrevRev.Size = New System.Drawing.Size(23, 22)
      Me.tsPrevRev.ToolTipText = "Click to view previous revision..."
      '
      'tsNextRev
      '
      Me.tsNextRev.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tsNextRev.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Next2
      Me.tsNextRev.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsNextRev.Name = "tsNextRev"
      Me.tsNextRev.Size = New System.Drawing.Size(23, 22)
      Me.tsNextRev.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
      Me.tsNextRev.ToolTipText = "Click to view next revision..."
      '
      'tsLatestRev
      '
      Me.tsLatestRev.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tsLatestRev.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Last
      Me.tsLatestRev.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsLatestRev.Name = "tsLatestRev"
      Me.tsLatestRev.Size = New System.Drawing.Size(23, 22)
      Me.tsLatestRev.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
      Me.tsLatestRev.ToolTipText = "Click to view the latest revision..."
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'tsSelectRevision
      '
      Me.tsSelectRevision.Name = "tsSelectRevision"
      Me.tsSelectRevision.Size = New System.Drawing.Size(165, 25)
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
      '
      'tsWarning
      '
      Me.tsWarning.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
      Me.tsWarning.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Warning
      Me.tsWarning.Name = "tsWarning"
      Me.tsWarning.Size = New System.Drawing.Size(271, 22)
      Me.tsWarning.Text = "Revision displayed is not the latest revision."
      Me.tsWarning.Visible = False
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RevisionViewToolStripMenuItem})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(326, 24)
      Me.MenuStrip1.TabIndex = 5
      Me.MenuStrip1.Text = "MenuStrip1"
      Me.MenuStrip1.Visible = False
      '
      'RevisionViewToolStripMenuItem
      '
      Me.RevisionViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenRev, Me.ToolStripSeparator3, Me.mnuPrevRev, Me.mnuNextRev, Me.ToolStripSeparator4, Me.mnuFirstRev, Me.mnuLatestRev})
      Me.RevisionViewToolStripMenuItem.Name = "RevisionViewToolStripMenuItem"
      Me.RevisionViewToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
      Me.RevisionViewToolStripMenuItem.Text = "Revision &View"
      '
      'mnuOpenRev
      '
      Me.mnuOpenRev.Enabled = False
      Me.mnuOpenRev.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
      Me.mnuOpenRev.Name = "mnuOpenRev"
      Me.mnuOpenRev.Size = New System.Drawing.Size(169, 22)
      Me.mnuOpenRev.Text = "Open Revision..."
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(166, 6)
      '
      'mnuPrevRev
      '
      Me.mnuPrevRev.Name = "mnuPrevRev"
      Me.mnuPrevRev.Size = New System.Drawing.Size(169, 22)
      Me.mnuPrevRev.Text = "Previous Revision"
      '
      'mnuNextRev
      '
      Me.mnuNextRev.Name = "mnuNextRev"
      Me.mnuNextRev.Size = New System.Drawing.Size(169, 22)
      Me.mnuNextRev.Text = "Next Revision"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(166, 6)
      '
      'mnuFirstRev
      '
      Me.mnuFirstRev.Name = "mnuFirstRev"
      Me.mnuFirstRev.Size = New System.Drawing.Size(169, 22)
      Me.mnuFirstRev.Text = "First Revision"
      '
      'mnuLatestRev
      '
      Me.mnuLatestRev.Name = "mnuLatestRev"
      Me.mnuLatestRev.Size = New System.Drawing.Size(169, 22)
      Me.mnuLatestRev.Text = "Latest Revision"
      '
      'RevisionView
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Transparent
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.MenuStrip1)
      Me.Name = "RevisionView"
      Me.Size = New System.Drawing.Size(700, 24)
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents tsPrevRev As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsNextRev As System.Windows.Forms.ToolStripButton
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents RevisionViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsSelectRevision As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuOpenRev As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuPrevRev As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuNextRev As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents mnuLatestRev As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuFirstRev As System.Windows.Forms.ToolStripMenuItem

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

   End Sub
   Friend WithEvents tsWarning As System.Windows.Forms.ToolStripLabel
   Friend WithEvents tsLatestRev As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsFirstRev As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator

End Class
