' (C) ARTURO JUAREZ FLORES 2016

Imports System.Drawing

Namespace Farmacocinética

    Public Class PrePlotEventArgs
        Inherits EventArgs
        Property Autorange As Boolean = True
        Property DrawAxis As Boolean = True
        Property ylog As Boolean = False
    End Class

    Public Class Marca
        Public Property y As Double
        Public Property color As Color
        Public Property size As Integer
        Public Property name As String
        Public Property show As Boolean
        Public Property style As NTGRAPHLib.LineType
    End Class

    Public Structure Range
        Property MinX As Double
        Property MinY As Double
        Property MaxX As Double
        Property MaxY As Double
    End Structure

    Public Enum Stats
        READY = 0
        BUSY = 1
    End Enum

    Public Structure Ciclo
        Property Ciclo As Integer
        Property Remaining As Double
        Property Past As Double
        Property ln As Double

        Public Overrides Function ToString() As String
            Return String.Format("Ciclo {0}, restante {1}", Ciclo, FormatNumber(Remaining, 3))
        End Function
    End Structure

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

End Namespace