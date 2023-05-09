namespace evaporative_condenser_chillers.sound_attenuation_option

class static_context
   public option_control as i_option_control
   public fan_watts_control as control
   public fan_hp_control as control
   
   public delegate function grab_dynamic_context_delegate() as dynamic_context
   public grab_dynamic_context as grab_dynamic_context_delegate
end class

end namespace