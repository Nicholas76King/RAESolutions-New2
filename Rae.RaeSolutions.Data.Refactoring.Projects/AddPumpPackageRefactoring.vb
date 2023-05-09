Imports Rae.Data.Refactoring
Imports Rae.Data.MicrosoftAccess

Public Class AddPumpPackageRefactoring
   Inherits RefactoringBase
   
   Sub New(connectionString As String)
      connectionString_ = connectionString
   End Sub
   
   Overrides ReadOnly Property Description As String
      Get
         Return "Add table and columns to store pump package pricing"
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return #12/2/2008#
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1, 19, 0, 0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim cmd As New Commands(connectionString_)
      Dim table = "PumpPackage"
      
      cmd.AddTable(table)
      cmd.AddColumn( table, New Column("EquipmentId", New DataTypes.Text(50)) )
      cmd.AddColumn( table, New Column("Revision", New DataTypes.Single(0)) )
      cmd.AddColumn( table, New Column("Manufacturer", New DataTypes.Text) )
      cmd.AddColumn( table, New Column("Flow", New DataTypes.Double) )
      cmd.AddColumn( table, New Column("Head", New DataTypes.Double) )
      cmd.AddColumn( table, New Column("System", New DataTypes.Text) )
      cmd.AddColumn( table, New Column("ChillerId", New DataTypes.Text) )
      
   End Sub
   
End Class
