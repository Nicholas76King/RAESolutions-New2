Imports Rae.Math
Imports Rae.RaeSolutions.DataAccess.Chillers
Imports System.Data
Imports System.Math
Imports GT1 = RAE.RAESolutions.DataAccess.Chillers.GlycolColumnNames

Namespace rae.solutions

MustInherit Class Glycol : Implements IFluid

   Sub New(percentage As Double)
      perc = percentage
      calc(perc)
   End Sub

   ReadOnly Property FreezePoint As Double _
   Implements IFluid.FreezePoint
      Get
         Return _freezePoint
      End Get
   End Property
   
   ReadOnly Property MinSuctionTemp As Double _
   Implements IFluid.MinSuctionTemp
      Get
         Return _minSuctionTemp
      End Get
   End Property
   
   ReadOnly Property Max As Double _
   Implements IFluid.Max
      Get
         Return 60
      End Get
   End Property

   ReadOnly Property Min As Double _
   Implements IFluid.Min
      Get
         Return 0
      End Get
   End Property

   Function IsInRange() As Boolean _
   Implements IFluid.PercentageInRange
      Return Rae.Math.comparisons.is_among(perc, Min, Max)
   End Function
   
   
   Private perc, _minSuctionTemp, _freezePoint As Double
   
   Private Sub calc(perc As Double)
      Dim glycolTable = getGlycolData()

      ' loops until glycol percentage is between the recommended glycol percentages in table
      ' Note: using (i + 1) so don't step through last index i.e. don't iterate past (count - 2)
      For i As Integer = 0 To glycolTable.Rows.Count - 2
                Dim currentPerc = CDbl(glycolTable.Rows(i)(GT1.RecommendedGlycolPercentage))
                Dim nextPerc = CDbl(glycolTable.Rows(i + 1)(GT1.RecommendedGlycolPercentage))

                ' checks if glycol percentage is between the recommended glycol percentages
                If comparisons.is_in_range(perc, currentPerc, nextPerc) Then
                    Dim currentFreezingPoint = CDbl(glycolTable.Rows(i)(GT1.FreezingPoint))
                    Dim nextFreezingPoint = CDbl(glycolTable.Rows(i + 1)(GT1.FreezingPoint))
                    Dim currentMinSuctionTemp = CDbl(glycolTable.Rows(i)(GT1.RecommendedMinSuctionTemperature))
                    Dim nextMinSuctionTemp = CDbl(glycolTable.Rows(i + 1)(GT1.RecommendedMinSuctionTemperature))

                    ' calculates freeze point per glycol percentage
                    Dim freezingPointPerPerc = (currentFreezingPoint - nextFreezingPoint) / (nextPerc - currentPerc)

            ' calculates freeze point at entered glycol percentage
            Dim freezingPoint = currentFreezingPoint - (perc - currentPerc) * freezingPointPerPerc

            ' calculates suction temperature per one percent glycol
            Dim suctionTempPerPerc = (currentMinSuctionTemp - nextMinSuctionTemp) / (nextPerc - currentPerc)

            ' calculates recommended suction temperature at the entered glycol percentage
            Dim minSuctionTemp = currentMinSuctionTemp - ((perc - currentPerc) * suctionTempPerPerc)

            _freezePoint  = Round(freezingPoint, 1)
            _minSuctionTemp = Round(minSuctionTemp, 1)
            Exit For
         End If
      Next
   End Sub
   
   MustOverride Protected Function getGlycolData() As DataTable

End Class

End Namespace