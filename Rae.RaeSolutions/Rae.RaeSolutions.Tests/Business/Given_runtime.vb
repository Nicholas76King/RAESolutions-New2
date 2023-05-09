<TestClass()> _
Public Class Given_runtime_in_valid_range : Inherits Test_context
	
Shared Protected warning As RuntimeWarning
	
<ClassInitialize()> _
Shared Sub when_flow_is_100_gpm_and_tank_size_is_800(ctx As TestContext)
   Dim flow=100
   Dim tank_size=800
   warning = New RuntimeWarning(flow, tank_size)
End Sub

<TestMethod()> _
Sub then_there_should_be_an_8_minute_runtime
	IsTrue( warning.Runtime = 8 )
End Sub

<TestMethod()> _
Sub then_warning_should_not_apply
	IsTrue( Not warning.Applies )
End Sub

<TestMethod()> _
Sub then_message_should_be_correct
	IsTrue(warning.Message = "Tank selected does not meet minimum 3-minute runtime. The remaining system volume must be covered by external piping. Contact factory.")
End Sub
End Class

<TestClass()> _
Public Class Given_runtime_out_of_range

Shared Protected warning As RuntimeWarning

<ClassInitialize> _
Shared Sub when_flow_is_200_gpm_and_tank_size_is_400(context As TestContext)
   warning=New RuntimeWarning(flow:=200,tankSize:=400)
End Sub

<TestMethod()> _
Sub then_there_should_be_a_2_minute_runtime
	IsTrue(warning.Runtime=2)
End Sub
<TestMethod()> _
Sub then_warning_applies
	IsTrue(warning.Applies)
End Sub
End Class
