' Utilidades.vb — ProInf.net — feb-2012
'
' Funciones de ámbito general 

Public Class Utilidades

    Public Shared Function Capitalizar(ByVal texto As String) As String
        If texto <> "" Then texto = texto.Substring(0, 1).ToUpper & texto.Substring(1).ToLower()
        Return texto
    End Function

    Public Shared Function CalcularEdad(ByVal fecha As Date) As Integer
        Dim años As Integer = Date.Today.Year - fecha.Year
        Dim cumpleaños As Date = New Date(Date.Today.Year, fecha.Month, fecha.Day)
        If Date.Today < cumpleaños Then años -= 1
        Return años
    End Function

    Public Shared Function CodificarHTML(ByVal text As String) As String
        If text Is Nothing Then
            Return ""
        Else
            Return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")
        End If
    End Function

    Public Shared Function ObtenerEntero(ByVal texto As String) As Integer
        Dim entero As Integer = 0
        Integer.TryParse(texto, entero)
        Return entero
    End Function

    Public Shared Function ObtenerDecimal(ByVal texto As String) As Decimal
        Dim numero As Decimal = 0
        Decimal.TryParse(texto, numero)
        Return numero
    End Function

    Public Shared Function FechaSQL(ByVal fecha As Date) As String
        Return fecha.ToString("yyyy-MM-dd")
    End Function

    Public Shared Function SimplificarNombre(ByVal nombre As String) As String
        nombre = nombre.Trim().ToLower()
        nombre = nombre.Replace(" ", "_")
        nombre = QuitarAcentos(nombre)
        nombre = DejarAlfanumerico(nombre)
        Return nombre
    End Function

    Public Shared Function DejarAlfanumerico(ByVal texto As String) As String
        Dim re = New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9-ñÑ]")
        Return re.Replace(texto, "")
    End Function

    Public Shared Function QuitarAcentos(ByVal texto As String) As String
        Const VOCALES = "aeiouAEIOU"
        Const ACENTUADAS = "áéíóúÁÉÍÓÚàèìòùÀÈÌÒÙ"
        Dim caracteres = texto.ToArray()
        For i = 0 To caracteres.Length - 1
            Dim posicion = ACENTUADAS.IndexOf(caracteres(i))
            If posicion >= 0 Then
                caracteres(i) = VOCALES(posicion Mod 10)
            End If
        Next
        Return New String(caracteres)
    End Function

    Public Shared Function NumeroPalabras(ByVal frase As String) As Integer
        Dim numeroCaracteres = frase.Length
        Dim numeroCaracteresSinEspacios = frase.Replace(" ", "").Length
        Return numeroCaracteres - numeroCaracteresSinEspacios + 1
    End Function

    Public Shared Function RecortarComillas(ByVal texto As String) As String
        Const CARACTERES = "'"""
        If CARACTERES.Contains(texto(0)) Then
            texto = texto.Substring(1)
        End If
        If CARACTERES.Contains(texto(texto.Length - 1)) Then
            texto = texto.Substring(0, texto.Length - 1)
        End If
        Return texto
    End Function


End Class

