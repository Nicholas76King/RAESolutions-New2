Imports System.Collections.Generic
Imports Rae.RaeSolutions.Business.Entities

Namespace Rae.RaeSolutions.Business

   ''' <summary>
   ''' Interface for metadata allowing implementer to describe itself and track its history.
   ''' </summary>
   Public Interface IMetaData

      ''' <summary>
      ''' Name data implementer is describing
      ''' </summary>
      ''' <history by="Casey Joyce" start="2006/04/06" finish="2006/04/06" hours="0">
      ''' Added
      ''' </history>
      Property Name() As String

      ''' <summary>
      ''' Description of implementer
      ''' </summary>
      Property Description() As String

      ''' <summary>
      ''' Comments concerning the implementer
      ''' </summary>
      Property Comments() As CommentList

      ''' <summary>
      ''' Who or what created implementer (ex. username or application name)
      ''' </summary>
      Property Author() As String

      ''' <summary>
      ''' Date implementer was created
      ''' </summary>
      Property DateCreated() As Date

      ' TODO: Add Modifications to IMetaData
      ' <summary>
      ' Modifications made to implementer
      ' </summary>
      'Property Modifications() As List(Of Modification)

   End Interface

End Namespace