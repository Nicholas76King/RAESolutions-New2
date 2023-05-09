<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemSelectionForm
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
Me.equipmentGrid = New System.Windows.Forms.DataGridView
Me.equipmentLabel = New System.Windows.Forms.Label
Me.cancelButton2 = New System.Windows.Forms.Button
Me.copyButton = New System.Windows.Forms.Button
Me.processesGrid = New System.Windows.Forms.DataGridView
Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.processesLabel = New System.Windows.Forms.Label
Me.boxLoadsLabel = New System.Windows.Forms.Label
Me.boxLoadsGrid = New System.Windows.Forms.DataGridView
Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.IdColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.shouldCopyColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
Me.ModelColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.NameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
CType(Me.equipmentGrid, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.processesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.boxLoadsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'equipmentGrid
'
Me.equipmentGrid.AllowUserToAddRows = False
Me.equipmentGrid.AllowUserToDeleteRows = False
Me.equipmentGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.equipmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.equipmentGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdColumn, Me.shouldCopyColumn, Me.ModelColumn, Me.NameColumn})
Me.equipmentGrid.Location = New System.Drawing.Point(12, 32)
Me.equipmentGrid.Name = "equipmentGrid"
Me.equipmentGrid.RowHeadersVisible = False
Me.equipmentGrid.Size = New System.Drawing.Size(446, 210)
Me.equipmentGrid.TabIndex = 0
'
'equipmentLabel
'
Me.equipmentLabel.AutoSize = True
Me.equipmentLabel.Location = New System.Drawing.Point(12, 9)
Me.equipmentLabel.Name = "equipmentLabel"
Me.equipmentLabel.Size = New System.Drawing.Size(197, 19)
Me.equipmentLabel.TabIndex = 1
Me.equipmentLabel.Text = "Select the equipment to copy"
'
'cancelButton2
'
Me.cancelButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.cancelButton2.Location = New System.Drawing.Point(383, 255)
Me.cancelButton2.Name = "cancelButton2"
Me.cancelButton2.Size = New System.Drawing.Size(75, 27)
Me.cancelButton2.TabIndex = 2
Me.cancelButton2.Text = "Cancel"
Me.cancelButton2.UseVisualStyleBackColor = True
'
'copyButton
'
Me.copyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.copyButton.Location = New System.Drawing.Point(302, 255)
Me.copyButton.Name = "copyButton"
Me.copyButton.Size = New System.Drawing.Size(75, 27)
Me.copyButton.TabIndex = 3
Me.copyButton.Text = "Copy"
Me.copyButton.UseVisualStyleBackColor = True
'
'processesGrid
'
Me.processesGrid.AllowUserToAddRows = False
Me.processesGrid.AllowUserToDeleteRows = False
Me.processesGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.processesGrid.BackgroundColor = System.Drawing.Color.Yellow
Me.processesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.processesGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
Me.processesGrid.Location = New System.Drawing.Point(12, 186)
Me.processesGrid.Name = "processesGrid"
Me.processesGrid.RowHeadersVisible = False
Me.processesGrid.Size = New System.Drawing.Size(446, 120)
Me.processesGrid.TabIndex = 4
Me.processesGrid.Visible = False
'
'DataGridViewTextBoxColumn1
'
Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
Me.DataGridViewTextBoxColumn1.Visible = False
'
'DataGridViewCheckBoxColumn1
'
Me.DataGridViewCheckBoxColumn1.HeaderText = "Copy"
Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
Me.DataGridViewCheckBoxColumn1.Width = 70
'
'DataGridViewTextBoxColumn2
'
Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
Me.DataGridViewTextBoxColumn2.ReadOnly = True
'
'DataGridViewTextBoxColumn3
'
Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
Me.DataGridViewTextBoxColumn3.HeaderText = "Model"
Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
Me.DataGridViewTextBoxColumn3.ReadOnly = True
Me.DataGridViewTextBoxColumn3.Width = 75
'
'processesLabel
'
Me.processesLabel.AutoSize = True
Me.processesLabel.BackColor = System.Drawing.Color.Yellow
Me.processesLabel.Location = New System.Drawing.Point(12, 164)
Me.processesLabel.Name = "processesLabel"
Me.processesLabel.Size = New System.Drawing.Size(193, 19)
Me.processesLabel.TabIndex = 5
Me.processesLabel.Text = "Select the processes to copy"
Me.processesLabel.Visible = False
'
'boxLoadsLabel
'
Me.boxLoadsLabel.AutoSize = True
Me.boxLoadsLabel.BackColor = System.Drawing.Color.Yellow
Me.boxLoadsLabel.Location = New System.Drawing.Point(12, 321)
Me.boxLoadsLabel.Name = "boxLoadsLabel"
Me.boxLoadsLabel.Size = New System.Drawing.Size(190, 19)
Me.boxLoadsLabel.TabIndex = 7
Me.boxLoadsLabel.Text = "Select the box loads to copy"
Me.boxLoadsLabel.Visible = False
'
'boxLoadsGrid
'
Me.boxLoadsGrid.AllowUserToAddRows = False
Me.boxLoadsGrid.AllowUserToDeleteRows = False
Me.boxLoadsGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.boxLoadsGrid.BackgroundColor = System.Drawing.Color.Yellow
Me.boxLoadsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.boxLoadsGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
Me.boxLoadsGrid.Location = New System.Drawing.Point(12, 343)
Me.boxLoadsGrid.Name = "boxLoadsGrid"
Me.boxLoadsGrid.RowHeadersVisible = False
Me.boxLoadsGrid.Size = New System.Drawing.Size(446, 120)
Me.boxLoadsGrid.TabIndex = 6
Me.boxLoadsGrid.Visible = False
'
'DataGridViewTextBoxColumn4
'
Me.DataGridViewTextBoxColumn4.HeaderText = "Id"
Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
Me.DataGridViewTextBoxColumn4.Visible = False
'
'DataGridViewCheckBoxColumn2
'
Me.DataGridViewCheckBoxColumn2.HeaderText = "Copy"
Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
Me.DataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
Me.DataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
Me.DataGridViewCheckBoxColumn2.Width = 70
'
'DataGridViewTextBoxColumn5
'
Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
Me.DataGridViewTextBoxColumn5.HeaderText = "Name"
Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
Me.DataGridViewTextBoxColumn5.ReadOnly = True
'
'DataGridViewTextBoxColumn6
'
Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
Me.DataGridViewTextBoxColumn6.HeaderText = "Description"
Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
Me.DataGridViewTextBoxColumn6.ReadOnly = True
Me.DataGridViewTextBoxColumn6.Width = 108
'
'IdColumn
'
Me.IdColumn.HeaderText = "Id"
Me.IdColumn.Name = "IdColumn"
Me.IdColumn.Visible = False
'
'shouldCopyColumn
'
Me.shouldCopyColumn.HeaderText = "Copy"
Me.shouldCopyColumn.Name = "shouldCopyColumn"
Me.shouldCopyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
Me.shouldCopyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
Me.shouldCopyColumn.Width = 70
'
'ModelColumn
'
Me.ModelColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
Me.ModelColumn.HeaderText = "Model"
Me.ModelColumn.Name = "ModelColumn"
Me.ModelColumn.ReadOnly = True
Me.ModelColumn.Width = 75
'
'NameColumn
'
Me.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
Me.NameColumn.HeaderText = "Name"
Me.NameColumn.Name = "NameColumn"
Me.NameColumn.ReadOnly = True
'
'ItemSelectionForm
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.White
Me.ClientSize = New System.Drawing.Size(470, 294)
Me.Controls.Add(Me.copyButton)
Me.Controls.Add(Me.cancelButton2)
Me.Controls.Add(Me.equipmentLabel)
Me.Controls.Add(Me.equipmentGrid)
Me.Controls.Add(Me.boxLoadsLabel)
Me.Controls.Add(Me.boxLoadsGrid)
Me.Controls.Add(Me.processesLabel)
Me.Controls.Add(Me.processesGrid)
Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "ItemSelectionForm"
Me.Text = "Item Selection"
CType(Me.equipmentGrid, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.processesGrid, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.boxLoadsGrid, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents equipmentGrid As System.Windows.Forms.DataGridView
    Friend WithEvents equipmentLabel As System.Windows.Forms.Label
    Friend WithEvents cancelButton2 As System.Windows.Forms.Button
    Friend WithEvents copyButton As System.Windows.Forms.Button
    Friend WithEvents processesGrid As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents processesLabel As System.Windows.Forms.Label
    Friend WithEvents boxLoadsLabel As System.Windows.Forms.Label
    Friend WithEvents boxLoadsGrid As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shouldCopyColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ModelColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
