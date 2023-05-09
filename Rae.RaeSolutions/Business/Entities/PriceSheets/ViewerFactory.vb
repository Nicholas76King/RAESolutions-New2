Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

Public Class ViewerFactory
   Function Create(user As String, app As String, version As String, by As FilterBy, filter As String) As IPriceViewer
      Dim viewer As IPriceViewer
      Select Case by
         Case FilterBy.Division
            viewer = New PriceByDivisionViewer(user, app, version, by, filter)
      	Case FilterBy.Series
      	   viewer = New PriceBySeriesViewer(user, app, version, by, filter)
      	Case FilterBy.Model
      	   viewer = New PriceByModelViewer(user, app, version, by, filter)
      End Select
      Return viewer
   End Function
End Class

End Namespace