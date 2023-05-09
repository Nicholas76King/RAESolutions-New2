Option Strict Off

Imports System
Imports rae.RaeSolutions.DataAccess.Projects

Namespace Rae.RaeSolutions.Business.Entities

    Public Class chiller_equipment
        Inherits EquipmentItem
        Implements ICopyable(Of chiller_equipment)
        Implements ICloneable(Of chiller_equipment)
        Implements IEquatable(Of chiller_equipment)

        ''' <summary>Constructs equipment with new ID.</summary>
        Sub New(ByVal name As String, ByVal division As Division, _
        ByVal author As String, ByVal password As String, ByVal parent As project_manager)
            MyBase.New(name, division, EquipmentType.Chiller, author, password, parent)
        End Sub

        ''' <summary>Constructs equipment with existing ID.</summary>
        Sub New(ByVal name As String, ByVal division As Division, _
        ByVal id As item_id, ByVal parent As project_manager)
            MyBase.New(name, division, EquipmentType.Chiller, id, parent)
        End Sub

        ''' <summary>Constructs equipment from process. Converts process to equipment.</summary>
        ''' <param name="balance">Chiller balance to convert</param>
        ''' <param name="equipment_name">Equipment name</param>
        Sub New(ByVal balance As Object, ByVal equipment_name As String)
            MyBase.New(equipment_name, _
               balance.Division, _
               EquipmentType.Chiller, _
               New item_id(balance.Id.Username, balance.Id.Password), _
               balance.ProjectManager)

            series = balance.Model.ToString.Substring(0, 6)
            model_without_series = balance.Model.ToString.Substring(6)

            Specs.AmbientTemp.value = balance.AmbientTemp
            ' removes low, high and medium temperature indicators from refrigerant
            Specs.Refrigerant = balance.Refrigerant.ToString.Trim(New Char() {"H"c, "L"c, "M"c})
            ' removes dash
            Specs.Refrigerant = Me.Specs.Refrigerant.Replace("-", "")

            If balance.Fluid = "Water" Then
                Me.Specs.Fluid = balance.Fluid
            ElseIf balance.Fluid = "Glycol" Then
                Me.Specs.Fluid = balance.CoolingMedia
            End If

            Specs.LeavingFluidTemp.value = balance.LeavingFluidTemp
            Specs.GlycolPercent.value = balance.GlycolPercentage

            common_specs.Altitude.value = balance.Altitude
            custom_model = balance.ModelDesc

            Specs.Capacity.set_to(System.Math.Round(balance.CapacityAtDesignConditions, 1))
            Specs.EvaporatorPressureDrop.set_to(System.Math.Round(balance.EvaporatorPressureDropAtDesignConditions, 2))
            Specs.Flow.set_to(System.Math.Round(balance.FlowAtDesignConditions))

            Specs.EnteringFluidTemp.set_to(Specs.LeavingFluidTemp.value + balance.TempRange)

            Dim voltage = balance.volts
            Dim hertz = balance.hertz
            common_specs.UnitVoltage.Voltage.set_to(voltage)
            common_specs.UnitVoltage.Hertz.set_to(hertz)
            common_specs.UnitVoltage.Phase.set_to(3)

            If series.StartsWith("35E2") Then
                has_balance = True
                balance_data = get_balance_data(CType(balance, EvaporativeCondenserChillerBalance))

                specs.unit_kw_per_ton = balance.unit_kw_per_ton_at_design_conditions

                If balance.subcooling_coil_option_selected Then
                    Dim subcooling_coil_option = Rae.RaeSolutions.DataAccess.Projects.EquipmentOptionsDa.Get_option(series, model_without_series, voltage, "ME16", 0)
                    subcooling_coil_option.selected = True
                    options.add(subcooling_coil_option)
                End If

                If balance.sound_attenuation_option_selected Then
                    Dim inlet_sound_attenuation_option = Rae.RaeSolutions.DataAccess.Projects.EquipmentOptionsDa.Get_option(series, model_without_series, voltage, "MA06", 0)
                    Dim outlet_sound_attenuation_option = Rae.RaeSolutions.DataAccess.Projects.EquipmentOptionsDa.Get_option(series, model_without_series, voltage, "MA07", 0)
                    options.add(inlet_sound_attenuation_option)
                    options.add(outlet_sound_attenuation_option)
                End If
            End If


            'If series.StartsWith("30A2") Then
            '    ' NEW CODE, NOT TESTED

            '    has_balance = True
            '    balance_data = get_balance_data(CType(balance, ACChillerProcessItem))

            '    '  Specs.unit_kw_per_ton = balance.unit_kw_per_ton_at_design_conditions
            'End If

            Dim info = New ChillerInfo(model)
            common_specs.OperatingWeight.set_to(info.OperatingWeight)
            common_specs.ShippingWeight.set_to(info.ShippingWeight)
            common_specs.Height.set_to(info.Height)
            common_specs.Width.set_to(info.Width)
            common_specs.Length.set_to(info.Length)

            ' associate equipment w/ process
            Me.processes.Add(balance)
            'link process and equipment in a database table
            Rae.RaeSolutions.DataAccess.Projects.ProcessEquipDA.Create(balance.Id.ToString, Me.id.ToString)
        End Sub

        Private Function get_balance_data(ByVal balance As EvaporativeCondenserChillerBalance) As balance_data
            Dim data As balance_data

            Dim compressor_repository = New rae.solutions.compressors.compressor_repository()
            Dim voltage = common_specs.UnitVoltage.Voltage.value_or_default
            Dim phase = common_specs.UnitVoltage.Phase.value_or_default
            Dim hertz = common_specs.UnitVoltage.Hertz.value_or_default
            Dim unit_type = "EvaporativeCondenserChiller"

            data.compressor_amps_1 = compressor_repository.get_compressor_amps( _
               balance.compressor_file_name_1, unit_type, voltage, phase, hertz, "TSI")
            data.compressor_quantity_1 = balance.NumCompressors1
            data.compressor_amps_2 = compressor_repository.get_compressor_amps( _
               balance.compressor_file_name_2, unit_type, voltage, phase, hertz, "TSI")
            data.compressor_quantity_2 = balance.NumCompressors2

            Dim motor_repository = New rae.solutions.motors.repository()
            data.spray_pump_amps = motor_repository.get_amps(balance.pump_motor_hp, voltage)
            data.blower_amps = motor_repository.get_amps(balance.fan_motor_hp, voltage)
            data.condenser_quantity = balance.NumCoils1

            Return data
        End Function


        Private Function get_balance_data(ByVal balance As ACChillerProcessItem) As balance_data
            Dim data As balance_data

            Dim compressor_repository = New Rae.solutions.compressors.compressor_repository()
            Dim voltage = common_specs.UnitVoltage.Voltage.value_or_default
            Dim phase = common_specs.UnitVoltage.Phase.value_or_default
            Dim hertz = common_specs.UnitVoltage.Hertz.value_or_default
            Dim unit_type = "AirCooledChiller"

            data.compressor_amps_1 = compressor_repository.get_compressor_amps(balance.Compressors1, unit_type, voltage, phase, hertz, "TSI")
            data.compressor_quantity_1 = balance.NumCompressors1
            data.compressor_amps_2 = compressor_repository.get_compressor_amps(balance.Compressors2, unit_type, voltage, phase, hertz, "TSI")
            data.compressor_quantity_2 = balance.NumCompressors2

            Dim motor_repository = New Rae.solutions.motors.repository()
            'data.spray_pump_amps = motor_repository.get_amps(balance.pump_motor_hp, voltage)
            'data.blower_amps = motor_repository.get_amps(balance.fan_motor_hp, voltage)
            data.condenser_quantity = balance.NumCoils1

            Return data
        End Function



        '


        Public has_balance As Boolean
        Public balance_data As balance_data

        Property Specs As chiller_specifications
            Get
                Return _specs
            End Get
            Set(ByVal value As chiller_specifications)
                _specs = value
            End Set
        End Property

        Function Add(ByVal pumpPackage As PumpEquipment) As PumpEquipment
            _pumpPackage = pumpPackage
            _pumpPackage.ChillerId = id
            Return _pumpPackage
        End Function

        Sub remove_pump_package()
            _pumpPackage = Nothing
        End Sub

        Function has_pump_package() As Boolean
            Return (_pumpPackage IsNot Nothing)
        End Function

        ReadOnly Property pump_package As PumpEquipment
            Get
                Return _pumpPackage
            End Get
        End Property


        ''' <summary>Loads this equipment from the data source based on the ID.</summary>
        Overrides Sub Load()
            Me.Copy(ChillerEquipmentDa.Retrieve(Me.id.Id, Me.revision))
        End Sub

        ''' <summary>Saves equipment to data source.</summary>
        Overrides Sub Save()
            If exists_in_data_source = ExistenceStatus.Existent Then
                ChillerEquipmentDa.Update(Me)
            Else
                ChillerEquipmentDa.Create(Me)
            End If
            MyBase.onSaved()
        End Sub


        ''' <summary>Compares equality of chillers.</summary>
        Shadows Function Equals(ByVal other As chiller_equipment) As Boolean _
        Implements IEquatable(Of chiller_equipment).Equals
            If Not is_equal_to(other) Then Return False

            If Specs.Equals(other.Specs) _
            AndAlso has_balance = other.has_balance _
            AndAlso balance_data.equals(other.balance_data) Then
                If has_pump_package Then
                    If other.has_pump_package Then
                        Return pump_package.Equals(other.pump_package)
                    Else
                        Return False
                    End If
                Else
                    Return Not other.has_pump_package 'true
                End If
            Else
                Return False
            End If
        End Function

        ''' <summary>Clones chiller.</summary>
        ''' <remarks>Use shadows so this will get called and not the unimplemented Clone method in the EquipmentItem base class.</remarks>
        Shadows Function Clone() As chiller_equipment _
        Implements ICloneable(Of chiller_equipment).Clone
            Dim theClone As New chiller_equipment(name, division, New item_id(id.ToString), _
               Me.ProjectManager)

            theClone.copy_base(Me)
            theClone.Specs = Me.Specs.Clone
            theClone.has_balance = has_balance
            theClone.balance_data = balance_data
            If has_pump_package Then
                theClone.Add(_pumpPackage.Clone)
            Else
                theClone.remove_pump_package()
            End If

            Return theClone
        End Function

        ''' <summary>Copies another chiller.</summary>
        Sub Copy(ByVal other As chiller_equipment) _
        Implements ICopyable(Of chiller_equipment).Copy
            copy_base(other)
            Specs = other.Specs.Clone
            has_balance = other.has_balance
            balance_data = other.balance_data
            If other.has_pump_package Then
                _pumpPackage = other.pump_package.Clone
            Else
                remove_pump_package()
            End If
        End Sub

        Private _specs As chiller_specifications
        Private processes As New ProcessItemList
        Private _pumpPackage As PumpEquipment

        ''' <summary>This overriding method is called by its parent class.</summary>
        Protected Overrides Sub initialize()
            MyBase.initialize()
            _specs = New chiller_specifications
        End Sub

    End Class

    Public Structure balance_data
        Public compressor_amps_1, compressor_quantity_1 As Double
        Public compressor_amps_2, compressor_quantity_2 As Double
        Public spray_pump_amps, blower_amps, condenser_quantity As Double

        Sub clear()
            compressor_amps_1 = 0 : compressor_quantity_1 = 0
            compressor_amps_2 = 0 : compressor_quantity_2 = 0
            spray_pump_amps = 0 : blower_amps = 0 : condenser_quantity = 0
        End Sub

        Function equals(ByVal other As balance_data) As Boolean
            Return rae.reflection.domain.are_equal(Me, other)
        End Function
    End Structure

End Namespace