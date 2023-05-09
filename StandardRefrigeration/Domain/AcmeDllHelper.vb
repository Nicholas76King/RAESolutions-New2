Class AcmeDllHelper

   Sub SetStaticSpecsFor(acme As AcmeXHX.DXdll)
      acme.DI_hiMethod     = 2
      acme.DI_AcmeMethod   = 2
      acme.DI_DataSpecified= 1
      acme.DI_SelectionDataSpecified  = 1
      acme.DI_EvapTempLocation        = 2
      acme.DI_Debug                   = 0
      acme.DI_FluidFlowRate           = 120
      acme.DI_FluidFoulingFactor      = 0.0001
      acme.DI_MaxFluidPressureDrop    = 10
      acme.DI_RefrigerantFlowRate     = 0
      acme.DI_RefrigerantFoulingFactor= 0
      acme.DI_EnteringRefrigerantTemp = 100
      acme.DI_DesiredCapacity         = 1000000 'only needed for selection (not rating)
      acme.DI_OperationMode           = "RATING"
      acme.DI_SelectModels            = "STANREF"
      acme.DI_outfile                 = "testdx"
      acme.DI_OEMfile                 = ""
      acme.DI_ActiveTubes             = 1
      acme.DI_NominalTubeLength       = 10
      acme.DI_RefrigerantPasses       = 4
      acme.DI_BaffleType              = "U"

      acme.DI_Password = ""
      acme.DI_hiCorrelation  = 0
      acme.DI_mode           = 0
      acme.DI_hiSPMultiplier = 0
      acme.DI_hiTPMultiplier = 0
      acme.DI_hoMultiplier   = 0
      acme.DI_pdMultiplier   = 0
      acme.DI_pdSPMultiplier = 0
      acme.DI_pdTPMultiplier = 0
      acme.DI_SuctionSuperheat = 0
      acme.DI_ssNozzle       = 0
   End Sub
   
   Function GetWarnings(acme As AcmeXHX.DXdll) As List(Of String)
      Dim warning As String = "".PadRight(255)
      Dim warnings = New List(Of String)
      For i = 0 To acme.DO_numMessages - 1
         acme.GetMessage(i, warning)
         warnings.Add(warning)
      Next
      Return warnings
   End Function
   
End Class