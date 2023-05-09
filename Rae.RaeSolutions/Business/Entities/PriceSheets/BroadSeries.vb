Namespace Rae.RaeSolutions.Business.Entities.PriceSheets

    Module BroadSeries

        ''' <summary>Broadens series (ex. 20A0CS > 20A0)</summary>
        ''' <param name="series">Equipment series to broaden</param>
        Function Broaden(ByVal series As String) As String
            Dim broadSeries As String

            Select Case series
                Case "10A0"
                    broadSeries = "10A0"
                Case "20A0CS", "20A0CD", "20A0CM", "20A0LS", "20A0LD"
                    broadSeries = "20A0"
                Case "30A0CS", "30A0CD", "30A0CM", "30A0LS", "30A0LD"
                    broadSeries = "30A0"
                Case "30A1SS", "30A1SD", "30A1SM"
                    broadSeries = "30A1"
                Case "32A0CS", "32A0CD", "32A0CM"
                    broadSeries = "32A0"
                Case "33A0CS", "33A0CD", "33A0CM"
                    broadSeries = "33A0"
                Case "34W0CS", "34W0CD", "34W0CM", "34W0LS", "34W0LD", "34W0SS", "34W0SD", "34W0SM"
                    broadSeries = "34W0"
                Case "NDB", "NSB", "NMB", "N", "NDF", "NSF", "NDC", "NSC"
                    broadSeries = "N"


                Case "DS", "DD", "DM"
                    broadSeries = "D"
                Case "LUI", "LUO"
                    broadSeries = "LUI"
                Case "HPC", "VPC"
                    broadSeries = "HPC"
                Case "A", "BOC", "NIBR", "WIBR", "XBOC"
                    broadSeries = "UnitCooler"
                Case "FV", "FH"
                    broadSeries = "F"
                Case "FC2", "FC4", "FC12", "FC24", "FC36", "FC48", "FC72", "FC96"
                    broadSeries = "FC"
                    '   Case "BLU-L", "BLU-B"
                    '      broadSeries = "BLU"
                Case Else
                    broadSeries = series
            End Select

            Return broadSeries
        End Function

    End Module

End Namespace