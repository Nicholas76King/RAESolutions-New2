Imports Rae.Data
Imports Rae.DataAccess.EquipmentOptions
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Text
Imports PBMT = Rae.DataAccess.EquipmentOptions.Tables.PricingByModelTable
Imports ST = Rae.DataAccess.EquipmentOptions.Tables.SeriesTable
Imports ET = Rae.DataAccess.EquipmentOptions.Tables.EquipmentPricingTable

Namespace Rae.DataAccess.EquipmentOptions

    Public Class EquipmentDataAccess

        ''' <summary>Retrieves only series that are in specified division and equipment type and filters for rep authorization.</summary>
        Shared Function retrieve_series(ByVal division As String, ByVal equipment_type As String, ByVal is_rep As Boolean) As List(Of String)
            Dim series_list As list(Of String)

            'todo: move authorization to database
            If equipment_type = "Chiller" And is_rep Then
                series_list = New list(Of String)
                'series_list.Add("30A2SS")
                'series_list.Add("30A2SD")
                'series_list.Add("30A2SM")
                series_list.Add("35E2SS")
                series_list.Add("35E2SD")
                series_list.Add("35E2SM")
            Else
                Dim sql = New StringBuilder().AppendFormat( _
                   "SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}' and {6} not like '{7}' and {6} not like '{8}'", _
                   ST.Series, ST.TableName, ST.Division, division, ST.EquipmentType, equipment_type, "Series", "%OBS", "BS%")


                If is_rep AndAlso division.ToUpper = "TSI" AndAlso equipment_type = "CondensingUnit" Then
                    sql.Append(" and ( series like '%LS%' or series like '%LD%' or series like '%LM%' ) ")
                End If

                If is_rep AndAlso division.ToUpper = "CRI" AndAlso equipment_type = "CondensingUnit" Then
                    sql.Append(" and series not in ('LUO','LUI','DS','DD') ")
                End If



                series_list = retrieve_strings(sql.ToString)
            End If

            Return series_list
        End Function

        ''' <summary>Retrieves all the series in the specified division.</summary>
        Shared Function RetrieveSalesCLass(ByVal series As String) As String
            Dim sql = New StringBuilder().AppendFormat( _
               "SELECT {0} FROM {1} WHERE {2}='{3}'", ST.SalesCLass, ST.TableName, ST.Series, series)

            Dim rStrings As List(Of String) = retrieve_strings(sql.ToString)

            If rStrings.Count > 0 Then
                Return rStrings(0)
            Else
                Return ""
            End If

        End Function





        ''' <summary>Retrieves all the series in the specified division.</summary>
        Shared Function RetrieveSeries(ByVal division As String) As List(Of String)
            Dim sql = New StringBuilder().AppendFormat( _
               "SELECT {0} FROM {1} WHERE {2}='{3}' and {5} not like '{6}' ORDER BY [{4}]", _
               ST.Series, ST.TableName, ST.Division, division, ST.ListOrder, "Series", "%OBS")

            Return retrieve_strings(sql.ToString)
        End Function




        ''' <summary>Retrieves model in the specified series
        ''' </summary>
        ''' <param name="series">Equipment series
        ''' </param>
        ''' <returns>List of models in the specified series
        ''' </returns>
        Shared Function RetrieveModels(ByVal series As String) As List(Of String)
            Dim sql = New StringBuilder().AppendFormat( _
               "SELECT {0} FROM {1} INNER JOIN {2} ON {1}.{3}={2}.{4} WHERE {2}.{2}='{6}' and {7} = 0", _
               "Model", "EquipmentPricing", "Series", "SeriesId", "Id", "Series", series, "HiddenModel").ToString
            Return retrieve_strings(sql)
        End Function


        ''' <summary>Retrieves equipment types in division
        ''' </summary>
        ''' <param name="division">Division of RAE Corporation
        ''' </param>
        ''' <returns>List of equipment types in division
        ''' </returns>
        Shared Function RetrieveTypes(ByVal division As String) As List(Of String)
            Dim sql = New StringBuilder().AppendFormat( _
               "SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}'", _
               ST.EquipmentType, ST.TableName, ST.Division, division)

            Return retrieve_strings(sql.ToString)
        End Function

        Function model_exists(ByVal series As String, ByVal model As String) As Boolean
            Dim sql = rae.io.text.str("SELECT {0} FROM {1} INNER JOIN {5} ON {1}.{2} = {5}.{6} WHERE {5}.{7}='{3}' AND {0}='{4}'",
                                      ET.Model, ET.TableName, ET.SeriesId, series, model, ST.TableName, ST.Id, ST.Series)
            Return retrieve_strings(sql).count > 0
        End Function



        Protected Shared Function retrieve_strings(ByVal sql As String) As List(Of String)
            Dim con = DataObjects.CreateConnection(ConnectionString.DataAccessType, ConnectionString.Text)
            Dim com = con.CreateCommand()
            com.CommandText = sql
            Dim rdr As IDataReader

            Dim series = New List(Of String)
            Try
                con.Open()
                rdr = com.ExecuteReader()
                While rdr.Read()
                    series.Add(rdr.GetString(0))
                End While
            Finally
                If rdr IsNot Nothing Then _
                   rdr.Close()
                If con.State <> ConnectionState.Closed Then _
                   con.Close()
            End Try

            Return series
        End Function

    End Class

End Namespace