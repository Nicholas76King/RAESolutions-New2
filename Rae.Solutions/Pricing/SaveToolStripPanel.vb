Option Strict On
Option Explicit On

Imports System

''' <summary>
''' Tool strip panel that contains buttons (ex. save buttons) used by child forms.
''' </summary>
''' <remarks>
''' Drag the SaveToolStripPanel from the toolbox onto a form.
''' The TargetToolStrip must be set for the merge functionality.
''' The SaveClick and SaveAsRevisionClick event handlers handle their respective button's click event.
''' </remarks>
Public Class SaveToolStripPanel : Inherits ToolStripPanel

#Region " Fields"

   Friend SourceToolStrip As ToolStrip
   Friend WithEvents SaveToolStripButton As ToolStripButton
   Friend WithEvents SaveAsRevisionToolStripButton As ToolStripButton

   Private targetToolStrip_ As ToolStrip
   Private saveHandler_ As EventHandler
   Private saveAsRevisionHandler_ As EventHandler
   Private isSetup As Boolean

#End Region


#Region " Properties"

   ''' <summary>
   ''' The tool strip that the source tool strip's buttons will be merged into.
   ''' </summary>
   Friend Property TargetToolStrip() As ToolStrip
      Get
         Return targetToolStrip_
      End Get
      Set(ByVal value As ToolStrip)
         targetToolStrip_ = value
      End Set
   End Property


   ''' <summary>
   ''' The event handler for the Save tool strip button's click event.
   ''' </summary>
   Friend Property SaveClick() As EventHandler
      Get
         Return saveHandler_
      End Get
      Set(ByVal value As EventHandler)
         saveHandler_ = value
      End Set
   End Property


   ''' <summary>
   ''' The event handler for the Save as Revision tool strip button's click event.
   ''' </summary>
   Friend Property SaveAsRevisionClick() As EventHandler
      Get
         Return saveAsRevisionHandler_
      End Get
      Set(ByVal value As EventHandler)
         saveAsRevisionHandler_ = value
      End Set
   End Property

#End Region


#Region " Public methods"

   ''' <summary>
   ''' Constructs a new tool strip panel with save buttons.
   ''' </summary>
   Public Sub New()
      MyBase.New()

      initialize()

      addToolStrip()
      addToolStripButtons()
   End Sub


   ''' <summary>
   ''' Sets the properties that should be set. And ensures they're only set once.
   ''' </summary>
   ''' <param name="targetToolStrip">
   ''' The target tool strip that the source tool strip will merge with.
   ''' </param>
   ''' <param name="saveHandler">
   ''' Event handler for the save button's click event.
   ''' </param>
   ''' <param name="saveAsRevisionHandler">
   ''' Event handler for the save as revision button's click event.
   ''' </param>
   ''' <remarks>
   ''' There is not a constructor with these parameters because you can't drag a control onto a form, if the constructor has 
   ''' parameters.
   ''' </remarks>
   Public Sub SetUp(ByVal targetToolStrip As ToolStrip, _
   ByVal saveHandler As EventHandler, ByVal saveAsRevisionHandler As EventHandler)
      If Not isSetup AndAlso targetToolStrip IsNot Nothing Then
         Me.targetToolStrip_ = targetToolStrip
         saveHandler_ = saveHandler
         saveAsRevisionHandler_ = saveAsRevisionHandler
         isSetup = True
      End If
   End Sub


   ''' <summary>
   ''' Merges source and target tool strips.
   ''' </summary>
   Public Sub Merge()
      If targetToolStrip_ Is Nothing Then
         Throw New System.ApplicationException("Cannot merge tool strips. The target tool strip is null.")
      End If
      ToolStripManager.Merge(SourceToolStrip, targetToolStrip_)
   End Sub


   ''' <summary>
   ''' Unmerges source tool strip from target tool strip.
   ''' </summary>
   Public Sub Unmerge()
      ToolStripManager.RevertMerge(targetToolStrip_, SourceToolStrip)
   End Sub

#End Region


#Region " Private methods"

   Private Sub initialize()
      With Me
         .Dock = DockStyle.Top
      End With

      SourceToolStrip = New ToolStrip()
      With SourceToolStrip
         .Name = "SaveToolStrip"
         .Visible = False
      End With

      SaveToolStripButton = New ToolStripButton()
      With SaveToolStripButton
         .Name = "SaveToolStripButton"
         .Text = "Save"
         .Image = My.Resources.Save
         .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
      End With

      SaveAsRevisionToolStripButton = New ToolStripButton()
      With SaveAsRevisionToolStripButton
         .Name = "SaveAsRevisionToolStripButton"
         .Text = "Save as Revision"
         .Image = My.Resources.SaveAsRevision
         .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
      End With
   End Sub


   Private Sub addToolStrip()
      SourceToolStrip.Parent = Me
   End Sub


   Private Sub addToolStripButtons()
      SourceToolStrip.Items.Add(SaveToolStripButton)
      SourceToolStrip.Items.Add(SaveAsRevisionToolStripButton)
   End Sub


   Private Sub SaveToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles SaveToolStripButton.Click
      SaveClick.Invoke(sender, e)
   End Sub


   Private Sub SaveAsRevisionToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
   Handles SaveAsRevisionToolStripButton.Click
      SaveAsRevisionClick.Invoke(sender, e)
   End Sub

#End Region

End Class


'Private Sub parentForm_Activated(ByVal sender As Object, ByVal e As EventArgs)
'   Try
'      merge()
'   Catch ex As ApplicationException
'      MessageBox.Show(ex.Message, "RAESolutions", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'   End Try
'End Sub


'Private Sub parentForm_Deactivate(ByVal sender As Object, ByVal e As EventArgs)
'   unmerge()
'End Sub


'Private Sub SaveToolStripPanel_ParentChanged(ByVal sender As Object, ByVal e As EventArgs) _
'Handles Me.ParentChanged
'   If Me.Parent IsNot Nothing Then
'      AddHandler Me.ParentForm.Activated, AddressOf parentForm_Activated
'      AddHandler Me.ParentForm.Deactivate, AddressOf parentForm_Deactivate
'   End If
'End Sub

