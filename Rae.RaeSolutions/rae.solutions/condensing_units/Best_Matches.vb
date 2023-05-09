Imports Rae.RaeSolutions.Business.Intelligence
Imports rae.solutions
Imports rae.solutions.compressors
Imports System.Math

namespace rae.solutions.condensing_units
'matches = best_matches.given(spec, at:=conditions)
    Public Class Best_Matches
        '    Friend userClass As user
        Public Structure Spec
            Public division As rae.RaeSolutions.Business.Division
            Public series, compressor_type As String
            Public compressor_quantity, num_circuits As Integer
            Public refrigerant As refrigerant
            Public capacity As Double
            Public DOEModels As String
        End Structure
        Public Structure Conditions
            Public ambient, suction, altitude As Double
            Public hertz, voltage As Integer
            Public catalog_rating As Boolean
        End Structure
        Class Selection
            Sub New(ByVal spec As Spec, ByVal unit As Condensing_Unit, ByVal point As Balance.Balance_Point, ByVal conditions As Conditions, ByVal constantReturnGasTemp As String)
                Me.unit = unit
                Me.balance_point = point
                Me.conditions = conditions
                Me.spec = spec
                Me.constantReturnGasTemp = constantReturnGasTemp
            End Sub
            Public spec As Spec
            Public unit As Condensing_Unit
            Public balance_point As Balance.Balance_Point
            Public conditions As Conditions
            Public constantReturnGasTemp As String
        End Class

        Sub New()
            condensing_units = New Repository()
            compressors = New compressor_repository()
        End Sub

        Function given(ByVal spec As Spec, ByVal at As Conditions, ByVal CondTempOverride As Boolean) As IList(Of Selection)
            Dim criteria = map(spec, at)
            Dim cus = condensing_units.get_units(criteria)  ' here

            Dim selections = determine_best_selections(cus, spec, at, CondTempOverride, False)

            ' selections = filter_unsafe_compressors(selections)



            Return selections
        End Function

        ReadOnly Property closest As Selection
            Get
                Return _closest
            End Get
        End Property

        ReadOnly Property above As Selection
            Get
                Return _above
            End Get
        End Property

        ReadOnly Property below As Selection
            Get
                Return _below
            End Get
        End Property


        Private _above, _below, _closest As Selection
        ' condenser capacity adjusted for unit quantity and run time
        Private cc As Double
        Private condensing_units As I_Repository
        Private compressors As i_compressor_repository
        Private at As Conditions

        Private Function filter_unsafe_compressors(ByVal selections As List(Of Selection)) As List(Of Selection)
            Dim filtered = New List(Of Selection)

            For Each selection In selections
                Dim compressorMasterID = selection.unit.circuits(0).compressorMasterID

                Dim compressor = compressors.get_compressor(compressorMasterID, selection.unit.refrigerant, selection.conditions.voltage, "Condenser", selection.constantReturnGasTemp)

                Dim condensingtemp = selection.balance_point.condensing_temp
                Dim suction = selection.conditions.suction



                If compressor.is_within_safety_limits(suction, condensingtemp) Then _
            filtered.Add(selection)
            Next

            Return filtered
        End Function





        Private Function finish_setting_conditions(ByVal conditions As Balance.Conditions, ByVal cu As Condensing_Unit, ByVal altitude As Double) As Balance.Conditions
            Dim fan_file = FanIntel.SelectStandardFile(cu.circuits(0).fanID, altitude, cu.circuits(0).hp, 1)
            conditions.fan_file_name_1 = fan_file
            conditions.hp_1 = cu.circuits(0).hp

            If cu.number_of_circuits > 1 Then
                fan_file = FanIntel.SelectStandardFile(cu.circuits(1).fanID, altitude, cu.circuits(1).hp, 1)
                conditions.fan_file_name_2 = fan_file
                conditions.hp_2 = cu.circuits(1).hp
            End If

            Return conditions
        End Function

        Private Function determine_best_selections(ByVal cus As IList(Of Condensing_Unit), ByVal spec As Spec, ByVal conditions_for_match As Conditions, ByVal CondTempOverride As Boolean, SuctionTempOverride As Boolean) As List(Of Selection)
            Dim selections = New List(Of Selection)

            Dim balance = New Balance(compressors)
            Dim conditions = map(conditions_for_match)

            For Each cu In cus

                If (Not SuctionTempOverride) AndAlso cu.SuctionIsInUnitLimits(CSng(conditions.suction)) Then

                    conditions = finish_setting_conditions(conditions, cu, conditions_for_match.altitude)

                    Dim result As Balance.Result = balance.this(cu, at:=conditions)


                    If Not result Is Nothing Then

                        Dim head_pressure_will_not_trip_sensor = New refrigerant_head_pressure_will_not_trip_sensor(cu.refrigerant, result.point.condensing_temp)
                        If head_pressure_will_not_trip_sensor.validate().is_valid Or CondTempOverride = True Then


                            If Not result Is Nothing Then
                                selections.Add(New Selection(spec, cu, result.point, conditions_for_match, cu.constantReturnGasTemp))
                            End If
                        Else
                            '  Beep()

                        End If
                    Else
                        '       Dim gh As Integer = 1
                    End If

                End If
            Next


            selections = filter_unsafe_compressors(selections)


            Dim closest As Selection
            For Each s In selections
                If s.balance_point.capacity > spec.capacity Then
                    If closest Is Nothing Then
                        closest = s
                    ElseIf (s.balance_point.capacity - spec.capacity) < (closest.balance_point.capacity - spec.capacity) Then
                        closest = s
                    End If
                End If
            Next

            Dim above As Selection
            For Each s In selections
                If s IsNot closest Then
                    Dim dif = s.balance_point.capacity - spec.capacity
                    If dif > 0 Then
                        If above Is Nothing Then
                            above = s
                        ElseIf dif < (above.balance_point.capacity - spec.capacity) Then
                            above = s
                        End If
                    End If
                End If
            Next

            Dim below As Selection
            For Each s In selections
                If s IsNot closest Then
                    Dim dif = s.balance_point.capacity - spec.capacity
                    If dif < 0 Then
                        If below Is Nothing Then
                            below = s
                        ElseIf dif > (below.balance_point.capacity - spec.capacity) Then
                            below = s
                        End If
                    End If
                End If
            Next

            _closest = closest
            _above = above
            _below = below

            Return selections
        End Function

        Private Function determine_compressor_quantity(ByVal compressor_qty As Integer, ByVal num_circuits As Integer) As String
            Dim s_d_m As String

            If compressor_qty > 0 And num_circuits > 0 Then
                If compressor_qty = 1 And num_circuits = 1 Then
                    s_d_m = "S"
                ElseIf compressor_qty = 2 And num_circuits = 1 Then
                    s_d_m = "D"
                ElseIf compressor_qty = 2 And num_circuits = 2 Then
                    s_d_m = "D"
                ElseIf compressor_qty > 2 And num_circuits >= 2 Then
                    s_d_m = "M"
                ElseIf compressor_qty = 3 And num_circuits = 1 Then
                    s_d_m = "M"
                Else
                    s_d_m = "ALL" 'Throw New Exception("The compressor quantity description cannot be determined.")
                End If
            Else
                s_d_m = "ALL"
            End If

            Return If(s_d_m = "ALL", Nothing, s_d_m)
        End Function

        Private Function map(ByVal best_spec As Best_Matches.Spec, ByVal conditions As Conditions) As Criteria
            Dim criteria As Criteria

            criteria.compressor_qty_description = determine_compressor_quantity(best_spec.compressor_quantity, best_spec.num_circuits)
            criteria.compressor_type = If(best_spec.compressor_type = "Best-optimized", Nothing, best_spec.compressor_type)
            criteria.division = best_spec.division
            criteria.refrigerant = best_spec.refrigerant
            criteria.series = best_spec.series
            criteria.suction_temp = conditions.suction
            criteria.DOEModels = best_spec.DOEModels

            Return criteria
        End Function

        ' TODO: could use same conditions type for balance and best condensing units
        Private Function map(ByVal best_conditions As Conditions) As Balance.Conditions
            Dim balance_conditions As Balance.Conditions

            balance_conditions.altitude = best_conditions.altitude
            balance_conditions.ambient = best_conditions.ambient
            balance_conditions.catalog_rating = best_conditions.catalog_rating
            balance_conditions.hertz = best_conditions.hertz
            balance_conditions.suction = best_conditions.suction
            balance_conditions.voltage = best_conditions.voltage

            Return balance_conditions
        End Function

    End Class

end namespace