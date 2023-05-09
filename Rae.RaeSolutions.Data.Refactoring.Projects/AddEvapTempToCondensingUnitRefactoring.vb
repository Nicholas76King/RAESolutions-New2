Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddEvapTempToCondensingUnitRefactoring : Inherits RefactoringBase

   Sub New(connectionString As String)
      Me.connectionString_ = connectionString
   End Sub
   
   Overrides ReadOnly Property Description As String
      Get
         Return "Add EvapTemp column to CondensingUnit table"
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 1, 18)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 20, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      addEvapTempColumn()
   End Sub
   
   Private Sub addEvapTempColumn()
      Dim commands = New Commands(connectionString_)
      commands.AddColumn("CondensingUnit", New Column("EvapTemp", New DataTypes.Double()))
   End Sub
   
End Class
