Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class Add35E2BalanceDataRefactoring : Inherits RefactoringBase
   Sub New(connectionString As String)
      me.connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Adds columns to store 35E2 balance data used for electrical calculations"
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2010, 04, 07)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 26, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands = New Commands(connectionString_)
      Dim table_name = "Chiller"
      commands.AddColumn(table_name, new column("CompressorAmps1", new dataTypes.Double()))
      commands.AddColumn(table_name, new column("CompressorAmps2", new dataTypes.Double()))
      commands.AddColumn(table_name, new column("CompressorQuantity1", new dataTypes.Double()))
      commands.AddColumn(table_name, new column("CompressorQuantity2", new dataTypes.Double()))
      commands.AddColumn(table_name, new column("CondenserQuantity", new dataTypes.Double()))
      commands.AddColumn(table_name, new column("SprayPumpAmps", new dataTypes.Double()))
      commands.AddColumn(table_name, new column("BlowerAmps", new dataTypes.Double()))
      commands.AddColumn(table_name, new column("HasBalance", new dataTypes.YesNo(false)))
   End Sub
End Class
