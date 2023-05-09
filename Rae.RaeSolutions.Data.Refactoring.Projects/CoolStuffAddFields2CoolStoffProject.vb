Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess
Public Class CoolStuffAddFields2CoolStoffProject
   Inherits RefactoringBase

   Public Sub New(ByVal connectionString As String)
      connectionString_ = connectionString


   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds 2 fields to COOL STUFF Projects database."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      Dim commands As New Commands(Me.ConnectionString)

      commands.AddColumn("CoolStuffProjects", New Column("BLName", New DataTypes.Text))
      commands.AddColumn("CoolStuffProjects", New Column("ProcessID", New DataTypes.Text))



   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #10/2/2007#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 7, 0, 0)

      End Get
   End Property
End Class
