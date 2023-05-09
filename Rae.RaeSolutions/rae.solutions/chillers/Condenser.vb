Namespace Rae.Solutions.Chillers

''' <summary>Defines conenser description and filename</summary>
Public Class Condenser1

   Sub New(description As String, fileName As String)
      _description = description
      _fileName = fileName
   End Sub

   Protected _description, _fileName As String

   Property Description As String
      Get
         Return _description
      End Get
      Set(value As String)
         _description = value
      End Set
   End Property

   Property FileName As String
      Get
         Return _fileName
      End Get
      Set(value As String)
         _fileName = value
      End Set
   End Property

   ''' <summary>Returns description</summary>
   Overrides Function ToString() As String
      Return _description
   End Function

End Class

End Namespace