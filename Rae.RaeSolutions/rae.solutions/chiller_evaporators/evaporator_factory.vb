Imports StandardRefrigeration

namespace rae.solutions.chiller_evaporators

Class evaporator_factory

   Sub New(repo As i_evaporator_repository)
      Me.repo = repo
      mapper = New mapper()
   End Sub
   
   ''' <summary>creates/rates evaporator at a different approach</summary>
   Function Create(spec As evaporator_spec, evap As evaporator) As evaporator
      Dim ratingOutput = New evaporator_rating().execute(mapper.Map(evap), spec)
      
      If ratingOutput.IsValid Then
         Dim dto = repo.get_evaporator_by_model(ratingOutput.Model)
         evap = buildEvap(ratingOutput, dto, spec)
      Else
         evap = Nothing
      End If
      
      Return evap
   End Function
   
   ''' <summary>creates evaporator based on a rating</summary>
   Function Create(spec As evaporator_spec, ratingOutput As Rating.Output) As evaporator
      Dim evap As evaporator
      
      If ratingOutput.IsValid Then
         Dim dto = repo.get_evaporator_by_model(ratingOutput.Model)
         evap = buildEvap(ratingOutput, dto, spec)
      End If
      
      Return evap
   End Function
   
   ''' <summary>creates evaporator based on evaporator part number, after chiller model selected</summary>
   ''' <remarks>the chiller data references the evaporator data by the evaporator part number</remarks>   
   Function Create(spec As evaporator_spec, evaporatorPartNum As String) As evaporator
      Dim dto = repo.get_evaporator_by_part_number(evaporatorPartNum)
      
      Dim rating = New evaporator_rating().execute(dto, spec)
      
      Dim evap As evaporator
      
      If rating.IsValid Then
         evap = buildEvap(rating, dto, spec)
      End If
      'todo: return acme warning, if fail
      Return evap
   End Function
   
   Private repo As i_evaporator_repository
   Private mapper As mapper
   Private employee, rep, lengthIsNotTooLong, hasRaePartNumber, numCircuitsMatch, refrigerantPressureDropIsInRange As Boolean
   Private approachIsInRange, fluidPressureDropIsInRange, fluidNozzleIsInRange As Boolean
   
   Private Function buildEvap(ratingOutput As Rating.Output, dto As evaporator_dto, spec As evaporator_spec) As evaporator
      Dim evap = mapper.map(dto)
      evap.load(ratingOutput)
      
      evap.spec = spec
      setupFilter(spec, evap)
      
      ' TODO: add back And refrigerantPressureDropIsInRange
      If numCircuitsMatch
         If Not refrigerantPressureDropIsInRange Then _
            evap.warnings.Add("rae: refrigeration pressure drop is not in range")
         If Not approachIsInRange Then _
            evap.warnings.Add("rae: approach is not in range; approach must be greater than 5")
         If Not fluidPressureDropIsInRange Then _
            evap.warnings.Add("rae: fluid pressure drop is not in range")
         If Not fluidNozzleIsInRange Then _
            evap.warnings.Add("rae: fluid nozzle rho v^2 < 1500 lbm/ft*s^2")
         
         'todo: If Not leavingGasVelocityIsInRange Then _
         '   evap.Warnings.Add("rae: leaving gas velocity should not be greater than 10 fps at minimum load")
         
         If employee Or (rep And lengthIsNotTooLong And hasRaePartNumber)
            ' valid
         Else
            evap = Nothing
         End If
      Else
         evap = Nothing
      End If
      
      Return evap
   End Function

   Private Sub setupFilter(spec As evaporator_spec, evap As evaporator)
      employee = spec.authorization = 1
      rep      = Not employee
      
      ' TODO: 0.01 is workaround until figure out why precision is off 70.88 <= 70.879997
      lengthIsNotTooLong = evap.length <= spec.length + 0.01
      hasRaePartNumber   = evap.rae_part_number.StartsWith("C")
      numCircuitsMatch   = evap.num_circuits = spec.num_circuits
      refrigerantPressureDropIsInRange = (evap.refrigerant_pressure_drop >= 1.5 And evap.refrigerant_pressure_drop <= 5) _
         OrElse (spec.refrigerant = StandardRefrigeration.Refrigerant.R134a AndAlso evap.refrigerant_pressure_drop >= 1.5 And evap.refrigerant_pressure_drop <= 4)
      approachIsInRange = (employee And evap.approach >= 5) _
                   OrElse (rep And evap.approach >=6)
      fluidPressureDropIsInRange = (spec.fluid = Fluid.Water AndAlso evap.fluid_pressure_drop >= 1 And evap.fluid_pressure_drop <= 6.5) _
                            OrElse ((spec.fluid = Fluid.Ethylene Or spec.fluid = Fluid.Propylene) _
                                    And evap.fluid_pressure_drop >= 2 And evap.fluid_pressure_drop <= 10)
      fluidNozzleIsInRange = evap.fluid_nozzle < 1500
   End Sub
  
End Class

End Namespace