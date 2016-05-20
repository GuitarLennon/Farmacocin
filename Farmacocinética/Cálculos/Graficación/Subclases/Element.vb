' (C) ARTURO JUAREZ FLORES 2016

Imports AxNTGRAPHLib
Imports NTGRAPHLib

Namespace Farmacocinética

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

        End Sub
    End Class

End Namespace