Imports System.Data

Namespace Rae.Data.Access

Public Interface IConnectionFactory
   Function Create() As IDbConnection
End Interface

End Namespace
