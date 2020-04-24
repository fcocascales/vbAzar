' Permanencia.vb — ProInf.net — feb-2012
' 
' Guardar campos definidos por el usuario en un archivo
' al estilo .INI o YAML

Imports System.IO

'Ejemplo del archivo ".ini"
'----------
'#comentario
'Clave:
'   Valor1
'   Valor2
'----------
Public Class Permanencia
    Private salida As StreamWriter = Nothing
    Private entrada As StreamReader = Nothing

    '--------------------------------------------
    ' INTERFAZ

    Public Property Diccionario As New Dictionary(Of String, List(Of String))

    Public Sub Agregar(ByVal clave As String, ByVal ParamArray valores() As String)
        Dim lista As New List(Of String)
        For Each valor In valores
            lista.Add(valor)
        Next
        Diccionario.Add(clave, lista)
    End Sub

    Public Sub Agregar(ByVal clave As String, ByVal valores As IEnumerable)
        Dim lista As New List(Of String)
        For Each valor In valores
            lista.Add(valor.ToString())
        Next
        Diccionario.Add(clave, lista)
    End Sub

    Public Function Obtener(ByVal clave As String, ByRef valores As IEnumerable) As Boolean
        Try
            valores = Diccionario.Item(clave)
            Return True
        Catch ex As KeyNotFoundException
            DialogoError(ex, "clave=" & clave)
            Return False
        End Try
    End Function

    Public Function Obtener(ByVal clave As String, ByRef valor As String) As Boolean
        Try
            valor = Diccionario.Item(clave)(0)
            Return True
        Catch ex As ArgumentOutOfRangeException
            Return False
        Catch ex As KeyNotFoundException
            DialogoError(ex, "clave=" & clave)
            Return False
        End Try
    End Function

    Public Function Escribir() As Boolean
        Try
            CopiaRespaldo()
            salida = New StreamWriter(ObtenerRuta(), append:=False)
            EscribirDiccionario()
            Return True
        Catch ex As Exception
            'DialogoError(ex, "No puedo escribir la permanencia")
            Return False
        Finally
            If salida IsNot Nothing Then salida.Close()
        End Try
    End Function

    Public Function Leer() As Boolean
        Try
            entrada = New StreamReader(ObtenerRuta())
            LeerDiccionario()
            Return True
        Catch ex As Exception
            'DialogoError(ex, "No puede leer la permanencia")
            Return False
        Finally
            If entrada IsNot Nothing Then entrada.Close()
        End Try
    End Function

    Private Sub CopiaRespaldo()
        Dim ruta = ObtenerRuta()
        Dim respaldo = Path.ChangeExtension(ruta, ".bak")
        If File.Exists(respaldo) Then File.Delete(respaldo)
        If File.Exists(ruta) Then File.Move(ruta, Path.ChangeExtension(ruta, ".bak"))
    End Sub

    Public Overridable Function ObtenerRuta() As String
        Return Path.ChangeExtension(Application.ExecutablePath, ".ini")
    End Function

    '--------------------------------------------
    ' PRIVADO

    Private Sub EscribirDiccionario()
        EscribirEncabezado()
        Dim enumerador As IDictionaryEnumerator = Diccionario.GetEnumerator()
        Do While enumerador.MoveNext()
            salida.WriteLine("{0}:", enumerador.Key)
            For Each valor In enumerador.Value
                salida.WriteLine("{0}{1}", vbTab, valor)
            Next
            salida.WriteLine()
        Loop
    End Sub

    Private Sub EscribirEncabezado()
        salida.WriteLine("# {0} — {1}",
            Path.GetFileName(ObtenerRuta()),
            Date.Now.ToString("yyyy-MM-dd HH:mm:ss"))
        salida.WriteLine()
    End Sub

    Private Sub LeerDiccionario()
        Diccionario.Clear()
        Dim clave As String = ""
        Dim valores As New List(Of String)
        Do Until entrada.EndOfStream
            Dim linea = entrada.ReadLine()
            Dim elemento = linea.Trim()
            If elemento.Length = 0 OrElse elemento.StartsWith("#") Then
                'Ignorar líneas vacía y comentarios
            ElseIf Char.IsWhiteSpace(linea(0)) Then
                valores.Add(elemento)
            ElseIf elemento.EndsWith(":") Then
                AgregarAlDiccionario(clave, valores)
                clave = linea.Substring(0, elemento.Length - 1)
            End If
        Loop
        AgregarAlDiccionario(clave, valores)
    End Sub

    Private Sub AgregarAlDiccionario(
        ByRef clave As String,
        ByRef valores As List(Of String)
    )
        If clave <> "" Then
            Diccionario.Add(clave, valores)
            clave = ""
            valores = New List(Of String)
        End If
    End Sub

End Class

