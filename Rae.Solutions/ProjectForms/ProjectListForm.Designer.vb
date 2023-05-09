<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectListForm
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
        Me.projectName = New System.Windows.Forms.TextBox()
        Me.projectLabel = New System.Windows.Forms.Label()
        Me.search = New System.Windows.Forms.TextBox()
        Me.searchLabel = New System.Windows.Forms.Label()
        Me.instructions = New System.Windows.Forms.Label()
        Me.cancel = New System.Windows.Forms.Button()
        Me.ok = New System.Windows.Forms.Button()
        Me.filteredByUsername = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'projectName
        '
        Me.projectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.projectName.Location = New System.Drawing.Point(354, 407)
        Me.projectName.Name = "projectName"
        Me.projectName.ReadOnly = True
        Me.projectName.Size = New System.Drawing.Size(230, 26)
        Me.projectName.TabIndex = 12
        Me.projectName.TabStop = False
        '
        'projectLabel
        '
        Me.projectLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.projectLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.projectLabel.Location = New System.Drawing.Point(228, 407)
        Me.projectLabel.Name = "projectLabel"
        Me.projectLabel.Size = New System.Drawing.Size(120, 27)
        Me.projectLabel.TabIndex = 11
        Me.projectLabel.Text = "Selected project"
        Me.projectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'search
        '
        Me.search.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.search.Location = New System.Drawing.Point(70, 407)
        Me.search.Name = "search"
        Me.search.Size = New System.Drawing.Size(140, 26)
        Me.search.TabIndex = 13
        '
        'searchLabel
        '
        Me.searchLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.searchLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchLabel.Location = New System.Drawing.Point(5, 407)
        Me.searchLabel.Name = "searchLabel"
        Me.searchLabel.Size = New System.Drawing.Size(59, 27)
        Me.searchLabel.TabIndex = 14
        Me.searchLabel.Text = "Search"
        Me.searchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'instructions
        '
        Me.instructions.Location = New System.Drawing.Point(12, 9)
        Me.instructions.Name = "instructions"
        Me.instructions.Size = New System.Drawing.Size(336, 23)
        Me.instructions.TabIndex = 15
        Me.instructions.Text = "Select a project"
        Me.instructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cancel
        '
        Me.cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.Location = New System.Drawing.Point(509, 453)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(75, 30)
        Me.cancel.TabIndex = 16
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'ok
        '
        Me.ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ok.Location = New System.Drawing.Point(428, 453)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(75, 30)
        Me.ok.TabIndex = 17
        Me.ok.Text = "OK"
        Me.ok.UseVisualStyleBackColor = True
        '
        'filteredByUsername
        '
        Me.filteredByUsername.AutoSize = True
        Me.filteredByUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.filteredByUsername.Location = New System.Drawing.Point(408, 9)
        Me.filteredByUsername.Name = "filteredByUsername"
        Me.filteredByUsername.Size = New System.Drawing.Size(163, 20)
        Me.filteredByUsername.TabIndex = 18
        Me.filteredByUsername.Text = "Only Show My Projects"
        Me.filteredByUsername.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(568, 328)
        Me.DataGridView1.TabIndex = 19
        '
        'ProjectListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(599, 495)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.filteredByUsername)
        Me.Controls.Add(Me.ok)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.instructions)
        Me.Controls.Add(Me.search)
        Me.Controls.Add(Me.searchLabel)
        Me.Controls.Add(Me.projectName)
        Me.Controls.Add(Me.projectLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ProjectListForm"
        Me.Text = "Projects"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents projects As C1.Win.C1TrueDBGrid.C1TrueDBGrid

    Friend WithEvents projectName As System.Windows.Forms.TextBox
    Friend WithEvents projectLabel As System.Windows.Forms.Label
    Friend WithEvents search As System.Windows.Forms.TextBox
    Friend WithEvents searchLabel As System.Windows.Forms.Label
    Friend WithEvents instructions As System.Windows.Forms.Label
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents filteredByUsername As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As DataGridView
End Class
