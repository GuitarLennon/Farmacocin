Imports NTGRAPHLib
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Xml
Imports Farmacocinética.ModeloFarmacocinéticoAnimado

Public Class MainForm

    <Serializable>
   Public Class Info
        'Public formas As FormaFarmacéutica()
        Public farmas As Fármaco()
        Sub New()

        End Sub
    End Class

    Public Sub loadCustom()
        'If Not IO.File.Exists(ruta) Then Exit Sub
        'Try
        '    Dim XmlRdr As New XmlTextReader(ruta)
        '    Dim Ser As New Serialization.XmlSerializer(GetType(Info))

        '    Dim i As Info

        '    If Ser.CanDeserialize(XmlRdr) Then

        '        i = Ser.Deserialize(XmlRdr)
        '        customFarmacos = i.farmas
        '        customFormasFarmacéuticas = i.formas

        '    Else

        '        'do nothing

        '    End If
        'Catch X As System.IO.FileNotFoundException

        'Catch

        'Finally

        'End Try
    End Sub

    Public Sub saveCustom()

        'Dim XmlWrt As XmlWriter
        'Dim settings As New XmlWriterSettings() With {.Indent = True, .IndentChars = " ", _
        '                                             .Encoding = System.Text.Encoding.Default}
        'Dim tipo As Type = GetType(Info)
        ''Dim extratypes As Type() = New Type() {GetType(FormaFarmacéutica)}

        'Dim i As New Info With {.farmas = customFarmacos, .formas = customFormasFarmacéuticas}

        'Try
        '    XmlWrt = XmlWriter.Create(ruta, settings)
        '    Dim Ser As New Serialization.XmlSerializer(tipo)

        '    Ser.Serialize(XmlWrt, i)

        'Catch ex As Exception

        'End Try
    End Sub

    '<Serializable>
    'Public Class FormaFarmacéutica
    '    Public Const DensidadEtanol As Double = 0.789
    '    Property Nombre As String
    '    Dim _dosis As Double
    '    ReadOnly Property Dosis As Double
    '        Get
    '            If _dosis = -1 Then Return mililitrosAGramos(Volumen)
    '            Return _dosis
    '        End Get
    '    End Property
    '    Property _default As Boolean

    '    Property AlcVol As Double
    '    Property Volumen As Double

    '    Sub New()

    '    End Sub

    '    Sub New(nombre As String, _default As Boolean)
    '        Me.Nombre = nombre
    '        Me._default = _default
    '    End Sub

    '    Sub New(nombre As String, AlcVol As Double, volumen As Double, Optional dosis As Double = -1)

    '        Me.Nombre = nombre
    '        Me.Volumen = volumen
    '        Me._dosis = dosis
    '        Me.AlcVol = AlcVol
    '    End Sub

    '    Public Sub CopyFrom(other As FormaFarmacéutica)
    '        Me.AlcVol = other.AlcVol
    '        Me.Volumen = other.Volumen

    '    End Sub

    '    Public Overrides Function ToString() As String
    '        If Not _default Then
    '            Return String.Format("{0} {1}% {2}ml ({3} g)", Me.Nombre, Me.AlcVol, Me.Volumen, Me.Dosis)

    '        End If
    '        Return String.Format("{0}", Me.Nombre)
    '    End Function

    '    Public Function mililitrosAGramos(mililitros As Double) As Double
    '        Return mililitrosAGramosDeAlcohol(mililitros * AlcVol / 100)
    '    End Function

    '    Public Shared Function mililitrosAGramosDeAlcohol(mililitros As Double) As Double
    '        Return mililitros * DensidadEtanol
    '    End Function

    '    Public Function getVolume(gramos As Double) As Double
    '        Return (gramos / DensidadEtanol) / (AlcVol / 100)
    '    End Function
    'End Class

    <Serializable>
    Public Class Fármaco
        Property Name As String
        Property BD As String
        Property ConstanteAbsorción As Double
        Property constanteEliminación As Double
        Property TipoEliminación As ModeloFarmacocinéticoAnimado.GradosDeEliminación = GradosDeEliminación.Primer_Orden
        Property vMax As Double
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
        Sub New()

        End Sub
    End Class

    Public ReadOnly Property Marcas()
        Get
            Dim l As New List(Of Marca)
            l.Add(New Marca With {.name = Marca1_label.Text,
                                  .color = Drawing.Color.FromKnownColor(Marca1_color.SelectedItem),
                                  .show = Marca1_visible.Checked,
                                  .y = Marca1.Value,
                                  .size = Marca1_tamaño.Value})
            l.Add(New Marca With {.name = Marca2_label.Text,
                                  .color = Drawing.Color.FromKnownColor(Marca2_Color.SelectedItem),
                                  .show = Marca2_visible.Checked,
                                  .y = Marca2.Value,
                                  .size = Marca2_tamaño.Value})
            l.Add(New Marca With {.name = Marca3_label.Text,
                                  .color = Drawing.Color.FromKnownColor(Marca3_color.SelectedItem),
                                  .show = Marca3_visible.Checked,
                                  .y = Marca3.Value,
                                  .size = Marca3_tamaño.Value})
          
            Return l.ToArray
        End Get
    End Property

#Region "Constants"

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

    Private customFarmacos As Fármaco()

    Private farmacosDefault As Fármaco() = New Fármaco() {
        New Fármaco With {.Name = "Etanol", .BD = 100,
                          .ConstanteAbsorción = 2.77,
                          .constanteEliminación = 0.0821,
                          .TipoEliminación = GradosDeEliminación.Michaelis_Menten,
                          .vMax = 0.232}}

    ReadOnly Property Fármacos As Fármaco()
        Get
            Dim l As New List(Of Fármaco)
            l.AddRange(farmacosDefault)
            If customFarmacos IsNot Nothing Then l.AddRange(customFarmacos)
            Return l.ToArray
        End Get
    End Property

#End Region

#Region "Properties"

#Region "   Experimental Design"

    ReadOnly Property VolumenDeDistribución As Double
        Get
            Return VD_num.Value '* 10 ^ VD_Exp.Value
        End Get
    End Property

    ReadOnly Property Horas_de_estudio As Double
        Get
            Return Horas_Estudio_Num.Value
        End Get
    End Property

    ReadOnly Property VelocidadDeTrazo As Double
        Get
            Return Velocidad_de_trazo.Value
        End Get
    End Property

    ReadOnly Property Unidad As Units
        Get
            Return Unidades.SelectedItem
        End Get
    End Property

#End Region

#Region "   Dosification"
    ReadOnly Property TipoDeDosificación As TipoDosificación
        Get
            If MúltiplesDosis.Checked Then Return TipoDosificación.Múltiple
            Return TipoDosificación.Única
            'If Dosificación.SelectedTab Is Volume Then
            '    Return TipoDosificación.Única
            'ElseIf Dosificación.SelectedTab Is MúltiplesDosis Then
            '    Return TipoDosificación.Múltiple
            'ElseIf Dosificación.SelectedTab Is DosisManual Then
            '    Return TipoDosificación.Manual
            'End If
            'Return TipoDosificación.Error
        End Get
    End Property

    ReadOnly Property Dosis As Double
        Get
            Return Dosis1.Value '* 10 ^ Dosis_exp_2.Value
        End Get
    End Property

    ReadOnly Property IntérvaloDeDosificación As Double
        Get
            Return IntérvaloDosificaciónHoras.Value + (IntérvaloDosificaciónMinutos.Value / 60)
        End Get
    End Property

    ReadOnly Property UsarDosisCarga As Boolean
        Get
            Return ChargeDoseActive.Checked
        End Get
    End Property

    ReadOnly Property DosisCarga As Double
        Get
            Return ChargeDose.Value '* 10 ^ ChargeExp.Value
        End Get
    End Property

    ReadOnly Property DosisTotales As Integer
        Get
            Return DosisTotalesNum.Value
        End Get
    End Property

#End Region

#Region "   Used Drug"

    ReadOnly Property FracciónBiodisponible As Double
        Get
            Return BD.Value / 100
        End Get
    End Property

    ReadOnly Property Ka As Double
        Get
            Return Absorción.Value '* 10 ^ Abosrción_exp.Value
        End Get
    End Property

    ReadOnly Property Ke As Double
        Get
            Return Eliminación.Value '* 10 ^ Eliminación_exp.Value
        End Get
    End Property

    ReadOnly Property TipoDeEliminación As GradosDeEliminación
        Get
            Return TipoEliminación.SelectedItem
        End Get
    End Property

    ReadOnly Property VelocidadMáximaDeEliminación As Double
        Get
            Return VelocidadMaximaEliminación.Value '* 10 ^ VME_exp.Value
        End Get
    End Property
#End Region

#Region "   Others"
    ReadOnly Property Nacional As Double
        Get
            Return Marca1.Value
        End Get
    End Property

    ReadOnly Property Internacional As Double
        Get
            Return Marca2.Value
        End Get
    End Property

    ReadOnly Property Estupor As Double
        Get
            Return Marca3.Value
        End Get
    End Property

    ReadOnly Property Limits As Double()
        Get
            Return New Double() {Nacional, Internacional, Estupor}
        End Get
    End Property

#End Region

#Region "   Colors and things"

    ReadOnly Property ColorPrincipal As Drawing.Color
        Get
            Try
                Return Drawing.Color.FromKnownColor(LineColor.SelectedItem)
            Catch ex As Exception
                Stop
            End Try
        End Get
    End Property

    ReadOnly Property LineaPrincipal As NTGRAPHLib.LineType
        Get
            Return LineType.SelectedItem
        End Get
    End Property

    ReadOnly Property TamañoLinea As Integer
        Get
            Return LineSize.Value
        End Get
    End Property

    ReadOnly Property ColorPunto As Drawing.Color
        Get
            Try
                Return Drawing.Color.FromKnownColor(DotColor.SelectedItem)
            Catch ex As Exception
                Stop
            End Try
        End Get
    End Property

    ReadOnly Property TipoPunto As NTGRAPHLib.SymbolType
        Get
            Return DotType.SelectedItem
        End Get
    End Property

    ReadOnly Property MostrarAcotaciones As Boolean
        Get
            Return Acotaciones1.Checked
        End Get
    End Property

    ReadOnly Property AcotacionesColor As Drawing.Color
        Get
            Return Drawing.Color.FromKnownColor(MaxColor.SelectedItem)
        End Get
    End Property

    ReadOnly Property ColorDiferencial As Drawing.Color
        Get
            Return Drawing.Color.FromKnownColor(DifColor.SelectedItem)
        End Get
    End Property

    ReadOnly Property TipoDiferencial As NTGRAPHLib.LineType
        Get
            Return DiffType.SelectedItem
        End Get
    End Property

    ReadOnly Property TamañoDiferencial As Integer
        Get
            Return DiffSize.Value
        End Get
    End Property

    ReadOnly Property DibujarDiferencial As Boolean
        Get
            Return UsarDiferencial.Checked
        End Get
    End Property

    Public ReadOnly Property SóloEliminación As Boolean
        Get
            Return SoloEliminación.Checked
        End Get
    End Property

    ReadOnly Property ColorFondo As Color
        Get
            Return Drawing.Color.FromKnownColor(Fondo.SelectedItem)
        End Get
    End Property
#End Region

#Region "   Obsolete"
    <Obsolete>
    ReadOnly Property UsarMúltipleDosis As Boolean
        Get
            Return False
        End Get
    End Property

    ReadOnly Property Latencia As Double
        Get
            'Return Latencia_num.Value * 10 ^ Latencia_exp.Value
            Return 0
        End Get
    End Property
#End Region

#Region "   Internal"
    ReadOnly Property PrincipalElement As Element
        Get
            Dim returning As Element = New Element With {.lineColor = ColorPrincipal, .id = NTGraph1.ElementCount + 1, .pointColor = ColorPunto, _
                                     .pointSymbol = TipoPunto, .lineType = LineaPrincipal, .width = TamañoLinea}
            Return returning
        End Get
    End Property

    ReadOnly Property SecondaryElement As Element
        Get
            Dim returning As Element = New Element With {.lineColor = ColorDiferencial, .id = NTGraph1.ElementCount, _
                    .lineType = TipoDiferencial, .width = TamañoDiferencial, .show = UsarDiferencial.Checked}
            Return returning
        End Get
    End Property

    ReadOnly Property extrapolado As Element
        Get
            Return New Element With {.lineColor = Drawing.Color.DarkBlue, .id = NTGraph1.ElementCount, _
                               .lineType = LineaPrincipal, .width = TamañoLinea}
        End Get
    End Property

    ReadOnly Property eliminado As Element
        Get
            Return New Element With {.lineColor = Drawing.Color.Cyan, .id = NTGraph1.ElementCount, _
                                           .lineType = LineaPrincipal, .width = TamañoLinea}
        End Get
    End Property

#End Region

#End Region

#Region "Instance variables"
    Private element As Element
    Private WithEvents ModeloFarmacocinéticoAnimado As ModeloFarmacocinéticoAnimado
#End Region

#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.initializeGraphic()

        Me.ModeloFarmacocinéticoAnimado = New ModeloFarmacocinéticoAnimado(Me.NTGraph1, True)
    End Sub

#End Region

    Friend WithEvents NTGraph1 As AxNTGRAPHLib.AxNTGraph

    Private Sub initializeGraphic()
        Me.NTGraph1 = New AxNTGRAPHLib.AxNTGraph()
        CType(Me.NTGraph1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'NTGraph1
        '
        Me.NTGraph1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NTGraph1.Location = New System.Drawing.Point(0, 0)
        Me.NTGraph1.Name = "NTGraph1"
        Me.NTGraph1.Size = New System.Drawing.Size(532, 701)
        Me.NTGraph1.TabIndex = 2

        CType(Me.NTGraph1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.Controls.Add(Me.NTGraph1)
        NTGraph1.BringToFront()
        Me.SplitContainer1.SplitterDistance += 1

    End Sub

    Private Sub initializeDrawing()
        VidaMediaEliminación(Nothing, Nothing)
        LineColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        LineColor.SelectedItem = System.Drawing.KnownColor.Red
        DotColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        DotColor.SelectedItem = System.Drawing.KnownColor.Green
        LineType.DataSource = [Enum].GetValues(GetType(NTGRAPHLib.LineType))
        LineType.SelectedItem = NTGRAPHLib.LineType.Solid
        DotType.DataSource = [Enum].GetValues(GetType(NTGRAPHLib.SymbolType))
        DotType.SelectedItem = NTGRAPHLib.SymbolType.Nosym
        MaxColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        MaxColor.SelectedItem = System.Drawing.KnownColor.YellowGreen
        DifColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        DifColor.SelectedItem = System.Drawing.KnownColor.Blue
        DiffType.DataSource = [Enum].GetValues(GetType(NTGRAPHLib.LineType))
        DiffType.SelectedItem = NTGRAPHLib.LineType.DashDotDot

        Marca1_color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        Marca2_Color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        Marca3_color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'Marca4_color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        Fondo.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))

        Marca1_color.SelectedItem = System.Drawing.KnownColor.Green
        Marca2_Color.SelectedItem = System.Drawing.KnownColor.Green
        Marca3_color.SelectedItem = System.Drawing.KnownColor.OrangeRed
        'Marca4_color.SelectedItem = System.Drawing.KnownColor.Red
        Fondo.SelectedItem = System.Drawing.KnownColor.Black

        'FarmacoPredeterminado.DataSource = Me.Fármacos

        Unidades.DataSource = [Enum].GetValues(GetType(ModeloFarmacocinéticoAnimado.Units))
        Unidades.SelectedItem = ModeloFarmacocinéticoAnimado.Units.gramos_por_litro
    End Sub

    Private Sub initialize_laboratory()
        TipoEliminación.DataSource = [Enum].GetValues(GetType(GradosDeEliminación))
        TipoEliminación.SelectedItem = GradosDeEliminación.Primer_Orden

        loadCustom()

        'FarmacoPredeterminado.DataSource = Me.Fármacos

        'FP_2.DataSource = Me.FormasFarmaDef
        'FP_3.DataSource = Me.FormasFarmaDef
        'FP_4.DataSource = Me.FormasFarmaDef

        'For Each f As FormaFarmacéutica In Me.FormasFarmaDef
        '    FP_2.Items.Add(f)
        '    FP_3.Items.Add(f)
        '    FP_4.Items.Add(f)
        'Next
        'FP_2.SelectedIndex = 0
        'FP_3.SelectedIndex = 0
        'FP_4.SelectedIndex = 0

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        initializeDrawing()
        initialize_laboratory()

        For i As Integer = 1 To 16
            Me.Controls.Find("ControlDemostración" & i, True).ToList.ForEach(Sub(control As Control)
                                                                                 Dim c As ControlActualizable.ControlDemostración = TryCast(control, ControlActualizable.ControlDemostración)
                                                                                 If c IsNot Nothing Then c.LabelIsVisible = True
                                                                             End Sub)
        Next
        'For Each Control As Control In Me.Controls
        '    Dim c As ControlActualizable.ControlDemostración = TryCast(Control, ControlActualizable.ControlDemostración)
        '    If c IsNot Nothing Then c.LabelIsVisible = True

        'Next
    End Sub

    Private Sub formaFarmacéuticaManaging(sender As Object, e As EventArgs)
        'Dim send As ComboBox = DirectCast(sender, ComboBox)

        '' If send IsNot FP_0 Then FP_0.SelectedItem = send.SelectedItem
        ''If send IsNot FP_1 Then FP_1.SelectedItem = send.SelectedItem
        'If send IsNot FP_2 Then FP_2.SelectedItem = send.SelectedItem
        'If send IsNot FP_3 Then FP_3.SelectedItem = send.SelectedItem
        'If send IsNot FP_4 Then FP_4.SelectedItem = send.SelectedItem

        'Dim ff As FormaFarmacéutica = TryCast(send.SelectedItem, FormaFarmacéutica)

        'Dim ff_default As FormaFarmacéutica = TryCast(FP_2.Items(0), FormaFarmacéutica)
        'ff_default.CopyFrom(ff)

        'If ff IsNot Nothing Then
        '    Me.Dosis_Num_2.Value = ff.Dosis
        '    Me.Dosis_exp_2.Value = 0
        '    Me.Volumen.Value = ff.Volumen
        '    Me.AlcVol.Value = ff.AlcVol
        'End If

    End Sub

    Private Sub DrawGraphicInfo()
        NTGraph1.XLabel = "Tiempo (horas)."
        NTGraph1.Caption = "Fármaco personalizado."
        NTGraph1.YLabel = "Concentración " & getUnitString(Me.Unidad)
        'graficar el eje
        NTGraph1.AddCursor(0, 0, 0, Drawing.Color.White, 0)
    End Sub

    Private Sub CreateNewElement()
        element = New Element With {.lineColor = ColorPrincipal, .id = NTGraph1.ElementCount, .pointColor = ColorPunto, _
                                    .pointSymbol = TipoPunto, .lineType = LineaPrincipal, .width = TamañoLinea, .name = "Gráfico " & .id}

        element.ToGraph(NTGraph1)
    End Sub

    Private Sub Crear_Modelo_Farmacocinético()
        Me.ModeloFarmacocinéticoAnimado = New ModeloFarmacocinéticoAnimado(Me.NTGraph1) With
                                         {.BackgroundColor = Me.ColorFondo,
                                          .Biodisponibilidad = Me.FracciónBiodisponible,
                                          .ConstanteAbsorción = Me.Ka,
                                          .ConstanteEliminación = Me.Ke,
                                          .CurrentX = 0,
                                          .DisplayOnSemilogarithm = Log.Checked,
                                          .Dosificación = Me.TipoDeDosificación,
                                          .Dosis = Me.Dosis,
                                          .DosisCarga = Me.DosisCarga,
                                          .DosisTotales = Me.DosisTotales,
                                          .EndingX = Me.Horas_de_estudio,
                                          .IntervaloEntreDosis = Me.IntérvaloDeDosificación,
                                          .GraphicName = "Farmacocinética",
                                          .Marcas = Me.Marcas,
                                          .MostrarAcotaciones = Me.MostrarAcotaciones,
                                          .PrincipalElement = PrincipalElement,
                                          .SecundaryElement = SecondaryElement,
                                          .SoloEliminacíón = Me.SóloEliminación,
                                          .StartingX = 0,
                                          .TipoEliminación = Me.TipoDeEliminación,
                                          .UsarCarga = Me.UsarDosisCarga,
                                          .unit = Unidad,
                                          .UnitsAbscises = "Horas",
                                          .UnitsOrdered = "Concentración plasmática ~ ",
                                          .VelocidadDelTrazo = Me.VelocidadDeTrazo,
                                          .VMax = Me.VelocidadMáximaDeEliminación,
                                          .VolumenDistribución = VolumenDeDistribución
                                         }
    End Sub

    Private Sub Iniciar_Click(sender As Object, e As EventArgs) Handles Iniciar.Click
        Crear_Modelo_Farmacocinético()
        Me.ModeloFarmacocinéticoAnimado.Start()
    End Sub

    Private Sub Detener_Click(sender As Object, e As EventArgs) Handles Detener.Click
        Me.ModeloFarmacocinéticoAnimado.Stop()
    End Sub

    Private Sub Instant_Click(sender As Object, e As EventArgs) Handles Instant.Click
        Crear_Modelo_Farmacocinético()
        Me.ModeloFarmacocinéticoAnimado.Instant()
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        Me.ModeloFarmacocinéticoAnimado.Clear()
    End Sub

    ''' <summary>
    ''' Cambios en el valor coordinados
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Dosis_Num_ValueChanged(sender As Object, e As EventArgs) Handles _
        Dosis1.ValueChanged


        'Try


        '    Dim t As NumericUpDown = DirectCast(sender, NumericUpDown)

        '    RemoveHandler Dosis_Num_2.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    RemoveHandler Dosis_Num_3.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    RemoveHandler Dosis_Num_1.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    RemoveHandler AlcVol.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    RemoveHandler Volumen.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    RemoveHandler Copas.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged

        '    Dim ff As FormaFarmacéutica = TryCast(FP_4.SelectedItem, FormaFarmacéutica)
        '    Dim dosis As Double
        '    'If Not ff._default Then
        '    '    dosis = ff.Volumen * (AlcVol.Value / 100) * FormaFarmacéutica.DensidadEtanol * Copas.Value
        '    'Else
        '    dosis = Volumen.Value * (AlcVol.Value / 100) * FormaFarmacéutica.DensidadEtanol * Copas.Value
        '    'End If


        '    If t Is AlcVol Then

        '        If ff Is Nothing Then
        '            'ff.AlcVol = t.Value
        '        Else
        '            If ff.AlcVol <> t.Value AndAlso FP_4.Items.Count > 0 Then
        '                FP_4.SelectedIndex = 0
        '                ff = TryCast(FP_4.SelectedItem, FormaFarmacéutica)
        '                ff.AlcVol = t.Value
        '            End If
        '        End If


        '        Dosis_Num_2.Value = dosis
        '        Dosis_Num_3.Value = dosis
        '        Dosis_Num_1.Value = dosis
        '        'AlcVol.Value = 
        '        'Volumen.Value = 

        '        'Copas.Value =
        '        If Not ff Is Nothing Then
        '            Copas.Value = dosis / ff.Dosis
        '        End If

        '    ElseIf t Is Volumen Then

        '        Dosis_Num_2.Value = dosis
        '        Dosis_Num_3.Value = dosis
        '        Dosis_Num_1.Value = dosis
        '        'AlcVol.Value = 
        '        'Volumen.Value = 
        '        'Copas.Value =
        '        If Not ff Is Nothing Then
        '            Copas.Value = dosis / ff.Dosis
        '        End If

        '    ElseIf t Is Copas Then

        '        Dosis_Num_2.Value = dosis
        '        Dosis_Num_3.Value = dosis
        '        Dosis_Num_1.Value = dosis
        '        'AlcVol.Value = 
        '        'Volumen.Value = 
        '        If Not AlcVol.Value = 0 Then
        '            Volumen.Value = dosis / ((AlcVol.Value / 100) * FormaFarmacéutica.DensidadEtanol * Copas.Value)
        '        Else
        '            Volumen.Value = 0
        '        End If
        '        'Copas.Value =

        '    ElseIf t Is Dosis_Num_1 Then

        '        Dosis_Num_2.Value = t.Value
        '        Dosis_Num_3.Value = t.Value
        '        'Dosis_Num_1.Value = 
        '        'AlcVol.Value = 

        '        'Volumen.Value = 
        '        If Not AlcVol.Value = 0 Then
        '            Volumen.Value = Dosis_Num_1.Value / ((AlcVol.Value / 100) * FormaFarmacéutica.DensidadEtanol * Copas.Value)
        '        Else
        '            Volumen.Value = 0
        '        End If

        '        'Copas.Value =
        '        If Not ff Is Nothing Then
        '            Copas.Value = Dosis_Num_1.Value / ff.Dosis
        '        End If

        '    ElseIf t Is Dosis_Num_2 Then

        '        Dosis_Num_1.Value = t.Value
        '        Dosis_Num_3.Value = t.Value
        '        'Dosis_Num_1.Value = 
        '        'AlcVol.Value = 

        '        'Volumen.Value = 
        '        If Not AlcVol.Value = 0 Then
        '            Volumen.Value = Dosis_Num_1.Value / ((AlcVol.Value / 100) * FormaFarmacéutica.DensidadEtanol * Copas.Value)
        '        Else
        '            Volumen.Value = 0
        '        End If

        '        'Copas.Value =
        '        If Not ff Is Nothing Then
        '            Copas.Value = Dosis_Num_1.Value / ff.Dosis
        '        End If

        '    ElseIf t Is Dosis_Num_3 Then

        '        Dosis_Num_1.Value = t.Value
        '        Dosis_Num_2.Value = t.Value
        '        'Dosis_Num_1.Value = 
        '        'AlcVol.Value = 

        '        'Volumen.Value = 
        '        If Not AlcVol.Value = 0 Then
        '            Volumen.Value = Dosis_Num_1.Value / ((AlcVol.Value / 100) * FormaFarmacéutica.DensidadEtanol * Copas.Value)
        '        Else
        '            Volumen.Value = 0
        '        End If

        '        'Copas.Value =
        '        If Not ff Is Nothing Then
        '            Copas.Value = Dosis_Num_1.Value / ff.Dosis
        '        End If

        '    End If

        'Catch ex As Exception

        'Finally
        '    AddHandler Dosis_Num_2.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    AddHandler Dosis_Num_3.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    AddHandler Dosis_Num_1.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    AddHandler AlcVol.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    AddHandler Volumen.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        '    AddHandler Copas.ValueChanged, AddressOf Me.Dosis_Num_ValueChanged
        'End Try
    End Sub

    ''' <summary>
    ''' Cambios en el valor coordinados
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Dosis_exp_ValueChanged(sender As Object, e As EventArgs)
        'Dim t As NumericUpDown = DirectCast(sender, NumericUpDown)
        'If t IsNot Dosis_Exp_1 Then Dosis_Exp_1.Value = t.Value
        'If t IsNot Dosis_exp_2 Then Dosis_exp_2.Value = t.Value
        'If t IsNot Dosis_exp_3 Then Dosis_exp_3.Value = t.Value
    End Sub

    ''' <summary>
    ''' Se encarga de definir donde se dió el clic
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NTGraph1_CursorPosition(sender As Object, e As AxNTGRAPHLib._DNTGraphEvents_CursorPositionEvent) Handles NTGraph1.CursorPosition
        TextBox_x.Text = Format(e.x, "0.# h")
        TextBox_y.Text = Format(e.y, "0.## ") & getUnitString(Me.Unidad)

        Dim factorConversión As Double

        Select Case Me.Unidad
            Case Units.g_por_decilitro
                factorConversión = 100
            Case Units.gramos_por_litro
                factorConversión = 1000
            Case Units.mg_por_100ml
                factorConversión = 10
        End Select

        TextBox_CAe.Text = String.Format(" {0} mg/L", Format(e.y * factorConversión / 2000, "0.###"))
    End Sub

    ''' <summary>
    ''' Displays the halfEliminationRate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub VidaMediaEliminación(sender As Object, e As EventArgs) Handles Dosis1.ValueChanged, Eliminación.ValueChanged, Absorción.ValueChanged
        Try
            Dim i As Double = VidaMediadeEliminación(Me.Ke, (Me.FracciónBiodisponible * Dosis) / Me.VolumenDeDistribución, Me.TipoDeEliminación, Me.VelocidadMáximaDeEliminación / 10)
            Dim j As Double = VidaMediaSegundoOrden(Ka)
            Dim k As Date = New Date

            If Double.IsPositiveInfinity(i) Or Double.IsNegativeInfinity(i) Or Double.IsNaN(i) Then
                VME.Text = "Infinito teórico"

            ElseIf i < Date.MinValue.Hour Or i > Date.MaxValue.MaxHoursTeoric Then

                VME.Text = i / 24 & " días"

            Else
                k = k.AddHours(i)
                VME.Text = k.DecirTiempo
            End If

            If Double.IsPositiveInfinity(j) Then
                VMA.Text = "Infinito teórico"
            ElseIf j < Date.MinValue.Hour Or j > Date.MaxValue.MaxHoursTeoric Then
                VMA.Text = j / 24 & " días"
            Else
                k = New Date
                k = k.AddHours(j)
                VMA.Text = k.DecirTiempo
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Administrar_Click(sender As Object, e As EventArgs)
        ModeloFarmacocinéticoAnimado.AdministrarDosis()
    End Sub

    Private Sub Guardar_Farmacos_Click(sender As Object, e As EventArgs)
        'Dim s As String = InputBox("Introduzca un nombre para este fármaco", "Nuevo Fármaco", "Nuevo fármaco")
        'Dim f As New Fármaco With {.Name = s}
        'f.BD = Me.FracciónBiodisponible * 100
        'f.ConstanteAbsorción = Me.Ka
        'f.constanteEliminación = Me.Ke
        'f.TipoEliminación = Me.TipoDeEliminación
        'f.vMax = Me.VelocidadMáximaDeEliminación
        'Dim l As New List(Of Fármaco)
        'If Not customFarmacos Is Nothing Then l.AddRange(customFarmacos)
        'l.Add(f)

        'customFarmacos = l.ToArray

        'FarmacoPredeterminado.DataSource = Me.Fármacos
        'FarmacoPredeterminado.SelectedItem = f

        'saveCustom()

    End Sub

    Private Sub FarmacoPredeterminado_SelectedIndexChanged(sender As Object, e As EventArgs)


        'Dim F As Fármaco = DirectCast(DirectCast(sender, ComboBox).SelectedItem, Fármaco)

        'Me.BD.Value = F.BD
        'Me.Absorción_num.Value = F.ConstanteAbsorción
        'Me.Abosrción_exp.Value = 0
        'Me.Eliminación_num.Value = F.constanteEliminación
        'Me.Eliminación_exp.Value = 0
        'Me.TipoEliminación.SelectedItem = F.TipoEliminación
        'Me.VelocidadMáximaEliminación.Value = F.vMax

    End Sub

    Private Sub G_FF_Click(sender As Object, e As EventArgs)
        'Dim s As String = InputBox("Introduzca un nombre para la nueva presentación comercial", "Nueva Presentación comercial", "Nueva Presentación comercial")
        'Dim f As New FormaFarmacéutica
        'f.Nombre = s
        'f.AlcVol = Me.AlcVol.Value
        'f.Volumen = Me.Volumen.Value
        'f._default = False

        'Dim L As New List(Of FormaFarmacéutica)
        'If customFormasFarmacéuticas IsNot Nothing Then L.AddRange(Me.customFormasFarmacéuticas)
        'L.Add(f)
        'customFormasFarmacéuticas = L.ToArray

        'FP_2.DataSource = Me.FormasFarmaDef
        'FP_3.DataSource = Me.FormasFarmaDef
        'FP_4.DataSource = Me.FormasFarmaDef

        'FP_2.SelectedItem = f

        'saveCustom()

    End Sub

    'Private Sub Eliminación_ValueChanged(sender As Object, e As EventArgs) Handles Eliminación.ValueChanged

    '    Dim t As NumericUpDown = TryCast(sender, NumericUpDown)
    '    Dim x As Double = 0

    '    If Me.ModeloFarmacocinéticoAnimado IsNot Nothing Then x = Me.ModeloFarmacocinéticoAnimado.CoeficienteQ
    '    If Not t Is Nothing Then VME.Text = VidaMediadeEliminación(t.Value, x, Me.TipoDeEliminación, Me.VelocidadMáximaDeEliminación)

    'End Sub

    'Private Sub Absorción_ValueChanged(sender As Object, e As EventArgs) Handles Absorción.ValueChanged

    '    Dim t As NumericUpDown = TryCast(sender, NumericUpDown)
    '    Dim x As Double = 0

    '    If Me.ModeloFarmacocinéticoAnimado IsNot Nothing Then x = Me.ModeloFarmacocinéticoAnimado.CoeficienteQ

    '    If Not t Is Nothing Then VMA.Text = VidaMediadeEliminación(t.Value, Nothing, GradosDeEliminación.Primer_Orden, Nothing)

    'End Sub
      
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Dim c As New Windows.Forms.SaveFileDialog With {.AddExtension = True,
                                                               .CheckFileExists = False,
                                                               .DefaultExt = "bmp",
                                                               .FileName = Me.ModeloFarmacocinéticoAnimado.GraphicName,
                                                               .Filter = "Archivos de mapa de bits|*.bmp"
                                                              }
        If c.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(c.FileName) Then My.Computer.FileSystem.DeleteFile(c.FileName)
            Me.NTGraph1.SaveAs(c.FileName)
        End If
    End Sub
End Class