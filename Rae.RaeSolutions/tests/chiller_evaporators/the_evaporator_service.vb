Imports rae.solutions.chiller_evaporators
Imports System.Diagnostics
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert

<TestClass, Ignore> _
public class bug : inherits test_base

   <TestMethod> _
   sub when_calling_acme_dll_on_same_thread_then_the_calls_are_completed_synchronously
      dim spec = new mocks().GetEvaporatorSpecWith1Circuit()
      
      log("before unmanaged call")
      dim service_1 = new Evaporator_service_factory().create()
      service_1.get_alternate_evaporators(spec)
      log("after unmanaged call")
      
      log("before unmanaged call")
      dim service_2 = new Evaporator_service_factory().create()
      service_2.get_alternate_evaporators(spec)
      log("after unmanaged call")
   end sub
   
   'the end logs are never called, so i'm assuming this process closes before they're done
   <TestMethod> _
   sub when_queueing_acme_dll_calls_in_thread_pool_then_it_still_works
      dim callback = new system.threading.WaitCallback(addressof unmanaged_call)
      
      log("queue: thread 1")
      dim state = new object()
      system.threading.ThreadPool.QueueUserWorkItem(callback, state)
      
      log("queue: thread 2")
      dim state_2 = new object()
      system.threading.threadPool.QueueUserWorkItem(callback, state_2)
      
      log("end: queueing")
   end sub
   
   private sub unmanaged_call(state as object)
      log("start: inside thread call")
      dim service = new Evaporator_service_factory().create()
      dim spec = new mocks().GetEvaporatorSpecWith1Circuit()
      dim evaporators = service.get_alternate_evaporators(spec)
      log(evaporators(0).model)
      log("end: inside thread call")
   end sub
   
   'hangs
   '<TestMethod> _
   'sub when_acme_dll_is_joined_then_
   '   dim thread = new system.threading.thread(addressof unmanaged_call)
   '   thread.start()
   '   thread.join()

   '   log("completed")
   'end sub
   
end class

<TestClass, Ignore> _
Public Class the_evaporator_service
   
   <TestMethod> _
   Sub can_filter_evaporators_for_rep
      Dim repo = New Evaporator_repository()
      Dim spec = New Mocks().GetEvaporatorSpecWith4CircuitsForRep()
      Dim svc  = New Evaporator_service(repo)
      
      Dim evaps = svc.get_alternate_evaporators(spec)
      
      IsTrue(evaps.Count = 2)
   End Sub
   
   <TestMethod> _
   Sub filters_by_length_and_part_number_for_reps
      Dim raeSpec = New Mocks().GetEvaporatorSpecWith4Circuits()
      Dim repSpec = New Mocks().GetEvaporatorSpecWith4CircuitsForRep()
      Dim repo = New Evaporator_repository()
      Dim svc  = New Evaporator_service(repo)
      
      Dim raeEvaps = svc.get_alternate_evaporators(raeSpec)
      Dim repEvaps = svc.get_alternate_evaporators(repSpec)
      
      IsTrue(repEvaps.Count < raeEvaps.Count)
   End Sub
   
   <TestMethod> _
   Sub gets_both_tx_and_rae_evaporators_with_1_circuit_when_1_circuit_is_specified
      Dim repo = New Evaporator_repository()
      Dim spec = New Mocks().GetEvaporatorSpecWith1Circuit()
      Dim svc  = New Evaporator_service(repo)
      Dim evaps = svc.get_alternate_evaporators(spec)
      
      dim svc_2 = new evaporator_service(repo)
      dim evaps_2 = svc_2.get_alternate_evaporators(spec)
      
      IsTrue(evaps.Count = 33)
   End Sub
   
End Class

<TestClass, Ignore> _
Public Class the_tx_evaporator_service
   <TestMethod> _
   Sub gets_all_tx_evaporators
      Dim repo = New Evaporator_repository()
      Dim spec = New Mocks().GetTxRatingSpec()
      Dim svc  = New Tx_evaporator_service(repo)
      
      Dim evaps = svc.get_evaporators(spec)
      
      IsTrue(evaps.Count = 28)
   End Sub
   
   <TestMethod> _
   Sub gets_approach_range_for_tx
      Dim repo = New Evaporator_repository()
      Dim spec = New Mocks().GetEvaporatorSpecWith1Circuit()
      Dim svc  = New Tx_evaporator_service(repo)
      
      Dim evap = svc.get_evaporators(spec)(0)
      Dim range = svc.get_approach_range(for:=evap, with:=spec)
      
      IsTrue(range.Count > 1)
   End Sub
End Class

<TestClass, Ignore> _
Public Class the_rae_evaporator_service
   <TestMethod> _
   Sub gets_rae_evaporators
      Dim repo = New Evaporator_repository()
      Dim spec = New Mocks().GetEvaporatorSpecWith4Circuits()
      Dim svc  = New Rae_evaporator_service(repo)
      
      Dim evaps = svc.get_evaporators(spec)
      
      IsTrue(evaps.Count = 7)
   End Sub
   
   <TestMethod> _
   Sub gets_approach_range_for_rae
      Dim repo = New Evaporator_repository()
      Dim spec = New Mocks().GetEvaporatorSpecWith4Circuits()
      Dim svc  = New Rae_evaporator_service(repo)
      
      Dim evap = svc.get_evaporators(spec)(0)
      Dim range = svc.get_approach_range(for:=evap, with:=spec)
      
      IsTrue(range.Count > 1)
      IsTrue(range(0).spec.approach <> range(1).spec.approach)
   End Sub
End Class
