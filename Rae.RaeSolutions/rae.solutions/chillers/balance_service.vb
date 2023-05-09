option strict off

imports rae.math.calculate

namespace rae.solutions.chillers

public class balance_service

   function get_hertz_multipliers(hertz as double) as polynomial_set
      dim m as polynomial_set
      
      if hertz = 50 then
         m.q = 0.833 'compressor at 50Hz runs at a lower speed
         m.w = 0.833
         m.a = 1
      elseif hertz = 60 then
         m.q = 1
         m.w = 1
         m.a = 1
      end if
      
      return m
   end function
   
   sub select_evaporating_temp_range(leaving_fluid_temp, byref lower_temp, byref upper_temp)
      'todo: make sure this isn't duplicated rae.solutions.chillers.chiller
      lower_temp = floor(leaving_fluid_temp, 5) - 10
      upper_temp = lower_temp + 15
   end sub

end class

end namespace