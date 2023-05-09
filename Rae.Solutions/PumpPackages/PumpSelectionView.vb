Imports Rae.RaeSolutions.Business.Entities

Public Interface IPumpSelectionView
   Sub [Select](mfgModel As String, raeModel As String, efficiency As Double, hp As Double, rpm As Double, pipeSize As Double, price As Double)
   ''' <summary>Occurs after pump selection criteria has changed</summary>
   Event Changed As EventHandler(Of Object, EventArgs)
   ''' <summary>Occurs after flow has changed</summary>
   Event FlowChanged As EventHandler(Of Object, EventArgs)
   Property Flow() As Double
   Property Manufacturer() As String
   Property Head() As Double
   Property Sys() As PumpSystem
   ReadOnly Property Series() As String
   ReadOnly Property Model() As String
   ReadOnly Property SelectionIsValid() As Boolean
   Sub Refresh()
End Interface

Public Class PumpSelectionView
   Implements IPumpSelectionView

   ''' <summary>Occurs after pump selection criteria has changed</summary>
   Event Changed As EventHandler(Of Object, EventArgs) Implements IPumpSelectionView.Changed
   
   Protected Overridable Sub onChanged()
   	If Me.ChangedEvent IsNot Nothing Then _
   	   RaiseEvent Changed(Me, EventArgs.Empty)
   End Sub
   
   ''' <summary>Occurs after flow has changed</summary>
   Event FlowChanged As EventHandler(Of Object, EventArgs) Implements IPumpSelectionView.FlowChanged
   
   Protected Overridable Sub onFlowChanged()
   	If Me.FlowChangedEvent IsNot Nothing Then _
   	   RaiseEvent FlowChanged(Me, EventArgs.Empty)
   End Sub

   
   Property Flow As Double Implements IPumpSelectionView.Flow
   	Get
   		Return txtFlow.Text
   	End Get
   	Set(value As Double)
         txtFlow.Text = value
      End Set
   End Property
   
   Property Manufacturer As String Implements IPumpSelectionView.Manufacturer
   	Get
   		Return cboMfg.SelectedItem
   	End Get
   	Set(value As String)
   	   If value Is Nothing Then
            cboMfg.SelectedIndex = 0
         Else
            cboMfg.SelectedIndex = cboMfg.Items.IndexOf(value)
         End If
      End Set
   End Property
   
   Property Head As Double Implements IPumpSelectionView.Head
   	Get
   		Return cboHead.SelectedItem
   	End Get
   	Set(value As Double)
         cboHead.SelectedIndex = cboHead.Items.IndexOf(value.ToString)
      End Set
   End Property
   
   Property Sys As PumpSystem Implements IPumpSelectionView.Sys
   	Get
   	   Dim s As PumpSystem
   	   
   	   If cboSys.SelectedIndex = 1 Then
            s = PumpSystem.Dual
         Else
            s = PumpSystem.Single
         End If
         
   		Return s
   	End Get
   	Set(value As PumpSystem)
         If value = PumpSystem.Dual Then
            cboSys.SelectedIndex = 1
         Else
            cboSys.SelectedIndex = 0
         End If
      End Set
   End Property
   
   
   ReadOnly Property Series As String Implements IPumpSelectionView.Series
   	Get
   		Return _series
   	End Get
   End Property : Private _series As String
   
   ReadOnly Property Model As String Implements IPumpSelectionView.Model
   	Get
   		Return _model
   	End Get
   End Property : Private _model As String
   
      
   ReadOnly Property SelectionIsValid As Boolean Implements IPumpSelectionView.SelectionIsValid
      Get
         Return cboSys.SelectedItem IsNot Nothing
      End Get
   End Property
   
   Sub [Select]( _
      mfgModel As String, _
      raeModel As String, _
      efficiency As Double, _
      hp As Double, _
      rpm As Double, _
      pipeSize As Double, _
      price As Double _
   ) Implements IPumpSelectionView.[Select]
      dataView.Populate(mfgModel, raeModel, efficiency, hp, rpm, pipeSize)
      lblPrice.Text = price
   End Sub
   
   Sub Refresh() Implements IPumpSelectionView.Refresh
      Dim m = New PumpDbModel(Manufacturer, Flow, Head, Sys)
      _series = m.Series
      _model = m.Model
      
      onChanged
   End Sub
   
   Private Sub me_load() Handles Me.Load
      cboMfg.SelectedIndex = 0
      cboHead.SelectedIndex = 0
      cboSys.SelectedIndex = 0
      
      Dim p = New PumpSelectionPresenter(Me, PumpRepoFactory.Create)
   End Sub
   
   Private Sub flow_Changed() Handles txtFlow.Leave
      onFlowChanged()
   End Sub
   
   Private Sub selection_Changed() Handles _
   txtFlow.Leave, _
   cboMfg.SelectedIndexChanged, _
   cboSys.SelectedIndexChanged, _
   cboHead.SelectedIndexChanged
      Dim m = New PumpDbModel(Manufacturer, Flow, Head, Sys)
      _series = m.Series
      _model = m.Model
   
      onChanged()
   End Sub
   
End Class
