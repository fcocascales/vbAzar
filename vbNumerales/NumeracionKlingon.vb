' NumeracionKlingon.vb — ProInf.net — 29-feb-2012

Public Class NumeracionKlingon

    'Rango entre 0 y 9.999.999

    'http://www.languagesandnumbers.com/como-contar-en-klingon/es/tlh/

    ' Ejemplos:
    ' 10 = wa’maH
    ' 11 = wa’maH wa’ 
    ' 20 = cha’maH
    ' 30 = wejmaH
    ' 75 = SochmaH vagh 
    ' 800 = chorghvatlh 
    ' 50000 = vaghnetlh 

    Public Shared Function Obtener(ByVal numero As Decimal) As String
        If numero >= 0 And numero <= 9999999 Then
            If numero = 0 Then Return unidades(0)
            Dim resultados() As String = DescomponerEnPotencias(numero)
            Dim resultado As String = Join(resultados, " ")
            Return resultado
        Else
            Return "?"
        End If
    End Function

    Private Shared Function DescomponerEnPotencias(ByVal numero As Decimal) As String()
        Dim resultado As New List(Of String)
        For i = 0 To sufijos_potencias.Length - 1
            Dim valor As Integer = numero Mod 10
            Dim sufijo = sufijos_potencias(i)
            If valor > 0 Then
                resultado.Insert(0, ObtenerValor(valor, sufijo))
            End If
            numero \= 10
            If numero = 0 Then Exit For
        Next
        Return resultado.ToArray()
    End Function

    Private Shared Function ObtenerValor(
        ByVal valor As Integer,
        ByVal sufijo As String
    ) As String
        Dim unidad = unidades(valor)
        Return String.Format("{0}{1}", unidad, sufijo)
    End Function

    '0..9 
    Private Shared unidades = {"pagh", "wa’", "cha’", "wej", "loS",
        "vagh", "jav", "Soch", "chorgh", "Hut"}

    '1, 10, 100, 1000, 10.000, 100.000, 1.000.000
    Private Shared sufijos_potencias = {
        "", "maH", "vatlh", "SaD", "netlh", "bIp", "’uy’"
    }

End Class
