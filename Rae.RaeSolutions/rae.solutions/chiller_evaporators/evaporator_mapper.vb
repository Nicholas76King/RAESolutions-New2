Imports rae.solutions
Imports StandardRefrigeration
Imports StandardRefrigeration.Refrigerant

Namespace rae.solutions.chiller_evaporators

    Public Class evaporator_mapper
        Function map(ByVal refrigerant As String) As StandardRefrigeration.Refrigerant
            If refrigerant Like "*22*" Then Return R22
            If refrigerant Like "*134*" Then Return R134a
            If refrigerant Like "*404*" Then Return R404a
            If refrigerant.ToUpper Like "*407A*" Then Return R407a
            If refrigerant.ToUpper Like "*407C*" Then Return R407c
            If refrigerant.ToUpper Like "*407F*" Then Return R407f
            If refrigerant Like "*410*" Then Return R410a
            If refrigerant Like "*507*" Then Return R507a
            If refrigerant.ToUpper Like "*448A*" Then Return R448a
            If refrigerant.ToUpper Like "*449A*" Then Return R449a




            Throw New Exception("Alternate chiller evaporators cannot determined. The refrigerant is invalid: " & refrigerant)
        End Function

        Function map(ByVal media As CoolingMedia) As Fluid
            Select Case media
                Case CoolingMedia.Water : Return Fluid.Water
                Case CoolingMedia.Ethylene : Return Fluid.Ethylene
                Case CoolingMedia.Propylene : Return Fluid.Propylene
            End Select
            Throw New Exception("Alternate chiller evaporators cannot be determined. The fluid is invalid: " & media.ToString)
        End Function
    End Class

End Namespace