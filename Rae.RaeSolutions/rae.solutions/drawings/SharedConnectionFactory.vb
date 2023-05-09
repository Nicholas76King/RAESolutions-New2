Imports System.Data

Namespace rae.solutions.drawings

''' <summary>Allows database connection to be reused without being closed</summary>
Public Class SharedConnectionFactory

   Sub New(dbPath As String)
      Me.dbPath = dbPath
   End Sub
   
   Public Count As Integer
   Public Auto As Boolean
   Public Max As Integer = 2000

   Function Create() As IDbConnection
      Count += 1
      If connection Is Nothing Then _
         connection = Rae.RaeSolutions.DataAccess.Common.CreateConnection(dbPath)
      If Auto And Count > Max Then
         Reset()
      End If
      Return connection
   End Function

   Sub Close()
      If connection IsNot Nothing _
      AndAlso connection.State <> ConnectionState.Closed Then
         connection.Close
      End If
   End Sub
   
   Sub Reset()
      Dim wasOpen = connection.State = ConnectionState.Open
      Close()
      Count = 0
      If wasOpen Then _
         connection.Open()
   End Sub

   Private connection As IDbConnection
   Private dbPath As String

End Class

End Namespace
