namespace rae.solutions.cu_uc_balances.balance_system

public class unit_evaluator
   structure results
      public condensing_unit_result as condensing_units.Balance.Result
      public condensing_unit_capacity, evaporator_capacity as double
      public condensing_unit_w, condensing_unit_kw as double
      public condensing_temp as double
   end structure

   private condensing_unit as condensing_unit
   private unit_coolers as unit_cooler_list
   private custom_unit_cooler as custom_unit_cooler
   private spec as spec
   private compressor_repository as compressors.i_compressor_repository

   sub new(condensing_unit as condensing_unit, unit_coolers as unit_cooler_list, custom_unit_cooler as custom_unit_cooler, spec as spec)
      me.condensing_unit    = condensing_unit
      me.unit_coolers       = unit_coolers
      me.custom_unit_cooler = custom_unit_cooler
      me.spec               = spec
      compressor_repository = new compressors.compressor_repository()
   end sub

   function update(evaporating_temp as double) as results
      spec.evaporating_temp = evaporating_temp
      return evaluate()
   end function

   function evaluate() as results
      static balance as new condensing_units.Balance(compressor_repository)

      dim total_evaporator_capacity  = unit_coolers.total_capacity_at(spec.evaporating_temp, spec.room_temp)
      dim custom_evaporator_capacity = if(custom_unit_cooler isnot nothing, custom_unit_cooler.capacity * custom_unit_cooler.quantity, 0)
      total_evaporator_capacity     += custom_evaporator_capacity

      dim conditions as condensing_units.Balance.Standard_Conditions
      conditions.altitude = spec.altitude
      conditions.ambient = spec.ambient
      conditions.suction = spec.suction_temp
            conditions.voltage = 460 ' Was 0, changed to 460 when N Series Units added
      
            Dim result = balance.this(condensing_unit.model, at:=conditions)

      dim results as results
      results.condensing_unit_result   = result
      results.evaporator_capacity      = total_evaporator_capacity
      results.condensing_unit_capacity = result.point.capacity
      results.condensing_unit_w        = result.point.unit_kw * 1000
      results.condensing_unit_kw       = result.point.unit_kw
      results.condensing_temp          = result.point.condensing_temp

      return results
   end function

end class

end namespace