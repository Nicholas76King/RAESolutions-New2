Imports Rae.Security

''' <summary>
''' Factory that creates identities based on username and password.
''' </summary>
''' <history by="Casey Joyce" finish="2006/07/11">
''' Created
''' </history>
Public Class IdentityFactory

   ''' <summary>
   ''' Constructor is private to prevent its use.
   ''' </summary>
   Private Sub New()
   End Sub


   ''' <summary>
   ''' Creates identities based on username and password.
   ''' </summary>
   ''' <param name="username">
   ''' Username
   ''' </param>
   ''' <param name="password">
   ''' Password
   ''' </param>
   ''' <returns>
   ''' Created identity.
   ''' </returns>
   Public Shared Function CreateIdentity(ByVal username As String, ByVal password As String) As IIdentity
      Dim user As New IntegratedSecurity.Identity(username, password)
      Return user
   End Function

End Class
