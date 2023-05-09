<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class unit_cooler_selection_screen
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
        Me.lbl_total_capacity = New System.Windows.Forms.Label()
        Me.lbl_room_temperature = New System.Windows.Forms.Label()
        Me.lbl_design_td = New System.Windows.Forms.Label()
        Me.lbl_refrigerant = New System.Windows.Forms.Label()
        Me.cbo_refrigerant = New System.Windows.Forms.ComboBox()
        Me.cbo_series = New System.Windows.Forms.ComboBox()
        Me.lbl_series = New System.Windows.Forms.Label()
        Me.lbl_total_capacity_btuh = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_fan_quantity = New System.Windows.Forms.Label()
        Me.cbo_fan_quantity = New System.Windows.Forms.ComboBox()
        Me.lbl_static_pressure = New System.Windows.Forms.Label()
        Me.cbo_static_pressure = New System.Windows.Forms.ComboBox()
        Me.cbo_defrost_type = New System.Windows.Forms.ComboBox()
        Me.lbl_defrost_type = New System.Windows.Forms.Label()
        Me.lbl_unit_cooler_quantity = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_suction_temperature_value = New System.Windows.Forms.Label()
        Me.lbl_suction_temperature = New System.Windows.Forms.Label()
        Me.btn_find_unit_coolers = New System.Windows.Forms.Button()
        Me.grd_unit_coolers = New System.Windows.Forms.DataGridView()
        Me.lbl_dimensions_note = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ddlDOEModels = New System.Windows.Forms.ComboBox()
        Me.txt_unit_cooler_quantity = New Rae.RaeSolutions.text_number()
        Me.txt_total_capacity = New Rae.RaeSolutions.text_number()
        Me.txt_td = New Rae.RaeSolutions.text_number()
        Me.txt_room_temperature = New Rae.RaeSolutions.text_number()
        Me.Panel1.SuspendLayout()
        CType(Me.grd_unit_coolers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_total_capacity
        '
        Me.lbl_total_capacity.AutoSize = True
        Me.lbl_total_capacity.Location = New System.Drawing.Point(17, 20)
        Me.lbl_total_capacity.Name = "lbl_total_capacity"
        Me.lbl_total_capacity.Size = New System.Drawing.Size(89, 16)
        Me.lbl_total_capacity.TabIndex = 0
        Me.lbl_total_capacity.Text = "Total Capacity"
        '
        'lbl_room_temperature
        '
        Me.lbl_room_temperature.AutoSize = True
        Me.lbl_room_temperature.Location = New System.Drawing.Point(329, 20)
        Me.lbl_room_temperature.Name = "lbl_room_temperature"
        Me.lbl_room_temperature.Size = New System.Drawing.Size(162, 16)
        Me.lbl_room_temperature.TabIndex = 2
        Me.lbl_room_temperature.Text = "Design Room Temperature"
        '
        'lbl_design_td
        '
        Me.lbl_design_td.AutoSize = True
        Me.lbl_design_td.Location = New System.Drawing.Point(329, 49)
        Me.lbl_design_td.Name = "lbl_design_td"
        Me.lbl_design_td.Size = New System.Drawing.Size(66, 16)
        Me.lbl_design_td.TabIndex = 4
        Me.lbl_design_td.Text = "Design TD"
        '
        'lbl_refrigerant
        '
        Me.lbl_refrigerant.AutoSize = True
        Me.lbl_refrigerant.Location = New System.Drawing.Point(17, 109)
        Me.lbl_refrigerant.Name = "lbl_refrigerant"
        Me.lbl_refrigerant.Size = New System.Drawing.Size(72, 16)
        Me.lbl_refrigerant.TabIndex = 6
        Me.lbl_refrigerant.Text = "Refrigerant"
        '
        'cbo_refrigerant
        '
        Me.cbo_refrigerant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_refrigerant.FormattingEnabled = True
        Me.cbo_refrigerant.Items.AddRange(New Object() {"R22", "R404a", "R507", "R134a", "R407a", "R407c", "R407f", "R448a", "R449a"})
        Me.cbo_refrigerant.Location = New System.Drawing.Point(157, 102)
        Me.cbo_refrigerant.Name = "cbo_refrigerant"
        Me.cbo_refrigerant.Size = New System.Drawing.Size(100, 24)
        Me.cbo_refrigerant.TabIndex = 4
        '
        'cbo_series
        '
        Me.cbo_series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_series.FormattingEnabled = True
        Me.cbo_series.Items.AddRange(New Object() {"All", "A", "AWSM", "BALV", "BOC", "E", "FV", "PFE", "UFH", "WIBR", "XBOC"})
        Me.cbo_series.Location = New System.Drawing.Point(157, 72)
        Me.cbo_series.Name = "cbo_series"
        Me.cbo_series.Size = New System.Drawing.Size(100, 24)
        Me.cbo_series.TabIndex = 3
        '
        'lbl_series
        '
        Me.lbl_series.AutoSize = True
        Me.lbl_series.Location = New System.Drawing.Point(17, 79)
        Me.lbl_series.Name = "lbl_series"
        Me.lbl_series.Size = New System.Drawing.Size(111, 16)
        Me.lbl_series.TabIndex = 9
        Me.lbl_series.Text = "Unit Cooler Series"
        '
        'lbl_total_capacity_btuh
        '
        Me.lbl_total_capacity_btuh.AutoSize = True
        Me.lbl_total_capacity_btuh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_capacity_btuh.ForeColor = System.Drawing.Color.Gray
        Me.lbl_total_capacity_btuh.Location = New System.Drawing.Point(263, 18)
        Me.lbl_total_capacity_btuh.Name = "lbl_total_capacity_btuh"
        Me.lbl_total_capacity_btuh.Size = New System.Drawing.Size(33, 13)
        Me.lbl_total_capacity_btuh.TabIndex = 10
        Me.lbl_total_capacity_btuh.Text = "BTUH"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(614, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "°F"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(614, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "°F"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(12, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Enter unit cooler selection criteria"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lbl_fan_quantity)
        Me.Panel1.Controls.Add(Me.cbo_fan_quantity)
        Me.Panel1.Controls.Add(Me.ddlDOEModels)
        Me.Panel1.Controls.Add(Me.lbl_static_pressure)
        Me.Panel1.Controls.Add(Me.cbo_static_pressure)
        Me.Panel1.Controls.Add(Me.txt_unit_cooler_quantity)
        Me.Panel1.Controls.Add(Me.txt_total_capacity)
        Me.Panel1.Controls.Add(Me.txt_td)
        Me.Panel1.Controls.Add(Me.txt_room_temperature)
        Me.Panel1.Controls.Add(Me.cbo_defrost_type)
        Me.Panel1.Controls.Add(Me.lbl_defrost_type)
        Me.Panel1.Controls.Add(Me.lbl_unit_cooler_quantity)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lbl_total_capacity)
        Me.Panel1.Controls.Add(Me.lbl_suction_temperature_value)
        Me.Panel1.Controls.Add(Me.lbl_suction_temperature)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lbl_room_temperature)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbl_total_capacity_btuh)
        Me.Panel1.Controls.Add(Me.lbl_design_td)
        Me.Panel1.Controls.Add(Me.lbl_series)
        Me.Panel1.Controls.Add(Me.cbo_series)
        Me.Panel1.Controls.Add(Me.lbl_refrigerant)
        Me.Panel1.Controls.Add(Me.cbo_refrigerant)
        Me.Panel1.Location = New System.Drawing.Point(12, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 174)
        Me.Panel1.TabIndex = 1
        '
        'lbl_fan_quantity
        '
        Me.lbl_fan_quantity.AutoSize = True
        Me.lbl_fan_quantity.Location = New System.Drawing.Point(329, 139)
        Me.lbl_fan_quantity.Name = "lbl_fan_quantity"
        Me.lbl_fan_quantity.Size = New System.Drawing.Size(80, 16)
        Me.lbl_fan_quantity.TabIndex = 22
        Me.lbl_fan_quantity.Text = "Fan Quantity"
        '
        'cbo_fan_quantity
        '
        Me.cbo_fan_quantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_fan_quantity.FormattingEnabled = True
        Me.cbo_fan_quantity.Items.AddRange(New Object() {"Any", "1", "2", "3", "4", "5", "6"})
        Me.cbo_fan_quantity.Location = New System.Drawing.Point(508, 133)
        Me.cbo_fan_quantity.Name = "cbo_fan_quantity"
        Me.cbo_fan_quantity.Size = New System.Drawing.Size(100, 24)
        Me.cbo_fan_quantity.TabIndex = 21
        '
        'lbl_static_pressure
        '
        Me.lbl_static_pressure.AutoSize = True
        Me.lbl_static_pressure.Location = New System.Drawing.Point(329, 109)
        Me.lbl_static_pressure.Name = "lbl_static_pressure"
        Me.lbl_static_pressure.Size = New System.Drawing.Size(94, 16)
        Me.lbl_static_pressure.TabIndex = 20
        Me.lbl_static_pressure.Text = "Static Pressure"
        '
        'cbo_static_pressure
        '
        Me.cbo_static_pressure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_static_pressure.FormattingEnabled = True
        Me.cbo_static_pressure.Items.AddRange(New Object() {"0", "0.25", "0.5"})
        Me.cbo_static_pressure.Location = New System.Drawing.Point(508, 103)
        Me.cbo_static_pressure.Name = "cbo_static_pressure"
        Me.cbo_static_pressure.Size = New System.Drawing.Size(100, 24)
        Me.cbo_static_pressure.TabIndex = 19
        '
        'cbo_defrost_type
        '
        Me.cbo_defrost_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_defrost_type.FormattingEnabled = True
        Me.cbo_defrost_type.Items.AddRange(New Object() {"A", "E", "HG"})
        Me.cbo_defrost_type.Location = New System.Drawing.Point(157, 132)
        Me.cbo_defrost_type.Name = "cbo_defrost_type"
        Me.cbo_defrost_type.Size = New System.Drawing.Size(100, 24)
        Me.cbo_defrost_type.TabIndex = 5
        '
        'lbl_defrost_type
        '
        Me.lbl_defrost_type.AutoSize = True
        Me.lbl_defrost_type.Location = New System.Drawing.Point(17, 140)
        Me.lbl_defrost_type.Name = "lbl_defrost_type"
        Me.lbl_defrost_type.Size = New System.Drawing.Size(81, 16)
        Me.lbl_defrost_type.TabIndex = 18
        Me.lbl_defrost_type.Text = "Defrost Type"
        '
        'lbl_unit_cooler_quantity
        '
        Me.lbl_unit_cooler_quantity.AutoSize = True
        Me.lbl_unit_cooler_quantity.Location = New System.Drawing.Point(17, 49)
        Me.lbl_unit_cooler_quantity.Name = "lbl_unit_cooler_quantity"
        Me.lbl_unit_cooler_quantity.Size = New System.Drawing.Size(122, 16)
        Me.lbl_unit_cooler_quantity.TabIndex = 13
        Me.lbl_unit_cooler_quantity.Text = "Unit Cooler Quantity"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(614, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "°F"
        '
        'lbl_suction_temperature_value
        '
        Me.lbl_suction_temperature_value.AutoSize = True
        Me.lbl_suction_temperature_value.ForeColor = System.Drawing.Color.Gray
        Me.lbl_suction_temperature_value.Location = New System.Drawing.Point(508, 79)
        Me.lbl_suction_temperature_value.Name = "lbl_suction_temperature_value"
        Me.lbl_suction_temperature_value.Size = New System.Drawing.Size(22, 16)
        Me.lbl_suction_temperature_value.TabIndex = 16
        Me.lbl_suction_temperature_value.Text = "30"
        '
        'lbl_suction_temperature
        '
        Me.lbl_suction_temperature.AutoSize = True
        Me.lbl_suction_temperature.ForeColor = System.Drawing.Color.Gray
        Me.lbl_suction_temperature.Location = New System.Drawing.Point(329, 79)
        Me.lbl_suction_temperature.Name = "lbl_suction_temperature"
        Me.lbl_suction_temperature.Size = New System.Drawing.Size(154, 16)
        Me.lbl_suction_temperature.TabIndex = 15
        Me.lbl_suction_temperature.Text = "Evaporating Temperature"
        '
        'btn_find_unit_coolers
        '
        Me.btn_find_unit_coolers.Location = New System.Drawing.Point(12, 219)
        Me.btn_find_unit_coolers.Name = "btn_find_unit_coolers"
        Me.btn_find_unit_coolers.Size = New System.Drawing.Size(140, 33)
        Me.btn_find_unit_coolers.TabIndex = 2
        Me.btn_find_unit_coolers.Text = "Find Unit Coolers"
        Me.btn_find_unit_coolers.UseVisualStyleBackColor = True
        '
        'grd_unit_coolers
        '
        Me.grd_unit_coolers.AllowUserToAddRows = False
        Me.grd_unit_coolers.AllowUserToDeleteRows = False
        Me.grd_unit_coolers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd_unit_coolers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grd_unit_coolers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_unit_coolers.Location = New System.Drawing.Point(12, 258)
        Me.grd_unit_coolers.Name = "grd_unit_coolers"
        Me.grd_unit_coolers.RowHeadersWidth = 30
        Me.grd_unit_coolers.Size = New System.Drawing.Size(898, 258)
        Me.grd_unit_coolers.TabIndex = 19
        '
        'lbl_dimensions_note
        '
        Me.lbl_dimensions_note.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_dimensions_note.AutoSize = True
        Me.lbl_dimensions_note.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_dimensions_note.Location = New System.Drawing.Point(15, 520)
        Me.lbl_dimensions_note.Name = "lbl_dimensions_note"
        Me.lbl_dimensions_note.Size = New System.Drawing.Size(230, 16)
        Me.lbl_dimensions_note.TabIndex = 20
        Me.lbl_dimensions_note.Text = "* dimensions and capacity are per unit"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(819, 219)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(91, 33)
        Me.btnPrint.TabIndex = 21
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(658, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "DOE Models Only?"
        '
        'ddlDOEModels
        '
        Me.ddlDOEModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlDOEModels.FormattingEnabled = True
        Me.ddlDOEModels.Items.AddRange(New Object() {"Yes", "No"})
        Me.ddlDOEModels.Location = New System.Drawing.Point(789, 17)
        Me.ddlDOEModels.Name = "ddlDOEModels"
        Me.ddlDOEModels.Size = New System.Drawing.Size(51, 24)
        Me.ddlDOEModels.TabIndex = 23
        '
        'txt_unit_cooler_quantity
        '
        Me.txt_unit_cooler_quantity.BackColor = System.Drawing.Color.White
        Me.txt_unit_cooler_quantity.Location = New System.Drawing.Point(157, 43)
        Me.txt_unit_cooler_quantity.message_margin = 5
        Me.txt_unit_cooler_quantity.Name = "txt_unit_cooler_quantity"
        Me.txt_unit_cooler_quantity.Size = New System.Drawing.Size(100, 23)
        Me.txt_unit_cooler_quantity.TabIndex = 2
        Me.txt_unit_cooler_quantity.Text = "1"
        '
        'txt_total_capacity
        '
        Me.txt_total_capacity.BackColor = System.Drawing.Color.White
        Me.txt_total_capacity.Location = New System.Drawing.Point(157, 13)
        Me.txt_total_capacity.message_margin = 5
        Me.txt_total_capacity.Name = "txt_total_capacity"
        Me.txt_total_capacity.Size = New System.Drawing.Size(100, 23)
        Me.txt_total_capacity.TabIndex = 1
        Me.txt_total_capacity.Text = "100000"
        '
        'txt_td
        '
        Me.txt_td.BackColor = System.Drawing.Color.White
        Me.txt_td.Location = New System.Drawing.Point(508, 43)
        Me.txt_td.message_margin = 5
        Me.txt_td.Name = "txt_td"
        Me.txt_td.Size = New System.Drawing.Size(100, 23)
        Me.txt_td.TabIndex = 7
        Me.txt_td.Text = "15"
        '
        'txt_room_temperature
        '
        Me.txt_room_temperature.BackColor = System.Drawing.Color.White
        Me.txt_room_temperature.Location = New System.Drawing.Point(508, 13)
        Me.txt_room_temperature.message_margin = 5
        Me.txt_room_temperature.Name = "txt_room_temperature"
        Me.txt_room_temperature.Size = New System.Drawing.Size(100, 23)
        Me.txt_room_temperature.TabIndex = 6
        Me.txt_room_temperature.Text = "45"
        '
        'unit_cooler_selection_screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(922, 552)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lbl_dimensions_note)
        Me.Controls.Add(Me.grd_unit_coolers)
        Me.Controls.Add(Me.btn_find_unit_coolers)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "unit_cooler_selection_screen"
        Me.Text = "unit_cooler_selection_screen"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grd_unit_coolers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_total_capacity As System.Windows.Forms.Label
    Friend WithEvents lbl_room_temperature As System.Windows.Forms.Label
    Friend WithEvents lbl_design_td As System.Windows.Forms.Label
    Friend WithEvents lbl_refrigerant As System.Windows.Forms.Label
    Friend WithEvents cbo_refrigerant As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_series As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_series As System.Windows.Forms.Label
    Friend WithEvents lbl_total_capacity_btuh As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_suction_temperature As System.Windows.Forms.Label
    Friend WithEvents lbl_suction_temperature_value As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_unit_cooler_quantity As System.Windows.Forms.Label
    Friend WithEvents btn_find_unit_coolers As System.Windows.Forms.Button
    Friend WithEvents grd_unit_coolers As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_defrost_type As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_defrost_type As System.Windows.Forms.Label
    Friend WithEvents lbl_dimensions_note As System.Windows.Forms.Label
    Friend WithEvents txt_room_temperature As Rae.RaeSolutions.text_number
    Friend WithEvents txt_td As Rae.RaeSolutions.text_number
    Friend WithEvents txt_total_capacity As Rae.RaeSolutions.text_number
    Friend WithEvents txt_unit_cooler_quantity As Rae.RaeSolutions.text_number
    Friend WithEvents lbl_static_pressure As System.Windows.Forms.Label
    Friend WithEvents cbo_static_pressure As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_fan_quantity As System.Windows.Forms.Label
    Friend WithEvents cbo_fan_quantity As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ddlDOEModels As System.Windows.Forms.ComboBox
End Class
