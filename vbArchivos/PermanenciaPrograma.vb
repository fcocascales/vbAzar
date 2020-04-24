' PermanenciaForm.vb — ProInf.net — feb-2012
' 
' Guardar datos del programa al finalizar el mismo,
' para restaurarlos al abrir de nuevo el programa

Public Class PermanenciaPrograma
    Inherits Permanencia

    Public Function Guardar() As Boolean
        Try
            Diccionario.Clear()
            PonerEnFormulario()
            Return Escribir()
        Catch ex As Exception
            DialogoError(ex)
            Return False
        End Try
    End Function

    Public Function Restaurar() As Boolean
        Try
            If Leer() Then
                ObtenerDesdeFormulario()
                Return True
            End If
        Catch ex As Exception
            DialogoError(ex)
        End Try
        Return False
    End Function

    '--------------------------------------------
    ' Datos en el formulario FormGenerar

    Private Sub PonerEnFormulario()
        With FormGenerar
            Agregar("PropiedadesFormulario", {.Width, .Height})
            Agregar("ArchivoDestino", .CajaArchivo.Text)
            Agregar("TotalFactor", .CajaTotalFactor.SelectedIndex)
            Agregar("TotalPotencia", .CajaTotalPotencia.SelectedIndex)
            Agregar("FormatoArchivo", .CajaFormato.Text)
            Agregar("CamposDefinidos", .CajaCamposDefinidos.Items)
            Agregar("PredefinidosMarcados", .CajaCamposPredefinidos.CheckedIndices)
            Agregar("DefinidosMarcados", .CajaCamposDefinidos.CheckedIndices)
        End With
    End Sub

    Private Sub ObtenerDesdeFormulario()
        With FormGenerar
            AplicarPropiedadesFormulario(FormGenerar, Diccionario("PropiedadesFormulario"))
            Obtener("ArchivoDestino", .CajaArchivo.Text)
            Obtener("TotalFactor", .CajaTotalFactor.SelectedIndex)
            Obtener("TotalPotencia", .CajaTotalPotencia.SelectedIndex)
            Obtener("FormatoArchivo", .CajaFormato.Text)
            RestaurarCamposDefinidos(.CajaCamposDefinidos, Diccionario("CamposDefinidos"))
            FormUtils.ChequearCajaLista(.CajaCamposPredefinidos, Diccionario("PredefinidosMarcados"))
            FormUtils.ChequearCajaLista(.CajaCamposDefinidos, Diccionario("DefinidosMarcados"))
        End With
    End Sub

    '--------------------------------------------
    ' Privado

    Private Sub AplicarPropiedadesFormulario(ByVal form As Form, ByVal propiedades As List(Of String))
        If propiedades.Count >= 2 Then
            form.Width = propiedades(0)
            form.Height = propiedades(1)
        End If
    End Sub

    Private Sub RestaurarCamposDefinidos(ByVal caja As CheckedListBox, ByVal campos As IEnumerable)
        caja.Items.Clear()
        For Each item In campos
            Dim campo = CampoDefinido.Instanciar(item)
            If campo IsNot Nothing Then caja.Items.Add(campo)
        Next
    End Sub

End Class
