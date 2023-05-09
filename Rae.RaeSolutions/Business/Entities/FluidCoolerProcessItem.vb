Imports System.Data
Imports Rae.RaeSolutions.DataAccess.Projects

Namespace Rae.RaeSolutions.Business.Entities
   Public Class FluidCoolerProcessItem
      Inherits ProcessItem
      'Implements ICopyable(Of FluidCoolerProcessItem)
      'Implements ICloneable(Of FluidCoolerProcessItem)
      'Implements IEquatable(Of FluidCoolerProcessItem)

      Private dr As DataRow

      Public Sub New()
         Me.dr = Utility.BuildDataRow(Me)
         Me.dr.Table.Columns.Add(New DataColumn("ProcessID", System.Type.GetType("System.String")))
         Me.dr.Table.Columns.Add(New DataColumn("FluidCoolerXML", System.Type.GetType("System.String")))
         SetBase()
      End Sub

      Public Sub New(ByVal dr_ As DataRow)
         Me.dr = dr_
         SetBase()
      End Sub

      Public Sub New(ByVal iID As item_id)
         Me.dr = Utility.BuildDataRow(Me)
         Me.dr.Table.Columns.Add(New DataColumn("ProcessID", System.Type.GetType("System.String")))
         Me.dr.Table.Columns.Add(New DataColumn("FluidCoolerXML", System.Type.GetType("System.String")))
         Me.dr("ProcessID") = iID.Id
         SetBase()
      End Sub

      Private Sub SetBase()
         Me.initialize()
         If FluidCooler IsNot Nothing Then
            MyBase.Model = FluidCooler.ModelNumber.ToString
            MyBase.Series = FluidCooler.FluidCoolerSeries.ModelSeries
            ' MyBase.Name = Me.Names
            MyBase.name = dr("Name").ToString
         End If
         MyBase.Revision = CSng(Utility.NullSafe(dr("Revision"), Type.GetType("System.Single")))
      End Sub

      Public Overrides Property id() As item_id
         Get
            Return New item_id(CStr(Utility.NullSafe(dr("ProcessID"), Type.GetType("System.String"))))
         End Get
         Set(ByVal value As item_id)
            dr("ProcessID") = value.Id
            ' Me.base.Id = value
         End Set
      End Property

      'Public Property Name() As String
      '   Get
      '      Return CStr(Utility.NullSafe(dr("Name"), Type.GetType("System.String")))
      '   End Get
      '   Set(ByVal value As String)
      '      dr("Name") = value
      '   End Set
      'End Property

      Public Property FluidCooler() As FluidCooler
         Get
            Dim fc As FluidCooler = CType(Utility.Deserialize(dr("FluidCoolerXML").ToString(), Me.GetType().GetProperty("FluidCooler").PropertyType), FluidCooler)
            'MyBase.Model = fc.ModelNumber.ToString
            'MyBase.Series = fc.FluidCoolerSeries.ModelSeries
            Return fc
         End Get
         Set(ByVal value As FluidCooler)
            dr("FluidCoolerXML") = Utility.Serialize(value)
            MyBase.Model = value.ModelNumber.ToString
            MyBase.Series = value.FluidCoolerSeries.ModelSeries
         End Set
      End Property

      Public Property Altitude() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("Altitude"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("Altitude") = value
         End Set
      End Property

      Public Property Capacity() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("Capacity"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("Capacity") = value
         End Set
      End Property

      Public Property AmbientTemp() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("AmbientTemp"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("AmbientTemp") = value
         End Set
      End Property

      Public Property EnteringFluidTemp() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("EnteringFluidTemp"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("EnteringFluidTemp") = value
         End Set
      End Property

      Public Property LeavingFluidTemp() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("LeavingFluidTemp"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("LeavingFluidTemp") = value
         End Set
      End Property

      Public Property Fluid() As String
         Get
            Return CStr(Utility.NullSafe(dr("Fluid"), Type.GetType("System.String")))
         End Get
         Set(ByVal value As String)
            dr("Fluid") = value
         End Set
      End Property

      Public Property GlycolPercent() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("GlycolPercent"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("GlycolPercent") = value
         End Set
      End Property

      Public Property Flow() As Double
         Get
            Return CDbl(Utility.NullSafe(dr("Flow"), Type.GetType("System.Double")))
         End Get
         Set(ByVal value As Double)
            dr("Flow") = value
         End Set
      End Property

      '''' <summary>
      '''' Saves process item. Updates if revision already exists or creates if revision does not exist.
      '''' </summary>
      'Public Overrides Sub Save()
      '   FluidCoolerProcessItemDA.Save(Me)
      '   Me.OnSaved()
      'End Sub

      ''' <summary>
      ''' Loads condenser process based on ID. 
      ''' ID must be set before calling this method.
      ''' (Optionally revision can be set to pull specific revision.)
      ''' </summary>
      Public Overrides Sub Load()
         If Me.Revision > -1 Then
            Me.dr = FluidCoolerProcessItemDA.Populate(Me.id.Id, Me.Revision).Rows(0)
         Else
            Me.dr = FluidCoolerProcessItemDA.Populate(Me.id.Id).Rows(0)
         End If
      End Sub

      Public Shared Function Populate(ByVal id As String) As System.Collections.Generic.List(Of FluidCoolerProcessItem)
         Dim dtb As DataTable = FluidCoolerProcessItemDA.Populate(id)
         Dim coll As New System.Collections.Generic.List(Of FluidCoolerProcessItem)
         For Each dr As DataRow In dtb.Rows
            Dim fcpi As New FluidCoolerProcessItem(dr)
            If ProcessItemDA.GetProjectID(fcpi.id.Id) IsNot Nothing Then
               fcpi.ProjectManager = New project_manager(ProcessItemDA.GetProjectID(fcpi.id.Id))
            End If
            coll.Add(New FluidCoolerProcessItem(dr))
         Next
         Return coll
      End Function

      Public Shared Function PopulateLatest(ByVal id As String) As FluidCoolerProcessItem
         Dim dtb As DataTable = FluidCoolerProcessItemDA.Populate(id, True)
         If dtb.Rows.Count > 0 Then
            Return New FluidCoolerProcessItem(dtb.Rows(0))
         End If
         Return Nothing
      End Function

      Public Shared Function PopulateRevision(ByVal id As String, ByVal rev As Single) As FluidCoolerProcessItem
         Dim dtb As DataTable = FluidCoolerProcessItemDA.Populate(id, rev)
         If dtb.Rows.Count > 0 Then
            Return New FluidCoolerProcessItem(dtb.Rows(0))
         End If
         Return Nothing
      End Function

      ''' <summary>
      ''' Initializes objects. Prevents NullReference.
      ''' </summary>
      Protected Overrides Sub initialize()
         MyBase.initialize()
      End Sub


      Protected Overrides Sub Finalize()
         MyBase.Finalize()
      End Sub

   End Class
End Namespace