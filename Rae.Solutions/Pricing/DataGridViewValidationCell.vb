Imports System.Windows.Forms
Imports Rae.RaeSolutions.Business

''' <summary>
''' Validation cell displays image to indicate validation status, Value property.
''' </summary>
''' <history by="Casey Joyce" finish="2006/07/17">
''' Created
''' </history>
Public Class DataGridViewValidationCell
   Inherits DataGridViewImageCell


   Private m_value As ValidationStatus
   Private images As New ImageList


   ''' <summary>
   ''' Indicates validation status.
   ''' </summary>
   Public Shadows Property Value() As ValidationStatus
      Get
         Return Me.m_value
      End Get
      Set(ByVal value As ValidationStatus)
         Me.m_value = value
         If value = ValidationStatus.Invalid Then
            MyBase.Value = My.Resources.Warning
         Else
            MyBase.Value = images.Images(0)
         End If
      End Set
   End Property


   ''' <summary>
   ''' Constructs cell to indicate validation status.
   ''' </summary>
   Public Sub New()
      Me.ValueType = GetType(ValidationStatus)
      MyBase.Value = ValidationStatus.Invalid

      Me.images.TransparentColor = System.Drawing.Color.Fuchsia
      Me.images.Images.Add(My.Resources.OK)
   End Sub


   'Protected Overrides Function GetFormattedValue(ByVal value As Object, ByVal rowIndex As Integer, ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal valueTypeConverter As System.ComponentModel.TypeConverter, ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object
   '   If CType(value, ValidationStatus) = ValidationStatus.Invalid Then
   '      Return My.Resources.WarningHS
   '   Else
   '      Return My.Resources.OK
   '   End If
   'End Function

End Class
