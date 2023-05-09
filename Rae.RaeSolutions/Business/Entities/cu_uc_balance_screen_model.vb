Imports UnitCoolerProcessDa = Rae.RaeSolutions.DataAccess.Projects.UnitCoolerProcessDA
Imports System.Collections.Generic


Namespace Rae.RaeSolutions.Business.Entities

    Public Class cu_uc_balance_screen_model : Inherits ProcessItem

        Public Structure UnitCooler
            Public model As String
            Public capacity As Double
            Public quantity As Integer
            Public capacity_per_degree As Double
            Public static_pressure As Double
        End Structure

        Public Class unit_cooler_list : Inherits list(Of UnitCooler)
            Sub New()
                MyBase.new()
            End Sub

            Sub New(other As unit_cooler_list)
                MyBase.new(other)
            End Sub

            Overrides Function Equals(obj As Object) As Boolean
                Dim other = CType(obj, unit_cooler_list)

                If count <> other.count Then Return False

                For i = 0 To count - 1
                    If Me(i).model = other(i).model _
                    AndAlso Me(i).capacity = other(i).capacity _
                    AndAlso Me(i).capacity_per_degree = other(i).capacity_per_degree _
                    AndAlso Me(i).quantity = other(i).quantity _
                    AndAlso Me(i).static_pressure = other(i).static_pressure Then
                        ' equal so far  
                    Else
                        Return False
                    End If
                Next
                Return True
            End Function
        End Class

        Public Structure results_for_pricing_conversion
            Public evaporating_temperature, suction, condensing_temperature, td, capacity As Double
        End Structure


        ''' <summary>
        ''' Constructs a balance process that already exists in the data source based on the ID.
        ''' Automatically loads the process from the data source.
        ''' </summary>
        Sub New(id As item_id)
            Me.initialize()
            Me.id = id
        End Sub

        ''' <summary>
        ''' Constructs a balance process that already exists in the data source based on the ID.
        ''' Automatically loads the process from the data source.
        ''' </summary>
        Sub New(id As item_id, revision As Integer)
            Me.initialize()
            Me.id = id
            Me.revision = revision
        End Sub

        ''' <summary>
        ''' Constructs a new balance process with the specified name.
        ''' Generates a new ID.
        ''' </summary>
        ''' <param name="parent">Parent project manager that process should be included in.</param>
        Sub New(name As String, username As String, password As String, parent As project_manager)
            Me.initialize()
            Me.name = name
            Me.id = New item_id(username, password)
            Me.ProjectManager = parent
        End Sub


        ''' <summary>
        ''' Constructs a new balance process with the specified name.
        ''' Used when making a clone.
        ''' </summary>
        Sub New(name As String, id As item_id)
            Me.initialize()
            Me.name = name
            Me.id = id
        End Sub

        ''' <summary>Constructs a balance process based on the unit cooler pricing parameter</summary>
        Sub New(unit_cooler As unit_cooler)
            Me.new(unit_cooler.name, unit_cooler.id.Username, unit_cooler.id.Password, unit_cooler.ProjectManager)
            Me.initialize()

            Static equipFlag As Boolean = False

            Me.Series = unit_cooler.series
            Me.Model = Me.Series + unit_cooler.model_without_series

            Me.refrigerant = unit_cooler.refrigerant
            If unit_cooler.common_specs.Altitude.has_value Then
                Me.altitude = unit_cooler.common_specs.Altitude.value
            End If

            'prevent null ref
            If equipFlag = False Then
                Me.Equipment = New EquipmentItemList
                equipFlag = True
            End If

            ' associate equipment w/ process
            Me.Equipment.Add(unit_cooler)

            'write out the data table?
            Rae.RaeSolutions.DataAccess.Projects.ProcessEquipDA.Create(Me.id.ToString, unit_cooler.id.ToString)
        End Sub


#Region " Properties"

        Property condensing_unit_series As String
        Property condensing_unit_model As String
        Property condensing_unit_quantity As Integer

        Property capacity_required As Double
        Property condenser_capacity_per_degree As Double
        Property capacity_is_adjusted_for_runtime As Boolean
        Property run_time_hours_per_day As Double
        ''' <summary>0 = 'ALL', which means don't filter by number of compressors per unit.</summary>
        Property compressor_quantity_per_unit As Integer
        Property compressor_type As String
        Property refrigerant As String
        ''' <summary>0 = 'ALL' which means don't filter condensing unit results based on number of circuits per unit (return all).</summary>
        Property refrigerant_circuits_per_unit As Integer
        Property altitude As Double
        Property suction As Double

        Property ambient As Double
        Property min_ambient As Double
        Property max_ambient As Double
        Property ambient_increment As Double

        Property rooms As Double
        Property room_temperature As Double
        Property min_room_temperature As Double
        Property max_room_temperature As Double
        Property room_temperature_increment As Double


        Property unit_cooler_series As String
        Property suction_line_loss As Double
        Property do_not_filter_unit_coolers_based_on_capacity As Boolean
        Property selected_unit_cooler_index As Integer
        Property selected_unit_coolers As unit_cooler_list
        Property custom_unit_cooler_is_selected As Boolean
        ''' <summary>balance of condensing unit(s) and unit cooler(s) in btuh</summary>
        Property balance As Double


        Property DOEModel As String

        Public CustomUnitCooler As UnitCooler
        Public results As results_for_pricing_conversion
        Private Equipment As EquipmentItemList


#Region " Unused"
        Private m_CustomCondensingUnit As String
        Property CustomCondensingUnit As String
            Get
                Return m_CustomCondensingUnit
            End Get
            Set(value As String)
                m_CustomCondensingUnit = value
            End Set
        End Property
#End Region

#End Region


        ''' <summary>
        ''' Loads UnitCooler process based on ID. 
        ''' ID must be set before calling this method.
        ''' (Optionally revision can be set to pull specific revision.)
        ''' </summary>
        Overrides Sub Load()
            Dim process As cu_uc_balance_screen_model
            If Revision > -1 Then
                process = UnitCoolerProcessDa.Retrieve(id, Revision)
            Else
                process = UnitCoolerProcessDa.Retrieve(id)
            End If
            Copy(process)
        End Sub

        Overrides Function Clone(Optional newId As Boolean = False) As Object
            Dim _clone = CType(MyBase.Clone(newId), cu_uc_balance_screen_model)
            _clone.CustomUnitCooler.capacity = CustomUnitCooler.capacity
            _clone.CustomUnitCooler.capacity_per_degree = CustomUnitCooler.capacity_per_degree
            _clone.CustomUnitCooler.model = CustomUnitCooler.model
            _clone.CustomUnitCooler.quantity = CustomUnitCooler.quantity
            _clone.selected_unit_coolers = New unit_cooler_list(selected_unit_coolers)
            Return _clone
        End Function



        Protected Overrides Sub initialize()
            MyBase.initialize()
            selected_unit_coolers = New unit_cooler_list
        End Sub

    End Class
End Namespace