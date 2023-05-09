Imports rae.solutions
Imports rae.solutions.refrigerant
Imports rae.RaeSolutions.Business.Entities.Cofans

Namespace rae.solutions.condensing_units

    Class Coil_Capacity
        Structure Spec
            Public refrigerant As refrigerant
            Public coil_file_name, fan_file_name As String
            Public FinHeight, FinLength, fpi As Double
            Public fan_qty, altitude As Double

            Public fanOperatingRPM, fanCurveRPM As Decimal

            Public subcooling_is_required As Boolean
            Public subcooling_percentage As Double  '10% = 10 not 0.1

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

            Public RowsDeep As Integer
            Public TubeDiameter As Decimal

        End Structure

        Function calculate(ByVal spec As Spec) As Double
            Return calculate_capacity(spec)
        End Function


        Public results As New List(Of cofan.result)

        Private Function calculate_capacity(ByVal spec As Spec) As Double
            'todo: dim cofan_spec = map(spec)
            Dim cofan_spec As cofan.specification
            cofan_spec.coil_file = spec.coil_file_name
            cofan_spec.fan_file = spec.fan_file_name
            cofan_spec.altitude = spec.altitude
            cofan_spec.fan_quantity = spec.fan_qty
            cofan_spec.FinHeight = spec.FinHeight
            cofan_spec.FinLength = spec.FinLength
            'eric121219

            cofan_spec.fanOperatingRPM = spec.fanOperatingRPM
            cofan_spec.fanCurveRPM = spec.fanCurveRPM



            cofan_spec.UseDLLForPerformance = spec.UseDLLForPerformance
            cofan_spec.CondFeeds = spec.CondFeeds
            cofan_spec.CondPasses = spec.CondPasses
            cofan_spec.SubCoolerFeeds = spec.SubCoolerFeeds
            cofan_spec.SubCoolerPasses = spec.SubCoolerPasses
            cofan_spec.FinSurface = spec.FinSurface
            cofan_spec.FinMaterial = spec.FinMaterial
            cofan_spec.FinThickness = spec.FinThickness
            cofan_spec.tubeSurface = spec.tubeSurface
            cofan_spec.TubeMaterial = spec.TubeMaterial
            cofan_spec.TubeThickness = spec.TubeThickness
            cofan_spec.TubeDiameter = spec.tubediameter
            cofan_spec.Rows = spec.RowsDeep
            cofan_spec.FPI = CInt(spec.fpi)




            results = New cofan().balance(cofan_spec)

            Dim capacity = get_coil_capacity_from_cofan_based_on_fpi(results, spec.fpi)




            capacity *= spec.refrigerant.coil_capacity_multiplier()


            ' Could correct for non-zero compressor coef (subcooling) - Jay Kindle.

            If spec.subcooling_is_required Then _
               capacity *= (1 - (spec.subcooling_percentage / 100))

            Return capacity
        End Function


        Public Function RecalculateCapacityWithTD(ByVal spec As Spec, ByVal td As Double) As Double

            Dim capacity = get_coil_capacity_from_cofan_based_on_fpi(results, spec.fpi)

            capacity *= spec.refrigerant.coil_capacity_multiplier(td)

            If spec.subcooling_is_required Then _
               capacity *= (1 - (spec.subcooling_percentage / 100))

            Return capacity
        End Function


        Private Function get_coil_capacity_from_cofan_based_on_fpi(ByVal results As List(Of cofan.result), ByVal fpi As Double) As Double
            Dim capacity As Double
            Dim c1 = results(0).capacity
            Dim c2 = results(1).capacity
            Dim c3 = results(2).capacity
            Dim c4 = results(3).capacity

            If fpi = 8 Then
                capacity = c1
            ElseIf fpi = 9 Then
                capacity = (c2 - c1) / 2 + c1
            ElseIf fpi = 10 Then
                capacity = c2
            ElseIf fpi = 11 Then
                capacity = (c3 - c2) / 2 + c2
            ElseIf fpi = 12 Then
                capacity = c3
            ElseIf fpi = 13 Then
                capacity = (c4 - c3) / 2 + c3
            ElseIf fpi = 14 Then
                capacity = c4
            Else
                Throw New Exception("Coil capacity cannot be calculated. FPI is invalid: " & fpi.ToString)
            End If

            Return capacity
        End Function




        Public Function get_sp_from_cofan_based_on_fpi(ByVal results As List(Of cofan.result), ByVal fpi As Double) As Double
            Dim sp As Double
            Dim sp_8 = results(0).static_pressure
            Dim sp_10 = results(1).static_pressure
            Dim sp_12 = results(2).static_pressure
            Dim sp_14 = results(3).static_pressure

            If fpi = 8 Then
                sp = sp_8
            ElseIf fpi = 9 Then
                sp = (sp_10 - sp_8) / 2 + sp_8
            ElseIf fpi = 10 Then
                sp = sp_10
            ElseIf fpi = 11 Then
                sp = (sp_12 - sp_10) / 2 + sp_10
            ElseIf fpi = 12 Then
                sp = sp_12
            ElseIf fpi = 13 Then
                sp = (sp_14 - sp_12) / 2 + sp_12
            ElseIf fpi = 14 Then
                sp = sp_14
            Else
                Throw New Exception("Coil capacity cannot be calculated. FPI is invalid: " & fpi.ToString)
            End If

            Return sp
        End Function

    End Class

End Namespace
