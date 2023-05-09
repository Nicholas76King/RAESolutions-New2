imports Rae.RaeSolutions.Business
imports Rae.RaeSolutions.Business.Entities

namespace rae.solutions.drawings

structure chiller_electrical_spec
   public model, unit_type as string
   public voltage, phase, hertz as integer
   public pump_package as pumpequipment
   public et02 as boolean
   public division as division
end structure

end namespace
