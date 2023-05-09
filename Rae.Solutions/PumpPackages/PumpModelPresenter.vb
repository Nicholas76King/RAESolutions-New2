Class PumpModelPresenter
   
   Private view As EquipmentForm
   Private WithEvents cboVoltage As ComboBox
   Private WithEvents pumpView As PumpSelectionView
   
   Sub New(view As EquipmentForm)
      ' gets references to necessary controls
      Me.view = view
      Dim specsCtrl = CType(view.specsControl, PumpSpecsControl)
      pumpView = specsCtrl.pumpView
      cboVoltage = specsCtrl.cboUnitVoltage
      
      ' hides standard model selection since pump package model is based on other criteria
      view.modelPanel.Visible = False
      
      ' enable unit voltage combobox since the other one is now hidden
      cboVoltage.Enabled = True
   End Sub
   
   
   Private Sub pumpView_FlowChanged() Handles pumpView.FlowChanged
      If pumpView.Flow >= 750 Then
         Rae.Ui.quickies.warn("Flow must be less than 750")
         pumpView.Flow = 749
         pumpView.Refresh()
      End If
   End Sub
   
   Private Sub pumpView_Changed() Handles pumpView.Changed
      view.EquipmentSelector1.Series = pumpView.Series
      view.EquipmentSelector1.Model = pumpView.Model
   End Sub
   
   Private Sub voltage_Changed() Handles cboVoltage.SelectedIndexChanged
      If Not view.isAlreadySyncing Then _
         syncVoltage
   End Sub
   
   Private Sub syncVoltage()
      view.isAlreadySyncing = True

      Dim newIndex = view.cboUnitVoltage.Items.IndexOf( cboVoltage.SelectedItem.ToString )      
      view.cboUnitVoltage.SelectedIndex = newIndex
      
      view.isAlreadySyncing = False
   End Sub
   
End Class
