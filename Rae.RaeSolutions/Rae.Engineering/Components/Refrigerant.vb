Imports System.Collections
Imports System.Collections.Generic
Imports System.Math
Imports m1 = RAE.Math

Namespace Rae.Engineering

#Region " Enumerations"

Public Enum RefrigerantType
   R134a = 0
   R22 = 1
   R404a = 2
   R407c = 3
   R502 = 4
   R507 = 5
End Enum

#End Region

Public Class Refrigerant

#Region " Properties"

   Private type_ As RefrigerantType
   ''' <summary>
   ''' Type
   ''' </summary>
   Public Property Type() As RefrigerantType
      Get
         Return Me.type_
      End Get
      Set(ByVal value As RefrigerantType)
         Me.type_ = value
      End Set
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return Type.ToString()
        End Get
    End Property

#End Region

#Region " Public Methods"

   Public Sub New(ByVal Type As RefrigerantType)
      Me.Type = Type
   End Sub

   ''' <summary>
   ''' Get's refrigerant's pressure based on current temperature (liquid state)
   ''' </summary>
   ''' <param name="CurrentTemperature">Temperature as deg F</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetCondenserPressure(ByVal currentTemperature As Double) As Double

      Dim condenserPressure As Double

      Dim T As Double = currentTemperature + 459.69

      If Me.Type = RefrigerantType.R22 Then
            condenserPressure = Round(10 ^ (29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10))), 10)

      ElseIf Me.Type = RefrigerantType.R404a Then
                condenserPressure = Round(m1.Calculate.e ^ (57.5895 + (-6526.55 / T) + ((-6.58061) * (Log(T)) + (0.00000393732 * T ^ 2))), 10)

            ElseIf Me.Type = RefrigerantType.R507 Then
                condenserPressure = Round(m1.Calculate.e ^ (29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)), 10)

            ElseIf Me.Type = RefrigerantType.R502 Then
            condenserPressure = Round(10 ^ (10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))), 10)

      ElseIf Me.Type = RefrigerantType.R407c Then
                condenserPressure = Round(m1.Calculate.e ^ (43.3622 + (-6020.28 / T) + (-4.3987 * Log(T)) + (0.00000212036 * (T ^ 2))), 10)

            ElseIf Me.Type = RefrigerantType.R134a Then
                condenserPressure = Round(m1.Calculate.e ^ (22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))), 10)

            End If

      Return condenserPressure

   End Function


   ''' <summary>
   ''' Get's refrigerant's pressure based on current temperature (gas state)
   ''' </summary>
   ''' <param name="CurrentTemperature">Temperature as deg F</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function GetEvapPressure(ByVal currentTemperature As Double) As Double

      Dim evapPressure As Double

      '30A0, 35A0, 
      Dim T As Double = currentTemperature + 459.69

        If Me.Type = RefrigerantType.R22 Then
            evapPressure = Round(10 ^ (29.35754453 + (-3845.193152 / T) + (-7.86103122 * (Log(T) / Log(10))) + (0.002190939 * T) + ((0.445746703 * (686.1 - T)) / T) * (Log(686.1 - T) / Log(10))), 10)

        ElseIf Me.Type = RefrigerantType.R404a Then
                evapPressure = Round(m1.Calculate.e ^ (72.1209 + (-7315.14 / T) + ((-8.717729) * (Log(T)) + (0.0000051875 * T ^ 2))), 10)

            ElseIf Me.Type = RefrigerantType.R507 Then
                evapPressure = Round(m1.Calculate.e ^ (29.24862663 + (-6980.5944 / T) + (-0.03143806111 * T) + (0.00002034543662 * T ^ 2)), 10)

            ElseIf Me.Type = RefrigerantType.R502 Then
            evapPressure = Round(10 ^ (10.644955 + (-3671.153813 / T) + (-0.369835 * (Log(T) / Log(10))) + (-0.001746352 * T) + ((0.8161139 * (654 - T)) / T) * (Log(654 - T) / Log(10))), 10)

        ElseIf Me.Type = RefrigerantType.R407c Then
                evapPressure = Round(m1.Calculate.e ^ (78.3549 + (-8101.06 / T) + (-9.51789 * Log(T)) + (0.0000053558 * (T ^ 2))), 10)

            ElseIf Me.Type = RefrigerantType.R134a Then
                evapPressure = Round(m1.Calculate.e ^ (22.98993635 + (-7243.876722 / T) + (-0.013362956 * T) + (0.00000692966 * T ^ 2) + ((0.1995548 * (674.72514 - T)) / T) * (Log(674.72514 - T))), 10)

            End If

      Return evapPressure

    End Function

   Public Function GetMF() As ArrayList
      Dim al As New ArrayList
      If Type = RefrigerantType.R507 Then
         al.Add(1.03)
         al.Add(1.02)
      ElseIf Type = RefrigerantType.R407c Then
         al.Add(0.96)
         al.Add(1.03)
      Else
         al.Add(1)
         al.Add(1)
      End If
      Return al
   End Function

#End Region

End Class
End Namespace