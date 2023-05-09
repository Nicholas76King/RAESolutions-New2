Option Strict On
Option Explicit On 


Imports Entities = Rae.RaeSolutions.Business.Entities
Imports System


Public Class PhoneControl
   Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Me._phoneNum = New Entities.ContactNum()
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
   Private WithEvents phoneExampleLabel As System.Windows.Forms.Label

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Private WithEvents phoneExtensionLabel As System.Windows.Forms.Label
   Private WithEvents phoneExtensionTextBox As System.Windows.Forms.TextBox
   Private WithEvents phoneLabel As System.Windows.Forms.Label
   Private WithEvents phoneAreaCodeTextBox As System.Windows.Forms.TextBox
   Private WithEvents phoneLeftParenthesisLabel As System.Windows.Forms.Label
   Private WithEvents phoneRightParenthesisLabel As System.Windows.Forms.Label
   Private WithEvents phoneAreaCodeExampleLabel As System.Windows.Forms.Label
   Private WithEvents phone7ExampleLabel As System.Windows.Forms.Label
   Friend WithEvents phoneNumMaskedTextBox As System.Windows.Forms.MaskedTextBox
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Private WithEvents phoneExtensionExampleLabel As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.phoneExampleLabel = New System.Windows.Forms.Label
      Me.phoneExtensionLabel = New System.Windows.Forms.Label
      Me.phoneExtensionTextBox = New System.Windows.Forms.TextBox
      Me.phoneLabel = New System.Windows.Forms.Label
      Me.phoneAreaCodeTextBox = New System.Windows.Forms.TextBox
      Me.phoneLeftParenthesisLabel = New System.Windows.Forms.Label
      Me.phoneRightParenthesisLabel = New System.Windows.Forms.Label
      Me.phoneAreaCodeExampleLabel = New System.Windows.Forms.Label
      Me.phone7ExampleLabel = New System.Windows.Forms.Label
      Me.phoneExtensionExampleLabel = New System.Windows.Forms.Label
      Me.phoneNumMaskedTextBox = New System.Windows.Forms.MaskedTextBox
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.SuspendLayout()
      '
      'phoneExampleLabel
      '
      Me.phoneExampleLabel.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.phoneExampleLabel.ForeColor = System.Drawing.Color.SteelBlue
      Me.phoneExampleLabel.Location = New System.Drawing.Point(0, 24)
      Me.phoneExampleLabel.Name = "phoneExampleLabel"
      Me.phoneExampleLabel.Size = New System.Drawing.Size(44, 16)
      Me.phoneExampleLabel.TabIndex = 140
      Me.phoneExampleLabel.Text = "Example"
      Me.phoneExampleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'phoneExtensionLabel
      '
      Me.phoneExtensionLabel.BackColor = System.Drawing.Color.Transparent
      Me.phoneExtensionLabel.ForeColor = System.Drawing.Color.Black
      Me.phoneExtensionLabel.Location = New System.Drawing.Point(174, 4)
      Me.phoneExtensionLabel.Name = "phoneExtensionLabel"
      Me.phoneExtensionLabel.Size = New System.Drawing.Size(32, 24)
      Me.phoneExtensionLabel.TabIndex = 134
      Me.phoneExtensionLabel.Text = "Ext."
      Me.phoneExtensionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'phoneExtensionTextBox
      '
      Me.phoneExtensionTextBox.ForeColor = System.Drawing.Color.Black
      Me.phoneExtensionTextBox.Location = New System.Drawing.Point(208, 4)
      Me.phoneExtensionTextBox.MaxLength = 5
      Me.phoneExtensionTextBox.Name = "phoneExtensionTextBox"
      Me.phoneExtensionTextBox.Size = New System.Drawing.Size(36, 21)
      Me.phoneExtensionTextBox.TabIndex = 15
      '
      'phoneLabel
      '
      Me.phoneLabel.BackColor = System.Drawing.Color.Transparent
      Me.phoneLabel.Location = New System.Drawing.Point(0, 4)
      Me.phoneLabel.Name = "phoneLabel"
      Me.phoneLabel.Size = New System.Drawing.Size(44, 24)
      Me.phoneLabel.TabIndex = 133
      Me.phoneLabel.Text = "Phone"
      Me.phoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'phoneAreaCodeTextBox
      '
      Me.phoneAreaCodeTextBox.Location = New System.Drawing.Point(56, 4)
      Me.phoneAreaCodeTextBox.MaxLength = 3
      Me.phoneAreaCodeTextBox.Name = "phoneAreaCodeTextBox"
      Me.phoneAreaCodeTextBox.Size = New System.Drawing.Size(28, 21)
      Me.phoneAreaCodeTextBox.TabIndex = 5
      '
      'phoneLeftParenthesisLabel
      '
      Me.phoneLeftParenthesisLabel.BackColor = System.Drawing.Color.Transparent
      Me.phoneLeftParenthesisLabel.Location = New System.Drawing.Point(40, 4)
      Me.phoneLeftParenthesisLabel.Name = "phoneLeftParenthesisLabel"
      Me.phoneLeftParenthesisLabel.Size = New System.Drawing.Size(16, 24)
      Me.phoneLeftParenthesisLabel.TabIndex = 135
      Me.phoneLeftParenthesisLabel.Text = "("
      Me.phoneLeftParenthesisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'phoneRightParenthesisLabel
      '
      Me.phoneRightParenthesisLabel.BackColor = System.Drawing.Color.Transparent
      Me.phoneRightParenthesisLabel.Location = New System.Drawing.Point(84, 4)
      Me.phoneRightParenthesisLabel.Name = "phoneRightParenthesisLabel"
      Me.phoneRightParenthesisLabel.Size = New System.Drawing.Size(10, 24)
      Me.phoneRightParenthesisLabel.TabIndex = 136
      Me.phoneRightParenthesisLabel.Text = ")"
      Me.phoneRightParenthesisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'phoneAreaCodeExampleLabel
      '
      Me.phoneAreaCodeExampleLabel.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.phoneAreaCodeExampleLabel.ForeColor = System.Drawing.Color.SteelBlue
      Me.phoneAreaCodeExampleLabel.Location = New System.Drawing.Point(56, 24)
      Me.phoneAreaCodeExampleLabel.Name = "phoneAreaCodeExampleLabel"
      Me.phoneAreaCodeExampleLabel.Size = New System.Drawing.Size(32, 16)
      Me.phoneAreaCodeExampleLabel.TabIndex = 137
      Me.phoneAreaCodeExampleLabel.Text = "555"
      '
      'phone7ExampleLabel
      '
      Me.phone7ExampleLabel.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.phone7ExampleLabel.ForeColor = System.Drawing.Color.SteelBlue
      Me.phone7ExampleLabel.Location = New System.Drawing.Point(100, 24)
      Me.phone7ExampleLabel.Name = "phone7ExampleLabel"
      Me.phone7ExampleLabel.Size = New System.Drawing.Size(60, 16)
      Me.phone7ExampleLabel.TabIndex = 138
      Me.phone7ExampleLabel.Text = "123-4567"
      '
      'phoneExtensionExampleLabel
      '
      Me.phoneExtensionExampleLabel.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.phoneExtensionExampleLabel.ForeColor = System.Drawing.Color.SteelBlue
      Me.phoneExtensionExampleLabel.Location = New System.Drawing.Point(208, 24)
      Me.phoneExtensionExampleLabel.Name = "phoneExtensionExampleLabel"
      Me.phoneExtensionExampleLabel.Size = New System.Drawing.Size(36, 16)
      Me.phoneExtensionExampleLabel.TabIndex = 139
      Me.phoneExtensionExampleLabel.Text = "123"
      '
      'phoneNumMaskedTextBox
      '
      Me.phoneNumMaskedTextBox.Location = New System.Drawing.Point(100, 4)
      Me.phoneNumMaskedTextBox.Mask = "000-0000"
      Me.phoneNumMaskedTextBox.Name = "phoneNumMaskedTextBox"
      Me.phoneNumMaskedTextBox.Size = New System.Drawing.Size(62, 21)
      Me.phoneNumMaskedTextBox.TabIndex = 10
      '
      'PhoneControl
      '
      Me.BackColor = System.Drawing.Color.White
      Me.Controls.Add(Me.phoneNumMaskedTextBox)
      Me.Controls.Add(Me.phoneExampleLabel)
      Me.Controls.Add(Me.phoneExtensionLabel)
      Me.Controls.Add(Me.phoneExtensionTextBox)
      Me.Controls.Add(Me.phoneLabel)
      Me.Controls.Add(Me.phoneAreaCodeTextBox)
      Me.Controls.Add(Me.phoneLeftParenthesisLabel)
      Me.Controls.Add(Me.phoneRightParenthesisLabel)
      Me.Controls.Add(Me.phoneAreaCodeExampleLabel)
      Me.Controls.Add(Me.phone7ExampleLabel)
      Me.Controls.Add(Me.phoneExtensionExampleLabel)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "PhoneControl"
      Me.Size = New System.Drawing.Size(248, 40)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region


   Private _phoneNum As Entities.ContactNum
   Private _extensionVisible As Boolean


#Region " Properties"

   ''' <summary>Phone number entered in control.</summary>
   Public Property PhoneNum() As Entities.ContactNum
      Get
         If Me.DesignMode Then Return Nothing
         Return Me.GrabPhoneNum()
      End Get
      Set(ByVal value As Entities.ContactNum)
         If Me.DesignMode Then Exit Property
         Me.SetPhoneNum(value)
      End Set
   End Property


   ''' <summary>
   ''' Gets and sets visibility of phone number extension controls (label, textbox, and example value).
   ''' </summary>
   Public Property ExtensionVisible() As Boolean
      Get
         Return Me._extensionVisible
      End Get
      Set(ByVal Value As Boolean)
         Me._extensionVisible = Value

         ' hides/shows controls
         Me.phoneExtensionLabel.Visible = Value
         Me.phoneExtensionTextBox.Visible = Value
         Me.phoneExtensionExampleLabel.Visible = Value
      End Set
   End Property

#End Region


#Region " Methods"


   Private Sub PhoneControl_Load(ByVal sender As Object, ByVal e As EventArgs) _
   Handles MyBase.Load
      Me.ExtensionVisible = True
   End Sub


   ''' <summary>Populates PhoneNum property with values in controls</summary>
   Private Function GrabPhoneNum() As Entities.ContactNum
      Me._phoneNum.AreaCode.set_to(Me.phoneAreaCodeTextBox.Text.Trim)
      Me._phoneNum.Number.set_to(Me.phoneNumMaskedTextBox.Text.Replace("-", "").Replace(" ", "").Trim)
      Me._phoneNum.Extension.set_to(Me.phoneExtensionTextBox.Text.Trim)

      Return Me._phoneNum
   End Function


   ''' <summary>Sets phone number object properties and sets control values.</summary>
   Private Sub SetPhoneNum(ByVal phoneNum As Entities.ContactNum)
      If phoneNum Is Nothing Then Exit Sub

      ' clones phone number
      Me._phoneNum = phoneNum.Clone()

      ' sets control values
      Me.phoneAreaCodeTextBox.Text = Me._phoneNum.AreaCode.ToString
      Me.phoneNumMaskedTextBox.Text = Me._phoneNum.Number.ToString
      Me.phoneExtensionTextBox.Text = Me._phoneNum.Extension.ToString
   End Sub

#End Region

End Class

