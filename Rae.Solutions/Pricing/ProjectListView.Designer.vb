<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectListView
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectListView))
        Me.grdProject = New System.Windows.Forms.DataGridView
        Me.ProjectName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CopyProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RenameProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem

        CType(Me.grdProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdProject
        '
        Me.grdProject.AllowUserToAddRows = False
        Me.grdProject.AllowUserToDeleteRows = False
        Me.grdProject.AllowUserToResizeColumns = False
        Me.grdProject.AllowUserToResizeRows = False
        Me.grdProject.BackgroundColor = System.Drawing.Color.White
        Me.grdProject.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.grdProject.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdProject.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdProject.ColumnHeadersHeight = 24
        Me.grdProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdProject.ColumnHeadersVisible = False
        Me.grdProject.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProjectName})
        Me.grdProject.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdProject.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdProject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProject.EnableHeadersVisualStyles = False
        Me.grdProject.GridColor = System.Drawing.Color.DimGray
        Me.grdProject.Location = New System.Drawing.Point(0, 0)
        Me.grdProject.MultiSelect = False
        Me.grdProject.Name = "grdProject"
        Me.grdProject.ReadOnly = True
        Me.grdProject.RowHeadersVisible = False
        Me.grdProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdProject.Size = New System.Drawing.Size(212, 50)
        Me.grdProject.TabIndex = 0
        '
        'ProjectName
        '
        Me.ProjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ProjectName.HeaderText = "Name"
        Me.ProjectName.Name = "ProjectName"
        Me.ProjectName.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.CopyProjectToolStripMenuItem, Me.DeleteProjectToolStripMenuItem, Me.RenameProjectToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 92)
        '
        'mnuOpen
        '
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(159, 22)
        Me.mnuOpen.Text = "Open"
        '
        'DeleteProjectToolStripMenuItem
        '
        Me.DeleteProjectToolStripMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.DeleteProjectToolStripMenuItem.Name = "DeleteProjectToolStripMenuItem"
        Me.DeleteProjectToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DeleteProjectToolStripMenuItem.Text = "Delete Project"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "OpenDocumentTransparentColor.bmp")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CopyProjectToolStripMenuItem
        '
        Me.CopyProjectToolStripMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Copy
        Me.CopyProjectToolStripMenuItem.Name = "CopyProjectToolStripMenuItem"
        Me.CopyProjectToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CopyProjectToolStripMenuItem.Text = "Copy Project..."
        '
        'RenameProjectToolStripMenuItem
        '
        Me.RenameProjectToolStripMenuItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Pencil
        Me.RenameProjectToolStripMenuItem.Name = "RenameProjectToolStripMenuItem"
        Me.RenameProjectToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.RenameProjectToolStripMenuItem.Text = "Rename Project"

        '
        'ProjectListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.grdProject)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ProjectListView"
        Me.Size = New System.Drawing.Size(212, 50)
        CType(Me.grdProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdProject As System.Windows.Forms.DataGridView
    Friend WithEvents ProjectName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeleteProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
