Option Strict On
Option Explicit On 

Imports Forms = System.Windows.Forms


Public Class ControlAssistant

   Public Shared Function SelectComboboxItem( _
   ByRef combobox As Forms.ComboBox, ByVal stringToSelect As Object, Optional ByVal defaultIndex As Integer = 0) As Integer
      ' ensures value is not DBNull or Nothing
      stringToSelect = ConvertNull.ToString(stringToSelect)

      ' checks that combobox contains at least one item
      If combobox.Items.Count > 0 Then
         ' checks if combobox contains string parameter
         If combobox.Items.Contains(stringToSelect) Then
            ' selects index containing matching value
            combobox.SelectedIndex = combobox.Items.IndexOf(stringToSelect)
         Else
            ' selects default index parameter
            combobox.SelectedIndex = defaultIndex
            Console.WriteLine("The attempt to select an item in combobox, {0}, failed. ", combobox.Name)
            Console.WriteLine("The combobox does not contain this item, {0}. ", stringToSelect)
            Console.WriteLine("The first selection was selected instead.")
         End If
      Else
         Console.WriteLine("The attempt to select an item in combobox, {0}, failed. ", combobox.Name)
         Console.WriteLine("The combobox is empty.")
      End If

      Return combobox.SelectedIndex
   End Function


   Public Shared Function GetIndexOfComboboxItem(ByVal combobox As Forms.ComboBox, ByVal itemToSelect As Object) As Integer
      Dim indexOfItem As Integer = -1

      ' checks that combobox contains at least one item
      If combobox.Items.Count > 0 Then
         ' checks if combobox contains item
         If combobox.Items.Contains(itemToSelect) Then
            ' gets index of item
            indexOfItem = combobox.Items.IndexOf(itemToSelect)
         End If
      End If

      Return indexOfItem
   End Function


   Public Shared Function GetIndexOfComboboxValue(ByVal combobox As Forms.ComboBox, ByVal valueToSelect As Object) As Integer
      For i As Integer = 0 To combobox.Items.Count - 1
         ' selects item, so selectedvalue property can be checked
         combobox.SelectedIndex = i
         ' checks if compressor is a match
         If combobox.SelectedValue.Equals(valueToSelect) Then
            Exit For
         ElseIf i = combobox.Items.Count - 1 Then
            ' selects first index if there is no match
            combobox.SelectedIndex = 0
            Console.WriteLine("Value, {0}, is not in combobox, {1}", valueToSelect.ToString, combobox.Name)
            Exit For
         End If
      Next

      Return combobox.SelectedIndex
   End Function


   Public Shared Function GetIndexOfValueInListBox(ByVal listBox As Forms.ListBox, ByVal selection As String) As Integer
      For i As Integer = 0 To listBox.Items.Count - 1
         ' selects item, so selectedvalue property can be checked
         listBox.SelectedIndex = i
         ' checks if compressor is a match
            If DirectCast(listBox.SelectedItem, rae.RaeSolutions.DataAccess.CompressorDescription).MasterID = selection Then
                Exit For
            ElseIf i = listBox.Items.Count - 1 Then
                ' selects first index if there is no match
                listBox.SelectedIndex = 0
                Console.WriteLine("Item is not in listbox")
                Exit For
            End If
      Next

      Return listBox.SelectedIndex
   End Function

End Class
