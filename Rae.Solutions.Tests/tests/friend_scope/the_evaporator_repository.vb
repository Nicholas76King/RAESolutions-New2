'Imports Rae.Data
'Imports rae.solutions.chiller_evaporators
'Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

'<TestClass> _
'Public Class the_evaporator_repository

'   Private repo As I_evaporator_repository
   
'   <TestInitialize> _
'   Sub setup
'      repo = New Evaporator_repository()
'   End Sub
   
'   <TestMethod> _
'   Sub gets_nominal_capacities_when_rating_type_is_tx_and_it_has_1_circuit
'      Dim ratingType = "TX"
'      Dim numCircuits= 1
'      Dim nominalCapacities = repo.get_nominal_capacities(ratingType, numCircuits)
      
'      Dim expectedCapacities As Double() = {2, 3, 5, 6, 7.5, 10, 12, 15, 20, 25}
      
'      IsTrue( nominalCapacities.Count = expectedCapacities.Length )
'      For Each expectedCapacity In expectedCapacities
'         IsTrue( nominalCapacities.Contains(expectedCapacity) )
'      Next
'   End Sub
   
'   <TestMethod> _
'   Sub gets_correct_results_for_evaporator_part_number_TX10_6441_2C
'      Dim evap = repo.get_evaporator_by_part_number("TX10-6441-2C")
      
'      IsTrue(evap.dll_model = "tx10-2")
'      IsTrue(evap.nominal_tons = 10)
'      IsTrue(evap.rae_part_number = "C00270-06")
'   End Sub
   
   
'   <TestMethod> _
'   Sub gets_correct_results_for_new_TXC1005B12
'      Dim evap = repo.get_evaporator_by_model("TXC1005B12")
      
'      assertCorrectValuesIn(evap)
'   End Sub   
   
'   <TestMethod, ExpectedException(GetType(NullParamEx))> _
'   Sub throws_null_parameter_exception
'      Dim evap = repo.get_evaporator_by_model(Nothing)
'   End Sub
   
'   <TestMethod, ExpectedException(GetType(NotFoundEx))> _
'   Sub throws_not_found_exception
'      Dim evap = repo.get_evaporator_by_model("model that will not be found")
'   End Sub
   
   
'   Private Sub assertCorrectValuesIn(evap As Evaporator_dto)
'      Assert.IsTrue(evap.length           = 71.03)
'      Assert.IsTrue(evap.width            = 18.69)
'      Assert.IsTrue(evap.height           = 16.76)
'      Assert.IsTrue(evap.nominal_tons      = 63)
'      Assert.IsTrue(evap.connection_size   = "5"" FLNG")
'      Assert.IsTrue(evap.evaporator_part_number= "TXC1005-B12-1C")
'      Assert.IsTrue(evap.old_dll_model      = "tx10056402")
'      Assert.IsTrue(evap.rae_part_number       = "C00270-21")
'      Assert.IsTrue(evap.dll_model         = "TXC1005B12")
'      Assert.IsTrue(evap.catalog_model     = "TXC1005B12,1C")
'      Assert.IsTrue(evap.number_of_circuits      = 1)
'      Assert.IsTrue(evap.rating_type       = "RAE")
'      Assert.IsTrue(evap.rae_index         = 3)
'   End Sub
   
'End Class
