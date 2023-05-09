Option Strict On
Option Explicit On

Imports System.Data
Namespace Rae.RaeSolutions.Business.Entities

    Public Class Coil

#Region " Enums"

        Public Enum CoilType
            Condenser
            Evaporator
        End Enum

        Public Enum FinType
            Flat = 2
            Waffle = 1
        End Enum

        Public Shared Function Diameters(ByVal cm As CoilModes, Optional ByVal c As CoilTypes = CoilTypes.W) As System.Collections.Hashtable
            Dim hash As New System.Collections.Hashtable
            hash.Add(0.625, 58)
            If cm = CoilModes.Rae Then
                If c = CoilTypes.SD Then
                    hash.Add(1, 11)
                ElseIf c = CoilTypes.S Then
                Else
                    hash.Add(0.5, 12)
                End If
            Else
                hash.Add(0.875, 78)
            End If
            Return hash
      End Function

      Public Enum FinMaterials
         AL = 1
         CU = 2
      End Enum

      Public Enum TubeMaterials
         CU = 1
         SS = 2
         ST = 3
         AL = 4
      End Enum

      Public Shared Function FinThicknesses() As System.Collections.Hashtable
         Dim hash As New System.Collections.Hashtable
         hash.Add(".006", 0.006)
         hash.Add(".008", 0.008)
         hash.Add(".010", 0.01)
         Return hash
      End Function

      Public Shared Function TubeThicknesses() As System.Collections.Hashtable
         Dim hash As New System.Collections.Hashtable
         hash.Add(".020", 0.02)
         hash.Add(".025", 0.025)
         hash.Add(".035", 0.035)
         hash.Add(".049", 0.049)
         Return hash
      End Function

      Public Enum FluidTypes
         Water = 1
         EthyleneGlycol = 2
         PropyleneGlycol = 3
      End Enum

      Public Enum Orientations
         L = 2
         R = 1
         V = 3
      End Enum

      Public Enum CoilTypes
         W = 1
         D = 2
         S = 3
         SD = 4
         C = 5
      End Enum

      Public Enum CoilModes
         Rae = 1
         King = 2
      End Enum


#End Region


#Region " Properties"

        Private tubeSurface_ As String
        Public Property TubeSurface() As String
            Get
                Return tubeSurface_
            End Get
            Set(ByVal value As String)
                tubeSurface_ = value
            End Set
        End Property


      Private diameter_ As Double
      Public Property Diameter() As Double
         Get
            Return diameter_
         End Get
         Set(ByVal value As Double)
            diameter_ = value
         End Set
      End Property

      Private numRows_ As Double
      Public Property NumRows() As Double
         Get
            Return numRows_
         End Get
         Set(ByVal value As Double)
            numRows_ = value
         End Set
      End Property

      Private fileName_ As String
      Public Property FileName() As String
         Get
            If fileName_ = String.Empty Then
               SetFileName()
            End If
            Return fileName_
         End Get
         Set(ByVal value As String)
            fileName_ = value
         End Set
      End Property

      Private coilApplication_ As CoilType = CoilType.Condenser
      Public Property CoilApplication() As CoilType
         Get
            Return coilApplication_
         End Get
         Set(ByVal value As CoilType)
            coilApplication_ = value
         End Set
      End Property

      Private finDesign_ As FinType = FinType.Waffle
      Public Property FinDesign() As FinType
         Get
            Return finDesign_
         End Get
         Set(ByVal value As FinType)
            finDesign_ = value
         End Set
      End Property

      Public ReadOnly Property Description() As String
         Get
            '0.625" diameter, 4 row(W) Evaporator

            Dim finDesignAbbreviation As String
            If finDesign_ = FinType.Flat Then
               finDesignAbbreviation = "F"
            ElseIf finDesign_ = FinType.Waffle Then
               finDesignAbbreviation = "W"
            Else
               Throw New ApplicationException("Coil fin design is not valid.")
            End If

                Dim description_ As String = diameter_.ToString() & """ Diameter, " & numRows_.ToString() & " Row(" & finDesignAbbreviation & ") " & coilApplication_.ToString() & " (" & tubeSurface_.ToString & ")"

            Return description_
         End Get
      End Property

      Private finheight_ As Double
      Public Property FinHeight() As Double
         Get
            Return finheight_
         End Get
         Set(ByVal value As Double)
            finheight_ = value
         End Set
      End Property

      Private finlength_ As Double
      Public Property FinLength() As Double
         Get
            Return finlength_
         End Get
         Set(ByVal value As Double)
            finlength_ = value
         End Set
      End Property

      Private fpi_ As Integer
      Public Property FPI() As Integer
         Get
            Return fpi_
         End Get
         Set(ByVal value As Integer)
            fpi_ = value
         End Set
      End Property

      Private orientation_ As Orientations = Orientations.R
      Public Property Orientation() As Orientations
         Get
            Return orientation_
         End Get
         Set(ByVal value As Orientations)
            orientation_ = value
         End Set
      End Property

      Private circuiting_ As FluidCoolerCircuiting = New FluidCoolerCircuiting
      Public Property Circuiting() As FluidCoolerCircuiting
         Get
            Return circuiting_
         End Get
         Set(ByVal value As FluidCoolerCircuiting)
            circuiting_ = value
         End Set
      End Property

      Public ReadOnly Property ModelNumber() As String
         Get
            Dim strD As String = String.Empty
            Dim ds As System.Collections.Hashtable = Diameters(Me.CoilMode, Me.CoilUseType)
            If ds.Contains(Me.Diameter) Then
               strD = Diameters(Me.CoilMode).Item(Diameter).ToString()
            Else
               For Each k As Object In ds.Keys
                  strD = ds.Item(k).ToString()
                  Me.Diameter = CDbl(k)
                  Exit For
               Next
            End If
            Return strD & CoilUseType.ToString() & FinHeight & "x" & FinLength.ToString() & "-" & FPI.ToString & "-" & NumRows.ToString() & "-" & FinDesign.ToString().Substring(0, 1) & Circuiting.FluidCoolerCircuitingType & Orientation.ToString()
         End Get
      End Property

      Private coilmode_ As CoilModes = CoilModes.Rae
      Public Property CoilMode() As CoilModes
         Get
            Return coilmode_
         End Get
         Set(ByVal value As CoilModes)
            coilmode_ = value
         End Set
      End Property

      Private coilUseType_ As CoilTypes = CoilTypes.W
      Public Property CoilUseType() As CoilTypes
         Get
            Return coilUseType_
         End Get
         Set(ByVal value As CoilTypes)
            coilUseType_ = value
         End Set
      End Property

      Private finMaterial_ As FinMaterials = FinMaterials.AL
      Public Property FinMaterial() As FinMaterials
         Get
            Return finMaterial_
         End Get
         Set(ByVal value As FinMaterials)
            finMaterial_ = value
         End Set
      End Property

      Private tubeMaterial_ As TubeMaterials = TubeMaterials.CU
      Public Property TubeMaterial() As TubeMaterials
         Get
            Return tubeMaterial_
         End Get
         Set(ByVal value As TubeMaterials)
            tubeMaterial_ = value
         End Set
      End Property

      Private finThickness_ As Double = 0
      Public Property FinThickness() As Double
         Get
            Return finThickness_
         End Get
         Set(ByVal value As Double)
            finThickness_ = value
         End Set
      End Property

      Private tubeThickness_ As Double = 0
      Public Property TubeThickness() As Double
         Get
            Return tubeThickness_
         End Get
         Set(ByVal value As Double)
            tubeThickness_ = value
         End Set
      End Property

#End Region

      Private Sub SetFileName()
         Dim str As String = String.Empty
         If Me.CoilApplication = CoilType.Condenser Then
            If Me.Diameter = 0.625 Then
               str = Me.NumRows.ToString() & "RCOND.58"
            ElseIf Me.Diameter = 0.5 Then
               str = Me.NumRows.ToString() & "RCOND"
            End If
         Else
            If Me.Diameter = 0.625 Then
               If Me.FinDesign = FinType.Waffle Then
                  str = Me.NumRows.ToString() & "REVAP.58W"
               Else
                  str = Me.NumRows.ToString() & "REVAP.58"
               End If
            ElseIf Me.Diameter = 0.5 Then
               If Me.FinDesign = FinType.Waffle Then
                  str = Me.NumRows.ToString() & "REVAP.12W"
               Else
                  str = Me.NumRows.ToString() & "REVAP.12"
               End If
            End If
         End If
         fileName_ = str
      End Sub

        Public Sub New(ByVal diameter As Double, ByVal numRows As Double, ByVal fileName As String, _
        ByVal coilApplication As CoilType, ByVal finDesign As FinType, ByVal tubeSurface As String)
            diameter_ = diameter
            numRows_ = numRows
            fileName_ = fileName
            coilApplication_ = coilApplication
            finDesign_ = finDesign
            tubeSurface_ = tubeSurface
        End Sub

        'Public Sub New(ByVal diameter As Double, ByVal numRows As Double, ByVal coilApplication As CoilType, ByVal finDesign As FinType, ByVal tubeSurface As String)
        '    diameter_ = diameter
        '    numRows_ = numRows
        '    coilApplication_ = coilApplication
        '    finDesign_ = finDesign
        '    '    tubeSurface_ = tubeSurface
        'End Sub

      'Public Sub New(ByVal dr As System.Data.DataRow)

      'End Sub

      Public Sub New()

      End Sub


      Public Overrides Function ToString() As String
         Return Me.Description
      End Function

      Public Function GetDiameters() As DataTable

         'Select Case Me.CoilType
         '    case coiltype.
         'End Select
         If CoilMode = CoilModes.Rae Then

         Else

         End If
      End Function

   End Class

End Namespace