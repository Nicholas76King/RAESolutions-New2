Namespace Rae.Data.Access

Public Interface IDataAccess(Of DtoT)

   Function Insert(dto As DtoT) As Integer

   Sub Update(dto As DtoT)

   ''' <summary>
   ''' Retrieves item's latest revision
   ''' </summary>
   Function Retrieve(itemId As String) As DtoT
   
   ''' <summary>
   ''' Retrieves item at specified revision
   ''' </summary>
   Function Retrieve(itemId As String, itemRevision As Integer) As DtoT

   Function Exists(itemId As String, itemRevision As Integer) As Boolean

   Sub Delete(itemId As String)

   Function Save(ByVal dto As DtoT) As Integer

End Interface

End Namespace
