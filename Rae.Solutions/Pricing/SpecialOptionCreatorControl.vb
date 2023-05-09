Imports Rae.Ui.Validation
Imports Rae.RaeSolutions.Business.Entities

Public Class SpecialOptionCreatorControl

#Region " Fields"

   ' for validation
   Public validationMgr As ValidationManager
   Private codeValidationCtrl As ValidationControl
   Private priceValidationCtrl As ValidationControl
   Private authorizedByValidationCtrl As ValidationControl
   Private quantityValidationCtrl As ValidationControl
   Private descriptionValidationCtrl As ValidationControl
   ' for properties
   Private m_SpecialOption As SpecialOption
   Private m_Id As item_id
   Private m_AuthorizedFor As String
   
#End Region


#Region " Properties"

   ''' <summary>
   ''' Special option that user entered.
   ''' </summary>
   Public ReadOnly Property SpecialOption() As SpecialOption
      Get
         Me.grabSpecialOption()
         Return Me.m_SpecialOption
      End Get
   End Property


   ''' <summary>
   ''' Id
   ''' </summary>
   Public ReadOnly Property Id() As item_id
      Get
         Return Me.m_Id
      End Get
   End Property


   ''' <summary>
   ''' AuthorizedFor
   ''' </summary>
   Public ReadOnly Property AuthorizedFor() As String
      Get
         Return Me.m_AuthorizedFor
      End Get
   End Property

#End Region



   ''' <summary>
   ''' Initializes control to create special option.
   ''' </summary>
   ''' <param name="id">
   ''' Equipment ID.</param>
   ''' <param name="authorizedFor">
   ''' Person who special option is authorized for</param>
   Public Sub Create(ByVal id As item_id, ByVal authorizedFor As String)
      Me.m_Id = id
      Me.m_AuthorizedFor = authorizedFor
   End Sub


   ''' <summary>
   ''' Initializes control to edit special option.
   ''' </summary>
   ''' <param name="id">
   ''' Equipment ID</param>
   ''' <param name="specialOption">
   ''' Special option to edit</param>
   Public Sub Create(ByVal id As item_id, ByVal specialOption As SpecialOption)
      Me.m_Id = id
      Me.populateSpecialOption(specialOption)
   End Sub


   Private Sub grabSpecialOption()
      If Me.m_SpecialOption Is Nothing Then
         Me.m_SpecialOption = New SpecialOption()
      End If
      With Me.m_SpecialOption
         .Code = Me.txtCode.Text.Trim
         .AuthorizedBy = Me.txtAuthorizedBy.Text.Trim
         .Description = Me.txtDescription.Text.Trim
         .Price.value = Double.Parse(Me.txtPrice.Text.Trim, Globalization.NumberStyles.Currency)
         .Quantity.set_to(Me.txtQuantity.Text)
         .EquipmentId = Me.m_Id
         .AuthorizedFor = Me.m_AuthorizedFor
      End With
   End Sub


   Private Sub populateSpecialOption(ByVal specialOption As SpecialOption)
      If specialOption Is Nothing Then
         Throw New ArgumentNullException("Cannot populate special option. Special option is null.")
      End If

      Me.m_SpecialOption = specialOption

      ' populates controls
      Me.txtCode.Text = specialOption.Code
      Me.txtAuthorizedBy.Text = specialOption.AuthorizedBy
      Me.txtDescription.Text = specialOption.Description
      Me.txtPrice.Text = specialOption.Price.ToString()
      Me.txtQuantity.Text = specialOption.Quantity.ToString()
   End Sub


   Private Sub initializeValidation()
      Me.validationMgr = New ValidationManager(Me.err)

      Me.codeValidationCtrl = New ValidationControl(Me.txtCode)
      Me.priceValidationCtrl = New ValidationControl(Me.txtPrice)
      Me.authorizedByValidationCtrl = New ValidationControl(Me.txtAuthorizedBy)
      Me.quantityValidationCtrl = New ValidationControl(Me.txtQuantity)
      Me.descriptionValidationCtrl = New ValidationControl(Me.txtDescription)

      Me.validationMgr.ValidationControls.Add(codeValidationCtrl)
      Me.validationMgr.ValidationControls.Add(priceValidationCtrl)
      Me.validationMgr.ValidationControls.Add(authorizedByValidationCtrl)
      Me.validationMgr.ValidationControls.Add(quantityValidationCtrl)
      Me.validationMgr.ValidationControls.Add(descriptionValidationCtrl)

      Dim codeReqValidator As New RequiredValidator(ErrorMessages.Required("Special option code"))
      Dim codeLengthValidator = New RegularExpressionValidator( _
         "Special option code must be 10 characters or less.", "^.{1,10}$")
      codeValidationCtrl.Validators.Add(codeReqValidator)
      codeValidationCtrl.Validators.Add(codeLengthValidator)

      Dim priceReqValidator As New RequiredValidator(ErrorMessages.Required("Price"))
      Dim priceNumValidator As New RegularExpressionValidator(ErrorMessages.Integer("Price"), rae.validation.regular_expressions.Integer)
      priceValidationCtrl.Validators.Add(priceReqValidator)
      priceValidationCtrl.Validators.Add(priceNumValidator)

      Dim authorizedByReqValidator As New RequiredValidator(ErrorMessages.Required("Authorized by"))
      authorizedByValidationCtrl.Validators.Add(authorizedByReqValidator)

      Dim quantityReqValidator As New RequiredValidator(ErrorMessages.Required("Quantity"))
      Dim quantityNumValidator As New RegularExpressionValidator(ErrorMessages.PositiveInteger("Quantity"), rae.validation.regular_expressions.positive_integer)
      Me.quantityValidationCtrl.Validators.Add(quantityReqValidator)
      Me.quantityValidationCtrl.Validators.Add(quantityNumValidator)

      Dim descriptionReqValidator As New RequiredValidator(ErrorMessages.Required("Description"))
      Dim descriptionLengthValidator As New RegularExpressionValidator( _
         "Special option description must be less than 255 characters.", "^.{1,255}$")
      Me.descriptionValidationCtrl.Validators.Add(descriptionReqValidator)
      descriptionValidationCtrl.Validators.Add(descriptionLengthValidator)
   End Sub


#Region " Validation event handlers"

   Private Sub SpecialOptionCreatorControl_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load
      Me.initializeValidation()
   End Sub

   Private Sub txtCode_Leave(ByVal sender As Object, ByVal e As EventArgs) _
   Handles txtCode.Leave
      Me.codeValidationCtrl.Validate()
   End Sub

   Private Sub txtAuthorizedBy_Leave(ByVal sender As Object, ByVal e As EventArgs) _
   Handles txtAuthorizedBy.Leave
      Me.authorizedByValidationCtrl.Validate()
   End Sub

   Private Sub txtDescription_Leave(ByVal sender As Object, ByVal e As EventArgs) _
   Handles txtDescription.Leave
      Me.descriptionValidationCtrl.Validate()
   End Sub

   Private Sub txtPrice_Leave(ByVal sender As Object, ByVal e As EventArgs) _
   Handles txtPrice.Leave
      Me.priceValidationCtrl.Validate()
   End Sub

   Private Sub txtQuantity_Leave(ByVal sender As Object, ByVal e As EventArgs) _
   Handles txtQuantity.Leave
      Me.quantityValidationCtrl.Validate()
   End Sub

#End Region

End Class
