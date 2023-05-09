Imports System
Imports Rae.RaeSolutions.DataAccess.Projects
Imports Rae.solutions.unit_coolers
Imports CNull = Rae.ConvertNull

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>Unit cooler equipment item.</summary>
    Public Class unit_cooler
        Inherits EquipmentItem
        Implements ICloneable(Of unit_cooler)
        Implements ICopyable(Of unit_cooler)
        Implements IEquatable(Of unit_cooler)


        ''' <summary>Constructs unit cooler equipment item with a new ID.</summary>
        Sub New(ByVal name As String, ByVal division As Division, _
        ByVal author As String, ByVal password As String, ByVal parent As project_manager)
            MyBase.New(name, division, EquipmentType.UnitCooler, author, password, parent)
        End Sub

        ''' <summary>Constructs condensing unit equipment item for an existing ID that hasn't been saved to a data source.</summary>
        Sub New(ByVal name As String, ByVal division As Division, _
        ByVal id As item_id, ByVal parent As project_manager)
            MyBase.New(name, division, EquipmentType.UnitCooler, id, parent)
        End Sub

        Sub New(ByVal balance As cu_uc_balance_screen_model, ByVal unit_cooler As cu_uc_balance_screen_model.UnitCooler, ByVal name As String)
            MyBase.New(name, _
               balance.Division, _
               EquipmentType.UnitCooler, _
               New item_id(balance.id.Username, balance.id.Password), _
               balance.ProjectManager)



            Dim firstNum As Integer
            For i As Integer = 0 To unit_cooler.model.Length - 1
                If IsNumeric(unit_cooler.model.Substring(i, 1)) Then
                    firstNum = i
                    Exit For
                End If
            Next

            Me.series = unit_cooler.model.Substring(0, firstNum)

            Dim firstDash As Integer = unit_cooler.model.IndexOf("-")
            Dim lp As String = unit_cooler.model.Substring(Me.series.Length, firstDash - Me.series.Length)
            Dim rp As String = unit_cooler.model.Substring(firstDash)

            If IsNumeric(lp.Substring(lp.Length - 1)) Then
                Me.refrigerant = lp.Substring(lp.Length - 1)
                Me.model_without_series = lp.Substring(0, lp.Length - 1) & "0" & rp
            Else
                Me.refrigerant = lp.Substring(lp.Length - 2)
                Me.model_without_series = lp.Substring(0, lp.Length - 2) & "0" & rp
            End If





            Dim split = unit_cooler.model.Split(" "c)

            '  Dim refrigerant_index = If(series.StartsWith("F"), 1, 2)
            ' Me.model_without_series = split(1).remove(refrigerant_index, 1).insert(refrigerant_index, "0") '& "A"



            Me.refrigerant = balance.refrigerant
            Me.common_specs.Altitude.value = balance.altitude
            Me.pricing.quantity = unit_cooler.quantity

            Me.condensing_temperature.set_to(balance.results.condensing_temperature)
            Me.box_temperature.set_to(balance.room_temperature)
            Me.evaporator_temperature.set_to(balance.results.evaporating_temperature)
            Me.temperature_difference.set_to(balance.results.td)
            Me.capacity.set_to(System.Math.Round((balance.results.capacity / unit_cooler.quantity) * balance.condensing_unit_quantity))

            ' associate equipment w/ process
            Me.processes.Add(balance)
            Rae.RaeSolutions.DataAccess.Projects.ProcessEquipDA.Create(balance.id.ToString, Me.id.ToString)
        End Sub

        Overrides ReadOnly Property model As String
            Get
                Return series & model_without_series
            End Get
        End Property

        Function model_with_refrigerant() As String
            Return New model_with_refrigerant(model, refrigerant).to_string
        End Function

        Property liquid_line_connection_quantity As nullable_integer
        Property capacity As nullable_double
        Property evaporator_temperature As nullable_double
        Property box_temperature As nullable_double
        Property temperature_difference As nullable_double
        Property condensing_temperature As nullable_double
        Property liquid_temperature As nullable_double
        Property refrigerant As String
        Property fan_voltage As VoltageRating
        Property defrost_voltage As VoltageRating
        Property fan_quantity As Integer
        Property unit_cooler_type As String

        Property coilLength As Double = 0
        Property coilHeight As Double = 0
        Property CFM As Double = 0

        Function FaceVelocity() As Double
            If CFM > 0 AndAlso coilHeight > 0 AndAlso coilLength > 0 Then
                Return CFM / ((coilHeight / 12) * (coilLength / 12))
            End If
        End Function




        ''' <summary>Saves unit cooler to data source.</summary>
        Overrides Sub Save()
            If EquipmentDa.Exists(id.Id, revision) = ExistenceStatus.Existent Then
                UnitCoolerEquipmentItemDa.Update(Me)
            Else
                UnitCoolerEquipmentItemDa.Create(Me)
            End If
            MyBase.onSaved()
        End Sub

        ''' <summary>Loads unit cooler from data source.</summary>
        Overrides Sub Load()
            Me.Copy(UnitCoolerEquipmentItemDa.Retrieve(Me.id.Id, Me.revision))
        End Sub


        ''' <summary>Compares unit coolers; returns true if unit coolers have the same values.</summary>
        Shadows Function Equals(ByVal other As unit_cooler) As Boolean _
        Implements iequatable(Of unit_cooler).equals
            If Not is_equal_to(other) Then Return False

            If Me.box_temperature.equals(other.box_temperature) _
            AndAlso capacity.equals(other.capacity) _
            AndAlso condensing_temperature.equals(other.condensing_temperature) _
            AndAlso evaporator_temperature.equals(other.evaporator_temperature) _
            AndAlso liquid_temperature.equals(other.liquid_temperature) _
            AndAlso refrigerant = other.refrigerant _
            AndAlso temperature_difference.equals(other.temperature_difference) _
            AndAlso fan_voltage.equals(other.fan_voltage) _
            AndAlso defrost_voltage.equals(other.defrost_voltage) _
            AndAlso fan_quantity = other.fan_quantity _
            AndAlso unit_cooler_type = other.unit_cooler_type Then
                Return True
            Else
                Return False
            End If
        End Function

        Shadows Function Clone() As unit_cooler _
        Implements ICloneable(Of unit_cooler).Clone
            Dim _clone = New unit_cooler(name, division, New item_id(id.ToString), _
                        ProjectManager)

            _clone.copy_base(Me)

            _clone.box_temperature = box_temperature.Clone()
            _clone.Capacity = capacity.Clone
            _clone.condensing_temperature = condensing_temperature.Clone()
            _clone.evaporator_temperature = evaporator_temperature.Clone()
            _clone.liquid_temperature = liquid_temperature.Clone()
            _clone.refrigerant = refrigerant
            _clone.temperature_difference = temperature_difference.Clone()
            _clone.fan_voltage = fan_voltage.Clone
            _clone.defrost_voltage = defrost_voltage.Clone
            _clone.fan_quantity = fan_quantity
            _clone.unit_cooler_type = unit_cooler_type

            If Not _clone.series Is Nothing Then

                '    If _clone.series = "A" Then _clone.series = "AWSM" : _clone.ForceSave = True
                If _clone.series = "FH" Then _clone.series = "UFH" : _clone.ForceSave = True

                If Not _clone.model.Contains("L-") AndAlso Not _clone.model.Contains("M-") Then

                    _clone.ForceSave = True
                    Dim suction As Double = _clone.evaporator_temperature.value_or_default
                    Dim tempIndicator As String



                    If _clone.model.StartsWith("A") AndAlso Not _clone.model.StartsWith("AWSM") Then
                    Else
                        Dim message As String = "The Unit Cooler model saved in this project is no longer available." & vbCrLf & "We recommend a low temperature model for evaporator" & vbCrLf & " temperatures below zero and a medium temperature model" & vbCrLf & "for temperatures above 0." & vbCrLf & "Please contact your sales manager if you have any questions. "
                        message &= vbCrLf & vbCrLf
                        message &= "Current Evaporator Temperature: " & suction
                        message &= vbCrLf & vbCrLf
                        message &= "Old Model: " & _clone.model
                        message &= vbCrLf & vbCrLf
                        message &= "Please choose below"


                        Dim myDialog As New UCTADialog
                        myDialog.setText(message)
                        myDialog.ShowDialog()

                        If myDialog.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            tempIndicator = "L"
                        ElseIf myDialog.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                            tempIndicator = "M"
                        End If


                    End If


                    '  _clone.model_without_series = "540-925M-HG"

                    Dim defrostType As String = _clone.model_without_series.Substring(_clone.model_without_series.Length - 1)
                    If defrostType = "G" Then defrostType = "HG"

                    _clone.model_without_series = _clone.model_without_series.Substring(0, Len(_clone.model_without_series) - Len(defrostType))
                    If _clone.model_without_series.EndsWith("-") Then _clone.model_without_series = _clone.model_without_series.Substring(0, _clone.model_without_series.Length - 1)


                    '_clone.name = _clone.model

                    If _clone.model.StartsWith("A") AndAlso Not _clone.model.StartsWith("AWSM") Then
                        _clone.model_without_series &= "-" & defrostType
                    Else
                        _clone.model_without_series &= tempIndicator & "-" & defrostType
                    End If



                End If


                End If




            Return _clone
        End Function

        ''' <summary>Copies another unit cooler's values into this unit cooler.</summary>
        ''' <param name="other">Other unit cooler to copy values from.</param>
        Sub Copy(ByVal other As unit_cooler) _
        Implements ICopyable(Of unit_cooler).Copy
            copy_base(other)

            box_temperature = other.box_temperature.Clone
            capacity = other.capacity.Clone
            condensing_temperature = other.condensing_temperature.Clone()
            evaporator_temperature = other.evaporator_temperature.Clone()
            liquid_temperature = other.liquid_temperature.Clone()
            refrigerant = other.refrigerant
            temperature_difference = other.temperature_difference.Clone()
            fan_voltage = other.fan_voltage.Clone
            defrost_voltage = other.defrost_voltage.Clone
            fan_quantity = other.fan_quantity
            unit_cooler_type = other.unit_cooler_type
        End Sub


        Private processes As New ProcessItemList

        ' This method is called by its parent class
        Protected Overrides Sub initialize()
            MyBase.initialize()
            liquid_line_connection_quantity = New nullable_integer()
            capacity = New nullable_double
            evaporator_temperature = New nullable_double
            box_temperature = New nullable_double
            temperature_difference = New nullable_double
            condensing_temperature = New nullable_double
            liquid_temperature = New nullable_double
            fan_voltage = New VoltageRating
            defrost_voltage = New VoltageRating
        End Sub

    End Class

End Namespace