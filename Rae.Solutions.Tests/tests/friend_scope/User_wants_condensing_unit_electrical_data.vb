Imports Drawings = rae.solutions.drawings
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Math.Comparisons
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

'Story:  User wants to get electrical data for condensing unit
'        such as RLA and MCA

'Public Class given_condensing_unit_and_voltage_and_et10_and_mc20
   
'   Shared Protected e As Drawings.CondensingUnitElectricalInfo

'   Shared Protected Sub calculate(model As String, voltage As Integer, phase As Integer, hertz As Integer, et10 As Boolean, mc20 As Boolean)
'      Dim service = New Drawings.DrawingService()
'      e = service.GetCondensingUnitElectricalInfo(model, voltage, phase, hertz, et10, mc20,  Rae.RaeSolutions.Division.CRI)
'   End Sub
   
'End Class


'<TestClass> _
'Public Class Given_model_is_DS08H2_and_voltage_is_230_3_60_and_et10_is_selected
'   Inherits given_condensing_unit_and_voltage_and_et10_and_mc20
   
'   <ClassInitialize> _
'   Shared Sub when_electrical_equations_are_calculated(context As TestContext)
'      calculate("DS08H2", 230, 3, 60, et10:=True, mc20:=False)
'   End Sub
   
'   <TestMethod> _
'   Sub then_rla_should_be_57
'      IsTrue(e.rla1 = 57)
'   End Sub
   
'   <TestMethod> _
'   Sub then_mca_should_be_65
'      IsTrue(e.mca1 = 65)
'   End Sub
   
'   <TestMethod> _
'   Sub then_number_of_circuits_should_be_1
'   	IsTrue(e.circuits = 1)
'   End Sub

'End Class

'<TestClass> _
'Public Class Given_model_is_DS08H2_and_voltage_is_230_3_60_and_et10_is_not_selected
'   Inherits given_condensing_unit_and_voltage_and_et10_and_mc20
   
'   <ClassInitialize> _
'   Shared Sub when_electrical_equations_are_calculated(context As TestContext)
'      calculate("DS08H2", 230, 3, 60, et10:=False, mc20:=False)
'   End Sub
   
'   <TestMethod> _
'   Sub then_rla_should_be_39
'      IsTrue(e.RLA1 = 47)
'   End Sub
   
'   <TestMethod> _
'   Sub then_mca_should_be_47
'      IsTrue(e.MCA1 = 55)
'   End Sub
   
'   <TestMethod> _
'   Sub then_number_of_circuits_should_be_1()
'   	IsTrue(e.Circuits = 1)
'   End Sub

'End Class

'<TestClass> _
'Public Class Given_model_is_DD30H2_and_voltage_is_460_3_60_and_et10_is_not_selected
'   Inherits given_condensing_unit_and_voltage_and_et10_and_mc20

'   <ClassInitialize> _
'   Shared Sub when_electrical_equations_are_calculated(context As TestContext)
'      calculate("DD30H2", 460, 3, 60, et10:=False, mc20:=False)
'   End Sub
   
'   <TestMethod> _
'   Sub then_rla_for_circuit_1_should_be_36
'      IsTrue(e.RLA1 = 44)
'      IsTrue(e.MCA1 = 51)
'   End Sub
   
'   <TestMethod> _
'   Sub then_rla_for_circuit_2_should_be_36
'   	IsTrue(e.RLA2 = 44)
'      IsTrue(e.MCA2 = 51)
'   End Sub
   
'End Class

'<TestClass> _
'Public Class Given_model_is_DD30H2_and_voltage_is_460_3_60_and_et10_is_selected
'   Inherits given_condensing_unit_and_voltage_and_et10_and_mc20
      
'   <ClassInitialize> _
'   Shared Sub when_electrical_calculations_are_calculated(context As TestContext)
'      calculate("DD30H2", 460,3,60, et10:=True, mc20:=False)
'   End Sub

'   <TestMethod> _
'   Sub then_rla_for_circuit_1_should_be_41
'   	IsTrue(e.RLA1 = 49) 'was 41
'   	IsTrue(e.MCA1 = 56) 'was 48
'   End Sub
   
'   <TestMethod> _
'   Sub then_rla_for_circuit_2_should_be_41
'   	IsTrue(e.RLA2 = 49)
'   	IsTrue(e.MCA2 = 56)
'   End Sub

'End Class

'<TestClass()> _
'Public Class Given_model_is_DD30H2_and_voltage_is_460_3_60_and_et10_and_mc20_are_selected
'   Inherits given_condensing_unit_and_voltage_and_et10_and_mc20
      
'   <ClassInitialize()> _
'   Shared Sub when_electrical_calculations_are_calculated(context As TestContext)
'      calculate("DD30H2", 460,3,60, et10:=True, mc20:=True)
'   End Sub

'   <TestMethod()> _
'   Sub then_rla_for_circuit_1_should_be_77
'   	IsTrue(e.RLA1 = 92)
'   	IsTrue(e.MCA1 = 99)
'   End Sub
   
'   <TestMethod()> _
'   Sub then_rla_for_circuit_2_should_be_0
'   	IsTrue(e.RLA2 = 0)
'   	IsTrue(e.MCA2 = 0)
'   End Sub

'End Class

'<TestClass()> _
'Public Class Given_model_is_DD30H2_and_voltage_is_460_3_60_and_et10_is_not_selected_and_mc20_is_selected
'   Inherits given_condensing_unit_and_voltage_and_et10_and_mc20
      
'   <ClassInitialize()> _
'   Shared Sub when_electrical_calculations_are_calculated(context As TestContext)
'      calculate("DD30H2", 460,3,60, et10:=False, mc20:=True)
'   End Sub

'   <TestMethod()> _
'   Sub then_rla_for_circuit_1_should_be_72
'   	IsTrue(e.RLA1 = 87)
'   	IsTrue(e.MCA1 = 94)
'   End Sub
   
'   <TestMethod()> _
'   Sub then_rla_for_circuit_2_should_be_0
'   	IsTrue(e.RLA2 = 0)
'   	IsTrue(e.MCA2 = 0)
'   End Sub

'End Class


'<TestClass()> _
'Public Class Given_model_is_DM90H2_and_voltage_is_460_3_60_without_mc20
'   Inherits given_condensing_unit_and_voltage_and_et10_and_mc20
      
'   <ClassInitialize()> _
'   Shared Sub when_electrical_calculations_are_calculated(context As TestContext)
'      calculate("DM90H2", 460,3,60, et10:=False, mc20:=False)
'   End Sub

'   <TestMethod()> _
'   Sub then_rla_for_circuit_1_should_be_165
'   	IsTrue(e.RLA1 = 169)
'   	IsTrue(e.MCA1 = 181)
'   End Sub
   
'   <TestMethod()> _
'   Sub then_rla_for_circuit_2_should_be_0
'   	IsTrue(e.RLA2 = 0)
'   	IsTrue(e.MCA2 = 0)
'   End Sub

'End Class