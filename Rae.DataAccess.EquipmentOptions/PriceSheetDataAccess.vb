Option Strict Off

Imports System.Data
Imports System.Collections.Generic
Imports PriceSheetDataSet
Imports Rae.DataAccess.EquipmentOptions.Tables
Imports MT = Rae.DataAccess.EquipmentOptions.Tables.master_options_table
Imports PT = Rae.DataAccess.EquipmentOptions.Tables.OptionPricingTable
Imports ST = Rae.DataAccess.EquipmentOptions.Tables.SeriesTable
Imports System.Text
Imports Rae.RaeSolutions.DataAccess

Namespace Rae.DataAccess.EquipmentOptions

''' <summary>Provides data access for price sheet data.</summary>
Public Class PriceSheetDataAccess

   ''' <summary>True to share connections</summary>
   Shared Property UseSharedConnections As Boolean
   	Get
   		Return _useSharedConnections
   	End Get
   	Set(value As Boolean)
   		_useSharedConnections = value
   		If _useSharedConnections = False Then
            If sharedConnection IsNot Nothing Then _
               sharedConnection.Close
         End If
   	End Set
   End Property
   

#Region " Public methods"

   ''' <summary>Retrieves price sheet options for division of RAE Corporation parameter.</summary>
   ''' <param name="division">Division of RAE Corporation to retrieve price sheets for.</param>
   Shared Function RetrieveDivisionOptions(division As String) As PriceSheetDataTable
      Dim opsWithoutExpandedDependentOps = retrieveOpsFilteredByDivision(division)
      Dim divisionOpsTable = replaceDependentCommonOps(opsWithoutExpandedDependentOps)

      Return divisionOpsTable
   End Function


   ''' <summary>Retrieves price sheet options for the equipment series parameter.</summary>
   ''' <param name="series">Series</param>
   Shared Function RetrieveSeriesOptions(series As String) As PriceSheetDataTable
      Dim opsWithoutExpandedDependentOps = retrieveOpsFilteredBySeries(series)
      Dim seriesOpsTable = replaceDependentCommonOps(opsWithoutExpandedDependentOps)

      Return seriesOpsTable
   End Function
   
   Shared Function RetrieveSeriesOptionsWithoutCommonOptions(series As String) As PriceSheetDataTable
      Dim ops = retrieveOpsFilteredBySeriesWithoutCommonOps(series)
      ops = replaceDependentCommonOps(ops)
      Return ops
   End Function


   Shared Function RetrieveModelOptions(series As String, model As String) As PriceSheetDataTable
      Dim opsWithoutExpandedDependentOps = retrieveOpsFilteredByModel(series, model)
      Dim modelOpsTable = replaceDependentCommonOps(opsWithoutExpandedDependentOps)

      Return modelOpsTable
   End Function
   
   Shared Function RetrieveModelOptionsWithoutCommonOptions(series As String, model As String) As PriceSheetDataTable
      Dim ops = retrieveOpsFilteredByModelWithoutCommonOps(series, model)
      ops = replaceDependentCommonOps(ops)
      Return ops
   End Function
   
   
   Shared Function RetrieveCommonOptions(series As String) As PriceSheetDataTable
      Dim sql = New Query().OpsFrom("PricingBySeries") _
                           .Where.SeriesIs(series).SQL
      Dim pricedBySeries = retrieveOps(sql)
      'pricedBySeries = replaceDependentCommonOps(pricedBySeries)
      Return pricedBySeries
   End Function

#End Region


#Region " Private methods"

   Private Shared _useSharedConnections As Boolean
   
   Private Shared Function createConnection() As IDbConnection
      If UseSharedConnections Then
         If sharedConnection Is Nothing Then
            sharedConnection = Common.CreateConnection(ConnectionString.DataSource)
         End If
         Return sharedConnection
      End If
      Return Common.CreateConnection(ConnectionString.DataSource)
   End Function
   Private Shared sharedConnection As IDbConnection

   Private Shared Function retrieveOps(sql As String) As PriceSheetDataTable
      Dim con = createConnection() ' Common.CreateConnection(ConnectionString.DataSource)
      Dim com = con.CreateCommand
      com.CommandText = sql
      Dim rdr As IDataReader
      Dim priceSheet = New PriceSheetDataTable()
      Dim op As PriceSheetRow
      
      Try
         If con.State <> ConnectionState.Open Then con.Open
         rdr = com.ExecuteReader
         While rdr.Read
            op = priceSheet.NewPriceSheetRow
            
            op.Code = rdr(MT.Code)
            op.Description = rdr(MT.Description)
            op.Category = rdr(MT.Category)
            op.Division = rdr(ST.Division)
            op.Series = rdr(ST.Series)
            op.EquipmentType = rdr(ST.EquipmentType)
            op.Price = rdr(PT.Price)
            op.Quantity = rdr(PT.Quantity)
            op.Voltage = rdr(MT.Voltage)
            
            priceSheet.AddPriceSheetRow(op)
         End While
      Finally
         If rdr IsNot Nothing Then _
            rdr.Close
         If Not UseSharedConnections _
         AndAlso con.State <> ConnectionState.Closed Then _
            con.Close
      End Try
      
      Return priceSheet
   End Function
   
      
   Private Shared Function retrieveOpsFilteredByDivision(division As String) As PriceSheetDataTable
      Dim series = EquipmentDataAccess.RetrieveSeries(division)
      
      Dim priceSheet = New PriceSheetDataTable
      For Each s In series
         priceSheet.Merge( retrieveOpsFilteredBySeries(s) )
      Next
      
      Return priceSheet
   End Function
   
   
   Private Shared Function retrieveOpsFilteredByModel( _
   series As String, model As String) As PriceSheetDataTable
      Dim sql = New Query().OpsFrom("PricingByModel") _
                           .Where.SeriesIs(series) _
                           .And.ModelIs(model).SQL
      Dim pricedByModel = retrieveOps(sql)
      
      sql = New Query().OpsFrom("PricingBySeries") _
                       .Where.SeriesIs(series).SQL
      Dim pricedBySeries = retrieveOps(sql)
      
      Dim priceSheet = pricedByModel
      priceSheet.Merge(pricedBySeries)
      
      If isUnitCooler(series) Then
         Dim numFans = CInt( model(1).ToString )
         sql = New Query().OpsFrom("PricingByNumFans") _
                          .Where.SeriesIs(series) _
                          .And.NumFansIs(numFans).SQL
         Dim pricedByFan = retrieveOps(sql)
         priceSheet.Merge(pricedByFan)
      End If
      
      For Each op As PriceSheetRow In priceSheet.Rows
         op.Model = model
      Next
      
      Dim baseListPrice = EquipmentOptions.OptionsDataAccess.RetrieveBaseListPrice(series, model)
      If priceSheet.Count = 0 Then
         ' prevent error when equipment doesn't have any options yet
         priceSheet.AddPriceSheetRow(series, model, "", "", "BaseList", "aaaBase List", "Base List Price", 0, baseListPrice, 1, "", 0)
      Else
         priceSheet.AddPriceSheetRow(series, model, priceSheet(0).Division, priceSheet(0).EquipmentType, "BaseList", "aaaBase List", "Base List Price", 0, baseListPrice, 1, "", 0)
      End If   
      priceSheet.Rows(priceSheet.Rows.Count - 1)("DependentPrice") = System.DBNull.Value
      
      Return priceSheet
   End Function
   
   Private Shared Function retrieveOpsFilteredByModelWithoutCommonOps( _
   series As String, model As String) As PriceSheetDataTable
      Dim sql = New Query().OpsFrom("PricingByModel") _
                           .Where.SeriesIs(series) _
                           .And.ModelIs(model).SQL
      Dim pricedByModel = retrieveOps(sql)
      
      Dim priceSheet = pricedByModel
            
      If isUnitCooler(series) Then
         Dim numFans = CInt( model(1).ToString )
         sql = New Query().OpsFrom("PricingByNumFans") _
                          .Where.SeriesIs(series) _
                          .And.NumFansIs(numFans).SQL
         Dim pricedByFan = retrieveOps(sql)
         priceSheet.Merge(pricedByFan)
      End If
      
      For Each op As PriceSheetRow In priceSheet.Rows
         op.Model = model
      Next
      
      Dim baseListPrice = EquipmentOptions.OptionsDataAccess.RetrieveBaseListPrice(series, model)
      If priceSheet.Count = 0 Then
         ' prevent error when equipment doesn't have any options yet
         priceSheet.AddPriceSheetRow(series, model, "", "", "BaseList", "aaaBase List", "Base List Price", 0, baseListPrice, 1, "", 0)
      Else
         priceSheet.AddPriceSheetRow(series, model, priceSheet(0).Division, priceSheet(0).EquipmentType, "BaseList", "aaaBase List", "Base List Price", 0, baseListPrice, 1, "", 0)
      End If   
      priceSheet.Rows(priceSheet.Rows.Count - 1)("DependentPrice") = System.DBNull.Value
      
      Return priceSheet
   End Function
   
   
   Private Shared Function retrieveOpsFilteredBySeries(series As String) As PriceSheetDataTable
      Dim models = EquipmentDataAccess.RetrieveModels(series)
      
      Dim priceSheet = New PriceSheetDataTable
      For Each model In models
         priceSheet.Merge( retrieveOpsFilteredByModel(series, model) )
      Next
      
      Return priceSheet
   End Function
   
   Private Shared Function retrieveOpsFilteredBySeriesWithoutCommonOps(series As String) As PriceSheetDataTable
      Dim models = EquipmentDataAccess.RetrieveModels(series)
      
      Dim priceSheet = New PriceSheetDataTable
      For Each model In models
         priceSheet.Merge( retrieveOpsFilteredByModelWithoutCommonOps(series, model) )
      Next
      
      Return priceSheet
   End Function
   
   


   ''' <summary>
   ''' Replaces each dependent option in the optionsToReplace parameter with a list of options.
   ''' Each option in the list contains a different parent option with the dependent options associated price.
   ''' </summary>
   ''' <remarks>
   ''' Dependent option prices are expanded to be displayed in the price sheets.
   ''' </remarks>
   ''' <param name="opsToReplace">
   ''' List of options that could contain dependent options that should be replaced.
   ''' </param>
   Private Shared Function replaceDependentCommonOps(opsToReplace As PriceSheetDataTable) As PriceSheetDataTable
      Dim indicesToRemove As New List(Of Integer)()
      Dim allExtendedOptions As New PriceSheetDataTable()

      ' searches through each option in list
      For i As Integer = opsToReplace.Count - 1 To 0 Step -1
         ' is this option a dependent common option?
         If opsToReplace(i).Price = [Option].COMMON_DEPENDENT Then
            ' pass in dependent option with price of 999997
            ' returns a list of options with the prices associated with a specific parent option
            Dim extendedOps = extendDependentOp(CType(opsToReplace.Rows(i), PriceSheetRow))

            ' includes newly extended options into the list containing the other extended options
            allExtendedOptions.Merge(extendedOps)

            ' adds index to remove
            indicesToRemove.Add(i)
         End If
      Next

      Dim optionsWithExtendedDependentOptions As PriceSheetDataTable
      ' removes indices
      optionsWithExtendedDependentOptions = removeReplacedDependentOptions(opsToReplace, indicesToRemove)
      ' adds all extended options
      optionsWithExtendedDependentOptions.Merge(allExtendedOptions)

      Return optionsWithExtendedDependentOptions
   End Function


   ''' <summary>
   ''' Returns a list of the dependent option to extend; 
   ''' one option for each parent code association and its price with that parent.
   ''' </summary>
   ''' <param name="priceSheetOptionToExtend">
   ''' Dependent option to show in price sheet that should be extended to contain
   ''' combination of prices with each of the available parent options.
   ''' </param>
   ''' <remarks>
   ''' The extended options all have the same information except for their price and parent option.
   ''' </remarks>
   Private Shared Function extendDependentOp(priceSheetOptionToExtend As PriceSheetRow) As PriceSheetDataTable
      Dim dependentOpsToAdd As New PriceSheetDataSet.PriceSheetDataTable()

      ' gets parent options
      Dim parentOps = DependentCommonOptionsDataAccess.RetrieveParentOptions( _
         priceSheetOptionToExtend.Code, priceSheetOptionToExtend.Series)

      For i As Integer = 0 To parentOps.Count - 1
         ' gets price for dependent option with parent option
         Dim priceRow = DependentCommonOptionsDataAccess.RetrieveDependentOption( _
            priceSheetOptionToExtend.Code, parentOps(i).Code, priceSheetOptionToExtend.Series)
         Dim priceObject As Object = priceRow(Tables.DependentCommonOptionsTable.DependentPrice)
         Dim dependentPrice As Double
         If priceObject Is Nothing OrElse System.DBNull.Value Is priceObject Then
            Throw New System.ApplicationException("Dependent option does not have a price.")
         Else
            dependentPrice = CDbl(priceObject)
         End If

         ' adds dependent option with this parent option and associated price
         Dim dependentOptionToAdd As PriceSheetRow = priceSheetOptionToExtend
         dependentOptionToAdd.ParentCode = parentOps(i).Code
         dependentOptionToAdd.DependentPrice = dependentPrice
         dependentOpsToAdd.ImportRow(dependentOptionToAdd)
      Next

      Return dependentOpsToAdd
   End Function


   ''' <summary>
   ''' Removes dependent options. The dependent options should have already been extended before being removed.
   ''' </summary>
   ''' <param name="priceSheet">List of price sheet options.</param>
   ''' <param name="indicesToRemove">Indices of the options to remove.</param>
   Private Shared Function removeReplacedDependentOptions( _
   priceSheet As PriceSheetDataTable, indicesToRemove As List(Of Integer)) As PriceSheetDataTable
      ' sorts indices to remove from greatest to smallest
      indicesToRemove.Sort()

      ' removes options
      For i As Integer = indicesToRemove.Count - 1 To 0 Step -1
         priceSheet.Rows(indicesToRemove(i)).Delete()
      Next

      Return priceSheet
   End Function


   Private Shared Function isUnitCooler(series As String) As Boolean
      Dim unitCoolerSeries = SeriesDataAccess.RetrieveUnitCoolerSeries
      Return unitCoolerSeries.Contains( series )
   End Function
#End Region

End Class

End Namespace