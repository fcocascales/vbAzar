' NumeracionInterlingua.vb — ProInf.net — 29-feb-2012
'
' Enlaces:
'   www.languagesandnumbers.com/como-contar-en-interlingua/es/ina/
'
' La interlingua es una lengua auxiliar internacional desarrollada entre 1937 y 1951 por 
' la International Auxiliary Language Association (IALA), 
' cuyo objetivo fue determinar cual lengua auxiliar era la más adecuada para la comunicación internacional, 
' pero acabó desarrollando un lenguaje propio con la ayuda de Alexander Gode. 
' Es una lengua auxiliar naturalista, o una lengua a posteriori, 
' porque basada en lenguajes naturales (es decir alemán, español, francés, inglés, italiano, latín, 
' portugués y ruso).

Public Class NumeracionInterlingua

    ' Ejemplos:
    '   12 = dece-duo
    '   25 = vinti-cinque
    '   79 = septanta-nove
    '   100 = cento
    '   137 = cento tresanta-septe
    '   200 = duo centos
    '   596 = cinque centos novanta-sex
    '   1000 = mille
    '   5000 = cinque milles
    '   11.111 =  dece-un milles cento dece-un
    '   1.000.000 = un million
    '   9.999.999 = nove milliones nove centos novanta-nove milles nove centos novanta-nove

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
        Else
            If valor = 1 Then
                If escala = 1 Then
                    Return escalas(escala)
                Else
                    Return String.Format("{0} {1}",
                        unidades(valor), escalas(escala))
                End If
            Else
                Return String.Format("{0} {1}",
                    ObtenerCentenas(valor), EnPlural(escalas(escala)))
            End If
        End If
    End Function

    '0..999
    Private Shared Function ObtenerCentenas(ByVal valor As Integer) As String
        Dim cociente = valor \ 100
        Dim resto = valor Mod 100
        If cociente = 0 Then
            Return ObtenerDecenas(resto)
        ElseIf resto = 0 Then
            Return ExtraerCentenas(cociente, potencias(2))
        Else
            Return String.Format("{0} {1}",
                ExtraerCentenas(cociente, potencias(2)),
                ObtenerDecenas(resto))
        End If
    End Function

    Private Shared Function ExtraerCentenas(
        ByVal valor As Integer, ByVal sufijo As String
    ) As String
        If valor = 1 Then
            Return sufijo
        Else
            Return String.Format("{0} {1}", unidades(valor), EnPlural(sufijo))
        End If
    End Function

    '0..99
    Private Shared Function ObtenerDecenas(ByVal valor As Integer) As String
        Dim cociente = valor \ 10
        Dim resto = valor Mod 10
        If cociente = 0 Then
            Return unidades(resto)
        ElseIf resto = 0 Then
            Return decenas(cociente)
        Else
            Return String.Format("{0}-{1}", decenas(cociente), unidades(resto))
        End If
    End Function

    Protected Shared Function EnPlural(ByVal texto As String) As String
        If AcabaEnVocal(texto) Then
            Return texto & "s"
        Else
            Return texto & "es"
        End If
    End Function

    Protected Shared Function AcabaEnVocal(ByVal texto As String) As String
        Return "aeiou".Contains(texto(texto.Length - 1))
    End Function

    '0..9
    Private Shared unidades = {
        "zero", "un", "duo", "tres", "quatro", "cinque", "sex", "septe", "octo", "nove"}

    '0, 10..90
    Private Shared decenas = {"", "dece", "vinti", "tresanta", "quaranta", "cinquanta",
        "sexanta", "septanta", "octanta", "novanta"}

    '1 10 100 1000 
    Private Shared potencias = {"", "dece", "cento", "mille"}

    'Escala corta: 1 10^3 10^6 10^9 10^12 10^15 10^18 10^21
    Private Shared escalas = {"", "mille",
        "million", "milliardo",
        "billion", "billiardo",
        "trillion", "trilliardo"}

End Class


