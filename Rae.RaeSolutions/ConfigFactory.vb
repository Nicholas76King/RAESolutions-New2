Namespace Rae.Configuration

Public Class ConfigFactory
   
   Shared Sub Initialize(path As String, appNamespace As String)
      ConfigFactory.path = path
      ConfigFactory.appNamespace = appNamespace
      
      ' sets config to nothing so it'll construct with new variables in Create method
      config = Nothing
   End Sub

   Shared Function Create() As IConfiguration
      If config Is Nothing Then _
         config = New AppSettings(path, appNamespace)

      Return config
   End Function
   
   Private Shared config As IConfiguration
   Private Shared path As String
   Private Shared appNamespace As String

End Class

End Namespace