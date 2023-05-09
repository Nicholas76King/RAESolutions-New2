Imports System.Environment

Namespace ExceptionHandling

   ''' Project	 : RAESolutions
   ''' Class	 : RAESolutions.ExceptionHandling.GlobalExceptionHandler
   ''' 
   ''' <summary>Contains method to handle unhandled global exceptions
   ''' </summary>
   ''' <remarks>Allows user to choose whether or not to continue the application
   ''' </remarks>
   ''' <history>[CASEYJ]	6/8/2005	Created
   ''' </history>
   Public Class GlobalExceptionHandler

      ''' <summary>Handles global exception
      ''' </summary>
      ''' <param name="source">Source of the exception
      ''' </param>
      ''' <param name="e">Contains exception
      ''' </param>
      ''' <remarks>Displays message box describing error, and allows user to choose
      ''' to continue or exit application.
      ''' </remarks>
      ''' <history>[CASEYJ]	6/8/2005	Created
      ''' </history>
      Friend Sub HandleGlobalException( _
      ByVal source As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
         Dim message As System.Text.StringBuilder
         Dim result As DialogResult

         message = New System.Text.StringBuilder
         result = New DialogResult

         With message
            ' builds message
            .AppendFormat("An unexpected exception occurred.{0}", NewLine)
            .AppendFormat("Type: {0}{1}", e.Exception.GetType().ToString, NewLine)
            .AppendFormat("Message: {0}{1}", e.Exception.Message, NewLine)
            .AppendFormat("Application: {0}{1}", e.Exception.Source, NewLine)
            .AppendFormat("Form: {0}{1}", e.Exception.TargetSite.DeclaringType.FullName, NewLine)
            .AppendFormat("Method: {0}{1}", e.Exception.TargetSite.Name, NewLine)
            .AppendFormat("Stack: {0}{1}{1}", e.Exception.StackTrace, NewLine)
            .Append("The program may not perform as expected. Do you want to continue?")
         End With

         ' shows message box
         result = MessageBox.Show(message.ToString, "RAESolutions", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Error)

         If result = DialogResult.No Then
            'closes application
            Application.Exit()
         End If
      End Sub

   End Class

End Namespace
