imports rae.solutions.drawings
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.Ui

Class pump_package_pricing_screen
   
   Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      
      ' Add any initialization after the InitializeComponent() call.
      opening = AddressOf createPumpModelPresenter
      loadEngineeringData = AddressOf loadPumpPackage

      if user.can_view_pricing then
         barReports.DropDownItems.Add("Order Write Up", nothing, addressof show_order_write_up)
         mnu_order_write_up = mnuReports.DropDownItems.Add("Order Write Up", nothing, addressof show_order_write_up)
      end if
   End Sub

   private sub show_submittal
        Dim report = New pump_accessories(Me)
        Dim junk As String = ""
        report.show(False, junk)
   end sub

   private sub show_order_write_up
        Dim report = New pump_order_write_up(Me)
        Dim junk As String = ""
        report.show(False, junk)
   end sub
   
   Protected Overrides Function create_presenter() As equipment_pricing_presenter_base
      Return New pump_pricing_presenter(Me, AppInfo.Main)
   End Function
   
   
   Private Sub me_load() Handles Me.Load
        ' cboUnitVoltage.Items.Remove("460/1/60")
      
      ' hides convert to process menu and toolbar
      mnuConvert.Visible = False
      barConvert.Visible = False
      
      panSelectedOptions.Height = 220
      
      addPipingNote()
      ppPresenter = CType(presenter, pump_pricing_presenter)
   End Sub
   
   Private Sub loadPumpPackage(unit As EquipmentItem)
      Dim pumpPackage = CType(unit, PumpEquipment)
      
      Dim weights = New PumpPackageWeightCalculator(pumpPackage, New drawing_repository())
      pumpPackage.common_specs.OperatingWeight.set_to(System.Math.Round(weights.OperatingWeight))
      pumpPackage.common_specs.ShippingWeight.set_to(System.Math.Round(weights.ShippingWeight))
      
      Dim control = CType(specsControl, PumpSpecsControl)
      control.SetControlValues(pumpPackage)
   End Sub
   
   Protected Overrides Sub onModelChanged(unit As EquipmentItem)
      ' this code is duplicated from base class but requires the grabEquipment method to grab head and manufacturer
      Dim ctrl = EquipmentSelector1
      If Not ctrl.IsCompleted Then Exit Sub
      grabEquipment()
      onModelChanged_price(unit)
      loadEngineeringData.Invoke(unit)
      onModelChanged_updateOps
   End Sub
   
   Private ppPresenter As pump_pricing_presenter
   Private modelPresenter As PumpModelPresenter
   
   Private Sub createPumpModelPresenter()
      If modelPresenter Is Nothing Then _
         modelPresenter = New PumpModelPresenter(Me)
   End Sub
   
   Overrides Protected Function createSpecsControl() As UserControl
      Return New PumpSpecsControl
   End Function
   
   Overrides Protected Sub onOpSelected(code As String, description As String)
      handleRuntime(code, description)
      handleOpenTank(code)
   End Sub
   
   Private Sub handleRuntime(code As String, description As String)
      Dim op = New TankOption(code, description)
      If op.IsTank Then
         Dim warning = New RuntimeWarning(pumpView.Flow, op.TankSize)
         If warning.Applies Then _
            warn(warning.Message)
      End If
   End Sub
   
   Private Sub handleOpenTank(code As String)
      Dim op = New OpenTankOption(code)
      If op.IsMatch Then _
         warn(op.Warning)
   End Sub
   
   Private Function pumpView As PumpSelectionView
      Return CType(specsControl, PumpSpecsControl).pumpView
   End Function
   
   Private Sub addPipingNote()
      Dim lblPiping = New Label()
      lblPiping.Text = "Copper pipe used through 4"" size; 6"" and larger will be welded black iron pipe"
        ''standardOpGrid.Height = standardOpGrid.Height - 20
        ''standardOpGrid.Parent.Controls.Add(lblPiping)
        ''lblPiping.Location = New Point(standardOpGrid.Location.X, standardOpGrid.Location.Y + standardOpGrid.Height + 4)
        ''lblPiping.Width = standardOpGrid.Width
        lblPiping.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
   End Sub

End Class
