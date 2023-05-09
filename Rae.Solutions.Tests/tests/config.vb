Module config
   Sub db
      Rae.Configuration.ConfigFactory.Initialize("c:\code\rae\solutions\main\rae.solutions\bin\debug\raesolutions.exe.config", "Rae.RaeSolutions")
      Rae.RaeSolutions.Business.Entities.Cofans.settings.set_defaults()
   End Sub
End Module
