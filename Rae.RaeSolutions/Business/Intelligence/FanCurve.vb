'*********************************************************
' **                                                   **
' **                                                   **
' **                  !!!WARNING!!!                    **
' **          Capacities are still a hair off          **
'                                                      
' **                                                   **
'*********************************************************
Imports System.Data

Namespace Rae.RaeSolutions.Business.Intelligence
   Public Class FanCurve

      Private dr As DataRow

      Public Sub New()
         Me.dr = Rae.RaeSolutions.Utility.BuildDataRow(Me)
      End Sub

      Public Sub New(ByVal strFileName As String)
         Me.dr = Rae.RaeSolutions.Utility.BuildDataRow(Me)
         FileName = strFileName
         Populate()
      End Sub

      Public Sub New(ByVal row As DataRow)
         Me.dr = row
      End Sub

      Public Property FileName() As String
         Get
            Return dr("FileName").ToString()
         End Get
         Set(ByVal value As String)
            dr("FileName") = value
         End Set
      End Property

      Public Property C0() As Double
         Get
            Return CDbl(dr("C0"))
         End Get
         Set(ByVal value As Double)
            dr("C0") = value
         End Set
      End Property

      Public Property C1() As Double
         Get
            Return CDbl(dr("C1"))
         End Get
         Set(ByVal value As Double)
            dr("C1") = value
         End Set
      End Property

      Public Property C2() As Double
         Get
            Return CDbl(dr("C2"))
         End Get
         Set(ByVal value As Double)
            dr("C2") = value
         End Set
      End Property

      Public Property C3() As Double
         Get
            Return CDbl(dr("C3"))
         End Get
         Set(ByVal value As Double)
            dr("C3") = value
         End Set
      End Property

      Public Property C4() As Double
         Get
            Return CDbl(dr("C4"))
         End Get
         Set(ByVal value As Double)
            dr("C4") = value
         End Set
      End Property

      Public Property C5() As Double
         Get
            Return CDbl(dr("C5"))
         End Get
         Set(ByVal value As Double)
            dr("C5") = value
         End Set
      End Property

      Public Property C6() As Double
         Get
            Return CDbl(dr("C6"))
         End Get
         Set(ByVal value As Double)
            dr("C6") = value
         End Set
      End Property

      Public Property C7() As Double
         Get
            Return CDbl(dr("C7"))
         End Get
         Set(ByVal value As Double)
            dr("C7") = value
         End Set
      End Property

      Public Property C8() As Double
         Get
            Return CDbl(dr("C8"))
         End Get
         Set(ByVal value As Double)
            dr("C8") = value
         End Set
      End Property

      Public Property C9() As Double
         Get
            Return CDbl(dr("C9"))
         End Get
         Set(ByVal value As Double)
            dr("C9") = value
         End Set
      End Property

      Private Sub Populate()
         If Not Me.dr Is Nothing Then
            Me.dr = rae.solutions.condensers.condenser_repository.RetrieveFanCurve(FileName)
         End If
      End Sub

   End Class
End Namespace