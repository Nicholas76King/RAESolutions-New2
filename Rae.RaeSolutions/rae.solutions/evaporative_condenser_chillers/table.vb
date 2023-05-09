namespace rae.solutions.evaporative_condenser_chillers

class table
   public const table_name as string            = "RECH_Master"
   public const model as string                 = "TSI Model"
   public const rech_model as string            = "Model"
   public const refrigerant as string           = "Refg_1"
   public const num_circuits as string          = "Circuits_Per_Unit"
   public const evaporator_model as string      = "Evap_Part_No"
        Public Const compressor_1 As String = "CompressorMasterID1"
        '  public const compressor_file_name_1 as string= "Comprfile_1"
   public const compressor_quantity_1 as string = "Compr_Qty_1"
        Public Const compressor_2 As String = "CompressorMasterID2"
        '   public const compressor_file_name_2 as string= "Comprfile_2"
   public const compressor_quantity_2 as string = "Compr_Qty_2"
   public const condenser_model_1 as string     = "Coil_1"
   public const condenser_model_2 as string     = "Coil_2"
   public const condenser_quantity_1 as string  = "CoilQty_1"
   public const condenser_quantity_2 as string  = "CoilQty_2"
   public const min_capacity as string          = "Approx_Min_Cap"
   public const max_capacity as string          = "Approx_Max_Cap"
end class

end namespace