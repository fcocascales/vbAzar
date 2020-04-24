' FormCampo.vb — ProInf.net — feb-2012
'
' Permite la creación y edición de campos definidos por el usuario

Public Class FormCampo

    Private inicializado As Boolean = False

    Private Sub FormCampo_Load() Handles Me.Load
        If Not inicializado Then
            inicializado = True
            EtiquetaCodigoLongitud.DataBindings.Add("Text", CajaCodigoLongitud, "Value")
            'EntrelazarMinimoMaximo(CajaRangoMinimo, CajaRangoMaximo)
            'EntrelazarMinimoMaximo(CajaMonedaMinima, CajaMonedaMaxima)
            'EntrelazarMinimoMaximo(CajaTextoMinimo, CajaTextoMaximo)
        End If
    End Sub

    'Private Shared Sub EntrelazarMinimoMaximo(ByVal cajaMinimo As NumericUpDown, ByVal cajaMaximo As NumericUpDown)
    '    cajaMaximo.DataBindings.Add("Minimum", cajaMinimo, "Value")
    '    cajaMinimo.DataBindings.Add("Maximum", cajaMaximo, "Value")
    'End Sub

    Public Function Mostrar(
        Optional ByRef campo As CampoDefinido = Nothing
    ) As Boolean
        VaciarCajas()
        PonerCampo(campo)
        If Me.ShowDialog(FormGenerar) = DialogResult.OK Then
            campo = ObtenerCampo()
            Return True
        Else
            Return False
        End If
    End Function

    Sub VaciarCajas()
        Dim ARABIGA = Numerales.Numeración_Arábiga.ToString()
        CajaCodigoCaracteres.Text = "ABC"
        CajaCodigoLongitud.Value = 1
        CajaLista.Text = ""
        CajaRangoMinimo.Value = 0
        CajaRangoMaximo.Value = 100
        RellenarCajaNumerales(CajaRangoNumeral)
        CajaRangoNumeral.SelectedIndex = CajaRangoNumeral.Items.IndexOf(ARABIGA)
        CajaMonedaMinima.Value = 0
        CajaMonedaMaxima.Value = 10000
        CajaMonedaUnidad.SelectedIndex = CajaMonedaUnidad.Items.IndexOf("1,00")
        CajaFechaMinima.Text = New Date(Date.Today.Year, 1, 1).ToString("dd/MM/yyyy")
        CajaFechaMaxima.Text = New Date(Date.Today.Year, 12, 31).ToString("dd/MM/yyyy")
        FormUtils.ChequearCajaLista(CajaFechaSemana, False)
        CajaHoraMinima.Text = "00:00"
        CajaHoraMaxima.Text = "23:59"
        CajaTextoMinimo.Value = 10
        CajaTextoMaximo.Value = 50
        CajaContadorInicio.Value = 1
        CajaContadorIncremento.Value = 1
        RellenarCajaNumerales(CajaContadorNumeral)
        CajaContadorNumeral.SelectedIndex = CajaContadorNumeral.Items.IndexOf(ARABIGA)
        'ReiniciarMinimoMaximo(CajaRangoMinimo, CajaRangoMaximo, -1000000000, 1000000000)
        'ReiniciarMinimoMaximo(CajaMonedaMinima, CajaMonedaMaxima, -1000000000, 1000000000)
        'ReiniciarMinimoMaximo(CajaTextoMinimo, CajaTextoMaximo, 1, 5000)
    End Sub

    Private Sub RellenarCajaNumerales(ByVal cajaLista As ListBox)
        With cajaLista.Items
            If .Count = 0 Then
                For Each clave As Numerales In Recursos.numerales.Keys
                    .Add(clave.ToString())
                Next
            End If
        End With
    End Sub

    'Private Shared Sub ReiniciarMinimoMaximo(
    '    ByVal cajaMinimo As NumericUpDown, ByVal cajaMaximo As NumericUpDown,
    '    ByVal minimo As Integer, ByVal maximo As Integer
    ')
    '    cajaMinimo.Minimum = minimo
    '    cajaMaximo.Maximum = maximo
    '    cajaMinimo.Maximum = maximo
    '    cajaMaximo.Minimum = minimo
    'End Sub

    Sub PonerCampo(ByVal campo As CampoDefinido)
        If campo Is Nothing Then
        Else
            CajaNombre.Text = campo.Nombre
            If TypeOf campo Is CampoCodigo Then
                Solapas.SelectedIndex = 0
                PonerCampoCodigo(campo)
            ElseIf TypeOf campo Is CampoLista Then
                Solapas.SelectedIndex = 1
                PonerCampoLista(campo)
            ElseIf TypeOf campo Is CampoRango Then
                Solapas.SelectedIndex = 2
                PonerCampoRango(campo)
            ElseIf TypeOf campo Is CampoMoneda Then
                Solapas.SelectedIndex = 3
                PonerCampoMoneda(campo)
            ElseIf TypeOf campo Is CampoFecha Then
                Solapas.SelectedIndex = 4
                PonerCampoFecha(campo)
            ElseIf TypeOf campo Is CampoHora Then
                Solapas.SelectedIndex = 5
                PonerCampoHora(campo)
            ElseIf TypeOf campo Is CampoLogico Then
                Solapas.SelectedIndex = 6
                PonerCampoLogico(campo)
            ElseIf TypeOf campo Is CampoTexto Then
                Solapas.SelectedIndex = 7
                PonerCampoTexto(campo)
            ElseIf TypeOf campo Is CampoContador Then
                Solapas.SelectedIndex = 8
                PonerCampoContador(campo)
            End If
        End If
    End Sub

    Sub PonerCampoCodigo(ByVal campo As CampoCodigo)
        CajaCodigoCaracteres.Text = campo.Caracteres
        CajaCodigoLongitud.Value = campo.Longitud
        CajaCodigoFormato.Text = campo.Formato
    End Sub

    Sub PonerCampoLista(ByVal campo As CampoLista)
        CajaLista.Lines = campo.Elementos
    End Sub

    Sub PonerCampoRango(ByVal campo As CampoRango)
        CajaRangoMaximo.Value = campo.Maximo
        CajaRangoMinimo.Value = campo.Minimo
        CajaRangoNumeral.SelectedIndex = campo.Numeral
    End Sub

    Sub PonerCampoMoneda(ByVal campo As CampoMoneda)
        CajaMonedaMaxima.Value = campo.Maximo
        CajaMonedaMinima.Value = campo.Minimo
        CajaMonedaUnidad.SelectedIndex = campo.IndiceUnidad
    End Sub

    Sub PonerCampoFecha(ByVal campo As CampoFecha)
        CajaFechaMaxima.Text = campo.Maximo.ToString("dd/MM/yyyy")
        CajaFechaMinima.Text = campo.Minimo.ToString("dd/MM/yyyy")
        FormUtils.ChequearCajaLista(CajaFechaSemana, campo.DiasSemana)
    End Sub

    Sub PonerCampoHora(ByVal campo As CampoHora)
        CajaHoraMaxima.Text = campo.Maximo.ToString("HH:mm")
        CajaHoraMinima.Text = campo.Minimo.ToString("HH:mm")
    End Sub

    Sub PonerCampoLogico(ByVal campo As CampoLogico)
        'Nada que hacer
    End Sub

    Sub PonerCampoTexto(ByVal campo As CampoTexto)
        CajaTextoMaximo.Value = campo.Maximo
        CajaTextoMinimo.Value = campo.Minimo
    End Sub

    Sub PonerCampoContador(ByVal campo As CampoContador)
        CajaContadorInicio.Value = campo.Inicio
        CajaContadorIncremento.Value = campo.Incremento
        CajaContadorNumeral.SelectedIndex = campo.Numeral
        CajaContadorPalabra.Text = campo.Palabra
        CajaContadorFemenina.Checked = campo.Femenina
    End Sub

    Function ObtenerCampo() As CampoDefinido
        Dim campo As CampoDefinido
        Select Case Solapas.SelectedIndex
            Case 0 : campo = ObtenerCampoCodigo()
            Case 1 : campo = ObtenerCampoLista()
            Case 2 : campo = ObtenerCampoRango()
            Case 3 : campo = ObtenerCampoMoneda()
            Case 4 : campo = ObtenerCampoFecha()
            Case 5 : campo = ObtenerCampoHora()
            Case 6 : campo = ObtenerCampoLogico()
            Case 7 : campo = ObtenerCampoTexto()
            Case 8 : campo = ObtenerCampoContador()
            Case Else : campo = Nothing
        End Select
        Return campo
    End Function

    Function ObtenerCampoCodigo() As CampoCodigo
        Dim campo As New CampoCodigo()
        campo.Nombre = CajaNombre.Text
        campo.Caracteres = CajaCodigoCaracteres.Text
        campo.Longitud = CajaCodigoLongitud.Value
        campo.Formato = CajaCodigoFormato.Text
        Return campo
    End Function

    Function ObtenerCampoLista() As CampoLista
        Dim campo As New CampoLista()
        campo.Nombre = CajaNombre.Text
        campo.Elementos = CajaLista.Lines
        Return campo
    End Function

    Function ObtenerCampoRango() As CampoRango
        Dim campo As New CampoRango()
        campo.Nombre = CajaNombre.Text
        campo.Maximo = CajaRangoMaximo.Value
        campo.Minimo = CajaRangoMinimo.Value
        campo.Numeral = CajaRangoNumeral.SelectedIndex
        Return campo
    End Function

    Function ObtenerCampoMoneda() As CampoMoneda
        Dim campo As New CampoMoneda()
        campo.Nombre = CajaNombre.Text
        campo.Maximo = CajaMonedaMaxima.Value
        campo.Minimo = CajaMonedaMinima.Value
        campo.IndiceUnidad = CajaMonedaUnidad.SelectedIndex
        Return campo
    End Function

    Function ObtenerCampoFecha() As CampoFecha
        Dim campo As New CampoFecha()
        campo.Nombre = CajaNombre.Text
        campo.Maximo = Date.Parse(CajaFechaMaxima.Text)
        campo.Minimo = Date.Parse(CajaFechaMinima.Text)
        campo.DiasSemana = FormUtils.ObtenerIndicesChequeados(CajaFechaSemana)
        Return campo
    End Function

    Function ObtenerCampoHora() As CampoHora
        Dim campo As New CampoHora()
        campo.Nombre = CajaNombre.Text
        campo.Maximo = Date.Parse(CajaHoraMaxima.Text)
        campo.Minimo = Date.Parse(CajaHoraMinima.Text)
        Return campo
    End Function

    Function ObtenerCampoLogico() As CampoLogico
        Dim campo As New CampoLogico()
        campo.Nombre = CajaNombre.Text
        Return campo
    End Function

    Function ObtenerCampoTexto() As CampoTexto
        Dim campo As New CampoTexto
        campo.Nombre = CajaNombre.Text
        campo.Maximo = CajaTextoMaximo.Value
        campo.Minimo = CajaTextoMinimo.Value
        Return campo
    End Function

    Function ObtenerCampoContador() As CampoContador
        Dim campo As New CampoContador
        campo.Nombre = CajaNombre.Text
        campo.Inicio = CajaContadorInicio.Value
        campo.Incremento = CajaContadorIncremento.Value
        campo.Numeral = CajaContadorNumeral.SelectedIndex
        campo.Palabra = CajaContadorPalabra.Text
        campo.Femenina = CajaContadorFemenina.Checked
        Return campo
    End Function

    Private Sub Probar() Handles BotonPrueba.Click
        Dim campo = ObtenerCampo()
        If TypeOf campo Is IReiniciable Then
            DirectCast(campo, IReiniciable).Reiniciar()
        End If
        CajaPrueba.Text = campo.Aleatorio()
    End Sub

End Class