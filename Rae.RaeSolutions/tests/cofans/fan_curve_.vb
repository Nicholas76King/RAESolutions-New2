Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.Business.Entities.Cofans

Namespace Rae.RaeSolutions.Tests.Cofans

<TestClass> Public Class fan_curve_ : Inherits test

   <TestMethod> Sub for_BR28IN_fan
      set_defaults()
      
      Dim repository = New cofan_repository()

      Dim coef = repository.get_fan_curves("BR28IN")

      assert(coef(0) = 9727.634)
   End Sub

End Class

End Namespace