<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGenerar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGenerar))
        Me.BotonGenerar = New System.Windows.Forms.Button()
        Me.BarraProgreso = New System.Windows.Forms.ProgressBar()
        Me.DialogoAbrir = New System.Windows.Forms.OpenFileDialog()
        Me.BotonCancelar = New System.Windows.Forms.Button()
        Me.Solapas = New System.Windows.Forms.TabControl()
        Me.SolapaInteractivo = New System.Windows.Forms.TabPage()
        Me.BotonAbajoIndefinido = New System.Windows.Forms.Button()
        Me.BotonArribaIndefinido = New System.Windows.Forms.Button()
        Me.BotonAbajoDefinido = New System.Windows.Forms.Button()
        Me.BotonArribaDefinido = New System.Windows.Forms.Button()
        Me.BotonMarcarDefinidos = New System.Windows.Forms.Button()
        Me.BotonAbrirArchivo = New System.Windows.Forms.Button()
        Me.CajaTotalFactor = New System.Windows.Forms.ListBox()
        Me.BotonMarcarPredefinidos = New System.Windows.Forms.Button()
        Me.BotonBorrarCampo = New System.Windows.Forms.Button()
        Me.BotonEditarCampo = New System.Windows.Forms.Button()
        Me.BotonNuevoCampo = New System.Windows.Forms.Button()
        Me.BotonSeleccionarArchivo = New System.Windows.Forms.Button()
        Me.CajaArchivo = New System.Windows.Forms.TextBox()
        Me.EtiquetaArchivo = New System.Windows.Forms.Label()
        Me.CajaCamposPredefinidos = New System.Windows.Forms.CheckedListBox()
        Me.CajaCamposDefinidos = New System.Windows.Forms.CheckedListBox()
        Me.EtiquetaDefinidos = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EtiquetaTotal = New System.Windows.Forms.Label()
        Me.EtiquetaPredefinidos = New System.Windows.Forms.Label()
        Me.CajaFormato = New System.Windows.Forms.ListBox()
        Me.CajaTotalPotencia = New System.Windows.Forms.ListBox()
        Me.SolapaGuion = New System.Windows.Forms.TabPage()
        Me.BotonNuevoGuion = New System.Windows.Forms.Button()
        Me.CajaGuion = New System.Windows.Forms.TextBox()
        Me.BotonGuardarGuion = New System.Windows.Forms.Button()
        Me.BotonAbrirGuion = New System.Windows.Forms.Button()
        Me.CajaArchivoGuion = New System.Windows.Forms.TextBox()
        Me.SolapaEspecial = New System.Windows.Forms.TabPage()
        Me.CajaOpcionTextoHTML = New System.Windows.Forms.RadioButton()
        Me.EtiquetaEnlace = New System.Windows.Forms.LinkLabel()
        Me.DialogoGuardar = New System.Windows.Forms.SaveFileDialog()
        Me.Solapas.SuspendLayout()
        Me.SolapaInteractivo.SuspendLayout()
        Me.SolapaGuion.SuspendLayout()
        Me.SolapaEspecial.SuspendLayout()
        Me.SuspendLayout()
        '
        'BotonGenerar
        '
        Me.BotonGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonGenerar.Location = New System.Drawing.Point(12, 436)
        Me.BotonGenerar.Name = "BotonGenerar"
        Me.BotonGenerar.Size = New System.Drawing.Size(101, 28)
        Me.BotonGenerar.TabIndex = 2
        Me.BotonGenerar.Text = "Generar"
        Me.BotonGenerar.UseVisualStyleBackColor = True
        '
        'BarraProgreso
        '
        Me.BarraProgreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BarraProgreso.Location = New System.Drawing.Point(195, 441)
        Me.BarraProgreso.Name = "BarraProgreso"
        Me.BarraProgreso.Size = New System.Drawing.Size(385, 20)
        Me.BarraProgreso.TabIndex = 4
        '
        'DialogoAbrir
        '
        Me.DialogoAbrir.CheckFileExists = False
        Me.DialogoAbrir.Title = "Seleccionar archivo"
        '
        'BotonCancelar
        '
        Me.BotonCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonCancelar.Enabled = False
        Me.BotonCancelar.Location = New System.Drawing.Point(119, 436)
        Me.BotonCancelar.Name = "BotonCancelar"
        Me.BotonCancelar.Size = New System.Drawing.Size(70, 28)
        Me.BotonCancelar.TabIndex = 3
        Me.BotonCancelar.Text = "Cancelar"
        Me.BotonCancelar.UseVisualStyleBackColor = True
        '
        'Solapas
        '
        Me.Solapas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Solapas.Controls.Add(Me.SolapaInteractivo)
        Me.Solapas.Controls.Add(Me.SolapaGuion)
        Me.Solapas.Controls.Add(Me.SolapaEspecial)
        Me.Solapas.Location = New System.Drawing.Point(10, 7)
        Me.Solapas.Name = "Solapas"
        Me.Solapas.SelectedIndex = 0
        Me.Solapas.Size = New System.Drawing.Size(570, 415)
        Me.Solapas.TabIndex = 0
        '
        'SolapaInteractivo
        '
        Me.SolapaInteractivo.Controls.Add(Me.BotonAbajoIndefinido)
        Me.SolapaInteractivo.Controls.Add(Me.BotonArribaIndefinido)
        Me.SolapaInteractivo.Controls.Add(Me.BotonAbajoDefinido)
        Me.SolapaInteractivo.Controls.Add(Me.BotonArribaDefinido)
        Me.SolapaInteractivo.Controls.Add(Me.BotonMarcarDefinidos)
        Me.SolapaInteractivo.Controls.Add(Me.BotonAbrirArchivo)
        Me.SolapaInteractivo.Controls.Add(Me.CajaTotalFactor)
        Me.SolapaInteractivo.Controls.Add(Me.BotonMarcarPredefinidos)
        Me.SolapaInteractivo.Controls.Add(Me.BotonBorrarCampo)
        Me.SolapaInteractivo.Controls.Add(Me.BotonEditarCampo)
        Me.SolapaInteractivo.Controls.Add(Me.BotonNuevoCampo)
        Me.SolapaInteractivo.Controls.Add(Me.BotonSeleccionarArchivo)
        Me.SolapaInteractivo.Controls.Add(Me.CajaArchivo)
        Me.SolapaInteractivo.Controls.Add(Me.EtiquetaArchivo)
        Me.SolapaInteractivo.Controls.Add(Me.CajaCamposPredefinidos)
        Me.SolapaInteractivo.Controls.Add(Me.CajaCamposDefinidos)
        Me.SolapaInteractivo.Controls.Add(Me.EtiquetaDefinidos)
        Me.SolapaInteractivo.Controls.Add(Me.Label3)
        Me.SolapaInteractivo.Controls.Add(Me.EtiquetaTotal)
        Me.SolapaInteractivo.Controls.Add(Me.EtiquetaPredefinidos)
        Me.SolapaInteractivo.Controls.Add(Me.CajaFormato)
        Me.SolapaInteractivo.Controls.Add(Me.CajaTotalPotencia)
        Me.SolapaInteractivo.Location = New System.Drawing.Point(4, 22)
        Me.SolapaInteractivo.Name = "SolapaInteractivo"
        Me.SolapaInteractivo.Padding = New System.Windows.Forms.Padding(3)
        Me.SolapaInteractivo.Size = New System.Drawing.Size(562, 389)
        Me.SolapaInteractivo.TabIndex = 0
        Me.SolapaInteractivo.Text = "Interactivo"
        Me.SolapaInteractivo.UseVisualStyleBackColor = True
        '
        'BotonAbajoIndefinido
        '
        Me.BotonAbajoIndefinido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonAbajoIndefinido.BackColor = System.Drawing.SystemColors.Control
        Me.BotonAbajoIndefinido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonAbajoIndefinido.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BotonAbajoIndefinido.Location = New System.Drawing.Point(88, 315)
        Me.BotonAbajoIndefinido.Name = "BotonAbajoIndefinido"
        Me.BotonAbajoIndefinido.Size = New System.Drawing.Size(24, 24)
        Me.BotonAbajoIndefinido.TabIndex = 21
        Me.BotonAbajoIndefinido.Text = "▼"
        Me.BotonAbajoIndefinido.UseVisualStyleBackColor = False
        Me.BotonAbajoIndefinido.Visible = False
        '
        'BotonArribaIndefinido
        '
        Me.BotonArribaIndefinido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonArribaIndefinido.BackColor = System.Drawing.SystemColors.Control
        Me.BotonArribaIndefinido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonArribaIndefinido.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BotonArribaIndefinido.Location = New System.Drawing.Point(112, 315)
        Me.BotonArribaIndefinido.Name = "BotonArribaIndefinido"
        Me.BotonArribaIndefinido.Size = New System.Drawing.Size(24, 24)
        Me.BotonArribaIndefinido.TabIndex = 20
        Me.BotonArribaIndefinido.Text = "▲"
        Me.BotonArribaIndefinido.UseVisualStyleBackColor = False
        Me.BotonArribaIndefinido.Visible = False
        '
        'BotonAbajoDefinido
        '
        Me.BotonAbajoDefinido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonAbajoDefinido.BackColor = System.Drawing.SystemColors.Control
        Me.BotonAbajoDefinido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonAbajoDefinido.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BotonAbajoDefinido.Location = New System.Drawing.Point(221, 315)
        Me.BotonAbajoDefinido.Name = "BotonAbajoDefinido"
        Me.BotonAbajoDefinido.Size = New System.Drawing.Size(24, 24)
        Me.BotonAbajoDefinido.TabIndex = 19
        Me.BotonAbajoDefinido.Text = "▼"
        Me.BotonAbajoDefinido.UseVisualStyleBackColor = False
        '
        'BotonArribaDefinido
        '
        Me.BotonArribaDefinido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonArribaDefinido.BackColor = System.Drawing.SystemColors.Control
        Me.BotonArribaDefinido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BotonArribaDefinido.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BotonArribaDefinido.Location = New System.Drawing.Point(245, 315)
        Me.BotonArribaDefinido.Name = "BotonArribaDefinido"
        Me.BotonArribaDefinido.Size = New System.Drawing.Size(24, 24)
        Me.BotonArribaDefinido.TabIndex = 18
        Me.BotonArribaDefinido.Text = "▲"
        Me.BotonArribaDefinido.UseVisualStyleBackColor = False
        '
        'BotonMarcarDefinidos
        '
        Me.BotonMarcarDefinidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonMarcarDefinidos.Location = New System.Drawing.Point(151, 315)
        Me.BotonMarcarDefinidos.Name = "BotonMarcarDefinidos"
        Me.BotonMarcarDefinidos.Size = New System.Drawing.Size(64, 24)
        Me.BotonMarcarDefinidos.TabIndex = 5
        Me.BotonMarcarDefinidos.Text = "marcar"
        Me.BotonMarcarDefinidos.UseVisualStyleBackColor = True
        '
        'BotonAbrirArchivo
        '
        Me.BotonAbrirArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonAbrirArchivo.Location = New System.Drawing.Point(476, 356)
        Me.BotonAbrirArchivo.Name = "BotonAbrirArchivo"
        Me.BotonAbrirArchivo.Size = New System.Drawing.Size(70, 23)
        Me.BotonAbrirArchivo.TabIndex = 17
        Me.BotonAbrirArchivo.Text = "Abrir"
        Me.BotonAbrirArchivo.UseVisualStyleBackColor = True
        '
        'CajaTotalFactor
        '
        Me.CajaTotalFactor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaTotalFactor.BackColor = System.Drawing.Color.GhostWhite
        Me.CajaTotalFactor.FormattingEnabled = True
        Me.CajaTotalFactor.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.CajaTotalFactor.Location = New System.Drawing.Point(419, 28)
        Me.CajaTotalFactor.Name = "CajaTotalFactor"
        Me.CajaTotalFactor.Size = New System.Drawing.Size(30, 134)
        Me.CajaTotalFactor.TabIndex = 10
        '
        'BotonMarcarPredefinidos
        '
        Me.BotonMarcarPredefinidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonMarcarPredefinidos.Location = New System.Drawing.Point(18, 315)
        Me.BotonMarcarPredefinidos.Name = "BotonMarcarPredefinidos"
        Me.BotonMarcarPredefinidos.Size = New System.Drawing.Size(64, 24)
        Me.BotonMarcarPredefinidos.TabIndex = 2
        Me.BotonMarcarPredefinidos.Text = "marcar"
        Me.BotonMarcarPredefinidos.UseVisualStyleBackColor = True
        '
        'BotonBorrarCampo
        '
        Me.BotonBorrarCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonBorrarCampo.BackColor = System.Drawing.SystemColors.Control
        Me.BotonBorrarCampo.Enabled = False
        Me.BotonBorrarCampo.Location = New System.Drawing.Point(403, 315)
        Me.BotonBorrarCampo.Name = "BotonBorrarCampo"
        Me.BotonBorrarCampo.Size = New System.Drawing.Size(64, 24)
        Me.BotonBorrarCampo.TabIndex = 8
        Me.BotonBorrarCampo.Text = "borrar"
        Me.BotonBorrarCampo.UseVisualStyleBackColor = False
        '
        'BotonEditarCampo
        '
        Me.BotonEditarCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonEditarCampo.BackColor = System.Drawing.SystemColors.Control
        Me.BotonEditarCampo.Enabled = False
        Me.BotonEditarCampo.Location = New System.Drawing.Point(339, 315)
        Me.BotonEditarCampo.Name = "BotonEditarCampo"
        Me.BotonEditarCampo.Size = New System.Drawing.Size(64, 24)
        Me.BotonEditarCampo.TabIndex = 7
        Me.BotonEditarCampo.Text = "editar"
        Me.BotonEditarCampo.UseVisualStyleBackColor = False
        '
        'BotonNuevoCampo
        '
        Me.BotonNuevoCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BotonNuevoCampo.BackColor = System.Drawing.SystemColors.Control
        Me.BotonNuevoCampo.Location = New System.Drawing.Point(275, 315)
        Me.BotonNuevoCampo.Name = "BotonNuevoCampo"
        Me.BotonNuevoCampo.Size = New System.Drawing.Size(64, 24)
        Me.BotonNuevoCampo.TabIndex = 6
        Me.BotonNuevoCampo.Text = "nuevo"
        Me.BotonNuevoCampo.UseVisualStyleBackColor = False
        '
        'BotonSeleccionarArchivo
        '
        Me.BotonSeleccionarArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonSeleccionarArchivo.Location = New System.Drawing.Point(400, 355)
        Me.BotonSeleccionarArchivo.Name = "BotonSeleccionarArchivo"
        Me.BotonSeleccionarArchivo.Size = New System.Drawing.Size(70, 24)
        Me.BotonSeleccionarArchivo.TabIndex = 16
        Me.BotonSeleccionarArchivo.Text = "Examinar"
        Me.BotonSeleccionarArchivo.UseVisualStyleBackColor = True
        '
        'CajaArchivo
        '
        Me.CajaArchivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaArchivo.BackColor = System.Drawing.Color.Honeydew
        Me.CajaArchivo.Location = New System.Drawing.Point(67, 358)
        Me.CajaArchivo.Name = "CajaArchivo"
        Me.CajaArchivo.Size = New System.Drawing.Size(327, 20)
        Me.CajaArchivo.TabIndex = 15
        Me.CajaArchivo.Text = "agenda.csv"
        '
        'EtiquetaArchivo
        '
        Me.EtiquetaArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EtiquetaArchivo.AutoSize = True
        Me.EtiquetaArchivo.Location = New System.Drawing.Point(15, 361)
        Me.EtiquetaArchivo.Name = "EtiquetaArchivo"
        Me.EtiquetaArchivo.Size = New System.Drawing.Size(46, 13)
        Me.EtiquetaArchivo.TabIndex = 14
        Me.EtiquetaArchivo.Text = "Archivo:"
        '
        'CajaCamposPredefinidos
        '
        Me.CajaCamposPredefinidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CajaCamposPredefinidos.BackColor = System.Drawing.Color.Beige
        Me.CajaCamposPredefinidos.CheckOnClick = True
        Me.CajaCamposPredefinidos.FormattingEnabled = True
        Me.CajaCamposPredefinidos.IntegralHeight = False
        Me.CajaCamposPredefinidos.Location = New System.Drawing.Point(16, 28)
        Me.CajaCamposPredefinidos.Name = "CajaCamposPredefinidos"
        Me.CajaCamposPredefinidos.Size = New System.Drawing.Size(129, 281)
        Me.CajaCamposPredefinidos.TabIndex = 1
        '
        'CajaCamposDefinidos
        '
        Me.CajaCamposDefinidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaCamposDefinidos.BackColor = System.Drawing.Color.FloralWhite
        Me.CajaCamposDefinidos.FormattingEnabled = True
        Me.CajaCamposDefinidos.IntegralHeight = False
        Me.CajaCamposDefinidos.Location = New System.Drawing.Point(151, 28)
        Me.CajaCamposDefinidos.Name = "CajaCamposDefinidos"
        Me.CajaCamposDefinidos.Size = New System.Drawing.Size(259, 281)
        Me.CajaCamposDefinidos.TabIndex = 4
        '
        'EtiquetaDefinidos
        '
        Me.EtiquetaDefinidos.AutoSize = True
        Me.EtiquetaDefinidos.Location = New System.Drawing.Point(151, 12)
        Me.EtiquetaDefinidos.Name = "EtiquetaDefinidos"
        Me.EtiquetaDefinidos.Size = New System.Drawing.Size(94, 13)
        Me.EtiquetaDefinidos.TabIndex = 3
        Me.EtiquetaDefinidos.Text = "Campos a medida:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Formato de archivo:"
        '
        'EtiquetaTotal
        '
        Me.EtiquetaTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EtiquetaTotal.AutoSize = True
        Me.EtiquetaTotal.Location = New System.Drawing.Point(414, 12)
        Me.EtiquetaTotal.Name = "EtiquetaTotal"
        Me.EtiquetaTotal.Size = New System.Drawing.Size(64, 13)
        Me.EtiquetaTotal.TabIndex = 9
        Me.EtiquetaTotal.Text = "Nº registros:"
        '
        'EtiquetaPredefinidos
        '
        Me.EtiquetaPredefinidos.AutoSize = True
        Me.EtiquetaPredefinidos.Location = New System.Drawing.Point(15, 12)
        Me.EtiquetaPredefinidos.Name = "EtiquetaPredefinidos"
        Me.EtiquetaPredefinidos.Size = New System.Drawing.Size(108, 13)
        Me.EtiquetaPredefinidos.TabIndex = 0
        Me.EtiquetaPredefinidos.Text = "Campos predefinidos:"
        '
        'CajaFormato
        '
        Me.CajaFormato.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaFormato.BackColor = System.Drawing.Color.Honeydew
        Me.CajaFormato.FormattingEnabled = True
        Me.CajaFormato.IntegralHeight = False
        Me.CajaFormato.Items.AddRange(New Object() {""})
        Me.CajaFormato.Location = New System.Drawing.Point(419, 192)
        Me.CajaFormato.Name = "CajaFormato"
        Me.CajaFormato.Size = New System.Drawing.Size(129, 117)
        Me.CajaFormato.TabIndex = 13
        '
        'CajaTotalPotencia
        '
        Me.CajaTotalPotencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaTotalPotencia.BackColor = System.Drawing.Color.GhostWhite
        Me.CajaTotalPotencia.FormattingEnabled = True
        Me.CajaTotalPotencia.Items.AddRange(New Object() {"x 1", "x 10", "x 100 ", "x 1.000", "x 10.000", "x 100.000", "x 1.000.000"})
        Me.CajaTotalPotencia.Location = New System.Drawing.Point(448, 28)
        Me.CajaTotalPotencia.Name = "CajaTotalPotencia"
        Me.CajaTotalPotencia.Size = New System.Drawing.Size(98, 134)
        Me.CajaTotalPotencia.TabIndex = 11
        '
        'SolapaGuion
        '
        Me.SolapaGuion.Controls.Add(Me.BotonNuevoGuion)
        Me.SolapaGuion.Controls.Add(Me.CajaGuion)
        Me.SolapaGuion.Controls.Add(Me.BotonGuardarGuion)
        Me.SolapaGuion.Controls.Add(Me.BotonAbrirGuion)
        Me.SolapaGuion.Controls.Add(Me.CajaArchivoGuion)
        Me.SolapaGuion.Location = New System.Drawing.Point(4, 22)
        Me.SolapaGuion.Name = "SolapaGuion"
        Me.SolapaGuion.Padding = New System.Windows.Forms.Padding(3)
        Me.SolapaGuion.Size = New System.Drawing.Size(716, 335)
        Me.SolapaGuion.TabIndex = 1
        Me.SolapaGuion.Text = "Guión"
        Me.SolapaGuion.UseVisualStyleBackColor = True
        '
        'BotonNuevoGuion
        '
        Me.BotonNuevoGuion.Location = New System.Drawing.Point(19, 16)
        Me.BotonNuevoGuion.Name = "BotonNuevoGuion"
        Me.BotonNuevoGuion.Size = New System.Drawing.Size(70, 23)
        Me.BotonNuevoGuion.TabIndex = 1
        Me.BotonNuevoGuion.Text = "Nuevo"
        Me.BotonNuevoGuion.UseVisualStyleBackColor = True
        '
        'CajaGuion
        '
        Me.CajaGuion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaGuion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaGuion.Location = New System.Drawing.Point(19, 47)
        Me.CajaGuion.Multiline = True
        Me.CajaGuion.Name = "CajaGuion"
        Me.CajaGuion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CajaGuion.Size = New System.Drawing.Size(682, 270)
        Me.CajaGuion.TabIndex = 0
        Me.CajaGuion.Text = "Archivo: productos.sql" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Total: 250" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Id = " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nombre = " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Correo = " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lista Zona = N" & _
            "orte, Centro, Sur" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rango Porcentaje = entre 0 y 100" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'BotonGuardarGuion
        '
        Me.BotonGuardarGuion.Location = New System.Drawing.Point(171, 16)
        Me.BotonGuardarGuion.Name = "BotonGuardarGuion"
        Me.BotonGuardarGuion.Size = New System.Drawing.Size(70, 23)
        Me.BotonGuardarGuion.TabIndex = 3
        Me.BotonGuardarGuion.Text = "Guardar"
        Me.BotonGuardarGuion.UseVisualStyleBackColor = True
        '
        'BotonAbrirGuion
        '
        Me.BotonAbrirGuion.Location = New System.Drawing.Point(95, 15)
        Me.BotonAbrirGuion.Name = "BotonAbrirGuion"
        Me.BotonAbrirGuion.Size = New System.Drawing.Size(70, 24)
        Me.BotonAbrirGuion.TabIndex = 2
        Me.BotonAbrirGuion.Text = "Abrir"
        Me.BotonAbrirGuion.UseVisualStyleBackColor = True
        '
        'CajaArchivoGuion
        '
        Me.CajaArchivoGuion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CajaArchivoGuion.BackColor = System.Drawing.SystemColors.Control
        Me.CajaArchivoGuion.Location = New System.Drawing.Point(247, 18)
        Me.CajaArchivoGuion.Name = "CajaArchivoGuion"
        Me.CajaArchivoGuion.ReadOnly = True
        Me.CajaArchivoGuion.Size = New System.Drawing.Size(454, 20)
        Me.CajaArchivoGuion.TabIndex = 4
        Me.CajaArchivoGuion.Text = "agenda.csv"
        '
        'SolapaEspecial
        '
        Me.SolapaEspecial.Controls.Add(Me.CajaOpcionTextoHTML)
        Me.SolapaEspecial.Location = New System.Drawing.Point(4, 22)
        Me.SolapaEspecial.Name = "SolapaEspecial"
        Me.SolapaEspecial.Padding = New System.Windows.Forms.Padding(3)
        Me.SolapaEspecial.Size = New System.Drawing.Size(716, 335)
        Me.SolapaEspecial.TabIndex = 2
        Me.SolapaEspecial.Text = "Especial"
        Me.SolapaEspecial.UseVisualStyleBackColor = True
        '
        'CajaOpcionTextoHTML
        '
        Me.CajaOpcionTextoHTML.AutoSize = True
        Me.CajaOpcionTextoHTML.Location = New System.Drawing.Point(21, 20)
        Me.CajaOpcionTextoHTML.Name = "CajaOpcionTextoHTML"
        Me.CajaOpcionTextoHTML.Size = New System.Drawing.Size(85, 17)
        Me.CajaOpcionTextoHTML.TabIndex = 0
        Me.CajaOpcionTextoHTML.TabStop = True
        Me.CajaOpcionTextoHTML.Text = "Texto HTML"
        Me.CajaOpcionTextoHTML.UseVisualStyleBackColor = True
        '
        'EtiquetaEnlace
        '
        Me.EtiquetaEnlace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EtiquetaEnlace.AutoSize = True
        Me.EtiquetaEnlace.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.EtiquetaEnlace.Location = New System.Drawing.Point(491, 7)
        Me.EtiquetaEnlace.Name = "EtiquetaEnlace"
        Me.EtiquetaEnlace.Size = New System.Drawing.Size(89, 13)
        Me.EtiquetaEnlace.TabIndex = 1
        Me.EtiquetaEnlace.TabStop = True
        Me.EtiquetaEnlace.Text = "ProInf.net ©2012"
        '
        'DialogoGuardar
        '
        Me.DialogoGuardar.Title = "Guardar archivo"
        '
        'FormGenerar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 473)
        Me.Controls.Add(Me.EtiquetaEnlace)
        Me.Controls.Add(Me.Solapas)
        Me.Controls.Add(Me.BotonCancelar)
        Me.Controls.Add(Me.BarraProgreso)
        Me.Controls.Add(Me.BotonGenerar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(600, 500)
        Me.Name = "FormGenerar"
        Me.Text = "Generador aleatorio de base de datos"
        Me.Solapas.ResumeLayout(False)
        Me.SolapaInteractivo.ResumeLayout(False)
        Me.SolapaInteractivo.PerformLayout()
        Me.SolapaGuion.ResumeLayout(False)
        Me.SolapaGuion.PerformLayout()
        Me.SolapaEspecial.ResumeLayout(False)
        Me.SolapaEspecial.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BotonGenerar As System.Windows.Forms.Button
    Friend WithEvents BarraProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents DialogoAbrir As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BotonCancelar As System.Windows.Forms.Button
    Friend WithEvents Solapas As System.Windows.Forms.TabControl
    Friend WithEvents SolapaInteractivo As System.Windows.Forms.TabPage
    Friend WithEvents BotonAbrirArchivo As System.Windows.Forms.Button
    Friend WithEvents CajaTotalFactor As System.Windows.Forms.ListBox
    Friend WithEvents BotonMarcarPredefinidos As System.Windows.Forms.Button
    Friend WithEvents BotonBorrarCampo As System.Windows.Forms.Button
    Friend WithEvents BotonEditarCampo As System.Windows.Forms.Button
    Friend WithEvents BotonNuevoCampo As System.Windows.Forms.Button
    Friend WithEvents BotonSeleccionarArchivo As System.Windows.Forms.Button
    Friend WithEvents CajaArchivo As System.Windows.Forms.TextBox
    Friend WithEvents EtiquetaArchivo As System.Windows.Forms.Label
    Friend WithEvents CajaCamposPredefinidos As System.Windows.Forms.CheckedListBox
    Friend WithEvents CajaCamposDefinidos As System.Windows.Forms.CheckedListBox
    Friend WithEvents EtiquetaDefinidos As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EtiquetaTotal As System.Windows.Forms.Label
    Friend WithEvents EtiquetaPredefinidos As System.Windows.Forms.Label
    Friend WithEvents CajaFormato As System.Windows.Forms.ListBox
    Friend WithEvents CajaTotalPotencia As System.Windows.Forms.ListBox
    Friend WithEvents SolapaGuion As System.Windows.Forms.TabPage
    Friend WithEvents EtiquetaEnlace As System.Windows.Forms.LinkLabel
    Friend WithEvents CajaGuion As System.Windows.Forms.TextBox
    Friend WithEvents BotonGuardarGuion As System.Windows.Forms.Button
    Friend WithEvents BotonAbrirGuion As System.Windows.Forms.Button
    Friend WithEvents CajaArchivoGuion As System.Windows.Forms.TextBox
    Friend WithEvents BotonNuevoGuion As System.Windows.Forms.Button
    Friend WithEvents DialogoGuardar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents BotonMarcarDefinidos As System.Windows.Forms.Button
    Friend WithEvents SolapaEspecial As System.Windows.Forms.TabPage
    Friend WithEvents CajaOpcionTextoHTML As System.Windows.Forms.RadioButton
    Friend WithEvents BotonAbajoIndefinido As System.Windows.Forms.Button
    Friend WithEvents BotonArribaIndefinido As System.Windows.Forms.Button
    Friend WithEvents BotonAbajoDefinido As System.Windows.Forms.Button
    Friend WithEvents BotonArribaDefinido As System.Windows.Forms.Button

End Class
