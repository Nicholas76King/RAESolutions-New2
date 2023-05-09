Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting


Namespace Business

   <TestClass()> Public Class NullableValueTest



      Private m_Name As NullableValue(Of Double)
      ''' <summary>
      ''' Name
      ''' </summary>
      Public Property Name() As NullableValue(Of Double)
         Get
            If Me.m_Name Is Nothing Then
               Me.m_Name = New NullableValue(Of Double)
            End If
            Return Me.m_Name
         End Get
         Set(ByVal value As NullableValue(Of Double))
            Me.m_Name = value
         End Set
      End Property



      ''' <summary>
      ''' Tests
      ''' </summary>
      <TestMethod()> _
      Public Sub TestClone()
         ' tests clone w/ null
         Dim a As New NullableValue(Of Integer)
         Dim b As NullableValue(Of Integer) = a.Clone()
         Assert.IsTrue(a.Equals(b))

         ' tests clone w/ same value
         a.Value = 2
         b = a.Clone()
         Assert.IsTrue(a.Equals(b))

         ' tests clone w/ different values
         a.Value = 3
         Assert.IsFalse(a.Equals(b))
      End Sub



      ''' <summary>
      ''' Don't need New constructor.
      ''' </summary>
      <TestMethod(), ExpectedException(GetType(NullReferenceException))> _
      Public Sub TestStructure()
         Dim a As NullableValue(Of Integer)
         a.Value = 1
      End Sub


      ''' <summary>
      ''' Is null before set. Value is value type's default.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestInitialState()
         Dim a As New NullableValue(Of Integer)
         Assert.IsFalse(a.HasValue)
         Assert.IsTrue(a.Default = 0)
         Assert.IsTrue(a.ValueOrDefault = 0)
      End Sub


      ''' <summary>
      ''' Does not have value when set to DBNull or Nothing.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestNull()
         Dim a As New NullableValue(Of Integer)
         a.Value = 3
         Assert.IsTrue(a.HasValue)
         a.SetValue(System.DBNull.Value)
         Assert.IsFalse(a.HasValue)
         a.Value = 2
         Assert.IsTrue(a.HasValue)
         a.SetValue(Nothing)
         Assert.IsFalse(a.HasValue)
      End Sub


      ''' <summary>
      ''' Default is returned when null when using ValueOrDefault
      ''' </summary>
      <TestMethod()> _
      Public Sub TestDefault()
         Dim a As New NullableValue(Of Integer)
         a.Default = 1
         Assert.IsTrue(a.ValueOrDefault = 1)
         Assert.IsTrue(a.ValueOrDefault(2) = 2)
      End Sub


      ''' <summary>
      ''' SetValue sets Value property.
      ''' </summary>
      ''' <remarks></remarks>
      <TestMethod()> _
      Public Sub TestSetValue()
         Dim a As New NullableValue(Of Integer)
         a.SetValue(3)
         Assert.IsTrue(a.Value = 3)
      End Sub


      ''' <summary>
      ''' Throws invalid operation exception during attempt to get Value while there is no value.
      ''' </summary>
      <TestMethod(), ExpectedException(GetType(InvalidOperationException))> _
      Public Sub TestSetValueException()
         Dim a As New NullableValue(Of Integer)
         a.SetValue(Nothing)
         Dim i As Integer = a.Value
      End Sub


      ''' <summary>
      ''' SetValue attempts to convert type to specified type T.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestSetValueConversions()
         Dim a As New NullableValue(Of Integer)
         a.SetValue(3)
         Assert.IsTrue(a.Value = 3)
         a.SetValue("4")
         Assert.IsTrue(a.Value = 4)
         a.SetValue(5.0!)
         Assert.IsTrue(a.Value = 5)
         a.SetValue(6.2)
         Assert.IsTrue(a.Value = 6)
         a.SetValue(6.5)
         Assert.IsTrue(a.Value = 6)
         a.SetValue(6.501)
         Assert.IsTrue(a.Value = 7)
      End Sub


      ''' <summary>
      ''' Tests ToString functions' return values when HasValue is False.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestToString()
         Dim a As New NullableValue(Of Integer)
         Assert.IsTrue(a.ToString = String.Empty)
         Assert.IsNull(a.ToStringOrNull)
      End Sub

      ''' <summary>
      ''' Tests setting value when NullableValue is a property.
      ''' Had to change to class from structure, b/c structure only passes value not reference.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestProperty()
         Me.Name.Value = 105
         Assert.IsTrue(Me.Name.Value = 105)

         Me.Name.SetValue(115)
         Assert.IsTrue(Me.Name.Value = 115)
      End Sub


      ''' <summary>
      ''' Tests constructor value parameter.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestConstructors()
         Dim a As New NullableValue(Of Integer)
         a.Value = 1
         Dim b As New NullableValue(Of Integer)(1)
         Assert.IsTrue(a.Value = b.Value)
      End Sub


      ''' <summary>
      ''' Test ResetToDefault method.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestResetToDefault()
         Dim a As New NullableValue(Of Integer)(3, 1)
         Assert.IsTrue(a.Value = 3)
         a.SetToDefault()
         Assert.IsTrue(a.Value = 1)
      End Sub


      ''' <summary>
      ''' Tests constructor default parameter.
      ''' </summary>
      <TestMethod()> _
      Public Sub TestConstructorDefaultParameter()
         Dim a As New NullableValue(Of Integer)(1, 3)
         a.SetToNull()
         Assert.IsTrue(a.ValueOrDefault = 3)
      End Sub


      ''' <summary>
      ''' Tests equals with a double value
      ''' </summary>
      <TestMethod()> _
      Public Sub TestEqualsWithDouble()
         Dim a As New NullableValue(Of Double)(3)
         Dim b As New NullableValue(Of Double)(3)

         ' tests are equal
         Assert.IsTrue(a.Equals(b))

         ' tests not equal numbers
         b.Value = 4
         Assert.IsFalse(a.Equals(b))

         ' test not equal w/ null value
         b.SetToNull()
         Assert.IsFalse(a.Equals(b))

         b = Nothing
         Assert.IsFalse(a.Equals(b))
      End Sub


   End Class

End Namespace