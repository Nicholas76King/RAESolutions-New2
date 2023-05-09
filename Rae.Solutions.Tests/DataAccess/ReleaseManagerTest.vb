Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass> Public Class ReleaseManagerTest : inherits test_base

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
   ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

   ' Use ClassInitialize to run code before running the first test in the class
   <ClassInitialize()> _
   Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)

      Dim appFolderPath As String = Rae.RaeSolutions.DataAccess.Common.AppFolderPath '.DbFolderPath '"C:\Documents and Settings\CaseyJ\My Documents\Visual Studio 2005\Projects\RAESolutions\"
      Dim dbFolderPath As String = Rae.RaeSolutions.DataAccess.Common.DbFolderPath ' appFolderPath & "Databases\"
      Rae.RaeSolutions.DataAccess.Common.Initialize(appFolderPath, dbFolderPath)
   End Sub

   <TestMethod()> _
   Public Sub ShouldConnectToSql()
      Dim releaseMgr As New Rae.RaeSolutions.DataAccess.ReleaseManager()
      Dim nextReleaseNum As Integer = releaseMgr.RetrieveNextUnassignedReleaseNum()

      Assert(nextReleaseNum > 0)
   End Sub

   <TestMethod, ignore>
   public sub retrieve_30A2_weights_from_item_master
      dim connection_string = Rae.RaeSolutions.DataAccess.Common.GetSqlConnectionString("master")
      dim connection = new system.data.sqlClient.sqlConnection(connection_string)
      'dim sql = "SELECT TOP 200 * FROM AS400.RAE270.CSSFILES.ITEMS"
      dim sql = "SELECT ITDESC, ITFSCT FROM AS400.RAE270.CSSFILES.ITEMS WHERE ITDESC LIKE 'FA 30A2%'"
      dim command = connection.CreateCommand()
      command.commandText = sql
      dim reader as system.data.idatareader
      dim table = new system.data.datatable

      try
         connection.open
         reader = command.ExecuteReader
         table.load(reader)
         log("connected to master items")
      catch ex as exception
         log(ex.message)
      finally
         if connection.state <> system.data.connectionstate.closed then connection.close
      end try
   end sub

end class