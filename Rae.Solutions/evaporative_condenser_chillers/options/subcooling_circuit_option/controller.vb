imports rae.ui.quickies

namespace evaporative_condenser_chillers.subcooling_circuit_option

class controller
   private option_control as i_option_control
   private subcooling_control as control
   private subcooling_adjustment as double = 10

   sub new(option_control as i_option_control, subcooling_control as control, pricing_repository as i_pricing_repository)
      me.option_control = option_control
      me.subcooling_control = subcooling_control
      
      option_control.option = pricing_repository.get_option("ME16")
      addhandler option_control.check_changed, addressof handle_check_changed
   end sub
   
   private sub handle_check_changed(option_control as i_option_control)
      dim new_line = system.environment.newLine
      dim previous_subcooling = subcooling_control.text
      
      if option_control.checked
         subcooling_control.text = subcooling_control.text + subcooling_adjustment
         dim updated_subcooling  = subcooling_control.text
         if option_control.notify_user
            inform(subcooling_adjustment & " degrees of subcooling has been automatically added" & new_line & new_line & _
                   "subcooling changed from " & previous_subcooling & " to " & updated_subcooling)
         end if
      else
         dim updated_subcooling = subcooling_control.text - subcooling_adjustment
         if updated_subcooling < 0 then _
            updated_subcooling = 0
         subcooling_control.text = updated_subcooling
         if option_control.notify_user
            inform(subcooling_adjustment & " degrees of subcooling has been removed" & new_line & new_line & _
                   "subcooling changed from " & previous_subcooling & " to " & updated_subcooling)
         end if
      end if
   end sub
end class

end namespace