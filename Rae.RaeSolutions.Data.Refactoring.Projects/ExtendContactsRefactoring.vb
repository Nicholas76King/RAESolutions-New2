Imports Rae.Data.MicrosoftAccess
Imports Rae.Data.MicrosoftAccess.DataTypes


Public Class ExtendContactsRefactoring
   Inherits Rae.Data.Refactoring.RefactoringBase

   Public Sub New(ByVal connectionString As String)
      Me.connectionString_ = connectionString
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Version: " & Version.ToString() & _
            " - Extends contact roles data"
      End Get
   End Property

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #7/15/2007 8:16:00 AM#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 1, 0, 0)
      End Get
   End Property

   Protected Overrides Sub Refactor()
      addProjectContactsTable()
   End Sub


   Private Sub addProjectContactsTable()
      Dim commands As New Commands(ConnectionString)
      Dim tableName As String = "ProjectContacts"
      With commands
         .AddTable(tableName)
         .AddColumn(tableName, New Column("ProjectId", New DataTypes.Text()))
         .AddColumn(tableName, New Column("ContactId", New LongInteger()))
      End With
   End Sub

End Class


Public Class ExtendContactsCsv
    Inherits Rae.Data.Refactoring.RefactoringBase

    Public Sub New(ByVal connectionString As String)
        Me.connectionString_ = connectionString
    End Sub


    Public Overrides ReadOnly Property Description() As String
        Get
            Return "Version: " & Version.ToString() & _
               " - Adds table for the Order Entry CSV Contacts"
        End Get
    End Property

    Public Overrides ReadOnly Property ReleaseDate() As Date
        Get
            Return #10/15/2018 8:16:00 AM#
        End Get
    End Property

    Public Overrides ReadOnly Property Version() As Deployment.Version
        Get
            Return New Deployment.Version(1, 38, 0, 0)
        End Get
    End Property

    Protected Overrides Sub Refactor()
        addOrderEntryContactsTable()
    End Sub

    Private Sub addOrderEntryContactsTable()
        Dim commands As New Commands(ConnectionString)
        Dim tableName As String = "OrderEntryContacts"
        With commands
            .AddTable(tableName)
            .AddColumn(tableName, New Column("ProjectId", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("Name", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("Address1", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("Address2", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("Phone", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("State", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("Zip", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("ContactType", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("ImportedFromCloud", New DataTypes.Text(250)))
            .AddColumn(tableName, New Column("UniqueID", New DataTypes.AutoNumber()))
        End With
    End Sub

End Class

Public Class ExtendContactsCsv1
    Inherits Rae.Data.Refactoring.RefactoringBase

    Public Sub New(ByVal connectionString As String)
        Me.connectionString_ = connectionString
    End Sub


    Public Overrides ReadOnly Property Description() As String
        Get
            Return "Version: " & Version.ToString() & _
               " - Adds table for the Order Entry CSV Contacts (forgot a column)"
        End Get
    End Property

    Public Overrides ReadOnly Property ReleaseDate() As Date
        Get
            Return #10/15/2018 8:16:00 AM#
        End Get
    End Property

    Public Overrides ReadOnly Property Version() As Deployment.Version
        Get
            Return New Deployment.Version(1, 39, 0, 0)
        End Get
    End Property

    Protected Overrides Sub Refactor()
        addOrderEntryContactsTable()
    End Sub

    Private Sub addOrderEntryContactsTable()
        Dim commands As New Commands(ConnectionString)
        Dim tableName As String = "OrderEntryContacts"
        With commands
            .AddColumn(tableName, New Column("City", New DataTypes.Text(250)))
        End With
    End Sub

End Class
