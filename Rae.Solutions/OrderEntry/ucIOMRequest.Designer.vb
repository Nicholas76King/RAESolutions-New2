<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucIOMRequest
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.ddlIOMQuantity = New System.Windows.Forms.ComboBox()
        Me.dtpIOMNeededBy = New System.Windows.Forms.DateTimePicker()
        Me.chkIncludeIOM = New System.Windows.Forms.CheckBox()
        Me.cboShippingMethod = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IOM Needed By:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "IOM Quantity:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Send IOMs To (Address):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(322, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Comments:"
        '
        'txtAddress
        '
        Me.txtAddress.Enabled = False
        Me.txtAddress.Location = New System.Drawing.Point(19, 83)
        Me.txtAddress.MaxLength = 254
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(294, 77)
        Me.txtAddress.TabIndex = 4
        '
        'txtComments
        '
        Me.txtComments.Enabled = False
        Me.txtComments.Location = New System.Drawing.Point(334, 83)
        Me.txtComments.MaxLength = 254
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(312, 77)
        Me.txtComments.TabIndex = 5
        '
        'ddlIOMQuantity
        '
        Me.ddlIOMQuantity.Enabled = False
        Me.ddlIOMQuantity.FormattingEnabled = True
        Me.ddlIOMQuantity.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.ddlIOMQuantity.Location = New System.Drawing.Point(291, 34)
        Me.ddlIOMQuantity.Name = "ddlIOMQuantity"
        Me.ddlIOMQuantity.Size = New System.Drawing.Size(41, 21)
        Me.ddlIOMQuantity.TabIndex = 12
        Me.ddlIOMQuantity.Text = "1"
        '
        'dtpIOMNeededBy
        '
        Me.dtpIOMNeededBy.Enabled = False
        Me.dtpIOMNeededBy.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIOMNeededBy.Location = New System.Drawing.Point(108, 34)
        Me.dtpIOMNeededBy.Name = "dtpIOMNeededBy"
        Me.dtpIOMNeededBy.Size = New System.Drawing.Size(97, 20)
        Me.dtpIOMNeededBy.TabIndex = 13
        '
        'chkIncludeIOM
        '
        Me.chkIncludeIOM.AutoSize = True
        Me.chkIncludeIOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncludeIOM.Location = New System.Drawing.Point(6, 3)
        Me.chkIncludeIOM.Name = "chkIncludeIOM"
        Me.chkIncludeIOM.Size = New System.Drawing.Size(146, 17)
        Me.chkIncludeIOM.TabIndex = 14
        Me.chkIncludeIOM.Text = "Include IOM Request"
        Me.chkIncludeIOM.UseVisualStyleBackColor = True
        '
        'cboShippingMethod
        '
        Me.cboShippingMethod.Enabled = False
        Me.cboShippingMethod.FormattingEnabled = True
        Me.cboShippingMethod.Items.AddRange(New Object() {"UPS Ground (3 to 5 Business Days)", "UPS Second Day", "UPS Overnight"})
        Me.cboShippingMethod.Location = New System.Drawing.Point(436, 33)
        Me.cboShippingMethod.Name = "cboShippingMethod"
        Me.cboShippingMethod.Size = New System.Drawing.Size(210, 21)
        Me.cboShippingMethod.TabIndex = 15
        Me.cboShippingMethod.Text = "UPS Ground (3 to 5 Business Days)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(340, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Shipping Method:"
        '
        'ucIOMRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboShippingMethod)
        Me.Controls.Add(Me.chkIncludeIOM)
        Me.Controls.Add(Me.dtpIOMNeededBy)
        Me.Controls.Add(Me.ddlIOMQuantity)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ucIOMRequest"
        Me.Size = New System.Drawing.Size(656, 177)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents ddlIOMQuantity As System.Windows.Forms.ComboBox
    Friend WithEvents dtpIOMNeededBy As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkIncludeIOM As System.Windows.Forms.CheckBox
    Friend WithEvents cboShippingMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
