''' <summary>
''' Base implementation that can be used to speed up implemenation of IIdentity.
''' Does not implement Authenticate().
''' </summary>
''' <remarks>
''' Inheritors should set Result and IsAuthenticated based on result of Authenticate().
''' </remarks>
''' <history by="Casey Joyce" finish="2006/07/07">
''' Created
''' </history>
Public MustInherit Class BaseIdentity
   Implements IIdentity

#Region " Fields"
   Protected m_password As String
   Protected m_username As String
   Protected m_result As AuthenticationResult


   Protected m_expirationWarningFlag As WebAuthenticationExpirationStatus

#End Region


#Region " Properties"

   ''' <summary>
   ''' Password of identity.
   ''' </summary>
   Public ReadOnly Property Password() As String _
   Implements IIdentity.Password
      Get
         Return Me.m_password
      End Get
   End Property


   Public ReadOnly Property ExpirationWarningFlag As WebAuthenticationExpirationStatus Implements IIdentity.ExpirationWarningFlag
      Get
         Return m_expirationWarningFlag
      End Get
   End Property


   ''' <summary>
   ''' Username of identity.
   ''' </summary>
   Public ReadOnly Property Username() As String _
   Implements IIdentity.Username
      Get
         Return Me.m_username
      End Get
   End Property


   ''' <summary>
   ''' Result of attempt to authenticate the identity.
   ''' </summary>
   Public ReadOnly Property Result() As AuthenticationResult _
   Implements IIdentity.Result
      Get
         Return Me.m_result
      End Get
   End Property


   ''' <summary>
   ''' True if identity is authenticated; false if identity is not authenticated.
   ''' </summary>
   ''' <remarks>
   ''' Property does not invoke authentication; it only indicates the result of previous authentication attempts.
   ''' If IsAuthenticated is false, either the identity may not be valid (authentication failed) 
   ''' or an authentication attempt may not have been made (Authenticate() method not called yet).
   ''' </remarks>
   Public ReadOnly Property IsAuthenticated() As Boolean _
   Implements IIdentity.IsAuthenticated
      Get
         If Me.m_result = AuthenticationResult.Authenticated Then
            Return True
         Else
            Return False
         End If
      End Get
   End Property

#End Region




#Region " Methods"

   ''' <summary>
   ''' Constructs an identity w/ a username and password. Does not call Authenticate().
   ''' </summary>
   ''' <param name="username">
   ''' Username to authenticate.
   ''' </param>
   ''' <param name="password">
   ''' Password to authenticate.
    ''' </param>
    ''' 
   Public Sub New(ByVal username As String, ByVal password As String)
      Me.m_username = username
      Me.m_password = password
      Me.m_expirationWarningFlag = WebAuthenticationExpirationStatus.NOT_SET

   End Sub


   ''' <summary>
   ''' Authenticates identity based on username and password. Not implemented.
   ''' </summary>
   ''' <returns>
   ''' Enumerated result of authentication attempt.
   ''' </returns>
   ''' <remarks>
   ''' Must override this method.
   ''' </remarks>
   Public MustOverride Function Authenticate() As AuthenticationResult _
   Implements IIdentity.Authenticate

#End Region

End Class
