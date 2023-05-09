<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreviewDrawingForm
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreviewDrawingForm))
Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
Me.openToolItem = New System.Windows.Forms.ToolStripButton
Me.saveToolItem = New System.Windows.Forms.ToolStripButton
Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
Me.printToolItem = New System.Windows.Forms.ToolStripButton
Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
Me.FileMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.OpenMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
Me.SaveMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
Me.PrintMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
Me.ExitMenuItem = New System.Windows.Forms.ToolStripMenuItem
Me.eViewer = New AxEModelView.AxEModelViewControl
Me.ToolStrip1.SuspendLayout()
Me.StatusStrip1.SuspendLayout()
Me.MenuStrip1.SuspendLayout()
CType(Me.eViewer, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'OpenFileDialog1
'
Me.OpenFileDialog1.FileName = "OpenFileDialog1"
'
'ToolStrip1
'
Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openToolItem, Me.saveToolItem, Me.ToolStripSeparator3, Me.printToolItem})
Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
Me.ToolStrip1.Name = "ToolStrip1"
Me.ToolStrip1.Size = New System.Drawing.Size(731, 25)
Me.ToolStrip1.TabIndex = 6
Me.ToolStrip1.Text = "ToolStrip1"
'
'openToolItem
'
Me.openToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.openToolItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
Me.openToolItem.ImageTransparentColor = System.Drawing.Color.Magenta
Me.openToolItem.Name = "openToolItem"
Me.openToolItem.Size = New System.Drawing.Size(23, 22)
Me.openToolItem.Text = "tsOpen"
Me.openToolItem.ToolTipText = "Open a drawing..."
'
'saveToolItem
'
Me.saveToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.saveToolItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
Me.saveToolItem.ImageTransparentColor = System.Drawing.Color.Magenta
Me.saveToolItem.Name = "saveToolItem"
Me.saveToolItem.Size = New System.Drawing.Size(23, 22)
Me.saveToolItem.Text = "tsSave"
Me.saveToolItem.ToolTipText = "Save drawing to file..."
'
'ToolStripSeparator3
'
Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
'
'printToolItem
'
Me.printToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.printToolItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
Me.printToolItem.ImageTransparentColor = System.Drawing.Color.Magenta
Me.printToolItem.Name = "printToolItem"
Me.printToolItem.Size = New System.Drawing.Size(23, 22)
Me.printToolItem.Text = "tsPrint"
Me.printToolItem.ToolTipText = "Print drawing..."
'
'StatusStrip1
'
Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
Me.StatusStrip1.Location = New System.Drawing.Point(0, 486)
Me.StatusStrip1.Name = "StatusStrip1"
Me.StatusStrip1.Size = New System.Drawing.Size(731, 22)
Me.StatusStrip1.TabIndex = 5
Me.StatusStrip1.Text = "StatusStrip1"
'
'ToolStripStatusLabel1
'
Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
'
'MenuStrip1
'
Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenuItem})
Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
Me.MenuStrip1.Name = "MenuStrip1"
Me.MenuStrip1.Size = New System.Drawing.Size(731, 24)
Me.MenuStrip1.TabIndex = 4
Me.MenuStrip1.Text = "MenuStrip1"
'
'FileMenuItem
'
Me.FileMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenMenuItem, Me.ToolStripSeparator4, Me.SaveMenuItem, Me.ToolStripSeparator2, Me.PrintMenuItem, Me.ToolStripSeparator1, Me.ExitMenuItem})
Me.FileMenuItem.Name = "FileMenuItem"
Me.FileMenuItem.Size = New System.Drawing.Size(35, 20)
Me.FileMenuItem.Text = "File"
'
'OpenMenuItem
'
Me.OpenMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
Me.OpenMenuItem.Name = "OpenMenuItem"
Me.OpenMenuItem.Size = New System.Drawing.Size(165, 22)
Me.OpenMenuItem.Text = "&Open Drawing..."
'
'ToolStripSeparator4
'
Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
Me.ToolStripSeparator4.Size = New System.Drawing.Size(162, 6)
'
'SaveMenuItem
'
Me.SaveMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Save
Me.SaveMenuItem.Name = "SaveMenuItem"
Me.SaveMenuItem.Size = New System.Drawing.Size(165, 22)
Me.SaveMenuItem.Text = "&Save..."
Me.SaveMenuItem.ToolTipText = "Save drawing to file..."
'
'ToolStripSeparator2
'
Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
Me.ToolStripSeparator2.Size = New System.Drawing.Size(162, 6)
'
'PrintMenuItem
'
Me.PrintMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Print
Me.PrintMenuItem.Name = "PrintMenuItem"
Me.PrintMenuItem.Size = New System.Drawing.Size(165, 22)
Me.PrintMenuItem.Text = "&Print..."
Me.PrintMenuItem.ToolTipText = "Print drawing..."
'
'ToolStripSeparator1
'
Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
Me.ToolStripSeparator1.Size = New System.Drawing.Size(162, 6)
'
'ExitMenuItem
'
Me.ExitMenuItem.Name = "ExitMenuItem"
Me.ExitMenuItem.Size = New System.Drawing.Size(165, 22)
Me.ExitMenuItem.Text = "E&xit"
Me.ExitMenuItem.ToolTipText = "Exit drawing preview."
'
'eViewer
'
Me.eViewer.Dock = System.Windows.Forms.DockStyle.Fill
Me.eViewer.Enabled = True
Me.eViewer.Location = New System.Drawing.Point(0, 49)
Me.eViewer.Name = "eViewer"
Me.eViewer.OcxState = CType(resources.GetObject("eViewer.OcxState"), System.Windows.Forms.AxHost.State)
Me.eViewer.Size = New System.Drawing.Size(731, 437)
Me.eViewer.TabIndex = 7
'
'PreviewDrawingForm
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(731, 508)
Me.Controls.Add(Me.eViewer)
Me.Controls.Add(Me.ToolStrip1)
Me.Controls.Add(Me.StatusStrip1)
Me.Controls.Add(Me.MenuStrip1)
Me.MinimizeBox = False
Me.Name = "PreviewDrawingForm"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "PreviewDrawingForm"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.ToolStrip1.ResumeLayout(False)
Me.ToolStrip1.PerformLayout()
Me.StatusStrip1.ResumeLayout(False)
Me.StatusStrip1.PerformLayout()
Me.MenuStrip1.ResumeLayout(False)
Me.MenuStrip1.PerformLayout()
CType(Me.eViewer, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents openToolItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents saveToolItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents printToolItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents FileMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents OpenMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SaveMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents PrintMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ExitMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents eViewer As AxEModelView.AxEModelViewControl
End Class
