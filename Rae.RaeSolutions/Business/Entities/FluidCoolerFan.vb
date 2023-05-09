Imports System.Collections
Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities
   Public Class FluidCoolerFan
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

      Public ReadOnly Property Description() As String
         Get
            Return System.Math.Round(Me.MotorHP, 2).ToString & " hp, " & System.Math.Round(Me.Diameter, 0).ToString & """ dia, " & Me.RPM.ToString & " rpm" & ", " & Me.Hertz.ToString() & " hz"
         End Get
      End Property

      Public Property FluidCoolerFanID() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("FluidCoolerFanID"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("FluidCoolerFanID") = value
         End Set
      End Property

      Public Property MotorHP() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("MotorHP"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("MotorHP") = value
         End Set
      End Property

      Public Property Diameter() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("Diameter"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("Diameter") = value
         End Set
      End Property

      Public Property Hertz() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("Hertz"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("Hertz") = value
         End Set
      End Property

      Public Property RPM() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("RPM"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("RPM") = value
         End Set
      End Property

      Public Shared Function Populate() As Generic.List(Of FluidCoolerFan)
         Dim coll As New Generic.List(Of FluidCoolerFan)
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerFans
         For Each row As DataRow In dtb.Rows
            coll.Add(New FluidCoolerFan(row))
         Next
         Return coll
      End Function

      Public Shared Function Populate(ByVal id As Integer) As FluidCoolerFan
         Dim fcf As New FluidCoolerFan
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerFans
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "FluidCoolerFanID = " & id.ToString()
         If dv.Count > 0 Then
            fcf = New FluidCoolerFan(dv.Item(0).Row)
         Else
            fcf = Nothing
         End If
         Return fcf
      End Function

      Public Shared Function Populate(ByVal id As Integer, ByVal IsSeriesID As Boolean) As FluidCoolerFan
         Dim fcf As New FluidCoolerFan
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerFans
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "FluidCoolerSeriesID = " & id.ToString()
         If dv.Count > 0 Then
            fcf = New FluidCoolerFan(dv.Item(0).Row)
         Else
            fcf = Nothing
         End If
         Return fcf
      End Function
   End Class
End Namespace