Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddCondenserCoilToCondUnitProject : Inherits RefactoringBase
    Sub New(ByVal connectionString As String)
        Me.connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Adds condenser coil fields to CondensingUnitProcesses database."
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return New Date(2015, 9, 10)
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Deployment.Version(1, 33, 0, 0)
        End Get
    End Property

    Protected Overrides Sub Refactor()
        Dim commands = New Commands(connectionString_)
        Dim table_name = "CondensingUnitProcesses"
        commands.AddColumn(table_name, New Column("TubeDiameter1", New DataTypes.Double()))
        commands.AddColumn(table_name, New Column("TubeDiameter2", New DataTypes.Double()))
        commands.AddColumn(table_name, New Column("TubeDiameter3", New DataTypes.Double()))
        commands.AddColumn(table_name, New Column("TubeDiameter4", New DataTypes.Double()))
        commands.AddColumn(table_name, New Column("TubeSurface1", New DataTypes.Text(25)))
        commands.AddColumn(table_name, New Column("TubeSurface2", New DataTypes.Text(25)))
        commands.AddColumn(table_name, New Column("TubeSurface3", New DataTypes.Text(25)))
        commands.AddColumn(table_name, New Column("TubeSurface4", New DataTypes.Text(25)))
        commands.AddColumn(table_name, New Column("FinType1", New DataTypes.Text(10)))
        commands.AddColumn(table_name, New Column("FinType2", New DataTypes.Text(10)))
        commands.AddColumn(table_name, New Column("FinType3", New DataTypes.Text(10)))
        commands.AddColumn(table_name, New Column("FinType4", New DataTypes.Text(10)))




    End Sub
End Class