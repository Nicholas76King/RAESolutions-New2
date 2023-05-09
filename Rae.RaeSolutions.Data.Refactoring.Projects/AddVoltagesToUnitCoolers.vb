Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddVoltagesToUnitCoolers
   Inherits RefactoringBase

   Sub New(connectionString As String)
      connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Add defrost and fan voltage to unit cooler pricing."
      End Get
   End Property
   
   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2008, 7, 15)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1,17,0,0)
      End Get
   End Property


   Protected Overrides Sub Refactor()
      Dim commands As New Commands(ConnectionString)
      Dim tableName = "UnitCooler"
      commands.AddColumn(tableName, New Column("DefrostVoltage", New DataTypes.Text(50)))
      commands.AddColumn(tableName, New Column("FanVoltage", New DataTypes.Text(50)))
   End Sub

End Class
