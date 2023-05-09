Imports System.Collections.Generic

Namespace Persistence

Public Interface IAskUserToSave
   Function Ask() As SaveResponse
   Property Instructions() As String
   Property InputNames() As String()
   Property Commands() As IDictionary(Of String, String)
End Interface

End Namespace
