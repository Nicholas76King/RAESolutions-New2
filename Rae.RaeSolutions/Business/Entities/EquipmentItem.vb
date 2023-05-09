Option Strict On
Option Explicit On

Imports Rae.RaeSolutions.DataAccess.Projects
Imports System

Namespace Rae.RaeSolutions.Business.Entities

    ''' <summary>Contains information about equipment</summary>
    Public MustInherit Class EquipmentItem
        Inherits RevisionBase
        Implements System.ICloneable

#Region " Events"

        Public Event Saved As EventHandler(Of EquipmentItem, EventArgs)

        Protected Overridable Sub onSaved()
            If Me.SavedEvent IsNot Nothing Then
                RaiseEvent Saved(Me, EventArgs.Empty)
            End If
        End Sub


        Public Event RevisionChanged As EventHandler(Of EquipmentItem, ValueChangedEventArgs(Of Single))

        Protected Overridable Sub onRevisionChanged(ByVal e As ValueChangedEventArgs(Of Single))
            If Me.RevisionChangedEvent IsNot Nothing Then _
               RaiseEvent RevisionChanged(Me, e)
        End Sub


        Public Event Removed As EventHandler(Of EquipmentItem, EventArgs)

        Protected Overridable Function onRemoved() As String
            If Me.RemovedEvent IsNot Nothing Then
                RaiseEvent Removed(Me, EventArgs.Empty)
                Return Me.id.Id
            Else
                Return ""
            End If
        End Function

#End Region


        Private _revision As Single

#Region " Properties"

        ''' <summary>Unique ID.</summary>
        ''' <remarks>Setter adds synchronizing functionality to base Id property</remarks>
        Overrides Property id As item_id
            Get
                Return MyBase.id
            End Get
            Set(ByVal value As item_id)
                MyBase.id = value
                options.Equipment.setId(value)
            End Set
        End Property

        Property series As String
        Property model_without_series As String

        ''' <summary>entire model including series</summary>
        Overridable ReadOnly Property model As String
            Get
                Return series & model_without_series
            End Get
        End Property

        Property custom_model As String
        Property division As Division
        Property type As EquipmentType
        Property project_revision As Integer
        Property options As EquipmentOptionList
        ''' <summary>Obsolete options are no longer available or have replacement option codes</summary>
        Property obsolete_options As EquipmentOptionList
        Property special_options As SpecialOptionList
        Property tag As String
        Property special_instructions As String
        Property pricing As equipment_pricing
        Property common_specs As CommonSpecifications
        Property is_included As Boolean
        Property ForceSave As Boolean = False


        Overridable ReadOnly Property validation_status As ValidationStatus
            Get
                Dim status As ValidationStatus

                ' if series and model are not null, and are not "Choose"
                If Not (String.IsNullOrEmpty(series) OrElse String.IsNullOrEmpty(model_without_series)) _
                AndAlso Not (Me.series = "Choose" OrElse Me.model_without_series = "Choose") Then
                    status = validation_status.Valid
                Else
                    status = validation_status.Invalid
                End If

                Return status
            End Get
        End Property

        Property revision As Single
            Get
                Return _revision
            End Get
            Set(ByVal value As Single)
                Dim e As New ValueChangedEventArgs(Of Single)(_revision, value)

                _revision = value
                onRevisionChanged(e)
                special_options.Revision = value
                setOptionsRevision(value)
            End Set
        End Property

        ReadOnly Property latest_revision As Single
            Get
                Return EquipmentDa.RetrieveLatestRevision(Me.id.Id)
            End Get
        End Property

        ReadOnly Property is_latest_revision As Boolean
            Get
                Return latest_revision = revision
            End Get
        End Property

        ''' <summary>Gets whether this equipment exists in the data source.</summary>
        ReadOnly Property exists_in_data_source As ExistenceStatus
            Get
                Return EquipmentDa.Exists(Me.id.Id, Me.revision)
            End Get
        End Property

        ''' <summary>Until a somewhat major re-factor, use temporarily to explicitly tie a piece of rating equipment to pricing equipment.  WHen EquipmentItem is saved, will check if this exists and save serialized version to db.</summary>
        Property RatingEquipment() As Object
            Get
                Return _rating
            End Get
            Set(ByVal value As Object)
                _rating = value
            End Set
        End Property
        Protected _rating As Object

#End Region


#Region " Public methods"

        ''' <summary>Constructs equipment item. Adds constructed equipment to project. Generates a new ID.</summary>
        Sub New(ByVal name As String, ByVal division As Division, ByVal equipmentType As EquipmentType, _
        ByVal username As String, ByVal password As String, ByVal parent As project_manager)
            Me.initialize()

            id = New item_id(username, password)
            Me.name = name
            Me.division = division
            type = equipmentType
            ProjectManager = parent

            ProjectManager.Equipment.Add(Me)
        End Sub

        ''' <summary>Constructs equipment item. Sets existing ID.</summary>
        ''' <remarks>This is used by the Clone method.</remarks>
        Protected Sub New(ByVal name As String, ByVal division As Division, ByVal equipmentType As EquipmentType, _
        ByVal id As item_id, ByVal parent As project_manager)
            Me.initialize()

            Me.id = id
            Me.name = name
            Me.division = division

            'If division = Business.Division.TSI AndAlso equipmentType = Business.EquipmentType.CondensingUnit Then
            '    Me.common_specs.ControlVoltage.Voltage.set_to(115)
            'End If

            type = equipmentType
            ProjectManager = parent
        End Sub

        ''' <summary>Loads equipment based on ID.</summary>
        ''' <param name="id">ID of equipment to load.</param>
        ''' <returns>Loaded equipment.</returns>
        Overloads Shared Function Load(ByVal id As String) As EquipmentItem
            ' retrieves equipment from data source
            Return EquipmentDa.Retrieve(id)
        End Function

        Sub remove()
            EquipmentDa.Delete(Me.id.Id, Me.type)
            Me.onRemoved()
        End Sub

        ''' <summary>Series (30A0CD) and model (30) ex 30A0CD30</summary>   
        Overrides Function ToString() As String
            Return ConvertNull.ToString(series) & ConvertNull.ToString(model_without_series)
        End Function

#Region " Unimplemented public methods"

        ''' <summary>Not implemented. Inheritors must override.</summary>
        Overrides Sub Load()
        End Sub


        ''' <summary>Not implemented. Inheritors must override.</summary>
        Overrides Sub Save()
        End Sub


        ''' <summary>Not implemented. Inheriting classes should shadow.</summary>
        Function Clone() As Object Implements System.ICloneable.Clone
        End Function

#End Region

#End Region


#Region " Non-public methods"

        ''' <summary>Initializes objects in equipment</summary>
        ''' <remarks>Helps prevent nulls from unconstructed objects</remarks>
        Protected Overrides Sub initialize()
            MyBase.initialize()

            options = New EquipmentOptionList(Me)
            pricing = New equipment_pricing()
            common_specs = New CommonSpecifications()
            special_options = New SpecialOptionList()
            obsolete_options = New EquipmentOptionList(Me)
        End Sub

        Protected Function is_equal_to(ByVal other As EquipmentItem) As Boolean
            If other Is Nothing Then Return False


            If other.ForceSave Then  ' force a save
                ' other.ForceSave = False
                Return False
            End If


            If name = other.name _
            AndAlso id.Equals(other.id) _
            AndAlso revision = other.revision _
            AndAlso model_without_series = other.model_without_series _
            AndAlso series = other.series _
            AndAlso custom_model = other.custom_model _
            AndAlso type = other.type _
            AndAlso special_instructions = other.special_instructions _
            AndAlso tag = other.tag _
            AndAlso is_included = other.is_included _
            AndAlso metadata.Equals(other.metadata) _
            AndAlso common_specs.Equals(other.common_specs) _
            AndAlso options.Equals(other.options) _
            AndAlso special_options.Equals(other.special_options) _
            AndAlso obsolete_options.Equals(other.obsolete_options) _
            AndAlso pricing.equals(other.pricing) Then
                Return True
            Else
                Return False
            End If
        End Function

        Protected Sub copy_base(ByVal other As EquipmentItem)
            With other
                id = New item_id(.id.Id)
                name = .name
                series = .series
                model_without_series = .model_without_series
                custom_model = .custom_model
                metadata = .metadata.Clone
                common_specs = .common_specs.Clone()
                tag = .tag
                special_instructions = .special_instructions
                options = .options.Clone()
                obsolete_options = .obsolete_options.Clone
                pricing = .pricing.Clone()
                ProjectManager = .ProjectManager
                special_options = .special_options.Clone()
                is_included = .is_included
                revision = .revision
                ForceSave = .ForceSave
            End With
        End Sub

        ''' <summary>Sets the revision of every option in option list.</summary>
        ''' <param name="revision">Revision to set options to.</param>
        Private Sub setOptionsRevision(ByVal revision As Single)
            For Each op As EquipmentOption In Me.options
                op.Revision = revision
                op.Equipment = Me
            Next
        End Sub

        Private Sub setId(ByVal id As item_id)
            MyBase.id = id
        End Sub

#End Region

    End Class

End Namespace
