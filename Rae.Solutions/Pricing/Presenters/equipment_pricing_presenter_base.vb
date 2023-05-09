MustInherit Class equipment_pricing_presenter_base

    Sub New(ByVal equipView As EquipmentForm, ByVal mainView As MainForm)
        Me.equipView = equipView
        Me.mainView = mainView
    End Sub

    Sub ViewSubmittal(ByVal generateOnly As Boolean, ByRef fileName As String, Optional ByVal showReport As Boolean = False, Optional ByVal logo As String = "")
        Dim submittal = create_submittal()
        ' Dim junk As String = ""
        If MainForm.currentLogo <> "" Then
            submittal.show(generateOnly, fileName, True)
        Else
            submittal.show(generateOnly, fileName)
        End If
    End Sub

    Sub ViewOrderWriteUp(ByVal generateOnly As Boolean, ByRef fileName As String, Optional ByVal showReport As Boolean = False)
        Dim order_write_up = create_order_write_up()

        If showReport Then
            order_write_up.show(generateOnly, fileName, True)
        Else
            order_write_up.show(generateOnly, fileName)
        End If
    End Sub

    Protected MustOverride Function create_submittal() As accessories_base
    Protected MustOverride Function create_order_write_up() As order_write_up_base

    Protected WithEvents equipView As EquipmentForm
    Protected mainView As MainForm

End Class
