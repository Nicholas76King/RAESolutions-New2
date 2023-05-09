Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddContactDataStructureColumnToProject
   Inherits RefactoringBase

   Public Sub New(ByVal connectionString As String)
      Me.connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds a column named ContactDataStructure to the Project table. The stored value will indicate whether the contact data structure needs to be updated."
      End Get
   End Property

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return New Date(2007, 7, 15)
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 1, 0, 0)
      End Get
   End Property

   Protected Overrides Sub Refactor()
      addColumn()
   End Sub


   Private Sub addColumn()
      Dim commands As New Commands(connectionString_)
      commands.AddColumn("Projects", New Column("ContactDataStructure", New DataTypes.Text()))
   End Sub

End Class
