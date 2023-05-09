Imports CNull = Rae.ConvertNull
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Data.Sql
Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports OT = Rae.RaeSolutions.DataAccess.Projects.Tables.OtherEquipmentCostsTable
Imports OET = Rae.RaeSolutions.DataAccess.Projects.Tables.OtherEquipmentCostsTable


Namespace Rae.RaeSolutions.DataAccess.Projects

   ''' <summary>
   ''' Provides data access to OtherEquipmentCosts table.
   ''' </summary>
   Public Class OtherEquipmentCostsDA


      ''' <summary>
      ''' Creates all of equipment's other costs.
      ''' </summary>
      ''' <param name="equipment">
      ''' Equipment containing other costs to create.
      ''' </param>
      Public Overloads Shared Sub Create(ByVal equipment As EquipmentItem)
         Dim connection As IDbConnection
         Dim command As IDbCommand
         Dim connectionString, sql As String

         connectionString = Common.GetConnectionString(Common.ProjectsDbPath)
         connection = Common.CreateConnection(Common.ProjectsDbPath) 'New OleDbConnection(connectionString)

         Try
            connection.Open()

            ' inserts all other costs
            For Each other As KeyValuePair(Of String, Double) In equipment.pricing.others
               sql = SqlFactory.GetInsertOtherEquipmentCostsSql(equipment.id.Id, other.Key, other.Value, equipment.revision)
               command = connection.CreateCommand 'New OleDbCommand(sql, connection)
               command.CommandText = sql
               command.ExecuteNonQuery()
            Next

         Catch ex As DataException
            Throw ex
         Finally
            If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         End Try
      End Sub


      ''' <summary>
      ''' Creates all of equipment's other costs.
      ''' </summary>
      ''' <param name="equipment">
      ''' Equipment containing other costs to create.
      ''' </param>
      ''' <param name="connection">
      ''' Open connection to database.
      ''' </param>
      ''' <param name="transaction">
      ''' Transaction that has already been started.
      ''' </param>
      Friend Overloads Shared Sub Create(ByVal connection As IDbConnection, ByVal transaction As IDbTransaction, _
      ByVal equipment As EquipmentItem)
         Dim command As IDbCommand
         Dim sql As String

         ' inserts all other costs
         For Each other As KeyValuePair(Of String, Double) In equipment.pricing.others
            sql = SqlFactory.GetInsertOtherEquipmentCostsSql(equipment.id.Id, other.Key, other.Value, equipment.revision)
            command = connection.CreateCommand 'New OleDbCommand(sql, connection)
            command.CommandText = sql
            command.ExecuteNonQuery()
         Next
      End Sub


      ''' <summary>
      ''' Retrieves dictionary of other equipment costs.
      ''' </summary>
      ''' <param name="equipmentId">
      ''' Id of equipment.
      ''' </param>
      ''' <returns>
      ''' Dictionary of other euqipment costs.
      ''' </returns>
      Public Shared Function Retrieve(ByVal equipmentId As String, ByVal revision As Single) As Dictionary(Of String, Double)
         Dim reader As IDataReader
         Dim sql As New StringBuilder
         Dim others As New Dictionary(Of String, Double)
         Dim description As String, price As Double

         Dim connection = Common.CreateConnection(Common.ProjectsDbPath)

         ' SELECT * FROM [OtherEquipmentCosts] WHERE [EquipmentId] = '..' AND Revision=#
         sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}] = '{2}' AND [{3}]={4}", _
            OT.TableName, OT.EquipmentID, equipmentId, OT.Revision, revision.ToString)
         Dim command = connection.CreateCommand()
         command.CommandText = sql.ToString

         Try
            connection.Open()
            reader = command.ExecuteReader()
            While reader.Read
               description = reader(OT.Description).ToString
               price = CNull.ToDouble(reader(OT.Price))
               others.Add(description, price)
            End While
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> System.Data.ConnectionState.Closed Then connection.Close()
         End Try

         Return others
      End Function





      ''' <summary>
      ''' Get SQL factory for other equipment costs.
      ''' </summary>
      Private Class SqlFactory

         ''' <summary>
         ''' Get SQL command to insert other equipment costs.
         ''' </summary>
         Public Shared Function GetInsertOtherEquipmentCostsSql(ByVal equipmentId As String, _
         ByVal description As String, ByVal price As Double, ByVal revision As Single) As String
            Dim affectedColumns As List(Of SqlColumn) = OtherEquipmentCostsColumns(equipmentId, description, price, revision)
            Dim builder As New SqlBuilder(affectedColumns, OET.TableName)

            Return builder.GenerateInsertCommand()
         End Function


         ''' <summary>
         ''' Other equipment costs columns
         ''' </summary>
         Private Shared Function OtherEquipmentCostsColumns( _
         ByVal equipmentId As String, ByVal description As String, ByVal price As Double, ByVal revision As Single) As List(Of SqlColumn)
            Dim columns As New List(Of SqlColumn)

            With columns
               .Add(New SqlColumn(OET.EquipmentID, SqlDataType.String, equipmentId))
               .Add(New SqlColumn(OET.Revision, SqlDataType.Number, revision.ToString))
               .Add(New SqlColumn(OET.Price, SqlDataType.Number, price.ToString))
               .Add(New SqlColumn(OET.Description, SqlDataType.String, description))
            End With

            Return columns
         End Function

      End Class


   End Class

End Namespace