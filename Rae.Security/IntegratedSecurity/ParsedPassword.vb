Imports System
Imports Rae.Io.Text

Namespace IntegratedSecurity

   ''' <summary>
   ''' Data parsed from password (i.e. username, password, authority group, and access level).
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/07/07" hours="1">
   ''' Created
   ''' </history>
   Friend Class ParsedPassword

#Region " Fields"
      Private m_UnparsedPassword As String
      Private m_Username As String
      Private m_Password As String
      Private m_AuthorityGroup As UserGroup
      Private m_Access As AccessLevel
#End Region


#Region " Properties"

      ''' <summary>
      ''' Unparsed password.
      ''' </summary>
      Public ReadOnly Property UnparsedPassword() As String
         Get
            Return Me.m_UnparsedPassword
         End Get
      End Property


      ''' <summary>
      ''' Username
      ''' </summary>
      Public ReadOnly Property Username() As String
         Get
            Return Me.m_Username
         End Get
      End Property


      ''' <summary>
      ''' Parsed password
      ''' </summary>
      Public ReadOnly Property Password() As String
         Get
            Return Me.m_Password
         End Get
      End Property


      ''' <summary>
      ''' Authority group.
      ''' </summary>
      Public ReadOnly Property AuthorityGroup() As UserGroup
         Get
            Return Me.m_AuthorityGroup
         End Get
      End Property


      ''' <summary>
      ''' Access level
      ''' </summary>
      Public ReadOnly Property Access() As AccessLevel
         Get
            Return Me.m_Access
         End Get
      End Property

#End Region


#Region " Methods"

      ''' <summary>
      ''' Constructs object w/ data parsed from the password. 
      ''' The unparsed password contains username, password, user group and access level.
      ''' </summary>
      ''' <param name="unparsedPassword">
      ''' Password that is unparsed (still contains data delimited by dash).
      ''' </param>
      Public Sub New(ByVal unparsedPassword As String)
         Me.m_UnparsedPassword = unparsedPassword
         Me.Parse()
      End Sub



      ''' <summary>
      ''' Parses password for username, password, authority group and access level, and sets properties.
      ''' </summary>
      ''' <exception cref="FormatException">
      ''' Thrown when password format is invalid.
      ''' </exception>
      Private Sub Parse()
         Dim parsedInfo As String()
         Dim isUserGroupParsed, isAccessParsed As Boolean

         ' parse exception "Password in database cannot be parsed because it has an invalid format."
         ' seperates individual data from login info string
         parsedInfo = Me.m_UnparsedPassword.Split(New String() {"-"}, StringSplitOptions.None)

         Try
            ' seperates password from login info
            Me.m_Password = parsedInfo(0)

            ' sets username
            Me.m_Username = parsedInfo(1)

            ' sets authorization level (employee/rep)
                isUserGroupParsed = GetEnumValue(Of UserGroup)(CInt(parsedInfo(2)), Me.m_AuthorityGroup)

            If Not isUserGroupParsed Then
               Throw New FormatException("User group cannot be parsed from password in database. Password has an invalid format or value.")
            End If

            ' sets pricing privilege and division access
            isAccessParsed = GetEnumValue(Of AccessLevel)(CInt(parsedInfo(3)), Me.m_Access)

            If Not isAccessParsed Then
               Throw New FormatException("Access level cannot be parsed from password in database. Password has an invalid format or value.")
            End If
         Catch ex As IndexOutOfRangeException
            ' converts out of range exception to format exception
            Throw New FormatException("Password in database cannot be parsed. Password may be missing data.", ex)
         End Try
      End Sub

#End Region

   End Class

End Namespace