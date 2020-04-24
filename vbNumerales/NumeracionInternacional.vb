' NumeracionInternacional.vb — ProInf.net — 1-mar-2012
'
' http://es.wikipedia.org/wiki/Sistema_Internacional_de_Unidades
' http://es.wikipedia.org/wiki/Escalas_numéricas_larga_y_corta
' 
' Numeración del sistema internacional
' Usa la escala numérica corta 
'
' Ejemplos (con gramo):
'  1 = un gramo
'  10 = diez gramos (un decagramo)
'  16 = dieciséis gramos (un decagramo y seis gramos)
'  23 = veintitrés gramos (dos decagramos y seis gramos)
'  178 = ciento setenta y ocho gramos (un hectogramo, siete decagramos y ocho gramos)
'  1.009 = un kilogramo y nueve gramos
'  2.456.089.001 = dos gigagramos, cuatro mil cincuenta y seis megagramos, ochenta y nueve kilogramos y un gramo
'  5.000.870.000.000 = cinco teragramos y ochocientos setenta megagramos

'================================================
' NUMERACIÓN INTERNACIONAL

Public Class NumeracionInternacional

    Private Shared _enCifras As NumeracionInternacionalEnCifras = Nothing
    Private Shared _enLetras As NumeracionInternacionalEnLetras = Nothing
    
    Public Shared Function ObtenerEnCifras(
        ByVal numero As Decimal,
        ByVal unidad As String,
        Optional ByVal unidadEnPlural As String = ""
    ) As String
        If _enCifras Is Nothing Then _enCifras = New NumeracionInternacionalEnCifras()
        _enCifras.UnidadEnSingular = unidad
        _enCifras.UnidadEnPlural = unidadEnPlural
        Return _enCifras.Obtener(numero)
    End Function

    Public Shared Function ObtenerEnLetras(
        ByVal numero As Decimal,
        ByVal unidad As String,
         Optional ByVal unidadEnPlural As String = "",
        Optional ByVal esFemenina As Boolean = False
    ) As String
        If _enLetras Is Nothing Then _enLetras = New NumeracionInternacionalEnLetras()
        _enLetras.UnidadEnSingular = unidad
        _enLetras.UnidadEnPlural = unidadEnPlural
        _enLetras.Femenina = esFemenina
        Return _enLetras.Obtener(numero)
    End Function

End Class

'================================================
' NUMERACIÓN INTERNACIONAL EN CIFRAS

Public Class NumeracionInternacionalEnCifras

    Public Property UnidadEnSingular As String
    Public Property UnidadEnPlural As String

    Public Overridable Function Obtener(ByVal numero As Decimal) As String
        PredeterminarUnidadEnPlural()
        If numero = 0 Then Return ObtenerValor(0, "")
        Dim resultados() As String = DescomponerEnEscalas(numero)
        Dim resultado As String = Join(resultados, ", ")
        Return InsertarConjuncion(resultado)
    End Function

    Protected Overridable Sub PredeterminarUnidadEnPlural()
        If UnidadEnPlural = "" And UnidadEnSingular <> "" Then
            UnidadEnPlural = UnidadEnSingular & "s"
        End If
    End Sub

    Protected Overridable Function InsertarConjuncion(ByVal texto As String) As String
        Dim posicion = texto.LastIndexOf(", ")
        If posicion > 0 Then
            texto = texto.Remove(posicion, 2).Insert(posicion, " y ")
        End If
        Return texto
    End Function

    Private Function DescomponerEnEscalas(ByVal numero As Decimal) As String()
        Dim resultado As New List(Of String)
        For i = 0 To array_escalas.Length - 1
            Dim valor As Integer = numero Mod 1000
            Dim prefijo = array_escalas(i)
            If valor > 0 Then
                resultado.Insert(0, ObtenerValor(valor, prefijo))
            End If
            numero \= 1000
            If numero = 0 Then Exit For
        Next
        Return resultado.ToArray()
    End Function

    Private Function ObtenerValor(
        ByVal valor As Integer,
        ByVal prefijo As String
    ) As String
        Dim cantidad = FormatearNumero(valor)
        Dim unidad = If(valor = 1, UnidadEnSingular, UnidadEnPlural)
        If unidad = "" Then unidad = "?"
        Return String.Format("{0} {1}{2}", cantidad, prefijo, unidad)
    End Function

    Protected Overridable Function FormatearNumero(ByVal numero As Integer) As String
        Return numero.ToString("#,##0")
    End Function

    '--------------------------------------------
    ' ARRAYS

    'Prefijos griegos entre 0  y 12
    Protected array_unidades As String() = {"", "mono", "bi", "tri", "tetra",
        "penta", "hexa", "hepta", "octa", "nona", "deca", "endeca", "duodeca"}

    'Potencias: 1, 10, 100, 1000
    Protected array_potencias As String() = {"", "deca", "hecto", "kilo"}

    'Escala corta: 1, 10^3, 10^6, 10^9, 10^12, 10^15, 10^18, 10^21, 10^24
    Protected array_escalas As String() = {"", "kilo", "mega", "giga", "tera",
                                           "peta", "exa", "zetta", "yotta"}

End Class

'================================================
' NUMERACIÓN INTERNACIONAL EN LETRAS

Public Class NumeracionInternacionalEnLetras
    Inherits NumeracionInternacionalEnCifras

    Public Property Femenina As Boolean

    Protected Overrides Function FormatearNumero(ByVal numero As Integer) As String
        If Femenina Then
            Return CifrasEnLetras.convertirCifrasEnLetrasFemeninas(numero)
        Else
            Return CifrasEnLetras.convertirCifrasEnLetras(numero)
        End If
    End Function

End Class
