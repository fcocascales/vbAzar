' NumeracionLatin.vb — ProInf.net — 29-feb-2012
' 
' El latín es una lengua itálica de la familia de las lenguas indoeuropeas. 
' Aunque definida como muerta, todavía es uno de los idiomas co-oficiales del Vaticano 
' (junto con el alemán, el francés y el italiano). 
' Hablada en la antigua República Romana y el Imperio romano, del siglo II a. C. al siglo II d. C., 
' perduró durante la Edad Media.
'
' http://www.wikiteka.com/apuntes/los-numeros-en-latin/
' http://www.languagesandnumbers.com/como-contar-en-latin/es/lat/

Public Class NumeracionLatin
    Private Shared _enNeutro As NumeracionLatinNeutro = Nothing
    Private Shared _enMasculino As NumeracionLatinMasculino = Nothing
    Private Shared _enFemenino As NumeracionLatinFemenino = Nothing

    Public Shared Function ObtenerEnNeutro(ByVal numero As Decimal) As String
        If _enNeutro Is Nothing Then _enNeutro = New NumeracionLatinNeutro()
        Return _enNeutro.Obtener(numero)
    End Function

    Public Shared Function ObtenerEnMasculino(ByVal numero As Decimal) As String
        If _enMasculino Is Nothing Then _enMasculino = New NumeracionLatinMasculino()
        Return _enMasculino.Obtener(numero)
    End Function

    Public Shared Function ObtenerEnFemenino(ByVal numero As Decimal) As String
        If _enFemenino Is Nothing Then _enFemenino = New NumeracionLatinFemenino()
        Return _enFemenino.Obtener(numero)
    End Function
End Class

'================================================
' NUMERACIÓN LATIN MASCULINO

Public Class NumeracionLatinMasculino

    'Rango entre 0 y 999.999

    ' Ejemplos:
    ' 54 = quinquaginta quattuor
    ' 99 = undecentum
    ' 100 = centum
    ' 199 = centum undecentum
    ' 399 = trecenti undecentum
    ' 400 = quadringenti
    ' 576 = quingenti septuaginta sex
    ' 988 = nongenti duodenonaginta
    ' 998 = nongenti nonaginta octo
    ' 999 = nongenti undecentum
    ' 1000 = mille
    ' 1999 = mille nongenti undecentum
    ' 2000 = duo milia
    ' 4320 = quattuor milia trecenti viginti
    ' 9999 = novem milia nongenti undecentum

    Public Function Obtener(ByVal numero As Integer) As String
        If numero >= 0 And numero <= 999999 Then
            Return ObtenerMiles(numero)
        Else
            Return "?"
        End If
    End Function

    '0..999.999
    Protected Function ObtenerMiles(ByVal numero As Integer) As String
        Dim miles As Integer = numero \ 1000
        Dim resto As Integer = numero Mod 1000
        If miles = 0 Then
            Return ObtenerCentenas(resto)
        ElseIf resto = 0 Then
            Return ObtenerMillares(miles)
        Else
            Return String.Format("{0} {1}",
                ObtenerMillares(miles), ObtenerCentenas(resto))
        End If
    End Function

    Private Function ObtenerMillares(ByVal cantidad As Integer) As String
        If cantidad = 1 Then
            Return "mille"
        Else
            Return String.Format("{0} milia",
                ObtenerCentenas(cantidad))
        End If
    End Function

    '0..999
    Protected Function ObtenerCentenas(ByVal numero As Integer) As String
        Dim centenas As Integer = numero \ 100
        Dim resto As Integer = numero Mod 100
        If centenas = 0 Then
            Return ObtenerDecenas(resto)
        ElseIf resto = 0 Then
            Return _centenas(centenas)
        Else
            Return String.Format("{0} {1}",
                _centenas(centenas), ObtenerDecenas(resto))
        End If
    End Function

    '0..99
    Protected Function ObtenerDecenas(ByVal numero As Integer) As String
        If numero >= 0 And numero <= 19 Then
            Return _unidades(numero)
        Else
            Dim decenas As Integer = numero \ 10
            Dim resto As Integer = numero Mod 10
            If resto = 0 Then
                Return _decenas(decenas)
            ElseIf resto = 8 And decenas <> 9 Then '98 es una excepción
                Return String.Format("duode{0}",
                    ObtenerSiguienteDecena(decenas))
            ElseIf resto = 9 Then
                Return String.Format("unde{0}",
                    ObtenerSiguienteDecena(decenas))
            Else
                Return String.Format("{0} {1}",
                    _decenas(decenas), ArrayUnidades(resto))
            End If
        End If
    End Function

    Protected Function ObtenerSiguienteDecena(ByVal decena As Integer) As String
        If decena <= 8 Then
            Return _decenas(decena + 1)
        Else
            Return "centum"
        End If
    End Function

    '0..19
    Private Shared _unidades = {"nulla", "unus", "duo", "tres", "quattuor",
        "quinque", "sex", "septem", "octo", "novem",
        "decem", "undecim", "duodecim", "tredecim", "quattuordecim",
        "quindecim", "sedecim", "septendecim", "duodeviginti", "undeviginti"}

    '0, 10..90
    Private Shared _decenas = {
        "", "decem", "viginti", "triginta", "quadraginta",
        "quinquaginta", "sexaginta", "septuaginta", "octoginta", "nonaginta"}

    '0, 100..900
    Private Shared _centenas = {
        "", "centum", "ducenti", "trecenti", "quadringenti",
        "quingenti", "sescenti", "septingenti", "octingenti", "nongenti"}

    Public Overridable Function ArrayUnidades(ByVal numero As Integer) As String
        Return _unidades(numero)
    End Function

End Class

'================================================
' NUMERACIÓN LATIN NEUTRO

Public Class NumeracionLatinNeutro
    Inherits NumeracionLatinMasculino

    Public Overrides Function ArrayUnidades(ByVal numero As Integer) As String
        Select Case numero
            Case 1 : Return "unum"
            Case 2 : Return "duo"
            Case 3 : Return "tria"
            Case Else : Return MyBase.ArrayUnidades(numero)
        End Select
    End Function

End Class

'================================================
' NUMERACIÓN LATIN FEMENINO

Public Class NumeracionLatinFemenino
    Inherits NumeracionLatinMasculino

    Public Overrides Function ArrayUnidades(ByVal numero As Integer) As String
        Select Case numero
            Case 1 : Return "una"
            Case 2 : Return "duae"
            Case 3 : Return "tres"
            Case Else : Return MyBase.ArrayUnidades(numero)
        End Select
    End Function

End Class