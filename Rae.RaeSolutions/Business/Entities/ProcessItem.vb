Imports System
Imports System.Collections.Generic
Imports Rae.Core
Imports ProcessItemDa = Rae.RaeSolutions.DataAccess.Projects.ProcessItemDA

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>
''' Persists process data for ratings, selections and balances.
''' This is the class that specific processes should inherit from.
''' </summary>
Public MustInherit Class ProcessItem
   Inherits RevisionBase

   Protected m_Model As String
   Protected m_Division As Business.Division

#Region " Events"

   Public Event Saved As EventHandler(Of ProcessItem, EventArgs)

   Protected Overridable Sub OnSaved()
      If Me.SavedEvent IsNot Nothing Then
         ' raises event
         RaiseEvent Saved(Me, EventArgs.Empty)
      End If
   End Sub


   Public Event SavedAs As EventHandler(Of ProcessItem, EventArgs)

   Protected Overridable Sub OnSavedAs()
      If Me.SavedAsEvent IsNot Nothing Then
         ' raises event
         RaiseEvent SavedAs(Me, EventArgs.Empty)
      End If
   End Sub


   Public Event Removed As EventHandler(Of ProcessItem, EventArgs)

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


#Region " Properties"

   Private m_ProcessRevisionDescription As String
   Property ProcessRevisionDescription As String
      Get
         Return m_ProcessRevisionDescription
      End Get
      Set(value As String)
         m_ProcessRevisionDescription = value
      End Set
   End Property

   Private m_ProjectRevision As Integer
   Property ProjectRevision As Integer
      Get
         Return m_ProjectRevision
      End Get
      Set(value As Integer)
         m_ProjectRevision = value
      End Set
   End Property

   Property Division As Business.Division
      Get
         Return m_Division
      End Get
      Set(value As Business.Division)
         m_Division = value
      End Set
   End Property

   Property Model As String
      Get
         Return Me.m_Model
      End Get
      Set(value As String)
         Me.m_Model = value
      End Set
   End Property

   Protected m_Series As String
   Property Series As String
      Get
         Return Me.m_Series
      End Get
      Set(value As String)
         Me.m_Series = value
      End Set
   End Property

   Private m_Version As String
   Property Version As String
      Get
         Return Me.m_Version
      End Get
      Set(value As String)
         Me.m_Version = value
      End Set
   End Property

   Private m_Notes As String
   Property Notes As String
      Get
         Return Me.m_Notes
      End Get
      Set(value As String)
         Me.m_Notes = value
      End Set
   End Property

   Private m_Revision As Single
   Property Revision As Single
      Get
         Return Me.m_Revision
      End Get
      Set(value As Single)
         Me.m_Revision = value
      End Set
   End Property

   Private m_CreatedBy As String
   Property CreatedBy As String
      Get
         Return Me.m_CreatedBy
      End Get
      Set(value As String)
         Me.m_CreatedBy = value
      End Set
   End Property

   Private m_RevisionDate As Date
   Property RevisionDate As Date
      Get
         Return Me.m_RevisionDate
      End Get
      Set(value As Date)
         Me.m_RevisionDate = value
      End Set
   End Property

   Private m_AssociatedEquipmentIDs As List(Of item_id)
   Property AssociatedEquipmentIDs As List(Of item_id)
      Get
         Return Me.m_AssociatedEquipmentIDs
      End Get
      Set(value As List(Of item_id))
         Me.m_AssociatedEquipmentIDs = value
      End Set
   End Property

   Private ObjectLinkXML_ As String
   ''' <summary>Holds XML string of associated object(s)</summary>
   Property ObjectLinkXML As String
      Get
         Return ObjectLinkXML_
      End Get
      Set(value As String)
         ObjectLinkXML_ = value
      End Set
   End Property

   Private ObjectLinkType_ As String
   ''' <summary>Holds types of associated object(s)</summary>
   Property ObjectLinkType As String
      Get
         Return ObjectLinkType_
      End Get
      Set(value As String)
         ObjectLinkType_ = value
      End Set
   End Property

#End Region


   ''' <summary>Inheritors should override Load().</summary>
   Overrides Sub Load()
   End Sub

   ''' <summary>Updates if revision already exists or creates if revision does not exist.</summary>
   Overrides Sub Save()
      ProcessItemDa.Save(Me)
      Me.OnSaved()
   End Sub

   ''' <summary>Saves process item as new process item.</summary>
   Sub SaveAs(Optional ByVal NewProjectManager As project_manager = Nothing)
      ProcessItemDa.SaveAs(Me, NewProjectManager)
      Me.OnSavedAs()
   End Sub

   ''' <summary>Removes process item from persistence storage.</summary>
   Sub Remove()
      ProcessItemDa.DeleteProcess(Me.id.Id)
      Me.OnRemoved()
   End Sub

   ''' <summary>Copies another process item's values into this process item.</summary>
   Sub Copy(ByVal other As ProcessItem)
      CopyObj.CopyObj(Me.GetType, other, Me)
   End Sub

   ''' <summary>Creates and returns a clone of this process item.</summary>
   Overridable Function Clone(Optional ByVal NewID As Boolean = False) As Object
      Return CopyObj.CloneObj(Me.GetType, Me)
   End Function

   ''' <summary>Checks if two process are equal.</summary>
   Overloads Function Equals(ByVal other As ProcessItem) As Boolean
      Return CopyObj.CompareObj(Me.GetType, Me, other)
   End Function

   ''' <summary>Initializes the objects of this class and parent classes to prevent null exceptions.</summary>
   Protected Overrides Sub initialize()
      MyBase.initialize()
      Me.m_AssociatedEquipmentIDs = New List(Of item_id)
   End Sub

End Class
End Namespace





