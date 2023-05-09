Namespace Rae.RaeSolutions.DataAccess.Projects.Tables

   ''' <summary>
   ''' List of column and table name from database table Options
   ''' </summary>
   Public Class EquipmentOptionsTable
      Public Shared ReadOnly TableName As String = "EquipmentOptions"
      ''' <summary>
      ''' Id that is unique to a selected equipment option in a RAESolutions project.
      ''' Id is for EquipmentOptions table in Projects database.
      ''' </summary>
      Public Shared ReadOnly Id As String = "Id"
      ''' <summary>
      ''' Id that is unique to an option and model number relationship and is used to determine price.
      ''' Id is for EquipmentOptions table in EquipmentOptions database.
      ''' </summary>
      Public Shared ReadOnly PricingId As String = "PricingId"
      ''' <summary>
      ''' Relates option to a specific equipment.
      ''' </summary>
      Public Shared ReadOnly EquipmentId As String = "EquipmentId"
      Public Shared ReadOnly Revision As String = "Revision"
      Public Shared ReadOnly Quantity As String = "Quantity"

   End Class

End Namespace