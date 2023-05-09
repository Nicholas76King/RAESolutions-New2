Imports System.ComponentModel

Namespace Rae.DataAccess.EquipmentOptions



    Public Class OptionComparer
        Implements System.Collections.Generic.IComparer(Of [Option])

        Public Function Compare(ByVal x As [Option], ByVal y As [Option]) As Integer Implements System.Collections.Generic.IComparer(Of [Option]).Compare
            '    Return String.Compare(x.Code, y.Code) Or CInt(x.Price < y.Price)
            '   Return String.Compare(x.Description, y.Description) Or CInt(x.Price < y.Price)

            Select Case String.Compare(x.Description, y.Description)
                Case -1
                    Return -1
                Case 0
                    If x.Price < y.Price Then
                        Return -1
                    ElseIf x.Price > x.Price Then
                        Return 1
                    Else
                        Return 0
                    End If
                Case 1
                    Return 1
            End Select

        End Function
    End Class


    <System.CLSCompliant(True)> _
    Public Class [Option]

#Region " Declarations"
        Private _assignedId, _masterId, _quantity, _voltage As Integer
        Private _code, _description, _category, _per As String
        Private _price As Double
        Private _isVoltageDependent, _isStandard, _contactFactory, _isQuantityReadOnly, _isDependentCommonOption As Boolean
        Private _equipment As Equipment

        ' option code value that indicates the base list price of the equipment
        Friend Shared BASE_LIST As String = "BASELIST"

        ' price codes
        '
        ''' <summary>Standard option</summary>
        Public Const STANDARD As Double = 999999
        ''' <summary>Must contact factory for price</summary>
        Public Const CONTACT_FACTORY As Double = 999998
        ''' <summary>Common (same across entire series) option whose price is dependent upon another selected option</summary>
        Public Const COMMON_DEPENDENT As Double = 999997
#End Region


#Region " Properties"

        ''' <summary>ID from EquipmentOptions database's EquipmentOptions table</summary>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Property PricingId As Integer
            Get
                Return _assignedId
            End Get
            Set(ByVal value As Integer)
                _assignedId = value
            End Set
        End Property

        ''' <summary>ID from Options database's MasterOptions table</summary>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Property MasterId As Integer
            Get
                Return _masterId
            End Get
            Set(ByVal value As Integer)
                _masterId = value
            End Set
        End Property

        ''' <summary>Option code</summary>
        Property Code As String
            Get
                Return _code
            End Get
            Set(ByVal Value As String)
                _code = Value
            End Set
        End Property

        ''' <summary>Description of option</summary>
        Property Description As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Property Details As String
            Get
                Return _details
            End Get
            Set(ByVal value As String)
                _details = value
            End Set
        End Property
        Private _details As String

        ''' <summary>Category that option is in</summary>
        Property Category As String
            Get
                Return _category
            End Get
            Set(ByVal Value As String)
                _category = Value
            End Set
        End Property

        ''' <summary>Price of option</summary>
        ''' <remarks>This property (not the private field) must be used to set price, if you want the price to be interpreted</remarks>
        Property Price As Double
            Get
                Return _price
            End Get
            Set(ByVal value As Double)
                _price = value
                interpretPrice()
            End Set
        End Property

        ''' <summary>Quantity of this option for equipment</summary>
        ''' <remarks>This property (not private field) must be used to set quantity, if you want the quantity to be interpreted</remarks>
        Property Quantity As Integer
            Get
                Return _quantity
            End Get
            Set(ByVal value As Integer)
                _quantity = value
                interpretQuantity()
            End Set
        End Property


        ''' <summary>Option quantity can be per unit or per system</summary>
        Property Per As String
            Get
                Return _per
            End Get
            Set(ByVal value As String)
                _per = value
            End Set
        End Property

        ''' <summary>Voltage that the price corresponds to</summary>
        ''' <remarks>This property (not private field) must be used to set voltage, if you want voltage to be interpreted</remarks>
        Property Voltage As Integer
            Get
                Return _voltage
            End Get
            Set(ByVal value As Integer)
                _voltage = value
                interpretVoltage()
            End Set
        End Property


#Region " Interpreted properties"

        ''' <summary>Indicates whether option price is dependent upon voltage</summary>
        ReadOnly Property IsVoltageDependent As Boolean
            Get
                Return _isVoltageDependent
            End Get
        End Property

        ''' <summary>Indicates whether option is standard with the current equipment</summary>
        ReadOnly Property IsStandard As Boolean
            Get
                Return _isStandard
            End Get
        End Property

        ''' <summary>Indicates whether the factory must be contacted in order to determine option's price</summary>
        ReadOnly Property ContactFactory As Boolean
            Get
                Return _contactFactory
            End Get
        End Property

        ''' <summary>Indicates whether option's price is dependent upon another option</summary>
        ReadOnly Property IsDependentCommonOption As Boolean
            Get
                Return _isDependentCommonOption
            End Get
        End Property

        ''' <summary>Indicates whether option's quantity is readonly (mandated).</summary>
        ReadOnly Property IsQuantityReadOnly As Boolean
            Get
                Return _isQuantityReadOnly
            End Get
        End Property

#End Region

        ''' <summary>Equipment that the option's price is based on</summary>
        Overridable Property Equipment As Rae.DataAccess.EquipmentOptions.Equipment
            Get
                Return _equipment
            End Get
            Set(ByVal value As Rae.DataAccess.EquipmentOptions.Equipment)
                _equipment = value
            End Set
        End Property

#End Region


#Region " Public methods"

        Sub New()
            _equipment = New Equipment
        End Sub


        ''' <summary>Imports information from master option</summary>
        Sub Import(ByVal op As master_option)
            Code = op.code
            Description = op.description
            Category = op.category
            Voltage = op.voltage
            MasterId = op.id
        End Sub


        Overrides Function ToString() As String
            Dim representation = Code
            If Description IsNot Nothing Then
                If Code IsNot Nothing Then _
                   representation &= " - "
                representation &= Description
            End If

            Return representation
        End Function

#End Region


#Region " Private methods"

        Private Sub interpretQuantity()
            ' interprets quantity (0 - user-specified, > 0 - mandated quantity)
            If _quantity > 0 Then
                ' mandates quantity
                _isQuantityReadOnly = True
            ElseIf _quantity = 0 Then
                _isQuantityReadOnly = False
            End If
        End Sub

        Private Sub interpretVoltage()
            ' interprets voltage (0 - voltage independent; > 0 - voltage dependent
            If _voltage > 0 Then
                _isVoltageDependent = True
            Else
                _isVoltageDependent = False
            End If
        End Sub

        Private Sub interpretPrice()
            ' standard option
            If _price = STANDARD Then
                _isStandard = True
            Else
                _isStandard = False
            End If

            ' contact factory
            If _price = CONTACT_FACTORY Then
                ' price is only available by contacting the factory
                _contactFactory = True
                ' price is not actually zero; it is undetermined
                _price = 0
            Else
                _contactFactory = False
            End If

            ' dependent common option
            If _price = COMMON_DEPENDENT Then
                ' common options have the same price across an entire series
                ' price is dependent upon the selection of other options
                _isDependentCommonOption = True
                ' price is not actually zero; it is undetermined until the options it is dependent upon are selected
                _price = 0
            Else
                _isDependentCommonOption = False
            End If
        End Sub

#End Region

    End Class

End Namespace