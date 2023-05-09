Imports System
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities

  ''' <summary>
  ''' Comment that has reference to its parent comment and to any replies
  ''' </summary>
  Public Class Comment
    Implements ICloneable(Of Comment)
    Implements IEquatable(Of Comment)


#Region " Declarations"
    Private m_id As Integer
    Private m_dateCreated As Date
    Private m_text As String
    Private m_author As String
    Private m_subject As String
    Private m_parent As Comment
    Private m_importance As Importance
    Private m_access As Access
    Private m_replies As CommentList
#End Region

#Region " Properties"

    ''' <summary>
    ''' Unique identifier
    ''' </summary>
    ''' <remarks>
    ''' Could have id assigned by database, if persisted.
    ''' </remarks>
    Public Property Id() As Integer
      Get
        Return Me.m_id
      End Get
      Set(ByVal value As Integer)
        Me.m_id = value
      End Set
    End Property

    ''' <summary>
    ''' Date comment was created
    ''' </summary>
    Public Property DateCreated() As Date
      Get
        Return Me.m_dateCreated
      End Get
      Set(ByVal value As Date)
        Me.m_dateCreated = value
      End Set
    End Property

    ''' <summary>
    ''' Text of comment
    ''' </summary>
    Public Property Text() As String
      Get
        Return Me.m_text
      End Get
      Set(ByVal value As String)
        Me.m_text = value
      End Set
    End Property

    ''' <summary>
    ''' Author of comment
    ''' </summary>
    Public Property Author() As String
      Get
        Return Me.m_author
      End Get
      Set(ByVal value As String)
        Me.m_author = value
      End Set
    End Property

    ''' <summary>
    ''' Subject or heading of comment
    ''' </summary>
    Public Property Subject() As String
      Get
        Return Me.m_subject
      End Get
      Set(ByVal value As String)
        Me.m_subject = value
      End Set
    End Property

    ''' <summary>
    ''' List of comments containing this comment
    ''' </summary>
    Public Property Parent() As Comment
      Get
        Return Me.m_parent
      End Get
      Set(ByVal value As Comment)
        Me.m_parent = value
      End Set
    End Property

    ''' <summary>
    ''' <see cref="Importance" /> level of comment, default is Regular
    ''' </summary>
    Public Property Importance() As Importance
      Get
        Return Me.m_importance
      End Get
      Set(ByVal value As Importance)
        Me.m_importance = value
      End Set
    End Property

    ''' <summary>
    ''' Access level of comment. Default is Public.
    ''' </summary>
    ''' <remarks>
    ''' Private can be used to hide comments from other users.
    ''' Public can be used to allow all users to view comment.
    ''' </remarks>
    Public Property Access() As Access
      Get
        Return Me.m_access
      End Get
      Set(ByVal value As Access)
        Me.m_access = value
      End Set
    End Property

    ''' <summary>
    ''' Other comments that are replies to this comment
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Public Property Replies() As CommentList
      Get
        Return Me.m_replies
      End Get
      Set(ByVal value As CommentList)
        Me.m_replies = value
      End Set
    End Property

#End Region

#Region " Public methods"

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
      Me.m_dateCreated = Date.Now()

      Me.m_access = Access.Public
      Me.m_importance = Importance.Regular
      ' caused stack overflow, circular reference
      'Me.m_parent = New Comment
      Me.m_replies = New CommentList
    End Sub

    ''' <summary>
    ''' Constructor that sets author and text
    ''' </summary>
    ''' <param name="author">Author of comment</param>
    ''' <param name="text">Text of comment</param>
    Public Sub New(ByVal author As String, ByVal text As String)
      Me.New()
      Me.m_author = author
      Me.m_text = text
    End Sub

    ''' <summary>
    ''' Constructor that sets author, subject and text
    ''' </summary>
    ''' <param name="author">Author of comment</param>
    ''' <param name="subject">Subject of comment</param>
    ''' <param name="text">Text of comment</param>
    Public Sub New(ByVal author As String, ByVal subject As String, ByVal text As String)
      Me.New(author, text)
      Me.m_subject = subject
    End Sub


    ''' <summary>
    ''' Clones comment; the returned clone has its own memory reference
    ''' </summary>
    ''' <returns>Clone of this comment</returns>
    Public Function Clone() As Comment _
    Implements ICloneable(Of Comment).Clone
      Dim myClone As New Comment(Me.m_author, Me.m_subject, Me.m_text)

      myClone.DateCreated = Me.m_dateCreated
      myClone.Access = Me.m_access
      myClone.Importance = Me.m_importance
      myClone.Id = Me.m_id
      If Me.m_parent IsNot Nothing Then
        myClone.Parent = Me.m_parent.Clone()
      Else
        myClone.Parent = Nothing
      End If
      myClone.Replies = Me.m_replies.Clone()

      Return myClone
    End Function

    ''' <summary>
    ''' Determines whether the comments properties are equal
    ''' </summary>
    ''' <param name="other">The other comment to compare</param>
    ''' <returns>True if comments are equal; false if they are NOT equal</returns>
    Public Overloads Function Equals(ByVal other As Comment) As Boolean _
    Implements IEquatable(Of Comment).Equals
      If Me.m_id = other.m_id _
      AndAlso Me.m_subject = other.m_subject AndAlso Me.m_text = other.m_text _
      AndAlso Me.m_author = other.m_author AndAlso Me.m_dateCreated = other.m_dateCreated _
      AndAlso Me.m_replies.Equals(Me.m_replies) _
      AndAlso Me.m_access = other.m_access AndAlso Me.m_importance = other.m_importance Then
        ' checks parent may be null
        If (Me.m_parent Is Nothing AndAlso other.m_parent Is Nothing) _
        OrElse Me.m_parent.Equals(other.m_parent) Then
          Return True
        Else
          Return False
        End If
      Else
        Return False
      End If

    End Function

    ''' <summary>
    ''' Text of comment
    ''' </summary>
    ''' <returns>
    ''' Text of comment
    ''' </returns>
    Public Overrides Function ToString() As String
      Return Me.m_text
    End Function

#End Region

  End Class

End Namespace