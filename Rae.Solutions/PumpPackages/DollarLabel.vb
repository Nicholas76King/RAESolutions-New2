Public Class DollarLabel
   Inherits Label

   Private dollarFormat As String = "$#0"

   Overrides Property Text As String
      Get
         Return MyBase.Text
      End Get
      Set(value As String)
         If String.IsNullOrEmpty(value) Then _
            value = "0"
         value = value.Replace("$", "")
         Try
            MyBase.Text = CDbl(value).ToString(dollarFormat)
         Catch ex As Exception
            MyBase.Text = "$0"
         End Try
      End Set
   End Property

End Class
