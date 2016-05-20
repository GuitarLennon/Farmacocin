Imports Farmacocinética.Farmacocinética

Module Prediseñados

    'Public customFormasFarmacéuticas() As FormaFarmacéutica

    'Private formasDefault As FormaFarmacéutica() = New FormaFarmacéutica() {
    '    New FormaFarmacéutica("PERSONALIZADO", True) With {.AlcVol = 5, .Volumen = 100},
    '    New FormaFarmacéutica("TEQUILA CAZADORES AÑEJO", 38, 45, 13.49),
    '    New FormaFarmacéutica("TEQUILA HERRADURA", 40, 45, 14.2),
    '    New FormaFarmacéutica("TEQUILA JIMADOR", 35, 45, 12.42),
    '    New FormaFarmacéutica("RON BACARDÍ", 40, 45, 14.2),
    '    New FormaFarmacéutica("BRANDY PRESIDENTE", 38, 45, 13.49),
    '    New FormaFarmacéutica("VODKA ABSOLUT", 40, 45, 13.49),
    '    New FormaFarmacéutica("WHISKEY J&B", 40, 45, 14.2),
    '    New FormaFarmacéutica("CERVEZA VICTORIA", 4, 355, 11.2),
    '    New FormaFarmacéutica("CERVEZA NOCHEBUENA", 5.9, 355, 16.52),
    '    New FormaFarmacéutica("CERVEZA CLARA BOHEMIA PREMIUM", 5, 355, 14.0),
    '    New FormaFarmacéutica("CERVEZA PACÍFICO", 4.5, 3.55, 12.6),
    '    New FormaFarmacéutica("CERVEZA XX LAGER SPECIAL", 4.3, 355, 12.04),
    '    New FormaFarmacéutica("CERVEZA CORONA EXTRA", 4.5, 355, 12.6),
    '    New FormaFarmacéutica("CERVEZA NEGRA MODELO", 5.3, 355, 14.84),
    '    New FormaFarmacéutica("CARIBE COOLER", 4.7, 300, 11.12),
    '    New FormaFarmacéutica("VIÑA REAL", 6, 345, 16.33)
    '    }

    'ReadOnly Property FormasFarmaDef As FormaFarmacéutica()
    '    Get
    '        'Dim l As New List(Of FormaFarmacéutica)
    '        'l.AddRange(formasDefault)
    '        'If Not customFormasFarmacéuticas Is Nothing Then l.AddRange(customFormasFarmacéuticas)
    '        'Return l.ToArray
    '        Return Nothing
    '    End Get

    'End Property

    <Serializable>
    Public Class formaGalénica
        Property nombre As String
        Property Vía As String
        Property BD As Double
        Property ConstanteAbsorción As Double
        Property Latencia As Double
        Property Dosis As Double
        Sub New()

        End Sub
        Public Overrides Function ToString() As String
            Return String.Format("{0}: {1}", nombre, Vía)
        End Function
    End Class

    <Serializable>
    Public Class Fármaco
        Property CME As Double = -1
        Property CMR As Double = -1
        Property CTx As Double = -1
        Property formasFarmacéuticas As formaGalénica()
        Property Ke As Double
        Property km As Double
        Property Nombre As String
        Property TipoEliminación As GradosDeEliminación = GradosDeEliminación.Primer_Orden
        Property VD As Double
        Property vMax As Double
        Public Overrides Function ToString() As String
            Return Me.Nombre
        End Function
        Sub New()

        End Sub
    End Class

    Public ReadOnly Property fármacos As Fármaco()
        Get
            Return fármacosDefault
        End Get
    End Property

    Private fármacosDefault As Fármaco() = New Fármaco() {
        New Fármaco With {
            .Ke = 0.36,
            .Nombre = "Ampicilina",
            .TipoEliminación = GradosDeEliminación.Primer_Orden,
            .VD = 27,
            .CME = 1.5,
            .CMR = 2,
            .CTx = 0,
            .vMax = 0,
            .formasFarmacéuticas = New formaGalénica() {
                New formaGalénica With {
                    .nombre = "Ampicilina capsulas 500 mg",
                    .Vía = "Oral con deglución",
                    .BD = 50,
                    .ConstanteAbsorción = 0.733,
                    .Latencia = 5,
                    .Dosis = 500
                    },
                New formaGalénica With {
                    .nombre = "Ampicilina tabletas 1 g",
                    .Vía = "Oral con deglución",
                    .BD = 50,
                    .ConstanteAbsorción = 0.733,
                    .Latencia = 5,
                    .Dosis = 1000
                    },
                New formaGalénica With {
                    .nombre = "Ampicilina tabletas 500 mg (con alimentos)",
                    .Vía = "Oral con deglución",
                    .BD = 25,
                    .ConstanteAbsorción = 0.4,
                    .Latencia = 5,
                    .Dosis = 500
                    },
                New formaGalénica With {
                    .nombre = "Ampicilina sódica 500 mg",
                    .Vía = "Intramuscular",
                    .BD = 100,
                    .ConstanteAbsorción = 2.5,
                    .Latencia = 5,
                    .Dosis = 500
                    },
                New formaGalénica With {
                    .nombre = "Ampicilina sódica 500 mg",
                    .Vía = "Intravenosa",
                    .BD = 100,
                    .ConstanteAbsorción = 1000000,
                    .Latencia = 0,
                    .Dosis = 500
                    }
                }
            },
        New Fármaco With {
            .Nombre = "Amoxicilina",
            .Ke = 0.3,
            .TipoEliminación = GradosDeEliminación.Primer_Orden,
            .vMax = 0,
            .VD = 19,
            .formasFarmacéuticas = New formaGalénica() {
                New formaGalénica With {
                    .nombre = "Amoxicilina 500 mg",
                    .Vía = "Oral con deglución",
                    .BD = 50,
                    .ConstanteAbsorción = 1.23,
                    .Latencia = 5,
                    .Dosis = 500
                    },
                New formaGalénica With {
                    .nombre = "Amoxicilina 500 mg (con alimentos)",
                    .Vía = "Oral con deglución",
                    .BD = 48,
                    .ConstanteAbsorción = 1.23,
                    .Latencia = 5,
                    .Dosis = 500
                    }
                }
            },
        New Fármaco With {
            .Nombre = "Metformina",
            .Ke = 0.21,
            .TipoEliminación = GradosDeEliminación.Primer_Orden,
            .vMax = 0,
            .VD = 140,
            .CME = 0.1,
            .CMR = 1.0,
            .formasFarmacéuticas = New formaGalénica() {
                New formaGalénica With {
                    .nombre = "Metformina 500 mg",
                    .Vía = "Oral con deglución",
                    .BD = 60,
                    .ConstanteAbsorción = 1.23,
                    .Latencia = 5,
                    .Dosis = 500
                    },
                New formaGalénica With {
                    .nombre = "Metformina 850 mg",
                    .Vía = "Oral con deglución",
                    .BD = 60,
                    .ConstanteAbsorción = 1.23,
                    .Latencia = 5,
                    .Dosis = 850
                    },
                New formaGalénica With {
                    .nombre = "Metformina liberación prolongada 1000 mg",
                    .Vía = "Oral con deglución",
                    .BD = 60,
                    .ConstanteAbsorción = 0.1,
                    .Latencia = 5,
                    .Dosis = 1000
                    }
                }
            }
        }


End Module
