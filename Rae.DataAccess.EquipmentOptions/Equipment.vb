Imports System.Collections.Generic

Namespace Rae.DataAccess.EquipmentOptions

''' <summary>Equipment</summary>
<System.CLSCompliant(True)> _
Public Class Equipment

   ''' <summary>Constructor, initializes objects</summary>
   Sub New()
      Me.m_options = New List(Of [Option])
   End Sub

#Region " Properties"

   ''' <summary>Equipment model number (not including series)</summary>
   Property Model As String
      Get
         Return Me.m_model
      End Get
      Set(ByVal value As String)
         Me.m_model = value
      End Set
   End Property

   ''' <summary>Series containing equipment</summary>
   Property Series As String
      Get
         Return Me.m_series
      End Get
      Set(ByVal value As String)
         Me.m_series = value
      End Set
   End Property

   ''' <summary>Division of RAE Corporation</summary>
   Property Division As String
      Get
         Return Me.m_division
      End Get
      Set(ByVal value As String)
         Me.m_division = value
      End Set
   End Property

   ''' <summary>Equipment type</summary>
   Property [Type] As String
      Get
         Return Me.m_type
      End Get
      Set(ByVal value As String)
         Me.m_type = value
      End Set
   End Property

        Property CompModel As String
            Get
                Return m_CompModel
            End Get
            Set(ByVal value As String)
                m_CompModel = value
            End Set
        End Property




   ''' <summary>List of options selected for equipment</summary>
   Property Options As List(Of [Option])
      Get
         Return Me.m_options
      End Get
      Set(ByVal value As List(Of [Option]))
         Me.m_options = value
      End Set
   End Property

#End Region
   
   Private m_model As String
   Private m_series As String
   Private m_division As String
   Private m_type As String
        Private m_options As List(Of [Option])

        Private m_CompModel As String

End Class

End Namespace