Public Interface IProjectSelector
   ReadOnly Property ProjectId As String
   ReadOnly Property Canceled As Boolean
   Sub AskUser()
End Interface
