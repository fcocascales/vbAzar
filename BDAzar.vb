' BDAzar.vb — ProInf.net — feb-2012
'
' Genaración de la base de datos al azar 
'  según los campos predefinidos (basados en cáldulo o datos estadísticos) y 
'  según los campos definidos por el usuario

Public Class BDAzar

    Public Property Predefinidos As String() = Nothing
    Public Property Definidos As CampoDefinido() = Nothing

    Public Property Campos As ICampo()
    Public Property Total As Integer
    Public Property Formato As FormatoAbstracto

    Public Event Progresando As Action(Of Double)
    Public Property Cancelar As Boolean

    Public Sub New()
    End Sub

    Public Sub Generar()
        Reiniciar()
        Formato.Inicio()
        Formato.EscribirMetadatos(Campos)
        Formato.EscribirTitulos(ObtenerTitulos())
        For contador = 1 To Total
            RaiseEvent Progresando(contador / Total)
            Formato.EscribirValores(ObtenerValores())
            If Cancelar Then Exit For
        Next
        Formato.Fin()
    End Sub

    Private Sub Reiniciar()
        ''Dim campoId As CampoId = Recursos.camposPredefinidos("id")
        ''campoId.Reiniciar()
        For Each campo In Campos
            If TypeOf campo Is IReiniciable Then
                Dim reiniciable As IReiniciable = campo
                reiniciable.Reiniciar()
            End If
        Next
        Cancelar = False
    End Sub

    Private Function ObtenerTitulos() As String()
        Dim lista As New List(Of String)
        For Each campo In Campos
            lista.Add(campo.Nombre)
        Next
        Return lista.ToArray()
    End Function

    Private Function ObtenerValores() As String()
        Dim lista As New List(Of String)
        For Each campo In Campos
            lista.Add(campo.Aleatorio())
        Next
        Return lista.ToArray()
    End Function

    '--------------------------------------------
    ' GUIÓN

    Public Shared Function EjecutarGuion(ByVal guion As String) As Boolean
        DialogoAviso("En obras")
        Return False
    End Function

End Class


