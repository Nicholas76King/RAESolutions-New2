<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class catalog_form
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(catalog_form))
        ''Me.grid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btn_generate = New System.Windows.Forms.Button()
Me.generate_catalog_background_worker = New System.ComponentModel.BackgroundWorker()
Me.progress_bar = New System.Windows.Forms.ProgressBar()
Me.load_screen_background_worker = New System.ComponentModel.BackgroundWorker()
Me.lbl_status = New System.Windows.Forms.Label()
        ''CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '''
        '''grid
        '''
        ''Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
        ''            Or System.Windows.Forms.AnchorStyles.Left) _
        ''            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ''Me.grid.GroupByCaption = "Drag a column header here to group by that column"
        ''Me.grid.Images.Add(CType(resources.GetObject("grid.Images"), System.Drawing.Image))
        ''Me.grid.Location = New System.Drawing.Point(0, 66)
        ''Me.grid.Name = "grid"
        ''Me.grid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        ''Me.grid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        ''Me.grid.PreviewInfo.ZoomFactor = 75.0R
        ''Me.grid.PrintInfo.PageSettings = CType(resources.GetObject("grid.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        ''Me.grid.Size = New System.Drawing.Size(630, 429)
        ''Me.grid.TabIndex = 0
        ''Me.grid.Text = "C1TrueDBGrid1"
        ''Me.grid.PropBag = resources.GetString("grid.PropBag")
        '
        'btn_generate
        '
        Me.btn_generate.Location = New System.Drawing.Point(13, 28)
Me.btn_generate.Name = "btn_generate"
Me.btn_generate.Size = New System.Drawing.Size(123, 34)
Me.btn_generate.TabIndex = 1
Me.btn_generate.Text = "Generate Catalog"
Me.btn_generate.UseVisualStyleBackColor = True
'
'generate_catalog_background_worker
'
Me.generate_catalog_background_worker.WorkerReportsProgress = True
'
'progress_bar
'
Me.progress_bar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.progress_bar.Location = New System.Drawing.Point(143, 28)
Me.progress_bar.Name = "progress_bar"
Me.progress_bar.Size = New System.Drawing.Size(475, 34)
Me.progress_bar.TabIndex = 2
'
'load_screen_background_worker
'
'
'lbl_status
'
Me.lbl_status.AutoSize = True
Me.lbl_status.Location = New System.Drawing.Point(13, 9)
Me.lbl_status.Name = "lbl_status"
Me.lbl_status.Size = New System.Drawing.Size(0, 13)
Me.lbl_status.TabIndex = 3
'
'catalog_form
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(630, 495)
Me.Controls.Add(Me.lbl_status)
Me.Controls.Add(Me.progress_bar)
Me.Controls.Add(Me.btn_generate)
        ''Me.Controls.Add(Me.grid)
        Me.Name = "catalog_form"
Me.Text = "catalog_form"
        ''CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    ''Friend WithEvents grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btn_generate As System.Windows.Forms.Button
    Friend WithEvents generate_catalog_background_worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents progress_bar As System.Windows.Forms.ProgressBar
    Friend WithEvents load_screen_background_worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbl_status As System.Windows.Forms.Label
End Class
