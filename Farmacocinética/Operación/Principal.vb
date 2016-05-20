Imports NTGRAPHLib
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Xml
Imports Farmacocinética.Farmacocinética

Public Class MainForm

    Public ReadOnly Property Marcas()
        Get
            Dim l As New List(Of Marca)
            l.Add(New Marca With {.Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Marca1_label.Text.ToLower()),
                                  .Color = Drawing.Color.FromKnownColor(Marca1_color.SelectedItem),
                                  .Show = Marca1_visible.Checked,
                                  .y = Marca1.Value,
                                  .Size = Marca1_tamaño.Value,
                                  .style = NTGRAPHLib.LineType.Dot})
            l.Add(New Marca With {.Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Marca2_label.Text.ToLower()),
                                  .Color = Drawing.Color.FromKnownColor(Marca2_Color.SelectedItem),
                                  .Show = Marca2_visible.Checked,
                                  .y = Marca2.Value,
                                  .Size = Marca2_tamaño.Value,
                                  .style = NTGRAPHLib.LineType.Dot})
            l.Add(New Marca With {.Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Marca3_label.Text.ToLower()),
                                  .Color = Drawing.Color.FromKnownColor(Marca3_color.SelectedItem),
                                  .Show = Marca3_visible.Checked,
                                  .y = Marca3.Value,
                                  .Size = Marca3_tamaño.Value,
                                  .style = NTGRAPHLib.LineType.Dot})

            Return l.ToArray
        End Get
    End Property

#Region "Properties"

#Region "   Experimental Design"

    ReadOnly Property VolumenDeDistribución As Double
        Get
            Return VD_Num.Value '* 10 ^ VD_Exp.Value
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
            Return Dosis1.Value * 10 ^ -3
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

    ReadOnly Property ColorEje As Drawing.Color
        Get
            Try
                Return Drawing.Color.FromKnownColor(AxisColor.SelectedItem)
            Catch ex As Exception
                Stop
            End Try
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
            Dim returning As Element = New Element With {.lineColor = ColorPrincipal, .pointColor = ColorPrincipal,
                                     .pointSymbol = SymbolType.Nosym, .lineType = LineaPrincipal, .width = TamañoLinea}
            Return returning
        End Get
    End Property

    ReadOnly Property SecondaryElement As Element
        Get
            Dim returning As Element = New Element With {.lineColor = ColorDiferencial,
                    .lineType = TipoDiferencial, .width = TamañoDiferencial, .show = UsarDiferencial.Checked}
            Return returning
        End Get
    End Property

    ReadOnly Property extrapolado As Element
        Get
            Return New Element With {.lineColor = Drawing.Color.DarkBlue, .id = NTGraph1.ElementCount,
                               .lineType = LineaPrincipal, .width = TamañoLinea}
        End Get
    End Property

    ReadOnly Property eliminado As Element
        Get
            Return New Element With {.lineColor = Drawing.Color.Cyan, .id = NTGraph1.ElementCount,
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

        Me.ModeloFarmacocinéticoAnimado = New ModeloFarmacocinéticoAnimado(Me.NTGraph1)
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

        'LineColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'LineColor.SelectedItem = System.Drawing.KnownColor.Red
        'DotColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'DotColor.SelectedItem = System.Drawing.KnownColor.Green
        LineType.DataSource = [Enum].GetValues(GetType(NTGRAPHLib.LineType))
        LineType.SelectedItem = NTGRAPHLib.LineType.Solid
        'DotType.DataSource = [Enum].GetValues(GetType(NTGRAPHLib.SymbolType))
        'DotType.SelectedItem = NTGRAPHLib.SymbolType.Nosym
        'MaxColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'MaxColor.SelectedItem = System.Drawing.KnownColor.YellowGreen
        'DifColor.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'DifColor.SelectedItem = System.Drawing.KnownColor.Blue
        DiffType.DataSource = [Enum].GetValues(GetType(NTGRAPHLib.LineType))
        DiffType.SelectedItem = NTGRAPHLib.LineType.DashDotDot

        SetColorComboBox(LineColor, KnownColor.Red)
        SetColorComboBox(AxisColor, KnownColor.Black)
        SetColorComboBox(MaxColor, KnownColor.Black)
        SetColorComboBox(DifColor, KnownColor.Cyan)

        SetColorComboBox(Marca1_color, KnownColor.Black)
        SetColorComboBox(Marca2_Color, KnownColor.Black)
        SetColorComboBox(Marca3_color, KnownColor.Black)
        SetColorComboBox(Fondo, KnownColor.White)

        'Marca1_color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'Marca2_Color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'Marca3_color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'Marca4_color.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))
        'Fondo.DataSource = [Enum].GetValues(GetType(System.Drawing.KnownColor))



        'Marca1_color.SelectedItem = System.Drawing.KnownColor.Yellow
        'Marca2_Color.SelectedItem = System.Drawing.KnownColor.Yellow
        'Marca3_color.SelectedItem = System.Drawing.KnownColor.Yellow
        'Marca4_color.SelectedItem = System.Drawing.KnownColor.Red
        'Fondo.SelectedItem = System.Drawing.KnownColor.Blue

        'FarmacoPredeterminado.DataSource = Me.Fármacos

        Unidades.DataSource = [Enum].GetValues(GetType(Units))
        Unidades.SelectedItem = Units.microgramos_por_mililitro
    End Sub

    Private Sub initialize_laboratory()
        TipoEliminación.DataSource = [Enum].GetValues(GetType(GradosDeEliminación))
        TipoEliminación.SelectedItem = GradosDeEliminación.Primer_Orden

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        initializeDrawing()
        initialize_laboratory()
        formas_load()

        NTGraph1.FrameStyle = NTGRAPHLib.FrameStyle.Scope

        MúltiplesDosis_CheckedBoxesEventHandler(sender, e)

        CD01.LabelIsVisible = True
        CD02.LabelIsVisible = True
        CD03.LabelIsVisible = True
        CD04.LabelIsVisible = True
        CD05.LabelIsVisible = True
        CD06.LabelIsVisible = True
        CD07.LabelIsVisible = True
        CD08.LabelIsVisible = True
        CD09.LabelIsVisible = True
        CD10.LabelIsVisible = True
        CD11.LabelIsVisible = True
        CD12.LabelIsVisible = True
        CD13.LabelIsVisible = True
        CD14.LabelIsVisible = True
        CD15.LabelIsVisible = True
        CD16.LabelIsVisible = True
        CD17.LabelIsVisible = True
        CD18.LabelIsVisible = True

        CD01.TabStop = False
        CD02.TabStop = False
        CD03.TabStop = False
        CD04.TabStop = False
        CD05.TabStop = False
        CD06.TabStop = False
        CD07.TabStop = False
        CD08.TabStop = False
        CD09.TabStop = False
        CD10.TabStop = False
        CD11.TabStop = False
        CD12.TabStop = False
        CD13.TabStop = False
        CD14.TabStop = False
        CD15.TabStop = False
        CD16.TabStop = False
        CD17.TabStop = False
        CD18.TabStop = False

    End Sub

#Region "OLD"
    Private Sub DrawGraphicInfo()
        NTGraph1.XLabel = "Tiempo (horas)."
        NTGraph1.Caption = "Fármaco personalizado."
        NTGraph1.YLabel = "Concentración " & getUnitString(Me.Unidad)
        'graficar el eje
        NTGraph1.AddCursor(0, 0, 0, Drawing.Color.White, 0)
    End Sub

    Private Sub CreateNewElement()
        element = New Element With {.lineColor = ColorPrincipal, .id = NTGraph1.ElementCount, .pointColor = ColorPrincipal,
                                    .pointSymbol = SymbolType.Nosym, .lineType = LineaPrincipal, .width = TamañoLinea, .name = "Gráfico " & .id}

        element.ToGraph(NTGraph1)
    End Sub

    Private Sub Crear_Modelo_Farmacocinético()
        RemoveHandler Me.ModeloFarmacocinéticoAnimado.StopEvent, AddressOf Me.StopEvent
        RemoveHandler Me.ModeloFarmacocinéticoAnimado.StartEvent, AddressOf Me.StartEvent

        Dim style As Byte = 0
        If Libre.Checked Then style = 1
        If Pinned.Checked Then style = 2

        Me.ModeloFarmacocinéticoAnimado = New ModeloFarmacocinéticoAnimado(Me.NTGraph1) With
                                         {.BackgroundColor = Me.ColorFondo,
                                          .Biodisponibilidad = Me.FracciónBiodisponible,
                                          .ConstanteAbsorción = Me.Ka,
                                          .ConstanteEliminación = Me.Ke,
                                          .ConstanteMichaelisMenten = Me.Ke,
                                          .CurrentX = 0,
                                          .CursorStyle = style,
                                          .Dosificación = Me.TipoDeDosificación,
                                          .Dosis = Me.Dosis,
                                          .DosisCarga = Me.DosisCarga,
                                          .DosisTotales = Me.DosisTotales,
                                          .EndingX = Me.Horas_de_estudio,
                                          .GraphicName = "Tiempo vs. concentración de " + TryCast(Medicamento.SelectedItem, Fármaco).Nombre,
                                          .IntervaloEntreDosis = Me.IntérvaloDeDosificación,
                                          .Marcas = Me.Marcas,
                                          .MostrarAdministraciones = admins.Checked,
                                          .MostrarAUC = AUC.Checked,
                                          .MostrarCmaxTmax = CmaxTmax.Checked,
                                          .MostrarCPT0 = CPT0.Checked,
                                          .MostrarSemilogaritmo = Log.Checked,
                                          .PrincipalAxisColor = ColorEje,
                                          .PrincipalElement = PrincipalElement,
                                          .SecundaryElement = SecondaryElement,
                                          .SoloEliminacíón = Me.SóloEliminación,
                                          .StartingX = -2,
                                          .StepX = 1 / 60,
                                          .TipoEliminación = Me.TipoDeEliminación,
                                          .unit = Unidad,
                                          .UnitsAbscises = "TIEMPO (horas)",
                                          .UnitsOrdered = "CONCENTRACIÓN PLASMÁTICA ~ ",
                                          .UsarCarga = Me.UsarDosisCarga,
                                          .VelocidadDelTrazo = Me.VelocidadDeTrazo,
                                          .VMax = Me.VelocidadMáximaDeEliminación,
                                          .VolumenDistribución = VolumenDeDistribución
                                         }

        AddHandler Me.ModeloFarmacocinéticoAnimado.StopEvent, AddressOf Me.StopEvent
        AddHandler Me.ModeloFarmacocinéticoAnimado.StartEvent, AddressOf Me.StartEvent
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

    Private Sub StartEvent(sender As Object, e As EventArgs)
        Me.Clear.Enabled = False
        Me.Instant.Enabled = False
        Me.Iniciar.Enabled = False
        Me.Detener.Enabled = True
        Me.Panel1.Enabled = False
    End Sub

    Private Sub StopEvent(sender As Object, e As EventArgs)
        Me.Clear.Enabled = True
        Me.Instant.Enabled = True
        Me.Iniciar.Enabled = True
        Me.Detener.Enabled = False
        Me.Panel1.Enabled = True


    End Sub

    ''' <summary>
    ''' Se encarga de definir donde se dió el clic
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NTGraph1_CursorPosition(sender As Object, e As AxNTGRAPHLib._DNTGraphEvents_CursorPositionEvent) Handles NTGraph1.CursorPosition
        Dim d As New Date
        If e.x < 0 Then
            e.x = 0
        End If

        d = d.AddHours(e.x)

        If e.x < 24 Then
            TextBox_x.Text = String.Format("{0} h {1} min", d.Hour, d.Minute)
        Else
            TextBox_x.Text = String.Format("{0} d {1} h {2} min", d.Day, d.Hour, d.Minute)
        End If
        TextBox_y.Text = Format(e.y, "0.### ") & getUnitString(Me.Unidad)

    End Sub

    ''' <summary>
    ''' Displays the halfEliminationRate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub VidaMediaEliminación(sender As Object, e As EventArgs) Handles Dosis1.ValueChanged, Absorción.ValueChanged, Eliminación.ValueChanged
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

    Private Sub Unidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Unidades.SelectedIndexChanged
        Dim s As String = getUnitString(DirectCast(DirectCast(sender, ComboBox).SelectedItem, Units))

        Unidades1.Text = s
        Unidades2.Text = s
        Unidades3.Text = s
    End Sub

    Private Sub Libre_CheckedChanged(sender As Object, e As EventArgs) Handles Libre.CheckedChanged
        If Not Me.NTGraph1 Is Nothing Then
            If ModeloFarmacocinéticoAnimado.Status = Stats.READY Then Me.NTGraph1.CursorMode = 1
        End If
    End Sub

    Private Sub Pinned_CheckedChanged(sender As Object, e As EventArgs) Handles Pinned.CheckedChanged
        If Not Me.NTGraph1 Is Nothing Then
            If ModeloFarmacocinéticoAnimado.Status = Stats.READY Then Me.NTGraph1.CursorMode = 2
        End If
    End Sub

    Private Sub MúltiplesDosis_CheckedBoxesEventHandler(sender As Object, e As EventArgs) Handles MúltiplesDosis.CheckedChanged, ChargeDoseActive.CheckedChanged
        CD05.Enabled = MúltiplesDosis.Checked
        CD06.Enabled = MúltiplesDosis.Checked
        CD07.Enabled = MúltiplesDosis.Checked
        ChargeDoseActive.Enabled = MúltiplesDosis.Checked
        CD08.Enabled = MúltiplesDosis.Checked And ChargeDoseActive.Checked
    End Sub

    Private Sub SetColorComboBox(Combobox As ComboBox, color As KnownColor)
        Dim listaDeColoresDelSistma As New List(Of String)
        Dim listaDeColores As New List(Of KnownColor)

        Dim props() As System.Reflection.PropertyInfo = GetType(SystemColors).GetProperties
        For Each p As System.Reflection.PropertyInfo In props
            listaDeColoresDelSistma.Add(p.Name)
        Next

        For Each col As Object In [Enum].GetValues(GetType(KnownColor))
            If Not listaDeColoresDelSistma.Contains(col.ToString) Then listaDeColores.Add(col)
        Next

        Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed

        AddHandler Combobox.DrawItem, Sub(_s As Object, _e As DrawItemEventArgs)
                                          _e.DrawBackground()

                                          Dim c As Color = Drawing.Color.FromKnownColor(listaDeColores(_e.Index))

                                          Dim b As New SolidBrush(c)

                                          Dim tb As Brush = Brushes.Black

                                          _e.Graphics.FillRectangle(b, _e.Bounds.X + CInt(_e.Bounds.Width * 0.5), _e.Bounds.Y + CInt(_e.Bounds.Height * 0.1), CInt(_e.Bounds.Width * 0.8), CInt(_e.Bounds.Height * 0.8))

                                          _e.Graphics.DrawString(listaDeColores(_e.Index).ToString, Combobox.Font, tb, _e.Bounds)

                                          b.Dispose()
                                          _e.DrawFocusRectangle()
                                      End Sub

        Combobox.DataSource = listaDeColores.ToArray

        Combobox.SelectedItem = color
    End Sub

    Private Sub Label65_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        MsgBox(Label65.Text, vbOKOnly + MsgBoxStyle.Information)

    End Sub
#End Region

#Region "Formas farmacéuticas"
    Sub formas_load()
        Medicamento.DataSource = Prediseñados.fármacos
        Medicamento.SelectedItem = Prediseñados.fármacos(0)
    End Sub

    Private Sub Medicamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Medicamento.SelectedIndexChanged
        Dim f As Fármaco = DirectCast(Medicamento.SelectedItem, Fármaco)
        Administración.DataSource = f.formasFarmacéuticas
        Administración.SelectedItem = f.formasFarmacéuticas(0)
    End Sub

    Private Sub Administración_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Administración.SelectedIndexChanged
        Dim f As Fármaco = DirectCast(Medicamento.SelectedItem, Fármaco)
        Dim g As formaGalénica = DirectCast(Administración.SelectedItem, formaGalénica)

        Absorción.Value = g.ConstanteAbsorción
        BD.Value = g.BD
        Eliminación.Value = f.Ke
        t_lag.Value = g.Latencia
        TipoEliminación.SelectedItem = f.TipoEliminación
        VD_Num.Value = f.VD
        VelocidadMaximaEliminación.Value = f.vMax
        MichaelisTx.Value = f.km
        Dosis1.Value = g.Dosis

        'CME
        Marca1_visible.Checked = (f.CME > 0)
        Marca1.Value = If(f.CME > 0, f.CME, 0)

        'CMR
        Marca3_visible.Checked = (f.CMR > 0)
        Marca3.Value = If(f.CMR > 0, f.CMR, 0)

        'CTx
        Marca2_visible.Checked = (f.CTx > 0)
        Marca2.Value = If(f.CTx > 0, f.CTx, 0)

    End Sub


#End Region

End Class