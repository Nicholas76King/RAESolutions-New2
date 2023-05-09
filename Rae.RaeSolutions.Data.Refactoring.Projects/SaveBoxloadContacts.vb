Imports Rae.Data.MicrosoftAccess
Imports Rae.Data.MicrosoftAccess.DataTypes
Imports Rae.Data.Refactoring

''' <summary>Adds contact columns and removes unused columns to box load table.</summary>
Public Class SaveBoxloadContacts
   Inherits RefactoringBase
   
   Sub New(connectionString As String)
      connectionString_ = connectionString
   End Sub

   Overrides ReadOnly Property Description As String
      Get
         Return "Adds contact columns and deletes unused columns."
      End Get
   End Property

   Overrides ReadOnly Property ReleaseDate As Date
      Get
         Return New Date(2008,8,1)
      End Get
   End Property

   Overrides ReadOnly Property Version As Deployment.Version
      Get
         Return New Deployment.Version(1,18,0,0)
      End Get
   End Property
   
   Protected Overrides Sub Refactor()
      Dim commands As New Commands(connectionString_)
      Dim tableName = "CoolStuffProjects"
      
      ' adds contact columns
      With commands
         Dim contact1 = New Column("Contact1", New Number(Of Integer)(NumberType.LongInteger))
         Dim contact2 = New Column("Contact2", New Number(Of Integer)(NumberType.LongInteger))
         
         .AddColumn(tableName, contact1)
         .AddColumn(tableName, contact2)
      End With
      
      ' deletes unused columns
      With commands
         .DeleteColumn(tableName, "IHeatRem")
         .DeleteColumn(tableName, "Product")
         .DeleteColumn(tableName, "Type")
         .DeleteColumn(tableName, "FreezePt")
         .DeleteColumn(tableName, "CHeat")
         .DeleteColumn(tableName, "FLatent")
         .DeleteColumn(tableName, "CIbs")
         .DeleteColumn(tableName, "CLoad")
         .DeleteColumn(tableName, "CPull")
         .DeleteColumn(tableName, "CEnter")
         .DeleteColumn(tableName, "CFinal")
         .DeleteColumn(tableName, "CTot")
         .DeleteColumn(tableName, "FTot")
         .DeleteColumn(tableName, "CFPTot")
         .DeleteColumn(tableName, "CFTot")
         .DeleteColumn(tableName, "ProdTot")
         .DeleteColumn(tableName, "RHeat")
         .DeleteColumn(tableName, "RIbs")
         .DeleteColumn(tableName, "RTot")
         .DeleteColumn(tableName, "Height")
         .DeleteColumn(tableName, "CFHeat")
         .DeleteColumn(tableName, "CreatedBy")
      End With
   End Sub
   
End Class