Imports Rae.RaeSolutions.Business.Entities.Cofans
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace cofans

Public Class test
   Sub assert(condition As Boolean)
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(condition)
   End Sub
End Class

<TestClass> Public Class cofan_with_2_row_coil_and_24_inch_fan : Inherits test

   <TestInitialize> _
   Sub initialize
      set_defaults()
   End Sub
   
   Private Function default_spec() As cofan.specification
      Dim spec As cofan.specification
      spec.coil_file    = "2RCOND"
      spec.fan_file     = "LAU2429"
      spec.altitude     = 0
      spec.coil_width   = 32.25
      spec.coil_length  = 48
      spec.fan_quantity = 1
      Return spec
   End Function

   <TestMethod> Sub default_configuration
      Dim cofan = New cofan()
      Dim result = cofan.balance(default_spec)(0)
      
      assert(result.capacity        = 2315)
      assert(result.btuh_sqft       = 215)
      assert(result.cfm_actual      = 6174)
      assert(result.cfm_standard    = 5895)
      assert(result.face_velocity   = 574)
      assert(result.fpi             = 8)
      assert(result.hp              = 0.66)
      assert(cofan.row_qty          = 2)
      assert(result.static_pressure = 0.17)
   End Sub

   <TestMethod> Sub fan_with_20_inch_diameter
      Dim spec = default_spec
      spec.fan_file = "LAU2030"
      
      Dim cofan = New cofan()
      Dim result = cofan.balance(spec)(0)
      With result
         assert(.capacity        = 1743)    
         assert(.btuh_sqft       = 162)     
         assert(.cfm_actual      = 3650)    
         assert(.cfm_standard    = 3486)    
         assert(.face_velocity   = 340)     
         assert(.fpi             = 8)       
         assert(.hp              = 0.22)    
         assert(cofan.row_qty          = 2)
         assert(.static_pressure = 0.1)
      End With
   End Sub

   <TestMethod> Sub altitude_is_4000
      Dim spec = default_spec
      spec.altitude = 4000
      
      Dim cofan = New cofan()
      Dim result = cofan.balance(spec)(0)
      
      assert(result.capacity        = 2150)    
      assert(result.btuh_sqft       = 200)     
      assert(result.cfm_actual      = 6174)    
      assert(result.cfm_standard    = 5094)    
      assert(result.face_velocity   = 574)     
      assert(result.fpi             = 8)       
      assert(result.hp              = 0.66)    
      assert(cofan.row_qty          = 2)
      assert(result.static_pressure = 0.17)
   End Sub

   <TestMethod> Sub number_of_fans_is_2
      Dim cofan = New cofan()
      Dim spec = default_spec
      spec.fan_quantity = 2
      Dim result = cofan.balance(spec)(0)
      
      assert(result.capacity        = 2876)
      assert(result.btuh_sqft       = 268)
      assert(result.cfm_actual      = 10382)
      assert(result.cfm_standard    = 9914)
      assert(result.face_velocity   = 966)
      assert(result.fpi             = 8)
      assert(result.hp              = 0.71)
      assert(cofan.row_qty          = 2)
      assert(result.static_pressure = 0.41)
   End Sub

   <TestMethod> Sub fin_length_is_49_inches
      Dim cofan = New cofan()
      Dim spec = default_spec
      spec.coil_length = 49
      Dim result = cofan.balance(spec)(0)
      
      assert(result.capacity        = 2343)
      assert(result.btuh_sqft       = 213)
      assert(result.cfm_actual      = 6194)
      assert(result.cfm_standard    = 5915)
      assert(result.face_velocity   = 564)
      assert(result.fpi             = 8)
      assert(result.hp              = 0.66)
      assert(cofan.row_qty          = 2)
      assert(result.static_pressure = 0.16)
   End Sub

End Class
End Namespace