Option Strict On
Option Explicit On

Imports System.Data

Imports rae.RaeSolutions.Business
Imports SC = System.ComponentModel
Imports rae.RaeSolutions.DataAccess
Imports rae.Ui
Imports System.Collections.Specialized
Imports Forms = System.Windows.Forms
Imports System.Collections.Generic
Imports rae.DataAccess.EquipmentOptions.EquipmentDataAccess
Imports rae.solutions

''' <summary>Control used to select equipment</summary>
''' <remarks>WARNING: will only work in EquipmentForm. It is getting division from EquipmentForm.</remarks>
Public Class EquipmentSelector
    Inherits System.Windows.Forms.UserControl


#Region " Windows Form Designer generated code "

    Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblEquipment As System.Windows.Forms.Label
    Friend WithEvents cbo_series As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_model As System.Windows.Forms.ComboBox
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblSeries As System.Windows.Forms.Label
    Friend WithEvents pinkImageList As System.Windows.Forms.ImageList
    Friend WithEvents lblOkPic As System.Windows.Forms.Label
    Friend WithEvents panBorder As System.Windows.Forms.Panel
    Friend WithEvents tip As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentSelector))
        Me.lblEquipment = New System.Windows.Forms.Label
        Me.cbo_series = New System.Windows.Forms.ComboBox
        Me.cbo_model = New System.Windows.Forms.ComboBox
        Me.lblModel = New System.Windows.Forms.Label
        Me.lblSeries = New System.Windows.Forms.Label
        Me.pinkImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.lblOkPic = New System.Windows.Forms.Label
        Me.panBorder = New System.Windows.Forms.Panel
        Me.tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.panBorder.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEquipment
        '
        Me.lblEquipment.Location = New System.Drawing.Point(0, 22)
        Me.lblEquipment.Name = "lblEquipment"
        Me.lblEquipment.Size = New System.Drawing.Size(64, 23)
        Me.lblEquipment.TabIndex = 145
        Me.lblEquipment.Text = "Equipment"
        Me.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbo_series
        '
        Me.cbo_series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_series.Location = New System.Drawing.Point(72, 22)
        Me.cbo_series.Name = "cbo_series"
        Me.cbo_series.Size = New System.Drawing.Size(72, 21)
        Me.cbo_series.TabIndex = 140
        '
        'cbo_model
        '
        Me.cbo_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_model.Location = New System.Drawing.Point(144, 22)
        Me.cbo_model.Name = "cbo_model"
        Me.cbo_model.Size = New System.Drawing.Size(103, 21)
        Me.cbo_model.TabIndex = 141
        '
        'lblModel
        '
        Me.lblModel.BackColor = System.Drawing.Color.Transparent
        Me.lblModel.Location = New System.Drawing.Point(144, 2)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(52, 20)
        Me.lblModel.TabIndex = 142
        Me.lblModel.Text = "Model"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSeries
        '
        Me.lblSeries.BackColor = System.Drawing.Color.Transparent
        Me.lblSeries.Location = New System.Drawing.Point(76, 2)
        Me.lblSeries.Name = "lblSeries"
        Me.lblSeries.Size = New System.Drawing.Size(52, 20)
        Me.lblSeries.TabIndex = 138
        Me.lblSeries.Text = "Series"
        Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pinkImageList
        '
        Me.pinkImageList.ImageStream = CType(resources.GetObject("pinkImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.pinkImageList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.pinkImageList.Images.SetKeyName(0, "")
        Me.pinkImageList.Images.SetKeyName(1, "")
        '
        'lblOkPic
        '
        Me.lblOkPic.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Warning
        Me.lblOkPic.Location = New System.Drawing.Point(251, 24)
        Me.lblOkPic.Name = "lblOkPic"
        Me.lblOkPic.Size = New System.Drawing.Size(16, 16)
        Me.lblOkPic.TabIndex = 147
        '
        'panBorder
        '
        Me.panBorder.BackColor = System.Drawing.Color.Transparent
        Me.panBorder.Controls.Add(Me.lblEquipment)
        Me.panBorder.Controls.Add(Me.cbo_series)
        Me.panBorder.Controls.Add(Me.cbo_model)
        Me.panBorder.Controls.Add(Me.lblModel)
        Me.panBorder.Controls.Add(Me.lblOkPic)
        Me.panBorder.Controls.Add(Me.lblSeries)
        Me.panBorder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panBorder.Location = New System.Drawing.Point(0, 0)
        Me.panBorder.Name = "panBorder"
        Me.panBorder.Size = New System.Drawing.Size(281, 51)
        Me.panBorder.TabIndex = 148
        '
        'tip
        '
        Me.tip.AutoPopDelay = 10000
        Me.tip.InitialDelay = 500
        Me.tip.ReshowDelay = 200
        '
        'EquipmentSelector
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.panBorder)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "EquipmentSelector"
        Me.Size = New System.Drawing.Size(281, 51)
        Me.panBorder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private _showBorder As Boolean
    Private _division As Business.Division
    Private _equipmentType As String


    ''' <summary>Text to prompt user to make a selection</summary>
    Public ReadOnly choose As String = "Choose"


#Region " Properties"

    ''' <summary>Equipment type</summary>
    Property EquipmentType As String
        Get
            Return _equipmentType
        End Get
        Set(ByVal value As String)
            If Not EquipmentType = value Then
                _equipmentType = value
                If hasVal(EquipmentType) AndAlso divisionIsSet Then _
                   populate_series()
            End If
        End Set
    End Property


    ''' <summary>Company division that equipment is in</summary>
    Property Division As Business.Division
        Get
            Return _division
        End Get
        Set(ByVal value As Business.Division)
            Me._division = value
            If hasVal(EquipmentType) AndAlso divisionIsSet Then _
               populate_series()
        End Set
    End Property


    ''' <summary>Selected equipment name (the series and model combined)</summary>
    <SC.Browsable(False)> _
    ReadOnly Property Equipment As String
        Get
            If Series Is Nothing OrElse Model Is Nothing _
            OrElse Series = choose OrElse Model = choose Then _
               Return Nothing

            If EquipmentType = "FluidCooler" Then _
               Return Series & "-" & Model

            Return Me.Series & Me.Model
        End Get
    End Property

    Property User As user
        Get
            Return _user
        End Get
        Set(ByVal value As user)
            _user = value
        End Set
    End Property
    Private _user As user


    ''' <summary>Selected equipment series as string</summary>
    <SC.Browsable(False)> _
    Property Series As String
        Get
            If cbo_series.SelectedItem Is Nothing Then
                Return Nothing
            Else
                Return Me.cbo_series.SelectedItem.ToString
            End If
        End Get
        Set(ByVal value As String)
            ' gets index of series
            Dim seriesIndex = ListHelper.IndexOfComboBoxItem(Me.cbo_series, value)
            ' is the series not already selected
            If Not Me.cbo_series.SelectedIndex = seriesIndex Then
                ' selects series
                Me.cbo_series.SelectedIndex = seriesIndex
            End If
        End Set
    End Property


    ''' <summary>Selected equipment model</summary>
    <SC.Browsable(False)> _
    Property Model() As String
        Get
            If cbo_model.SelectedItem Is Nothing Then
                Return String.Empty
            Else
                Return cbo_model.SelectedItem.ToString
            End If
        End Get
        Set(ByVal value As String)
            ' gets index of model
            Dim modelIndex = ListHelper.IndexOfComboBoxItem(Me.cbo_model, value)
            ' are the selected model and model to be selected different
            If Not Me.cbo_model.SelectedIndex = modelIndex Then
                ' selects model
                Me.cbo_model.SelectedIndex = modelIndex
            End If
        End Set
    End Property


    ''' <summary>Indicates whether the equipment is completely selected.</summary>
    <SC.Browsable(False)> _
    ReadOnly Property IsCompleted As Boolean
        Get
            ' determines whether the equipment is completely selected
            If cbo_series.SelectedItem Is Nothing _
            OrElse cbo_model.SelectedItem Is Nothing _
            OrElse cbo_series.SelectedItem.ToString = choose _
            OrElse cbo_model.SelectedItem.ToString = choose Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property


    ''' <summary>Shows border around control if true; sets border to none if false</summary>
    Property ShowBorder As Boolean
        Get
            Return _showBorder
        End Get
        Set(ByVal value As Boolean)
            Me._showBorder = value
            If Me._showBorder Then
                ' shows border
                Me.panBorder.BorderStyle = Forms.BorderStyle.FixedSingle
            Else
                ' hides border
                Me.panBorder.BorderStyle = Forms.BorderStyle.None
            End If
        End Set
    End Property

#End Region


#Region " Events"

    ''' <summary>Raised before series changes, allows series change to be canceled</summary>
    Public Event BeforeSeriesChanged(ByVal sender As EquipmentSelector, ByRef e As SC.CancelEventArgs)
    ''' <summary>Raises after series changes and model list is filled</summary>
    Public Event SeriesChanged(ByVal sender As EquipmentSelector, ByVal selectedSeries As String)

    Public Event BeforeModelChanged(ByVal sender As EquipmentSelector, ByRef e As SC.CancelEventArgs)
    ''' <summary>Raises after model changes</summary>
    Public Event ModelChanged(ByVal sender As EquipmentSelector, ByVal selectedModel As String)

#End Region


#Region " Event handlers"

    ''' <summary>Handles control load</summary>
    Private Sub EquipmentSelector_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Dim sDivision As String
        Dim division As Division

        If Me.DesignMode = False Then
            ' sets division in EquipmentSelector same as in parent form, EquipmentForm
            Me.Division = AppInfo.Division 'CType(Me.ParentForm, EquipmentForm).Equipment.Equipment.Division
        End If

        ' disables model until the equipment line is selected
        Me.cbo_model.Enabled = False

        Me.setColors()
    End Sub


    ''' <summary>Handles series change</summary>
    Private Sub cboSeries_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cbo_series.SelectedIndexChanged
        Static previousSeries As String = choose
        Static handleChangeEvent As Boolean = True

        ' checks if a series selection is made
        If Me.Series = String.Empty Then
            ' disables model, sets completion icon to incomplete and exits
            Me.cbo_model.Enabled = False : Me.setImageToNotSelected() : Exit Sub
        End If

        ' checks if selection has actually changed and that the event is to be handled
        If Me.Series = previousSeries AndAlso handleChangeEvent = True Then Exit Sub

        ' checks whether to handle change event or not
        If Not handleChangeEvent Then
            ' resets
            handleChangeEvent = True : Exit Sub
        End If

        Dim cancelEventArgs As New System.ComponentModel.CancelEventArgs(False)
        previous_series = previousSeries
        ' raises event before the change is handled
        RaiseEvent BeforeSeriesChanged(Me, cancelEventArgs)

        ' checks whether to cancel change
        If cancelEventArgs.Cancel Then
            ' prevents changing to previous series from raising events
            handleChangeEvent = False
            ' resets series to previous selection and exits
            Me.Series = previousSeries : Exit Sub
        End If

        ' sets previous series
        previousSeries = Me.Series

        ' sets image to incomplete
        Me.setImageToNotSelected()

        ' checks if series is set to choose still (a selection is not made)
        If Not Me.Series = choose Then
            ' removes choose
            If Me.cbo_series.Items.Contains(Me.choose) Then Me.cbo_series.Items.RemoveAt(Me.cbo_series.Items.IndexOf(Me.choose))
            ' enables model combobox
            Me.cbo_model.Enabled = True
            ' populates models and selects choose
            Me.populateModels()
        Else
            ' clears and disables model combobox
            Me.cbo_model.Items.Clear() : Me.cbo_model.Enabled = False
        End If

        RaiseEvent SeriesChanged(Me, Me.Series)
    End Sub

    Public previous_series As String


    Private wasCanceled As Boolean = False

    ''' <summary>Handles model change</summary>
    Private Sub cboModel_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
    Handles cbo_model.SelectedIndexChanged
        Static previousModel As String = choose

        ' checks if a model is selected
        If Me.Model = String.Empty Then
            ' sets image to incomplete and exits
            Me.setImageToNotSelected() : Exit Sub
        End If

        ' checks if model has changed
        If Me.Model = previousModel Then Exit Sub

        'If wasCanceled Then
        '   wasCanceled = False
        '   Exit Sub
        'End If

        Dim cancelArgs = New SC.CancelEventArgs(False)
        If previousModel <> "Choose" Then ' not opening
            RaiseEvent BeforeModelChanged(Me, cancelArgs)

            If cancelArgs.Cancel Then
                'wasCanceled = True
                Me.Model = previousModel
                Exit Sub
            End If
        End If
        ' sets previous model
        previousModel = Me.Model

        ' sets completed icon indicator
        If Me.Model = choose Then
            ' sets completion image to incomplete icon
            Me.setImageToNotSelected()
        Else
            ' removes choose
            If Me.cbo_model.Items.Contains(Me.choose) Then Me.cbo_model.Items.RemoveAt(Me.cbo_model.Items.IndexOf(Me.choose))
            ' sets completion image to completed icon
            Me.setImageToSelected()
        End If

        ' raises event for subscribers
        RaiseEvent ModelChanged(Me, Me.Model)
    End Sub

#End Region


#Region " Private methods"

    ''' <summary>Populates equipment series and sets choose as default</summary>
    Private Sub populate_series()
        Dim series_list = retrieve_series(_division.ToString.ToUpper, _equipmentType, user.is_rep)
        series_list.insert(0, Me.choose)

        cbo_series.items.clear()
        For Each series As String In series_list
            '  If series.ToUpper <> "NIBR" Then
            cbo_series.Items.Add(series)
            '   End If
        Next

        cbo_series.SelectedIndex = 0
    End Sub

    Private Function EnsureModelHasRating(ByVal model As String) As Boolean
        Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
        Dim command = connection.CreateCommand()
        Dim sql As String
        EnsureModelHasRating = False


        Dim FanQTY1 As Integer
        Dim FanQTY2 As Integer

        sql = "select MODEL  from table5 where model = '" & model & "'"
        command.CommandText = sql
        Dim reader As IDataReader
        Try
            connection.Open()
            reader = command.ExecuteReader()

            If reader.Read Then
                EnsureModelHasRating = True
            Else
                EnsureModelHasRating = False
            End If

        Catch
            EnsureModelHasRating = False
        Finally
            If reader IsNot Nothing Then _
               reader.Close()
            If connection.State <> ConnectionState.Closed Then _
               connection.Close()
        End Try



    End Function




    ''' <summary>Populates models and sets choose as default</summary>
    Private Sub populateModels()
        ' retrieves models in the selected series
        Dim models = Convert.Sorter(rae.DataAccess.EquipmentOptions.EquipmentDataAccess.RetrieveModels(Series), 9) 'pass list to be sorted and number of number-alpha blocks you think might be needed


        If _division = Business.Division.CRI And _equipmentType.ToUpper = "CONDENSINGUNIT" Then

            Dim connection = Common.CreateConnection(Common.CondensingUnitDbPath)
            Dim command = connection.CreateCommand()
            Dim sql As String

            Dim goodModels As New List(Of String)


            Dim reader As IDataReader
            Try
                connection.Open()

                For Each Model As String In models
                    sql = "select MODEL  from table5 where model = '" & Series & Model & "'"
                    command.CommandText = sql
                    reader = command.ExecuteReader()

                    If reader.Read Then
                        goodModels.add(Model)
                    End If
                    If reader IsNot Nothing Then _
                       reader.Close()

                Next


                models.Clear()
                models.AddRange(goodModels)




            Catch
                Beep()
            Finally
                If connection.State <> ConnectionState.Closed Then _
                   connection.Close()
            End Try

        End If










        ' inserts choose text
        models.Insert(0, choose)

        ' clears models in combobox
        Me.cbo_model.Items.Clear()
        ' populates models combobox
        For i As Integer = 0 To models.Count - 1
            Me.cbo_model.Items.Add(models(i))
        Next
        ' selects choose as default
        Me.cbo_model.SelectedIndex = 0
    End Sub


    ''' <summary>Sets image to symbol indicating the equipment is selected.</summary>
    Private Sub setImageToSelected()
        Me.lblOkPic.Image = Me.pinkImageList.Images(0)

        Dim message = "Equipment is selected"
        Me.tip.SetToolTip(Me.lblOkPic, message)
    End Sub

    Private Sub setImageToNotSelected()
        lblOkPic.Image = My.Resources.Warning

        Dim message = "Equipment is not selected"
        Me.tip.SetToolTip(Me.lblOkPic, message)
    End Sub

    Private Sub setColors()
        lblEquipment.ForeColor = MyColors.DarkBlue
        lblModel.ForeColor = MyColors.DarkBlue
        lblSeries.ForeColor = MyColors.DarkBlue
    End Sub


    Private Function divisionIsSet() As Boolean
        Return Not (Division = Business.Division.NotSet)
    End Function

    Private Function hasVal(ByVal value As String) As Boolean
        Return Not String.IsNullOrEmpty(value)
    End Function

#End Region

End Class

