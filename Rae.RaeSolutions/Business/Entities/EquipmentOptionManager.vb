Imports Rae.Data.Access
Imports Rae.RaeSolutions.DataAccess.Common
Imports from_users_project = Rae.RaeSolutions.DataAccess.Projects.EquipmentOptionsDa

Namespace Rae.RaeSolutions.Business.Entities

    '[unit, from_users_project, from_legacy_pricing, from_current_pricing]
    'user_project     has pricingId,quantity
    'current_pricing  has code,description,price,per
    'legacy_pricing   has old pricing version to retrieve deleted options before the obsolete column was created

    ''' <summary>Handles retrieving available equipment options and identifying any options that are no longer available</summary>
    Public Class GetAvailableOptionsCommand

        Private unit As EquipmentItem
        Private from_legacy_pricing As LegacyPricing

        Sub New(ByVal unit As EquipmentItem)
            Me.unit = unit
            from_legacy_pricing = create_legacy_pricing()
        End Sub

        Sub Execute()
            'from.current_pricing.get_options_saved_for(unit).in(user_project)
            Dim selected_options = from_users_project.Get_options_selected_for(unit)
            unit.options.AddRange(selected_options)

            'get_options_from_user_project_that_are_marked_obsolete_in_current_pricing '_for_this(unit)
            Dim obsolete_options = from_users_project.get_options_marked_obsolete_for(unit)
            unit.obsolete_options.AddRange(obsolete_options)

            'if_options_from(users_project).are_missing_in(current_pricing).for_this(unit).search_for_missing_data_in(legacy_pricing)

            Dim hasMissingOptions As Boolean = False

                Dim missing_options = from_users_project.Get_options_missing_from(unit)
                If Not missing_options Is Nothing AndAlso missing_options.Count > 0 Then

                    For Each missing_option In missing_options
                        Dim legacy_option = from_legacy_pricing.Find(missing_option)

                    Dim replacement_option = from_users_project.Get_replacement_for(legacy_option, unit)

                    If replacement_option Is Nothing AndAlso legacy_option Is Nothing Then
                        hasMissingOptions = True
                    ElseIf replacement_option Is Nothing Then
                        unit.obsolete_options.Add(legacy_option)
                    Else
                        unit.options.Add(replacement_option)
                    End If
                Next

                End If


 
            If hasMissingOptions Then
                MsgBox("Sone option codes could not be loaded.  Please verify all selected options before proceeding.")
            End If

        End Sub

        Private Function create_legacy_pricing() As LegacyPricing
            Dim connString = GetMicrosoftAccessConnectionString(LegacyPricingDbPath)
            Dim connFactory = New ConnectionFactory(connString)
            Return New LegacyPricing(connFactory)
        End Function

    End Class

End Namespace