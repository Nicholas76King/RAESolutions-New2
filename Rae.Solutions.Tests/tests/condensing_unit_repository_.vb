Imports Rae.RaeSolutions.Business.Division
Imports rae.solutions
Imports rae.solutions.condensing_units
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass> _
public class condensing_unit_repository_

   private repository As I_Repository

   <TestInitialize()> _
   Sub init()
   	config.db
   	repository = new condensing_units.Repository()
   End Sub

   <TestMethod> _
   Sub gets_tsi_single_scroll_r22_high_temp_units
      Dim criteria As Criteria
      criteria.compressor_qty_description = "S"
      criteria.compressor_type = "SCROLL"
      criteria.division = TSI
      criteria.Refrigerant = refrigerant.parse("R22")
      criteria.series = "20A0"
      criteria.suction_temp = 35
   
      Dim cus = repository.get_units(criteria)
      IsTrue( cus.Count = 7 )
   End Sub
      
   <TestMethod> _
   Sub does_not_get_units_when_suction_is_out_of_range
      Dim criteria = get_criteria_for_cri_dual_compressor_R404a_low_temp()
      Dim suction_outside_low_temp_range=1
      criteria.suction_temp = suction_outside_low_temp_range
      
      Dim cus = repository.get_units(criteria)
      IsTrue( cus.Count = 11 )
   End Sub
   
   Private Function get_criteria_for_cri_dual_compressor_R404a_low_temp() As Criteria
      Dim criteria As Criteria
      criteria.compressor_qty_description = "D"
      'spec.CompressorType = not set
      criteria.division = CRI
      criteria.Refrigerant = refrigerant.parse("R404a")
      criteria.series = "DD"
      criteria.suction_temp = 0
      Return criteria
   End Function
   
   
   'gets_units_speced_with_407c
   'gets_units_speced_with_134a
   'gets_units_speced_with_410a
End Class