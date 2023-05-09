Imports System.Collections.Generic

Namespace Persistence

Public Class AskUserToSaveFactory

   Shared Function Create( _
   instructions As String, _
   inputs As String(), _
   commands As IDictionary(Of String, String)) As IAskUserToSave
      Return New AskUserToSave(instructions, inputs, commands)
   End Function

End Class

End Namespace
