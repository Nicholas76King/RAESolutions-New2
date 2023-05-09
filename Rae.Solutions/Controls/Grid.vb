''' <summary>
''' Grid control with more functionality than DataGridView
''' </summary>
Public Class Grid
   Inherits DataGridView
   
   ''' <summary>
   ''' Gets location to display pop-up below or above selected row without exceeding screen boundaries.
   ''' </summary>
   ''' <param name="popupSize">
   ''' Size of popup to display
   ''' </param>
   Function GetLocationNearSelectedRow(popupSize As Size) As Point
      Dim position As Point
      
      If SelectedRows.Count > 0 Then
         position = GetLocationNearRow(SelectedRows(0), popupSize)
      End If
      
      Return position
   End Function
   
   ''' <summary>
   ''' Gets location to display pop-up below row or above row w/out exceeeding screen boundaries.
   ''' </summary>
   ''' <param name="row">
   ''' Row that return location is related to.
   ''' </param>
   ''' <param name="popupSize">
   ''' Size of pop-up to display.
   ''' </param>
   Function GetLocationNearRow(row As DataGridViewRow, popupSize As Size) As Point
      Dim formLocation As Point

      '
      ' gets location BELOW row
      '
      Dim formRectangleBelow As New Rectangle(Me.getLocationBelowRow(row), popupSize)

      If Me.isContainedByScreen(formRectangleBelow) Then
         formLocation = Me.getLocationBelowRow(row) : Return formLocation
      End If

      '
      ' gets location ABOVE row, if location below exceed screen boundaries
      '
      Dim formRectangleAbove As Rectangle
      Dim formLocationAbove As Point

      formLocationAbove = Me.getLocationAboveRow(row)
      formLocationAbove.Y -= popupSize.Height

      formRectangleAbove = New Rectangle(formLocationAbove, popupSize)

      If Me.isContainedByScreen(formRectangleAbove) Then
         formLocation = formRectangleAbove.Location : Return formLocation
      End If

      '
      ' gets DEFAULT location, if location above and below row both exceed screen boundaries
      ' default setting shouldn't occur (causes: large pop-up or small screen)
      '
      formLocation = New Point(0, 0) : Return formLocation
   End Function


#Region " Internal"

   ''' <summary>
   ''' Gets location below and to the left of row.
   ''' </summary>
   ''' <param name="row">
   ''' Row the returned location is related to.
   ''' </param>
   ''' <returns>
   ''' Location below and to the left of row.
   ''' </returns>
   Private Function getLocationBelowRow(row As DataGridViewRow) As Point
      Dim location As Point
      Dim x, y As Integer

      ' gets location below row aligned w/ left of grid
      x = Me.Left
      y = Me.GetRowDisplayRectangle(row.Index, True).Y + row.Height

      location = Me.PointToScreen(New Point(x, y))

      Return location
   End Function


   ''' <summary>
   ''' Gets location above and to the left of row.
   ''' </summary>
   ''' <param name="row">
   ''' Row that returned location is related to.
   ''' </param>
   ''' <returns>
   ''' Location above and to the left of row.
   ''' </returns>
   Private Function getLocationAboveRow(row As DataGridViewRow) As Point
      Dim location As Point
      Dim x, y As Integer

      ' gets location above row aligned w/ left of grid
      x = Me.Left
      y = Me.GetRowDisplayRectangle(row.Index, True).Y

      location = Me.PointToScreen(New Point(x, y))

      Return location
   End Function


   ''' <summary>
   ''' True if rectangle is completely contained by screen; else false.
   ''' </summary>
   ''' <param name="rectangle">
   ''' Rectangle to check if it is completely contained by screen.
   ''' </param>
   ''' <returns>
   ''' True if rectangle is completely contained by screen; else false.
   ''' </returns>
   Private Function isContainedByScreen(rectangle As Rectangle) As Boolean
      Dim screen As Rectangle
      Dim contained As Boolean

      ' gets screen size
      screen = My.Computer.Screen.WorkingArea

      ' checks if rectangle is completely contained in screen
      contained = screen.Contains(rectangle)

      Return contained
   End Function
   
#End Region

End Class
