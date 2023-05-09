Namespace Rae.RaeSolutions.DataAccess.Projects.Tables

   ''' <summary>
   ''' Table and column names in projects database table
   ''' </summary>
   ''' <history by="Casey Joyce" finish="2006/05/05">
   ''' Created
   ''' </history>
   Public Class ProjectsTable
      Public Shared ReadOnly TableName As String = "Projects"
      Public Shared ReadOnly ProjectId As String = "ProjectId"
      Public Shared ReadOnly ProjectRevision As String = "ProjectRevision"
      Public Shared ReadOnly Name As String = "Name"
      Public Shared ReadOnly Notes As String = "Notes"
      Public Shared ReadOnly Tag As String = "Tag"
      Public Shared ReadOnly ReleaseStatus As String = "ReleaseStatus"
      Public Shared ReadOnly ReleaseNum As String = "ReleaseNum"
      Public Shared ReadOnly HoursBeforeDeliveryToCall As String = "HoursBeforeDeliveryToCall"
      ''' <summary>
      ''' Purchase order number
      ''' </summary>
      Public Shared ReadOnly PoNum As String = "PoNum"
      ''' <summary>
      ''' Purchase order date
      ''' </summary>
      Public Shared ReadOnly PoDate As String = "PoDate"
      Public Shared ReadOnly RequestedShipDate As String = "RequestedShipDate"
      Public Shared ReadOnly SalesClass As String = "SalesClass"
      ''' <summary>
      ''' Indicates the kind of information stored for a contact; indicates if contact structure needs to be updated.
      ''' </summary>
      Public Shared ReadOnly ContactDataStructure As String = "ContactDataStructure"




      Public Shared ReadOnly RepId As String = "RepId"
      Public Shared ReadOnly ArchitectName As String = "ArchitectName"
      Public Shared ReadOnly ContractorName As String = "ContractorName"
      Public Shared ReadOnly EngineerName As String = "EngineerName"
      Public Shared ReadOnly RepCompanyId As String = "RepCompanyId"
      Public Shared ReadOnly ArchitectCompanyName As String = "ArchitectCompanyName"
      Public Shared ReadOnly ContractorCompanyName As String = "ContractorCompanyName"
      Public Shared ReadOnly EngineerCompanyName As String = "EngineerCompanyName"

      Public Shared ReadOnly ProjectOwner As String = "ProjectOwner"
      Public Shared ReadOnly OpenedBy As String = "OpenedBy"
      Public Shared ReadOnly CheckedOutBy As String = "CheckedOutBy"
      Public Shared ReadOnly RevisionDate As String = "RevisionDate"

   End Class

End Namespace
