Imports Rae.utilities

Public Class Rating
   Sub New()
      acme = New AcmeXHX.DXdll()
      help = New AcmeDllHelper()
   End Sub
   
   Function RunRae(spec As Spec, index As Integer) As Output
      acme.DI_ModelCode             = 103 'todo:EvaporatorType.RAE
      acme.DI_NominalShellDiameter  = index
      Return run(spec)
   End Function

   Function RunTx(spec As Spec, nominalCapacity As Double, type As EvaporatorType) As Output
      acme.DI_ModelCode             = type
      acme.DI_NominalShellDiameter  = nominalCapacity
      Return run(spec)
   End Function
   
   
   Private acme As AcmeXHX.DXdll
   Private help As AcmeDllHelper
   
   
   Private Function toType(modelCode As Integer) As EvaporatorType
      Dim type As EvaporatorType
      
      Select Case modelCode
         Case 8   : type = EvaporatorType.TX
         Case 9   : type = EvaporatorType.TXC
         Case 101 : type = EvaporatorType.TXG
         Case 103 : type = EvaporatorType.RAE
         Case Else: Throw New Exception("Cannot determine evaporator type. Model code is invalid: " & modelCode)
      End Select
      
      Return type
   End Function
   
   Private Function run(spec As Spec) As Output
      use(spec)
      help.SetStaticSpecsFor(acme)
      acme.CallDX()
      
      Return getOutput()
   End Function
  
   Private Sub use(spec As Spec)
      acme.DI_FluidType            = spec.Fluid
      acme.DI_RefrigerantType      = spec.Refrigerant
      acme.DI_EnteringFluidTemp    = spec.EnteringFluidF
      acme.DI_LeavingFluidTemp     = spec.LeavingFluidF
      acme.DI_FluidConcentration   = spec.GlycolPercentage
      acme.DI_EvaporatingTemp      = spec.EvaporatingF
      acme.DI_RefrigerantCircuits  = spec.NumCircuits
   End Sub
  
   Private Function getOutput() As Output
      Dim out As Output
      out.Model                   = acme.DO_Model
      Dim capacity = (acme.DO_Q_a + acme.DO_Q_c) / 2
      If acme.DI_RefrigerantCircuits = 4 Then
         out.Capacity = capacity / 2
      Else
         out.Capacity = capacity / acme.DI_RefrigerantCircuits
      End If
      out.RefrigerantPressureDrop = acme.DO_dp_r
      out.RefrigerantFlow         = acme.DO_mdot_r
      out.FluidPressureDrop       = acme.DO_dp_f
      out.FluidFlow               = acme.DO_vdot_f
      out.RaeIndex                = acme.DI_NominalShellDiameter
      out.Type                    = toType(acme.DI_ModelCode)
      out.FluidDensity            = acme.DO_rho_f
      out.SpecificHeat            = acme.DO_cp_f
      out.FluidNozzle             = acme.DO_rv2_noz

      out.Warnings = help.GetWarnings(acme)
      
      Return out
   End Function
   
   Public Structure Spec
      Public Fluid As Fluid
      Public Refrigerant As Refrigerant
      Public EnteringFluidF As Double
      Public LeavingFluidF As Double
      Public EvaporatingF As Double
      Public GlycolPercentage As Double
      Public NumCircuits As Integer
   End Structure
   
   Public Structure Output
      Public Warnings As List(Of String)
      Public Model As String
      Public Capacity As Double
      Public RefrigerantPressureDrop As Double
      Public RefrigerantFlow As Double
      Public FluidPressureDrop As Double
      Public FluidFlow As Double
      Public FluidDensity As Double 'lbm/ft^3
      Public FluidNozzle As Double ' lbm/ft*s^2
      Function SpecificGravity As Double
         Return FluidDensity / 62.43
      End Function
      Public SpecificHeat As Double
      
      Public RaeIndex As Integer ' rae: index; tx: nominal capacity;
      Public [Type] As EvaporatorType
      Public Acme As AcmeXHX.DXdll

      Function IsValid As Boolean
         If String.IsNullOrEmpty(Model) Then _
            Return False
         
         For Each warning In Warnings
            If warning.StartsWith("ERROR") Then
               Return False
            End If
         Next
         
         Return True
      End Function
   End Structure
End Class