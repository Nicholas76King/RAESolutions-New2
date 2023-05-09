Option Strict On
Option Explicit On

Imports System.Data

Namespace Rae.RaeSolutions.DataAccess


    ''' <summary>Provides access to data that can assist the user in creating orders.
    ''' </summary>
    ''' <remarks>This data is read-only it is not user-specific data
    ''' </remarks>
    Public Class OrderAssistanceDA

        ''' <summary>Retrieves table of multiplier and commission pairs for Technical Systems</summary>
        Shared Function RetrieveTsiMultipliersCommissions() As DataTable
            Return retrieveMultipliersCommissions("TsiMultipliersCommissions")
        End Function


        ''' <summary>Retrieves table of multiplier and commission pairs for Century Refrigeration</summary>
        Shared Function RetrieveCriMultipliersCommissions() As DataTable
            Return retrieveMultipliersCommissions("CriMultipliersCommissions")
        End Function


        ''' <summary>
        ''' Retrieves table of multiplier and commission pairs for employees at RESCO
        ''' </summary>
        Shared Function RetrieveRescoMultipliersCommissions() As DataTable
            Return retrieveMultipliersCommissions("RescoMultipliersCommissions")
        End Function


        Shared Function RetrieveContractorMultipliersCommissions() As DataTable
            Return retrieveMultipliersCommissions("Contractors")
        End Function




        ''' <summary>Retrieves table of states' full name and abbreviation</summary>
        Shared Function RetrieveUnitedStates() As DataTable
            Dim connectionString, sqlCommand As String
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim statesTable As DataTable
            Dim row As DataRow

            connectionString = Common.GetConnectionString(Common.OrderAssistanceDbPath)
            sqlCommand = "SELECT Abbreviation, FullName FROM States"

            connection = Common.CreateConnection(Common.OrderAssistanceDbPath) 'New OleDbConnection(connectionString)

            command = connection.CreateCommand 'New OleDbCommand(sql, connection)
            command.CommandText = sqlCommand
            statesTable = New DataTable("States")
            statesTable.Columns.Add("Abbreviation")
            statesTable.Columns.Add("FullName")

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    row = statesTable.NewRow
                    row("Abbreviation") = reader.GetString(0)
                    row("FullName") = reader.GetString(1)
                    statesTable.Rows.Add(row)
                End While
            Catch dbEx As DataException
                Throw
            Finally
                If Not (reader Is Nothing) Then reader.Close()
                If Not (connection.State.Equals(ConnectionState.Closed)) Then connection.Close()
            End Try

            Return statesTable
        End Function



        ''' <summary>Retrieves multipliers and commission rates</summary>
        Private Shared Function retrieveMultipliersCommissions(ByVal tableName As String) As DataTable
            Dim connectionString, sqlCommand As String
            Dim connection As IDbConnection
            Dim command As IDbCommand
            Dim reader As IDataReader
            Dim table As DataTable
            Dim row As DataRow


            table = New DataTable("MultipliersCommissions")
            table.Columns.Add("Multiplier")
            table.Columns.Add("Commission")


            If tableName.ToLower = "contractors" Then
                row = table.NewRow
                row("Multiplier") = 1
                row("Commission") = 0

                table.Rows.Add(row)

                Return table
            End If



            connectionString = Common.GetConnectionString(Common.OrderAssistanceDbPath)
            sqlCommand = "SELECT Multiplier, Commission FROM " & tableName

            connection = Common.CreateConnection(Common.OrderAssistanceDbPath)

            command = connection.CreateCommand
            command.CommandText = sqlCommand

            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    row = table.NewRow
                    row("Multiplier") = reader.GetDouble(0)
                    row("Commission") = reader.GetDouble(1)
                    table.Rows.Add(row)
                End While
            Catch ex As DataException
                Throw
            Finally
                If Not connection.State.Equals(ConnectionState.Closed) Then connection.Close()
            End Try



            Return table
        End Function

    End Class
End Namespace