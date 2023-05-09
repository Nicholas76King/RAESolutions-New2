<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessListView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcessListView))
        Me.processGrid = New System.Windows.Forms.DataGridView
        Me.mnuItemOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuName = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSeperator = New System.Windows.Forms.ToolStripSeparator
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRename = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDuplicate = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.processGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuItemOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'processGrid
        '
        Me.processGrid.AllowUserToAddRows = False
        Me.processGrid.AllowUserToDeleteRows = False
        Me.processGrid.AllowUserToOrderColumns = True
        Me.processGrid.AllowUserToResizeColumns = False
        Me.processGrid.AllowUserToResizeRows = False
        Me.processGrid.BackgroundColor = System.Drawing.Color.White
        Me.processGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.processGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.processGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.processGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.processGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDColumn, Me.ModelColumn, Me.NameColumn})
        Me.processGrid.ContextMenuStrip = Me.mnuItemOptions
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.processGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.processGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.processGrid.EnableHeadersVisualStyles = False
        Me.processGrid.GridColor = System.Drawing.Color.DimGray
        Me.processGrid.Location = New System.Drawing.Point(0, 0)
        Me.processGrid.MultiSelect = False
        Me.processGrid.Name = "processGrid"
        Me.processGrid.ReadOnly = True
        Me.processGrid.RowHeadersVisible = False
        Me.processGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.processGrid.Size = New System.Drawing.Size(193, 122)
        Me.processGrid.TabIndex = 0
        '
        'mnuItemOptions
        '
        Me.mnuItemOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuName, Me.mnuSeperator, Me.mnuNew, Me.mnuOpen, Me.mnuRename, Me.mnuDuplicate, Me.mnuDelete})
        Me.mnuItemOptions.Name = "ContextMenuStrip1"
        Me.mnuItemOptions.Size = New System.Drawing.Size(194, 142)
        '
        'mnuName
        '
        Me.mnuName.Enabled = False
        Me.mnuName.Name = "mnuName"
        Me.mnuName.Size = New System.Drawing.Size(193, 22)
        Me.mnuName.Text = "Name: Big Green Giant"
        Me.mnuName.ToolTipText = "Name of selected equipment that menu options apply to."
        '
        'mnuSeperator
        '
        Me.mnuSeperator.Name = "mnuSeperator"
        Me.mnuSeperator.Size = New System.Drawing.Size(190, 6)
        '
        'mnuNew
        '
        Me.mnuNew.Image = Global.Rae.RaeSolutions.My.Resources.Resources.NewDocument
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(193, 22)
        Me.mnuNew.Text = "New..."
        '
        'mnuOpen
        '
        Me.mnuOpen.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(193, 22)
        Me.mnuOpen.Text = "Open"
        '
        'mnuRename
        '
        Me.mnuRename.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Rename
        Me.mnuRename.Name = "mnuRename"
        Me.mnuRename.Size = New System.Drawing.Size(193, 22)
        Me.mnuRename.Text = "Rename..."
        '
        'mnuDuplicate
        '
        Me.mnuDuplicate.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Copy
        Me.mnuDuplicate.Name = "mnuDuplicate"
        Me.mnuDuplicate.Size = New System.Drawing.Size(193, 22)
        Me.mnuDuplicate.Text = "Duplicate"
        Me.mnuDuplicate.Visible = False
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(193, 22)
        Me.mnuDelete.Text = "Delete"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Model"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 59
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ToolTipText = "Name of selection."
        '
        'IDColumn
        '
        Me.IDColumn.HeaderText = "ID"
        Me.IDColumn.Name = "IDColumn"
        Me.IDColumn.ReadOnly = True
        Me.IDColumn.Visible = False
        '
        'ModelColumn
        '
        Me.ModelColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ModelColumn.HeaderText = "Model"
        Me.ModelColumn.Name = "ModelColumn"
        Me.ModelColumn.ReadOnly = True
        Me.ModelColumn.Width = 59
        '
        'NameColumn
        '
        Me.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NameColumn.HeaderText = "Name"
        Me.NameColumn.Name = "NameColumn"
        Me.NameColumn.ReadOnly = True
        Me.NameColumn.ToolTipText = "Name of selection."
        '
        'ProcessListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.processGrid)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ProcessListView"
        Me.Size = New System.Drawing.Size(193, 122)
        CType(Me.processGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuItemOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents processGrid As System.Windows.Forms.DataGridView
    Friend WithEvents IDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuItemOptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSeperator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDuplicate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
