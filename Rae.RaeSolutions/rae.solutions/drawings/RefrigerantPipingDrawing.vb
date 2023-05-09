Imports System.Drawing
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities

Namespace rae.solutions.drawings

    Public Class RefrigerantPipingDrawing : Inherits DrawingBase

        Sub New(ByVal unit As EquipmentItem, ByVal targetUserGroup As user_group)
            MyBase.New(DrawingType.RefrigerantPiping, unit, targetUserGroup)

            ' suction temperature and refrigerant are used in head fan rules for D series
            ' suction temperature property is not applicable to all equipment types
            If unit.type = EquipmentType.CondensingUnit Then
                Dim cu = CType(unit, CondensingUnitEquipmentItem)
                SST = cu.specs.suction.value_or_default
                Refrigerant = cu.specs.refrigerant

                ' capacity is used for valve rules
                Capacity1 = cu.specs.capacity_1.value_or_default
                Capacity2 = cu.specs.capacity_2.value_or_default


                If DivisionName.ToLower = "tsi" Then
                    Capacity1 *= 12000
                    Capacity2 *= 12000
                End If


            ElseIf unit.type = EquipmentType.PumpPackage Then
                GPM = CType(unit, PumpEquipment).Flow.value_or_default
            ElseIf TypeOf unit Is chiller_equipment Then
                Dim chiller = CType(unit, chiller_equipment)
                ChillerCapacityPerCircuit = Convert.TonsToBtuh(chiller.Specs.CapacityPerUnit)
                Refrigerant = chiller.Specs.Refrigerant
            End If


            addChillerOptions()


            Me.setConnectionSizes()
            Me.setElectricalInfo()
        End Sub


        Private Sub addChillerOptions()
            If Options.Contains("CK01") Then
                If Not Options.Contains("MD03") Then
                    Dim tOption As New EquipmentOption
                    tOption.Code = "MD03"
                    tOption.Description = "System Inserted"
                    Options.Add(tOption)
                End If
                If Not Options.Contains("MA01") Then
                    Dim tOption As New EquipmentOption
                    tOption.Code = "MA01"
                    tOption.Description = "System Inserted"
                    Options.Add(tOption)
                End If
                If Not Options.Contains("MV06") Then
                    Dim tOption As New EquipmentOption
                    tOption.Code = "MV06"
                    tOption.Description = "System Inserted"
                    Options.Add(tOption)
                End If
                If Not Options.Contains("MS02") Then
                    Dim tOption As New EquipmentOption
                    tOption.Code = "MS02"
                    tOption.Description = "System Inserted"
                    Options.Add(tOption)
                End If
            End If
        End Sub


        ''' <summary>Circuit info (i forgot what this is for ask cliff)</summary>
        Property CircuitInfo As String
            Get
                Return _circuitInfo
            End Get
            Set(ByVal value As String)
                _circuitInfo = value
            End Set
        End Property

        ''' <summary>Saturated suction temperature in degrees Fahrenheit</summary>
        Property SST As Double
            Get
                Return _sst
            End Get
            Set(ByVal value As Double)
                _sst = value
            End Set
        End Property

        ''' <summary>Refrigerant (ex. R22)</summary>
        Property Refrigerant As String
            Get
                Return _refrigerant
            End Get
            Set(ByVal value As String)
                _refrigerant = value
            End Set
        End Property

        ''' <summary>Capacity for circuit 1 in BTUH</summary>
        Property Capacity1 As Double
            Get
                Return _capacity1
            End Get
            Set(ByVal value As Double)
                _capacity1 = value
            End Set
        End Property

        Property Capacity2 As Double
            Get
                Return _capacity2
            End Get
            Set(ByVal value As Double)
                _capacity2 = value
            End Set
        End Property

        Property Capacity3 As Double
            Get
                Return _capacity3
            End Get
            Set(ByVal value As Double)
                _capacity3 = value
            End Set
        End Property

        Property Capacity4 As Double
            Get
                Return _capacity4
            End Get
            Set(ByVal value As Double)
                _capacity4 = value
            End Set
        End Property

        Property GPM As Double
            Get
                Return _gpm
            End Get
            Set(ByVal value As Double)
                _gpm = value
            End Set
        End Property

        Property ChillerCapacityPerCircuit As Double
            Get
                Return _chillerCapacityPerCircuit
            End Get
            Set(ByVal value As Double)
                _chillerCapacityPerCircuit = value
            End Set
        End Property

        Private _capacity1, _capacity2, _capacity3, _capacity4, _gpm, _chillerCapacityPerCircuit As Double
        Private _refrigerant, _circuitInfo As String
        Private _sst As Double

    End Class

End Namespace