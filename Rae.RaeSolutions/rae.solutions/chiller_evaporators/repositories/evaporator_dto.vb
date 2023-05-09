namespace rae.solutions.chiller_evaporators

public structure evaporator_dto
   public dll_model, old_dll_model, rae_part_number, evaporator_part_number, catalog_model as string
   public nominal_tons, length, width, height as double
   public connection_size as string
   public number_of_circuits as integer
   public rating_type as string
   public rae_index as integer
end structure

end namespace