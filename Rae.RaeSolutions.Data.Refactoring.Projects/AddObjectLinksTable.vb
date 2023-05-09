Imports Rae.Data.MicrosoftAccess

Public Class AddObjectLinksTable
   Inherits Rae.Data.Refactoring.RefactoringBase

   Public Sub New(ByVal connectionstring As String)
      Me.connectionString_ = connectionstring
   End Sub


   Public Overrides ReadOnly Property Description() As String
      Get
         Return "Adds ObjectLinks table to Projects database."
      End Get
   End Property

   Protected Overrides Sub Refactor()
      Dim cmds As New Rae.Data.MicrosoftAccess.Commands(ConnectionString)
      cmds.AddTable("ObjectLinks")
      cmds.AddColumn("ObjectLinks", New Column("ObjectId", New DataTypes.Text(50)))
      cmds.AddColumn("ObjectLinks", New Column("ReferenceObjectType", New DataTypes.Text(50)))
      cmds.AddColumn("ObjectLinks", New Column("ReferenceObjectXML", New DataTypes.Memo()))
   End Sub

   Public Overrides ReadOnly Property ReleaseDate() As Date
      Get
         Return #8/13/2007#
      End Get
   End Property

   Public Overrides ReadOnly Property Version() As Deployment.Version
      Get
         Return New Deployment.Version(1, 5, 0, 0)
      End Get
   End Property
End Class
