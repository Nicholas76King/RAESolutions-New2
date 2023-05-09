Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Business.Repositories

Public Class PumpSelectionPresenter
   
   Private WithEvents view As IPumpSelectionView
   Private repo As IPumpRepo
   
   Sub New(view As IPumpSelectionView, repo As IPumpRepo)
      Me.view = view
      Me.repo = repo
   End Sub
   
   Private Sub view_Changed() Handles view.Changed
      update
   End Sub

   
   Private Sub update()
      Dim p = repo.GetPump(view.Manufacturer, view.Flow, view.Head, view.Sys)
      Dim raeModel = New PumpRaeModel(view.Flow, view.Sys).Value
      
      If view.SelectionIsValid Then _
         view.Select(p.Model, raeModel, p.Efficiency, p.HP, p.RPM, p.PipeSize, p.BaseListPrice)
   End Sub
   
End Class
