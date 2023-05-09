Imports rae.solutions.compressors

Namespace rae.solutions.air_cooled_chillers

    Public Class service : Inherits chillers.base_chiller_service

        Protected chiller_repository As i_repository
        Protected user1 As user


        Sub New(ByVal compressor_repository As i_compressor_repository, ByVal chiller_repository As i_repository, ByVal user As user)
            MyBase.new(compressor_repository)
            Me.chiller_repository = chiller_repository
            Me.user1 = user
        End Sub

        Function get_models(ByVal series As String) As ilist(Of String)
            Dim models = chiller_repository.get_models(series)

            models.sort(New comparison(Of String)(AddressOf sort_chiller_models))

            models.insert(0, "Choose")

            Return models
        End Function

        Overrides Function get_compressors(ByVal refg As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As List(Of compressor)
            Dim compressors = MyBase.get_compressors(refg, voltage, model_type, constantReturnGasTemp)

            If Not user1.is_in(rae.solutions.group.CSW_Compressors) Then
                compressors = remove_compressors_that_start_with_csw_from(compressors)
            End If


            Return compressors
        End Function


        Private Function remove_compressors_that_start_with_csw_from(ByVal compressors As list(Of compressor)) As list(Of compressor)
            Dim compressors_to_remove = New list(Of compressor)

            For Each compressor In compressors
                If compressor.model.startsWith("CSW") Then _
                   compressors_to_remove.add(compressor)
            Next

            For Each compressor_to_remove In compressors_to_remove
                compressors.remove(compressor_to_remove)
            Next

            Return compressors
        End Function

    End Class

End Namespace