Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddTypeColumnToUnitCoolerRefactoring : Inherits RefactoringBase

   Sub New(connectionString As String)
      connectionString_ = connectionString
   End Sub
   
   Overrides ReadOnly Property Description As String
      Get
         Return "Add UnitCoolerType column to UnitCooler table"
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 1, 18)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 21, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands = New Commands(connectionString_)
      commands.AddColumn("UnitCooler", New Column("UnitCoolerType", New DataTypes.Text()))
   End Sub
End Class
