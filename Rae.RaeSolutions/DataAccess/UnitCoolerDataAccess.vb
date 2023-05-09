Imports System.Data
Imports Common = rae.RaeSolutions.DataAccess.Common

Namespace Rae.RaeSolutions.DataAccess

    ''' <summary>Provides data access for the unit cooler database.</summary>
    Public Class UnitCoolerDataAccess

        ''' <summary>Retrieves all unit cooler data for model parameter</summary>
        ''' <param name="model">Unit cooler model to get info for</param>
        ''' <returns>Table with unit cooler data</returns>
        Shared Function RetrieveUnitCooler(ByVal model As String) As DataTable
            Dim connection = Common.CreateConnection(Common.UnitCoolerDbPath)
            Dim command = connection.CreateCommand()
            Dim sql = "SELECT * " & _
                             "FROM [" & Common.CommonTableName(Common.UnitCoolerDbPath, "unit_coolers") & "]  " & _
                             "WHERE Model = '" & model & "'"
            command.CommandText = sql

            Dim reader As IDataReader
            Dim table = New DataTable()

            Try
                connection.Open()
                reader = command.ExecuteReader()
                table.Load(reader)



            Finally
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Return table
        End Function

    End Class

End Namespace
