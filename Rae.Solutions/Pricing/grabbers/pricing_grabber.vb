Class pricing_grabber

    Sub New(ByVal view As EquipmentForm)
        Me.view = view
    End Sub

    Function grab() As bag
        Dim bag As bag
        Dim _grab = New grabber()

        Dim warranty As String = view.txtFourYearCompressorWarranty.Text
        If warranty IsNot Nothing AndAlso warranty <> "Unavailable" Then
            warranty = _grab.price(view.txtFourYearCompressorWarranty).ToString(price_format)
        End If

        Dim multiplier As String = ""

        If view.cboParMultiplier.Visible = False Then
            multiplier = view.NumericUpDown1.Value.ToString()
        Else
            multiplier = view.cboParMultiplier.Text
        End If

        Dim commissionRate As String = view.lblCommissionRate.Text.ToString()
        'Dim dblCommissionRate As Double = 0

        'If view.cboParMultiplier.Visible = False Then
        '    dblCommissionRate = Double.Parse(view.lblCommissionRate.Text.Replace("%", "")) / 100
        '    commissionRate = String.Format("{0:N4}", dblCommissionRate)
        'Else
        '    commissionRate = view.cboParMultiplier.SelectedValue.ToString()
        'End If

        bag.options = view.totalOptionsPrice.ToString(price_format)
        bag.base_list = view.grabBaseList().ToString(price_format)
        bag.total_list = _grab.price(view.lblSummaryTotalListPrice).ToString(price_format)
        bag.par_multiplier = CDbl(multiplier).ToString
        bag.par_price = _grab.price(view.lblParPrice).ToString(price_format)
        bag.commission_rate = commissionRate
        bag.commission = _grab.price(view.lblCommissionPrice).ToString(price_format)
        bag.warranty = warranty
        bag.freight = _grab.price(view.txtFreight).ToString(price_format)
        bag.start_up = _grab.price(view.txtStartUp).ToString(price_format)
        bag.other = _grab.price(view.txtOther).ToString(price_format)
        bag.other_description = view.txtOtherDescription.Text
        bag.nfsp = _grab.price(view.lblNfsp).ToString(price_format)

        Return bag
    End Function

    Structure bag
        Public options, base_list, total_list, par_multiplier, par_price As String
        Public commission_rate, commission, nfsp As String
        Public warranty, freight, start_up, other, other_description As String
    End Structure

    Private view As EquipmentForm
    Private price_format = price.dollar

End Class