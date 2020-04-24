' NumeracionEsperanto.vb — ProInf.net — 29-feb-2012
'
' Enlaces:
'   es.wikibooks.org/wiki/Esperanto/Gramática/Números
'   www.languagesandnumbers.com/como-contar-en-esperanto/es/epo/
'   mylanguages.org/es/esperanto_numeros.php
'
' El esperanto es una lengua auxiliar internacional inventada por Ludwik Łazarz Zamenhof en 1887. 
' Tiene por lo menos 100 000 hablantes muy activos, cerca de 2 millones de hablantes regulares
' y mil hablantes nativos. 
' Basado principalmente en un conjunto de idiomas europeos (alemán, francés, polaco y ruso), 
' está escrito en una versión modificada del alfabeto latino y es muy regular en su formación.
'

Public Class NumeracionEsperanto

    ' Ejemplos:
    '   10 = dek
    '   20 = dudek
    '   13 = dek tri
    '   20 = dudek
    '   25 = dukek kvin
    '   30 = tridek
    '   46 = kvardek ses
    '   100 = cent
    '   137 = cent tridek sep
    '   200 = ducent
    '   567 = kvincent sesdek sep
    '   1.000 = mil
    '   2.000 = dumil
    '   9.999.999 = naŭ miliono naŭcent naŭdek naŭmil naŭcent naŭdek naŭ

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
        If valor = 1 And escala >= 1 Then
            Return escalas(escala)
        Else
            Dim escalar = Join(DescomponerEnPotencias(valor), " ")
            Return String.Format("{0} {1}", escalar, escalas(escala))
        End If
    End Function

    Private Shared Function DescomponerEnPotencias(
        ByVal numero As Integer
    ) As String()
        Dim resultado As New List(Of String)
        For potencia = 0 To potencias.Length - 1
            Dim unidad As Integer = numero Mod 10
            If unidad > 0 Then
                resultado.Insert(0, ObtenerValor(unidad, potencia))
            End If
            numero \= 10
            If numero = 0 Then Exit For
        Next
        Return resultado.ToArray()
    End Function

    Private Shared Function ObtenerValor(
        ByVal unidad As Integer,
        ByVal potencia As Integer
    ) As String
        If unidad = 1 And potencia >= 1 Then
            Return potencias(potencia)
        Else
            Return String.Format("{0}{1}", unidades(unidad), potencias(potencia))
        End If
    End Function

    ' 0..9
    Protected Shared unidades = {
        "nul", "unu", "du", "tri", "kvar", "kvin", "ses", "sep", "ok", "naŭ"}

    ' 1, 10, 100, 1000
    Protected Shared potencias = {"", "dek", "cent", "mil"}

    ' Escala corta: 1, 10^3, 10^6, 10^9, 10^12, 10^15 .. 10^33
    ' eo.wikipedia.org/wiki/Vortoj_por_grandegaj_nombroj
    '
    Protected Shared escalas = {"", "mil",
        "miliono", "miliardo",
        "duiliono", "duiliardo",
        "triiliono", "triiliardo",
        "kvariliono", "kvariliardo",
        "kviniliono", "kviniliardo"}

End Class

