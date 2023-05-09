<TestClass()> _
Public Class pump_package_model : Inherits Test_context
	
<TestMethod()> _
Sub always_includes_suffix_dash_H ' because its housed standard
   Dim model = "PPS120A50"
   Dim ops = New EquipmentOptionList(Nothing)
   
   Dim pp = New PumpPackageModel(model, ops).Dash
	IsTrue( pp = model & "-H")
End Sub

<TestMethod()> _
Sub when_has_tank_then_suffix_is_dash_TH
	Dim model = "PPS120A50"
	
   Dim ops     = New EquipmentOptionList(Nothing)
   Dim tankOp  = New EquipmentOption()
   tankOp.Code = "HT05"
   ops.Add(tankOp)
   
   Dim pp = New PumpPackageModel(model, ops).Dash
   IsTrue( pp = "PPS120A50-TH" )
End Sub

End Class
