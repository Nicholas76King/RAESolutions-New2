Option Strict On
Option Explicit On 

Imports System.Collections.Generic
Imports DA1 = RAE.RAESolutions.DataAccess.EquipmentOptionsAgent.DependentCommonOptionsDa


Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Provides data access for dependent common options
   ''' </summary>
   Public Class RelatedCommonOption


#Region " Declarations"

      Private _option As EquipmentOption
      Private _dependentOptions As List(Of EquipmentOption)
      Private _parentOptions As List(Of EquipmentOption)
      Private _isDependent As Boolean
      Private _isParent As Boolean
      Private _refreshDependentOptions As Boolean
      Private _refreshParentOptions As Boolean

      Private hasRetrievedDependentOptions As Boolean
      Private hasRetrievedParentOptions As Boolean
#End Region


#Region " Properties"

      ''' <summary>Option to determine parent and dependent options for</summary>
      Public Property [Option]() As EquipmentOption
         Get
            Return Me._option
         End Get
         Set(ByVal Value As EquipmentOption)
            Me._option = Value
         End Set
      End Property

      ''' <summary>List of options whose prices are dependent upon the Option property</summary>
      Public ReadOnly Property DependentOptions() As List(Of EquipmentOption)
         Get
            ' checks whether or not to refresh list of dependent options
            If Me._refreshDependentOptions Then
               ' retrieves dependent options and sets refresh and IsParent properties
               Me.GetDependentOptions()
            End If

            Return Me._dependentOptions
         End Get
      End Property

      ''' <summary>List of options that are parent options of the Option property</summary>
      Public ReadOnly Property ParentOptions() As List(Of EquipmentOption)
         Get
            ' checks if parent options should be refreshed
            If Me._refreshParentOptions Then
               ' retrieves list of parent options and sets refresh and IsDependent properties
               Me.GetParentOptions()
            End If

            Return Me._parentOptions
         End Get
      End Property

      ''' <summary>True if Option property is dependent (its price is dependent upon another option)</summary>
      Public ReadOnly Property IsDependent() As Boolean
         Get
            ' checks if it is known whether this is a dependent option yet
            If Not Me.hasRetrievedParentOptions Then
               ' checks if this is a dependent option since it hasn't been checked yet
               Me.GetParentOptions()
            End If

            Return Me._isDependent
         End Get
      End Property

      ''' <summary>True if Option property is parent (other option prices are dependent upon it)</summary>
      Public ReadOnly Property IsParent() As Boolean
         Get
            ' checks if it is known yet if this option is a parent option
            If Not Me.hasRetrievedDependentOptions Then
               ' checks if this is a parent option since it hasn't been checked yet
               Me.GetDependentOptions()
            End If

            Return Me._isParent
         End Get
      End Property

      ''' <summary>If true then dependent options are retrieved from datasource; otherwise, they're retrieved from cache
      ''' </summary>
      Public ReadOnly Property RefreshDependentOptions() As Boolean
         Get
            Return Me._refreshDependentOptions
         End Get
      End Property

      ''' <summary>If true then parent options are retrieved from datasource; otherwise, they're retrieved from cache
      ''' </summary>
      Public ReadOnly Property RefreshParentOptions() As Boolean
         Get
            Return Me._refreshParentOptions
         End Get
      End Property

#End Region


      ''' <summary>Constructor, sets Option property</summary>
      ''' <param name="op">Option to determine parent and dependent options for</param>
      Public Sub New(ByVal op As EquipmentOption)
         Me._option = op
         Me.InitializeProperties()
      End Sub


#Region " Private methods"

      ''' <summary>Initializes property values</summary>
      Private Sub InitializeProperties()
         Me._refreshDependentOptions = True
         Me._refreshParentOptions = True
         Me.hasRetrievedDependentOptions = False
         Me.hasRetrievedParentOptions = False
      End Sub


      ''' <summary>Retrieves dependent options and sets RefreshDependentOptions and IsParent properties</summary>
      Private Function GetDependentOptions() As List(Of EquipmentOption)
            ' retrieves options dependent upon Option property
            Me._dependentOptions = DA1.RetrieveDependentOptions(Me._option.Code, Me._option.Equipment.series)
            ' sets IsParent property (if option has dependents then it is a parent)
            Me._isParent = (Me._dependentOptions.Count > 0)
         ' resets refresh so that next call to dependent options will use cached dependent options
         Me._refreshDependentOptions = False
         ' lets IsParent property know dependents have been retrieved
         Me.hasRetrievedDependentOptions = True

         Return Me._dependentOptions
      End Function


      ''' <summary>Retrieves parent options and sets RefreshParentOptions and IsDependent properties</summary>
      Private Function GetParentOptions() As List(Of EquipmentOption)
            ' retrieves potential parent options of Option property
            Me._parentOptions = DA1.RetrieveParentOptions(Me._option.Code, Me._option.Equipment.series)
            'Me._parentOptions = RetrieveParentOptions(Me._option.Code
            ' sets IsDependent property (if option has parents then it is dependent)
            Me._isDependent = (Me._parentOptions.Count > 0)
         ' resets RefreshParentOptions property, so that next time ParentOptions is accessed it will use cached values
         Me._refreshParentOptions = False
         ' lets IsDependent property know parents have been retrieved
         Me.hasRetrievedParentOptions = True

         Return Me._parentOptions
      End Function

#End Region

   End Class

End Namespace