namespace evaporative_condenser_chillers.sound_attenuation_option

class motor_hp_list
   private hps() as double
   
   public original, upsize, downsize as double
   
   sub new(original_hp as double)
      hps = new double() {3, 5, 7.5, 10, 15, 20, 25, 30, 35}
      me.original = original_hp
      
      dim index_of_original_hp = hps.indexOf(hps, original_hp)
      
      if is_not_largest(index_of_original_hp)
         upsize = hps(index_of_original_hp + 1)
      else
         upsize = original_hp
      end if
      
      if is_not_smallest(index_of_original_hp)
         downsize = hps(index_of_original_hp - 1)
      else
         downsize = original_hp
      end if
   end sub
   
   private function is_not_largest(index as integer) as boolean
      return index < hps.length - 1
   end function
   
   private function is_not_smallest(index as integer) as boolean
      return index > 0
   end function
end class

end namespace