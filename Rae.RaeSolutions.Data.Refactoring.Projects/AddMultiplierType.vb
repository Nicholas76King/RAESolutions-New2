Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddMultiplierType : Inherits RefactoringBase
    Sub New(ByVal connectionString As String)
        Me.connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Add MultiplierType to Equipment Table."
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return New Date(2018, 7, 31)
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Deployment.Version(1, 35, 0, 0)
        End Get
    End Property

    Protected Overrides Sub Refactor()
        Dim commands = New Commands(connectionString_)
        Dim table_name = "Equipment"
        commands.AddColumn(table_name, New Column("MultiplierType", New DataTypes.Text(50)))
    End Sub
End Class

Public Class AddProjectID : Inherits RefactoringBase
    Sub New(ByVal connectionString As String)
        Me.connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Add ProjectID to Contacts Table."
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return New Date(2018, 9, 11)
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Deployment.Version(1, 37, 0, 0)
        End Get
    End Property

    Protected Overrides Sub Refactor()
        Dim commands = New Commands(connectionString_)
        Dim table_name = "Contacts"
        commands.AddColumn(table_name, New Column("ProjectID", New DataTypes.Text(250)))
    End Sub
End Class