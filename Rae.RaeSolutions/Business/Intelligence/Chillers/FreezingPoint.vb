Imports Rae.Math.comparisons
Imports Rae.RaeSolutions.DataAccess.Chillers
Imports Intelligence = Rae.RaeSolutions.Business.Intelligence
Imports Rae.Solutions.Chillers
Imports System.Math


' TODO: move to business entities namespace
Namespace Rae.RaeSolutions.Business.Intelligence.Chillers

''' <summary>Calculates freezing temperature for a given glycol percentage and glycol type</summary>
''' <remarks>All temperatures are supplied in Fahrenheit.</remarks>
''' <history>[CASEYJ]	9/8/2005	Created</history>
Public Class FreezingPoint

   Private _glycol As Glycol
   Private _glycolPerc, _freezingPoint, _minSuctionTemp As Double

#Region " Properties"

   ''' <summary>The smallest valid glycol percentage allowed</summary>
   Shared ReadOnly Property GlycolPercentageLowerBound() As Double
      Get
         Return 0.0
      End Get
   End Property

   ''' <summary>The largest valid glycol percentage allowed</summary>
   Public Shared ReadOnly Property GlycolPercentageUpperBound() As Double
      Get
         Return 60.0
      End Get
   End Property

   ''' <summary>Temperature in Fahrenheit at which water freezes</summary>
   Shared ReadOnly Property FreezingPointForWater As Double
      Get
         Return 32.0
      End Get
   End Property

   ''' <summary>Recommended minimum suction temperature for water</summary>
   Shared ReadOnly Property RecommendedMinSuctionTemperatureForWater As Double
      Get
         Return 33.0
      End Get
   End Property

   ''' <summary>Glycol used in freezing point calculations</summary>
   Property Glycol As Glycol
      Get
         Return _glycol
      End Get
      Set(value As Glycol)
         _glycol = value
      End Set
   End Property

   ''' <summary>Glycol percentage used in freezing point calculations</summary>
   ''' <remarks>Example: 10 = 10% not .1 = 10%</remarks>
   Property GlycolPercentage As Double
      Get
         Return _glycolPerc
      End Get
      Set(value As Double)
         _glycolPerc = value
      End Set
   End Property

   ''' <summary>The temperature in Fahrenheit at which the fluid freezes.</summary>
   ReadOnly Property FreezingPoint As Double
      Get
         Return _freezingPoint
      End Get
   End Property

   ''' <summary>The recommended minimum suction temperature (in Fahrenheit) for the fluid</summary>
   ReadOnly Property RecommendedMinSuctionTemperature As Double
      Get
         Return _minSuctionTemp
      End Get
   End Property

#End Region


#Region " Public methods"

   ''' <summary>Constructs a freezing point object. Calculates freezing point and sets properties.</summary>
   ''' <param name="glycol">The glycol type ex. Ethylene or Propylene</param>
   ''' <param name="glycolPercentage">The percentage of glycol</param>
   ''' <remarks>There is no need to call the CalculateFreezingPoint method after constructing object; 
   ''' the method is called during construction.</remarks>
   Sub New(glycol As Glycol, glycolPercentage As Double)
      _glycol = glycol
      _glycolPerc = glycolPercentage

      calculate()
   End Sub
   
   ''' <summary>Checks if glycol percentage parameter is valid range</summary>
   Shared Function IsGlycolPercentageOutsideRange(glycolPercentage As Double) As Boolean
      ' checks glycol percentage is in proper range
      Return is_outside(glycolPercentage, GlycolPercentageLowerBound, GlycolPercentageUpperBound)
   End Function


   ''' <summary>Calculates freezing point in Fahrenheit</summary>
   ''' <remarks>Retrieves freezing point from database and then interpolates.</remarks>
   Private Sub calculate()
      ' recommended glycol percentages
      Dim currentPerc, nextPerc As Double
      Dim currentFreezingPoint, nextFreezingPoint, freezingPoint As Double
      ' recommended minimum suction temperatures
      Dim currentMinSuctionTemp, nextMinSuctionTemp, minSuctionTemp As Double
      Dim freezingPointPerPercent, suctionTempPerPerc As Double
      Dim glycolTable As System.Data.DataTable

      ' retrieves glycol (ethylene, propylene) data from appropriate table
      If _glycol = Glycol.Ethylene Then
         glycolTable = ChillerDataAccess.RetrieveEthylene()
      ElseIf Me._glycol = Glycol.Propylene Then
         glycolTable = ChillerDataAccess.RetrievePropylene()
      Else
         Throw New System.Exception("No glycol selected.")
      End If

      ' loops until glycol percentage is between the recommended glycol percentages in table
      ' Note: using (i + 1) so don't step through last index i.e. don't iterate past (count - 2)
      For i As Integer = 0 To glycolTable.Rows.Count - 2
         currentPerc = CDbl(glycolTable.Rows(i)(GlycolColumnNames.RecommendedGlycolPercentage))
         nextPerc    = CDbl(glycolTable.Rows(i + 1)(GlycolColumnNames.RecommendedGlycolPercentage))

         ' checks if glycol percentage is between the recommended glycol percentages
         If is_in_range(GlycolPercentage, currentPerc, nextPerc) Then
            currentFreezingPoint = CDbl(glycolTable.Rows(i)(GlycolColumnNames.FreezingPoint))
            nextFreezingPoint = CDbl(glycolTable.Rows(i + 1)(GlycolColumnNames.FreezingPoint))
            currentMinSuctionTemp = CDbl(glycolTable.Rows(i)(GlycolColumnNames.RecommendedMinSuctionTemperature))
            nextMinSuctionTemp = CDbl(glycolTable.Rows(i + 1)(GlycolColumnNames.RecommendedMinSuctionTemperature))

            ' calculates freeze point per glycol percentage
            freezingPointPerPercent = (currentFreezingPoint - nextFreezingPoint) / (nextPerc - currentPerc)

            ' calculates freeze point at entered glycol percentage
            freezingPoint = currentFreezingPoint _
               - (GlycolPercentage - currentPerc) * freezingPointPerPercent

            ' calculates suction temperature per one percent glycol
            suctionTempPerPerc = (currentMinSuctionTemp - nextMinSuctionTemp) / (nextPerc - currentPerc)

            ' calculates recommended suction temperature at the entered glycol percentage
            minSuctionTemp = currentMinSuctionTemp - ((GlycolPercentage - currentPerc) * suctionTempPerPerc)

            _freezingPoint  = Round(freezingPoint, 1)
            _minSuctionTemp = Round(minSuctionTemp, 1)
            Exit For
         End If
      Next
   End Sub

#End Region

End Class

End Namespace