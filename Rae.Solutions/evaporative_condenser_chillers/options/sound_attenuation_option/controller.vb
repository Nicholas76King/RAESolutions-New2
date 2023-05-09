imports rae.solutions.evaporative_condenser_chillers
imports rae.ui.quickies
imports system.math

namespace evaporative_condenser_chillers.sound_attenuation_option

class controller
   private static_context as static_context
   private new_line = system.environment.newLine
   private option_control as i_option_control
   
   sub new(static_context as static_context)
      me.static_context = static_context
      option_control = static_context.option_control
      
      option_control.option = get_option()
      addhandler option_control.check_changed, addressof handle_option_check_changed
   end sub
   
   sub update_watts()
      handle_option_check_changed(me.option_control)
   end sub
   
   private sub handle_option_check_changed(control as i_option_control)
      dim dynamic_context = static_context.grab_dynamic_context.invoke()
      
      if control.checked then
         upsize_motor(control, dynamic_context.chiller)
      else
         downsize_motor_to_original_size(control, dynamic_context.chiller)
      end if
   end sub
   
   private sub upsize_motor(control as i_option_control, chiller as chiller)
      dim motor_hps = new motor_hp_list( chiller.condenser.fan_hp )
      
      dim previous_fan_watts = cdbl(static_context.fan_watts_control.text)
      dim new_fan_watts = chiller.calculate_watts(motor_hps.upsize, chiller.condenser_quantity)
      static_context.fan_watts_control.text = round(new_fan_watts)
      static_context.fan_hp_control.text = motor_hps.upsize
      
      if control.notify_user
         inform(control.option.code & " - " & control.option.long_description & new_line & new_line & _
                "The fan motor has been automatically upsized from " & motor_hps.original & "hp to " & motor_hps.upsize & "hp." & new_line & _
                "The fan watts increased accordingly from " & round(previous_fan_watts) & "w to " & round(new_fan_watts) & "w.")
      end if
   end sub
   
   private sub downsize_motor_to_original_size(control as i_option_control, chiller as chiller)
      dim motor_hps = new motor_hp_list( chiller.condenser.fan_hp )
      
      dim previous_fan_watts = cdbl(static_context.fan_watts_control.text)
      dim new_fan_watts_1 = chiller.calculate_watts(motor_hps.original, chiller.condenser_quantity)
      static_context.fan_watts_control.text = round(new_fan_watts_1)
      static_context.fan_hp_control.text = motor_hps.original
      
      if control.notify_user
         inform(control.option.code & " - " & control.option.long_description & new_line & new_line & _
                "The fan motor has been automaticaly downsized from " & motor_hps.upsize & "hp to " & motor_hps.original & "hp." & new_line & _
                "The fan watts decreased from " & round(previous_fan_watts) & "w to " & round(new_fan_watts_1) & "w accordingly.")
      end if
   end sub
   
   private function get_option() as [option]
      dim [option] as [option]
      [option].code = "MA06 and MA07"
      [option].description = "Evap Condenser Inlet and Outlet Sound Attenuation"
      [option].long_description = "The attenuation package adds ESP. Therefore motors and drives must be increased one size. Attenuation ships loose and requires field mounting."
      return [option]
   end function
   
end class

end namespace