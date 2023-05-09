Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.SelectedOptionsDataSet
imports rae.reporting.beta

class chiller_accessories : inherits accessories_base

   sub new(screen as EquipmentForm)
      report = new report(reports.file_paths.chiller_accessories_file_path)
      text = new dictionary(of string, string)

      dim project_bag = new project_grabber(screen).grab
      text.add("project", project_bag.project_name)
      text.add("representative", project_bag.rep_company)
      text.add("release_status", project_bag.release_status)
      text.add("release_number", project_bag.release_number)

      dim equipment_bag = new equipment_grabber(screen).grab
      text.add("job", equipment_bag.job)
      text.add("quantity", equipment_bag.quantity)
      
      dim model as string
      if equipment_bag.custom_model.is_not_set then
         model = equipment_bag.model
      else
         model = equipment_bag.custom_model & " (" & equipment_bag.model.remove(0,1) & ")"
      end if
      text.add("model", model)
      text.add("application_version", my.application.info.version.toString)
      text.add("created", DateTime.Now.ToString("MM/dd/yyyy"))

      dim chiller_bag = new chiller_grabber(screen).grab
      text.add("tag", chiller_bag.tag)
      text.add("ambient", chiller_bag.ambient)
      text.add("entering_temperature", chiller_bag.entering_temperature)
      text.add("leaving_temperature", chiller_bag.leaving_temperature)
      text.add("unit_voltage", chiller_bag.unit_voltage)
      text.add("control_voltage", chiller_bag.control_voltage)
      text.add("rla", chiller_bag.rla)
      text.add("mca", chiller_bag.mca)
      text.add("dimensions", chiller_bag.dimensions)
      text.add("shipping_weight", chiller_bag.shipping_weight)
      text.add("operating_weight", chiller_bag.operating_weight)
      text.add("glycol", chiller_bag.glycol)
      text.add("glycol_percentage", chiller_bag.glycol_percentage)
      text.add("gpm", chiller_bag.gpm)
      text.add("evaporator_pressure_drop", chiller_bag.evaporator_pressure_drop)

      screen.populateSelectedOptionsDataSet(false)

      dim screen_options = screen.selectedOpsDs.SelectedOptions
      dim options = organize_options(screen_options)
      
      report.set_list("options", options)
   end sub

   private function organize_options(screen_options as SelectedOptionsDataTable) as list(of string)
      dim pump_option as SelectedOptionsRow
      for each op in screen_options
         if pump_package_code.matches(op.code)
            pump_option = op
            exit for
         end if
      next

      dim pump_options = new list(of string)
      dim non_pump_options = new list(of string)

      dim options = new list(of string)

      if not pump_option is nothing then
         for each op in screen_options
            if pump_package_codes.has(op.code)
               pump_options.add("    • " & op.description)
            else if not pump_package_code.matches(op.code)
               non_pump_options.add("• " & op.description)
            end if
         next
         options.add(pump_option.description)
         for each pump_op in pump_options
            options.add(pump_op)
         next
         for each non_pump_op in non_pump_options
            options.add(non_pump_op)
         next
      else
         for each op in screen_options
            options.add("• " & op.description)
         next
      end if

      return options
   end function
   
end class