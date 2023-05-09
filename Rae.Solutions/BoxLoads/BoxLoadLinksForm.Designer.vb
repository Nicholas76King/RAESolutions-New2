<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BoxLoadLinksForm
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
Me.Label1 = New System.Windows.Forms.Label
Me.linksGrid = New System.Windows.Forms.DataGridView
Me.cancelButton1 = New System.Windows.Forms.Button
CType(Me.linksGrid, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(9, 9)
Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(193, 19)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Select the box load to link to"
'
'linksGrid
'
Me.linksGrid.AllowUserToAddRows = False
Me.linksGrid.AllowUserToDeleteRows = False
Me.linksGrid.AllowUserToOrderColumns = True
Me.linksGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.linksGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
Me.linksGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.linksGrid.Location = New System.Drawing.Point(12, 32)
Me.linksGrid.Name = "linksGrid"
Me.linksGrid.Size = New System.Drawing.Size(517, 136)
Me.linksGrid.TabIndex = 1
'
'cancelButton1
'
Me.cancelButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.cancelButton1.Location = New System.Drawing.Point(454, 177)
Me.cancelButton1.Name = "cancelButton1"
Me.cancelButton1.Size = New System.Drawing.Size(75, 29)
Me.cancelButton1.TabIndex = 2
Me.cancelButton1.Text = "Cancel"
Me.cancelButton1.UseVisualStyleBackColor = True
'
'BoxLoadLinksForm
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.BackColor = System.Drawing.Color.White
Me.ClientSize = New System.Drawing.Size(541, 215)
Me.ControlBox = False
Me.Controls.Add(Me.cancelButton1)
Me.Controls.Add(Me.linksGrid)
Me.Controls.Add(Me.Label1)
Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Margin = New System.Windows.Forms.Padding(4)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "BoxLoadLinksForm"
Me.ShowIcon = False
Me.Text = "Box Load Links"
CType(Me.linksGrid, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents linksGrid As System.Windows.Forms.DataGridView
    Friend WithEvents cancelButton1 As System.Windows.Forms.Button
End Class
