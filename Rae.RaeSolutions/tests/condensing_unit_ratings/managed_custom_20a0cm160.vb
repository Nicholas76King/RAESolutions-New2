Imports Rae.Math.Comparisons
imports rae.solutions.condensing_units
imports rae.solutions.compressors

<TestClass> _
Public Class managed_custom_20a0cm160

   Private tolerance As Double = 0.1
   Private result As Balance.Result
   Private repository As I_Repository

   <TestInitialize> _
   Sub init
      config.db
      
      dim conditions as Balance.Conditions
      conditions.altitude = 0
      conditions.ambient = 95
      conditions.catalog_rating = True
      conditions.hertz = 60
      conditions.suction = 43
      conditions.voltage = 230
      
      repository = new Repository()
      Dim cu = repository.get_unit(model:="20A0CM160")
      
      conditions.fan_file_name_1 = Rae.RaeSolutions.Business.Intelligence.FanIntel.SelectStandardFile(cu.circuits(0).fan_diameter, conditions.altitude)
      conditions.fan_file_name_2 = Rae.RaeSolutions.Business.Intelligence.FanIntel.SelectStandardFile(cu.circuits(1).fan_diameter, conditions.altitude)
      
      For Each circuit In cu.circuits
         circuit.coil.Height = 75
         circuit.coil.Length = 248
         circuit.compressor_file_name = "ZR300KC.H2"
         circuit.compressor_model = "ZR300KCE"
         circuit.compressor_quantity = 4
         circuit.SubCooling = 10
      Next
      
      Dim compressors = new compressor_repository()
      Dim balance = New Balance(compressors)
      result = balance.This(cu, at:=conditions)
      
   End Sub
   
   <TestMethod> _
   Sub has_conditions_at_95_ambient_and_43_suction      
      Dim suction = result.conditions.suction
      Dim ambient = result.conditions.ambient
      
      Assert.IsTrue(suction = 43)
      Assert.IsTrue(ambient = 95)
   End Sub
   
   <TestMethod> _
   Sub condenser_temp_should_be_126p7
      Dim condenserTemp = result.point.condensing_temp
      Assert.IsTrue( IsAccurate(condenserTemp, tolerance, 126.9) )
   End Sub
   
   <TestMethod> _
   Sub td_should_be_31p7
      Dim td = result.point.td
      Assert.IsTrue( IsAccurate(td, tolerance, 31.9) )
   End Sub
   
   <TestMethod> _
   Sub capacity_should_be_207p66
      Dim capacity = result.point.capacity
      Assert.IsTrue( IsAccurate(actual:=capacity, percentage:=tolerance, expected:=207.43) )      
   End Sub
   
   <TestMethod> _
   Sub power_should_be_210p51_kw
      Dim kw = result.point.unit_kw
      Assert.IsTrue( IsAccurate(actual:=kw, percentage:=tolerance, expected:=210.81) )
   End Sub
   
   <TestMethod> _
   Sub eer_should_be_11p84
      Dim eer = result.point.unit_eer
      Assert.IsTrue( IsAccurate(actual:=eer, percentage:=tolerance, expected:=11.81) )
   End Sub
   
   <TestMethod> _
   Sub amps_at_230_should_be_650
      Dim ampsAt230 = result.point.unit_amps
      Assert.IsTrue( IsAccurate(actual:=ampsAt230, percentage:=tolerance, expected:=651) )
   End Sub
   
   <TestMethod> _
   Sub condenser_capacity_should_be_235p32
      Dim capacity = result.point.condenser_capacity
      Assert.IsTrue( IsAccurate(actual:=capacity, percentage:=tolerance, expected:=235.12) )
   End Sub
   
   <TestMethod> _
   Sub condenser_capacity_at_1_td_should_be_89199
      Dim capacity = result.point.coil_capacity
      Assert.IsTrue( capacity=88479 )
   End Sub
   
End Class
