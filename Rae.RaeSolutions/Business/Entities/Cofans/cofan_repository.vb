Option Strict Off

Imports System.Collections.Generic
Imports System.Data

Namespace Rae.RaeSolutions.Business.Entities.Cofans

    Class cofan_repository : Inherits repository

        ''' <summary>indices 0-4 are for cfm and indices 5-9 are for hp</summary>
        Function get_fan_curves(ByVal fan_file_name As String) As List(Of Double)
            Dim connection = get_connection()
            Dim command = connection.CreateCommand()
            Dim sql = "SELECT * FROM FanCurves WHERE FileName='" & fan_file_name & "'"
            command.CommandText = sql
            Dim reader As IDataReader
            Dim coef = New List(Of Double)
            Try
                connection.Open()
                reader = command.ExecuteReader()
                While reader.Read()
                    'cfm
                    coef.Add(reader("C0"))
                    coef.Add(reader("C1"))
                    coef.Add(reader("C2"))
                    coef.Add(reader("C3"))
                    coef.Add(reader("C4"))
                    'hp
                    coef.Add(reader("C5"))
                    coef.Add(reader("C6"))
                    coef.Add(reader("C7"))
                    coef.Add(reader("C8"))
                    coef.Add(reader("C9"))
                End While
            Finally
                If reader IsNot Nothing Then _
                    reader.Close()
                If connection.State <> ConnectionState.Closed Then _
                    connection.Close()
            End Try

            Return coef
        End Function

        Function get_coil(ByVal coil_file_name As String) As coil
            Dim connection = get_connection()
            Dim coil As coil

            Try
                connection.Open()

                coil = get_coil_data(coil_file_name, connection)
                coil = get_coil_curves(coil, connection)
            Finally
                If connection.State <> ConnectionState.Closed Then _
                    connection.Close()
            End Try

            Return coil
        End Function

        Private Function get_coil_data(ByVal coil_file_name As String, ByVal connection As IDbConnection) As coil
            Dim command = connection.CreateCommand()

            Dim sql = "SELECT * FROM Coils WHERE FileName='" & coil_file_name & "'"
            command.CommandText = sql

            Dim reader = command.ExecuteReader()
            Dim coil As coil

            While reader.Read()
                coil = New coil()
                coil.file_name = coil_file_name
                coil.coil_type = reader("CoilType")



                coil.tubeDiameter = reader("Diameter")
                coil.fin_type = reader("FinType")
                coil.id = reader("Id")
                coil.row_qty = reader("NumRows")
            End While

            Return coil
        End Function



        Public Function getCoilFilename(ByVal diameter As String, ByVal numRows As Integer, ByVal finType As String, ByVal tubeSurface As String) As String

            Dim connection = get_connection()




            Try
                connection.Open()

                Dim command = connection.CreateCommand()

                Dim sql = "select filename from coils where coiltype='Condenser' and Diameter = " & diameter & " and NumRows = " & numRows & " and FinType = '" & finType & "' and TubeSurface = '" & tubeSurface & "'"
                command.CommandText = sql

                Dim reader = command.ExecuteReader()
                Dim coil As coil

                getCoilFilename = ""

                While reader.Read()
                    getCoilFilename = reader("filename")
                End While


            Finally
                If connection.State <> ConnectionState.Closed Then _
                    connection.Close()
            End Try




    


        End Function


        Private Function get_coil_curves(ByVal coil As coil, ByVal connection As IDbConnection) As coil
            Dim command = connection.CreateCommand()
            Dim sql = "SELECT * FROM CoilCurves WHERE FileName='" & coil.file_name & "'"
            command.CommandText = sql
            Dim reader = command.ExecuteReader()

            While reader.Read()
                coil.p(0) = reader("P0")
                coil.p(1) = reader("P1")
                coil.p(2) = reader("P2")
                coil.p(3) = reader("P3")
                coil.p(4) = reader("P4")

                With coil.at_fpi(0)
                    .f(0) = reader("F0_1")
                    .f(1) = reader("F1_1")
                    .f(2) = reader("F2_1")
                    .f(3) = reader("F3_1")
                    .f(4) = reader("F4_1")
                    .fpi = reader("Fpi_1")
                    .p = reader("P_1")
                End With
                With coil.at_fpi(1)
                    .f(0) = reader("F0_2")
                    .f(1) = reader("F1_2")
                    .f(2) = reader("F2_2")
                    .f(3) = reader("F3_2")
                    .f(4) = reader("F4_2")
                    .fpi = reader("Fpi_2")
                    .p = reader("P_2")
                End With
                With coil.at_fpi(2)
                    .f(0) = reader("F0_3")
                    .f(1) = reader("F1_3")
                    .f(2) = reader("F2_3")
                    .f(3) = reader("F3_3")
                    .f(4) = reader("F4_3")
                    .fpi = reader("Fpi_3")
                    .p = reader("P_3")
                End With
                With coil.at_fpi(3)
                    .f(0) = reader("F0_4")
                    .f(1) = reader("F1_4")
                    .f(2) = reader("F2_4")
                    .f(3) = reader("F3_4")
                    .f(4) = reader("F4_4")
                    .fpi = reader("Fpi_4")
                    .p = reader("P_4")
                End With
            End While

            Return coil
        End Function

    End Class

End Namespace