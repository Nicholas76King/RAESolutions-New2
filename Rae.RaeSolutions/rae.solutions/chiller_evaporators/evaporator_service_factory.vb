namespace rae.solutions.chiller_evaporators

public class evaporator_service_factory
   function create() as i_evaporator_service
      dim repo = new evaporator_repository()
      return new evaporator_service(repo)
   end function
end class

end namespace