' NumeracionOrdinal.vb — ProInf.net — 4-mar-2012
'
' http://es.wikipedia.org/wiki/Número_ordinal
'
'En número ordinal es un número que denota la posición de un elemento 
' perteneciente a una sucesión ordenada

'================================================
' NUMERACIÓN ORDINAL

Public Class NumeracionOrdinal

    Private Shared _enNeutro As NumeracionOrdinalEnNeutro = Nothing
    Private Shared _enMasculino As NumeracionOrdinalEnMasculino = Nothing
    Private Shared _enFemenino As NumeracionOrdinalEnFemenino = Nothing

    Private Shared _palabra As String = ""
    Private Shared _femenina As Boolean

    Public Shared Sub Apalabrar(ByVal palabra As String, ByVal esFemenina As Boolean)
        _palabra = palabra
        _femenina = esFemenina
    End Sub

    Public Shared Function Obtener(ByVal numero As Decimal) As String
        If _palabra = "" Then
            Return ObtenerEnMasculino(numero)
        Else
            Dim ordinal As String
            If _femenina Then
                ordinal = ObtenerEnFemenino(numero)
            Else
                ordinal = ObtenerEnNeutro(numero)
            End If
            Return String.Format("{0} {1}", ordinal, _palabra)
        End If
    End Function

    Public Shared Function ObtenerEnNeutro(ByVal numero As Decimal) As String
        If _enNeutro Is Nothing Then _enNeutro = New NumeracionOrdinalEnNeutro()
        Return _enNeutro.Obtener(numero)
    End Function

    Public Shared Function ObtenerEnMasculino(ByVal numero As Decimal) As String
        If _enMasculino Is Nothing Then _enMasculino = New NumeracionOrdinalEnMasculino()
        Return _enMasculino.Obtener(numero)
    End Function

    Public Shared Function ObtenerEnFemenino(ByVal numero As Decimal) As String
        If _enFemenino Is Nothing Then _enFemenino = New NumeracionOrdinalEnFemenino()
        Return _enFemenino.Obtener(numero)
    End Function
    
End Class

'================================================
' NUMERACIÓN ORDINAL EN NEUTRO

Public Class NumeracionOrdinalEnNeutro

    'Ejemplos:
    ' 123 = tricentésimo vigésimo tercero
    ' 1.111 = milésimo, centésimo undécimo
    ' 2.050 = segundo milésimo, quincuagésimo
    ' 17.290 = decimoséptimo milésimo, ducentésimo nonagésimo
    ' 3.010.200.045 = tercer milésimo, décimo millonésimo; ducentésimo milésimo, cuadragésimo quinto
    ' 12 veces 9 = noningentésimo nonagésimo noveno milésimo, 
    '              noningentésimo nonagésimo noveno millonésimo;
    '              noningentésimo nonagésimo noveno milésimo,
    '              noningentésimo nonagésimo noveno.

    Public Function Obtener(ByVal numero As Decimal) As String
        Return ObtenerMillones(numero)
    End Function

    'Entre 1 y 999.999.999.999
    Private Function ObtenerMillones(ByVal numero As Decimal) As String
        If numero >= 1 And numero <= 999999999999 Then
            Dim cociente As Decimal = numero \ 1000000
            Dim resto As Decimal = numero Mod 1000000
            If cociente = 0 Then
                Return ObtenerMiles(resto)
            ElseIf resto = 0 Then
                Return ObtenerMillonesimos(cociente)
            Else
                Return String.Format("{0} {1}",
                    ObtenerMillonesimos(cociente), ObtenerMiles(resto))
            End If
        Else
            Return ""
        End If
    End Function

    Private Function ObtenerMillonesimos(ByVal cantidad As Integer) As String
        If cantidad = 1 Then
            Return ArrayPotencias(2)
        Else
            Return String.Format("{0} {1}",
                ObtenerMiles(cantidad, neutral:=True), ArrayPotencias(2))
        End If
    End Function

    'Entre 1 y 999.999
    Private Function ObtenerMiles(ByVal numero As Integer,
        Optional ByVal neutral As Boolean = False
    ) As String
        If numero >= 1 And numero <= 999999 Then
            Dim cociente As Integer = numero \ 1000
            Dim resto As Integer = numero Mod 1000
            If cociente = 0 Then
                Return ObtenerCentenas(resto, neutral)
            ElseIf resto = 0 Then
                Return ObtenerMilesimos(cociente)
            Else
                Return String.Format("{0} {1}",
                    ObtenerMilesimos(cociente), ObtenerCentenas(resto, neutral))
            End If
        Else
            Return ""
        End If
    End Function

    Private Function ObtenerMilesimos(ByVal cantidad As Integer) As String
        If cantidad = 1 Then
            Return ArrayPotencias(1)
        Else
            Return String.Format("{0} {1}",
                ObtenerCentenas(cantidad, neutral:=True), ArrayPotencias(1))
        End If
    End Function

    'Entre 1 y 999
    Private Function ObtenerCentenas(ByVal numero As Integer, ByVal neutral As Boolean) As String
        If numero >= 1 And numero <= 999 Then
            Dim cociente As Integer = numero \ 100
            Dim resto As Integer = numero Mod 100
            If cociente = 0 Then
                Return ObtenerDecenas(resto, neutral)
            ElseIf resto = 0 Then
                Return ArrayCentenas(cociente)
            Else
                Return String.Format("{0} {1}",
                    ArrayCentenas(cociente), ObtenerDecenas(resto, neutral))
            End If
        Else
            Return ""
        End If
    End Function

    'Entre 1 y 99
    Private Function ObtenerDecenas(ByVal numero As Integer, ByVal neutral As Boolean) As String
        If numero >= 1 And numero <= 19 Then
            Return ObtenerUnidades(numero, neutral)
        ElseIf numero <= 99 Then
            Dim cociente = numero \ 10
            Dim resto = numero Mod 10
            If resto = 0 Then
                Return ArrayDecenas(cociente)
            Else
                Return String.Format("{0} {1}",
                    ArrayDecenas(cociente), ObtenerUnidades(resto, neutral))
            End If
        Else
            Return ""
        End If
    End Function

    'Entre 1 y 19
    Protected Overridable Function ObtenerUnidades(ByVal numero As Integer, ByVal neutral As Boolean)
        If neutral Then
            Return unidades(numero)
        Else
            Return ArrayUnidades(numero)
        End If
    End Function

    '--------------------------------------------
    ' IMPLEMENTACIÓN

    Private Shared unidades As String() = {"", "primer", "segundo", "tercer", "cuarto",
        "quinto", "sexto", "séptimo", "octavo", "noveno",
        "décimo", "undécimo", "duodécimo", "decimotercer", "decimocuarto",
        "decimoquinto", "decimosexto", "decimoséptimo", "decimoctavo", "decimonoveno"}

    Private Shared decenas As String() = {"", "décimo", "vigésimo", "trigésimo", "cuadragésimo",
        "quincuagésimo", "sexagésimo", "septuagésimo", "octogésimo", "nonagésimo"}

    Private Shared centenas As String() = {"", "centésimo", "ducentésimo", "tricentésimo", "cuadringentésimo",
        "quingentésimo", "sexcentésimo", "septingentésimo", "octingentésimo", "noningentésimo"}

    Private Shared potencias As String() = {"", "milésimo", "millonésimo"}

    Protected Overridable Function ArrayUnidades(ByVal numero As Integer) As String
        If numero >= 0 And numero < unidades.Length Then
            Return unidades(numero)
        Else
            Return ""
        End If
    End Function

    Protected Overridable Function ArrayDecenas(ByVal numero As Integer) As String
        If numero >= 0 And numero < decenas.Length Then
            Return decenas(numero)
        Else
            Return ""
        End If
    End Function

    Protected Overridable Function ArrayCentenas(ByVal numero As Integer) As String
        If numero >= 0 And numero < centenas.Length Then
            Return centenas(numero)
        Else
            Return ""
        End If
    End Function

    Protected Overridable Function ArrayPotencias(ByVal numero As Integer) As String
        If numero >= 0 And numero < potencias.Length Then
            Return potencias(numero)
        Else
            Return ""
        End If
    End Function

End Class

'================================================
' NUMERACIÓN ORDINAL EN MASCULINO

Public Class NumeracionOrdinalEnMasculino
    Inherits NumeracionOrdinalEnNeutro

    Protected Overrides Function ArrayUnidades(ByVal numero As Integer) As String
        Select Case numero
            Case 1 : Return "primero"
            Case 3 : Return "tercero"
            Case 13 : Return "decimotercero"
            Case Else : Return MyBase.ArrayUnidades(numero)
        End Select
    End Function

End Class

'================================================
' NUMERACIÓN ORDINAL EN FEMENINO

Public Class NumeracionOrdinalEnFemenino
    Inherits NumeracionOrdinalEnMasculino

    Protected Overrides Function ObtenerUnidades(ByVal numero As Integer, ByVal neutral As Boolean)
        Return ArrayUnidades(numero)
    End Function

    Protected Overrides Function ArrayUnidades(ByVal numero As Integer) As String
        Return EnFemenino(MyBase.ArrayUnidades(numero))
    End Function

    Protected Overrides Function ArrayDecenas(ByVal numero As Integer) As String
        Return EnFemenino(MyBase.ArrayDecenas(numero))
    End Function

    Protected Overrides Function ArrayCentenas(ByVal numero As Integer) As String
        Return EnFemenino(MyBase.ArrayCentenas(numero))
    End Function

    Protected Overrides Function ArrayPotencias(ByVal numero As Integer) As String
        Return EnFemenino(MyBase.ArrayPotencias(numero))
    End Function

    Private Shared Function EnFemenino(ByVal texto As String) As String
        If texto = "" Then Return ""
        Return texto.Substring(0, texto.Length - 1) & "a"
    End Function

End Class