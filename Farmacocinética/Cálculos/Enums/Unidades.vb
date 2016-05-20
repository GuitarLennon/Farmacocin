' (C) ARTURO JUAREZ FLORES 2016

Namespace Farmacocinética

    Public Module Unidades
        Public Function getUnitString(unit As Units, Optional log As Boolean = False) As String
            Select Case unit
                Case Units.microgramos_por_mililitro
                    If log Then Return "log(mcg/mL)" Else Return "mcg/mL"
                Case Units.gramos_por_litro
                    If log Then Return "log(g/L)" Else Return "g/L"
                Case Units.miligramos_por_decilitro
                    If log Then Return "log(mg/100mL)" Else Return "mg/100mL"
                Case Units.gramos_por_decilitro
                    If log Then Return "log(g/dL)" Else Return "g/dL"
                Case Units.miligramos_por_litro
                    If log Then Return "log(mg/L)" Else Return "mg/L"
                Case Else
                    Return "unidades Desconocidas"
            End Select
        End Function

        Public Function getUnit(unit As Units) As Double
            Select Case unit
                Case Units.microgramos_por_mililitro
                    '    g    1000000 mcg      1 l
                    ' 1 --- (-------------)(---------)
                    '    l         1 g       1000 ml
                    Return 1000
                Case Units.gramos_por_litro
                    '    g    1 g    1 l
                    ' 1 --- (-----)(-----)
                    '    l    1 g    1 l
                    Return 1000 / 1000
                Case Units.miligramos_por_decilitro
                    '    g    1000 mg      1 l        100 ml
                    ' 1 --- (---------)(---------)(------------)
                    '    l      1 g      1000 ml    1 (100 mL)
                    Return 100
                Case Units.gramos_por_decilitro
                    '    g    1 g     1 l
                    ' 1 --- (-----)(-------)
                    '    l    1 g    10 dl
                    Return 1 / 10
                Case Units.miligramos_por_litro
                    '    g    1000 mg     1 l
                    ' 1 --- (---------)(-------)
                    '    l      1 g       1 l
                    Return 1000
                Case Else
                    Return 1
            End Select
        End Function
    End Module

End Namespace