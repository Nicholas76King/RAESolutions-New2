<TestClass()> _
Public Class TankOptionTests : Inherits Test_context

Private Shared op As TankOption

<ClassInitialize()> _
Shared Sub when_option_is_100_gallon_tank(ctx As TestContext)
   op = New TankOption("HT05","Chilled Water Storage Tank - Open Type 100")   
End Sub

<TestMethod()> _
Sub then_option_is_a_tank
   IsTrue( op.IsTank )
End Sub

<TestMethod()> _
Sub then_tank_size_is_100_gallons
	IsTrue( op.TankSize=100)
End Sub

End Class