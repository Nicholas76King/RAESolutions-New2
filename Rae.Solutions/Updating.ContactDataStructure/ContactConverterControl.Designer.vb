<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactConverterControl
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContactConverterControl))
      Me.contactGrid = New System.Windows.Forms.DataGridView
      Me.IsConvertedColumn = New System.Windows.Forms.DataGridViewImageColumn
      Me.ContactNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CompanyNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.RoleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CreateColumn = New System.Windows.Forms.DataGridViewButtonColumn
      Me.OrColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.SelectColumn = New System.Windows.Forms.DataGridViewButtonColumn
      Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn
      Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn
      Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      CType(Me.contactGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'contactGrid
      '
      Me.contactGrid.AllowUserToAddRows = False
      Me.contactGrid.AllowUserToDeleteRows = False
      Me.contactGrid.AllowUserToResizeRows = False
      Me.contactGrid.BackgroundColor = System.Drawing.Color.White
      Me.contactGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.contactGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
      Me.contactGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(254, Byte), Integer))
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.contactGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.contactGrid.ColumnHeadersHeight = 24
      Me.contactGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IsConvertedColumn, Me.ContactNameColumn, Me.CompanyNameColumn, Me.RoleColumn, Me.CreateColumn, Me.OrColumn, Me.SelectColumn})
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.contactGrid.DefaultCellStyle = DataGridViewCellStyle3
      Me.contactGrid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.contactGrid.EnableHeadersVisualStyles = False
      Me.contactGrid.GridColor = System.Drawing.Color.Black
      Me.contactGrid.Location = New System.Drawing.Point(0, 0)
      Me.contactGrid.Name = "contactGrid"
      Me.contactGrid.ReadOnly = True
      Me.contactGrid.RowHeadersVisible = False
      Me.contactGrid.RowTemplate.Height = 24
      Me.contactGrid.Size = New System.Drawing.Size(653, 196)
      Me.contactGrid.TabIndex = 0
      '
      'IsConvertedColumn
      '
      Me.IsConvertedColumn.HeaderText = ""
      Me.IsConvertedColumn.Name = "IsConvertedColumn"
      Me.IsConvertedColumn.ReadOnly = True
      Me.IsConvertedColumn.Width = 22
      '
      'ContactNameColumn
      '
      Me.ContactNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.ContactNameColumn.HeaderText = "Contact Name"
      Me.ContactNameColumn.Name = "ContactNameColumn"
      Me.ContactNameColumn.ReadOnly = True
      '
      'CompanyNameColumn
      '
      Me.CompanyNameColumn.HeaderText = "Company Name"
      Me.CompanyNameColumn.Name = "CompanyNameColumn"
      Me.CompanyNameColumn.ReadOnly = True
      Me.CompanyNameColumn.Width = 170
      '
      'RoleColumn
      '
      Me.RoleColumn.HeaderText = "Role"
      Me.RoleColumn.Name = "RoleColumn"
      Me.RoleColumn.ReadOnly = True
      '
      'CreateColumn
      '
      Me.CreateColumn.HeaderText = ""
      Me.CreateColumn.Name = "CreateColumn"
      Me.CreateColumn.ReadOnly = True
      Me.CreateColumn.Width = 70
      '
      'OrColumn
      '
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.OrColumn.DefaultCellStyle = DataGridViewCellStyle2
      Me.OrColumn.HeaderText = ""
      Me.OrColumn.Name = "OrColumn"
      Me.OrColumn.ReadOnly = True
      Me.OrColumn.Width = 40
      '
      'SelectColumn
      '
      Me.SelectColumn.HeaderText = ""
      Me.SelectColumn.Name = "SelectColumn"
      Me.SelectColumn.ReadOnly = True
      Me.SelectColumn.Width = 70
      '
      'DataGridViewTextBoxColumn1
      '
      Me.DataGridViewTextBoxColumn1.HeaderText = "Contact Name"
      Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
      Me.DataGridViewTextBoxColumn1.ReadOnly = True
      Me.DataGridViewTextBoxColumn1.Width = 200
      '
      'DataGridViewTextBoxColumn2
      '
      Me.DataGridViewTextBoxColumn2.HeaderText = "Company Name"
      Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
      Me.DataGridViewTextBoxColumn2.ReadOnly = True
      Me.DataGridViewTextBoxColumn2.Width = 180
      '
      'DataGridViewTextBoxColumn3
      '
      Me.DataGridViewTextBoxColumn3.HeaderText = "Role"
      Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
      Me.DataGridViewTextBoxColumn3.ReadOnly = True
      Me.DataGridViewTextBoxColumn3.Width = 80
      '
      'DataGridViewButtonColumn1
      '
      Me.DataGridViewButtonColumn1.HeaderText = "Create"
      Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
      Me.DataGridViewButtonColumn1.ReadOnly = True
      Me.DataGridViewButtonColumn1.Width = 70
      '
      'DataGridViewButtonColumn2
      '
      Me.DataGridViewButtonColumn2.HeaderText = "Select Existing"
      Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
      Me.DataGridViewButtonColumn2.ReadOnly = True
      '
      'DataGridViewImageColumn1
      '
      Me.DataGridViewImageColumn1.HeaderText = "Converted"
      Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
      Me.DataGridViewImageColumn1.ReadOnly = True
      Me.DataGridViewImageColumn1.Width = 22
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
      Me.ImageList1.Images.SetKeyName(0, "OK.bmp")
      '
      'ContactConverterControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.White
      Me.Controls.Add(Me.contactGrid)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "ContactConverterControl"
      Me.Size = New System.Drawing.Size(653, 196)
      CType(Me.contactGrid, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents contactGrid As System.Windows.Forms.DataGridView
   Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
   Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents DataGridViewButtonColumn2 As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents IsConvertedColumn As System.Windows.Forms.DataGridViewImageColumn
   Friend WithEvents ContactNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CompanyNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents RoleColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CreateColumn As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents OrColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SelectColumn As System.Windows.Forms.DataGridViewButtonColumn
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
