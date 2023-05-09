namespace rae.solutions.chiller_evaporators

public interface i_evaporator_service
   function get_alternate_evaporators(spec as evaporator_spec) as List(Of evaporator)
   function get_alternate_evaporators_for_rep(spec as evaporator_spec, standard_evaporator_part_number as string) as List(of evaporator)
   function get_approach_range([for] as evaporator, [with] as evaporator_spec) As evaporator_list
   function get_approach_range(evaporator_part_number as string, spec as evaporator_spec) as evaporator_list
end interface

end namespace
