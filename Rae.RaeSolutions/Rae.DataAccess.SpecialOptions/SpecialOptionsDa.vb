Imports System.Data
Imports System.Data.OleDb
Imports System.Text
Imports T1 = RAE.DataAccess.SpecialOptions.SpecialOptionsTable
Imports CNull = Rae.ConvertNull
Imports System.Environment

Namespace Rae.DataAccess.SpecialOptions

   ''' <summary>
   ''' Provides data access to SpecialOptions database.
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/05/31" hours="2">
   ''' Created
   ''' </history>
   Public Class SpecialOptionsDa


      ''' <summary>
      ''' Creates special option and retrieves its unique identifier.
      ''' </summary>
      Public Shared Function Create(ByVal description As String, ByVal price As Double, _
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date) As Integer
         Dim connection As OleDbConnection
         Dim command As OleDbCommand
         Dim transaction As OleDbTransaction
         Dim sql As String
         Dim id As Integer
         Dim numRows As Integer

         connection = New OleDbConnection(ConnectionString.Text)

         Try
            connection.Open()
            transaction = connection.BeginTransaction()

            ' creates special option
            sql = SqlFactory.GetCreateSql(description, price, assignedBy, assignedTo, expirationDate)
            command = New OleDbCommand(sql, connection, transaction)
            numRows = command.ExecuteNonQuery()

                ' retrieves assigned unique id
                sql = "SELECT MAX([" & T1.Id.ToString & "]) FROM [" & T1.TableName & "]"
                command = New OleDbCommand(sql, connection, transaction)
            id = CInt(command.ExecuteScalar())

            transaction.Commit()
         Catch ex As OleDbException
            If transaction IsNot Nothing Then transaction.Rollback()
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return id
      End Function


      ''' <summary>
      ''' Retrieves special options by ID.
      ''' </summary>
      ''' <returns>
      ''' Boolean indicating whether special exists. True if option exists; else false.
      ''' </returns>
      Public Shared Function Retrieve(ByVal id As Integer, ByRef description As String, ByRef price As Double, _
      ByRef assignedBy As String, ByRef assignedTo As String, ByRef expirationDate As Date, ByRef dateGenerated As Date) As Boolean
         Dim connection As OleDbConnection
         Dim command As OleDbCommand
         Dim reader As OleDbDataReader
         Dim sql As String
         Dim found As Boolean

         connection = New OleDbConnection(ConnectionString.Text)

         sql = SqlFactory.GetRetrieveByIdSql(id)
         command = New OleDbCommand(sql, connection)

         Dim defaultExpirationDate As Date = New Date(Date.Now.Year, 12, 31)

         Try
            connection.Open()
            reader = command.ExecuteReader()
            If Not reader.HasRows Then
               found = False
            Else
               While reader.Read
                        description = reader(T1.Description).ToString
                        price = CNull.ToDouble(reader(T1.Price))
                        assignedBy = reader(T1.AssignedBy).ToString
                        assignedTo = reader(T1.AssignedTo).ToString
                        expirationDate = CNull.ToDate(reader(T1.ExpirationDate), defaultExpirationDate)
                        dateGenerated = CNull.ToDate(reader(T1.DateGenerated))
                        found = True
                    End While
                End If
            Catch ex As OleDbException
                Throw ex
            Finally
                If reader IsNot Nothing Then reader.Close()
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try

            Return found
        End Function


        ''' <summary>
        ''' Retrieves special option by ID; returns data table.
        ''' </summary>
        ''' <param name="id">
        ''' Unique ID to retrieve special option by.</param>
        ''' <returns>
        ''' Table with special option with ID.
        ''' </returns>
        Public Shared Function RetrieveById(ByVal id As Integer) As DataTable
            Dim sql As String = SqlFactory.GetRetrieveByIdSql(id)
            Return RetrieveDataTable(sql)
        End Function


        ''' <summary>
        ''' Updates special option that has the specified ID.
        ''' </summary>
        Public Shared Sub Update(ByVal description As String, ByVal price As Double,
      ByVal assignedBy As String, ByVal assignedTo As String, ByVal expirationDate As Date, ByVal id As Integer)
            Dim connection As OleDbConnection
            Dim command As OleDbCommand
            Dim sql As String

            connection = New OleDbConnection(ConnectionString.Text)

            Try
                connection.Open()

                ' creates special option
                sql = SqlFactory.GetUpdateSql(description, price, assignedBy, assignedTo, expirationDate, id)
                command = New OleDbCommand(sql, connection)
                command.ExecuteNonQuery()
            Catch ex As OleDbException
                Throw ex
            Finally
                If connection.State <> ConnectionState.Closed Then connection.Close()
            End Try
        End Sub


        ''' <summary>
        ''' Verifies the special option ID and price combination.
        ''' </summary>
        ''' <param name="id">
        ''' Special option unique ID.</param>
        ''' <param name="price">
        ''' Special option's assigned price.</param>
        ''' <returns>
        ''' Verification message. Null if verfication succeeded.</returns>
        Public Shared Function Verify(ByVal id As Integer, ByVal price As Double) As String
            Dim connection As OleDbConnection
            Dim command As OleDbCommand
            Dim reader As OleDbDataReader
            Dim sql As New StringBuilder
            Dim message As String
            Dim dbPrice As Double

            connection = New OleDbConnection(ConnectionString.Text)

            sql.AppendFormat("SELECT [{3}] FROM [{0}] WHERE [{1}] = {2}",
            T1.TableName, T1.Id, id.ToString, T1.Price)
            command = New OleDbCommand(sql.ToString, connection)

            Try
                connection.Open()
                reader = command.ExecuteReader()
                If Not reader.HasRows Then
                    message = "The ID, " & CNull.ToString(id) & ", is not assigned."
                    Return message
                End If
                While reader.Read
                    ' checks if price is dbnull
                    If reader.IsDBNull(0) Then
                        message = "No price is assigned to the ID."
                        Return message
                    End If
                    dbPrice = CDbl(reader(T1.Price))
                End While
         Catch ex As OleDbException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         If Not dbPrice = price Then
            message = "The entered price is different than the assigned price." & NewLine & NewLine
            message &= "Entered (Incorrect) Price: " & price.ToString("c") & NewLine
            message &= "Assigned (Correct) Price: " & dbPrice.ToString("c")
         End If

         Return message
      End Function


      ''' <summary>
      ''' Retrieves special options assigned by the specified person.
      ''' </summary>
      ''' <param name="assignedBy">
      ''' Person special options are assigned by.</param>
      ''' <returns>
      ''' Table of special options assigned by specified person.</returns>
      Public Shared Function RetrieveByAssignedBy(ByVal assignedBy As String) As DataTable
         Dim sql As String = SqlFactory.GetRetrieveByAssignedBySql(assignedBy)
         Return RetrieveDataTable(sql)
      End Function


      ''' <summary>
      ''' Retrieves special options assigned to the specified person.
      ''' </summary>
      ''' <param name="assignedTo">
      ''' Person special options are assigned to.</param>
      ''' <returns>
      ''' Table of special option assignments assigned to specified person.</returns>
      Public Shared Function RetrieveByAssignedTo(ByVal assignedTo As String) As DataTable
         Dim sql As String = SqlFactory.GetRetrieveByAssignedToSql(assignedTo)
         Return RetrieveDataTable(sql)
      End Function


      ''' <summary>
      ''' Retrieves all special options in table.
      ''' </summary>
      Public Shared Function RetrieveAll() As DataTable
         Dim sql As String = SqlFactory.GetRetrieveAllSql()
         Return RetrieveDataTable(sql)
      End Function


      ''' <summary>
      ''' Retrieves data table depending on SQL parameter.
      ''' </summary>
      ''' <param name="sql">
      ''' SQL command to execute that selects a table of special option info.</param>
      Private Shared Function RetrieveDataTable(ByVal sql As String) As DataTable
         Dim connection As OleDbConnection
         Dim adapter As OleDbDataAdapter
         Dim table As New DataTable("SpecialOptions")

         connection = New OleDbConnection(ConnectionString.Text)
         adapter = New OleDbDataAdapter(sql, connection)

         Try
            connection.Open()
            adapter.Fill(table)
         Catch ex As OleDbException
            Throw ex
         Finally
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try

         Return table
      End Function

   End Class

End Namespace