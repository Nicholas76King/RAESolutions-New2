Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class Add35E2BalanceOptionsRefactoring : Inherits RefactoringBase

   Sub New(connectionString As String)
      me.connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Adds columns for 35E2 balance options: sound attenuation and subcooling coil."
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 03, 01)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 23, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands = New Commands(connectionString_)
      commands.AddColumn("EvapChillerProcesses", New Column("SubcoolingCoilOption", New DataTypes.YesNo()))
      commands.AddColumn("EvapChillerProcesses", New Column("SoundAttenuationOption", New DataTypes.YesNo()))
   End Sub

End Class
