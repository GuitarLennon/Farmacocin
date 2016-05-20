' (C) ARTURO JUAREZ FLORES 2016

Namespace Farmacocinética

    Public Module PK_Pool

        Function CP(t As Double, dosis As Double, fBd As Double, Ka As Double, Ke As Double, eliminación As GradosDeEliminación, Vd As Double, tlag As Double, Optional vMax As Double = 0) As Double
            Dim returning As Double

            If t < 0 Then Return 0
            Dim A As Double = (fBd * dosis) / Vd

            'eliminación
            Dim frac3a As Double
            If eliminación = GradosDeEliminación.Michaelis_Menten Then

                Dim C4 As Double = Math.E ^ (-Ka * t - tlag)

                Dim exp As Double = Math.E ^ (vMax / (2.303 * Ke * (t - tlag)))

                Dim G4 As Double = A / exp

                Return G4 * C4

            ElseIf eliminación = GradosDeEliminación.Primer_Orden Then

                Dim frac2 As Double = Ka / (Ka - Ke)

                Dim frac3b As Double = Math.E ^ (-Ka * (t - tlag))

                frac3a = Math.E ^ (-Ke * (t - tlag))

                Dim frac3 As Double = frac3a - frac3b

                returning = A * frac2 * frac3

            Else
                Stop
            End If

            If returning < 0 Then Return 0
            Return returning
        End Function

        Function Cp_1(t As Double, fbd As Double, dosis As Double, ka As Double, vd As Double, kel As Double) As Double
            Dim calc As Double = A(fbd, dosis, ka, vd, kel)
            Return (calc * Math.E ^ kel * t) - (calc * Math.E ^ -ka * t)
        End Function

        Function CP_Múltiple(t As Double,
                         intérvalo As Double,
                         dosis As Double,
                         fBd As Double,
                         Ka As Double,
                         Ke As Double,
                         eliminación As GradosDeEliminación,
                         Vd As Double,
                         tlag As Double,
                         Optional dosistotales As Integer = -1) As Double

            If t < 0 Then Return 0
            Dim administrados As Integer = CInt(t / intérvalo)
            Dim returning As Double
            Dim a(administrados) As Double

            If dosistotales <> -1 AndAlso administrados > (dosistotales - 1) Then administrados = (dosistotales - 1)

            For i As Integer = 0 To administrados
                a(i) = CP(t, dosis, fBd, Ka, Ke, eliminación, Vd, intérvalo * i)
                returning += a(i)
            Next

            'For i As Integer = 0 To administrados

            '    a(i) = CP(t - (i * intérvalo), dosis, fBd, Ka, Ke, eliminación, Vd, tlag)
            '    returning += a(i)
            'Next

            'If administrados >= 1 Then Stop

            Return returning

        End Function

        Function CP_Múltiple_Charge(t As Double,
                                intérvalo As Double,
                                carga As Double,
                                dosis As Double,
                                fBd As Double,
                                Ka As Double,
                                Ke As Double,
                                eliminación As GradosDeEliminación,
                                Vd As Double,
                                tlag As Double,
                                Optional dosistotales As Integer = -1) As Double

            Dim administrados As Integer = CInt(t / intérvalo)
            Dim returning As Double
            Dim a(administrados) As Double

            a(0) = CP(t, carga, fBd, Ka, Ke, eliminación, Vd, tlag)
            returning += a(0)

            If dosistotales <> -1 AndAlso administrados > (dosistotales - 1) Then administrados = (dosistotales - 1)

            For i As Integer = 1 To administrados
                a(i) = CP(t - (i * intérvalo), dosis, fBd, Ka, Ke, eliminación, Vd, tlag)
                returning += a(i)
            Next

            Return returning

        End Function

        Function C0(fbd As Double, dosis As Double, ka As Double, vd As Double, kel As Double) As Double
            Return A(fbd, dosis, ka, vd, kel)
        End Function

        Function AUC_0ToInf(C0 As Double, ke As Double, a0 As Double, ka As Double) As Double
            Return (C0 / ke) - (a0 / ka)
        End Function

        Function AUC_aTob(matriz As Coordenadas(), a As Double, b As Double, intervalo As Double) As Double
            Dim m As Coordenadas() = ValoresEspecíficos(matriz, a, b)
            Dim result As Double

            For i = 0 To m.GetUpperBound(0)
                result += m(i).y * intervalo
            Next
            Return result
        End Function

        'Function A0(ke As Double, c0 As Double, tmax As Double, ka As Double) As Double
        '    Dim calc1 As Double = ke * c0 * (Math.E ^ (-ke * tmax))
        '    Dim calc2 As Double = ka * (Math.E ^ (-ka * tmax))
        '    Return calc1 / calc2
        'End Function

        Function Cl(Fbd As Double, dosis As Double, c0 As Double, ke As Double) As Double
            If Double.IsNaN(c0) Then Return 0
            Dim auc_0toinf As Double = c0 * ke
            Return Fbd * dosis / auc_0toinf
        End Function

        Function ValoresEspecíficos(matriz As Coordenadas(), limiteInferior As Double, limiteSuperior As Double) As Coordenadas()
            Dim l As New List(Of Coordenadas)
            If matriz Is Nothing Then Return Nothing
            For Each valor As Coordenadas In matriz
                If valor.x >= limiteInferior And valor.x < limiteSuperior Then
                    l.Add(valor)
                End If
            Next
            Return l.ToArray
        End Function

        Function C_x(t As Double, ka As Double, Fbd As Double, dosis As Double, Vd As Double, Kel As Double) As Double
            'Dim calc1 As Double = Fbd * dosis 'C0(dosis, Fbd, Vd) '* ka ' ka * Fbd * dosis
            'Dim calc2 As Double = Vd * (ka - K)
            Dim calc1 As Double = A(Fbd, dosis, ka, Vd, Kel)
            Dim calc3 As Double = Math.E ^ (-ka * t)
            Return calc1 * calc3
        End Function

        Function Cp_late(t As Double, ka As Double, Fbd As Double, dosis As Double, Vd As Double, Kel As Double) As Double

            Dim _a As Double = A(Fbd, dosis, ka, Vd, Kel)
            Dim calc As Double = Math.E ^ (-Kel * t)
            Return _a * calc
        End Function

        Function Cp_late_cero(t As Double, ka As Double, Fbd As Double, dosis As Double, Vd As Double, Kel As Double) As Double

            Dim _a As Double = A(Fbd, dosis, ka, Vd, Kel)
            Dim calc As Double = Math.E ^ (-Kel * t)
            Return _a - (Kel * t)
        End Function

        Function Residual(t As Double, ka As Double, Fbd As Double, dosis As Double, Vd As Double, Kel As Double) As Double
            Return A(Fbd, dosis, ka, Vd, Kel) * Math.E ^ (-ka * t)
        End Function

        Function A(fbd As Double, dosis As Double, ka As Double, vd As Double, kel As Double) As Double
            Return (fbd * dosis * ka) / (vd * (ka - kel))
        End Function

        Function Cmax(Q As Double, ke As Double, tmax As Double) As Double
            Return Q * Math.E ^ (-ke * tmax)
        End Function

        Function Tmax(ka As Double, ke As Double) As Double
            Return Math.Log(ka / ke) / (ka - ke)
        End Function

        Function Cmax_ee(dosis As Double, vd As Double, ke As Double, tao As Double) As Double
            Return dosis / (vd * (1 - Math.E ^ (-ke * tao)))
        End Function

        Function Cmin_ee(dosis As Double, vd As Double, ke As Double, tao As Double) As Double
            Dim cmax As Double = Cmax_ee(dosis, vd, ke, tao)
            Return cmax * (Math.E ^ (-ke * tao))
        End Function

        Function tmax_ss(ka As Double, ke As Double, tau As Double) As Double
            Dim calc1 As Double = ka * (1 - Math.E ^ (-ke * tau))
            Dim calc2 As Double = ke * (1 - Math.E ^ (-ka * tau))
            Dim calc3 As Double = Math.Log(calc1 / calc2)
            Dim calc4 As Double = ka - ke
            Return calc3 / calc4
        End Function

    End Module

End Namespace