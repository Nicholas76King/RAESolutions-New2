Imports Rae.RaeSolutions.DataAccess
Imports System.Data

Namespace Rae.RaeSolutions.Business.Entities.Cofans

Class repository

    Function get_connection() As IDbConnection        
        Return Common.CreateConnection(settings.db_file_path)
    End Function

End Class

End Namespace