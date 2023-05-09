<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class boc_catalog_window
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(boc_catalog_window))
Me.grid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
Me.btn_generate = New System.Windows.Forms.Button()
Me.cbo_series = New System.Windows.Forms.ComboBox()
CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'grid
'
Me.grid.AllowUpdate = False
Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grid.CaptionHeight = 17
Me.grid.GroupByCaption = "Drag a column header here to group by that column"
Me.grid.Images.Add(CType(resources.GetObject("grid.Images"), System.Drawing.Image))
Me.grid.Location = New System.Drawing.Point(0, 63)
Me.grid.Name = "grid"
Me.grid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
Me.grid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
Me.grid.PreviewInfo.ZoomFactor = 75.0R
Me.grid.PrintInfo.PageSettings = CType(resources.GetObject("grid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
Me.grid.RowHeight = 15
Me.grid.Size = New System.Drawing.Size(513, 199)
Me.grid.TabIndex = 0
Me.grid.Text = "C1TrueDBGrid1"
Me.grid.PropBag = resources.GetString("grid.PropBag")
'
'btn_generate
'
Me.btn_generate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btn_generate.Location = New System.Drawing.Point(360, 24)
Me.btn_generate.Name = "btn_generate"
Me.btn_generate.Size = New System.Drawing.Size(141, 33)
Me.btn_generate.TabIndex = 1
Me.btn_generate.Text = "Generate Catalog"
Me.btn_generate.UseVisualStyleBackColor = True
'
'cbo_series
'
Me.cbo_series.FormattingEnabled = True
Me.cbo_series.Items.AddRange(New Object() {"A", "BOC"})
Me.cbo_series.Location = New System.Drawing.Point(12, 24)
Me.cbo_series.Name = "cbo_series"
Me.cbo_series.Size = New System.Drawing.Size(121, 21)
Me.cbo_series.TabIndex = 2
Me.cbo_series.Text = "A"
'
'boc_catalog_window
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(513, 262)
Me.Controls.Add(Me.cbo_series)
Me.Controls.Add(Me.btn_generate)
Me.Controls.Add(Me.grid)
Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Name = "boc_catalog_window"
Me.Text = "BOC Catalog"
CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
    Friend WithEvents grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btn_generate As System.Windows.Forms.Button
    Friend WithEvents cbo_series As System.Windows.Forms.ComboBox
End Class
