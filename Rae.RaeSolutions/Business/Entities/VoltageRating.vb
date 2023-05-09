Imports System

Namespace Rae.RaeSolutions.Business.Entities

  ''' <summary>
  ''' Voltage rating, voltage/phase/hertz.
  ''' </summary>
  ''' <remarks>
  ''' The public properties are constructed on their first Get. 
  ''' In order to prevent NullReferenceExceptions, use public properties to get and set values not private members.
  ''' 
  ''' List of likely values.
  ''' ------------------
  ''' Volts  Phase Hertz
  ''' ------------------
  ''' 460    3     60
  ''' 230    1     50
  ''' 208
  ''' </remarks>
  ''' <history by="Casey Joyce" finish="2006/05/02" hours="3">
  ''' Modified: nullable properties, new format [voltage], update other member accordingly, pass 14/14 tests
  ''' </history>
  Public Class VoltageRating
    Implements IEquatable(Of VoltageRating)
    Implements ICloneable(Of VoltageRating)

    Private m_voltage As nullable_value(Of Integer)
    Private m_phase As nullable_value(Of Integer)
    Private m_hertz As nullable_value(Of Integer)

#Region " Properties"

    ''' <summary>
    ''' Voltage
    ''' </summary>
    Public Property Voltage() As nullable_value(Of Integer)
      Get
        If Me.m_voltage Is Nothing Then
          Me.m_voltage = New nullable_value(Of Integer)
        End If
        Return Me.m_voltage
      End Get
      Set(ByVal value As nullable_value(Of Integer))
        Me.m_voltage = value
      End Set
    End Property

    ''' <summary>
    ''' Phase
    ''' </summary>
    Public Property Phase() As nullable_value(Of Integer)
      Get
        If Me.m_phase Is Nothing Then
          Me.m_phase = New nullable_value(Of Integer)
        End If
        Return Me.m_phase
      End Get
      Set(ByVal value As nullable_value(Of Integer))
        Me.m_phase = value
      End Set
    End Property

    ''' <summary>
    ''' Hertz
    ''' </summary>
    Public Property Hertz() As nullable_value(Of Integer)
      Get
        If Me.m_hertz Is Nothing Then
          Me.m_hertz = New nullable_value(Of Integer)
        End If
        Return Me.m_hertz
      End Get
      Set(ByVal value As nullable_value(Of Integer))
        Me.m_hertz = value
      End Set
    End Property

#End Region


#Region " Public methods"

    ''' <summary>
    ''' Parameterless constructor
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Constructs voltage rating using the voltage, phase and hertz parameters.
    ''' </summary>
    ''' <param name="voltage">Voltage (ex. 460, 230, 208)</param>
    ''' <param name="phase">Phase (ex. 1, 3)</param>
    ''' <param name="hertz">Hertz (ex. 50, 60)</param>
    Public Sub New(ByVal voltage As Integer, ByVal phase As Integer, ByVal hertz As Integer)
      Me.Voltage.value = voltage
      Me.Phase.value = phase
      Me.Hertz.value = hertz
    End Sub

    ''' <summary>
    ''' Constructs voltage rating by parsing voltage rating text. Format: '[voltage]/[phase]/[hertz]'.
    ''' </summary>
    ''' <param name="voltageRating">
    ''' Voltage rating text. Format: '[voltage]/[phase]/[hertz]'. Ex. 460/3/60.
    ''' </param>
    Public Sub New(ByVal voltageRating As String)
      ' parses voltage, phase and hertz from voltage rating text
      Me.Parse(voltageRating)
    End Sub


    ''' <summary>
    ''' Represents voltage rating as a string. Format: '[voltage]/[phase]/[hertz]' -or- '[voltage]'. Ex. '460/3/60' or '460'.
    ''' </summary>
    Public Overrides Function ToString() As String
      ' 460
      If Me.Voltage.has_value AndAlso Not Me.Phase.has_value AndAlso Not Me.Hertz.has_value Then
        Return Me.Voltage.ToString

        ' 460/3/60
      ElseIf Me.Voltage.has_value AndAlso Me.Phase.has_value AndAlso Me.Hertz.has_value Then
        Return Me.Voltage.ToString & "/" & Me.Phase.ToString & "/" & Me.Hertz.ToString

        ' 115/12
      ElseIf Me.Voltage.has_value AndAlso Me.Phase.has_value AndAlso Not Me.Hertz.has_value Then
        Return Me.Voltage.ToString & "/" & Me.Phase.ToString

      Else
        Return String.Empty
      End If
    End Function


    ''' <summary>
    ''' Parses voltage, phase and hertz from voltage rating.
    ''' </summary>
    ''' <param name="voltageRating">
    ''' Voltage rating. Format: '[voltage]/[phase]/[hertz]'. Ex. 460/3/60. -or- '[voltage]'. Ex. 460
    ''' </param>
    ''' <exception cref="FormatException">
    ''' Thrown when voltage rating is not in parsable format.
    ''' </exception>
    Public Sub Parse(ByVal voltageRating As String)
      Dim slash1Index, slash2Index As Integer

      ' handles null voltage rating
      If voltageRating Is Nothing Then
        Me.Voltage.set_to_null() : Me.Phase.set_to_null() : Me.Hertz.set_to_null() : Exit Sub
      End If

      ' trims whitespace from beginning and end of voltage rating
      voltageRating = voltageRating.Trim

      ' handles empty voltage rating
      If voltageRating = String.Empty Then
        Me.Voltage.set_to_null() : Me.Phase.set_to_null() : Me.Hertz.set_to_null() : Exit Sub
      End If

      ' gets index of first slash
      slash1Index = voltageRating.IndexOf("/")

      ' checks are there any slashes ("/")
      If slash1Index = -1 Then
        Try   ' if exception occurs in CInt, throws FormatException not InvalidCastException
          ' since there are no slashes assume voltage only format, ex. "220"
          Me.Voltage.value = CInt(voltageRating)
        Catch ex As InvalidCastException : Throw New FormatException(ex.Message) : End Try
        Me.Phase.set_to_null()
        Me.Hertz.set_to_null()
      Else
        ' gets index of second slash
        slash2Index = voltageRating.IndexOf("/", slash1Index + 1)

        If slash2Index > -1 Then
          ' assumes formatted as ex. "220/3/60"
          Try   ' if exception occurs in CInt, throws FormatException not InvalidCastException
            ' parses voltage (everything before first slash)
            Me.Voltage.value = CInt(voltageRating.Substring(0, slash1Index))
            ' parses phase (everything between slashes)
            Me.Phase.value = CInt(voltageRating.Substring(slash1Index + 1, slash2Index - (slash1Index + 1)))
            ' parses hertz (everything after second slash)
            Me.Hertz.value = CInt(voltageRating.Substring(slash2Index + 1, voltageRating.Length - slash2Index - 1))
          Catch ex As InvalidCastException : Throw New FormatException(ex.Message) : End Try
        Else
          ' parses voltage (everything before first slash)
          Me.Voltage.value = CInt(voltageRating.Substring(0, slash1Index))
          ' parses second voltage (everything after first slash)
          ' stores second voltage in phase property
          Me.Phase.value = CInt(voltageRating.Substring(slash1Index + 1, voltageRating.Length - slash1Index - 1))
          ' invalid format (only has one slash) "[chars]/[chars]", can't parse
          'Throw New FormatException("Cannot parse voltage rating, '" & voltageRating & "'. Voltage rating must be formatted as '[voltage]/[phase]/[hertz]' or '[voltage]'.")
        End If
      End If

    End Sub

#End Region

    ''' <summary>
    ''' Indicates whether this voltage rating equals another voltage rating
    ''' </summary>
    ''' <param name="other">The other voltage rating to compare with</param>
    ''' <returns>
    ''' True if voltage ratings are equal, false if they are not equal.
    ''' </returns>
    ''' <remarks>
    ''' Voltage ratings are equal, if the voltage, hertz and phase properties are equal.
    ''' </remarks>
    Public Overloads Function Equals(ByVal other As VoltageRating) As Boolean _
    Implements System.IEquatable(Of VoltageRating).Equals
      If Me.Voltage.ToString = other.Voltage.ToString _
      AndAlso Me.Phase.ToString = other.Phase.ToString _
      AndAlso Me.Hertz.ToString = other.Hertz.ToString Then
        Return True
      Else
        Return False
      End If
    End Function


    ''' <summary>
    ''' Clones voltage rating.
    ''' </summary>
    Public Function Clone() As VoltageRating _
    Implements ICloneable(Of VoltageRating).Clone
      Dim voltage As New VoltageRating

      voltage.Voltage = Me.Voltage.clone()
      voltage.Hertz = Me.Hertz.clone()
      voltage.Phase = Me.Phase.clone()

      Return voltage
    End Function

  End Class

End Namespace