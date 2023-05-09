Imports System
Imports Rae.Collections

Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' List of process items.
   ''' </summary>
   ''' <remarks>
   ''' Has name changed event.
   ''' </remarks>
   Public Class ProcessItemList
      Inherits EventfulList(Of ProcessItem)


#Region " Events"


      ''' <summary>
      ''' Occurs after an item's name is changed.
      ''' </summary>
      Public Event ItemNameChanged As EventHandler(Of ProcessItem, EventArgs)

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
      Protected Overridable Sub OnItemNameChanged(ByVal item As ProcessItem, ByVal e As EventArgs)
         If Me.ItemNameChangedEvent IsNot Nothing Then
            ' raises event
            RaiseEvent ItemNameChanged(item, e)
         End If
      End Sub

#End Region


      ''' <summary>
      ''' Constructor
      ''' </summary>
      Public Sub New()

      End Sub


#Region " Public properties"

      ''' <summary>
      ''' Provides access to process items by ID. Returns null if ID doesn't exist.
      ''' </summary>
      ''' <param name="id">
      ''' ID of process to get.
      ''' </param>
      ''' <returns>
      ''' Process item with ID or null if there is no item with the ID.
      ''' </returns>
      Public Overloads Function Items(ByVal id As item_id) As ProcessItem
         If id Is Nothing Then
            Throw New ArgumentNullException("Process item list's Items does not allow null for ID parameter.")
         End If

         ' searches item for item w/ the specified ID
         For Each item As ProcessItem In Me
            If item.id.ToString = id.ToString Then
               Return item
            End If
         Next

         ' returns null when there is not an item with the id
         Return Nothing
         'Throw New ArgumentException("Process item list's items does not contain an item with the ID, " & id.SafeId)
      End Function


      ''' <summary>
      ''' Provides access to process items by ID. Returns null if ID doesn't exist.
      ''' </summary>
      ''' <param name="id">
      ''' ID of process to get.
      ''' </param>
      ''' <returns>
      ''' Process item with ID or null if there is no item with the ID.
      ''' </returns>
      Public Overloads Function Items(ByVal id As String) As ProcessItem
         Return Me.Items(New item_id(id))
      End Function


      ''' <summary>
      ''' Adds process item to list.
      ''' </summary>
      ''' <param name="item">
      ''' Item to add to list.
      ''' </param>
        Public Shadows Sub Add(ByVal item As ProcessItem)
            If item Is Nothing Then Exit Sub
            MyBase.Add(item)
            AddHandler item.NameChanged, AddressOf ItemName_Changed
        End Sub

#End Region

      ''' <summary>
      ''' Propogates name changed event.
      ''' </summary>
      Private Sub ItemName_Changed(ByVal sender As ItemBase, ByVal e As EventArgs)
         Me.OnItemNameChanged(Me.Items(sender.id), e)
      End Sub

   End Class

End Namespace