namespace rae.solutions.cu_uc_balances.balance_system

public class spec
   public ambient, room_temp as double
   public altitude, suction_line_loss as double
   public division as Rae.RaeSolutions.Business.Division
   public suction_temp as double

   property evaporating_temp as double
      set(value as double)
         _evaporating_temp = value
         suction_temp = _evaporating_temp - suction_line_loss
      end set
      get
         return _evaporating_temp
      end get
   end property

   private _evaporating_temp as double

end class

public class range_spec : inherits spec
   public min_room_temp, max_room_temp, room_temp_step as double
   public min_ambient, max_ambient, ambient_step as double

   sub import(spec as spec)
      altitude          = spec.altitude
      ambient           = spec.ambient
      division          = spec.division         
      evaporating_temp  = spec.evaporating_temp
      room_temp         = spec.room_temp
      suction_temp      = spec.suction_temp     
      suction_line_loss = spec.suction_line_loss
   end sub

end class

end namespace