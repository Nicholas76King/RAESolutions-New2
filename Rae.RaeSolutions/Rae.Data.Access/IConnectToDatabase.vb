Namespace Rae.Data.Access

Public Interface IConnectToDatabase
   ReadOnly Property ConnectionFactory As IConnectionFactory
   
   ' should also have this constructor if using DataAccessFactory
   'Sub New(connectionFactory As IConnectionFactory)
End Interface

End Namespace