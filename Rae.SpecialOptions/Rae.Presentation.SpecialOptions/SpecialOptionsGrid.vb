Imports System.Data
Imports T = Rae.DataAccess.SpecialOptions.SpecialOptionsTable
Imports Rae.DataAccess.SpecialOptions

Namespace Rae.Presentation.SpecialOptions

   Public Class SpecialOptionsGrid

      Public Sub SetDataSource(ByVal specialOptionsTable As DataTable)
         Me.DataGridView1.DataSource = specialOptionsTable
         Me.Format()
      End Sub


      Public Sub Format()
         Dim table As DataTable

         table = CType(Me.DataGridView1.DataSource, DataTable)

         table.Columns(T.Id).Caption = "Code"

      End Sub


      Public Sub ViewAll()
         Me.SetDataSource(SpecialOptionsDa.RetrieveAll())
      End Sub


      Public Sub ViewById(ByVal id As Integer)
         Me.SetDataSource(SpecialOptionsDa.RetrieveById(id))
      End Sub


      Public Sub ViewBySalesman(ByVal salesman As String)
         Me.SetDataSource(SpecialOptionsDa.RetrieveByAssignedBy(salesman))
      End Sub

      Public Sub ViewByAssignedTo(ByVal assignedTo As String)
         Me.SetDataSource(SpecialOptionsDa.RetrieveByAssignedTo(assignedTo))
      End Sub

   End Class

End Namespace