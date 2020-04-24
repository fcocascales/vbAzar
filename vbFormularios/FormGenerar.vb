' FormGenerar.vb — ProInf.net — feb-2012
'
' Formulario para generar una base de datos al azar
'
' Web: proinf.net/permalink/generador_aleatorio_ponderado_de_nombres_y_apellidos

Public Class FormGenerar

    Dim permanencia As New PermanenciaPrograma()

    Private Sub CargarForm() Handles MyBase.Load
        IniciarCajasLista()
        permanencia.Restaurar()
        BorrarSolapasEnConstruccion()
    End Sub

    Private Sub BorrarSolapasEnConstruccion()
        Solapas.TabPages.Remove(SolapaEspecial)
        Solapas.TabPages.Remove(SolapaGuion)
    End Sub

    Private Sub CerrarForm() Handles Me.FormClosed
        permanencia.Guardar()
    End Sub

    '============================================
    ' CAJAS DE LISTA

    Sub IniciarCajasLista()
        RellenarCajaCamposDefinidos()
        RellenarCajaLista(CajaCamposPredefinidos, Recursos.camposPredefinidos.Values)
        RellenarCajaLista(CajaFormato, Recursos.formatosArchivo.Keys)
        FormUtils.ChequearCajaLista(CajaCamposPredefinidos)
        FormUtils.ChequearCajaLista(CajaCamposDefinidos)
        CajaTotalFactor.SelectedIndex = 0
        CajaTotalPotencia.SelectedIndex = 2
        CajaFormato.SelectedIndex = 0
    End Sub

    Sub RellenarCajaCamposDefinidos()
        For i = 0 To Recursos.definidosPredeterminados.Count - 1
            Dim item = Recursos.definidosPredeterminados.Items(i)
            CajaCamposDefinidos.Items.Add(CampoDefinido.Instanciar(item.Texto))
        Next
    End Sub

    Sub RellenarCajaLista(
        ByVal cajaLista As ListBox,
        ByVal coleccion As ICollection
    )
        cajaLista.Items.Clear()
        For Each item In coleccion
            cajaLista.Items.Add(item)
        Next
    End Sub

    Private Sub AutochequearCampos(ByVal sender As System.Object, ByVal e As System.EventArgs
    ) Handles BotonMarcarPredefinidos.Click, BotonMarcarDefinidos.Click
        Dim cajaLista As CheckedListBox
        If sender Is BotonMarcarPredefinidos Then
            cajaLista = CajaCamposPredefinidos
        Else
            cajaLista = CajaCamposDefinidos
        End If
        FormUtils.ChequearCajaLista(cajaLista, Not cajaLista.GetItemChecked(0))
    End Sub

    Private Sub MoverArribaAbajo(
        ByVal sender As System.Object, ByVal e As System.EventArgs
    ) Handles BotonArribaDefinido.Click, BotonAbajoDefinido.Click
        If sender Is BotonArribaDefinido Then
            FormUtils.MoverArribaSeleccionado(CajaCamposDefinidos)
        ElseIf sender Is BotonAbajoDefinido Then
            FormUtils.MoverAbajoSeleccionado(CajaCamposDefinidos)
        End If
    End Sub

    '============================================
    ' GENERACIÓN BD AZAR

    Dim bd As New BDAzar()

    Private Sub Generar() Handles BotonGenerar.Click
        Select Case Solapas.SelectedIndex
            Case 0 : GenerarInteractivo()
            Case 1 : GenerarGuion()
        End Select
    End Sub

    '============================================
    ' GENERACIÓN INTERACTIVO

    Private Sub GenerarInteractivo()
        MostrarProgreso(True)
        bd.Campos = ObtenerCampos()
        bd.Total = ObtenerTotal()
        bd.Formato = Recursos.formatosArchivo(CajaFormato.Text)
        bd.Formato.Ruta = CajaArchivo.Text
        bd.Generar()
        MostrarProgreso(False)
    End Sub

    Private Sub Cancelar() Handles BotonCancelar.Click
        bd.Cancelar = True
    End Sub

    Function ObtenerCampos() As ICampo()
        Dim lista As New List(Of ICampo)
        For Each item In CajaCamposPredefinidos.CheckedItems
            lista.Add(item)
        Next
        For Each item In CajaCamposDefinidos.CheckedItems
            lista.Add(item)
        Next
        With Recursos.camposPredefinidos
            .EnlazarSexoConNombre(lista.Contains(.Item("nombre")))
            .EnlazarProvinciaConMunicipio(lista.Contains(.Item("municipio")))
            .EnlazarEdadConNacimiento(lista.Contains(.Item("nacimiento")))
            .EnlazarCodigoPostalConProvincia(lista.Contains(.Item("provincia")))
            .EnlazarTelefonoFijoConProvincia(lista.Contains(.Item("provincia")))
            .EnlazarCorreoConNombre(lista.Contains(.Item("nombre")))
            .EnlazarCorreoConApellido(lista.Contains(.Item("apellido1")))
        End With
        Return lista.ToArray()
    End Function

    Private Function ObtenerTotal() As Integer
        Return (CajaTotalFactor.SelectedIndex + 1) * 10 ^ CajaTotalPotencia.SelectedIndex
    End Function

    Private Sub CambiarTotal() Handles CajaTotalPotencia.SelectedIndexChanged, CajaTotalFactor.SelectedIndexChanged
        EtiquetaTotal.Text = ObtenerTotal().ToString("#,##0") & " registros"
    End Sub

    '============================================
    ' BARRA DE PROGRESO

    Sub MostrarProgreso(ByVal activado As Boolean)
        If activado Then
            AddHandler bd.Progresando, AddressOf Progresar
            BotonGenerar.Enabled = False
            BotonCancelar.Enabled = True
        Else
            RemoveHandler bd.Progresando, AddressOf Progresar
            BarraProgreso.Value = 0
            BotonGenerar.Enabled = True
            BotonCancelar.Enabled = False
        End If
    End Sub

    Sub Progresar(ByVal ratio As Double)
        BarraProgreso.Value = ratio * 100
        Application.DoEvents()
    End Sub

    '============================================
    ' SELECCIÓN ARCHIVO DESTINO

    Private Sub SeleccionarFormato() Handles CajaFormato.SelectedIndexChanged
        Dim ruta As String = CajaArchivo.Text
        CajaArchivo.Text = IO.Path.ChangeExtension(ruta, ObtenerExtension())
    End Sub

    Private Sub SeleccionarArchivo() Handles BotonSeleccionarArchivo.Click
        DialogoAbrir.FileName = CajaArchivo.Text
        DialogoAbrir.DefaultExt = ObtenerExtension()
        If DialogoAbrir.ShowDialog() = DialogResult.OK Then
            CajaArchivo.Text = DialogoAbrir.FileName
        End If
    End Sub

    Function ObtenerExtension() As String
        Return Recursos.formatosArchivo(CajaFormato.Text).ObtenerExtension()
    End Function

    Sub AbrirArchivo() Handles BotonAbrirArchivo.Click
        Try
            System.Diagnostics.Process.Start(CajaArchivo.Text)
        Catch ex As Exception
            DialogoError(ex)
        End Try
    End Sub

    '============================================
    ' EDICIÓN CAMPOS DEFINIDOS POR USUARIO

    Private Sub CambiarCampo(ByVal sender As System.Object, ByVal e As System.EventArgs
    ) Handles BotonNuevoCampo.Click, BotonEditarCampo.Click, BotonBorrarCampo.Click
        With CajaCamposDefinidos
            If sender Is BotonNuevoCampo Then
                Dim campo As CampoDefinido = New CampoRango("RANGO Sin nombre = entre 0 y 100")
                If FormCampo.Mostrar(campo) Then
                    .Items.Add(campo, True)
                End If
            ElseIf sender Is BotonEditarCampo Then
                Dim indice = .SelectedIndex
                Dim campo = .Items(indice)
                If campo IsNot Nothing AndAlso FormCampo.Mostrar(campo) Then
                    .Items(indice) = campo
                End If
            ElseIf sender Is BotonBorrarCampo Then
                Dim indice = .SelectedIndex
                If indice >= 0 AndAlso DialogoConfirmar() Then
                    .Items.RemoveAt(indice)
                End If
            End If
        End With
    End Sub

    Private Sub AutoactivarBotonesEdicionCampos(
    ) Handles CajaCamposDefinidos.SelectedIndexChanged
        Dim activado As Boolean = CajaCamposDefinidos.SelectedIndex >= 0
        BotonEditarCampo.Enabled = activado
        BotonBorrarCampo.Enabled = activado
        BotonArribaDefinido.Enabled = activado
        BotonAbajoDefinido.Enabled = activado
    End Sub

    '============================================
    ' GENERACION GUIÓN  

    Private Sub GenerarGuion() 'TODO GenerarGuion
        BDAzar.EjecutarGuion(CajaGuion.Text)
    End Sub

    Private Sub AccionesGuion(ByVal sender As System.Object, ByVal e As System.EventArgs
    ) Handles BotonNuevoGuion.Click, BotonAbrirGuion.Click, BotonGuardarGuion.Click
        If sender Is BotonNuevoGuion Then
            If DialogoConfirmar() Then
                CajaArchivoGuion.Text = "SinNombre.bdazar"
                CajaGuion.Text = ""
            End If
        ElseIf sender Is BotonAbrirGuion Then
            With DialogoAbrir
                .FileName = CajaArchivoGuion.Text
                .DefaultExt = ".bdazar"
                If .ShowDialog() = DialogResult.OK Then
                    CajaArchivoGuion.Text = .FileName
                    CajaGuion.Text = System.IO.File.ReadAllText(.FileName)
                End If
            End With
        ElseIf sender Is BotonGuardarGuion Then
            With DialogoGuardar
                .FileName = CajaArchivoGuion.Text
                .DefaultExt = ".bdazar"
                If .ShowDialog() = DialogResult.OK Then
                    CajaArchivoGuion.Text = .FileName
                    System.IO.File.WriteAllText(.FileName, CajaGuion.Text)
                End If
            End With
        End If
    End Sub

    '============================================
    ' AUTORÍA

    Private Sub IrEnlace() Handles EtiquetaEnlace.LinkClicked
        System.Diagnostics.Process.Start("http://proinf.net/permalink/generador_aleatorio_de_base_de_datos")
    End Sub

End Class


