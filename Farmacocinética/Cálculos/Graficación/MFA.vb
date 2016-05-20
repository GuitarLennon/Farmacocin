' (C) ARTURO JUAREZ FLORES 2016

Imports System.Drawing

Namespace Farmacocinética
    Public Class ModeloFarmacocinéticoAnimado
        Inherits ModeloGraficador

#Region "INSTANCE VARIABLES"

        Private CustomStartDosage As Double()
        Private Property _cmax As Double
        Private Property _tmax As Double
        Private Const precision As Double = 1.0E-20

#End Region

#Region "LABORATORY PROPERTIES"

        Private ReadOnly Property InicioDosis As Double()
            Get

                If Me.Dosificación = TipoDosificación.Múltiple Then

                    Dim l As New List(Of Double)
                    For i = 1 To DosisTotales
                        l.Add((i - 1) * IntervaloEntreDosis)
                    Next
                    Return l.ToArray

                ElseIf Me.Dosificación = TipoDosificación.Única Then

                    Return New Double() {0}

                ElseIf Me.Dosificación = TipoDosificación.Error Then

                    Return Nothing

                ElseIf Me.Dosificación = TipoDosificación.Manual Then

                    If CustomStartDosage Is Nothing Then
                        Dim l As New List(Of Double)
                        For i = 1 To DosisTotales
                            l.Add((i - 1) * IntervaloEntreDosis)
                        Next
                        CustomStartDosage = l.ToArray
                    End If

                    'If CustomStartDosage Is Nothing Then CustomStartDosage = New Double() {0}

                    Return Me.CustomStartDosage

                End If

                Return Nothing

            End Get
        End Property

        Public ReadOnly Property TotalDosis As Double
            Get
                Return Dosis * DosisTotales
            End Get
        End Property

        Public Sub AdministrarDosis()
            If CustomStartDosage Is Nothing Then CustomStartDosage = New Double() {0}
            ReDim Preserve CustomStartDosage(CustomStartDosage.Count)
            CustomStartDosage(CustomStartDosage.GetUpperBound(0)) = CurrentX
        End Sub

        Public Property Biodisponibilidad As Double
        Public Property ConstanteAbsorción As Double
        Public Property ConstanteEliminación As Double
        Public Property ConstanteMichaelisMenten As Double
        Public Property Dosificación As TipoDosificación = TipoDosificación.Error
        Public Property Dosis As Double
        Public Property DosisCarga As Double
        Public Property DosisTotales As Integer
        Public Property IntervaloEntreDosis As Double
        Public Property MostrarAcotaciones As Boolean = False
        Public Property MostrarAdministraciones As Boolean = False
        Public Property MostrarAUC As Boolean = False
        Public Property MostrarCmaxTmax As Boolean = False
        Public Property MostrarCPT0 As Boolean = False
        Public Property MostrarSemilogaritmo As Boolean = False
        Public Property SoloEliminacíón As Boolean = False
        Public Property TipoEliminación As GradosDeEliminación
        Public Property tLag As Double
        Public Property UsarCarga As Boolean
        Public Property VMax As Double
        Public Property VolumenDistribución As Double

        Public ReadOnly Property CoeficienteQ As Double
            Get
                Return (Biodisponibilidad * Dosis) / VolumenDistribución
            End Get
        End Property

        Public ReadOnly Property CoeficienteQTotal As Double
            Get
                Return (Biodisponibilidad * Dosis * DosisTotales) / VolumenDistribución
            End Get
        End Property

        Public ReadOnly Property CoeficienteK As Double
            Get
                Dim c As Double = (ConstanteAbsorción / (ConstanteAbsorción - ConstanteEliminación))
                If Double.IsInfinity(c) Then Return 1 Else Return c
            End Get
        End Property

        Public ReadOnly Property AUC As Double
            Get
                If Dosificación = TipoDosificación.Única And TipoEliminación = GradosDeEliminación.Primer_Orden Then
                    'Return PK_Pool.AUC_0ToInf(C0, ConstanteEliminación, A0, ConstanteAbsorción) [g*h/l]
                    Return CoeficienteQ * getUnit(unit) / ConstanteEliminación
                Else
                    Return AUC(0, Duración)
                End If
            End Get
        End Property

        Public ReadOnly Property AUC(inicio As Double, final As Double) As Double
            Get
                Return AUC_aTob(Registro.ToArray, inicio, final, StepX)
            End Get
        End Property

        ReadOnly Property Tmax As Double
            Get
                Return _tmax
            End Get
        End Property

        ReadOnly Property Cmax As Double
            Get
                Return _cmax
            End Get
        End Property

#End Region

#Region "METHODS"

        Sub New(gráfico As AxNTGRAPHLib.AxNTGraph)
            MyBase.New(gráfico)
            AddHandler StopEvent, AddressOf Finalizado
            AddHandler PrePlotEvent, AddressOf PreDibujo
            AddHandler DrawEvent, AddressOf Dibujar
            AddHandler ClearEvent, AddressOf Limpiar
        End Sub

        Private Sub PreDibujo(sender As Object, e As PrePlotEventArgs)
            e.Autorange = False
            e.DrawAxis = True
            e.ylog = Me.MostrarSemilogaritmo

            DibujarMarcas()

        End Sub

        Private Sub autoRange()

            If Not MostrarSemilogaritmo Then

                Dim max As Double = 1 ' * getUnit(unit)

                'hay que decidir si CPT0 o CMAX es mayor (tomando en cuenta que Cmax se calcula con dosis múltiples)

                If _cmax > max Then max = _cmax
                If MostrarCPT0 Then If (CoeficienteQ * getUnit(unit)) > max Then max = CoeficienteQ * getUnit(unit)

                Gráfico.SetRange(-0.5, EndingX, -0.1, max * 1.1)

                Dim range As Double = Me.EndingX - Me.StartingX

                Dim i As Short = Gráfico.Element
                Gráfico.Element = 0
                Gráfico.ElementLineColor = BackgroundColor
                Gráfico.Element = i

                plotData(New DrawingEventArgs.response(Me.StartingX) With {.y = max, .element = 0})
                plotData(New DrawingEventArgs.response(Me.EndingX) With {.y = 0, .element = 0})
                plotData(New DrawingEventArgs.response(Me.StartingX) With {.y = -0.5, .element = 0})
            Else

                Gráfico.SetRange(-0.5, EndingX, -4, 1)

            End If

        End Sub

        Public Sub Dibujar(sender As Object, e As DrawingEventArgs)

            Dim y As Double = CP(e.X - tLag)

            If SoloEliminacíón Then
                e.addResponse(CP(e.X - tLag, True), PrincipalElement.id)
            Else
                e.addResponse(y, PrincipalElement.id)
                e.addResponse(CP(e.X - tLag, True), SecundaryElement.id)
            End If

            If y > _cmax AndAlso Tmax() >= 0 Then
                _cmax = y
                _tmax = e.X
            Else

            End If

        End Sub

        Private Sub Finalizado()

            autoRange()

            Try
                'draw Cmax Tmax
                If Me.Dosificación = TipoDosificación.Única And Me.MostrarCmaxTmax Then
                    Gráfico.AddCursor(Me._tmax, Me._cmax, 0, Color.Gray)
                    Me.Gráfico.AddAnnotation(Me._tmax + 1, Me._cmax * 1, "c-max: " & FormatNumber(_cmax, 3) & " " & getUnitString(unit) &
                                                                    ", t-max: " & FormatNumber(_tmax, 3) & " h", BackgroundColor, forecolor:=Me.PrincipalAxisColor)
                End If

                If Me.MostrarAUC Then
                    Me.Gráfico.AddAnnotation(Me._tmax / 3, Me._cmax / 2, " AUC " & FormatNumber(AUC(), 3) & " (h * " & getUnitString(unit) & ")^2", forecolor:=Me.PrincipalAxisColor)

                End If
                If Me.MostrarAdministraciones Then
                    If Me.InicioDosis Is Nothing Then Exit Sub

                    If Me.InicioDosis.Count > 0 Then
                        Dim i As Integer = 1
                        For Each d As Double In Me.InicioDosis

                            Dim c As New Coordenadas With {.x = d, .y = CP(d - tLag)}
                            If Not c.x = 0 Then
                                Me.Gráfico.AddCursor(c.x, c.y, color:=Me.SecundaryElement.lineColor, horizontal:=False, style:=2)
                                Me.Gráfico.AddAnnotation(c.x, c.y * 0.95, CStr(i), BackgroundColor, forecolor:=Me.PrincipalAxisColor)
                            End If
                            i = i + 1
                        Next
                    End If
                End If

                'añadir cursor móvil
                Gráfico.AddCursor(0, 0, Me.CursorStyle, Color.Gold, 0)

                ' C0
                If Me.MostrarCPT0 And Me.Dosificación = TipoDosificación.Única Then
                    Gráfico.AddCursor(0, CoeficienteQ * getUnit(unit), color:=Color.Violet, horizontal:=True)
                    Gráfico.AddAnnotation(Me.EndingX - Duración * 5 / 14, CoeficienteQ * getUnit(unit), "Concentración Tiempo Cero", BackgroundColor, Color.Violet, True, True)
                    Me.Gráfico.AddAnnotation(Me._tmax + 1, CoeficienteQ * getUnit(unit), "Cpt0: " & FormatNumber(CoeficienteQ * getUnit(unit), 3) & " " & getUnitString(unit), BackgroundColor, forecolor:=Me.PrincipalAxisColor)
                End If

            Catch ex As Exception

            End Try

        End Sub

        Public Sub DibujarMarcas()

            If MostrarSemilogaritmo Then Exit Sub

            Dim range As Double = Me.EndingX - Me.StartingX

            For Each marca As Marca In Me.Marcas

                'Gráfico.AddAnnotation(EndingX - range * 5 / 14, marca.y * getUnit(unit), marca.name, BackgroundColor, marca.color, True, marca.show)
                Gráfico.AddAnnotation(EndingX - range * 5 / 14, marca.y, marca.name, BackgroundColor, marca.color, True, marca.show)

                Dim e As New Element() With {.lineColor = marca.color,
                                         .id = Gráfico.ElementCount,
                                         .lineType = marca.style,
                                         .name = marca.name,
                                         .pointColor = Color.Empty,
                                         .pointSymbol = NTGRAPHLib.SymbolType.Nosym,
                                         .show = marca.show,
                                         .solidPoint = True,
                                         .width = marca.size}
                e.ToGraph(Gráfico)
                'Gráfico.PlotXY(StartingX, marca.y * getUnit(unit), e.id)
                'Gráfico.PlotXY(EndingX, marca.y * getUnit(unit), e.id)
                Gráfico.PlotXY(StartingX, marca.y, e.id)
                Gráfico.PlotXY(EndingX, marca.y, e.id)
            Next

        End Sub

        Public Sub Limpiar()
            Me._cmax = -1
            Me._tmax = -1
            Me.CustomStartDosage = Nothing
        End Sub

#End Region

#Region "Métodos Farmacológicos"

        'Concentraciones Plasmáticas
        Function CP(x As Double, Optional OmitirAbsorcíón As Boolean = False) As Double
            'If x = 0 Then Stop

            Dim returning As Double
            Select Case Me.Dosificación
                Case TipoDosificación.Manual
                    returning = DosificaciónMúltipleOManual(x, OmitirAbsorcíón) * getUnit(unit)
                Case TipoDosificación.Múltiple
                    returning = DosificaciónMúltipleOManual(x, OmitirAbsorcíón) * getUnit(unit)
                Case TipoDosificación.Única
                    returning = Dosificaciónúnica(x, OmitirAbsorcíón) * getUnit(unit)
            End Select

            Return returning
        End Function

        Private Function Dosificaciónúnica(x As Double, Optional omitirAdministración As Boolean = False) As Double
            Dim c As Double
            Select Case Me.TipoEliminación
                Case GradosDeEliminación.Orden_Cero
                    c = ZeroOrderElimination(x, omitirAbsorción:=omitirAdministración)
                Case GradosDeEliminación.Primer_Orden
                    If omitirAdministración Then
                        c = CoeficienteQ * (Math.E ^ (-ConstanteEliminación * x))
                    Else
                        c = CoeficienteQ * CoeficienteK * (Math.E ^ (-ConstanteEliminación * x) - Math.E ^ (-ConstanteAbsorción * x))
                    End If
                Case GradosDeEliminación.Michaelis_Menten
                    c = MichaelisMentenElimination(x, OmitirAbsorción:=omitirAdministración)
                Case Else
                    Stop
            End Select

            If c > 0 Then Return c Else Return 0
        End Function

        'Private LastCiclo As Integer = 0

        Private Function DosificaciónMúltipleOManual(x As Double, Optional omitirAdministración As Boolean = False) As Double
            If x <= 0 Then
                ' If Not Recursivo Then LastCiclo = 0
                Return 0
            End If

            Dim Ciclo_Actual As Ciclo = averiguar_ciclo(x)

            Dim previousConcentration As Double = 0
            Dim previousDosage As Double = 0
            Dim currentDosage As Double = 0

            If Ciclo_Actual.Ciclo > 0 Then

                Debug.Indent()
                previousConcentration = DosificaciónMúltipleOManual(Ciclo_Actual.Past, True)

                previousDosage = previousConcentration * VolumenDistribución / Biodisponibilidad

                currentDosage = previousDosage + Dosis

                Debug.Unindent()

            ElseIf Ciclo_Actual.Ciclo = -1 Then
                currentDosage = Me.DosisTotales * Dosis
            Else
                currentDosage = Dosis
            End If

            Dim CurrentConcentration As Double

            Select Case Me.TipoEliminación
                Case GradosDeEliminación.Orden_Cero
                    CurrentConcentration = ZeroOrderElimination(Ciclo_Actual.Remaining,
                                                            currentDosage,
                                                            omitirAdministración,
                                                            previousConcentration)
                Case GradosDeEliminación.Primer_Orden
                    CurrentConcentration = EliminaciónPrimerOrden(Ciclo_Actual.Remaining,
                                                                   dosis:=currentDosage,
                                                                   omitirAbsorción:=omitirAdministración,
                                                                   previousConcentration:=previousConcentration
                                                                    )
                Case GradosDeEliminación.Michaelis_Menten
                    ' If Ciclo_Actual.Ciclo > LastCiclo Then _ln = -1
                    CurrentConcentration = MichaelisMentenElimination(Ciclo_Actual.Remaining,
                                                                      Ciclo_Actual.Ciclo,
                                                                      currentDosage,
                                                                      omitirAdministración,
                                                                      previousConcentration
                                                                      )

                    'LastCiclo = Ciclo_Actual.Ciclo
                Case Else
                    Stop
            End Select

            If Debug.IndentLevel = 0 Then
                Debug.Print("x: {0} {1}, Conc. Previa {2}, Dosis previa/actual {3} / {4}, Conc. Actual {5}",
                        FormatNumber(x, 3),
                        Ciclo_Actual,
                        FormatNumber(previousConcentration, 3),
                        FormatNumber(previousDosage, 3),
                        FormatNumber(currentDosage, 3),
                        FormatNumber(CurrentConcentration, 3)
                        )
            End If

            Return CurrentConcentration
        End Function

        Private Function ZeroOrderElimination(x As Double,
                                          Optional dosis As Double = -1,
                                          Optional omitirAbsorción As Boolean = False,
                                          Optional previousConcentration As Double = 0) As Double
            Dim c As Double, q As Double

            If dosis < 0 Then
                q = CoeficienteQ
            Else
                q = (dosis * Biodisponibilidad / VolumenDistribución)
            End If

            If x < 0 Then Return 0
            If x = 0 Then If omitirAbsorción Then Return q Else Return 0

            If omitirAbsorción Then
                c = q - (VMax * x)
            Else
                c = q - (VMax * x) - (q - (VMax * x) - previousConcentration) * Math.E ^ (-(ConstanteAbsorción) * x)
            End If

            If c < 0 Then Return 0

            Return c
        End Function

        Private _ln() As Double = {-1}

        Private Function MichaelisMentenElimination(T As Double,
                                                    Optional ciclo As Integer = 0,
                                                    Optional dosis As Double = -1,
                                                    Optional OmitirAbsorción As Boolean = False,
                                                    Optional previousConcentration As Double = 0) As Double
            'Static _ln As Double = -1

            If T <= 0 Then
                If OmitirAbsorción Then
                    _ln = {-1}
                    Return (dosis * Biodisponibilidad / VolumenDistribución)

                Else
                    _ln = {-1}
                    Return 0
                End If
            Else
                If _ln.GetUpperBound(0) <= ciclo Then
                    ReDim Preserve _ln(ciclo)
                End If
            End If

            Dim C0 As Double
            Dim VmT As Double
            Dim Km As Double
            Dim Cp As Double
            Dim ln As Double

            If dosis < 0 Then
                C0 = CoeficienteQ
            Else
                C0 = (dosis * Biodisponibilidad / VolumenDistribución)
            End If

            VmT = VMax * T
            Km = ConstanteMichaelisMenten
            Cp = C0
            If _ln(ciclo) = -1 Then _ln(ciclo) = Math.Log(C0 / Cp)
            'ln = Math.Log(C0 / Cp)
            ln = _ln(ciclo)
            '
            ' Cp = c0 - VmT + km * ln(c0/cp)
            '

            Do
                Cp = C0 - VmT + Km * ln
                ln = ln + 0.001
            Loop Until C0 - Cp - VmT + Km * Math.Log(C0 / Cp) < 0.000001

            _ln(ciclo) = ln

            If Not OmitirAbsorción Then Cp = Cp - (Cp - previousConcentration) * Math.E ^ (-(ConstanteAbsorción) * T)
            Return Cp

        End Function

        Public Function EliminaciónPrimerOrden(x As Double,
                                                      Optional dosis As Double = -1,
                                                      Optional omitirAbsorción As Boolean = False,
                                                      Optional previousConcentration As Double = 0) As Double

            Dim q As Double = 0

            Dim c As Double = q * CoeficienteK * (Math.E ^ (-ConstanteEliminación * x))

            If omitirAbsorción Then
                Return c
            End If

            Dim abs As Double = (c - previousConcentration) * CoeficienteK * Math.E ^ (-(ConstanteAbsorción) * x)

            Return c - abs
        End Function

        Private Function averiguar_ciclo(x As Double) As Ciclo
            If IntervaloEntreDosis = 0 Then Return New Ciclo With {.Ciclo = -1, .Remaining = x, .Past = 0}
            Dim inicios As Double() = Me.InicioDosis
            For i As Integer = inicios.Count - 1 To 0 Step -1
                If x > inicios(i) Then Return New Ciclo With {.Ciclo = i, .Remaining = x - inicios(i), .Past = inicios(i)}
            Next
            Return New Ciclo With {.Ciclo = 0, .Remaining = 0}
        End Function

#End Region

    End Class
End Namespace