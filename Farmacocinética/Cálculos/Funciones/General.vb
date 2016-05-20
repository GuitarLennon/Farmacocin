' (C) ARTURO JUAREZ FLORES 2016

Imports System.Runtime.CompilerServices
Imports AxNTGRAPHLib

Namespace Farmacocinética
    Public Module Main

        <Extension> Function MaxHoursTeoric(nada As Date) As Double
            'nada = New Date
            'nada = nada.AddHours(MaxHoursTeoric + 1)
            Return Date.MaxValue.Hour + Date.MaxValue.Day * 24 + Date.MaxValue.Month * 30 * 24 + Date.MaxValue.Year * 365 * 24
        End Function

        <Extension>
        Function AddAnnotation(ntgraph As AxNTGraph, x As Double, y As Double, texto As String,
                            Optional backcolor As Drawing.Color = Nothing,
                            Optional forecolor As Drawing.Color = Nothing,
                            Optional horizontal As Boolean = True,
                            Optional visible As Boolean = True) As Integer

            ntgraph.AddAnnotation()

            If backcolor = Drawing.Color.Empty Then backcolor = ntgraph.PlotAreaColor
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
        Function AddCursor(ntgraph As AxNTGraph, x As Double, y As Double,
                            Optional mode As Short = 0,
                            Optional color As Drawing.Color = Nothing,
                            Optional style As Short = 0,
                            Optional horizontal As Boolean = False,
                            Optional visible As Boolean = True) As Integer

            ntgraph.AddCursor()
            If color = Drawing.Color.Empty Then color = Drawing.Color.Yellow

            ntgraph.CursorColor = color
            Try
                ntgraph.CursorMode = mode
            Catch ex As Exception
                ntgraph.CursorMode = 0
            End Try
            If horizontal = True Then ntgraph.CursorStyle = 1 Else ntgraph.CursorStyle = style
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
                ntgrap.PlotXY(i, Array(i), CShort(element))
                ntgrap.Refresh()
            Next

            ntgrap.AutoRange()
        End Sub

        <Extension>
        Public Sub plotMatriz(ntgrap As AxNTGraph, element As Element, Array() As Double)

            ntgrap.AddElement()
            element.id = CShort(ntgrap.ElementCount - 1)
            element.ToGraph(ntgrap)
            For i = Array.GetLowerBound(0) To Array.GetUpperBound(0)
                ntgrap.PlotXY(i, Array(i), element.id)
                ntgrap.Refresh()
            Next

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

        Function VidaMediaSegundoOrden(eliminación As Double) As Double
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

        Function DecirCmin(Cmin As Double) As String
            Return "Cmin-ee: " & Format(Cmin, "#.##")
        End Function

    End Module
End Namespace