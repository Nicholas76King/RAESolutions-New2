Imports Rae.Math.comparisons
Imports rae.solutions.compressors
Imports rae.solutions.compressors.compressor_type
Imports System
Imports System.Data


Namespace Rae.RaeSolutions.Business.Intelligence

   ''' <summary>
   ''' Compressor information services.
   ''' </summary>
   Public Class CompressorService

#Region " Internal classes and structures"

      ''' <summary>
      ''' Contains strings used in compressor class.
      ''' </summary>
      Private Class Strings

         Private Shared cannotDetermineTemperatureLimits As String = _
            "The temperature limits for the compressor cannot be determined."

         Public Shared Function CompressorTemperatureLimitsDataError(ByVal compressorFileName As String, ByVal exceptionMessage As String) As String
            Return Strings.cannotDetermineTemperatureLimits & " A database error occured while retrieving data for the compressor file name, " & compressorFileName & ". " & exceptionMessage
         End Function

         Public Shared Function CompressorFileNameIsNull() As String
            Return Strings.cannotDetermineTemperatureLimits & " The compressor file name is null or empty."
         End Function

         Public Shared Function CompressorFileNameDoesNotExist(ByVal compressorFileName As String) As String
            Return Strings.cannotDetermineTemperatureLimits & " The compressor file name, " & compressorFileName & ", does not exist in the compressor data source."
         End Function

      End Class


      ''' <summary>
      ''' Temperature limits that the compressor should operate within.
      ''' </summary>
      Public Structure TemperatureLimitsTransferientialData
         Public MinSuctionTemperature As Double
         Public MaxSuctionTemperature As Double

         Public MinCondensingTemperature As Double
         Public MaxCondensingTemperature As Double
      End Structure

#End Region


      Public Shared Function ConvertToCompressorType(compressorType As String) As compressor_type
         Dim type As compressor_type

         Select Case compressorType.ToUpper
            Case "SCREW"                : type = Screw
            Case "SCROLL"               : type = Scroll
            Case "SEMI-HERMETIC DISCUS" : type = semihermetic_discus
         End Select

         Return type
      End Function


      ''' <summary>Checks compressor safety
      ''' </summary>
      ''' <param name="suctionTemperature">Suction temperature
      ''' </param>
      ''' <param name="condensingTemperature">Condensing temperature
      ''' </param>
      ''' <param name="evaporatingTemperature">Evaporating temperature
      ''' </param>
      ''' <param name="leavingTemperature">Leaving fluid temperature
      ''' </param>
      ''' <param name="refrigerant">Refrigerant
      ''' </param>
      ''' <param name="compressorModel">Compressor model
      ''' </param>
      ''' <param name="recommendedMinSuctionTemperature">Recommended minimum suction temperature; evaporator temperature must be 
      ''' greater or equal to this temperature.
      ''' </param>
      ''' <returns>Boolean indicating compressor safety
      ''' </returns>
      ''' <remarks>Reads yes/no notes from database to determine compressor safety.
      ''' Checks condensing and suction temperature are within range.
      ''' </remarks>
      ''' <history>[CASEYJ]	6/14/2005	Created
      ''' </history>
      Public Shared Function IsCompressorSafe( _
      ByVal suctionTemperature As Single, _
      ByVal condensingTemperature As Single, _
      ByVal evaporatingTemperature As Single, _
      ByVal leavingTemperature As Single, _
      ByVal refrigerant As String, _
      ByVal compressorModel As String, _
      ByVal recommendedMinSuctionTemperature As Single, _
      ByVal authorizationLevel As Integer) As Boolean
         Dim _isCompressorSafe As Boolean
         Dim _compressorSafety As CompressorSafety
         Dim yesNotes(19) As String
         Dim noNotes(9) As String
         Dim i As Integer
         Dim temp_maxst, temp_minst As Double
         Dim temp_maxct, temp_minct As Single
         Dim note As String

         Try
            'retrieves compressor safety information
            _compressorSafety = DataAccess.CompressorDataAccess.RetrieveCompressorSafety( _
               compressorModel, refrigerant)
         Catch dbEx As System.Data.OleDb.OleDbException
            Return False
         End Try

         ' initializes yes
         For i = 0 To yesNotes.Length - 1
            yesNotes(i) = ""
         Next
         ' initializes no
         For i = 0 To noNotes.Length - 1
            noNotes(i) = ""
         Next

         With _compressorSafety
            For i = 0 To yesNotes.Length - 1
               note = "YES" & i.ToString

               If .Unloading = note Or .HeatingAndCoolingFan = note _
               Or .Demandc = note Or .LiquidInjection = note _
               Or .OilCooling = note Then
                  yesNotes(i) = "Show"
               End If
            Next

            For i = 0 To noNotes.Length - 1
               note = "NO" & i.ToString
               If .Unloading = note Or .HeatingAndCoolingFan = note _
               Or .Demandc = note Or .LiquidInjection = note _
               Or .OilCooling = note Then
                  noNotes(i) = "Show"
               End If
            Next

            ' sets max and mins for suction and condensing temperatures
            temp_maxst = .MaxSuctionTemperature
            temp_minst = .MinSuctionTemperature
            temp_maxct = CSng(.MaxCondensingTemperature)
            temp_minct = CSng(.MinCondensingTemperature)
            
            If authorizationLevel = 3 And compressorModel.StartsWith("SCA2") Then _
               temp_maxct = 135
         End With

         ' sets max and min condensing temperatures based on compressor safety notes
         Rae.RaeSolutions.Business.Intelligence.CompressorService.SetCondensingTemperatureLimits( _
            temp_maxct, temp_minct, suctionTemperature, yesNotes, noNotes)

         If authorizationLevel = 3 And compressorModel.StartsWith("SCA2") Then
            temp_maxct = 135
         End If

         ' checks if condensing or suction temp. is out of range
         If condensingTemperature >= temp_minct _
         And condensingTemperature <= temp_maxct _
         And suctionTemperature <= temp_maxst _
         And suctionTemperature >= temp_minst Then
            _isCompressorSafe = True
         Else
            _isCompressorSafe = False
         End If

         ' checks difference between leaving fluid temp. and evaporating temp.
         If (leavingTemperature - evaporatingTemperature) < 5 _
         And authorizationLevel < 3 Then
            _isCompressorSafe = False
         End If
         If (leavingTemperature - evaporatingTemperature) < 6 _
         And authorizationLevel = 3 Then
            _isCompressorSafe = False
         End If

         ' checks if evaporating temp. is less than recommended minimum suction temp.
         If evaporatingTemperature < recommendedMinSuctionTemperature Then
            _isCompressorSafe = False
         End If

         Return _isCompressorSafe
      End Function


      ''' <summary>Changes condensing temperature limits, if there are compressor
      ''' safety notes
      ''' </summary>
      ''' <param name="suctionTemp">Suction temperature</param>
      ''' <param name="yesNotes">Compressor safety notes</param>
      ''' <param name="noNotes">Compressor safety notes</param>
      ''' <param name="maxCondensingTemperature">The current max
      ''' condensing temperature</param>
      ''' <param name="minCondensingTemperature">The current min
      ''' condensing temperature</param>
      ''' <remarks>If there are no compressor safety notes, current temperature 
      ''' limit parameters are returned.
      ''' </remarks>
      ''' <history>[CASEYJ]	6/15/2005	Created
      ''' </history>
      Public Shared Sub SetCondensingTemperatureLimits( _
      ByRef maxCondensingTemperature As Single, _
      ByRef minCondensingTemperature As Single, _
      ByVal suctionTemp As Single, _
      ByVal yesNotes() As String, _
      ByVal noNotes() As String)

         ''' <history>Casey Joyce per Jim McLarty, 06/14/2005, Modified</history>
         ''' <summary>Updated limits, index equals yes number, yes(3) = YES3 (as in db)</summary>
         If yesNotes(3) = "Show" Then
            If suctionTemp >= 14 And suctionTemp <= 23 Then
               maxCondensingTemperature = 125
            End If
         End If
         If yesNotes(5) = "Show" Then
            'sets max condensing temperature
            If suctionTemp >= 0 And suctionTemp <= 5 Then
               maxCondensingTemperature = 120
            ElseIf suctionTemp > 5 And suctionTemp <= 10 Then
               maxCondensingTemperature = 125
            ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
               maxCondensingTemperature = 135
            ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
               maxCondensingTemperature = 140
            End If
            'sets min condensing temperature
            If suctionTemp >= 0 And suctionTemp <= 10 Then
               minCondensingTemperature = 80
            ElseIf suctionTemp > 10 And suctionTemp <= 30 Then
               minCondensingTemperature = 90
            ElseIf suctionTemp > 30 And suctionTemp <= 50 Then
               minCondensingTemperature = 100
            End If
         End If
         If yesNotes(6) = "Show" Then
            If suctionTemp >= 0 And suctionTemp <= 5 Then
               maxCondensingTemperature = 120
            ElseIf suctionTemp > 5 And suctionTemp <= 10 Then
               maxCondensingTemperature = 125
            ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
               maxCondensingTemperature = 135
            ElseIf suctionTemp > 15 Then
               maxCondensingTemperature = 140
            End If
            If suctionTemp >= 0 And suctionTemp <= 25 Then
               minCondensingTemperature = 80
            ElseIf suctionTemp > 25 And suctionTemp <= 40 Then
               minCondensingTemperature = 90
            ElseIf suctionTemp > 45 And suctionTemp <= 50 Then
               minCondensingTemperature = 100
            End If
         End If
         If yesNotes(7) = "Show" Then
            If suctionTemp >= 10 And suctionTemp <= 15 Then
               minCondensingTemperature = 80
               maxCondensingTemperature = 110 '120
            ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
               minCondensingTemperature = 80
               maxCondensingTemperature = 117
            ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
               minCondensingTemperature = 80
               maxCondensingTemperature = 125
            ElseIf suctionTemp > 25 And suctionTemp <= 40 Then
               minCondensingTemperature = 80
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 40 And suctionTemp <= 50 Then
               minCondensingTemperature = 87
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 50 And suctionTemp <= 55 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 130
            End If
         End If
         If yesNotes(13) = "Show" Then
            If suctionTemp >= 5 And suctionTemp <= 10 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 120
            ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 125
            ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 20 And suctionTemp <= 30 Then
               minCondensingTemperature = 75
               maxCondensingTemperature = 135
            ElseIf suctionTemp > 30 And suctionTemp <= 40 Then
               minCondensingTemperature = 85
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 40 And suctionTemp <= 55 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 140
            End If
         End If
         If yesNotes(14) = "Show" Then
            If suctionTemp >= 10 And suctionTemp <= 15 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
               minCondensingTemperature = 80
               maxCondensingTemperature = 136
            ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 143
            ElseIf suctionTemp > 25 And suctionTemp <= 40 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 150
            ElseIf suctionTemp > 40 And suctionTemp <= 47 Then
               minCondensingTemperature = 95
               maxCondensingTemperature = 150
            ElseIf suctionTemp > 47 And suctionTemp <= 55 Then
               minCondensingTemperature = 100
               maxCondensingTemperature = 150
            End If
         End If
         If yesNotes(16) = "Show" Then
            If suctionTemp >= 40 And suctionTemp <= 45 Then
               minCondensingTemperature = 70
            End If
         End If
         If yesNotes(17) = "Show" Then
            If suctionTemp >= 0 And suctionTemp <= 10 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 15 And suctionTemp <= 55 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 150
            End If
         End If
         If yesNotes(18) = "Show" Then
            If suctionTemp >= -12 And suctionTemp <= -5 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 121
            ElseIf suctionTemp > -5 And suctionTemp <= 0 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 0 And suctionTemp <= 5 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 135
            ElseIf suctionTemp > 5 And suctionTemp <= 20 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 20 And suctionTemp <= 32 Then
               minCondensingTemperature = 85
               maxCondensingTemperature = 140
            End If
         End If
         If yesNotes(19) = "Show" Then
            If is_among(suctionTemp, -10, 0) Then
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 0 AndAlso suctionTemp <= 10 Then
               maxCondensingTemperature = 135
            ElseIf suctionTemp > 10 AndAlso suctionTemp <= 55 Then
               maxCondensingTemperature = 140
            End If
         End If

         If noNotes(1) = "Show" Then
            'sets min condensing temperature
            If suctionTemp >= -10 And suctionTemp <= 55 Then
               minCondensingTemperature = 80
            End If
            'sets max condensing temperature
            If suctionTemp >= -10 And suctionTemp <= -5 Then
               maxCondensingTemperature = 100
            ElseIf suctionTemp > -5 And suctionTemp <= 0 Then
               maxCondensingTemperature = 105
            ElseIf suctionTemp > 0 And suctionTemp <= 5 Then
               maxCondensingTemperature = 110
            ElseIf suctionTemp > 5 And suctionTemp <= 10 Then
               maxCondensingTemperature = 115
            ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
               maxCondensingTemperature = 120
            ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
               maxCondensingTemperature = 125
            ElseIf suctionTemp > 20 And suctionTemp <= 25 Then
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 25 And suctionTemp <= 30 Then
               maxCondensingTemperature = 135
            ElseIf suctionTemp > 30 And suctionTemp <= 35 Then
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 35 And suctionTemp <= 40 Then
               maxCondensingTemperature = 145
            ElseIf suctionTemp > 40 And suctionTemp <= 55 Then
               maxCondensingTemperature = 150
            End If
         End If
         If noNotes(2) = "Show" Then
            If suctionTemp >= 25 And suctionTemp <= 30 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 130
            ElseIf suctionTemp > 30 And suctionTemp <= 45 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 45 And suctionTemp <= 49 Then
               minCondensingTemperature = 75
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 49 And suctionTemp <= 55 Then
               minCondensingTemperature = 85
               maxCondensingTemperature = 140
            End If
         End If
         If noNotes(3) = "Show" Then
            If suctionTemp >= -40 And suctionTemp <= -7 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 130
            ElseIf suctionTemp > -7 And suctionTemp <= 0 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 135
            End If
         End If
         If noNotes(4) = "Show" Then
            If suctionTemp >= 0 And suctionTemp <= 5 Then
               maxCondensingTemperature = 120
            ElseIf suctionTemp > 5 Then
               maxCondensingTemperature = 130
            End If
         End If
         If noNotes(5) = "Show" Then
            If suctionTemp >= 0 And suctionTemp <= 5 Then
               maxCondensingTemperature = 110
            ElseIf suctionTemp > 5 Then
               maxCondensingTemperature = 120
            End If
         End If
         If noNotes(6) = "Show" Then
            If suctionTemp >= 0 And suctionTemp <= 10 Then
               maxCondensingTemperature = 120
            ElseIf suctionTemp > 10 Then
               maxCondensingTemperature = 130
            End If
         End If
         If noNotes(7) = "Show" Then
            If suctionTemp >= -40 And suctionTemp <= -35 Then
               maxCondensingTemperature = 120
            ElseIf suctionTemp > -50 And suctionTemp <= 0 Then
               maxCondensingTemperature = 130
            End If
         End If
         If noNotes(8) = "Show" Then
            If suctionTemp >= 5 And suctionTemp <= 10 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 120
            ElseIf suctionTemp > 10 And suctionTemp <= 15 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 128
            ElseIf suctionTemp > 15 And suctionTemp <= 20 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 138
            ElseIf suctionTemp > 20 And suctionTemp <= 30 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 150
            ElseIf suctionTemp > 30 And suctionTemp <= 35 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 165
            ElseIf suctionTemp > 35 And suctionTemp <= 45 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 165
            ElseIf suctionTemp > 45 And suctionTemp <= 50 Then
               minCondensingTemperature = 80
               maxCondensingTemperature = 165
            ElseIf suctionTemp > 50 And suctionTemp <= 60 Then
               minCondensingTemperature = 90
               maxCondensingTemperature = 165
            End If
         End If
         If noNotes(9) = "Show" Then
            If suctionTemp >= -10 And suctionTemp <= -5 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 130
            ElseIf suctionTemp > -5 And suctionTemp <= 5 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 135
            ElseIf suctionTemp > 5 And suctionTemp <= 35 Then
               minCondensingTemperature = 70
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 35 And suctionTemp <= 40 Then
               minCondensingTemperature = 78
               maxCondensingTemperature = 140
            ElseIf suctionTemp > 40 And suctionTemp <= 45 Then
               minCondensingTemperature = 85
               maxCondensingTemperature = 140
            End If
         End If

      End Sub


      ''' <summary>
      ''' Gets compressor temperature limits for the compressor associated with the compressor file name.
      ''' </summary>
      ''' <param name="compressorFileName">
      ''' Compressor file name
      ''' </param>
      ''' <exception cref="ApplicationException">
      ''' Thrown when compressor file name is null or empty, data access error occurs or compressor data does not exist.
      ''' </exception>
      Public Shared Function GetTemperatureLimits(ByVal compressorFileName As String) As TemperatureLimitsTransferientialData
         ' validates compressor file name
         If String.IsNullOrEmpty(compressorFileName) Then
            Throw New ApplicationException(Strings.CompressorFileNameIsNull)
         End If

         ' retrieves condensing and suction temperature limits of compressor
         Dim temperatureLimitsTable As DataTable
         Try
            temperatureLimitsTable = DataAccess.CompressorDataAccess.RetrieveCompressorTemperatureLimits(compressorFileName)
         Catch dbEx As DataException
            Throw New ApplicationException(Strings.CompressorTemperatureLimitsDataError(compressorFileName, dbEx.Message), dbEx)
         End Try

         ' checks if temperature limits for compressor are available (were found in database)
         If temperatureLimitsTable Is Nothing OrElse temperatureLimitsTable.Rows.Count = 0 Then
            Throw New ApplicationException(Strings.CompressorFileNameDoesNotExist(compressorFileName))
         End If

         ' converts data table to transferiential data
         Dim temperatureLimits As TemperatureLimitsTransferientialData
         With temperatureLimitsTable.Rows(0)
            temperatureLimits.MinSuctionTemperature = CDbl(.Item("minst").ToString())
            temperatureLimits.MaxSuctionTemperature = CDbl(.Item("maxst").ToString())
            temperatureLimits.MinCondensingTemperature = CDbl(.Item("minct").ToString())
            temperatureLimits.MaxCondensingTemperature = CDbl(.Item("maxct").ToString())
         End With

         Return temperatureLimits
      End Function


      ''' <summary>
      ''' Checks that suction and condensing temperatures are within compressor limits for the compressor file name.
      ''' </summary>
      ''' <param name="compressorFileName">
      ''' Compressor file name to get temperature limits for
      ''' </param>
      ''' <param name="suctionTemperature">
      ''' Compressor suction temperature in degrees Fahrenheit
      ''' </param>
      ''' <param name="condensingTemperature">
      ''' Compressor condensing temperature in degrees Fahrenheit
      ''' </param>
      Public Shared Function CheckCompressorTemperatureLimits(ByVal compressorFileName As String, _
      ByVal suctionTemperature As Double, ByVal condensingTemperature As Double) As String
         Dim message As String

         ' gets temperature limits based on the compressor file name
         Dim limits As New CompressorTemperatureLimits(compressorFileName)

         ' sets message if a temperature is outside the application range
         If suctionTemperature < CompressorTemperatureLimits.ABSOLUTE_MIN_SUCTION_TEMPERATURE Then     '59601
            message = "Balance point is outside compressor application range. " & _
               "Suction temperature is less than -40°F."
         ElseIf suctionTemperature < limits.MinSuctionTemperature Then
            message = "Suction temperature is below compressor range."
         ElseIf suctionTemperature > limits.MaxSuctionTemperature Then
            message = "Suction temperature is above compressor range."
         ElseIf condensingTemperature < limits.MinCondensingTemperature Then
            message = "Condenser temperature is below compressor range."
         ElseIf condensingTemperature > limits.MaxCondensingTemperature Then
            message = "Condenser temperature is above compressor range."
         End If

         Return message
      End Function

   End Class


End Namespace