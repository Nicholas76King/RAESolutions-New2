Imports System.Collections.Generic

Public Interface IItemSelector
   ReadOnly Property Items() As List(Of ItemInfo)
   ReadOnly Property Canceled() As Boolean
   Sub AskUser(projectId As String)
End Interface
