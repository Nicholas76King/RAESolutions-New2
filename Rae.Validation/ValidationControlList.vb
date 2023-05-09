Namespace Rae.Validation

   Public Class ValidationControlList
      Inherits System.Collections.ArrayList


#Region " Events"
      Public Event ValidationControlAdded(ByVal validationControl As Validation.ValidationControl)
#End Region


#Region " Public methods"

      ''' <summary>Adds a validation control to the list
      ''' </summary>
      ''' <param name="text">Validation control to be added to list
      ''' </param>
      ''' <returns>Index that the validation control was added to
      ''' </returns>
      ''' <history>[Casey.Joyce]	6/5/2005	Created
      ''' </history>
      Public Shadows Function Add( _
      ByVal validationControl As Validation.ValidationControl) As Integer
         Dim index As Integer = MyBase.Add(validationControl)
         RaiseEvent ValidationControlAdded(validationControl)
         Return index
      End Function

      ''' <summary>Removes validation control from the list
      ''' </summary>
      ''' <param name="validationControl">Validation control to be removed from 
      ''' the list
      ''' </param>
      ''' <history>[Casey.Joyce]	6/5/2005	Created
      ''' </history>
      Public Shadows Sub Remove( _
      ByVal validationControl As Validation.ValidationControl)
         MyBase.Remove(validationControl)
      End Sub

      ''' <summary>Gets the index of the validation control parameter
      ''' </summary>
      ''' <param name="validationControl">Validation control to get index for
      ''' </param>
      ''' <returns>Index of the validation control parameter
      ''' </returns>
      ''' <remarks>If the validation control is not found, -1 is returned.
      ''' </remarks>
      ''' <history>[Casey.Joyce]	6/5/2005	Created
      ''' </history>
      Public Shadows Function IndexOf(ByVal validationControl As String) As Integer
         Return MyBase.IndexOf(validationControl)
      End Function

      ''' <summary>Gets the validation control at the index parameter
      ''' </summary>
      ''' <param name="validationControl">Index of the validation control to be 
      ''' returned
      ''' </param>
      ''' <returns>Validation control at the index parameter
      ''' </returns>
      ''' <history>[Casey.Joyce]	6/5/2005	Created
      ''' </history>
      Public Shadows Function Item(ByVal index As Integer) _
      As Validation.ValidationControl
         Return DirectCast(MyBase.Item(index), Validation.ValidationControl)
      End Function

#End Region

   End Class
End Namespace