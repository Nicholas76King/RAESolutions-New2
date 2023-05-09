Option Strict On
Option Explicit On

Imports System.Collections.Generic
' Business Entities
Imports BE1 = RAE.RAESolutions.Business.Entities
' Data Access
Imports DA1 = RAE.DataAccess.EquipmentOptions.DependentCommonOptionsDataAccess
' Equipment Options
Imports EO1 = RAE.DataAccess.EquipmentOptions

Namespace Rae.RaeSolutions.DataAccess.EquipmentOptionsAgent

   ''' <summary>
   ''' Retrieves dependent common options from RAE.DataAccess.EquipmentOptions and translates option object.
   ''' </summary>
   Public Class DependentCommonOptionsDa

        ''' <summary>
        ''' Retrieves dependent common options for the parent option and equipment series
        ''' </summary>
        ''' <param name="parentCode">Option code for the parent option</param>
        ''' <param name="series">Equipment series</param>
        ''' <returns>Dependent options</returns>
        Public Shared Function RetrieveDependentOptions(ByVal parentCode As String, ByVal series As String) As List(Of BE1.EquipmentOption)
            Dim dependentOps As List(Of EO1.Option)
            Dim convertedOps As New List(Of BE1.EquipmentOption)

            ' retrieves EquipmentOptions options
            dependentOps = DA1.RetrieveDependentOptions(parentCode, series)
            ' converts options to RAESolutions options
            For i As Integer = 0 To dependentOps.Count - 1
                convertedOps.Add(ToOption(dependentOps(i)))
            Next

            Return convertedOps
        End Function


        ''' <summary>
        ''' Retrieves parent options for the dependent option and equipment series
        ''' </summary>
        ''' <param name="dependentCode">Option code of dependent option</param>
        ''' <param name="series">Equipment series</param>
        ''' <returns>Parent options</returns>
        Public Shared Function RetrieveParentOptions(ByVal dependentCode As String, ByVal series As String) As List(Of BE1.EquipmentOption)
            Dim parentOps As List(Of EO1.Option)
            Dim convertedOps As New List(Of BE1.EquipmentOption)

            ' retrieves EquipmentOptions parent options
            parentOps = DA1.RetrieveParentOptions(dependentCode, series)
            ' converts options
            For i As Integer = 0 To parentOps.Count - 1
                convertedOps.Add(ToOption(parentOps(i)))
            Next

            Return convertedOps
        End Function




        ''' <summary>
        ''' Converts EquipmentOptions Option object to a RAESolutions Option object
        ''' </summary>
        ''' <param name="op">Option to convert</param>
        ''' <returns>Converted option</returns>
        ''' <remarks></remarks>
        Private Shared Function ToOption(ByVal op As EO1.Option) As BE1.EquipmentOption
            Dim convertedOp As New BE1.EquipmentOption

            With convertedOp
                .PricingId = op.PricingId
                .Code = op.Code
                .Description = op.Description
                .Category = op.Category
                .Voltage = op.Voltage
                .Price = op.Price
                .Quantity = op.Quantity
                Dim bogusEquipment As New BE1.CondensingUnitEquipmentItem("", Business.Division.TSI, New BE1.item_id("a", "b"), Nothing)
                .Equipment = bogusEquipment
                .Equipment.series = op.Equipment.Series

                ''' <history>removed series and model b/c they were null</history>
                '.Equipment.Equipment.Series = op.Equipment.Series
                '.Equipment.Equipment.Model = op.Equipment.Model

                '.IsDependentCommonOption = op.IsDependentCommonOption
                '.IsQuantityReadOnly = op.IsQuantityReadOnly
                '.IsStandard = op.IsStandard
                '.IsVoltageDependent = op.IsVoltageDependent
                '.ContactFactory = op.ContactFactory
                .Selected = op.IsStandard
            End With

            Return convertedOp
        End Function

    End Class

End Namespace