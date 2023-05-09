Option Strict On
Option Explicit On 


Imports Data = System.Data
Imports GlycolNames = Rae.RaeSolutions.DataAccess.Chillers.GlycolColumnNames
Imports rae.solutions.chillers
Imports rae.solutions.air_cooled_chillers.chiller
Imports Rae.Math.comparisons


Namespace Rae.RaeSolutions.Business.Intelligence.Chillers


Public Class ChillerIntel


   Shared Sub SelectEvaporatorTempRange(leavingTemp As Double, _
   ByRef lowerEvaporatorTemp As Double, ByRef upperEvaporatorTemp As Double)
      ' determines whether leaving fluid temperature is in range
      If is_among(leavingTemp, LEAVING_FLUID_TEMP_LOWER_LIMIT, LEAVING_FLUID_TEMP_UPPER_LIMIT) Then
         ' sets leaving fluid temperature lower bound to next lower number divisible by 5 then subtracts 10
         lowerEvaporatorTemp = System.Math.Floor(leavingTemp / 5) * 5 - 10
         ' sets leaving fluid temperature upper bound to 15 more than lower bound (next higher number divisible by 5)
         upperEvaporatorTemp = lowerEvaporatorTemp + 15
      Else
         ' TODO: throw business (out of range) exception
      End If
   End Sub

   ' todo: design so that manually conversions aren't necessary
   Shared Function ConvertStringToSeries(seriesString As String) As Series
      Dim seriesEnum As Series

      Select Case seriesString
         Case "24W0" : seriesEnum = Series.n_24W0
         Case "30A0" : seriesEnum = Series.n_30A0
         Case "30A1" : seriesEnum = Series.n_30A1
         Case "30A2" : seriesEnum = Series.n_30A2
         Case "34W0" : seriesEnum = Series.n_34W0
         Case "35E0" : seriesEnum = Series.n_35E0
         Case "35E1" : seriesEnum = Series.n_35E1
         Case "RECH" : seriesEnum = Series.n_RECH
         Case Else : Throw New ArgumentException("The chiller series is invalid. The series cannot be converted to an enum.")
      End Select

      Return seriesEnum
   End Function

   Shared Function ConvertSeriesToString(seriesEnum As Series) As String
      Dim _series As String

      Select Case seriesEnum
         Case Series.n_24W0 : _series = "24W0"
         Case Series.n_30A0 : _series = "30A0"
         Case Series.n_30A1 : _series = "30A1"
         Case Series.n_30A2 : _series = "30A2"
         Case Series.n_35E0 : _series = "35E0"
         Case Series.n_35E1 : _series = "35E1"
         Case Series.n_RECH : _series = "RECH"

         Case series.All : _series = "*"
         Case Else : _series = "*"
      End Select

      Return _series
   End Function


   ''' <summary>Selects multiplier for refrigerant parameter</summary>
   Shared Function SelectRefrigerantMultiplier(refrigerant As String) As Double
      dim multiplier as double = 1

      if refrigerant like "*22*"
         multiplier = 1
      elseif refrigerant like "*407*"
         multiplier = 0.99
      elseif refrigerant like "*134*"
         multiplier = 0.94
      elseif refrigerant like "*407*"
         multiplier = 0.985
      elseif refrigerant like "*507*"
         multiplier = 0.985
      end if
      
      return multiplier
   end function

   ''' <summary>Adjusts condenser capacity based on the refrigerant</summary>
   ''' <param name="refrigerantAbbreviation">Abbreviation of refrigerant (ex. 22, 22H)</param>
   Shared Function AdjustCondenserCapacityForRefrigerant(condenserCapacity As Double, refrigerantAbbreviation As String) As Double
      Dim refrigerantMultiplier = ChillerIntel.SelectRefrigerantMultiplier(refrigerantAbbreviation)
      Dim adjustedCapacity As Double = condenserCapacity * refrigerantMultiplier
      Return adjustedCapacity
   End Function


   Shared Function AdjustCondenserCapacityForSubCooling(condenserCapacity As Double, subCoolingPercentage As Double) As Double
      Dim adjustedCapacity = condenserCapacity * (1 - (subCoolingPercentage / 100))
      Return adjustedCapacity
   End Function

End Class

End Namespace
