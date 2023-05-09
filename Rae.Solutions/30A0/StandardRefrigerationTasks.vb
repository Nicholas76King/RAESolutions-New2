Imports Rae.Math.comparisons
Imports Rae.Engineering
Imports Rae.Engineering.Equipment.Chillers.ChillyWrapper
Imports rae.solutions.chiller_evaporators
Imports System.Math
Imports Agent = Rae.RaeSolutions.Business.Agents.ChillerAgent

Class StandardRefrigerationTasks
   Sub New(form As air_cooled_chiller_balance_window)
      Me.form = form
      grab = New ChillerGrab(form)
   End Sub
   
   Sub SetSpecificHeatAndGravity()
      Dim bag = grab.BagForSpecificHeatAndGravity
      Dim specific = form.service.calculate_specific_heat_and_gravity(bag.Fluid, bag.GlycolPercentage, bag.EnteringFluidF, bag.LeavingFluidF)

      form.txtSpecificHeat.Text    = specific.heat.ToString("0.####")
      form.txtSpecificGravity.Text = specific.gravity.ToString("0.####")
   End Sub
   
   Sub ListAlternateEvaporators()
      Dim altModels = New List(Of String)
   
      Dim spec  = grab.SpecForAlternateEvaporators
      Dim svc   = New evaporator_service_factory().create()
      Dim evaps = svc.get_alternate_evaporators(spec)
      
      form.cbo_evaporator_model.Items.Clear()
      For Each evap In evaps
         altModels.Add(evap.evaporator_part_number)
         form.cbo_evaporator_model.Items.Add(evap.evaporator_part_number)
      Next
   End Sub
   
   Sub ListEvaporatorDataForApproachRange()
      Dim spec = grab.SpecForAlternateEvaporators
      Dim evapPartNum = form.EvaporatorModel
      Dim range = New List(Of evaporator)

      Try
         If Not form.EvaporatorGrid1.CustomSelected Then
            Dim svc = New evaporator_service_factory().create()
            range = svc.get_approach_range(evapPartNum, spec)

            form.EvaporatorGrid1.Show(range)
         End If
            
         For Each evap In range
            form.PD_GPM(evap.spec.approach, 1) = Round(evap.fluid_pressure_drop, 2)
            form.PD_GPM(evap.spec.approach, 2) = Round(evap.fluid_flow, 2)
         Next
      Catch ex As StandardRefrigerationException
         form.EvaporatorGrid1.Show(Nothing)
         Ui.alert(ex.Message)
      End Try
   End Sub
   
   Private form As air_cooled_chiller_balance_window
   Private grab As ChillerGrab
End Class

