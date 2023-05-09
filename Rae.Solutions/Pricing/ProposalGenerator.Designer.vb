<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProposalGenerator
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
        Me.btnGenerateProposal = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cblEquipment = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMyTitle = New System.Windows.Forms.TextBox()
        Me.txtMyEmail = New System.Windows.Forms.TextBox()
        Me.txtMyPhone = New System.Windows.Forms.TextBox()
        Me.txtMyName = New System.Windows.Forms.TextBox()
        Me.txtMyCompanyName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQuoteNumber = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtRevisionNumber = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnGenerateProjectSummary = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboLeadTime = New System.Windows.Forms.ComboBox()
        Me.cboBasePrice = New System.Windows.Forms.ComboBox()
        Me.btnSaveInfo = New System.Windows.Forms.Button()
        Me.ContactManagerControl1 = New Rae.RaeSolutions.ContactManagerControl()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenerateProposal
        '
        Me.btnGenerateProposal.Location = New System.Drawing.Point(705, 324)
        Me.btnGenerateProposal.Name = "btnGenerateProposal"
        Me.btnGenerateProposal.Size = New System.Drawing.Size(132, 49)
        Me.btnGenerateProposal.TabIndex = 0
        Me.btnGenerateProposal.Text = "Generate Proposal"
        Me.btnGenerateProposal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 20)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Address Proposal To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 231)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 20)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "My Information:"
        '
        'cblEquipment
        '
        Me.cblEquipment.CheckOnClick = True
        Me.cblEquipment.FormattingEnabled = True
        Me.cblEquipment.Location = New System.Drawing.Point(397, 43)
        Me.cblEquipment.Name = "cblEquipment"
        Me.cblEquipment.Size = New System.Drawing.Size(248, 394)
        Me.cblEquipment.TabIndex = 153
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(393, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 20)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Selected Equipment"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(671, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 20)
        Me.Label9.TabIndex = 160
        Me.Label9.Text = "Quote Number:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtMyTitle)
        Me.Panel1.Controls.Add(Me.txtMyEmail)
        Me.Panel1.Controls.Add(Me.txtMyPhone)
        Me.Panel1.Controls.Add(Me.txtMyName)
        Me.Panel1.Controls.Add(Me.txtMyCompanyName)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(359, 173)
        Me.Panel1.TabIndex = 166
        '
        'txtMyTitle
        '
        Me.txtMyTitle.Location = New System.Drawing.Point(176, 134)
        Me.txtMyTitle.Name = "txtMyTitle"
        Me.txtMyTitle.Size = New System.Drawing.Size(165, 20)
        Me.txtMyTitle.TabIndex = 175
        '
        'txtMyEmail
        '
        Me.txtMyEmail.Location = New System.Drawing.Point(176, 104)
        Me.txtMyEmail.Name = "txtMyEmail"
        Me.txtMyEmail.Size = New System.Drawing.Size(165, 20)
        Me.txtMyEmail.TabIndex = 174
        '
        'txtMyPhone
        '
        Me.txtMyPhone.Location = New System.Drawing.Point(176, 74)
        Me.txtMyPhone.Name = "txtMyPhone"
        Me.txtMyPhone.Size = New System.Drawing.Size(165, 20)
        Me.txtMyPhone.TabIndex = 173
        '
        'txtMyName
        '
        Me.txtMyName.Location = New System.Drawing.Point(176, 44)
        Me.txtMyName.Name = "txtMyName"
        Me.txtMyName.Size = New System.Drawing.Size(165, 20)
        Me.txtMyName.TabIndex = 172
        '
        'txtMyCompanyName
        '
        Me.txtMyCompanyName.Location = New System.Drawing.Point(176, 14)
        Me.txtMyCompanyName.Name = "txtMyCompanyName"
        Me.txtMyCompanyName.Size = New System.Drawing.Size(165, 20)
        Me.txtMyCompanyName.TabIndex = 171
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 18)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "My Title:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 18)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "My Phone:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 18)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "My Email:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 18)
        Me.Label5.TabIndex = 167
        Me.Label5.Text = "Company Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 18)
        Me.Label4.TabIndex = 166
        Me.Label4.Text = "My Name:"
        '
        'txtQuoteNumber
        '
        Me.txtQuoteNumber.Location = New System.Drawing.Point(693, 32)
        Me.txtQuoteNumber.Name = "txtQuoteNumber"
        Me.txtQuoteNumber.Size = New System.Drawing.Size(165, 20)
        Me.txtQuoteNumber.TabIndex = 172
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(176, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(165, 20)
        Me.TextBox1.TabIndex = 171
        '
        'txtRevisionNumber
        '
        Me.txtRevisionNumber.Location = New System.Drawing.Point(693, 105)
        Me.txtRevisionNumber.Name = "txtRevisionNumber"
        Me.txtRevisionNumber.Size = New System.Drawing.Size(165, 20)
        Me.txtRevisionNumber.TabIndex = 174
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(671, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 20)
        Me.Label10.TabIndex = 173
        Me.Label10.Text = "Revision Number:"
        '
        'btnGenerateProjectSummary
        '
        Me.btnGenerateProjectSummary.Location = New System.Drawing.Point(705, 384)
        Me.btnGenerateProjectSummary.Name = "btnGenerateProjectSummary"
        Me.btnGenerateProjectSummary.Size = New System.Drawing.Size(132, 49)
        Me.btnGenerateProjectSummary.TabIndex = 175
        Me.btnGenerateProjectSummary.Text = "Generate Project Summary"
        Me.btnGenerateProjectSummary.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(671, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 20)
        Me.Label11.TabIndex = 176
        Me.Label11.Text = "Lead Time:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(671, 205)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.TabIndex = 177
        Me.Label12.Text = "Price Base:"
        '
        'cboLeadTime
        '
        Me.cboLeadTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeadTime.FormattingEnabled = True
        Me.cboLeadTime.Items.AddRange(New Object() {"4-6 weeks", "6-8 weeks", "8-10 weeks", "10-12 weeks", "[Contact Factory]"})
        Me.cboLeadTime.Location = New System.Drawing.Point(693, 170)
        Me.cboLeadTime.Name = "cboLeadTime"
        Me.cboLeadTime.Size = New System.Drawing.Size(121, 21)
        Me.cboLeadTime.TabIndex = 178
        '
        'cboBasePrice
        '
        Me.cboBasePrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBasePrice.FormattingEnabled = True
        Me.cboBasePrice.Items.AddRange(New Object() {"List Price", "Net Price"})
        Me.cboBasePrice.Location = New System.Drawing.Point(693, 233)
        Me.cboBasePrice.Name = "cboBasePrice"
        Me.cboBasePrice.Size = New System.Drawing.Size(121, 21)
        Me.cboBasePrice.TabIndex = 179
        '
        'btnSaveInfo
        '
        Me.btnSaveInfo.Location = New System.Drawing.Point(257, 231)
        Me.btnSaveInfo.Name = "btnSaveInfo"
        Me.btnSaveInfo.Size = New System.Drawing.Size(114, 23)
        Me.btnSaveInfo.TabIndex = 180
        Me.btnSaveInfo.Text = "Save My Info"
        Me.btnSaveInfo.UseVisualStyleBackColor = True
        '
        'ContactManagerControl1
        '
        Me.ContactManagerControl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ContactManagerControl1.BackColor = System.Drawing.Color.White
        Me.ContactManagerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContactManagerControl1.CanEdit = True
        Me.ContactManagerControl1.ContactLimit = 999
        Me.ContactManagerControl1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactManagerControl1.Location = New System.Drawing.Point(12, 43)
        Me.ContactManagerControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ContactManagerControl1.Name = "ContactManagerControl1"
        Me.ContactManagerControl1.SelectedContactControl = Nothing
        Me.ContactManagerControl1.Size = New System.Drawing.Size(359, 171)
        Me.ContactManagerControl1.TabIndex = 150
        '
        'ProposalGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 454)
        Me.Controls.Add(Me.btnSaveInfo)
        Me.Controls.Add(Me.cboBasePrice)
        Me.Controls.Add(Me.cboLeadTime)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnGenerateProjectSummary)
        Me.Controls.Add(Me.txtRevisionNumber)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtQuoteNumber)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cblEquipment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ContactManagerControl1)
        Me.Controls.Add(Me.btnGenerateProposal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProposalGenerator"
        Me.Text = "Project Reports"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerateProposal As System.Windows.Forms.Button
    Friend WithEvents ContactManagerControl1 As Rae.RaeSolutions.ContactManagerControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cblEquipment As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtMyTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtMyEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtMyPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtMyName As System.Windows.Forms.TextBox
    Friend WithEvents txtMyCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQuoteNumber As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRevisionNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnGenerateProjectSummary As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboLeadTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboBasePrice As System.Windows.Forms.ComboBox
    Friend WithEvents btnSaveInfo As System.Windows.Forms.Button
End Class
