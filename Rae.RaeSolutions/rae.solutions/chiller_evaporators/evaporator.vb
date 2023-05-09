imports StandardRefrigeration

namespace rae.solutions.chiller_evaporators

public class evaporator

   sub new()
      warnings = new list(of string)
   end sub
   
   ' from db
   public model as string
   public old_model as string ' old standard refrigeration model
   public rae_part_number, evaporator_part_number, catalog_model as string
   public nominal_tons as double
   public length, width, height as double
   public connection_size as string
   public num_circuits as integer
   
   readonly property approach as double
      get
         return spec.approach
      end get
   end property
   
   ' from dll
   property capacity as double
   
   property fluid_pressure_drop as double
   property fluid_flow as double
   ''' <summary>refrigerant pressure drop in psid</summary>
   property refrigerant_pressure_drop as double
   ''' <summary>refrigerant flow in lbm/hr</summary>
   property refrigerant_flow as double
   ''' <summary>fluid nozzle rho v^2 [lbm/ft*s^2]</summary>
   property fluid_nozzle as double
   
   public specific_gravity as double ' lbm/ft^3
   public type as evaporatortype
   public rae_index as integer
   public spec as evaporator_spec
   
   property warnings as list(of string)
   
   readonly property warnings_message as string
      get
         dim msg as string = ""
         
         for each warning in warnings
            msg &= warning & system.environment.newline
         next
         
         return msg
      end get
   end property
   
   ' todo: move back to a mapper, this is only necessary for creating a new evap
   friend sub load(output as rating.output)
      capacity                = output.capacity
      fluid_flow              = output.fluidflow
      fluid_pressure_drop     = output.fluidpressuredrop
      refrigerant_flow        = output.refrigerantflow
      refrigerant_pressure_drop = output.refrigerantpressuredrop
      specific_gravity        = output.specificgravity
      fluid_nozzle            = output.fluidnozzle
      
      warnings.addrange(output.warnings)
   end sub
   
end class

end namespace