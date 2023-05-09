<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentListView
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentListView))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.mnuItemOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSeperator = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRename = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopyExistingItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.grdEquipment = New Rae.RaeSolutions.Grid()
        Me.IdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsIncludedColumn = New Rae.RaeSolutions.DataGridViewCheckColumn()
        Me.ValidationColumn = New Rae.RaeSolutions.DataGridViewValidationColumn()
        Me.ModelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckColumn1 = New Rae.RaeSolutions.DataGridViewCheckColumn()
        Me.DataGridViewValidationColumn1 = New Rae.RaeSolutions.DataGridViewValidationColumn()
        Me.mnuItemOptions.SuspendLayout()
        CType(Me.grdEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuItemOptions
        '
        Me.mnuItemOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuName, Me.mnuSeperator, Me.mnuNew, Me.mnuOpen, Me.mnuRename, Me.mnuDuplicate, Me.mnuDelete, Me.mnuCopyExistingItem})
        Me.mnuItemOptions.Name = "ContextMenuStrip1"
        Me.mnuItemOptions.Size = New System.Drawing.Size(195, 164)
        '
        'mnuName
        '
        Me.mnuName.Enabled = False
        Me.mnuName.Name = "mnuName"
        Me.mnuName.Size = New System.Drawing.Size(194, 22)
        Me.mnuName.Text = "Name: Big Green Giant"
        Me.mnuName.ToolTipText = "Name of selected equipment that menu options apply to."
        '
        'mnuSeperator
        '
        Me.mnuSeperator.Name = "mnuSeperator"
        Me.mnuSeperator.Size = New System.Drawing.Size(191, 6)
        '
        'mnuNew
        '
        Me.mnuNew.Image = Global.Rae.RaeSolutions.My.Resources.Resources.NewDocument
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(194, 22)
        Me.mnuNew.Text = "New..."
        '
        'mnuOpen
        '
        Me.mnuOpen.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Open
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(194, 22)
        Me.mnuOpen.Text = "Open"
        '
        'mnuRename
        '
        Me.mnuRename.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Rename
        Me.mnuRename.Name = "mnuRename"
        Me.mnuRename.Size = New System.Drawing.Size(194, 22)
        Me.mnuRename.Text = "Rename..."
        '
        'mnuDuplicate
        '
        Me.mnuDuplicate.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Copy
        Me.mnuDuplicate.Name = "mnuDuplicate"
        Me.mnuDuplicate.Size = New System.Drawing.Size(194, 22)
        Me.mnuDuplicate.Text = "Duplicate"
        Me.mnuDuplicate.Visible = False
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(194, 22)
        Me.mnuDelete.Text = "Delete"
        '
        'mnuCopyExistingItem
        '
        Me.mnuCopyExistingItem.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Copy
        Me.mnuCopyExistingItem.Name = "mnuCopyExistingItem"
        Me.mnuCopyExistingItem.Size = New System.Drawing.Size(194, 22)
        Me.mnuCopyExistingItem.Text = "Copy Existing Item..."
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Model"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'btnUp
        '
        Me.btnUp.BackColor = System.Drawing.Color.Transparent
        Me.btnUp.BackgroundImage = CType(resources.GetObject("btnUp.BackgroundImage"), System.Drawing.Image)
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUp.Font = New System.Drawing.Font("DejaVu Sans", 7.0!)
        Me.btnUp.ForeColor = System.Drawing.Color.Transparent
        Me.btnUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUp.Location = New System.Drawing.Point(169, 3)
        Me.btnUp.Margin = New System.Windows.Forms.Padding(0)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(15, 20)
        Me.btnUp.TabIndex = 35
        Me.btnUp.TabStop = False
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.btnDown.BackColor = System.Drawing.Color.Transparent
        Me.btnDown.BackgroundImage = CType(resources.GetObject("btnDown.BackgroundImage"), System.Drawing.Image)
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDown.Font = New System.Drawing.Font("DejaVu Sans", 7.0!)
        Me.btnDown.ForeColor = System.Drawing.Color.Transparent
        Me.btnDown.Location = New System.Drawing.Point(185, 3)
        Me.btnDown.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(15, 20)
        Me.btnDown.TabIndex = 36
        Me.btnDown.TabStop = False
        Me.btnDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'grdEquipment
        '
        Me.grdEquipment.AllowUserToAddRows = False
        Me.grdEquipment.AllowUserToDeleteRows = False
        Me.grdEquipment.AllowUserToResizeColumns = False
        Me.grdEquipment.AllowUserToResizeRows = False
        Me.grdEquipment.BackgroundColor = System.Drawing.Color.White
        Me.grdEquipment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.grdEquipment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdEquipment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdEquipment.ColumnHeadersHeight = 24
        Me.grdEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdColumn, Me.IsIncludedColumn, Me.ValidationColumn, Me.ModelColumn, Me.NameColumn})
        Me.grdEquipment.ContextMenuStrip = Me.mnuItemOptions
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(126, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdEquipment.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEquipment.EnableHeadersVisualStyles = False
        Me.grdEquipment.GridColor = System.Drawing.Color.DimGray
        Me.grdEquipment.Location = New System.Drawing.Point(0, 0)
        Me.grdEquipment.MultiSelect = False
        Me.grdEquipment.Name = "grdEquipment"
        Me.grdEquipment.RowHeadersVisible = False
        Me.grdEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdEquipment.Size = New System.Drawing.Size(264, 150)
        Me.grdEquipment.TabIndex = 0
        '
        'IdColumn
        '
        Me.IdColumn.HeaderText = "Id"
        Me.IdColumn.Name = "IdColumn"
        Me.IdColumn.Visible = False
        '
        'IsIncludedColumn
        '
        Me.IsIncludedColumn.HeaderText = ""
        Me.IsIncludedColumn.Name = "IsIncludedColumn"
        Me.IsIncludedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IsIncludedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IsIncludedColumn.ToolTipText = "Indicates whether equipment is included in project."
        Me.IsIncludedColumn.Width = 26
        '
        'ValidationColumn
        '
        Me.ValidationColumn.HeaderText = ""
        Me.ValidationColumn.Name = "ValidationColumn"
        Me.ValidationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ValidationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ValidationColumn.ToolTipText = "Indicates whether equipment data is valid."
        Me.ValidationColumn.Width = 26
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
        '
        'DataGridViewCheckColumn1
        '
        Me.DataGridViewCheckColumn1.HeaderText = ""
        Me.DataGridViewCheckColumn1.Name = "DataGridViewCheckColumn1"
        Me.DataGridViewCheckColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewCheckColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckColumn1.ToolTipText = "Indicates whether equipment is included in project."
        Me.DataGridViewCheckColumn1.Width = 26
        '
        'DataGridViewValidationColumn1
        '
        Me.DataGridViewValidationColumn1.HeaderText = ""
        Me.DataGridViewValidationColumn1.Name = "DataGridViewValidationColumn1"
        Me.DataGridViewValidationColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewValidationColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewValidationColumn1.ToolTipText = "Indicates whether equipment data is valid."
        Me.DataGridViewValidationColumn1.Width = 26
        '
        'EquipmentListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.grdEquipment)
        Me.Name = "EquipmentListView"
        Me.Size = New System.Drawing.Size(264, 150)
        Me.mnuItemOptions.ResumeLayout(False)
        CType(Me.grdEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
   Friend WithEvents grdEquipment As Grid
   Friend WithEvents DataGridViewCheckColumn1 As RAE.RAESolutions.DataGridViewCheckColumn
   Friend WithEvents DataGridViewValidationColumn1 As RAE.RAESolutions.DataGridViewValidationColumn
   Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents mnuItemOptions As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents mnuRename As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuDuplicate As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuName As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuSeperator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopyExistingItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsIncludedColumn As Rae.RaeSolutions.DataGridViewCheckColumn
    Friend WithEvents ValidationColumn As Rae.RaeSolutions.DataGridViewValidationColumn
    Friend WithEvents ModelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button

End Class
