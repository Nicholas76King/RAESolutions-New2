Option Strict Off

Imports Rae.RaeSolutions.DataAccess.Chillers
Imports StandardRefrigeration

Namespace rae.solutions.chiller_evaporators

Class mapper

   Function map(evapSpec As evaporator_spec) As Rating.Spec
      Dim ratingSpec As Rating.Spec

      ratingSpec.Refrigerant       = evapSpec.refrigerant
      ratingSpec.Fluid             = evapSpec.fluid
      ratingSpec.GlycolPercentage  = evapSpec.glycol_percentage
      ratingSpec.NumCircuits       = evapSpec.num_circuits
      ratingSpec.EnteringFluidF    = evapSpec.entering_fluid_temp
      ratingSpec.LeavingFluidF     = evapSpec.leaving_fluid_temp
      ratingSpec.EvaporatingF      = evapSpec.evaporating_temp

      Return ratingSpec
   End Function
   
   Function map(dto As evaporator_dto) As evaporator
      Dim evap = New evaporator()
      
      evap.connection_size          = dto.connection_size
      evap.evaporator_part_number   = dto.evaporator_part_number
      evap.catalog_model            = dto.catalog_model
      evap.height                   = dto.height
      evap.length                   = dto.length
      evap.nominal_tons             = dto.nominal_tons
      evap.old_model                = dto.old_dll_model
      evap.rae_part_number          = dto.rae_part_number
      evap.model                    = dto.dll_model
      evap.width                    = dto.width
      evap.num_circuits             = dto.number_of_circuits
      evap.rae_index                = dto.rae_index
      
      Rae.Io.Text.GetEnumValue(Of EvaporatorType)(dto.rating_type, evap.type)
      
      Return evap
   End Function
   
   Function Map(evap As evaporator) As evaporator_dto
      Dim dto As evaporator_dto
      
      dto.connection_size      = evap.connection_size
      dto.evaporator_part_number   = evap.evaporator_part_number
      dto.catalog_model        = evap.catalog_model
      dto.height              = evap.height
      dto.length              = evap.length
      dto.dll_model            = evap.model
      dto.nominal_tons         = evap.nominal_tons
      dto.number_of_circuits         = evap.num_circuits
      dto.old_dll_model         = evap.old_model
      dto.rae_index            = evap.rae_index
      dto.rae_part_number          = evap.rae_part_number
      dto.rating_type          = evap.type.ToString
      dto.width               = evap.width
      
      Return dto
   End Function

End Class

End Namespace