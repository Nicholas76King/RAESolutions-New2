Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddMultiplierCodeRefactoring
   Inherits RefactoringBase
   
   Sub New(connectionString As String)
      connectionString_ = connectionString
   End Sub
   
   Overrides ReadOnly Property Description As String
      Get
         Return "Adds multiplier code column."
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return #5/19/2008#
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 15, 0, 0)
      End Get
   End Property
   
   
   Protected Overrides Sub Refactor()
      Dim commands As New Commands(connectionString_)
      commands.AddColumn("Equipment", New Column("MultiplierCode", New DataTypes.Text()))
   End Sub
   
End Class
