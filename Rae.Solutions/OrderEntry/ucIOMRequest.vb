Public Class ucIOMRequest

    Public Property IncludeIOM As Boolean
        Get
            Return chkIncludeIOM.Checked
        End Get
        Set(ByVal value As Boolean)
            chkIncludeIOM.Checked = value
        End Set
    End Property

    Public Property IOMAddress As String
        Get
            Return txtAddress.Text
        End Get
        Set(ByVal value As String)
            txtAddress.Text = value
        End Set
    End Property

    Public Property Comments As String
        Get
            Return txtComments.Text
        End Get
        Set(ByVal value As String)
            txtComments.Text = value
        End Set
    End Property

    Public Property NeededBy As Date
        Get
            Return dtpIOMNeededBy.Value
        End Get
        Set(ByVal value As Date)
            '  dtpIOMNeededBy.Value = value
        End Set
    End Property


    Public Property Quantity As Integer
        Get
            Return ddlIOMQuantity.Text
        End Get
        Set(ByVal value As Integer)
            ddlIOMQuantity.Text = value
        End Set
    End Property

    Public Property ShippingMethod As String
        Get
            Return cboShippingMethod.Text
        End Get
        Set(ByVal value As String)
            cboShippingMethod.Text = value
        End Set
    End Property



    Private Sub chkIncludeIOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludeIOM.CheckedChanged
        txtAddress.Enabled = chkIncludeIOM.Checked
        txtComments.Enabled = chkIncludeIOM.Checked
        dtpIOMNeededBy.Enabled = chkIncludeIOM.Checked
        ddlIOMQuantity.Enabled = chkIncludeIOM.Checked
        cboShippingMethod.Enabled = chkIncludeIOM.Checked
    End Sub

    Private Sub ucIOMRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
