<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PumpSelectionView
    Inherits View

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
Me.Label6 = New System.Windows.Forms.Label
Me.panPumpInputs = New System.Windows.Forms.Panel
Me.lblPrice = New Rae.RaeSolutions.DollarLabel
Me.lblMfg = New System.Windows.Forms.Label
Me.cboMfg = New System.Windows.Forms.ComboBox
Me.lblFlow = New System.Windows.Forms.Label
Me.txtFlow = New System.Windows.Forms.TextBox
Me.lblHead = New System.Windows.Forms.Label
Me.cboHead = New System.Windows.Forms.ComboBox
Me.lblSys = New System.Windows.Forms.Label
Me.cboSys = New System.Windows.Forms.ComboBox
Me.dataView = New Rae.RaeSolutions.PumpDataView
Me.panPumpInputs.SuspendLayout()
Me.SuspendLayout()
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
Me.Label6.Location = New System.Drawing.Point(10, -32)
Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(171, 23)
Me.Label6.TabIndex = 29
Me.Label6.Text = "Select Pump Package"
'
'panPumpInputs
'
Me.panPumpInputs.Controls.Add(Me.lblPrice)
Me.panPumpInputs.Controls.Add(Me.lblMfg)
Me.panPumpInputs.Controls.Add(Me.cboMfg)
Me.panPumpInputs.Controls.Add(Me.lblFlow)
Me.panPumpInputs.Controls.Add(Me.txtFlow)
Me.panPumpInputs.Controls.Add(Me.lblHead)
Me.panPumpInputs.Controls.Add(Me.cboHead)
Me.panPumpInputs.Controls.Add(Me.lblSys)
Me.panPumpInputs.Controls.Add(Me.cboSys)
Me.panPumpInputs.Dock = System.Windows.Forms.DockStyle.Top
Me.panPumpInputs.Location = New System.Drawing.Point(0, 0)
Me.panPumpInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.panPumpInputs.Name = "panPumpInputs"
Me.panPumpInputs.Size = New System.Drawing.Size(368, 112)
Me.panPumpInputs.TabIndex = 28
'
'lblPrice
'
Me.lblPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.lblPrice.ForeColor = System.Drawing.Color.Green
Me.lblPrice.Location = New System.Drawing.Point(280, 5)
Me.lblPrice.Name = "lblPrice"
Me.lblPrice.Size = New System.Drawing.Size(78, 21)
Me.lblPrice.TabIndex = 8
Me.lblPrice.Text = "$0"
Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
Me.lblPrice.Visible = False
'
'lblMfg
'
Me.lblMfg.AutoSize = True
Me.lblMfg.Location = New System.Drawing.Point(4, 7)
Me.lblMfg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblMfg.Name = "lblMfg"
Me.lblMfg.Size = New System.Drawing.Size(83, 15)
Me.lblMfg.TabIndex = 1
Me.lblMfg.Text = "Manufacturer"
'
'cboMfg
'
Me.cboMfg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.cboMfg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cboMfg.FormattingEnabled = True
Me.cboMfg.Items.AddRange(New Object() {"Bell and Gossett Pumps", "Armstrong Pumps"})
Me.cboMfg.Location = New System.Drawing.Point(141, 5)
Me.cboMfg.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
Me.cboMfg.Name = "cboMfg"
Me.cboMfg.Size = New System.Drawing.Size(134, 23)
Me.cboMfg.TabIndex = 0
'
'lblFlow
'
Me.lblFlow.AutoSize = True
Me.lblFlow.Location = New System.Drawing.Point(4, 34)
Me.lblFlow.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblFlow.Name = "lblFlow"
Me.lblFlow.Size = New System.Drawing.Size(135, 15)
Me.lblFlow.TabIndex = 2
Me.lblFlow.Text = "System Flow Rate [gpm]"
'
'txtFlow
'
Me.txtFlow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.txtFlow.Location = New System.Drawing.Point(141, 32)
Me.txtFlow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtFlow.Name = "txtFlow"
Me.txtFlow.Size = New System.Drawing.Size(134, 23)
Me.txtFlow.TabIndex = 3
Me.txtFlow.Text = "10"
'
'lblHead
'
Me.lblHead.AutoSize = True
Me.lblHead.Location = New System.Drawing.Point(4, 61)
Me.lblHead.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblHead.Name = "lblHead"
Me.lblHead.Size = New System.Drawing.Size(79, 15)
Me.lblHead.TabIndex = 4
Me.lblHead.Text = "Head TDH [ft]"
'
'cboHead
'
Me.cboHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.cboHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cboHead.FormattingEnabled = True
Me.cboHead.Items.AddRange(New Object() {"50", "75", "100"})
Me.cboHead.Location = New System.Drawing.Point(141, 58)
Me.cboHead.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
Me.cboHead.Name = "cboHead"
Me.cboHead.Size = New System.Drawing.Size(134, 23)
Me.cboHead.TabIndex = 5
'
'lblSys
'
Me.lblSys.AutoSize = True
Me.lblSys.Location = New System.Drawing.Point(4, 88)
Me.lblSys.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblSys.Name = "lblSys"
Me.lblSys.Size = New System.Drawing.Size(45, 15)
Me.lblSys.TabIndex = 6
Me.lblSys.Text = "System"
'
'cboSys
'
Me.cboSys.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.cboSys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cboSys.FormattingEnabled = True
Me.cboSys.Items.AddRange(New Object() {"Single", "Dual (Primary Stand By Arrangement)"})
Me.cboSys.Location = New System.Drawing.Point(141, 86)
Me.cboSys.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
Me.cboSys.Name = "cboSys"
Me.cboSys.Size = New System.Drawing.Size(134, 23)
Me.cboSys.TabIndex = 7
'
'dataView
'
Me.dataView.BackColor = System.Drawing.Color.White
Me.dataView.Dock = System.Windows.Forms.DockStyle.Fill
Me.dataView.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.dataView.Location = New System.Drawing.Point(0, 112)
Me.dataView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
Me.dataView.Name = "dataView"
Me.dataView.Size = New System.Drawing.Size(368, 64)
Me.dataView.TabIndex = 48
Me.dataView.TabStop = False
'
'PumpSelectionView
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.Controls.Add(Me.dataView)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.panPumpInputs)
Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
Me.Name = "PumpSelectionView"
Me.Size = New System.Drawing.Size(368, 176)
Me.panPumpInputs.ResumeLayout(False)
Me.panPumpInputs.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents panPumpInputs As System.Windows.Forms.Panel
    Friend WithEvents lblMfg As System.Windows.Forms.Label
    Friend WithEvents cboMfg As System.Windows.Forms.ComboBox
    Friend WithEvents lblFlow As System.Windows.Forms.Label
    Friend WithEvents txtFlow As System.Windows.Forms.TextBox
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents cboHead As System.Windows.Forms.ComboBox
    Friend WithEvents lblSys As System.Windows.Forms.Label
    Friend WithEvents cboSys As System.Windows.Forms.ComboBox
    Friend WithEvents dataView As Rae.RaeSolutions.PumpDataView
    Friend WithEvents lblPrice As Rae.RaeSolutions.DollarLabel

End Class
