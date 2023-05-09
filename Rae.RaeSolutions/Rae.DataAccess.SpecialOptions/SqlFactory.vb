Imports System.Collections.Generic
Imports Rae.Data.Sql
Imports System.Text
Imports T1 = RAE.DataAccess.SpecialOptions.SpecialOptionsTable

Namespace Rae.DataAccess.SpecialOptions

   ''' <summary>
   ''' SQL factory to generate SQL commands for data access.
   ''' </summary>
   Public Class SqlFactory


      Public Shared Function GetCreateSql(ByVal description As String, ByVal price As Double, _
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date) As String
         Dim cols As List(Of SqlColumn) = GetSpecialOptionsColumns(description, price, assignedBy, assignedTo, expirationDate)
            cols.Add(New SqlColumn(T1.DateGenerated, SqlDataType.Date, Date.Now.ToString))
            Dim builder As New SqlBuilder(cols, T1.TableName)
            Dim sql As String = builder.GenerateInsertCommand()

            Return sql
        End Function


        Public Shared Function GetUpdateSql(ByVal description As String, ByVal price As Double,
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date, ByVal id As Integer) As String
            Dim cols As List(Of SqlColumn) = GetSpecialOptionsColumns(description, price, assignedBy, assignedTo, expirationDate)
            Dim criteriaCols As New List(Of SqlColumn)
            criteriaCols.Add(New SqlColumn(T1.Id, SqlDataType.Number, id.ToString))
            Dim builder As New SqlBuilder(cols, T1.TableName, criteriaCols)
            Dim sql As String = builder.GenerateUpdateCommand()

            Return sql
        End Function


        Public Shared Function GetRetrieveByIdSql(ByVal id As Integer) As String
            Dim sql As New StringBuilder
            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = {2}",
            T1.TableName, T1.Id, id.ToString)
            Return sql.ToString
        End Function

        Public Shared Function GetRetrieveAllSql() As String
            Dim sql As New StringBuilder
            sql.AppendFormat("SELECT * FROM [{0}]", T1.TableName)
            Return sql.ToString
        End Function

        Public Shared Function GetRetrieveByAssignedBySql(ByVal assignedBy As String) As String
            Dim sql As New StringBuilder
            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}'", T1.TableName, T1.AssignedBy, assignedBy)
            Return sql.ToString
        End Function

        Public Shared Function GetRetrieveByAssignedToSql(ByVal assignedTo As String) As String
            Dim sql As New StringBuilder
            sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]='{2}'", T1.TableName, T1.AssignedTo, assignedTo)
            Return sql.ToString
        End Function





        Private Shared Function GetSpecialOptionsColumns(ByVal description As String, ByVal price As Double,
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date) As List(Of SqlColumn)
            Dim cols As New List(Of SqlColumn)

            cols.Add(New SqlColumn(T1.Description, SqlDataType.String, description))
            cols.Add(New SqlColumn(T1.Price, SqlDataType.Number, price.ToString))
            cols.Add(New SqlColumn(T1.AssignedBy, SqlDataType.String, assignedBy))
            cols.Add(New SqlColumn(T1.AssignedTo, SqlDataType.String, assignedTo))
            cols.Add(New SqlColumn(T1.ExpirationDate, SqlDataType.Date, expirationDate.ToString))

            Return cols
      End Function

   End Class

End Namespace