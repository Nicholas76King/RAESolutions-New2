Imports Rae.Math.comparisons

Namespace rae.solutions.compressors

''' <summary>Determines whether suction and discharge temperatures are safe for the compressor.</summary>
''' <remarks>Database safety limits use the yes/no entries in the compressor database to adjust the default min and max discharge temperatures</remarks>
    'class db_compressor_limits : inherits compressor_limits_base
    '   sub new(compressor as compressor, suction_temp as double, discharge_temp as double)
    '      me.compressor = compressor
    '      dim s = suction_temp
    '      dim d = discharge_temp

    '      dim issafe as boolean

    '      dim no = get_no()
    '      dim yes = get_yes()
    '      dim dmin = compressor.discharge_min
    '      dim dmax = compressor.discharge_max
    '      set_discharge_limits(dmin, dmax, s, yes, no)

    '      _exceeded = true
    '      if d < dmin
    '         _discharge_is_below_min = true
    '      elseIf d > dmax
    '         _discharge_is_above_max = true
    '      elseIf s > compressor.suction_max
    '         _suction_is_above_max = true
    '      elseIf s < compressor.suction_min
    '         _suction_is_below_min = true
    '      else
    '         _exceeded = false
    '      end if
    '   end sub


    '   Private Function get_yes() As String()
    '      Dim c = compressor
    '      Dim show As String
    '      Dim yes(19) As String

    '      For i = 0 To yes.Length - 1
    '         show = "YES" & i.ToString
    '         If c.Unloading = show Or c.HeadCoolingFan = show _
    '         Or c.DemandC = show Or c.LiquidInjection = show _
    '         Or c.OilCool = show Then
    '            yes(i) = "Show"
    '         End If
    '      Next

    '      Return yes
    '   End Function

    '   Private Function get_no() As String()
    '      Dim c = compressor
    '      Dim show As String
    '      Dim no(9) As String

    '      For i = 1 To no.Length - 1
    '         show = "NO" & i
    '         If c.Unloading = show Or c.HeadCoolingFan = show _
    '         Or c.DemandC = show Or c.LiquidInjection = show _
    '         Or c.OilCool = show Then
    '            no(i) = "Show"
    '         End If
    '      Next

    '      Return no
    '   End Function

    '   Private Sub set_discharge_limits( _
    '   ByRef minDischarge As Double, ByRef maxDischarge As Double, _
    '   suctionTemp As Double, yesNotes() As String, noNotes() As String)

    '      'only yes indices 3, 5, 6, 7, 13, 14, 16, 17, 18, 19 are used

    '            'NEwCompressor



    '      If yesNotes(3) = "Show" Then
    '         If suctionTemp >= 14 And suctionTemp <= 23 Then
    '            maxDischarge = 125
    '         End If
    '      End If
    '      If yesNotes(5) = "Show" Then
    '         'sets max condensing temperature
    '         If suctionTemp >= 0 And suctionTemp <= 5 Then
    '            maxDischarge = 120
    '         ElseIf suctionTemp > 5 And suctionTemp <= 10 Then
    '            maxDischarge = 125
    '         ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
    '            maxDischarge = 135
    '         ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
    '            maxDischarge = 140
    '         End If
    '         'sets min condensing temperature
    '         If suctionTemp >= 0 And suctionTemp <= 10 Then
    '            minDischarge = 80
    '         ElseIf suctionTemp > 10 And suctionTemp <= 30 Then
    '            minDischarge = 90
    '         ElseIf suctionTemp > 30 And suctionTemp <= 50 Then
    '            minDischarge = 100
    '         End If
    '      End If
    '      If yesNotes(6) = "Show" Then
    '         If suctionTemp >= 0 And suctionTemp <= 5 Then
    '            maxDischarge = 120
    '         ElseIf suctionTemp > 5 And suctionTemp <= 10 Then
    '            maxDischarge = 125
    '         ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
    '            maxDischarge = 135
    '         ElseIf suctionTemp > 15 Then
    '            maxDischarge = 140
    '         End If
    '         If suctionTemp >= 0 And suctionTemp <= 25 Then
    '            minDischarge = 80
    '         ElseIf suctionTemp > 25 And suctionTemp <= 40 Then
    '            minDischarge = 90
    '         ElseIf suctionTemp > 45 And suctionTemp <= 50 Then
    '            minDischarge = 100
    '         End If
    '      End If
    '      If yesNotes(7) = "Show" Then
    '         If suctionTemp >= 10 And suctionTemp <= 15 Then
    '            minDischarge = 80
    '            maxDischarge = 110 '120
    '         ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
    '            minDischarge = 80
    '            maxDischarge = 117
    '         ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
    '            minDischarge = 80
    '            maxDischarge = 125
    '         ElseIf suctionTemp > 25 And suctionTemp <= 40 Then
    '            minDischarge = 80
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 40 And suctionTemp <= 50 Then
    '            minDischarge = 87
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 50 And suctionTemp <= 55 Then
    '            minDischarge = 90
    '            maxDischarge = 130
    '         End If
    '      End If
    '      If yesNotes(13) = "Show" Then
    '         If suctionTemp >= 5 And suctionTemp <= 10 Then
    '            minDischarge = 70
    '            maxDischarge = 120
    '         ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
    '            minDischarge = 70
    '            maxDischarge = 125
    '         ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
    '            minDischarge = 70
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 20 And suctionTemp <= 30 Then
    '            minDischarge = 75
    '            maxDischarge = 135
    '         ElseIf suctionTemp > 30 And suctionTemp <= 40 Then
    '            minDischarge = 85
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 40 And suctionTemp <= 55 Then
    '            minDischarge = 90
    '            maxDischarge = 140
    '         End If
    '      End If
    '      If yesNotes(14) = "Show" Then
    '         If suctionTemp >= 10 And suctionTemp <= 15 Then
    '            minDischarge = 90
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
    '            minDischarge = 80
    '            maxDischarge = 136
    '         ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
    '            minDischarge = 90
    '            maxDischarge = 143
    '         ElseIf suctionTemp > 25 And suctionTemp <= 40 Then
    '            minDischarge = 90
    '            maxDischarge = 150
    '         ElseIf suctionTemp > 40 And suctionTemp <= 47 Then
    '            minDischarge = 95
    '            maxDischarge = 150
    '         ElseIf suctionTemp > 47 And suctionTemp <= 55 Then
    '            minDischarge = 100
    '            maxDischarge = 150
    '         End If
    '      End If
    '      If yesNotes(16) = "Show" Then
    '         If suctionTemp >= 40 And suctionTemp <= 45 Then
    '            minDischarge = 70
    '         End If
    '      End If
    '      If yesNotes(17) = "Show" Then
    '         If suctionTemp >= 0 And suctionTemp <= 10 Then
    '            minDischarge = 90
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
    '            minDischarge = 90
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 15 And suctionTemp <= 55 Then
    '            minDischarge = 90
    '            maxDischarge = 150
    '         End If
    '      End If
    '      If yesNotes(18) = "Show" Then
    '         If suctionTemp >= -12 And suctionTemp <= -5 Then
    '            minDischarge = 70
    '            maxDischarge = 121
    '         ElseIf suctionTemp > -5 And suctionTemp <= 0 Then
    '            minDischarge = 70
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 0 And suctionTemp <= 5 Then
    '            minDischarge = 70
    '            maxDischarge = 135
    '         ElseIf suctionTemp > 5 And suctionTemp <= 20 Then
    '            minDischarge = 70
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 20 And suctionTemp <= 32 Then
    '            minDischarge = 85
    '            maxDischarge = 140
    '         End If
    '      End If
    '      If yesNotes(19) = "Show" Then
    '         If is_among(suctionTemp, -10, 0) Then
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 0 AndAlso suctionTemp <= 10 Then
    '            maxDischarge = 135
    '         ElseIf suctionTemp > 10 AndAlso suctionTemp <= 55 Then
    '            maxDischarge = 140
    '         End If
    '      End If

    '      If noNotes(1) = "Show" Then
    '         'sets min condensing temperature
    '         If suctionTemp >= -10 And suctionTemp <= 55 Then
    '            minDischarge = 80
    '         End If
    '         'sets max condensing temperature
    '         If suctionTemp >= -10 And suctionTemp <= -5 Then
    '            maxDischarge = 100
    '         ElseIf suctionTemp > -5 And suctionTemp <= 0 Then
    '            maxDischarge = 105
    '         ElseIf suctionTemp > 0 And suctionTemp <= 5 Then
    '            maxDischarge = 110
    '         ElseIf suctionTemp > 5 And suctionTemp <= 10 Then
    '            maxDischarge = 115
    '         ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
    '            maxDischarge = 120
    '         ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
    '            maxDischarge = 125
    '         ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 25 And suctionTemp <= 30 Then
    '            maxDischarge = 135
    '         ElseIf suctionTemp > 30 And suctionTemp <= 35 Then
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 35 And suctionTemp <= 40 Then
    '            maxDischarge = 145
    '         ElseIf suctionTemp > 40 And suctionTemp <= 55 Then
    '            maxDischarge = 150
    '         End If
    '      End If
    '      If noNotes(2) = "Show" Then
    '         If suctionTemp >= 25 And suctionTemp <= 30 Then
    '            minDischarge = 70
    '            maxDischarge = 130
    '         ElseIf suctionTemp > 30 And suctionTemp <= 45 Then
    '            minDischarge = 70
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 45 And suctionTemp <= 49 Then
    '            minDischarge = 75
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 49 And suctionTemp <= 55 Then
    '            minDischarge = 85
    '            maxDischarge = 140
    '         End If
    '      End If
    '      If noNotes(3) = "Show" Then
    '         If suctionTemp >= -40 And suctionTemp <= -7 Then
    '            minDischarge = 70
    '            maxDischarge = 130
    '         ElseIf suctionTemp > -7 And suctionTemp <= 0 Then
    '            minDischarge = 70
    '            maxDischarge = 135
    '         End If
    '      End If
    '      If noNotes(4) = "Show" Then
    '         If suctionTemp >= 0 And suctionTemp <= 5 Then
    '            maxDischarge = 120
    '         ElseIf suctionTemp > 5 Then
    '            maxDischarge = 130
    '         End If
    '      End If
    '      If noNotes(5) = "Show" Then
    '         If suctionTemp >= 0 And suctionTemp <= 5 Then
    '            maxDischarge = 110
    '         ElseIf suctionTemp > 5 Then
    '            maxDischarge = 120
    '         End If
    '      End If
    '      If noNotes(6) = "Show" Then
    '         If suctionTemp >= 0 And suctionTemp <= 10 Then
    '            maxDischarge = 120
    '         ElseIf suctionTemp > 10 Then
    '            maxDischarge = 130
    '         End If
    '      End If
    '      If noNotes(7) = "Show" Then
    '         If suctionTemp >= -40 And suctionTemp <= -35 Then
    '            maxDischarge = 120
    '         ElseIf suctionTemp > -50 And suctionTemp <= 0 Then
    '            maxDischarge = 130
    '         End If
    '      End If
    '      If noNotes(8) = "Show" Then
    '         If suctionTemp >= 5 And suctionTemp <= 10 Then
    '            minDischarge = 70
    '            maxDischarge = 120
    '         ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
    '            minDischarge = 70
    '            maxDischarge = 128
    '         ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
    '            minDischarge = 70
    '            maxDischarge = 138
    '         ElseIf suctionTemp > 20 And suctionTemp <= 30 Then
    '            minDischarge = 70
    '            maxDischarge = 150
    '         ElseIf suctionTemp > 30 And suctionTemp <= 35 Then
    '            minDischarge = 70
    '            maxDischarge = 165
    '         ElseIf suctionTemp > 35 And suctionTemp <= 45 Then
    '            minDischarge = 70
    '            maxDischarge = 165
    '         ElseIf suctionTemp > 45 And suctionTemp <= 50 Then
    '            minDischarge = 80
    '            maxDischarge = 165
    '         ElseIf suctionTemp > 50 And suctionTemp <= 60 Then
    '            minDischarge = 90
    '            maxDischarge = 165
    '         End If
    '      End If
    '      If noNotes(9) = "Show" Then
    '         If suctionTemp >= -10 And suctionTemp <= -5 Then
    '            minDischarge = 70
    '            maxDischarge = 130
    '         ElseIf suctionTemp > -5 And suctionTemp <= 5 Then
    '            minDischarge = 70
    '            maxDischarge = 135
    '         ElseIf suctionTemp > 5 And suctionTemp <= 35 Then
    '            minDischarge = 70
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 35 And suctionTemp <= 40 Then
    '            minDischarge = 78
    '            maxDischarge = 140
    '         ElseIf suctionTemp > 40 And suctionTemp <= 45 Then
    '            minDischarge = 85
    '            maxDischarge = 140
    '         End If
    '      End If

    '   End Sub

    '   Private compressor As compressor
    'End Class

End Namespace