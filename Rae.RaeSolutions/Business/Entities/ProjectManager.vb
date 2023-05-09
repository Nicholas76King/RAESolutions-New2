Imports System
Imports Rae.Collections
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Project manager provides access to items in project.</summary>
Public Class project_manager

#Region " Events"

   ''' <summary>Event raised when equipment is added to project.</summary>
   Public Event EquipmentAdded As EventHandler(Of ProjectItem, ListItemAddedEventArgs)

   Protected Overridable Sub onEquipmentAdded(sender As ProjectItem, e As ListItemAddedEventArgs)
      If Not Me.EquipmentAddedEvent Is Nothing Then _
         RaiseEvent EquipmentAdded(Project, e)
   End Sub

   ''' <summary>
   ''' Handles item add to equipment list. 
   ''' Raises project's <see cref="EquipmentAdded"/> event, so that other objects can subscribe to it.
   ''' </summary>
   Private Sub m_equipmentItems_ItemAdded(sender As EventfulList(Of EquipmentItem), e As ListItemAddedEventArgs) _
   Handles _equipmentItems.ItemAdded
      onEquipmentAdded(Me.Project, e)
   End Sub

#End Region

   Private WithEvents _processItems As ProcessItemList
   Private WithEvents _equipmentItems As EquipmentItemList
   Protected WithEvents _boxLoads As BoxLoadList
   Private _project As ProjectItem


#Region " Properties"

   ReadOnly Property Project() As ProjectItem
      Get
         Return _project
      End Get
   End Property

   ''' <summary>List of equipment items</summary>
   Property Equipment As EquipmentItemList
      Get
         Return Me._equipmentItems
      End Get
      Set(value As EquipmentItemList)
         Me._equipmentItems = value
      End Set
   End Property

   ''' <summary>List of process items</summary>
   Property Processes As ProcessItemList
      Get
         Return _processItems
      End Get
      Set(value As ProcessItemList)
         _processItems = value
      End Set
   End Property

   ''' <summary>List of box loads</summary>
   Property BoxLoads As BoxLoadList
      Get
         Return _boxLoads
      End Get
      Set(value As BoxLoadList)
         _boxLoads = value
      End Set
   End Property

#End Region


#Region " Public methods"

   ''' <summary>Parameterless constructor for serialization purposes only... DO NOT USE</summary>
   <EditorBrowsable(EditorBrowsableState.Never)> _      
   Sub New()
   End Sub

   ''' <summary>Constructs project with temporary name that is not saved.</summary>
   Sub New(author As String, password As String)
      Me.initialize()
      _project = New ProjectItem("Untitled", author, password)
   End Sub

   ''' <summary>Constructs project with specified ID.</summary>
   ''' <param name="projectId">Project ID</param>
   Sub New(projectId As item_id)
      initialize()
      _project = New ProjectItem(projectId, True)
   End Sub

   ''' <summary>Constructs project manager for the specified project.</summary>
   ''' <param name="project">Project to construct project manager for.</param>
   Sub New(project As ProjectItem)
      initialize()
      _project = project
   End Sub

   ''' <summary>
   ''' Constructs new project manager and a project.
   ''' </summary>
   ''' <param name="name">
   ''' Name of project
   ''' </param>
   ''' <param name="author">Author</param>
   ''' <param name="password">Password</param>
   Sub New(name As String, author As String, password As String)
      Me.initialize()
      Me._project = New ProjectItem(name, author, password)
   End Sub

#End Region

   Private Sub initialize()
      _processItems = New ProcessItemList()
      _equipmentItems = New EquipmentItemList()
      _boxLoads = New BoxLoadList()
   End Sub

End Class

End Namespace

' FUTURE: Make project contacts easily accessible
   'Property Contacts() As Integer
   '   Get

   '   End Get
   '   Set(ByVal value As Integer)

   '   End Set
   'End Property

   ' FUTURE: Allow user to attach their own documents
   'Property Attachments() As Integer
   '   Get

   '   End Get
   '   Set(ByVal value As Integer)

   '   End Set
   'End Property

   'FUTURE: provide aggregate of all items
   'Property Items() As List(Of ItemBase)
   '   Get

   '   End Get
   '   Set(ByVal value As List(Of ItemBase))

   '   End Set
   'End Property