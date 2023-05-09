namespace rae.solutions.chiller_evaporators

interface i_evaporator_repository
   function get_evaporator_by_model(model as string) as evaporator_dto
   function get_evaporator_by_part_number(part_number as string) as evaporator_dto
   function get_nominal_capacities(rating_type as string, number_of_circuits as integer) as ilist(of double)
end interface

end namespace
