Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert
Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess.Projects
Imports Rae.Data.Access

<TestClass()> _
Public Class When_retrieving_saved_options

' test data
Const PRICING_ID_FOUND As Integer = 46566
Const PRICING_ID_MISSING As Integer = 31583
Const PRICING_ID_LEGACY As Integer = 31583
Const PRICING_ID_REPLACEMENT As Integer = 46538
Const PRICING_ID_OBSOLETE As Integer = 40465 ' for unit cooler

Private Shared condensingUnit As CondensingUnitEquipmentItem
Private Shared unitCooler As UnitCoolerEquipmentItem
Private Shared connFactory As IConnectionFactory

<TestMethod()> _
Sub get_options_whose_pricing_ids_can_be_found
	Dim ops = EquipmentOptionsDa.Get_options_selected_for(condensingUnit)
	IsTrue( ops.Exists( Function(x) x.PricingId=PRICING_ID_FOUND ))
End Sub

<TestMethod()> _
Sub and_ignore_options_whose_ids_cannot_be_found
	Dim ops = EquipmentOptionsDa.Get_options_selected_for(condensingUnit)
	IsFalse( ops.Exists( Function(x) x.PricingId=PRICING_ID_MISSING ))
End Sub

<TestMethod()> _
Sub then_get_missing_options
	Dim ops = EquipmentOptionsDa.Get_options_missing_from(condensingUnit)
	IsTrue( ops.Exists( Function(x) x.PricingId = PRICING_ID_MISSING ))
End Sub

<TestMethod()> _
Sub and_ignore_options_whose_pricing_ids_can_be_found
	Dim ops = EquipmentOptionsDa.Get_options_missing_from(condensingUnit)
	IsFalse( ops.Exists( Function(x) x.PricingId = PRICING_ID_FOUND ))
End Sub

<TestMethod()> _
Sub get_legacy_options_for_missing_options
   Dim missingOps = EquipmentOptionsDa.Get_options_missing_from(condensingUnit)
	Dim missingOp = missingOps.Find( Function(x) x.PricingId = PRICING_ID_LEGACY )
	' not found in new db
	IsTrue( missingOp.Code Is Nothing )
	
	' finds replacement in legacy db
	Dim replacementOp = New LegacyPricing(connFactory).Find(missingOp)
	IsTrue( replacementOp.Code = "EC07" )
	IsTrue( replacementOp.Voltage = 0 )
	IsTrue( replacementOp.Description IsNot Nothing )
	IsTrue( replacementOp.Category = "Defrost" )
	IsTrue( replacementOp.Id = 1639 )
	IsTrue( replacementOp.Per = "unit" )
	IsTrue( replacementOp.Price = 533 )
	IsTrue( replacementOp.Quantity = 1 )
	IsTrue( replacementOp.Voltage = 0 )
End Sub

<TestMethod()> _
Sub get_obsolete_options_for_missing_options
   ' heat exchangers were deleted
	Dim missingOps = EquipmentOptionsDa.Get_options_missing_from(unitCooler)
	Dim missingOp = missingOps.Find( Function(x) x.PricingId = PRICING_ID_OBSOLETE )
	' data not available in new db so option is obsolete
	IsTrue( missingOp.Code Is Nothing )
	
	' get obsolete option from legacy db
	Dim replacementOp = New LegacyPricing(connFactory).Find(missingOp)
	IsTrue( replacementOp.PricingId = PRICING_ID_OBSOLETE )
	IsTrue( replacementOp.Code = "MH01" )
	IsTrue( replacementOp.Description.StartsWith("Heat Exchanger") )
End Sub

<TestMethod()> _
Sub replace_legacy_option_with_matching_common_option()
   Dim missingOps = EquipmentOptionsDa.Get_options_missing_from(condensingUnit)
   Dim missingOp = missingOps.Find(Function(x) x.PricingId = PRICING_ID_LEGACY)
   IsTrue(missingOp.PricingId = PRICING_ID_LEGACY)
   IsTrue(missingOp.Code Is Nothing)

   Dim legacyOp = New LegacyPricing(connFactory).Find(missingOp)
   IsTrue(legacyOp.PricingId = PRICING_ID_LEGACY)
   IsTrue(legacyOp.Code = "EC07")

   Dim replacementOp = EquipmentOptionsDa.Get_replacement_for(legacyOp, condensingUnit)
   IsTrue(replacementOp.PricingId = PRICING_ID_REPLACEMENT)
   IsTrue(replacementOp.Code = "EC07")
End Sub

#Region " Initialize and cleanup"

Property Context As TestContext
   Get
      Return _context
   End Get
   Set(value As TestContext)
      _context = value
   End Set
End Property

Private _context As TestContext

<ClassInitialize()> Shared Sub InitializeClass(context As TestContext)
   Dim AppFolderPath As String = "C:\Code\Rae\Solutions\Main\Rae.Solutions\"
   Dim DbFolderPath As String = AppFolderPath & "Databases\"
   Rae.RaeSolutions.DataAccess.Common.Initialize(appFolderPath, dbFolderPath)
   
   Rae.DataAccess.EquipmentOptions.ConnectionString.InitializeTest(DbFolderPath & "EquipmentOptions_ForTesting.mdb")
   
   Dim connString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" & DbFolderPath & "LegacyPricing.mdb"
	connFactory = New ConnectionFactory(connString)
   
   Dim author As String = "CaseyJ"
   Dim password As String = "LS3H4H6654"
   Dim division As Rae.RaeSolutions.Business.Division = Rae.RaeSolutions.Business.Division.CRI
   Dim cuId As New item_id(author & "+" & password & "+20080828102829")
   
   Dim projectMgr = New project_manager(author, password)
   
   condensingUnit = New CondensingUnitEquipmentItem( _
      "Condensing Unit Test", division, cuId, projectMgr) With {.Revision = 0.001}
   Dim voltage = New NullableValue(Of Integer)(460)
   condensingUnit.CommonSpecs.UnitVoltage.Voltage = voltage
   condensingUnit.Series = "DS"
   condensingUnit.ModelNum = "10H2"
      
   Dim ucId = New item_id(author & "+" & password & "+20080829093518")
   
   unitCooler = New UnitCoolerEquipmentItem( _
      "Unit Cooler Test", division, ucId, projectMgr) With {.Revision = 0.001}
   unitCooler.CommonSpecs.UnitVoltage.Voltage = voltage
   unitCooler.Series = "A"
   unitCooler.ModelNum = "410-126G"
End Sub
'
' <ClassCleanup()> Shared Sub CleanupClass()
' End Sub
'
' <TestInitialize()> Sub InitializeTest()
' End Sub
'
' <TestCleanup()> Sub CleanupTest()
' End Sub

#End Region

End Class
