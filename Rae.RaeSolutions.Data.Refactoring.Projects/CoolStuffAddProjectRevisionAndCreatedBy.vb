Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class CoolStuffAddProjectRevisionAndCreatedBy
   Inherits RefactoringBase

   Public Sub New(ByVal connectionString As String)
      connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds project revision & created by columns to CoolStuffProjects table in Projects database."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      addColumns()
   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #10/25/2007#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 8, 0, 0)
      End Get
   End Property

   Private Sub addColumns()
      Dim commands As New Commands(connectionString_)
      commands.AddColumn("CoolStuffProjects", New Column("ProjectRevision", New DataTypes.LongInteger(0)))
      commands.AddColumn("CoolStuffProjects", New Column("CreatedBy", New DataTypes.Text()))
   End Sub

End Class