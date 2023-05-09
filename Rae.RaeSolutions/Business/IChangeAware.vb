Namespace Rae.RaeSolutions.Business

   ''' <summary>
   ''' Implements are aware of changes to their state.
   ''' </summary>
   ''' <history></history>
   Public Interface IChangeAware(Of T)

      ''' <summary>
      ''' The original state after last load or save.
      ''' </summary>
      Property OriginalState() As T

      ''' <summary>
      ''' True if state changed from original.
      ''' </summary>
      ReadOnly Property StateChanged() As Boolean

   End Interface

End Namespace