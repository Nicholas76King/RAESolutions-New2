Option Strict On
Option Explicit On 


Imports Rae.RaeSolutions.Business.Entities
Imports Rae.RaeSolutions.DataAccess
Imports System.Data





Public Class AddressControl
   Inherits System.Windows.Forms.UserControl


#Region " Windows Form Designer generated code "

   Public Sub New()
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
   Friend WithEvents cboState As System.Windows.Forms.ComboBox
   Friend WithEvents lblAddress1Required As System.Windows.Forms.Label
   Friend WithEvents lblZip5Example As System.Windows.Forms.Label
   Friend WithEvents lblZipExample As System.Windows.Forms.Label
   Friend WithEvents lblZip4Example As System.Windows.Forms.Label
   Friend WithEvents lblCity As System.Windows.Forms.Label
   Friend WithEvents txtCity As System.Windows.Forms.TextBox
   Friend WithEvents lblState As System.Windows.Forms.Label
   Friend WithEvents lblZip As System.Windows.Forms.Label
   Friend WithEvents txtZip5 As System.Windows.Forms.TextBox
   Friend WithEvents txtZip4 As System.Windows.Forms.TextBox
   Friend WithEvents lblCityRequired As System.Windows.Forms.Label
   Friend WithEvents lblStateRequired As System.Windows.Forms.Label
   Friend WithEvents tip As System.Windows.Forms.ToolTip
   Friend WithEvents lblLine2 As System.Windows.Forms.Label
   Friend WithEvents txtLine2 As System.Windows.Forms.TextBox
   Friend WithEvents lblLine1 As System.Windows.Forms.Label
   Friend WithEvents txtLine1 As System.Windows.Forms.TextBox
   Friend WithEvents lblZipDash As System.Windows.Forms.Label
   Friend WithEvents lblZip5Required As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.lblAddress1Required = New System.Windows.Forms.Label
      Me.cboState = New System.Windows.Forms.ComboBox
      Me.lblLine2 = New System.Windows.Forms.Label
      Me.txtLine2 = New System.Windows.Forms.TextBox
      Me.lblZip5Example = New System.Windows.Forms.Label
      Me.lblZipExample = New System.Windows.Forms.Label
      Me.lblZip4Example = New System.Windows.Forms.Label
      Me.lblZipDash = New System.Windows.Forms.Label
      Me.lblCity = New System.Windows.Forms.Label
      Me.txtCity = New System.Windows.Forms.TextBox
      Me.lblLine1 = New System.Windows.Forms.Label
      Me.txtLine1 = New System.Windows.Forms.TextBox
      Me.lblState = New System.Windows.Forms.Label
      Me.lblZip = New System.Windows.Forms.Label
      Me.txtZip5 = New System.Windows.Forms.TextBox
      Me.txtZip4 = New System.Windows.Forms.TextBox
      Me.lblCityRequired = New System.Windows.Forms.Label
      Me.lblZip5Required = New System.Windows.Forms.Label
      Me.lblStateRequired = New System.Windows.Forms.Label
      Me.tip = New System.Windows.Forms.ToolTip(Me.components)
      Me.SuspendLayout()
      '
      'lblAddress1Required
      '
      Me.lblAddress1Required.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAddress1Required.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblAddress1Required.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblAddress1Required.Location = New System.Drawing.Point(280, 4)
      Me.lblAddress1Required.Name = "lblAddress1Required"
      Me.lblAddress1Required.Size = New System.Drawing.Size(16, 16)
      Me.lblAddress1Required.TabIndex = 125
      Me.lblAddress1Required.Text = "R"
      '
      'cboState
      '
      Me.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboState.Location = New System.Drawing.Point(60, 100)
      Me.cboState.Name = "cboState"
      Me.cboState.Size = New System.Drawing.Size(48, 21)
      Me.cboState.TabIndex = 4
      Me.tip.SetToolTip(Me.cboState, "State")
      '
      'lblLine2
      '
      Me.lblLine2.BackColor = System.Drawing.Color.Transparent
      Me.lblLine2.Location = New System.Drawing.Point(0, 36)
      Me.lblLine2.Name = "lblLine2"
      Me.lblLine2.Size = New System.Drawing.Size(48, 24)
      Me.lblLine2.TabIndex = 115
      Me.lblLine2.Text = "Line 2"
      Me.lblLine2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLine2
      '
      Me.txtLine2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtLine2.Location = New System.Drawing.Point(60, 36)
      Me.txtLine2.Name = "txtLine2"
      Me.txtLine2.Size = New System.Drawing.Size(220, 21)
      Me.txtLine2.TabIndex = 2
      Me.txtLine2.Text = ""
      Me.tip.SetToolTip(Me.txtLine2, "Address line 2")
      '
      'lblZip5Example
      '
      Me.lblZip5Example.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblZip5Example.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblZip5Example.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblZip5Example.Location = New System.Drawing.Point(188, 120)
      Me.lblZip5Example.Name = "lblZip5Example"
      Me.lblZip5Example.Size = New System.Drawing.Size(40, 16)
      Me.lblZip5Example.TabIndex = 110
      Me.lblZip5Example.Text = "12345"
      '
      'lblZipExample
      '
      Me.lblZipExample.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblZipExample.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblZipExample.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblZipExample.Location = New System.Drawing.Point(124, 120)
      Me.lblZipExample.Name = "lblZipExample"
      Me.lblZipExample.Size = New System.Drawing.Size(52, 16)
      Me.lblZipExample.TabIndex = 111
      Me.lblZipExample.Text = "Example"
      Me.lblZipExample.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'lblZip4Example
      '
      Me.lblZip4Example.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblZip4Example.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblZip4Example.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblZip4Example.Location = New System.Drawing.Point(244, 120)
      Me.lblZip4Example.Name = "lblZip4Example"
      Me.lblZip4Example.Size = New System.Drawing.Size(36, 16)
      Me.lblZip4Example.TabIndex = 112
      Me.lblZip4Example.Text = "1234"
      '
      'lblZipDash
      '
      Me.lblZipDash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblZipDash.BackColor = System.Drawing.Color.Transparent
      Me.lblZipDash.Location = New System.Drawing.Point(232, 112)
      Me.lblZipDash.Name = "lblZipDash"
      Me.lblZipDash.Size = New System.Drawing.Size(10, 4)
      Me.lblZipDash.TabIndex = 108
      Me.lblZipDash.Text = "-"
      Me.lblZipDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblCity
      '
      Me.lblCity.BackColor = System.Drawing.Color.Transparent
      Me.lblCity.Location = New System.Drawing.Point(0, 68)
      Me.lblCity.Name = "lblCity"
      Me.lblCity.Size = New System.Drawing.Size(48, 24)
      Me.lblCity.TabIndex = 94
      Me.lblCity.Text = "City"
      Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCity
      '
      Me.txtCity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCity.Location = New System.Drawing.Point(60, 68)
      Me.txtCity.Name = "txtCity"
      Me.txtCity.Size = New System.Drawing.Size(220, 21)
      Me.txtCity.TabIndex = 3
      Me.txtCity.Text = ""
      Me.tip.SetToolTip(Me.txtCity, "City")
      '
      'lblLine1
      '
      Me.lblLine1.BackColor = System.Drawing.Color.Transparent
      Me.lblLine1.Location = New System.Drawing.Point(0, 4)
      Me.lblLine1.Name = "lblLine1"
      Me.lblLine1.Size = New System.Drawing.Size(48, 24)
      Me.lblLine1.TabIndex = 93
      Me.lblLine1.Text = "Line 1"
      Me.lblLine1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLine1
      '
      Me.txtLine1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtLine1.Location = New System.Drawing.Point(60, 4)
      Me.txtLine1.Name = "txtLine1"
      Me.txtLine1.Size = New System.Drawing.Size(220, 21)
      Me.txtLine1.TabIndex = 1
      Me.txtLine1.Text = ""
      Me.tip.SetToolTip(Me.txtLine1, "Address line 1")
      '
      'lblState
      '
      Me.lblState.BackColor = System.Drawing.Color.Transparent
      Me.lblState.Location = New System.Drawing.Point(0, 100)
      Me.lblState.Name = "lblState"
      Me.lblState.Size = New System.Drawing.Size(48, 24)
      Me.lblState.TabIndex = 96
      Me.lblState.Text = "State"
      Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblZip
      '
      Me.lblZip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblZip.BackColor = System.Drawing.Color.Transparent
      Me.lblZip.Location = New System.Drawing.Point(140, 100)
      Me.lblZip.Name = "lblZip"
      Me.lblZip.Size = New System.Drawing.Size(36, 24)
      Me.lblZip.TabIndex = 97
      Me.lblZip.Text = "Zip"
      Me.lblZip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtZip5
      '
      Me.txtZip5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtZip5.Location = New System.Drawing.Point(188, 100)
      Me.txtZip5.MaxLength = 5
      Me.txtZip5.Name = "txtZip5"
      Me.txtZip5.Size = New System.Drawing.Size(44, 21)
      Me.txtZip5.TabIndex = 5
      Me.txtZip5.Text = ""
      Me.tip.SetToolTip(Me.txtZip5, "5 digit zip code")
      '
      'txtZip4
      '
      Me.txtZip4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtZip4.Location = New System.Drawing.Point(244, 100)
      Me.txtZip4.MaxLength = 4
      Me.txtZip4.Name = "txtZip4"
      Me.txtZip4.Size = New System.Drawing.Size(36, 21)
      Me.txtZip4.TabIndex = 6
      Me.txtZip4.Text = ""
      Me.tip.SetToolTip(Me.txtZip4, "+4 digit zip code")
      '
      'lblCityRequired
      '
      Me.lblCityRequired.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCityRequired.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCityRequired.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblCityRequired.Location = New System.Drawing.Point(280, 68)
      Me.lblCityRequired.Name = "lblCityRequired"
      Me.lblCityRequired.Size = New System.Drawing.Size(16, 16)
      Me.lblCityRequired.TabIndex = 123
      Me.lblCityRequired.Text = "R"
      '
      'lblZip5Required
      '
      Me.lblZip5Required.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblZip5Required.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblZip5Required.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblZip5Required.Location = New System.Drawing.Point(232, 100)
      Me.lblZip5Required.Name = "lblZip5Required"
      Me.lblZip5Required.Size = New System.Drawing.Size(16, 16)
      Me.lblZip5Required.TabIndex = 127
      Me.lblZip5Required.Text = "R"
      '
      'lblStateRequired
      '
      Me.lblStateRequired.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblStateRequired.ForeColor = System.Drawing.Color.SteelBlue
      Me.lblStateRequired.Location = New System.Drawing.Point(108, 100)
      Me.lblStateRequired.Name = "lblStateRequired"
      Me.lblStateRequired.Size = New System.Drawing.Size(16, 16)
      Me.lblStateRequired.TabIndex = 126
      Me.lblStateRequired.Text = "R"
      '
      'AddressControl
      '
      Me.BackColor = System.Drawing.Color.White
      Me.Controls.Add(Me.lblZipExample)
      Me.Controls.Add(Me.lblAddress1Required)
      Me.Controls.Add(Me.cboState)
      Me.Controls.Add(Me.lblLine2)
      Me.Controls.Add(Me.txtLine2)
      Me.Controls.Add(Me.lblZipDash)
      Me.Controls.Add(Me.lblCity)
      Me.Controls.Add(Me.txtCity)
      Me.Controls.Add(Me.lblLine1)
      Me.Controls.Add(Me.txtLine1)
      Me.Controls.Add(Me.lblState)
      Me.Controls.Add(Me.lblZip)
      Me.Controls.Add(Me.txtZip5)
      Me.Controls.Add(Me.txtZip4)
      Me.Controls.Add(Me.lblCityRequired)
      Me.Controls.Add(Me.lblZip5Required)
      Me.Controls.Add(Me.lblStateRequired)
      Me.Controls.Add(Me.lblZip4Example)
      Me.Controls.Add(Me.lblZip5Example)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "AddressControl"
      Me.Size = New System.Drawing.Size(296, 136)
      Me.ResumeLayout(False)

   End Sub

#End Region


   Private _address As Address

   ''' <summary>
   ''' Address to populate controls with
   ''' </summary>
   ''' <remarks>
   ''' Get automatically pulls values from controls, but
   ''' Set must be followed by the UpdateControls method to populate controls.
   ''' </remarks>
   <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
   Public Property Address() As Address
      Get
         Return Me._address
      End Get
      Set(ByVal Value As Address)
         Me._address = Value
      End Set
   End Property


   Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Me._address = New Address

      Me.InitializeControls()
   End Sub


   Private Sub InitializeControls()
      If Me.DesignMode Then Exit Sub

      Dim statesTable As DataTable

      ' fills states combobox
      '
      ' retrieves table with a list of state abbreviates and full names
      statesTable = OrderAssistanceDA.RetrieveUnitedStates()
      ' sets combobox's data source to states table
      Me.cboState.DataSource = statesTable
      ' sets combobox to display state abbreviation
      Me.cboState.DisplayMember = "Abbreviation"
      Me.cboState.ValueMember = "FullName"
   End Sub


   ''' <summary>
   ''' Refreshes address object from entered values in controls.
   ''' </summary>
   Public Sub RefreshData()
      If Me.DesignMode Then Exit Sub
      Me._address.Line1 = Me.txtLine1.Text.Trim
      Me._address.Line2 = Me.txtLine2.Text.Trim
      Me._address.City = Me.txtCity.Text.Trim
      If Not Me.cboState.SelectedItem Is Nothing Then
         Me._address.State = DirectCast(Me.cboState.SelectedItem, System.Data.DataRowView).Item("Abbreviation").ToString : End If
      ' checks if zip code was entered
      Me._address.Zip5.set_to(Me.txtZip5.Text.Trim)
      Me._address.Zip4.set_to(Me.txtZip4.Text.Trim)
   End Sub


   ''' <summary>
   ''' Updates controls
   ''' </summary>
   Public Sub UpdateControls()
      If Me.DesignMode Then Exit Sub
      ' sets controls
      Me.txtLine1.Text = Me._address.Line1
      Me.txtLine2.Text = Me._address.Line2
      Me.txtCity.Text = Me._address.City
      Me.cboState.SelectedIndex = Rae.Ui.ListHelper.IndexOfComboboxDataRowViewItem( _
         Me.cboState, Me._address.State, "Abbreviation")

      Me.txtZip5.Text = Me._address.Zip5.ToString
      Me.txtZip4.Text = Me._address.Zip4.ToString
   End Sub


End Class


