Imports RegEx = System.Text.RegularExpressions.Regex
Imports RegularExpressions = Rae.Validation.regular_expressions
Imports System.Data

Public Class OptionQuantityForm

   ''' <summary>
   ''' Initializes option quantity
   ''' </summary>
   ''' <param name="code">Option code</param>
   ''' <param name="description">Option description</param>
   Sub New(code As String, description As String)
      MyBase.New()
      Me.InitializeComponent()

      Me.code = code
      Me.description = description
   End Sub


   ''' <summary>
   ''' Option quantity entered by user
   ''' </summary>
   ReadOnly Property Quantity As Integer
   	Get
   		Return _quantity
   	End Get
   End Property : Protected _quantity As Integer


   Function CenterIn(control As Control) As OptionQuantityForm
      Dim grid = New Rectangle(control.Left, control.Top, control.Width, control.Height)

      Dim x = CInt(grid.Width/2 - Width/2)
      Dim y = CInt(grid.Height/2 - Height/2)
      Dim start = New System.Drawing.Rectangle(x, y, Width, Height)
          start = control.RectangleToScreen(start)

      StartPosition = FormStartPosition.Manual
      Left = start.X
      Top  = start.Y

      Return Me
   End Function



   Private code, description As String


   Private Function isValid(quantity As String) As Boolean
      If      Not String.IsNullOrEmpty(quantity) _
      AndAlso RegEx.IsMatch(quantity, RegularExpressions.positive_integer) _
      AndAlso CInt(quantity) > 0 Then
         isValid = True
      Else
         isValid = False
      End If
   End Function


   Private Sub submit()
      If isValid(quantityText.Text) Then
         _quantity = quantityText.Text
         Close()
      Else
         Ui.MessageBox.Show("Please enter a valid quantity. The quantity must be a positive integer greater than zero.", MessageBoxIcon.Warning)
         quantityText.SelectAll()
      End If
   End Sub


   Private Function shorten(Of T)(variableToShortenName As T) As T
      Return variableToShortenName
   End Function

   
   Private Sub quantityText_ValueChanged(s As Object, e As EventArgs) _
   Handles quantityText.ValueChanged
      If isValid(quantityText.Text) Then
         quantityText.Appearance.BorderColor = Color.Green
      Else
         quantityText.Appearance.BorderColor = Color.Orange
      End If
   End Sub


   Private Sub quantityText_KeyDown(s As Object, e As KeyEventArgs) _
   Handles quantityText.KeyDown
      If e.KeyCode = Keys.Enter Then
         submit()
      ElseIf e.Control Then
         Opacity = .6
         Refresh
      End If
   End Sub


   Private Sub quantityText_KeyUp(s As Object, e As KeyEventArgs) _
   Handles quantityText.KeyUp
      If Opacity < 1 Then _
         Opacity = 1
   End Sub


   Private Sub ok_Click(s As Object, e As EventArgs) _
   Handles okButton_.Click
      submit()
   End Sub


   Private Sub form_Load(s As Object, e As EventArgs) _
   Handles Me.Load
      descriptionLabel.Text = code & " " & description
      quantityText.SelectAll()
   End Sub

End Class