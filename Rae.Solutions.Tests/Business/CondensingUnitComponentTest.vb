Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Rae.RaeSolutions.Business.Intelligence

<TestClass> _
Public Class CondensingUnitComponentTest

   <TestMethod> _
   Sub get_best_three_using_wrapper
      Dim condensingUnit = CondensingUnitWrapper.GetThreeBestCondensingUnits( _
         "LUO", 28000, 95, 95, 35, "R22H", "Best-optimized", 0, 0, 0, "CRI", 460, False)

      Assert.IsTrue(condensingUnit.RAE_Out_TXT_A1 > 0)
   End Sub

   <TestMethod> _
   Sub rate_using_wrapper
      Dim condensingUnit = CondensingUnitWrapper.RateCondensingUnit( _
         "LUO2.02H", 95, 35, "R22H", RaeSolutions.Business.Division.CRI, 0, 460, False)

      Assert.IsTrue( condensingUnit.RAE_R_Coil_L_1 > 0 )
   End Sub
   
   <TestMethod> _
   Sub rate_setting_all_inputs_manually
      Dim cu = New RAEDLL_CONDENSING_UNIT.Selection_Mod()
     
      cu.RAE_MODEL_NUMBER     = "LUO2.02H"
      cu.RAE_TXT_AMBIENT_HIGH = 95
      cu.RAE_TXT_SUCTION_HIGH = 35
      cu.RAE_Refg_type        = "R22H"
      cu.RAE_RAE_Company      = "CRI"
      cu.RAE_Voltage          = 460
      cu.RAE_Opt_10Coff       = False

      ' sets constants
      cu.RAE_STD_OR_CATALOG_RATING  = 1   '0 - Standard, 1 - Catalog
      cu.RAE_50_OR_60_HZ            = 1   '0 - 50 Hz, 1 - 60 Hz
      cu.RAE_AMBIENT_STEPS          = 3
      cu.RAE_TXT_AMBIENT_STEP       = 5
      cu.RAE_TXT_SUCTION_STEP       = 1
      
      ' sets database values
      cu.RAE_Degrees_sub_cooling_Coil_1= 0
      cu.RAE_SubCooling_required       = "N" 'Y / N

      cu.RAE_fan_dia_1  = 20
      cu.RAE_R_Fan_Dia_1= "20"
      cu.RAE_FanHp_1    = 0.25

      cu.RAE_NUMBER_OF_FANS_1  = 1
      cu.RAE_R_Fan_Qty_1       = 1

      cu.RAE_COIL_FACE_1 = 20
      cu.RAE_R_Coil_H_1  = 20

      cu.RAE_COIL_LENGHT_1 = 27
      cu.RAE_R_Coil_L_1    = 27

      cu.RAE_Rows_deep_1   = 2
      cu.RAE_R_Coil_Row_1  = 2

      cu.RAE_COMPRESSOR_REQD_CIRCUIT_1 = 1
      cu.RAE_R_Compr_Qty_1             = 1

      cu.RAE_fpi_in_1= 8
      cu.RAE_R_FPI_1 = 8

      cu.RAE_COMPRESSOR_FILENAME_CIRCUIT_1= "Zr24k3.H2"
      cu.RAE_R_Compr_File_1               = "Zr24k3.H2"
     
      cu.AddToDatabase4()
      
      Assert.IsTrue( cu.RAE_R_Coil_L_1 > 0 )
   End Sub

End Class
