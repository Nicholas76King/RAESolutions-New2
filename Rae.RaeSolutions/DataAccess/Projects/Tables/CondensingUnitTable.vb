Namespace Rae.RaeSolutions.DataAccess.Projects.Tables

''' <summary>Table and column names of condensing units database table</summary>
Public Class CondensingUnitTable
   Public Shared ReadOnly TableName As String = "CondensingUnit"
   Public Shared ReadOnly EquipmentId As String = "EquipmentId"
   Public Shared ReadOnly Revision As String = "Revision"
   Public Shared ReadOnly ProjectRevision As String = "ProjectRevision"

   Public Shared ReadOnly AmbientTemp As String = "AmbientTemp"
   Public Shared ReadOnly SuctionTemp As String = "SuctionTemp"   ' Saturated Suction Temperature
   Public Shared ReadOnly EvapTemp As String = "EvapTemp"
   Public Shared ReadOnly Refrigerant As String = "Refrigerant"
   Public Shared ReadOnly Circuit1Capacity As String = "Circuit1Capacity"
   Public Shared ReadOnly Circuit2Capacity As String = "Circuit2Capacity"
   Public Shared ReadOnly Circuit3Capacity As String = "Circuit3Capacity"
   Public Shared ReadOnly Circuit4Capacity As String = "Circuit4Capacity"
End Class

End Namespace