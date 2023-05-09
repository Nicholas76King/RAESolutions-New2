Imports CondenserProcessDa = Rae.RaeSolutions.DataAccess.Projects.CondenserProcessDA


Namespace Rae.RaeSolutions.Business.Entities

   ''' <summary>
   ''' Condenser process.
   ''' </summary>
   ''' <history start="2006/08/01">
   ''' Created
   ''' </history>
   Public Class CondenserProcessItem
      Inherits ProcessItem

      'Implements RAE.Core.ICopyable(Of CondenserProcessItem)
      'Implements RAE.Core.ICloneable(Of CondenserProcessItem)
      '  Implements System.IEquatable(Of CondenserProcessItem)

      Private Equipment As EquipmentItemList


#Region " Properties"

      Private m_Refrigerant As String
      ''' <summary>
      ''' Refrigrant
      ''' </summary>
      Public Property Refrigerant() As String
         Get
            Return Me.m_Refrigerant
         End Get
         Set(ByVal value As String)
            Me.m_Refrigerant = value
         End Set
      End Property

      Private m_CoilWidth As Double
      ''' <summary>
      ''' CoilWidth
      ''' </summary>
      Public Property CoilWidth() As Double
         Get
            Return Me.m_CoilWidth
         End Get
         Set(ByVal value As Double)
            Me.m_CoilWidth = value
         End Set
      End Property

      Private m_CoilLength As Double
      ''' <summary>
      ''' CoilLength
      ''' </summary>
      Public Property CoilLength() As Double
         Get
            Return Me.m_CoilLength
         End Get
         Set(ByVal value As Double)
            Me.m_CoilLength = value
         End Set
      End Property

      Private m_Altitude As Double
      ''' <summary>
      ''' Altitude
      ''' </summary>
      Public Property Altitude() As Double
         Get
            Return Me.m_Altitude
         End Get
         Set(ByVal value As Double)
            Me.m_Altitude = value
         End Set
      End Property

      Private m_SubCooling As Boolean
      ''' <summary>
      ''' SubCooling
      ''' </summary>
      Public Property SubCooling() As Boolean
         Get
            Return Me.m_SubCooling
         End Get
         Set(ByVal value As Boolean)
            Me.m_SubCooling = value
         End Set
      End Property

      Private m_SubCoolingPercentage As Double
      ''' <summary>
      ''' SubCoolingPercentage
      ''' </summary>
      Public Property SubCoolingPercentage() As Double
         Get
            Return Me.m_SubCoolingPercentage
         End Get
         Set(ByVal value As Double)
            Me.m_SubCoolingPercentage = value
         End Set
      End Property

      Private m_AmbientTemp As Double
      ''' <summary>
      ''' AmbientTemp
      ''' </summary>
      Public Property AmbientTemp() As Double
         Get
            Return Me.m_AmbientTemp
         End Get
         Set(ByVal value As Double)
            Me.m_AmbientTemp = value
         End Set
      End Property

      Private m_TD As Double
      ''' <summary>
      ''' TD
      ''' </summary>
      Public Property TD() As Double
         Get
            Return Me.m_TD
         End Get
         Set(ByVal value As Double)
            Me.m_TD = value
         End Set
      End Property

      Private m_Fan As String
      ''' <summary>
      ''' Fan
      ''' </summary>
      Public Property Fan() As String
         Get
            Return Me.m_Fan
         End Get
         Set(ByVal value As String)
            Me.m_Fan = value
         End Set
      End Property

      Private m_NumFans As Integer
      ''' <summary>
      ''' NumFans
      ''' </summary>
      Public Property NumFans() As Integer
         Get
            Return Me.m_NumFans
         End Get
         Set(ByVal value As Integer)
            Me.m_NumFans = value
         End Set
      End Property

      Private m_CFM As Double
      ''' <summary>
      ''' CFM
      ''' </summary>
      Public Property CFM() As Double
         Get
            Return Me.m_CFM
         End Get
         Set(ByVal value As Double)
            Me.m_CFM = value
         End Set
      End Property

      Private m_CoilDesc As String
      ''' <summary>
      ''' CoilDesc
      ''' </summary>
      Public Property CoilDesc() As String
         Get
            Return Me.m_CoilDesc
         End Get
         Set(ByVal value As String)
            Me.m_CoilDesc = value
         End Set
      End Property

      Private m_ExtStaticPressure As Double
      ''' <summary>
      ''' ExtStaticPressure
      ''' </summary>
      Public Property ExtStaticPressure() As Double
         Get
            Return Me.m_ExtStaticPressure
         End Get
         Set(ByVal value As Double)
            Me.m_ExtStaticPressure = value
         End Set
      End Property


      Private m_CatalogRating As Boolean
      ''' <summary>
      ''' CatalogRating
      ''' </summary>
      Public Property CatalogRating() As Boolean
         Get
            Return Me.m_CatalogRating
         End Get
         Set(ByVal value As Boolean)
            Me.m_CatalogRating = value
         End Set
      End Property


      Private m_ModelDescription As String
      ''' <summary>
      ''' ModelDescription
      ''' </summary>
      Public Property ModelDescription() As String
         Get
            Return Me.m_ModelDescription
         End Get
         Set(ByVal value As String)
            Me.m_ModelDescription = value
         End Set
      End Property


#End Region


#Region " Public methods"

      ''' <summary>
      ''' Constructs a condenser process that already exists in the data source based on the ID.
      ''' Automatically loads the process from the data source.
      ''' </summary>
      ''' <param name="id">
      ''' ID of the condenser process to load.
      ''' </param>
      Public Sub New(ByVal id As item_id)
         Me.initialize()
         Me.id = id
      End Sub

      ''' <summary>
      ''' Constructs a condenser process that already exists in the data source based on the ID.
      ''' Automatically loads the process from the data source.
      ''' </summary>
      ''' <param name="id">
      ''' ID of the condenser process to load.
      ''' </param>
      ''' <param name="RevNumber">
      ''' Revision number of the condenser process to load.
      ''' </param>
      Public Sub New(ByVal id As item_id, ByVal RevNumber As Integer)
         Me.initialize()
         Me.id = id
         Me.Revision = RevNumber
      End Sub

      ''' <summary>
      ''' Constructs a new condenser process with the specified name.
      ''' Generates a new ID.
      ''' </summary>
      ''' <param name="name">
      ''' Name of the process.
      ''' </param>
      ''' <param name="createdBy">
      ''' Username of the person who created the process.
      ''' </param>
      ''' <param name="password">
      ''' Password of the person who created the process.
      ''' </param>
      ''' <param name="parent">
      ''' Parent project manager that process should be included in.
      ''' </param>
      Public Sub New(ByVal name As String, ByVal createdBy As String, ByVal password As String, ByVal parent As project_manager)
         Me.initialize()
         Me.name = name
         Me.id = New item_id(createdBy, password)
         Me.ProjectManager = parent
      End Sub


      ''' <summary>
      ''' Constructs a new condenser process with the specified name.
      ''' Used when making a clone.
      ''' </summary>
      ''' <param name="name">
      ''' Name of process.
      ''' </param>
      ''' <param name="id">
      ''' ID of process.
      ''' </param>
      Public Sub New(ByVal name As String, ByVal id As item_id)
         Me.initialize()
         Me.name = name
         Me.id = id
      End Sub

      Public Sub New(ByVal condenserEquipment As CondenserEquipmentItem)
         Me.New(condenserEquipment.name, condenserEquipment.id.Username, condenserEquipment.id.Password, condenserEquipment.ProjectManager)
         Me.initialize()

         Static equipFlag As Boolean = False

         ' sets common properties
         '
         Me.Series = condenserEquipment.series
         Me.Model = Me.Series.Replace("10A0", "10AO") & "-" & condenserEquipment.model_without_series
         Me.ModelDescription = condenserEquipment.custom_model

         Me.AssociatedEquipmentIDs.Add(condenserEquipment.id)

         If condenserEquipment.Specs.AmbientTemp.has_value Then
            Me.AmbientTemp = condenserEquipment.Specs.AmbientTemp.value
         End If
         If condenserEquipment.Specs.TempDifference.has_value Then
            Me.TD = condenserEquipment.Specs.TempDifference.value
         End If

         If Not String.IsNullOrEmpty(condenserEquipment.Specs.Refrigerant) Then
            Me.Refrigerant = condenserEquipment.Specs.Refrigerant
         End If

         Me.SubCooling = condenserEquipment.Specs.SubCooling

         If condenserEquipment.common_specs.Altitude.has_value Then
            Me.Altitude = condenserEquipment.common_specs.Altitude.value
         End If

         'prevent null ref
         If equipFlag = False Then
            Me.Equipment = New EquipmentItemList
            equipFlag = True
         End If

         ' associate equipment w/ process
         Me.Equipment.Add(condenserEquipment)

         'Me.Save()
         'link process and equipment in a database table
         Rae.RaeSolutions.DataAccess.Projects.ProcessEquipDA.Create(Me.id.ToString, condenserEquipment.id.ToString)
      End Sub


      ''' <summary>
      ''' Loads condenser process based on ID. 
      ''' ID must be set before calling this method.
      ''' (Optionally revision can be set to pull specific revision.)
      ''' </summary>
      Public Overrides Sub Load()
         Dim process As CondenserProcessItem
         If Me.Revision > -1 Then
            process = CondenserProcessDa.Retrieve(Me.id, Me.Revision)
         Else
            process = CondenserProcessDa.Retrieve(Me.id)
         End If
         Me.Copy(process)
      End Sub

#End Region


      ''' <summary>
      ''' Initializes objects. Prevents NullReference.
      ''' </summary>
      Protected Overrides Sub initialize()
         MyBase.initialize()
      End Sub


      Protected Overrides Sub Finalize()
         MyBase.Finalize()
      End Sub
   End Class
End Namespace
