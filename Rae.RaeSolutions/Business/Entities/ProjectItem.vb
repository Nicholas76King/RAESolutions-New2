Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports Rae.Io.Text
Imports Rae.RaeSolutions.DataAccess.Projects

Namespace Rae.RaeSolutions.Business.Entities

Public Class ProjectItem
   Inherits RevisionBase
   Implements ICloneable(Of ProjectItem)
   Implements ICopyable(Of ProjectItem)
   Implements IEquatable(Of ProjectItem)


#Region " Events"

   ''' <summary>
   ''' Occurs after/before ...
   ''' </summary>
   Public Event Loaded As EventHandler(Of ProjectItem, EventArgs)

   ''' <summary>
   ''' Raises <see cref="Loaded" /> event.
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
   Protected Overridable Sub OnLoaded(ByVal e As EventArgs)
      If Me.LoadedEvent IsNot Nothing Then
         ' raises event
         RaiseEvent Loaded(Me, e)
      End If
   End Sub

   ''' <summary>
   ''' Occurs after/before ...
   ''' </summary>
   Public Event Removed As EventHandler(Of ProjectItem, EventArgs)

   ''' <summary>
   ''' Raises <see cref="Removed" /> event.
   ''' </summary>
   ''' <remarks>
   ''' Use this method to raise event rather than raising event directly.
   ''' Protected - Prevents other classes from raising event
   ''' Overridable - Allows derived classes to override implementation.
   ''' </remarks>
   Protected Overridable Function OnRemoved() As String
      If Me.RemovedEvent IsNot Nothing Then
         ' raises event
         RaiseEvent Removed(Me, EventArgs.Empty)
         Return Me.id.Id
      Else
         Return ""
      End If
   End Function

#End Region


#Region " Fields"

   Private contacts_ As ContactList
   Private releaseNum_ As nullable_value(Of Integer)
   Private notes_ As String
   Private m_StartUpContact As String
   Private m_releaseStatus As ReleaseStatus
   Private m_HoursBeforeDeliveryToCall As nullable_value(Of Double)
   Private m_SalesClass As String
   Private m_PurchaseOrderDate As nullable_value(Of Date)
   Private m_PurchaseOrderNum As nullable_value(Of Integer)
   Private m_RequestedShipDate As nullable_value(Of Date)
   Private m_Tag As String
   Private m_Pricing As ProjectPricing

#End Region


#Region " Properties"

   ''' <summary>List of contacts in project</summary>
   Property Contacts() As ContactList
      Get
         Return contacts_
      End Get
      Set(ByVal value As ContactList)
         contacts_ = value
      End Set
   End Property

   Property Notes() As String
      Get
         Return Me.notes_
      End Get
      Set(ByVal value As String)
         Me.notes_ = value
      End Set
   End Property

   ''' <summary>HR or PR number</summary>
   Property ReleaseNum() As nullable_value(Of Integer)
      Get
         Return Me.releaseNum_
      End Get
      Set(ByVal value As nullable_value(Of Integer))
         Me.releaseNum_ = value
      End Set
   End Property


   ''' <summary>Type of order release (HR or PR)</summary>
   Property ReleaseStatus() As Business.ReleaseStatus
      Get
         Return Me.m_releaseStatus
      End Get
      Set(ByVal value As Business.ReleaseStatus)
         Me.m_releaseStatus = value
      End Set
   End Property

   Property StartUpContact() As String
      Get
         Return Me.m_StartUpContact
      End Get
      Set(ByVal value As String)
         Me.m_StartUpContact = value
      End Set
   End Property

   Property SalesClass() As String
      Get
         Return Me.m_SalesClass
      End Get
      Set(ByVal value As String)
         Me.m_SalesClass = value
      End Set
   End Property

   Property HoursBeforeDeliveryToCall() As nullable_value(Of Double)
      Get
         Return Me.m_HoursBeforeDeliveryToCall
      End Get
      Set(ByVal value As nullable_value(Of Double))
         Me.m_HoursBeforeDeliveryToCall = value
      End Set
   End Property


   Property RequestedShipDate() As nullable_value(Of Date)
      Get
         Return Me.m_RequestedShipDate
      End Get
      Set(ByVal value As nullable_value(Of Date))
         Me.m_RequestedShipDate = value
      End Set
   End Property

   Property PurchaseOrderNum() As nullable_value(Of Integer)
      Get
         Return Me.m_PurchaseOrderNum
      End Get
      Set(ByVal value As nullable_value(Of Integer))
         Me.m_PurchaseOrderNum = value
      End Set
   End Property

   Property PurchaseOrderDate() As nullable_value(Of Date)
      Get
         Return Me.m_PurchaseOrderDate
      End Get
      Set(ByVal value As nullable_value(Of Date))
         Me.m_PurchaseOrderDate = value
      End Set
   End Property

   ' TODO: ProjectItem.Status
   Public Property Status() As Integer
      Get

      End Get
      Set(ByVal value As Integer)

      End Set
   End Property

   Property Pricing() As ProjectPricing
      Get
         Return Me.m_Pricing
      End Get
      Set(ByVal value As ProjectPricing)
         Me.m_Pricing = value
      End Set
   End Property

   Property Tag() As String
      Get
         Return Me.m_Tag
      End Get
      Set(ByVal value As String)
         Me.m_Tag = value
      End Set
   End Property

   Private m_Revision As Integer
   Property Revision() As Integer
      Get
         Return Me.m_Revision
      End Get
      Set(ByVal value As Integer)
         Me.m_Revision = value
      End Set
   End Property

   Private m_OpenedBy As String
   Property OpenedBy() As String
      Get
         Return m_OpenedBy
      End Get
      Set(ByVal value As String)
         m_OpenedBy = value
      End Set
   End Property

   ''' <summary>Project currently checked out by (String - Name)</summary>
   Private m_CheckedOutBy As String
   Property CheckedOutBy() As String
      Get
         Return m_CheckedOutBy
      End Get
      Set(ByVal value As String)
         m_CheckedOutBy = value
      End Set
   End Property

   Private m_RevisionDate As nullable_value(Of Date)
   Property RevisionDate() As nullable_value(Of Date)
      Get
         Return m_RevisionDate
      End Get
      Set(ByVal value As nullable_value(Of Date))
         m_RevisionDate = value
      End Set
   End Property

   Private m_ProjectOwner As String
   Public Property ProjectOwner() As String
      Get
         Return m_ProjectOwner
      End Get
      Set(ByVal value As String)
         m_ProjectOwner = value
      End Set
   End Property


#End Region


#Region " Public methods"

   Private Sub New()
      Me.initialize()
   End Sub

   ''' <summary>Constructs a new project with a new ID.</summary>
   Sub New(name As String, author As String, password As String)
      Me.initialize()

      ' sets project ID and metadata author and date created
      Me.id = New item_id(author, password)
      Me.Tag = Me.id.Id
      ' sets project name
      Me.name = name
   End Sub


   ''' <summary>
   ''' Constructs a project that sets an existing ID. The date is set to the original date.
   ''' </summary>
   ''' <param name="id">Project ID.</param>
   Sub New(id As item_id)
      Me.initialize()
      Me.id = id
   End Sub


   ''' <summary>Constructs a project that loads existing data for the ID</summary>
   ''' <param name="id">ID of project to load.</param>
   ''' <param name="shouldLoad">True to load project data; false to not load data.</param>
   Sub New(id As item_id, shouldLoad As Boolean)
      Me.New(id)
      If shouldLoad Then
         Me.Load()
      End If
   End Sub

   ''' <summary>Loads project with ID.</summary>
   Overrides Sub Load()
      ' loads project
      Me.Copy(ProjectsDataAccess.Retrieve(Me.id.Id))

      ' raises Loaded event
      Me.OnLoaded(EventArgs.Empty)
   End Sub


   ''' <summary>Saves project with ID.</summary>
   Overrides Sub Save()
      If ProjectsDataAccess.Exists(Me.id.Id, Revision) Then
         Me.Revision = Rae.RaeSolutions.DataAccess.Projects.ProjectsDataAccess.RetrieveLatestRevision(Me.id.Id)
         ProjectsDataAccess.Update(Me)
      Else
         ProjectsDataAccess.Create(Me)
      End If
   End Sub


   Protected Overrides Sub initialize()
      MyBase.initialize()

      ' constructs objects
      '
      contacts_ = New ContactList()
      Me.m_RevisionDate = New nullable_value(Of Date)
      Me.m_HoursBeforeDeliveryToCall = New nullable_value(Of Double)
      Me.m_PurchaseOrderDate = New nullable_value(Of Date)
      Me.m_PurchaseOrderNum = New nullable_value(Of Integer)
      Me.releaseNum_ = New nullable_value(Of Integer)
      Me.m_RequestedShipDate = New nullable_value(Of Date)

      ' sets defaults
      '
      ' sets release status to 'Project' by default
      Me.ReleaseStatus = Business.ReleaseStatus.Project
   End Sub


   ''' <summary>
   ''' Removes project item and all associated equipment and processes.
   ''' </summary>
   Sub Remove()
      ProjectsDataAccess.Delete(Me.id.Id)
      Me.OnRemoved()
   End Sub


   Sub Copy(objectToCopy As ProjectItem) _
   Implements ICopyable(Of ProjectItem).Copy
      With objectToCopy
         Me.id = objectToCopy.id
         Me.metadata = .metadata.Clone()
         Me.name = .name
         contacts_ = .Contacts.Clone()
         Me.HoursBeforeDeliveryToCall = .HoursBeforeDeliveryToCall.clone()
         Me.Notes = .Notes
         Me.PurchaseOrderNum = .PurchaseOrderNum.clone()
         Me.PurchaseOrderDate = .PurchaseOrderDate.clone()
         GetEnumValue(Of Business.ReleaseStatus)(.ReleaseStatus.ToString, Me.ReleaseStatus)
         Me.ReleaseNum = .ReleaseNum.clone()
         Me.RequestedShipDate = .RequestedShipDate.clone()
         Me.SalesClass = .SalesClass
         Me.Tag = .Tag
         Me.ProjectOwner = .ProjectOwner
      End With
   End Sub


   Overloads Function Equals(ByVal other As ProjectItem) As Boolean _
   Implements IEquatable(Of ProjectItem).Equals
      If other Is Nothing Then Return False

      If Me.HoursBeforeDeliveryToCall.equals(other.HoursBeforeDeliveryToCall) _
      AndAlso Me.id.Equals(other.id) _
      AndAlso Me.metadata.Equals(other.metadata) _
      AndAlso Me.name = other.name _
      AndAlso Me.Notes = other.Notes _
      AndAlso Me.PurchaseOrderDate.equals(other.PurchaseOrderDate) _
      AndAlso Me.PurchaseOrderNum.equals(other.PurchaseOrderNum) _
      AndAlso Me.ReleaseNum.equals(other.ReleaseNum) _
      AndAlso Me.ReleaseStatus = other.ReleaseStatus _
      AndAlso Me.RequestedShipDate.equals(other.RequestedShipDate) _
      AndAlso Me.SalesClass = other.SalesClass _
      AndAlso Me.StartUpContact = other.StartUpContact _
      AndAlso Me.Tag = other.Tag _
      AndAlso contacts_.Equals(other.Contacts) Then
         Return True
      Else
         Return False
      End If
   End Function


   Function Clone() As ProjectItem _
   Implements ICloneable(Of ProjectItem).Clone
      Dim projectClone As New ProjectItem(Me.id)

      With projectClone
         .name = Me.name
         .Notes = Me.Notes
         .ReleaseStatus = Me.ReleaseStatus
         .ReleaseNum = Me.ReleaseNum.clone()

         .Contacts = contacts_.Clone()

         .HoursBeforeDeliveryToCall = Me.HoursBeforeDeliveryToCall.clone()
         .ProjectManager = Me.ProjectManager
         .PurchaseOrderDate = Me.PurchaseOrderDate.clone()
         .PurchaseOrderNum = Me.PurchaseOrderNum.clone()
         .SalesClass = Me.SalesClass
         .Tag = Me.Tag
      End With

      Return projectClone
   End Function

#End Region

End Class
End Namespace
