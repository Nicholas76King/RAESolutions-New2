''' <summary>
''' Identity signature
''' </summary>
''' <remarks>
''' Example
''' <code>
''' Dim identity As IIdentity
''' Dim result As AuthenticationResult
''' 
''' identity = New Identity(name, password)
''' 
''' result = identity.Authenticate()
''' 
''' Select Case result
'''    Case AuthenticationResult.Authenticated
'''       StartApplication()
'''    Case AuthenticationResult.InvalidUsername, InvalidPassword
'''       Message("Invalid credentials.")
''' End Select
''' </code>
''' </remarks>
''' <history by="Casey Joyce" finish="2006/07/07">
''' Created
''' </history>
Public Interface IIdentity

   ''' <summary>
   ''' Username
   ''' </summary>
   ReadOnly Property Username() As String

   ''' <summary>
   ''' Password
   ''' </summary>
   ReadOnly Property Password() As String

   ''' <summary>
   ''' True if identity is authenticated; false if identity is not authenticated.
   ''' </summary>
   ReadOnly Property IsAuthenticated() As Boolean

   ''' <summary>
   ''' Result of the authentication attempt.
   ''' </summary>
   ReadOnly Property Result() As AuthenticationResult


   ReadOnly Property ExpirationWarningFlag As WebAuthenticationExpirationStatus
   
   ''' <summary>
   ''' Authenticates identity based on username and password.
   ''' </summary>
   ''' <returns>
   ''' Result of authentication (Authenticated, NotAuthenticated, etc).
   ''' </returns>
   Function Authenticate() As AuthenticationResult

End Interface
