Imports System.Data
Imports System.Data.OleDb
Imports Rae.Data.Sql.SqlParameterComplianceEnforcer

Namespace IntegratedSecurity

   ''' <summary>
   ''' Identity data with the password still encrypted (direct from database).
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/07/07" hours="1">
   ''' Created
   ''' </history>
   Friend Class EncryptedIdentityData

#Region " Fields"
      Private m_Username As String
      Private m_EncryptedPassword As String
      Private m_Name As String
      Private m_UsernameExistence As ExistenceStatus
      Private m_LastWebAuthentication As Date
#End Region


#Region " Properties"

      ''' <summary>
      ''' Username to find identity data for.
      ''' </summary>
      Public ReadOnly Property Username() As String
         Get
            Return Me.m_Username
         End Get
      End Property



      Public ReadOnly Property LastWebAuthentication As Date
         Get
            Return m_LastWebAuthentication
         End Get
      End Property

      ''' <summary>
      ''' Encrypted password.
      ''' </summary>
      Public ReadOnly Property EncryptedPassword() As String
         Get
            If Me.UsernameExistence = ExistenceStatus.Nonexistent Then Me.ThrowInvalidOperation("EncryptedPassword")
            Return Me.m_EncryptedPassword
         End Get
      End Property


      ''' <summary>
      ''' Name (first and last) of user.
      ''' </summary>
      Public ReadOnly Property Name() As String
         Get
            If Me.UsernameExistence = ExistenceStatus.Nonexistent Then Me.ThrowInvalidOperation("Name")
            Return Me.m_Name
         End Get
      End Property


      ''' <summary>
      ''' Existence indicates whether username exists in authentication data source.
      ''' </summary>
      Public ReadOnly Property UsernameExistence() As ExistenceStatus
         Get
            Return Me.m_UsernameExistence
         End Get
      End Property

#End Region


#Region " Methods"

      ''' <summary>
      ''' Constructs identity data w/ the password still encrypted. Data is unmodified from the database.
      ''' </summary>
      ''' <param name="username">
      ''' Username to retrieve data for.
      ''' </param>
      Public Sub New(ByVal username As String)
         ' sets username property
         Me.m_Username = username
         ' retrieves identity data
         Me.RetrieveEncryptedIdentity()
      End Sub



      ''' <summary>
      ''' Retrieves identity data from database. Password is not decrypted.
      ''' </summary>
      Private Sub RetrieveEncryptedIdentity()
         Dim sql As String
         Dim connection As OleDbConnection
         Dim command As OleDbCommand
         Dim reader As OleDbDataReader

         sql = "SELECT User_Name, Password, Sp2, LastWebAuthentication FROM Table1 " & _
            "WHERE User_Name='" & EnforceCompliance(Me.m_Username) & "'"

         connection = New OleDbConnection(ConnectionString.Text)
         command = New OleDbCommand(sql, connection)

         Try
            connection.Open()
            reader = command.ExecuteReader

            ' username is not found
            If Not reader.HasRows Then
               Me.m_UsernameExistence = ExistenceStatus.Nonexistent
               Exit Sub
            End If

            ' reads data from database
            While reader.Read

               Me.m_Username = reader.GetString(0)
               Me.m_EncryptedPassword = reader.GetString(1)
               Me.m_Name = reader.GetString(2)
               If Not Date.TryParse(reader(3).ToString, Me.m_LastWebAuthentication) Then Me.m_LastWebAuthentication = Date.MinValue
            End While

            ' sets property; username exists
            Me.m_UsernameExistence = ExistenceStatus.Existent

         Catch ex As OleDbException
            Throw ex
         Finally
            If reader IsNot Nothing Then reader.Close()
            If connection.State <> ConnectionState.Closed Then connection.Close()
         End Try
      End Sub


      ''' <summary>
      ''' Throws invalid operation exception when there is an attempt to access a property that requires an authenticated username.
      ''' </summary>
      ''' <param name="propertyName">
      ''' Name of property being accessed.
      ''' </param>
      Private Sub ThrowInvalidOperation(ByVal propertyName As String)
         Dim message As String

         message = "The property, " & propertyName & ", cannot be accessed because the username is not authenticated."
         Throw New System.InvalidOperationException(message)
      End Sub

#End Region

   End Class

End Namespace