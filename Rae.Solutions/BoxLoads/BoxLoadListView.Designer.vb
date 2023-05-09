<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BoxLoadListView
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
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxLoadListView))
Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
Me.optionsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
Me.nameMenu = New System.Windows.Forms.ToolStripMenuItem
Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
Me.newMenu = New System.Windows.Forms.ToolStripMenuItem
Me.openMenu = New System.Windows.Forms.ToolStripMenuItem
Me.duplicateMenu = New System.Windows.Forms.ToolStripMenuItem
Me.deleteMenu = New System.Windows.Forms.ToolStripMenuItem
Me.BoxLoadGrid = New Rae.RaeSolutions.Grid
Me.ItemIdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.LinkedColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.optionsMenu.SuspendLayout()
CType(Me.BoxLoadGrid, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ImageList1
'
Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
Me.ImageList1.Images.SetKeyName(0, "")
Me.ImageList1.Images.SetKeyName(1, "")
'
'optionsMenu
'
Me.optionsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.nameMenu, Me.ToolStripSeparator1, Me.newMenu, Me.openMenu, Me.duplicateMenu, Me.deleteMenu})
Me.optionsMenu.Name = "MNUiTEMoPTIONS"
Me.optionsMenu.Size = New System.Drawing.Size(142, 120)
Me.optionsMenu.Text = "Open..."
'
'nameMenu
'
Me.nameMenu.Enabled = False
Me.nameMenu.Name = "nameMenu"
Me.nameMenu.Size = New System.Drawing.Size(141, 22)
Me.nameMenu.Text = "Name"
'
'ToolStripSeparator1
'
Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
'
'newMenu
'
Me.newMenu.Image = Global.Rae.RaeSolutions.My.Resources.Resources.NewDocument
Me.newMenu.Name = "newMenu"
Me.newMenu.Size = New System.Drawing.Size(141, 22)
Me.newMenu.Text = "New..."
'
'openMenu
'
Me.openMenu.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
Me.openMenu.Name = "openMenu"
Me.openMenu.Size = New System.Drawing.Size(141, 22)
Me.openMenu.Text = "Open..."
'
'duplicateMenu
'
Me.duplicateMenu.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Copy
Me.duplicateMenu.Name = "duplicateMenu"
Me.duplicateMenu.Size = New System.Drawing.Size(141, 22)
Me.duplicateMenu.Text = "Duplicate..."
'
'deleteMenu
'
Me.deleteMenu.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
Me.deleteMenu.Name = "deleteMenu"
Me.deleteMenu.Size = New System.Drawing.Size(141, 22)
Me.deleteMenu.Text = "Delete..."
'
'BoxLoadGrid
'
Me.BoxLoadGrid.AllowUserToAddRows = False
Me.BoxLoadGrid.AllowUserToDeleteRows = False
Me.BoxLoadGrid.AllowUserToOrderColumns = True
Me.BoxLoadGrid.AllowUserToResizeColumns = False
Me.BoxLoadGrid.AllowUserToResizeRows = False
Me.BoxLoadGrid.BackgroundColor = System.Drawing.Color.White
Me.BoxLoadGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
Me.BoxLoadGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(254, Byte), Integer))
DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.BoxLoadGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.BoxLoadGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
Me.BoxLoadGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIdColumn, Me.NameColumn, Me.LinkedColumn})
DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(126, Byte), Integer))
DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.BoxLoadGrid.DefaultCellStyle = DataGridViewCellStyle2
Me.BoxLoadGrid.Dock = System.Windows.Forms.DockStyle.Fill
Me.BoxLoadGrid.EnableHeadersVisualStyles = False
Me.BoxLoadGrid.GridColor = System.Drawing.Color.DimGray
Me.BoxLoadGrid.Location = New System.Drawing.Point(0, 0)
Me.BoxLoadGrid.MultiSelect = False
Me.BoxLoadGrid.Name = "BoxLoadGrid"
Me.BoxLoadGrid.ReadOnly = True
DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.BoxLoadGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
Me.BoxLoadGrid.RowHeadersVisible = False
Me.BoxLoadGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.BoxLoadGrid.Size = New System.Drawing.Size(150, 150)
Me.BoxLoadGrid.TabIndex = 1
'
'ItemIdColumn
'
Me.ItemIdColumn.HeaderText = "ID"
Me.ItemIdColumn.Name = "ItemIdColumn"
Me.ItemIdColumn.ReadOnly = True
Me.ItemIdColumn.Visible = False
'
'NameColumn
'
Me.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
Me.NameColumn.HeaderText = "Name"
Me.NameColumn.Name = "NameColumn"
Me.NameColumn.ReadOnly = True
Me.NameColumn.ToolTipText = "Name of selection."
'
'LinkedColumn
'
Me.LinkedColumn.HeaderText = "Link"
Me.LinkedColumn.Name = "LinkedColumn"
Me.LinkedColumn.ReadOnly = True
Me.LinkedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
Me.LinkedColumn.Width = 28
'
'BoxLoadListView
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.Controls.Add(Me.BoxLoadGrid)
Me.Name = "BoxLoadListView"
Me.optionsMenu.ResumeLayout(False)
CType(Me.BoxLoadGrid, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
    Friend WithEvents BoxLoadGrid As Grid
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents optionsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents nameMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents newMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents openMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents deleteMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents duplicateMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemIdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkedColumn As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
