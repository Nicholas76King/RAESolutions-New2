Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess
Imports Rae.Data.MicrosoftAccess.DataTypes
Imports DataTypes = Rae.Data.MicrosoftAccess.DataTypes

Public Class ConformBoxLoadRefactoring
   Inherits Rae.Data.Refactoring.RefactoringBase
   
   Sub New(connectionString As String)
      Me.connectionString_ = connectionString
   End Sub
   
   Overrides ReadOnly Property Description() As String
      Get
         Return "Conforms box load to be an item."
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #3/25/2008 5:10:00 PM#
      End Get
   End Property

   Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 14, 0, 0)
      End Get
   End Property
   
   
   Protected Overrides Sub Refactor()
      Dim commands As New Commands(ConnectionString)
      Dim tableName As String = "CoolStuffProjects"
      With commands
         '
         ' Revision: rename and change type from Single to LongInteger
         '
         Dim before As New Column("Revision", New LongInteger())
         Dim after As New Column("ItemRevision", New LongInteger(0))
         ' change Revision type from Single to LongInteger
         .EditColumn(tableName, before)
         ' change Revision name from Revision to ItemRevision
         .RenameColumn(tableName, before, after)


         '
         ' ProjectId: change ProjectId column casing
         '
         before = New Column("PROJECTID", New DataTypes.Text())
         after = New Column("ProjectId", New DataTypes.Text())
         .RenameColumn(tableName, before, after)
         
         
         '
         ' ProjectRevision: change ProjectRevision from Double to LongInteger
         '
         .EditColumn(tableName, New Column("ProjectRevision", New LongInteger(0)))
         
         '
         ' ItemId: change ProcessID name to ItemId
         '
         before = New Column("ProcessID", New DataTypes.Text())
         after = New Column("ItemId", New DataTypes.Text())
         .RenameColumn(tableName, before, after)
         
         '
         ' Add link columns
         '
         .AddColumn(tableName, New Column("LinkedItemId", New DataTypes.Text()))
         .AddColumn(tableName, New Column("LinkedItemRevision", _
            New DataTypes.Number(Of Single)(NumberType.Single)))
      End With
   End Sub
   
End Class
