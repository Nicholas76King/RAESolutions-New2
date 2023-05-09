imports rae.validation

namespace rae.solutions.drawings

class unit_cooler_electrical_info
   sub new()
      validators = new validator_list()
   end sub
   public fan_motor_amps, defrost_heater_amps, defrost_heater_watts, defrost_blocks, fan_blocks, fan_quantity as double
   public fan_voltage, defrost_voltage as double
   public sccr_1, sccr_2, sccr_3 as double
   public model_is_in_database as boolean
   public validators as validator_list
end class

end namespace