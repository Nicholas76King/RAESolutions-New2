Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddOwnerOpenedByAndCheckedOutByToProjects
   Inherits RefactoringBase

   Public Sub New(ByVal connectionString As String)
      connectionString_ = connectionString
   End Sub

   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds project owner, opened by, checked out by & revision date columns to Projects table in Projects database."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      addColumns()
   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #11/7/2007#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 9, 0, 0)
      End Get
   End Property

   Private Sub addColumns()
      Dim commands As New Commands(connectionString_)
      commands.AddColumn("Projects", New Column("ProjectOwner", New DataTypes.Text()))
      commands.AddColumn("Projects", New Column("OpenedBy", New DataTypes.Text()))
      commands.AddColumn("Projects", New Column("CheckedOutBy", New DataTypes.Text()))
      commands.AddColumn("Projects", New Column("RevisionDate", New DataTypes.DateTime))
   End Sub

End Class
