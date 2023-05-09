Imports Rae.RaeSolutions.DataAccess.Chillers
Imports StandardRefrigeration
Imports StandardRefrigeration.EvaporatorType

Namespace rae.solutions.chiller_evaporators

Class tx_evaporator_service

   Sub New(repo As i_evaporator_repository)
      Me.repo = repo
      mapper = New mapper()
   End Sub

   Function get_evaporators(spec As evaporator_spec) As List(Of evaporator)
      Dim evaps  = New List(Of evaporator)
      Dim rating = New Rating()
      
      Dim evapTypes As EvaporatorType() = {TX, TXC, TXG}
      Dim ratingSpec = mapper.map(spec)
      
      For Each evapType In evapTypes
         Dim nominalCapacities = repo.get_nominal_capacities(evapType.ToString, spec.num_circuits)
         For Each nominalCapacity In nominalCapacities
            Dim ratingOutput = rating.RunTx(ratingSpec, nominalCapacity, evapType)
            
            Dim evap = New evaporator_factory(repo).Create(spec, ratingOutput)
            
            If evap IsNot Nothing Then _
               evaps.Add(evap)
         Next
      Next
      
      Return evaps
   End Function
   
   Function get_approach_range([for] As evaporator, [with] As evaporator_spec) As evaporator_list
      Dim evaps = New evaporator_list()
      Dim evaporator = [for] : Dim spec = [with]
      
      For approach=4 To 12
         Dim evap = [get](evaporator, spec, at:=approach)
         If evap IsNot Nothing Then _
            evaps.Add(evap)
      Next
      
      Return evaps
   End Function
   
   Private repo As i_evaporator_repository
   Private mapper As mapper
   
   Private Function [get](evap As evaporator, spec As evaporator_spec, at As Double) As evaporator
      ' update evaporating temperature based on approach
      spec.evaporating_temp = spec.leaving_fluid_temp - at
      
      Dim newEvap = New evaporator_factory(repo).Create(spec, evap)
      
      Return newEvap
   End Function

End Class

End Namespace