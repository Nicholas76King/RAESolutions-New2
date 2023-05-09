Namespace Rae.RaeSolutions.DataAccess.Projects.Tables

''' <summary>Chiller equipment item table.</summary>
Public Class ChillerTable
   Public Shared ReadOnly TableName As String = "Chiller"
   Public Shared ReadOnly EquipmentId As String = "EquipmentId"
   Public Shared ReadOnly Revision As String = "Revision"
   Public Shared ReadOnly Capacity As String = "Capacity"
   Public Shared ReadOnly AmbientTemp As String = "AmbientTemp"
   Public Shared ReadOnly EnteringFluidTemp As String = "EnteringFluidTemp"
   Public Shared ReadOnly LeavingFluidTemp As String = "LeavingFluidTemp"
   Public Shared ReadOnly GlycolPercent As String = "GlycolPercent"
   Public Shared ReadOnly Fluid As String = "Fluid"
   Public Shared ReadOnly Flow As String = "Flow"
   Public Shared ReadOnly Refrigerant As String = "Refrigerant"
   Public Shared ReadOnly EvaporatorPressureDrop As String = "EvaporatorPressureDrop"
   Public Shared ReadOnly UnitKwPerTon As String = "UnitKwPerTon"
   public shared readonly compressor_amps_1 as string = "CompressorAmps1"
   public shared readonly compressor_amps_2 as string = "CompressorAmps2"
   public shared readonly compressor_quantity_1 as string = "CompressorQuantity1"
   public shared readonly compressor_quantity_2 as string = "CompressorQuantity2"
   public shared readonly spray_pump_amps as string = "SprayPumpAmps"
   public shared readonly blower_amps as string = "BlowerAmps"
   public shared readonly condenser_quantity as string = "CondenserQuantity"
   public shared readonly has_balance as string = "HasBalance"
End Class

End Namespace