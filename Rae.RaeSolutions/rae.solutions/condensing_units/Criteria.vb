imports rae.solutions

Namespace rae.solutions.condensing_units

    Public Structure Criteria
        Public suction_temp As Double
        Public division As rae.raesolutions.business.division
        Public series, compressor_type As String
        Public compressor_qty_description As String
        Public refrigerant As refrigerant
        Public DOEModels As String
    End Structure

End Namespace