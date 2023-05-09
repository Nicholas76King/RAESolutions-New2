Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Business.Entities.PumpSystem

<TestClass()> _
Public Class Test_context

   Property Context As TestContext
      Get
         Return _context
      End Get
      Set(value As TestContext)
         _context = value
      End Set
   End Property

   Private _context As TestContext
   
End Class


<TestClass()> _
Public Class Pump_package_context : Inherits Test_context

   Protected Shared pumpPackage As PumpData
   Protected Shared bellAndGossett As String = "Bell and Gossett Pumps"

   Shared Sub Given_a_pump_package_with_(mfg As String, gpm As Double, head As Double, system As PumpSystem)
      Dim r = PumpRepoFactory.Create
      pumpPackage = r.GetPump(mfg, gpm, head, system)
   End Sub

End Class

<TestClass()> _
Public Class Given_a_pump : Inherits Pump_package_context

   <ClassInitialize()> _
   Shared Sub when_gpm_is_20_and_head_is_50_and_it_is_a_single_pump_system(context As TestContext)
      Given_a_pump_package_with_(mfg:=bellAndGossett, gpm:=20, head:=50, system:=[Single])
   End Sub

   <TestMethod()> _
   Sub then_list_price_should_be_10209
	   IsTrue( pumpPackage.BaseListPrice = 10209 )
   End Sub

   <TestMethod()> _
   Sub then_pipe_size_should_be_1_inch
	   IsTrue( pumpPackage.PipeSize = 1 )
   End Sub

   <TestMethod()> _
   Sub then_motor_hp_should_be_1()
	   IsTrue( pumpPackage.HP = 1 )
   End Sub

   <TestMethod()> _
   Sub then_rpm_and_model_and_efficiency_should_be_correct()
	   IsTrue( pumpPackage.RPM = 1750 )
	   IsTrue( pumpPackage.Model = "1AAB" )
	   IsTrue( pumpPackage.Efficiency = 38 )
   End Sub

End Class
