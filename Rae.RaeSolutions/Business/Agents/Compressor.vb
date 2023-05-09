Imports System.Collections.Generic
Imports System.Data

Namespace Rae.RaeSolutions.Business.Agents

Public Class Compressor

   ''' <summary>Hides default constructor</summary>
   Private Sub New()
   End Sub


   ''' <summary>Retrieves compressor descriptions in addition to to other compressor info
   ''' based on refrigerant parameter
   ''' </summary>
   ''' <param name="refrigerant">Compressor's refrigerant, omit R prefix (ex. 22H not R22H)</param>
   ''' <returns>Table of compressors matching refrigerant parameter</returns>
   Overloads Shared Function RetrieveCompressorDescriptions(refrigerant As String) As DataTable
      Dim row As DataRow

      ' retrieves table of all compressors w/ refrigerant
      Dim compressorsTable As DataTable = DataAccess.CompressorDataAccess.RetrieveCompressors(refrigerant)
      ' adds description column
      compressorsTable.Columns.Add("Description", GetType(String))

      ' creates a list of compressor descriptions from table
      For Each row In compressorsTable.Rows
         ' adds a description to the list, 'model        HP: hp'
         row("Description") = row("compmodel").ToString.PadRight(13) & "HP: " & row("hp").ToString
      Next

      Return compressorsTable
   End Function

   Overloads Shared Function RetrieveCompressorDescriptions2(refrigerant As String, Optional ByVal isNewCoeff As Boolean = False) As DataTable
      Dim row As DataRow

      ' retrieves table of all compressors w/ refrigerant
      Dim compressorsTable As DataTable = DataAccess.CompressorDataAccess.RetrieveCompressors2(refrigerant, isNewCoeff)
      ' adds description column
      compressorsTable.Columns.Add("Description", GetType(String))

      ' creates a list of compressor descriptions from table
      For Each row In compressorsTable.Rows
          ' adds a description to the list, 'model        HP: hp'
          row("Description") = row("compmodel").ToString.PadRight(13) & "HP: " & row("hp").ToString
      Next

      Return compressorsTable
   End Function


   Overloads Shared Function RetrieveCompressorDescriptions( _
   compressorModels As List(Of String), refrigerant As String) As DataTable
      Dim compressorTable As DataTable
      Dim comprehensiveCompressorTable As New DataTable("Compressors")
      Dim row As DataRow

      For i As Integer = 0 To compressorModels.Count - 1
         ' retrieves all compressor data
         compressorTable = DataAccess.CompressorDataAccess.RetrieveCompressor(compressorModels(i), refrigerant)
         ' adds column
         compressorTable.Columns.Add("Description", GetType(String))
         ' builds compressor description
         compressorTable.Rows(0)("Description") = compressorTable.Rows(0)("compModel").ToString.PadRight(13) & _
            "HP: " & compressorTable.Rows(0)("hp").ToString
         ' copies structure of table
         If i = 0 Then comprehensiveCompressorTable = compressorTable.Clone()
         ' copies row, Note: row can only belong to one table at a time
         row = comprehensiveCompressorTable.NewRow
         For j As Integer = 0 To compressorTable.Columns.Count - 1
            row(j) = compressorTable.Rows(0)(j)
         Next
         ' adds copy of row to table that will hold all data
         comprehensiveCompressorTable.Rows.Add(row)
      Next

      Return comprehensiveCompressorTable
   End Function

End Class
End Namespace