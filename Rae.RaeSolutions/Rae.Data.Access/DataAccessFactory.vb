Imports Rae.Configuration
Imports Rae.Reflection
Imports Rae.RaeSolutions.DataAccess
Imports System.Configuration

Namespace Rae.Data.Access

Public Class DataAccessFactory(Of T As IConnectToDatabase)
   
   Shared Function Create() As T
      Dim connString = readConfig(GetType(T).Name)
      
      Dim connFactory As IConnectionFactory = New ConnectionFactory(connString)
      
      Dim dataAccess As T = reflector.Construct(Of T)(connFactory)

      Return dataAccess
   End Function

   
   Private Shared Function readConfig(name As String) As String
      Dim appSettings = ConfigFactory.Create()

      Dim connString = appSettings.Read(name)

      connString = connString.Replace(".\", Common.DbFolderPath)

      Return connString
   End Function

End Class

End Namespace