Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddFanWattsToChillerProcess
   Inherits RefactoringBase

   Sub New(connectionString As String)
      connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Adds fan watts column to chiller process table"
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return #6/25/2008#
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Rae.Deployment.Version(1, 16, 0, 0)
      End Get
   End Property


   Protected Overrides Sub Refactor()
      Dim commands = New Commands(ConnectionString)
      commands.AddColumn("ACChillerProcesses", New Column("FanWatts", New DataTypes.Double))
   End Sub

End Class
