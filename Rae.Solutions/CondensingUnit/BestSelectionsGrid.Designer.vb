<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BestSelectionsGrid
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BestSelectionsGrid))
        ''Me.grid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.footer = New System.Windows.Forms.Label
        Me.dataGridView = New System.Windows.Forms.DataGridView
        Me.note = New System.Windows.Forms.Label
        ''CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '''
        '''grid
        '''
        ''Me.grid.AllowUpdate = False
        ''Me.grid.CaptionHeight = 17
        ''Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        ''Me.grid.FetchRowStyles = True
        ''Me.grid.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.grid.Images.Add(CType(resources.GetObject("grid.Images"), System.Drawing.Image))
        ''Me.grid.Location = New System.Drawing.Point(0, 0)
        ''Me.grid.Name = "grid"
        ''Me.grid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.grid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.grid.PreviewInfo.ZoomFactor = 75
        ''Me.grid.PrintInfo.PageSettings = CType(resources.GetObject("grid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.grid.RowHeight = 15
        ''Me.grid.Size = New System.Drawing.Size(150, 120)
        ''Me.grid.TabIndex = 0
        ''Me.grid.Text = "C1TrueDBGrid1"
        ''Me.grid.PropBag = resources.GetString("grid.PropBag")
        '
        'footer
        '
        Me.footer.Dock = System.Windows.Forms.DockStyle.Bottom
Me.footer.Location = New System.Drawing.Point(0, 120)
Me.footer.Name = "footer"
Me.footer.Size = New System.Drawing.Size(150, 30)
Me.footer.TabIndex = 1
        Me.footer.Text = "footer"
        '
        'dataGridView
        '
        Me.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        ''Me.dataGridView.Images.Add(CType(resources.GetObject("grid.Images"), System.Drawing.Image))
        Me.dataGridView.Location = New System.Drawing.Point(0, 0)
        Me.dataGridView.Name = "dataGridView"
        Me.dataGridView.Size = New System.Drawing.Size(150, 120)
        Me.dataGridView.TabIndex = 0
        Me.dataGridView.Text = "dataGridView"

        '
        'note
        '
        Me.note.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.note.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(134, Byte), Integer))
Me.note.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.note.Location = New System.Drawing.Point(1, 1)
Me.note.Name = "note"
Me.note.Size = New System.Drawing.Size(148, 118)
Me.note.TabIndex = 2
Me.note.Text = "There are no condensing units matching the criteria."
Me.note.Visible = False
'
'BestSelectionsGrid
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.White
Me.Controls.Add(Me.note)
        Me.Controls.Add(Me.dataGridView)
        Me.Controls.Add(Me.footer)
Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Name = "BestSelectionsGrid"
        CType(Me.dataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    ''Friend WithEvents grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents footer As System.Windows.Forms.Label
    Friend WithEvents note As System.Windows.Forms.Label
    Friend WithEvents dataGridView As System.Windows.Forms.DataGridView



End Class
