namespace rae.solutions.condensing_units

    Public Interface I_Repository

        Function get_models(ByVal series As String, ByVal refrigerant As String, DOEFlag As String) As List(Of String)
        Function get_unit(ByVal model As String) As Condensing_Unit
        Function get_units(ByVal criteria As Criteria) As List(Of Condensing_Unit)
        Function get_units_where_model_starts_with(ByVal start_of_model As String) As List(Of Condensing_Unit)
    End Interface

end namespace