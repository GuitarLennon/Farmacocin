' (C) ARTURO JUAREZ FLORES 2016

Imports System.Drawing
Imports AxNTGRAPHLib

Namespace Farmacocinética
    Public Class ModeloGraficador

        Private _gráfico As AxNTGraph
        Protected ReadOnly Timer As New Windows.Forms.Timer

        Protected Property Gráfico As AxNTGRAPHLib.AxNTGraph
            Get
                If _gráfico Is Nothing Then Stop
                Return _gráfico
            End Get
            Set(value As AxNTGRAPHLib.AxNTGraph)

                _gráfico = value
            End Set
        End Property

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
                    Me.Timer.Interval = CInt(value)
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

        Public Property BackgroundColor As Color
        Public Property CurrentX As Double = 0
        Public Property EndingX As Double = 100
        Public Property GraphicName As String
        Public Property Marcas As Marca()
        Public Property PrincipalAxisColor As Color
        Public Property PrincipalElement As Element
        Public Property SecundaryElement As Element
        Public Property StartingX As Double = 0
        Public Property Status As Stats
        Public Property StepX As Double = 1 / 60
        Public Property UnitsAbscises As String
        Public Property UnitsOrdered As String
        Public Property CursorStyle As Byte
        Public Registro As New List(Of Coordenadas)
        Public Property unit As Units

        Public Event DrawEvent As EventHandler(Of DrawingEventArgs)
        Public Event PrePlotEvent As EventHandler
        Public Event StopEvent As EventHandler
        Public Event StartEvent As EventHandler
        Public Event ClearEvent As EventHandler

        Sub New(gráfico As AxNTGRAPHLib.AxNTGraph)
            If gráfico Is Nothing Then Stop
            Me.Gráfico = gráfico

            AddHandler Me.Timer.Tick, AddressOf internalDraw
        End Sub

        Protected Overridable Sub internalDraw(sender As Object, e As EventArgs)
            If Me.Gráfico Is Nothing Then Exit Sub
            Dim d As New DrawingEventArgs(Me.CurrentX)

            Try
                RaiseEvent DrawEvent(Me, d)

                If Not d.Y Is Nothing Then
                    Registro.Add(New Coordenadas With {.x = d.X, .y = d.Y(0).y})
                    For Each response As DrawingEventArgs.response In d.Y
                        plotData(response)
                    Next
                End If

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

        Protected Overridable Sub plotData(response As DrawingEventArgs.response)
            If Gráfico Is Nothing Then Exit Sub
            Gráfico.PlotXY(response.x, response.y, CShort(response.element))
        End Sub

        Protected Overridable Sub Register(d As DrawingEventArgs)
            If Not d.Y Is Nothing Then
                Registro.Add(New Coordenadas With {.x = d.X, .y = d.Y(0).y})
                For Each response As DrawingEventArgs.response In d.Y
                    plotData(response)
                Next
            End If

        End Sub

        Protected Overridable Sub drawAxis()

            Gráfico.AddCursor(0, 0, 0, PrincipalAxisColor)

            Gráfico.AddAnnotation(0, -0.05, "0", BackgroundColor, PrincipalAxisColor)
            Gráfico.AddAnnotation(-0.25, 0, "0", BackgroundColor, PrincipalAxisColor)

            Gráfico.Caption = Me.GraphicName
            Gráfico.XLabel = UnitsAbscises
            Gráfico.XGridNumber = 10
            Gráfico.YLabel = UnitsOrdered & getUnitString(Me.unit)
            Gráfico.YGridNumber = 25

        End Sub

        Private Sub prePlotCommonPath()
            Me.Status = Stats.BUSY

            RaiseEvent StartEvent(Me, New EventArgs)

            Dim d As New PrePlotEventArgs

            RaiseEvent PrePlotEvent(Me, d)

            Gráfico.PlotAreaColor = BackgroundColor

            If d.DrawAxis Then drawAxis()

            If d.Autorange Then Gráfico.AutoRange()

            If d.ylog Then Gráfico.YLog = True Else Gráfico.YLog = False

            SecundaryElement.id = Me.Gráfico.ElementCount
            SecundaryElement.ToGraph(Me.Gráfico)

            PrincipalElement.id = Me.Gráfico.ElementCount
            PrincipalElement.ToGraph(Me.Gráfico)

        End Sub

        Public Sub Instant()
            prePlotCommonPath()

            Dim dea As New List(Of DrawingEventArgs)

            For Me._CurrentX = StartingX To EndingX Step StepX
                Dim dr As New DrawingEventArgs(Me.CurrentX)
                RaiseEvent DrawEvent(Me, dr)
                dea.Add(dr)
            Next

            dea.ForEach(AddressOf Register)

            RaiseEvent StopEvent(Me, New EventArgs)

            Me.Status = Stats.READY
        End Sub

        Public Sub Start()
            prePlotCommonPath()

            CurrentX = StartingX

            [Continue]()

        End Sub

        Public Sub [Stop]()

            Timer.Stop()

            CurrentX = Nothing

            RaiseEvent StopEvent(Me, New EventArgs)

            Me.Status = Stats.READY
        End Sub

        Public Sub [Continue]()
            Timer.Start()
        End Sub

        Public Sub Pause()
            Timer.Stop()
        End Sub

        Public Sub Clear()
            Me.Timer.Stop()
            Me.CurrentX = 0
            Gráfico.ClearGraph()
            Me.Registro.Clear()

            Dim t As Stopwatch = Stopwatch.StartNew

            While Gráfico.AnnoCount > 0 Or t.ElapsedMilliseconds > 10000
                Gráfico.DeleteAnnotation(0)
            End While

            While Gráfico.CursorCount > 0 Or t.ElapsedMilliseconds > 10000
                Gráfico.DeleteCursor(0)
            End While

            RaiseEvent ClearEvent(Me, New EventArgs)
        End Sub

    End Class

End Namespace