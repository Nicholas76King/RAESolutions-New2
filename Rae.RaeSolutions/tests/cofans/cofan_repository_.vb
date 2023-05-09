Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.Business.Entities.Cofans

Namespace Rae.RaeSolutions.Tests.Cofans

<TestClass> Public Class cofan_repository_
   Shared coil As coil

   <ClassInitialize> Shared Sub initialize(context As TestContext)
      set_defaults()
      Dim repository = New cofan_repository
      coil = repository.get_coil("2RCOND")
   End Sub

   <TestMethod()> Sub can_get_coil()
      Assert.IsTrue(coil.p(0) = 0.113527)
   End Sub

   <TestMethod()> Sub can_get_coil_type()
      Assert.IsTrue(coil.coil_type = "Condenser")
   End Sub

   <TestMethod()> Sub can_get_coil_diameter()
      Assert.IsTrue(coil.diameter = 0.5)
   End Sub

   <TestMethod()> Sub can_get_coil_f()
      With coil.at_fpi(0)
      Assert.IsTrue(.f(0) = 0.7453185)
      Assert.IsTrue(.f(1) = 0.00000000000008223945)
      Assert.IsTrue(.f(2) = -0.0000000006500312)
      Assert.IsTrue(.f(3) = 0.000001299211)
      Assert.IsTrue(.f(4) = -0.001226739)
      End With
   End Sub

   <TestMethod()> Sub can_get_coil_f2()
      Assert.IsTrue(coil.at_fpi(1).f(0) = 0.9841753)
   End Sub

   <TestMethod()> Sub can_get_coil_f3()
      Assert.IsTrue(coil.at_fpi(2).f(0) = 0.8548924)
   End Sub

   <TestMethod()> Sub can_get_coil_f4()
      Assert.IsTrue(coil.at_fpi(3).f(0) = 0.8575598)
   End Sub

   <TestMethod()> Sub can_get_coil_filename()
      Assert.IsTrue(coil.file_name = "2RCOND")
   End Sub

   <TestMethod()> Sub can_get_coil_fintype()
      Assert.IsTrue(coil.fin_type = "Waffle")
   End Sub

   <TestMethod()> Sub can_get_coil_fpi1()
      Assert.IsTrue(coil.at_fpi(0).fpi = 8)
   End Sub

End Class

End Namespace