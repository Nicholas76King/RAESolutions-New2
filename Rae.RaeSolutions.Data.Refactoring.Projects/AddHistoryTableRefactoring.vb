Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddHistoryTableRefactoring
   Inherits Rae.Data.Refactoring.RefactoringBase

   Public Sub New(ByVal connectionString As String)
      Me.connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Version: " & Version.ToString() & _
            " - Creates version history table and columns"
      End Get
   End Property

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #6/5/2007 10:09:00 AM#
      End Get
   End Property

  Public Overrides ReadOnly Property Version() As Deployment.Version
    Get
      Return New Deployment.Version(1, 0, 0, 0)
    End Get
  End Property

   Protected Overrides Sub Refactor()
      addVersionHistoryTable()
   End Sub

   

   Private Sub addVersionHistoryTable()
      Dim refactoring As New Commands(ConnectionString)
      Const tableName As String = "VersionHistory"

      refactoring.AddTable(tableName)
      refactoring.AddColumn(tableName, New Column("Id", New DataTypes.AutoNumber()))
      refactoring.AddColumn(tableName, New Column("Description", New DataTypes.Text()))
      refactoring.AddColumn(tableName, New Column("ExecutionDate", New DataTypes.DateTime()))
      refactoring.AddColumn(tableName, New Column("Version", New DataTypes.Text(50)))
   End Sub

End Class
