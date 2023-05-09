<TestClass>
public class compressors_without_amp_data_ : inherits test_base

   <TestMethod>
   sub standard_compressors_without_amp_data
      dim compressor_repository = new compressors.compressor_repository()
      dim condensing_unit_repository = new condensing_units.Repository()
      dim pricing_repository = new Rae.DataAccess.EquipmentOptions.EquipmentDataAccess

      dim condensing_units = condensing_unit_repository.get_all()

      dim missing = new list(of condensing_units.condensing_unit)

      dim pricing = new list(of condensing_units.condensing_unit)
      for each condensing_unit in condensing_units
         dim series as string
         if condensing_unit.model.startsWith("20A0") then
            series = condensing_unit.model.substring(0, 6)
         else
            series = condensing_unit.series
         end if
         dim exists = pricing_repository.model_exists(series, condensing_unit.model.replace(series, ""))
         if exists then _
            pricing.add(condensing_unit)
      next

      for each condensing_unit in pricing
         dim exists = compressor_repository.compressor_amps_exist(condensing_unit.circuits(0).compressor_file_name)
         if not exists then _
            missing.add(condensing_unit)
      next

      missing.ForEach( sub(x) log(x.circuits(0).compressor_file_name & ", " & x.model) )
   end sub

end class