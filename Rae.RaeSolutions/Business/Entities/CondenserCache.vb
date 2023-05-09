Imports Rae.solutions.condensers.condenser_repository

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>
    ''' Caches values from data source. Use Create method to create an instance (singleton).
    ''' </summary>
    Public Class CondenserCache

        Private Shared instance As CondenserCache

        Public Shared Function Create() As CondenserCache
            If instance Is Nothing Then
                instance = New CondenserCache()
            End If
            Return instance
        End Function

        Private Sub New()
            Me.CatalogRatingMultiplier = CDbl(RetrieveConstant("CatalogRatingMultiplier"))
            Me.R22Multiplier = CDbl(RetrieveConstant("R22Multiplier"))
            Me.R404aMultiplier = CDbl(RetrieveConstant("R404aMultiplier"))
            Me.R134aMultiplier = CDbl(RetrieveConstant("R134aMultiplier"))
            Me.R410aMultiplier = CDbl(RetrieveConstant("R410aMultiplier"))
            Me.R507Multiplier = CDbl(RetrieveConstant("R507aMultiplier"))

            Me.R407aMultiplier = CDbl(RetrieveConstant("R407aMultiplier"))
            Me.R407cMultiplier = CDbl(RetrieveConstant("R407cMultiplier"))
            Me.R407fMultiplier = CDbl(RetrieveConstant("R407fMultiplier"))
            Me.R448aMultiplier = CDbl(RetrieveConstant("R448aMultiplier"))
            Me.R449aMultiplier = CDbl(RetrieveConstant("R449aMultiplier"))
        End Sub


        Public ReadOnly CatalogRatingMultiplier As Double

        Public ReadOnly R22Multiplier As Double
        Public ReadOnly R404aMultiplier As Double
        Public ReadOnly R134aMultiplier As Double
        Public ReadOnly R410aMultiplier As Double
        Public ReadOnly R507Multiplier As Double

        Public ReadOnly R407aMultiplier As Double
        Public ReadOnly R407cMultiplier As Double
        Public ReadOnly R407fMultiplier As Double
        Public ReadOnly R448aMultiplier As Double
        Public ReadOnly R449aMultiplier As Double

    End Class

End Namespace