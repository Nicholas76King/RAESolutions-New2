Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Entities

namespace rae.solutions.drawings

interface i_drawing_service
   function get_unit_cooler_electrical_info(unit as unit_cooler) as unit_cooler_electrical_info
   function get_condenser(_model as string) as condensers.condenser   

   Function GetPumpPackageElectricalInfo(pp As PumpEquipment) As pump_package_electrical_info
        Function GetChillerElectricalInfo(ByVal spec As chiller_electrical_spec, ByVal model_type As String) As chiller_electrical_info
   Function GetCondenserElectricalInfo(model As String, voltage As Integer) As condenser_electrical_info
   Function GetCondensingUnitElectricalInfo(model As String, voltage As Integer, phase As Integer, hertz As Integer, et10 As Boolean, mc20 As Boolean, division as Division) As condensing_unit_electrical_info
   
   Function GetPumpPackageConnectionSize(manufacturer As String, flow As Double, head As Double, system As PumpSystem) As String
   Function GetChillerConnectionSizes(chiller As chiller_equipment) As ConnectionSize
   Function GetCondensingUnitConnectionSizes(model As String, mc20 As Boolean) As List(Of ConnectionSize)
end interface

end namespace
