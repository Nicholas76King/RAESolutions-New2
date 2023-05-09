Imports rae.solutions.drawings
Imports Rae.RaeSolutions.DataAccess
Imports System.Collections.Generic

<TestClass()> _
Public Class DrawingRepoTests : Inherits Test_context
	
Private Shared rules As List(Of Rule)

<ClassInitialize()> _
Shared Sub when_layer_is_1_fan_h1(ctx As TestContext)
   Dim repo = New DrawingRepo(New SharedConnectionFactory(Common.DrawingDataDbPath))
   Dim layer = "1 FAN H1"
   
   rules = repo.GetRulesFor(layer)
End Sub
	
<TestMethod()> _
Sub then_there_should_be_30_rules
	IsTrue(rules.Count = 30)
End Sub

<TestMethod()> _
Sub then_data_for_position_1_
   Dim rule = rules.Find( Function(r) r.Position = 1 )
   
	IsTrue( rule.State = "On" )
	IsTrue( rule.Qualifier = "Model" )
	IsTrue( rule.Operator = "EQ" )
	IsTrue( rule.Value = "20A0LS3" )
	IsTrue( rule.Conjunction = "AND" )
End Sub

End Class
