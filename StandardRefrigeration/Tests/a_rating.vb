Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports StandardRefrigeration
Imports System.Math
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass> _
Public Class a_rating

   <TestMethod> _
   Sub can_get_rae_model
      Dim spec = New Mocks().GetRaeRatingSpec()
      spec.Refrigerant = Refrigerant.R134a
      
      Dim rating = New Rating()
      Dim output = rating.RunRae(spec, 27)
      
      Assert.IsTrue( output.Model = "TXC3075A42R" )
   End Sub
   
   <TestMethod> _
   Sub can_get_tx_model
      Dim spec = New Mocks().GetTxRatingSpec()
      
      Dim rating = New Rating()
      Dim output = rating.RunTx(spec, 3, EvaporatorType.TX)
      
      Assert.IsTrue( output.Model = "TX3-1" )
   End Sub
   
   <TestMethod> _
   Sub is_invalid_when_warnings_contain_an_error
      Dim spec = New Mocks().GetFailingSpec()
      
      Dim rating = New Rating()
      Dim output = rating.RunTx(spec, 3, EvaporatorType.TX)
      
      Assert.IsFalse( output.IsValid )
   End Sub
   
   <TestMethod> _
   Sub finds_evaporator_for_tx_when_nominal_capacity_is_2
      Dim spec   = New Mocks().GetTxRatingSpec()
      Dim rating = New Rating()
      Dim output = rating.RunTx(spec, 2, EvaporatorType.TX)
      
      Assert.IsTrue( output.IsValid )
   End Sub
   
   <TestMethod> _
   Sub does_not_find_evaporator_for_tx_when_nominal_capacity_is_2p2
      'TODO: change test nominal capacities must be exact
      Dim spec   = New Mocks().GetTxRatingSpec()
      Dim rating = New Rating()
      Dim output = rating.RunTx(spec, 2.2, EvaporatorType.TX)
      
      Assert.IsFalse( output.IsValid )
   End Sub

   <TestMethod> _
   Sub a_txc_with_1_circuit_and_a_nominal_capacity_of_30
      Dim spec = New Mocks().GetTxRatingSpec()
      Dim rating = New Rating()
      Dim output = rating.RunTx(spec, 30, EvaporatorType.TXC)
      
      ' should match excel file from Standard Refrigeration
      Assert.IsTrue( output.Type             = EvaporatorType.TXC )
      Assert.IsTrue( output.Model            = "TXC30-1" )
      Assert.IsTrue( Round(output.Capacity)  = 358892 )
      Assert.IsTrue( Round(output.FluidFlow) = 71 )
      Assert.IsTrue( Round(output.FluidPressureDrop, 2) = 5.34 )
      Assert.IsTrue( Round(output.RefrigerantFlow) = 5203 )
      Assert.IsTrue( Round(output.RefrigerantPressureDrop, 2) = 2.82 )
   End Sub
   
   <TestMethod> _
   Sub a_txg_with_1_circuit_and_a_nominal_capacity_of_40
      Dim spec = New Mocks().GetTxRatingSpec()
      Dim rating = New Rating()
      Dim output = rating.RunTx(spec, 40, EvaporatorType.TXG)
      
      Assert.IsTrue( output.Type = EvaporatorType.TXG )
      Assert.IsTrue( output.Model = "TXG40-1" )
      Assert.IsTrue( Round(output.Capacity)  = 483626 )
      Assert.IsTrue( Round(output.FluidFlow) = 97 )
      Assert.IsTrue( Round(output.FluidPressureDrop, 2) = 5.79 )
      Assert.IsTrue( Round(output.RefrigerantPressureDrop, 2) = 2.38 )
      Assert.IsTrue( Round(output.RefrigerantFlow) = 7055 )
   End Sub
   
End Class