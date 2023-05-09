Imports Rae.RaeSolutions.DataAccess
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports MT = Rae.DataAccess.EquipmentOptions.Tables.master_options_table
Imports ST = Rae.DataAccess.EquipmentOptions.Tables.SeriesTable
Imports PT = Rae.DataAccess.EquipmentOptions.Tables.PersTable
Imports opt = Rae.DataAccess.EquipmentOptions.Tables.OptionPricingTable
Imports pbst = Rae.DataAccess.EquipmentOptions.Tables.PricingBySeriesTable
Imports pbft = Rae.DataAccess.EquipmentOptions.Tables.PricingByNumFansTable
Imports pbmt = Rae.DataAccess.EquipmentOptions.Tables.PricingByModelTable

Namespace Rae.DataAccess.EquipmentOptions
    Friend Class Query

        Function OpsFrom(ByVal table As String) As Query
            ' NOTE: using PricingByNumFans.PricingId and SeriesId because they're named the same
            ' in the other tables, the parameter table is the table name they're actually
            ' retrieved from though
            Dim sql = New StringBuilder
            sql.AppendFormat("SELECT * FROM ((({0} INNER JOIN {1} ON {0}.{2}={1}.{3}) ", _
               opt.TableName, table, opt.Id, pbft.PricingId)
            sql.AppendFormat("INNER JOIN {0} ON {1}.{2}={0}.{3}) ", _
               MT.table_name, opt.TableName, opt.OptionId, MT.Id)
            sql.AppendFormat("INNER JOIN {0} ON {1}.{2}={0}.{3}) ", _
               ST.TableName, table, pbft.SeriesId, ST.Id)
            sql.AppendFormat("INNER JOIN {0} ON {1}.{2}={0}.{3} ", _
         PT.TableName, opt.TableName, opt.PerId, PT.Id)
            _sql = sql.ToString
            Return Me
        End Function

        Function Where() As Query
            _sql &= " WHERE "
            Return Me
        End Function

        Function [And]() As Query
            _sql &= " AND "
            Return Me
        End Function

        Function Append(ByVal sql As String) As Query
            _sql &= sql
            Return Me
        End Function

        Function SeriesIs(ByVal series As String) As Query
            _sql &= New StringBuilder().AppendFormat("{0}='{1}'", ST.Series, series).ToString
            Return Me
        End Function

        Function VoltageIs(ByVal voltage As Integer) As Query
            _sql &= New StringBuilder().AppendFormat("({0}={1} OR {0}=0)", MT.Voltage, voltage).ToString
            Return Me
        End Function

        Function NumFansIs(ByVal numFans As Integer) As Query
            _sql &= New StringBuilder().AppendFormat("({0}<={1} AND {2}>={1})", pbft.Low, numFans, pbft.High).ToString
            Return Me
        End Function

        Function FanMotorPhaseIs(ByVal phase As Integer) As Query
            _sql &= New StringBuilder().AppendFormat("({0}={1} OR {0}=0)", MT.phase, phase).ToString
            Return Me
        End Function

        Function ModelIs(ByVal model As String) As Query
            _sql &= New StringBuilder().AppendFormat("{0}='{1}'", pbmt.Model, model).ToString
            Return Me
        End Function

        Function CodeIs(ByVal code As String) As Query
            _sql &= New StringBuilder().AppendFormat("{0}='{1}'", MT.Code, code).ToString
            Return Me
        End Function

        Function PricingIdIs(ByVal pricingId As Integer) As Query
            _sql &= New StringBuilder().AppendFormat("{0}.{1}={2}", opt.TableName, opt.Id, pricingId).ToString
            Return Me
        End Function

        Function IsNotObsolete() As Query
            _sql &= New StringBuilder().AppendFormat("{0}.{1}=False", opt.TableName, opt.Obsolete).ToString()
            Return Me
        End Function

        Function IsObsolete() As Query
            _sql &= New StringBuilder().AppendFormat("{0}.{1}=True", opt.TableName, opt.Obsolete).ToString()
            Return Me
        End Function


        ReadOnly Property SQL() As String
            Get
                Return _sql
            End Get
        End Property

        Public Shared AvailableSql As String = New StringBuilder().AppendFormat("{0}<>999999", opt.Price).ToString()
        'Public Shared AvailableSql As String = New StringBuilder(). _
        '   AppendFormat("{0}<>999999", opt.Price).ToString
        Public Shared StandardSql As String = New StringBuilder(). _
           AppendFormat("{0}=999999", opt.Price).ToString

        Private _sql, series, model As String
        Private voltage, numFans As Integer

    End Class
End Namespace
