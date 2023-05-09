Imports System.Collections.Specialized
Imports System.Collections.Generic
Imports Rae.Io.Text
Imports Rae.RaeSolutions.Business
Imports Rae.RaeSolutions.Business.Division
Imports Rae.solutions
Imports Rae.solutions.group
Imports Rae.Ui.Validation

''' <summary>Form to get project, equipment and selection names from user.</summary>
Public Class NewItemForm2

    Public IsValid As Boolean = False

    Public Enum NewItemType
        ProjectOnly
        EquipmentOnly
        EquipmentAndProject
        EquipmentOnlyFromSelection
        SelectionOnly
        SelectionAndProject
        SelectionAndEquipment
        SelectionEquipmentAndProject
        SelectionTypeOnly
    End Enum

    Private validationManager As ValidationManager
    Private projectNameValidationControl As ValidationControl = Nothing
    Private equipmentNameValidationControl As ValidationControl = Nothing
    Private selectionNameValidationControl As ValidationControl = Nothing

    Public getProcessType As Boolean
    Private m_Item_Type As NewItemType
    Private m_Selection_Type As ProcessType
    Private m_Equipment_Type As EquipmentType


#Region " Properties"

    ReadOnly Property ProjectName As String
        Get
            Return Me.projectNameTextBox.Text.Trim
        End Get
    End Property

    ReadOnly Property EquipmentName As String
        Get
            Return Me.equipmentNameTextBox.Text.Trim
        End Get
    End Property

    Private m_GetRevDesc As Boolean = False
    Property GetRevDesc As Boolean
        Get
            Return Me.m_GetRevDesc
        End Get
        Set(ByVal value As Boolean)
            Me.m_GetRevDesc = value
        End Set
    End Property

    ReadOnly Property RevisionDescription As String
        Get
            Return Me.txtRevDesc.Text.Trim
        End Get
    End Property

    ReadOnly Property SelectionName As String
        Get
            Return Me.selectionNameTextBox.Text.Trim
        End Get
    End Property

    ReadOnly Property EquipmentType As EquipmentType
        Get
            Dim typeEnum As EquipmentType
            Dim typeString As String

            ' gets selected equipment type
            typeString = Me.cboEquipmentType.SelectedItem.ToString
            ' removes spaces
            typeString = typeString.Replace(" ", "")
            ' converts string to enum
            Io.Text.GetEnumValue(typeString, typeEnum)

            Return typeEnum
        End Get
    End Property

    ReadOnly Property ProcessType As ProcessType
        Get
            Return Me.m_Selection_Type
        End Get
    End Property

    ReadOnly Property Division As Division
        Get
            Dim divisionEnum As Division
            GetEnumValue(Of Division)(Me.cboDivision.SelectedItem.ToString, divisionEnum)
            Return divisionEnum
        End Get
    End Property

#End Region


#Region " Public events"

    ''' <summary>Sets form controls based on item type</summary>
    ''' <param name="New_Item_Type">ProjectOnly, EquipmentOnly, EquipmentAndProject, SelectionOnly, SelectionAndProject</param>
    ''' <remarks></remarks>
    Sub NewItem(ByVal Item_Type As NewItemType, Optional ByVal Selection_Type As ProcessType = Nothing, Optional ByVal Equipment_Type As EquipmentType = Nothing)

        ' Set properties...
        m_Item_Type = Item_Type
        m_Selection_Type = Selection_Type
        m_Equipment_Type = Equipment_Type

        ' Initialize validation...
        If Me.m_GetRevDesc = False Then
            initializeValidation()
        End If

        ' Should we get a revision description?
        If Me.m_GetRevDesc = True Then

            Me.pnlRevDesc.Visible = True
            Me.txtRevDesc.Focus()

            ' disable other text boxes...
            Me.projectNameTextBox.Enabled = False
            Me.equipmentNameTextBox.Enabled = False
            Me.selectionNameTextBox.Enabled = False

            ' size form
            Me.Height = 150 + Me.pnlRevDesc.Height

        Else

            Me.pnlRevDesc.Visible = False

        End If

    End Sub

#End Region


#Region " Private event handlers"

    Private Sub form_Load() _
    Handles MyBase.Load
        Me.CenterToParent()
        Me.fillComboboxWithProcessTypesForSelectedDivision()
    End Sub

    Private Sub cboDivision_SelectedIndexChanged() _
    Handles cboDivision.SelectedIndexChanged
        fillComboboxWithEquipmentTypesForSelectedDivision()
    End Sub

    Private Sub okButton_Click() _
    Handles okButton.Click
        ' validates inputs and hides form (if is valid) or alerts user (if is not valid)

        ' are user inputs valid
        If Me.GetRevDesc = True OrElse Me.validationManager.Validate Then
            ' user inputs are valid
            Me.IsValid = True
            Me.DialogResult = Windows.Forms.DialogResult.OK
            ' hides dialog so that code will continue
            Me.Hide()
        Else
            ' user inputs are NOT valid
            Me.IsValid = False
            ' alerts user of invalid inputs
            Ui.MessageBox.Show(Me.validationManager.ErrorMessagesSummary)
        End If

    End Sub

    Private Sub cancelButton_Click() _
    Handles cancel2Button.Click
        ' cancels and hides form
        Me.m_Selection_Type = Business.ProcessType.NA
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.IsValid = False
        Me.Hide()
    End Sub

    ' todo: add handler, has required field validator
    Private Sub projectNameTextBox_Leave()
        Me.projectNameValidationControl.Validate()
    End Sub

    Private Sub equipmentNameTextBox_Leave() _
    Handles equipmentNameTextBox.Leave
        Me.equipmentNameValidationControl.Validate()
    End Sub

    Private Sub selectionNameTextBox_Leave() _
    Handles selectionNameTextBox.Leave
        Me.selectionNameValidationControl.Validate()
    End Sub

#End Region


#Region " Private helper methods"

    Private Sub initializeValidation()

        ' sub variables
        Dim projectNameRequiredValidator As RequiredValidator = Nothing
        Dim equipmentNameRequiredValidator As RequiredValidator = Nothing
        Dim selectionNameRequiredValidator As RequiredValidator = Nothing

        ' controls
        Me.equipmentAdditionalInfoPanel.Visible = False
        Me.equipmentNamePanel.Visible = False
        Me.projectNamePanel.Visible = False
        Me.selectionNamePanel.Visible = False

        ' constructs validation manager
        Me.validationManager = New ValidationManager(Me.newErrorProvider)

        ' construct validation controls based on
        ' the new item type
        Select Case m_Item_Type

            Case NewItemType.EquipmentOnly, NewItemType.EquipmentOnlyFromSelection
                ' constructs validation controls
                Me.equipmentNameValidationControl = New ValidationControl(Me.equipmentNameTextBox)

                ' constructs validators
                equipmentNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Equipment name"))

                ' set caption label
                Me.captionLabel.Text = "Please choose equipment name before saving."

            Case NewItemType.SelectionOnly
                ' constructs validation controls
                Me.selectionNameValidationControl = New ValidationControl(Me.selectionNameTextBox)

                ' constructs validators
                selectionNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Selection name"))

                ' set caption label
                Me.captionLabel.Text = "Please choose selection name before saving."


            Case NewItemType.ProjectOnly
                ' constructs validation controls
                Me.projectNameValidationControl = New ValidationControl(Me.projectNameTextBox)

                ' constructs validators
                projectNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Project name"))

                ' set caption label
                Me.captionLabel.Text = "Please choose project name before saving."


            Case NewItemType.EquipmentAndProject
                ' constructs validation controls
                Me.equipmentNameValidationControl = New ValidationControl(Me.equipmentNameTextBox)
                Me.projectNameValidationControl = New ValidationControl(Me.projectNameTextBox)

                ' constructs validators
                equipmentNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Equipment name"))
                projectNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Project name"))

                ' set caption label
                Me.captionLabel.Text = "Please choose project and equipment names before saving."


            Case NewItemType.SelectionAndEquipment
                ' constructs validation controls
                Me.equipmentNameValidationControl = New ValidationControl(Me.equipmentNameTextBox)
                Me.selectionNameValidationControl = New ValidationControl(Me.selectionNameTextBox)

                ' constructs validators
                equipmentNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Equipment name"))
                selectionNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Selection name"))

                ' set caption label
                Me.captionLabel.Text = "Please choose equipment and selection names before saving."


            Case NewItemType.SelectionAndProject
                ' constructs validation controls
                Me.selectionNameValidationControl = New ValidationControl(Me.selectionNameTextBox)
                Me.projectNameValidationControl = New ValidationControl(Me.projectNameTextBox)

                ' constructs validators
                selectionNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Selection name"))
                projectNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Project name"))

                ' set caption label
                Me.captionLabel.Text = "Please choose project and selection names before saving."


            Case NewItemType.SelectionEquipmentAndProject
                ' constructs validation controls
                Me.equipmentNameValidationControl = New ValidationControl(Me.equipmentNameTextBox)
                Me.selectionNameValidationControl = New ValidationControl(Me.selectionNameTextBox)
                Me.projectNameValidationControl = New ValidationControl(Me.projectNameTextBox)

                ' constructs validators
                projectNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Project name"))
                equipmentNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Equipment name"))
                selectionNameRequiredValidator = New RequiredValidator(ErrorMessages.Required("Selection name"))

                ' set caption label
                Me.captionLabel.Text = "Please choose project, equipment and selection names before saving."

            Case NewItemType.SelectionTypeOnly
                ' set caption label
                Me.captionLabel.Text = "Please choose a selection/rating type from the dropdown below:"
                Me.okButton.Text = "OK"

        End Select

        ' adds validators to validation controls and
        ' validation(Controls) to validation manager
        ' if the validation control has been set based
        ' on the new item type - we'll also set the
        ' form control visibility and size the form
        Me.Height = 150

        ' project validation
        If projectNameValidationControl IsNot Nothing Then
            projectNameValidationControl.Validators.Add(projectNameRequiredValidator)
            Me.validationManager.ValidationControls.Add(projectNameValidationControl)
            ' show project name panel
            Me.projectNamePanel.Visible = True
            ' size form
            Me.Height += Me.projectNamePanel.Height
        End If

        ' equipment Validation
        If equipmentNameValidationControl IsNot Nothing Then
            equipmentNameValidationControl.Validators.Add(equipmentNameRequiredValidator)
            Me.validationManager.ValidationControls.Add(equipmentNameValidationControl)
            ' show equipment name panel
            Me.equipmentNamePanel.Visible = True
            Me.equipmentAdditionalInfoPanel.Visible = True
            ' size form
            Me.Height += Me.equipmentNamePanel.Height
            ' fill divisions
            fillDivisionsCombobox()
        End If

        ' selection validation
        If selectionNameValidationControl IsNot Nothing Then
            selectionNameValidationControl.Validators.Add(selectionNameRequiredValidator)
            Me.validationManager.ValidationControls.Add(selectionNameValidationControl)
            ' show selection name panel
            Me.selectionNamePanel.Visible = True
            ' size form
            Me.Height += Me.selectionNamePanel.Height
        End If

        ' show selection type panel?
        If Me.getProcessType = True Then
            Me.selectionTypePanel.Visible = True
            Me.Height += Me.selectionTypePanel.Height
        End If

        ' Focus the correct text box...
        If projectNameValidationControl IsNot Nothing Then
            Me.projectNameTextBox.Focus()
        ElseIf equipmentNameValidationControl IsNot Nothing Then
            Me.equipmentNameTextBox.Focus()
        ElseIf selectionNameValidationControl IsNot Nothing Then
            Me.selectionNameTextBox.Focus()
        End If

    End Sub


    Private Sub fillDivisionsCombobox()
        ' clears divisions
        Me.cboDivision.Items.Clear()

        ' checks which divisions are authorized for selection
        If AppInfo.User.authority_group = user_group.employee Then
            ' shows all divisions
            Me.cboDivision.Items.Add(Business.Division.CRI.ToString.ToUpper)
            Me.cboDivision.Items.Add(Business.Division.TSI.ToString.ToUpper)
        Else
            ' shows only division logged in under
            Me.cboDivision.Items.Add(AppInfo.Division.ToString.ToUpper)
        End If

        ' selects division logged in under
        Me.cboDivision.SelectedIndex = Me.cboDivision.Items.IndexOf(AppInfo.Division.ToString.ToUpper)
        Me.cboDivision.Enabled = False

    End Sub

    Private Sub fillComboboxWithEquipmentTypesForSelectedDivision()
        Dim equipmentTypes As List(Of String)

        ' retrieves list of equipment types for the division
        equipmentTypes = Rae.DataAccess.EquipmentOptions.EquipmentDataAccess.RetrieveTypes(Me.Division.ToString.ToUpper)


        ' clears combobox
        Me.cboEquipmentType.Items.Clear()

        ' inserts spaces
        For Each typ As String In equipmentTypes
            typ = typ.Replace(" ", "")
            Me.cboEquipmentType.Items.Add(typ)
        Next

        ' selects first equipment type as default (prevents null)
        Me.cboEquipmentType.SelectedIndex = 0

        If Not IsNothing(Me.m_Equipment_Type) And Me.m_Equipment_Type <> Business.EquipmentType.NotSet Then
            Me.cboEquipmentType.Text = Me.m_Equipment_Type.ToString
            Me.cboEquipmentType.Enabled = False
        End If

    End Sub

    Private Sub fillComboboxWithProcessTypesForSelectedDivision()
        Dim user = AppInfo.User
        Dim div = AppInfo.Division

        Dim processes = New List(Of String)

        If div = TSI Then
            If user.is_rep Then
                '    processes.Add(ProcessType.AirCooledChiller.ToString)
                processes.Add(ProcessType.Condenser.ToString)
                processes.Add(ProcessType.EvaporativeCondenserChiller.ToString())
                '   processes.Add(ProcessType.SpecBuilder.ToString)
                processes.Add(ProcessType.CondensingUnit.ToString)
            Else
                processes.Add(ProcessType.AirCooledChiller.ToString)
                processes.Add(ProcessType.EvaporativeCondenserChiller.ToString())
                processes.Add(ProcessType.Condenser.ToString)
                processes.Add(ProcessType.CondensingUnit.ToString)
                processes.Add(ProcessType.AirHandler.ToString)
                processes.Add(ProcessType.SpecBuilder.ToString)
            End If

        ElseIf div = CRI Then
            processes.Add(ProcessType.Condenser.ToString)
            processes.Add(ProcessType.CondensingUnit.ToString())
            processes.Add(ProcessType.UnitCoolerBalance.ToString())

            For i As Integer = 0 To processes.Count - 1
                processes(i) = Rae.Io.Text.SpaceBeforeUpperCase(processes(i))
            Next


        ElseIf div = RSI Then
            If user.is_rep Then
            Else
                processes.Add(ProcessType.UnitCoolerBalance.ToString())
                processes.Add(ProcessType.AirCooledChiller.ToString)
                processes.Add(ProcessType.EvaporativeCondenserChiller.ToString())
                processes.Add(ProcessType.Condenser.ToString)
                processes.Add(ProcessType.CondensingUnit.ToString)
                processes.Add(ProcessType.AirHandler.ToString)
                processes.Add(ProcessType.SpecBuilder.ToString)

                For i As Integer = 0 To processes.Count - 1
                    processes(i) = Rae.Io.Text.SpaceBeforeUpperCase(processes(i))
                Next


            End If
        End If

        ' clears combobox
        Me.cboProcessTypes.Items.Clear()

        For Each process As String In processes
            Dim display_name = rae.io.text.SpaceBeforeUpperCase(process.ToString())
            cboProcessTypes.Items.Add(display_name)
        Next

        ' selects first process type as default (prevents null)
        If Me.ProcessType > 0 Then
            Me.cboProcessTypes.Text = Me.ProcessType.ToString
        Else
            Me.cboProcessTypes.SelectedIndex = 0
        End If

        cboProcessTypes.Focus()
    End Sub

#End Region

    Private Sub cboProcessTypes_SelectedIndexChanged() Handles cboProcessTypes.SelectedIndexChanged
        Dim process = cboProcessTypes.Text.Replace(" ", "")
        GetEnumValue(Of ProcessType)(process, m_Selection_Type)
    End Sub

End Class