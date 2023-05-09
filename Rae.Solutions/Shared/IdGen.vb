Imports Rae.RaeSolutions.Business.Entities

Public Class IdGen
   
   Shared Function Gen() As item_id
      Dim id As New item_id(AppInfo.User.username, AppInfo.User.password)
      Return id
   End Function

End Class
