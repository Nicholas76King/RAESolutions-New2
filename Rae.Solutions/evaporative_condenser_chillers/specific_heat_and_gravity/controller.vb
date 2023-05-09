imports rae.solutions.evaporative_condenser_chillers

namespace evaporative_condenser_chillers.specific_heat_and_gravity

structure controls
   public fluid_control, glycol_control, glycol_percentage_control as control
   public temperature_range_control, leaving_fluid_temperature_control as control
   public specific_heat_control, specific_gravity_control as control
end structure

class controller

   sub new(controls as controls, service as service)
      me.controls = controls
      me.service = service
   end sub
   
   private controls as controls
   private service as service
   
   sub calculate()
      dim fluid                      = grab_fluid()
      dim fluid_percentage           = grab_text_value(controls.glycol_percentage_control)
      dim range                      = grab_text_value(controls.temperature_range_control, 1)
      dim leaving_fluid_temperature  = grab_text_value(controls.leaving_fluid_temperature_control)
      dim entering_fluid_temperature = leaving_fluid_temperature + range
      
      if fluid_percentage = 0
         controls.specific_heat_control.text = 1
         controls.specific_gravity_control.text = 1
      else
         dim specific = service.calculate_specific_heat_and_gravity( _
            fluid, fluid_percentage, entering_fluid_temperature, leaving_fluid_temperature)
      
         controls.specific_heat_control.text = specific.heat.ToString("0.####")
         controls.specific_gravity_control.text = specific.gravity.ToString("0.####")
      end if
   end sub
   
   private function grab_text_value(control as control, optional default_value as double = 0) as double
      if is_null_or_empty(control.text) orElse control.text = "-" then _
         return default_value
      return control.text
   end function
   
   private function grab_fluid() as StandardRefrigeration.Fluid
      dim fluid as StandardRefrigeration.Fluid
      
      if controls.fluid_control.text = "Water"
         fluid = StandardRefrigeration.Fluid.Water
      else if controls.fluid_control.text = "Glycol"
         if controls.glycol_control.text = "Ethylene"
            fluid = StandardRefrigeration.Fluid.Ethylene
         else if controls.glycol_control.text = "Propylene"
            fluid = StandardRefrigeration.Fluid.Propylene
         end if
      end if
      
      return fluid
   end function

   private function is_null_or_empty(text as string) as boolean
      return String.IsNullOrEmpty(text)
   end function
end class

end namespace