Imports System.Windows.Forms
Imports AxNTGRAPHLib
Imports Farmacocinética.TimingGraphicator
Imports System.Drawing

Public Class ModeloFarmacocinéticoAnimado
#Region "Enums and clases"
    Public Enum GradosDeEliminación
        Primer_Orden
        Michaelis_Menten
        Orden_Cero
    End Enum

    Public Enum TipoDosificación
        [Error]
        Única
        Múltiple
        Manual
    End Enum

    Public Class PrePlotEventArgs
        Inherits EventArgs
        Property Autorange As Boolean = True
        Property DrawAxis As Boolean = True
        Property AnnotateStarts As Boolean = True
    End Class

    Public Class Marca
        Public Property y As Single
        Public Property color As Color
        Public Property size As Integer
        Public Property name As String
        Public Property show As Boolean
    End Class

    Public Structure Range
        Property MinX As Double
        Property MinY As Double
        Property MaxX As Double
        Property MaxY As Double
    End Structure

    Public Enum Units
        microgramos_por_mililitro
        gramos_por_litro
        g_por_decilitro
        mg_por_100ml
    End Enum

    Public Shared Function getUnitString(unit As Units, Optional log As Boolean = False) As String
        Select Case unit
            Case Units.microgramos_por_mililitro
                If log Then Return "log(mcg/mL)" Else Return "mcg/mL"
            Case Units.gramos_por_litro
                If log Then Return "log(g/L)" Else Return "g/L"
            Case Units.mg_por_100ml
                If log Then Return "log(mg/100mL)" Else Return "mg/100mL"
            Case Units.g_por_decilitro
                If log Then Return "log(g/dL)" Else Return "g/dL"
            Case Else
                Return "unidades Desconocidas"
        End Select
    End Function

    Public Shared Function getUnit(unit As Units) As Double
        Select Case unit
            Case Units.microgramos_por_mililitro
                '    g    1000000 g      1 l
                ' 1 --- (-----------)(---------)
                '    l       1 g       1000 ml
                Return 1000
            Case Units.gramos_por_litro
                '    g    1 g    1 l
                ' 1 --- (-----)(-----)
                '    l    1 g    1 l
                Return 1000 / 1000
            Case Units.mg_por_100ml
                '    g    1000 mg      1 l        100 ml
                ' 1 --- (---------)(---------)(------------)
                '    l      1 g      1000 ml    1 (100 mL)
                Return 100
            Case Units.g_por_decilitro
                '    g    1 g    10 dl
                ' 1 --- (-----)(-------)
                '    l    1 g     1 l
                Return 10
            Case Else
                Return 1
        End Select
    End Function
#End Region

#Region "INSTANCE VARIABLES"

    Private _gráfico As AxNTGraph
    Private ReadOnly Timer As New Timer
    Private CustomStartDosage As Double()
    Private Annotations As Boolean = True

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

                Return Me.CustomStartDosage

            End If

            Return Nothing

        End Get
    End Property

    Public Property VolumenDistribución As Double
    'Public Property HorasDeEstudio As Double
    Public Property Dosis As Double
    Public Property Dosificación As TipoDosificación = TipoDosificación.Error
    Public Property IntervaloEntreDosis As Double
    Public Property UsarCarga As Boolean
    Public Property DosisCarga As Double
    Public Property DosisTotales As Double
    Public Sub AdministrarDosis()
        If CustomStartDosage Is Nothing Then CustomStartDosage = New Double() {0}
        ReDim Preserve CustomStartDosage(CustomStartDosage.Count)
        CustomStartDosage(CustomStartDosage.GetUpperBound(0)) = CurrentX
    End Sub
    Public Property Biodisponibilidad As Double
    Public Property ConstanteAbsorción As Double
    Public Property ConstanteEliminación As Double
    Public Property TipoEliminación As GradosDeEliminación
    Public Property VMax As Double
    Public Property unit As Units
    'Public Property kMichaelis As Double

    'Calculados
    Public Registro As New List(Of Coordenadas)

    Public ReadOnly Property C0 As Double
        Get
            Return PK_Pool.C0(Biodisponibilidad, Dosis, ConstanteAbsorción, VolumenDistribución, ConstanteEliminación) * 10 ^ 3
        End Get
    End Property

    Public ReadOnly Property A0 As Double
        Get
            Return PK_Pool.A(Biodisponibilidad, Dosis, ConstanteAbsorción, VolumenDistribución, ConstanteEliminación)
        End Get
    End Property

    Public ReadOnly Property CoeficienteQ As Double
        Get
            Return (Biodisponibilidad * Dosis) / VolumenDistribución
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
            If Dosificación = TipoDosificación.Única Then
                'Return PK_Pool.AUC_0ToInf(C0, ConstanteEliminación, A0, ConstanteAbsorción)
                Return CoeficienteQ / ConstanteEliminación
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

    ReadOnly Property Cmax_ee As Double
        Get
            Return PK_Pool.Cmax_ee(Dosis, VolumenDistribución, ConstanteEliminación, IntervaloEntreDosis) * 10 ^ 3
        End Get
    End Property

    ReadOnly Property Cmin_ee As Double
        Get
            Return PK_Pool.Cmin_ee(Dosis, VolumenDistribución, ConstanteEliminación, IntervaloEntreDosis) * 10 ^ 3
        End Get
    End Property

    ReadOnly Property Tmax_ss As Double
        Get
            Return PK_Pool.tmax_ss(ConstanteAbsorción, ConstanteEliminación, IntervaloEntreDosis)
        End Get
    End Property

    Private Property _cmax As Double
    Private Property _tmax As Double

    ReadOnly Property Tmax As Double
        Get
            If Dosificación = TipoDosificación.Múltiple Then
                Return Tmax_ss
            End If
            Return PK_Pool.Tmax(ConstanteAbsorción, ConstanteEliminación) * 10 ^ 2
            'Return _tmax
        End Get
    End Property

    ReadOnly Property Cmax As Double
        Get
            If Dosificación = TipoDosificación.Única Then
                Return PK_Pool.Cmax(CoeficienteQ, ConstanteEliminación, Tmax) * 10 ^ 2
            ElseIf Dosificación = TipoDosificación.Múltiple Then
                Return Cmax_ee

            End If
            Return -1

        End Get
    End Property

#End Region

#Region "GRAPHICATOR PROPERTIES"

    Private Property Gráfico As AxNTGRAPHLib.AxNTGraph
        Get
            If _gráfico Is Nothing Then Stop
            Return _gráfico
        End Get
        Set(value As AxNTGRAPHLib.AxNTGraph)

            _gráfico = value
        End Set
    End Property

    Public Property GraphicName As String
    Public Property UnitsOrdered As String
    Public Property UnitsAbscises As String

    Public Property StartingX As Double = 0
    Public Property EndingX As Double = 100
    Public Property StepX As Double = 0.5
    Public Property CurrentX As Double = 0

    Public Property PrincipalElement As Element
    Public Property SecundaryElement As Element
    Public Property BackgroundColor As Color

    Public Property DisplayOnSemilogarithm As Boolean = False

    Public ReadOnly Property Duración As Double
        Get
            Return EndingX - StartingX
        End Get
    End Property

    Public Property timerInterval As Double
        Get
            Return Me.Timer.Interval / 0.01
        End Get
        Set(value As Double)
            If value < 1 Then
                Me.StepX = 0.01 * Me.StepX / value
                Me.Timer.Interval = 1
            Else
                Me.Timer.Interval = value
            End If
        End Set
    End Property

    Public Property VelocidadDelTrazo As Double
        Get
            Return StepX / timerInterval
        End Get
        Set(value As Double)
            Me.timerInterval = StepX / (value)
        End Set
    End Property

    Public Property MostrarAcotaciones As Boolean = False
    Public Property SoloEliminacíón As Boolean = False

    Public Property Marcas As Marca()

    Public ReadOnly Property Rango() As Range
        Get
            If Me.DisplayOnSemilogarithm Then
                Return New Range With {.MinX = 0, .MaxX = EndingX, .minY = StartingX - 1, .MaxY = Math.Abs(Math.Log10(_cmax)) * 1.15}
            Else
                Return New Range With {.MinX = 0, .MaxX = EndingX, .minY = StartingX - 1, .MaxY = _cmax * 1.15}
            End If
        End Get
    End Property

#End Region

#Region "CONSTRUCTORS"

    Sub New(gráfico As AxNTGRAPHLib.AxNTGraph, Optional UseInternalDraw As Boolean = True)
        If gráfico Is Nothing Then Stop
        Me.Gráfico = gráfico
        'Me.CurrentElement = element

        AddHandler Me.Timer.Tick, AddressOf internalDraw
        If UseInternalDraw Then AddHandler Me.Draw, AddressOf Me_Draw
    End Sub

#End Region

#Region "EVENTS"

    Public Event Draw As EventHandler(Of DrawingEventArgs)

    Public Event PrePlot As EventHandler

    Public Event StopEvent As EventHandler

#End Region

#Region "METHODS"

    Private Sub internalDraw(sender As Object, e As EventArgs)
        If Me.Gráfico Is Nothing Then Exit Sub
        Dim d As New DrawingEventArgs(Me.CurrentX)

        Try
            RaiseEvent Draw(Me, d)

            If Not d.Y Is Nothing Then
                Registro.Add(New Coordenadas With {.x = d.X, .y = d.Y(0).y})
                For Each response As DrawingEventArgs.response In d.Y
                    plotData(response)
                Next
            End If

            Me.Gráfico.AutoRange()

            Me.CurrentX = CurrentX + StepX
            If CurrentX > EndingX Then
                Timer.Stop()
                [Stop]() : Exit Sub
            End If

            Select Case d.option
                Case DrawingEventArgs.Options.Continue

                Case DrawingEventArgs.Options.Stop
                    Timer.Stop()
                    [Stop]()
            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Me_Draw(sender As Object, e As DrawingEventArgs)

        If Me.Gráfico Is Nothing Then [Stop]() : Exit Sub
        If Me.Gráfico.ElementCount <= PrincipalElement.id Then [Stop]() : Exit Sub

        Dim y As Double = CP(e.X)

        If SoloEliminacíón Then
            e.addResponse(CP(e.X, True), PrincipalElement.id)
        Else
            e.addResponse(y, PrincipalElement.id)
            e.addResponse(CP(e.X, True), SecundaryElement.id)
        End If

        If y > _cmax AndAlso Tmax >= 0 Then
            _cmax = y
            _tmax = e.X
        Else

        End If

    End Sub

    Private Sub Me_Clear()
        Me.Timer.Stop()
        Me.CurrentX = 0
        Gráfico.ClearGraph()
        Me.Registro.Clear()
        Me._cmax = -1
        Me._tmax = -1
        Me.CustomStartDosage = Nothing

        While Gráfico.AnnoCount > 0
            Gráfico.DeleteAnnotation(0)
        End While

        While Gráfico.CursorCount > 0
            Gráfico.DeleteCursor(0)
        End While

    End Sub

    Private Sub plotData(response As DrawingEventArgs.response)
        If Gráfico Is Nothing Then Exit Sub
        Gráfico.PlotXY(response.x, response.y, response.element)
    End Sub

    Private Sub autoRange()
        Dim max As Double

        If Me.DisplayOnSemilogarithm Then
            If _cmax < CoeficienteQ Then max = Math.Log(CoeficienteQ * getUnit(unit) * 1.1) Else max = Math.Log(_cmax * 1.1)
            'Gráfico.SetRange(-1, EndingX, StartingX - 1, Math.Abs(Math.Log10(max)) * 1.15)
        Else
            If _cmax < CoeficienteQ Then max = CoeficienteQ * getUnit(unit) * 1.1 Else max = _cmax * 1.1
            'Gráfico.SetRange(-1, EndingX, 0, max * 1.15)
        End If

        Dim range As Double = Me.EndingX - Me.StartingX

        plotData(New DrawingEventArgs.response(Me.StartingX) With {.y = max, .element = 0})
        plotData(New DrawingEventArgs.response(Me.EndingX) With {.y = 0, .element = 0})

        Gráfico.AutoRange()
    End Sub

    Private Sub drawAxis()
        Dim range As Double = Me.EndingX - Me.StartingX
        Gráfico.AddCursor(0, 0, 0, Drawing.Color.White)
        Gráfico.Caption = Me.GraphicName
        Gráfico.XLabel = UnitsAbscises
        Gráfico.XGridNumber = 10
        Gráfico.YLabel = UnitsOrdered & getUnitString(Me.unit)
        Gráfico.YGridNumber = 25

        For Each marca As Marca In Me.Marcas
            'Gráfico.AddCursor(Me.EndingX - range * 2 / 7, marca.y * getUnit(unit), 0, marca.color, 1, True, marca.show)
            Gráfico.AddCursor(Me.EndingX - range * 2 / 7, marca.y, 0, marca.color, 1, True, marca.show)
            'Gráfico.Cursor
            'Gráfico.AddAnnotation(Me.EndingX - range * 2 / 7, marca.y * getUnit(unit), marca.name, BackgroundColor, marca.color, True, marca.show)
            Gráfico.AddAnnotation(Me.EndingX - range * 2 / 7, marca.y, marca.name, BackgroundColor, marca.color, True, marca.show)

            'Dim e As New Element() With {.lineColor = marca.color,
            '                             .id = Gráfico.ElementCount,
            '                             .lineType = NTGRAPHLib.LineType.Solid,
            '                             .name = marca.name,
            '                             .pointColor = Color.Empty,
            '                             .pointSymbol = NTGRAPHLib.SymbolType.Nosym,
            '                             .show = marca.show,
            '                             .solidPoint = True,
            '                             .width = marca.size}
            'e.ToGraph(Gráfico)
            'Gráfico.PlotXY(Me.Rango.MinX, marca.y, e.id)
            'Gráfico.PlotXY(Me.Rango.MaxX, marca.y, e.id)
        Next

        Dim change As Double = CoeficienteQ * getUnit(unit) / Math.E
        'Cambio de cinética
        'Gráfico.AddCursor(0, change, 0, Color.Chocolate)
        'Gráfico.AddAnnotation(Me.EndingX - range * 2 / 7, change, "Cambio de cinética", BackgroundColor, Color.Chocolate, True, True)

        ' C0
        Gráfico.AddCursor(0, CoeficienteQ * getUnit(unit), color:=Color.Violet)
        Gráfico.AddAnnotation(Me.EndingX - range * 2 / 7, CoeficienteQ * getUnit(unit), "Concentración tiempo cero", BackgroundColor, Color.Violet, True, True)

    End Sub

    Public Sub Instant()
        'Clear()

        Dim d As New PrePlotEventArgs

        RaiseEvent PrePlot(Me, d)

        Gráfico.PlotAreaColor = BackgroundColor

        If d.DrawAxis Then drawAxis()

        If d.Autorange Then autoRange()

        If d.AnnotateStarts Then Me.Annotations = True Else Me.Annotations = False

        SecundaryElement.ToGraph(Me.Gráfico)

        PrincipalElement.ToGraph(Me.Gráfico)

        'For Me._CurrentX = StartingX To EndingX Step StepX
        While Me.CurrentX < Me.EndingX

            Me.internalDraw(Me, New EventArgs)
        End While
        'Next

        Me_stopEvent()

    End Sub

    Public Sub Start()

        'Clear()

        Dim d As New PrePlotEventArgs

        RaiseEvent PrePlot(Me, d)

        Gráfico.PlotAreaColor = BackgroundColor

        If d.DrawAxis Then drawAxis()

        If d.Autorange Then autoRange()

        If d.AnnotateStarts Then Me.Annotations = True Else Me.Annotations = False

        SecundaryElement.ToGraph(Me.Gráfico)

        PrincipalElement.ToGraph(Me.Gráfico)

        CurrentX = StartingX

        [Continue]()

    End Sub

    Public Sub [Stop]()

        Timer.Stop()

        If Me.Annotations Then Me_stopEvent()

        CurrentX = Nothing

        RaiseEvent StopEvent(Me, New EventArgs)

    End Sub

    Public Sub [Continue]()
        Timer.Start()
    End Sub

    Public Sub Pause()
        Timer.Stop()
    End Sub

    Public Sub Clear()
        Me_Clear()
    End Sub

    Private Sub Me_stopEvent()
        autoRange()
        Try
            'draw Cmax Tmax
            If Me.Dosificación = TipoDosificación.Única And Me.MostrarAcotaciones Then
                Gráfico.AddCursor(Me._tmax, Me._cmax, 0, Color.Gray)
                Me.Gráfico.AddAnnotation(Me._tmax + 1, Me._cmax * 1, "c-max: " & FormatNumber(_cmax, 3) & " " & getUnitString(unit) &
                                                                    ", t-max: " & FormatNumber(_tmax, 3) & " h", BackgroundColor)
            End If

            If Me.MostrarAcotaciones Then
                Me.Gráfico.AddAnnotation(Me._tmax / 3, Me._cmax / 2, " AUC " & FormatNumber(AUC(), 3) & " " & getUnitString(unit) &
                                         "^2")

                'Me.Gráfico.AddAnnotation((EndingX - StartingX) / 10, Me.CoeficienteQ * 1.1, " Concentración tiempo cero " &
                '                          FormatNumber(Me.CoeficienteQ, 3) & " " & getUnitString(unit))

            End If

            If Me.InicioDosis Is Nothing Then Exit Sub
            If Me.InicioDosis.Count > 0 Then
                Dim i As Integer = 1
                For Each d As Double In Me.InicioDosis

                    Dim c As New Coordenadas With {.x = d, .y = CP(d)}
                    If Not c.x = 0 Then
                        Me.Gráfico.AddCursor(c.x, c.y, color:=Me.SecundaryElement.lineColor, horizontal:=False, style:=2)
                        Me.Gráfico.AddAnnotation(c.x, c.y * 0.95, i, BackgroundColor)
                    End If
                    i = i + 1
                Next
            End If

            Gráfico.AddCursor(0, 0, 2, Color.Gold, 0)

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Métodos Farmacológicos"

    Private Const precision As Double = 1.0E-20

    Private Structure Ciclo
        Property Ciclo As Integer
        Property Remaining As Double
        Property Past As Double

        Public Overrides Function ToString() As String
            Return String.Format("Ciclo {0}, restante {1}", Ciclo, FormatNumber(Remaining, 3))
        End Function
    End Structure

    'Concentraciones Plasmáticas
    Function CP(x As Double, Optional OmitirAbsorcíón As Boolean = False)

        Dim returning As Double
        Select Case Me.Dosificación
            Case TipoDosificación.Manual
                returning = DosificaciónMúltipleOManual(x, OmitirAbsorcíón) * getUnit(unit)
            Case TipoDosificación.Múltiple
                returning = DosificaciónMúltipleOManual(x, OmitirAbsorcíón) * getUnit(unit)
            Case TipoDosificación.Única
                returning = Dosificaciónúnica(x, OmitirAbsorcíón) * getUnit(unit)
        End Select

        If Me.DisplayOnSemilogarithm Then
            If returning = 0 Then Return 0
            returning = Math.Log10(returning)
        Else
            returning = returning

        End If

        'If returning > _cmax AndAlso Tmax >= 0 Then
        '    _cmax = returning
        '    _tmax = x
        'Else
        '
        'End If

        Return returning
    End Function

    <Obsolete>
    Function CPWithoutAdministration(x As Double)
        If x <= 0 Then Return CoeficienteQ * getUnit(unit)

        Dim p As ModeloFarmacocinéticoAnimado = Me.MemberwiseClone

        p.ConstanteAbsorción = Double.PositiveInfinity

        Dim returning As Double

        Select Case p.Dosificación
            Case TipoDosificación.Manual
                returning = p.DosificaciónMúltipleOManual(x, True) * getUnit(unit)
            Case TipoDosificación.Múltiple
                returning = p.DosificaciónMúltipleOManual(x, True) * getUnit(unit)
            Case TipoDosificación.Única
                returning = p.Dosificaciónúnica(x, True) * getUnit(unit)
        End Select

        If p.DisplayOnSemilogarithm Then
            If returning = 0 Then Return 0
            returning = Math.Log10(returning)
        Else
            returning = returning

        End If

        Return returning

    End Function

    'Esquemas de dosificación
    Private Function Dosificaciónúnica(x As Double, Optional omitirAdministración As Boolean = False) As Double
        'If x - tlag <= 0 Then Return 0
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
                'c = CoeficienteQ * EliminaciónPrimerOrden(x, omitirAbsorción:=omitirAdministración)
            Case GradosDeEliminación.Michaelis_Menten
                c = MichaelisMentenElimination(x, OmitirAbsorción:=omitirAdministración)
            Case Else
                Stop
        End Select

        If c > 0 Then Return c Else Return 0
    End Function

    Private Function DosificaciónMúltipleOManual(x As Double, Optional omitirAdministración As Boolean = False) As Double
        Dim Ciclo_Actual As Ciclo = averiguar_ciclo(x)

        Dim previousConcentration As Double = 0
        Dim previousDosage As Double = 0
        Dim currentDosage As Double = 0

        If Ciclo_Actual.Ciclo > 0 Then
            Debug.Indent()
            previousConcentration = DosificaciónMúltipleOManual(Ciclo_Actual.Past)

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

                CurrentConcentration = MichaelisMentenElimination(Ciclo_Actual.Remaining,
                                                                   dosis:=currentDosage,
                                                                   OmitirAbsorción:=omitirAdministración,
                                                                   previousConcentration:=previousConcentration
                                                                   )
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

    Private Function MichaelisMentenElimination(x As Double,
                                           Optional dosis As Double = -1,
                                           Optional OmitirAbsorción As Boolean = False,
                                           Optional previousConcentration As Double = 0) As Double

        'If x < 0 Then Return 0
        If x <= 0 Then If OmitirAbsorción Then Return (dosis * Biodisponibilidad / VolumenDistribución) Else Return 0

        Dim result As Double = 0
        Dim ka As Double = ConstanteAbsorción
        Dim km As Double = ConstanteEliminación
        Dim t As Double = (x)
        Dim vmax As Double = Me.VMax / 10

        Dim q0 As Double

        If dosis <= -1 Then
            q0 = CoeficienteQ
        Else
            q0 = (dosis * Biodisponibilidad / VolumenDistribución)
        End If

        Dim qt As Double = q0 - (vmax * t)
        'Dim qt_1 As New List(Of Double)

        Do
            If Double.IsNaN(qt) Then qt = q0 - (vmax * t)

            Dim qt_1 As Double = q0 / (Math.E ^ ((vmax * t) / km) + q0 - qt)

            qt = km * Math.Log(q0 / qt_1) + q0 - (vmax * t)

            qt = q0 / (Math.E ^ ((vmax * t) / km) + q0 - qt)

            qt = km * Math.Log(q0 / qt) + q0 - (vmax * t)

            qt = q0 / (Math.E ^ ((vmax * t) / km) + q0 - qt)

            'ivisor = Math.E ^ parentesis'

            '            If Double.IsPositiveInfinity(divisor) Then
            'parentesis = ((q0 - VMax * t) + fracción1 - q0) / (km)
            'divisor = Math.E ^ parentesis
            'End If

            'qt = q0 / divisor

            If isInRange(CSng(result), CSng(qt)) Then Exit Do
            'If qt_1.Count > 250 Then
            ' qt_1.Remove(qt_1(0))
            ' End If

            'qt_1.Add(qt)

            If qt < 0 Then qt = -qt

            result = qt

            'qt = promedio(qt_1)

            'Debug.Print(result)

        Loop

        'result = result

        Dim percent As Double = result / q0 * 100

        'If (percent = 100 And Not t = 0) Then
        '    result = CoeficienteQ - (VMax * t)
        'End If

        'If result <= 0.005 Then
        '    result = CoeficienteQ - (VMax * t) + result
        'End If

        'If (percent = 100 And Not t = 0) Then
        '    result = CoeficienteQ - (VMax * t)
        'End If

        'If Not Double.IsPositiveInfinity(ka) Then
        'result = result - result * Math.E ^ (-(ka * 1.5) * t)
        'End If
        ' Debug.Print("t: {0} res: {1}", FormatNumber(t, 3), result)
        If OmitirAbsorción Then
            Return result
        End If
        Return result - (result - previousConcentration) * Math.E ^ (-(ka) * t)
    End Function

    Public Function EliminaciónPrimerOrden(x As Double,
                                                      Optional dosis As Double = -1,
                                                      Optional omitirAbsorción As Boolean = False,
                                                      Optional previousConcentration As Double = 0) As Double

        Dim q As Double = 0

        If dosis = -1 Then q = CoeficienteQ Else q = dosis * Biodisponibilidad / VolumenDistribución

        If x < 0 Then If omitirAbsorción Then Return q Else Return 0

        Dim c As Double = q * CoeficienteK * (Math.E ^ (-ConstanteEliminación * x))

        If omitirAbsorción Then
            Return c
        End If

        Dim abs As Double = (c - previousConcentration) * CoeficienteK * Math.E ^ (-(ConstanteAbsorción) * x)

        Return c - abs
    End Function

    'Miscelaneas
    <DebuggerStepThrough>
    Private Shared Function isInRange(query As Double, range As Double)
        If query < range - precision Then Return False
        If query > range + precision Then Return False
        Return True
    End Function

    Private Function promedio(ienumerable As IEnumerable(Of Double)) As Double
        Dim numeros As Double
        Dim sumatoria As Double

        For Each numero As Double In ienumerable
            sumatoria += numero
            numeros += 1
        Next
        Return sumatoria / numeros
    End Function

    Private Function averiguar_ciclo(x As Double) As Ciclo
        If IntervaloEntreDosis = 0 Then Return New Ciclo With {.Ciclo = -1, .Remaining = x, .Past = 0}
        Dim inicios As Double() = Me.InicioDosis
        For i As Integer = inicios.Count - 1 To 0 Step -1
            If x > inicios(i) Then Return New Ciclo With {.Ciclo = i, .Remaining = x - inicios(i), .Past = inicios(i)}
        Next
        Return New Ciclo With {.Ciclo = 0, .Remaining = 0}
    End Function

    Private Function DosificaciónMúltiple(x As Double)
        Dim c As New List(Of Double)
        Dim ret As Double = 0

        If Not Me.InicioDosis Is Nothing AndAlso Not Me.InicioDosis.Count = 0 Then

            'If Not Me.TipoEliminación = GradosDeEliminación.Michaelis_Menten Then
            For Each d As Double In Me.InicioDosis
                Dim res As Double = Dosificaciónúnica(x, d)
                c.Add(res)
                ret += res
            Next
            'Else
            'ret = experimentalMultipleKinetics2(x)
            'End If

            Return ret

        End If

        Return 0

    End Function

#End Region

End Class