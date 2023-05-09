Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddBaseListPriceRefactoring
   Inherits RefactoringBase

   Sub New(ByVal connectionString As String)
      connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description() As String
      Get
         Return "Adds columns for base list price override."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      addColumns()
   End Sub

   Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return New Date(2007, 7, 25)
      End Get
   End Property

   Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 3, 0, 0)
      End Get
   End Property

   Private Sub addColumns()
      Dim commands As New Commands(connectionString_)
      commands.AddColumn("Equipment", New Column("OverriddenBaseListPrice", New DataTypes.Double()))
      commands.AddColumn("Equipment", New Column("ShouldOverrideBaseListPrice", New DataTypes.YesNo(False)))
   End Sub

End Class
