Imports System.Collections.Generic
Imports System
Imports Rae.Core

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Metadata
   ''' </summary>
   ''' <remarks>
   ''' Can be used as a property in a class to help describe itself and its history
   ''' </remarks>
   ''' <history start="2006/05/04" by="Casey Joyce">
   ''' Created
   ''' </history>
   Public Class MetaData
      Implements IMetaData
      Implements IEquatable(Of MetaData)
      Implements ICloneable(Of MetaData)


#Region " Events"

      ''' <summary>
      ''' Occurs after/before ...
      ''' </summary>
      Public Event Changed As EventHandler(Of MetaData, EventArgs)

      ''' <summary>
      ''' Raises <see cref="Changed" /> event.
      ''' </summary>
      ''' <param name="e">
      ''' Event arguments to pass in event.
      ''' Use System.EventArgs.Empty if no data is being passed.
      ''' </param>
      ''' <remarks>
      ''' Use this method to raise event rather than raising event directly.
      ''' Protected - Prevents other classes from raising event
      ''' Overridable - Allows derived classes to override implementation.
      ''' </remarks>
      Protected Overridable Sub OnChanged(ByVal e As EventArgs)
         If Me.ChangedEvent IsNot Nothing Then
            ' raises event
            RaiseEvent Changed(Me, e)
         End If
      End Sub

#End Region


#Region " Declarations"
      Private m_name As String
      Private m_description As String
      Private m_comments As CommentList
      Private m_author As String
      Private m_dateCreated As Date
      'Private m_modifications As List(Of Modification)
#End Region


#Region " Properties"

      ''' <summary>
      ''' Name of data that metadata is describing
      ''' </summary>
      ''' <history by="Casey Joyce" start="2006/04/06" finish="2006/04/06" hours="0">
      ''' Added
      ''' </history>
      Public Property Name() As String _
      Implements IMetaData.Name
         Get
            Return Me.m_name
         End Get
         Set(ByVal value As String)
            Me.m_name = value
            Me.OnChanged(EventArgs.Empty)
         End Set
      End Property

      ''' <summary>
      ''' Description of data
      ''' </summary>
      Public Property Description() As String _
      Implements IMetaData.Description
         Get
            Return Me.m_description
         End Get
         Set(ByVal value As String)
            Me.m_description = value
            Me.OnChanged(EventArgs.Empty)
         End Set
      End Property

      ''' <summary>
      ''' List of comments concerning data
      ''' </summary>
      Public Property Comments() As CommentList _
      Implements IMetaData.Comments
         Get
            Return Me.m_comments
         End Get
         Set(ByVal value As CommentList)
            Me.m_comments = value
            Me.OnChanged(EventArgs.Empty)
         End Set
      End Property

      ''' <summary>
      ''' Author of data
      ''' </summary>
      Public Property Author() As String _
      Implements IMetaData.Author
         Get
            Return Me.m_author
         End Get
         Set(ByVal value As String)
            Me.m_author = value
            Me.OnChanged(EventArgs.Empty)
         End Set
      End Property

      ''' <summary>
      ''' Date data was created
      ''' </summary>
      Public Property DateCreated() As Date _
      Implements IMetaData.DateCreated
         Get
            Return Me.m_dateCreated
         End Get
         Set(ByVal value As Date)
            Me.m_dateCreated = value
            Me.OnChanged(EventArgs.Empty)
         End Set
      End Property

      '''' <summary>
      '''' (Not implemented) List of modifications to data
      '''' </summary>
      'Public Property Modifications() As List(Of Modification)
      '   Get
      '      ' IDEA: Change notices
      '      ' include in Constructors, Clone(), and Equals()
      '      Throw New System.NotImplementedException()
      '   End Get
      '   Set(ByVal value As List(Of Modification))

      '   End Set
      'End Property

#End Region


#Region " Public methods"

      ''' <summary>
      ''' Constructor
      ''' </summary>
      Public Sub New()
         ' prevents nulls
         Me.m_comments = New CommentList
         'Me.m_modifications = New List(Of Modification)
      End Sub

      ''' <summary>
      ''' Constructor for new metadata
      ''' </summary>
      ''' <param name="name">
      ''' Name of data
      ''' </param>
      ''' <param name="author">
      ''' Author of data
      ''' </param>
      ''' <param name="description">
      ''' Description of data
      ''' </param>
      Public Sub New(ByVal name As String, ByVal author As String, ByVal description As String)
         Me.New()
         Me.m_dateCreated = Date.Now
         Me.m_name = name
         Me.m_author = author
         Me.m_description = description
      End Sub

      ''' <summary>
      ''' Constructor that populates metadata
      ''' </summary>
      ''' <param name="description">Description</param>
      ''' <param name="author">Name of creator</param>
      ''' <param name="dateCreated">Date of creation</param>
      ''' <param name="comments">Comments</param>
      ''' <remarks>
      ''' If comments or modifications parameters are null, they are constructed before setting properties to prevent nulls.
      ''' </remarks>
      Public Sub New(ByVal name As String, ByVal author As String, ByVal description As String, ByVal dateCreated As Date, _
      ByVal comments As CommentList)
         Me.m_name = name
         Me.m_description = description
         Me.m_author = author
         Me.m_dateCreated = dateCreated
         Me.m_comments = comments
         'Me.m_modifications = Modifications

         ' prevents nulls
         'If Modifications Is Nothing Then
         '   Me.m_modifications = New List(Of Modification)
         'End If
         If comments Is Nothing Then
            Me.m_comments = New CommentList
         End If
      End Sub

      ''' <summary>
      ''' Determines whether metadata is equal
      ''' </summary>
      ''' <param name="other">The other metadata to compare equality</param>
      ''' <returns>
      ''' True if meta data is equal, false if metadata is NOT equal
      ''' </returns>
      Public Overloads Function Equals(ByVal other As MetaData) As Boolean _
      Implements System.IEquatable(Of MetaData).Equals
         If Me.m_name = other.m_name _
         AndAlso Me.m_description = other.m_description _
         AndAlso Me.m_author = other.m_author _
         AndAlso item_id.DatesAreEqual(Me.m_dateCreated, other.m_dateCreated) _
         AndAlso Me.m_comments.Equals(other.m_comments) Then
            Return True
         Else
            Return False
         End If
      End Function

      ''' <summary>
      ''' Clones metadata; clone has its own memory reference.
      ''' </summary>
      ''' <returns>
      ''' Clone of this metadata.
      ''' </returns>
      Public Function Clone() As MetaData _
      Implements ICloneable(Of MetaData).Clone
         ' clones this metadata
         Dim myClone As New MetaData(Me.m_name, Me.m_author, Me.m_description, Me.m_dateCreated, Me.m_comments.Clone())

         Return myClone
      End Function

#End Region

   End Class



End Namespace