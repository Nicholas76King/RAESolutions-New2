<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PriceSheetForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PriceSheetForm))
        Me.transparentImageList = New System.Windows.Forms.ImageList(Me.components)
        ''Me.GradientPanel1 = New Rae.Ui.Controls.GradientPanel()
        Me.viewReportButton = New System.Windows.Forms.Button()
        Me.filterHeaderLabel = New System.Windows.Forms.Label()
        Me.filterCriteriaPanel = New System.Windows.Forms.Panel()
        Me.compressorRadioButton = New System.Windows.Forms.RadioButton()
        Me.modelRadioButton = New System.Windows.Forms.RadioButton()
        Me.seriesRadioButton = New System.Windows.Forms.RadioButton()
        Me.divisionRadioButton = New System.Windows.Forms.RadioButton()
        Me.divisionComboBox = New System.Windows.Forms.ComboBox()
        Me.seriesComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.filterInfoLabel = New System.Windows.Forms.Label()
        Me.viewInfoLabel = New System.Windows.Forms.Label()
        Me.viewPriceSheetBackgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.modelComboBox = New System.Windows.Forms.ComboBox()
        ''Me.GradientPanel1.SuspendLayout()
        Me.filterCriteriaPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'transparentImageList
        '
        Me.transparentImageList.ImageStream = CType(resources.GetObject("transparentImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.transparentImageList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.transparentImageList.Images.SetKeyName(0, "NoAction.bmp")
        '''
        '''GradientPanel1
        '''
        ''Me.GradientPanel1.BorderColor = System.Drawing.Color.Empty
        ''Me.GradientPanel1.BorderWidth = 0
        ''Me.GradientPanel1.Controls.Add(Me.viewReportButton)
        ''Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        ''Me.GradientPanel1.Flip = False
        ''Me.GradientPanel1.GradientAngle = 90
        ''Me.GradientPanel1.GradientEndColor = System.Drawing.Color.LightSteelBlue
        ''Me.GradientPanel1.GradientStartColor = System.Drawing.Color.White
        ''Me.GradientPanel1.HorizontalFillPercent = 100.0!
        ''Me.GradientPanel1.Location = New System.Drawing.Point(0, 253)
        ''Me.GradientPanel1.Name = "GradientPanel1"
        ''Me.GradientPanel1.Size = New System.Drawing.Size(399, 52)
        ''Me.GradientPanel1.TabIndex = 14
        ''Me.GradientPanel1.VerticalFillPercent = 100.0!
        '
        'viewReportButton
        '
        Me.viewReportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.viewReportButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Report
        Me.viewReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.viewReportButton.Location = New System.Drawing.Point(242, 14)
        Me.viewReportButton.Name = "viewReportButton"
        Me.viewReportButton.Size = New System.Drawing.Size(137, 26)
        Me.viewReportButton.TabIndex = 1
        Me.viewReportButton.Text = "       View Price Sheets "
        Me.viewReportButton.UseVisualStyleBackColor = True
        '
        'filterHeaderLabel
        '
        Me.filterHeaderLabel.AutoSize = True
        Me.filterHeaderLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.filterHeaderLabel.ForeColor = System.Drawing.Color.SteelBlue
        Me.filterHeaderLabel.Location = New System.Drawing.Point(16, 13)
        Me.filterHeaderLabel.Name = "filterHeaderLabel"
        Me.filterHeaderLabel.Size = New System.Drawing.Size(92, 16)
        Me.filterHeaderLabel.TabIndex = 22
        Me.filterHeaderLabel.Text = "Filter Criteria"
        '
        'filterCriteriaPanel
        '
        Me.filterCriteriaPanel.Controls.Add(Me.compressorRadioButton)
        Me.filterCriteriaPanel.Controls.Add(Me.modelRadioButton)
        Me.filterCriteriaPanel.Controls.Add(Me.seriesRadioButton)
        Me.filterCriteriaPanel.Controls.Add(Me.divisionRadioButton)
        Me.filterCriteriaPanel.Location = New System.Drawing.Point(34, 56)
        Me.filterCriteriaPanel.Name = "filterCriteriaPanel"
        Me.filterCriteriaPanel.Size = New System.Drawing.Size(152, 144)
        Me.filterCriteriaPanel.TabIndex = 24
        '
        'compressorRadioButton
        '
        Me.compressorRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.compressorRadioButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compressorRadioButton.Location = New System.Drawing.Point(8, 84)
        Me.compressorRadioButton.Name = "compressorRadioButton"
        Me.compressorRadioButton.Size = New System.Drawing.Size(144, 56)
        Me.compressorRadioButton.TabIndex = 3
        Me.compressorRadioButton.Text = "Compressor Warranties"
        Me.compressorRadioButton.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.compressorRadioButton.UseVisualStyleBackColor = True
        Me.compressorRadioButton.Visible = False
        '
        'modelRadioButton
        '
        Me.modelRadioButton.AutoSize = True
        Me.modelRadioButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modelRadioButton.Location = New System.Drawing.Point(8, 58)
        Me.modelRadioButton.Name = "modelRadioButton"
        Me.modelRadioButton.Size = New System.Drawing.Size(60, 20)
        Me.modelRadioButton.TabIndex = 2
        Me.modelRadioButton.Text = "Model"
        Me.modelRadioButton.UseVisualStyleBackColor = True
        '
        'seriesRadioButton
        '
        Me.seriesRadioButton.AutoSize = True
        Me.seriesRadioButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seriesRadioButton.Location = New System.Drawing.Point(8, 32)
        Me.seriesRadioButton.Name = "seriesRadioButton"
        Me.seriesRadioButton.Size = New System.Drawing.Size(62, 20)
        Me.seriesRadioButton.TabIndex = 1
        Me.seriesRadioButton.Text = "Series"
        Me.seriesRadioButton.UseVisualStyleBackColor = True
        '
        'divisionRadioButton
        '
        Me.divisionRadioButton.AutoSize = True
        Me.divisionRadioButton.Checked = True
        Me.divisionRadioButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.divisionRadioButton.Location = New System.Drawing.Point(8, 5)
        Me.divisionRadioButton.Name = "divisionRadioButton"
        Me.divisionRadioButton.Size = New System.Drawing.Size(69, 20)
        Me.divisionRadioButton.TabIndex = 0
        Me.divisionRadioButton.TabStop = True
        Me.divisionRadioButton.Text = "Division"
        Me.divisionRadioButton.UseVisualStyleBackColor = True
        '
        'divisionComboBox
        '
        Me.divisionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.divisionComboBox.FormattingEnabled = True
        Me.divisionComboBox.Location = New System.Drawing.Point(192, 60)
        Me.divisionComboBox.Name = "divisionComboBox"
        Me.divisionComboBox.Size = New System.Drawing.Size(183, 21)
        Me.divisionComboBox.TabIndex = 26
        '
        'seriesComboBox
        '
        Me.seriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.seriesComboBox.FormattingEnabled = True
        Me.seriesComboBox.Location = New System.Drawing.Point(192, 87)
        Me.seriesComboBox.Name = "seriesComboBox"
        Me.seriesComboBox.Size = New System.Drawing.Size(183, 21)
        Me.seriesComboBox.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(40, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(356, 27)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "The price sheets can then be saved or printed."
        '
        'filterInfoLabel
        '
        Me.filterInfoLabel.AutoSize = True
        Me.filterInfoLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.filterInfoLabel.ForeColor = System.Drawing.Color.DimGray
        Me.filterInfoLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.filterInfoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.filterInfoLabel.Location = New System.Drawing.Point(16, 35)
        Me.filterInfoLabel.Name = "filterInfoLabel"
        Me.filterInfoLabel.Size = New System.Drawing.Size(363, 16)
        Me.filterInfoLabel.TabIndex = 23
        Me.filterInfoLabel.Text = "      Choose criteria to filter equipment included in price sheet."
        '
        'viewInfoLabel
        '
        Me.viewInfoLabel.AutoSize = True
        Me.viewInfoLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewInfoLabel.ForeColor = System.Drawing.Color.DimGray
        Me.viewInfoLabel.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.viewInfoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.viewInfoLabel.Location = New System.Drawing.Point(16, 203)
        Me.viewInfoLabel.Name = "viewInfoLabel"
        Me.viewInfoLabel.Size = New System.Drawing.Size(359, 16)
        Me.viewInfoLabel.TabIndex = 25
        Me.viewInfoLabel.Text = "      Click 'View Price Sheets' to view the filtered price sheets."
        '
        'viewPriceSheetBackgroundWorker
        '
        Me.viewPriceSheetBackgroundWorker.WorkerReportsProgress = True
        '
        'modelComboBox
        '
        Me.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.modelComboBox.FormattingEnabled = True
        Me.modelComboBox.Location = New System.Drawing.Point(192, 114)
        Me.modelComboBox.Name = "modelComboBox"
        Me.modelComboBox.Size = New System.Drawing.Size(183, 21)
        Me.modelComboBox.TabIndex = 29
        Me.modelComboBox.Visible = False
        '
        'PriceSheetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(399, 305)
        Me.Controls.Add(Me.modelComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.seriesComboBox)
        Me.Controls.Add(Me.divisionComboBox)
        Me.Controls.Add(Me.filterHeaderLabel)
        Me.Controls.Add(Me.filterInfoLabel)
        Me.Controls.Add(Me.filterCriteriaPanel)
        Me.Controls.Add(Me.viewInfoLabel)
        ''Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PriceSheetForm"
        Me.Text = "Price Sheets"
        ''Me.GradientPanel1.ResumeLayout(False)
        Me.filterCriteriaPanel.ResumeLayout(False)
        Me.filterCriteriaPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents viewReportButton As System.Windows.Forms.Button
    Friend WithEvents transparentImageList As System.Windows.Forms.ImageList
    ''Friend WithEvents GradientPanel1 As RAE.UI.Controls.GradientPanel
    Friend WithEvents filterHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents filterInfoLabel As System.Windows.Forms.Label
    Friend WithEvents filterCriteriaPanel As System.Windows.Forms.Panel
    Friend WithEvents seriesRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents divisionRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents viewInfoLabel As System.Windows.Forms.Label
    Friend WithEvents divisionComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents seriesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents viewPriceSheetBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents modelRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents modelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents compressorRadioButton As System.Windows.Forms.RadioButton
End Class
