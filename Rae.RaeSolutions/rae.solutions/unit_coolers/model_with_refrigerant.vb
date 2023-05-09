Namespace rae.solutions.unit_coolers

    Public Class Model_with_Refrigerant
        Private model, refrigerant As String

        Sub New(model As String, refrigerant As String)
            Me.model = model
            Me.refrigerant = refrigerant
        End Sub

        Function to_string() As String
            Dim refrigerant_indicator As String


            If String.IsNullOrEmpty(refrigerant) Then Return model


            Select Case refrigerant.ToUpper
                Case "R22" : refrigerant_indicator = "2"
                Case "R404A" : refrigerant_indicator = "4"
                Case "R507" : refrigerant_indicator = "7"

                Case "R507C" : refrigerant_indicator = "7"
                Case "R407A" : refrigerant_indicator = "7A"
                Case "R407C" : refrigerant_indicator = "7C"
                Case "R407F" : refrigerant_indicator = "7F"
                Case "R448A" : refrigerant_indicator = "8A"
                Case "R449A" : refrigerant_indicator = "9A"

                Case Else
                    refrigerant_indicator = "0"
                    Return model
            End Select

            ' in case a custom model preceeds base model
            Dim base_index = model.IndexOf("Base")
            If base_index = -1 Then _
               base_index = 0

            Dim refrigerant_indicator_index = model.IndexOf("0", startIndex:=base_index)
            model = model.remove(refrigerant_indicator_index, 1)
            model = model.insert(refrigerant_indicator_index, refrigerant_indicator)

            Return model
        End Function
    End Class

End Namespace