<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderEntry
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderEntry))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnCopyToClipboard = New System.Windows.Forms.Button()
        Me.txtUniqueKey = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCloudSave = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UltraDateTimeEditorColumn1 = New Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn(Me.components)
        Me.UltraDateTimeEditorColumn2 = New Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(755, 269)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btnCopyToClipboard)
        Me.TabPage1.Controls.Add(Me.txtUniqueKey)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnCloudSave)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(747, 243)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Save to Cloud"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnCopyToClipboard
        '
        Me.btnCopyToClipboard.Location = New System.Drawing.Point(331, 182)
        Me.btnCopyToClipboard.Name = "btnCopyToClipboard"
        Me.btnCopyToClipboard.Size = New System.Drawing.Size(110, 27)
        Me.btnCopyToClipboard.TabIndex = 13
        Me.btnCopyToClipboard.Text = "Copy to Clipboard"
        Me.btnCopyToClipboard.UseVisualStyleBackColor = True
        Me.btnCopyToClipboard.Visible = False
        '
        'txtUniqueKey
        '
        Me.txtUniqueKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUniqueKey.Location = New System.Drawing.Point(23, 182)
        Me.txtUniqueKey.Name = "txtUniqueKey"
        Me.txtUniqueKey.ReadOnly = True
        Me.txtUniqueKey.Size = New System.Drawing.Size(285, 26)
        Me.txtUniqueKey.TabIndex = 11
        Me.txtUniqueKey.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 17)
        Me.Label2.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 17)
        Me.Label1.TabIndex = 9
        '
        'btnCloudSave
        '
        Me.btnCloudSave.Location = New System.Drawing.Point(40, 48)
        Me.btnCloudSave.Name = "btnCloudSave"
        Me.btnCloudSave.Size = New System.Drawing.Size(243, 27)
        Me.btnCloudSave.TabIndex = 8
        Me.btnCloudSave.Text = "Save Project to Cloud"
        Me.btnCloudSave.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Part Number"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Part Description"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'UltraDateTimeEditorColumn1
        '
        Me.UltraDateTimeEditorColumn1.DefaultNewRowValue = CType(resources.GetObject("UltraDateTimeEditorColumn1.DefaultNewRowValue"), Object)
        Me.UltraDateTimeEditorColumn1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.UltraDateTimeEditorColumn1.DropDownCalendarAlignment = Infragistics.Win.DropDownListAlignment.Right
        Me.UltraDateTimeEditorColumn1.HeaderText = "Estimated Date of Receipt"
        Me.UltraDateTimeEditorColumn1.MaskInput = Nothing
        Me.UltraDateTimeEditorColumn1.Name = "UltraDateTimeEditorColumn1"
        Me.UltraDateTimeEditorColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.UltraDateTimeEditorColumn1.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None
        Me.UltraDateTimeEditorColumn1.Width = 115
        '
        'UltraDateTimeEditorColumn2
        '
        Me.UltraDateTimeEditorColumn2.DefaultNewRowValue = CType(resources.GetObject("UltraDateTimeEditorColumn2.DefaultNewRowValue"), Object)
        Me.UltraDateTimeEditorColumn2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.[Default]
        Me.UltraDateTimeEditorColumn2.DropDownCalendarAlignment = Infragistics.Win.DropDownListAlignment.Right
        Me.UltraDateTimeEditorColumn2.HeaderText = "Cut Sheet Arrival"
        Me.UltraDateTimeEditorColumn2.MaskInput = Nothing
        Me.UltraDateTimeEditorColumn2.Name = "UltraDateTimeEditorColumn2"
        Me.UltraDateTimeEditorColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.UltraDateTimeEditorColumn2.SpinButtonAlignment = Infragistics.Win.SpinButtonDisplayStyle.None
        Me.UltraDateTimeEditorColumn2.Width = 115
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(325, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(400, 62)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Once saved, other employees at your company will be able to import this project i" & _
            "nto their copy of RAE Solutions."
        '
        'OrderEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 293)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OrderEntry"
        Me.Text = "Cloud Save and Import"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UltraDateTimeEditorColumn1 As Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn
    Friend WithEvents UltraDateTimeEditorColumn2 As Infragistics.Win.UltraDataGridView.UltraDateTimeEditorColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnCopyToClipboard As System.Windows.Forms.Button
    Friend WithEvents txtUniqueKey As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCloudSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
