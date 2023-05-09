Imports System.Text
Imports System.Data
Imports CT = Rae.DataAccess.EquipmentOptions.Tables.SuggestedModelsTable


Namespace Rae.DataAccess.EquipmentOptions

   ''' <summary>
   ''' Contains data access for DependentEquipment table.
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/05/26">
   ''' Created
   ''' </history>
   Public Class SuggestedModelsDataAccess

      ''' <summary>
      ''' Retrieves dependent model and price for the specified parent model.
      ''' </summary>
      ''' <param name="model">
      ''' Model to get suggested models for
      ''' </param>
      Public Shared Function Retrieve(ByVal model As String) As String
         Dim connection As iDbConnection
         Dim command As iDbCommand
         Dim reader As iDataReader
         Dim sql As New StringBuilder
         Dim suggestedModel As String

         connection = Rae.Data.DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text) '

         sql.AppendFormat("SELECT [{3}] FROM [{0}] WHERE [{1}] = '{2}'", _
            CT.TableName, CT.Model, model, CT.SuggestedModel)
         command = connection.CreateCommand 'New OleDbCommand(sql.ToString, connection)
         command.CommandText = sql.ToString
         Try
            connection.Open()
            reader = command.ExecuteReader()
            'If Not reader.HasRows Then
            '   Throw New DataException("There is no dependent equipment for the parent equipment, '" & model & "'.")
            'End If
            Dim rows As Integer = 0
            While reader.Read
               suggestedModel = reader(CT.SuggestedModel).ToString
               rows += 1
            End While

            If Not rows > 0 Then
               Throw New DataException("There is no dependent equipment for the parent equipment, '" & model & "'.")
            End If
         Catch ex As DataException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return suggestedModel
      End Function

   End Class

End Namespace