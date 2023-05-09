namespace rae.solutions.unit_coolers

public class unit_cooler_list : inherits list(of unit_cooler)

   shadows sub sort()
      dim model_comparison = new comparison(of unit_cooler)( addressof sort_by_model )
      mybase.sort(model_comparison)
   end sub

   private function sort_by_model(x as unit_cooler, y as unit_cooler) as integer
      if x.series = y.series
         if x.refrigerant = y.refrigerant
            if x.fpi = y.fpi
               if x.fan_quantity = y.fan_quantity
                  if x.model_capacity = y.model_capacity
                     return 0
                  else
                     return cint(x.model_capacity - y.model_capacity)
                  end if
               else
                  return cint(x.fan_quantity - y.fan_quantity)
               end if
            else
               return cint(x.fpi - y.fpi)
            end if
         else
            return string.compare(x.refrigerant.toString, y.refrigerant.toString)
         end if
      else
         return string.compare(x.series, y.series)
      end if
   end function

   sub remove_ibrs_until_multiplier_equation_is_available_from_jim_wilson()
      me.RemoveAll( function(x) x.series like "*IBR" )
   end sub

end class

end namespace