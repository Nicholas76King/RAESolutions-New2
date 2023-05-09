Imports System
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.Business
Imports System.Xml.Serialization

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>Base class that items should inherit from</summary>
''' <remarks>Its recommended that inheriters implement IEquatable(Of T) and ICloneable(Of T).</remarks>
<Serializable()> _
Public MustInherit Class ItemBase
   Implements IPersistable

#Region " Events"

   ''' <summary>Occurs after item's name is changed</summary>
   Public Event NameChanged As EventHandler(Of ItemBase, EventArgs)

   ''' <summary>Raises <see cref="NameChanged" /> event.</summary>
   Protected Overridable Sub onNameChanged()
      If Me.NameChangedEvent IsNot Nothing Then _
         RaiseEvent NameChanged(Me, EventArgs.Empty)
   End Sub

#End Region

#Region " Properties"

   ''' <summary>Unique identifier. When set the metadata author and date created set.</summary>
   Overridable Property id As item_id
      Get
         Return _id
      End Get
      Set(value As item_id)
         If value Is Nothing Then
            Throw New ArgumentNullException("Item ID cannot be set. The value is null.")
         End If

         _id = value

         metadata.Author = value.Username
         metadata.DateCreated = value.DateGenerated
      End Set
   End Property

   ''' <summary>Item name. Raises NameChanged event when set. Also sets MetaData Name when set.</summary>
   ''' <remarks>Raises NameChanged event when set. Also sets MetaData Name when set.</remarks>
   Overridable Property name As String
      Get
         Return _name
      End Get
      Set(value As String)
         If Not _name = value Then
            _name = value
            metadata.Name = value
            onNameChanged()
         End If
      End Set
   End Property

   ''' <summary>Metadata (data describing data) for item</summary>
   Property metadata() As MetaData
      Get
         Return _metadata
      End Get
      Set(value As MetaData)
         _metadata = value
      End Set
   End Property

   ''' <summary>Project manager of project item is in.</summary>
   <XmlIgnore()> _
   Property ProjectManager() As project_manager
      Get
         Return _projectManager
      End Get
      Set(value As project_manager)
         _projectManager = value
      End Set
   End Property

#End Region

#Region " Unimplemented methods"
   ' methods should be overrided by inheriters

   ''' <summary>Method to load item</summary>
   MustOverride Sub Load() _
   Implements IPersistable.Load

   ''' <summary>Method to save item</summary>
   MustOverride Sub Save() _
   Implements IPersistable.Save

#End Region


   Private _id As item_id
   Private _name As String
   Private _metadata As MetaData
   Private _projectManager As project_manager

   ''' <summary>Inheritors should call this method in their constructor.</summary>
   Protected Overridable Sub initialize()
      _metadata = New MetaData()
   End Sub

End Class
End Namespace