Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddStaticPressureForCuUcBalanceRefactoring : Inherits RefactoringBase
   Sub New(connectionString As String)
      me.connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Add static pressure columns for condensing unit unit cooler balance"
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 5, 13)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 27, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands = New Commands(connectionString_)
      commands.AddColumn("UnitCoolerProcesses", new column("static_pressure_1", new DataTypes.Double(0)))
      commands.AddColumn("UnitCoolerProcesses", new column("static_pressure_2", new DataTypes.Double(0)))
      commands.AddColumn("UnitCoolerProcesses", new column("static_pressure_3", new DataTypes.Double(0)))
   End Sub
End Class