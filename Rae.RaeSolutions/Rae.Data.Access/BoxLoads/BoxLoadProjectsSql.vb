Imports Rae.Data.Sql
Imports System.Collections.Generic
Imports System.Text
Imports Table = Rae.Data.Access.BoxLoadProjectsTable

Namespace Rae.Data.Access

Friend Module BoxLoadProjectsSql
   
   Function Update(boxLoad As BoxLoadDto) As String
      Dim affectedColumns As List(Of SqlColumn) = getColumns(boxLoad)
      Dim criteriaColumns As New List(Of SqlColumn)
      With criteriaColumns
         .Add(New SqlColumn(Table.Id, SqlDataType.Number, boxLoad.Id.ToString))
      End With

      Dim builder As New SqlBuilder(affectedColumns, Table.TableName, criteriaColumns)
      Return builder.GenerateUpdateCommand()
   End Function


   Function Insert(boxLoad As BoxLoadDto) As String
      Dim affectedColumns As List(Of SqlColumn) = getColumns(boxLoad)

      Dim builder As New SqlBuilder(affectedColumns, Table.TableName)

      Return builder.GenerateInsertCommand()
   End Function


   Function Retrieve(itemId As String, itemRevision As Integer) As String
      Dim sql As New StringBuilder()
      sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]={2} AND [{3}]={4}", _
         Table.TableName, ItemTable.ItemId, itemId, ItemTable.ItemRevision, itemRevision.ToString)
      Return sql.ToString()
   End Function
   
   Function Retrieve(dbId As Integer) As String
      Dim sql As New StringBuilder()
      
      sql.AppendFormat("SELECT * FROM [{0}] WHERE [{1}]={2}", _
         Table.TableName, Table.Id, dbId.ToString)
         
      Return sql.ToString
   End Function


   Private Function getColumns(boxLoad As BoxLoadDto) As List(Of SqlColumn)
      Dim columns As New List(Of SqlColumn)

      With columns
         .Add(New SqlColumn(Table.ItemId, SqlDataType.String, boxLoad.ItemId))
         .Add(New SqlColumn(Table.ItemRevision, SqlDataType.Number, boxLoad.ItemRevision.ToString))
         .Add(New SqlColumn(Table.ProjectId, SqlDataType.String, boxLoad.ProjectId))
         .Add(New SqlColumn(Table.ProjectRevision, SqlDataType.Number, boxLoad.ProjectRevision.ToString))

         .Add(New SqlColumn(Table.BlName, SqlDataType.String, boxLoad.BlName))
         .Add(New SqlColumn(Table.Ambient, SqlDataType.String, boxLoad.Ambient))
         .Add(New SqlColumn(Table.ExtWb, SqlDataType.String, boxLoad.ExtWb))
         .Add(New SqlColumn(Table.RmTemp, SqlDataType.String, boxLoad.RmTemp))
         .Add(New SqlColumn(Table.RmWb, SqlDataType.String, boxLoad.RMWB))
         .Add(New SqlColumn(Table.RoomVolume, SqlDataType.String, boxLoad.RoomVolume))
         .Add(New SqlColumn(Table.RoomArea, SqlDataType.String, boxLoad.RoomArea))
         '.Add( New SqlColumn(Table.Height, SqlDataType.String, boxLoad.heigh
         .Add(New SqlColumn(Table.ExtTempW1, SqlDataType.String, boxLoad.ExtTempW1))
         .Add(New SqlColumn(Table.ExtTempW2, SqlDataType.String, boxLoad.ExtTempW2))
         .Add(New SqlColumn(Table.ExtTempW3, SqlDataType.String, boxLoad.ExtTempW3))
         .Add(New SqlColumn(Table.ExtTempW4, SqlDataType.String, boxLoad.ExtTempW4))
         .Add(New SqlColumn(Table.ExtTempW5, SqlDataType.String, boxLoad.ExtTempW5))
         .Add(New SqlColumn(Table.ExtTempW6, SqlDataType.String, boxLoad.ExtTempW6))

         .Add(New SqlColumn(Table.InsulW1, SqlDataType.String, boxLoad.InsulW1))
         .Add(New SqlColumn(Table.InsulW2, SqlDataType.String, boxLoad.InsulW2))
         .Add(New SqlColumn(Table.InsulW3, SqlDataType.String, boxLoad.InsulW3))
         .Add(New SqlColumn(Table.InsulW4, SqlDataType.String, boxLoad.InsulW4))
         .Add(New SqlColumn(Table.InsulW5, SqlDataType.String, boxLoad.InsulW5))
         .Add(New SqlColumn(Table.InsulW6, SqlDataType.String, boxLoad.InsulW6))

         .Add(New SqlColumn(Table.ThickW1, SqlDataType.String, boxLoad.ThickW1))
         .Add(New SqlColumn(Table.ThickW2, SqlDataType.String, boxLoad.ThickW2))
         .Add(New SqlColumn(Table.ThickW3, SqlDataType.String, boxLoad.ThickW3))
         .Add(New SqlColumn(Table.ThickW4, SqlDataType.String, boxLoad.ThickW4))
         .Add(New SqlColumn(Table.ThickW5, SqlDataType.String, boxLoad.ThickW5))
         .Add(New SqlColumn(Table.ThickW6, SqlDataType.String, boxLoad.ThickW6))

         .Add(New SqlColumn(Table.KFactorW1, SqlDataType.String, boxLoad.KFactorW1))
         .Add(New SqlColumn(Table.KFactorW2, SqlDataType.String, boxLoad.KFactorW2))
         .Add(New SqlColumn(Table.KFactorW3, SqlDataType.String, boxLoad.KFactorW3))
         .Add(New SqlColumn(Table.KFactorW4, SqlDataType.String, boxLoad.KFactorW4))
         .Add(New SqlColumn(Table.KFactorW5, SqlDataType.String, boxLoad.KFactorW5))
         .Add(New SqlColumn(Table.KFactorW6, SqlDataType.String, boxLoad.KFactorW6))

         .Add(New SqlColumn(Table.WallTot, SqlDataType.String, boxLoad.WallTot))
         .Add(New SqlColumn(Table.FExtTemp, SqlDataType.String, boxLoad.FExtTemp))
         .Add(New SqlColumn(Table.InsulF, SqlDataType.String, boxLoad.InsulF))
         .Add(New SqlColumn(Table.ThickF, SqlDataType.String, boxLoad.ThickF))
         .Add(New SqlColumn(Table.KFactorF, SqlDataType.String, boxLoad.KFactorF))
         .Add(New SqlColumn(Table.FloorTot, SqlDataType.String, boxLoad.FloorTot))
         .Add(New SqlColumn(Table.CExtTemp, SqlDataType.String, boxLoad.CExtTemp))
         .Add(New SqlColumn(Table.InsulC, SqlDataType.String, boxLoad.InsulC))
         .Add(New SqlColumn(Table.ThickC, SqlDataType.String, boxLoad.ThickC))
         .Add(New SqlColumn(Table.KFactorC, SqlDataType.String, boxLoad.KFactorC))
         .Add(New SqlColumn(Table.CeilingTot, SqlDataType.String, boxLoad.CeilingTot))
         .Add(New SqlColumn(Table.TransTot, SqlDataType.String, boxLoad.TransTot))
         .Add(New SqlColumn(Table.IVolume, SqlDataType.String, boxLoad.IVolume))
         .Add(New SqlColumn(Table.InfWb, SqlDataType.String, boxLoad.InfWb))
         .Add(New SqlColumn(Table.InfDb, SqlDataType.String, boxLoad.InfDb))
         .Add(New SqlColumn(Table.IFactor, SqlDataType.String, boxLoad.IFactor))
         .Add(New SqlColumn(Table.IAirChg, SqlDataType.String, boxLoad.IAirChg))
         '.Add( New SqlColumn(Table.IHeatRem, SqlDataType.String, boxLoad.IHeatRem
         .Add(New SqlColumn(Table.TotInfil, SqlDataType.String, boxLoad.TotInfil))
         '.Add( New SqlColumn(Table.Product, SqlDataType.String, boxLoad.Product
         '.Add( New SqlColumn(Table.Type_, SqlDataType.String, boxLoad.Type
         '.Add( New SqlColumn(Table.FreezePt, SqlDataType.String, boxLoad.Free
         '.Add( New SqlColumn(Table.CHeat, SqlDataType.String, boxLoad.Che
         '.Add( New SqlColumn(Table.CFHeat, SqlDataType.String, boxLoad.CF
         '.Add( New SqlColumn(Table.FLatent, SqlDataType.String, boxLoad.Fl
         '.Add( New SqlColumn(Table.FLatent, SqlDataType.String, boxLoad.Fl
         '.Add( New SqlColumn(Table.CIbs, SqlDataType.String, boxLoad.CIbs
         '.Add( New SqlColumn(Table.CLoad, SqlDataType.String, boxLoad.Cload
         '.Add( New SqlColumn(Table.CPull, SqlDataType.String, boxLoad.C
         '.Add( New SqlColumn(Table.CEnter, SqlDataType.String, boxLoad.CEn
         '.Add( New SqlColumn(Table.CFinal, SqlDataType.String, boxLoad.CF) )
         '.Add( New SqlColumn(Table.CTot, SqlDataType.String, boxLoad.cTot
         '.Add( New SqlColumn(Table.FTot, SqlDataType.String, boxLoad.Fot
         '.Add( New SqlColumn(Table.CFPTot, SqlDataType.String, boxLoad.CFPTot
         '.Add( New SqlColumn(Table.RIbs, SqlDataType.String, boxLoad.RIb
         '.Add( New SqlColumn(Table.RHeat, SqlDataType.String, boxLoad.RHea
         '.Add( New SqlColumn(Table.RTot, SqlDataType.String, boxLoad.Rto
         '.Add( New SqlColumn(Table.ProdTot, SqlDataType.String, boxLoad.prod
         .Add(New SqlColumn(Table.WattL, SqlDataType.String, boxLoad.WattL))
         .Add(New SqlColumn(Table.TotOl, SqlDataType.String, boxLoad.TotOl))
         .Add(New SqlColumn(Table.MotorHp, SqlDataType.String, boxLoad.MotorHp))
         .Add(New SqlColumn(Table.TotOm, SqlDataType.String, boxLoad.TotOm))
         .Add(New SqlColumn(Table.People, SqlDataType.String, boxLoad.People))
         .Add(New SqlColumn(Table.TotOp, SqlDataType.String, boxLoad.TotOP))
         .Add(New SqlColumn(Table.OtherType, SqlDataType.String, boxLoad.OtherType))
         .Add(New SqlColumn(Table.OtherBtu, SqlDataType.String, boxLoad.OtherBtu))
         .Add(New SqlColumn(Table.TotOo, SqlDataType.String, boxLoad.TotOo))
         .Add(New SqlColumn(Table.OtherTot, SqlDataType.String, boxLoad.OtherTot))
         .Add(New SqlColumn(Table.SumTran, SqlDataType.String, boxLoad.SumTran))
         .Add(New SqlColumn(Table.SumInf, SqlDataType.String, boxLoad.SumInf))
         .Add(New SqlColumn(Table.SumProd, SqlDataType.String, boxLoad.SumProd))
         .Add(New SqlColumn(Table.SumOther, SqlDataType.String, boxLoad.SumOther))
         .Add(New SqlColumn(Table.SumTot, SqlDataType.String, boxLoad.SumTot))
         .Add(New SqlColumn(Table.Safety, SqlDataType.String, boxLoad.Safety))
         .Add(New SqlColumn(Table.SafetyTot, SqlDataType.String, boxLoad.SafetyTot))
         .Add(New SqlColumn(Table.RunVar, SqlDataType.String, boxLoad.RunVar))
         .Add(New SqlColumn(Table.RunVarTot, SqlDataType.String, boxLoad.RunVarTot))
         .Add(New SqlColumn(Table.LoadTot, SqlDataType.String, boxLoad.LoadTot))
         .Add(New SqlColumn(Table.btnAllWallsy, SqlDataType.Boolean, boxLoad.btnAllWallSy.ToString))
         .Add(New SqlColumn(Table.btnAllWallsN, SqlDataType.Boolean, boxLoad.btnAllWallSn.ToString))
         '.Add( New SqlColumn(Table.chkFreezePt, SqlDataType.Boolean, boxLoad.c
         '.Add( New SqlColumn(Table.chkFreezeToCore, SqlDataType.Boolean, boxLoad.
         .Add(New SqlColumn(Table.myState, SqlDataType.String, boxLoad.MyState))
         .Add(New SqlColumn(Table.myCity, SqlDataType.String, boxLoad.MyCity))
         .Add(New SqlColumn(Table.Rw1, SqlDataType.Number, boxLoad.Rw1.ToString))
         .Add(New SqlColumn(Table.Rw2, SqlDataType.Number, boxLoad.Rw2.ToString))
         .Add(New SqlColumn(Table.Rw3, SqlDataType.Number, boxLoad.Rw3.ToString))
         .Add(New SqlColumn(Table.Rw4, SqlDataType.Number, boxLoad.Rw4.ToString))
         .Add(New SqlColumn(Table.Rw5, SqlDataType.Number, boxLoad.Rw5.ToString))
         .Add(New SqlColumn(Table.Rw6, SqlDataType.Number, boxLoad.Rw6.ToString))
         .Add(New SqlColumn(Table.RwFloor, SqlDataType.String, boxLoad.RwFloor.ToString))
         .Add(New SqlColumn(Table.RwCeiling, SqlDataType.String, boxLoad.RwCeiling.ToString))
         .Add(New SqlColumn(Table.KFactors, SqlDataType.Boolean, boxLoad.KFactors.ToString))
         .Add(New SqlColumn(Table.Forklift, SqlDataType.String, boxLoad.ForkLift))
         .Add(New SqlColumn(Table.TotForklift, SqlDataType.String, boxLoad.TotForkLift))
         .Add(New SqlColumn(Table.DockDoors, SqlDataType.String, boxLoad.DockDoors))
         '.Add( New SqlColumn(Table.TotDockDoors, SqlDataType.String, boxLoad.TotDo
         .Add(New SqlColumn(Table.Wall1, SqlDataType.String, boxLoad.Wall1))
         .Add(New SqlColumn(Table.Wall2, SqlDataType.String, boxLoad.Wall2))
         .Add(New SqlColumn(Table.Wall3, SqlDataType.String, boxLoad.Wall3))
         .Add(New SqlColumn(Table.Wall4, SqlDataType.String, boxLoad.Wall4))
         .Add(New SqlColumn(Table.Wall5, SqlDataType.String, boxLoad.Wall5))
         .Add(New SqlColumn(Table.Wall6, SqlDataType.String, boxLoad.Wall6))
         .Add(New SqlColumn(Table.Height1, SqlDataType.String, boxLoad.Height1))
         .Add(New SqlColumn(Table.Height2, SqlDataType.String, boxLoad.Height2))
         .Add(New SqlColumn(Table.Height3, SqlDataType.String, boxLoad.Height3))
         .Add(New SqlColumn(Table.Height4, SqlDataType.String, boxLoad.Height4))
         .Add(New SqlColumn(Table.Height5, SqlDataType.String, boxLoad.Height5))
         .Add(New SqlColumn(Table.Height6, SqlDataType.String, boxLoad.Height6))

         .Add(New SqlColumn(Table.rdoRectangle, SqlDataType.Boolean, boxLoad.rdoRectangle.ToString))
         .Add(New SqlColumn(Table.txtImageCounter, SqlDataType.String, boxLoad.txtImageCounter))

         .Add(New SqlColumn(Table.Description, SqlDataType.String, boxLoad.Description))
         .Add(New SqlColumn(Table.UserCapacity, SqlDataType.String, boxLoad.UserCapacity))
         .Add(New SqlColumn(Table.UserCapacityChecked, SqlDataType.Boolean, boxLoad.UserCapacityChecked.ToString))
         '.Add( New SqlColumn(Table.CreatedWhen, SqlDataType.Date, boxLoad.Created
         .Add(New SqlColumn(Table.RoomNumber, SqlDataType.String, boxLoad.RoomNumber))
         '.Add( New SqlColumn(Table.BlName, SqlDataType.String, boxLoad.Name
         '.Add( New SqlColumn(Table.ProcessId, SqlDataType.String, boxLoad.ProcessId
         '.Add( New SqlColumn(Table.CreatedBy, SqlDataType.String, boxLoad.Created

      End With

      Return columns
   End Function

End Module

End Namespace
