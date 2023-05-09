Imports System

Namespace Rae.Persistence

''' <summary>Revision navigator</summary>
Public Class Navigator
   Implements ICanNavigate
   
   ''' <summary>
   ''' Occurs before after the request to navigate, but before the item is navigated.
   ''' Allows navigation to be canceled.   
   ''' </summary>
   Event Navigating(sender As ICanNavigate, e As NavigatingEventArgs) _
   Implements ICanNavigate.Navigating

   ''' <summary>
   ''' Occurs after an item has been navigated.
   ''' </summary>
   Event Navigated(sender As ICanNavigate, e As NavigatedEventArgs) _
   Implements ICanNavigate.Navigated


   ''' <summary>
   ''' Navigate to revision
   ''' </summary>
   ''' <param name="revision">
   ''' Revision to navigate to
   ''' </param>
   ''' <exception cref="System.NullReferenceException">
   ''' Thrown when the item to revision is null.
   ''' </exception>
   Overridable Sub NavigateTo(revision As Revision) _
   Implements ICanNavigate.NavigateTo
     
      If Item.Revisions.Current = revision Then
         ' no need to navigate; already on desired revision
         Exit Sub
      ElseIf Not Item.Revisions.Contains(revision) Then
         'Alert(Revision does not exist)
         Exit Sub
      End If

      Dim e As New NavigatingEventArgs(Item.Revisions.Current, revision)
      onNavigating(e)

      If e.Canceled Then
         'Alert(e.Message)
      Else
         Dim args As New NavigatedEventArgs(Item.Revisions.Current, revision)
         onNavigated(args)
      End If
   End Sub

   ''' <summary>
   ''' Item that can be navigated by the navigator.
   ''' </summary>
   Property Item As ICanBeRevisioned _
   Implements ICanNavigate.Item
      Set(value As ICanBeRevisioned)
         item_ = value
      End Set
      Get
         Return item_
      End Get
   End Property


#Region " Internal"

   Protected Overridable Sub onNavigating(e As NavigatingEventArgs)
      If NavigatingEvent IsNot Nothing Then
         RaiseEvent Navigating(Me, e)
      End If
   End Sub

   Protected Overridable Sub onNavigated(e As NavigatedEventArgs)
      If NavigatedEvent IsNot Nothing Then
         RaiseEvent Navigated(Me, e)
      End If
   End Sub

   Protected item_ As ICanBeRevisioned

#End Region

End Class

End Namespace