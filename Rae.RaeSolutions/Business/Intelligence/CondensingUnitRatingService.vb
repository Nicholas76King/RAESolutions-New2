Option Strict Off

Imports rae.Data.Access
Imports rae.RaeSolutions.Business.Entities
Imports rae.solutions
Imports rae.solutions.compressors

Namespace Rae.RaeSolutions.Business.Intelligence

    Public Class CondensingUnitRatingService
        Private compressor_repo As i_compressor_repository

        Sub New(ByVal compressor_repo As i_compressor_repository)
            Me.compressor_repo = compressor_repo
        End Sub

        Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal suction As Double, ByVal overrideSafetyLimit As Boolean, ByVal constantReturnGasTemp As String) As List(Of compressor)
            Dim compressors = compressor_repo.get_compressors(refrigerant, voltage, suction, "Condenser", overrideSafetyLimit, constantReturnGasTemp)
            compressors.sort(New Comparison(Of compressor)(AddressOf sort_compressors))
            Return compressors
        End Function

        Private Function sort_compressors(ByVal x As compressor, ByVal y As compressor) As Integer
            If x.model < y.model Then
                Return -1
            ElseIf x.model = y.model Then
                Return 0
            Else
                Return 1
            End If
        End Function

        Function GetFans() As List(Of Fan)
            Return rae.solutions.condensers.condenser_repository.GetCondensingUnitFans()
        End Function

        Function SelectDefaultFan(ByVal fanID As String, ByVal hp As Decimal, ByVal altitude As Decimal, ByVal junk As Decimal) As Fan
            Dim fileName = FanIntel.SelectStandardFile(fanID, altitude, hp, 1)
            Dim fan = getFan(fileName, hp)
            Return fan
        End Function

        'note: fan may have received 24" to 28" high altitude upgrade
        '      so omit diameter from selection criteria
        'note: there are 2 F1082029.11 files with different hp
        '      so include hp in selection criteria when selecting F1082029.11
        Private Function getFan(ByVal fileName As String, ByVal hp As Decimal) As Fan
            Dim fans = GetFans()
            For Each fan In fans
                If fileName = fan.FileName Then
                    If fileName = "F1082029.11" Then
                        If hp = fan.Hp Then
                            Return fan
                        End If
                    Else
                        Return fan
                    End If
                End If
            Next
        End Function

    End Class

End Namespace