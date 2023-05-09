Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting


Namespace Business

<TestClass> Public Class nullable_value_

   Private m_Name As nullable_value(Of Double)
   Property Name As nullable_value(Of Double)
      Get
         If Me.m_Name Is Nothing Then
            Me.m_Name = New nullable_value(Of Double)
         End If
         Return Me.m_Name
      End Get
      Set(ByVal value As nullable_value(Of Double))
         Me.m_Name = value
      End Set
   End Property



   <TestMethod> _
   Sub clone_number
      ' tests clone w/ null
      Dim a As New nullable_value(Of Integer)
      Dim b As nullable_value(Of Integer) = a.clone()
      Assert.IsTrue(a.equals(b))

      ' tests clone w/ same value
      a.value = 2
      b = a.clone()
      Assert.IsTrue(a.equals(b))

      ' tests clone w/ different values
      a.value = 3
      Assert.IsFalse(a.equals(b))
   End Sub

   <TestMethod>
   sub reflector_can_clone
      dim x = new nullable_value(of double)(22)
      dim y = rae.reflection.reflector.clone(x)

      assert.isTrue(x.equals(y))
      assert.isTrue(x.value = 22)

      assert.isTrue(x.has_value)
      assert.isTrue(y.has_value)

      y.set_to(1)
      assert.isFalse(x.equals(y))
   end sub

   <TestMethod, ExpectedException(GetType(NullReferenceException))> _
   Sub must_be_constructed
      Dim a As nullable_value(Of Integer)
      a.value = 1
   End Sub


   ''' <summary>
   ''' Is null before set. Value is value type's default.
   ''' </summary>
   <TestMethod()> _
   Sub TestInitialState()
      Dim a As New nullable_value(Of Integer)
      Assert.IsFalse(a.has_value)
      Assert.IsTrue(a.[default] = 0)
      Assert.IsTrue(a.value_or_default = 0)
   End Sub


   ''' <summary>
   ''' Does not have value when set to DBNull or Nothing.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestNull()
      Dim a As New nullable_value(Of Integer)
      a.value = 3
      Assert.IsTrue(a.has_value)
      a.set_to(System.DBNull.Value)
      Assert.IsFalse(a.has_value)
      a.value = 2
      Assert.IsTrue(a.has_value)
      a.set_to(Nothing)
      Assert.IsFalse(a.has_value)
   End Sub


   ''' <summary>
   ''' Default is returned when null when using ValueOrDefault
   ''' </summary>
   <TestMethod()> _
   Public Sub TestDefault()
      Dim a As New nullable_value(Of Integer)
      a.[default] = 1
      Assert.IsTrue(a.value_or_default = 1)
      Assert.IsTrue(a.value_or_default(2) = 2)
   End Sub


   <TestMethod>
   sub set_value
      dim a = new nullable_value(of integer)
      a.set_to(3)
      Assert.IsTrue(a.value = 3)
   end sub

   <TestMethod>
   sub has_value_after_setting_value
      dim a = new nullable_value(of double)(1)
      assert.isTrue(a.has_value)

      dim b = new nullable_value(of double)(1)
      assert.isTrue(b.has_value)

      dim c = new nullable_double(1)
      assert.isTrue(c.has_value)

      dim d = new nullable_double(1)
      assert.isTrue(d.has_value)
   end sub

   <TestMethod>
   sub cloned_nullable_double_has_value
      dim a = new nullable_double(1)
      assert.isTrue(a.has_value)
   end sub


   ''' <summary>
   ''' Throws invalid operation exception during attempt to get Value while there is no value.
   ''' </summary>
   <TestMethod(), ExpectedException(GetType(InvalidOperationException))> _
   Public Sub TestSetValueException()
      Dim a As New nullable_value(Of Integer)
      a.set_to(Nothing)
      Dim i As Integer = a.value
   End Sub


   ''' <summary>
   ''' SetValue attempts to convert type to specified type T.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestSetValueConversions()
      Dim a As New nullable_value(Of Integer)
      a.set_to(3)
      Assert.IsTrue(a.value = 3)
      a.set_to("4")
      Assert.IsTrue(a.value = 4)
      a.set_to(5.0!)
      Assert.IsTrue(a.value = 5)
      a.set_to(6.2)
      Assert.IsTrue(a.value = 6)
      a.set_to(6.5)
      Assert.IsTrue(a.value = 6)
      a.set_to(6.501)
      Assert.IsTrue(a.value = 7)
   End Sub


   ''' <summary>
   ''' Tests ToString functions' return values when HasValue is False.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestToString()
      Dim a As New nullable_value(Of Integer)
      Assert.IsTrue(a.ToString = String.Empty)
      Assert.IsNull(a.to_string_or_null)
   End Sub

   ''' <summary>
   ''' Tests setting value when NullableValue is a property.
   ''' Had to change to class from structure, b/c structure only passes value not reference.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestProperty()
      Me.Name.value = 105
      Assert.IsTrue(Me.Name.value = 105)

      Me.Name.set_to(115)
      Assert.IsTrue(Me.Name.value = 115)
   End Sub


   ''' <summary>
   ''' Tests constructor value parameter.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestConstructors()
      Dim a As New nullable_value(Of Integer)
      a.value = 1
      Dim b As New nullable_value(Of Integer)(1)
      Assert.IsTrue(a.value = b.value)
   End Sub


   ''' <summary>
   ''' Test ResetToDefault method.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestResetToDefault()
      Dim a As New nullable_value(Of Integer)(3, 1)
      Assert.IsTrue(a.value = 3)
      a.set_to_default()
      Assert.IsTrue(a.value = 1)
   End Sub


   ''' <summary>
   ''' Tests constructor default parameter.
   ''' </summary>
   <TestMethod()> _
   Public Sub TestConstructorDefaultParameter()
      Dim a As New nullable_value(Of Integer)(1, 3)
      a.set_to_null()
      Assert.IsTrue(a.value_or_default = 3)
   End Sub


   ''' <summary>
   ''' Tests equals with a double value
   ''' </summary>
   <TestMethod()> _
   Public Sub TestEqualsWithDouble()
      Dim a As New nullable_value(Of Double)(3)
      Dim b As New nullable_value(Of Double)(3)

      ' tests are equal
      Assert.IsTrue(a.equals(b))

      ' tests not equal numbers
      b.value = 4
      Assert.IsFalse(a.equals(b))

      ' test not equal w/ null value
      b.set_to_null()
      Assert.IsFalse(a.equals(b))

      b = Nothing
      Assert.IsFalse(a.equals(b))
   End Sub


End Class

End Namespace