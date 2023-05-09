Namespace Rae.RaeSolutions.Business

   ''' <summary>
   ''' Defines methods to persist and retrieve implementer's data
   ''' </summary>
   Public Interface IPersistable

      ''' <summary>When implemented, persists object data so that it can be opened later.
      ''' </summary>
      Sub Save()


      ''' <summary>When implemented, loads object data into the instance executing this method.
      ''' </summary>
      Sub Load()

   End Interface

End Namespace