Namespace IntegratedSecurity

   ''' <summary>
   ''' Group that user is in.
   ''' </summary>
   ''' <remarks>
   ''' Allows application to make decisions based on what group a user is in.
   ''' Group is retrieved from password database. It's called RevLevel in web application.
   ''' </remarks>
   ''' <history by="Casey Joyce" finish="2006/07/07">
   ''' Copied
   ''' </history>
   Public Enum UserGroup As Integer
      Employee = 1
      Rep = 3
   End Enum

End Namespace