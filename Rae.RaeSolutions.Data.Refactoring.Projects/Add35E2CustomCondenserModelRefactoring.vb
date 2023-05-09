Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class Add35E2CustomCondenserModelRefactoring : Inherits RefactoringBase
   Sub New(connectionString As String)
      me.connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Adds a CustomCondenserModel, FanMotorHp and PumpMotorHp columns to the EvapChillerProcesses table."
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 03, 25)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 24, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands = New Commands(connectionString_)
      dim table_name = "EvapChillerProcesses"
      commands.AddColumn(table_name, New Column("CustomCondenserModel", New DataTypes.Text()))
      commands.AddColumn(table_name, New Column("FanMotorHp", New DataTypes.Double()))
      commands.AddColumn(table_name, New Column("PumpMotorHp", New DataTypes.Double()))
   End Sub
End Class