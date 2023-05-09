Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports Rae.Data.Access
Imports System.Data
Imports Rae.Data.MicrosoftAccess
Imports Rae.ExistenceStatus

<TestClass(), Ignore> _
Public Class BoxLoadTests

   <ClassInitialize()> _
   Shared Sub Initialize(context As TestContext)
      tableName = "CoolStuffProjects"
      connection = New Connection().Choose(ConnectionName.Projects)
      da = New BoxLoadProjects()
   End Sub


   <TestMethod()> _
   Sub ConnectionCanOpen()
      connection.Open()
      connection.Close()
   End Sub

   
   <TestMethod()> _
   Sub ThisItemShouldExist()
      Dim dto As BoxLoadDto = getDto()
      
      Dim exists As Boolean = da.Exists(dto.ItemId, dto.ItemRevision)

      IsTrue(exists)
   End Sub
   
   
   <TestMethod()> _
   Sub ThisItemShould_Not_Exist()
      Dim dto As BoxLoadDto = getDto
      dto.ItemRevision = 1 ' doesn't exist
      
      Dim exists As Boolean = da.Exists(dto.ItemId, dto.ItemRevision)
      
      IsFalse(exists)
   End Sub


   <TestMethod()> _
   Sub ShouldInsert()
      Dim dto As BoxLoadDto = getDto()
      
      Dim id As Integer = da.Insert(dto)
      
      IsTrue(id > 0)
   End Sub
   
   
   <TestMethod()> _
   Sub ShouldUpdate()
      Dim dto As BoxLoadDto = getDto("1", 0, 1)
      da.Update(dto)
      IsTrue( da.Exists(dto.ItemId, dto.ItemRevision) )
   End Sub
   
   
   <TestMethod()> _
   Sub ShouldRetrieve()
      Dim dto As BoxLoadDto
      dto = da.Retrieve("1", 0)
      
      IsTrue( dto.ItemId = "1" _
      AndAlso dto.ItemRevision = 0 _
      AndAlso dto.ProjectRevision = 0)
   End Sub
   
   
   <TestMethod()> _
   Sub DeleteTable()
      If commands.CheckTableExistence(tableName) = Existent Then
         commands.DeleteTable(tableName)
      End If
      
      IsTrue( commands.CheckTableExistence(tableName) = Nonexistent )
   End Sub


   <TestMethod()> _
   Sub CreateTable()
      createTable(connection.ConnectionString)
      
      IsTrue( commands.CheckTableExistence(tableName) = Existent )
   End Sub
   
   
#Region " Internal"
   
   Private Shared da As BoxLoadProjects
   Private Shared tableName As String
   Private Shared connection As IDbConnection
   Private Shared commands_ As Commands
   
   
   Private Shared ReadOnly Property commands As Commands
      Get
         If commands_ Is Nothing Then
           commands_ = New Commands(connection.ConnectionString)
         End If
         Return commands_
      End Get
   End Property

   Private Overloads Function getDto() As BoxLoadDto
      Return getDto("1", 0, 0)
   End Function

   Private Overloads Function getDto( _
   itemId As String, itemRevision As Integer, projectRevision As Integer) As BoxLoadDto
      Dim dto As New BoxLoadDto
      With dto
         .ItemId = itemId
         .ItemRevision = itemRevision
         .ProjectRevision = projectRevision
      End With
      Return dto
   End Function
   
   Private Shared Sub createTable(connectionString As String)
      commands.AddTable(tableName)
      
      commands.AddColumn(tableName, New Column("Id", New DataTypes.AutoNumber))
      commands.AddColumn(tableName, New Column("ProjectId", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ProjectRevision", New DataTypes.LongInteger(0)))
      commands.AddColumn(tableName, New Column("ItemId", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ItemRevision", New DataTypes.LongInteger()))
      
      commands.AddColumn(tableName, New Column("BLName", New DataTypes.Text))
      
      commands.AddColumn(tableName, New Column("Ambient", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ExtWB", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("RmTemp", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("RMWB", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("roomVolume", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("roomArea", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("Height", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ExtTempW1", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ExtTempW2", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ExtTempW3", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ExtTempW4", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ExtTempW5", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ExtTempW6", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulW1", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulW2", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulW3", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulW4", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulW5", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulW6", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickW1", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickW2", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickW3", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickW4", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickW5", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickW6", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorW1", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorW2", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorW3", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorW4", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorW5", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorW6", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("Walltot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("FExtTemp", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulF", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickF", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorF", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("FloorTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CExtTemp", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InsulC", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ThickC", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("KFactorC", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CeilingTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("TransTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("IVolume", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InfWB", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("InfDB", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("IFactor", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("IAirChg", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("IHeatRem", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("TotInfil", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("Product", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("Type", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("FreezePt", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CHeat", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CFHeat", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("FLatent", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CIbs", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CLoad", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CPull", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CEnter", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CFinal", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("FTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CFPTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CFTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("RIbs", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("RHeat", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("RTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("ProdTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("WattL", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("TotOL", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("MotorHP", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("TotOM", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("People", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("TotOP", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("OtherType", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("OtherBTU", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("TotOO", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("OtherTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("SumTran", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("SumINf", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("SumProd", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("SumOther", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("SumTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("Safety", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("SafetyTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("RunVar", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("RunVarTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("LoadTot", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("btnAllWallsy", New DataTypes.YesNo))
      commands.AddColumn(tableName, New Column("btnallwallsN", New DataTypes.YesNo))
      commands.AddColumn(tableName, New Column("chkFreezept", New DataTypes.YesNo))
      commands.AddColumn(tableName, New Column("chkfreezetoCore", New DataTypes.YesNo))
      commands.AddColumn(tableName, New Column("mystate", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("mycity", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("rw1", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("rw2", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("rw3", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("rw4", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("rw5", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("rw6", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("rwfloor", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("rwceiling", New DataTypes.Single))
      commands.AddColumn(tableName, New Column("kfactors", New DataTypes.YesNo))
      commands.AddColumn(tableName, New Column("forklift", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("totforklift", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("dockdoors", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("totdockdoors", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("wall1", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("wall2", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("wall3", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("wall4", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("wall5", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("wall6", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("height1", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("height2", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("height3", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("height4", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("height5", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("height6", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("rdorectangle", New DataTypes.YesNo))
      commands.AddColumn(tableName, New Column("txtimagecounter", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("Description", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("UserCapacity", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("UserCapacityChecked", New DataTypes.YesNo))
      commands.AddColumn(tableName, New Column("CreatedWhen", New DataTypes.DateTime))
      commands.AddColumn(tableName, New Column("RoomNumber", New DataTypes.Text))
      commands.AddColumn(tableName, New Column("CreatedBy", New DataTypes.Text()))
   End Sub
   
#End Region

End Class
