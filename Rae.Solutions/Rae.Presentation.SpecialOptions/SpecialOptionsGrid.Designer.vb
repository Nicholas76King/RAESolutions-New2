Namespace SpecialOptions

   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class SpecialOptionsGrid
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
         Me.DataGridView1 = New System.Windows.Forms.DataGridView
         CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         'DataGridView1
         '
         Me.DataGridView1.AllowUserToOrderColumns = True
         Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
         Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
         Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
         Me.DataGridView1.Name = "DataGridView1"
         Me.DataGridView1.ReadOnly = True
         Me.DataGridView1.RowHeadersVisible = False
         Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
         Me.DataGridView1.Size = New System.Drawing.Size(258, 237)
         Me.DataGridView1.TabIndex = 0
         '
         'SpecialOptionsGrid
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackColor = System.Drawing.Color.White
         Me.Controls.Add(Me.DataGridView1)
         Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.Name = "SpecialOptionsGrid"
         Me.Size = New System.Drawing.Size(258, 237)
         CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub
      Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

   End Class

End Namespace