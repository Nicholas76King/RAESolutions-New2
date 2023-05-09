Imports Rae.reporting.beta

Class accessories_base
    Protected report As report
    Protected text As Dictionary(Of String, String)

    Protected Sub New()
    End Sub

    Sub New(ByVal screen As EquipmentForm, ByVal report_file_path As String)
        report = New report(report_file_path)
        text = New Dictionary(Of String, String)

        Dim project_bag = New project_grabber(screen).grab
        text.Add("project", project_bag.project_name)
        text.Add("representative", project_bag.rep_company)
        text.Add("release_status", project_bag.release_status)
        text.Add("projectName", project_bag.release_status)
        text.Add("release_number", project_bag.release_number)


        Dim equipment_bag = New equipment_grabber(screen).grab
        text.Add("job", equipment_bag.job)
        text.Add("quantity", equipment_bag.quantity)
        text.Add("tag", equipment_bag.tag)


        Select Case My.Settings.Division
            Case "CRI"
                text.Add("Division", "Century Refrigeration")
            Case "TSI"
                text.Add("Division", "Technical Systems")
            Case Else
                text.Add("Division", My.Settings.Division)

        End Select



        Dim model As String
        If equipment_bag.custom_model.is_not_set Then
            model = equipment_bag.model
        Else
            model = equipment_bag.custom_model & " (" & equipment_bag.model.Remove(0, 1) & ")"
        End If
        text.Add("model", model)
        text.Add("application_version", My.Application.Info.Version.ToString)
        text.Add("created", DateTime.Now.ToString("MM/dd/yyyy"))

        ' set options list
        screen.populateSelectedOptionsDataSet(False)
        Dim options = New List(Of String)
        For Each op In screen.selectedOpsDs.SelectedOptions
            options.Add("• " & op.Description.Replace("Warranty (Net)", "Warranty"))  ' for Brookei
        Next
        report.set_list("options", options)
    End Sub

    Sub show(ByVal generateOnly As Boolean, ByRef fileName As String, Optional ByVal showReport As Boolean = False)
        Try
            report.set_text(text)
            'If generateOnly Then
            '    fileName = report.generate
            'Else
            '    report.show()
            'End If


            If generateOnly Then
                If MainForm.openReport = False Then
                    If showReport Then
                        If MainForm.currentLogo <> "" Then
                            report.close()
                            Dim p As Process = New Process()
                            Dim psi As ProcessStartInfo = New ProcessStartInfo()
                            psi.CreateNoWindow = True
                            psi.Verb = "print"
                            psi.FileName = report.report_file_path
                            p.StartInfo = psi
                            p.Start()
                        Else
                            report.show()
                        End If
                    Else
                        fileName = report.generate
                    End If
                Else
                    Exit Sub
                End If
            Else
                report.show()
            End If

        Catch ex As System.ComponentModel.Win32Exception
            Rae.Ui.warn(ex.Message)
        End Try
    End Sub
End Class
