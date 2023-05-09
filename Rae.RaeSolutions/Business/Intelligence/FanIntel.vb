Option Strict On
Option Explicit On

Imports Rae.RaeSolutions.DataAccess
Namespace Rae.RaeSolutions.Business.Intelligence

Public Class FanIntel

   ''' <summary>For any altitude greater than this high altitude, a high altitude fan is recommended</summary>
   ''' <value>The highest altitude that a high altitude fan is not recommended</value>
   Shared ReadOnly Property HighAltitude() As Double
      Get
         Return 4000.0
      End Get
   End Property

   Shared Function IsAltitudeHigh(altitude As Double) As Boolean
      Return (altitude >= HighAltitude)
   End Function


   ''' <summary>Checks if fan is a high altitude fan</summary>
   ''' <param name="fanFileName">Fan file name of fan to check</param>
   Shared Function IsHighAltitudeFan(fanFileName As String) As Boolean
      Dim isHigh As Boolean

      Select Case fanFileName
         Case "BR28IN.HA", "BR28INHA.950"
            isHigh = True
         Case Else
            isHigh = False
      End Select

      Return isHigh
   End Function


   ''' <summary>Selects fan file name for the parameters</summary>
   ''' <param name="motorHorsepower">Horsepower of the motor</param>
   ''' <param name="fanRPM">Fan RPMs</param>
   ''' <param name="altitude">Altitude in feet</param>
   ''' <param name="hertz">Hertz (Either 50 Hz or 60 Hz)</param>
   Overloads Shared Function SelectFanFileName(motorHorsepower As Single, fanRPM As Single, altitude As Single, _
   Optional hertz As Integer = 60) As String
      ' UNSURE: FH series has 16 horsepower motors which aren't listed here
      ' UNSURE: PFE series have higher horsepower than listed

      Dim isAltitudeHigh As Boolean = (altitude > HighAltitude)
      Dim fanFileName As String = ""

      If hertz = 60 Then
         Select Case motorHorsepower
            Case 0.25
               If Not isAltitudeHigh Then
                  If fanRPM = 1140 Then : fanFileName = "LAU2030"
                  ElseIf fanRPM = 1725 Then : fanFileName = "LAUFC20.23"
                  End If
               End If
            Case 0.5
               If Not isAltitudeHigh Then
                  If fanRPM = 1140 Then fanFileName = "LAU2429"
               End If
            Case 1
               If isAltitudeHigh Then
                  If fanRPM = 1140 Then : fanFileName = "BR28IN.HA"
                     'ElseIf fanRPM = 950 Then : fanFileName = "BR28INHA.950"
                  ElseIf fanRPM = 850 Then : fanFileName = "BR28IN.850"
                  End If
               Else
                  If fanRPM = 1140 Then : fanFileName = "BR28IN"
                     'ElseIf fanRPM = 950 Then : fanFileName = "BR28IN.950"
                     ' 50 'ElseIf fanRPM = 850 Then : fanFileName = "BR28IN.708"
                  ElseIf fanRPM = 850 Then : fanFileName = "LAU2840.850"
                  End If
               End If
            Case 2
               If Not isAltitudeHigh Then
                  If fanRPM = 1140 Then : fanFileName = "S42832"
                  ElseIf fanRPM = 850 Then : fanFileName = "S42832.850"
                  End If
               End If
         End Select
      ElseIf hertz = 50 Then
         If motorHorsepower = 0.5 Then
            If fanRPM = 950 Then : fanFileName = "LAU2429.950"
            End If
         ElseIf motorHorsepower = 1 Then
            If Not isAltitudeHigh Then
               If fanRPM = 850 Then : fanFileName = "BR28IN.708"
               ElseIf fanRPM = 950 Then : fanFileName = "BR28IN.950"
               End If
            Else
               If fanRPM = 950 Then : fanFileName = "BR28INHA.950"
               End If
            End If
         ElseIf motorHorsepower = 2 Then
            If Not isAltitudeHigh Then
               If fanRPM = 950 Then : fanFileName = "S42832.950"
               End If
            End If
         End If
      End If

      Return fanFileName
   End Function


   Overloads Shared Function SelectFanFileName(fanDiameter As Double) As String
      Dim fanFileName As String = ""

      ' selects fan based on fan diameter
      Select Case fanDiameter
         Case 24 : fanFileName = "LAU2429"
         Case 28 : fanFileName = "BR28IN"
         Case 282 : fanFileName = "S42832"
      End Select

      Return fanFileName
   End Function

        Shared Function SelectStandardFile(ByVal fanID As String, ByVal altitude As Double, ByVal hp As Double, ByVal junk As Integer) As String

            If IsAltitudeHigh(altitude) Then
                Select Case fanID
                    Case "BR28IN"
                        Return "BR28IN.HA"
                    Case "LAU2429"
                        Return "BR28IN"  ' RAE Solutions upgrades the 24 inch curve to 28 inch curve.  Does not charge extra.  Not sure why, always been that way.
                    Case Else
                        Return fanID
                End Select
            Else
                Return fanID
            End If







            'Dim file As String = ""
            ''
            'If IsAltitudeHigh(altitude) Then
            '    If diameter = 28 Then
            '        file = "BR28IN.HA"
            '    ElseIf diameter = 24 Then
            '        file = "BR28IN" 'upgrade 24" to 28"
            '    ElseIf diameter = 20 Then
            '        file = "F1082029.11" '?
            '    End If
            'ElseIf diameter = 28 Then
            '    If hp = 2 Then
            '        file = "S42832"
            '    Else
            '        file = "BR28IN"
            '    End If
            'ElseIf diameter = 24 Then
            '    file = "LAU2429"
            'ElseIf diameter = 20 Then
            '    file = "F1082029.11"
            'ElseIf diameter = 800 Then
            '    file = "ZN080.GL"
            'End If

            'Return file
        End Function






        Shared Function SelectWatts(ByVal fanFileName As String, ByVal hp As Double, Optional ByVal hertz As Integer = 60, Optional PowerOverride As String = "") As Integer
            Dim w As Integer

            If hertz = 50 Then
                Select Case fanFileName
                    Case "BR28IN", "BR28IN.708", "BR28IN.950", "BR28IN.HA", "BR28INHA.950", "LAU2840.850"
                        w = 805
                    Case "LAU2030"
                        w = 229
                    Case "LAU2429", "LAU2429.950"
                        w = 455
                    Case "S42832", "S42832.950", "S42832.850"
                        w = 1245
                    Case "BR28IN.HE"
                        w = 675
                    Case "F1082029.11"
                        If hp = 0.25 Then
                            w = 206
                        ElseIf hp = 0.5 Then
                            w = 413
                        End If
                    Case "ZN050.DC"
                        w = 900

                    Case Else
                        w = 805    'default 1 horse power motor
                End Select
            ElseIf hertz = 60 Then
                Select Case fanFileName
                    Case "BR28IN", "BR28IN.708", "BR28IN.950", "BR28IN.HA", "BR28INHA.950", "LAU2840.850"
                        w = 1100
                    Case "LAU2030"
                        w = 275
                    Case "LAU2429", "LAU2429.950"
                        w = 550
                    Case "S42832", "S42832.950", "S42832.850"
                        w = 1700
                    Case "BR28IN.HE"
                        w = 900
                    Case "F1082029.11"
                        If hp = 0.25 Then
                            w = 275
                        ElseIf hp = 0.5 Then
                            w = 550
                        End If
                    Case "ZN050.DC"
                        w = 900
                    Case Else
                        'todo: throw exception
                        If fanFileName.StartsWith("OVERRIDE") AndAlso Not String.IsNullOrWhiteSpace(PowerOverride) Then
                            w = CInt(Double.Parse(PowerOverride))
                        Else
                            w = 1100
                        End If

                End Select
            End If

            Return w
        End Function

        ''' <summary>Accounts for voltage parameter when selecting fan</summary>
        Shared Function SelectFanWatts(ByVal fanFileName As String, ByVal hertz As Integer, ByVal voltage As Integer) As Integer
            If voltage = 415 AndAlso hertz = 50 Then
                ' changing hertz b/c at 415 volts the fan wattage is the same as at 60 hertz
                hertz = 60
            End If

            Return SelectWatts(fanFileName, 0, hertz)
        End Function

    End Class
End Namespace