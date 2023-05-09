namespace evaporative_condenser_chillers

interface i_pricing_repository
   function get_option(code as string) as [option]
end interface

class pricing_repository : implements i_pricing_repository
   function get_option(code as string) as [option] _
   implements i_pricing_repository.get_option
      dim [option] as [option]
      
      dim master_option = Rae.DataAccess.EquipmentOptions.master_options_data_access.retrieve_options(code)(0)
      [option].code              = master_option.code
      [option].description       = master_option.description
      [option].long_description  = master_option.long_description
      
      return [option]
   end function
end class

class test_pricing_repository : implements i_pricing_repository
   function get_option(code as string) as [option] _
   implements i_pricing_repository.get_option
      dim [option] as [option]
      if code = "ME16"
         with [option]
            .code = code
            .description = "Integral Sub-Cooling Coil"
            .long_description = "The sub-cooling coil section is mounted between the condensing coil and the basin section and will add 7"" to the height of the unit. Coil will add approximately 10°F additional degrees of sub-cooling."
         end with
      else
         with [option]
            .code = "MA06 and MA07"
            .description = "Evap Condenser Inlet and Outlet Sound Attenuation"
            .long_description = "Discharge attenuation package adds ESP. Therefore motors and drives must be increased one size. Discharge attenuation ships loose and requires field mounting."
         end with
      end if
      return [option]
   end function
end class


    Interface i_option_control
        Property notify_user As Boolean
        Property checked As Boolean
        Property [option] As [option]

        Event check_changed(ByVal option_control As i_option_control)
    End Interface


    Structure [option]
        Public code, description, long_description As String
    End Structure


end namespace