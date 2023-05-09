<TestClass>
public class unit_coolers_in_engineering_database_but_not_in_pricing : inherits test_base

   <TestMethod, Ignore>
   sub xbocs_in_engineering_but_not_in_pricing
      dim engineering_database = new unit_coolers.repository()
      dim pricing_database = new Rae.DataAccess.EquipmentOptions.EquipmentDataAccess()
      dim formatter = new unit_coolers.database_formatter()

      dim engineering_models = (from unit in engineering_database.get_by_series("XBOC")
                               select unit.model).toList
      for i=0 to engineering_models.count-1
         'set refrigerant indicator to 0
         engineering_models(i) = engineering_models(i).remove(7,1).insert(7,"0")
      next
      dim unique_engineering_models = new rae.collections.UniqueList(Of String)()
      unique_engineering_models.addRange(engineering_models)

      dim pricing_models = pricing_database.RetrieveModels("XBOC")
      for i=0 to pricing_models.count-1
         ' prepends series
         pricing_models(i) = "XBOC " & pricing_models(i)
         ' remove defrost indicator (last character)
         pricing_models(i) = pricing_models(i).substring(0, pricing_models(i).length-1)
      next
      dim unique_pricing_models = new rae.collections.UniqueList(Of String)
      unique_pricing_models.addRange(pricing_models)

      dim models_in_engineering_but_not_in_pricing = new list(of string)
      for each engineering_model in unique_engineering_models
         if not pricing_models.contains(engineering_model) then
            models_in_engineering_but_not_in_pricing.add(engineering_model)
         end if
      next
      models_in_engineering_but_not_in_pricing.sort()
      models_in_engineering_but_not_in_pricing.forEach( sub(x) log(x) )
   end sub

   <TestMethod, Ignore>
   sub mark_xbocs_that_are_not_in_pricing_database
      dim pricing_models = Rae.DataAccess.EquipmentOptions.EquipmentDataAccess.RetrieveModels("XBOC")
      dim pricing_models_without_defrost = new list(of string)
      for each model in pricing_models
         'add series
         dim m = "XBOC " & model
         'remove defrost indicator
         m = m.substring(0, m.length-1)
         pricing_models_without_defrost.add(m)
      next
      
      dim engineering_repository = new unit_coolers.repository()
      dim engineering_xbocs = engineering_repository.get_by_series("XBOC")

      for each xboc in engineering_xbocs 
         dim model_formatted_for_pricing = xboc.model.remove(7,1).insert(7,"0") 'set refrigerant indicator to 0
         if not pricing_models_without_defrost.contains(model_formatted_for_pricing) then
            engineering_repository.mark_as_not_in_pricing(xboc.model)
         end if
      next
   end sub

end class