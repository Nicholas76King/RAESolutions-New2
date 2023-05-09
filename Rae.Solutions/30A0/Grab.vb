Imports rae.solutions
Imports rae.solutions.chiller_evaporators
imports Rae.RaeSolutions.Business.Entities

''' <summary>Facade for grabbing bags (values needed to perform a task)</summary>
Class ChillerGrab
   Sub New(form As air_cooled_chiller_balance_window)
      grabSpecificHeatAndGravity = New SpecificHeatAndGravityGrab(form)
      grabAltEvap = New AlternateEvaporatorsGrab(form)
   End Sub
   
   Function BagForSpecificHeatAndGravity() As SpecificHeatAndGravityGrab.BagForSpecificHeatAndGravity
      Return grabSpecificHeatAndGravity.Bag
   End Function
   
   Function BagForAlternateEvaporators() As AlternateEvaporatorsGrab.BagForAlternateEvaporators
      Return grabAltEvap.Bag
   End Function
   
   Function SpecForAlternateEvaporators() As evaporator_spec
      Return grabAltEvap.Spec
   End Function
   
   Private grabAltEvap As AlternateEvaporatorsGrab
   Private grabSpecificHeatAndGravity As SpecificHeatAndGravityGrab
End Class

Class SpecificHeatAndGravityGrab
   Sub New(form As air_cooled_chiller_balance_window)
      Me.form = form
   End Sub

   Function Bag() As BagForSpecificHeatAndGravity
      Dim b = New BagForSpecificHeatAndGravity()
      Dim mapper = New evaporator_mapper()
      b.Fluid            = mapper.map(form.CoolingFluid)
      b.GlycolPercentage = form.GlycolPercentage
      b.EnteringFluidF   = form.EnteringFluidTemp
      b.LeavingFluidF    = form.leaving_fluid_temperature
      Return b
   End Function
   
   Public Class BagForSpecificHeatAndGravity
      Public Fluid As StandardRefrigeration.Fluid
      Public GlycolPercentage, EnteringFluidF, LeavingFluidF As Double
   End Class
   
   Private form As air_cooled_chiller_balance_window
End Class

Class AlternateEvaporatorsGrab
   Sub New(form As air_cooled_chiller_balance_window)
      Me.form = form
   End Sub
   
   Function Bag() As BagForAlternateEvaporators
      Dim b = New BagForAlternateEvaporators()
      
      b.Authorization      = form.user.authority_group
      ' TODO: make clear difference between evap, cond and sys capacity
      b.CondenserCapacity  = form.GrabSystemCapacityTons
      b.EnteringFluidTemp  = form.EnteringFluidTemp
      b.EvaporatorLength   = form.EvaporatorLength
      b.Fluid              = form.CoolingFluid
      b.FoulingFactor      = form.FoulingFactor
      b.GlycolPercentage   = form.GlycolPercentage
      b.LeavingFluidTemp   = form.leaving_fluid_temperature
      b.NumCircuits        = form.NumCircuits
      b.Refrigerant        = form.RefrigerantString
      
      Return b
   End Function
   
   Function Spec() As evaporator_spec
      Dim defaultEvaporatorLength = form.EvaporatorLength
      
      Dim s As evaporator_spec
      s.entering_fluid_temp    = form.EnteringFluidTemp
      s.length            = defaultEvaporatorLength
      s.glycol_percentage  = form.GlycolPercentage
      s.leaving_fluid_temp     = form.leaving_fluid_temperature
      s.num_circuits       = form.NumCircuits
      'TODO: confirm using min suction as evaporating temp
      s.evaporating_temp      = form.MinSuctionTemp
      s.authorization     = form.user.authority_group
      Dim mapping = New evaporator_mapper()
      s.fluid             = mapping.map(form.CoolingFluid)
      s.refrigerant       = mapping.map(form.RefrigerantString)
      
      Return s
   End Function
   
   Public Class BagForAlternateEvaporators
      Public FoulingFactor, GlycolPercentage, CondenserCapacity, EvaporatorLength As Double
      Public EnteringFluidTemp, LeavingFluidTemp As Double
      Public Refrigerant As String
      Public Fluid As CoolingMedia
      Public Authorization As user_group
      Public NumCircuits As Integer
   End Class
   
   Private form As air_cooled_chiller_balance_window
End Class