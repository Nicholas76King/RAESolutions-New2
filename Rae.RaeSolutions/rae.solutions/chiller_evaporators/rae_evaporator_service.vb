Imports Rae.RaeSolutions.DataAccess.Chillers
Imports StandardRefrigeration

Namespace rae.solutions.chiller_evaporators

Class rae_evaporator_service
   
   Sub New(repo As i_evaporator_repository)
      Me.repo = repo
      mapper  = New mapper()
      evapFactory = New evaporator_factory(repo)
   End Sub
   
   Function get_evaporators(spec As evaporator_spec) As List(Of evaporator)
      Dim evaps  = New List(Of evaporator)
      Dim rating = New Rating()
      
      For i = 1 To 27
         Dim output = rating.RunRae(mapper.map(spec), i)
         Dim evap = evapFactory.Create(spec, output)
         
         If evap IsNot Nothing Then _
            evaps.Add(evap)
      Next
      
      Return evaps
   End Function
   
   Function get_approach_range([for] As evaporator, [with] As evaporator_spec) As evaporator_list
      Dim evaps = New evaporator_list()
      Dim spec = [with] : Dim evaporator = [for]
      
      For approach=4 To 12
         Dim evap = [get](evaporator, spec, at:=approach)
         If evap IsNot Nothing Then _
            evaps.Add(evap)
      Next
      
      Return evaps
   End Function
   
   Private repo As i_evaporator_repository
   Private evapFactory As evaporator_factory
   Private mapper As mapper
   
   Private Function [get](evap As evaporator, spec As evaporator_spec, at As Double) As evaporator
      ' update evaporating temperature based on approach
      spec.evaporating_temp = spec.leaving_fluid_temp - at
      
      Dim newEvap = New evaporator_factory(repo).Create(spec, evap)
      
      Return newEvap
   End Function
   
End Class

End Namespace
