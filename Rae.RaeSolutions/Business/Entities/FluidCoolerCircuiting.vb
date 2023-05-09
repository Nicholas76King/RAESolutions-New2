Imports System.Collections
Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities
   Public Class FluidCoolerCircuiting
      'Inherits BaseObject

      Private dr As DataRow

      Public Sub New()
         'dbPath = "FluidCooler"
         Me.dr = Utility.BuildDataRow(Me)
      End Sub

      Public Sub New(ByVal _dr As System.Data.DataRow)
         'dbPath = "FluidCooler"
         Me.dr = _dr
      End Sub

      Public Property FluidCoolerCircuitingID() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("FluidCoolerCircuitingID"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("FluidCoolerCircuitingID") = value
         End Set
      End Property

      Public Property FluidCoolerCircuitingText() As String
         Get
            Return CStr(Utility.NullSafe(dr("FluidCoolerCircuitingText"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("FluidCoolerCircuitingText") = value
         End Set
      End Property

      Public Property FluidCoolerCircuitingType() As String
         Get
            Return CStr(Utility.NullSafe(dr("FluidCoolerCircuitingType"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("FluidCoolerCircuitingType") = value
         End Set
      End Property

      Public Property FluidCoolerCircuitingValue() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("FluidCoolerCircuitingValue"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("FluidCoolerCircuitingValue") = value
         End Set
      End Property

      Public Shared Function Populate() As Generic.List(Of FluidCoolerCircuiting)
         Dim coll As New Generic.List(Of FluidCoolerCircuiting)
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerCircuiting
         For Each row As DataRow In dtb.Rows
            Dim fc As New FluidCoolerCircuiting(row)
            coll.Add(fc)
         Next
         Return coll
      End Function

      Public Shared Function Populate(ByVal id As Integer) As FluidCoolerCircuiting
         Dim fc As New FluidCoolerCircuiting
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerCircuiting
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "FluidCoolerCircuitingID = " & id.ToString()
         If dv.Count > 0 Then
            fc = New FluidCoolerCircuiting(dv.Item(0).Row)
         Else
            fc = Nothing
         End If
         Return fc
      End Function
   End Class
End Namespace