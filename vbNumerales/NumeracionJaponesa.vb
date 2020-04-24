' NumeracionJaponesa.vb — ProInf.net — 26-feb-2012
'
' http://es.wikipedia.org/wiki/Numeración_japonesa

Public Class NumeracionJaponesa

    'Ejemplos:
    ' 11 = jū-ichi
    ' 17 = jū-nana
    ' 151 = hyaku go-jū ichi
    ' 302 = san-hyaku ni
    ' 469 = yon-hyaku roku-jū kyū
    ' 2025 = ni-sen ni-jū go
    ' 1'0000 = ichi-man
    ' 983'6703 = kyū-hyaku hachi-jū san man roku-sen nana-hyaku san
    ' 20'3652'1801 = ni-jū oku san-zen rop-pyaku go-jū ni-man sen hap-pyaku ichi
    ' 10'0000 = jū-man 

    ' 0..9
    Private Shared unidades As String() = {
        "zero", "ichi", "ni", "san", "yon", "go", "roku", "nana", "hachi", "kyū"
    }

    'Potencia: 1, 10, 100, 1000
    Private Shared potencias As String() = {
        "", "jū", "hyaku", "sen"
    }

    'Miriadas: 10^0, 10^4, 10^8, 10^12,... 10^72
    Private Shared escalas As String() = {
        "", "man", "oku", "chō", "kei", "gai", "jo", "jō", "kō", "kan", "sei", "sai",
        "goku", "gōgasha", "asōgi", "nayuta", "fukashigi", "muryō", "taisū"
    }

    Private Shared modificaciones As New ModificacionesFoneticas()

    Private Class ModificacionesFoneticas
        Inherits Dictionary(Of String, String)
        Public Sub New()
            Add("san-hyaku", "sanbyaku") '300
            Add("roku-hyaku", "roppyaku") '600
            Add("hachi-hyaku", "happyaku") '800
            Add("san-sen", "sanzen") '3000
            Add("hachi-sen", "hassen") '8000
        End Sub
        Public Function Reemplazar(ByVal texto As String) As String
            Dim enumerador As IDictionaryEnumerator = Me.GetEnumerator()
            Do While enumerador.MoveNext()
                texto = texto.Replace(enumerador.Key, enumerador.Value)
            Loop
            Return texto
        End Function
    End Class

    Public Shared Function Obtener(ByVal numero As Integer) As String
        If numero = 0 Then Return unidades(0)

        Dim resultado As New System.Text.StringBuilder()
        Dim potenciaMiriada As Integer = 0

        Do While numero > 0
            Dim miriada = numero Mod 10000

            If resultado.Length > 0 Then resultado.Insert(0, " ")
            If potenciaMiriada > 0 Then
                resultado.Insert(0, ObtenerEscala(potenciaMiriada))
                If miriada <= 10 Or miriada = 100 Or miriada = 1000 Then
                    resultado.Insert(0, "-")
                Else
                    resultado.Insert(0, " ")
                End If
            End If
            resultado.Insert(0, ObtenerMiriada(miriada))

            numero \= 10000
            potenciaMiriada += 1
        Loop
        Return resultado.ToString()
    End Function

    'Número entre 1 y 9999
    Public Shared Function ObtenerMiriada(ByVal numero As Integer) As String
        Dim resultado As New System.Text.StringBuilder()
        Dim potenciaDiez As Integer = 0

        Do While numero > 0
            Dim digitoDecimal = numero Mod 10

            If digitoDecimal <> 0 Then
                If potenciaDiez = 0 Then
                    resultado.Insert(0, ObtenerUnidad(digitoDecimal))
                Else
                    If resultado.Length > 0 Then
                        If potenciaDiez = 1 And digitoDecimal = 1 Then
                            resultado.Insert(0, "-")
                        Else
                            resultado.Insert(0, " ")
                        End If
                    End If
                    resultado.Insert(0, ObtenerPotencia(potenciaDiez))
                    If digitoDecimal > 1 Then
                        resultado.Insert(0, "-")
                        resultado.Insert(0, ObtenerUnidad(digitoDecimal))
                    End If
                End If
            End If

            numero \= 10
            potenciaDiez += 1
        Loop
        Return modificaciones.Reemplazar(resultado.ToString())
    End Function

    Private Shared Function ObtenerUnidad(ByVal digito As Integer) As String
        If digito >= 1 And digito <= 9 Then
            Return unidades(digito)
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerPotencia(ByVal potencia As Integer) As String
        If potencia >= 0 And potencia <= potencias.Length Then
            Return potencias(potencia)
        Else
            Return "?"
        End If
    End Function

    Private Shared Function ObtenerEscala(ByVal escala As Integer) As String
        If escala >= 0 And escala <= escalas.Length Then
            Return escalas(escala)
        Else
            Return "?"
        End If
    End Function

End Class

'Public Class Alfajapones
'    Private Shared japones = {"Ē", "Bī", "Shī", "Dī", "Ī", "Efu",
'        "Jī", "Eichi", "Ai", "Jē", "Kē", "Eru", "Emu", "Enu", "Ō",
'        "Pī", "Kyū", "Āru", "Esu", "Tī", "Yū", "Vi", "Daburyū",
'        "Ekkusu", "Wai", "Zetto"}
'End Class