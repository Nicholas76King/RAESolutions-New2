Imports System.Collections.Generic
Imports Entities = Rae.RaeSolutions.Business.Entities
Imports rae.solutions.chillers
Imports rae.solutions.air_cooled_chillers
Imports System.Data
Imports ChillerDataAccess = Rae.RaeSolutions.DataAccess.Chillers.ChillerDataAccess

Namespace Rae.RaeSolutions.Business.Agents


Public Class ChillerAgent

   ''' <summary>Retrieves the chiller evaporator info for the evaporator model parameter</summary>
   ''' <exception cref="System.ApplicationException">Thrown when database error occurs</exception>
   Shared Function RetrieveChillerEvaporator(evaporatorModel As String) As Evaporator1
      Dim evaporator As New Evaporator1
      Dim evaporatorTable As DataTable

      Try
         evaporatorTable = ChillerDataAccess.RetrieveChillerEvaporator(evaporatorModel)
      Catch ex As dataException
         Throw New System.ApplicationException("Attempt to retrieve chiller evaporator was unsuccessful.", ex)
      End Try

      'If evaporatorTable.Rows.Count = 0 Then
      '   Throw New RAE.ExceptionHandling.Exceptions.ResultNullException("No evaporator matched evaporator model parameter.")
      'End If

      If evaporatorTable.Rows.Count > 0 Then
         With evaporator
            .RaePartNum       = evaporatorTable.Rows(0)("RAEPartNum").ToString
            .StandardModelNum = evaporatorTable.Rows(0)("StandardModelNum").ToString
            .NominalTons      = CSng(evaporatorTable.Rows(0)("NominalTons"))
            .ConnectionSize   = evaporatorTable.Rows(0)("ConnectionSize").ToString
            .Length           = CSng(evaporatorTable.Rows(0)("Length"))
            .Width            = CSng(evaporatorTable.Rows(0)("Width"))
            .Height           = CSng(evaporatorTable.Rows(0)("Height"))
            .EvaporatorPartNum= evaporatorTable.Rows(0)("EvaporatorPartNum").ToString
         End With
      End If

      Return evaporator
   End Function


   Shared Function RetrieveChiller(chillerModel As String) As chiller
      Dim chiller As New chiller
      Dim circuit1 As New circuit
      Dim circuit2 As New circuit

      Dim chillerTable = ChillerDataAccess.RetrieveChiller(chillerModel)

      If chillerTable Is Nothing OrElse chillerTable.Rows.Count = 0 Then Return Nothing

      With chillerTable.Rows(0)
         
         ' general
         chiller.model                    = .Item("Model").ToString
         chiller.evaporator_part_number   = ConvertNull.ToString(.Item("Evap_part_no"))
         chiller.approx_max_capacity      = ConvertNull.ToDouble(.Item("Approx_Max_Cap"))
         chiller.approx_min_capacity      = ConvertNull.ToDouble(.Item("Approx_Min_Cap"))
         chiller.num_circuits_per_unit    = ConvertNull.ToInteger(.Item("Circuits_Per_Unit"))


         ' circuit 1
         circuit1.refrigerant                = ConvertNull.ToString(.Item("Refg_1"))
         circuit1.subcooling_percentage      = ConvertNull.ToDouble(.Item("Degrees_Sub_Cooling_Coil_1"))
         circuit1.is_subcooling              = Convert.YesNoToBoolean(.Item("Sub_Cooling_1").ToString)
         circuit1.num_refrigeration_circuits = ConvertNull.ToInteger(.Item("Number_Ref_Circuits_1"))

         circuit1.coil.name         = ConvertNull.ToString(.Item("Coil_1"))
         circuit1.coil.fpi          = ConvertNull.ToInteger(.Item("FPI_1"))
         circuit1.coil.Capacity     = ConvertNull.ToDouble(.Item("Cap_1"))
         circuit1.coil.Diameter     = ConvertNull.ToDouble(.Item("Coil_Dia_1"))
         circuit1.coil.Height       = ConvertNull.ToDouble(.Item("Coil_H_1"))
         circuit1.coil.Length       = ConvertNull.ToDouble(.Item("Coil_L_1"))
         circuit1.coil.Rows         = ConvertNull.ToInteger(.Item("Rows_1"))
         circuit1.coil_quantity     = ConvertNull.ToInteger(.Item("CoilQty_1"))

                circuit1.compressor.masterID = ConvertNull.ToString(.Item("CompressorMasterID1"))
                '      circuit1.compressor.file_name = ConvertNull.ToString(.Item("Comprfile_1"))
                circuit1.compressor.type = Business.Intelligence.CompressorService.ConvertToCompressorType(ConvertNull.ToString(.Item("Compressor_Type_1")))
                circuit1.compressor_quantity = ConvertNull.ToInteger(.Item("Compr_Qty_1"))

                circuit1.fan_diameter = ConvertNull.ToDouble(.Item("Fan_Dia_1"))
                circuit1.fan_quantity = ConvertNull.ToDouble(.Item("FanQty_1"))

                chiller.circuit_1 = circuit1

                ' checks if there is a second circuit
                If chiller.num_circuits_per_unit > 1 Then
                    ' circuit 2
                    circuit2.refrigerant = ConvertNull.ToString(.Item("Refg_2"))
                    circuit2.subcooling_percentage = ConvertNull.ToDouble(.Item("Degrees_Sub_Cooling_Coil_2"))
                    circuit2.is_subcooling = Convert.YesNoToBoolean(.Item("Sub_Cooling_2").ToString)
                    circuit2.num_refrigeration_circuits = ConvertNull.ToInteger(.Item("Number_Ref_Circuits_2"))

                    circuit2.coil.name = ConvertNull.ToString(.Item("Coil_2"))
                    circuit2.coil.fpi = ConvertNull.ToInteger(.Item("FPI_2"))
                    circuit2.coil.capacity = ConvertNull.ToDouble(.Item("Cap_2"))
                    circuit2.coil.diameter = ConvertNull.ToDouble(.Item("Coil_Dia_2"))
                    circuit2.coil.height = ConvertNull.ToDouble(.Item("Coil_H_2"))
                    circuit2.coil.length = ConvertNull.ToDouble(.Item("Coil_L_2"))
                    circuit2.coil.rows = ConvertNull.ToInteger(.Item("Rows_2"))
                    circuit2.coil_quantity = ConvertNull.ToInteger(.Item("CoilQty_2"))

                    circuit2.compressor.masterID = ConvertNull.ToString(.Item("CompressorMasterID2"))
                    '  circuit2.compressor.file_name = ConvertNull.ToString(.Item("Comprfile_2"))
                    circuit2.compressor.type = Business.Intelligence.CompressorService.ConvertToCompressorType(ConvertNull.ToString(.Item("Compressor_Type_2")))
                    circuit2.compressor_quantity = ConvertNull.ToInteger(.Item("Compr_Qty_2"))

                    circuit2.fan_diameter = ConvertNull.ToDouble(.Item("Fan_Dia_2"))
                    circuit2.fan_quantity = ConvertNull.ToDouble(.Item("FanQty_2"))
                Else
                    circuit2 = Nothing
                End If

         chiller.circuit_2 = circuit2

      End With

      Return chiller
   End Function

End Class

End Namespace