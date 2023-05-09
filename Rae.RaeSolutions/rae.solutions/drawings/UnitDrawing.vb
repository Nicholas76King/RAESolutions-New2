Imports Rae.RaeSolutions.Business.Entities

Namespace rae.solutions.drawings

Public Class UnitDrawing : Inherits DrawingBase 
   
   Sub New(unit As EquipmentItem, targetUserGroup As user_group)
      MyBase.New(DrawingType.Unit, unit, targetUserGroup)

            Me.EstimatedOperatingWeight = unit.common_specs.OperatingWeight.value_or_default
      Me.EstimatedShipWeight = unit.common_specs.ShippingWeight.value_or_default
      Me.Disconnect = "Internal"
      Me.UnitHeight = unit.common_specs.Height.value_or_default
      If TypeOf unit Is PumpEquipment Then
         Dim pumpPackage = CType(unit, PumpEquipment)
         GPM = pumpPackage.Flow.value_or_default
      Else
         GPM = 0
      End If
      If TypeOf unit Is chiller_equipment Then
         Dim chiller = CType(unit, chiller_equipment)
         If chiller.has_pump_package Then
            GPM = chiller.pump_package.Flow.value
            Dim pumpPackage as New PumpPackageWeightCalculator(chiller.pump_package, repo)
            EstimatedShipWeight      += pumpPackage.ShippingWeight
            EstimatedOperatingWeight += pumpPackage.OperatingWeight
         End If
      End If
      If TypeOf unit Is unit_cooler Then
         Dim uc = CType(unit, unit_cooler)
         If uc.liquid_line_connection_quantity.has_value Then
            LiquidLineConnectionQuantity = uc.liquid_line_connection_quantity.ToString()
         Else
            LiquidLineConnectionQuantity = "NA"
         End If
      End If

      Me.setConnectionSizes()
      Me.setElectricalInfo()
   End Sub


   Property UnitHeight As Double
   Property EstimatedShipWeight As Double
   Property EstimatedOperatingWeight As Double
   Property Disconnect As String
   Property GPM As Double
   Property LiquidLineConnectionQuantity As String

End Class

End Namespace