Imports rae.solutions.compressors

Namespace rae.solutions.evaporative_condenser_chillers

    Public Class service : Inherits chillers.base_chiller_service

        Private chiller_repository As i_repository

        Sub New(ByVal compressor_repository As i_compressor_repository, ByVal chiller_repository As i_repository)
            MyBase.new(compressor_repository)
            Me.chiller_repository = chiller_repository
        End Sub

        Function get_evaporative_condensers() As list(Of evaporative_condenser)
            Dim condensers = chiller_repository.get_condensers()
            condensers.add(build_custom_condenser)
            Return condensers
        End Function

        Private Function build_custom_condenser() As evaporative_condenser
            Dim condenser As evaporative_condenser
            condenser.model = "Custom"
            condenser.is_custom = True
            Return condenser
        End Function

        Function get_models(ByVal series As String, ByVal refg As refrigerant) As ilist(Of String)
            Dim models = chiller_repository.get_models(series, refg.value)
            models.sort(New comparison(Of String)(AddressOf sort_chiller_models))
            Return models
        End Function

        Function [get](ByVal model As String, ByVal voltage As Integer) As chiller
            If voltage = 208 Then voltage = 230 'to match compressors
            Return chiller_repository.[get](model, voltage)
        End Function

        Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal standard_hp As Double, ByVal user As user) As list(Of compressor)
            Dim compressors As list(Of compressor)

            If user.is_employee Then
                compressors = MyBase.get_compressors(refrigerant, voltage, "EvaporativeCondenserChiller", "N")
            Else
                compressors = get_compressors_for_rep(refrigerant, voltage, standard_hp)
            End If

            Return compressors
        End Function

        Private Function get_compressors_for_rep(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal standard_hp As Double) As list(Of compressor)
            Dim compressor_models = chiller_repository.get_distinct_compressor_models(series:="35E2")

            Dim compressors = New list(Of compressor)
            For Each compressor_model In compressor_models
                compressors.Add(compressor_repository.get_compressor(compressor_model, refrigerant, voltage, "EvaporativeCondenserChiller", "N"))
            Next

            compressors = get_one_hp_size_up_and_down(compressors, standard_hp)

            Return compressors
        End Function

        Private Function compare_compressors_by_hp(ByVal x As compressor, ByVal y As compressor) As Integer
            Return CInt(x.hp - y.hp)
        End Function

        Private Function get_one_hp_size_up_and_down(ByVal compressors As list(Of compressor), ByVal hp As Double) As list(Of compressor)
            compressors.sort(New comparison(Of compressor)(AddressOf compare_compressors_by_hp))

            Dim filtered = New list(Of compressor)

            For i As Integer = 0 To compressors.count - 1
                If compressors(i).hp = hp Then
                    If i > 0 Then filtered.add(compressors(i - 1))

                    filtered.add(compressors(i))

                    If i < compressors.count - 1 Then filtered.add(compressors(i + 1))

                    Exit For
                End If
            Next

            Return filtered
        End Function

    End Class

End Namespace