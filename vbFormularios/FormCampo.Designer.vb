<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCampo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCampo))
        Me.EtiquetaNombre = New System.Windows.Forms.Label()
        Me.CajaNombre = New System.Windows.Forms.TextBox()
        Me.Solapas = New System.Windows.Forms.TabControl()
        Me.SolapaCodigo = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CajaCodigoFormato = New System.Windows.Forms.TextBox()
        Me.EtiquetaCodigoLongitud = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CajaCodigoCaracteres = New System.Windows.Forms.TextBox()
        Me.CajaCodigoLongitud = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SolapaLista = New System.Windows.Forms.TabPage()
        Me.CajaLista = New System.Windows.Forms.TextBox()
        Me.SolapaRango = New System.Windows.Forms.TabPage()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CajaRangoDistribucion = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CajaRangoNumeral = New System.Windows.Forms.ListBox()
        Me.EtiquetaMaximo = New System.Windows.Forms.Label()
        Me.CajaRangoMaximo = New System.Windows.Forms.NumericUpDown()
        Me.EtiquetaMinimo = New System.Windows.Forms.Label()
        Me.CajaRangoMinimo = New System.Windows.Forms.NumericUpDown()
        Me.SolapaMoneda = New System.Windows.Forms.TabPage()
        Me.CajaMonedaUnidad = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CajaMonedaMaxima = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CajaMonedaMinima = New System.Windows.Forms.NumericUpDown()
        Me.SolapaFecha = New System.Windows.Forms.TabPage()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CajaFechaSemana = New System.Windows.Forms.CheckedListBox()
        Me.CajaFechaMaxima = New System.Windows.Forms.MaskedTextBox()
        Me.CajaFechaMinima = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SolapaHora = New System.Windows.Forms.TabPage()
        Me.CajaHoraMaxima = New System.Windows.Forms.MaskedTextBox()
        Me.CajaHoraMinima = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SolapaLogico = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SolapaTexto = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CajaTextoMaximo = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CajaTextoMinimo = New System.Windows.Forms.NumericUpDown()
        Me.SolapaContador = New System.Windows.Forms.TabPage()
        Me.CajaContadorFemenina = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CajaContadorPalabra = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CajaContadorNumeral = New System.Windows.Forms.ListBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CajaContadorIncremento = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CajaContadorInicio = New System.Windows.Forms.NumericUpDown()
        Me.BotonAceptar = New System.Windows.Forms.Button()
        Me.BotonCancelar = New System.Windows.Forms.Button()
        Me.BotonPrueba = New System.Windows.Forms.Button()
        Me.CajaPrueba = New System.Windows.Forms.TextBox()
        Me.Solapas.SuspendLayout()
        Me.SolapaCodigo.SuspendLayout()
        CType(Me.CajaCodigoLongitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SolapaLista.SuspendLayout()
        Me.SolapaRango.SuspendLayout()
        CType(Me.CajaRangoMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CajaRangoMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SolapaMoneda.SuspendLayout()
        CType(Me.CajaMonedaMaxima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CajaMonedaMinima, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SolapaFecha.SuspendLayout()
        Me.SolapaHora.SuspendLayout()
        Me.SolapaLogico.SuspendLayout()
        Me.SolapaTexto.SuspendLayout()
        CType(Me.CajaTextoMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CajaTextoMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SolapaContador.SuspendLayout()
        CType(Me.CajaContadorIncremento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CajaContadorInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EtiquetaNombre
        '
        Me.EtiquetaNombre.AutoSize = True
        Me.EtiquetaNombre.Location = New System.Drawing.Point(9, 9)
        Me.EtiquetaNombre.Name = "EtiquetaNombre"
        Me.EtiquetaNombre.Size = New System.Drawing.Size(47, 13)
        Me.EtiquetaNombre.TabIndex = 0
        Me.EtiquetaNombre.Text = "Nombre:"
        '
        'CajaNombre
        '
        Me.CajaNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaNombre.Location = New System.Drawing.Point(65, 6)
        Me.CajaNombre.Name = "CajaNombre"
        Me.CajaNombre.Size = New System.Drawing.Size(365, 20)
        Me.CajaNombre.TabIndex = 1
        Me.CajaNombre.Text = "Sin nombre"
        '
        'Solapas
        '
        Me.Solapas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Solapas.Controls.Add(Me.SolapaCodigo)
        Me.Solapas.Controls.Add(Me.SolapaLista)
        Me.Solapas.Controls.Add(Me.SolapaRango)
        Me.Solapas.Controls.Add(Me.SolapaMoneda)
        Me.Solapas.Controls.Add(Me.SolapaFecha)
        Me.Solapas.Controls.Add(Me.SolapaHora)
        Me.Solapas.Controls.Add(Me.SolapaLogico)
        Me.Solapas.Controls.Add(Me.SolapaTexto)
        Me.Solapas.Controls.Add(Me.SolapaContador)
        Me.Solapas.Location = New System.Drawing.Point(12, 32)
        Me.Solapas.Multiline = True
        Me.Solapas.Name = "Solapas"
        Me.Solapas.SelectedIndex = 0
        Me.Solapas.Size = New System.Drawing.Size(418, 302)
        Me.Solapas.TabIndex = 2
        '
        'SolapaCodigo
        '
        Me.SolapaCodigo.Controls.Add(Me.Label17)
        Me.SolapaCodigo.Controls.Add(Me.CajaCodigoFormato)
        Me.SolapaCodigo.Controls.Add(Me.EtiquetaCodigoLongitud)
        Me.SolapaCodigo.Controls.Add(Me.Label9)
        Me.SolapaCodigo.Controls.Add(Me.CajaCodigoCaracteres)
        Me.SolapaCodigo.Controls.Add(Me.CajaCodigoLongitud)
        Me.SolapaCodigo.Controls.Add(Me.Label2)
        Me.SolapaCodigo.Location = New System.Drawing.Point(4, 22)
        Me.SolapaCodigo.Name = "SolapaCodigo"
        Me.SolapaCodigo.Size = New System.Drawing.Size(410, 276)
        Me.SolapaCodigo.TabIndex = 6
        Me.SolapaCodigo.Text = "Código"
        Me.SolapaCodigo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Formato:"
        '
        'CajaCodigoFormato
        '
        Me.CajaCodigoFormato.BackColor = System.Drawing.SystemColors.Control
        Me.CajaCodigoFormato.Enabled = False
        Me.CajaCodigoFormato.Location = New System.Drawing.Point(82, 86)
        Me.CajaCodigoFormato.Name = "CajaCodigoFormato"
        Me.CajaCodigoFormato.Size = New System.Drawing.Size(151, 20)
        Me.CajaCodigoFormato.TabIndex = 9
        '
        'EtiquetaCodigoLongitud
        '
        Me.EtiquetaCodigoLongitud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EtiquetaCodigoLongitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EtiquetaCodigoLongitud.Location = New System.Drawing.Point(349, 44)
        Me.EtiquetaCodigoLongitud.Name = "EtiquetaCodigoLongitud"
        Me.EtiquetaCodigoLongitud.Size = New System.Drawing.Size(45, 23)
        Me.EtiquetaCodigoLongitud.TabIndex = 8
        Me.EtiquetaCodigoLongitud.Text = "0"
        Me.EtiquetaCodigoLongitud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Longitud:"
        '
        'CajaCodigoCaracteres
        '
        Me.CajaCodigoCaracteres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaCodigoCaracteres.Location = New System.Drawing.Point(82, 12)
        Me.CajaCodigoCaracteres.Name = "CajaCodigoCaracteres"
        Me.CajaCodigoCaracteres.Size = New System.Drawing.Size(312, 20)
        Me.CajaCodigoCaracteres.TabIndex = 6
        '
        'CajaCodigoLongitud
        '
        Me.CajaCodigoLongitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaCodigoLongitud.Location = New System.Drawing.Point(79, 38)
        Me.CajaCodigoLongitud.Maximum = 50
        Me.CajaCodigoLongitud.Minimum = 1
        Me.CajaCodigoLongitud.Name = "CajaCodigoLongitud"
        Me.CajaCodigoLongitud.Size = New System.Drawing.Size(264, 42)
        Me.CajaCodigoLongitud.TabIndex = 5
        Me.CajaCodigoLongitud.TickFrequency = 5
        Me.CajaCodigoLongitud.Value = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Caracteres:"
        '
        'SolapaLista
        '
        Me.SolapaLista.Controls.Add(Me.CajaLista)
        Me.SolapaLista.Location = New System.Drawing.Point(4, 22)
        Me.SolapaLista.Name = "SolapaLista"
        Me.SolapaLista.Padding = New System.Windows.Forms.Padding(8)
        Me.SolapaLista.Size = New System.Drawing.Size(410, 276)
        Me.SolapaLista.TabIndex = 1
        Me.SolapaLista.Text = "Lista"
        Me.SolapaLista.UseVisualStyleBackColor = True
        '
        'CajaLista
        '
        Me.CajaLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CajaLista.Location = New System.Drawing.Point(8, 8)
        Me.CajaLista.Multiline = True
        Me.CajaLista.Name = "CajaLista"
        Me.CajaLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CajaLista.Size = New System.Drawing.Size(394, 260)
        Me.CajaLista.TabIndex = 0
        '
        'SolapaRango
        '
        Me.SolapaRango.Controls.Add(Me.Label20)
        Me.SolapaRango.Controls.Add(Me.CajaRangoDistribucion)
        Me.SolapaRango.Controls.Add(Me.Label18)
        Me.SolapaRango.Controls.Add(Me.CajaRangoNumeral)
        Me.SolapaRango.Controls.Add(Me.EtiquetaMaximo)
        Me.SolapaRango.Controls.Add(Me.CajaRangoMaximo)
        Me.SolapaRango.Controls.Add(Me.EtiquetaMinimo)
        Me.SolapaRango.Controls.Add(Me.CajaRangoMinimo)
        Me.SolapaRango.Location = New System.Drawing.Point(4, 22)
        Me.SolapaRango.Name = "SolapaRango"
        Me.SolapaRango.Padding = New System.Windows.Forms.Padding(8)
        Me.SolapaRango.Size = New System.Drawing.Size(410, 276)
        Me.SolapaRango.TabIndex = 0
        Me.SolapaRango.Text = "Rango"
        Me.SolapaRango.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 80)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 13)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Distribución:"
        '
        'CajaRangoDistribucion
        '
        Me.CajaRangoDistribucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CajaRangoDistribucion.Enabled = False
        Me.CajaRangoDistribucion.FormattingEnabled = True
        Me.CajaRangoDistribucion.Items.AddRange(New Object() {"Lineal", "Campana de Gauss", "Campana invertida", "Cuadrático", "Raiz cuadrática"})
        Me.CajaRangoDistribucion.Location = New System.Drawing.Point(100, 80)
        Me.CajaRangoDistribucion.Name = "CajaRangoDistribucion"
        Me.CajaRangoDistribucion.Size = New System.Drawing.Size(130, 21)
        Me.CajaRangoDistribucion.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(250, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Numeral:"
        '
        'CajaRangoNumeral
        '
        Me.CajaRangoNumeral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CajaRangoNumeral.FormattingEnabled = True
        Me.CajaRangoNumeral.Location = New System.Drawing.Point(250, 27)
        Me.CajaRangoNumeral.Name = "CajaRangoNumeral"
        Me.CajaRangoNumeral.Size = New System.Drawing.Size(150, 225)
        Me.CajaRangoNumeral.TabIndex = 13
        '
        'EtiquetaMaximo
        '
        Me.EtiquetaMaximo.AutoSize = True
        Me.EtiquetaMaximo.Location = New System.Drawing.Point(12, 40)
        Me.EtiquetaMaximo.Name = "EtiquetaMaximo"
        Me.EtiquetaMaximo.Size = New System.Drawing.Size(46, 13)
        Me.EtiquetaMaximo.TabIndex = 4
        Me.EtiquetaMaximo.Text = "Máximo:"
        '
        'CajaRangoMaximo
        '
        Me.CajaRangoMaximo.Location = New System.Drawing.Point(100, 38)
        Me.CajaRangoMaximo.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.CajaRangoMaximo.Minimum = New Decimal(New Integer() {-727379968, 232, 0, -2147483648})
        Me.CajaRangoMaximo.Name = "CajaRangoMaximo"
        Me.CajaRangoMaximo.Size = New System.Drawing.Size(130, 20)
        Me.CajaRangoMaximo.TabIndex = 3
        '
        'EtiquetaMinimo
        '
        Me.EtiquetaMinimo.AutoSize = True
        Me.EtiquetaMinimo.Location = New System.Drawing.Point(12, 15)
        Me.EtiquetaMinimo.Name = "EtiquetaMinimo"
        Me.EtiquetaMinimo.Size = New System.Drawing.Size(45, 13)
        Me.EtiquetaMinimo.TabIndex = 2
        Me.EtiquetaMinimo.Text = "Mínimo:"
        '
        'CajaRangoMinimo
        '
        Me.CajaRangoMinimo.Location = New System.Drawing.Point(100, 12)
        Me.CajaRangoMinimo.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.CajaRangoMinimo.Minimum = New Decimal(New Integer() {-727379968, 232, 0, -2147483648})
        Me.CajaRangoMinimo.Name = "CajaRangoMinimo"
        Me.CajaRangoMinimo.Size = New System.Drawing.Size(130, 20)
        Me.CajaRangoMinimo.TabIndex = 1
        '
        'SolapaMoneda
        '
        Me.SolapaMoneda.Controls.Add(Me.CajaMonedaUnidad)
        Me.SolapaMoneda.Controls.Add(Me.Label10)
        Me.SolapaMoneda.Controls.Add(Me.Label3)
        Me.SolapaMoneda.Controls.Add(Me.CajaMonedaMaxima)
        Me.SolapaMoneda.Controls.Add(Me.Label4)
        Me.SolapaMoneda.Controls.Add(Me.CajaMonedaMinima)
        Me.SolapaMoneda.Location = New System.Drawing.Point(4, 22)
        Me.SolapaMoneda.Name = "SolapaMoneda"
        Me.SolapaMoneda.Size = New System.Drawing.Size(410, 276)
        Me.SolapaMoneda.TabIndex = 2
        Me.SolapaMoneda.Text = "Moneda"
        Me.SolapaMoneda.UseVisualStyleBackColor = True
        '
        'CajaMonedaUnidad
        '
        Me.CajaMonedaUnidad.ColumnWidth = 50
        Me.CajaMonedaUnidad.FormattingEnabled = True
        Me.CajaMonedaUnidad.Items.AddRange(New Object() {"0,01", "0,02", "0,05", "0,10", "0,20", "0,50", "1,00", "2,00", "5,00", "10,00", "20,00", "50,00", "100,00", "200,00", "500,00", "1000,00", "2000,00", "5000,00"})
        Me.CajaMonedaUnidad.Location = New System.Drawing.Point(253, 28)
        Me.CajaMonedaUnidad.MultiColumn = True
        Me.CajaMonedaUnidad.Name = "CajaMonedaUnidad"
        Me.CajaMonedaUnidad.Size = New System.Drawing.Size(125, 121)
        Me.CajaMonedaUnidad.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(250, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Unidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Moneda hasta:"
        '
        'CajaMonedaMaxima
        '
        Me.CajaMonedaMaxima.Location = New System.Drawing.Point(100, 38)
        Me.CajaMonedaMaxima.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.CajaMonedaMaxima.Minimum = New Decimal(New Integer() {-727379968, 232, 0, -2147483648})
        Me.CajaMonedaMaxima.Name = "CajaMonedaMaxima"
        Me.CajaMonedaMaxima.Size = New System.Drawing.Size(130, 20)
        Me.CajaMonedaMaxima.TabIndex = 7
        Me.CajaMonedaMaxima.Value = New Decimal(New Integer() {10000, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Moneda desde:"
        '
        'CajaMonedaMinima
        '
        Me.CajaMonedaMinima.Location = New System.Drawing.Point(100, 12)
        Me.CajaMonedaMinima.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.CajaMonedaMinima.Minimum = New Decimal(New Integer() {-727379968, 232, 0, -2147483648})
        Me.CajaMonedaMinima.Name = "CajaMonedaMinima"
        Me.CajaMonedaMinima.Size = New System.Drawing.Size(130, 20)
        Me.CajaMonedaMinima.TabIndex = 5
        '
        'SolapaFecha
        '
        Me.SolapaFecha.Controls.Add(Me.Label19)
        Me.SolapaFecha.Controls.Add(Me.CajaFechaSemana)
        Me.SolapaFecha.Controls.Add(Me.CajaFechaMaxima)
        Me.SolapaFecha.Controls.Add(Me.CajaFechaMinima)
        Me.SolapaFecha.Controls.Add(Me.Label5)
        Me.SolapaFecha.Controls.Add(Me.Label6)
        Me.SolapaFecha.Location = New System.Drawing.Point(4, 22)
        Me.SolapaFecha.Name = "SolapaFecha"
        Me.SolapaFecha.Size = New System.Drawing.Size(410, 276)
        Me.SolapaFecha.TabIndex = 3
        Me.SolapaFecha.Text = "Fecha"
        Me.SolapaFecha.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(220, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Días de la semana:"
        '
        'CajaFechaSemana
        '
        Me.CajaFechaSemana.CheckOnClick = True
        Me.CajaFechaSemana.FormattingEnabled = True
        Me.CajaFechaSemana.Items.AddRange(New Object() {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"})
        Me.CajaFechaSemana.Location = New System.Drawing.Point(223, 31)
        Me.CajaFechaSemana.Name = "CajaFechaSemana"
        Me.CajaFechaSemana.Size = New System.Drawing.Size(100, 124)
        Me.CajaFechaSemana.TabIndex = 11
        '
        'CajaFechaMaxima
        '
        Me.CajaFechaMaxima.Location = New System.Drawing.Point(100, 39)
        Me.CajaFechaMaxima.Mask = "00/00/0000"
        Me.CajaFechaMaxima.Name = "CajaFechaMaxima"
        Me.CajaFechaMaxima.Size = New System.Drawing.Size(100, 20)
        Me.CajaFechaMaxima.TabIndex = 10
        Me.CajaFechaMaxima.ValidatingType = GetType(Date)
        '
        'CajaFechaMinima
        '
        Me.CajaFechaMinima.Location = New System.Drawing.Point(100, 12)
        Me.CajaFechaMinima.Mask = "00/00/0000"
        Me.CajaFechaMinima.Name = "CajaFechaMinima"
        Me.CajaFechaMinima.Size = New System.Drawing.Size(100, 20)
        Me.CajaFechaMinima.TabIndex = 9
        Me.CajaFechaMinima.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha hasta:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Fecha desde:"
        '
        'SolapaHora
        '
        Me.SolapaHora.Controls.Add(Me.CajaHoraMaxima)
        Me.SolapaHora.Controls.Add(Me.CajaHoraMinima)
        Me.SolapaHora.Controls.Add(Me.Label7)
        Me.SolapaHora.Controls.Add(Me.Label8)
        Me.SolapaHora.Location = New System.Drawing.Point(4, 22)
        Me.SolapaHora.Name = "SolapaHora"
        Me.SolapaHora.Size = New System.Drawing.Size(410, 276)
        Me.SolapaHora.TabIndex = 4
        Me.SolapaHora.Text = "Hora"
        Me.SolapaHora.UseVisualStyleBackColor = True
        '
        'CajaHoraMaxima
        '
        Me.CajaHoraMaxima.Location = New System.Drawing.Point(100, 38)
        Me.CajaHoraMaxima.Mask = "00:00"
        Me.CajaHoraMaxima.Name = "CajaHoraMaxima"
        Me.CajaHoraMaxima.Size = New System.Drawing.Size(100, 20)
        Me.CajaHoraMaxima.TabIndex = 10
        Me.CajaHoraMaxima.ValidatingType = GetType(Date)
        '
        'CajaHoraMinima
        '
        Me.CajaHoraMinima.Location = New System.Drawing.Point(100, 12)
        Me.CajaHoraMinima.Mask = "00:00"
        Me.CajaHoraMinima.Name = "CajaHoraMinima"
        Me.CajaHoraMinima.Size = New System.Drawing.Size(100, 20)
        Me.CajaHoraMinima.TabIndex = 9
        Me.CajaHoraMinima.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Hora hasta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Hora desde:"
        '
        'SolapaLogico
        '
        Me.SolapaLogico.Controls.Add(Me.Label1)
        Me.SolapaLogico.Location = New System.Drawing.Point(4, 22)
        Me.SolapaLogico.Name = "SolapaLogico"
        Me.SolapaLogico.Size = New System.Drawing.Size(410, 276)
        Me.SolapaLogico.TabIndex = 5
        Me.SolapaLogico.Text = "Lógico"
        Me.SolapaLogico.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Valores TRUE o FALSE"
        '
        'SolapaTexto
        '
        Me.SolapaTexto.Controls.Add(Me.Label11)
        Me.SolapaTexto.Controls.Add(Me.CajaTextoMaximo)
        Me.SolapaTexto.Controls.Add(Me.Label12)
        Me.SolapaTexto.Controls.Add(Me.CajaTextoMinimo)
        Me.SolapaTexto.Location = New System.Drawing.Point(4, 22)
        Me.SolapaTexto.Name = "SolapaTexto"
        Me.SolapaTexto.Padding = New System.Windows.Forms.Padding(3)
        Me.SolapaTexto.Size = New System.Drawing.Size(410, 276)
        Me.SolapaTexto.TabIndex = 7
        Me.SolapaTexto.Text = "Texto"
        Me.SolapaTexto.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Hasta palabras:"
        '
        'CajaTextoMaximo
        '
        Me.CajaTextoMaximo.Location = New System.Drawing.Point(100, 38)
        Me.CajaTextoMaximo.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.CajaTextoMaximo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CajaTextoMaximo.Name = "CajaTextoMaximo"
        Me.CajaTextoMaximo.Size = New System.Drawing.Size(100, 20)
        Me.CajaTextoMaximo.TabIndex = 7
        Me.CajaTextoMaximo.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Desde palabras:"
        '
        'CajaTextoMinimo
        '
        Me.CajaTextoMinimo.Location = New System.Drawing.Point(100, 12)
        Me.CajaTextoMinimo.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.CajaTextoMinimo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CajaTextoMinimo.Name = "CajaTextoMinimo"
        Me.CajaTextoMinimo.Size = New System.Drawing.Size(100, 20)
        Me.CajaTextoMinimo.TabIndex = 5
        Me.CajaTextoMinimo.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'SolapaContador
        '
        Me.SolapaContador.Controls.Add(Me.CajaContadorFemenina)
        Me.SolapaContador.Controls.Add(Me.Label16)
        Me.SolapaContador.Controls.Add(Me.CajaContadorPalabra)
        Me.SolapaContador.Controls.Add(Me.Label15)
        Me.SolapaContador.Controls.Add(Me.CajaContadorNumeral)
        Me.SolapaContador.Controls.Add(Me.Label14)
        Me.SolapaContador.Controls.Add(Me.CajaContadorIncremento)
        Me.SolapaContador.Controls.Add(Me.Label13)
        Me.SolapaContador.Controls.Add(Me.CajaContadorInicio)
        Me.SolapaContador.Location = New System.Drawing.Point(4, 22)
        Me.SolapaContador.Name = "SolapaContador"
        Me.SolapaContador.Padding = New System.Windows.Forms.Padding(3)
        Me.SolapaContador.Size = New System.Drawing.Size(410, 276)
        Me.SolapaContador.TabIndex = 8
        Me.SolapaContador.Text = "Contador"
        Me.SolapaContador.UseVisualStyleBackColor = True
        '
        'CajaContadorFemenina
        '
        Me.CajaContadorFemenina.AutoSize = True
        Me.CajaContadorFemenina.Location = New System.Drawing.Point(100, 110)
        Me.CajaContadorFemenina.Name = "CajaContadorFemenina"
        Me.CajaContadorFemenina.Size = New System.Drawing.Size(72, 17)
        Me.CajaContadorFemenina.TabIndex = 15
        Me.CajaContadorFemenina.Text = "Femenina"
        Me.CajaContadorFemenina.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Palabra:"
        '
        'CajaContadorPalabra
        '
        Me.CajaContadorPalabra.Location = New System.Drawing.Point(100, 84)
        Me.CajaContadorPalabra.Name = "CajaContadorPalabra"
        Me.CajaContadorPalabra.Size = New System.Drawing.Size(130, 20)
        Me.CajaContadorPalabra.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(250, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Numeral:"
        '
        'CajaContadorNumeral
        '
        Me.CajaContadorNumeral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CajaContadorNumeral.FormattingEnabled = True
        Me.CajaContadorNumeral.Location = New System.Drawing.Point(250, 27)
        Me.CajaContadorNumeral.Name = "CajaContadorNumeral"
        Me.CajaContadorNumeral.Size = New System.Drawing.Size(150, 225)
        Me.CajaContadorNumeral.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Incremento:"
        '
        'CajaContadorIncremento
        '
        Me.CajaContadorIncremento.Location = New System.Drawing.Point(100, 38)
        Me.CajaContadorIncremento.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.CajaContadorIncremento.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CajaContadorIncremento.Name = "CajaContadorIncremento"
        Me.CajaContadorIncremento.Size = New System.Drawing.Size(130, 20)
        Me.CajaContadorIncremento.TabIndex = 9
        Me.CajaContadorIncremento.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Inicio contador:"
        '
        'CajaContadorInicio
        '
        Me.CajaContadorInicio.Location = New System.Drawing.Point(100, 12)
        Me.CajaContadorInicio.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.CajaContadorInicio.Name = "CajaContadorInicio"
        Me.CajaContadorInicio.Size = New System.Drawing.Size(130, 20)
        Me.CajaContadorInicio.TabIndex = 7
        Me.CajaContadorInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BotonAceptar
        '
        Me.BotonAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BotonAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonAceptar.Location = New System.Drawing.Point(12, 340)
        Me.BotonAceptar.Name = "BotonAceptar"
        Me.BotonAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BotonAceptar.TabIndex = 3
        Me.BotonAceptar.Text = "Aceptar"
        Me.BotonAceptar.UseVisualStyleBackColor = True
        '
        'BotonCancelar
        '
        Me.BotonCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BotonCancelar.Location = New System.Drawing.Point(93, 340)
        Me.BotonCancelar.Name = "BotonCancelar"
        Me.BotonCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BotonCancelar.TabIndex = 4
        Me.BotonCancelar.Text = "Cancelar"
        Me.BotonCancelar.UseVisualStyleBackColor = True
        '
        'BotonPrueba
        '
        Me.BotonPrueba.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonPrueba.Location = New System.Drawing.Point(355, 340)
        Me.BotonPrueba.Name = "BotonPrueba"
        Me.BotonPrueba.Size = New System.Drawing.Size(75, 23)
        Me.BotonPrueba.TabIndex = 10
        Me.BotonPrueba.Text = "Prueba"
        Me.BotonPrueba.UseVisualStyleBackColor = True
        '
        'CajaPrueba
        '
        Me.CajaPrueba.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaPrueba.Location = New System.Drawing.Point(174, 342)
        Me.CajaPrueba.Name = "CajaPrueba"
        Me.CajaPrueba.ReadOnly = True
        Me.CajaPrueba.Size = New System.Drawing.Size(175, 20)
        Me.CajaPrueba.TabIndex = 11
        '
        'FormCampo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BotonCancelar
        Me.ClientSize = New System.Drawing.Size(442, 373)
        Me.Controls.Add(Me.CajaPrueba)
        Me.Controls.Add(Me.BotonPrueba)
        Me.Controls.Add(Me.BotonCancelar)
        Me.Controls.Add(Me.BotonAceptar)
        Me.Controls.Add(Me.Solapas)
        Me.Controls.Add(Me.CajaNombre)
        Me.Controls.Add(Me.EtiquetaNombre)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(450, 400)
        Me.Name = "FormCampo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Campo a medida"
        Me.Solapas.ResumeLayout(False)
        Me.SolapaCodigo.ResumeLayout(False)
        Me.SolapaCodigo.PerformLayout()
        CType(Me.CajaCodigoLongitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SolapaLista.ResumeLayout(False)
        Me.SolapaLista.PerformLayout()
        Me.SolapaRango.ResumeLayout(False)
        Me.SolapaRango.PerformLayout()
        CType(Me.CajaRangoMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CajaRangoMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SolapaMoneda.ResumeLayout(False)
        Me.SolapaMoneda.PerformLayout()
        CType(Me.CajaMonedaMaxima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CajaMonedaMinima, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SolapaFecha.ResumeLayout(False)
        Me.SolapaFecha.PerformLayout()
        Me.SolapaHora.ResumeLayout(False)
        Me.SolapaHora.PerformLayout()
        Me.SolapaLogico.ResumeLayout(False)
        Me.SolapaLogico.PerformLayout()
        Me.SolapaTexto.ResumeLayout(False)
        Me.SolapaTexto.PerformLayout()
        CType(Me.CajaTextoMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CajaTextoMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SolapaContador.ResumeLayout(False)
        Me.SolapaContador.PerformLayout()
        CType(Me.CajaContadorIncremento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CajaContadorInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EtiquetaNombre As System.Windows.Forms.Label
    Friend WithEvents CajaNombre As System.Windows.Forms.TextBox
    Friend WithEvents Solapas As System.Windows.Forms.TabControl
    Friend WithEvents SolapaRango As System.Windows.Forms.TabPage
    Friend WithEvents SolapaLista As System.Windows.Forms.TabPage
    Friend WithEvents CajaLista As System.Windows.Forms.TextBox
    Friend WithEvents BotonAceptar As System.Windows.Forms.Button
    Friend WithEvents BotonCancelar As System.Windows.Forms.Button
    Friend WithEvents CajaRangoMinimo As System.Windows.Forms.NumericUpDown
    Friend WithEvents EtiquetaMinimo As System.Windows.Forms.Label
    Friend WithEvents EtiquetaMaximo As System.Windows.Forms.Label
    Friend WithEvents CajaRangoMaximo As System.Windows.Forms.NumericUpDown
    Friend WithEvents SolapaCodigo As System.Windows.Forms.TabPage
    Friend WithEvents SolapaMoneda As System.Windows.Forms.TabPage
    Friend WithEvents SolapaFecha As System.Windows.Forms.TabPage
    Friend WithEvents SolapaHora As System.Windows.Forms.TabPage
    Friend WithEvents SolapaLogico As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EtiquetaCodigoLongitud As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CajaCodigoCaracteres As System.Windows.Forms.TextBox
    Friend WithEvents CajaCodigoLongitud As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CajaMonedaMaxima As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CajaMonedaMinima As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CajaHoraMaxima As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CajaHoraMinima As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CajaFechaMaxima As System.Windows.Forms.MaskedTextBox
    Friend WithEvents CajaFechaMinima As System.Windows.Forms.MaskedTextBox
    Friend WithEvents BotonPrueba As System.Windows.Forms.Button
    Friend WithEvents SolapaTexto As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CajaTextoMaximo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CajaTextoMinimo As System.Windows.Forms.NumericUpDown
    Friend WithEvents SolapaContador As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CajaContadorNumeral As System.Windows.Forms.ListBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CajaContadorIncremento As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CajaContadorInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CajaContadorPalabra As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CajaCodigoFormato As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CajaRangoNumeral As System.Windows.Forms.ListBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CajaFechaSemana As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CajaRangoDistribucion As System.Windows.Forms.ComboBox
    Friend WithEvents CajaMonedaUnidad As System.Windows.Forms.ListBox
    Friend WithEvents CajaContadorFemenina As System.Windows.Forms.CheckBox
    Friend WithEvents CajaPrueba As System.Windows.Forms.TextBox
End Class
