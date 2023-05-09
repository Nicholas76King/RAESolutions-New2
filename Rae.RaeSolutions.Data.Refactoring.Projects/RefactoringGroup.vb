Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess
Imports System

Public Class ModifyACChillerProcessFanToHoldDecimal
    Inherits RefactoringBase

    Sub New(ByVal connectionString As String)
        connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Makes fan quantity in ACChillerProcess table hold a decimal value"
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return #7/20/2011#
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Rae.Deployment.Version(1, 30, 0, 0)
        End Get
    End Property


    Protected Overrides Sub Refactor()
        Dim commands = New Commands(ConnectionString)
        commands.EditColumn("ACChillerProcesses", New Column("NumFans1", New DataTypes.Double))
        commands.EditColumn("ACChillerProcesses", New Column("NumFans2", New DataTypes.Double))
        ' commands.AddColumn("ACChillerProcesses", New Column("FanWatts", New DataTypes.Double))
    End Sub

End Class



Public Class CreateElectronicOrderDetailsTable
    Inherits RefactoringBase

    Sub New(ByVal connectionString As String)
        connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Created table to store electronic order details"
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return #8/4/2011#
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Rae.Deployment.Version(1, 31, 0, 0)
        End Get
    End Property


    Protected Overrides Sub Refactor()
        Dim commands = New Commands(ConnectionString)

        commands.AddTable("ElectronicOrderDetails")
        commands.AddColumn("ElectronicOrderDetails", New Column("ProjectNumber", New DataTypes.Text))
        commands.AddColumn("ElectronicOrderDetails", New Column("FieldName", New DataTypes.Text))
        commands.AddColumn("ElectronicOrderDetails", New Column("FieldValue", New DataTypes.Text))


        ' commands.AddColumn("ACChillerProcesses", New Column("FanWatts", New DataTypes.Double))
    End Sub

End Class

Public Class AddEquipmentListPosition
    Inherits RefactoringBase

    Sub New(ByVal connectionString As String)
        connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Add ListPosition to Equipment Table - Used for re-ordering equipment items on Order Entry CSV."
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return #10/25/2018#
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Rae.Deployment.Version(1, 41, 0, 0)
        End Get
    End Property


    Protected Overrides Sub Refactor()
        Dim commands = New Commands(ConnectionString)


        commands.AddColumn("Equipment", New Column("ListPosition", New DataTypes.LongInteger))



        ' commands.AddColumn("ACChillerProcesses", New Column("FanWatts", New DataTypes.Double))
    End Sub

End Class


Public Class AddFanRPMToCondensingUnitProcesses
    Inherits RefactoringBase

    Sub New(ByVal connectionString As String)
        connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Add Fan RPM (1-4) to CondensingUnitProcesses Table"
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return #3/23/2020#
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Rae.Deployment.Version(1, 42, 0, 0)
        End Get
    End Property


    Protected Overrides Sub Refactor()
        Dim commands = New Commands(ConnectionString)


        commands.AddColumn("CondensingUnitProcesses", New Column("FanRPM1", New DataTypes.Double))
        commands.AddColumn("CondensingUnitProcesses", New Column("FanRPM2", New DataTypes.Double))
        commands.AddColumn("CondensingUnitProcesses", New Column("FanRPM3", New DataTypes.Double))
        commands.AddColumn("CondensingUnitProcesses", New Column("FanRPM4", New DataTypes.Double))



        ' commands.AddColumn("ACChillerProcesses", New Column("FanWatts", New DataTypes.Double))
    End Sub

End Class


Public Class CreateProposalInfoTable
    Inherits RefactoringBase

    Sub New(ByVal connectionString As String)
        connectionString_ = connectionString
    End Sub

    Overrides ReadOnly Property Description As String
        Get
            Return "Created table to store electronic order details"
        End Get
    End Property

    Overrides ReadOnly Property ReleaseDate As Date
        Get
            Return #7/14/2020#
        End Get
    End Property

    Overrides ReadOnly Property Version As Deployment.Version
        Get
            Return New Rae.Deployment.Version(1, 34, 0, 0)
        End Get
    End Property


    Protected Overrides Sub Refactor()
        Dim commands = New Commands(ConnectionString)

        Try


            commands.AddTable("ProposalInfo")
            commands.AddColumn("ProposalInfo", New Column("Id", New DataTypes.AutoNumber()))
            commands.AddColumn("ProposalInfo", New Column("Company", New DataTypes.Text))
            commands.AddColumn("ProposalInfo", New Column("MyName", New DataTypes.Text))
            commands.AddColumn("ProposalInfo", New Column("MyPhone", New DataTypes.Text))
            commands.AddColumn("ProposalInfo", New Column("MyEmail", New DataTypes.Text))
            commands.AddColumn("ProposalInfo", New Column("MyTitle", New DataTypes.Text))
            commands.AddColumn("ProposalInfo", New Column("Username", New DataTypes.Text))


        Catch ex As Exception

        End Try
        ' commands.AddColumn("ACChillerProcesses", New Column("FanWatts", New DataTypes.Double))
    End Sub





    Public Class AddFanRPMToCondensingUnitProcesses
        Inherits RefactoringBase

        Sub New(ByVal connectionString As String)
            connectionString_ = connectionString
        End Sub

        Overrides ReadOnly Property Description As String
            Get
                Return "Add DOEModel to CondensingUnitProcesses and UnitCoolerProcesses Tables"
            End Get
        End Property

        Overrides ReadOnly Property ReleaseDate As Date
            Get
                Return #12/8/2020#
            End Get
        End Property

        Overrides ReadOnly Property Version As Deployment.Version
            Get
                Return New Rae.Deployment.Version(1, 100, 0, 0)
            End Get
        End Property


        Protected Overrides Sub Refactor()
            Dim commands = New Commands(ConnectionString)


            commands.AddColumn("CondensingUnitProcesses", New Column("DOEModel", New DataTypes.Text))
            commands.AddColumn("UnitCoolerProcesses", New Column("DOEModel", New DataTypes.Text))


            ' commands.AddColumn("ACChillerProcesses", New Column("FanWatts", New DataTypes.Double))
        End Sub

    End Class


End Class