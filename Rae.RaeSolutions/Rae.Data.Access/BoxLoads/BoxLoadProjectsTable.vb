Namespace Rae.Data.Access

Class BoxLoadProjectsTable
   Inherits ItemTable
   
   Public Const TableName As String = "CoolStuffProjects"
   
   Public Const LinkedItemId As String = "LinkedItemId"
   Public Const LinkedItemRevision As String = "LinkedItemRevision"
   
   Public Const Description As String = "Description"
   Public Const Ambient As String = "Ambient"
   Public Const ExtWb As String = "ExtWb"
   Public Const RmTemp As String = "RmTemp"
   Public Const RmWb As String = "RmWb"
   Public Const RoomVolume As String = "RoomVolume"
   Public Const RoomArea As String = "RoomArea"
   Public Const Height As String = "Height"
   Public Const ExtTempW1 As String = "ExtTempW1"
   Public Const ExtTempW2 As String = "ExtTempW2"
   Public Const ExtTempW3 As String = "ExtTempW3"
   Public Const ExtTempW4 As String = "ExtTempW4"
   Public Const ExtTempW5 As String = "ExtTempW5"
   Public Const ExtTempW6 As String = "ExtTempW6"
   Public Const InsulW1 As String = "InsulW1"
   Public Const InsulW2 As String = "InsulW2"
   Public Const InsulW3 As String = "InsulW3"
   Public Const InsulW4 As String = "InsulW4"
   Public Const InsulW5 As String = "InsulW5"
   Public Const InsulW6 As String = "InsulW6"
   Public Const ThickW1 As String = "ThickW1"
   Public Const ThickW2 As String = "ThickW2"
   Public Const ThickW3 As String = "ThickW3"
   Public Const ThickW4 As String = "ThickW4"
   Public Const ThickW5 As String = "ThickW5"
   Public Const ThickW6 As String = "ThickW6"
   Public Const KFactorW1 As String = "KFactorW1"
   Public Const KFactorW2 As String = "KFactorW2"
   Public Const KFactorW3 As String = "KFactorW3"
   Public Const KFactorW4 As String = "KFactorW4"
   Public Const KFactorW5 As String = "KFactorW5"
   Public Const KFactorW6 As String = "KFactorW6"
   Public Const WallTot As String = "WallTot"
   Public Const FExtTemp As String = "FExtTemp"
   Public Const InsulF As String = "InsulF"
   Public Const ThickF As String = "ThickF"
   Public Const KFactorF As String = "KFactorF"
   Public Const FloorTot As String = "FloorTot"
   Public Const CExtTemp As String = "CExtTemp"
   Public Const InsulC As String = "InsulC"
   Public Const ThickC As String = "ThickC"
   Public Const KFactorC As String = "KFactorC"
   Public Const CeilingTot As String = "CeilingTot"
   Public Const TransTot As String = "TransTot"
   Public Const IVolume As String = "IVolume"
   Public Const InfWb As String = "InfWb"
   Public Const InfDb As String = "InfDb"
   Public Const IFactor As String = "IFactor"
   Public Const IAirChg As String = "IAirChg"
   Public Const IHeatRem As String = "IHeatRem"
   Public Const TotInfil As String = "TotInfil"
   Public Const Product As String = "Product"
   Public Const Type_ As String = "Type"
   Public Const FreezePt As String = "FreezePt"
   Public Const CHeat As String = "CHeat"
   Public Const CFHeat As String = "CFHeat"
   Public Const FLatent As String = "FLatent"
   Public Const CIbs As String = "CIbs"
   Public Const CLoad As String = "CLoad"
   Public Const CPull As String = "CPull"
   Public Const CEnter As String = "CEnter"
   Public Const CFinal As String = "CFinal"
   Public Const CTot As String = "CTot"
   Public Const FTot As String = "FTot"
   Public Const CFPTot As String = "CFPTot"
   Public Const CFTot As String = "CFTot"
   Public Const RIbs As String = "RIbs"
   Public Const RHeat As String = "RHeat"
   Public Const RTot As String = "RTot"
   Public Const ProdTot As String = "ProdTot"
   Public Const WattL As String = "WattL"
   Public Const TotOl As String = "TotOl"
   Public Const MotorHp As String = "MotorHp"
   Public Const TotOm As String = "TotOm"
   Public Const People As String = "People"
   Public Const TotOp As String = "TotOp"
   Public Const OtherType As String = "OtherType"
   Public Const OtherBtu As String = "OtherBtu"
   Public Const TotOo As String = "TotOo"
   Public Const OtherTot As String = "OtherTot"
   Public Const SumTran As String = "SumTran"
   Public Const SumInf As String = "SumInf"
   Public Const SumProd As String = "SumProd"
   Public Const SumOther As String = "SumOther"
   Public Const SumTot As String = "SumTot"
   Public Const Safety As String = "Safety"
   Public Const SafetyTot As String = "SafetyTot"
   Public Const RunVar As String = "RunVar"
   Public Const RunVarTot As String = "RunVarTot"
   Public Const LoadTot As String = "LoadTot"
   Public Const btnAllWallsy As String = "btnAllWallsy"
   Public Const btnAllWallsN As String = "btnAllWallsN"
   Public Const chkFreezePt As String = "chkFreezePt"
   Public Const chkFreezeToCore As String = "chkFreezeToCore"
   Public Const myState As String = "myState"
   Public Const myCity As String = "myCity"
   Public Const Rw1 As String = "Rw1"
   Public Const Rw2 As String = "Rw2"
   Public Const Rw3 As String = "Rw3"
   Public Const Rw4 As String = "Rw4"
   Public Const Rw5 As String = "Rw5"
   Public Const Rw6 As String = "Rw6"
   Public Const RwFloor As String = "RwFloor"
   Public Const RwCeiling As String = "RwCeiling"
   Public Const KFactors As String = "KFactors"
   Public Const Forklift As String = "Forklift"
   Public Const TotForklift As String = "TotForklift"
   Public Const DockDoors As String = "DockDoors"
   Public Const TotDockDoors As String = "TotDockDoors"
   Public Const Wall1 As String = "Wall1"
   Public Const Wall2 As String = "Wall2"
   Public Const Wall3 As String = "Wall3"
   Public Const Wall4 As String = "Wall4"
   Public Const Wall5 As String = "Wall5"
   Public Const Wall6 As String = "Wall6"
   Public Const Height1 As String = "Height1"
   Public Const Height2 As String = "Height2"
   Public Const Height3 As String = "Height3"
   Public Const Height4 As String = "Height4"
   Public Const Height5 As String = "Height5"
   Public Const Height6 As String = "Height6"
   Public Const rdoRectangle As String = "rdoRectangle"
   Public Const txtImageCounter As String = "txtImageCounter"
   Public Const UserCapacity As String = "UserCapacity"
   Public Const UserCapacityChecked As String = "UserCapacityChecked"
   Public Const CreatedWhen As String = "CreatedWhen"
   Public Const RoomNumber As String = "RoomNumber"
   Public Const BlName As String = "BlName"
   Public Const ProcessId As String = "ProcessId"
   Public Const CreatedBy As String = "CreatedBy"
   
End Class

End Namespace

'Public Class BoxLoad
'   Function Exists(dto As BoxLoadDto) As Boolean

'   End Function
'   Function Insert(dto As BoxLoadDto) As Integer

'   End Function
'   Sub Update(dto As BoxLoadDto)

'   End Sub
'   Function Retrieve(id As Integer, projectRevision As Integer, itemRevision As Integer) As BoxLoadDto

'   End Function
'End Class

'Public Class DataAccessBase(Of DtoT As IItemDto)
'   Implements IDataAccess(Of DtoT)
   
'   Protected connectionFactory As ConnectionFactory
   
'   Sub New(connectionFactory As ConnectionFactory, tableName As String)
'      Me.connectionFactory = connectionFactory
'   End Sub
   
'   Sub Delete(itemId As String) _
'   Implements IDataAccess(Of DtoT).Delete
'      Dim connection As IDbConnection = connectionFactory.Create()
'      Dim command As IDbCommand = connection.CreateCommand()
'      command.CommandText = New ItemSql("").Delete(itemId)
'      Try
'         connection.Open()
'         command.ExecuteNonQuery()
'      Finally
'         If connection.State = ConnectionState.Closed Then _
'            connection.Close()
'      End Try
'   End Sub

'   Function Exists(itemId As String, itemRevision As Integer) As Boolean _
'   Implements IDataAccess(Of DtoT).Exists
'      Dim da As New Item(connectionFactory, tableName)
'      Return da.Exists(itemId, itemRevision)
'   End Function

'   Function Insert(dto As DtoT) As Integer _
'   Implements IDataAccess(Of DtoT).Insert

'   End Function

'   Function Retrieve(itemId As String) As DtoT _
'   Implements IDataAccess(Of DtoT).Retrieve

'   End Function

'   Public Sub Update(dto As DtoT) _
'   Implements IDataAccess(Of DtoT).Update

'   End Sub

'   Function Save(dto As DtoT) As Integer _
'   Implements IDataAccess(Of DtoT).Save
'      Dim dbId As Integer
      
'      If Exists(dto.ItemId, dto.ItemRevision) Then
'         Update(dto)
'         dbId = dto.Id
'      Else
'         dbId = Insert(dto)
'      End If
      
'      Return dbId
'   End Function
   
'End Class
