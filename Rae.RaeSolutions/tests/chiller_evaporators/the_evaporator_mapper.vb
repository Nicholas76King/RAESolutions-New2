Imports rae.solutions.chiller_evaporators

<TestClass> _
Public Class the_evaporator_mapper

   <TestMethod> _
   Sub maps_rating_type_from_database_text_type_to_objects_enum_type
      Dim mapper = New Mapper()
      
      Dim dtoWithRaeType = New Mocks().GetEvaporatorDto()
      Dim evapWithRaeType = mapper.Map(dtoWithRaeType)
      Assert.IsTrue( evapWithRaeType.type = StandardRefrigeration.EvaporatorType.Rae )
      
      dtoWithRaeType.rating_type = "TX"
      evapWithRaeType = mapper.Map(dtoWithRaeType)
      Assert.IsTrue( evapWithRaeType.type = StandardRefrigeration.EvaporatorType.TX )
   End Sub
End Class
