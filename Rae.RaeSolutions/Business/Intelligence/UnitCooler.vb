Imports System.Data

Namespace Rae.RaeSolutions.Business.Intelligence

Public Class UnitCooler

   ''' <summary>Gets compressor file name for condensing unit.</summary>
   ''' <exception cref="ApplicationException">
   ''' Thrown when data access error occurs or condensing unit does not exist
   ''' </exception>
   Shared Function GetCompressorFileName(condensing_unit_model As String) As String
      If String.IsNullOrEmpty(condensing_unit_model) Then _
         Throw New ApplicationException(strings.CannotGetCompressorFileNameCondensingUnitIsNull)

      dim condensing_unit as rae.solutions.condensing_units.Condensing_Unit
      Try
         dim repository = new rae.solutions.condensing_units.Repository()
         condensing_unit = repository.get_unit(condensing_unit_model)
      Catch dbEx As DataException
         Throw New ApplicationException(strings.ErrorRetrievingCompressorDataForCondensingUnit(dbEx))
      End Try

      ' checks if compressor data was found
      if condensing_unit is nothing then
         throw new ApplicationException(strings.CannotGetCompressorFileNameCondensingUnitDoesNotExist(condensing_unit_model))
      end if

            Dim compressorMasterID = condensing_unit.circuits(0).compressorMasterID

            Return compressorMasterID
   End Function

   Private Class strings

      Shared Function ErrorRetrievingCompressorDataForCondensingUnit(exceptionMessage As DataException) As String
         Return "The attempt to retrieve compressor information for the condensing unit failed. A database exception occured: " & exceptionMessage.Message
      End Function

      Private Shared cannotGetCompressorFileNameForCondensingUnit As String = _
         "The attempt to retreive the compressor file name for a condensing unit failed."

      Shared Function CannotGetCompressorFileNameCondensingUnitDoesNotExist(condensingUnitModel As String) As String
         Return strings.cannotGetCompressorFileNameForCondensingUnit & " Condensing unit model, " & condensingUnitModel & ", does not exist."
      End Function

      Shared Function CannotGetCompressorFileNameCondensingUnitIsNull() As String
         Return strings.cannotGetCompressorFileNameForCondensingUnit & " Condensing unit model is null or empty."
      End Function

   End Class
   
End Class
End Namespace