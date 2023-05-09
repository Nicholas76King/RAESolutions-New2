imports rae.solutions.drawings

<TestClass>
public class generate_standard_drawings : inherits test_base

   <TestMethod, Ignore>
   sub generate_condenser_unit_drawings
      dim series = "10A0"
      dim models = Rae.DataAccess.EquipmentOptions.EquipmentDataAccess.RetrieveModels(series)
      models.remove("30")
      models.remove("30-SC")
      dim project_manager = new project_manager("Standard Drawing", "Anonymous", "LS3H4H6654")

      for each model in models
         try
            log("generating model: " & series & model)
            dim condenser = new CondenserEquipmentItem(series & model, Rae.RaeSolutions.Business.Division.TSI, "Anonymous", "LS3H4H6654", project_manager)
            condenser.series = series
            condenser.model_without_series = model
            condenser.common_specs.UnitVoltage = New VoltageRating(460, 3, 60)

            dim data = rae.solutions.condensers.condenser_repository.RetrieveCondenser(series & "-" & model)
            condenser.common_specs.OperatingWeight.set_to(data.operating_weight)
            condenser.common_specs.ShippingWeight.set_to(data.shipping_weight)
      
            Dim file_path = "c:\users\caseyj\desktop\standard drawings\" & series & model & ".dxf"
            dim drawing = new UnitDrawing(condenser, user_group.employee)
            ' drawing.save(file_path)
         catch ex as exception
            log(series & model & ": failed " & system.environment.newLine & ex.message)
         end try
      next
   end sub

   <TestMethod, Ignore>
   sub generate_condensing_unit_drawings
      ' place of change
      dim series_list = {"LUI", "LUO"}
      
      dim project_manager = new project_manager("Standard Drawing", "Anonymous", "LS3H4H6654")

      dim models as ienumerable(of string)
      for each series in series_list
         models = Rae.DataAccess.EquipmentOptions.EquipmentDataAccess.RetrieveModels(series).
            where( function(model) ( (model.endsWith("L") or model.endsWith("H")) and model.substring(model.length-2, 1) = "7") or
                                   ( model.endsWith("XL") and model.substring(model.length-3,2) = "7")
                 )
      
         for each model in models
            try
               log("generating model: " & series & model)
               ' place of change
               dim unit = new CondensingUnitEquipmentItem(series & model, Rae.RaeSolutions.Business.Division.CRI, "Anonymous", "LS3H4H6654", project_manager)
               unit.series = series
               unit.model_without_series = model
               for each voltage in {new VoltageRating(460, 3, 60), new VoltageRating(230, 3, 60)}
                  unit.common_specs.UnitVoltage = voltage

                  'place of change
                  dim data = new rae.solutions.condensing_units.Repository().get_unit(series & model)
                  unit.common_specs.OperatingWeight.set_to(data.operating_weight)
                  unit.common_specs.ShippingWeight.set_to(data.shipping_weight)
      
                  Dim file_path = "c:\users\caseyj.rae-corp\desktop\condensing unit standard drawings\" & series & model & "_" & voltage.Voltage.value & ".dxf"
                  dim drawing = new UnitDrawing(unit, user_group.employee)
                  ' drawing.save(file_path)
               next
            catch ex as exception
               log(series & model & ": failed " & system.environment.newLine & ex.message)
            end try
         next
      next
   end sub

end class
