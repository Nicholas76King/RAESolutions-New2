Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class Refactoring : Inherits RefactoringBase
   Sub New(connectionString As String)
      me.connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Add UnitKwPerTon column to chiller table"
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 04, 01)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 25, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands = New Commands(connectionString_)
      commands.AddColumn("Chiller", New Column("UnitKwPerTon", New DataTypes.Text()))
   End Sub
End Class