<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EvaporatorGrid
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rbo6To8 = New System.Windows.Forms.RadioButton()
        Me.rbo7To9 = New System.Windows.Forms.RadioButton()
        Me.rbo8To10 = New System.Windows.Forms.RadioButton()
        Me.rbo9To11 = New System.Windows.Forms.RadioButton()
        Me.rbo10To12 = New System.Windows.Forms.RadioButton()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.rboCustom = New System.Windows.Forms.RadioButton()
        Me.lblCustomInstructions = New System.Windows.Forms.Label()
        Me.panCustom = New System.Windows.Forms.Panel()
        Me.lblEvaporatorUserCapacities = New System.Windows.Forms.Label()
        Me.lbl8DegreeApproach = New System.Windows.Forms.Label()
        Me.lblEvaporatorCircuit1 = New System.Windows.Forms.Label()
        Me.txtCustomCapacity2At10 = New System.Windows.Forms.TextBox()
        Me.txtCustomCapacity2At8 = New System.Windows.Forms.TextBox()
        Me.txtCustomCapacity1At10 = New System.Windows.Forms.TextBox()
        Me.lbl10DegreeApproach = New System.Windows.Forms.Label()
        Me.txtCustomCapacity1At8 = New System.Windows.Forms.TextBox()
        Me.lblEvaporatorCircuit2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.panCustom.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbo6To8
        '
        Me.rbo6To8.AutoSize = True
        Me.rbo6To8.Location = New System.Drawing.Point(5, 21)
        Me.rbo6To8.Name = "rbo6To8"
        Me.rbo6To8.Size = New System.Drawing.Size(53, 17)
        Me.rbo6To8.TabIndex = 1
        Me.rbo6To8.TabStop = True
        Me.rbo6To8.Text = "6 to 8"
        Me.rbo6To8.UseVisualStyleBackColor = True
        '
        'rbo7To9
        '
        Me.rbo7To9.AutoSize = True
        Me.rbo7To9.Location = New System.Drawing.Point(5, 43)
        Me.rbo7To9.Name = "rbo7To9"
        Me.rbo7To9.Size = New System.Drawing.Size(53, 17)
        Me.rbo7To9.TabIndex = 2
        Me.rbo7To9.TabStop = True
        Me.rbo7To9.Text = "7 to 9"
        Me.rbo7To9.UseVisualStyleBackColor = True
        '
        'rbo8To10
        '
        Me.rbo8To10.AutoSize = True
        Me.rbo8To10.Checked = True
        Me.rbo8To10.Location = New System.Drawing.Point(5, 66)
        Me.rbo8To10.Name = "rbo8To10"
        Me.rbo8To10.Size = New System.Drawing.Size(59, 17)
        Me.rbo8To10.TabIndex = 3
        Me.rbo8To10.TabStop = True
        Me.rbo8To10.Text = "8 to 10"
        Me.rbo8To10.UseVisualStyleBackColor = True
        '
        'rbo9To11
        '
        Me.rbo9To11.AutoSize = True
        Me.rbo9To11.Location = New System.Drawing.Point(5, 90)
        Me.rbo9To11.Name = "rbo9To11"
        Me.rbo9To11.Size = New System.Drawing.Size(59, 17)
        Me.rbo9To11.TabIndex = 3
        Me.rbo9To11.TabStop = True
        Me.rbo9To11.Text = "9 to 11"
        Me.rbo9To11.UseVisualStyleBackColor = True
        '
        'rbo10To12
        '
        Me.rbo10To12.AutoSize = True
        Me.rbo10To12.Location = New System.Drawing.Point(5, 112)
        Me.rbo10To12.Name = "rbo10To12"
        Me.rbo10To12.Size = New System.Drawing.Size(65, 17)
        Me.rbo10To12.TabIndex = 4
        Me.rbo10To12.TabStop = True
        Me.rbo10To12.Text = "10 to 12"
        Me.rbo10To12.UseVisualStyleBackColor = True
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.ForeColor = System.Drawing.Color.DimGray
        Me.lblInstructions.Location = New System.Drawing.Point(1, 1)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(90, 13)
        Me.lblInstructions.TabIndex = 5
        Me.lblInstructions.Text = "- select approach"
        '
        'rboCustom
        '
        Me.rboCustom.AutoSize = True
        Me.rboCustom.Location = New System.Drawing.Point(5, 308)
        Me.rboCustom.Name = "rboCustom"
        Me.rboCustom.Size = New System.Drawing.Size(118, 17)
        Me.rboCustom.TabIndex = 6
        Me.rboCustom.TabStop = True
        Me.rboCustom.Text = "Custom evaporator"
        Me.rboCustom.UseVisualStyleBackColor = True
        '
        'lblCustomInstructions
        '
        Me.lblCustomInstructions.AutoSize = True
        Me.lblCustomInstructions.ForeColor = System.Drawing.Color.DimGray
        Me.lblCustomInstructions.Location = New System.Drawing.Point(1, 289)
        Me.lblCustomInstructions.Name = "lblCustomInstructions"
        Me.lblCustomInstructions.Size = New System.Drawing.Size(249, 13)
        Me.lblCustomInstructions.TabIndex = 7
        Me.lblCustomInstructions.Text = "- or select custom evaporator and enter capacities"
        '
        'panCustom
        '
        Me.panCustom.Controls.Add(Me.lblEvaporatorUserCapacities)
        Me.panCustom.Controls.Add(Me.lbl8DegreeApproach)
        Me.panCustom.Controls.Add(Me.lblEvaporatorCircuit1)
        Me.panCustom.Controls.Add(Me.txtCustomCapacity2At10)
        Me.panCustom.Controls.Add(Me.txtCustomCapacity2At8)
        Me.panCustom.Controls.Add(Me.txtCustomCapacity1At10)
        Me.panCustom.Controls.Add(Me.lbl10DegreeApproach)
        Me.panCustom.Controls.Add(Me.txtCustomCapacity1At8)
        Me.panCustom.Controls.Add(Me.lblEvaporatorCircuit2)
        Me.panCustom.Location = New System.Drawing.Point(0, 331)
        Me.panCustom.Name = "panCustom"
        Me.panCustom.Size = New System.Drawing.Size(467, 88)
        Me.panCustom.TabIndex = 8
        Me.panCustom.Visible = False
        '
        'lblEvaporatorUserCapacities
        '
        Me.lblEvaporatorUserCapacities.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporatorUserCapacities.Location = New System.Drawing.Point(154, 3)
        Me.lblEvaporatorUserCapacities.Name = "lblEvaporatorUserCapacities"
        Me.lblEvaporatorUserCapacities.Size = New System.Drawing.Size(112, 19)
        Me.lblEvaporatorUserCapacities.TabIndex = 23
        Me.lblEvaporatorUserCapacities.Text = "Capacities (BTUH)"
        '
        'lbl8DegreeApproach
        '
        Me.lbl8DegreeApproach.Location = New System.Drawing.Point(4, 39)
        Me.lbl8DegreeApproach.Name = "lbl8DegreeApproach"
        Me.lbl8DegreeApproach.Size = New System.Drawing.Size(110, 23)
        Me.lbl8DegreeApproach.TabIndex = 16
        Me.lbl8DegreeApproach.Text = "8 Degree Approach"
        Me.lbl8DegreeApproach.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEvaporatorCircuit1
        '
        Me.lblEvaporatorCircuit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporatorCircuit1.Location = New System.Drawing.Point(120, 15)
        Me.lblEvaporatorCircuit1.Name = "lblEvaporatorCircuit1"
        Me.lblEvaporatorCircuit1.Size = New System.Drawing.Size(84, 19)
        Me.lblEvaporatorCircuit1.TabIndex = 18
        Me.lblEvaporatorCircuit1.Text = "Circuit 1"
        Me.lblEvaporatorCircuit1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtCustomCapacity2At10
        '
        Me.txtCustomCapacity2At10.Location = New System.Drawing.Point(204, 63)
        Me.txtCustomCapacity2At10.Name = "txtCustomCapacity2At10"
        Me.txtCustomCapacity2At10.Size = New System.Drawing.Size(72, 21)
        Me.txtCustomCapacity2At10.TabIndex = 22
        Me.txtCustomCapacity2At10.Text = "0"
        Me.txtCustomCapacity2At10.Visible = False
        '
        'txtCustomCapacity2At8
        '
        Me.txtCustomCapacity2At8.Location = New System.Drawing.Point(204, 39)
        Me.txtCustomCapacity2At8.Name = "txtCustomCapacity2At8"
        Me.txtCustomCapacity2At8.Size = New System.Drawing.Size(72, 21)
        Me.txtCustomCapacity2At8.TabIndex = 21
        Me.txtCustomCapacity2At8.Text = "0"
        Me.txtCustomCapacity2At8.Visible = False
        '
        'txtCustomCapacity1At10
        '
        Me.txtCustomCapacity1At10.Location = New System.Drawing.Point(120, 63)
        Me.txtCustomCapacity1At10.Name = "txtCustomCapacity1At10"
        Me.txtCustomCapacity1At10.Size = New System.Drawing.Size(72, 21)
        Me.txtCustomCapacity1At10.TabIndex = 19
        Me.txtCustomCapacity1At10.Text = "0"
        '
        'lbl10DegreeApproach
        '
        Me.lbl10DegreeApproach.Location = New System.Drawing.Point(4, 63)
        Me.lbl10DegreeApproach.Name = "lbl10DegreeApproach"
        Me.lbl10DegreeApproach.Size = New System.Drawing.Size(110, 23)
        Me.lbl10DegreeApproach.TabIndex = 24
        Me.lbl10DegreeApproach.Text = "10 Degree Approach"
        Me.lbl10DegreeApproach.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCustomCapacity1At8
        '
        Me.txtCustomCapacity1At8.Location = New System.Drawing.Point(120, 39)
        Me.txtCustomCapacity1At8.Name = "txtCustomCapacity1At8"
        Me.txtCustomCapacity1At8.Size = New System.Drawing.Size(72, 21)
        Me.txtCustomCapacity1At8.TabIndex = 17
        Me.txtCustomCapacity1At8.Text = "0"
        '
        'lblEvaporatorCircuit2
        '
        Me.lblEvaporatorCircuit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporatorCircuit2.Location = New System.Drawing.Point(204, 11)
        Me.lblEvaporatorCircuit2.Name = "lblEvaporatorCircuit2"
        Me.lblEvaporatorCircuit2.Size = New System.Drawing.Size(100, 23)
        Me.lblEvaporatorCircuit2.TabIndex = 20
        Me.lblEvaporatorCircuit2.Text = "Circuit 2"
        Me.lblEvaporatorCircuit2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(120, 21)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(693, 252)
        Me.DataGridView1.TabIndex = 9
        Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.MultiSelect = False
        '
        'EvaporatorGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.panCustom)
        Me.Controls.Add(Me.lblCustomInstructions)
        Me.Controls.Add(Me.rboCustom)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.rbo10To12)
        Me.Controls.Add(Me.rbo9To11)
        Me.Controls.Add(Me.rbo8To10)
        Me.Controls.Add(Me.rbo7To9)
        Me.Controls.Add(Me.rbo6To8)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "EvaporatorGrid"
        Me.Size = New System.Drawing.Size(834, 328)
        Me.panCustom.ResumeLayout(False)
        Me.panCustom.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    ''Friend WithEvents grid As C1.Win.C1TrueDBGrid.Grid
    Friend WithEvents rbo6To8 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo7To9 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo8To10 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo9To11 As System.Windows.Forms.RadioButton
    Friend WithEvents rbo10To12 As System.Windows.Forms.RadioButton
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents rboCustom As System.Windows.Forms.RadioButton
    Friend WithEvents lblCustomInstructions As System.Windows.Forms.Label
    Friend WithEvents panCustom As System.Windows.Forms.Panel
    Friend WithEvents lblEvaporatorUserCapacities As System.Windows.Forms.Label
    Friend WithEvents lbl8DegreeApproach As System.Windows.Forms.Label
    Friend WithEvents lblEvaporatorCircuit1 As System.Windows.Forms.Label
    Friend WithEvents txtCustomCapacity2At10 As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomCapacity2At8 As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomCapacity1At10 As System.Windows.Forms.TextBox
    Friend WithEvents lbl10DegreeApproach As System.Windows.Forms.Label
    Friend WithEvents txtCustomCapacity1At8 As System.Windows.Forms.TextBox
    Friend WithEvents lblEvaporatorCircuit2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
