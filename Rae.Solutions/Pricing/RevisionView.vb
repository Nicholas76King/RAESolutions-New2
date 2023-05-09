Imports Rae.RaeSolutions.DataAccess.Projects
Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic

Public Class RevisionView

   Private m_CurrentRev As Single = -1
   ''' <summary>
   ''' The current revision being displayed.
   ''' </summary>
   Public ReadOnly Property CurrentRev() As Single
      Get
         Return Me.m_CurrentRev
      End Get
   End Property

   Private m_LastRev As Single
   ''' <summary>
   ''' The last revision for this process.
   ''' </summary>
   Public ReadOnly Property LastRev() As Single
      Get
         Return Me.m_LastRev
      End Get
   End Property

   Private WithEvents m_RevList As List(Of Single)
   ''' <summary>
   ''' RevList
   ''' </summary>
   Public Property RevList() As List(Of Single)
      Get
         Return Me.m_RevList
      End Get
      Set(ByVal value As List(Of Single))
         Me.m_RevList = value
         Me.tsSelectRevision.Items.Clear()
         If value IsNot Nothing Then
            Me.tsSelectRevision.Items.Add(value)
         End If
      End Set
   End Property

   Private m_ActiveProcessForm As Object
   ''' <summary>
   ''' ActiveProcessForm
   ''' </summary>
   Public ReadOnly Property ActiveProcessForm() As Object
      Get
         Return Me.m_ActiveProcessForm
      End Get
   End Property

   Private Sub mnuPrevRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrevRev.Click
      ViewPrevious()
   End Sub

   Private Sub mnuNextRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNextRev.Click
      ViewNext()
   End Sub

   Private Sub tsSelectRevision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsSelectRevision.SelectedIndexChanged
      ViewRevision(tsSelectRevision.Text)
   End Sub

   Private Sub tsPrevRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPrevRev.Click
      ViewPrevious()
   End Sub

   Private Sub tsNextRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNextRev.Click
      ViewNext()
   End Sub

   Private Sub tsLatestRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLatestRev.Click
      ViewLast()
   End Sub

   Private Sub tsFirstRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFirstRev.Click
      ViewFirst()
   End Sub

   Private Sub mnuFirstRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFirstRev.Click
      ViewFirst()
   End Sub

   Private Sub mnuLatestRev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLatestRev.Click
      ViewLast()
   End Sub

   Private Sub ViewFirst()
      Try
         If Not OpenedProject.IsOpened Then Exit Sub
         If ProjectInfo.Viewer.ActiveItemIsValid Then
            Me.tsSelectRevision.Text = "Revision " & Me.RevList(0) & " (First)"
         End If
      Catch ex As Exception
         Throw
      End Try
   End Sub

   Private Sub ViewLast()
      Try
         If Not OpenedProject.IsOpened Then Exit Sub
         If ProjectInfo.Viewer.ActiveItemIsValid Then
            Me.tsSelectRevision.Text = "Revision " & Me.m_LastRev & " (Latest)"
         End If
      Catch ex As Exception
         Throw
      End Try
   End Sub

   Private Sub ViewPrevious()
      Try
         If Not OpenedProject.IsOpened Then Exit Sub
         If ProjectInfo.Viewer.ActiveItemIsValid Then
            If Me.RevList.IndexOf(Me.CurrentRev) > 0 Then
               If Me.RevList.IndexOf(Me.CurrentRev) - 1 = 0 Then
                  Me.tsSelectRevision.Text = "Revision " & Me.RevList(0) & " (First)"
               Else
                  Me.tsSelectRevision.Text = "Revision " & Me.RevList(Me.RevList.IndexOf(Me.m_CurrentRev) - 1)
               End If
            End If
         End If
         'ProjectInfo.Viewer.DisplayPreviousRevision(ProjectInfo.Viewer.GetActiveProcess)
      Catch ex As Exception
         Throw
      End Try
   End Sub

   Private Sub ViewNext()
      Try
         If Not OpenedProject.IsOpened Then Exit Sub
         If ProjectInfo.Viewer.ActiveItemIsValid Then
            If Me.CurrentRev < Me.m_LastRev Then
               If Me.RevList(Me.RevList.IndexOf(Me.m_CurrentRev) + 1) = Me.m_LastRev Then
                  Me.tsSelectRevision.Text = "Revision " & Me.LastRev & " (Latest)"
               Else
                  Me.tsSelectRevision.Text = "Revision " & Me.RevList(Me.RevList.IndexOf(Me.m_CurrentRev) + 1)
               End If
            End If
         End If
         'ProjectInfo.Viewer.DisplayNextRevision(ProjectInfo.Viewer.GetActiveProcess)
      Catch ex As Exception
         Throw
      End Try
   End Sub

   Private Sub ViewRevision(ByVal revisionToView As String)
      Try
         If Not OpenedProject.IsOpened Then Exit Sub

         ' is active form an equipment form
         If ProjectInfo.Viewer.GetActiveForm IsNot Nothing _
         AndAlso TypeOf ProjectInfo.Viewer.GetActiveForm() Is EquipmentForm Then
            ' converts displayed revision text to revision number
            revisionToView = Trim(Replace(Replace(Replace(revisionToView, "Revision", ""), "(First)", ""), "(Latest)", ""))
            ' raises revision changed event
            Me.OnRevisionChanged(New ValueChangedEventArgs(Of Single)(Me.CurrentRev, CSng(revisionToView)))
            ' views equipment at the specified revision
            ProjectInfo.Viewer.ViewEquipmentRevision(CType(ProjectInfo.Viewer.GetActiveForm(), EquipmentForm).Equipment, CSng(revisionToView))
         ElseIf ProjectInfo.Viewer.GetActiveProcess IsNot Nothing Then
            revisionToView = Trim(Replace(Replace(Replace(revisionToView, "Revision", ""), "(First)", ""), "(Latest)", ""))
            Me.OnRevisionChanged(New ValueChangedEventArgs(Of Single)(Me.CurrentRev, CSng(revisionToView)))
            ProjectInfo.Viewer.DisplayRevision(ProjectInfo.Viewer.GetActiveProcess, CSng(revisionToView))
         End If
      Catch ex As Exception
         Throw
      Finally
         Me.m_CurrentRev = CSng(revisionToView)
         UpdateRevisionView(Nothing, Nothing)
         ' Display warning if this is not the current revision...
         SetWarning()
      End Try
   End Sub


   Private Sub RevisionView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If Me.DesignMode = False Then
         AddHandler CType(Me.ParentForm, MainForm).MdiChildActivate, AddressOf UpdateRevisionView
      End If
   End Sub


   Public Sub UpdateRevisionView(ByVal sender As Object, ByVal e As EventArgs)

      ' Clear combo revision list...
      Me.tsSelectRevision.Items.Clear()
      Me.tsSelectRevision.Text = "No Selection"

      ' Make sure project is opened...
      If Not OpenedProject.IsOpened Then Exit Sub

      ' Set active process form...
      Me.m_ActiveProcessForm = ProjectInfo.Viewer.GetActiveForm()
      If Me.m_ActiveProcessForm Is Nothing Then Exit Sub

      ' Clear revision list property...
      If Me.m_RevList IsNot Nothing Then Me.m_RevList.Clear()

      ' Set last revision...
      If TypeOf Me.m_ActiveProcessForm Is EquipmentForm Then
         Dim activeEquipmentForm As EquipmentForm

         ' converts active form to equipment form to get equipment specific properties
         activeEquipmentForm = CType(Me.m_ActiveProcessForm, EquipmentForm)
         ' gets latest revsion
         Me.m_LastRev = EquipmentDa.RetrieveLatestRevision(activeEquipmentForm.Tag)
         ' Set current revision & update combo text
         ' before we populate combo list...
         Try
            Me.m_CurrentRev = activeEquipmentForm.Equipment.revision
            If Me.m_CurrentRev = -1 Then Me.m_CurrentRev = Me.m_LastRev
            If Me.m_CurrentRev = 0 Then
               Me.tsSelectRevision.Text = "Revision " & Me.m_CurrentRev & " (First)"
            ElseIf Me.m_CurrentRev = Me.m_LastRev Then
               Me.tsSelectRevision.Text = "Revision " & Me.m_CurrentRev & " (Latest)"
            Else
               Me.tsSelectRevision.Text = "Revision " & Me.m_CurrentRev
            End If
         Catch ex As Exception
            ' Form does not have correct properties...
            Exit Sub
         End Try

         ' Set revision list...
         Me.m_RevList = EquipmentDa.RetrieveAllRevisions(activeEquipmentForm.Tag)

      Else

         Me.m_LastRev = ProcessItemDA.LastestRevision(Me.m_ActiveProcessForm.Tag)

         ' Set current revision & update combo text
         ' before we populate combo list...
         Try
            Me.m_CurrentRev = Me.m_ActiveProcessForm.CurrentRevision
            If Me.m_CurrentRev = -1 Then Me.m_CurrentRev = Me.m_LastRev
            If Me.m_CurrentRev = 0 Then
               Me.tsSelectRevision.Text = "Revision " & Me.m_CurrentRev & " (First)"
            ElseIf Me.m_CurrentRev = Me.m_LastRev Then
               Me.tsSelectRevision.Text = "Revision " & Me.m_CurrentRev & " (Latest)"
            Else
               Me.tsSelectRevision.Text = "Revision " & Me.m_CurrentRev
            End If
         Catch ex As Exception
            ' Form does not have correct properties...
            Exit Sub
         End Try

         ' Set revision list...
         Me.m_RevList = ProcessItemDA.GetAllRevisions(Me.m_ActiveProcessForm.Tag)

      End If

      ' Populate combo list...
      For Each Rev As Single In RevList
         If RevList.IndexOf(Rev) = 0 Then
            Me.tsSelectRevision.Items.Add("Revision " & Rev & " (First)")
         ElseIf Rev = Me.m_LastRev Then
            Me.tsSelectRevision.Items.Add("Revision " & Rev & " (Latest)")
         Else
            Me.tsSelectRevision.Items.Add("Revision " & Rev)
         End If
      Next

      ' Display warning if this is not the current revision...
      SetWarning()

   End Sub

   Public Sub SetWarning()

      ' Display warning if this is not the current revision...
      If Me.m_CurrentRev = Me.m_LastRev Or Me.tsSelectRevision.Text = "No Selection" Then
         tsWarning.Visible = False
      Else
         tsWarning.Visible = True
      End If

   End Sub


#Region " Events"

   '''' <summary>
   '''' List of event handlers subscribed to the revision changed event.
   '''' </summary>
   'Private revisionChangedEventHandlers As New List(Of [Delegate])
   '''' <summary>
   '''' Number of event handlers subscribed to the revision changed event.
   '''' Counts redundantly added event handlers even though 
   '''' they are not actually added to the event handler list.
   '''' </summary>
   'Private numRevisionChangedEventHandlers As Integer


   '''' <summary>
   '''' Occurs after revision is changed, but before the view is changed.
   '''' </summary>
   '''' <remarks>
   '''' <para>
   '''' A custom event is being used to prevent event handlers that are added multiple times
   '''' (such as from the same form simutaneously having multiple instances open) 
   '''' from being executed multiple times.
   '''' </para>
   '''' <para>
   '''' Implementation note:
   '''' Removing event handlers only when the number of added event handlers is zero
   '''' will only work as long as only one event handler is being added.
   '''' At the time this code was written only the EquipmentForm.RevisionView_RevisionChanged
   '''' event handler was being added.
   '''' If other event handlers are added later then another solution will have to be implemented.
   '''' </para>
   '''' </remarks>
   'Public Custom Event RevisionChanged As EventHandler(Of RevisionView, ValueChangedEventArgs(Of Integer))

   '   ' adds revision changed event handler if it is not already added
   '   AddHandler(ByVal value As EventHandler(Of RevisionView, ValueChangedEventArgs(Of Integer)))
   '      ' adds event handlers for revision changed
   '      ' doesn't allow the same event handler to be added multiple times,
   '      ' which prevents the event handler method from being executed multiple times

   '      Dim isEventHandlerAlreadyAdded As Boolean

   '      ' adds up number of event handlers that have been added (even redundant adds)
   '      Me.numRevisionChangedEventHandlers += 1

   '      For i As Integer = 0 To Me.revisionChangedEventHandlers.Count - 1
   '         ' does this handler already exist
   '         If value.Method Is Me.revisionChangedEventHandlers(i).Method Then
   '            ' indicates event handler is already in list
   '            isEventHandlerAlreadyAdded = True
   '            Exit For
   '         End If
   '      Next

   '      ' if event handler is not already added
   '      If Not isEventHandlerAlreadyAdded Then
   '         ' add event handler
   '         Me.revisionChangedEventHandlers.Add(value)
   '      Else
   '         ' event handler has already been added
   '         ' if it is added again the event handler would be executed multiple times
   '         ' which would cause an error or decrease performance
   '      End If
   '   End AddHandler

   '   ' removes revision changed event handler if it is the last one
   '   RemoveHandler(ByVal value As EventHandler(Of RevisionView, ValueChangedEventArgs(Of Integer)))
   '      ' updates number of event handlers
   '      Me.numRevisionChangedEventHandlers -= 1

   '      ' checks if this is the last equipment form to remove handler from
   '      If Me.numRevisionChangedEventHandlers = 0 Then
   '         For i As Integer = 0 To Me.revisionChangedEventHandlers.Count - 1
   '            ' does this handler exist
   '            If value.Method Is Me.revisionChangedEventHandlers(i).Method Then
   '               ' removes event handler
   '               Me.revisionChangedEventHandlers.RemoveAt(i)
   '               Exit For
   '            End If
   '         Next
   '      End If
   '   End RemoveHandler

   '   ' invokes all revision changed event handlers
   '   RaiseEvent(ByVal sender As RevisionView, ByVal e As ValueChangedEventArgs(Of Integer))
   '      For Each handler As EventHandler(Of RevisionView, ValueChangedEventArgs(Of Integer)) In revisionChangedEventHandlers
   '         handler.Invoke(sender, e)
   '      Next
   '   End RaiseEvent

   'End Event

   '''' <summary>
   '''' Raises <see cref="RevChanged" /> event.
   '''' </summary>
   '''' <param name="e">
   '''' Value changed event arguments. 
   '''' The before value should be the previous revision, 
   '''' and the after value should be the revision that was just set.
   '''' </param>
   '''' <remarks>
   '''' Use this method to raise event rather than raising event directly.
   '''' Protected - Prevents other classes from raising event
   '''' Overridable - Allows derived classes to override implementation.
   '''' </remarks>
   'Protected Overridable Sub OnRevisionChanged(ByVal e As RAE.Core.ValueChangedEventArgs(Of Integer))
   '   ' checks if there are any event handlers subscribed to this event
   '   If Me.revisionChangedEventHandlers.Count > 0 Then
   '      ' raises event
   '      RaiseEvent RevisionChanged(Me, e)
   '   End If
   'End Sub


   ''' <summary>
   ''' Occurs after/before ...
   ''' </summary>
   Public Event RevisionChanged As EventHandler(Of RevisionView, ValueChangedEventArgs(Of Single))

   ''' <summary>
   ''' Raises <see cref="RevisionChanged" /> event.
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
   Protected Overridable Sub OnRevisionChanged(ByVal e As ValueChangedEventArgs(Of Single))
      If Me.RevisionChangedEvent IsNot Nothing Then
         ' raises event
         RaiseEvent RevisionChanged(Me, e)
      End If
   End Sub

#End Region

End Class






