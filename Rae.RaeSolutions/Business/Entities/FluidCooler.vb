Imports System.Collections
Imports System.Data
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.RaeSolutions.Business.Entities

   Public Class FluidCooler
      'Inherits BaseObject

      Public Fans As New Generic.List(Of FluidCoolerFan)
      Public Coils As New Generic.List(Of FluidCoolerCoil)
      Private _fluidcoolerseries As FluidCoolerSeries
      Private _cfm As Integer
      Private dr As DataRow

      Public Sub New()
         Me.dr = Utility.BuildDataRow(Me)
      End Sub

      Public Sub New(ByVal _dr As System.Data.DataRow)
         Me.dr = _dr
      End Sub

      Public Property FluidCoolerID() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("FluidCoolerID"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("FluidCoolerID") = value
         End Set
      End Property

      Public Property FluidCoolerSeries() As FluidCoolerSeries
         Get
            Return _fluidcoolerseries
         End Get
         Set(ByVal value As FluidCoolerSeries)
            _fluidcoolerseries = value
         End Set
      End Property

      'Public ReadOnly Property FluidCoolerSeries() As FluidCoolerSeries
      '    Get
      '        Return _fluidcoolerseries
      '    End Get
      'End Property

      Public Property ModelNumber() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("ModelNumber"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("ModelNumber") = value
         End Set
      End Property

      Public ReadOnly Property ModelName() As String
         Get
            Return Me.FluidCoolerSeries.ModelSeries & "-" & Me.ModelNumber.ToString()
         End Get
      End Property

      Public Sub SetFluidCoolerSeries(ByVal fcs As FluidCoolerSeries)
         _fluidcoolerseries = fcs
      End Sub

      Public Property CoilQuantity() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("CoilQuantity"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("CoilQuantity") = value
         End Set
      End Property

      Public Property CFM() As Integer
         Get
            Return _cfm
         End Get
         Set(ByVal value As Integer)
            _cfm = value
         End Set
      End Property

      'Public Property Fans() As Generic.List(Of FluidCoolerFan)
      '    Get
      '    If _fans.Count = 0 AndAlso Not Me.FluidCoolerSeries Is Nothing Then
      '       Dim fan As FluidCoolerFan = FluidCoolerFan.Populate(Me.FluidCoolerSeries.FluidCoolerSeriesID, True)
      '       For i As Integer = 0 To Me.FluidCoolerSeries.FanQuantity - 1
      '          _fans.Add(fan)
      '       Next
      '    End If
      '        Return _fans
      '    End Get
      '    Set(ByVal value As Generic.List(Of FluidCoolerFan))
      '        _fans = value
      '    End Set
      'End Property

      'Public Property Coils() As Generic.List(Of FluidCoolerCoil)
      ' Get
      '    If _coils.Count = 0 AndAlso Me.FluidCoolerID > 0 Then
      '       Dim coil As FluidCoolerCoil = FluidCoolerCoil.Populate(Me.FluidCoolerID)
      '       For i As Integer = 0 To Me.CoilQuantity - 1
      '          _coils.Add(coil)
      '       Next
      '    End If
      '    Return _coils
      ' End Get
      '    Set(ByVal value As Generic.List(Of FluidCoolerCoil))
      '        _coils = value
      '    End Set
      'End Property

      Public Property Dimensions() As String
         Get
            Return CStr(Utility.NullSafe(dr("Dimensions"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("Dimensions") = value
         End Set
      End Property

      Public Property Operating_Weight() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("Operating_Weight"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("Operating_Weight") = value
         End Set
      End Property

      Public Property Shipping_Weight() As Integer
         Get
            Return CInt(Utility.NullSafe(dr("Shipping_Weight"), Type.GetType("System.Int32")))
         End Get
         Set(ByVal value As Integer)
            dr("Shipping_Weight") = value
         End Set
      End Property

      Public Shared Function Populate() As Generic.List(Of FluidCooler)
         Dim coll As New Generic.List(Of FluidCooler)
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCooler
         For Each row As DataRow In dtb.Rows
            Dim fc As New FluidCooler(row)
            fc.Coils.Clear()
            Dim fcCoil As FluidCoolerCoil = FluidCoolerCoil.Populate(fc.FluidCoolerID)
            For i As Integer = 1 To fc.CoilQuantity
               fc.Coils.Add(fcCoil)
            Next
            fc.FluidCoolerSeries = FluidCoolerSeries.Populate(CInt(row("FluidCoolerSeriesID")))
            fc.Fans.Clear()
            Dim fcFan As FluidCoolerFan = FluidCoolerFan.Populate(fc.FluidCoolerSeries.FluidCoolerSeriesID, True)
            For i As Integer = 1 To fc.FluidCoolerSeries.FanQuantity
               fc.Fans.Add(fcFan)
            Next
            coll.Add(fc)
         Next
         Return coll
      End Function

      Public Shared Function Populate(ByVal id As Integer) As FluidCooler
         Dim fc As New FluidCooler
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCooler
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "FluidCoolerID = " & id.ToString()
         If dv.Count > 0 Then
            fc = New FluidCooler(dv.Item(0).Row)
            fc.FluidCoolerSeries = FluidCoolerSeries.Populate(CInt(dv.Item(0).Row("FluidCoolerSeriesID")))
            'fc.SetFluidCoolerSeries(FluidCoolerSeries.Populate(CInt(dv.Item(0).Row("FluidCoolerSeriesID"))))
            fc.Coils.Clear()
            Dim fcCoil As FluidCoolerCoil = FluidCoolerCoil.Populate(fc.FluidCoolerID)
            For i As Integer = 1 To fc.CoilQuantity
               fc.Coils.Add(fcCoil)
            Next
            fc.FluidCoolerSeries = FluidCoolerSeries.Populate(CInt(dv.Item(0).Row("FluidCoolerSeriesID")))
            fc.Fans.Clear()
            Dim fcFan As FluidCoolerFan = FluidCoolerFan.Populate(fc.FluidCoolerSeries.FluidCoolerSeriesID, True)
            For i As Integer = 1 To fc.FluidCoolerSeries.FanQuantity
               fc.Fans.Add(fcFan)
            Next
         Else
            fc = Nothing
         End If
         Return fc
      End Function

      Public Shared Function Populate(ByVal model As String) As FluidCooler
         Dim fcs As FluidCoolerSeries = FluidCoolerSeries.Populate(model.Split(CChar("-"))(0))
         Dim fclist As Generic.List(Of FluidCooler) = FluidCooler.Populate(fcs)
         Dim fc As FluidCooler
         For Each f As FluidCooler In fclist
            If f.ModelName = model Then
               fc = f
            End If
         Next
         Return fc
      End Function

      Public Shared Function Populate(ByVal series As String, ByVal model As String) As FluidCooler
         Dim fcs As FluidCoolerSeries = FluidCoolerSeries.Populate(series)
         Dim fclist As Generic.List(Of FluidCooler) = FluidCooler.Populate(fcs)
         Dim fc As FluidCooler
         For Each f As FluidCooler In fclist
            If f.ModelNumber.ToString = model Then
               fc = f
            End If
         Next
         Return fc
      End Function

      Public Shared Function Populate(ByVal id As Integer, ByVal bool As Boolean) As Generic.List(Of FluidCooler)
         Dim fcs As FluidCoolerSeries = FluidCoolerSeries.Populate(id)
         Return Populate(fcs)
      End Function

      Public Shared Function Populate(ByVal fcs As FluidCoolerSeries) As Generic.List(Of FluidCooler)
         Dim coll As New Generic.List(Of FluidCooler)
         Dim dtb As DataTable = FluidCoolerDataAccess.RetrieveFluidCooler
         Dim dv As DataView = dtb.DefaultView
         dv.RowFilter = "FluidCoolerSeriesID = " & fcs.FluidCoolerSeriesID.ToString()
         If dv.Count > 0 Then
            For Each item As DataRowView In dv
               Dim fc As New FluidCooler(item.Row)
               fc.FluidCoolerSeries = fcs
               fc.Coils.Clear()
               Dim fcCoil As FluidCoolerCoil = FluidCoolerCoil.Populate(fc.FluidCoolerID)
               For i As Integer = 1 To fc.CoilQuantity
                  fc.Coils.Add(fcCoil)
               Next
               fc.FluidCoolerSeries = FluidCoolerSeries.Populate(CInt(dv.Item(0).Row("FluidCoolerSeriesID")))
               fc.Fans.Clear()
               Dim fcFan As FluidCoolerFan = FluidCoolerFan.Populate(fc.FluidCoolerSeries.FluidCoolerSeriesID, True)
               For i As Integer = 1 To fc.FluidCoolerSeries.FanQuantity
                  fc.Fans.Add(fcFan)
               Next
               'fc.SetFluidCoolerSeries(fcs)
               coll.Add(fc)
            Next
         End If
         Return coll
      End Function

   End Class
End Namespace