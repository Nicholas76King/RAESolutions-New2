Imports Rae.Math.Comparisons
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass> _
Public Class for_water_specific

   Private specific As Specific

   <TestInitialize> _
   Sub init
      specific = New Specific(Fluid.Water, 0, 54, 44)
   End Sub
   
   <TestMethod, Ignore> _
   Sub gravity_is_1p0004
      IsTrue( IsAccurate(specific.Gravity, 0.01, 1.0004) )
   End Sub
   
   <TestMethod, Ignore> _
   Sub heat_is_1p0043
      IsTrue( IsAccurate(specific.Heat, 0.01, 1.0043) )
   End Sub
   
End Class

<TestClass> _
Public Class for_ethylene_20_specific
   
   Private specific As Specific
   
   <TestInitialize> _
   Sub init
      specific = New Specific(Fluid.Ethylene, 20, 54, 44)
   End Sub
   
   <TestMethod, Ignore> _
   Sub gravity_is_1p033
      IsTrue( IsAccurate(specific.Gravity, 0.01, 1.03304) )
   End Sub
   
   <TestMethod, Ignore> _
   Sub heat_is_0p9054
      IsTrue( IsAccurate(specific.Heat, 0.01, 0.9054) )
   End Sub
   
End Class

<TestClass> _
Public Class for_propylene_30_specific
   
   Private specific As Specific
   
   <TestInitialize> _
   Sub init
      specific = New Specific(Fluid.Propylene, 30, 54, 44)
   End Sub
   
   <TestMethod, Ignore> _
   Sub heat_is_0p9121
      IsTrue( IsAccurate(specific.Heat, 0.01, 0.9121) )
   End Sub
   
   <TestMethod, Ignore> _
   Sub gravity_is_1p0327
      IsTrue( IsAccurate(specific.Gravity, 0.01, 1.0327) )
   End Sub
   
End Class