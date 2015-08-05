Imports NTGRAPHLib, AxNTGRAPHLib
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Farmacocinética.ModeloFarmacocinéticoAnimado

Public Module Main
    'Dim f As New Formulario
    'Dim x As AxNTGraph

    <Extension> Function MaxHoursTeoric(nada As Date) As Double
        'nada = New Date
        'nada = nada.AddHours(MaxHoursTeoric + 1)
        Return Date.MaxValue.Hour + Date.MaxValue.Day * 24 + Date.MaxValue.Month * 30 * 24 + Date.MaxValue.Year * 365 * 24
    End Function

    <Extension>
    Function AddAnnotation(ntgraph As AxNTGraph, x As Double, y As Double, texto As String, _
                            Optional backcolor As Drawing.Color = Nothing, _
                            Optional forecolor As Drawing.Color = Nothing, _
                            Optional horizontal As Boolean = True, _
                            Optional visible As Boolean = True) As Integer

        ntgraph.AddAnnotation()

        If backcolor = Drawing.Color.Empty Then backcolor = Drawing.Color.Black
        If forecolor = Drawing.Color.Empty Then forecolor = Drawing.Color.White

        ntgraph.AnnoLabelBkColor = backcolor
        ntgraph.AnnoLabelCaption = texto
        ntgraph.AnnoLabelColor = forecolor
        ntgraph.AnnoLabelHorizontal = horizontal
        ntgraph.AnnoLabelX = x
        ntgraph.AnnoLabelY = y
        ntgraph.AnnoVisible = visible

        Return ntgraph.AnnoCount - 1
    End Function

    <Extension>
    Function AddCursor(ntgraph As AxNTGraph, x As Double, y As Double, _
                            Optional mode As Short = 0, _
                            Optional color As Drawing.Color = Nothing, _
                            Optional style As Short = 0, _
                            Optional horizontal As Boolean = True, _
                            Optional visible As Boolean = True) As Integer

        ntgraph.AddCursor()
        If color = Drawing.Color.Empty Then color = Drawing.Color.Yellow

        ntgraph.CursorColor = color
        Try
            ntgraph.CursorMode = mode
        Catch ex As Exception
            ntgraph.CursorMode = 0
        End Try
        ntgraph.CursorStyle = style
        ntgraph.CursorVisible = visible
        ntgraph.CursorX = x
        ntgraph.CursorY = y

        Return ntgraph.CursorCount - 1
    End Function

    Public Function Función1() As Double()
        Dim a(1000) As Double
        For i As Integer = 0 To 1000
            a(i) = Rnd()
        Next
        Return a
    End Function

    Public Class Element
        Public id As Short = 0
        Public lineColor As Drawing.Color = Drawing.Color.Gold
        Public lineType As LineType = NTGRAPHLib.LineType.Solid
        Public name As String
        Public pointColor As Drawing.Color = Drawing.Color.Green
        Public pointSymbol As SymbolType = SymbolType.Nosym
        Public show As Boolean = True
        Public solidPoint As Boolean = False
        Public width As Integer = 1

        Sub ToGraph(ntgraph As AxNTGraph)
            While ntgraph.ElementCount < id + 1
                ntgraph.AddElement()
            End While
            ntgraph.Element = id
            ntgraph.ElementLineColor = lineColor
            ntgraph.ElementLinetype = Me.lineType
            ntgraph.ElementName = Me.name
            ntgraph.ElementPointColor = Me.pointColor
            ntgraph.ElementPointSymbol = Me.pointSymbol
            ntgraph.ElementShow = Me.show
            ntgraph.ElementSolidPoint = Me.solidPoint
            ntgraph.ElementWidth = Me.width
            'ntgraph.Element = old
        End Sub
    End Class

    <Extension>
    Public Function GetElement(ntgraph As AxNTGraph) As Element
        Dim e As New Element
        e.id = ntgraph.Element
        e.lineColor = ntgraph.ElementLineColor
        e.lineType = ntgraph.ElementLinetype
        e.name = ntgraph.ElementName
        e.pointColor = ntgraph.ElementPointColor
        e.pointSymbol = ntgraph.ElementPointSymbol
        e.show = ntgraph.ElementShow
        e.solidPoint = ntgraph.ElementSolidPoint
        e.width = ntgraph.ElementWidth
        Return e
    End Function

    <Extension>
    Public Function GetElement(ntgraph As AxNTGraph, id As Short) As Element
        Dim old As Short = ntgraph.Element
        Dim e As New Element
        e.id = ntgraph.Element
        e.lineColor = ntgraph.ElementLineColor
        e.lineType = ntgraph.ElementLinetype
        e.name = ntgraph.ElementName
        e.pointColor = ntgraph.ElementPointColor
        e.pointSymbol = ntgraph.ElementPointSymbol
        e.show = ntgraph.ElementShow
        e.solidPoint = ntgraph.ElementSolidPoint
        e.width = ntgraph.ElementWidth
        ntgraph.Element = old
        Return e
    End Function

    <Extension>
    Public Sub plotMatriz(ntgrap As AxNTGraph, element As Integer, Array() As Double)

        ntgrap.ClearGraph()

        Dim e As New Element With {.lineColor = Drawing.Color.Aquamarine, .pointColor = Drawing.Color.Azure}
        e.ToGraph(ntgrap)

        For i = Array.GetLowerBound(0) To Array.GetUpperBound(0)
            ntgrap.PlotXY(i, Array(i), element)
            ntgrap.Refresh()
        Next

        ntgrap.TrackMode = TrackModeState.Zoom
        ntgrap.AutoRange()
    End Sub

    <Extension>
    Public Sub plotMatriz(ntgrap As AxNTGraph, element As Element, Array() As Double)

        ntgrap.AddElement()
        element.id = ntgrap.ElementCount - 1
        element.ToGraph(ntgrap)
        For i = Array.GetLowerBound(0) To Array.GetUpperBound(0)
            ntgrap.PlotXY(i, Array(i), element.id)
            ntgrap.Refresh()
        Next

        ntgrap.TrackMode = TrackModeState.Zoom
        ntgrap.AutoRange()
    End Sub

    <Extension>
    Public Sub plotData(ntgrap As AxNTGraph, coordenada As Coordenadas)

        ntgrap.PlotXY(coordenada.x, coordenada.y, ntgrap.Element)

    End Sub

    Private Sub click(sender As Object, e As EventArgs)
        Dim x As AxNTGraph = DirectCast(sender, AxNTGraph)
        x.AutoRange()
    End Sub

    Function eliminación(concentración As Double, Ke As Double, tiempo As Double) As Double
        Dim halfLife As Double
        halfLife = Math.Log(2) / Ke
        Dim actualConcentration As Double
        actualConcentration = concentración * Math.E ^ (-tiempo / halfLife)
        Return actualConcentration
    End Function

    Function MichaelisMenten(Vmax As Double, Km As Double, S As Double) As Double
        Dim dato As Double = S + Km
        Return Vmax / dato
    End Function

    Function VidaMediadeEliminación(eliminación As Double, concentraciónTiempoCero As Double, cinética As GradosDeEliminación, Optional vmax As Double = 0) As Double
        If concentraciónTiempoCero = Double.NegativeInfinity Then Return 0

        'If eliminación = 0 Then Return "Infinito"
        Select Case cinética
            Case GradosDeEliminación.Michaelis_Menten
                Return ((eliminación * Math.Log(2)) + (concentraciónTiempoCero / 2)) / vmax
            Case GradosDeEliminación.Primer_Orden
                Return Math.Log(2) / eliminación
            Case Else
                'segundo orden
                '1/K*A^2
                Return 1 / (concentraciónTiempoCero ^ 2)
        End Select

    End Function

    Function VidaMediaSegundoOrden(eliminación As Double)
        Return Math.Log(2) / eliminación
    End Function

    <Extension>
    Function DecirTiempo(fecha As Date) As String
        Dim sec As String = Nothing
        If fecha.Second > 0 Then sec = " " & fecha.Second & " seg"
        If fecha.Second > 1 Then sec = sec & "(s)"

        Dim min As String = Nothing
        If Not fecha.Minute = 0 Then min = " " & fecha.Minute & " min"
        If fecha.Minute > 1 Then min = min & "(s)"

        Dim hor As String = Nothing
        If Not fecha.Hour = 0 Then hor = " " & fecha.Hour & " hora"
        If fecha.Hour > 1 Then hor = hor & "(s)"

        Dim día As String = Nothing
        If fecha.Day - 1 > 0 Then día = fecha.Day - 1 & " día"
        If fecha.Day - 1 > 1 Then día = día & "(s)"

        If String.IsNullOrWhiteSpace(día & hor & min & sec) Then Return "Menos de un segundo"

        Return (día & hor & min & sec)
    End Function

    Function DecirTmaxCmax(tmax As Double, cmax As Double, múltiple As Boolean) As String
        If múltiple Then
            Return "Cmax-ee: " & Format(cmax, "#.###") & " ng/ml " & "Tmax-ee: " & Format(tmax, "#.###") & " h"
        Else
            Return "Cmax: " & Format(cmax, "#.###") & " ng/ml " & "Tmax: " & Format(tmax, "#.###") & " h"
        End If
    End Function

    Function DecirAUC(auc As Double) As String
        Return "AUC: " & Format(auc, "#0.###") & " U^2"
    End Function

    Function DecirC0(c0 As Double) As String
        Return "C0: " & Format(c0, "#.##")
    End Function

    Function DecirCmin(Cmin As Double)
        Return "Cmin-ee: " & Format(Cmin, "#.##")
    End Function

End Module


Public Module PK_Pool

    Function CP(t As Double, dosis As Double, fBd As Double, Ka As Double, Ke As Double, eliminación As GradosDeEliminación, Vd As Double, tlag As Double, Optional vMax As Double = 0) As Double
        Dim returning As Double

        If t < 0 Then Return 0
        Dim A As Double = (fBd * dosis) / Vd

        'eliminación
        Dim frac3a As Double
        If eliminación = GradosDeEliminación.Michaelis_Menten Then

            Dim C4 As Double = Math.E ^ (-Ka * t)

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

    Function CP_Múltiple(t As Double, intérvalo As Double, dosis As Double, fBd As Double, Ka As Double, Ke As Double, eliminación As GradosDeEliminación, Vd As Double, tlag As Double) As Double
        Dim administrados As Integer = CInt(t / intérvalo)
        Dim returning As Double
        Dim a(administrados)

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

    Function CP_Múltiple_Charge(t As Double, intérvalo As Double, carga As Double, dosis As Double, fBd As Double, Ka As Double, Ke As Double, eliminación As GradosDeEliminación, Vd As Double, tlag As Double) As Double
        Dim administrados As Integer = CInt(t / intérvalo)
        Dim returning As Double
        Dim a(administrados) As Double


        a(0) = CP(t, carga, fBd, Ka, Ke, eliminación, Vd, tlag)
        returning += a(0)

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

    Function Cl(Fbd As Double, dosis As Double, c0 As Double, ke As Double)
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
        Return fbd * dosis * ka / (vd * (ka - kel))
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

Public Structure Coordenadas
    Dim x As Double
    Dim y As Double
End Structure

Public NotInheritable Class Pk_Calc
    Dim _cp() As Coordenadas
    Dim _dif() As Coordenadas
    Dim _extrapol() As Coordenadas
    Dim _eliminación() As Coordenadas
    Dim _resid() As Coordenadas



    Public Class paqueteCoordines
        Property Tiempo As Double
        Property Residuales As Double
        Property Eliminación As Double
        Property Extrapolados As Double
        Property Diferencial As Double
        Property ConcentraciónPlasmática As Double
    End Class

    Function Residuales() As Coordenadas()
        Return _resid
    End Function

    Function Eliminación() As Coordenadas()
        Return _eliminación
    End Function

    Function Extrapolados() As Coordenadas()
        Return _extrapol
    End Function

    Function Diferencial() As Coordenadas()
        Return _dif
    End Function

    Function Gráfica() As Coordenadas()
        Return _cp
    End Function

    ReadOnly Property CP(index As Integer) As Coordenadas
        Get
            Return _cp(index)
        End Get
    End Property

    'Datos de entrada
    Property Fbd As Double
    Property Dosis As Double
    Property Ka As Double
    Property Vd As Double
    Property Ke As Double
    Property Tlag As Double

    Property vMax As Double

    Property MúltiplesDosis As Boolean
    Property IntérvaloDosis As Double

    Property UsarDosisCarga As Boolean
    Property DosisCarga As Double


    Property Duración As Double
    Property Muestras As Double

    Private ReadOnly Property Rel As Double
        Get
            Return Duración / Muestras
        End Get
    End Property
    Property AmplificaciónDiferencial As Double = 4
    Property GradoDeEliminación As GradosDeEliminación = GradosDeEliminación.Primer_Orden

    'Datos de salida
    ReadOnly Property AUC As Double
        Get
            If Not MúltiplesDosis Then
                Return PK_Pool.AUC_0ToInf(C0, Ke, A0, Ka)
            Else
                Return AUC(0, Duración)
            End If
        End Get
    End Property

    ReadOnly Property AUC(inicio As Double, final As Double) As Double
        Get
            Return AUC_aTob(_cp, inicio, final, Rel)
        End Get
    End Property

    ReadOnly Property C0 As Double
        Get
            Return PK_Pool.C0(Fbd, Dosis, Ka, Vd, Ke) * 10 ^ 3
        End Get
    End Property

    ReadOnly Property A0 As Double
        Get
            Return PK_Pool.A(Fbd, Dosis, Ka, Vd, Ke)
        End Get
    End Property

    ReadOnly Property Q() As Double
        Get
            Return Fbd * Dosis / Vd
        End Get
    End Property

    ReadOnly Property Cmax_ee As Double
        Get
            Return PK_Pool.Cmax_ee(Dosis, Vd, Ke, IntérvaloDosis) * 10 ^ 3
        End Get
    End Property

    ReadOnly Property Cmin_ee As Double
        Get
            Return PK_Pool.Cmin_ee(Dosis, Vd, Ke, IntérvaloDosis) * 10 ^ 3
        End Get
    End Property

    ReadOnly Property Tmax_ss As Double
        Get
            Return PK_Pool.tmax_ss(Ka, Ke, IntérvaloDosis)
        End Get
    End Property

    Dim _cmax As Double

    ReadOnly Property Cmax As Double
        Get
            If MúltiplesDosis Then
                Return Cmax_ee
            End If
            Return PK_Pool.Cmax(Q, Ke, Tmax) * 10 ^ 3
            Return _cmax
        End Get
    End Property

    Dim _tmax As Double

    ReadOnly Property Tmax As Double
        Get
            If MúltiplesDosis Then
                Return Tmax_ss
            End If
            Return PK_Pool.Tmax(Ka, Ke)
            Return _tmax
        End Get
    End Property


    Dim _cmin As Double
    ReadOnly Property Cmin As Double
        Get
            Return Cmin_ee
            Return _cmin
        End Get
    End Property

    ReadOnly Property Cl As Double
        Get
            Dim i As Double = PK_Pool.Cl(Fbd, Dosis, C0, Ke)
            If Double.IsInfinity(i) Then
                Return Nothing
            End If
            Return i
        End Get
    End Property

    'Constructores y destructores
    Sub New()

    End Sub
    'Sub New(FracciónBiodisponible As Double, Dosificación As Double, _
    '        ka As Double, vd As Double, ke As Double, _
    '        gradoDeEliminación As GradosDeEliminación, latencia As Double, _
    '        múltiplesDosis As Boolean, intérvaloDosis As Double, _
    '        UsarCarga As Boolean, dosisCarga As Double, _
    '        duración As Double, muestras As Double)
    '    Me.Fbd = FracciónBiodisponible
    '    Me.Dosis = Dosificación
    '    Me.Ka = ka
    '    Me.Vd = vd
    '    Me.Ke = ke
    '    Me.GradoDeEliminación = gradoDeEliminación
    '    Me.Tlag = latencia
    '    Me.MúltiplesDosis = múltiplesDosis
    '    Me.IntérvaloDosis = intérvaloDosis
    '    Me.UsarDosisCarga = UsarCarga
    '    Me.DosisCarga = dosisCarga
    '    Me.Duración = duración
    '    Me.Muestras = muestras

    'End Sub

    Protected Overloads Overrides Sub finalize() 'Optional lol As Boolean = False)
        MyBase.Finalize()
    End Sub

    Function Calculate(time As Double) As paqueteCoordines
        Dim p As New paqueteCoordines

        p.Tiempo = time

        If MúltiplesDosis Then
            If UsarDosisCarga Then
                p.ConcentraciónPlasmática = PK_Pool.CP_Múltiple_Charge(time, IntérvaloDosis, DosisCarga, Dosis, Fbd, Ka, Ke, Me.GradoDeEliminación, Vd, Tlag) * 10 ^ 3
            Else
                p.ConcentraciónPlasmática = PK_Pool.CP_Múltiple(time, IntérvaloDosis, Dosis, Fbd, Ka, Ke, Me.GradoDeEliminación, Vd, Tlag) * 10 ^ 3
            End If
        Else
            p.ConcentraciónPlasmática = PK_Pool.CP(time, Dosis, Fbd, Ka, Ke, Me.GradoDeEliminación, Vd, Tlag, vMax) * 10 ^ 3

            'extrapolación
            p.Extrapolados = PK_Pool.C_x(time, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3


            Select Case Me.GradoDeEliminación
                Case GradosDeEliminación.Michaelis_Menten
                    p.Eliminación = PK_Pool.Cp_late_cero(time, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3
                Case GradosDeEliminación.Primer_Orden
                    p.Eliminación = PK_Pool.Cp_late(time, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3
            End Select

            p.Residuales = PK_Pool.Residual(time, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3
            '_cp(i).x - _eliminación(i).y '(_extrapol(i).y - _eliminación(i).y)
        End If

        'If time = 0 Then
        'p.Diferencial = (_cp(0).y / _cp(0).x) * AmplificaciónDiferencial
        'Else
        '    p.Diferencial = (_cp(i).y - _cp(i - 1).y) / (_cp(i).x - _cp(i - 1).x) * AmplificaciónDiferencial
        'End If

        Return p
    End Function

    'Funciones
    Function DoMath() As Coordenadas()
        ReDim _cp(0 To Muestras)
        ReDim _dif(0 To Muestras)
        ReDim _extrapol(0 To Muestras)
        ReDim _eliminación(0 To Muestras)
        ReDim _resid(0 To Muestras)

        Dim work_cmin As Double, anterior_cmin As Double = Double.PositiveInfinity

        Dim rel_locale As Double = Rel

        For i = 0 To _cp.GetUpperBound(0)
            _cp(i).x = rel_locale * i
            _dif(i).x = _cp(i).x


            If MúltiplesDosis Then
                If UsarDosisCarga Then
                    _cp(i).y = PK_Pool.CP_Múltiple_Charge(_cp(i).x, IntérvaloDosis, DosisCarga, Dosis, Fbd, Ka, Ke, Me.GradoDeEliminación, Vd, Tlag)
                Else
                    _cp(i).y = PK_Pool.CP_Múltiple(_cp(i).x, IntérvaloDosis, Dosis, Fbd, Ka, Ke, Me.GradoDeEliminación, Vd, Tlag)
                End If
            Else
                _cp(i).y = PK_Pool.CP(_cp(i).x, Dosis, Fbd, Ka, Ke, Me.GradoDeEliminación, Vd, Tlag)

                'extrapolación
                _extrapol(i).x = _cp(i).x
                _extrapol(i).y = PK_Pool.C_x(_cp(i).x, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3

                _eliminación(i).x = _cp(i).x
                Select Case Me.GradoDeEliminación
                    Case GradosDeEliminación.Michaelis_Menten
                        _eliminación(i).y = PK_Pool.Cp_late_cero(_cp(i).x, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3
                    Case GradosDeEliminación.Primer_Orden
                        _eliminación(i).y = PK_Pool.Cp_late(_cp(i).x, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3
                End Select


                _resid(i).x = _cp(i).x
                _resid(i).y = Residual(_cp(i).x, Ka, Fbd, Dosis, Vd, Ke) * 10 ^ 3
            End If
            _cp(i).y = _cp(i).y * 10 ^ 3

            'Calcular diferencia
            If i = 0 Then
                _dif(0).y = (_cp(0).y / _cp(0).x) * AmplificaciónDiferencial
            Else
                _dif(i).y = (_cp(i).y - _cp(i - 1).y) / (_cp(i).x - _cp(i - 1).x) * AmplificaciónDiferencial
            End If

            'obtener Cmax, Tmax
            If i = 0 Then
                _cmax = _cp(i).y
                _tmax = _cp(i).x
            Else
                If _cp(i).y > _cmax Then
                    _cmax = _cp(i).y
                    _tmax = _cp(i).x
                    work_cmin = _cmax
                Else
                    If _cp(i).y < work_cmin Then work_cmin = _cp(i).y
                End If
            End If
        Next
        _cmin = work_cmin

        Return _cp
    End Function

End Class

Public Class TimingGraphicator

    Private _gráfico As AxNTGraph
    Private Property Gráfico As AxNTGRAPHLib.AxNTGraph
        Get
            If _gráfico Is Nothing Then Stop
            Return _gráfico
        End Get
        Set(value As AxNTGRAPHLib.AxNTGraph)

            _gráfico = value
        End Set
    End Property
    Private Timer As New Timer
    Private _status As StatusEnum
    'Public Property CurrentElement As Element

    Public Class DrawingEventArgs
        Inherits EventArgs

        Public Class response
            Private _x As Double
            ReadOnly Property x As Double
                Get
                    Return _x
                End Get
            End Property
            Property y As Double
            Property element As Integer
            Friend Sub New(x As Double)
                Me._x = x
            End Sub
            Public Function toCoordenada() As Coordenadas
                Return New Coordenadas With {.x = Me.x, .y = Me.y}
            End Function
        End Class

        Private _x As Double

        Protected Friend Sub New(x As Double)
            Me._x = x
        End Sub

        ReadOnly Property X As Double
            Get
                Return Me._x
            End Get
        End Property

        Public Property Y As response()

        Public Sub addResponse(y As Double, element As Integer)
            Dim l As New List(Of response)
            If Not Me.Y Is Nothing Then l.AddRange(Me.Y)
            l.Add(New response(X) With {.element = element, .y = y})
            Me.Y = l.ToArray
        End Sub

        Public Property [option] As Options = Options.Continue

        Public Enum Options As Integer
            [Continue]
            [Stop]
        End Enum
    End Class

    Public Enum StatusEnum
        Ready
        Starting
        Stopping
        paused
        Drawing
    End Enum

    Sub New(gráfico As AxNTGRAPHLib.AxNTGraph)
        If gráfico Is Nothing Then Stop
        Me.Gráfico = gráfico
        'Me.CurrentElement = element

        AddHandler Me.Timer.Tick, AddressOf internalDraw
    End Sub

    Private Sub plotData(response As DrawingEventArgs.response)
        If Gráfico Is Nothing Then Exit Sub
        Gráfico.PlotXY(response.x, response.y, response.element)
    End Sub

    Private Sub plotArea()
        plotData(New DrawingEventArgs.response(Me.StartingX))
        plotData(New DrawingEventArgs.response(Me.EndingX))
    End Sub

    Private Sub internalDraw(sender As Object, e As EventArgs)
        If Me.Gráfico Is Nothing Then Exit Sub
        Me._status = StatusEnum.Drawing
        Try

            Dim d As New DrawingEventArgs(Me.CurrentX)

            'd.Element = CurrentElement

            RaiseEvent Draw(Me, d)

            'CurrentElement = d.Element
            If Not d.Y Is Nothing Then
                For Each response As DrawingEventArgs.response In d.Y
                    plotData(response)
                Next
            End If
            Me.Gráfico.AutoRange()

            Me.CurrentX = CurrentX + StepX
            If CurrentX > EndingX Then [Stop]()

            Select Case d.option
                Case DrawingEventArgs.Options.Continue

                Case DrawingEventArgs.Options.Stop
                    [Stop]()
            End Select

        Catch ex As Exception
            Stop
        End Try

    End Sub

    Public Event Draw As EventHandler(Of DrawingEventArgs)
    Public Event StartEvent As EventHandler
    Public Event StopEvent As EventHandler

    Public Sub Start()

        Me._status = StatusEnum.Starting
        CurrentX = StartingX
        plotArea()
        [Continue]()
        RaiseEvent StartEvent(Me, New EventArgs)
    End Sub

    Public Sub [Stop]()
        Me._status = StatusEnum.Stopping
        Timer.Stop()
        CurrentX = Nothing

        RaiseEvent StopEvent(Me, New EventArgs)
        Me._status = StatusEnum.Ready
    End Sub

    Public Sub [Continue]()
        Timer.Start()
    End Sub

    Public Sub Pause()
        Timer.Stop()
        Me._status = StatusEnum.paused
    End Sub

    Public Property timeInterval As Double
        Get
            Return Me.Timer.Interval
        End Get
        Set(value As Double)
            If value < 1 Then value = 1
            Me.Timer.Interval = value
        End Set
    End Property

    'Velocidad = cambio/tiempo
    'tiempo = cambio/velocidad
    Public Property Velocity As Double
        Get
            Return StepX / timeInterval
        End Get
        Set(value As Double)
            Me.timeInterval = StepX / value
        End Set
    End Property

    Public Property StartingX As Double = 0
    Public Property EndingX As Double = 100
    Public Property StepX As Double = 1
    Public Property CurrentX As Double = 0
    Public ReadOnly Property Status As StatusEnum
        Get
            Return _status
        End Get
    End Property


    Protected Overrides Sub finalize()
        Timer.Stop()

        Timer.Dispose()
        Timer = Nothing
        MyBase.Finalize()
    End Sub
End Class