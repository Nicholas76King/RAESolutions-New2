option strict off

imports system.environment
Imports System.Math
Imports rae.solutions.compressors.compressor_repository

namespace rae.solutions.cu_uc_balances.balance_system

public class balance

   private increments() as double = {5, 0.5, 0.1}
   private spec as range_spec
   private condensing_unit as condensing_unit
   private unit_coolers as unit_cooler_list
   private custom_unit_cooler as custom_unit_cooler
        Private results_dataset As balance_dataset
        Private user As user


        Sub New(condensing_unit As condensing_unit, unit_coolers As unit_cooler_list, custom_unit_cooler As custom_unit_cooler, spec As spec, user1 As user)
            Dim range_spec = New range_spec()
            range_spec.max_ambient = spec.ambient
            range_spec.min_ambient = spec.ambient
            range_spec.ambient_step = 1
            range_spec.min_room_temp = spec.room_temp
            range_spec.max_room_temp = spec.room_temp
            range_spec.room_temp_step = 1
            range_spec.import(spec)
            user = user1


            Me.spec = range_spec
            Me.condensing_unit = condensing_unit
            Me.unit_coolers = unit_coolers
            Me.custom_unit_cooler = custom_unit_cooler
        End Sub

   sub new(condensing_unit as condensing_unit, unit_coolers as unit_cooler_list, custom_unit_cooler as custom_unit_cooler, spec as range_spec)
      me.spec = spec
      me.condensing_unit = condensing_unit
      me.unit_coolers = unit_coolers
      me.custom_unit_cooler = custom_unit_cooler
   end sub
   
   public messages as string

   function run() as balance_dataset
      results_dataset = new balance_dataset()

      messages = ""
      for ambient = spec.min_ambient to spec.max_ambient step spec.ambient_step
         for room_temp = spec.min_room_temp to spec.max_room_temp step spec.room_temp_step
            spec.ambient = ambient
            spec.room_temp = room_temp
            run_at_condition()
         next
         ' adds a solid row before ambient increases unless its on last increment
         if ambient < spec.max_ambient then add_solid_row_in_results_grid("----")
      next

      return results_dataset
   end function

   private sub run_at_condition()
      spec.evaporating_temp = determine_evaporating_temp_to_begin_with(spec.room_temp)
      
      dim unit_evaluator = new unit_evaluator(condensing_unit, unit_coolers, custom_unit_cooler, spec)
      dim results = unit_evaluator.evaluate()

      for i = 0 to increments.length - 1 'iterate evaporating temp
         while results.condensing_unit_capacity < results.evaporator_capacity
            results = unit_evaluator.update( spec.evaporating_temp + increments(i) )
         end while

         if i < (increments.length - 1) then
            results = unit_evaluator.update( spec.evaporating_temp - increments(i) + increments(i+1) )
         end if
      next

      dim total_unit_cooler_fan_watts, fan_watts As Integer
      for each unit_cooler in unit_coolers
                fan_watts = unit_cooler.quantity * select_total_fan_watts(unit_cooler.model, spec.altitude, hertz:=60)
         total_unit_cooler_fan_watts += fan_watts
      next

      dim system_watts = results.condensing_unit_w + total_unit_cooler_fan_watts
      ' bug: i'm pretty sure this is wrong, amps can't be calculated this way for 3 phase
      dim system_amps_at_460 = system_watts / 460
      dim system_amps_at_230 = system_watts / 230
            '  Dim user As user


      ' if balances right on suction temperature limit, assume it would have actually balance outside limits
      dim cu = new condensing_units.Repository().get_unit(condensing_unit.model)
            If Round(spec.suction_temp, 2) <= cu.minSuctionOfUnit Then
                add_solid_row_in_results_grid("below min suction")
            ElseIf user.is_rep AndAlso (spec.room_temp - spec.evaporating_temp) < 8 Then
                MsgBox("System TD Balance is too low. Reselect evaporator(s).")
                add_solid_row_in_results_grid("TD Too Low")
            Else
                add_results_row(spec.ambient, spec.room_temp, spec.suction_temp, spec.evaporating_temp, _
                   results.condensing_temp, results.condensing_unit_capacity, system_watts / 1000, system_amps_at_460, system_amps_at_230, spec.division)
            End If
        End Sub

   private sub add_solid_row_in_results_grid(fill_with_this as string)
      Dim row As balance_dataset.balance_resultsRow = results_dataset.balance_results.NewRow()

      row.ambient_temp     = fill_with_this
      row.room_temp        = fill_with_this
      row.suction_temp     = fill_with_this
      row.evaporating_temp = fill_with_this
      row.condensing_temp  = fill_with_this
      row.td               = fill_with_this
      row.system_power     = fill_with_this
      row.system_current   = fill_with_this
      row.Capacity         = fill_with_this

      results_dataset.balance_results.Rows.Add(row)
   end sub

   private function add_results_row( _
      ambient as double, room_temp as double, suction_temp as double, evaporating_temp as double, condensing_temp as double, _
      capacity as double, system_kw as double, system_amps_460 as double, system_amps_230 as double,
      division as Rae.RaeSolutions.Business.Division
   ) as rae.validation.validator_list
      dim messages as list(of string)

      ' rounds
      evaporating_temp = Round(evaporating_temp, 1)
      capacity = Round(capacity, 0)
      If division = Rae.RaeSolutions.Business.Division.TSI Then _
         capacity = Round(Convert.BtuhToTons(capacity), 2)
      suction_temp = Round(suction_temp, 1)
      condensing_temp = Round(condensing_temp, 1)
      system_amps_460 = Round(system_amps_460, 1)
      system_amps_230 = Round(system_amps_230, 1)

      ' validates temperature ranges and gets error messages
      messages = Me.get_error_messages(condensing_unit.model, evaporating_temp, condensing_temp, suction_temp)
      
      for each message in messages
         me.messages &= message & NewLine
      next

      ' shows data in datagrid and store in database
      If messages.Count = 0 Then

         Dim row As balance_dataset.balance_resultsRow = results_dataset.balance_results.NewRow()
         row.ambient_temp = ambient.ToString
         row.room_temp = room_temp.ToString
         row.evaporating_temp = evaporating_temp.ToString
         row.suction_temp = suction_temp.ToString
         row.condensing_temp = condensing_temp.ToString
         row.Capacity = capacity.ToString
         row.system_power = Round(system_kw, 1).ToString
         row.system_current = system_amps_460.ToString & " / " & system_amps_230.ToString
         row.td = Round(room_temp - evaporating_temp, 1).ToString
         results_dataset.balance_results.Rows.Add(row)

      Else
         Dim message As String = ""
         Dim i As Integer

         ' builds message string
         For i = 0 To messages.Count - 1
            ' adds error message
            message &= messages.Item(i)
            ' adds return after each error, except last
            If i < (messages.Count - 1) Then _
               message &= NewLine
         Next

         Dim row As balance_dataset.balance_resultsRow = results_dataset.balance_results.NewRow()
         row.ambient_temp = ambient.ToString
         row.room_temp = room_temp.ToString
         row.evaporating_temp = evaporating_temp.ToString
         row.suction_temp = suction_temp.ToString
         row.condensing_temp = condensing_temp.ToString
         row.td = "Error"
         row.system_current = "Error"
         row.system_power = "Error"
         row.Capacity = "Error"
         results_dataSet.balance_results.Rows.Add(row)

         'todo: Ui.MessageBox.Show(message)
      End If

      'todo: populate validation
      return new rae.Validation.validator_list()
   End function

   ''' <summary>Checks evaporating temperature range for the unit cooler parameter</summary>
   Private Function CheckEvaporatingTemperatureRange( _
   unitCoolerModel As String, _
   evaporatingTemperature As Single) As String
      Dim message As String

      ' Note: catalog and db only list -10F to +30F suction temperatures
            If unitCoolerModel Like "FH*" _
            And (evaporatingTemperature < -10 Or evaporatingTemperature > 55) Then
                message = "Evaporating temperature outside suitable range for FH series."

                ' Note: db lists capacities for 15F to 50F
            ElseIf unitCoolerModel Like "FV*" _
            And (evaporatingTemperature < 15 Or evaporatingTemperature > 55) Then
                message = "Evaporating temperature outside range for FV series. '57301"

                ' checks some As
            ElseIf (unitCoolerModel Like "A 51*153" _
            Or unitCoolerModel Like "A 52*307" _
            Or unitCoolerModel Like "A 53*461" _
            Or unitCoolerModel Like "A 61*164" _
            Or unitCoolerModel Like "A 62*328" _
            Or unitCoolerModel Like "A 63*492") _
            And (evaporatingTemperature > 30) Then     '57901
                message = "High face velocity could cause water carry over."

                ' checks BOCs with 6 fpi
            ElseIf (unitCoolerModel Like "BOC 62*912" _
            Or unitCoolerModel Like "BOC 62*1067" _
            Or unitCoolerModel Like "BOC 63*1200" _
            Or unitCoolerModel Like "BOC 63*1395" _
            Or unitCoolerModel Like "BOC 64*1600" _
            Or unitCoolerModel Like "BOC 64*1860") _
            And (evaporatingTemperature < -20) Then     '58201
                message = "6 FPI BOC coil is not recommended at temperatures less than -20°F."

                ' checks BOCs with 8 fpi
            ElseIf (unitCoolerModel Like "BOC 82*1006" _
            Or unitCoolerModel Like "BOC 82*1145" _
            Or unitCoolerModel Like "BOC 83*1280" _
            Or unitCoolerModel Like "BOC 83*1550" _
            Or unitCoolerModel Like "BOC 84*1707" _
            Or unitCoolerModel Like "BOC 84*2067") _
            And (evaporatingTemperature < 25) Then     '58901
                message = "8 FPI BOC coil is not recommended at temperatures less than 25°F."

                ' checks if 6 fpi
            ElseIf ((unitCoolerModel Like "A 6*") _
            Or (unitCoolerModel Like "PFE 6*")) _
            And evaporatingTemperature < -20 Then
                message = "6 FPI unit cooler not a good selection below -20°F"
            End If

      Return message
   End Function

   
   private function get_error_messages(
      condensing_unit_model as string, evaporating_temp as double, condensing_temp as double, suction_temp as double
   ) as list(of string)
      Dim i = 0
      Dim messages As New List(Of String)
      Dim message As String

      for each unit_cooler in unit_coolers
         if unit_cooler.model.length > 0 then
            message = Me.CheckEvaporatingTemperatureRange(unit_cooler.model, evaporating_temp)
            If Not String.IsNullOrEmpty(message) Then _
               messages.Add(message)
         end if
      next
      
      ' checks that compressor temperature limits are not exceeded
      Dim compressorMessage As String
      compressorMessage = Me.CheckCompressorTemperatureLimits(condensing_unit_model, suction_temp, condensing_temp)
      If Not String.IsNullOrEmpty(compressorMessage) Then
         messages.Add(compressorMessage & ": cond. temp. " & condensing_temp & "; suction " & suction_temp)
      End If

      Return messages
   End Function

   ''' <summary>
   ''' Checks that compressor suction and condensing temperatures are within the limits.
   ''' Compressor is selected based on the condensing unit model.
   ''' Returns message if a temperature is out of range; else returns null.
   ''' </summary>
   Private Function CheckCompressorTemperatureLimits( _
   condensingUnitModel As String, suctionTemperature As Double, condensingTemperature As Double) As String
      ' todo: condensing_unit.circuits(0).compressor.file_name
            Dim compressorFileName = Rae.RaeSolutions.Business.Intelligence.UnitCooler.GetCompressorFileName(condensingUnitModel)
            Dim message As String = ""


            Dim CR As New compressors.compressor_repository

            Dim limitID As String = CR.getCompressorLimitID(compressorFileName)
            Dim SuccessFlag As Boolean = False

            Dim j As New compressors.CompressorLimits(limitID, False, successFlag)

            If Not j.Valid(suctionTemperature) Then
                message = "Compressor is ourside safety limits of compressor"
            End If


            '     Dim message = Rae.RaeSolutions.Business.Intelligence.CompressorService.CheckCompressorTemperatureLimits(compressorFileName, suctionTemperature, condensingTemperature)

      Return message
   End Function
   
   private function get_condensing_unit(model as string, _spec as spec) as rae.solutions.condensing_units.balance.result
      dim compressor_repo = new compressors.compressor_repository()
      dim balance = new condensing_units.Balance(compressor_repo)
      dim conditions as condensing_units.Balance.Standard_Conditions
      conditions.altitude = _spec.altitude
      conditions.ambient = _spec.ambient
      conditions.suction = _spec.suction_temp
      conditions.voltage = 0
      dim result = balance.this(model, at:=conditions)
      return result
   end function

   private function determine_evaporating_temp_to_begin_with(room_temp as double) as double
      dim evaporating_temp = spec.room_temp - 45

      ' prevents errors caused by evap temp being too low
      dim min_evaporating_temp = -40
      if evaporating_temp < min_evaporating_temp then _
         evaporating_temp = min_evaporating_temp

      return evaporating_temp
   end function

   Private Function select_total_fan_watts(unit_cooler_model As String, altitude as double, hertz as integer) As Integer
      Dim fanWatts As Integer
      Dim table = Rae.RaeSolutions.DataAccess.UnitCoolerDataAccess.RetrieveUnitCooler(unit_cooler_model)
      If unit_cooler_model Like "FH*" Then
         ' Note: Apparently horsepower entry in unit cooler db actually stores watts not hp per Danny
         fanWatts = 16
      Else
         Dim hp = CSng(table.Rows(0)("Motor_HP"))
         Dim fan_file_name = Rae.RaeSolutions.Business.Intelligence.FanIntel.SelectFanFileName(hp, CSng(table.Rows(0)("Fan_RPM")), csng(altitude), hertz)
         fanWatts = Rae.RaeSolutions.Business.Intelligence.FanIntel.SelectWatts(fan_file_name, hp)
      End If
      
      Dim numFans = CInt(table.Rows(0)("Fans"))
      Dim totalFanWatts = fanWatts*numFans

      Return totalFanWatts
   End Function

end class

end namespace