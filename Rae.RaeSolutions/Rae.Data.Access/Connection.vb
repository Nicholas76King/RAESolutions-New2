Imports Rae.RaeSolutions.DataAccess.Common
Imports System.Data

Namespace Rae.Data.Access
'Picker, Selector, Choose
Public Class Connection

   Function Choose(name As ConnectionName) As IDbConnection
      Dim connectionString As String
      connectionString = getConnectionString(name)

      Dim connection As IDbConnection
      connection = New ConnectionFactory(connectionString).Create()

      Return connection
   End Function


#Region " Internal"

   Private Function getConnectionString(ByVal name As ConnectionName) As String
      Dim dbPath As String
      dbPath = System.IO.Path.Combine(DbFolderPath, name.value & ".mdb")

      Dim connectionString As String
      connectionString = GetMicrosoftAccessConnectionString(dbPath)

      Return connectionString
   End Function

   ' ServerIsAvailable
   ' ProjectIsCheckedOut

   ' Local
   ' Server
   'GetConnection()

   'GetConnection(serverIsAvailable, projectIsCheckedOut)
   'GetConnection("Local")
   'GetConnection("Server")
   'GetConnection("LocalTest")

#End Region

End Class
End Namespace