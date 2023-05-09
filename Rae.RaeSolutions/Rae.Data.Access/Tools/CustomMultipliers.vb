Imports System.Text
Imports T1 = RAE.Data.Access.Tools.CustomMultipliersTable

Namespace Rae.Data.Access.Tools

Public Class CustomMultipliers
   Inherits DataAccessBase
   
   
   Sub New(connectionFactory As IConnectionFactory)
      MyBase.New(connectionFactory)
   End Sub
   
   Sub Insert(assignedBy As String, assignedTo As String, assignedOn As Date, _
              code As String, multiplier As Double, commission As Double)
      Dim sql As New StringBuilder()
            sql.AppendFormat("INSERT INTO [{0}] ({1},{2},{3},{4},{5},{6},{7}) VALUES " &
                       "(#{8}#,#{9}#,'{10}','{11}','{12}',{13},{14})",
                       T1.TableName, T1.LoggedOn, T1.AssignedOn, T1.AssignedBy, T1.AssignedTo,
                       T1.Code, T1.Multiplier, T1.Commission,
                       Date.Now.ToString, assignedOn, assignedBy, assignedTo,
                       code, multiplier, commission)

            Me.ExecuteNonQuery(sql.ToString)
   End Sub
   
End Class

End Namespace