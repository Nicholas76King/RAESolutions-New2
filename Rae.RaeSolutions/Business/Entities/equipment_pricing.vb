Imports Rae.Reflection
Imports System.Linq

Namespace Rae.RaeSolutions.Business.Entities

    Public Class equipment_pricing

        ''' <summary>List price for one unit (includes options)</summary>
        Property list_price As Double
        Property quantity As Integer
        Property warranty As Double
        Property start_up As Double
        Property freight As Double
        ''' <summary>List of other prices (value) and their description (key)</summary>
        <Exclude()>
        Property others As Dictionary(Of String, Double)
        Property par_multiplier As Double
        Property commission_rate As Double
        Property multiplier_code As MultiplierCode
        Property other_price As Double
        Property other_description As String
        Property base_list_price_is_overridden As Boolean
        Property overridden_base_list_price As Double
        Property multiplier_type As String

        Private Function total_others() As Double
            Return others.Values.Sum
        End Function

        Sub New()
            others = New Dictionary(Of String, Double)
            quantity = 1

        End Sub

        Overloads Function equals(ByVal other As equipment_pricing) As Boolean
            Dim are_equal = reflector.are_equal(Me, other) _
                        And others.Count = other.others.Count

            If Not are_equal Then Return False

            For Each key In others.Keys
                If Not (other.others.ContainsKey(key) AndAlso others.Item(key) = other.others.Item(key)) Then _
                   Return False
            Next
            Return True
        End Function

        Function clone() As equipment_pricing
            Dim the_clone = reflector.clone(Me)
            the_clone.others = New Dictionary(Of String, Double)(Me.others)
            Return the_clone
        End Function

    End Class
End Namespace