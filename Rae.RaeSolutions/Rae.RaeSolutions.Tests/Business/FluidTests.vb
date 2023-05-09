Imports rae.solutions


<TestClass()> Public Class FluidTests

   Private testContextInstance As TestContext

   Property TestContext As TestContext
      Get
         Return testContextInstance
      End Get
      Set(value As TestContext)
         testContextInstance = value
      End Set
   End Property
   
   <TestMethod> Sub freezing_point_of_water_should_be_32
      Dim water = New FluidFactory().Create(CoolingMedia.Water, 0)
      IsTrue(water.FreezePoint = 32)
   End Sub

   <TestMethod> Sub freeze_point_of_propylene_at_10_percent_should_be_27
      Dim propylene = New FluidFactory().Create(CoolingMedia.Propylene, 10)
      IsTrue(propylene.FreezePoint = 27)
   End Sub
   
   <TestMethod> Sub recommended_min_suction_temp_of_propylene_at_10_percent_should_be_30
      Dim propylene = New FluidFactory().Create(CoolingMedia.Propylene, 10)
      IsTrue(propylene.MinSuctionTemp = 30)
   End Sub
   
   <TestMethod> Sub freeze_point_of_ethylene_at_10_percent_should_be_25
      Dim ethylene = New FluidFactory().Create(CoolingMedia.Ethylene, 10)
      IsTrue(ethylene.FreezePoint = 25)
   End Sub
   
   <TestMethod> Sub recommended_min_suction_temp_of_ethylene_at_10_percent_should_be_30
      Dim ethylene = New FluidFactory().Create(CoolingMedia.Ethylene, 10)
      IsTrue(ethylene.MinSuctionTemp = 30)
   End Sub

End Class
