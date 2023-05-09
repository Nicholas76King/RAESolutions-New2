Imports rae.solutions
Imports rae.solutions.compressors

Namespace rae.solutions.chillers

    Public Structure specific
        Public heat, gravity As Double
    End Structure

    Public MustInherit Class base_chiller_service

        Protected compressor_repository As i_compressor_repository

        Sub New(ByVal compressor_repository As i_compressor_repository)
            Me.compressor_repository = compressor_repository
        End Sub

        Function calculate_specific_heat_and_gravity( _
           ByVal fluid As StandardRefrigeration.Fluid, _
           ByVal concentration As Double, _
           ByVal enteringtemp As Double, _
           ByVal leavingtemp As Double _
        ) As specific
            Dim sp = New StandardRefrigeration.Specific(fluid, concentration, enteringTemp, leavingTemp)

            Dim specific As specific
            specific.gravity = sp.gravity
            specific.heat = sp.heat

            Return specific
        End Function

        Overridable Function get_compressors(ByVal refg As refrigerant, ByVal voltage As Integer, ByVal model_type As String, ByVal constantReturnGasTemp As String) As List(Of compressor)
            Dim compressors = compressor_repository.get_compressors(refg, voltage, model_type, constantReturnGasTemp)

            compressors.sort(New Comparison(Of compressor)(AddressOf sort_compressors))

            Return compressors
        End Function


        Protected Function sort_compressors(ByVal x As compressor, ByVal y As compressor) As Integer
            If x.model < y.model Then
                Return -1
            ElseIf x.model = y.model Then
                Return 0
            Else
                Return 1
            End If
        End Function

        Protected Function sort_chiller_models(ByVal x As String, ByVal y As String) As Integer
            Dim unit_x = New model_number(x)
            Dim unit_y = New model_number(y)
            'ex. 30A2SD110
            If (unit_x.compressor_type < unit_y.compressor_type) _
            Or (unit_x.compressor_type = unit_y.compressor_type And unit_x.compressor_quantity < unit_y.compressor_quantity) _
            Or (unit_x.compressor_type = unit_y.compressor_type And unit_x.compressor_quantity = unit_y.compressor_quantity And unit_x.hp < unit_y.hp) Then
                Return -1
            ElseIf unit_x.compressor_type = unit_y.compressor_type _
            And unit_x.compressor_quantity = unit_y.compressor_quantity _
            And unit_x.hp = unit_y.hp Then
                Return 0
            Else
                Return 1
            End If
        End Function

        Structure model_number
            Sub New(ByVal model As String)
                Dim compressor_quantity_indicator = model(5).tostring()
                Select Case compressor_quantity_indicator
                    Case "S" : compressor_quantity = 1
                    Case "D" : compressor_quantity = 2
                    Case "M" : compressor_quantity = 4
                End Select

                compressor_type = model(4).ToString()

                ' remove suffixes to make parsing easier
                Dim m = model.Replace(" ALT", "")

                If m.EndsWith("A") Then _
                   m = m.Remove(m.Length - 1)

                hp = CInt(m.substring(6, m.length - 6))
            End Sub

            Public compressor_type As String
            Public compressor_quantity As Integer
            Public hp As Integer
        End Structure

    End Class

End Namespace