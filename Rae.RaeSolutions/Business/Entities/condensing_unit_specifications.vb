Imports System

Namespace Rae.RaeSolutions.Business.Entities

    'move specifications into condensing unit class
    'namespace: rae.solutions
    Public Class condensing_unit_specifications

        Sub New()
            ambient = New nullable_double
            suction = New nullable_double
            evaporating_temperature = New nullable_double
            capacity_1 = New nullable_double
            capacity_2 = New nullable_double
            capacity_3 = New nullable_double
            capacity_4 = New nullable_double
            efficiency = New nullable_double
            mca = New nullable_double
            rla = New nullable_double
            mop = New nullable_double
            powerFeeds = New nullable_double
        End Sub

        Property refrigerant As String
        Property ambient As nullable_double
        Property suction As nullable_double
        Property evaporating_temperature As nullable_double
        Property capacity_1 As nullable_double
        Property capacity_2 As nullable_double
        Property capacity_3 As nullable_double
        Property capacity_4 As nullable_double
        Property efficiency As nullable_double
        Property mca As nullable_double
        Property rla As nullable_double
        Property mop As nullable_double
        Property powerFeeds As nullable_double

        Function clone() As condensing_unit_specifications
            Return rae.reflection.reflector.clone(Me)
        End Function

        Overrides Function equals(ByVal other As Object) As Boolean
            Return rae.reflection.reflector.are_equal(Me, other)
        End Function

    End Class
End Namespace