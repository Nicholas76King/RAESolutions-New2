Imports Rae.Io.Text
Imports StandardRefrigeration

namespace rae.solutions.chiller_evaporators

Class evaporator_rating

   Function execute(dto As evaporator_dto, spec As evaporator_spec) As Rating.Output
      Dim rating As Rating.Output
   
      SyncLock Me
         Dim r = New Rating()
         Dim mapper = New mapper()
         
         Select Case dto.rating_type
            Case "RAE"
               rating = r.RunRae(mapper.map(spec), dto.rae_index)
            Case "TX", "TXC", "TXG"
               Dim evapType As EvaporatorType
               GetEnumValue(Of EvaporatorType)(dto.rating_type, evapType)
               rating = r.RunTx(mapper.map(spec), dto.nominal_tons, evapType)
            Case Else
               Throw New Exception("The approach range cannot be determined. The evaporator type is invalid.")
         End Select
      End SyncLock
      
      Return rating
   End Function
   
End Class

End Namespace