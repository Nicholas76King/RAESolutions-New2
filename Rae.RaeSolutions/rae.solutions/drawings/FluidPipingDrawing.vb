imports Rae.RaeSolutions.Business.Entities

Namespace rae.solutions.drawings

Public Class FluidPipingDrawing : Inherits DrawingBase
   Sub New(unit As EquipmentItem, targetUserGroup As user_group)
      MyBase.New(DrawingType.FluidPiping, unit, targetUserGroup)
      
      If TypeOf unit Is PumpEquipment
         GPM = CType(unit, PumpEquipment).Flow.value_or_default
      ElseIf TypeOf unit Is chiller_equipment
         Dim chiller = CType(unit, chiller_equipment)
         If chiller.has_pump_package Then _
            GPM = chiller.pump_package.Flow.value_or_default
      End If
   End Sub
   
   Property GPM As Double
   	Get
   		Return _gpm
   	End Get
   	Set(value As Double)
   		_gpm = value
   	End Set
   End Property
   
   Private _gpm As Double
End Class

End Namespace