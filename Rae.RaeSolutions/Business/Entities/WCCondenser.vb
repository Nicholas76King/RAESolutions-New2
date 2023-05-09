Imports System.Collections
Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities
   Public Class WCCondenser
      Public dr As DataRow

      Public Sub New()
         Me.dr = Utility.BuildDataRow(Me)
      End Sub

      Public Sub New(ByVal _dr As System.Data.DataRow)
         Me.dr = _dr
      End Sub

      Public Property Model() As String
         Get
            Return CStr(Utility.NullSafe(dr("Model"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("Model") = value
         End Set
      End Property

      Public Property GP() As Double
         Get
            Return CInt(Utility.NullSafe(dr("GP"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("GP") = value
         End Set
      End Property


      Public Property B0() As Double
         Get
            Return CInt(Utility.NullSafe(dr("B0"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B0") = value
         End Set
      End Property

      Public Property B1() As Double
         Get
            Return CInt(Utility.NullSafe(dr("B1"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B1") = value
         End Set
      End Property

      Public Property B2() As Double
         Get
            Return CInt(Utility.NullSafe(dr("B2"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B2") = value
         End Set
      End Property

      Public Property B3() As Double
         Get
            Return CInt(Utility.NullSafe(dr("B3"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B3") = value
         End Set
      End Property

      Public Property B4() As Double
         Get
            Return CInt(Utility.NullSafe(dr("B4"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B4") = value
         End Set
      End Property

      Public Property B5() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("B5"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B5") = value
         End Set
      End Property

      Public Property B6() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("B6"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B6") = value
         End Set
      End Property

      Public Property B7() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("B7"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B7") = value
         End Set
      End Property

      Public Property B8() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("B8"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B8") = value
         End Set
      End Property

      Public Property B9() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("B9"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("B9") = value
         End Set
      End Property

      Public ReadOnly Property Capacity() As Double
         Get
            Return (B0 + B1 * GP ^ 4 + B2 * GP ^ 3 + B3 * GP ^ 2 + B4 * GP)
         End Get
      End Property

      Public Shared Function RetrieveCondensers() As System.Collections.Generic.List(Of WCCondenser)
         Dim list As New System.Collections.Generic.List(Of WCCondenser)
         Dim dtb As DataTable = DataAccess.WaterCooledDA.RetrieveCondensers()
         For Each dr As DataRow In dtb.Rows
            list.Add(New WCCondenser(dr))
         Next
         Return list
      End Function

   End Class

End Namespace