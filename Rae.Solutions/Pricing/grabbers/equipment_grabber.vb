Class equipment_grabber

    Sub New(view As equipmentForm)
        Me.view = view
    End Sub

    Function grab() As bag
        Dim quantity = view.txtUnitQuantity.text

        Dim customModel = view.txtCustomModel.Text
        Dim model = view.EquipmentSelector1.Series & view.EquipmentSelector1.Model
        If Not String.isNullOrEmpty(customModel) Then
            model = " Base:" & model
        End If

        Dim bag As bag
        bag.model = model
        bag.custom_model = view.txtCustomModel.text
        bag.quantity = quantity
        bag.job = view.text
        bag.tag = CType(view.specsControl, CommonSpecsControl).txtTag.Text
        bag.equipmentType = view.EquipmentSelector1.EquipmentType


        Return bag
    End Function

    Structure bag
        Public model, custom_model, quantity, job, tag, equipmentType As String
    End Structure

    Private view As equipmentForm
End Class