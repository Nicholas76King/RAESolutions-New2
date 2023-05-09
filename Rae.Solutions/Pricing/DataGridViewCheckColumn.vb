Imports System.Windows.Forms

''' <summary>
''' Check box column that show check box image in column header cell.
''' </summary>
''' <history by="Casey Joyce" finish="2006/07/17">
''' Created
''' </history>
Public Class DataGridViewCheckColumn
   Inherits DataGridViewCheckBoxColumn

   Public Sub New()
      Me.HeaderCell = New DataGridViewImageColumnHeaderCell(My.Resources.Checked)
   End Sub

End Class
