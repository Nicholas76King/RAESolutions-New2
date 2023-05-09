Imports Rae.RaeSolutions.DataAccess
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports MT = Rae.DataAccess.EquipmentOptions.Tables.master_options_table
Imports ST = Rae.DataAccess.EquipmentOptions.Tables.SeriesTable
Imports PT = Rae.DataAccess.EquipmentOptions.Tables.PersTable
Imports ept = Rae.DataAccess.EquipmentOptions.Tables.EquipmentPricingTable
Imports opt = Rae.DataAccess.EquipmentOptions.Tables.OptionPricingTable
Imports pbst = Rae.DataAccess.EquipmentOptions.Tables.PricingBySeriesTable
Imports pbft = Rae.DataAccess.EquipmentOptions.Tables.PricingByNumFansTable
Imports pbmt = Rae.DataAccess.EquipmentOptions.Tables.PricingByModelTable

Namespace Rae.DataAccess.EquipmentOptions

''' <summary>Contains methods to retrieve options</summary>
Public Class OptionsDataAccess

#Region " Public methods"

   ''' <summary>Retrieves base list price for the equipment</summary>
   ''' <param name="series">Equipment series</param>
   ''' <param name="model">Equipment model number</param>
   ''' <returns>Base list price</returns>
   Shared Function RetrieveBaseListPrice(series As String, model As String) As Double
      Dim sql = New StringBuilder().AppendFormat( _
         "SELECT {8} FROM {0} INNER JOIN {1} ON {0}.{2}={1}.{3} WHERE {4}='{5}' AND {6}='{7}'", _
         ept.TableName, ST.TableName, ept.SeriesId, ST.Id, ST.Series, series, ept.Model, model, ept.Price).ToString

      Return executeScalar(Of Double)(sql)
   End Function




        Shared Function CheckDBVersion(ByVal dbVersionCheck As String) As Boolean
            Try

                Dim sql As String = "select Version from VersionDB"

                Dim dbVersion As String = executeScalar(Of String)(sql)

                If dbVersion.ToLower = dbVersionCheck.ToLower Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try

        End Function





        Shared Function RetrieveAvailableOptions( _
        ByVal series As String, ByVal model As String, ByVal voltage As Integer, ByVal numFans As Integer, ByVal fanMotorPhase As Integer) As List(Of [Option])
            Return RetrieveOps(series, model, voltage, numFans, Query.AvailableSql, fanMotorPhase)
        End Function
   
   ''' <summary>Retrieves standard options for the specified equipment</summary>
   ''' <param name="series">Equipment series</param>
   ''' <param name="model">Equipment model number</param>
   ''' <param name="voltage">Unit voltage that equipment runs on</param>
   ''' <returns>List of standard options for the specified equipment</returns>
        Shared Function RetrieveStandardOptions( _
        ByVal series As String, ByVal model As String, ByVal voltage As Integer, ByVal numFans As Integer, ByVal fanMotorPhase As Integer) As List(Of [Option])
            Return RetrieveOps(series, model, voltage, numFans, Query.StandardSql, fanMotorPhase)
        End Function


   ''' <summary>Retrieves option for the equipment that has the code and voltage.</summary>
   ''' <param name="code">Option code</param>
   ''' <param name="voltage">Unit voltage</param>
   ''' <param name="series">Series</param>
   ''' <param name="model">Model</param>
   ''' <returns>A unique option based on its code and voltage</returns>
        Overloads Shared Function RetrieveOption( _
        ByVal series As String, ByVal model As String, ByVal code As String, ByVal voltage As Integer, ByVal numFans As Integer, ByVal fanMotorPhase As Integer) As [Option]
            Dim ops = RetrieveOps(series, model, voltage, numFans, MT.code & "='" & code & "'", fanMotorPhase)
            Dim op As [Option]
            If ops.Count > 0 Then _
               op = ops(0)
            Return op
        End Function


   ''' <summary>Retrieve option pricing info for the PricingId.</summary>
   ''' <param name="pricingId">Option pricing ID</param>
   ''' <returns>Option with Id</returns>
   Overloads Shared Function RetrieveOption(pricingId As Integer) As [Option]
      ' look by series
      Dim sql = New Query().OpsFrom(pbst.TableName).Where.PricingIdIs(pricingId).SQL
      Dim ops = retrieveOps(sql)
      
      If ops.Count = 0 Then
         ' look by model
         sql = New Query().OpsFrom(pbmt.TableName).Where.PricingIdIs(pricingId).SQL
         ops = retrieveOps(sql)
         
         If ops.Count = 0 Then
            ' look by number of fans
            sql = New Query().OpsFrom(pbft.TableName).Where.PricingIdIs(pricingId).SQL
            ops = retrieveOps(sql)
         End If
      End If
      
      Dim op As [Option]
      If ops.Count > 0 Then _
         op = ops(0)
      
      Return op
   End Function
   
   Shared Function RetrieveObsoleteOption(pricingId As Integer) As [Option]
      Dim sql = New Query().OpsFrom(pbst.TableName).Where.PricingIdIs(pricingId).And.IsObsolete.SQL
      Dim ops = retrieveOps(sql)
      
      If ops.Count = 0 Then
         sql = New Query().OpsFrom(pbmt.TableName).Where.PricingIdIs(pricingId).And.IsObsolete.SQL
         ops = retrieveOps(sql)
         
         If ops.Count = 0 Then
            sql = New Query().OpsFrom(pbft.TableName).Where.PricingIdIs(pricingId).And.IsObsolete.SQL
            ops = retrieveOps(sql)
         End If
      End If
      
      Dim op As [Option]
      If ops.Count > 0 Then _
         op = ops(0)
      
      Return op
   End Function
   
   Shared Function IsObsolete(pricingId As Integer) As Boolean
      Dim sql = New Query().OpsFrom(pbst.TableName).Where.PricingIdIs(pricingId).And.IsObsolete.SQL
      Dim ops = retrieveOps(sql)
      
      If ops.Count = 0
         sql = New Query().OpsFrom(pbmt.TableName).Where.PricingIdIs(pricingId).And.IsObsolete.SQL
         ops = retrieveOps(sql)
         
         If ops.Count = 0
            sql = New Query().OpsFrom(pbft.TableName).Where.PricingIdIs(pricingId).And.IsObsolete.SQL
            ops = retrieveOps(sql)
         End If
      End If
      
      Return (ops.Count > 0)
   End Function
   
   

#End Region


#Region " Private methods"

   ''' <summary>There is no need for a constructor; all methods are shared.</summary>
   Private Sub New()
   End Sub
   
        Friend Shared Function RetrieveOps( _
        ByVal series As String, ByVal model As String, ByVal voltage As Integer, ByVal numFans As Integer, _
        ByVal sql As String, ByVal fanMotorPhase As Integer) As List(Of [Option])
            Dim connection = Common.CreateConnection(ConnectionString.DataSource)
            Dim opsBySeries, opsByModel, opsByNumFans As List(Of [Option])
            Try
                connection.Open()
                Dim sqlBySeries = New Query().OpsFrom(pbst.TableName).Where.Append(sql).And.SeriesIs(series).And.VoltageIs(voltage).And.IsNotObsolete.SQL.append(" order by code ")
                opsBySeries = RetrieveOps(connection, sqlBySeries)

                Dim sqlByModel = New Query().OpsFrom(pbmt.TableName) _
                                           .Where.Append(sql) _
                                           .And.SeriesIs(series) _
                                           .And.ModelIs(model) _
                                           .And.VoltageIs(voltage) _
                                           .And.IsNotObsolete.SQL.append(" order by code ")
                opsByModel = RetrieveOps(connection, sqlByModel)

                Dim sqlByNumFans = New Query().OpsFrom(pbft.TableName) _
                                              .Where.Append(sql) _
                                              .And.SeriesIs(series) _
                                              .And.VoltageIs(voltage) _
                                              .And.NumFansIs(numFans) _
                                              .And.FanMotorPhaseIs(fanMotorPhase) _
                                              .And.IsNotObsolete.SQL.append(" order by code ")
                opsByNumFans = RetrieveOps(connection, sqlByNumFans)
            Finally
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

            Dim ops = New List(Of [Option])()
            ops.AddRange(opsBySeries) : ops.AddRange(opsByModel) : ops.AddRange(opsByNumFans)

            Return ops
        End Function

   Private Shared Function retrieveOps(connection As IDbConnection, sql As String) As List(Of [Option])
      Dim command = connection.CreateCommand
      command.CommandText = sql
            Dim reader = command.ExecuteReader
      Dim ops = New List(Of [Option])
      read(ops, reader)
      
      Return ops
   End Function
   
   Private Shared Function retrieveOps(sql As String) As List(Of [Option])
      Dim connection = Common.CreateConnection(ConnectionString.DataSource)
      Dim ops As List(Of [Option])
      Try
         connection.Open
         ops = retrieveOps(connection, sql)
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close
      End Try
      
      Return ops
   End Function

   Private Shared Sub read(ops As List(Of [Option]), reader As IDataReader)
      While reader.Read
         Dim op = New [Option]
         op.PricingId         = CInt(reader(opt.TableName & "." & opt.Id))
         op.MasterId          = CInt(reader(MT.table_name & "." & MT.Id))
         op.Category          = reader(MT.Category).ToString
         op.Code              = reader(MT.Code).ToString
         op.Description       = reader(MT.Description).ToString
         op.Details           = reader(MT.Details).ToString
         op.Equipment.Series  = reader(ST.Series).ToString
         op.Voltage           = CInt(reader(MT.Voltage))
         op.Price             = CDbl(reader(opt.Price))
         op.Quantity          = CInt(reader(opt.Quantity))
                op.Per = reader(PT.Per).ToString

         ops.Add(op)
      End While
      If reader IsNot Nothing Then _
         reader.Close
   End Sub

   ''' <summary>Generic scalar execution</summary>
   ''' <typeparam name="T">Return type expected from SQL command</typeparam>
   ''' <param name="sql">SQL command that returns a scalar value</param>
   ''' <returns>Value returned by SQL command</returns>
   ''' <exception cref="System.ApplicationException">Thrown when price is not listed.</exception>
   Private Shared Function executeScalar(Of T)(sql As String) As T
      Dim connection = Common.CreateConnection(ConnectionString.DataSource)
      Dim command = connection.CreateCommand
      command.CommandText = sql
      Dim returnValue As T

      Try
         connection.Open()
         ' returns a null reference if the result set is empty
         If command.ExecuteScalar() Is Nothing Then
            ' price not listed
            Throw New System.ApplicationException("Equipment price is not listed.")
         Else
            returnValue = CType(command.ExecuteScalar(), T)
         End If
      Finally
         If connection.State <> ConnectionState.Closed Then _
            connection.Close()
      End Try

      Return returnValue
   End Function  

#End Region

End Class

End Namespace