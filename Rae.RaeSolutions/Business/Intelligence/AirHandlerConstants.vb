Imports Rae.RaeSolutions.Business
Imports Rae.Math.comparisons
Imports System

Namespace Rae.RaeSolutions.Business.Intelligence

   ''' <summary>
   ''' Constants used by air handler. Will need to be updated periodically.
   ''' </summary>
   ''' <history by="Casey Joyce" start="2006/05/24" finish="2006/05/25" hours="6">
   ''' Created, encapsulated air handler constants into this class.
   ''' </history>
   Public Class AirHandlerConstants


      ''' <summary>
      ''' Database multipliers used to secure pricing in databases.
      ''' </summary>
      ''' <remarks>
      ''' Prices in database are multiplied these multipliers.
      ''' So divide by these multipliers to get true price.
      ''' </remarks>
      Public Class DatabaseMultipliers
         Public Const COIL As Double = 2.6
         Public Const HOURS As Double = 2.3
         Public Const BALDOR_MOTOR As Double = 0.38
         Public Const MOTOR As Double = 2.5
         Public Const BIDI_FAN As Double = 2.8
         ''' <summary>
         ''' Forward curved fan multiplier.
         ''' </summary>
         Public Const FC_FAN As Double = 2.8
         Public Const PLENUM_FAN As Double = 2.8
         Public Const DUCT_HEATER As Double = 2.4
         Public Const FILTER As Double = 2.1
         Public Const DAMPER As Double = 2
      End Class


      ''' <summary>
      ''' Costs and weights of air handler materials.
      ''' </summary>
      ''' <remarks>
      ''' weights are in #/ft^2
      ''' </remarks>
      Public Class Weights

         Public Const PANEL_INSULATION_WEIGHT As Double = 0.5
         Public Const PAINT_WEIGHT_PER_GALLON As Double = 8
         ''' <summary>
         ''' Weight of door hardware.
         ''' </summary>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 20 to 25
         ''' </history>
         Public Const DOOR_WEIGHT As Double = 25
         Public Const FLOOR_INSULATION_WEIGHT As Double = 0.5
         Public Const EXTERIOR_WEIGHT As Double = 2.65
         Public Const INTERIOR_WEIGHT As Double = 2.15
         Public Const AIR_SEAL_WEIGHT As Double = 2.65
         Public Const SHEET_METAL_FLOOR_WEIGHT As Double = 3.2
         Public Const SHEET_METAL_BASE_WEIGHT As Double = 5.7
         Public Const STEEL_BASE_WEIGHT As Double = 8.2
         Public Const STEEL_BASE_FLOOR_WEIGHT As Double = 2.65
         Public Const STEEL_BASE_SUB_FLOOR_WEIGHT As Double = 1.67

      End Class


      ''' <summary>
      ''' Costs included in air handler pricing.
      ''' </summary>
      ''' <remarks>
      ''' costs are in cost/ft^2
      ''' see Jay on these costs
      ''' </remarks>
      Public Class Costs

#Region " Constants"

         ''' <summary>
         ''' Panel insulation cost per square foot.
         ''' </summary>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 0.4 to 1.166
         ''' </history>
         Public Const PANEL_INSULATION_COST As Double = 1.166

         ''' <summary>
         ''' Floor insulation cost per square foot.
         ''' </summary>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 0.4 to 1.166
         ''' </history>
         Public Const FLOOR_INSULATION_COST As Double = 1.166

         ''' <summary>
         ''' Cost of paint per gallon.
         ''' </summary>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 30 to 35
         ''' </history>
         Public Const PAINT_COST_PER_GALLON As Double = 35

         ''' <summary>
         ''' Cost of door.
         ''' </summary>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 50 to 75
         ''' </history>
         Public Const DOOR_COST As Double = 75

         ''' <summary>
         ''' Cost of exterior material, 16 gauge galvanized, per square foot.
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 0.79 to 1.18
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 1.18 to 1.31
         ''' </history>
         Public Const EXTERIOR_COST As Double = 1.31

         ''' <summary>
         ''' Cost of interior material, 18 gauge galvanized, per square foot.
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 0.66 to 0.97
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 0.97 to 1.066
         ''' </history>
         Public Const INTERIOR_COST As Double = 1.066

         ''' <summary>
         ''' Cost of air seal, 16 gauge galvanized.
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 0.79 to 1.18
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 1.18 to 1.71
         ''' </history>
         Public Const AIR_SEAL_COST As Double = 1.71

         ''' <summary>
         ''' Cost of sheet metal floor, 14 gauge galvanized.
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 0.99 to 1.46
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 1.46 to 1.61
         ''' </history>
         Public Const SHEET_METAL_FLOOR_COST As Double = 1.61

         ''' <summary>
         ''' Cost of sheet metal base, 10 gauge galvanized.
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 1.76 to 2.74
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 2.74 to 2.96
         ''' </history>
         Public Const SHEET_METAL_BASE_COST As Double = 2.96

         ''' <summary>
         ''' Cost of steel base, C6 x 8.2 channel, per square foot.
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 1.49 to 2.99
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 2.99 to 3.102
         ''' </history>
         Public Const STEEL_BASE_COST As Double = 3.102

         ''' <summary>
         ''' Cost of floor with steel base, 16 gauge galvanized.
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 0.79 to 1.18.
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 1.18 to 1.31
         ''' </history>
         Public Const STEEL_BASE_FLOOR_COST As Double = 1.31

         ''' <summary>
         ''' Cost of sub floor with steel base, 20 gauge galvanized
         ''' </summary>
         ''' <history finish="2005/02/01">
         ''' Updated from 0.5 to 0.75
         ''' </history>
         ''' <history by="Casey Joyce" finish="2006/08/04">
         ''' Updated from 0.75 to 0.84
         ''' </history>
         Public Const STEEL_BASE_SUB_FLOOR_COST As Double = 0.84

#End Region


#Region " Methods"

         ''' <summary>
         ''' Cost of blender used in air handler.
         ''' </summary>
         ''' <remarks>
         ''' The blender cost returned is only for one blender even if model contains multiple blenders.
         ''' </remarks>
         ''' <param name="model">
         ''' Air handler model.
         ''' </param>
         Public Shared ReadOnly Property BlenderCost(ByVal model As String) As Double
            Get
               Dim cost As Double

               Select Case model
                  Case "TPAH-4"
                     cost = 208
                  Case "TPAH-5", "TPAH-7", "TPAH-8", "TPAH-10"
                     cost = 212
                  Case "TPAH-6"
                     cost = 221
                  Case "TPAH-11", "TPAH-12"
                     cost = 214
                  Case "TPAH-15"
                     cost = 226
                  Case "TPAH-18"
                     cost = 271
                  Case "TPAH-22", "TPAH-24"
                     cost = 314
                  Case "TPAH-28"
                     cost = 382
                  Case "TPAH-32"
                     cost = 501
                  Case "TPAH-38"
                     cost = 608
                  Case "TPAH-44", "TPAH-50", "TPAH-58"
                     cost = 653
                  Case Else
                     Throw New ArgumentException("Blender cost cannot be determined. Air handler model, " & model.ToString & ", is invalid.")
               End Select

               Return cost
            End Get
         End Property

#End Region

      End Class


      ''' <summary>
      ''' Multipliers to calculate costs.
      ''' </summary>
      ''' <history start="2006/05/24" hours="2">
      ''' Created
      ''' </history>
      Public Class Multipliers

#Region " Constants"

         ''' <summary>
         ''' Percentage to add to account for scrap material.
         ''' </summary>
         ''' <history>
         ''' 2/1/05 - was 0.1
         ''' </history>
         Public Const SCRAP As Double = 0.15

         ''' <summary>
         ''' Blender markup used to calculate blender cost. 
         ''' BlenderCost = BlenderBaseCost * BLENDER_MULTIPLIER
         ''' </summary>
         ''' <remarks>
         ''' from Jay Kindle
         ''' </remarks>
         Public Const BLENDER_MULTIPLIER As Double = 1.15

         ''' <summary>
         ''' Filter multiplier used to calculate filter cost.
         ''' FilterCost = FilterListPrice * FILTER_MULTIPLIER
         ''' </summary>
         Public Const FILTER_MULTIPLIER As Double = 0.45

         ''' <summary>
         ''' Vent Products Company multiplier used when calculating damper cost.
         ''' DamperCost = DamperCost * VENT_PRODUCTS_CO_MULTIPLIER.
         ''' </summary>
         Public Const VENT_PRODUCTS_CO_MULTIPLIER As Double = 0.56

         ''' <summary>
         ''' Miscellaneous material multiplier for steel base.
         ''' MaterialCost = MaterialCost * (1 + MiscMaterialMultiplier)
         ''' </summary>
         Public Const STEEL_BASE_MISC_MULTIPLIER As Double = 0.1

         ''' <summary>
         ''' Housed fan multiplier.
         ''' </summary>
         Public Const HOUSED_FAN_MULTIPLIER As Double = 1.1

#End Region


#Region " Methods"

         ''' <summary>
         ''' Damper multiplier used to calculate damper cost.
         ''' DamperCost = DamperCost * DamperMultiplier
         ''' </summary>
         ''' <param name="outsideAirHeight">
         ''' Height of outside air opening.
         ''' </param>
         ''' <param name="roomAirHeight">
         ''' Height of room air opening.
         ''' </param>
         Public Shared ReadOnly Property DamperMultiplier(ByVal outsideAirHeight As Integer, ByVal roomAirHeight As Integer) As Double
            Get
               Dim multiplier As Double

               If outsideAirHeight < 24 Or roomAirHeight < 24 Then
                  multiplier = 1.25
               ElseIf is_in_range(outsideAirHeight, 24, 36) _
               OrElse is_in_range(roomAirHeight, 24, 36) Then
                  multiplier = 1.2
               ElseIf is_in_range(outsideAirHeight, 36, 48) _
               OrElse is_in_range(roomAirHeight, 36, 48) Then
                  multiplier = 1.15
               ElseIf outsideAirHeight >= 48 OrElse roomAirHeight >= 48 Then
                  multiplier = 1.1
               End If

               Return multiplier
            End Get
         End Property


         ''' <summary>
         ''' Tube multiplier based on tube thickness used to calculate cost of tube.
         ''' </summary>
         ''' <param name="thickness">
         ''' Tube thickness in inches.
         ''' </param>
         Public Shared ReadOnly Property TubeMultiplier(ByVal thickness As Double) As Double
            Get
               Dim multiplier As Double

               If thickness = 0.025 Then
                  multiplier = 2.4
               ElseIf thickness = 0.035 Then
                  multiplier = 6.24
               ElseIf thickness = 0.049 Then
                  multiplier = 12.88
               Else
                  multiplier = 0
               End If

               Return multiplier
            End Get
         End Property

#End Region

      End Class




      ''' <summary>
      ''' Hourly wage in dollars.
      ''' </summary>
      ''' <history finish="2005/02/01">
      ''' Updated
      ''' </history>
      ''' <history by="Casey Joyce" finish="2006/08/04">
      ''' Updated from 24.15 to 24.40
      ''' </history>
      Public Const HOURLY_WAGE As Double = 25

      ''' <summary>
      ''' Hourly wage for coil labor in dollars.
      ''' </summary>
      Public Const COIL_HOURLY_WAGE As Double = 23.85

   End Class

End Namespace