<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSubmittalRequest
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
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSendViaEmail = New System.Windows.Forms.CheckBox()
        Me.chkSendViaRegularMail = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbFileFormatAutoCad = New System.Windows.Forms.RadioButton()
        Me.rbFileFormatPDF = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmailAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtATTN = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbCopies = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Red
        Me.btnDelete.Location = New System.Drawing.Point(517, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(20, 21)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "X"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Send Submittals to"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(99, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Company:"
        '
        'chkSendViaEmail
        '
        Me.chkSendViaEmail.AutoSize = True
        Me.chkSendViaEmail.BackColor = System.Drawing.SystemColors.Control
        Me.chkSendViaEmail.Location = New System.Drawing.Point(0, 0)
        Me.chkSendViaEmail.Name = "chkSendViaEmail"
        Me.chkSendViaEmail.Size = New System.Drawing.Size(97, 17)
        Me.chkSendViaEmail.TabIndex = 4
        Me.chkSendViaEmail.Text = "Send Via Email"
        Me.chkSendViaEmail.UseVisualStyleBackColor = False
        '
        'chkSendViaRegularMail
        '
        Me.chkSendViaRegularMail.AutoSize = True
        Me.chkSendViaRegularMail.BackColor = System.Drawing.SystemColors.Control
        Me.chkSendViaRegularMail.Location = New System.Drawing.Point(0, 0)
        Me.chkSendViaRegularMail.Name = "chkSendViaRegularMail"
        Me.chkSendViaRegularMail.Size = New System.Drawing.Size(131, 17)
        Me.chkSendViaRegularMail.TabIndex = 5
        Me.chkSendViaRegularMail.Text = "Send Via Regular Mail"
        Me.chkSendViaRegularMail.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSendViaEmail)
        Me.GroupBox1.Controls.Add(Me.rbFileFormatAutoCad)
        Me.GroupBox1.Controls.Add(Me.rbFileFormatPDF)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtEmailAddress)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 111)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'rbFileFormatAutoCad
        '
        Me.rbFileFormatAutoCad.AutoSize = True
        Me.rbFileFormatAutoCad.Location = New System.Drawing.Point(111, 49)
        Me.rbFileFormatAutoCad.Name = "rbFileFormatAutoCad"
        Me.rbFileFormatAutoCad.Size = New System.Drawing.Size(65, 17)
        Me.rbFileFormatAutoCad.TabIndex = 12
        Me.rbFileFormatAutoCad.Text = "Autocad"
        Me.rbFileFormatAutoCad.UseVisualStyleBackColor = True
        '
        'rbFileFormatPDF
        '
        Me.rbFileFormatPDF.AutoSize = True
        Me.rbFileFormatPDF.Checked = True
        Me.rbFileFormatPDF.Location = New System.Drawing.Point(17, 49)
        Me.rbFileFormatPDF.Name = "rbFileFormatPDF"
        Me.rbFileFormatPDF.Size = New System.Drawing.Size(65, 17)
        Me.rbFileFormatPDF.TabIndex = 11
        Me.rbFileFormatPDF.TabStop = True
        Me.rbFileFormatPDF.Text = "PDF File"
        Me.rbFileFormatPDF.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Email Address:"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(78, 23)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(166, 20)
        Me.txtEmailAddress.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkSendViaRegularMail)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtATTN)
        Me.GroupBox2.Controls.Add(Me.txtAddress)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbCopies)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(265, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 111)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(102, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Attn:"
        '
        'txtATTN
        '
        Me.txtATTN.Location = New System.Drawing.Point(137, 78)
        Me.txtATTN.Name = "txtATTN"
        Me.txtATTN.Size = New System.Drawing.Size(129, 20)
        Me.txtATTN.TabIndex = 14
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(50, 20)
        Me.txtAddress.MaxLength = 254
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(216, 54)
        Me.txtAddress.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Address:"
        '
        'cbCopies
        '
        Me.cbCopies.FormattingEnabled = True
        Me.cbCopies.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cbCopies.Location = New System.Drawing.Point(50, 78)
        Me.cbCopies.Name = "cbCopies"
        Me.cbCopies.Size = New System.Drawing.Size(41, 21)
        Me.cbCopies.TabIndex = 11
        Me.cbCopies.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Copies:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(143, 1)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(129, 20)
        Me.txtName.TabIndex = 15
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(338, 0)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(129, 20)
        Me.txtCompany.TabIndex = 16
        '
        'ucSubmittalRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "ucSubmittalRequest"
        Me.Size = New System.Drawing.Size(545, 150)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkSendViaEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkSendViaRegularMail As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtATTN As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbCopies As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbFileFormatAutoCad As System.Windows.Forms.RadioButton
    Friend WithEvents rbFileFormatPDF As System.Windows.Forms.RadioButton
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox

End Class
