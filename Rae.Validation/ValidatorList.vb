Namespace Rae.Validation

   Public Class ValidatorList
      Inherits System.Collections.ArrayList

#Region " Events"
      Event ValidatorAdded(ByVal validator As RAE.Validation.Validator)
#End Region


#Region " Public methods"

      Public Shadows Function Add(ByVal validator As Validation.Validator) _
      As Integer
         MyBase.Add(validator)
         RaiseEvent ValidatorAdded(validator)
      End Function

      Public Shadows Function Item(ByVal index As Integer) As Validation.Validator
         Return DirectCast(MyBase.Item(index), Validation.Validator)
      End Function


      Public Shadows Sub Remove(ByVal validator As Validation.Validator)
         MyBase.Remove(validator)
      End Sub


      Public Shadows Function IndexOf(ByVal validator As Validation.Validator) _
      As Integer
         Return MyBase.IndexOf(validator)
      End Function

      Public Shadows Function Contains(ByVal validator As Validation.Validator) _
      As Boolean
         Return MyBase.Contains(validator)
      End Function

#End Region

   End Class
End Namespace
