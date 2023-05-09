Option Strict Off

Imports rae.Io.Text
Imports System.Data
Imports t1 = RAE.Solutions.motors.nec_table

Namespace rae.solutions.motors

    Class nec_table
        Public Const table_name As String = "NEC430250"
        Public Const hp As String = "Motor_Horsepower"
        Shared Function amps(ByVal voltage As Integer) As String
            Return voltage & "v_Amps"
        End Function
    End Class

    Class motor_data_table
        Public Const table_name As String = "MotorData"
        Public Const part_number As String = "Motor_Part_Number"
        Shared Function amps(ByVal voltage As Integer) As String
            Return voltage & "v_Amps"
        End Function
    End Class

    Public Interface i_repository
        Function get_amps(ByVal hp As Double, ByVal voltage As Integer) As Double
        Function get_amps(ByVal part_number As String, ByVal voltage As Integer) As Double
    End Interface

    Class repository : Implements i_repository

        Function get_amps(ByVal hp As Double, ByVal voltage As Integer) As Double _
        Implements i_repository.get_amps
            Dim connection = create_connection()
            Dim command = connection.createCommand()
            command.CommandText = Str("SELECT [{0}] FROM [{1}] WHERE [{2}]={3}",
               t1.amps(voltage), t1.table_name, t1.hp, hp)
            Dim amps As Double

            Try
                connection.open()
                amps = command.executeScalar()
            Finally
                If connection.state <> connectionState.closed Then connection.close()
            End Try

            Return amps
        End Function

        Function get_amps(ByVal part_number As String, ByVal voltage As Integer) As Double Implements i_repository.get_amps
            Dim connection = create_connection()
            Dim command = connection.CreateCommand()
            Dim sql = Str("SELECT [{0}] FROM {1} WHERE {2}='{3}'",
                motor_data_table.amps(voltage), motor_data_table.table_name, motor_data_table.part_number, part_number)

            command.CommandText = sql

            Dim amps As Double
            Try
                connection.Open()
                amps = CDbl(command.ExecuteScalar())
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return amps
        End Function

        Private Function create_connection() As IDbConnection
            Return rae.raesolutions.dataaccess.common.CreateConnection(rae.raesolutions.dataaccess.common.MotorsDbPath)
        End Function
    End Class

End Namespace