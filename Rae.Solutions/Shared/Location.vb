''' <summary>
''' Location of a folder or file
''' </summary>
Public Class Location

   Sub New(path As String)
      _path = path
      s = "\"
   End Sub

   Property Path As String
      Get
         Return _path
      End Get
      Set(value As String)
         _path = value
      End Set
   End Property

   Function Up() As Location
      Dim separatorIndex As Integer

      ' ends with seperator
      If lastIndex = Path.LastIndexOf(s) Then
         ' get index of second to last separator
         separatorIndex = Path.Remove(lastIndex).LastIndexOf(s)
      Else
         ' get index of last separator
         separatorIndex = Path.LastIndexOf(s)
      End If

      ' moves up a folder
      Path = Path.Remove(separatorIndex + 1)

      Return Me
   End Function



   Protected ReadOnly Property lastIndex As Integer
      Get
         Return Path.Length - 1
      End Get
   End Property

   Private _path As String
   ''' <summary>Separator</summary>
   Private s As String

End Class
