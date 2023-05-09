Imports System
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

''' <summary>Arranges pages so that associated covers and price sheets are together 
''' and covers are not duplicated.</summary>
Class PageArranger

   Sub New(repository As IPriceSheetRepository, _
           series_options As List(Of Series_Options_Assoc))
      If series_options Is Nothing Then _
         Throw New ArgumentNullException("PageArranger does not accept null series options parameter in constructor.")
      Me.series_ops = series_options
      Me.repository = repository
   End Sub


   ''' <summary>Gets list of associations between series and page types.</summary>
   ReadOnly Property Series_PageType_Assocs As List(Of Series_PageType_Assoc)
      Get
         Return _series_pageType_Assocs
      End Get
   End Property


   ''' <summary>Arranges price sheet pages.
   ''' Prevents the same series cover page from being printed multiple times for similar series (ex. 20A0CS, 20A0CD, 20A0CM).
   ''' </summary>
   Function Arrange() As List(Of Series_PageType_Assoc)
      Me._series_pageType_Assocs.Clear()

      If Me.isCentury() Then
         If Me.series_ops.Count > 1 Then
            Me._series_pageType_Assocs = Me.sortCenturySeriesOptions()
         Else
            Me._series_pageType_Assocs = Me.getPageTypesFor(Me.series_ops(0).Series)
         End If
      Else ' assumes is Technical Systems
         ' assumes printing entire technical systems
         If Me.series_ops.Count > 1 Then
            Me._series_pageType_Assocs = Me.sortTechnicalSystemsSeriesOptions() 'Me.sortSeriesOptionsBySeries()
         Else
            Me._series_pageType_Assocs = Me.getPageTypesFor(Me.series_ops(0).Series)
         End If
      End If

      Return Me._series_pageType_Assocs
   End Function


#Region " Private methods"

   Private repository As IPriceSheetRepository
   Private series_ops As List(Of Series_Options_Assoc)
   Private _series_pageType_Assocs As New List(Of Series_PageType_Assoc)()

   Private Function sortSeriesOptionsBySeries() As List(Of Series_Options_Assoc)
      Dim sortedList As New List(Of Series_Options_Assoc)()
      Dim unsortedList As List(Of Series_Options_Assoc) = Me.series_ops

      For i As Integer = 0 To unsortedList.Count - 1
         If sortedList.Count > 0 Then
            For j As Integer = 0 To sortedList.Count - 1
               If unsortedList(i).Series <= sortedList(j).Series Then
                  sortedList.Insert(j, unsortedList(i))
                  Exit For
               ElseIf sortedList.Count - 1 = j Then
                  sortedList.Add(unsortedList(i))
               End If
            Next
         Else
            sortedList.Add(unsortedList(i))
         End If
      Next

      Return sortedList
   End Function


   Private Function isCentury() As Boolean
      Dim century As Boolean
      Dim seriesList As List(Of String) = repository.GetSeriesIn("CRI")

      For Each series As String In seriesList
         If series = Me.series_ops(0).Series Then
            century = True
            Exit For
         End If
      Next

      Return century
   End Function


   Private Function sortCenturySeriesOptions() As List(Of Series_PageType_Assoc)
      Dim sorted As New List(Of Series_PageType_Assoc)()

            sorted.Add(New Series_PageType_Assoc("N", PageType.Cover))
            sorted.Add(New Series_PageType_Assoc("NSB", PageType.PriceSheets))
            sorted.Add(New Series_PageType_Assoc("NDB", PageType.PriceSheets))
            sorted.Add(New Series_PageType_Assoc("NSC", PageType.PriceSheets))
            sorted.Add(New Series_PageType_Assoc("NDC", PageType.PriceSheets))
            sorted.Add(New Series_PageType_Assoc("NSF", PageType.PriceSheets))
            sorted.Add(New Series_PageType_Assoc("NDF", PageType.PriceSheets))

            sorted.Add(New Series_PageType_Assoc("D", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("DS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("DD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("DM", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("LUI", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("LUI", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("LUO", PageType.PriceSheets))
            'sorted.Add(New Series_PageType_Assoc("RS", PageType.Cover))
            'sorted.Add(New Series_PageType_Assoc("RS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("HPC", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("HPC", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("VPC", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("PFC", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("PFC", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("UnitCooler", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("A", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("BOC", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("PFE", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("PFE", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("F", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("FH", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("FV", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("BALV", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("BALV", PageType.PriceSheets))

      Return sorted
   End Function


   Private Function sortTechnicalSystemsSeriesOptions() As List(Of Series_PageType_Assoc)
      Dim sorted As New List(Of Series_PageType_Assoc)

      sorted.Add(New Series_PageType_Assoc("10A0", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("10A0", PageType.PriceSheets))

      sorted.Add(New Series_PageType_Assoc("20A0", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("20A0CS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("20A0CD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("20A0CM", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("20A0LS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("20A0LD", PageType.PriceSheets))

      sorted.Add(New Series_PageType_Assoc("30A0", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("30A0CS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("30A0CD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("30A0CM", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("30A0LS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("30A0LD", PageType.PriceSheets))

      sorted.Add(New Series_PageType_Assoc("30A1", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("30A1SS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("30A1SD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("30A1SM", PageType.PriceSheets))

      sorted.Add(New Series_PageType_Assoc("32A0", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("32A0CS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("32A0CD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("32A0CM", PageType.PriceSheets))

      sorted.Add(New Series_PageType_Assoc("33A0", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("33A0CS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("33A0CD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("33A0CM", PageType.PriceSheets))

      sorted.Add(New Series_PageType_Assoc("34W0", PageType.Cover))
      sorted.Add(New Series_PageType_Assoc("34W0CS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("34W0CD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("34W0CM", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("34W0SS", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("34W0SD", PageType.PriceSheets))
      sorted.Add(New Series_PageType_Assoc("34W0SM", PageType.PriceSheets))

      Return sorted
   End Function


   Private Function getPageTypesFor(series As String) As List(Of Series_PageType_Assoc)
      Dim series_PageTypes As New List(Of Series_PageType_Assoc)()

      Dim cover = New Series_PageType_Assoc( Broaden(series), PageType.Cover )
      series_PageTypes.Add( cover )

      Dim pricing = New Series_PageType_Assoc(series, PageType.PriceSheets)
      series_PageTypes.Add( pricing )

      Return series_PageTypes
   End Function


   Private Function getSeriesOptionsWithSeries( _
   series As String, seriesOptionsToSearch As List(Of Series_Options_Assoc)) As Series_Options_Assoc
      For Each seriesOptions As Series_Options_Assoc In seriesOptionsToSearch
         If seriesOptions.Series = series Then
            Return seriesOptions
         End If
      Next

      Throw New System.ApplicationException("PageArranger cannot find series/options association for series, " & series & ".")
   End Function

#End Region

End Class

End Namespace