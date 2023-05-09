Imports System
Imports System.Collections.Generic

Namespace Rae.RaeSolutions.Business.Entities

''' <summary>
''' List of equipment options.
''' </summary>
''' <history by="Casey Joyce" finish="2006/05/04" hours="0.5">
''' Created
''' </history>
Public Class EquipmentOptionList
   Inherits List(Of EquipmentOption)
   Implements IEquatable(Of EquipmentOptionList)
   Implements ICloneable(Of EquipmentOptionList)


   Private _equipment As EquipmentItem
   ''' <summary>
   ''' Equipment
   ''' </summary>
   Property Equipment As EquipmentItem
      Get
         Return Me._equipment
      End Get
      Set(value As EquipmentItem)
         Me._equipment = value
      End Set
   End Property


#Region " Methods"

   ''' <summary>
   ''' Constructs option list for equipment.
   ''' </summary>
   ''' <param name="equipment">
   ''' Equipment that options are selected for.
   ''' </param>
   Sub New(equipment As EquipmentItem)
      Me._equipment = equipment
   End Sub


   ''' <summary>
   ''' Adds option to list and sets its Equipment property.
   ''' </summary>
   ''' <param name="op">
   ''' Option to add.
   ''' </param>
   Shadows Sub Add(op As EquipmentOption)
      op.Equipment = Me.Equipment
      MyBase.Add(op)
   End Sub


   ''' <summary>
   ''' Determines whether option lists are equal.
   ''' </summary>
   ''' <param name="other">
   ''' Other option list to compare.
   ''' </param>
   ''' <returns>
   ''' True if lists are equal, else false.
   ''' </returns>
   Overloads Function Equals(other As EquipmentOptionList) As Boolean _
   Implements IEquatable(Of EquipmentOptionList).Equals
      ' checks if option lists contain the same number of comments
      If Me.Count = other.Count Then
        ' checks if options in list are equals
        '
        For i As Integer = 0 To Me.Count - 1
          If Not Me.Item(i).Equals(other.Item(i)) Then
            ' option lists are NOT equal (all options are not the same)
            Return False
          End If
        Next

        ' comment lists are equal
        Return True
      Else
        ' comment list are NOT equal (different number of comments)
        Return False
      End If
   End Function


   ''' <summary>
   ''' Clones equipment option list.
   ''' </summary>
   Function Clone() As EquipmentOptionList _
   Implements ICloneable(Of EquipmentOptionList).Clone
      Dim ops As New EquipmentOptionList(Me.Equipment)

      For Each op As EquipmentOption In Me
        ops.Add(op.Clone)
      Next

      Return ops
   End Function
   
   
   ''' <summary>
   ''' Returns true if option list contains an option with the specified option code
   ''' </summary>
   ''' <param name="optionCode">Option code to find in list</param>
   Overloads Function Contains(optionCode As String) As Boolean
      For Each op In Me
         If op.Code = optionCode Then _
            Return True
      Next
      Return False
   End Function

#End Region

End Class

End Namespace