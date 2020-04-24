' NumeracionSona.vb — ProInf.net — 29-feb-2012
'
' Enlaces:
'   http://es.wikipedia.org/wiki/Lengua_sona
'   http://www.rickharrison.com/language/sona4.html
'   http://www.languagesandnumbers.com/como-contar-en-sona/es/sona/
'
' Searight incorporó en su proyecto elementos semánticos y estructurales de diversos idiomas,
' entre ellos el japonés, el inglés, el turco, el chino, el ruso, el persa y el árabe,
' así como de las lenguas neolatinas.

Public Class NumeracionSona

    ' Ejemplos:
    '   0 = naci
    '   1 = enna
    '   10 = dici
    '   100 = son
    '   442 = ca-son ca-y-edi-do
    '   1000 = tan
    '   1001 = tan-y-enna
    '   1934 = tan nun-son tin-y-edi-ca
    '   10.000 = dici-tan
    '   100.000 = son-tan
    '   1.000.000 = tan-ta
    '   1.000.000.000 = do-tanta

    Public Shared Function Obtener(ByVal numero As Decimal) As String
        If numero = 0 Then Return unidades(0)
        Dim escalas() As String = DescomponerEnEscalas(numero)
        Dim resultado As String = Join(escalas, " ")
        Return resultado
    End Function

    Private Shared Function DescomponerEnEscalas(ByVal numero As Decimal) As String()
        Dim resultado As New List(Of String)
        For escala = 0 To escalas.Length - 1
            Dim valor As Integer = numero Mod 1000
            If valor > 0 Then
                resultado.Insert(0, ObtenerEscala(valor, escala))
            End If
            numero \= 1000
            If numero = 0 Then Exit For
        Next
        Return resultado.ToArray()
    End Function

    Private Shared Function ObtenerEscala(
        ByVal valor As Integer,
        ByVal escala As Integer
    ) As String
        If escala = 0 Then
            Return ObtenerCentenas(valor)
        ElseIf valor = 1 Then
            Return escalas(escala)
        Else
            Return String.Format("{0}{1}",
                ObtenerCentenas(valor),
                escalas(escala))
        End If
    End Function

    '0..999
    Private Shared Function ObtenerCentenas(ByVal valor As Integer) As String
        Dim cociente = valor \ 100
        Dim resto = valor Mod 100
        If cociente = 0 Then
            Return ObtenerDecenas(resto)
        ElseIf resto = 0 Then
            Return ExtraerCentena(cociente)
        Else
            Return String.Format("{0} {1}",
                ExtraerCentena(cociente),
                ObtenerDecenas(resto))
        End If
    End Function

    Private Shared Function ExtraerCentena(ByVal digito As Integer) As String
        If digito = 1 Then
            Return "son"
        ElseIf digito <= 9 Then
            Return unidades(digito) & "son"
        Else
            Return ""
        End If
    End Function

    '0..99
    Private Shared Function ObtenerDecenas(ByVal valor As Integer) As String
        Dim cociente = valor \ 10
        Dim resto = valor Mod 10
        If resto = 0 Then
            Return ExtraerDecena(cociente)
        ElseIf cociente = 0 Then
            Return unidades(resto)
        ElseIf cociente = 1 Then
            Return unidades(resto) & ExtraerDecena(cociente)
        Else
            Return ExtraerDecena(cociente) & unidades(resto)
        End If
    End Function

    '10*1..10*9
    Private Shared Function ExtraerDecena(ByVal digito As Integer) As String
        If digito = 1 Then
            Return "dici"
        ElseIf digito <= 9 Then
            Return unidades(digito) & "yedi"
        Else
            Return ""
        End If
    End Function

    ' Los guiones no se ponen
    '
    ' 0 = naci   10 = dici
    ' 1 = enna   11 = enna-dici   10 = dici        21 = doyedi-enna   100 = son
    ' 2 = do     12 = do-dici     20 = do-y-edi    22 = doyedi-do     200 = do-son
    ' 3 = tin    13 = tin-dici    30 = tin-y-edi   23 = doyedi-tin    300 = tin-son
    ' 4 = ca     14 = ca-dici     40 = can-y-edi   24 = doyedi-ca     400 = ca-son
    ' 5 = pen    15 = pen-dici    50 = pen-y-edi   25 = doyedi-pen    500 = pen-son
    ' 6 = xi     16 = xi-dici     60 = xi-y-edi    26 = doyedi-xi     600 = xi-son
    ' 7 = zun    17 = zun-dici    70 = zun-y-edi   27 = doyedi-zun    700 = zun-son
    ' 8 = atu    18 = atu-dici    80 = atu-y-edi   28 = doyedi-atu    800 = atu-son
    ' 9 = nun    19 = nun-dici    90 = nun-y-edi   29 = doyedi-nun    900 = nun-son

    '0..9
    Private Shared unidades = {
        "naci", "enna", "do", "tin", "ca", "pen", "xi", "zun", "atu", "nun"}

    '1 10 100 1000
    Private Shared potencias = {"", "dici", "son", "tan"}

    'Escala corta: 1 10^3 10^6 10^9
    Private Shared escalas = {"", "tan", "tanta", "dotanta"}

End Class


