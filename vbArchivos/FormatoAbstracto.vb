' FormatoAbstracto.vb — ProInf.net — feb-2012
'
' Clase base de los archivos para exportar 
'  a los formatos: CSV, XML, HTML, etc.

Imports System.IO

Public MustInherit Class FormatoAbstracto

    Public Property Ruta As String
    Protected fichero As StreamWriter

    Public Sub Inicio()
        AbrirFichero()
        InicioDocumento()
    End Sub

    Public Sub Fin()
        FinDocumento()
        CerrarFichero()
    End Sub

    '--------------------------------------------
    ' Gestión del archivo

    Private Sub AbrirFichero()
        fichero = New StreamWriter(Ruta, append:=False)
    End Sub

    Private Sub CerrarFichero()
        fichero.Close()
    End Sub

    Protected Sub Escribir(ByVal texto As String)
        fichero.Write(texto)
    End Sub

    Protected Sub EscribirLinea(Optional ByVal texto As String = "")
        fichero.WriteLine(texto)
    End Sub

    Protected Function ObtenerNombreTabla() As String
        Dim nombre = System.IO.Path.GetFileNameWithoutExtension(Ruta)
        Return Utilidades.SimplificarNombre(nombre)
    End Function

    '--------------------------------------------
    ' Para implementar en las clases descendientes

    Protected Overridable Sub InicioDocumento()
    End Sub

    Protected Overridable Sub FinDocumento()
    End Sub

    Public Overridable Sub EscribirMetadatos(ByVal campos As ICampo())
    End Sub

    Public Overridable Sub EscribirTitulos(ByVal titulos As String())
    End Sub

    Public Overridable Sub EscribirValores(ByVal valores As String())
    End Sub

    Public Overridable Function ObtenerExtension() As String
        Dim clase As String = Me.GetType().Name
        Return "." & clase.Substring("Archivo".Length).ToLower()
    End Function

End Class