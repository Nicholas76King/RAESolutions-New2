Imports System.Collections.Generic

Namespace Persistence

''' <summary>
''' Provides customizable form to present saving options.
''' </summary>
''' <remarks>
''' Basic Format:
''' Instructions: Do you want to save?
''' Inputs:       Project Name [______]
'''               Item Name    [______]
''' Commands:     [  Save  ]
'''               [ Cancel ]
''' Validates inputs as not null or empty.
''' Has custom handling for Cancel button.
''' </remarks>
Public Class AskUserToSave
   Inherits SaveForm
   Implements IAskUserToSave

#Region " External"

   Sub New(instructions As String, inputNames As String(), commands As IDictionary(Of String, String))
      MyBase.New()
      _instructions = instructions
      _inputNames = inputNames
      _commands = commands
   End Sub


   Property Instructions As String _
   Implements IAskUserToSave.Instructions
      Get
         Return _instructions
      End Get
      Set(value As String)
         _instructions = value
      End Set
   End Property

   Property Commands As IDictionary(Of String, String) _
   Implements IAskUserToSave.Commands
      Get
         Return _commands
      End Get
      Set(value As IDictionary(Of String, String))
         _commands = value
      End Set
   End Property

   Property InputNames As String() _
   Implements IAskUserToSave.InputNames
      Get
         Return _inputNames
      End Get
      Set(value As String())
         _inputNames = value
      End Set
   End Property
      
   
   Function Ask() As SaveResponse _
   Implements IAskUserToSave.Ask
      addControls()
      
      Me.Height = calculateHeightToFitControlsInForm()
      
      ShowDialog()

      Return response
   End Function
   
#End Region

#Region " Internal"

   Private totalControlHeight As Integer
   Protected response As SaveResponse
   Protected _commands As IDictionary(Of String, String)
   Protected _instructions As String
   Protected _inputNames As String()
   
   Private Sub addControls()
      addInstructions(Instructions)
      addSpace(10)
      For Each inputName As String In InputNames
         addInput(inputName)
      Next
      addSpace(20)
      For Each command As KeyValuePair(Of String, String) In Commands
         addCommand(command.Key, command.Value)
      Next
   End Sub
   
   Private Function calculateHeightToFitControlsInForm() As Integer
      Dim height As Integer
      
      ' padding between controls and form border
      Dim padding As Integer = Me.Padding.Top + Me.Padding.Bottom
      ' nonClient height contains title bar, border, etc.
      Dim nonClient As Integer = Me.Height - Me.ClientSize.Height
      
      height = sumHeightOfControls() + padding + nonClient
      
      Return height
   End Function
   
   Private Function sumHeightOfControls() As Integer
      Dim totalHeight As Integer
      
      For Each control As Control In Me.Controls
         totalHeight += control.Height 
      Next
      
      Return totalHeight
   End Function

   Private Sub addSpace(height As Integer)
      Dim label As New Label()
      label.Height = height
      label.Dock = DockStyle.Top
      
      addControl(label)
   End Sub


   Private Sub addInstructions(instructions As String)
      Dim label As New Label()
      With label
         .Dock = DockStyle.Top
         .Height = 42
         .Text = instructions
         .TextAlign = ContentAlignment.MiddleLeft
      End With
      
      addControl(label)
   End Sub


   Private Sub addInput(inputName As String)
      Dim label As New Label()
      label.Dock = DockStyle.Top
      label.Height = 24
      label.Text = inputName

      Dim textBox As New TextBox()
      textBox.Height = 24
      textBox.Dock = DockStyle.Top
      textBox.Tag = inputName

      addControl(label)
      addControl(textBox)
   End Sub


   Private Sub addCommand(name As String, description As String)
      Dim button As New Button()
      button.Height = 55
      button.Text = name
      button.Dock = DockStyle.Top
      If name = "Cancel" OrElse name = "Don't Save" Then
         AddHandler button.Click, AddressOf cancel_Click
      Else
         AddHandler button.Click, AddressOf command_Click
      End If
      addControl(button)
   End Sub

   
   Private Sub addControl(control As Control)
      Me.Controls.Add(control)
      'note: bringing to front so tab goes top to bottom not bottom to top
      control.BringToFront()
      totalControlHeight += control.Height
   End Sub
   
   
   Private Sub command_Click(sender As Object, e As EventArgs)
      Dim button As Button = CType(sender, Button)
      Dim inputs As New StringDictionary()
      
      For Each control As Control In Me.Controls
         If TypeOf control Is TextBox Then
            inputs.Add(control.Tag, control.Text.Trim)
            If Not validate(inputs) Then
               Exit Sub ' without closing so user can make valid
            End If
         End If
      Next
      
      response = New SaveResponse(inputs, button.Text)
      Close()
   End Sub
   
   Private Sub cancel_Click(sender As Object, e As EventArgs)
      response = New SaveResponse(New StringDictionary(), sender.Text)
      Close()
   End Sub
   
   Private Function validate(inputs As Dictionary(Of String, String)) As Boolean
      Dim isValid As Boolean = True
      
      For Each input As KeyValuePair(Of String, String) In inputs
         If String.IsNullOrEmpty(input.Value) Then
            isValid = False
            Ui.MessageBox.Show(input.Key & " cannot be empty.", MessageBoxIcon.Warning)
            Exit For
         End If
      Next
      
      Return isValid
   End Function

#End Region

End Class

End Namespace
