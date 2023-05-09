Namespace rae.solutions.unit_coolers

    ''' <summary>converts model from format used in pricing database to format used in engineering database.</summary>
    ''' <remarks>ex. pricing/input model: BOC 550-1916HG. ex. engineering/output model: BOC 554-1916.</remarks>
    Public Class database_formatter
        '              |engineering|pricing |
        'refrigerant   | yes       | no     |
        'defrost type  | no        | yes    |

        Function format_model(ByVal model As String, ByVal refrigerant As String) As String
            Dim formatted_model = model 'will be formatted model
            Dim refrigerant_indicator = select_refrigerant_indicator(refrigerant)
            formatted_model = include_refrigerant_indicator_in_model(formatted_model, refrigerant_indicator)
            formatted_model = format_defrost_portion_of_model(formatted_model)
            Return formatted_model
        End Function

        'pricing model does not include refrigerant indicator in model 
        'ex. without refrigerant BOC 420-800
        'ex. with refrigerant    BOC 424-800
        'first 0 becomes a refrigerant indicator in this case 4)
        Private Function include_refrigerant_indicator_in_model(ByVal model As String, ByVal refrigerant_indicator As String) As String
            Dim f = model 'formatted model
            Dim r = refrigerant_indicator

            If Not model.Contains("-") Then Return model


            Dim lp, rp As String
            lp = model.Substring(0, model.IndexOf("-"))

            If IsNumeric(lp.Substring(lp.Length - 1)) Then
                lp = lp.Substring(0, lp.Length - 1) & refrigerant_indicator

            Else
                lp = lp.Substring(0, lp.Length - 2) & refrigerant_indicator

            End If

            rp = model.Substring(model.IndexOf("-"))

            model = lp & rp

            '                model_portion = model_portion.Remove(2, 1).Insert(2, "0") 'replace refrigerant indicator with 0


            Return model




            ''todo: figure out way to format without have to hard code all these models
            ' Done, you stupid shit.
            'If model Like "FV*" Then
            '    f = f.Replace("20", "2" & r)
            '    f = f.Replace("30", "3" & r)
            '    f = f.Replace("40", "4" & r)
            'Else
            '    f = f.Replace("410-", "41" & r & "-")
            '    f = f.Replace("420-", "42" & r & "-")
            '    f = f.Replace("430-", "43" & r & "-")
            '    f = f.Replace("440-", "44" & r & "-")
            '    f = f.Replace("450-", "45" & r & "-")
            '    f = f.Replace("460-", "46" & r & "-")
            '    f = f.Replace("510-", "51" & r & "-")
            '    f = f.Replace("520-", "52" & r & "-")
            '    f = f.Replace("530-", "53" & r & "-")
            '    f = f.Replace("540-", "54" & r & "-")
            '    f = f.Replace("550-", "55" & r & "-")
            '    f = f.Replace("560-", "56" & r & "-")
            '    f = f.Replace("610-", "61" & r & "-")
            '    f = f.Replace("620-", "62" & r & "-")
            '    f = f.Replace("630-", "63" & r & "-")
            '    f = f.Replace("640-", "64" & r & "-")
            '    f = f.Replace("650-", "65" & r & "-")
            '    f = f.Replace("660-", "66" & r & "-")
            '    f = f.Replace("810-", "81" & r & "-")
            '    f = f.Replace("820-", "82" & r & "-")
            '    f = f.Replace("830-", "83" & r & "-")
            '    f = f.Replace("840-", "84" & r & "-")
            '    f = f.Replace("850-", "85" & r & "-")
            '    f = f.Replace("860-", "86" & r & "-")
            'End If

            'Return f
        End Function


        'most of the unit coolers in the database don't have a refrigerant indicator in the model, but some do
        Private Function format_defrost_portion_of_model(ByVal model As String) As String

            Return model.Replace("-HG", "").Replace("-A", "").Replace("-E", "")

            'Dim f = model 'formatted model

            'If model.StartsWith("A") Then
            '    If model.EndsWith("HG") Then
            '        f = model.Remove(model.Length - 2, 2) 'remove HG
            '    ElseIf model.EndsWith("E") Then
            '        f = model.Remove(model.Length - 1, 1) 'remove E
            '    ElseIf model.EndsWith("A") Then
            '        'f = model.Insert(model.Length - 1, "-") 'insert dash before A
            '        f = model.Remove(model.Length - 1, 1) 'insert dash before A
            '    End If
            'ElseIf model.EndsWith("HG") Then
            '    f = model.Remove(model.Length - 2, 2) 'remove HG
            'ElseIf model.EndsWith("A") OrElse model.EndsWith("E") OrElse model.EndsWith("G") Then
            '    f = model.Remove(model.Length - 1, 1) 'remove defrost type indicator
            'End If

            'Return f
        End Function


        Private Function select_refrigerant_indicator(ByVal refrigerant As String) As String
            Dim formatted_refrigerant As String = "2"
            If String.IsNullOrEmpty(refrigerant) Then
                formatted_refrigerant = "0"
            Else
                If refrigerant.ToUpper Like "*22*" Then formatted_refrigerant = "2"
                If refrigerant.ToUpper Like "*404A*" Then formatted_refrigerant = "4"
                If refrigerant.ToUpper Like "*507*" Then formatted_refrigerant = "7"
                If refrigerant.ToUpper Like "*507C*" Then formatted_refrigerant = "7"
                If refrigerant.ToUpper Like "*407A*" Then formatted_refrigerant = "7A"
                If refrigerant.ToUpper Like "*407C*" Then formatted_refrigerant = "7C"
                If refrigerant.ToUpper Like "*407F*" Then formatted_refrigerant = "7F"
                If refrigerant.ToUpper Like "*448A*" Then formatted_refrigerant = "8A"
                If refrigerant.ToUpper Like "*449A*" Then formatted_refrigerant = "9A"
            End If


            Return formatted_refrigerant
        End Function

    End Class

End Namespace