Imports Rae.RaeSolutions.Business.Entities
Imports System.Collections.Generic

Namespace Updating.ContactDataStructure

   Public Class ContactUpdateController

      Protected projectId_ As item_id
      ''' <summary>
      ''' Project ID
      ''' </summary>
      Public ReadOnly Property ProjectId() As item_id
         Get
            Return projectId_
         End Get
      End Property


      ''' <summary>
      ''' Initializes a new instance of contact update controller.
      ''' </summary>
      ''' <param name="projectId">
      ''' Project ID
      ''' </param>
      Public Sub New(ByVal projectId As item_id)
         projectId_ = projectId
      End Sub


      ''' <summary>
      ''' Checks what the contact data structure is
      ''' </summary>
      Public Function Check() As ContactDataStructureDescription
         Dim analyzer As New Analyzer(ProjectId)

         Return analyzer.ContactDataStructure
      End Function


      ''' <summary>
      ''' Starts wizard that user can go through to update contacts.
      ''' </summary>
      Public Function StartConversionWizard() As Outcome
         Dim welcome As New WelcomeWizardForm()
         If welcome.ShowDialog() = DialogResult.Cancel Then
            Return Rae.Outcome.Failed
         End If

         Dim update As New UpdateWizardForm()
         update.Initialize(ProjectId)
         Dim outcome As Outcome
         If update.ShowDialog() = DialogResult.OK Then
            Return Rae.Outcome.Succeeded
         Else
            Return Rae.Outcome.Failed
         End If
      End Function


      Private Sub addContacts(ByVal projectId As item_id, ByVal contacts As List(Of Integer))
         For Each contactId As Integer In contacts
            DataAccess.Projects.ProjectContactsDataAccess.Create(projectId.Id, contactId)
         Next
      End Sub

   End Class

End Namespace