Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Reports
Imports Rae.RaeSolutions.SelectedOptionsDataSet
Imports Col = Rae.RaeSolutions.DataAccess.Projects.Tables.OptionsObjectTable
Imports Rae.Ui

MustInherit Class OrderWriteUp

   Sub New(equipView As EquipmentForm, mainView As MainForm)
      Me.equipView = equipView
      Me.mainView = mainView
   End Sub 
   
   Sub View()
      Dim viewer = createViewer()
      If Not isValid Then
         warn(errorMessage)
         Exit Sub
      End If
      prepare(viewer)
      _finish(viewer)
      finish(viewer)
      viewer.view()
   End Sub
   
   
   Private errorMessage As String
   Protected equipView As EquipmentForm
   Protected mainView As MainForm
   Protected equipBag As equipment_grabber.bag
   Protected projectBag As project_grabber.bag
   Protected pricingBag As pricing_grabber.bag
   
   MustOverride Protected Function createViewer() As order_write_up_report_viewer
   
   Protected Overridable Sub prepare(viewer As order_write_up_report_viewer)
      projectBag = New project_grabber(equipView).grab()
      equipBag   = New equipment_grabber(equipView).grab()
      pricingBag = New pricing_grabber(equipView).grab()
      
      With viewer
         If String.IsNullOrEmpty(equipBag.custom_model) Then
            .model_number = equipBag.model
         Else
            .model_number = equipBag.custom_model & equipBag.model
         End If
         .unit_quantity = equipBag.quantity
         .job = equipBag.job
         
         .project                = projectBag.project_name
         .project_id             = projectBag.project_id
         .representative         = projectBag.rep
         .representative_company = projectBag.rep_company
         .contractor             = projectBag.contractor
         .contractor_company     = projectBag.contractor_company
         .engineer               = projectBag.engineer
         .engineer_company       = projectBag.engineer_company
         .architect              = projectBag.architect
         .architect_company      = projectBag.architect_company         
         
         .version               = My.Application.Info.Version.ToString
         .creator               = AppInfo.User.username
         .pricing_is_authorized = AppInfo.User.can_view_pricing
         
         .base_list_price   = pricingBag.base_list
         .total_list_price  = pricingBag.total_list
         .options_price     = pricingBag.options
         .other_price       = pricingBag.other
         .other_description = pricingBag.other_description
         .par_multiplier    = pricingBag.par_multiplier
         .par_price         = pricingBag.par_price
         .freight           = pricingBag.freight
         .start_up          = pricingBag.start_up
         .warranty          = pricingBag.warranty
         .commission_price  = pricingBag.commission
         .commission_rate   = pricingBag.commission_rate
      End With
   End Sub
   
   Protected Overridable Sub _finish(ByRef viewer As order_write_up_report_viewer)
      equipView.populateSelectedOptionsDataSet(AppInfo.User.can_view_pricing)
   End Sub
   
   Protected Overridable Sub finish(viewer As order_write_up_report_viewer)
      viewer.Report.Subreports(0).SetDataSource(equipView.selectedOpsDs)
      viewer.Report.Subreports(1).SetDataSource(equipView.selectedOpsDs)
   End Sub
   
   Private Function isValid() As Boolean
      isValid = equipView.orderReportValidationManager.Validate()
      If Not isValid Then _
         errorMessage = equipView.orderReportValidationManager.ErrorMessagesSummary
      Return isValid
   End Function
   
End Class

Class ChillerOrderWriteUp : Inherits OrderWriteUp

   Sub New(equipView As EquipmentForm, mainView As MainForm)
      MyBase.New(equipView, mainView)
   End Sub
   
   Protected Overrides Function createViewer() As order_write_up_report_viewer
      Return New chiller_order_write_up_report_viewer()
   End Function

   Protected Overrides Sub prepare(viewer As order_write_up_report_viewer)
      MyBase.prepare(viewer)
      
      CType(equipView.specsControl, chiller_specs_control).PassOrderWriteUpParams(viewer)
   End Sub
   
   Protected Overrides Sub _finish(ByRef viewer As Reports.order_write_up_report_viewer)
      MyBase._finish(viewer)
      
      ' find pump package option
      Dim pumpOp As SelectedOptionsRow
      For Each op As SelectedOptionsRow In equipView.selectedOpsDs.SelectedOptions
         If pump_package_code.matches(op.Code) Then
            pumpOp = op
            Exit For
         End If
      Next
      
      ' if pump package selected
      If pumpOp IsNot Nothing Then
         Dim pumpDescription = pumpOp.Description
         ' find standard pump package options &
         '  include in pump description & make list to remove
         Dim optionCodesToRemove = New List(Of String)
            ''For Each op In CType(equipView.standardOpGrid.DataSource, System.Data.DataTable).Rows
            ''   If pump_package_codes.has(op(Col.Code)) Then
            ''      optionCodesToRemove.Add(op(Col.Code))
            ''      pumpDescription &= "; " & op(Col.Description)
            ''   End If
            ''Next

            ' find options to remove based on codes
            Dim optionsToRemove = New List(Of SelectedOptionsRow)
         For Each op As SelectedOptionsRow In equipView.selectedOpsDs.SelectedOptions
            For Each code In optionCodesToRemove
               If op.Code = code Then
                  optionsToRemove.Add(op)
                  Exit For
               End If
            Next
         Next
         
         ' remove
         For Each op In optionsToRemove
            equipView.selectedOpsDs.SelectedOptions.RemoveSelectedOptionsRow(op)
         Next
         
         pumpOp.Description = pumpDescription
      End If
      
      
      ' find pump package option
      ' find standard pump package options
      '  include in pump package option
      '  remove from selected options list
      
      ' indent selected pump options
      For Each op As SelectedOptionsRow In equipView.selectedOpsDs.SelectedOptions.Rows
         If pump_package_codes.has( op(Col.Code).ToString ) Then
            ' indent
            op(Col.Code) = "     " & op(Col.Code).ToString
            op(Col.Description) = "     " & op(Col.Description).ToString
         End If
      Next
   End Sub
   
End Class
