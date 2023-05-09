Public Class Specific

   Sub New(fluid As Fluid, concentration As Double, enteringTemp As Double, leavingTemp As Double)
        Dim standard = New AcmeXHX.DXdll()
      With standard
         .DI_FluidType           = fluid
         .DI_FluidConcentration  = concentration
         .DI_EnteringFluidTemp   = enteringTemp
         .DI_LeavingFluidTemp    = leavingTemp
         
         .DI_ModelCode           = 103 'todo:EvaporatorType.RAE
         .DI_RefrigerantCircuits = 1
         .DI_NominalShellDiameter= 1
         
         Dim help = New AcmeDllHelper()
         help.SetStaticSpecsFor(standard)
         
         System.Diagnostics.Debug.WriteLine("going to call dx for specific heat and gravity " & Threading.Thread.CurrentThread.ManagedThreadId)
         .CallDX()
         
         Dim warnings = help.GetWarnings(standard)
         
         Dim density = .DO_rho_f
         Gravity = density / 62.43
         
         Heat = .DO_cp_f
      End With
   End Sub
   
   Public Gravity As Double
   Public Heat As Double
End Class