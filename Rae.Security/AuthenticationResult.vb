''' <summary>
''' The result of an attempt to authenticate an identity.
''' </summary>
''' <history by="Casey Joyce" finish="2006/07/07">
''' Created
''' </history>
Public Enum AuthenticationResult As Integer

   ''' <summary>
   ''' No result is indicated.
   ''' </summary>
   NoResult = 0

   ''' <summary>
   ''' Authentication succeeded.
   ''' </summary>
   Authenticated = 1

   ''' <summary>
   ''' Username is invalid.
   ''' </summary>
   UsernameInvalid = 2

   ''' <summary>
   ''' Password is invalid.
   ''' </summary>
   PasswordInvalid = 4

   ''' <summary>
   ''' Authentication failed for a reason other than an invalid username or password.
   ''' </summary>
   NotAuthenticated = 8


End Enum


Public Enum WebAuthenticationExpirationStatus
   NOT_SET = 1
   UP_TO_DATE = 2
   SOON_TO_EXPIRE = 3
   EXPIRED = 4
End Enum