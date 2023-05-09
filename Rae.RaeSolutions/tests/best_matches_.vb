Imports rae.solutions
Imports rae.solutions.condensing_units
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass> _
Public Class best_matches_
   
   <TestMethod> _
   Sub gets_same_best_units_as_original_dll
      config.db
      
      Dim spec As Best_Matches.Spec
      spec.Capacity = 120000
      spec.compressor_quantity = 1
      spec.num_circuits = 1
      spec.compressor_type = "Semi-Hermetic Discus"
      spec.division = Rae.RaeSolutions.Business.Division.CRI
      spec.refrigerant = refrigerant.parse("R22")
      spec.series = "DS"
      
      dim conditions as Best_Matches.Conditions
      conditions.altitude = 0
      conditions.ambient = 95
      conditions.catalog_rating = true
      conditions.hertz = 60
      conditions.suction = 35
      conditions.voltage = 230
      
      Dim bestMatches = New Best_Matches()
      bestMatches.given(spec, at:=conditions)
      
      IsTrue( bestMatches.closest.unit.Model = "DS10H2" )
      IsTrue( bestMatches.above.unit.Model   = "DS12H2" )
      IsTrue( bestMatches.below.unit.Model   = "DS09H2" )
   End Sub
End Class
