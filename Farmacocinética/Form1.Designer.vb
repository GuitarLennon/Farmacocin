<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Instant = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Iniciar = New System.Windows.Forms.ToolStripButton()
        Me.Detener = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Clear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Save = New System.Windows.Forms.ToolStripButton()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ControlDemostración16 = New ControlActualizable.ControlDemostración()
        Me.VME = New System.Windows.Forms.TextBox()
        Me.ControlDemostración15 = New ControlActualizable.ControlDemostración()
        Me.VMA = New System.Windows.Forms.TextBox()
        Me.ControlDemostración14 = New ControlActualizable.ControlDemostración()
        Me.VelocidadMaximaEliminación = New System.Windows.Forms.NumericUpDown()
        Me.ControlDemostración13 = New ControlActualizable.ControlDemostración()
        Me.TipoEliminación = New System.Windows.Forms.ComboBox()
        Me.ControlDemostración12 = New ControlActualizable.ControlDemostración()
        Me.Eliminación = New System.Windows.Forms.NumericUpDown()
        Me.ControlDemostración11 = New ControlActualizable.ControlDemostración()
        Me.Absorción = New System.Windows.Forms.NumericUpDown()
        Me.ControlDemostración3 = New ControlActualizable.ControlDemostración()
        Me.BD = New System.Windows.Forms.NumericUpDown()
        Me.ControlDemostración2 = New ControlActualizable.ControlDemostración()
        Me.VD_Num = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ControlDemostración9 = New ControlActualizable.ControlDemostración()
        Me.ChargeDose = New System.Windows.Forms.NumericUpDown()
        Me.ChargeDoseActive = New System.Windows.Forms.CheckBox()
        Me.ControlDemostración10 = New ControlActualizable.ControlDemostración()
        Me.DosisTotalesNum = New System.Windows.Forms.NumericUpDown()
        Me.ControlDemostración8 = New ControlActualizable.ControlDemostración()
        Me.IntérvaloDosificaciónMinutos = New System.Windows.Forms.NumericUpDown()
        Me.ControlDemostración7 = New ControlActualizable.ControlDemostración()
        Me.IntérvaloDosificaciónHoras = New System.Windows.Forms.NumericUpDown()
        Me.MúltiplesDosis = New System.Windows.Forms.CheckBox()
        Me.ControlDemostración1 = New ControlActualizable.ControlDemostración()
        Me.Dosis1 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ControlDemostración6 = New ControlActualizable.ControlDemostración()
        Me.Unidades = New System.Windows.Forms.ComboBox()
        Me.ControlDemostración5 = New ControlActualizable.ControlDemostración()
        Me.Velocidad_de_trazo = New System.Windows.Forms.NumericUpDown()
        Me.ControlDemostración4 = New ControlActualizable.ControlDemostración()
        Me.Horas_Estudio_Num = New System.Windows.Forms.NumericUpDown()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupMarcas = New System.Windows.Forms.GroupBox()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Marca3_visible = New System.Windows.Forms.CheckBox()
        Me.Marca3 = New System.Windows.Forms.NumericUpDown()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Marca3_color = New System.Windows.Forms.ComboBox()
        Me.Marca3_tamaño = New System.Windows.Forms.NumericUpDown()
        Me.Marca3_label = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Marca2_visible = New System.Windows.Forms.CheckBox()
        Me.Marca2 = New System.Windows.Forms.NumericUpDown()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Marca2_Color = New System.Windows.Forms.ComboBox()
        Me.Marca2_tamaño = New System.Windows.Forms.NumericUpDown()
        Me.Marca2_label = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Marca1 = New System.Windows.Forms.NumericUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Marca1_color = New System.Windows.Forms.ComboBox()
        Me.Marca1_tamaño = New System.Windows.Forms.NumericUpDown()
        Me.Marca1_visible = New System.Windows.Forms.CheckBox()
        Me.Marca1_label = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Panel31 = New System.Windows.Forms.Panel()
        Me.Fondo = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.LineType = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LineColor = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LineSize = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.DotType = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DotColor = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.DiffType = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.DifColor = New System.Windows.Forms.ComboBox()
        Me.UsarDiferencial = New System.Windows.Forms.CheckBox()
        Me.DiffSize = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.SoloEliminación = New System.Windows.Forms.CheckBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.MaxColor = New System.Windows.Forms.ComboBox()
        Me.Log = New System.Windows.Forms.CheckBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Acotaciones1 = New System.Windows.Forms.CheckBox()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.TextBox_y = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox_x = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TextBox_CAe = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ControlDemostración16.SuspendLayout()
        Me.ControlDemostración15.SuspendLayout()
        Me.ControlDemostración14.SuspendLayout()
        CType(Me.VelocidadMaximaEliminación, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración13.SuspendLayout()
        Me.ControlDemostración12.SuspendLayout()
        CType(Me.Eliminación, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración11.SuspendLayout()
        CType(Me.Absorción, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración3.SuspendLayout()
        CType(Me.BD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración2.SuspendLayout()
        CType(Me.VD_Num, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.ControlDemostración9.SuspendLayout()
        CType(Me.ChargeDose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración10.SuspendLayout()
        CType(Me.DosisTotalesNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración8.SuspendLayout()
        CType(Me.IntérvaloDosificaciónMinutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración7.SuspendLayout()
        CType(Me.IntérvaloDosificaciónHoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración1.SuspendLayout()
        CType(Me.Dosis1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.ControlDemostración6.SuspendLayout()
        Me.ControlDemostración5.SuspendLayout()
        CType(Me.Velocidad_de_trazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlDemostración4.SuspendLayout()
        CType(Me.Horas_Estudio_Num, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupMarcas.SuspendLayout()
        Me.Panel20.SuspendLayout()
        CType(Me.Marca3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Marca3_tamaño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel17.SuspendLayout()
        CType(Me.Marca2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Marca2_tamaño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        CType(Me.Marca1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Marca1_tamaño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel31.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.LineSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.Panel15.SuspendLayout()
        CType(Me.DiffSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel26.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel22.SuspendLayout()
        Me.Panel25.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.MainTabControl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel22)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Panel2MinSize = 290
        Me.SplitContainer1.Size = New System.Drawing.Size(984, 736)
        Me.SplitContainer1.SplitterDistance = 689
        Me.SplitContainer1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Instant, Me.ToolStripSeparator2, Me.Iniciar, Me.Detener, Me.ToolStripSeparator3, Me.Clear, Me.ToolStripSeparator1, Me.Save})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(689, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Instant
        '
        Me.Instant.Image = Global.Farmacocinética.My.Resources.Resources.flag_16xLG
        Me.Instant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Instant.Name = "Instant"
        Me.Instant.Size = New System.Drawing.Size(89, 22)
        Me.Instant.Text = "Instantáneo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Iniciar
        '
        Me.Iniciar.Image = Global.Farmacocinética.My.Resources.Resources.startwithoutdebugging_6556
        Me.Iniciar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Iniciar.Name = "Iniciar"
        Me.Iniciar.Size = New System.Drawing.Size(59, 22)
        Me.Iniciar.Text = "Iniciar"
        '
        'Detener
        '
        Me.Detener.Image = Global.Farmacocinética.My.Resources.Resources.Stroke
        Me.Detener.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Detener.Name = "Detener"
        Me.Detener.Size = New System.Drawing.Size(68, 22)
        Me.Detener.Text = "Detener"
        Me.Detener.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'Clear
        '
        Me.Clear.Image = Global.Farmacocinética.My.Resources.Resources.Clearallrequests_8816
        Me.Clear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(67, 22)
        Me.Clear.Text = "Limpiar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Save
        '
        Me.Save.Image = Global.Farmacocinética.My.Resources.Resources.Save_6530
        Me.Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(112, 22)
        Me.Save.Text = "Guardar Imagen"
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.TabPage2)
        Me.MainTabControl.Controls.Add(Me.TabPage3)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(291, 680)
        Me.MainTabControl.TabIndex = 38
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(283, 654)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Diseño experimental"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Teal
        Me.GroupBox3.Controls.Add(Me.ControlDemostración16)
        Me.GroupBox3.Controls.Add(Me.ControlDemostración15)
        Me.GroupBox3.Controls.Add(Me.ControlDemostración14)
        Me.GroupBox3.Controls.Add(Me.ControlDemostración13)
        Me.GroupBox3.Controls.Add(Me.ControlDemostración12)
        Me.GroupBox3.Controls.Add(Me.ControlDemostración11)
        Me.GroupBox3.Controls.Add(Me.ControlDemostración3)
        Me.GroupBox3.Controls.Add(Me.ControlDemostración2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(3, 404)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 319)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Parámetros Farmacocinéticos"
        '
        'ControlDemostración16
        '
        Me.ControlDemostración16.Control = Me.VME
        Me.ControlDemostración16.Controls.Add(Me.VME)
        Me.ControlDemostración16.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración16.LabelIsVisible = False
        Me.ControlDemostración16.Location = New System.Drawing.Point(3, 269)
        Me.ControlDemostración16.Name = "ControlDemostración16"
        Me.ControlDemostración16.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración16.TabIndex = 10
        Me.ControlDemostración16.Text = "Vida media de eliminación"
        '
        'VME
        '
        Me.VME.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VME.Location = New System.Drawing.Point(0, 0)
        Me.VME.Name = "VME"
        Me.VME.Size = New System.Drawing.Size(254, 20)
        Me.VME.TabIndex = 10
        '
        'ControlDemostración15
        '
        Me.ControlDemostración15.Control = Me.VMA
        Me.ControlDemostración15.Controls.Add(Me.VMA)
        Me.ControlDemostración15.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración15.LabelIsVisible = False
        Me.ControlDemostración15.Location = New System.Drawing.Point(3, 233)
        Me.ControlDemostración15.Name = "ControlDemostración15"
        Me.ControlDemostración15.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración15.TabIndex = 9
        Me.ControlDemostración15.Text = "Vida media de absorción"
        '
        'VMA
        '
        Me.VMA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VMA.Location = New System.Drawing.Point(0, 0)
        Me.VMA.Name = "VMA"
        Me.VMA.Size = New System.Drawing.Size(254, 20)
        Me.VMA.TabIndex = 10
        '
        'ControlDemostración14
        '
        Me.ControlDemostración14.Control = Me.VelocidadMaximaEliminación
        Me.ControlDemostración14.Controls.Add(Me.VelocidadMaximaEliminación)
        Me.ControlDemostración14.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración14.LabelIsVisible = False
        Me.ControlDemostración14.Location = New System.Drawing.Point(3, 197)
        Me.ControlDemostración14.Name = "ControlDemostración14"
        Me.ControlDemostración14.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración14.TabIndex = 8
        Me.ControlDemostración14.Text = "Velocidad Máxima de Eliminación"
        '
        'VelocidadMaximaEliminación
        '
        Me.VelocidadMaximaEliminación.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VelocidadMaximaEliminación.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.VelocidadMaximaEliminación.Location = New System.Drawing.Point(0, 0)
        Me.VelocidadMaximaEliminación.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.VelocidadMaximaEliminación.Name = "VelocidadMaximaEliminación"
        Me.VelocidadMaximaEliminación.Size = New System.Drawing.Size(254, 20)
        Me.VelocidadMaximaEliminación.TabIndex = 1
        Me.VelocidadMaximaEliminación.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.VelocidadMaximaEliminación.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'ControlDemostración13
        '
        Me.ControlDemostración13.Control = Me.TipoEliminación
        Me.ControlDemostración13.Controls.Add(Me.TipoEliminación)
        Me.ControlDemostración13.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración13.LabelIsVisible = False
        Me.ControlDemostración13.Location = New System.Drawing.Point(3, 160)
        Me.ControlDemostración13.Name = "ControlDemostración13"
        Me.ControlDemostración13.Size = New System.Drawing.Size(254, 37)
        Me.ControlDemostración13.TabIndex = 7
        Me.ControlDemostración13.Text = "Tipo de eliminación"
        '
        'TipoEliminación
        '
        Me.TipoEliminación.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TipoEliminación.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoEliminación.FormattingEnabled = True
        Me.TipoEliminación.Location = New System.Drawing.Point(0, 0)
        Me.TipoEliminación.Name = "TipoEliminación"
        Me.TipoEliminación.Size = New System.Drawing.Size(254, 21)
        Me.TipoEliminación.TabIndex = 4
        '
        'ControlDemostración12
        '
        Me.ControlDemostración12.Control = Me.Eliminación
        Me.ControlDemostración12.Controls.Add(Me.Eliminación)
        Me.ControlDemostración12.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración12.LabelIsVisible = False
        Me.ControlDemostración12.Location = New System.Drawing.Point(3, 124)
        Me.ControlDemostración12.Name = "ControlDemostración12"
        Me.ControlDemostración12.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración12.TabIndex = 4
        Me.ControlDemostración12.Text = "Constante de eliminación (ke)"
        '
        'Eliminación
        '
        Me.Eliminación.DecimalPlaces = 3
        Me.Eliminación.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Eliminación.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Eliminación.Location = New System.Drawing.Point(0, 0)
        Me.Eliminación.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.Eliminación.Name = "Eliminación"
        Me.Eliminación.Size = New System.Drawing.Size(254, 20)
        Me.Eliminación.TabIndex = 1
        Me.Eliminación.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Eliminación.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'ControlDemostración11
        '
        Me.ControlDemostración11.Control = Me.Absorción
        Me.ControlDemostración11.Controls.Add(Me.Absorción)
        Me.ControlDemostración11.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración11.LabelIsVisible = False
        Me.ControlDemostración11.Location = New System.Drawing.Point(3, 88)
        Me.ControlDemostración11.Name = "ControlDemostración11"
        Me.ControlDemostración11.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración11.TabIndex = 3
        Me.ControlDemostración11.Text = "Constante de absorción (Ka)"
        '
        'Absorción
        '
        Me.Absorción.DecimalPlaces = 3
        Me.Absorción.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Absorción.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.Absorción.Location = New System.Drawing.Point(0, 0)
        Me.Absorción.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.Absorción.Name = "Absorción"
        Me.Absorción.Size = New System.Drawing.Size(254, 20)
        Me.Absorción.TabIndex = 1
        Me.Absorción.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Absorción.Value = New Decimal(New Integer() {3, 0, 0, 131072})
        '
        'ControlDemostración3
        '
        Me.ControlDemostración3.Control = Me.BD
        Me.ControlDemostración3.Controls.Add(Me.BD)
        Me.ControlDemostración3.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración3.LabelIsVisible = False
        Me.ControlDemostración3.Location = New System.Drawing.Point(3, 52)
        Me.ControlDemostración3.Name = "ControlDemostración3"
        Me.ControlDemostración3.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración3.TabIndex = 2
        Me.ControlDemostración3.Text = "Biodisponibilidad"
        '
        'BD
        '
        Me.BD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BD.Location = New System.Drawing.Point(0, 0)
        Me.BD.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.BD.Name = "BD"
        Me.BD.Size = New System.Drawing.Size(254, 20)
        Me.BD.TabIndex = 1
        Me.BD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.BD.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'ControlDemostración2
        '
        Me.ControlDemostración2.Control = Me.VD_Num
        Me.ControlDemostración2.Controls.Add(Me.VD_Num)
        Me.ControlDemostración2.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración2.LabelIsVisible = False
        Me.ControlDemostración2.Location = New System.Drawing.Point(3, 16)
        Me.ControlDemostración2.Name = "ControlDemostración2"
        Me.ControlDemostración2.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración2.TabIndex = 1
        Me.ControlDemostración2.Text = "Volumen de distribución (L)"
        '
        'VD_Num
        '
        Me.VD_Num.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VD_Num.Location = New System.Drawing.Point(0, 0)
        Me.VD_Num.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.VD_Num.Name = "VD_Num"
        Me.VD_Num.Size = New System.Drawing.Size(254, 20)
        Me.VD_Num.TabIndex = 1
        Me.VD_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.VD_Num.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Red
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.ControlDemostración1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(3, 138)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 266)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dosificación y diseño"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.LawnGreen
        Me.GroupBox5.Controls.Add(Me.ControlDemostración9)
        Me.GroupBox5.Controls.Add(Me.ChargeDoseActive)
        Me.GroupBox5.Controls.Add(Me.ControlDemostración10)
        Me.GroupBox5.Controls.Add(Me.ControlDemostración8)
        Me.GroupBox5.Controls.Add(Me.ControlDemostración7)
        Me.GroupBox5.Controls.Add(Me.MúltiplesDosis)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(3, 52)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(254, 204)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Dosis múltiples"
        '
        'ControlDemostración9
        '
        Me.ControlDemostración9.BackColor = System.Drawing.Color.ForestGreen
        Me.ControlDemostración9.Control = Me.ChargeDose
        Me.ControlDemostración9.Controls.Add(Me.ChargeDose)
        Me.ControlDemostración9.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración9.ForeColor = System.Drawing.Color.White
        Me.ControlDemostración9.LabelIsVisible = False
        Me.ControlDemostración9.Location = New System.Drawing.Point(3, 158)
        Me.ControlDemostración9.Name = "ControlDemostración9"
        Me.ControlDemostración9.Size = New System.Drawing.Size(248, 40)
        Me.ControlDemostración9.TabIndex = 6
        Me.ControlDemostración9.Text = "Dosis de carga (gramos)"
        '
        'ChargeDose
        '
        Me.ChargeDose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChargeDose.Location = New System.Drawing.Point(0, 0)
        Me.ChargeDose.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.ChargeDose.Name = "ChargeDose"
        Me.ChargeDose.Size = New System.Drawing.Size(248, 20)
        Me.ChargeDose.TabIndex = 1
        Me.ChargeDose.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ChargeDoseActive
        '
        Me.ChargeDoseActive.AutoSize = True
        Me.ChargeDoseActive.BackColor = System.Drawing.Color.ForestGreen
        Me.ChargeDoseActive.Dock = System.Windows.Forms.DockStyle.Top
        Me.ChargeDoseActive.ForeColor = System.Drawing.Color.White
        Me.ChargeDoseActive.Location = New System.Drawing.Point(3, 141)
        Me.ChargeDoseActive.Name = "ChargeDoseActive"
        Me.ChargeDoseActive.Size = New System.Drawing.Size(248, 17)
        Me.ChargeDoseActive.TabIndex = 7
        Me.ChargeDoseActive.Text = "Usar Dosis de carga"
        Me.ChargeDoseActive.UseVisualStyleBackColor = False
        '
        'ControlDemostración10
        '
        Me.ControlDemostración10.Control = Me.DosisTotalesNum
        Me.ControlDemostración10.Controls.Add(Me.DosisTotalesNum)
        Me.ControlDemostración10.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración10.LabelIsVisible = False
        Me.ControlDemostración10.Location = New System.Drawing.Point(3, 105)
        Me.ControlDemostración10.Name = "ControlDemostración10"
        Me.ControlDemostración10.Size = New System.Drawing.Size(248, 36)
        Me.ControlDemostración10.TabIndex = 9
        Me.ControlDemostración10.Text = "Dosis totales"
        '
        'DosisTotalesNum
        '
        Me.DosisTotalesNum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DosisTotalesNum.Location = New System.Drawing.Point(0, 0)
        Me.DosisTotalesNum.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.DosisTotalesNum.Name = "DosisTotalesNum"
        Me.DosisTotalesNum.Size = New System.Drawing.Size(248, 20)
        Me.DosisTotalesNum.TabIndex = 1
        Me.DosisTotalesNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DosisTotalesNum.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'ControlDemostración8
        '
        Me.ControlDemostración8.Control = Me.IntérvaloDosificaciónMinutos
        Me.ControlDemostración8.Controls.Add(Me.IntérvaloDosificaciónMinutos)
        Me.ControlDemostración8.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración8.LabelIsVisible = False
        Me.ControlDemostración8.Location = New System.Drawing.Point(3, 69)
        Me.ControlDemostración8.Name = "ControlDemostración8"
        Me.ControlDemostración8.Size = New System.Drawing.Size(248, 36)
        Me.ControlDemostración8.TabIndex = 5
        Me.ControlDemostración8.Text = "Intervalo de dosificación (minutos)"
        '
        'IntérvaloDosificaciónMinutos
        '
        Me.IntérvaloDosificaciónMinutos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IntérvaloDosificaciónMinutos.Location = New System.Drawing.Point(0, 0)
        Me.IntérvaloDosificaciónMinutos.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.IntérvaloDosificaciónMinutos.Name = "IntérvaloDosificaciónMinutos"
        Me.IntérvaloDosificaciónMinutos.Size = New System.Drawing.Size(248, 20)
        Me.IntérvaloDosificaciónMinutos.TabIndex = 1
        Me.IntérvaloDosificaciónMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.IntérvaloDosificaciónMinutos.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'ControlDemostración7
        '
        Me.ControlDemostración7.Control = Me.IntérvaloDosificaciónHoras
        Me.ControlDemostración7.Controls.Add(Me.IntérvaloDosificaciónHoras)
        Me.ControlDemostración7.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración7.LabelIsVisible = False
        Me.ControlDemostración7.Location = New System.Drawing.Point(3, 33)
        Me.ControlDemostración7.Name = "ControlDemostración7"
        Me.ControlDemostración7.Size = New System.Drawing.Size(248, 36)
        Me.ControlDemostración7.TabIndex = 4
        Me.ControlDemostración7.Text = "Intervalo de dosificación (horas)"
        '
        'IntérvaloDosificaciónHoras
        '
        Me.IntérvaloDosificaciónHoras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IntérvaloDosificaciónHoras.Location = New System.Drawing.Point(0, 0)
        Me.IntérvaloDosificaciónHoras.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.IntérvaloDosificaciónHoras.Name = "IntérvaloDosificaciónHoras"
        Me.IntérvaloDosificaciónHoras.Size = New System.Drawing.Size(248, 20)
        Me.IntérvaloDosificaciónHoras.TabIndex = 1
        Me.IntérvaloDosificaciónHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.IntérvaloDosificaciónHoras.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'MúltiplesDosis
        '
        Me.MúltiplesDosis.AutoSize = True
        Me.MúltiplesDosis.BackColor = System.Drawing.Color.Chartreuse
        Me.MúltiplesDosis.Dock = System.Windows.Forms.DockStyle.Top
        Me.MúltiplesDosis.ForeColor = System.Drawing.Color.Black
        Me.MúltiplesDosis.Location = New System.Drawing.Point(3, 16)
        Me.MúltiplesDosis.Name = "MúltiplesDosis"
        Me.MúltiplesDosis.Size = New System.Drawing.Size(248, 17)
        Me.MúltiplesDosis.TabIndex = 8
        Me.MúltiplesDosis.Text = "Activar Múltiples dosis"
        Me.MúltiplesDosis.UseVisualStyleBackColor = False
        '
        'ControlDemostración1
        '
        Me.ControlDemostración1.Control = Me.Dosis1
        Me.ControlDemostración1.Controls.Add(Me.Dosis1)
        Me.ControlDemostración1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración1.LabelIsVisible = False
        Me.ControlDemostración1.Location = New System.Drawing.Point(3, 16)
        Me.ControlDemostración1.Name = "ControlDemostración1"
        Me.ControlDemostración1.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración1.TabIndex = 0
        Me.ControlDemostración1.Text = "Dosis (miligramos)"
        '
        'Dosis1
        '
        Me.Dosis1.DecimalPlaces = 3
        Me.Dosis1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dosis1.Location = New System.Drawing.Point(0, 0)
        Me.Dosis1.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.Dosis1.Name = "Dosis1"
        Me.Dosis1.Size = New System.Drawing.Size(254, 20)
        Me.Dosis1.TabIndex = 1
        Me.Dosis1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Dosis1.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox4.Controls.Add(Me.ControlDemostración6)
        Me.GroupBox4.Controls.Add(Me.ControlDemostración5)
        Me.GroupBox4.Controls.Add(Me.ControlDemostración4)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(260, 135)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Diseño del estudio"
        '
        'ControlDemostración6
        '
        Me.ControlDemostración6.Control = Me.Unidades
        Me.ControlDemostración6.Controls.Add(Me.Unidades)
        Me.ControlDemostración6.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración6.LabelIsVisible = False
        Me.ControlDemostración6.Location = New System.Drawing.Point(3, 88)
        Me.ControlDemostración6.Name = "ControlDemostración6"
        Me.ControlDemostración6.Size = New System.Drawing.Size(254, 37)
        Me.ControlDemostración6.TabIndex = 6
        Me.ControlDemostración6.Text = "Unidades"
        '
        'Unidades
        '
        Me.Unidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Unidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Unidades.FormattingEnabled = True
        Me.Unidades.Location = New System.Drawing.Point(0, 0)
        Me.Unidades.Name = "Unidades"
        Me.Unidades.Size = New System.Drawing.Size(254, 21)
        Me.Unidades.TabIndex = 4
        '
        'ControlDemostración5
        '
        Me.ControlDemostración5.Control = Me.Velocidad_de_trazo
        Me.ControlDemostración5.Controls.Add(Me.Velocidad_de_trazo)
        Me.ControlDemostración5.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración5.LabelIsVisible = False
        Me.ControlDemostración5.Location = New System.Drawing.Point(3, 52)
        Me.ControlDemostración5.Name = "ControlDemostración5"
        Me.ControlDemostración5.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración5.TabIndex = 5
        Me.ControlDemostración5.Text = "Velocidad del trazo (h/seg)"
        '
        'Velocidad_de_trazo
        '
        Me.Velocidad_de_trazo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Velocidad_de_trazo.Location = New System.Drawing.Point(0, 0)
        Me.Velocidad_de_trazo.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.Velocidad_de_trazo.Name = "Velocidad_de_trazo"
        Me.Velocidad_de_trazo.Size = New System.Drawing.Size(254, 20)
        Me.Velocidad_de_trazo.TabIndex = 1
        Me.Velocidad_de_trazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Velocidad_de_trazo.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'ControlDemostración4
        '
        Me.ControlDemostración4.Control = Me.Horas_Estudio_Num
        Me.ControlDemostración4.Controls.Add(Me.Horas_Estudio_Num)
        Me.ControlDemostración4.Dock = System.Windows.Forms.DockStyle.Top
        Me.ControlDemostración4.LabelIsVisible = False
        Me.ControlDemostración4.Location = New System.Drawing.Point(3, 16)
        Me.ControlDemostración4.Name = "ControlDemostración4"
        Me.ControlDemostración4.Size = New System.Drawing.Size(254, 36)
        Me.ControlDemostración4.TabIndex = 4
        Me.ControlDemostración4.Text = "Horas de estudio (h)"
        '
        'Horas_Estudio_Num
        '
        Me.Horas_Estudio_Num.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Horas_Estudio_Num.Location = New System.Drawing.Point(0, 0)
        Me.Horas_Estudio_Num.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.Horas_Estudio_Num.Name = "Horas_Estudio_Num"
        Me.Horas_Estudio_Num.Size = New System.Drawing.Size(254, 20)
        Me.Horas_Estudio_Num.TabIndex = 1
        Me.Horas_Estudio_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Horas_Estudio_Num.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label65)
        Me.TabPage3.Controls.Add(Me.PictureBox1)
        Me.TabPage3.Controls.Add(Me.GroupMarcas)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(283, 654)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Valores de referencia y gráfico"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(94, 487)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(186, 160)
        Me.Label65.TabIndex = 74
        Me.Label65.Text = resources.GetString("Label65.Text")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 514)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(89, 99)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        '
        'GroupMarcas
        '
        Me.GroupMarcas.Controls.Add(Me.Panel20)
        Me.GroupMarcas.Controls.Add(Me.Marca3_label)
        Me.GroupMarcas.Controls.Add(Me.Panel17)
        Me.GroupMarcas.Controls.Add(Me.Marca2_label)
        Me.GroupMarcas.Controls.Add(Me.Panel16)
        Me.GroupMarcas.Controls.Add(Me.Marca1_label)
        Me.GroupMarcas.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupMarcas.Location = New System.Drawing.Point(3, 251)
        Me.GroupMarcas.Name = "GroupMarcas"
        Me.GroupMarcas.Size = New System.Drawing.Size(277, 157)
        Me.GroupMarcas.TabIndex = 72
        Me.GroupMarcas.TabStop = False
        Me.GroupMarcas.Text = "Valores de referencia"
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Blue
        Me.Panel20.Controls.Add(Me.Marca3_visible)
        Me.Panel20.Controls.Add(Me.Marca3)
        Me.Panel20.Controls.Add(Me.Label60)
        Me.Panel20.Controls.Add(Me.Marca3_color)
        Me.Panel20.Controls.Add(Me.Marca3_tamaño)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.ForeColor = System.Drawing.Color.White
        Me.Panel20.Location = New System.Drawing.Point(3, 99)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(271, 22)
        Me.Panel20.TabIndex = 77
        '
        'Marca3_visible
        '
        Me.Marca3_visible.AutoSize = True
        Me.Marca3_visible.Checked = True
        Me.Marca3_visible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Marca3_visible.Dock = System.Windows.Forms.DockStyle.Left
        Me.Marca3_visible.Location = New System.Drawing.Point(0, 0)
        Me.Marca3_visible.Name = "Marca3_visible"
        Me.Marca3_visible.Size = New System.Drawing.Size(61, 22)
        Me.Marca3_visible.TabIndex = 82
        Me.Marca3_visible.Text = "Mostrar"
        Me.Marca3_visible.UseVisualStyleBackColor = True
        '
        'Marca3
        '
        Me.Marca3.DecimalPlaces = 3
        Me.Marca3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Marca3.Location = New System.Drawing.Point(0, 0)
        Me.Marca3.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.Marca3.Name = "Marca3"
        Me.Marca3.Size = New System.Drawing.Size(110, 20)
        Me.Marca3.TabIndex = 15
        Me.Marca3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Marca3.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label60.Location = New System.Drawing.Point(110, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(24, 13)
        Me.Label60.TabIndex = 12
        Me.Label60.Text = "g/L"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Marca3_color
        '
        Me.Marca3_color.Dock = System.Windows.Forms.DockStyle.Right
        Me.Marca3_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Marca3_color.FormattingEnabled = True
        Me.Marca3_color.Location = New System.Drawing.Point(134, 0)
        Me.Marca3_color.Name = "Marca3_color"
        Me.Marca3_color.Size = New System.Drawing.Size(97, 21)
        Me.Marca3_color.TabIndex = 57
        '
        'Marca3_tamaño
        '
        Me.Marca3_tamaño.Dock = System.Windows.Forms.DockStyle.Right
        Me.Marca3_tamaño.Location = New System.Drawing.Point(231, 0)
        Me.Marca3_tamaño.Name = "Marca3_tamaño"
        Me.Marca3_tamaño.Size = New System.Drawing.Size(40, 20)
        Me.Marca3_tamaño.TabIndex = 58
        Me.Marca3_tamaño.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Marca3_label
        '
        Me.Marca3_label.BackColor = System.Drawing.Color.Blue
        Me.Marca3_label.Dock = System.Windows.Forms.DockStyle.Top
        Me.Marca3_label.ForeColor = System.Drawing.Color.White
        Me.Marca3_label.Location = New System.Drawing.Point(3, 86)
        Me.Marca3_label.Name = "Marca3_label"
        Me.Marca3_label.Size = New System.Drawing.Size(271, 13)
        Me.Marca3_label.TabIndex = 76
        Me.Marca3_label.Text = "Otra concentración"
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Blue
        Me.Panel17.Controls.Add(Me.Marca2_visible)
        Me.Panel17.Controls.Add(Me.Marca2)
        Me.Panel17.Controls.Add(Me.Label44)
        Me.Panel17.Controls.Add(Me.Marca2_Color)
        Me.Panel17.Controls.Add(Me.Marca2_tamaño)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel17.ForeColor = System.Drawing.Color.White
        Me.Panel17.Location = New System.Drawing.Point(3, 64)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(271, 22)
        Me.Panel17.TabIndex = 75
        '
        'Marca2_visible
        '
        Me.Marca2_visible.AutoSize = True
        Me.Marca2_visible.Checked = True
        Me.Marca2_visible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Marca2_visible.Dock = System.Windows.Forms.DockStyle.Left
        Me.Marca2_visible.Location = New System.Drawing.Point(0, 0)
        Me.Marca2_visible.Name = "Marca2_visible"
        Me.Marca2_visible.Size = New System.Drawing.Size(61, 22)
        Me.Marca2_visible.TabIndex = 82
        Me.Marca2_visible.Text = "Mostrar"
        Me.Marca2_visible.UseVisualStyleBackColor = True
        '
        'Marca2
        '
        Me.Marca2.DecimalPlaces = 3
        Me.Marca2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Marca2.Location = New System.Drawing.Point(0, 0)
        Me.Marca2.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.Marca2.Name = "Marca2"
        Me.Marca2.Size = New System.Drawing.Size(110, 20)
        Me.Marca2.TabIndex = 15
        Me.Marca2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Marca2.Value = New Decimal(New Integer() {2, 0, 0, 65536})
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label44.Location = New System.Drawing.Point(110, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(24, 13)
        Me.Label44.TabIndex = 12
        Me.Label44.Text = "g/L"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Marca2_Color
        '
        Me.Marca2_Color.Dock = System.Windows.Forms.DockStyle.Right
        Me.Marca2_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Marca2_Color.FormattingEnabled = True
        Me.Marca2_Color.Location = New System.Drawing.Point(134, 0)
        Me.Marca2_Color.Name = "Marca2_Color"
        Me.Marca2_Color.Size = New System.Drawing.Size(97, 21)
        Me.Marca2_Color.TabIndex = 57
        '
        'Marca2_tamaño
        '
        Me.Marca2_tamaño.Dock = System.Windows.Forms.DockStyle.Right
        Me.Marca2_tamaño.Location = New System.Drawing.Point(231, 0)
        Me.Marca2_tamaño.Name = "Marca2_tamaño"
        Me.Marca2_tamaño.Size = New System.Drawing.Size(40, 20)
        Me.Marca2_tamaño.TabIndex = 58
        Me.Marca2_tamaño.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Marca2_label
        '
        Me.Marca2_label.BackColor = System.Drawing.Color.Blue
        Me.Marca2_label.Dock = System.Windows.Forms.DockStyle.Top
        Me.Marca2_label.ForeColor = System.Drawing.Color.White
        Me.Marca2_label.Location = New System.Drawing.Point(3, 51)
        Me.Marca2_label.Name = "Marca2_label"
        Me.Marca2_label.Size = New System.Drawing.Size(271, 13)
        Me.Marca2_label.TabIndex = 74
        Me.Marca2_label.Text = "Concentración tóxica"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Blue
        Me.Panel16.Controls.Add(Me.Marca1)
        Me.Panel16.Controls.Add(Me.Label42)
        Me.Panel16.Controls.Add(Me.Marca1_color)
        Me.Panel16.Controls.Add(Me.Marca1_tamaño)
        Me.Panel16.Controls.Add(Me.Marca1_visible)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.ForeColor = System.Drawing.Color.White
        Me.Panel16.Location = New System.Drawing.Point(3, 29)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(271, 22)
        Me.Panel16.TabIndex = 73
        '
        'Marca1
        '
        Me.Marca1.DecimalPlaces = 3
        Me.Marca1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Marca1.Location = New System.Drawing.Point(61, 0)
        Me.Marca1.Maximum = New Decimal(New Integer() {-1, -1, -1, 0})
        Me.Marca1.Name = "Marca1"
        Me.Marca1.Size = New System.Drawing.Size(49, 20)
        Me.Marca1.TabIndex = 15
        Me.Marca1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Marca1.Value = New Decimal(New Integer() {8, 0, 0, 65536})
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label42.Location = New System.Drawing.Point(110, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(24, 13)
        Me.Label42.TabIndex = 12
        Me.Label42.Text = "g/L"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Marca1_color
        '
        Me.Marca1_color.Dock = System.Windows.Forms.DockStyle.Right
        Me.Marca1_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Marca1_color.FormattingEnabled = True
        Me.Marca1_color.Location = New System.Drawing.Point(134, 0)
        Me.Marca1_color.Name = "Marca1_color"
        Me.Marca1_color.Size = New System.Drawing.Size(97, 21)
        Me.Marca1_color.TabIndex = 55
        '
        'Marca1_tamaño
        '
        Me.Marca1_tamaño.Dock = System.Windows.Forms.DockStyle.Right
        Me.Marca1_tamaño.Location = New System.Drawing.Point(231, 0)
        Me.Marca1_tamaño.Name = "Marca1_tamaño"
        Me.Marca1_tamaño.Size = New System.Drawing.Size(40, 20)
        Me.Marca1_tamaño.TabIndex = 56
        Me.Marca1_tamaño.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Marca1_visible
        '
        Me.Marca1_visible.AutoSize = True
        Me.Marca1_visible.Checked = True
        Me.Marca1_visible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Marca1_visible.Dock = System.Windows.Forms.DockStyle.Left
        Me.Marca1_visible.Location = New System.Drawing.Point(0, 0)
        Me.Marca1_visible.Name = "Marca1_visible"
        Me.Marca1_visible.Size = New System.Drawing.Size(61, 22)
        Me.Marca1_visible.TabIndex = 81
        Me.Marca1_visible.Text = "Mostrar"
        Me.Marca1_visible.UseVisualStyleBackColor = True
        '
        'Marca1_label
        '
        Me.Marca1_label.BackColor = System.Drawing.Color.Blue
        Me.Marca1_label.Dock = System.Windows.Forms.DockStyle.Top
        Me.Marca1_label.ForeColor = System.Drawing.Color.White
        Me.Marca1_label.Location = New System.Drawing.Point(3, 16)
        Me.Marca1_label.Name = "Marca1_label"
        Me.Marca1_label.Size = New System.Drawing.Size(271, 13)
        Me.Marca1_label.TabIndex = 72
        Me.Marca1_label.Text = "Concentración efectiva"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label64)
        Me.GroupBox1.Controls.Add(Me.Panel31)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Panel11)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Panel12)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.Panel15)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Panel26)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Panel14)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(277, 248)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Colores"
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.PaleGreen
        Me.Label64.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label64.Location = New System.Drawing.Point(3, 17)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(271, 13)
        Me.Label64.TabIndex = 83
        Me.Label64.Text = "Color de fondo"
        '
        'Panel31
        '
        Me.Panel31.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel31.Controls.Add(Me.Fondo)
        Me.Panel31.Controls.Add(Me.Label73)
        Me.Panel31.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel31.Location = New System.Drawing.Point(3, 30)
        Me.Panel31.Name = "Panel31"
        Me.Panel31.Size = New System.Drawing.Size(271, 25)
        Me.Panel31.TabIndex = 82
        '
        'Fondo
        '
        Me.Fondo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Fondo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Fondo.FormattingEnabled = True
        Me.Fondo.Location = New System.Drawing.Point(38, 0)
        Me.Fondo.Name = "Fondo"
        Me.Fondo.Size = New System.Drawing.Size(230, 21)
        Me.Fondo.TabIndex = 48
        '
        'Label73
        '
        Me.Label73.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label73.Location = New System.Drawing.Point(0, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(38, 25)
        Me.Label73.TabIndex = 47
        Me.Label73.Text = "Color"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.PaleGreen
        Me.Label29.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label29.Location = New System.Drawing.Point(3, 55)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(271, 13)
        Me.Label29.TabIndex = 81
        Me.Label29.Text = "Linea principal"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel11.Controls.Add(Me.LineType)
        Me.Panel11.Controls.Add(Me.Label30)
        Me.Panel11.Controls.Add(Me.LineColor)
        Me.Panel11.Controls.Add(Me.Label28)
        Me.Panel11.Controls.Add(Me.LineSize)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel11.Location = New System.Drawing.Point(3, 68)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(271, 25)
        Me.Panel11.TabIndex = 80
        '
        'LineType
        '
        Me.LineType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LineType.FormattingEnabled = True
        Me.LineType.Location = New System.Drawing.Point(182, 0)
        Me.LineType.Name = "LineType"
        Me.LineType.Size = New System.Drawing.Size(55, 21)
        Me.LineType.TabIndex = 50
        '
        'Label30
        '
        Me.Label30.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label30.Location = New System.Drawing.Point(151, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(31, 25)
        Me.Label30.TabIndex = 49
        Me.Label30.Text = "Tipo"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LineColor
        '
        Me.LineColor.Dock = System.Windows.Forms.DockStyle.Left
        Me.LineColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LineColor.FormattingEnabled = True
        Me.LineColor.Location = New System.Drawing.Point(38, 0)
        Me.LineColor.Name = "LineColor"
        Me.LineColor.Size = New System.Drawing.Size(113, 21)
        Me.LineColor.TabIndex = 48
        '
        'Label28
        '
        Me.Label28.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label28.Location = New System.Drawing.Point(0, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(38, 25)
        Me.Label28.TabIndex = 47
        Me.Label28.Text = "Color"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LineSize
        '
        Me.LineSize.Dock = System.Windows.Forms.DockStyle.Right
        Me.LineSize.Location = New System.Drawing.Point(237, 0)
        Me.LineSize.Name = "LineSize"
        Me.LineSize.Size = New System.Drawing.Size(34, 20)
        Me.LineSize.TabIndex = 46
        Me.LineSize.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.PaleGreen
        Me.Label26.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label26.Enabled = False
        Me.Label26.Location = New System.Drawing.Point(3, 93)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(271, 13)
        Me.Label26.TabIndex = 79
        Me.Label26.Text = "Mediciones"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel12.Controls.Add(Me.DotType)
        Me.Panel12.Controls.Add(Me.Label31)
        Me.Panel12.Controls.Add(Me.DotColor)
        Me.Panel12.Controls.Add(Me.Label32)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Enabled = False
        Me.Panel12.Location = New System.Drawing.Point(3, 106)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(271, 25)
        Me.Panel12.TabIndex = 78
        '
        'DotType
        '
        Me.DotType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DotType.FormattingEnabled = True
        Me.DotType.Location = New System.Drawing.Point(182, 0)
        Me.DotType.Name = "DotType"
        Me.DotType.Size = New System.Drawing.Size(89, 21)
        Me.DotType.TabIndex = 51
        '
        'Label31
        '
        Me.Label31.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label31.Location = New System.Drawing.Point(151, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(31, 25)
        Me.Label31.TabIndex = 50
        Me.Label31.Text = "Tipo"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DotColor
        '
        Me.DotColor.Dock = System.Windows.Forms.DockStyle.Left
        Me.DotColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DotColor.FormattingEnabled = True
        Me.DotColor.Location = New System.Drawing.Point(38, 0)
        Me.DotColor.Name = "DotColor"
        Me.DotColor.Size = New System.Drawing.Size(113, 21)
        Me.DotColor.TabIndex = 49
        '
        'Label32
        '
        Me.Label32.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label32.Location = New System.Drawing.Point(0, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(38, 25)
        Me.Label32.TabIndex = 48
        Me.Label32.Text = "Color"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.PaleGreen
        Me.Label37.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label37.Location = New System.Drawing.Point(3, 131)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(271, 13)
        Me.Label37.TabIndex = 77
        Me.Label37.Text = "Valores sin absorción"
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel15.Controls.Add(Me.DiffType)
        Me.Panel15.Controls.Add(Me.Label39)
        Me.Panel15.Controls.Add(Me.DifColor)
        Me.Panel15.Controls.Add(Me.UsarDiferencial)
        Me.Panel15.Controls.Add(Me.DiffSize)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel15.Location = New System.Drawing.Point(3, 144)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(271, 25)
        Me.Panel15.TabIndex = 76
        '
        'DiffType
        '
        Me.DiffType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DiffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DiffType.FormattingEnabled = True
        Me.DiffType.Location = New System.Drawing.Point(182, 0)
        Me.DiffType.Name = "DiffType"
        Me.DiffType.Size = New System.Drawing.Size(55, 21)
        Me.DiffType.TabIndex = 55
        '
        'Label39
        '
        Me.Label39.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label39.Location = New System.Drawing.Point(151, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(31, 25)
        Me.Label39.TabIndex = 54
        Me.Label39.Text = "Tipo"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DifColor
        '
        Me.DifColor.Dock = System.Windows.Forms.DockStyle.Left
        Me.DifColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DifColor.FormattingEnabled = True
        Me.DifColor.Location = New System.Drawing.Point(48, 0)
        Me.DifColor.Name = "DifColor"
        Me.DifColor.Size = New System.Drawing.Size(103, 21)
        Me.DifColor.TabIndex = 53
        '
        'UsarDiferencial
        '
        Me.UsarDiferencial.AutoSize = True
        Me.UsarDiferencial.Checked = True
        Me.UsarDiferencial.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UsarDiferencial.Dock = System.Windows.Forms.DockStyle.Left
        Me.UsarDiferencial.Location = New System.Drawing.Point(0, 0)
        Me.UsarDiferencial.Name = "UsarDiferencial"
        Me.UsarDiferencial.Size = New System.Drawing.Size(48, 25)
        Me.UsarDiferencial.TabIndex = 51
        Me.UsarDiferencial.Text = "Usar"
        Me.UsarDiferencial.UseVisualStyleBackColor = True
        '
        'DiffSize
        '
        Me.DiffSize.Dock = System.Windows.Forms.DockStyle.Right
        Me.DiffSize.Location = New System.Drawing.Point(237, 0)
        Me.DiffSize.Name = "DiffSize"
        Me.DiffSize.Size = New System.Drawing.Size(34, 20)
        Me.DiffSize.TabIndex = 46
        Me.DiffSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.PaleGreen
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label22.Location = New System.Drawing.Point(3, 169)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(271, 13)
        Me.Label22.TabIndex = 85
        Me.Label22.Text = "Miscelaneo"
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel26.Controls.Add(Me.SoloEliminación)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel26.Location = New System.Drawing.Point(3, 182)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(271, 25)
        Me.Panel26.TabIndex = 84
        '
        'SoloEliminación
        '
        Me.SoloEliminación.AutoSize = True
        Me.SoloEliminación.Dock = System.Windows.Forms.DockStyle.Left
        Me.SoloEliminación.Location = New System.Drawing.Point(0, 0)
        Me.SoloEliminación.Name = "SoloEliminación"
        Me.SoloEliminación.Size = New System.Drawing.Size(138, 25)
        Me.SoloEliminación.TabIndex = 51
        Me.SoloEliminación.Text = "Únicamente eliminación"
        Me.SoloEliminación.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.IndianRed
        Me.Label36.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(3, 207)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(271, 13)
        Me.Label36.TabIndex = 75
        Me.Label36.Text = "Herramientas"
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.IndianRed
        Me.Panel14.Controls.Add(Me.MaxColor)
        Me.Panel14.Controls.Add(Me.Log)
        Me.Panel14.Controls.Add(Me.Label38)
        Me.Panel14.Controls.Add(Me.Acotaciones1)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel14.Location = New System.Drawing.Point(3, 220)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(271, 25)
        Me.Panel14.TabIndex = 74
        '
        'MaxColor
        '
        Me.MaxColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MaxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MaxColor.FormattingEnabled = True
        Me.MaxColor.Location = New System.Drawing.Point(123, 0)
        Me.MaxColor.Name = "MaxColor"
        Me.MaxColor.Size = New System.Drawing.Size(97, 21)
        Me.MaxColor.TabIndex = 53
        '
        'Log
        '
        Me.Log.AutoSize = True
        Me.Log.Dock = System.Windows.Forms.DockStyle.Right
        Me.Log.ForeColor = System.Drawing.Color.White
        Me.Log.Location = New System.Drawing.Point(220, 0)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(51, 25)
        Me.Log.TabIndex = 52
        Me.Log.Text = "YLog"
        Me.Log.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(85, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(38, 25)
        Me.Label38.TabIndex = 50
        Me.Label38.Text = "Color"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Acotaciones1
        '
        Me.Acotaciones1.AutoSize = True
        Me.Acotaciones1.Checked = True
        Me.Acotaciones1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Acotaciones1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Acotaciones1.ForeColor = System.Drawing.Color.White
        Me.Acotaciones1.Location = New System.Drawing.Point(0, 0)
        Me.Acotaciones1.Name = "Acotaciones1"
        Me.Acotaciones1.Size = New System.Drawing.Size(85, 25)
        Me.Acotaciones1.TabIndex = 49
        Me.Acotaciones1.Text = "Acotaciones"
        Me.Acotaciones1.UseVisualStyleBackColor = True
        '
        'Panel22
        '
        Me.Panel22.Controls.Add(Me.Panel25)
        Me.Panel22.Controls.Add(Me.Panel7)
        Me.Panel22.Controls.Add(Me.Label1)
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel22.Location = New System.Drawing.Point(0, 680)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(291, 56)
        Me.Panel22.TabIndex = 39
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.DarkGreen
        Me.Panel25.Controls.Add(Me.TextBox_y)
        Me.Panel25.Controls.Add(Me.Label10)
        Me.Panel25.Controls.Add(Me.TextBox_x)
        Me.Panel25.Controls.Add(Me.Label11)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel25.ForeColor = System.Drawing.Color.White
        Me.Panel25.Location = New System.Drawing.Point(0, 14)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(291, 21)
        Me.Panel25.TabIndex = 70
        '
        'TextBox_y
        '
        Me.TextBox_y.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_y.Location = New System.Drawing.Point(201, 0)
        Me.TextBox_y.Name = "TextBox_y"
        Me.TextBox_y.ReadOnly = True
        Me.TextBox_y.Size = New System.Drawing.Size(90, 20)
        Me.TextBox_y.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Location = New System.Drawing.Point(145, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 21)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = " Conc. F"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox_x
        '
        Me.TextBox_x.Dock = System.Windows.Forms.DockStyle.Left
        Me.TextBox_x.Location = New System.Drawing.Point(77, 0)
        Me.TextBox_x.Name = "TextBox_x"
        Me.TextBox_x.ReadOnly = True
        Me.TextBox_x.Size = New System.Drawing.Size(68, 20)
        Me.TextBox_x.TabIndex = 1
        Me.TextBox_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 21)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "tiempo (h):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGreen
        Me.Panel7.Controls.Add(Me.TextBox_CAe)
        Me.Panel7.Controls.Add(Me.Label53)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.ForeColor = System.Drawing.Color.White
        Me.Panel7.Location = New System.Drawing.Point(0, 35)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(291, 21)
        Me.Panel7.TabIndex = 69
        '
        'TextBox_CAe
        '
        Me.TextBox_CAe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox_CAe.Location = New System.Drawing.Point(171, 0)
        Me.TextBox_CAe.Name = "TextBox_CAe"
        Me.TextBox_CAe.ReadOnly = True
        Me.TextBox_CAe.Size = New System.Drawing.Size(120, 20)
        Me.TextBox_CAe.TabIndex = 3
        '
        'Label53
        '
        Me.Label53.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label53.Location = New System.Drawing.Point(0, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(171, 21)
        Me.Label53.TabIndex = 0
        Me.Label53.Text = "Concentración en Aire Espirado"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkGreen
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(291, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Datos del puntero"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 736)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 300)
        Me.Name = "MainForm"
        Me.Text = "Farma-lab"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MainTabControl.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ControlDemostración16.ResumeLayout(False)
        Me.ControlDemostración16.PerformLayout()
        Me.ControlDemostración15.ResumeLayout(False)
        Me.ControlDemostración15.PerformLayout()
        Me.ControlDemostración14.ResumeLayout(False)
        Me.ControlDemostración14.PerformLayout()
        CType(Me.VelocidadMaximaEliminación, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración13.ResumeLayout(False)
        Me.ControlDemostración13.PerformLayout()
        Me.ControlDemostración12.ResumeLayout(False)
        Me.ControlDemostración12.PerformLayout()
        CType(Me.Eliminación, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración11.ResumeLayout(False)
        Me.ControlDemostración11.PerformLayout()
        CType(Me.Absorción, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración3.ResumeLayout(False)
        Me.ControlDemostración3.PerformLayout()
        CType(Me.BD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración2.ResumeLayout(False)
        Me.ControlDemostración2.PerformLayout()
        CType(Me.VD_Num, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ControlDemostración9.ResumeLayout(False)
        Me.ControlDemostración9.PerformLayout()
        CType(Me.ChargeDose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración10.ResumeLayout(False)
        Me.ControlDemostración10.PerformLayout()
        CType(Me.DosisTotalesNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración8.ResumeLayout(False)
        Me.ControlDemostración8.PerformLayout()
        CType(Me.IntérvaloDosificaciónMinutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración7.ResumeLayout(False)
        Me.ControlDemostración7.PerformLayout()
        CType(Me.IntérvaloDosificaciónHoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración1.ResumeLayout(False)
        Me.ControlDemostración1.PerformLayout()
        CType(Me.Dosis1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ControlDemostración6.ResumeLayout(False)
        Me.ControlDemostración6.PerformLayout()
        Me.ControlDemostración5.ResumeLayout(False)
        Me.ControlDemostración5.PerformLayout()
        CType(Me.Velocidad_de_trazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlDemostración4.ResumeLayout(False)
        Me.ControlDemostración4.PerformLayout()
        CType(Me.Horas_Estudio_Num, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupMarcas.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel20.PerformLayout()
        CType(Me.Marca3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Marca3_tamaño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        CType(Me.Marca2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Marca2_tamaño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        CType(Me.Marca1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Marca1_tamaño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel31.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.LineSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        CType(Me.DiffSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel26.ResumeLayout(False)
        Me.Panel26.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.Panel22.ResumeLayout(False)
        Me.Panel25.ResumeLayout(False)
        Me.Panel25.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents LineType As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents LineColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents LineSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents DotType As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DotColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents DiffType As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents DifColor As System.Windows.Forms.ComboBox
    Friend WithEvents UsarDiferencial As System.Windows.Forms.CheckBox
    Friend WithEvents DiffSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents MaxColor As System.Windows.Forms.ComboBox
    Friend WithEvents Log As System.Windows.Forms.CheckBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Acotaciones1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Panel31 As System.Windows.Forms.Panel
    Friend WithEvents Fondo As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents TextBox_y As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox_x As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TextBox_CAe As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents SoloEliminación As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ControlDemostración1 As ControlActualizable.ControlDemostración
    Friend WithEvents Dosis1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ControlDemostración2 As ControlActualizable.ControlDemostración
    Friend WithEvents VD_Num As System.Windows.Forms.NumericUpDown
    Friend WithEvents ControlDemostración3 As ControlActualizable.ControlDemostración
    Friend WithEvents BD As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ControlDemostración9 As ControlActualizable.ControlDemostración
    Friend WithEvents ChargeDose As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChargeDoseActive As System.Windows.Forms.CheckBox
    Friend WithEvents ControlDemostración8 As ControlActualizable.ControlDemostración
    Friend WithEvents IntérvaloDosificaciónMinutos As System.Windows.Forms.NumericUpDown
    Friend WithEvents ControlDemostración7 As ControlActualizable.ControlDemostración
    Friend WithEvents IntérvaloDosificaciónHoras As System.Windows.Forms.NumericUpDown
    Friend WithEvents MúltiplesDosis As System.Windows.Forms.CheckBox
    Friend WithEvents ControlDemostración10 As ControlActualizable.ControlDemostración
    Friend WithEvents DosisTotalesNum As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ControlDemostración6 As ControlActualizable.ControlDemostración
    Friend WithEvents Unidades As System.Windows.Forms.ComboBox
    Friend WithEvents ControlDemostración5 As ControlActualizable.ControlDemostración
    Friend WithEvents Velocidad_de_trazo As System.Windows.Forms.NumericUpDown
    Friend WithEvents ControlDemostración4 As ControlActualizable.ControlDemostración
    Friend WithEvents Horas_Estudio_Num As System.Windows.Forms.NumericUpDown
    Friend WithEvents ControlDemostración11 As ControlActualizable.ControlDemostración
    Friend WithEvents Absorción As System.Windows.Forms.NumericUpDown
    Friend WithEvents ControlDemostración12 As ControlActualizable.ControlDemostración
    Friend WithEvents Eliminación As System.Windows.Forms.NumericUpDown
    Friend WithEvents ControlDemostración13 As ControlActualizable.ControlDemostración
    Friend WithEvents TipoEliminación As System.Windows.Forms.ComboBox
    Friend WithEvents ControlDemostración14 As ControlActualizable.ControlDemostración
    Friend WithEvents VelocidadMaximaEliminación As System.Windows.Forms.NumericUpDown
    Friend WithEvents ControlDemostración16 As ControlActualizable.ControlDemostración
    Friend WithEvents VME As System.Windows.Forms.TextBox
    Friend WithEvents ControlDemostración15 As ControlActualizable.ControlDemostración
    Friend WithEvents VMA As System.Windows.Forms.TextBox
    Friend WithEvents GroupMarcas As System.Windows.Forms.GroupBox
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Marca3_visible As System.Windows.Forms.CheckBox
    Friend WithEvents Marca3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Marca3_color As System.Windows.Forms.ComboBox
    Friend WithEvents Marca3_tamaño As System.Windows.Forms.NumericUpDown
    Friend WithEvents Marca3_label As System.Windows.Forms.Label
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Marca2_visible As System.Windows.Forms.CheckBox
    Friend WithEvents Marca2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Marca2_Color As System.Windows.Forms.ComboBox
    Friend WithEvents Marca2_tamaño As System.Windows.Forms.NumericUpDown
    Friend WithEvents Marca2_label As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Marca1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Marca1_color As System.Windows.Forms.ComboBox
    Friend WithEvents Marca1_tamaño As System.Windows.Forms.NumericUpDown
    Friend WithEvents Marca1_visible As System.Windows.Forms.CheckBox
    Friend WithEvents Marca1_label As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Instant As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Iniciar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Detener As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Clear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Save As System.Windows.Forms.ToolStripButton

End Class
