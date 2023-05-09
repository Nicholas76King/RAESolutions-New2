Imports System.Collections.Generic

Public Interface IItemSelection
   ReadOnly Property Items() As List(Of ItemInfo)
   ReadOnly Property Canceled() As Boolean
   Sub AskUser()
End Interface
