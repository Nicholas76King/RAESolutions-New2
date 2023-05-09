Public Class ucSubmittalRequest

    Public Property Copies As Integer
        Get
            Return cbCopies.Text
        End Get
        Set(ByVal value As Integer)
            cbCopies.Text = value
        End Set
    End Property


    Public Property Address As String
        Get
            Return txtAddress.Text
        End Get
        Set(ByVal value As String)
            txtAddress.Text = value
        End Set
    End Property


    Public Property ATTN As String
        Get
            Return txtATTN.Text
        End Get
        Set(ByVal value As String)
            txtATTN.Text = value
        End Set
    End Property

    Public Property cName As String
        Get
            Return txtName.Text
        End Get
        Set(ByVal value As String)
            txtName.Text = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return txtCompany.Text
        End Get
        Set(ByVal value As String)
            txtCompany.Text = value
        End Set
    End Property

    Public Property EmailAddress As String
        Get
            Return txtEmailAddress.Text
        End Get
        Set(ByVal value As String)
            txtEmailAddress.Text = value
        End Set
    End Property


    Public Property SendViaEmail As Boolean
        Get
            Return chkSendViaEmail.Checked
        End Get
        Set(ByVal value As Boolean)
            chkSendViaEmail.Checked = value
        End Set
    End Property

    Public Property SendViaRegularMail As Boolean
        Get
            Return chkSendViaRegularMail.Checked
        End Get
        Set(ByVal value As Boolean)
            chkSendViaRegularMail.Checked = value
        End Set
    End Property

    Public Property FileFormatAutoCad As Boolean
        Get
            Return rbFileFormatAutoCad.Checked
        End Get
        Set(ByVal value As Boolean)
            rbFileFormatAutoCad.Checked = value
        End Set
    End Property

    Public Property FileFormatPDF As Boolean
        Get
            Return rbFileFormatPDF.Checked
        End Get
        Set(ByVal value As Boolean)
            rbFileFormatPDF.Checked = value
        End Set
    End Property


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        ClearControl()

    End Sub

    Public Sub ClearControl()
        cbCopies.Text = 1
        txtAddress.Text = ""
        txtATTN.Text = ""
        chkSendViaEmail.Checked = False
        chkSendViaRegularMail.Checked = False
        txtName.Text = ""
        txtCompany.Text = ""
        txtEmailAddress.Text = ""
        rbFileFormatAutoCad.Checked = False
        rbFileFormatPDF.Checked = True
    End Sub

End Class
