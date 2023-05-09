'****************************************
'** FILL COMBOBOX WITH DISPLAYMEMBER AND VALUEMEMBER
'** To get the selecteditem use "(combobox).SelectedItem.DisplayName"
'** To get the selectedvalue use "(Combobox).SelectedITem.ValueName"
'****************************************
Public Class cFillCombobox
   Private _value As String = ""
   Private _display As String = ""


   Public ReadOnly Property ValueName() As String
      Get
         Return Me._value
      End Get
   End Property

   Public ReadOnly Property DisplayName() As String
      Get
         Return Me._display
      End Get
   End Property


   Public Sub New(ByVal display As String, ByVal value As String)
      Me._value = value
      Me._display = display
   End Sub

End Class
