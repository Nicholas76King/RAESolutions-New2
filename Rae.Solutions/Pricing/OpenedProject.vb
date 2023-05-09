Imports Rae.RaeSolutions.Business.Entities


''' <summary>
''' Holds reference to open project.
''' </summary>
''' <history by="Casey Joyce" finish="2006/07/24" hours="1">
''' Created
''' </history>
Public Class OpenedProject

   ''' <summary>
   ''' Occurs after project is set.
   ''' </summary>
   Public Shared Event ProjectSet As EventHandler(Of project_manager, EventArgs)

   ''' <summary>
   ''' Raises <see cref="ProjectSet" /> event.
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
   Protected Shared Sub OnProjectSet(ByVal e As EventArgs)
      If ProjectSetEvent IsNot Nothing Then
         ' raises event
         RaiseEvent ProjectSet(m_manager, e)
      End If
   End Sub


   ''' <summary>Project manager that is open.</summary>
   Shared Property Manager() As project_manager
      Get
         Return m_manager
      End Get
      Set(ByVal value As project_manager)
         m_manager = value
         ' raises event
         OnProjectSet(EventArgs.Empty)
      End Set
   End Property


   ''' <summary>True if project is open; else false.</summary>
   Shared ReadOnly Property IsOpened() As Boolean
      Get
         Return (m_manager IsNot Nothing)
      End Get
   End Property


   Shared ReadOnly Property ProjectId As item_id
      Get
         Dim id As item_id
         If IsOpened Then
            id = Manager.Project.id
         End If
         Return id
      End Get
   End Property


   Private Shared WithEvents m_manager As project_manager

   ''' <summary>Hide constructor.</summary>
   Private Sub New()
   End Sub


End Class
