Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddEfficiencyToCondUnitRefactoring : Inherits RefactoringBase
    Sub New(ByVal connectionString As String)
        Me.connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Adds Efficiency column to CondensingUnit table in Projects database table."
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return New Date(2013, 4, 1)
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Deployment.Version(1, 32, 0, 0)
        End Get
    End Property

    Protected Overrides Sub Refactor()
        Dim commands = New Commands(connectionString_)
        Dim table_name = "CondensingUnit"
        commands.AddColumn(table_name, New Column("Efficiency", New DataTypes.Double()))
    End Sub
End Class