Option Strict Off

Imports System.Collections.Generic
Imports System.Math
Imports Rae.BuzzDllInterface
Imports RAE.RaeSolutions



Namespace Rae.RaeSolutions.Business.Entities.Cofans

    Public Class cofan

        Public row_qty As Double


        Public Function GetFanPower(ByVal fan_file As String, ByVal sp As Decimal, ByVal OperatingRPM As Decimal, ByVal CurveRPM As Decimal) As Decimal
            Dim f As List(Of Double)
            Dim repo = New cofan_repository()


            If Mid(fan_file, 1, 8) = "OVERRIDE" Then
                Return 0
            Else
                f = repo.get_fan_curves(fan_file)
            End If


            Dim rpmFact As Decimal = 1

            If CurveRPM <> 0 Then
                rpmFact = OperatingRPM / CurveRPM
            End If


            Return (f(5) + f(6) * sp ^ 4 + f(7) * sp ^ 3 + f(8) * sp ^ 2 + f(9) * sp) * (rpmFact ^ 3)


        End Function


        Function balance(ByVal spec As specification) As List(Of result)
            Dim repo = New cofan_repository()
            Dim calc = New calculator()

            Dim esp = spec.esp
            Dim td = 1

            Dim cfm_act As Double

            Dim f As List(Of Double)
            Dim fan_file = spec.fan_file
            If Mid(fan_file, 1, 8) = "OVERRIDE" Then
            Else
                f = repo.get_fan_curves(fan_file)

            End If

            Dim coil As coil = repo.get_coil(spec.coil_file)

            Dim rpmFact As Decimal = 1

            If spec.fanCurveRPM <> 0 Then
                rpmFact = spec.fanOperatingRPM / spec.fanCurveRPM
            End If


            row_qty = coil.row_qty

            Dim area = spec.FinHeight * spec.FinLength / 144

            Dim temperature_correction = calc.temperature_correction()
            Dim altitude_correction = calc.altitude_correction(spec.altitude)

            Dim fv As Double ' face velocity
            Dim fan_sp As Double ' fan static pressure
            Dim results = New List(Of result)

            For Each at_fpi In coil.at_fpi
                For fan_sp = 0.1 To 1.5 Step 0.01
                    fan_sp = fan_sp + esp

                    If Mid(fan_file, 1, 8) = "OVERRIDE" Then
                        cfm_act = Val(Mid(fan_file, 9, 10))
                    Else
                        cfm_act = (f(0) + f(1) * fan_sp ^ 4 + f(2) * fan_sp ^ 3 + f(3) * fan_sp ^ 2 + f(4) * fan_sp) * rpmFact ' same for all fpi



                    End If

                    fv = spec.fan_quantity * cfm_act / area
                    fan_sp = fan_sp - esp

                    Dim coil_sp = calc.coil_static_pressure(fv, coil.p, at_fpi.p)

                    If fan_sp > coil_sp Then _
                       Exit For
                Next fan_sp

                Dim cfm_std = cfm_act * temperature_correction * altitude_correction * spec.fan_quantity
                Dim fv_std = cfm_std / area

                Dim capacity = calc.capacity(at_fpi.f, fv_std)
                capacity = capacity * 1.08 * cfm_std * td

                fan_sp = fan_sp + esp


                Dim hp As Double

                If Mid(fan_file, 1, 8) = "OVERRIDE" Then
                    hp = 0
                Else
                    hp = (f(5) + f(6) * fan_sp ^ 4 + f(7) * fan_sp ^ 3 + f(8) * fan_sp ^ 2 + f(9) * fan_sp) * (rpmFact ^ 3)

                End If

                Dim btu_sqft = capacity / area
                cfm_act = cfm_act * spec.fan_quantity



                If Not (spec.tubeSurface Is Nothing) AndAlso spec.tubeSurface.ToLower = "rifled" Then
                    capacity = capacity * (0.00003101 * fv + 1.06075146)
                End If



                Dim result As result
                result.fpi = at_fpi.fpi
                result.capacity = Round(capacity)
                result.face_velocity = Round(fv)
                result.static_pressure = Round(fan_sp, 2)
                result.hp = Round(hp, 2)
                result.cfm_actual = Round(cfm_act)
                result.cfm_standard = Round(cfm_std)
                result.btuh_sqft = Round(btu_sqft)

                results.Add(result)
            Next

            Return results
        End Function

        Structure specification
            Public coil_file, fan_file As String
            Public fanOperatingRPM As Decimal
            Public fanCurveRPM As Decimal
            Public DataPath As String
            Public altitude, fan_quantity, FinHeight, FinLength As Double
            ''' <summary>external static pressure</summary>
            Public esp As Double

            Public TubeDiameter As Decimal
            Public FPI As Integer
            Public Rows As Integer
            Public UseDLLForPerformance As Boolean


            Public CondFeeds As Integer
            Public CondPasses As Integer
            Public SubCoolerFeeds As Integer
            Public SubCoolerPasses As Integer
            Public FinSurface As String
            Public FinMaterial As String
            Public FinThickness As Decimal
            Public tubeSurface As String
            Public TubeMaterial As String
            Public TubeThickness As String

        End Structure

        Structure result
            Public capacity, btuh_sqft, cfm_actual, cfm_standard, face_velocity As Double
            Public fpi, hp, static_pressure, num_rows As Double
        End Structure

        Private Class calculator
            Function altitude_correction(ByVal a As Double) As Double
                Dim c0 = 2.60087E-18
                Dim c1 = 0.0000000000000312094
                Dim c2 = 0.000000000385576
                Dim c3 = 0.0000358752
                altitude_correction = 1 - c0 * a ^ 4 + c1 * a ^ 3 + c2 * a ^ 2 - c3 * a
            End Function

            Function temperature_correction() As Double
                Dim ambient_temperature = 95 ' per frank pukett 2/1/2002
                Dim room_temperature = 70
                room_temperature = room_temperature + 460
                ambient_temperature = ambient_temperature + 460
                temperature_correction = room_temperature / ambient_temperature
            End Function

            Function capacity(ByVal f() As Double, ByVal fv As Double) As Double
                capacity = f(0) + f(1) * fv ^ 4 + f(2) * fv ^ 3 + f(3) * fv ^ 2 + f(4) * fv
            End Function

            Function coil_static_pressure(ByVal fv As Double, ByVal p() As Double, ByVal pc As Double) As Double
                coil_static_pressure = (p(0) + p(1) * fv ^ 4 + p(2) * fv ^ 3 + p(3) * fv ^ 2 + p(4) * fv) * pc
            End Function
        End Class

    End Class

End Namespace