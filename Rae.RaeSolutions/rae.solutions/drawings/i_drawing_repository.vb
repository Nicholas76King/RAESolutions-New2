Option Strict Off

Imports rae.RaeSolutions.Business.Entities

Namespace rae.solutions.drawings

    Public Interface i_drawing_repository
        Function get_unit_cooler_electrical_data(ByVal unit As String) As unit_cooler_electrical_data
        Function GetChiller(ByVal model As String) As chiller_electrical_data
        Function get_evaporative_condenser_chiller(ByVal model As String, ByVal voltage As Integer) As chiller_electrical_data
        Function GetCondenser(ByVal model As String) As rae.solutions.condensers.condenser
        Function GetCondensingUnit(ByVal model, ByVal phase, ByVal voltage) As condensing_unit_data
        Function GetFanAmps(ByVal motorPartNum As String, ByVal voltage As Integer) As Double
        Function GetCompressorAmps(ByVal compressorFile As String, ByVal unitType As String, ByVal voltage As Integer, ByVal phase As Integer, ByVal hertz As Integer, ByVal division As String) As Double
        Function GetPumpPackageHp(ByVal mfg As String, ByVal gpm As Double, ByVal head As Double, ByVal system As PumpSystem) As Double
        Function GetPumpPackageMotorAmps(ByVal hp As Double, ByVal voltage As Integer) As Double
        Function GetPumpPackageWeights(ByVal flow As Double) As PumpPackageWeights

        Function GetPumpPackageConnectionSize(ByVal manufacturer As String, ByVal flow As Double, ByVal head As Double, ByVal system As PumpSystem) As String
        Function GetChillerConnectionSizes(ByVal model As String) As ConnectionSize
        Function GetCondensingUnitConnectionSizes(ByVal model As String) As CondensingUnitConnectionSizes
    End Interface

End Namespace