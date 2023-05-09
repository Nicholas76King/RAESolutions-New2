Imports System
Imports Rae.Collections

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' List of items.
   ''' </summary>
   ''' <history by="Casey Joyce" start="2006/07/14">
   ''' Created
   ''' </history>
   <Serializable()> _
   Public Class ItemList(Of T As ItemBase)
      Inherits EventfulList(Of T)


#Region " Events"


      ''' <summary>
      ''' Occurs after an item's name is changed.
      ''' </summary>
      Public Event ItemNameChanged As EventHandler(Of T, EventArgs)

      ''' <summary>
      ''' Raises <see cref="ItemNameChanged" /> event.
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
      Protected Overridable Sub OnItemNameChanged(item As T, e As EventArgs)
         If Me.ItemNameChangedEvent IsNot Nothing Then
            ' raises event
            RaiseEvent ItemNameChanged(item, e)
         End If
      End Sub


#End Region


#Region " Public properties"

      ''' <summary>
      ''' Constructs equipment item list.
      ''' </summary>
      Sub New()
         MyBase.New()
      End Sub


      ''' <summary>
      ''' Provides access to equipment items by ID. Returns null if ID doesn't exist.
      ''' </summary>
      ''' <param name="id">
      ''' ID of equipment to get.
      ''' </param>
      ''' <returns>
      ''' Equipment item with ID or null if there is no item with the ID.
      ''' </returns>
      Overloads Function Items(id As item_id) As T
         If id Is Nothing Then
            Throw New ArgumentNullException("Item list's Items does not allow null for ID parameter.")
         End If

         ' searches item for item w/ the specified ID
         For Each item As T In Me
            If item.id.ToString = id.ToString Then
               Return item
            End If
         Next

         ' returns null when there is not an item with the id
         Return Nothing
         'Throw New ArgumentException("Equipment item list's items does not contain an item with the ID, " & id.SafeId)
      End Function


      ''' <summary>
      ''' Provides access to items by ID. Returns null if ID doesn't exist.
      ''' </summary>
      ''' <param name="id">
      ''' ID of equipment to get.
      ''' </param>
      ''' <returns>
      ''' Equipment item with ID or null if there is no item with the ID.
      ''' </returns>
      Overloads Function Items(id As String) As T
         Return Me.Items(New item_id(id))
      End Function


      ''' <summary>
      ''' Adds equipment item to list.
      ''' </summary>
      ''' <param name="item">
      ''' Item to add to list.
      ''' </param>
      Shadows Sub Add(item As T)
         MyBase.Add(item)
         AddHandler item.NameChanged, AddressOf ItemName_Changed
      End Sub

#End Region

      ''' <summary>
      ''' Propogates name changed event.
      ''' </summary>
      Private Sub ItemName_Changed(sender As ItemBase, e As EventArgs)
         Me.OnItemNameChanged(Me.Items(sender.id), e)
      End Sub

   End Class

End Namespace
