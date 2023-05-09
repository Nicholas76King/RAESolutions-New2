Namespace Updating.ContactDataStructure

   ''' <summary>
   ''' Describes contact structure
   ''' </summary>
   Public Enum ContactDataStructureDescription

      ''' <summary>
      ''' Contact info only contains company and contact name (not addresses, phone numbers, etc.).
      ''' </summary>
      ''' <remarks>
      ''' This was the contact info for architect, engineer and contractor originally
      ''' </remarks>
      NamesOnly


      ''' <summary>
      ''' Contact info contains a single address and contact number per contact (can't have multiple addresses)
      ''' </summary>
      ''' <remarks>
      ''' This is the second contact data structure.
      ''' </remarks>
      SingleMapping

   End Enum

End Namespace