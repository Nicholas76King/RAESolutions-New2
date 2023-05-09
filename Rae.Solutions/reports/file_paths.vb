Option Strict On
Option Explicit On

Namespace reports

    ''' <summary>File paths of reports.</summary>
    Class file_paths

        Public Shared ReadOnly report_folder_path As String = AppInfo.AppFolderPath & "Reports\"

        ' selection and rating reports
        '
        Public Shared ReadOnly condenser_rating_report_file_path As String = report_folder_path & "condenser_rating_template.docx"




        Public Shared ReadOnly CenturyProposalFrontDocsPath As String = report_folder_path & "Proposal\CenturyProposalFrontDocs.docx"
        Public Shared ReadOnly CenturyProposalUnitCoolerSheetPath As String = report_folder_path & "Proposal\CenturyProposalUnitCoolerSheet.docx"
        Public Shared ReadOnly CenturyProposalProductCoolerSheetPath As String = report_folder_path & "Proposal\CenturyProposalProductCoolerSheet.docx"
        Public Shared ReadOnly CenturyProposalCondenserSheetPath As String = report_folder_path & "Proposal\CenturyProposalCondenserSheet.docx"
        Public Shared ReadOnly CenturyProposalCondensingUnitSheetPath As String = report_folder_path & "Proposal\CenturyProposalCondensingUnitSheet.docx"
        Public Shared ReadOnly CenturyProposalEndDocsPath As String = report_folder_path & "Proposal\CenturyProposalEndDocs.docx"


        ' chiller



        Public Shared ReadOnly air_cooled_chiller_balance_template_file_path As String = report_folder_path & "air_cooled_chiller_balance_template.docx"
        'Public Shared ReadOnly AirCooledChillerRatingReportFilePath As String = report_folder_path & "AirCooledChillerRatingReport.rpt"





        Public Shared ReadOnly EvaporativeCooledChillerRatingReportFilePath As String = report_folder_path & "EvaporativeCondenserChillerBalanceReport.rpt"


        Public Shared ReadOnly evaporative_condenser_chiller_proposal_file_path As String = report_folder_path & "evaporative_condenser_chiller_proposal_report.rpt"
        Public Shared ReadOnly EvaporativeCondenserChillerProposalFilePath As String = report_folder_path & "evaporativecondenserchillerproposal.docx"

        Public Shared ReadOnly CondensingUnitProposalFilePath As String = report_folder_path & "condensingUnitproposal.docx"



        Public Shared ReadOnly evaporative_condenser_chiller_plv_file_path As String = report_folder_path & "evaporative_condenser_chiller_plv_template.docx"
        Public Shared ReadOnly evaporative_condenser_chiller_balance_file_path As String = report_folder_path & "evaporative_condenser_chiller_balance_template.docx"

        ' air handler
        Public Shared ReadOnly AirHandlerUnitReportFilePath As String = report_folder_path & "AirHandlerUnitReport.rpt"
        Public Shared ReadOnly AirHandlerUnitReportWordFilePath As String = report_folder_path & "AirHandlerUnitReport.docx"





        Public Shared ReadOnly AirHandlerProjectReportFilePath As String = report_folder_path & "AirHandlerProjectReport.rpt"
        ' others
        Public Shared ReadOnly condensing_unit_rating_file_path As String = report_folder_path & "condensing_unit_rating_template.docx"
        Public Shared ReadOnly cu_uc_balance_template_file_path As String = report_folder_path & "cu_uc_balance_template.docx"
        Public Shared ReadOnly FluidCoolerRatingReportFilePath As String = report_folder_path & "FluidCoolerRatingReport.rpt"
        Public Shared ReadOnly box_load_template_file_path As String = report_folder_path & "box_load_template.docx"
        ' order write-up reports
        '
        Public Shared ReadOnly chiller_order_write_up_report_file_path As String = report_folder_path & "chiller_order_write_up_report.rpt"

        Public Shared ReadOnly unit_cooler_order_write_up_file_path As String = report_folder_path & "unit_cooler_order_write_up_template.docx"
        Public Shared ReadOnly product_cooler_order_write_up_file_path As String = report_folder_path & "product_cooler_order_write_up_template.docx"
        Public Shared ReadOnly fluid_cooler_order_write_up_file_path As String = report_folder_path & "fluid_cooler_order_write_up_template.docx"
        Public Shared ReadOnly condensing_unit_order_write_up_file_path As String = report_folder_path & "condensing_unit_order_write_up_template.docx"
        Public Shared ReadOnly condenser_order_write_up_file_path As String = report_folder_path & "condenser_order_write_up_template.docx"
        Public Shared ReadOnly pump_order_write_up_file_path As String = report_folder_path & "pump_order_write_up_template.docx"
        Public Shared ReadOnly chiller_order_write_up_file_path As String = report_folder_path & "chiller_order_write_up_template.docx"

        ' submittal (accessories) reports
        Public Shared ReadOnly unit_cooler_accessories_file_path As String = report_folder_path & "unit_cooler_accessories_template.docx"
        Public Shared ReadOnly condenser_accessories_file_path As String = report_folder_path & "condenser_accessories_template.docx"
        Public Shared ReadOnly condensing_unit_accessories_file_path As String = report_folder_path & "condensing_unit_accessories_template.docx"
        Public Shared ReadOnly product_cooler_accessories_file_path As String = report_folder_path & "product_cooler_accessories_template.docx"
        Public Shared ReadOnly fluid_cooler_accessories_file_path As String = report_folder_path & "fluid_cooler_accessories_template.docx"
        Public Shared ReadOnly chiller_accessories_file_path As String = report_folder_path & "chiller_accessories_template.docx"
        Public Shared ReadOnly pump_accessories_file_path As String = report_folder_path & "pump_accessories_template.docx"

        Public Shared ReadOnly cover_letter_file_path As String = report_folder_path & "cover_letter_template.docx"
        Public Shared ReadOnly cover_page_file_path As String = report_folder_path & "cover_page_template.docx"

        Public Shared ReadOnly compressor_warranty_file_path As String = report_folder_path & "compressor_warranty.docx"


        Public Shared ReadOnly PROJECT_SUMMARY_PATH As String = report_folder_path & "ProjectSheetTemplate.xlsx"


    End Class

End Namespace