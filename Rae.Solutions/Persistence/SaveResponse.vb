Imports Rae.Persistence
Imports System.Collections.Generic

Namespace Persistence

Public Class SaveResponse

   Sub New(inputs As Dictionary(Of String, String), selectedCommand As String)
      _inputs = inputs
      _selectedCommand = selectedCommand
   End Sub

   ReadOnly Property Inputs As Dictionary(Of String, String)
      Get
         Return _inputs
      End Get
   End Property

   ReadOnly Property SelectedCommand As String
      Get
         Return _selectedCommand
      End Get
   End Property

   Protected _inputs As Dictionary(Of String, String)
   Protected _selectedCommand As String
   
End Class

End Namespace
