Imports rae.Collections

Namespace rae.solutions

    Class refrigerant

        Public Shared ReadOnly R22 As New refrigerant("R22", 1)
        Public Shared ReadOnly R404a As New refrigerant("R404a", 0.985, subcooling_factor:=1.33333)
        Public Shared ReadOnly R134a As New refrigerant("R134a", 0.94)
        Public Shared ReadOnly R410a As New refrigerant("R410a", 1, subcooling_factor:=1.33333)

        'Public Shared ReadOnly R507 As New refrigerant("R507", 0.985, q:=1.03, w:=1.02, a:=1.02)
        'Public Shared ReadOnly R407c As New refrigerant("R407c", 0.99, q:=0.96, w:=1.03, a:=1.03)
        Public Shared ReadOnly R507 As New refrigerant("R507", 0.985, subcooling_factor:=1.33333)
        '  Public Shared ReadOnly R407c As New refrigerant("R407c", 0.99)

        ' New refrigerants - 6/29/15 Jay Kindle
        Public Shared ReadOnly R407a As New refrigerant("R407a", 0.98)
        Public Shared ReadOnly R407c As New refrigerant("R407c", 0.97)
        Public Shared ReadOnly R407f As New refrigerant("R407f", 0.98)
        Public Shared ReadOnly R448a As New refrigerant("R448a", 0.96)
        Public Shared ReadOnly R449a As New refrigerant("R449a", 0.96)





        Shared Function parse(ByVal ref As String) As refrigerant
            Dim r As refrigerant

            If ref Like "*22*" Then
                r = R22
            ElseIf ref Like "*404*" Then
                r = R404a
            ElseIf ref.ToLower Like "*134a*" Then
                r = R134a
            ElseIf ref.ToLower Like "*407a*" Then
                r = R407a
            ElseIf ref.ToLower Like "*407c*" Then
                r = R407c
            ElseIf ref.ToLower Like "*407f*" Then
                r = R407f
            ElseIf ref.ToLower Like "*448a*" Then
                r = R448a
            ElseIf ref.ToLower Like "*449a*" Then
                r = R449a
            ElseIf ref Like "*410*" Then
                r = R410a
            ElseIf ref Like "*507*" Then
                r = R507
            Else
                Throw New Exception("The refrigerant string cannot be parsed; it is not among the list of refrigerants.")
            End If

            r._fordb = ref

            Return r
        End Function

        ReadOnly Property for_db As String
            Get
                Return _fordb
            End Get
        End Property

        Public Const NO_TD_VALUE = -9999
        Public Function coil_capacity_multiplier(Optional ByVal td As Double = NO_TD_VALUE) As Double

            If td = NO_TD_VALUE Then
                coil_capacity_multiplier = cm
            Else

                Select Case Me.parse(Me.value)
                    Case R410a, R22, R134a, R507, R404a
                        coil_capacity_multiplier = cm
                    Case Else
                        coil_capacity_multiplier = cm + (0.024083759556601834 - (1.9228 * (System.Math.E ^ (-0.146 * td))))
                        ' 2/29/16

                        If coil_capacity_multiplier < 0.01 Then coil_capacity_multiplier = 0.01

                End Select

            End If






        End Function

        Overrides Function toString() As String
            Return value
        End Function

        Public cm, sc, q, w, a As Double
        'Public cm, w, a, q As Double


        Private _fordb As String
    End Class

    Partial Public Class refrigerant
        Inherits listing(Of String)

        Protected Sub New(ByVal description As String, ByVal coil_capacity_multiplier As Double, Optional ByVal subcooling_factor As Double = 2, _
                          Optional ByVal q As Double = 1, Optional ByVal w As Double = 1, Optional ByVal a As Double = 1)
            MyBase.new(description)
            cm = coil_capacity_multiplier
            sc = subcooling_factor
            Me.q = q
            Me.w = w
            Me.a = a
        End Sub
    End Class

End Namespace