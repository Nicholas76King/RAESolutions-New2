Imports System.Data

Public Enum ReportType
    Evap = 1
    WCChill = 2
    WCCond = 3
End Enum

Public Class CRDAL

   Public ds As DataSet

   Public dt As DataTable
   Private dr As DataRow

   Public Sub New()

   End Sub

   Sub New(rpt As ReportType)
       If rpt = ReportType.Evap Then
           CRDAL()
       ElseIf rpt = ReportType.WCChill Then
           CRDAL(True)
       ElseIf rpt = ReportType.WCCond Then
           CRDAL(False)
       End If
   End Sub

   Sub CRDAL(IsWC As Boolean) 'for WC Chiller / WC Cond Unit format
      ds = New DataSet

      'initialize the data table

      'init the row
      'dr = New DataRow()
      If IsWC Then
          dt = New DataTable("WC_CALCULATIONS")

          Dim dc As DataColumn

          dc = New DataColumn
          dc.ColumnName = "TW"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "CE"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "CL"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "TE"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "TC"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "Q"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "GPM"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "KW"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "GP"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "PD"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "ER"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)
      Else
          dt = New DataTable("WCond_CALCULATIONS")

          Dim dc As DataColumn
          dc = New DataColumn
          dc.ColumnName = "CE"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "CL"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "TE"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "TC"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "Q"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "KW"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "GP"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "PD"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)

          dc = New DataColumn
          dc.ColumnName = "ER"
          dc.DataType = System.Type.GetType("System.String")
          dt.Columns.Add(dc)
      End If
      'set up all the columns

      ds.Tables.Add(dt)
   End Sub

   Sub CRDAL()
      ds = New DataSet

      'initialize the data table
      dt = New DataTable("CALCULATIONS")

      'init the row
      'dr = New DataRow()

      'set up all the columns
      Dim dc As DataColumn

      dc = New DataColumn
      dc.ColumnName = "TW"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "TA"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "TE"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "TC"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "Q"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

        dc = New DataColumn
        dc.ColumnName = "UKW"
        dc.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "KW"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "GP"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "A"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "ER"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      dc = New DataColumn
      dc.ColumnName = "EZ"
      dc.DataType = System.Type.GetType("System.String")
      dt.Columns.Add(dc)

      ds.Tables.Add(dt)


   End Sub

   Sub InsertResults(TW, TA, TE, TC, Q, UKW, KW, GP, A, ER, EZ)
      dr = dt.NewRow()
      dr("TW") = CStr(Format(TW, "###"))
      dr("TA") = CStr(Format(TA, "###"))
      dr("TE") = CStr(Format(TE, "##.0"))
      dr("TC") = CStr(Format(TC, "###.0"))
      dr("Q") = CStr(Format(Q, "###.0"))
      dr("UKW") = CStr(Format(UKW, "####.0"))
      dr("KW") = CStr(Format(KW, "####.0"))
      dr("GP") = CStr(Format(GP, "####.0"))
      if A >= 999 then
         dr("A") = "*"
      else
         dr("A") = CStr(Format(A, "###.#0"))
      end if
      dr("ER") = CStr(Format(ER, "####.##"))
      dr("EZ") = CStr(Format(EZ, "####.##"))
      dt.Rows.Add(dr)
   End Sub
   
   sub insert(tw, ta, message)
      dim text = tw & ", " & ta & " - " & message.status.toString() & ": " & message.description
      dr = dt.NewRow()
      dr("TW") = text
      dr("TA") = ""
      dr("TE") = ""
      dr("TC") = ""
      dr("Q")  = ""
      dr("UKW")= ""
      dr("KW") = ""
      dr("GP") = ""
      dr("A")  = ""
      dr("ER") = ""
      dr("EZ") = ""
      dt.rows.add(dr)
   end sub

   Public Sub InsertResults2(TW, CE, CL, TE, TC, Q, GPM, KW, GP, PD, ER)
      If dt.TableName = ("WCond_CALCULATIONS") Then
         dr = dt.NewRow()
         dr("CE") = CStr(Format(CE, "###"))
         dr("CL") = CStr(Format(CL, "###"))
         dr("TE") = CStr(Format(TE, "##.0"))
         dr("TC") = CStr(Format(TC, "###.0"))
         dr("Q") = CStr(Format(Q, "###.0"))
         dr("KW") = CStr(Format(KW, "####.0"))
         dr("GP") = CStr(Format(GP, "####.0"))
         dr("PD") = CStr(Format(PD, "##.#"))
         dr("ER") = CStr(Format(ER, "####.#"))
         dt.Rows.Add(dr)
      Else
         dr = dt.NewRow()
         dr("TW") = CStr(Format(TW, "###"))
         dr("CE") = CStr(Format(CE, "###"))
         dr("CL") = CStr(Format(CL, "###"))
         dr("TE") = CStr(Format(TE, "##.0"))
         dr("TC") = CStr(Format(TC, "###.0"))
         dr("Q") = CStr(Format(Q, "###.0"))
         dr("GPM") = CStr(Format(GPM, "####.0"))
         dr("KW") = CStr(Format(KW, "####.0"))
         dr("GP") = CStr(Format(GP, "####.0"))
         dr("PD") = CStr(Format(PD, "##.#"))
         dr("ER") = CStr(Format(ER, "####.#"))
         dt.Rows.Add(dr)
      End If
   End Sub

   Sub InsertBlankRowInResults()

      'Dim dr As DataRow

      dr = dt.NewRow
      dr("TW") = "-"
      dr("TA") = "-"
      dr("TE") = "-"
      dr("TC") = "-"
        dr("Q") = "-"
        dr("UKW") = "-"
      dr("KW") = "-"
      dr("GP") = "-"
      dr("A") = "-"
      dr("ER") = "-"
      dr("EZ") = "-"
      dt.Rows.Add(dr)

    End Sub

    Sub InsertBlankRowInResults2()

        If dt.TableName = ("WCond_CALCULATIONS") Then
            dr = dt.NewRow
            dr("CE") = "-"
            dr("CL") = "-"
            dr("TE") = "-"
            dr("TC") = "-"
            dr("Q") = "-"
            dr("KW") = "-"
            dr("GP") = "-"
            dr("PD") = "-"
            dr("ER") = "-"
            dt.Rows.Add(dr)
        Else
            dr = dt.NewRow
            dr("TW") = "-"
            dr("CE") = "-"
            dr("CL") = "-"
            dr("TE") = "-"
            dr("TC") = "-"
            dr("Q") = "-"
            dr("GPM") = "-"
            dr("KW") = "-"
            dr("GP") = "-"
            dr("PD") = "-"
            dr("ER") = "-"
            dt.Rows.Add(dr)
        End If

 

    End Sub

   Sub Reset()
      dt.Reset()
   End Sub

   Sub Clean()
      Dim i As Integer

      'i = dt.Rows.Count()
      dt.Clear()

      'If i <> 0 Then
      'Dim row As DataRow
      'Try
      'For Each row In dt.Rows
      'row.Delete()
      'Next
      'Catch
      'Finally
      'End Try
      'End If
   End Sub

   Public Function CALCULATIONS() As DataSet
      Return ds
   End Function

End Class
