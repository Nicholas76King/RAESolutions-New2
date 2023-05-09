Namespace Rae.RaeSolutions.Business.Entities

    Public Class PumpDbModel

        Sub New(ByVal manufacturer As String, ByVal flow As Double, ByVal head As Double, ByVal sys As PumpSystem)
            setModel(manufacturer, flow, head, sys)
        End Sub


        ReadOnly Property Series As String
            Get
                Return _series
            End Get
        End Property : Private _series As String

        ReadOnly Property Model As String
            Get
                Return _model
            End Get
        End Property : Private _model As String

        ReadOnly Property FullModel As String
            Get
                Return _series & _model
            End Get
        End Property : Private _fullModel As String



        Private Sub setModel(ByVal mfg As String, ByVal flow As Double, ByVal head As Double, ByVal system As PumpSystem)
            'P(ump)P(ackage)(Flow)20(Mfg)A(rmstrong)(Head)50
            'PPS20A50

            Dim sys As String
            If system = PumpSystem.Single Then
                sys = "S"
            Else
                sys = "D"
            End If

            'PPS20
            Dim flowRangeLimit = New FlowRange().LimitFor(flow)
            _series = "PP" & sys & flowRangeLimit

            Dim m As String
            If mfg = "Armstrong Pumps" Then
                m = "A"
            Else
                m = "B"
            End If
            'A50
            _model = m & head
        End Sub



    End Class

    Class FlowRange
        Function LimitFor(ByVal flow As Double) As Double
            Dim upper As Double

            Dim limits As Double() = {20, 30, 45, 80, 130, 200, 380, 450, 650, 750}

            For Each limit In limits    ' ERICC 20120403
                If flow <= limit Then
                    upper = limit
                    Exit For
                End If
            Next

            Return upper
        End Function
    End Class

End Namespace