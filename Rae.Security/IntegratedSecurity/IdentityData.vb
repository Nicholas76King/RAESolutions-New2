Imports Rae.Security.Cryptography

Namespace IntegratedSecurity

   ''' <summary>
   ''' Identity data (i.e. username, password, name, authority group and access level) that has been decrypted and parsed.
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/07/07" hours="1">
   ''' Created
   ''' </history>
   Public Class IdentityData

#Region " Fields"
      Private m_Username As String
      Private m_Password As String
      Private m_Name As String
      Private m_AuthorityGroup As UserGroup
      Private m_Access As AccessLevel
      Private m_UsernameExistence As ExistenceStatus
      Private m_LastWebAuthentication As Date
#End Region


#Region " Properties"

      ''' <summary>
      ''' Username
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
      ''' Password
      ''' </summary>
      Public ReadOnly Property Password() As String
         Get
            Return Me.m_Password
         End Get
      End Property


      ''' <summary>
      ''' Name
      ''' </summary>
      Public Property Name() As String
         Get
            Return Me.m_Name
         End Get
         Set(ByVal value As String)
            Me.m_Name = value
         End Set
      End Property


      ''' <summary>
      ''' AuthorityGroup
      ''' </summary>
      Public ReadOnly Property AuthorityGroup() As UserGroup
         Get
            Return Me.m_AuthorityGroup
         End Get
      End Property


      ''' <summary>
      ''' Access
      ''' </summary>
      Public ReadOnly Property Access() As AccessLevel
         Get
            Return Me.m_Access
         End Get
      End Property


      ''' <summary>
      ''' UsernameExistence
      ''' </summary>
      Public ReadOnly Property UsernameExistence() As ExistenceStatus
         Get
            Return Me.m_UsernameExistence
         End Get
      End Property

#End Region


#Region " Methods"

      ''' <summary>
      ''' Construct identity data (i.e. username, password, name, user group, and access level)
      ''' </summary>
      ''' <param name="username">
      ''' Username to get data for.
      ''' </param>
      Public Sub New(ByVal username As String)
         Dim encryptedData As EncryptedIdentityData
         Dim decryptedUnparsedPassword As String
         Dim parsedPassword1 As ParsedPassword

         ' sets username
         Me.m_Username = username

         ' IDEA: validate username (check for ' and @ symbols, proper length, require letters and numbers, etc.)

         ' gets encrypted data for username
         encryptedData = New EncryptedIdentityData(username)

         ' sets whether username exists
         Me.m_UsernameExistence = encryptedData.UsernameExistence

         ' checks if username was found
         If Me.m_UsernameExistence = ExistenceStatus.Nonexistent Then
            Exit Sub
         End If

         ' sets first, last name
         Me.m_Name = encryptedData.Name

         'Set Last Web Authentication Date
         Me.m_LastWebAuthentication = encryptedData.LastWebAuthentication


         ' decrypts password
         decryptedUnparsedPassword = Cryptographer.Decrypt(encryptedData.EncryptedPassword)

         ' parses password
         parsedPassword1 = New ParsedPassword(decryptedUnparsedPassword)

         ' sets properties
         Me.m_Password = parsedPassword1.Password
         Me.m_AuthorityGroup = parsedPassword1.AuthorityGroup
         Me.m_Access = parsedPassword1.Access
      End Sub

#End Region

   End Class

End Namespace