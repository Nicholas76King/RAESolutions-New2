Namespace Rae.RaeSolutions.DataAccess.Projects.Tables

   ''' <summary>
   ''' Fluid cooler equipment item table.
   ''' </summary>
   ''' <history by="Casey" finish="2006/05/09">
   ''' Created
   ''' </history>
   Public Class FluidCoolerTable
      Public Shared ReadOnly TableName As String = "FluidCooler"
      Public Shared ReadOnly EquipmentId As String = "EquipmentId"
      Public Shared ReadOnly Revision As String = "Revision"
      Public Shared ReadOnly Capacity As String = "Capacity"
      Public Shared ReadOnly AmbientTemp As String = "AmbientTemp"
      Public Shared ReadOnly EnteringFluidTemp As String = "EnteringFluidTemp"
      Public Shared ReadOnly LeavingFluidTemp As String = "LeavingFluidTemp"
      Public Shared ReadOnly GlycolPercent As String = "GlycolPercent"
      Public Shared ReadOnly Fluid As String = "Fluid"
      Public Shared ReadOnly Flow As String = "Flow"
   End Class

End Namespace