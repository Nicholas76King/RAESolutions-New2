Imports System.Collections
Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities

   Public Class FluidCoolerCoil
      Inherits Coil

      Private dr As DataRow

      Public Sub New()
         'dbPath = "FluidCooler"
         Me.dr = Utility.BuildDataRow(Me)
         Me.NumRows = Me.Rows
         Me.FinHeight = Me.Height
         Me.FinLength = Me.Width
         If Me.Diameter = 0 Then
            Me.Diameter = 0.625
         End If
      End Sub

      Public Sub New(ByVal _dr As System.Data.DataRow)
         'dbPath = "FluidCooler"
         Me.dr = _dr
         Me.NumRows = Me.Rows
         Me.FinHeight = Me.Height
         Me.FinLength = Me.Width
         If Me.Diameter = 0 Then
            Me.Diameter = 0.625
         End If
      End Sub

      Private _circuitA As FluidCoolerCircuiting
      Private _circuitB As FluidCoolerCircuiting

      Public Property FluidCoolerID() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("FluidCoolerID"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("FluidCoolerID") = value
         End Set
      End Property

      Public Property Volume() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("Volume"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("Volume") = value
         End Set
      End Property

      Public Property Height() As Double
         Get
            Dim h As Double = CDbl(Utility.NullSafe(dr("Height"), Type.GetType("System.Double")))
            Me.FinHeight = h
            Return h
         End Get
         Set(ByVal value As Double)
            dr("Height") = value
            Me.FinHeight = value
         End Set
      End Property

      Public Property Width() As Double
         Get
            Dim w As Double = CDbl(Utility.NullSafe(dr("Width"), Type.GetType("System.Double")))
            Me.FinLength = w
            Return w
         End Get
         Set(ByVal value As Double)
            dr("Width") = value
            Me.FinLength = value
         End Set
      End Property

      Public Property Rows() As Integer
         Get
            Dim r As Integer = CInt(Utility.NullSafe(dr("Rows"), Type.GetType("System.Int32")))
            Me.NumRows = r
            Return r
         End Get
         Set(ByVal value As Integer)
            dr("Rows") = value
            Me.NumRows = value
         End Set
      End Property

      Public Overloads Property FPI() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("FPI"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("FPI") = value
         End Set
      End Property

      Public Property CircuitA() As FluidCoolerCircuiting
         Get
            If _circuitA Is Nothing Then
               _circuitA = FluidCoolerCircuiting.Populate(CInt(dr("CircuitA").ToString()))
            End If
            Return _circuitA
         End Get
         Set(ByVal value As FluidCoolerCircuiting)
            _circuitA = value
         End Set
      End Property

      Public Function Convert() As Coil
         Dim c As New Coil()
         c.CoilApplication = Me.CoilApplication
         c.CoilMode = Me.CoilMode
         c.CoilUseType = Me.CoilUseType
         c.Diameter = Me.Diameter
         c.FileName = Me.FileName
         c.FinDesign = Me.FinDesign
         c.FinHeight = Me.FinHeight
         c.FinLength = Me.FinLength
         c.FinMaterial = Me.FinMaterial
         c.FinThickness = Me.FinThickness
         c.FPI = Me.FPI
         c.NumRows = Me.Rows
         c.Orientation = Me.Orientation
         c.TubeMaterial = Me.TubeMaterial
         c.TubeThickness = Me.TubeThickness
         Return c
      End Function

      Public Property CircuitB() As FluidCoolerCircuiting
         Get
            If _circuitB Is Nothing Then
               _circuitB = FluidCoolerCircuiting.Populate(CInt(dr("CircuitB").ToString()))
            End If
            Return _circuitB
         End Get
         Set(ByVal value As FluidCoolerCircuiting)
            _circuitB = value
         End Set
      End Property

      Public Shared Function Populate() As Generic.List(Of FluidCoolerCoil)
         Dim coll As New Generic.List(Of FluidCoolerCoil)
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerCoils
         For Each row As DataRow In dtb.Rows
            coll.Add(New FluidCoolerCoil(row))
         Next
         Return coll
      End Function

      Public Shared Function Populate(ByVal id As Integer) As FluidCoolerCoil
         Dim fcc As New FluidCoolerCoil
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCoolerCoils
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "FluidCoolerID = " & id.ToString()
         If dv.Count > 0 Then
            fcc = New FluidCoolerCoil(dv.Item(0).Row)
         Else
            fcc = Nothing
         End If
         Return fcc
      End Function
   End Class
End Namespace