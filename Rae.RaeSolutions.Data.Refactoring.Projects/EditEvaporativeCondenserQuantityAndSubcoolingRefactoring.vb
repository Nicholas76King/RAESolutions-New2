Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class EditEvaporativeCondenserQuantityAndSubcoolingRefactoring
   Inherits RefactoringBase
   
   Sub New(connectionString As String)
      Me.connectionString_ = connectionString
   End Sub
   
   Overrides ReadOnly Property Description As String
      Get
         Return "Change evaporative condenser chillers condenser quantity from integer to double. Change subcooling from boolean to double."
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 2, 23)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 22, 1, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands = New Commands(connectionString_)
      commands.EditColumn("EvapChillerProcesses", New Column("NumCoils1", New DataTypes.Double()))
      commands.EditColumn("EvapChillerProcesses", New Column("NumCoils2", New DataTypes.Double()))
      commands.EditColumn("EvapChillerProcesses", New Column("SubCooling", New DataTypes.Double()))
   End Sub

End Class