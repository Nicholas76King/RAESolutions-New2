<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMultiplierForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.generateButton = New System.Windows.Forms.Button()
        Me.multiplierTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.assignedByLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.commissionTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.instructionsLabel = New System.Windows.Forms.Label()
        Me.assignedOnDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.generatedCodeTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.emailButton = New System.Windows.Forms.Button()
        Me.codeInfoPicture = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.copyButton = New System.Windows.Forms.Button()
        Me.emailTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.assignedByCombobox = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.assignedToCombobox = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        CType(Me.codeInfoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.assignedByCombobox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.assignedToCombobox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 161)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Assigned To"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'generateButton
        '
        Me.generateButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generateButton.ForeColor = System.Drawing.Color.RoyalBlue
        Me.generateButton.Location = New System.Drawing.Point(466, 301)
        Me.generateButton.Margin = New System.Windows.Forms.Padding(4)
        Me.generateButton.Name = "generateButton"
        Me.generateButton.Size = New System.Drawing.Size(155, 34)
        Me.generateButton.TabIndex = 7
        Me.generateButton.Text = "Generate Code"
        Me.generateButton.UseVisualStyleBackColor = True
        '
        'multiplierTextBox
        '
        Me.multiplierTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.multiplierTextBox.Location = New System.Drawing.Point(155, 196)
        Me.multiplierTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.multiplierTextBox.Name = "multiplierTextBox"
        Me.multiplierTextBox.Size = New System.Drawing.Size(466, 27)
        Me.multiplierTextBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 196)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 27)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Multiplier"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'assignedByLabel
        '
        Me.assignedByLabel.Location = New System.Drawing.Point(24, 92)
        Me.assignedByLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.assignedByLabel.Name = "assignedByLabel"
        Me.assignedByLabel.Size = New System.Drawing.Size(123, 27)
        Me.assignedByLabel.TabIndex = 5
        Me.assignedByLabel.Text = "Assigned By"
        Me.assignedByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 127)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 27)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Assigned On"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'commissionTextBox
        '
        Me.commissionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.commissionTextBox.Location = New System.Drawing.Point(155, 231)
        Me.commissionTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.commissionTextBox.Name = "commissionTextBox"
        Me.commissionTextBox.Size = New System.Drawing.Size(466, 27)
        Me.commissionTextBox.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 231)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 27)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Commission"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'instructionsLabel
        '
        Me.instructionsLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.instructionsLabel.Location = New System.Drawing.Point(24, 15)
        Me.instructionsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.instructionsLabel.Name = "instructionsLabel"
        Me.instructionsLabel.Size = New System.Drawing.Size(597, 27)
        Me.instructionsLabel.TabIndex = 9
        Me.instructionsLabel.Text = "Use this form to assign a representative a custom multiplier and commission."
        Me.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'assignedOnDatePicker
        '
        Me.assignedOnDatePicker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedOnDatePicker.Location = New System.Drawing.Point(155, 127)
        Me.assignedOnDatePicker.Name = "assignedOnDatePicker"
        Me.assignedOnDatePicker.Size = New System.Drawing.Size(466, 27)
        Me.assignedOnDatePicker.TabIndex = 2
        '
        'generatedCodeTextBox
        '
        Me.generatedCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.generatedCodeTextBox.Location = New System.Drawing.Point(155, 266)
        Me.generatedCodeTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.generatedCodeTextBox.Name = "generatedCodeTextBox"
        Me.generatedCodeTextBox.ReadOnly = True
        Me.generatedCodeTextBox.Size = New System.Drawing.Size(466, 27)
        Me.generatedCodeTextBox.TabIndex = 6
        Me.generatedCodeTextBox.TabStop = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 266)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 27)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Generated Code"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'emailButton
        '
        Me.emailButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.emailButton.ForeColor = System.Drawing.Color.RoyalBlue
        Me.emailButton.Location = New System.Drawing.Point(466, 419)
        Me.emailButton.Margin = New System.Windows.Forms.Padding(4)
        Me.emailButton.Name = "emailButton"
        Me.emailButton.Size = New System.Drawing.Size(155, 34)
        Me.emailButton.TabIndex = 10
        Me.emailButton.Text = "Email Code"
        Me.emailButton.UseVisualStyleBackColor = True
        '
        'codeInfoPicture
        '
        Me.codeInfoPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.codeInfoPicture.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Info
        Me.codeInfoPicture.Location = New System.Drawing.Point(621, 266)
        Me.codeInfoPicture.Name = "codeInfoPicture"
        Me.codeInfoPicture.Size = New System.Drawing.Size(22, 27)
        Me.codeInfoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.codeInfoPicture.TabIndex = 17
        Me.codeInfoPicture.TabStop = False
        Me.ToolTip1.SetToolTip(Me.codeInfoPicture, "The representative must apply the custom multiplier the same day it is assigned.")
        '
        'copyButton
        '
        Me.copyButton.Image = Global.Rae.RaeSolutions.My.Resources.Resources.Copy
        Me.copyButton.Location = New System.Drawing.Point(597, 267)
        Me.copyButton.Name = "copyButton"
        Me.copyButton.Size = New System.Drawing.Size(23, 25)
        Me.copyButton.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.copyButton, "Copies code to clipboard. You can then paste it.")
        Me.copyButton.UseVisualStyleBackColor = True
        '
        'emailTextBox
        '
        Me.emailTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.emailTextBox.Location = New System.Drawing.Point(155, 384)
        Me.emailTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.emailTextBox.Name = "emailTextBox"
        Me.emailTextBox.Size = New System.Drawing.Size(466, 27)
        Me.emailTextBox.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 384)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 27)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Email address"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label9.Location = New System.Drawing.Point(24, 55)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 27)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Step 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label10.Location = New System.Drawing.Point(100, 55)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(521, 27)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Generate Code"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label11.Location = New System.Drawing.Point(24, 347)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 27)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Step 2"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label12.Location = New System.Drawing.Point(100, 347)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(546, 27)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Email Code to Rep"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'assignedByCombobox
        '
        Me.assignedByCombobox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedByCombobox.AutoComplete = True
        Me.assignedByCombobox.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.assignedByCombobox.Location = New System.Drawing.Point(155, 92)
        Me.assignedByCombobox.Name = "assignedByCombobox"
        Me.assignedByCombobox.Size = New System.Drawing.Size(466, 29)
        Me.assignedByCombobox.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.assignedByCombobox.SyncWithCurrencyManager = False
        Me.assignedByCombobox.TabIndex = 1
        Me.assignedByCombobox.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        '
        'assignedToCombobox
        '
        Me.assignedToCombobox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.assignedToCombobox.AutoComplete = True
        Me.assignedToCombobox.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.assignedToCombobox.Location = New System.Drawing.Point(155, 160)
        Me.assignedToCombobox.Name = "assignedToCombobox"
        Me.assignedToCombobox.Size = New System.Drawing.Size(466, 29)
        Me.assignedToCombobox.SortStyle = Infragistics.Win.ValueListSortStyle.Ascending
        Me.assignedToCombobox.SyncWithCurrencyManager = False
        Me.assignedToCombobox.TabIndex = 3
        Me.assignedToCombobox.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        '
        'CustomMultiplierForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(656, 470)
        Me.Controls.Add(Me.copyButton)
        Me.Controls.Add(Me.assignedToCombobox)
        Me.Controls.Add(Me.assignedByCombobox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.emailTextBox)
        Me.Controls.Add(Me.codeInfoPicture)
        Me.Controls.Add(Me.emailButton)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.generatedCodeTextBox)
        Me.Controls.Add(Me.assignedOnDatePicker)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.instructionsLabel)
        Me.Controls.Add(Me.commissionTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.assignedByLabel)
        Me.Controls.Add(Me.multiplierTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.generateButton)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CustomMultiplierForm"
        Me.Text = "Custom Multiplier"
        CType(Me.codeInfoPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.assignedByCombobox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.assignedToCombobox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents generateButton As System.Windows.Forms.Button
    Friend WithEvents multiplierTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents assignedByLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents commissionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents instructionsLabel As System.Windows.Forms.Label
    Friend WithEvents assignedOnDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents generatedCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents emailButton As System.Windows.Forms.Button
    Friend WithEvents codeInfoPicture As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents emailTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents assignedByCombobox As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents assignedToCombobox As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents copyButton As System.Windows.Forms.Button
End Class
