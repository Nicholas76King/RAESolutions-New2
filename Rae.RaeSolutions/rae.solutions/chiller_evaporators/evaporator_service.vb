Imports StandardRefrigeration

namespace rae.solutions.chiller_evaporators

class thread_safe_evaporator_service : implements i_evaporator_service

   private service as i_evaporator_service
   private processing as boolean = false
   
   sub new(repository as i_evaporator_repository)
      service = new evaporator_service(repository)
   end sub

   function get_alternate_evaporators(spec as evaporator_spec) as list(of evaporator) _
   implements i_evaporator_service.get_alternate_evaporators
      while processing
         system.threading.thread.currentThread.sleep(1000)
      end while
      
      processing = true
      dim evaporators = service.get_alternate_evaporators(spec)
      processing = false
      
      return evaporators
   end function

   function get_alternate_evaporators_for_rep(spec as evaporator_spec, standard_evaporator_part_number as string) as system.collections.generic.list(of evaporator) _
   implements i_evaporator_service.get_alternate_evaporators_for_rep
      return service.get_alternate_evaporators_for_rep(spec, standard_evaporator_part_number)
   end function

   function get_approach_range([for] as evaporator, [with] as evaporator_spec) as evaporator_list _
   implements i_evaporator_service.get_approach_range
      return service.get_approach_range([for], [with])
   end function

   function get_approach_range(evaporator_part_number as string, spec as evaporator_spec) as evaporator_list _
   implements i_evaporator_service.get_approach_range
      return service.get_approach_range(evaporator_part_number, spec)
   end function
   
end class

class evaporator_service : implements i_evaporator_service

   private repo as i_evaporator_repository

   sub new(repo as i_evaporator_repository)
      me.repo = repo
   end sub

   function get_alternate_evaporators(spec as evaporator_spec) as List(Of evaporator) _
   implements i_evaporator_service.get_alternate_evaporators
      system.diagnostics.debug.WriteLine("start: unmanaged code, thread id:" & system.threading.thread.CurrentThread.ManagedThreadId)
      dim evaps = New List(Of evaporator)
   
      SyncLock Me
         dim raeEvaps = New rae_evaporator_service(repo).get_evaporators(spec)
         dim txEvaps  = New tx_evaporator_service(repo).get_evaporators(spec)
         evaps.AddRange(raeEvaps)
         evaps.AddRange(txEvaps)
      End SyncLock

      system.diagnostics.debug.WriteLine("end: unmanaged code, thread id:" & system.threading.thread.CurrentThread.ManagedThreadId)
      return evaps
   end function
   
   function get_alternate_evaporators_for_reps(spec as evaporator_spec, standard_evaporator_part_number as String) as List(of evaporator) _
   implements i_evaporator_service.get_alternate_evaporators_for_rep
      dim evaporators = get_alternate_evaporators(spec)
      dim standard_evaporator = repo.get_evaporator_by_part_number(standard_evaporator_part_number)
      
      evaporators = filter_by_part_number(evaporators, standard_evaporator.evaporator_part_number)
      evaporators = filter_r22_evaporators_that_may_not_work_with_r134a(evaporators)
      evaporators = filter_by_nominal_tons(evaporators, standard_evaporator.nominal_tons)
      
      return evaporators
   end function
   
   private function filter_r22_evaporators_that_may_not_work_with_r134a(evaporators as list(of evaporator)) as list(of evaporator)
      dim filtered_evaporators = new list(of evaporator)
            ' modify to not allow any c00270*  this will be the only exclusion.


            For Each evaporator In evaporators

                If Not evaporator.rae_part_number.ToUpper.StartsWith("C00270") Then
                    filtered_evaporators.Add(evaporator)
                End If

            Next
      
      return filtered_evaporators
   end function
   
   private function filter_by_nominal_tons(evaporators as list(of evaporator), standard_nominal_tons as double) as list(of evaporator)
      evaporators.sort( new comparison(of evaporator)(addressof compare_by_nominal_tons) )
      
      dim filtered_evaporators = new list(of evaporator)
      
      for i as integer = 0 to evaporators.count - 1
         if evaporators(i).nominal_tons = standard_nominal_tons then
            if i > 0 then filtered_evaporators.add(evaporators(i-1))
            filtered_evaporators.add(evaporators(i))
            if i < evaporators.count-1 then filtered_evaporators.add(evaporators(i+1))
            if i < evaporators.count-2 then filtered_evaporators.add(evaporators(i+2))
            exit for
         end if
      next
      
      return filtered_evaporators
   end function
   
   private function compare_by_nominal_tons(x as evaporator, y as evaporator) as integer
      return cint(x.nominal_tons - y.nominal_tons)
   end function
   
   private function filter_by_part_number(evaporators as list(of evaporator), standard_part_number as string) as list(of evaporator)
      dim filtered_evaporators = new list(of evaporator)
      dim starts_with = standard_part_number.substring(0, 3)
      for each evaporator in evaporators
         if evaporator.evaporator_part_number.startsWith(starts_with) then _
            filtered_evaporators.add(evaporator)
      next
      
      return filtered_evaporators
   end function
   
   'model > rae/tx
   function get_approach_range([for] as evaporator, [with] as evaporator_spec) as evaporator_list _
   implements i_evaporator_service.get_approach_range
      dim evap = [for] : dim spec = [with]
      dim range as evaporator_list
      
      ' TODO: create factory for sub services or move them into this one, dto contains rae index and nominal capacity now
      'svc = svcFactory.Create(for:=evap, with:=spec)
      'dim range = svc.GetApproachRange(for:=evap, with:=spec)
      
      if evap.type = EvaporatorType.RAE
         dim svc = New rae_evaporator_service(repo) ' TODO: ServiceFactory.Create([for].Type)
         range = svc.get_approach_range(for:=evap, with:=spec)
      else if evap.type = EvaporatorType.TX _
      OrElse evap.type = EvaporatorType.TXC _
      OrElse evap.type = EvaporatorType.TXG Then
         dim svc = New tx_evaporator_service(repo)
         range = svc.get_approach_range(for:=evap, with:=spec)
      else
         throw new Exception("The approach range cannot be determined. The evaporator type is invalid.")
      end If
      
      return range
   end function
   
   function get_approach_range(evaporator_part_number as String, spec as evaporator_spec) as evaporator_list _
   implements i_evaporator_service.get_approach_range
      dim evap = New evaporator_factory(repo).Create(spec, evaporator_part_number)
      
      if evap is nothing then
         throw New StandardRefrigerationException("The evaporator had an error or exceeded a limit.")
      end If
      
      return get_approach_range(for:=evap, with:=spec)
   end function

end class

Public class StandardRefrigerationException : Inherits Exception
   Sub New(message as String)
      MyBase.New(message)
   end Sub
end class

end Namespace