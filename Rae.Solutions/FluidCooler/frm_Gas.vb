Public Class frm_Gas

    Dim p As FluidCoolerForm
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Me.Close()
    End Sub

    Private Sub FRM_Gas_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        p = CType(Me.ParentForm, FluidCoolerForm)
        'Passing info
        'C_GAS          'Description of Gas
        'C_FLUID        'Description of Fluid
        ''**Gas Varibles************************************
        'a_UVA          'Gas Viscisity (Lbm/Ft -  Sec )
        'a_CPA          'Gas Specific Heat (BTU/Lb - F)
        'a_DPA          'Gas Density (Lbs/Cf)
        'a_KTA          'Gas Thermal Conductivity (BTU/H - Ft^2F - F)
        ''**Fluid Varibles************************************
        'a_UVG          'Fluid Viscisity (Centipoise)
        'a_CPG          'Fluid Specific Heat (BTU/Lb - F)
        'a_DPG          'Fluid Density (Lbs/Cf)
        'a_TKG          'Fluid Thermal Conductivity (BTU/H - Ft^2F - F)
        ''****************************************************

        If p.Cbo_GAS.Text = "OTHER" Then
            Frame_Gas.Visible = True
            Label5.Text = "Gas Type = " & p.C_GAS
            Text1.Text = CStr(p.a_UVA)
            Text2.Text = CStr(p.a_CPA)
            Text3.Text = CStr(p.a_DPA)
            Text4.Text = CStr(p.a_KTA)
        End If

        If p.CBO_FLUIDTYPE.Text = "OTHER" Then
            Frame_Fluid.Visible = True
            Label6.Text = "Fluid Type = " & p.C_FLUID
            Text8.Text = CStr(p.a_UVG)
            Text7.Text = CStr(p.a_CPG)
            Text6.Text = CStr(p.a_DPG)
            Text5.Text = CStr(p.a_TKG)
        End If


    End Sub

    'UPGRADE_WARNING: Event Text1.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
        ' a_UVA       'Viscisity=UVA(Single)-Lbm/Ft Sec
        p.a_UVA = Val(Text1.Text)
    End Sub

    'UPGRADE_WARNING: Event Text2.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.TextChanged
        ' a_CPA       'Sp. Heat of Gas=CPA(Single)-BTU/Lb Deg F
        p.a_CPA = Val(Text2.Text)
    End Sub

    'UPGRADE_WARNING: Event Text3.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text3.TextChanged
        'a_DPA     'Density- DPA(Single)- Lbs/C. Ft.
        p.a_DPA = Val(Text3.Text)

    End Sub

    'UPGRADE_WARNING: Event Text4.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text4_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text4.TextChanged
        'a_TKA     'Thermal Conductivity=TKA(Single)-BTU/Hr-Ft^2F per Ft.
        p.a_KTA = Val(Text4.Text)
    End Sub

    'UPGRADE_WARNING: Event Text5.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text5_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text5.TextChanged
        'a_TKA     'Thermal Conductivity=TKA(Single)-BTU/Hr-Ft^2F per Ft.
        p.a_TKG = Val(Text5.Text)
    End Sub


    'UPGRADE_WARNING: Event Text6.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text6_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text6.TextChanged
        'a_DPG     'Density- DPA(Single)- Lbs/C. Ft.
        p.a_DPG = Val(Text6.Text)
    End Sub

    'UPGRADE_WARNING: Event Text7.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text7_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text7.TextChanged
        ' a_CPG       'Sp. Heat of Gas=CPA(Single)-BTU/Lb Deg F
        p.a_CPG = Val(Text7.Text)
    End Sub

    'UPGRADE_WARNING: Event Text8.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub Text8_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text8.TextChanged
        ' a_UVG       'Viscisity=UVA(Single)-Centipoise
        p.a_UVG = Val(Text8.Text)
    End Sub
End Class