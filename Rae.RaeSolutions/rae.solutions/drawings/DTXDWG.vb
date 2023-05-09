Namespace rae.solutions.drawings

   Public Class DTXDWG

      Public Enum LayerMode As Integer
         ON_OFF = 1
         THAW_FREEZE = 2
      End Enum


      Public Enum LayerState As Integer
         ON_THAW = 1
         OFF_FREEZE = 2
      End Enum


      Public Enum ExportXML As Integer
         DO_NOT_EXPORT = 0
         EXPORT = 1
      End Enum


      Public Enum XMLDataToGet As Integer
         LAYER_NAMES = 0
         INPUT_TEXT_2DARRAY = 1
         ALL_TEXT_2DARRAY = 2
         CONSOLE_OUTPUT_ONLY = 3
      End Enum


      Public Enum DWGVersion As Integer
         dwg_2007 = 2007
         dwg_2004_2005_2006 = 2004
         dwg_2000_2000i_2002 = 2000
         dwg_14 = 14
         dwg_13 = 13
         dwg_12 = 12
         dwg_11 = 11
         dwg_10 = 10
      End Enum


      Public Enum DXFVersion As Integer
         dwg_2004_2005_2006 = 2004
         dwg_2000_2000i_2002 = 2000
         dwg_14 = 14
         dwg_13 = 13
         dwg_12 = 12
         dwg_11 = 11
         dwg_10 = 10
      End Enum


      Private m_LayerName As String
      ''' <summary>
      ''' LayerName
      ''' </summary>
      Public Property LayerName() As String
         Get
            Return Me.m_LayerName
         End Get
         Set(ByVal value As String)
            Me.m_LayerName = value
         End Set
      End Property


      Private m_Freeze As Boolean
      ''' <summary>
      ''' Freeze
      ''' </summary>
      Public Property Freeze() As Boolean
         Get
            Return Me.m_Freeze
         End Get
         Set(ByVal value As Boolean)
            Me.m_Freeze = value
         End Set
      End Property


      Private Function LayerFreeze(ByVal Value As Boolean) As Boolean


      End Function

   End Class

End Namespace