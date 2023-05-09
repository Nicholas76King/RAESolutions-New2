Option Strict Off

Imports System.Math

Namespace rae.solutions

    Public Class compressor_polynomial

        Private pt As pressure_temperature_conversion

        Sub New()
            pt = New pressure_temperature_conversion()
        End Sub

        Function calculate(ByVal refg, ByVal coef, ByVal te, ByVal tc) As polynomial_set
            Dim result As polynomial_set
            Dim c = coef.c : Dim w = coef.w : Dim a = coef.a
            'Dim using_5_coef = (c(5) = 0)

            'If using_5_coef Then
            '    Dim pc = pt.pc(tc, refg)
            '    Dim pe = pt.pe(te, refg)
            '    result.q = (c(0) + c(1) * tc + c(2) * pe + c(3) * pe * pc + c(4) * pc / Sqrt(pe)) * refg.q
            '    result.w = (w(0) + w(1) * tc + w(2) * pe + w(3) * pe * pc + w(4) * pc / Sqrt(pe)) * refg.w
            '    result.a = (a(0) + a(1) * tc + a(2) * pe + a(3) * pe * pc + a(4) * pc / Sqrt(pe)) * refg.a
            'Else ' using 10 coef
            result.q = c(0) + c(1) * te + c(2) * tc + c(3) * te ^ 2 + c(4) * te * tc + c(5) * tc ^ 2 + c(6) * te ^ 3 + c(7) * tc * te ^ 2 + c(8) * te * tc ^ 2 + c(9) * tc ^ 3
            result.w = w(0) + w(1) * te + w(2) * tc + w(3) * te ^ 2 + w(4) * te * tc + w(5) * tc ^ 2 + w(6) * te ^ 3 + w(7) * tc * te ^ 2 + w(8) * te * tc ^ 2 + w(9) * tc ^ 3
            result.a = a(0) + a(1) * te + a(2) * tc + a(3) * te ^ 2 + a(4) * te * tc + a(5) * tc ^ 2 + a(6) * te ^ 3 + a(7) * tc * te ^ 2 + a(8) * te * tc ^ 2 + a(9) * tc ^ 3




            'result.q = result.q - ((result.q * (c.SubCooling / 100)) / sc)



            result.a = result.a '* (coef.curveVoltage / coef.unitVoltage)    ' 4_13_2015_amp_error

            '  End If

            Return result
        End Function

        Function [set](ByVal refg, ByVal coef)
            Me.refg = refg
            Me.coef = coef
            Return Me
        End Function

        Function calculate(ByVal te, ByVal tc) As polynomial_set
            Return calculate(refg, coef, te, tc)
        End Function

        Private refg, coef
    End Class

    Public Structure polynomial_set
        Sub New(ByVal q, ByVal w, ByVal a, ByVal curveVoltage, ByVal unitVoltage)
            Me.q = q : Me.w = w : Me.a = a
            Me.curveVoltage = curveVoltage
            Me.unitVoltage = unitVoltage
            ' Me.curveSubcooling = curveSubcooling
        End Sub
        Public q, w, a, curveVoltage, unitVoltage ', curveSubcooling
        ' Public TempCap As Decimal
    End Structure

End Namespace