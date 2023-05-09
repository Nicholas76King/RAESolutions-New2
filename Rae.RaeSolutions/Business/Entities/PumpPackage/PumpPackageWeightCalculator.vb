Option Strict Off

Imports Rae.Collections
Imports Rae.RaeSolutions.Business.Entities

Namespace rae.solutions.drawings

Public Class PumpPackageWeightCalculator

   Sub New(pumpPackage As PumpEquipment, drawingRepo As i_drawing_repository)
      Dim flow    = New FlowRange().LimitFor(pumpPackage.Flow.value)
      Dim weights = drawingRepo.GetPumpPackageWeights(flow)
      calculateWeight(pumpPackage, weights)
   End Sub

   Public OperatingWeight, ShippingWeight As Double


   Private storageTankCodes As List(Of String)

   Private Sub calculateWeight(pumpPackage As PumpEquipment, weightOf As PumpPackageWeights)
      Dim hasTank  = pumpPackage.options.Exists(AddressOf tank)
      
      If pumpPackage.System = PumpSystem.Single
         ShippingWeight  = weightOf.BaseWithSinglePump
         OperatingWeight = weightOf.BaseWithSinglePump + weightOf.FluidInPipe
      ElseIf pumpPackage.System = PumpSystem.Dual
         ShippingWeight  = weightOf.BaseWithDualPump
         OperatingWeight = weightOf.BaseWithDualPump + weightOf.FluidInPipe
      End If

      If hasTank
         ShippingWeight  += weightOf.EmptyTank
         OperatingWeight += weightOf.FullTank
      End If
      
      ShippingWeight  *= 1.1
      OperatingWeight *= 1.1
   End Sub

   Private Function tank(op as EquipmentOption) As Boolean
      Dim tankCode = New TankCode()
      If tankCode.Matches(op.Code) Then _
         Return True
   End Function

End Class

End Namespace