Namespace Rae.Persistence

Public Class NavigatingEventArgs
   Inherits ValueChangedEventArgs(Of Revision)

   Sub New(before As Revision, after As Revision)
      MyBase.New(before, after)
   End Sub

   Sub Cancel(message As String)
      canceled_ = True
      message_ = message
   End Sub

   ReadOnly Property Canceled As Boolean
      Get
         Return canceled_
      End Get
   End Property

   ReadOnly Property Message As String
      Get
         Return message_
      End Get
   End Property



   Private canceled_ As Boolean
   Private message_ As String

End Class

End Namespace