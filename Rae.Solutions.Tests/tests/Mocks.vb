Imports StandardRefrigeration
Imports rae.solutions.chiller_evaporators

Public Class Mocks

   Function GetEvaporatorDto() As Evaporator_dto
      Dim evap As Evaporator_dto
      evap.rating_type = "RAE"
      
      evap.connection_size = "3"
      evap.evaporator_part_number = "foo"
      evap.height = 5
      evap.length = 6
      evap.dll_model = "foo"
      evap.nominal_tons = 7
      evap.number_of_circuits = 1
      evap.old_dll_model = "foo"
      evap.rae_index = 8
      evap.rae_part_number = "foo"
      evap.width = 9
      
      Return evap
   End Function

   ' only rae evaporators have 4 circuits
   Function GetEvaporatorSpecWith4Circuits() As Evaporator_spec
      Dim spec As Evaporator_spec
      
      spec.fluid             = Fluid.Water
      spec.glycol_percentage  = 40
      spec.num_circuits       = 4
      spec.refrigerant       = StandardRefrigeration.Refrigerant.R22
      spec.entering_fluid_temp    = 54
      spec.leaving_fluid_temp     = 44
      spec.evaporating_temp      = 35
      spec.length            = 100
      spec.authorization     = 1
      
      Return spec
   End Function
   
   Function GetEvaporatorSpecWith1Circuit() As Evaporator_spec
      Dim spec = GetEvaporatorSpecWith4Circuits()
      spec.num_circuits = 1
      Return spec      
   End Function
   
   Function GetEvaporatorSpecWith4CircuitsForRep() As Evaporator_spec
      Dim spec = GetEvaporatorSpecWith4Circuits()
      spec.authorization = 3
      Return spec
   End Function
   
   Function GetTxRatingSpec() As Evaporator_spec
      Dim spec As Evaporator_spec
      
      spec.fluid             = Fluid.Water
      spec.glycol_percentage  = 40
      spec.num_circuits       = 1
      spec.refrigerant       = StandardRefrigeration.Refrigerant.R22
      spec.entering_fluid_temp    = 54
      spec.leaving_fluid_temp     = 44
      spec.evaporating_temp      = 35
      spec.authorization     = 1
      spec.length            = 72
      
      Return spec
   End Function

End Class