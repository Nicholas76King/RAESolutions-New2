Imports Rae.RaeSolutions.Business.Entities
Imports System.Math

Public Class PumpDataView
   Implements IPumpDataView
   
   Sub Populate( _
      mfgModel As String, _
      raeModel As String, _
      efficiency As Double, _
      hp As Double, _
      rpm As Double, _
      pipeSize As Double _
   ) Implements IPumpDataView.Populate
      lblMfgModel.Text = mfgModel
      lblEfficiency.Text = efficiency & "%"
      lblHp.Text = hp
      lblRpm.Text = rpm
      lblRaeModel.Text = raeModel
      lblPipeSize.Text = pipeSize & """"
   End Sub
   
End Class

Public Interface IPumpDataView
   Sub Populate(mfgModel As String, raeModel As String, efficiency As Double, hp As Double, rpm As Double, pipeSize As Double)
End Interface
