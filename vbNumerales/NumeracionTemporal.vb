' NumeracionTemporal.vb — ProInf.net — 2-mar-2012
'
' Clases: 
'   NumeracionTemporal (shared)
'   NumeracionTemporalEnLetras
'   NumeracionTemporalEnCifras
'
' Requisitos:
'   La clase "CifrasEnLetras"
'
' Enlaces:
'   http://es.wikipedia.org/wiki/Sistemas_de_tiempo
'
' Ejemplos:
'   cinco días = 5
'   cuatro meses, dos semanas y tres días = 4*30 + 2*7 + 3
'   un semestre = 6*30 
'   dos años y un día = 2*365+1
'   un lustro y tres meses = 2*5*365 + 3*30
'   seis años = 6*365 
'   dos lustros = 2*5*365
'   un decenio = 10*365
'   tres milenios, dos lustros y tres años = (3*1000 + 2*5+3)*365 
'

'================================================
' NUMERACIÓN TEMPORAL (COMPARTIDO)

Public Class NumeracionTemporal

    Private Shared _enLetras As NumeracionTemporalEnLetras = Nothing
    Private Shared _enCifras As NumeracionTemporalEnCifras = Nothing

    Public Shared Function ObtenerEnLetras(ByVal numero As Decimal) As String
        If _enLetras Is Nothing Then _enLetras = New NumeracionTemporalEnLetras()
        Return _enletras.Obtener(numero)
    End Function

    Public Shared Function ObtenerEnCifras(ByVal numero As Decimal) As String
        If _enCifras Is Nothing Then _enCifras = New NumeracionTemporalEnCifras()
        Return _enCifras.Obtener(numero)
    End Function

End Class

'================================================
' NUMERACIÓN TEMPORAL EN LETRAS

Public Class NumeracionTemporalEnLetras

    '--------------------------------------------
    ' INTERFAZ

    Public Function Obtener(ByVal numero As Decimal) As String
        Dim tiemposAños = ObtenerTiempo(numero \ 365, unidades_años, factores_años)
        Dim tiemposDias = ObtenerTiempo(numero Mod 365, unidades_dias, factores_dias)
        Dim texto = Unir(tiemposAños, tiemposDias, ", ")
        texto = ObtenerAbreviaturas().Reemplazar(texto)
        texto = InsertarConjuncion(texto)
        Return texto
    End Function

    Protected Function Unir(
        ByVal array1 As String(),
        ByVal array2 As String(),
        ByVal separador As String
    ) As String
        Dim union As IEnumerable(Of String) = array1.Union(array2)
        Dim lista As New List(Of String)
        For Each elemento In union
            lista.Add(elemento)
        Next
        Return Join(lista.ToArray(), separador)
    End Function

    Protected Function InsertarConjuncion(ByVal texto As String) As String
        Dim posicion = texto.LastIndexOf(", ")
        If posicion > 0 Then
            texto = texto.Remove(posicion, 2).Insert(posicion, " y ")
        End If
        Return texto
    End Function

    '--------------------------------------------
    ' IMPLEMENTACIÓN

    Shared unidades_dias As String() = {"día", "semana", "mes", "año"}
    Shared factores_dias As Integer() = {1, 7, 30, 365}

    Shared unidades_años As String() = {"año", "lustro", "década", "siglo", "milenio", "cron"}
    Shared factores_años As Integer() = {1, 5, 10, 100, 1000, 1000000}

    Protected Function ObtenerTiempo(
        ByVal numero As Decimal,
        ByVal unidades As String(),
        ByVal factores As Integer()
    ) As String()
        Dim resultado As New List(Of String)
        For indice = unidades.Length - 1 To 0 Step -1
            Dim factor = numero \ factores(indice)
            numero = numero Mod factores(indice)
            If factor > 0 Then
                Dim unidad = unidades(indice)
                resultado.Add(ObtenerCantidad(factor, unidad))
            End If
        Next
        Return resultado.ToArray()
    End Function

    '--------------------------------------------
    ' UTILIDADES

    Protected Overridable Function ObtenerCantidad(
        ByVal cantidad As Integer,
        ByVal unidad As String
    ) As String
        Dim resultado As String
        Dim cifras = ObtenerCifras(cantidad, EsFemenino(unidad))
        If cantidad = 1 Then
            resultado = cifras & " " & unidad
        Else
            resultado = cifras & " " & EnPlural(unidad)
        End If
        Return resultado
    End Function

    Protected Function ObtenerCifras(
       ByVal cantidad As Integer,
       ByVal enFemenino As Boolean
    ) As String
        If enFemenino Then
            Return CifrasEnLetras.convertirCifrasEnLetrasFemeninas(cantidad)
        Else
            Return CifrasEnLetras.convertirCifrasEnLetras(cantidad)
        End If
    End Function

    Protected Function EsFemenino(ByVal unidad As String) As Integer
        Return unidad = "semana" Or unidad = "década"
    End Function

    Protected Function EnPlural(ByVal texto As String) As String
        If AcabaEnVocal(texto) Then
            Return texto & "s"
        Else
            Return texto & "es"
        End If
    End Function

    Protected Function AcabaEnVocal(ByVal texto As String) As String
        Return "aeiou".Contains(texto(texto.Length - 1))
    End Function

    '--------------------------------------------
    ' ABREVIATURAS

    Private Shared _abreviaturas As AbreviaturasEnLetras = Nothing

    Protected Overridable Function ObtenerAbreviaturas() As AbreviaturasEnLetras
        If _abreviaturas Is Nothing Then
            _abreviaturas = New AbreviaturasEnLetras()
        End If
        Return _abreviaturas
    End Function

    Protected Class AbreviaturasEnLetras
        Inherits Dictionary(Of String, String)
        Public Sub New()
            Add("dos semanas, un día", "una quincena")
            Add("dos meses", "un bimestre")
            Add("tres meses", "un trimestre")
            Add("cuatro meses", "un cuatrimestre")
            Add("seis meses", "un semestre")
            Add("dos años", "un bienio")
            Add("tres años", "un trienio")
        End Sub
        Public Function Reemplazar(ByVal texto As String) As String
            Dim enumerador As IDictionaryEnumerator = Me.GetEnumerator()
            Do While enumerador.MoveNext()
                texto = texto.Replace(enumerador.Key, enumerador.Value)
            Loop
            Return texto
        End Function
    End Class

End Class

'================================================
' NUMERACIÓN TEMPORAL EN CIFRAS

Public Class NumeracionTemporalEnCifras
    Inherits NumeracionTemporalEnLetras

    Protected Overrides Function ObtenerCantidad(
        ByVal cantidad As Integer,
        ByVal unidad As String
    ) As String
        If cantidad = 1 Then
            Return cantidad & " " & unidad
        Else
            Return cantidad & " " & EnPlural(unidad)
        End If
    End Function

    '--------------------------------------------
    ' ABREVIATURAS

    Private Shared _abreviaturas As AbreviaturasEnCifras = Nothing

    Protected Overrides Function ObtenerAbreviaturas() As AbreviaturasEnLetras
        If _abreviaturas Is Nothing Then
            _abreviaturas = New AbreviaturasEnCifras()
        End If
        Return _abreviaturas
    End Function

    Protected Class AbreviaturasEnCifras
        Inherits AbreviaturasEnLetras
        Public Sub New()
            Add("2 semanas, 1 día", "1 quincena")
            Add("2 meses", "1 bimestre")
            Add("3 meses", "1 trimestre")
            Add("4 meses", "1 cuatrimestre")
            Add("6 meses", "1 semestre")
            Add("2 años", "1 bienio")
            Add("3 años", "1 trienio")
        End Sub
    End Class

End Class