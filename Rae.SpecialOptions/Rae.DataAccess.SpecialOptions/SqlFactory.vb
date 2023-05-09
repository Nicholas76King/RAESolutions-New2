Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports System.Text
Imports T = Rae.DataAccess.SpecialOptions.SpecialOptionsTable

Namespace Rae.DataAccess.SpecialOptions

   ''' <summary>
   ''' SQL factory to generate SQL commands for data access.
   ''' </summary>
   Public Class SqlFactory


      Public Shared Function GetCreateSql(ByVal description As String, ByVal price As Double, _
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date) As String
         Dim cols As List(Of SqlColumn) = GetSpecialOptionsColumns(description, price, assignedBy, assignedTo, expirationDate)
         cols.Add(New SqlColumn(T.DateGenerated, SqlDataType.Date, Date.Now.ToString))
         Dim builder As New SqlBuilder(cols, T.TableName)
         Dim sql As String = builder.GenerateInsertCommand()

         Return sql
      End Function


      Public Shared Function GetUpdateSql(ByVal description As String, ByVal price As Double, _
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date, ByVal id As Integer) As String
         Dim cols As List(Of SqlColumn) = GetSpecialOptionsColumns(description, price, assignedBy, assignedTo, expirationDate)
         Dim criteriaCols As New List(Of SqlColumn)
         criteriaCols.Add(New SqlColumn(T.Id, SqlDataType.Number, id.ToString))
         Dim builder As New SqlBuilder(cols, T.TableName, criteriaCols)
         Dim sql As String = builder.GenerateUpdateCommand()

         Return sql
      End Function


      Public Shared Function GetRetrieveByIdSql(ByVal id As Integer) As String
         Dim sql As New StringBuilder
         sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}", _
            T.TableName, T.Id, id.ToString)
         Return sql.ToString
      End Function

      Public Shared Function GetRetrieveAllSql() As String
         Dim sql As New StringBuilder
         sql.AppendFormat("SELECT * FROM [{0}]", T.TableName)
         Return sql.ToString
      End Function

      Public Shared Function GetRetrieveByAssignedBySql(ByVal assignedBy As String) As String
         Dim sql As New StringBuilder
         sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}'", T.TableName, T.AssignedBy, assignedBy)
         Return sql.ToString
      End Function

      Public Shared Function GetRetrieveByAssignedToSql(ByVal assignedTo As String) As String
         Dim sql As New StringBuilder
         sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}'", T.TableName, T.AssignedTo, assignedTo)
         Return sql.ToString
      End Function





      Private Shared Function GetSpecialOptionsColumns(ByVal description As String, ByVal price As Double, _
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date) As List(Of SqlColumn)
         Dim cols As New List(Of SqlColumn)

         cols.Add(New SqlColumn(T.Description, SqlDataType.String, description))
         cols.Add(New SqlColumn(T.Price, SqlDataType.Number, price.ToString))
         cols.Add(New SqlColumn(T.AssignedBy, SqlDataType.String, assignedBy))
         cols.Add(New SqlColumn(T.AssignedTo, SqlDataType.String, assignedTo))
         cols.Add(New SqlColumn(T.ExpirationDate, SqlDataType.Date, expirationDate.ToString))

         Return cols
      End Function

   End Class

End Namespace