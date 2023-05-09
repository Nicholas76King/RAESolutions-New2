Imports System.Windows.Forms

''' <summary>
''' Validation column displays images that indicate validation status.
''' </summary>
''' <history by="Casey Joyce" finish="2006/07/17">
''' Created
''' </history>
<DataGridViewColumnDesignTimeVisible(True)> _
Public Class DataGridViewValidationColumn
   Inherits DataGridViewImageColumn


   ''' <summary>
   ''' Column header cell with image.
   ''' </summary>
   <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
   Public Shadows Property HeaderCell() As DataGridViewImageColumnHeaderCell
      Get
         Return CType(MyBase.HeaderCell, DataGridViewImageColumnHeaderCell)
      End Get
      Set(ByVal value As DataGridViewImageColumnHeaderCell)
         MyBase.HeaderCell = value
      End Set
   End Property


   ''' <summary>
   ''' Constructs validation column to display validation status in cells and image in column header cell.
   ''' </summary>
   Public Sub New()
      MyBase.New()

      Me.CellTemplate = New DataGridViewValidationCell
      Me.HeaderCell = New DataGridViewImageColumnHeaderCell(My.Resources.Warning)
   End Sub

End Class
