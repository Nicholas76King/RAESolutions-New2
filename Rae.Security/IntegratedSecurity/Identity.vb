Imports Microsoft.VisualBasic

Namespace IntegratedSecurity

   ''' <summary>
   ''' Identity for authentication. Authenticates based on username and password.
   ''' </summary>
   ''' <remarks></remarks>
   ''' <history by="Casey Joyce" finish="2006/07/07" hours="1">
   ''' Created
   ''' </history>
   Public Class Identity
      Inherits BaseIdentity



      ''' <summary>
      ''' Constructs identity w/ username and password.
      ''' </summary>
      ''' <param name="username">Username to authenticate.</param>
      ''' <param name="password">Password to authenticate.</param>
      Public Sub New(ByVal username As String, ByVal password As String)
         MyBase.New(username, password)
      End Sub


      ''' <summary>
      ''' Authenticates identity based on username and password.
      ''' </summary>
      ''' <returns>
      ''' Result of attempt to authenticate identity.
      ''' </returns>
      Public Overrides Function Authenticate() As AuthenticationResult
         Dim result As AuthenticationResult
         Dim data As IdentityData

         ' gets identity's data
         data = New IdentityData(Me.m_username)

         ' checks if username was found
         If data.UsernameExistence = ExistenceStatus.Nonexistent Then
            result = AuthenticationResult.UsernameInvalid
         Else
            ' checks password is valid
            If Me.m_password = data.Password Then

                    Select Case DateDiff(Microsoft.VisualBasic.DateInterval.Day, data.LastWebAuthentication, Now)
                        Case Is < 45
                            result = AuthenticationResult.Authenticated
                            Me.m_expirationWarningFlag = WebAuthenticationExpirationStatus.UP_TO_DATE
                        Case Is > 60
                            result = AuthenticationResult.NotAuthenticated
                            Me.m_expirationWarningFlag = WebAuthenticationExpirationStatus.EXPIRED
                        Case Else
                            result = AuthenticationResult.Authenticated
                            Me.m_expirationWarningFlag = WebAuthenticationExpirationStatus.SOON_TO_EXPIRE
                    End Select

                Else
                    result = AuthenticationResult.PasswordInvalid
                End If
         End If

            ' sets property
            Me.m_result = result

            Return result
      End Function

   End Class

End Namespace