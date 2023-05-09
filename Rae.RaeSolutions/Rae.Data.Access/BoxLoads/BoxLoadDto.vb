Imports System.Reflection
Imports Rae.Reflection

Namespace Rae.Data.Access

''' <summary>
''' Box load data transfer object
''' </summary>
Public Class BoxLoadDto
   Implements IItemDto

#Region " Properties"

   ''' <summary>
   ''' Database ID
   ''' </summary>
   Property Id() As Integer _
   Implements IItemDto.Id
      Get
         Return id_
      End Get
      Set(ByVal value As Integer)
         id_ = value
      End Set
   End Property : Protected id_ As Integer

   ''' <summary>
   ''' Process/Item ID
   ''' </summary>
   Property ItemId() As String _
   Implements IItemDto.ItemId
      Get
         Return itemId_
      End Get
      Set(ByVal value As String)
         itemId_ = value
      End Set
   End Property : Protected itemId_ As String

   ''' <summary>
   ''' Item revision
   ''' </summary>
   Property ItemRevision() As Integer _
   Implements IItemDto.ItemRevision
      Get
         Return itemRevision_
      End Get
      Set(ByVal value As Integer)
         itemRevision_ = value
      End Set
   End Property : Protected itemRevision_ As Integer


   ''' <summary>
   ''' Project ID
   ''' </summary>
   Property ProjectId() As String
      Get
         Return projectId_
      End Get
      Set(ByVal value As String)
         projectId_ = value
      End Set
   End Property : Protected projectId_ As String


   Property ProjectRevision() As Integer
      Get
         Return projectRevision_
      End Get
      Set(ByVal value As Integer)
         projectRevision_ = value
      End Set
   End Property : Protected projectRevision_ As Integer
   
   
   Property BlName() As String
      Get
         Return blName_
      End Get
      Set(ByVal value As String)
         blName_ = value
      End Set
   End Property : Protected blName_ As String



   Protected description_ As String
   Protected userCapacity_ As String
   Protected userCapacityChecked_ As Boolean
   Protected ambient_ As String

   ''' <summary>
   ''' Description
   ''' </summary>
   Property Description() As String
      Get
         Return description_
      End Get
      Set(ByVal value As String)
         description_ = value
      End Set
   End Property


   ''' <summary>
   ''' Capacity the user entered
   ''' </summary>
   Property UserCapacity() As String
      Get
         Return userCapacity_
      End Get
      Set(ByVal value As String)
         userCapacity_ = value
      End Set
   End Property


   ''' <summary>
   ''' User capacity
   ''' </summary>
   Property UserCapacityChecked() As Boolean
      Get
         Return userCapacityChecked_
      End Get
      Set(ByVal value As Boolean)
         userCapacityChecked_ = value
      End Set
   End Property


   ''' <summary>
   ''' Ambient temperature
   ''' </summary>
   Property Ambient() As String
      Get
         Return ambient_
      End Get
      Set(ByVal value As String)
         ambient_ = value
      End Set
   End Property



   ''' <summary>
   ''' External wet bulb
   ''' </summary>
   Property ExtWb() As String
      Get
         Return externalWb_
      End Get
      Set(ByVal value As String)
         externalWb_ = value
      End Set
   End Property : Protected externalWb_ As String



   ''' <summary>
   ''' Room temperature
   ''' </summary>
   Property RmTemp() As String
      Get
         Return roomTemperature_
      End Get
      Set(ByVal value As String)
         roomTemperature_ = value
      End Set
   End Property : Protected roomTemperature_ As String


   Property ExtTempW1() As String
      Get
         Return externalWallTemperature1_
      End Get
      Set(ByVal value As String)
         externalWallTemperature1_ = value
      End Set
   End Property : Protected externalWallTemperature1_ As String

   Property ExtTempW2() As String
      Get
         Return externalWallTemperature2_
      End Get
      Set(ByVal value As String)
         externalWallTemperature2_ = value
      End Set
   End Property : Protected externalWallTemperature2_ As String

   Property ExtTempW3() As String
      Get
         Return externalWallTemperature3_
      End Get
      Set(ByVal value As String)
         externalWallTemperature3_ = value
      End Set
   End Property : Protected externalWallTemperature3_ As String

   Property ExtTempW4() As String
      Get
         Return externalWallTemperature4_
      End Get
      Set(ByVal value As String)
         externalWallTemperature4_ = value
      End Set
   End Property : Protected externalWallTemperature4_ As String

   Property ExtTempW5() As String
      Get
         Return externalWallTemperature5_
      End Get
      Set(ByVal value As String)
         externalWallTemperature5_ = value
      End Set
   End Property : Protected externalWallTemperature5_ As String

   Property ExtTempW6() As String
      Get
         Return externalWallTemperature6_
      End Get
      Set(ByVal value As String)
         externalWallTemperature6_ = value
      End Set
   End Property : Protected externalWallTemperature6_ As String



   Property InsulW1() As String
      Get
         Return insulW1_
      End Get
      Set(ByVal value As String)
         insulW1_ = value
      End Set
   End Property : Protected insulW1_ As String

   Property InsulW2() As String
      Get
         Return insulW2_
      End Get
      Set(ByVal value As String)
         insulW2_ = value
      End Set
   End Property : Protected insulW2_ As String

   Property InsulW3() As String
      Get
         Return insulW3_
      End Get
      Set(ByVal value As String)
         insulW3_ = value
      End Set
   End Property : Protected insulW3_ As String

   Property InsulW4() As String
      Get
         Return insulW4_
      End Get
      Set(ByVal value As String)
         insulW4_ = value
      End Set
   End Property : Protected insulW4_ As String

   Property InsulW5() As String
      Get
         Return insulW5_
      End Get
      Set(ByVal value As String)
         insulW5_ = value
      End Set
   End Property : Protected insulW5_ As String

   Property InsulW6() As String
      Get
         Return insulW6_
      End Get
      Set(ByVal value As String)
         insulW6_ = value
      End Set
   End Property : Protected insulW6_ As String


   Property ThickW1() As String
      Get
         Return thickW1_
      End Get
      Set(ByVal value As String)
         thickW1_ = value
      End Set
   End Property : Protected thickW1_ As String

   Property ThickW2() As String
      Get
         Return thickW2_
      End Get
      Set(ByVal value As String)
         thickW2_ = value
      End Set
   End Property : Protected thickW2_ As String

   Property ThickW3() As String
      Get
         Return thickW3_
      End Get
      Set(ByVal value As String)
         thickW3_ = value
      End Set
   End Property : Protected thickW3_ As String

   Property ThickW4() As String
      Get
         Return thickW4_
      End Get
      Set(ByVal value As String)
         thickW4_ = value
      End Set
   End Property : Protected thickW4_ As String

   Property ThickW5() As String
      Get
         Return thickW5_
      End Get
      Set(ByVal value As String)
         thickW5_ = value
      End Set
   End Property : Protected thickW5_ As String

   Property ThickW6() As String
      Get
         Return thickW6_
      End Get
      Set(ByVal value As String)
         thickW6_ = value
      End Set
   End Property : Protected thickW6_ As String


   Property KFactorW1() As String
      Get
         Return kFactorW1_
      End Get
      Set(ByVal value As String)
         kFactorW1_ = value
      End Set
   End Property : Protected kFactorW1_ As String

   Property KFactorW2() As String
      Get
         Return kFactor2_
      End Get
      Set(ByVal value As String)
         kFactor2_ = value
      End Set
   End Property : Protected kFactor2_ As String

   Property KFactorW3() As String
      Get
         Return kFactor3_
      End Get
      Set(ByVal value As String)
         kFactor3_ = value
      End Set
   End Property : Protected kFactor3_ As String

   Property KFactorW4() As String
      Get
         Return kFactor4_
      End Get
      Set(ByVal value As String)
         kFactor4_ = value
      End Set
   End Property : Protected kFactor4_ As String

   Property KFactorW5() As String
      Get
         Return kFactor5_
      End Get
      Set(ByVal value As String)
         kFactor5_ = value
      End Set
   End Property : Protected kFactor5_ As String

   Property KFactorW6() As String
      Get
         Return kFactor6_
      End Get
      Set(ByVal value As String)
         kFactor6_ = value
      End Set
   End Property : Protected kFactor6_ As String

   Property WallTot() As String
      Get
         Return wallTotal_
      End Get
      Set(ByVal value As String)
         wallTotal_ = value
      End Set
   End Property : Protected wallTotal_ As String

   Property FExtTemp() As String
      Get
         Return fExtTemp_
      End Get
      Set(ByVal value As String)
         fExtTemp_ = value
      End Set
   End Property : Protected fExtTemp_ As String

   Property InsulF() As String
      Get
         Return insulF_
      End Get
      Set(ByVal value As String)
         insulF_ = value
      End Set
   End Property : Protected insulF_ As String

   Property ThickF() As String
      Get
         Return thickF_
      End Get
      Set(ByVal value As String)
         thickF_ = value
      End Set
   End Property : Protected thickF_ As String

   Property KFactorF() As String
      Get
         Return kFactorF_
      End Get
      Set(ByVal value As String)
         kFactorF_ = value
      End Set
   End Property : Protected kFactorF_ As String

   Property FloorTot() As String
      Get
         Return floorTotal_
      End Get
      Set(ByVal value As String)
         floorTotal_ = value
      End Set
   End Property : Protected floorTotal_ As String

   Property CExtTemp() As String
      Get
         Return cExtTemp_
      End Get
      Set(ByVal value As String)
         cExtTemp_ = value
      End Set
   End Property : Protected cExtTemp_ As String

   Property InsulC() As String
      Get
         Return insulC_
      End Get
      Set(ByVal value As String)
         insulC_ = value
      End Set
   End Property : Protected insulC_ As String

   Property ThickC() As String
      Get
         Return thickC_
      End Get
      Set(ByVal value As String)
         thickC_ = value
      End Set
   End Property : Protected thickC_ As String

   Property KFactorC() As String
      Get
         Return kFactorC_
      End Get
      Set(ByVal value As String)
         kFactorC_ = value
      End Set
   End Property : Protected kFactorC_ As String

   Property CeilingTot() As String
      Get
         Return ceilingTotal_
      End Get
      Set(ByVal value As String)
         ceilingTotal_ = value
      End Set
   End Property : Protected ceilingTotal_ As String

   Property TransTot() As String
      Get
         Return transTotal_
      End Get
      Set(ByVal value As String)
         transTotal_ = value
      End Set
   End Property : Protected transTotal_ As String

   Property IVolume() As String
      Get
         Return iVolume_
      End Get
      Set(ByVal value As String)
         iVolume_ = value
      End Set
   End Property : Protected iVolume_ As String

   Property InfWb() As String
      Get
         Return infWb_
      End Get
      Set(ByVal value As String)
         infWb_ = value
      End Set
   End Property : Protected infWb_ As String

   Property InfDb() As String
      Get
         Return infDb_
      End Get
      Set(ByVal value As String)
         infDb_ = value
      End Set
   End Property : Protected infDb_ As String

   Property IFactor() As String
      Get
         Return iFactor_
      End Get
      Set(ByVal value As String)
         iFactor_ = value
      End Set
   End Property : Protected iFactor_ As String

   Property IAirChg() As String
      Get
         Return iAirChange_
      End Get
      Set(ByVal value As String)
         iAirChange_ = value
      End Set
   End Property : Protected iAirChange_ As String

   Property TotInfil() As String
      Get
         Return totalInfil_
      End Get
      Set(ByVal value As String)
         totalInfil_ = value
      End Set
   End Property : Protected totalInfil_ As String

   Property RoomArea() As String
      Get
         Return roomArea_
      End Get
      Set(ByVal value As String)
         roomArea_ = value
      End Set
   End Property : Protected roomArea_ As String

   Property RoomVolume() As String
      Get
         Return roomVolume_
      End Get
      Set(ByVal value As String)
         roomVolume_ = value
      End Set
   End Property : Protected roomVolume_ As String

   Property Wall1() As String
      Get
         Return wall1_
      End Get
      Set(ByVal value As String)
         wall1_ = value
      End Set
   End Property : Protected wall1_ As String

   Property Wall2() As String
      Get
         Return wall2_
      End Get
      Set(ByVal value As String)
         wall2_ = value
      End Set
   End Property : Protected wall2_ As String

   Property Wall3() As String
      Get
         Return wall3_
      End Get
      Set(ByVal value As String)
         wall3_ = value
      End Set
   End Property : Protected wall3_ As String

   Property Wall4() As String
      Get
         Return wall4_
      End Get
      Set(ByVal value As String)
         wall4_ = value
      End Set
   End Property : Protected wall4_ As String

   Property Wall5() As String
      Get
         Return wall5_
      End Get
      Set(ByVal value As String)
         wall5_ = value
      End Set
   End Property : Protected wall5_ As String

   Property Wall6() As String
      Get
         Return wall6_
      End Get
      Set(ByVal value As String)
         wall6_ = value
      End Set
   End Property : Protected wall6_ As String

   Property Height1() As String
      Get
         Return height1_
      End Get
      Set(ByVal value As String)
         height1_ = value
      End Set
   End Property : Protected height1_ As String

   Property Height2() As String
      Get
         Return height2_
      End Get
      Set(ByVal value As String)
         height2_ = value
      End Set
   End Property : Protected height2_ As String

   Property Height3() As String
      Get
         Return height3_
      End Get
      Set(ByVal value As String)
         height3_ = value
      End Set
   End Property : Protected height3_ As String

   Property Height4() As String
      Get
         Return height4_
      End Get
      Set(ByVal value As String)
         height4_ = value
      End Set
   End Property : Protected height4_ As String

   Property Height5() As String
      Get
         Return height5_
      End Get
      Set(ByVal value As String)
         height5_ = value
      End Set
   End Property : Protected height5_ As String

   Property Height6() As String
      Get
         Return height6_
      End Get
      Set(ByVal value As String)
         height6_ = value
      End Set
   End Property : Protected height6_ As String

   Property txtImageCounter() As String
      Get
         Return txtImageCounter_
      End Get
      Set(ByVal value As String)
         txtImageCounter_ = value
      End Set
   End Property : Protected txtImageCounter_ As String

   Property rdoRectangle() As Boolean
      Get
         Return rdoRectangle_
      End Get
      Set(ByVal value As Boolean)
         rdoRectangle_ = value
      End Set
   End Property : Protected rdoRectangle_ As Boolean

   Property WattL() As String
      Get
         Return wattL_
      End Get
      Set(ByVal value As String)
         wattL_ = value
      End Set
   End Property : Protected wattL_ As String

   Property TotOl() As String
      Get
         Return totalOl_
      End Get
      Set(ByVal value As String)
         totalOl_ = value
      End Set
   End Property : Protected totalOl_ As String

   Property MotorHp() As String
      Get
         Return motorHp_
      End Get
      Set(ByVal value As String)
         motorHp_ = value
      End Set
   End Property : Protected motorHp_ As String

   Property TotOm() As String
      Get
         Return totalOm_
      End Get
      Set(ByVal value As String)
         totalOm_ = value
      End Set
   End Property : Protected totalOm_ As String

   Property People() As String
      Get
         Return people_
      End Get
      Set(ByVal value As String)
         people_ = value
      End Set
   End Property : Protected people_ As String

   Property TotOP() As String
      Get
         Return totalOP_
      End Get
      Set(ByVal value As String)
         totalOP_ = value
      End Set
   End Property : Protected totalOP_ As String

   Property OtherType() As String
      Get
         Return otherType_
      End Get
      Set(ByVal value As String)
         otherType_ = value
      End Set
   End Property : Protected otherType_ As String

   Property OtherBtu() As String
      Get
         Return otherBtu_
      End Get
      Set(ByVal value As String)
         otherBtu_ = value
      End Set
   End Property : Protected otherBtu_ As String

   Property TotOo() As String
      Get
         Return totalOo_
      End Get
      Set(ByVal value As String)
         totalOo_ = value
      End Set
   End Property : Protected totalOo_ As String

   Property OtherTot() As String
      Get
         Return otherTotal_
      End Get
      Set(ByVal value As String)
         otherTotal_ = value
      End Set
   End Property : Protected otherTotal_ As String

   Property ForkLift() As String
      Get
         Return forkLift_
      End Get
      Set(ByVal value As String)
         forkLift_ = value
      End Set
   End Property : Protected forkLift_ As String

   Property TotForkLift() As String
      Get
         Return totalForkLift_
      End Get
      Set(ByVal value As String)
         totalForkLift_ = value
      End Set
   End Property : Protected totalForkLift_ As String

   Property DockDoors() As String
      Get
         Return dockDoors_
      End Get
      Set(ByVal value As String)
         dockDoors_ = value
      End Set
   End Property : Protected dockDoors_ As String

   Property TotDockDoors() As String
      Get
         Return dockDoorsTotal_
      End Get
      Set(ByVal value As String)
         dockDoorsTotal_ = value
      End Set
   End Property : Protected dockDoorsTotal_ As String

   Property SumTran() As String
      Get
         Return sumTran_
      End Get
      Set(ByVal value As String)
         sumTran_ = value
      End Set
   End Property : Protected sumTran_ As String

   Property SumInf() As String
      Get
         Return sumInf_
      End Get
      Set(ByVal value As String)
         sumInf_ = value
      End Set
   End Property : Protected sumInf_ As String

   Property SumProd() As String
      Get
         Return sumProd_
      End Get
      Set(ByVal value As String)
         sumProd_ = value
      End Set
   End Property : Protected sumProd_ As String

   Property SumOther() As String
      Get
         Return sumOther_
      End Get
      Set(ByVal value As String)
         sumOther_ = value
      End Set
   End Property : Protected sumOther_ As String

   Property SumTot() As String
      Get
         Return sumTotal_
      End Get
      Set(ByVal value As String)
         sumTotal_ = value
      End Set
   End Property : Protected sumTotal_ As String

   Property Safety() As String
      Get
         Return safety_
      End Get
      Set(ByVal value As String)
         safety_ = value
      End Set
   End Property : Protected safety_ As String

   Property SafetyTot() As String
      Get
         Return safetyTotal_
      End Get
      Set(ByVal value As String)
         safetyTotal_ = value
      End Set
   End Property : Protected safetyTotal_ As String

   Property RunVar() As String
      Get
         Return runVar_
      End Get
      Set(ByVal value As String)
         runVar_ = value
      End Set
   End Property : Protected runVar_ As String

   Property RunVarTot() As String
      Get
         Return runVarTotal_
      End Get
      Set(ByVal value As String)
         runVarTotal_ = value
      End Set
   End Property : Protected runVarTotal_ As String

   Property LoadTot() As String
      Get
         Return loadTotal_
      End Get
      Set(ByVal value As String)
         loadTotal_ = value
      End Set
   End Property : Protected loadTotal_ As String

   Property btnAllWallSy() As Boolean
      Get
         Return btnAllWallSy_
      End Get
      Set(ByVal value As Boolean)
         btnAllWallSy_ = value
      End Set
   End Property : Protected btnAllWallSy_ As Boolean

   Property btnAllWallSn() As Boolean
      Get
         Return btnAllWallSn_
      End Get
      Set(ByVal value As Boolean)
         btnAllWallSn_ = value
      End Set
   End Property : Protected btnAllWallSn_ As Boolean

   Property MyState() As String
      Get
         Return myState_
      End Get
      Set(ByVal value As String)
         myState_ = value
      End Set
   End Property : Protected myState_ As String

   Property MyCity() As String
      Get
         Return myCity_
      End Get
      Set(ByVal value As String)
         myCity_ = value
      End Set
   End Property : Protected myCity_ As String

   Property KFactors() As Boolean
      Get
         Return kFactors_
      End Get
      Set(ByVal value As Boolean)
         kFactors_ = value
      End Set
   End Property : Protected kFactors_ As Boolean

   Property Rw1() As Single
      Get
         Return rw1_
      End Get
      Set(ByVal value As Single)
         rw1_ = value
      End Set
   End Property : Protected rw1_ As Single

   Property Rw2() As Single
      Get
         Return rw2_
      End Get
      Set(ByVal value As Single)
         rw2_ = value
      End Set
   End Property : Protected rw2_ As Single

   Property Rw3() As Single
      Get
         Return rw3_
      End Get
      Set(ByVal value As Single)
         rw3_ = value
      End Set
   End Property : Protected rw3_ As Single

   Property Rw4() As Single
      Get
         Return rw4_
      End Get
      Set(ByVal value As Single)
         rw4_ = value
      End Set
   End Property : Protected rw4_ As Single

   Property Rw5() As Single
      Get
         Return rw5_
      End Get
      Set(ByVal value As Single)
         rw5_ = value
      End Set
   End Property : Protected rw5_ As Single

   Property Rw6() As Single
      Get
         Return rw6_
      End Get
      Set(ByVal value As Single)
         rw6_ = value
      End Set
   End Property : Protected rw6_ As Single

   Property RwFloor() As Single
      Get
         Return rwFloor_
      End Get
      Set(ByVal value As Single)
         rwFloor_ = value
      End Set
   End Property : Protected rwFloor_ As Single

   Property RwCeiling() As Single
      Get
         Return rwCeiling_
      End Get
      Set(ByVal value As Single)
         rwCeiling_ = value
      End Set
   End Property : Protected rwCeiling_ As Single

   
   Property RoomNumber() As String
      Get
         Return roomNumber_
      End Get
      Set(ByVal value As String)
         roomNumber_ = value
      End Set
   End Property : Protected roomNumber_ As String
   
   
   Property RMWB As String
      Get
         Return _rmWb
      End Get
      Set(value As String)
         _rmWb = value
      End Set
   End Property : Protected _rmWb As String

#End Region

   Sub GetValuesFrom(reader As System.Data.IDataReader)
      fillDto(Me, reader)
   End Sub
   
   
   Private Sub fillDto(ByRef dto As Object, ByVal reader As System.Data.IDataReader)
      Dim properties As PropertyInfo()
      properties = dto.GetType.GetProperties(BindingFlags.Instance Or BindingFlags.Public)

      Dim value As Object
      Dim columnName As String

      For Each [property] As PropertyInfo In properties
         If Not reflector.HasAttribute([property], GetType(ExcludeAttribute)) Then
            ' gets column name which is assumed to be the same as the property name
            columnName = [property].Name
            ' gets value in column
            value = reader(columnName)
            
            If value Is System.DBNull.Value Then
               If [property].PropertyType Is GetType(System.String) Then
                  value = Rae.ConvertNull.ToString(value)
               ElseIf [property].PropertyType Is GetType(Integer) Then
                  value = Rae.ConvertNull.ToInteger(value)
               ElseIf [property].PropertyType Is GetType(Double) Then
                  value = Rae.ConvertNull.ToDouble(value)
               ElseIf [property].PropertyType Is GetType(Single) Then
                  value = Rae.ConvertNull.ToSingle(value)
               ElseIf [property].PropertyType Is GetType(Boolean) Then
                  value = Rae.ConvertNull.ToBoolean(value)
               Else
                  Throw New Exception("Cannot fill data transfer object through reflection. DBNull was not converted to a type.")
               End If
            End If
            ' sets value of property in data transfer object
            [property].SetValue(dto, value, Nothing)
         End If
      Next

   End Sub
End Class

End Namespace