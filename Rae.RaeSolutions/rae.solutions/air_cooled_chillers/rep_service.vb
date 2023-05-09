Imports rae.solutions.compressors
Imports Rae.RaeSolutions.DataAccess.Chillers

namespace rae.solutions.air_cooled_chillers

public class rep_service : inherits service

        Sub New(ByVal compressor_repository As i_compressor_repository, ByVal chiller_repository As i_repository, ByVal user1 As user)
            MyBase.new(compressor_repository, chiller_repository, user1)
        End Sub
   
        Overloads Function get_compressors(ByVal refrigerant As refrigerant, ByVal voltage As Integer, ByVal compressor_model As String, ByVal model_type As String) As List(Of compressor)
            '    Dim c = compressor_repository.get_compressor(compressor_model, refrigerant, voltage, model_type)
            '    Return compressor_repository.get_rep_air_cooled_chiller_compressors(refrigerant, voltage, standard_hp:=c.hp)
            MsgBox("Add THis method!")

        End Function

        Overloads Function get_models(ByVal series As String) As IList(Of String)
            Dim models = chiller_repository.get_models(series)

            models.Sort(New Comparison(Of String)(AddressOf sort_chiller_models))

            models.Insert(0, "Choose")

            Return models
        End Function
    End Class

end namespace