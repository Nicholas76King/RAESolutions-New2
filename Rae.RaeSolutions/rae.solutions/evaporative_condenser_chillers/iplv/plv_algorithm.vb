imports rae.solutions.chillers
imports rae.solutions.chiller_evaporators

namespace rae.solutions.evaporative_condenser_chillers

''' <summary>Part load value algorithm is used for both IPLV and NPLV.</summary>
public class plv_algorithm

   public outputs as list(of iplv_output)
   public iplv_value as double

   protected commands as plv_commands
   protected logger as logger

   sub new(commands as plv_commands)
      me.commands = commands
      me.logger = new logger()
   end sub

   readonly property plv_type as string
      get
         return commands.plv_type
      end get
   end property
   
   function calculate() as double
      outputs = new list(of iplv_output)
   
      dim _100 = commands.at_100_load().run()
      outputs.add(_100)
      logger.log(_100)
set_progress(10)

      dim _75 = commands.at_75_load(_100).run
      logger.log(_75)
         _75 = match_gpm_by_adjusting_temperature_range(_100, _75)
         _75 = match_capacity_by_adjusting_compressor_capacity_factor(_100, _75)
         _75 = keep_condensing_temp_above_100_by_increasing_condenser_capacity_factor(_75)
set_progress(20)         
         _75 = match_gpm_by_adjusting_temperature_range(_100, _75)
         _75 = match_capacity_by_adjusting_compressor_capacity_factor(_100, _75)
      outputs.add(_75)
      logger.log(_75)
set_progress(30)

      dim _50 = commands.at_50_load(_100).run()
      logger.log(_50)
         _50 = match_gpm_by_adjusting_temperature_range(_100, _50)
         _50 = match_capacity_by_adjusting_compressor_capacity_factor(_100, _50)
         _50 = keep_condensing_temp_above_100_by_increasing_condenser_capacity_factor(_50)
set_progress(40)         
         _50 = match_gpm_by_adjusting_temperature_range(_100, _50)
         _50 = match_capacity_by_adjusting_compressor_capacity_factor(_100, _50)
set_progress(50)         
         _50 = match_gpm_by_adjusting_temperature_range(_100, _50)
      outputs.add(_50)
      logger.log(_50)
set_progress(60)

      dim _25 = commands.at_25_load(_100).run()
      logger.log(_25)
         _25 = match_gpm_by_adjusting_temperature_range(_100, _25)
set_progress(70)
         _25 = match_capacity_by_adjusting_compressor_capacity_factor(_100, _25)
         _25 = keep_condensing_temp_above_100_by_increasing_condenser_capacity_factor(_25)
set_progress(80)         
         _25 = match_gpm_by_adjusting_temperature_range(_100, _25)
         _25 = match_capacity_by_adjusting_compressor_capacity_factor(_100, _25)
         
         _25 = match_gpm_by_adjusting_temperature_range(_100, _25)
      outputs.add(_25)
      logger.log(_25)
set_progress(95)

      dim iplv_value = commands.calculate_iplv(_100, _75, _50, _25)
      logger.log("iplv:" & iplv_value.ToString())

      me.iplv_value = iplv_value
      return iplv_value
   end function

   public event progress_changed(percentage as double)

   private sub set_progress(percentage as double)
      RaiseEvent progress_changed(percentage)
   end sub

   protected function match_gpm_by_adjusting_temperature_range(high as iplv_output, low as iplv_output) as iplv_output
      dim temperature_increments as double() = {0.8, 0.2, 0.05}
      
      for each temperature_increment in temperature_increments
         if low.gpm > high.gpm
            do while (low.gpm > high.gpm)
               low = commands.increase_temperature_range(temperature_increment).run()
               logger.log_range(low)
            loop
         else
            do while (low.gpm < high.gpm)
               low = commands.reduce_temperature_range(temperature_increment).run()
               logger.log_range(low)
            loop
         end if
      next

      logger.log("after gpm match")
      logger.log(low, high, low.load)

      return low
   end function

   protected function match_capacity_by_adjusting_compressor_capacity_factor(high as iplv_output, low as iplv_output) as iplv_output
      dim load_as_decimal = low.load * 0.01
      dim factor_increments as double() = {0.05, 0.01}
      for each factor_increment in factor_increments
         if low.capacity > (high.capacity * load_as_decimal)
            do while (low.capacity > (high.capacity * load_as_decimal))
               low = commands.decrease_compressor_capacity_factor(factor_increment).run()
               logger.log_compressor_capacity_factor(low)
            loop
         else
            do while (low.capacity < (high.capacity * load_as_decimal))
               low = commands.increase_compressor_capacity_factor(factor_increment).run()
               logger.log_compressor_capacity_factor(low)
            loop
         end if
      next
      logger.log("after capacity match")
      logger.log(low, high, load_as_decimal)

      return low
   end function

   protected function keep_condensing_temp_above_100_by_increasing_condenser_capacity_factor(low as iplv_output) as iplv_output
      do while (low.condensing_temp <= 90)
         low = commands.decrease_condenser_capacity_factor().run
         logger.log("cond temp:" & system.math.round(low.condensing_temp,1))
      loop
      logger.log("after adjusting condensing temp")
      logger.log(low)

      return low
   end function

end class

end namespace