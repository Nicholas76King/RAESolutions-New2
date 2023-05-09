<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialOptionsControl
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
        Me.lblTotalPrice = New System.Windows.Forms.Label()
        Me.lblTotalPriceLabel = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.opGrid = New System.Windows.Forms.DataGridView()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        CType(Me.opGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTotalPrice
        '
        Me.lblTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPrice.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalPrice.Location = New System.Drawing.Point(296, 196)
        Me.lblTotalPrice.Name = "lblTotalPrice"
        Me.lblTotalPrice.Size = New System.Drawing.Size(67, 18)
        Me.lblTotalPrice.TabIndex = 3
        Me.lblTotalPrice.Text = "$0"
        Me.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalPriceLabel
        '
        Me.lblTotalPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPriceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPriceLabel.Location = New System.Drawing.Point(225, 193)
        Me.lblTotalPriceLabel.Name = "lblTotalPriceLabel"
        Me.lblTotalPriceLabel.Size = New System.Drawing.Size(142, 24)
        Me.lblTotalPriceLabel.TabIndex = 4
        Me.lblTotalPriceLabel.Text = "Total Price"
        Me.lblTotalPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Pencil
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(84, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 25)
        Me.btnEdit.TabIndex = 6
        Me.btnEdit.Text = "    Edit..."
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'opGrid
        '
        Me.opGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.opGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.opGrid.Location = New System.Drawing.Point(3, 29)
        Me.opGrid.Name = "opGrid"
        Me.opGrid.ReadOnly = True
        Me.opGrid.Size = New System.Drawing.Size(360, 165)
        Me.opGrid.TabIndex = 5
        Me.opGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        Me.opGrid.EnableHeadersVisualStyles = False
        Me.opGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
        Me.opGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.opGrid.MultiSelect = False
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Delete
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(165, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "    Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(3, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 25)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "     Add..."
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'SpecialOptionsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.opGrid)
        Me.Controls.Add(Me.lblTotalPrice)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblTotalPriceLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SpecialOptionsControl"
        Me.Size = New System.Drawing.Size(370, 218)
        CType(Me.opGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAdd As System.Windows.Forms.Button
   Friend WithEvents btnDelete As System.Windows.Forms.Button
   Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
   Friend WithEvents lblTotalPriceLabel As System.Windows.Forms.Label
    'Friend WithEvents opGrid As SpecialOptionGrid
    Friend WithEvents opGrid As DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button

End Class
