Imports StandardRefrigeration

namespace rae.solutions.chiller_evaporators

public structure evaporator_spec
   public refrigerant as StandardRefrigeration.refrigerant
   public fluid as fluid
   public glycol_percentage as double
   ''' <summary>number of refrigeration circuits</summary>
   public num_circuits as integer
   public entering_fluid_temp as double ' valid range ?
   public leaving_fluid_temp as double  ' valid range ?
   public evaporating_temp as double   ' valid range ?
   ''' <summary>length of the default evaporator - used to select similarly sized alternate evaporators</summary>
   public length as double
   ''' <summary>1=employee; 3=rep</summary>
   public authorization as integer
   function approach as double
      return leaving_fluid_temp - evaporating_temp
   end function
end structure

end namespace