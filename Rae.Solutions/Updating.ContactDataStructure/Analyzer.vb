Imports Rae.RaeSolutions.Business.Entities
Imports ProjectsDataAccess = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess

Namespace Updating.ContactDataStructure

   ''' <summary>
   ''' Analyzes the current contact data structure.
   ''' Useful in determining whether the data structure should be updated to a newer existing structure.
   ''' </summary>
   ''' <remarks>
   ''' <para>
   ''' If the project only contains a representative contact, it is automatically converted and 
   ''' the project is marked as updated (SingleMapping).
   ''' </para>
   ''' Example:
   ''' <code>
   ''' Dim analyzer As New Analyzer(projectId)
   ''' If analyzer.ContactStructure = ... Then ...
   ''' </code>
   ''' </remarks>
   Public Class Analyzer

      Protected contactStructure_ As ContactDataStructureDescription
      ''' <summary>
      ''' Indicates what type of contact structure is being used
      ''' </summary>
      Public ReadOnly Property ContactDataStructure() As ContactDataStructureDescription
         Get
            Return contactStructure_
         End Get
      End Property


      Protected projectId_ As item_id
      ''' <summary>
      ''' ID of the project whose contact data structure is being analyzed.
      ''' </summary>
      Public ReadOnly Property ProjectId() As item_id
         Get
            Return projectId_
         End Get
      End Property


      ''' <summary>
      ''' Initializes a new instance of the contact data structure analyzer.
      ''' </summary>
      ''' <param name="projectId">
      ''' ID of the project whose contact data structure is being analyzed.
      ''' </param>
      Sub New(ByVal projectId As item_id)
         projectId_ = projectId
         contactStructure_ = getStructure(projectId)

         markAsConvertedIfNoContactsNeedToBeConverted(projectId)
      End Sub


#Region " Private"

      Private Function getStructure(ByVal projectId As item_id) As ContactDataStructureDescription
         Dim textDescription As String = ProjectsDataAccess.RetrieveContactDataStructure(projectId.Id)
         textDescription = handleNullDescriptions(textDescription)
         Dim contactStructure As ContactDataStructureDescription = convertDescriptionToEnum(textDescription)

         Return contactStructure
      End Function


      Private Function handleNullDescriptions(ByVal description As String) As String
         If String.IsNullOrEmpty(description) Then
            description = ContactDataStructureDescription.NamesOnly.ToString()
         End If

         Return description
      End Function


      Private Function convertDescriptionToEnum(ByVal textDescription As String) As ContactDataStructureDescription
         Dim description As ContactDataStructureDescription
         Rae.Io.Text.GetEnumValue(Of ContactDataStructureDescription)(textDescription, description)
         Return description
      End Function


      Private Sub markAsConvertedIfNoContactsNeedToBeConverted(ByVal projectId As item_id)
         If contactStructure_ = ContactDataStructureDescription.NamesOnly Then
            convertRep(projectId.Id)

            Dim deficientContacts As ContactList = ProjectsDataAccess.RetrieveDeficientContacts(projectId.Id)
            If deficientContacts.Count = 0 Then
               ProjectsDataAccess.UpdateContactDataStructure(ContactDataStructure.SingleMapping.ToString(), projectId.Id)
               contactStructure_ = ContactDataStructureDescription.SingleMapping
            End If
         End If
      End Sub


      Private Sub convertRep(ByVal projectId As String)
         Dim repId As nullable_value(Of Integer) = ProjectsDataAccess.RetrieveRepId(projectId)
         If repId.has_value Then
            DataAccess.Projects.ProjectContactsDataAccess.Create(projectId, repId.value)
         End If
      End Sub

#End Region

   End Class

End Namespace