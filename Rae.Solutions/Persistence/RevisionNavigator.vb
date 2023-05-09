Imports Rae.Persistence

Public Class RevisionNavigator
   Inherits ToolStrip
   Implements ICanNavigate
   
   
   Sub New()
      MyBase.New()
      
      addControls()
   End Sub
   
   
   Event Navigating(sender As ICanNavigate, e As NavigatingEventArgs) _
   Implements ICanNavigate.Navigating
   
   Event Navigated(sender As ICanNavigate, e As NavigatedEventArgs) _
   Implements ICanNavigate.Navigated
   
   
   Property Item As ICanBeRevisioned _
   Implements ICanNavigate.Item
      Get
         Return item_
      End Get
      Set(value As ICanBeRevisioned)
         item_ = value
         If item_ IsNot Nothing Then
            Me.revisionLabel.Text = item_.Revisions.Current.ToString
         End If
      End Set
   End Property
   

   Sub NavigateTo(revision As Revision) _
   Implements ICanNavigate.NavigateTo
      If Item Is Nothing Then
         ' no item is selected, so do not attempt to navigate
         Exit Sub
      ElseIf Item.Revisions.Count = 0 Then
        ' there are no revisions, do not attempt to navigate
         Exit Sub
      ElseIf Item.Revisions.Current Is Nothing Then
         ' item has no current revision, invalid state; this shouldn't be allowed
         Exit Sub
      ElseIf Item.Revisions.Current = revision Then
         ' no need to navigate; already on desired revision
         Exit Sub
      ElseIf Not Item.Revisions.Contains(revision) Then
         '?Alert(Revision does not exist)
         Exit Sub
      End If
      
      Item.Refresh.Invoke()
      
      Dim e As New NavigatingEventArgs(Item.Revisions.Current, revision)
      onNavigating(e)

      If e.Canceled Then
         'Alert(e.Message)
      Else
         Dim args As New NavigatedEventArgs(Item.Revisions.Current, revision)
         onNavigated(args)
      End If
   End Sub


#Region " Internal"

   Private WithEvents item_ As ICanBeRevisioned
   Private WithEvents firstButton As ToolStripButton
   Private WithEvents previousButton As ToolStripButton
   Private WithEvents nextButton As ToolStripButton
   Private WithEvents lastButton As ToolStripButton
   Private revisionLabel As ToolStripLabel
   
   
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
   
   
   
   Private Sub addControls()
      firstButton = New ToolStripButton(My.Resources.First)
      firstButton.ToolTipText = "Go to first revision"
      Items.Add(firstButton)
      AddHandler firstButton.Click, AddressOf firstButton_Click
   
      previousButton = New ToolStripButton(My.Resources.Previous)
      With previousButton
         .ToolTipText = "Go to previous revision"
      End With
      Items.Add(previousButton)
      AddHandler previousButton.Click, AddressOf previousButton_Click
      
      Dim nextButton As New ToolStripButton(My.Resources.Next2)
      With nextButton
         .ToolTipText = "Go to next revision"
      End With
      Items.Add(nextButton)
      AddHandler nextButton.Click, AddressOf nextButton_Click
      
      Dim lastButton As New ToolStripButton(My.Resources.Last)
      With lastButton
         .ToolTipText = "Go to last revision"
      End With
      Items.Add(lastButton)
      AddHandler lastButton.Click, AddressOf lastButton_Click
      
      
      revisionLabel = New ToolStripLabel()
      Items.Add(revisionLabel)
   End Sub
   
   
   Private Sub firstButton_Click(sender As Object, e As EventArgs)
      If Item Is Nothing Then Exit Sub
      
      NavigateTo(Item.Revisions.First)
   End Sub
   
   Private Sub previousButton_Click(sender As Object, e As EventArgs)
      If Item Is Nothing Then Exit Sub
      
      NavigateTo(Item.Revisions.Previous)
   End Sub
   
   Private Sub nextButton_Click(sender As Object, e As EventArgs)
      If Item Is Nothing Then Exit Sub
      
      NavigateTo(Item.Revisions.Next)
   End Sub
   
   Private Sub lastButton_Click(sender As Object, e As EventArgs)
      If Item Is Nothing Then Exit Sub
      
      NavigateTo(Item.Revisions.Last)
   End Sub
   
   Private Sub Me_Navigated(sender As ICanNavigate, e As NavigatedEventArgs) _
   Handles Me.Navigated
      revisionLabel.Text = e.AfterValue.ToString()
   End Sub
   
   Private Sub Item_SavedAsRevision(sender As ICanBeRevisioned, e As EventArgs) _
   Handles item_.SavedAsRevision
      revisionLabel.Text = sender.Revisions.Current.ToString()
   End Sub
   
#End Region
   
End Class