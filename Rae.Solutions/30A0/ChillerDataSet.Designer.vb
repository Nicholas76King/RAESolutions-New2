﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System


<System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
 Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.ComponentModel.ToolboxItem(true),  _
 System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"),  _
 System.Xml.Serialization.XmlRootAttribute("ChillerDataSet"),  _
 System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class ChillerDataSet
    Inherits System.Data.DataSet
    
    Private tableResults As ResultsDataTable
    
    Private _schemaSerializationMode As System.Data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub New()
        MyBase.New
        Me.BeginInit
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler MyBase.Relations.CollectionChanged, schemaChangedHandler
        Me.EndInit
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context, false)
        If (Me.IsBinarySerialized(info, context) = true) Then
            Me.InitVars(false)
            Dim schemaChangedHandler1 As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
            AddHandler Me.Tables.CollectionChanged, schemaChangedHandler1
            AddHandler Me.Relations.CollectionChanged, schemaChangedHandler1
            Return
        End If
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(String)),String)
        If (Me.DetermineSchemaSerializationMode(info, context) = System.Data.SchemaSerializationMode.IncludeSchema) Then
            Dim ds As System.Data.DataSet = New System.Data.DataSet
            ds.ReadXmlSchema(New System.Xml.XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Results")) Is Nothing) Then
                MyBase.Tables.Add(New ResultsDataTable(ds.Tables("Results")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXmlSchema(New System.Xml.XmlTextReader(New System.IO.StringReader(strSchema)))
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Results() As ResultsDataTable
        Get
            Return Me.tableResults
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.BrowsableAttribute(true),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)>  _
    Public Overrides Property SchemaSerializationMode() As System.Data.SchemaSerializationMode
        Get
            Return Me._schemaSerializationMode
        End Get
        Set
            Me._schemaSerializationMode = value
        End Set
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Tables() As System.Data.DataTableCollection
        Get
            Return MyBase.Tables
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Relations() As System.Data.DataRelationCollection
        Get
            Return MyBase.Relations
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub InitializeDerivedDataSet()
        Me.BeginInit
        Me.InitClass
        Me.EndInit
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Overrides Function Clone() As System.Data.DataSet
        Dim cln As ChillerDataSet = CType(MyBase.Clone,ChillerDataSet)
        cln.InitVars
        cln.SchemaSerializationMode = Me.SchemaSerializationMode
        Return cln
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As System.Xml.XmlReader)
        If (Me.DetermineSchemaSerializationMode(reader) = System.Data.SchemaSerializationMode.IncludeSchema) Then
            Me.Reset
            Dim ds As System.Data.DataSet = New System.Data.DataSet
            ds.ReadXml(reader)
            If (Not (ds.Tables("Results")) Is Nothing) Then
                MyBase.Tables.Add(New ResultsDataTable(ds.Tables("Results")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXml(reader)
            Me.InitVars
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New System.Xml.XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New System.Xml.XmlTextReader(stream), Nothing)
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars()
        Me.InitVars(true)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars(ByVal initTable As Boolean)
        Me.tableResults = CType(MyBase.Tables("Results"),ResultsDataTable)
        If (initTable = true) Then
            If (Not (Me.tableResults) Is Nothing) Then
                Me.tableResults.InitVars
            End If
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "ChillerDataSet"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/ChillerRatingDataSet.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableResults = New ResultsDataTable
        MyBase.Tables.Add(Me.tableResults)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeResults() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Shared Function GetTypedDataSetSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
        Dim ds As ChillerDataSet = New ChillerDataSet
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub ResultsRowChangeEventHandler(ByVal sender As Object, ByVal e As ResultsRowChangeEvent)
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class ResultsDataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnLeavingTemperature As System.Data.DataColumn
        
        Private columnAmbientTemperature As System.Data.DataColumn
        
        Private columnEvaporatorTemperature As System.Data.DataColumn
        
        Private columnCondenserTemperature As System.Data.DataColumn
        
        Private columnCapacity As System.Data.DataColumn
        
        Private columnUnitPower As System.Data.DataColumn
        
        Private columnFlowRate As System.Data.DataColumn
        
        Private columnEvaporatorPressureDrop As System.Data.DataColumn
        
        Private columnCompressorEfficiency As System.Data.DataColumn
        
        Private columnUnitEfficiency As System.Data.DataColumn
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "Results"
            Me.BeginInit
            Me.InitClass
            Me.EndInit
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal table As System.Data.DataTable)
            MyBase.New
            Me.TableName = table.TableName
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            Me.InitVars
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property LeavingTemperatureColumn() As System.Data.DataColumn
            Get
                Return Me.columnLeavingTemperature
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property AmbientTemperatureColumn() As System.Data.DataColumn
            Get
                Return Me.columnAmbientTemperature
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property EvaporatorTemperatureColumn() As System.Data.DataColumn
            Get
                Return Me.columnEvaporatorTemperature
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property CondenserTemperatureColumn() As System.Data.DataColumn
            Get
                Return Me.columnCondenserTemperature
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property CapacityColumn() As System.Data.DataColumn
            Get
                Return Me.columnCapacity
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property UnitPowerColumn() As System.Data.DataColumn
            Get
                Return Me.columnUnitPower
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property FlowRateColumn() As System.Data.DataColumn
            Get
                Return Me.columnFlowRate
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property EvaporatorPressureDropColumn() As System.Data.DataColumn
            Get
                Return Me.columnEvaporatorPressureDrop
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property CompressorEfficiencyColumn() As System.Data.DataColumn
            Get
                Return Me.columnCompressorEfficiency
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property UnitEfficiencyColumn() As System.Data.DataColumn
            Get
                Return Me.columnUnitEfficiency
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Default ReadOnly Property Item(ByVal index As Integer) As ResultsRow
            Get
                Return CType(Me.Rows(index),ResultsRow)
            End Get
        End Property
        
        Public Event ResultsRowChanging As ResultsRowChangeEventHandler
        
        Public Event ResultsRowChanged As ResultsRowChangeEventHandler
        
        Public Event ResultsRowDeleting As ResultsRowChangeEventHandler
        
        Public Event ResultsRowDeleted As ResultsRowChangeEventHandler
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddResultsRow(ByVal row As ResultsRow)
            Me.Rows.Add(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddResultsRow(ByVal LeavingTemperature As String, ByVal AmbientTemperature As String, ByVal EvaporatorTemperature As String, ByVal CondenserTemperature As String, ByVal Capacity As String, ByVal UnitPower As String, ByVal FlowRate As String, ByVal EvaporatorPressureDrop As String, ByVal CompressorEfficiency As String, ByVal UnitEfficiency As String) As ResultsRow
            Dim rowResultsRow As ResultsRow = CType(Me.NewRow,ResultsRow)
            rowResultsRow.ItemArray = New Object() {LeavingTemperature, AmbientTemperature, EvaporatorTemperature, CondenserTemperature, Capacity, UnitPower, FlowRate, EvaporatorPressureDrop, CompressorEfficiency, UnitEfficiency}
            Me.Rows.Add(rowResultsRow)
            Return rowResultsRow
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As ResultsDataTable = CType(MyBase.Clone,ResultsDataTable)
            cln.InitVars
            Return cln
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New ResultsDataTable
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnLeavingTemperature = MyBase.Columns("LeavingTemperature")
            Me.columnAmbientTemperature = MyBase.Columns("AmbientTemperature")
            Me.columnEvaporatorTemperature = MyBase.Columns("EvaporatorTemperature")
            Me.columnCondenserTemperature = MyBase.Columns("CondenserTemperature")
            Me.columnCapacity = MyBase.Columns("Capacity")
            Me.columnUnitPower = MyBase.Columns("UnitPower")
            Me.columnFlowRate = MyBase.Columns("FlowRate")
            Me.columnEvaporatorPressureDrop = MyBase.Columns("EvaporatorPressureDrop")
            Me.columnCompressorEfficiency = MyBase.Columns("CompressorEfficiency")
            Me.columnUnitEfficiency = MyBase.Columns("UnitEfficiency")
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnLeavingTemperature = New System.Data.DataColumn("LeavingTemperature", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnLeavingTemperature)
            Me.columnAmbientTemperature = New System.Data.DataColumn("AmbientTemperature", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnAmbientTemperature)
            Me.columnEvaporatorTemperature = New System.Data.DataColumn("EvaporatorTemperature", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnEvaporatorTemperature)
            Me.columnCondenserTemperature = New System.Data.DataColumn("CondenserTemperature", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnCondenserTemperature)
            Me.columnCapacity = New System.Data.DataColumn("Capacity", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnCapacity)
            Me.columnUnitPower = New System.Data.DataColumn("UnitPower", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnUnitPower)
            Me.columnFlowRate = New System.Data.DataColumn("FlowRate", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnFlowRate)
            Me.columnEvaporatorPressureDrop = New System.Data.DataColumn("EvaporatorPressureDrop", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnEvaporatorPressureDrop)
            Me.columnCompressorEfficiency = New System.Data.DataColumn("CompressorEfficiency", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnCompressorEfficiency)
            Me.columnUnitEfficiency = New System.Data.DataColumn("UnitEfficiency", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnUnitEfficiency)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewResultsRow() As ResultsRow
            Return CType(Me.NewRow,ResultsRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New ResultsRow(builder)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(ResultsRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.ResultsRowChangedEvent) Is Nothing) Then
                RaiseEvent ResultsRowChanged(Me, New ResultsRowChangeEvent(CType(e.Row,ResultsRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.ResultsRowChangingEvent) Is Nothing) Then
                RaiseEvent ResultsRowChanging(Me, New ResultsRowChangeEvent(CType(e.Row,ResultsRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.ResultsRowDeletedEvent) Is Nothing) Then
                RaiseEvent ResultsRowDeleted(Me, New ResultsRowChangeEvent(CType(e.Row,ResultsRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.ResultsRowDeletingEvent) Is Nothing) Then
                RaiseEvent ResultsRowDeleting(Me, New ResultsRowChangeEvent(CType(e.Row,ResultsRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveResultsRow(ByVal row As ResultsRow)
            Me.Rows.Remove(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As ChillerDataSet = New ChillerDataSet
            xs.Add(ds.GetSchemaSerializable)
            Dim any1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any1.Namespace = "http://www.w3.org/2001/XMLSchema"
            any1.MinOccurs = New Decimal(0)
            any1.MaxOccurs = Decimal.MaxValue
            any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any1)
            Dim any2 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
            any2.MinOccurs = New Decimal(1)
            any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any2)
            Dim attribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute1.Name = "namespace"
            attribute1.FixedValue = ds.Namespace
            type.Attributes.Add(attribute1)
            Dim attribute2 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute2.Name = "tableTypeName"
            attribute2.FixedValue = "ResultsDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class ResultsRow
        Inherits System.Data.DataRow
        
        Private tableResults As ResultsDataTable
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableResults = CType(Me.Table,ResultsDataTable)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property LeavingTemperature() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.LeavingTemperatureColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'LeavingTemperature' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.LeavingTemperatureColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property AmbientTemperature() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.AmbientTemperatureColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'AmbientTemperature' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.AmbientTemperatureColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property EvaporatorTemperature() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.EvaporatorTemperatureColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'EvaporatorTemperature' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.EvaporatorTemperatureColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property CondenserTemperature() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.CondenserTemperatureColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'CondenserTemperature' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.CondenserTemperatureColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property Capacity() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.CapacityColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'Capacity' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.CapacityColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property UnitPower() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.UnitPowerColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'UnitPower' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.UnitPowerColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property FlowRate() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.FlowRateColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'FlowRate' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.FlowRateColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property EvaporatorPressureDrop() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.EvaporatorPressureDropColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'EvaporatorPressureDrop' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.EvaporatorPressureDropColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property CompressorEfficiency() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.CompressorEfficiencyColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'CompressorEfficiency' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.CompressorEfficiencyColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property UnitEfficiency() As String
            Get
                Try 
                    Return CType(Me(Me.tableResults.UnitEfficiencyColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'UnitEfficiency' in table 'Results' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableResults.UnitEfficiencyColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsLeavingTemperatureNull() As Boolean
            Return Me.IsNull(Me.tableResults.LeavingTemperatureColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetLeavingTemperatureNull()
            Me(Me.tableResults.LeavingTemperatureColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsAmbientTemperatureNull() As Boolean
            Return Me.IsNull(Me.tableResults.AmbientTemperatureColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetAmbientTemperatureNull()
            Me(Me.tableResults.AmbientTemperatureColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsEvaporatorTemperatureNull() As Boolean
            Return Me.IsNull(Me.tableResults.EvaporatorTemperatureColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetEvaporatorTemperatureNull()
            Me(Me.tableResults.EvaporatorTemperatureColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsCondenserTemperatureNull() As Boolean
            Return Me.IsNull(Me.tableResults.CondenserTemperatureColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetCondenserTemperatureNull()
            Me(Me.tableResults.CondenserTemperatureColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsCapacityNull() As Boolean
            Return Me.IsNull(Me.tableResults.CapacityColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetCapacityNull()
            Me(Me.tableResults.CapacityColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsUnitPowerNull() As Boolean
            Return Me.IsNull(Me.tableResults.UnitPowerColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetUnitPowerNull()
            Me(Me.tableResults.UnitPowerColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsFlowRateNull() As Boolean
            Return Me.IsNull(Me.tableResults.FlowRateColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetFlowRateNull()
            Me(Me.tableResults.FlowRateColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsEvaporatorPressureDropNull() As Boolean
            Return Me.IsNull(Me.tableResults.EvaporatorPressureDropColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetEvaporatorPressureDropNull()
            Me(Me.tableResults.EvaporatorPressureDropColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsCompressorEfficiencyNull() As Boolean
            Return Me.IsNull(Me.tableResults.CompressorEfficiencyColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetCompressorEfficiencyNull()
            Me(Me.tableResults.CompressorEfficiencyColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsUnitEfficiencyNull() As Boolean
            Return Me.IsNull(Me.tableResults.UnitEfficiencyColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetUnitEfficiencyNull()
            Me(Me.tableResults.UnitEfficiencyColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class ResultsRowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As ResultsRow
        
        Private eventAction As System.Data.DataRowAction
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As ResultsRow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As ResultsRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Action() As System.Data.DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
