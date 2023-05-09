Imports System.Collections
Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities

   Public Class FluidCoolerSeries
      'Inherits BaseObject

      Private _fluidCoolers As New Generic.List(Of FluidCooler)
      Private dr As DataRow

      Public Sub New()
         Me.dr = Utility.BuildDataRow(Me)
      End Sub

      Public Sub New(ByVal _dr As System.Data.DataRow)
         Me.dr = _dr
      End Sub

      Public Property FluidCoolerSeriesID() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("FluidCoolerSeriesID"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("FluidCoolerSeriesID") = value
         End Set
      End Property

      Public Property ModelSeries() As String
         Get
            Return CStr(Utility.NullSafe(dr("ModelSeries"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("ModelSeries") = value
         End Set
      End Property

      Public Property FanQuantity() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("FanQuantity"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("FanQuantity") = value
         End Set
      End Property

      Public Property FluidCoolers() As Generic.List(Of FluidCooler)
         Get
            Return _fluidCoolers
         End Get
         Set(ByVal value As Generic.List(Of FluidCooler))
            _fluidCoolers = value
            For Each fc As FluidCooler In _fluidCoolers
               fc.FluidCoolerSeries = Me
               'fc.SetFluidCoolerSeries(Me)
            Next
         End Set
      End Property

      Public Shared Function Populate() As Generic.List(Of FluidCoolerSeries)
         Dim coll As New Generic.List(Of FluidCoolerSeries)
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerSeries
         For Each row As DataRow In dtb.Rows
            coll.Add(New FluidCoolerSeries(row))
         Next
         Return coll
      End Function

      Public Shared Function Populate(ByVal id As Integer) As FluidCoolerSeries
         Dim fcs As New FluidCoolerSeries
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerSeries
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "FluidCoolerSeriesID = " & id.ToString()
         If dv.Count > 0 Then
            fcs = New FluidCoolerSeries(dv.Item(0).Row)
         Else
            fcs = Nothing
         End If
         Return fcs
      End Function

      Public Shared Function Populate(ByVal series As String) As FluidCoolerSeries
         Dim fcs As New FluidCoolerSeries
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerSeries
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "ModelSeries = '" & series & "'"
         If dv.Count > 0 Then
            fcs = New FluidCoolerSeries(dv.Item(0).Row)
         Else
            fcs = Nothing
         End If
         Return fcs
      End Function

   End Class
End Namespace